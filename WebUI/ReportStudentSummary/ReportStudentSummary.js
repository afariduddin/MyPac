/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.ReportStudentSummaryPageController = function (idPrefix) {


    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnExport = "#" + idPrefix + "_btnExport";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";
    //var btnNew = "#" + idPrefix + "_btnNew";
    var txtSearchName = "#" + idPrefix + "_txtSearchName";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    
    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {
        buildButton();
        BuildSurfaceListing()

    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated() {


        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_Blank1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Registered Student Report",
            Link: local.aspxContent_RoadInfoAdministration1
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        
    }
    //#endregion

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }

    //#region build button
    function buildButton() {
        
        function PopulateListing(Title) {
            //$(spanTitle).html("Administration - " + Title);
            self.Title = Title;
            var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            self.ListControlller.Populate(res.value);
        }

    }
    //#endregion    

    //#region BuildSurfaceListing 

    function BuildSurfaceListing() {


        self.ListControlller = new teq.EntityListController();
        //#region Elements  

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        // self.ListControlller.btnToggleSearch = $(btnShowSearch);
        //self.ListControlller.btnNew = $(btnNew);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        //#endregion
        //#region Settings
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
        //#endregion

        //#region Delegates       
        self.ListControlller.SearchDelegate = function () {
            var name = $(txtSearchName).val();
            if (name != "") {
                var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
                self.ListControlller.Populate(res.value);
            }
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            //teq.Common.BuildColumnIndexes(tbl);

            var ctd = $("<td align=center/>");
            //ctd.append(this.MultiSelector.BuildSelectorControl());

            var htr = $("<tr></tr>");
            //htr.append(ctd);
            //htr.append("<td >No.</td>");            
            htr.append("<td rowspan=2>Campus</td>");
            htr.append("<td rowspan=2>No of Students </td>");
            htr.append("<td colspan=11>No. Students by Paper</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

            var htr2 = $("<tr></tr>");
            htr2.append("<td>F6</td>");
            htr2.append("<td>F7</td>");
            htr2.append("<td>F8</td>");
            htr2.append("<td>F9</td>");
            htr2.append("<td>P1</td>");
            htr2.append("<td>P2</td>");
            htr2.append("<td>P3</td>");
            htr2.append("<td>P4</td>");
            htr2.append("<td>P5</td>");
            htr2.append("<td>P6</td>");
            htr2.append("<td>P7</td>");
            thead.append(htr2);
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();

            var L1 = [
                ['Main Campus (MC)', 'Sign Board'],
                ['Sentral College, Penang (ST)', 'Culvert'],
                ['UNITAR Kota Kinabalu (KK)', 'Traffic Light'],
                ['UNITAR Johor Bahru (JB)', 'Sign Board']];

                    var j = 0;
                for (var i = 4; i >0; i--) {                 
                    var tr = $("<tr></tr>");
                    tr.append(("<td align=center> " + L1[j][0] + "</td>"));
                    tr.append(("<td align=center> " + (i * 8) + "</td>"));                    
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tr.append(("<td align=center>0</td>"));
                    tbody.append(tr);
                    j++;
                }
            

        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog("New");
        }

        //#endregion

        self.ListControlller.Initialize();


        //Construct Button toggle search pnl
        {


            $(btnShowSearch).css("background-color", "black");
            $(btnShowSearch).css("color", "white");
            $(btnShowSearch).css("font-weight", "bold");
            $(btnShowSearch).css("padding-left", "10px");
            $(btnShowSearch).css("cursor", "pointer");
            $(btnShowSearch).css("padding", "10px 13px 10px 13px");
            $(btnShowSearch).css("border-radius", "5px");
            $(btnShowSearch).css("border", "1px solid #aaaaaa");

            //$(btnExport).button({
            //    icons: { primary: "ui-icon-arrowthickstop-1-s" }
            //});
            $(btnExport).css("background-color", "black");
            $(btnExport).css("color", "white");
            $(btnExport).css("font-weight", "bold");
            $(btnExport).css("padding-left", "10px");
            $(btnExport).css("cursor", "pointer");
            $(btnExport).css("padding", "10px 13px 10px 13px");
            $(btnExport).css("border-radius", "5px");
            $(btnExport).css("border", "1px solid #aaaaaa");
            $(btnExport).css("width", "120px");
            


            $(btnShowSearch_SpanIcon).append(SearchImageicon);
            $(btnShowSearch_SpanIcon).css("padding-right", "10px")
            $(btnShowSearch_SpanArrowIcon).append(ArrowImageicon);

            $(btnShowSearch).click(function () {
                //event.preventDefault();
                self.ListControlller.ToggleSearchForm($(window).width() - ($(this).parent().closest('div').offset().left + $(this).parent().closest('div').outerWidth()));

                if (searchShown == true) {

                    ArrowImageicon.attr("src", "Resource/ToggleSearchDownIcon.png");

                    searchShown = false;
                }
                else {

                    ArrowImageicon.attr("src", "Resource/ToggleSearchUpIcon.png");

                    searchShown = true;
                }
            });

            $(btnShowSearch).mousedown(function () {

                $(this).animate({ opacity: 0.1 }, 10);

            })
            $(btnShowSearch).mouseup(function () {

                $(this).animate({ opacity: 1 }, 10);

            })
            $(btnShowSearch).mouseout(function () {

                $(this).animate({ opacity: 1 }, 10);

            })
            $(btnShowSearch).mouseenter(function () {

                $(this).animate({ opacity: 0.5 }, 10);

            })

        }


    }

    //#endregion

    //#region buildSurfaceDataDialog
    var Title = null;
    self.Title = Title;
    function buildSurfaceDataDialog(edit) {
        var ctrl = new teq.EntityPropertiesDialogController();
        //ctrl.DialogWidth = 800;
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
            var title = self.Title + " Maintenance - " + edit;
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
            grp.Name = "Work Order Detail ";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                //var sec = new teq.EntityPropertiesGridSection();
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);

                //#region Field: Code
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Work Order Code";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        //element.width("400px");
                    };
                    //sec.Grids[0][0].Property = prop;
                    sec.Properties.push(prop);

                }
                //#endregion

                //#region Field: Name/Description
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Name/Description";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[1][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Asset Type
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Asset Type";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals = [];
                    vals[0] = "Road";
                    vals[1] = "Culvert";
                    vals[2] = "Signboard";
                    vals[3] = "Traffic Light";
                    vals[4] = "Park";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[2][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Raised By
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Raised By";
                    
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.text = "admin";
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[3][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Assign To
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Assign To";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals2 = [];
                    vals2[0] = "Team A";
                    vals2[1] = "Team B";
                    vals2[2] = "Team C";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals2
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[4][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Status
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals3 = [];
                    vals3[0] = "Open";
                    vals3[1] = "In Progress";
                    vals3[2] = "Closed";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals3
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[5][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Remarks
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[6][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion
            }
            //#endregion                

        }
        //#endregion

        //#region Group: NOD
        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "NOD ";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesFormSection();
                grp.Sections.push(sec);

                //#region Field: Code
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "NOD No";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        //element.width("400px");
                    };
                    //sec.Grids[0][0].Property = prop;
                    sec.Properties.push(prop);

                }
                //#endregion

                //#region Field: Name/Description
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Name/Description";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[1][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Raised By
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Raised By";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.text = "admin";
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[3][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Assign To
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Notified ";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals2 = [];
                    vals2[0] = "Department A";
                    vals2[1] = "Department B";
                    vals2[2] = "Department C";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals2
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[4][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Status
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Status";
                    prop.Input = new teq.EntityDropdownSelectInput();
                    var vals3 = [];
                    vals3[0] = "Open";
                    vals3[1] = "In Progress";
                    vals3[2] = "Closed";
                    prop.Input.BuildElementDelegate = function (element) {
                        element.dropdownSelect(
                        {
                            nullLabel: "- Please Select -",
                            nullValue: "",
                            choices: vals3
                        });
                        element.width(inputWidth);
                    };
                    //sec.Grids[5][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion

                //#region Field: Remarks
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Remarks";

                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextareaInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    //sec.Grids[6][0].Property = prop;
                    sec.Properties.push(prop);
                }
                //#endregion
            }
            //#endregion                

        }
        //#endregion

        ctrl.Initialize();


    }

    //#endregion


}