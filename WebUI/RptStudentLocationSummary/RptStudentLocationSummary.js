﻿local.RptStudentLocationSummaryPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divMain";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";

    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

    var cboSearchYearFrom = "#" + idPrefix + "_cboSearchYearFrom";
    var cboSearchYearTo = "#" + idPrefix + "_cboSearchYearTo";

    var btnExport = "#" + idPrefix + "_btnExport";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tftList = "#" + idPrefix + "_tftList";

    var tblPager = "#" + idPrefix + "_tblPager";

    var divChart = "#" + idPrefix + "_divChart";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing();

        var today = new Date();
        for (year = 2012; year <= today.getFullYear() ; year++) {
            $(cboSearchYearFrom).append('<option val="'+year+'">'+year+'</option>');
            $(cboSearchYearTo).append('<option val="' + year + '">' + year + '</option>');
        }
        $(cboSearchYearTo).val(today.getFullYear());


        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {

            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var yearfrom = $(cboSearchYearFrom).val();
            var yearto = $(cboSearchYearTo).val();

            RptStudentLocationSummaryAjaxGateway.GetResult(yearfrom, yearto, true, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptStudentLocationSummary");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportStudentLocationSummary)) {
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
            Name: "Report - Student Location Summary",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

    }

    this.Shown = function () {
        //self.ListControlller.ShowSearchForm($(window).width() - ($(btnShowSearch).parent().closest('div').offset().left + $(btnShowSearch).parent().closest('div').outerWidth()));
    }
    function BuildSurfaceListing() {
        self.ListControlller = new teq.EntityListController();

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        self.ListControlller.divSearch = $(divSearch);
        self.ListControlller.btnSearch = $(btnSearch);
        self.ListControlller.btnToggleSearch = $(btnShowSearch);
        //self.ListControlller.btnNew = $(btnNew);
        self.ListControlller.btnPinSearch = $(btnPinSearch);
        self.ListControlller.AutoSearch = false;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";

        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;
            
            var yearfrom = $(cboSearchYearFrom).val();
            var yearto = $(cboSearchYearTo).val();
            //var tsp = $(chkSearchTSP).checkboxList("getValues");
            //var course = $(chkSearchCourse).checkboxList("getValues");




            RptStudentLocationSummaryAjaxGateway.GetResult(yearfrom, yearto, false, function (res) {
                if (res.error == null) {
                    // self.ListControlller.Populate(res.value);

                    //tbl = res.value;
                    //teq.Common.Reveal(tbl.Rows[12]);
                    //alert(tbl.Rows[12]["Jan 2016"]);
                    //alert(tbl.Columns.length);

                    self.ListControlller.PopulateHeaderDelegate(res.value);
                    self.ListControlller.PopulateDataDelegate(res.value);

                    $(divList).show();

                }
            });



        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl2) {
                    var htr = $("<tr></tr>");

                    for (var i = 0; i < tbl2.Columns.length; i++) {
                        var col = tbl2.Columns[i];
                        htr.append(("<td align=center>" + col.Name + "</td>"));
                    }

                    var thead = $(thdList);
                    thead.empty();
                    thead.append(htr);

                    $(btnShowSearch).click();

        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            
            var tbody = $(tbdList);
            tbody.empty();
            var tfoot = $(tftList);
            tfoot.empty();

            var grandTotal = [];

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                for (var j = 0; j < tbl.Columns.length; j++) {
                    var col = tbl.Columns[j];
                    tr.append(("<td align=center>" + dr[col.Name] + "</td>"));
                    if (col.Name != "State") {
                        var ttl = parseInt(dr[col.Name]);
                        if (grandTotal[j - 1] + "" == "undefined") grandTotal[j - 1] = 0;
                        grandTotal[j - 1] += ttl;
                    }
                }
                tbody.append(tr);

                if (i == tbl.Rows.length - 1) { //Run Once for Footer
                    var tr = $("<tr></tr>");
                    tr.append("<td>Total</td>");
                    for (var c = 0; c < grandTotal.length; c++) {
                        tr.append("<td>"+grandTotal[c]+"</td>");
                    }
                    tfoot.append(tr);
                }
            }


            //Generate Chart
            RptStudentLocationSummaryAjaxGateway.GetColumnChart(function (res) {
                if (res.error == null) {
                    imgURL = res.value;
                    $(divChart).empty();
                    $(divChart).append("<img src='" + imgURL + "' />");
                }
            });
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Student Location Summary Report";
    self.Title = Title;

}