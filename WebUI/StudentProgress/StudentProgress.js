
local.StudentProgressPageController = function (idPrefix) {

    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnImport = "#" + idPrefix + "_btnImport";
    var btnDownloadImport = "#" + idPrefix + "_btnDownloadImport";
    //var btnExport = "#" + idPrefix + "_btnExport";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";
    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchStudentCourseStatusType = "#" + idPrefix + "_selSearchStudentCourseStatusType";

    var searchShown = true;
    var SettingType;

    var selField1 = $("<select style=\"width:266px; padding: 3px 6px; margin-bottom:3px;\" />");
    var selCoaching = $("<select style=\"width:266px; padding: 3px 6px; margin-bottom:3px;\" />");

    this.Initialize = Initialize;
    function Initialize() {

        $(btnImport).button();
        $(btnDownloadImport).button();
        //$(btnExport).button();

        $(btnImport).click(function (event) {
            event.stopPropagation();
            buildImportDialog();
        });

        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.GenderType
        });

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.ContractType
        });

        $(selSearchStudentCourseStatusType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.StudentCourseStatusType
        });


        StudentProgressAjaxGateway.GetGlobalSetting(FlagCodes.GlobalSettingType.ReasonsForDeferment, function (resField) {
            selField1.dropdownSelect({
                nullValue: "",
                nullLabel: "- Please Select -",
                choices: teq.Common.DictionaryToArray(resField.value)
            });

           

        });

        //StudentProgressAjaxGateway.GetCoaching(function (resField) {
        //            selCoaching.dropdownSelect({
        //                nullValue: GuidEmpty,
        //                nullLabel: "- None -",
        //                choices: teq.Common.DictionaryToArray(resField.value)
        //            });

        //            //ctrl.Populate(res.value);
        //        });

        BuildSurfaceListing()

        if (!local.ValidatePermission(FlagCodes.PermissionType.StudentProgressEdit)) {
            $(btnImport).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.StudentProgressView)) {
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
            Name: "Student Progress List",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        
    }
    this.Shown = function () {

    }

    function BuildSurfaceListing() {
        $(txtSearchDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        teq.Common.SetDatePickerClearable($(txtSearchDateFrom));
        $(txtSearchDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        teq.Common.SetDatePickerClearable($(txtSearchDateTo));
        self.ListControlller = new teq.EntityListController();

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);

        self.ListControlller.btnPinSearch = $(btnPinSearch);

        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";

        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var startDate = $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var state = $(txtSearchState).val();
            var contractType = $(selSearchContractType).val();
            var StudentCourseStatusType = $(selSearchStudentCourseStatusType).val();
            StudentProgressAjaxGateway.GetStudentProgressList(startDate, endDate, fullname, gender, email, IC, state, contractType, StudentCourseStatusType, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >IC Number</td>");
            htr.append("<td >Institute</td>");
            htr.append("<td >Mobile Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Subject</td>");
            htr.append("<td >Sponsor</td>");
            htr.append("<td >Absent Count</td>");
            htr.append("<td >Latest Exam Score</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");
            htr.append("<td >Action</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();
            var HasPermission = local.ValidatePermission(FlagCodes.PermissionType.StudentProgressEdit);
            for (var i = 0; i < tbl.Rows.length; i++) {

                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.Application_FullName +  "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_CampusName + ", " + dr.TSP_City + "</td>"));
                tr.append(("<td align=center>" + dr.Application_MobilePhonePrefix + " - " + dr.Application_MobilePhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + dr.CourseSubject_Code + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor_Code + "</td>"));
                tr.append(("<td align=center>" + dr.Absent_Count + "</td>"));
                tr.append(("<td align=center>" + dr.LatestExamScore + "</td>"));
                tr.append(("<td align=center>" + FlagNames.StudentCourseStatusType[dr.StudentCourse_Status] + "</td>"));
                tr.append(buileEditTd(dr));

                if (dr.StudentCourse_Status != FlagCodes.StudentCourseStatusType.Active || !HasPermission) {
                    tr.append("<td align=center></td>");
                }
                else
                {
                    tr.append(buileActionTd(dr));
                }
            
                tbody.append(tr);

            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.StudentCourse_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var detLnk = $("<a href='javascript:void(0);'>Attn.</a>");
                detLnk.click(function (event) {
                    buildStudentProgressDialog(dr.StudentCourse_ID, dr.Application_FullName, dr.CourseSubject_Code);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "clipboard"), detLnk);

                var ExmLnk = $("<a href='javascript:void(0);'>Exam</a>");
                ExmLnk.click(function (event) {
                    buildStudentExamProgressDialog(dr.StudentCourse_ID, dr.Application_FullName, dr.CourseSubject_Code);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "script"), ExmLnk);

                

                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");
                var editLnk = $("<a href='javascript:void(0);'>Assign Coach</a>");
                editLnk.click(function (event) {
                    buildCoachingSurfaceDataDialog(dr.StudentCourse_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);



                var editLnk = $("<a href='javascript:void(0);'>Attachment</a>");
                editLnk.click(function (event) {
                    buildAttachmentSurfaceDataDialog(dr.StudentCourse_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //var editLnk = $("<a href='javascript:void(0);'>Edit / View Log</a>");
                //editLnk.click(function (event) {
                //    //buildSurfaceDataDialog("Edit");
                //    event.stopPropagation();
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //var editLnk = $("<a href='javascript:void(0);'>Terminate</a>");
                //editLnk.click(function (event) {
                //    event.stopPropagation();
                //    self.TerminateRecord(dr.StudentCourse_ID, dr.Application_FullName);
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), editLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }
        self.ListControlller.Initialize();

        {
            $(btnShowSearch_SpanIcon).append(SearchImageicon);
            $(btnShowSearch_SpanIcon).css("padding-right", "10px")
            $(btnShowSearch_SpanArrowIcon).append(ArrowImageicon);
        }
    }
    var Title = "Student Progress Detail";
    self.Title = Title;

    var tblBodyAttachment = $("<tbody>");
    function buildAttachmentSurfaceDataDialog(id) {
        var prop = $("<div title='Attachment'>");

        var divBtnAttachment = $("<div align='right'>");
        var btnAddAttachment = $("<button>Create New</button>");

        var divListAttachment = $("<div>");
        var divWrapAttachment = $("<div class='Wrap' style='width:99%;'>");
        var tblListAttachment = $("<table class='List'>");
        var tblHeaderAttachment = $("<thead>");
        var tblPagerAttachment = $("<table class='Pager'>");

        divBtnAttachment.append(btnAddAttachment);

        tblListAttachment.append(tblHeaderAttachment);
        tblListAttachment.append(tblBodyAttachment);
        divWrapAttachment.append(tblListAttachment);
        divWrapAttachment.append(tblPagerAttachment);
        divListAttachment.append(divWrapAttachment);

        prop.append(divBtnAttachment, "</br>", divListAttachment);

        $(btnAddAttachment).button();

        var htr = $("<tr></tr>");
        htr.append("<td >Name</td>");
        htr.append("<td >Remark</td>");

        htr.append("<td>Action</td>");

        tblHeaderAttachment.empty();
        tblHeaderAttachment.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 500);
        prop.dialog("option", "height", 450);
        prop.dialog('open');

        PopulateAttachmentGrid(id);

        function PopulateAttachmentGrid(id) {
            btnAddAttachment.click(function (event) {
                buildAttachmentDetailSurfaceDataDialog(null, id);
            })
            refreshItem(id);
        }
    }

    function refreshItem(id) {
        StudentProgressAjaxGateway.GetAttachmentList(id, function (entity) {
            
            tblBodyAttachment.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entAttachment = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + entAttachment.StudentCourseAttachment_Name + "</td>"));
                tr.append(("<td align=center>" + entAttachment.StudentCourseAttachment_Remark + "</td>"));
                tr.append(buileEditTd(entAttachment));
                tblBodyAttachment.append(tr);
            }

            function buileEditTd(entAttachment) {
                var actionTd = $("<td align=center/>");

                var downloadLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Edit / View</a>");


                if (entAttachment.StudentCourseAttachment_OriginalFileName != "") {
                    downloadLnk.text("Download");
                    downloadLnk.attr("href", "/UserFiles/StudentCourseAttachment/" + entAttachment.StudentCourseAttachment_ID + "/" + entAttachment.StudentCourseAttachment_PhysicalFileName);
                    downloadLnk.attr("download", entAttachment.StudentCourseAttachment_OriginalFileName);

                    actionTd.append(teq.Common.ThemeIcon("active", "disk"), downloadLnk);
                }
        

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildAttachmentDetailSurfaceDataDialog(entAttachment.StudentCourseAttachment_ID, entAttachment.StudentCourse_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteAttachment(entAttachment.StudentCourseAttachment_ID, entAttachment.StudentCourseAttachment_Name, entAttachment.StudentCourse_ID);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        });
    }

    function buildAttachmentDetailSurfaceDataDialog(StudentCourseAttachment_ID, StudentCourse_ID) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 600;

        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists.");
                    ctrl.Close();
                }
                else ctrl.Populate(res.value);
            }
            else ctrl.Close();
        }

        if (StudentCourseAttachment_ID == null) {
            ctrl.LoadDelegate = function () {
                StudentProgressAjaxGateway.NewAttachment(StudentCourse_ID,populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                StudentProgressAjaxGateway.GetAttachment(StudentCourseAttachment_ID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressAjaxGateway.SaveAttachment(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) refreshItem(StudentCourse_ID);//self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Attachment";
            if (entity.Entity.StudentCourseAttachment_ID != GuidEmpty) title = "Editing \"" + entity.Entity.StudentCourseAttachment_Name + "\"";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Attachment Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();

                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.StudentCourseAttachment_Name;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.StudentCourseAttachment_Name = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remark";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Entity.StudentCourseAttachment_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Entity.StudentCourseAttachment_Remark = val;
                    }
                    //prop.ValidationDelegate = function (val, callback) {
                    //    CodeManagementAjaxGateway.VerifyName(val, callback);
                    //}
                    sec.Properties.push(prop);
                }
                {
                    var downloadLnk1 = $("<a download='' href=''></a>");
                    var inputWidth = "150px";
                    var prop = new teq.EntityProperty();
                    prop.Label = "Attachment";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertyradio");
                        element.append(downloadLnk1);
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif", "docx", "doc", "xlsx", "xls","pptx","ppt"], null);
                        jqUploadDocument = element;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                    }
                    prop.GetValueDelegate = function (entity) {
                        if (entity.Entity.StudentCourseAttachment_OriginalFileName != null)
                        {
                            downloadLnk1.text(entity.Entity.StudentCourseAttachment_OriginalFileName);
                            downloadLnk1.attr("href", "/UserFiles/StudentCourseAttachment/" + entity.Entity.StudentCourseAttachment_ID + "/" + entity.Entity.StudentCourseAttachment_PhysicalFileName);
                            downloadLnk1.attr("download", entity.Entity.StudentCourseAttachment_OriginalFileName);
                        }
         

        
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.Attachment = val;
                    }
                    sec.Properties.push(prop);
                }
    
            }

            ctrl.Initialize();
        }
    }

    this.DeleteAttachment = function (id, name, StudentCourse_ID) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {

            StudentProgressAjaxGateway.DeleteAttachment(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        refreshItem(StudentCourse_ID);
                        teq.Context.ToastTape("Record deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }

    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                //StudentProgressAjaxGateway.NewStudentProgress(populateDel);
                StudentProgressAjaxGateway.NewStudentProgress(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                //StudentProgressAjaxGateway.GetStudentProgress(id, populateDel);
                StudentProgressAjaxGateway.GetStudentProgress(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            ctrl.Populate(res.value);

                            
                            if (res.value.StudentCourse_Status == FlagCodes.StudentCourseStatusType.Completed || !local.ValidatePermission(FlagCodes.PermissionType.StudentProgressEdit)) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }
                        }
                    }
                    else ctrl.Close();
                });
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressAjaxGateway.SaveStudentCourse(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                }
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Application";
            if (entity.StudentCourse_ID != GuidEmpty) title = "Editing \"" + entity.Application_FullName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var inputWidth = "180px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Student Progress Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                sec.Name = "";

                grp.Sections.push(sec);


                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_FullName;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "D.O.B.";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return teq.Common.FormatDate(entity.Application_DOB);
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Gender";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return FlagNames.GenderType[entity.Application_Gender];
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Nationality";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return FlagNames.NationalityType[entity.Application_Nationality];
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_IdentificationNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_PhonePrefix + " " + entity.Application_PhoneNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_MobilePhonePrefix + " " + entity.Application_MobilePhoneNumber;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr("readonly", "readonly");
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.Application_Email;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                    };
                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            choices: Enums.StudentCourseStatusType
                        });
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.StudentCourse_Status;
                    };
                    prop.SetValueDelegate = function (entity, val) {
                        entity.StudentCourse_Status = val;
                    };

                    sec.Properties.push(prop);
                }

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Deferment Reason";

                    prop.Input = new teq.EntityCustomInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append(selField1);
                    };
                    prop.GetValueDelegate = function (entity) {
                        selField1.val(entity.StudentCourse_DefermentReason);
                        return entity.StudentCourse_DefermentReason;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.StudentCourse_DefermentReason = selField1.val();
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.StudentCourse_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.StudentCourse_Remark = val;
                    }
                    sec.Properties.push(prop);
                }
            }


            //var grp = new teq.EntityPropertiesGroup();
            //grp.Name = "Coaching";
            //ctrl.Groups.push(grp);
            //{
            //    var sec = new teq.EntityPropertiesFormSection();
            //    sec.Name = "Detail";

            //    grp.Sections.push(sec);

            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "Coaching";

            //        prop.Input = new teq.EntityCustomInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            element.append(selCoaching);
            //            element.width(inputWidth);
            //        };
            //        prop.GetValueDelegate = function (entity) {
            //            selCoaching.val(entity.Coaching_UserAccount_ID);
            //            return entity.Coaching_UserAccount_ID;
            //        }
            //        prop.SetValueDelegate = function (entity, val) {
            //            entity.Coaching_UserAccount_ID = selCoaching.val();
            //        }
            //        sec.Properties.push(prop);
            //    }
            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "Coaching Description";
            //        prop.Input = new teq.EntityTextareaInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            element.width(inputWidth);
            //        };
            //        prop.GetValueDelegate = function (entity) {
            //            return entity.Coaching_Description;
            //        }
            //        prop.SetValueDelegate = function (entity, val) {
            //            entity.Coaching_Description = val;
            //        }
            //        sec.Properties.push(prop);
            //    }
            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "Coaching Remarks";
            //        prop.Input = new teq.EntityTextareaInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            element.width(inputWidth);
            //        };
            //        prop.GetValueDelegate = function (entity) {
            //            return entity.Coaching_Remark;
            //        }
            //        prop.SetValueDelegate = function (entity, val) {
            //            entity.Coaching_Remark = val;
            //        }
            //        sec.Properties.push(prop);
            //    }
            //}

            //var grp = new teq.EntityPropertiesGroup();
            //grp.Name = "Attachment";
            //ctrl.Groups.push(grp);
            //{
            //    sec = new teq.EntityPropertiesFormSection();

            //    grp.Sections.push(sec);
            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "File 1";
            //        prop.Input = new teq.EntitySingleFileUploadInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png"], null);
            //        }
            //        prop.ValidationDelegate = function (val, callback) {
            //        }
            //        prop.SetValueDelegate = function (entity, val) {

            //        }
            //        sec.Properties.push(prop);
            //    }

            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "File 2";
            //        prop.Input = new teq.EntitySingleFileUploadInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png"], null);
            //        }
            //        prop.ValidationDelegate = function (val, callback) {
            //        }
            //        prop.SetValueDelegate = function (entity, val) {

            //        }
            //        sec.Properties.push(prop);
            //    }
            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "File 3";
            //        prop.Input = new teq.EntitySingleFileUploadInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png"], null);
            //        }
            //        prop.ValidationDelegate = function (val, callback) {
            //        }
            //        prop.SetValueDelegate = function (entity, val) {

            //        }
            //        sec.Properties.push(prop);
            //    }
            //    {
            //        var prop = new teq.EntityProperty();
            //        prop.Label = "File 4";
            //        prop.Input = new teq.EntitySingleFileUploadInput();
            //        prop.Input.BuildElementDelegate = function (element) {
            //            teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png"], null);
            //        }
            //        prop.ValidationDelegate = function (val, callback) {
            //        }
            //        prop.SetValueDelegate = function (entity, val) {

            //        }
            //        sec.Properties.push(prop);
            //    }

            //}
        }

        ctrl.Initialize();
    }

    function buildCoachingSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;
        var jqCoaching = null;
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {

                    StudentProgressAjaxGateway.GetCoaching(function (resField) {
                                //selCoaching.dropdownSelect({
                                //    nullValue: GuidEmpty,
                                //    nullLabel: "- None -",
                                //    choices: teq.Common.DictionaryToArray(resField.value)
                                //});
                        jqCoaching.dropdownSelect("option", "choices", teq.Common.DictionaryToArray(resField.value));
                                ctrl.Populate(res.value);
                            });
                  
                    //ctrl.Populate(res.value);

                    //if (res.value.StudentCourse_Status == FlagCodes.StudentCourseStatusType.Completed) {

                    //    $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                    //}
                }
            }
            else ctrl.Close();
        }
        if (id == null) {
            ctrl.LoadDelegate = function () {
                StudentProgressAjaxGateway.NewStudentProgress(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                StudentProgressAjaxGateway.GetStudentProgress(id, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressAjaxGateway.SaveCoaching(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                }
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Application";
            if (entity.StudentCourse_ID != GuidEmpty) title = "Assign Coach for \"" + entity.Application_FullName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            {
                var grp = new teq.EntityPropertiesGroup();
                grp.Name = "";
                ctrl.Groups.push(grp);
                {
                    var sec = new teq.EntityPropertiesFormSection();
                    sec.Name = "";

                    grp.Sections.push(sec);

                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Coach";

                        //prop.Input = new teq.EntityCustomInput();
                        //prop.Input.BuildElementDelegate = function (element) {
                        //    element.append(selCoaching);
                        //    element.addClass("property");
                        //};
                        prop.Input = new teq.EntityDropdownSelectInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                            element.dropdownSelect(
                            {
                                nullLabel: "- None -",
                                nullValue: GuidEmpty
                            });

                            jqCoaching = element;
                        };

                        prop.GetValueDelegate = function (entity) {
                           // selCoaching.val(entity.Coaching_UserAccount_ID);
                            // return entity.Coaching_UserAccount_ID;
                            //selCoaching.val(GuidEmpty);
                            return GuidEmpty;
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            //entity.Coaching_UserAccount_ID = selCoaching.val();
                            entity.Coaching_UserAccount_ID = val;
                        }
                        sec.Properties.push(prop);
                    }
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Coaching Description";
                        prop.Input = new teq.EntityTextareaInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                        };
                        prop.GetValueDelegate = function (entity) {
                            // return entity.Coaching_Description;
                            return "";
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Coaching_Description = val;
                        }
                        sec.Properties.push(prop);
                    }
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Coaching Remarks";
                        prop.Input = new teq.EntityTextareaInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                        };
                        prop.GetValueDelegate = function (entity) {
                            // return entity.Coaching_Remark;
                            return "";
                        }
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Coaching_Remark = val;
                        }
                        sec.Properties.push(prop);
                    }
                }
            }

            ctrl.Initialize();
        }

    }

    var tblBodySubject = $("<tbody>");
    function buildStudentProgressDialog(StudentCourse_ID, Name, Code) {
        var prop = $("<div title=\"" + Name + " (" + Code + ") Attendance History\">");

        var divBtnSubject = $("<div align='right'>");

        var divListSubject = $("<div>");
        var divWrapSubject = $("<div class='Wrap' style='width:99%;'>");
        var tblListSubject = $("<table class='List'>");
        var tblHeaderSubject = $("<thead>");
        var tblPagerSubject = $("<table class='Pager'>");

        tblListSubject.append(tblHeaderSubject);
        tblListSubject.append(tblBodySubject);
        divWrapSubject.append(tblListSubject);
        divWrapSubject.append(tblPagerSubject);
        divListSubject.append(divWrapSubject);

        prop.append(divBtnSubject, "</br>", divListSubject);


        var htr = $("<tr></tr>");
        htr.append("<td >Month</td>");
        htr.append("<td >Total Class</td>");
        htr.append("<td >Attended Class</td>");

        tblHeaderSubject.empty();
        tblHeaderSubject.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 500);
        prop.dialog("option", "height", 250);
        prop.dialog('open');

        PopulateSubjectGrid(StudentCourse_ID);

        function PopulateSubjectGrid(id) {
            refreshItemAttendance(id);
        }
    }
    function refreshItemAttendance(id) {
            StudentProgressAjaxGateway.GetAttendanceHistory(id, function (entity) {

                tblBodySubject.empty();

                for (var i = 0; i < entity.value.length; i++) {
                    var entAttendance = entity.value[i];
                    var tr = $("<tr></tr>");
                    tr.append(("<td align=center>" + entAttendance.AttendanceDate + "</td>"));
                    tr.append(("<td align=center>" + entAttendance.TotalClass + "</td>"));
                    tr.append(("<td align=center>" + entAttendance.AttendedClass + "</td>"));
                    tblBodySubject.append(tr);
                }
            });
    }

    var tblBodyExam = $("<tbody>");
    function buildStudentExamProgressDialog(StudentCourse_ID, Name, Code) {
        var prop = $("<div title=\"" + Name + " (" + Code + ") Exam History\">");

        var divBtnSubject = $("<div align='right'>");

        var divListSubject = $("<div>");
        var divWrapSubject = $("<div class='Wrap' style='width:99%;'>");
        var tblListSubject = $("<table class='List'>");
        var tblHeaderSubject = $("<thead>");
        var tblPagerSubject = $("<table class='Pager'>");

        tblListSubject.append(tblHeaderSubject);
        tblListSubject.append(tblBodyExam);
        divWrapSubject.append(tblListSubject);
        divWrapSubject.append(tblPagerSubject);
        divListSubject.append(divWrapSubject);

        prop.append(divBtnSubject, "</br>", divListSubject);


        var htr = $("<tr></tr>");
        htr.append("<td >Exam Date</td>");
        htr.append("<td >Exam Score</td>");
        htr.append("<td >Is Final</td>");

        tblHeaderSubject.empty();
        tblHeaderSubject.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 500);
        prop.dialog("option", "height", 250);
        prop.dialog('open');

        PopulateSubjectGrid(StudentCourse_ID);

        function PopulateSubjectGrid(id) {
            refreshExamItem(id);
        }
    }
    function refreshExamItem(id) {
        StudentProgressAjaxGateway.GetExamHistory(id, function (entity) {

            tblBodyExam.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entAttendance = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + entAttendance.ExamDate + "</td>"));
                tr.append(("<td align=center>" + entAttendance.ExamScore + "</td>"));
                tr.append(("<td align=center>" + entAttendance.IsFinal + "</td>"));
                tblBodyExam.append(tr);
            }
        });
    }

    this.TerminateRecord = function (id, fullname) {
        StudentProgressAjaxGateway.VerifyTerminatedStudent(id, function (res) {
            if (res.error == null) {
                if (res.value.Code == teq.Context.SuccessErrorCode) {
                    var msg = "Terminate Student:<br><br>\"" + fullname + "\"<br><br>Are you sure?";
                    teq.Context.Confirm(msg, function () {
                        StudentProgressAjaxGateway.TerminateStudent(id, function (res) {
                            if (res.error == null) {
                                if (res.value.Code == teq.Context.SuccessErrorCode) {
                                    self.ListControlller.RefreshList();
                                    teq.Context.ToastTape("Student is terminated.");
                                }
                                else teq.Context.Alert(res.value.Name);
                            }
                        });
                    });
                }
                else teq.Context.Alert(res.value.Name);
            }
        });
    }

    function buildImportDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 450;
        var jqUploadFile = null;
        ctrl.LoadDelegate = function () {
            StudentProgressAjaxGateway.NewImport(function (res) {
                if (res.error == null) {
                    if (res.value == null) {
                        teq.Context.Alert("Selected record no longer exists.");
                        ctrl.Close();
                    }
                    else {
                        ctrl.Populate(res.value);
                    }
                }
            });
        }
        ctrl.SaveDelegate = function (entity, callback) {
            StudentProgressAjaxGateway.Import(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    jqUploadFile.Reset();
                }
            });

        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Import Student Progress";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var inputWidth = "250px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = " ";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "File";
                    prop.Input = new teq.EntitySingleFileUploadInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        teq.Common.BuildSingleFileUploadInput(element, inputWidth, "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["xlsx"], null);
                        jqUploadFile = element;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.UploadFile = val;
                    }
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }
}