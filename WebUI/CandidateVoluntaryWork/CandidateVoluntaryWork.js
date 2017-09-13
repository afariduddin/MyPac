local.CandidateVoluntaryWorkPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnAssign = "#" + idPrefix + "_btnAssign";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    var btnNew = "#" + idPrefix + "_btnNew";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";
    var txtSearchVoluntaryWorkTitle = "#" + idPrefix + "_txtSearchVoluntaryWorkTitle";
    var txtSearchHourFrom = "#" + idPrefix + "_dpSearchHourFrom";
    var txtSearchHourTo = "#" + idPrefix + "_dpSearchHourTo";
    var selSearchVoluntaryHourStatusType = "#" + idPrefix + "_selSearchVoluntaryHourStatusType";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {

        $(btnAssign).button();

        $(selSearchVoluntaryHourStatusType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Please Select -",
            choices: Enums.VoluntaryHourStatusType
        });

        BuildSurfaceListing()

    }
    this.Activated = Activated;
    function Activated() {


        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_CandidateDashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Voluntary Work",
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
            var title = $(txtSearchVoluntaryWorkTitle).val();
            var startHour = $(txtSearchHourFrom).val();
            var endHour = $(txtSearchHourTo).val();
            var VoluntaryHourStatusType = $(selSearchVoluntaryHourStatusType).val();
            CandidateVoluntaryWorkAjaxGateway.GetCandidateVoluntaryWorkList(startDate, endDate, title, startHour, endHour, VoluntaryHourStatusType, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Date</td>");
            htr.append("<td >Title</td>");
            htr.append("<td >Work Hour</td>");
            htr.append("<td >Description</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

            //function headerCol(colName) {
            //    var td = $("<td/>");
            //    var a = $("<a href='javascript:void(0);'>" + colName + "</a>");
            //    td.append(a);
            //    return td;
            //}
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();
            for (var i = 0; i < tbl.Rows.length; i++) {

                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");

                var StatusType = "";
                if (dr.VoluntaryHour_Status == "1") {
                    StatusType = FlagNames.VoluntaryHourStatusType[1];//Pending
                }
                else if (dr.VoluntaryHour_Status == "2") {
                    StatusType = FlagNames.VoluntaryHourStatusType[2];//Approve
                }
                else if (dr.VoluntaryHour_Status == "3") {
                    StatusType = FlagNames.VoluntaryHourStatusType[3];//Reject
                }

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDateTime(dr.VoluntaryHour_Date) + "</td>"));
                tr.append(("<td align=center>" + dr.VoluntaryHour_Title + "</td>"));
                tr.append(("<td align=center>" + dr.VoluntaryHour_Duration + "</td>"));
                tr.append(("<td align=center>" + dr.VoluntaryHour_Description + "</td>"));
                tr.append(("<td align=center>" + StatusType + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);
            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.VoluntaryHour_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                if (dr.VoluntaryHour_Status == "1") {
                    var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                    delLnk.click(function (event) {
                        event.stopPropagation();
                        self.DeleteRecord(dr.VoluntaryHour_ID, dr.VoluntaryHour_Title);
                    });
                    actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);
                }
                return actionTd;
            }

            //function buileActionTd() {
            //    var actionTd = $("<td align=center/>");

            //    var editLnk = $("<a href='javascript:void(0);'>Set Assessment Session</a>");
            //    editLnk.click(function (event) {
            //        //buildSurfaceDataDialog("Edit");
            //        event.stopPropagation();
            //    });
            //    actionTd.append(teq.Common.ThemeIcon("active", "calendar"), editLnk);

            //    return actionTd;
            //}
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog();
        }

        //#endregion

        self.ListControlller.Initialize();


        //Construct Button toggle search pnl
        {
            $(btnShowSearch_SpanIcon).append(SearchImageicon);
            $(btnShowSearch_SpanIcon).css("padding-right", "10px")
            $(btnShowSearch_SpanArrowIcon).append(ArrowImageicon);
        }
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "Voluntary Work Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 550;

        if (id == null) {
            ctrl.LoadDelegate = function () {
                CandidateVoluntaryWorkAjaxGateway.NewVoluntaryWork(function (res) {
                    if (res.error == null) ctrl.Populate(res.value);
                    else ctrl.Close();
                });
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CandidateVoluntaryWorkAjaxGateway.GetVoluntaryWork(id, function (res) {
                    if (res.error == null) {
                        if (res.value == null) {
                            teq.Context.Alert("Selected record no longer exists.");
                            ctrl.Close();
                        }
                        else {
                            
                            if (res.value.VoluntaryHour_Status != "1")
                            {
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
            CandidateVoluntaryWorkAjaxGateway.SaveVoluntaryWork(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) self.ListControlller.RefreshList();
            });
        };

        ctrl.GetTitleDelegate = function (entity) {
            var title = "Create Voluntary Hour";
            if (entity.VoluntaryHour_ID != GuidEmpty) title = "Editing \"" + entity.VoluntaryHour_Title + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Voluntary Hour Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

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
                        return entity.VoluntaryHour_Date;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.VoluntaryHour_Date = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Title";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.VoluntaryHour_Title;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.VoluntaryHour_Title = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Work Hour";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.VoluntaryHour_Duration;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.VoluntaryHour_Duration = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Description";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property propertyseperator");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.VoluntaryHour_Description;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.VoluntaryHour_Description = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                         element.attr("readonly", "readonly");
                        element.dropdownSelect(
                        {
                            choices: Enums.VoluntaryHourStatusType
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return FlagNames.VoluntaryHourStatusType[entity.VoluntaryHour_Status];
                    }
                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.Initialize();
    }

    this.DeleteRecord = function (id, title) {
        var msg = "Delete Record:<br><br>\"" + title + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {
            //teq.Context.ToastTape("Record deleted successfully.");
            CandidateVoluntaryWorkAjaxGateway.DeleteVoluntaryWork(id, function (res) {
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
}