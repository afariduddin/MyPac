/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateAssessmentResultPageController = function (idPrefix) {


    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnAssign = "#" + idPrefix + "_btnAssign";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnSendCLO = "#" + idPrefix + "_btnSendCLO";
    

    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    //var btnNew = "#" + idPrefix + "_btnNew";


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;


    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {

        $(btnSendCLO).button();
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
            Link: local.aspxContent_Dashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Assessment Result",
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

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        //self.ListControlller.btnNew = $(btnNew);
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
            var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 100, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            self.ListControlller.Populate(res.value);
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr1 = $("<tr></tr>");
            htr1.append("<td rowspan=2>No. </td>");
            htr1.append("<td rowspan=2>Assessment Date</td>");
            htr1.append("<td rowspan=2>Location</td>");
            htr1.append("<td colspan=3>LA 1</td>");
            htr1.append("<td colspan=2>LA 2</td>");
            htr1.append("<td colspan=4>English Proficiency Test</td>");
            htr1.append("<td rowspan=2>Status</td>");
            htr1.append("<td rowspan=2>View</td>");
            

            var htr = $("<tr></tr>");
            htr.append("<td>Abstract Logic</td>");
            htr.append("<td>Logical Process</td>");
            htr.append("<td>Numerical</td>");
            htr.append("<td>Spatial Reasoning</td>");
            htr.append("<td>Social Context</td>");
            htr.append("<td>Listening</td>");
            htr.append("<td>Writing</td>");
            htr.append("<td>Speaking</td>");
            htr.append("<td>Reading</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr1);
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
            for (var i = 1; i < 25; i++) {

                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + i + ".</td>"));
                tr.append(("<td align=center>11-11-2015</td>"));
                tr.append(("<td align=center>IPAC</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>80</td>"));
                tr.append(("<td align=center>Pass</td>"));
                tr.append(buileEditTd());
                tbody.append(tr);

            }

            function buileEditTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Accept</a>");
                editLnk.click(function (event) {
                    //buildSurfaceDataDialog("Edit");
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "check"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Reject</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord("", "&lt;Name&gt;");
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }

            function buileActionTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Assign to YPPB</a>");
                editLnk.click(function (event) {
                    //buildSurfaceDataDialog("Edit");
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "refresh"), editLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog("New");
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
    var Title = "Assessment Result Detail";
    self.Title = Title;
    function buildSurfaceDataDialog(edit) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;
        // ctrl.DialogHeight= 600;

        ctrl.LoadDelegate = function () {

            ctrl.Populate();
        }

        ctrl.SaveDelegate = function (entity, callback) {
            ctrl.Close();
            if (edit == "Edit") teq.Context.ToastTape("Record save successfully.");
            else teq.Context.ToastTape("Record create Successfully.");
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = self.Title + " - " + edit;
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
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Applicant Detail";
            ctrl.Groups.push(grp);
            {
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Full Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        //element.width("400px");
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Last Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        //element.width("400px");
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "D.O.B";
                    prop.Input = new teq.EntityDateInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.datepicker({
                            autoSize: true,
                            changeMonth: true,
                            changeYear: true,
                            dateFormat: "d-M-yy",
                             showButtonPanel: true,yearRange: "-100:+5"
                        });
                    };
                    //sec.Grids[4][0].Property = prop;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Gender";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals2 = [];
                    vals2[0] = "Male";
                    vals2[1] = "Female";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals2
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[2][0].Property = prop;
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Nationality";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "Malaysian";
                    vals[1] = "Singapore";
                    vals[2] = "Thailand";
                    vals[3] = "Others";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals
                        });
                        element.width(inputWidth);
                    };

                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: IC
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                //#endregion
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Assessment Result";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "LA 1";
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Abstract Logic";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Logical Process";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Numerical";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }

                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "LA 2";
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Spatial Reasoning";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Social Context";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }

                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "English Proficiency Test";
                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Listening";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Writing";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Speaking";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Reading";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }

                sec = new teq.EntityPropertiesFormSection();
                sec.Name = "Result Summary";
                grp.Sections.push(sec);

                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Sponsor";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "MyPAC";
                    vals[1] = "YPPB";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals
                        });
                        element.width(inputWidth);
                    };

                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    var bumic = [];
                    bumic[0] = "Pass";
                    bumic[1] = "Fail";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.radioButtonList({
                            choices: bumic,
                            columns: 2,
                            columnSpacing: "20px",
                            width: null,
                            allowNone: false
                        });
                    }

                    sec.Properties.push(prop);
                }
            }
        }

        ctrl.Initialize();
    }
}