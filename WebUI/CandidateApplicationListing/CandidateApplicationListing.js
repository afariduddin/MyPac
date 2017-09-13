/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateApplicationListingPageController = function (idPrefix) {


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
            Name: "Application List",
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

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Application Date</td>");
            htr.append("<td >Contract Type</td>");
            htr.append("<td >Preferred Location</td>");
            htr.append("<td >Status</td>");
            htr.append("<td >View</td>");

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
            for (var i = 1; i < 25; i++) {

                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + i + ".</td>"));
                tr.append(("<td align=center>12 Oct 2015</td>"));
                tr.append(("<td align=center>Full Time</td>"));
                tr.append(("<td align=center>INTEC, Shah Alam</td>"));
                tr.append(("<td align=center>Submitted</td>"));
                tr.append(buileEditTd());
                tbody.append(tr);

            }

            function buileEditTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog("Edit");
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                //var delLnk = $("<a href='javascript:void(0);'>Reject</a>");
                //delLnk.click(function (event) {
                //    event.stopPropagation();
                //    self.DeleteRecord("", "&lt;Name&gt;");
                //});
                //actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }

            function buileActionTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Set Assessment Session</a>");
                editLnk.click(function (event) {
                    //buildSurfaceDataDialog("Edit");
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "calendar"), editLnk);

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
    var Title = "Application Detail";
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
                    prop.Label = "First Name";
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
            grp.Name = "Contact Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address 1";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Address 2";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Postcode";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "City";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "State";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Country";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Contact Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mobile Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Email";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Parents' Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                //#region Field: BumiStatus
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's First Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's Last Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Father's IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's First Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's Last Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Mother's IC Number";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Education Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                //#region Field: BumiStatus
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Current Field of Study";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "University / Institution";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Current / Final CGPA";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Accountancy Professional Qualification (PQ)";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Registration No.";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Properties.push(prop);
                }
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "PQ Start Date";
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
                } {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Level PQ Started";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "CAT";
                    vals[1] = "After Foundation";
                    vals[2] = "After Diploma";
                    vals[3] = "After Degree";
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
            }

            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Application Detail";
            ctrl.Groups.push(grp);
            {
                sec = new teq.EntityPropertiesFormSection();

                grp.Sections.push(sec);
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Course";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "ACCA - Association of Chartered Certified Accountant";
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
                    prop.Label = "PQ Start Date";
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
                    prop.Label = "Contract Type";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    var bumic = [];
                    bumic[0] = "Part Time";
                    bumic[1] = "Full Time";
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
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Outstanding Papers";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals2 = [];
                    vals2[0] = "F1 Accountant in Business";
                    vals2[1] = "F2 Management Accounting";
                    vals2[2] = "F3 Financial Accounting";
                    vals2[3] = "F4 Corporate and Business Law";
                    vals2[4] = "F5 Performance Management";
                    vals2[5] = "F6 Taxation";
                    vals2[6] = "F7 Financial Reporting";
                    vals2[7] = "F8 Audit and Assurance";
                    vals2[8] = "F9 Financial Management";
                    vals2[9] = "P1 Governance, Risk and Ethics";
                    vals2[10] = "P2 Corporate Reporting";
                    vals2[11] = "P3 Business Analysis";
                    vals2[12] = "P4 Advanced Financial Management";
                    vals2[13] = "P5 Advanced Performance Management";
                    vals2[14] = "P6 Advanced Taxation";
                    vals2[15] = "P7 Advanced Audit and Assurance";
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
                    prop.Label = "Deadline";
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
                    prop.Label = "Registered Next Exam Sitting";
                    prop.Input = new teq.EntityRadioButtonListInput();
                    var bumic = [];
                    bumic[0] = "Yes";
                    bumic[1] = "No";
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
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Next Exam Session";
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
                    prop.Label = "Study Location";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "INTEC, Shah Alam";
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
            }
        }

        ctrl.Initialize();
    }
}