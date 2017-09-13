/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.RegistrationDataProcessingPageController = function (idPrefix) {


    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";
    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

    var searchShown = true;
    var allowedit = null;


    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";
    var btnNew = "#" + idPrefix + "_btnNew";

    var btnCulvert = $("<span class='Button'> Culvert </span>");
    var btnGuardrails = $("<span class='Button'> Guardrails </span>");
    var btnSignages = $("<span class='Button'> Signages </span>");
    var btnTrafficLight = $("<span class='Button'> Traffic Light </span>");
    var btnLineMarkings = $("<span class='Button'> Line Markings </span>");
    var btnRoadShoulder = $("<span class='Button'> Road Shoulder </span>");
    var btnRoadsideDrain = $("<span class='Button'> Roadside Drain </span>");
    var btnOthers = $("<span class='Button'> Others </span>")
    var rptTypes = 0;
    var btnCulvert2 = $("<span class='Button'> Culvert </span>");
    var btnGuardrails2 = $("<span class='Button'> Guardrails </span>");
    var btnSignages2 = $("<span class='Button'> Signages </span>");
    var btnTrafficLight2 = $("<span class='Button'> Traffic Light </span>");
    var btnLineMarkings2 = $("<span class='Button'> Line Markings </span>");
    var btnRoadShoulder2 = $("<span class='Button'> Road Shoulder </span>");
    var btnRoadsideDrain2 = $("<span class='Button'> Roadside Drain </span>");
    var btnOthers2 = $("<span class='Button'> Others </span>")

    var btns1 = [];
    btns1.push(btnCulvert);
    btns1.push(btnGuardrails);
    btns1.push(btnSignages);
    btns1.push(btnTrafficLight);
    btns1.push(btnLineMarkings);
    btns1.push(btnRoadShoulder);
    btns1.push(btnRoadsideDrain);
    btns1.push(btnOthers);
    var btns2 = [];
    btns2.push(btnCulvert2);
    btns2.push(btnGuardrails2);
    btns2.push(btnSignages2);
    btns2.push(btnTrafficLight2);
    btns2.push(btnLineMarkings2);
    btns2.push(btnRoadShoulder2);
    btns2.push(btnRoadsideDrain2);
    btns2.push(btnOthers2);
    //#endregion

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize() {
        buildButton();
        BuildCulvertListing();
        BuildInspectionListing();
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
            Name: "Registration / Application - Data Processing",
            Link: local.aspxContent_RoadInfoDataProcessing1
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = 1;
    }
    //#endregion

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }

    //#region build button
    function buildButton() {

        var div = $("<div style='border-right:solid 1px #888888;'>")
        var div2 = $("<div >")


        var table = $("<table >");
        var trCulvert = $("<tr vallign='middle'>");
        var tdCulvert = $("<td >");

        var table2 = $("<table >");

        var trInspection = $("<tr vallign='middle'>");
        var tdInspection = $("<td>");
        trInspection.append(tdCulvert);
        trInspection.append(tdInspection);
        table.append(trCulvert);
        table2.append(trInspection);
        div.append(table);
        div2.append(table2);

        var tablewrap = $("<table style='width:500px;'>")
        var trwrap = $("<tr style='vertical-align:top;'>");
        var tdwrap1 = $("<td>");
        var tdwrap2 = $("<td>");
        tablewrap.append(trwrap);
        trwrap.append(tdwrap1);
        trwrap.append(tdwrap2);
        tdwrap1.append(div);
        tdwrap2.append(div2);
        $(divModuleBtn).append(tablewrap);

        var tableCulvert = $("<table>");
        var trCulvertTitle = $("<tr>");
        var tdCulvertTitle = $("<td>");
        trCulvertTitle.append(tdCulvertTitle);
        tableCulvert.append(trCulvertTitle);

        var tableInspection = $("<table>");
        var trInspectionTitle = $("<tr>");
        var tdInspectionTitle = $("<td>");
        trInspectionTitle.append(tdInspectionTitle);
        tableInspection.append(trInspectionTitle);


        tdCulvertTitle.append("<div style='  text-align:left;'><span > <b>Culvert & Furniture Data</b> <br/>  Add / Modify / View Drainage & Roadside Furniture Data. <br/><br/></span></div>");
        $(tdCulvert).append(tableCulvert);
        for (i = 0 ; i < btns1.length ; i++) {
            buildButtonCulvertNavigation(tableCulvert, btns1[i], i);
        };

        tdInspectionTitle.append("<div style=' text-align:left; '><span > <b>Inspection Data</b> <br/>  Add / Modify / View Drainage & Roadside Furniture Inspection Data. <br/><br/> </span></div>");
        $(tdInspection).append(tableInspection);

        for (i = 0 ; i < btns2.length ; i++) {
            buildButtonInspectionNavigation(tableInspection, btns2[i]);
        };
    }

    function ChangeToggleSearchButtonArrow() {

        if (searchShown == true) {

            ArrowImageicon.attr("src", "Resource/ToggleSearchDownIcon.png");

            searchShown = false;
        }
        else {

            ArrowImageicon.attr("src", "Resource/ToggleSearchUpIcon.png");

            searchShown = true;
        }
    }

    function buildButtonCulvertNavigation(hook, btn, rptType) {

        var button = $("<button class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icons' role='button' aria-disabled='false' style='width:200px;'></button>");
        //var SpanIcon =$("<span class='ui-button-icon-primary ui-icon ui-icon-search'></span>");
        var SpanText = $("<span class='ui-button-text'></span>");
        // var SpanSecond=$("<span class='ui-button-icon-secondary ui-icon ui-icon-triangle-1-n'></span>");
        var _rptType = rptType + 1;

        // alert(rptType);

        SpanText.append(btn.html());
        button.append(SpanText);

        var tr = $("<tr>");
        var td = $("<td>");
        tr.append(td);
        hook.append(tr);
        //var divWrapButton = $("<div style='float:left; padding:10px 5px 5px 10px'><div/>");
        //divWrapButton.append(btn);
        td.append(button);
        td.append("<br/>");
        button.click(function () {
            self.rptTypes = _rptType;
            local.AdvancedSearchModule = button.children().html();
            local.ShowPage(null, function () {
                allowedit = true;
                $(spanTitle).html("Data Processing - " + btn.html());
                var res = { "value": { "DataTable": new Ajax.Web.DataTable([["ID", "System.Int32"], ["UserName", "System.String"], ["FullName", "System.String"], ["Email", "System.String"], ["Description", "System.String"], ["DepartmentFlag", "System.String"], ["CreatedBy", "System.String"], ["CreatedDate", "System.DateTime"], ["ModifiedBy", "System.String"], ["ModifiedDate", "System.DateTime"], ["SiteFlags", "System.String"], ["RowNum", "System.Int64"]], [[256, "HAHHAS", "A HASAN, Hasdi", "hasdi_hasan@astro.com.my", null, "PnP", "KAMRKHAI", new Date(2014, 0, 16, 16, 16, 53, 970), "HAKHASH", new Date(2014, 1, 12, 10, 41, 16, 587), "AABC,CBC,", 1], [273, "MKHAHMO", "AB HAMID, Mohd Khairul Hafiz", "hafiz_hamid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 240), "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 303), "AABC,CBC,", 2], [320, "RFAARROS", "ABD RASHID, Rose Farah Ashidah", "rose-farah-ashidah_abd-rashid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 1, 19, 16, 56, 31, 187), "HAKHASH", new Date(2014, 1, 19, 17, 2, 46, 753), "AABC,CBC,", 3], [176, "KHARKHA", "ABD. RAHMAN, Khairul Hisham", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 157), "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 223), "AABC,CBC,WP,", 4], [136, "AAAANITH", "ABDUL AZIZ, Anith", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 16, 50, 44, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 29, 307), "AABC,CBC,", 5], [282, "AAAATHI", "ABDUL AZIZ, Athirah", "athirah_aziz@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 743), "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 807), "AABC,CBC,", 6], [138, "MHAJMUHA", "ABDUL JALIL, Muhammad Haziq", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 6, 36, 417), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 33, 667), "AABC,CBC,", 7], [127, "AHAKAH", "ABDUL KADIR, Ahmad Hafidz ", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 723), "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 793), "AABC,CBC,", 8], [166, "NPALNOO", "ABDUL LATIF, Noor Paridah", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 823), "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 893), "AABC,CBC,WP,", 9], [269, "MAHARMO", "ABDUL RAHIM, Mohd Aisar Hafidz", "hafidz_rahim@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 703), "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 783), "AABC,CBC,", 10], [14, "NHABNU", "Abu Bakar, Nur Hazlina", null, null, "ML", "admin", new Date(2014, 0, 3, 13, 28, 14, 610), "SKCSOOKI", new Date(2014, 0, 16, 11, 30, 44, 797), "AABC,CBC,WP,", 11], [139, "NABNURLI", "ABU BAKAR, Nurlina", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 7, 8, 293), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 37, 787), "AABC,CBC,", 12], [327, "admin", "Administrator", null, null, "BSD", null, null, "admin", new Date(2014, 2, 20, 11, 52, 25, 873), "AABC,ACBC,CBC,WP,", 13], [232, "NAANOORA", "AFANDI, Noor Azlien", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 613), "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 687), "AABC,CBC,WP,", 14], [92, "AFMYAHM", "Ahmad Faisol B Mohd Yusof", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 883), "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 970), "AABC,", 15], [122, "ARASHAB", "AHMAD SHUKRI, Abdul Rahman", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 790), "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 883), "AABC,CBC,", 16], [281, "AAAMINA", "AHMAD, Amin", "amin_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 15, 44, 810), "HAKHASH", new Date(2014, 1, 25, 11, 19, 43, 843), "AABC,CBC,", 17], [262, "NANOOLI", "AHMAD, Noorliza", "noorliza_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 32, 10, 557), "HAKHASH", new Date(2014, 1, 12, 10, 42, 59, 983), "AABC,CBC,", 18], [81, "AAARJAL", "ALAUDDIN AWANG ABD RAHMAN@JUSOH", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 130), "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 200), "AABC,CBC,", 19], [140, "NAANURDI", "AMER, Nurdiyana 'amera", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 11, 6, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 41, 787), "AABC,CBC,", 20], [293, "NANOOR", "AMIR, Noorliana", "noorliana_amir@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 777), "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 857), "AABC,CBC,", 21], [268, "NAANURULAM", "AMRAN, Nurul Akma", "akma_amran@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 860), "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 923), "AABC,CBC,", 22], [113, "MAMURAL", "ANBALAGAN, Muralitharan", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 417), "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 533), "AABC,CBC,", 23], [82, "AJANDRE", "ANDREW JAYASEELAN", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 273), "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 367), "AABC,CBC,", 24], [100, "AWJANN", "Ann Wan Joo", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 460), "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 553), "AABC,", 25]]), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };

                self.ListControlller.Populate(res.value);

                ChangeToggleSearchButtonArrow();

            });

        });
    }

    function buildButtonInspectionNavigation(hook, btn) {

        var button = $("<button class='ui-button ui-widget ui-state-default ui-corner-all ui-button-text-icons' role='button' aria-disabled='false' style='width:200px;'></button>");
        // var SpanIcon = $("<span class='ui-button-icon-primary ui-icon ui-icon-search'></span>");
        var SpanText = $("<span class='ui-button-text'></span>");
        // var SpanSecond=$("<span class='ui-button-icon-secondary ui-icon ui-icon-triangle-1-n'></span>");



        SpanText.append(btn.html());
        button.append(SpanText);

        var tr = $("<tr>");
        var td = $("<td>");
        tr.append(td);
        hook.append(tr);
        //var divWrapButton = $("<div style='float:left; padding:10px 5px 5px 10px'><div/>");
        //divWrapButton.append(btn);
        td.append(button);
        td.append("<br/>");
        button.click(function () {
            local.AdvancedSearchModule = "Culvert";
            allowedit = true;
            $(spanTitle).html("Data Processing - " + btn.html());
            var res = { "value": { "DataTable": new Ajax.Web.DataTable([["ID", "System.Int32"], ["UserName", "System.String"], ["FullName", "System.String"], ["Email", "System.String"], ["Description", "System.String"], ["DepartmentFlag", "System.String"], ["CreatedBy", "System.String"], ["CreatedDate", "System.DateTime"], ["ModifiedBy", "System.String"], ["ModifiedDate", "System.DateTime"], ["SiteFlags", "System.String"], ["RowNum", "System.Int64"]], [[256, "HAHHAS", "A HASAN, Hasdi", "hasdi_hasan@astro.com.my", null, "PnP", "KAMRKHAI", new Date(2014, 0, 16, 16, 16, 53, 970), "HAKHASH", new Date(2014, 1, 12, 10, 41, 16, 587), "AABC,CBC,", 1], [273, "MKHAHMO", "AB HAMID, Mohd Khairul Hafiz", "hafiz_hamid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 240), "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 303), "AABC,CBC,", 2], [320, "RFAARROS", "ABD RASHID, Rose Farah Ashidah", "rose-farah-ashidah_abd-rashid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 1, 19, 16, 56, 31, 187), "HAKHASH", new Date(2014, 1, 19, 17, 2, 46, 753), "AABC,CBC,", 3], [176, "KHARKHA", "ABD. RAHMAN, Khairul Hisham", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 157), "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 223), "AABC,CBC,WP,", 4], [136, "AAAANITH", "ABDUL AZIZ, Anith", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 16, 50, 44, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 29, 307), "AABC,CBC,", 5], [282, "AAAATHI", "ABDUL AZIZ, Athirah", "athirah_aziz@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 743), "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 807), "AABC,CBC,", 6], [138, "MHAJMUHA", "ABDUL JALIL, Muhammad Haziq", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 6, 36, 417), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 33, 667), "AABC,CBC,", 7], [127, "AHAKAH", "ABDUL KADIR, Ahmad Hafidz ", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 723), "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 793), "AABC,CBC,", 8], [166, "NPALNOO", "ABDUL LATIF, Noor Paridah", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 823), "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 893), "AABC,CBC,WP,", 9], [269, "MAHARMO", "ABDUL RAHIM, Mohd Aisar Hafidz", "hafidz_rahim@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 703), "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 783), "AABC,CBC,", 10], [14, "NHABNU", "Abu Bakar, Nur Hazlina", null, null, "ML", "admin", new Date(2014, 0, 3, 13, 28, 14, 610), "SKCSOOKI", new Date(2014, 0, 16, 11, 30, 44, 797), "AABC,CBC,WP,", 11], [139, "NABNURLI", "ABU BAKAR, Nurlina", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 7, 8, 293), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 37, 787), "AABC,CBC,", 12], [327, "admin", "Administrator", null, null, "BSD", null, null, "admin", new Date(2014, 2, 20, 11, 52, 25, 873), "AABC,ACBC,CBC,WP,", 13], [232, "NAANOORA", "AFANDI, Noor Azlien", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 613), "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 687), "AABC,CBC,WP,", 14], [92, "AFMYAHM", "Ahmad Faisol B Mohd Yusof", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 883), "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 970), "AABC,", 15], [122, "ARASHAB", "AHMAD SHUKRI, Abdul Rahman", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 790), "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 883), "AABC,CBC,", 16], [281, "AAAMINA", "AHMAD, Amin", "amin_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 15, 44, 810), "HAKHASH", new Date(2014, 1, 25, 11, 19, 43, 843), "AABC,CBC,", 17], [262, "NANOOLI", "AHMAD, Noorliza", "noorliza_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 32, 10, 557), "HAKHASH", new Date(2014, 1, 12, 10, 42, 59, 983), "AABC,CBC,", 18], [81, "AAARJAL", "ALAUDDIN AWANG ABD RAHMAN@JUSOH", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 130), "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 200), "AABC,CBC,", 19], [140, "NAANURDI", "AMER, Nurdiyana 'amera", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 11, 6, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 41, 787), "AABC,CBC,", 20], [293, "NANOOR", "AMIR, Noorliana", "noorliana_amir@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 777), "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 857), "AABC,CBC,", 21], [268, "NAANURULAM", "AMRAN, Nurul Akma", "akma_amran@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 860), "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 923), "AABC,CBC,", 22], [113, "MAMURAL", "ANBALAGAN, Muralitharan", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 417), "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 533), "AABC,CBC,", 23], [82, "AJANDRE", "ANDREW JAYASEELAN", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 273), "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 367), "AABC,CBC,", 24], [100, "AWJANN", "Ann Wan Joo", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 460), "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 553), "AABC,", 25]]), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };

            self.ListControlller1.Populate(res.value);
            ChangeToggleSearchButtonArrow();

        });
    }
    //#endregion

    //#region build culvert /furniture listing

    function BuildCulvertListing() {

        self.ListControlller = new teq.EntityListController();
        //#region Elements  

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        // self.ListControlller.btnToggleSearch = $(btnShowSearch);


        //self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        self.ListControlller.btnNew = $(btnNew);
        //#endregion
        //#region Settings
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;
        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";
        //#endregion

        //#region Delegates       
        self.ListControlller.SearchDelegate = function () {


        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            //teq.Common.BuildColumnIndexes(tbl);

            var ctd = $("<td align=center/>");
            //ctd.append(this.MultiSelector.BuildSelectorControl());

            var htr = $("<tr></tr>");

            htr.append("<td >No.</td>");
            htr.append("<td >District code</td>");
            htr.append("<td >Road Name</td>");
            htr.append("<td >Road ID</td>");
            htr.append("<td >Route ID</td>");
            htr.append("<td >Section ID</td>");
            htr.append("<td >From CH</td>");
            htr.append("<td >To CH</td>");
            htr.append("<td >Culvert ID</td>");
            htr.append("<td >Culvert Type</td>");
            htr.append("<td >Structure</td>");
            htr.append("<td >No of Cells</td>");
            htr.append("<td >Installation Date</td>");
            htr.append("<td >Updated By</td>");
            htr.append("<td >Updated On</td>");

            htr.append("<td width=100px>Action</td>");

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

        self.ListControlller.PopulateDataDelegate = function (tbl, rptType) {
            var tbody = $(tbdList);
            tbody.empty();

            var roadname = [];
            roadname.push("Jalan Legoland");
            roadname.push("Lebuh Medini Timur 2");
            roadname.push("Lebuh Medini Timur 20");
            roadname.push("Lebuh Medini Timur 17");
            roadname.push("Lebuh Medini Timur 17/7");
            roadname.push("Lebuh Medini Timur 17/8");
            roadname.push("Lebuh Medini Timur 17/10");
            roadname.push("Lebuh Medini Utara 8");
            roadname.push("Jalan Medini Utara 8/1");
            roadname.push("Persiaran Medini 3");
            //roadname.push("Persiaran Kasturi");

            var culvertType = [];
            culvertType.push("Reinforced Concrete Pipe");
            culvertType.push("Box Culvert");
            culvertType.push("Arch Culvert");

            for (var i = 0; i < 25; i++) {
                var RoadID = "" + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10));
                var frmch = Math.floor((Math.random() * 5)) + "." + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10));
                var toch = Math.floor((Math.random() * 10)) + "." + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10));
                var tr = $("<tr></tr>");
                var count = i + 1;

                tr.append(("<td align=center> " + count + ". </td>"));

                tr.append(("<td align=center> 01 </td>"));
                tr.append(("<td align=center> " + roadname[Math.floor((Math.random() * 5))] + " </td>"));
                tr.append(("<td align=center> 0" + RoadID + "</td>"));
                tr.append(("<td align=center> 0" + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + Math.floor((Math.random() * 10)) + "</td>"));
                tr.append(("<td align=center>" + RoadID + ":0000 </td>"));
                tr.append(("<td align=center> " + frmch + " </td>"));
                tr.append(("<td align=center> " + toch + " </td>"));
                tr.append(("<td align=center> CL/01/10171/0.9880/-/-/-/RCP/BB/- </td>"));
                tr.append(("<td align=center> " + culvertType[Math.floor((Math.random() * 3))] + " </td>"));
                tr.append(("<td align=center> </td>"));
                tr.append(("<td align=center> " + Math.floor((Math.random() * 3)) + " cells </td>"));
                tr.append(("<td align=center> </td>"));
                tr.append(("<td align=center> </td>"));
                tr.append(("<td align=center> </td>"));
                tr.append(buileActionTd());
                tbody.append(tr);
            }
            function buileActionTd() {
                var actionTd = $("<td align=center/>");

                var editLnk = $("<a href='javascript:void(0);'>View / Edit</a>");
                editLnk.click(function (event) {
                    //self.EditUser(dr.ID);
                    buildEditDataDialog();
                    event.stopPropagation();
                });



                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                return actionTd;
            }
        }

        self.ListControlller.NewDelegate = function () {
            buildEditDataDialog();
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


            $(btnShowSearch_SpanIcon).append(SearchImageicon);
            $(btnShowSearch_SpanIcon).css("padding-right", "10px")
            $(btnShowSearch_SpanArrowIcon).append(ArrowImageicon);

            $(btnShowSearch).click(function () {
                // event.preventDefault();
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

    //#region build edit listing

    function BuildInspectionListing() {

        self.ListControlller1 = new teq.EntityListController();
        //#region Elements  

        self.ListControlller1.divList = $(divList);
        self.ListControlller1.tblPager = $(tblPager);
        self.ListControlller1.divSearch = $(divSearch);
        self.ListControlller1.btnSearch = $(btnSearch);
        // self.ListControlller1.btnToggleSearch = $(btnShowSearch);

        //self.ListControlller1.divSearch = $(divSearch);
        self.ListControlller1.btnSearch = $(btnSearch);
        self.ListControlller1.btnPinSearch = $(btnPinSearch);
        //#endregion
        //#region Settings
        self.ListControlller1.AutoSearch = false;
        self.ListControlller1.AutoDropSearch = false;

        self.ListControlller1.MultiSelector.SelectedRowClass = "Selected";
        //#endregion

        //#region Delegates       
        self.ListControlller1.SearchDelegate = function () {

            var res = { "value": { "DataTable": new Ajax.Web.DataTable([["ID", "System.Int32"], ["UserName", "System.String"], ["FullName", "System.String"], ["Email", "System.String"], ["Description", "System.String"], ["DepartmentFlag", "System.String"], ["CreatedBy", "System.String"], ["CreatedDate", "System.DateTime"], ["ModifiedBy", "System.String"], ["ModifiedDate", "System.DateTime"], ["SiteFlags", "System.String"], ["RowNum", "System.Int64"]], [[256, "HAHHAS", "A HASAN, Hasdi", "hasdi_hasan@astro.com.my", null, "PnP", "KAMRKHAI", new Date(2014, 0, 16, 16, 16, 53, 970), "HAKHASH", new Date(2014, 1, 12, 10, 41, 16, 587), "AABC,CBC,", 1], [273, "MKHAHMO", "AB HAMID, Mohd Khairul Hafiz", "hafiz_hamid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 240), "HAKHASH", new Date(2014, 0, 24, 18, 3, 9, 303), "AABC,CBC,", 2], [320, "RFAARROS", "ABD RASHID, Rose Farah Ashidah", "rose-farah-ashidah_abd-rashid@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 1, 19, 16, 56, 31, 187), "HAKHASH", new Date(2014, 1, 19, 17, 2, 46, 753), "AABC,CBC,", 3], [176, "KHARKHA", "ABD. RAHMAN, Khairul Hisham", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 157), "SKCSOOKI", new Date(2014, 0, 16, 9, 49, 17, 223), "AABC,CBC,WP,", 4], [136, "AAAANITH", "ABDUL AZIZ, Anith", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 16, 50, 44, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 29, 307), "AABC,CBC,", 5], [282, "AAAATHI", "ABDUL AZIZ, Athirah", "athirah_aziz@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 743), "HAKHASH", new Date(2014, 0, 24, 18, 16, 16, 807), "AABC,CBC,", 6], [138, "MHAJMUHA", "ABDUL JALIL, Muhammad Haziq", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 6, 36, 417), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 33, 667), "AABC,CBC,", 7], [127, "AHAKAH", "ABDUL KADIR, Ahmad Hafidz ", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 723), "SKCSOOKI", new Date(2014, 0, 15, 16, 37, 44, 793), "AABC,CBC,", 8], [166, "NPALNOO", "ABDUL LATIF, Noor Paridah", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 823), "SKCSOOKI", new Date(2014, 0, 16, 9, 46, 56, 893), "AABC,CBC,WP,", 9], [269, "MAHARMO", "ABDUL RAHIM, Mohd Aisar Hafidz", "hafidz_rahim@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 703), "HAKHASH", new Date(2014, 0, 24, 17, 58, 15, 783), "AABC,CBC,", 10], [14, "NHABNU", "Abu Bakar, Nur Hazlina", null, null, "ML", "admin", new Date(2014, 0, 3, 13, 28, 14, 610), "SKCSOOKI", new Date(2014, 0, 16, 11, 30, 44, 797), "AABC,CBC,WP,", 11], [139, "NABNURLI", "ABU BAKAR, Nurlina", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 7, 8, 293), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 37, 787), "AABC,CBC,", 12], [327, "admin", "Administrator", null, null, "BSD", null, null, "admin", new Date(2014, 2, 20, 11, 52, 25, 873), "AABC,ACBC,CBC,WP,", 13], [232, "NAANOORA", "AFANDI, Noor Azlien", null, null, "ML", "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 613), "SKCSOOKI", new Date(2014, 0, 16, 10, 55, 16, 687), "AABC,CBC,WP,", 14], [92, "AFMYAHM", "Ahmad Faisol B Mohd Yusof", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 883), "SKCSOOKI", new Date(2014, 0, 15, 0, 30, 5, 970), "AABC,", 15], [122, "ARASHAB", "AHMAD SHUKRI, Abdul Rahman", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 790), "SKCSOOKI", new Date(2014, 0, 15, 16, 35, 3, 883), "AABC,CBC,", 16], [281, "AAAMINA", "AHMAD, Amin", "amin_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 15, 44, 810), "HAKHASH", new Date(2014, 1, 25, 11, 19, 43, 843), "AABC,CBC,", 17], [262, "NANOOLI", "AHMAD, Noorliza", "noorliza_ahmad@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 32, 10, 557), "HAKHASH", new Date(2014, 1, 12, 10, 42, 59, 983), "AABC,CBC,", 18], [81, "AAARJAL", "ALAUDDIN AWANG ABD RAHMAN@JUSOH", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 130), "SKCSOOKI", new Date(2014, 0, 14, 23, 14, 52, 200), "AABC,CBC,", 19], [140, "NAANURDI", "AMER, Nurdiyana 'amera", null, null, "QA", "TBTHEIV", new Date(2014, 0, 15, 17, 11, 6, 800), "TBTHEIV", new Date(2014, 0, 16, 10, 34, 41, 787), "AABC,CBC,", 20], [293, "NANOOR", "AMIR, Noorliana", "noorliana_amir@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 777), "HAKHASH", new Date(2014, 0, 24, 18, 35, 9, 857), "AABC,CBC,", 21], [268, "NAANURULAM", "AMRAN, Nurul Akma", "akma_amran@astro.com.my", null, "PnP", "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 860), "HAKHASH", new Date(2014, 0, 24, 17, 49, 52, 923), "AABC,CBC,", 22], [113, "MAMURAL", "ANBALAGAN, Muralitharan", null, null, "TND", "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 417), "SKCSOOKI", new Date(2014, 0, 15, 16, 28, 56, 533), "AABC,CBC,", 23], [82, "AJANDRE", "ANDREW JAYASEELAN", null, null, "NPU", "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 273), "SKCSOOKI", new Date(2014, 0, 14, 23, 15, 20, 367), "AABC,CBC,", 24], [100, "AWJANN", "Ann Wan Joo", null, null, "SOC", "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 460), "SKCSOOKI", new Date(2014, 0, 15, 0, 34, 54, 553), "AABC,", 25]]), "TotalRecords": 315, "ListingRecordFrom": 1, "ListingRecordTo": 25, "TotalPages": 13, "CurrentPage": 1, "RecordsPerPage": 25 } };
            self.ListControlller1.Populate(res.value);
        }

        self.ListControlller1.PopulateHeaderDelegate = function (tbl) {
            //teq.Common.BuildColumnIndexes(tbl);

            var ctd = $("<td align=center/>");
            //ctd.append(this.MultiSelector.BuildSelectorControl());

            var htr = $("<tr></tr>");
            //htr.append(ctd);
            //htr.append("<td >No.</td>");
            htr.append("<td nowrap='nowrap'>Batch No</td>");
            htr.append("<td nowrap='nowrap'>Year</td>");
            htr.append("<td width='100%'>Description</td>");
            htr.append("<td nowrap='nowrap'>Created By</td>");
            htr.append("<td nowrap='nowrap'>Created On</td>");
            htr.append("<td nowrap='nowrap'>Last Update By</td>");
            htr.append("<td nowrap='nowrap'>Last Update On</td>");

            htr.append("<td  width='130px'>Action</td>");

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

        self.ListControlller1.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();
            for (var i = 0; i < 10; i++) {
                //var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                var count = i + 1;

                tr.append(("<td align=center> " + Math.floor((Math.random()) * 3) + "</td>"));
                tr.append(("<td align=center> 200" + Math.floor((Math.random()) * 3) + "</td>"));
                tr.append(("<td align=center> Unsealed visual inspection </td>"));
                tr.append(("<td align=center> Admin </td>"));
                tr.append(("<td align=center> 9/20/2013 </td>"));
                tr.append(("<td align=center> Admin </td>"));
                tr.append(("<td align=center> 9/20/2013 </td>"));

                tr.append(buileActionTd());
                tbody.append(tr);
            }
            //if (tbl.Rows.length == 0) {
            //    local.ListingEmptyRecord(tbody);
            //}
            function buileActionTd() {
                var actionTd = $("<td align=center nowrap='nowrap' />");

                var editLnk = $("<a href='javascript:void(0);'>View / Edit</a>");
                editLnk.click(function (event) {
                    //self.EditUser(dr.ID);
                    buildEditDataDialog();
                    event.stopPropagation();
                });



                actionTd.append(teq.Common.ThemeIcon("active", "pencil"), editLnk);

                return actionTd;
            }
        }

        self.ListControlller1.NewDelegate = function () {
            self.NewUser();
        }

        //#endregion

        self.ListControlller1.Initialize();

    }

    //#endregion

    //#region Build edit data dialogs
    function buildEditDataDialog() {
        var ctrl = new teq.EntityPropertiesDialogController();
        ctrl.DialogWidth = 800;
        ctrl.DialogHeight = 600;

        ctrl.LoadDelegate = function () {

            ctrl.Populate();
        }

        ctrl.SaveDelegate = function (entity, callback) {
            ctrl.Close();
        };
        ctrl.GetTitleDelegate = function (entity) {
            var title = "Road Data - Edit";
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
            grp.Name = "Culvert Details";
            ctrl.Groups.push(grp);
            //#region Section: Generic
            {
                var sec = new teq.EntityPropertiesGridSection();
                // sec.Name = "Shift information";
                sec.ConfigureGrids(3, 3);
                grp.Sections.push(sec);

                //#region Field: Road Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Culvert ID";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        element.width("400px");
                    };
                    sec.Grids[0][0].Property = prop;
                    sec.Grids[0][0].ColSpan = 3;
                }
                //#endregion

                //#region Field: MARRIS ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Section ID";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[1][0].Property = prop;
                }
                //#endregion
                //#region Field:FROM MARRIS CH
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Culvert Type";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[1][1].Property = prop;
                }
                //#endregion
                //#region Field: To MARRIS CH
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "No. Of Cells";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[1][2].Property = prop;
                }
                //#endregion

                //#region Field: Road ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Construction Date";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[2][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Culvert Size";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[2][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "KM Chainage";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec.Grids[2][2].Property = prop;
                }
                //#endregion

                var sec2 = new teq.EntityPropertiesGridSection();
                // sec.Name = "Shift information";
                sec2.ConfigureGrids(5, 3);
                grp.Sections.push(sec2);

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    //prop.Label = "KM Chainage";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append("<b><--------- INLET ---------></b>");
                    };
                    sec2.Grids[0][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Inlet Structure";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[1][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Inlet GPS X";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[2][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Inlet GPS Y";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[3][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Embarkment Height";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[4][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    //prop.Label = "KM Chainage";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.append("<b><-------- OUTLET --------></b>");
                    };
                    sec2.Grids[0][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Outlet Structure";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[1][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Outlet GPS X";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[2][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Outlet GPS Y";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[3][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Embarkment Height";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                    };
                    sec2.Grids[4][1].Property = prop;
                }
                //#endregion

                var sec3 = new teq.EntityPropertiesGridSection();
                // sec.Name = "Shift information";
                sec3.ConfigureGrids(4, 3);
                grp.Sections.push(sec3);

                //#region Field: Road Name
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Name";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        element.width("400px");
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[0][0].Property = prop;
                    sec3.Grids[0][0].ColSpan = 3;
                }
                //#endregion

                //#region Field: MARRIS ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Road Section ID";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[1][0].Property = prop;
                }
                //#endregion
                //#region Field:FROM MARRIS CH
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "From CH";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[1][1].Property = prop;
                }
                //#endregion
                //#region Field: To MARRIS CH
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "To CH";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[1][2].Property = prop;
                }
                //#endregion

                //#region Field: Road ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Route ID";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "District";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][2].Property = prop;
                }
                //#endregion

                //#region Field: Road ID
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Last Inspection Date";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][0].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Last Update By";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][1].Property = prop;
                }
                //#endregion

                //#region Field: MARRIS Update Date
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Last Update On";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityTextboxInput();
                    prop.Input.BuildElementDelegate = function (element) {
                        element.attr('disabled', 'disabled');
                    };
                    sec3.Grids[2][2].Property = prop;
                }
                //#endregion

            }
            //#endregion
        }
        //#endregion

        //#region Group: Road Info
        {
            var grp = new teq.EntityPropertiesGroup();
            grp.Name = "Attachment";
            ctrl.Groups.push(grp);
            //#region Section: 1
            {

                var sec = new teq.EntityPropertiesGridSection();

                sec.ConfigureGrids(3, 1);
                grp.Sections.push(sec);

                //#region Field: Document Attachment
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Document Attachment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        inputUpload = $("<form />");
                        element.append(inputUpload);
                        teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");

                    };
                    sec.Grids[0][0].Property = prop;
                    //sec.Grids[3][0].ColSpan = 3;
                }
                //#endregion
                //#region Field: Image Attachment
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Image Attachment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        inputUpload = $("<form />");
                        element.append(inputUpload);
                        teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");

                    };
                    sec.Grids[1][0].Property = prop;
                    //sec.Grids[3][0].ColSpan = 3;
                }
                //#endregion
                //#region Field: Video Attachment
                {
                    var prop = new teq.EntityProperty();
                    prop.Label = "Video Attachment";
                    //prop.MarkCompulsary = true;
                    prop.Input = new teq.EntityHtmlContentInput();
                    prop.Input.BuildElementDelegate = function (element) {

                        inputUpload = $("<form />");
                        element.append(inputUpload);
                        teq.Common.BuildSingleFileUploadInput(inputUpload, "500px", "FileUploadInput", "FileUploadInputHover", "myFile", 500000000, ["jpg", "png", "bmp", "gif", "msg", "zip", "rar", "7zip", "pdf", "txt", "doc", "docx", "ppt", "pptx", "xls", "xlsx", "rtf"], null, "Remove File");

                    };
                    sec.Grids[2][0].Property = prop;
                    //sec.Grids[3][0].ColSpan = 3;
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