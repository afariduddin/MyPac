local.CoachingManagementPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var divSearch = "#" + idPrefix + "_divSearch";
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

    var searchShown = true;
    var SettingType;

    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchIC = "#" + idPrefix + "_txtSearchIC";
    var txtSearchState = "#" + idPrefix + "_txtSearchState";
    var txtSearchAssessmentDateFrom = "#" + idPrefix + "_txtSearchAssessmentDateFrom";
    var txtSearchAssessmentDateTo = "#" + idPrefix + "_txtSearchAssessmentDateTo";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";

    this.Initialize = Initialize;
    function Initialize() {
        $(txtSearchAssessmentDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchAssessmentDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ContractType
        });
        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.CoachingStatusType
        });
        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

        BuildSurfaceListing()
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.CounsellingView)) {
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
            Name: "Counselling / Mentoring List",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }

    this.Shown = function () {
    }
    
    function BuildSurfaceListing() {

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

            var FullName = $(txtSearchFullName).val();
            var Gender = $(selSearchGender).val();
            var Email = $(txtSearchEmail).val();
            var IC = $(txtSearchIC).val();
            var State = $(txtSearchState).val();
            var DateFrom = $(txtSearchAssessmentDateFrom).val();
            var DateTo = $(txtSearchAssessmentDateTo).val();
            var ContractType = $(selSearchContractType).val();
            var Status = $(selSearchStatus).val();

            CoachingManagementAjaxGateway.GetCoachingListing(FullName, Gender, Email, IC, State, DateFrom, DateTo, ContractType, Status, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >IC Number</td>");
            htr.append("<td >Institute</td>");
            htr.append("<td >Contact Number</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Subject</td>");
            htr.append("<td >Description</td>");
            htr.append("<td >Coach</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");
            htr.append("<td >Action</td>");

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
                tr.append(("<td align=center>" + dr.Application_FullName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_IdentificationNumber + "</td>"));
                tr.append(("<td align=center>" + dr.TSP_CampusName + "</td>"));
                tr.append(("<td align=center>" + dr.Application_MobilePhonePrefix + "-" + dr.Application_MobilePhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Application_Email + "</td>"));
                tr.append(("<td align=center>" + dr.CourseSubject_Code + ": " + dr.CourseSubject_Name + "</td>"));
                tr.append(("<td align=center>" + dr.Coaching_Description + "</td>"));
                tr.append(("<td align=center>" + dr.UserAccount_FullName + "</td>"));
                tr.append(("<td align=center>" + FlagNames.CoachingStatusType[dr.Coaching_Status] + "</td>"));
                tr.append(buileEditTd(dr));
                tr.append(buileActionTd(dr));
                tbody.append(tr);

            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.Coaching_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                return actionTd;
            }

            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");
                var lnkViewLog = $("<a href='javascript:void(0);'>Log</a>");
                lnkViewLog.click(function (event) {
                    var lock = false;
                    if (dr.Coaching_Status == FlagCodes.CoachingStatusType.Closed || !local.ValidatePermission(FlagCodes.PermissionType.CounsellingEdit))
                        lock = true;

                    buildLogSurfaceDataDialog(dr.Coaching_ID, lock);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "clipboard"), lnkViewLog);

                if (dr.Coaching_Status != FlagCodes.CoachingStatusType.Closed && local.ValidatePermission(FlagCodes.PermissionType.CounsellingEdit)) {
                    var editLnk = $("<a href='javascript:void(0);'>Close Case</a>");
                    editLnk.click(function (event) {
                        self.CloseCase(dr.Coaching_ID, dr.Application_FullName);
                        event.stopPropagation();
                    });
                    actionTd.append(teq.Common.ThemeIcon("active", "close"), editLnk);
                }

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Student Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 600;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                CoachingManagementAjaxGateway.NewCoachingDetail(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CoachingManagementAjaxGateway.GetCoachingDetail(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            if (res.value.Coaching_Status == FlagCodes.CoachingStatusType.Closed || !local.ValidatePermission(FlagCodes.PermissionType.CounsellingEdit)) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true).addClass("ui-state-disabled");
                            }

                            ctrl.Populate(res.value);
                        }
                    }
                    else ctrl.Close();
                });
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            CoachingManagementAjaxGateway.SaveCoaching(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Counselling / Mentoring Case";
            if (entity.AssessmentResult_ID != GuidEmpty) title = "Editing \"" + entity.Application_FullName + "\"";
            return title;
        };
        
        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Counselling / Mentoring Detail";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                    var sec = new teq.EntityPropertiesFormSection();
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
                        prop.Label = "Description";
                        //prop.MarkCompulsary = true;
                        prop.Input = new teq.EntityTextareaInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                            element.attr("readonly", "readonly");
                        };
                        prop.GetValueDelegate = function (entity) {
                            return entity.Coaching_Description;
                        };
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Coaching_Description = val;
                        };
                        sec.Properties.push(prop);
                    }
                    {
                        var prop = new teq.EntityProperty();
                        prop.Label = "Remarks";
                        //prop.MarkCompulsary = true;
                        prop.Input = new teq.EntityTextareaInput();
                        prop.Input.BuildElementDelegate = function (element) {
                            element.addClass("property");
                            element.attr("readonly", "readonly");
                        };
                        prop.GetValueDelegate = function (entity) {
                            return entity.Coaching_Remark;
                        };
                        prop.SetValueDelegate = function (entity, val) {
                            entity.Coaching_Remark = val;
                        };
                        sec.Properties.push(prop);
                    }
            }
        }
        ctrl.Initialize();
    }
    
    function buildLogSurfaceDataDialog(id, isLocked) {
        var prop = $("<div title='Coaching / Mentoring Log'>");

        var divBtnLog = $("<div align='right'>");
        var btnAddLog = $("<button>Create New</button>");

        var divListLog = $("<div>");
        var divWrapLog = $("<div class='Wrap' style='width:99%;'>");
        var tblListLog = $("<table class='List'>");
        var tblHeaderLog = $("<thead>");
        var tblPagerLog = $("<table class='Pager'>");

        if (!isLocked)
            divBtnLog.append(btnAddLog);

        tblListLog.append(tblHeaderLog);
        tblListLog.append(tblBodyLog);
        divWrapLog.append(tblListLog);
        divWrapLog.append(tblPagerLog);
        divListLog.append(divWrapLog);

        prop.append(divBtnLog, "</br>", divListLog);

        $(btnAddLog).button();

        var htr = $("<tr></tr>");
        htr.append("<td >Date</td>");
        htr.append("<td >Description</td>");
        htr.append("<td >Remark</td>");

        htr.append("<td>Action</td>");

        tblHeaderLog.empty();
        tblHeaderLog.append(htr);

        prop.dialog();
        prop.dialog("option", "width", 800);
        prop.dialog('open');

        PopulateLogGrid(id);

        function PopulateLogGrid(id) {
            btnAddLog.click(function (event) {
                buildLogPropertySurfaceDataDialog(id, null);
            })
            refreshItem(id, isLocked);
        }
    }

    var tblBodyLog = $("<tbody>");
    function refreshItem(id, isLocked) {
        CoachingManagementAjaxGateway.GetCoachingItemListing(id, function (entity) {
            tblBodyLog.empty();

            for (var i = 0; i < entity.value.length; i++) {
                var entCoachingItem = entity.value[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(entCoachingItem.CoachingItem_Date) + "</td>"));
                tr.append(("<td align=center>" + entCoachingItem.CoachingItem_Description + "</td>"));
                tr.append(("<td align=center>" + entCoachingItem.CoachingItem_Remark + "</td>"));
                if (!isLocked)
                    tr.append(buileEditTd(entCoachingItem));
                else
                    tr.append("<td></td>");
                tblBodyLog.append(tr);
            }

            function buileEditTd(entCoachingItem) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildLogPropertySurfaceDataDialog(entCoachingItem.Coaching_ID, entCoachingItem.CoachingItem_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a style='color:#00F;' href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteCoachingItem(entCoachingItem.CoachingItem_ID, teq.Common.FormatDateTime(entCoachingItem.CoachingItem_Date), entCoachingItem.Coaching_ID);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        });
    }

    function buildLogPropertySurfaceDataDialog(Coaching_ID, CoachingItem_ID) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 500;

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

        if (CoachingItem_ID == null) {
            ctrl.LoadDelegate = function () {
                CoachingManagementAjaxGateway.NewCoachingItem(Coaching_ID, populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CoachingManagementAjaxGateway.GetCoachingItem(CoachingItem_ID, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            CoachingManagementAjaxGateway.SaveCoachingItem(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) refreshItem(Coaching_ID, false);//self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Coaching / Mentoring Log";
            if (entity.CoachingItem_ID != GuidEmpty) title = "Editing Log Entry \"" + teq.Common.FormatDateTime(entity.CoachingItem_Date) + "\"";
            return title;
        };

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Course Detail";
            ctrl.Groups.push(grp);
            ctrl.DialogWidth = 500;
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Date and Time";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDateTimeInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertydatetime");
                        element.Date.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true, yearRange: "-100:+5"
                        });
                        element.Date.timeInput({
                            textboxWidth: "40px",
                            format: "12"
                        });
                        element.Time.timeInput({
                            textboxWidth: "40px",
                            format: "12"
                        });
                        element.Time.css('margin-left', 5);
                        teq.Common.SetDatePickerClearable($(element.Date));
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CoachingItem_Date;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Date = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Description";

                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CoachingItem_Description;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Description = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.CoachingItem_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.CoachingItem_Remark = val;
                    }
                    sec.Properties.push(prop);
                }
            }

            ctrl.Initialize();
        }
    }

    this.DeleteCoachingItem = function (id, name, Coaching_ID) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Proceed?";
        teq.Context.Confirm(msg, function () {

            CoachingManagementAjaxGateway.DeleteCoachingItem(id, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        refreshItem(Coaching_ID, false);
                        teq.Context.ToastTape("Record deleted successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }

    this.CloseCase = function (Coaching_ID, name) {
        var msg = "Close Log For:<br><br>\"" + name + "\"<br><br>Case will be locked. Proceed?";
        teq.Context.Confirm(msg, function () {

            CoachingManagementAjaxGateway.CloseCase(Coaching_ID, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Log closed successfully.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });

        });
    }

}