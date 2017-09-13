local.AssessmentSessionManagementPageController = function (idPrefix) {

    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnNew = "#" + idPrefix + "_btnNew";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";
    var txtSearchName = "#" + idPrefix + "_txtSearchName";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing();

        if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentSessionListEdit)) {
            $(btnNew).prop('disabled', true)
                    .addClass("ui-state-disabled");
        }
    }

    this.Activated = Activated;
    function Activated() {

        if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentSessionListView)) {
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
            Name: "Assessment Session Management",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

    }

    this.Shown = function () {
    }
    function buildInvitationDataDialog(ID, TotalCandidate)
    {
        var msg = "An invitation will be sent to all " + TotalCandidate + " candidates. Proceed?";
        teq.Context.Confirm(msg, function () {
            
            AssessmentSessionManagementAjaxGateway.SendEmail(ID, function (res) {
                if (res.error == null) {
                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                        self.ListControlller.RefreshList();
                        teq.Context.ToastTape("Invitations are successfully queued for sending.");
                    }
                    else teq.Context.Alert(res.value.Name);
                }
            });
        });
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
            showButtonPanel: true, yearRange: "-100:+5"
        });
        teq.Common.SetDatePickerClearable($(txtSearchDateTo));
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
            var startDate = $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val();
            var location = $(txtSearchName).val();
            AssessmentSessionManagementAjaxGateway.GetAssessmentSessionList(startDate, endDate, location, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) self.ListControlller.Populate(res.value);
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Location</td>");
            htr.append("<td >Date</td>");
            htr.append("<td >Time</td>");
            htr.append("<td >Assigned Student</td>");
            htr.append("<td >Maximum Student</td>");
            htr.append("<td >Sent</td>");
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

            var HasPermission = true;

            if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentSessionListEdit)) {
                HasPermission = false;
            }

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                //dr.AssessmentSession_DateTime: "Tue Apr 05 2016 19:18:00 GMT+0800 (Malay Peninsula Standard Time)"
                var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                //var days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
                var yr = dr.AssessmentSession_DateTime.getFullYear();
                var mth = dr.AssessmentSession_DateTime.getMonth();
                var date = dr.AssessmentSession_DateTime.getDate();
                var hr = dr.AssessmentSession_DateTime.getHours(); //Returns the hour of the day (0-23).
                var min = dr.AssessmentSession_DateTime.getMinutes();
                var ampm = hr < 12 ? "am" : "pm";
                if (hr > 12) {
                    hr = hr - 12;
                }
                if (min < 10)
                {
                    min = "0" + min;
                }

                var SentStatus = "";
                if (dr.AssessmentSession_IsSent) {
                    SentStatus = "Yes";//Employed
                }
                else {
                    SentStatus = "No";//Unemployed
                }

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.AssessmentSession_Location + "</td>"));
                tr.append(("<td align=center>" + date + "-" + months[mth] + "-" + yr + "</td>"));
                tr.append(("<td align=center>" + hr + ":" + min + " " + ampm + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentSession_AssignedStudent + "</td>"));
                tr.append(("<td align=center>" + dr.AssessmentSession_MaximumStudent + "</td>"));
                tr.append(("<td align=center>" + SentStatus + "</td>"));
                if (HasPermission)
                {
                    tr.append(buileEditTd(dr));
                    tr.append(buileActionTd(dr));
                }
                else
                {
                    tr.append("<td></td>");
                    tr.append("<td></td>");
                }

                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.AssessmentSession_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.AssessmentSession_ID, dr.AssessmentSession_Location);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
            function buileActionTd(dr) {
                var actionTd = $("<td align=center/>");
                if (!dr.AssessmentSession_IsSent)
                {
                    var editLnk = $("<a href='javascript:void(0);'>Send Invitation</a>");
                    editLnk.click(function (event) {
                        buildInvitationDataDialog(dr.AssessmentSession_ID, dr.AssessmentSession_AssignedStudent);
                        event.stopPropagation();
                    });
                    actionTd.append(teq.Common.ThemeIcon("active", "mail-open"), editLnk);
                }
    

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }
        self.ListControlller.Initialize();
    }

    var Title = "Assessment Session Management";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                AssessmentSessionManagementAjaxGateway.NewAssessmentSession(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                AssessmentSessionManagementAjaxGateway.GetAssessmentSession(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            if (!local.ValidatePermission(FlagCodes.PermissionType.AssessmentSessionListEdit)) {
                                $(".ui-dialog-buttonpane button:contains('Save')").attr("disabled", true)
                                                                      .addClass("ui-state-disabled");
                            }
                            ctrl.Populate(res.value);
                        }
                    }
                    else ctrl.Close();
                });
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            AssessmentSessionManagementAjaxGateway.SaveAssessmentSession(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            //var title = self.Title + " - " + edit;
            //return title;
            var title = "Create Assessment Session";
            if (entity.AssessmentSession_ID != GuidEmpty) title = "Editing \"" + entity.AssessmentSession_Location + "\"";
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
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Personal Detail ";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Location";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentSession_Location;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentSession_Location = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        AssessmentSessionManagementAjaxGateway.VerifyLocation(val, callback);
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Date and Time";
                    //prop.Input = new teq.EntityDateInput();
                    prop.Input = new teq.EntityDateTimeInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("propertydatetime");
                        element.Date.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                             showButtonPanel: true,yearRange: "-100:+5"
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
                        return entity.AssessmentSession_DateTime;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentSession_DateTime = val;
                    }
                    prop.ValidationDelegate = function (val, callback) {
                        //AssessmentSessionManagementAjaxGateway.VerifyDateTime(val, callback);
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Maximum Student";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.AssessmentSession_MaximumStudent;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentSession_MaximumStudent = val;
                    }
                    sec.Properties.push(prop);

                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Interview Session";
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

                        if (entity.AssessmentSession_IsInterview)
                            return FlagCodes.YesNoType.Yes;
                        else return FlagCodes.YesNoType.No;
                    }
                    prop.SetValueDelegate = function (entity, val) {

                        if (val == FlagCodes.YesNoType.Yes)
                            entity.AssessmentSession_IsInterview = true;
                        else
                            entity.AssessmentSession_IsInterview = false;
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
                        return entity.AssessmentSession_Remark;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.AssessmentSession_Remark = val;
                    }
                    sec.Properties.push(prop);
                }
            }
        }
        ctrl.Initialize();
    }


    this.DeleteRecord = function (id, location) {
        var msg = "Delete Record:<br><br>\"" + location + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {
            AssessmentSessionManagementAjaxGateway.VerifyAssessmentSessionApplicantRecord(id, function (res) {
                    if (res.error == null) {
                        if (res.value.Code == teq.Context.SuccessErrorCode) {
                            AssessmentSessionManagementAjaxGateway.DeleteAssessmentSession(id, function (res) {
                                if (res.error == null) {
                                    if (res.value.Code == teq.Context.SuccessErrorCode) {
                                        self.ListControlller.RefreshList();
                                        teq.Context.ToastTape("Record deleted successfully.");
                                    }
                                    else teq.Context.Alert(res.value.Name);
                                }
                            });     
                        }
                        else teq.Context.Alert(res.value.Name);
                    }
            });
        });
    }
}