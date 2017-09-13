/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateWorkHistoryPageController = function (idPrefix) {


    //#region Elements
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

    //"Search" function button 
    var txtSearchCompanyName = "#" + idPrefix + "_txtSearchCompanyName";
    var txtSearchJobTitle = "#" + idPrefix + "_txtSearchJobTitle";
    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";

    var searchShown = true;
    var SettingType;


    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {

        $(btnAssign).button();

        BuildSurfaceListing()

    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {


        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_CandidateDashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Work History",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;


    }
    //#endregion

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }

    //#region BuildCandidateListing 

    function BuildSurfaceListing() {
        $(txtSearchDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true
        });
        teq.Common.SetDatePickerClearable($(txtSearchDateFrom));
        $(txtSearchDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true
        });
        teq.Common.SetDatePickerClearable($(txtSearchDateTo));

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        self.ListControlller.btnNew = $(btnNew);
        // self.ListControlller.btnToggleSearch = $(btnShowSearch);
        //self.ListControlller.btnNew = $(btnNew);
        //self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        //#endregion
        //#region Settings
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
        //#endregion

        //#region Delegates       
        self.ListControlller.SearchDelegate = function () {
            //var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 100, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            //self.ListControlller.Populate(res.value);
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            var CompanyName = $(txtSearchCompanyName).val();
            var JobTitle = $(txtSearchJobTitle).val();
            var startDate = $(txtSearchDateFrom).val();
            var endDate = $(txtSearchDateTo).val();
            CandidateWorkHistoryAjaxGateway.GetCandidateWorkHistoryList(CompanyName, JobTitle, startDate, endDate, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Company Name</td>");
            htr.append("<td >Job Title</td>");
            htr.append("<td >Work From</td>");
            htr.append("<td >Work To</td>");;
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

                var resignDate = teq.Common.FormatDate(dr.WorkHistory_ResignDate);
                if (resignDate == "1-Jan-1900")//to standardize date format
                {
                    resignDate = "";
                }

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.WorkHistory_CompanyName + "</td>"));
                tr.append(("<td align=center>" + dr.WorkHistory_JobTitle + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.WorkHistory_StartDate) + "</td>"));
                tr.append(("<td align=center>" + resignDate + "</td>"));
                tr.append(buileEditTd(dr));
                tbody.append(tr);

            }

            function buileEditTd(dr) {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog(dr.WorkHistory_ID);
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord(dr.WorkHistory_ID, dr.WorkHistory_CompanyName);
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

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
    var Title = "Work History Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(id) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;
        // ctrl.DialogHeight= 600;

        //ctrl.LoadDelegate = function () {

        //    ctrl.Populate();
        //}
        var populateDel = function (res) {
            if (res.error == null) {
                if (res.value == null) {
                    teq.Context.Alert("Selected record no longer exists."); //ErrorMessages[ErrorCodes.GEN_RecordNotFound]);
                    ctrl.Close();
                }
                else {
                    ctrl.Populate(res.value);
                }
            }
            else ctrl.Close();
        }
        if (id == null) {
            ctrl.LoadDelegate = function () {
                CandidateWorkHistoryAjaxGateway.NewWorkHistory(populateDel);
            }
        }
        else {
            ctrl.LoadDelegate = function () {
                CandidateWorkHistoryAjaxGateway.GetWorkHistory(id, populateDel);
            }
        }

        ctrl.SaveDelegate = function (entity, callback) {
            //ctrl.Close();
            //if (edit == "Edit") teq.Context.ToastTape("Record save successfully.");
            //else teq.Context.ToastTape("Record create Successfully.");
            CandidateWorkHistoryAjaxGateway.SaveWorkHistory(entity, function (res) {
                callback(res);
                if (res.error == null && res.value.length == 0) {
                    self.ListControlller.RefreshList();
                }
            });
        };
        ctrl.GetTitleDelegate = function (entity) {
            //var title = self.Title + " - " + edit;
            var title = "Create Work History";
            if (entity.WorkHistory_ID != GuidEmpty) title = "Editing \"" + entity.WorkHistory_CompanyName + "\"";
            return title;
        };

        function Enums_GetLabel(key) {
            if (key == null) return '';
            else if (typeof (key) == 'string') return teq.Common.FormatString(this[key]);
            else if (typeof (key) == 'number') return teq.Common.FormatString(this[key]);
            else return '';
        }

        //#region Application Property
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Voluntary Work Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Company Name";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_CompanyName;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_CompanyName = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Job Title";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_JobTitle;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_JobTitle = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Start Date";
                    prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_StartDate;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_StartDate = val;
                    }
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Reisgn Date";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                            showButtonPanel: true
                        });
                    };
                    prop.GetValueDelegate = function (entity) {
                        if (teq.Common.FormatDate(entity.WorkHistory_ResignDate) == "1-Jan-1900")
                        {
                            return "";
                        }
                        else return entity.WorkHistory_ResignDate;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        if (val == null)
                        {
                            entity.WorkHistory_ResignDate = "1900-01-01 00:00:00.000";
                        }
                        else entity.WorkHistory_ResignDate = val;
                    }
                    sec.Properties.push(prop);
                }
           
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Job Description";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.addClass("property");
                    };
                    prop.GetValueDelegate = function (entity) {
                        return entity.WorkHistory_Description;
                    }
                    prop.SetValueDelegate = function (entity, val) {
                        entity.WorkHistory_Description = val;
                    }
                    sec.Properties.push(prop);
                }
                
            }
        }

        ctrl.Initialize();
    }

    this.DeleteRecord = function (id, CompanyName) {
        var msg = "Delete Record:<br><br>\"" + CompanyName + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {
            //teq.Context.ToastTape("Record deleted successfully.");
            CandidateWorkHistoryAjaxGateway.DeleteWorkHistory(id, function (res) {
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