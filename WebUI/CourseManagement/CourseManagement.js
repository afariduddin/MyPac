local.CourseManagementPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnNew = "#" + idPrefix + "_btnNew";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var txtSearchName = "#" + idPrefix + "_txtSearchName";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing()
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.CourseManagement)) {
            teq.Context.Alert("You do not have sufficient permission to the page you are trying to access.<br />Please contact your system administrator for further information.");
            teq.Context.ShowPage(local.aspxContent_Dashboard1);
        }

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Course Management",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }
    function BuildSurfaceListing() {
        self.ListControlller = new teq.EntityListController();

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        self.ListControlller.btnNew = $(btnNew);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
   
        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var name = $(txtSearchName).val();
            CourseManagementAjaxGateway.GetCourseList(name, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No.</td>");
            htr.append("<td >Course Code</td>");
            htr.append("<td >Course Name</td>");
            htr.append("<td >Created Date</td>");
            htr.append("<td >Created By</td>");
            htr.append("<td >Available</td>");

            htr.append("<td  width='200px'>View</td>");
            htr.append("<td>Action</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

            function headerCol(colName) {
                var td = $("<td/>");
                var a = $("<a href='javascript:void(0);'>" + colName + "</a>");
                td.append(a);
                return td;
            }
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Course_Code + "</td>"));
                tr.append(("<td align=center>" + dr.Course_Name + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.Course_CreatedDate) + "</td>"));
                tr.append(("<td align=center>" + dr.Course_CreatedBy + "</td>"));
                tr.append(("<td align=center>" + (dr.Course_ApplicableForApply ? "Yes" : "No") + "</td>"));
                tr.append(buileEditTd(dr));
                tr.append(buileActionTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Course_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.Course_ID, dr.Course_Name);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");
                var editLnk = $("<a href='javascript:void(0);'>Course Subject</a>");
                editLnk.click(function (event) {
                    buildCourseSubjectSurfaceDataDialog(dr.Course_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "newwin"), editLnk);
                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = 'Course Management';
    self.Title = Title;

    var tblBodySubject = $("<tbody>");
    function buildCourseSubjectSurfaceDataDialog(id)
    {
        var prop = $("<div title='Course Subject'>");

        var divBtnSubject = $("<div align='right'>");
        var btnAddSubject = $("<button>Create New</button>");

        var divListSubject = $("<div>");
        var divWrapSubject = $("<div class='Wrap' style='width:99%;'>");
        var tblListSubject = $("<table class='List'>");
        var tblHeaderSubject = $("<thead>");
        var tblPagerSubject = $("<table class='Pager'>");

        divBtnSubject.append(btnAddSubject);

        tblListSubject.append(tblHeaderSubject);
        tblListSubject.append(tblBodySubject);
        divWrapSubject.append(tblListSubject);
        divWrapSubject.append(tblPagerSubject);
        divListSubject.append(divWrapSubject);

        prop.append(divBtnSubject, "</br>", divListSubject);

        $(btnAddSubject).button();

        var htr = $("<tr></tr>");
        htr.append("<td >Subject Code</td>");
        htr.append("<td >Subject Name</td>");

        htr.append("<td>Action</td>");

        tblHeaderSubject.empty();
        tblHeaderSubject.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 500);
        prop.dialog("option", "height", 450);
        prop.dialog('open');

        PopulateSubjectGrid(id);

        function PopulateSubjectGrid(id) {
            btnAddSubject.click(function (event) {
                buildSubjectSurfaceDataDialog(id, null);
            })
            refreshItem(id);
        }
    }

    function refreshItem(id) {
        CourseManagementAjaxGateway.GetSubject(id, function (entity) {

            tblBodySubject.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entSubject = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + entSubject.CourseSubject_Code + "</td>"));
                tr.append(("<td align=center>" + entSubject.CourseSubject_Name + "</td>"));
                tr.append(buileEditTd(entSubject));
                tblBodySubject.append(tr);
            }

            function buileEditTd(entSubject) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSubjectSurfaceDataDialog(entSubject.Course_ID, entSubject.CourseSubject_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteCourseSubject(entSubject.CourseSubject_ID, entSubject.CourseSubject_Name, entSubject.Course_ID);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        });
    }

    function buildSubjectSurfaceDataDialog(CourseID, SubjectID) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 600;

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }

        if (SubjectID == null) {
            ctrl.LoadDelegate = function () {
                CourseManagementAjaxGateway.NewCourseSubject(CourseID, populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CourseManagementAjaxGateway.GetCourseSubject(SubjectID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            CourseManagementAjaxGateway.SaveCourseSubject(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) refreshItem(CourseID);//self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Course Subject";
            if (entity.CourseSubject_ID != GuidEmpty) title = "Editing \"" + entity.CourseSubject_Code + "\"";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Course Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Subject Code";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();

                    if (SubjectID == null){
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                        };
                    }
                    else {
                        prop.Input.BuildElementDelegate = function (element) {
                            element.prop("readonly", true);
                            element.addClass("property");
                        };
                    }

                    prop.GetValueDelegate = function (entity) {
                        return entity.CourseSubject_Code;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CourseSubject_Code = val;
                    }
                    if (SubjectID == null) {
                        //prop.ValidationDelegate = function (val, callback) {
                            
                        //}
                    }
                    else prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Subject Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CourseSubject_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CourseSubject_Name = val;
                    }
                    //prop.ValidationDelegate = function (val, callback) {
                    //    CodeManagementAjaxGateway.VerifyName(val, callback);
                    //}
                    sec.Properties.push(prop);
                }            
            }

            ctrl.Initialize();
        }
    }
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

        var jqTSP = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value.Entity == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else {
                    jqTSP.checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value.TSP));
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }

        if (id == null) {
            ctrl.LoadDelegate = function () {
                CourseManagementAjaxGateway.NewCourse(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CourseManagementAjaxGateway.GetCourse(id, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            CourseManagementAjaxGateway.SaveCourse(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Course";
            if (entity.Entity.Course_ID != GuidEmpty) {
                title = "Editing \"" + entity.Entity.Course_Name + "\"";
            }
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }
        //#region Group: General
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Course Detail";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 500;
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                //#region Code
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Course Code";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    
                    if (id == null) {
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                        };
                    }
                    else {
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                            element.prop("readonly", true);
                        };
                    }

                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Course_Code;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Course_Code = val;
                    }
                    if (id == null) {
                        prop.ValidationDelegate = function (val, callback) {
                            CourseManagementAjaxGateway.VerifyCode(val, callback);
                        }
                    }
                    else prop.ValidationDelegate = null;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Course Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Course_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Course_Name = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        CourseManagementAjaxGateway.VerifyName(val, callback);
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Campus
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Available Campus";
                    prop.Input = new teq.EntityCheckboxListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.checkboxList({
                            columns: 1,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });

                        jqTSP = element;
                    }

                    prop.GetValueDelegate = function (entity) {
                        return entity.SelectedTSP;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.SelectedTSP = val;
                    }

                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Available: 
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Available";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.radioButtonList({
                            choices: Enums.YesNoType,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }
                    prop.AssociatedErrors = [];
                    prop.GetValueDelegate = function (entity) {
                        //return entity.Entity.Course_ApplicableForApply;
                        if (entity.Entity.Course_ApplicableForApply)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        //entity.Entity.Course_ApplicableForApply = val;

                        if (val == FlagCodes.YesNoType.Yes)
                            entity.Entity.Course_ApplicableForApply = true;
                        else
                            entity.Entity.Course_ApplicableForApply = false;
                    }
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Remarks
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";
                    prop.MarkCompulsary = false;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.Course_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.Course_Remark = val;
                    }
                    //prop.ValidationDelegate = function (val, callback) {
                    //    CodeManagementAjaxGateway.VerifyName(val, callback);
                    //}
                    sec.Properties.push(prop);
                }
                //#endregion
            }
            //#endregion                

            //var grp = new teq.EntityPropertiesGroup();
            //grp.Name = "Course Subject";
            //ctrl.Groups.push(grp);
            //{
            //    var sec = new teq.EntityPropertiesCustomSection();
            //    grp.Sections.push(sec);

            //    var divBtnSubject = $("<div align='right'>");
            //    var btnAddSubject = $("<button>Create New</button>");

            //    var divListSubject = $("<div>");
            //    var divWrapSubject = $("<div class='Wrap' style='width:99%;'>");
            //    var tblListSubject = $("<table class='List'>");
            //    var tblHeaderSubject = $("<thead>");
            //    var tblBodySubject = $("<tbody>");
            //    var tblPagerSubject = $("<table class='Pager'>");

            //    sec.BuildContentDelegate = function (element) {

            //        divBtnSubject.append(btnAddSubject);

            //        tblListSubject.append(tblHeaderSubject);
            //        tblListSubject.append(tblBodySubject);
            //        divWrapSubject.append(tblListSubject);
            //        divWrapSubject.append(tblPagerSubject);
            //        divListSubject.append(divWrapSubject);

            //        element.append(divBtnSubject, "</br>",divListSubject);

            //        $(btnAddSubject).button();

            //        var htr = $("<tr></tr>");
            //        htr.append("<td >Subject Code</td>");
            //        htr.append("<td >Subject Name</td>");

            //        htr.append("<td  width='200px'>Action</td>");

            //        tblHeaderSubject.empty();
            //        tblHeaderSubject.append(htr);
            //    }
            //    sec.PopulateContentDelegate = function (entity) {
            //        btnAddSubject.click(function (event) {
            //            buildSubjectSurfaceDataDialog(entity.Entity.Course_ID, null);
            //        })

            //    tblBodySubject.empty();

            //        for (var i = 0; i < entity.EntitySubject.length; i++) {
            //            var entSubject = entity.EntitySubject[i];
            //            var tr = $("<tr></tr>");
            //            tr.append(("<td align=center>" + entSubject.CourseSubject_Code + ".</td>"));
            //            tr.append(("<td align=center>" + entSubject.CourseSubject_Cod + "</td>"));
            //            tr.append(buileEditTd(entSubject));
            //            tblBodySubject.append(tr);
            //        }

            //        function buileEditTd(entSubject) {
            //            var actionTd = $("<td align=center/>");

            //            var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
            //            editLnk.click(function (event) {
            //                buildSubjectSurfaceDataDialog(entSubject.Course_ID, entSubject.CourseSubject_ID);
            //                event.stopPropagation();
            //            });
            //            actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

            //            var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
            //            delLnk.click(function (event) {
            //                event.stopPropagation();
            //                //self.DeleteRecord(dr.Course_ID, dr.Course_Name);
            //            });
            //            actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

            //            return actionTd;
            //        }
            //    }
            //}
            //sec.CollectContentDelegate = function (entity) {
            //}
        }

        ctrl.Initialize();
    }

    this.DeleteRecord = function (id, name) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {

            CourseManagementAjaxGateway.DeleteCourse(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Record deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }

    this.DeleteCourseSubject = function (id, name, CourseID) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {

            CourseManagementAjaxGateway.DeleteCourseSubject(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        refreshItem(CourseID);
                        teq.Context.ToastTape("Record deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }
}