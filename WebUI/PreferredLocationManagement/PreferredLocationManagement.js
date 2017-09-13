/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.PreferredLocationManagementPageController = function (idPrefix) {


    //#region Elements
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
        //buildButton();
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
            Name: "Preferred Location Management",
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

    ////#region build button
    //function buildButton() {



    //    $(divModuleBtn).append(table);

    //    //$(tdTitle).append("<div style='  text-align:left;'><span > <b>Master File Administration</b><br/> To view or modify Master File Administration  <br/><br/></span></div>");


    //    btnSurface.click(function () {

    //        local.AdvancedSearchModule = btnSurface.children().html();
    //        local.ShowPage(null, function () {
    //            allowedit = true;
    //            PopulateListing("Registration Listing");

    //        });

    //        self.SettingType = 1;

    //        if (searchShown == true) {
    //            ArrowImageicon.attr("src", "Resource/ToggleSearchDownIcon.png");
    //            searchShown = false;
    //        }
    //        else {
    //            ArrowImageicon.attr("src", "Resource/ToggleSearchUpIcon.png");
    //            searchShown = true;
    //        }
    //    });

    //    btnJurisdiction.click(function () {

    //        local.AdvancedSearchModule = btnSurface.children().html();
    //        local.ShowPage(null, function () {
    //            allowedit = true;
    //            PopulateListing("Application Listing");

    //        });

    //        self.SettingType = 1;

    //        if (searchShown == true) {
    //            ArrowImageicon.attr("src", "Resource/ToggleSearchDownIcon.png");
    //            searchShown = false;
    //        }
    //        else {
    //            ArrowImageicon.attr("src", "Resource/ToggleSearchUpIcon.png");
    //            searchShown = true;
    //        }
    //    });




    //    function PopulateListing(Title) {
    //        $(spanTitle).html("Administration - " + Title);
    //        self.Title = Title;
    //        var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
    //        self.ListControlller.Populate(res.value);
    //    }
    //}
    ////#endregion    

    //#region BuildCandidateListing 

    function BuildSurfaceListing() {

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

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
        //#endregion

        //#region Delegates       
        self.ListControlller.SearchDelegate = function () {
            var res = { "value": { "DataTable": new Ajax.Web.DataTable(), "TotalRecords": 100, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            self.ListControlller.Populate(res.value);
        }


        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            //teq.Common.BuildColumnIndexes(tbl);

            var ctd = $("<td align=center/>");
            //ctd.append(this.MultiSelector.BuildSelectorControl());

            var htr = $("<tr></tr>");
            //htr.append(ctd);
            //htr.append("<td >No.</td>");
            htr.append("<td >No. </td>");
            htr.append("<td >Name</td>");
            htr.append("<td >Created By</td>");
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
                tr.append(("<td align=center>Name - " + i + "</td>"));
                tr.append(("<td align=center>Master Administrator</td>"));
                tr.append(buileEditTd());
                tbody.append(tr);

            }


            //if (tbl.Rows.length == 0) {
            //    local.ListingEmptyRecord(tbody);
            //}
            function buileEditTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>Edit / View</a>");
                editLnk.click(function (event) {
                    buildSurfaceDataDialog("Edit");
                    event.stopPropagation();
                });
                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                var delLnk = $("<a href='javascript:void(0);'>Delete</a>");
                delLnk.click(function (event) {
                    event.stopPropagation();
                    self.DeleteRecord("", "&lt;Name&gt;");
                });
                actionTd.append(teq.Common.ThemeIcon("active", "close"), delLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildSurfaceDataDialog("New");
        }

        //#endregion

        self.ListControlller.Initialize();
    }

    //#endregion

    //#region buildCandidateDataDialog
    var Title = "Preffered Location Management";
    self.Title = Title;
    function buildSurfaceDataDialog(edit) {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 400;
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

        //#region Group: General
        {
            var inputWidth = "150px";
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Campus Detail ";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesFormSection();

                //sec.ConfigureGrids(7, 1);
                grp.Sections.push(sec);

                //#region Field: Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        //element.width("400px");
                    };
                    sec.Properties.push(prop);

                }
                //#endregion

        
            }
            //#endregion                

        }
        //#endregion

        ////#region Group: Contact Detail
        //{
        //    var inputWidth = "150px";
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Contact";
        //    ctrl.Groups.push(grp);
        //    //#region Section: Generic
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        grp.Sections.push(sec);

        //        //#region Field: Add1
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Address 1";
        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                //element.width("400px");
        //            };
        //            //sec.Grids[0][0].Property = prop;
        //            sec.Properties.push(prop);

        //        }
        //        //#endregion

        //        //#region Field: Add2
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Address 2";
        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[1][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: City
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "City";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "admin";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: ZipCode
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Zip Code";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "45160";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Country
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Country";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityDropdownSelectInput();
        //            var vals21 = [];
        //            vals21[0] = "Malaysian";
        //            vals21[1] = "Singapore";
        //            vals21[2] = "Thailand";
        //            vals21[3] = "Others";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.dropdownSelect(
        //                {
        //                    nullLabel: "- Please Select -",
        //                    nullValue: "",
        //                    choices: vals21
        //                });
        //                element.width(inputWidth);
        //            };

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Phone
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Phone No.";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Mobile
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Mobile No.";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Email
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Email";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //    }
        //    //#endregion                

        //}
        ////#endregion

        ////#region Group: Parent Info
        //{
        //    var inputWidth = "150px";
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Parent Info";
        //    ctrl.Groups.push(grp);
        //    //#region Section: Generic
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        grp.Sections.push(sec);

        //        //#region Field: Father Name
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Father Full Name";
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                //element.width("400px");
        //            };
        //            //sec.Grids[0][0].Property = prop;
        //            sec.Properties.push(prop);

        //        }
        //        //#endregion

        //        //#region Field: Father IC
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Father IC No.";
        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[1][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Mother Name
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Mother Full Name";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "admin";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Mother IC
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Mother IC";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "45160";
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Combine Income
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Combine Income";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityDropdownSelectInput();
        //            var vals31 = [];
        //            vals31[0] = "< RM 830";
        //            vals31[1] = "RM 830 - RM 1,000";
        //            vals31[2] = "RM 1,001 - RM 3,000";
        //            vals31[3] = "RM 3,001 - RM 5,000";
        //            vals31[4] = "RM 5,001 - RM 7,000";
        //            vals31[5] = "> RM 7,000";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.dropdownSelect(
        //                {
        //                    nullLabel: "- Please Select -",
        //                    nullValue: "",
        //                    choices: vals31
        //                });
        //                element.width(inputWidth);
        //            };

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //    }
        //    //#endregion                

        //}
        ////#endregion

        ////#region Group: Education background
        //{
        //    var inputWidth = "150px";
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Education Info";
        //    ctrl.Groups.push(grp);

        //    //#region Section: Education
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        sec.Name = "Education Background";
        //        grp.Sections.push(sec);

        //        //#region Field: Level of study
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Level of Study";
        //            prop.Input = new teq.EntityRadioButtonListInput();
        //            var vals41 = [];
        //            vals41[0] = "Completed Degree";
        //            vals41[1] = "Pursuing Degree";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.radioButtonList({
        //                    choices: vals41,
        //                    columns: 2,
        //                    columnSpacing: "20px",
        //                    width: null,
        //                    allowNone: false
        //                });
        //            }

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Field of Study
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Field of Study";
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                //element.width("400px");
        //            };
        //            //sec.Grids[0][0].Property = prop;
        //            sec.Properties.push(prop);

        //        }
        //        //#endregion

        //        //#region Field: University
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "University / Institution";
        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //            };
        //            //sec.Grids[1][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: CGPA
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Current CGPA";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.text = "admin";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.width("100px");
        //            };
        //            //sec.Grids[3][0].Property = prop;
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion       

        //    }
        //    //#endregion                

        //    //#region Section: Certificate
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        sec.Name = "Certification / Employment";
        //        grp.Sections.push(sec);

        //        //#region Field: MIA Member
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "MIA Member";
        //            prop.Input = new teq.EntityRadioButtonListInput();
        //            var vals42 = [];
        //            vals42[0] = "Yes";
        //            vals42[1] = "No";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.radioButtonList({
        //                    choices: vals42,
        //                    columns: 2,
        //                    columnSpacing: "20px",
        //                    width: null,
        //                    allowNone: false
        //                });
        //            }

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Membership Number
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Membership Number";
        //            prop.Input = new teq.EntityTextboxInput();
        //            prop.Input.BuildElementDelegate = function (element) {
        //                //element.width("400px");
        //            };
        //            sec.Properties.push(prop);

        //        }
        //        //#endregion

        //        //#region Field: Currently pursuing Professional Qualification
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Currently pursuing Professional Qualification";
        //            prop.Input = new teq.EntityRadioButtonListInput();
        //            var vals42 = [];
        //            vals42[0] = "Yes";
        //            vals42[1] = "No";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.radioButtonList({
        //                    choices: vals42,
        //                    columns: 2,
        //                    columnSpacing: "20px",
        //                    width: null,
        //                    allowNone: false
        //                });
        //            }

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Currently Employed
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Currently Employed";
        //            prop.Input = new teq.EntityRadioButtonListInput();
        //            var vals42 = [];
        //            vals42[0] = "Yes";
        //            vals42[1] = "No";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.radioButtonList({
        //                    choices: vals42,
        //                    columns: 2,
        //                    columnSpacing: "20px",
        //                    width: null,
        //                    allowNone: false
        //                });
        //            }

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Preferred Location
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Preferred Study Location";

        //            //prop.MarkCompulsary = true;
        //            prop.Input = new teq.EntityDropdownSelectInput();
        //            var vals43 = [];
        //            vals43[0] = "IPAC Shah Alam";
        //            vals43[1] = "UNITAR Klang Valley";
        //            vals43[2] = "UNITAR Penang";
        //            prop.Input.BuildElementDelegate = function (element) {
        //                element.dropdownSelect(
        //                {
        //                    nullLabel: "- Please Select -",
        //                    nullValue: "",
        //                    choices: vals43
        //                });
        //                element.width(inputWidth);
        //            };

        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //    }
        //    //#endregion                
        //}
        ////#endregion

        ////#region Group: Attachment
        //{
        //    var inputWidth = "150px";
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Attachments";
        //    ctrl.Groups.push(grp);

        //    //#region Section: Generic
        //    {
        //        var sec = new teq.EntityPropertiesFormSection();
        //        grp.Sections.push(sec);

        //        //#region Field: Document Attachment
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Document Attachment";
        //            prop.Input = new teq.EntityHtmlContentInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                inputUpload = $("<form />");
        //                element.append(inputUpload);
        //                teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");
        //            };
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Document Attachment
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Document Attachment";
        //            prop.Input = new teq.EntityHtmlContentInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                inputUpload = $("<form />");
        //                element.append(inputUpload);
        //                teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");
        //            };
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Document Attachment
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Document Attachment";
        //            prop.Input = new teq.EntityHtmlContentInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                inputUpload = $("<form />");
        //                element.append(inputUpload);
        //                teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");
        //            };
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion

        //        //#region Field: Document Attachment
        //        {
        //            var prop = new teq.EntityProperty();
        //            prop.Label = "Document Attachment";
        //            prop.Input = new teq.EntityHtmlContentInput();
        //            prop.Input.BuildElementDelegate = function (element) {

        //                inputUpload = $("<form />");
        //                element.append(inputUpload);
        //                teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");
        //            };
        //            sec.Properties.push(prop);
        //        }
        //        //#endregion
        //    }
        //    //#endregion    
        //}
        ////#endregion

        ////#region Group: Others
        //{
        //    var inputWidth = "150px";
        //    var grp = new teq.EntityPropertiesGroup();
        //    grp.Name = "Others";
        //    ctrl.Groups.push(grp);
        //}
        ////#endregion


        ctrl.Initialize();
    }


    this.DeleteRecord = function (id, name) {
        var msg = "Delete Record:<br><br>\"" + name + "\"<br><br>Deleted record cannot be recovered. Are you sure?";
        teq.Context.Confirm(msg, function () {
            teq.Context.ToastTape("Record deleted successfully.");
            //ClaimsAjaxGateway.DeleteClaimForLoss(id, function (res) {
            //    if (res.error == null) {
            //        if (res.value.Code == teq.Context.SuccessErrorCode) {
            //            self.ListControlller.RefreshList();
            //            teq.Context.ToastTape("Record deleted successfully.");
            //        }
            //        else teq.Context.Alert(res.value.Name);
            //    }
            //});
        });
    }
    //#endregion


}