local.RptIntakeBySponsorshipPageController = function (idPrefix) {
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
    var chkSearchTSP = "#" + idPrefix + "_chkSearchTSP";
    var chkSearchSponsor = "#" + idPrefix + "_chkSearchSponsor";

    var btnExport = "#" + idPrefix + "_btnExport";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";
    var tftList = "#" + idPrefix + "_tftList";

    var divChart = "#" + idPrefix + "_divChart";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {
        BuildSurfaceListing();

        var today = new Date();
        for (year = 2012; year <= today.getFullYear() ; year++) {
            $(cboSearchYearFrom).append('<option val="' + year + '">' + year + '</option>');
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
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            var sponsor = $(chkSearchSponsor).checkboxList("getValues");

            RptIntakeBySponsorshipAjaxGateway.GetResult(yearfrom, yearto, tsp, sponsor, true, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptIntakeBySponsorship");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportActiveStudentSummary)) {
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
            Name: "Report - Intake By Sponsorship",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        TSPManagementAjaxGateway.GetAllTSP(function (res) {
            //teq.Common.Reveal(res);
            //alert(res.value.length)
            //val = res.value[0];
            //alert(val.Label);

            TSPList = [];
            for (i = 0; i < res.value.length; i++) {
                val = res.value[i];
                TSPList[val.Value] = val.Label;
            }

            $(chkSearchTSP).checkboxList(
            {
                columnSpacing: 20,
                valuesChanged: null,
                choices: TSPList, //Flags.TradeType,
                showLinks: true,
                columns: 1
            }
            );
        });

        $(chkSearchSponsor).checkboxList(
        {
            columnSpacing: 20,
            valuesChanged: null,
            choices: Enums.SponsorType, //Flags.TradeType,
            //showLinks: true,
            columns: 1
        }
        );


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
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            var sponsor = $(chkSearchSponsor).checkboxList("getValues");

            RptIntakeBySponsorshipAjaxGateway.GetResult(yearfrom, yearto, tsp, sponsor, false, function (res) {
                if (res.error == null) {
                    self.ListControlller.PopulateHeaderDelegate(res.value);
                    self.ListControlller.PopulateDataDelegate(res.value);
                    $(divList).show();
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var htr = $("<tr></tr>");

            for (var i = 0; i < tbl.Columns.length; i++) {
                var col = tbl.Columns[i];
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
                    if (col.Name != "Intake") {
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
                        tr.append("<td>" + grandTotal[c] + "</td>");
                    }
                    tfoot.append(tr);
                }
            }

            //Generate Chart
            RptIntakeBySponsorshipAjaxGateway.GetColumnChart(function (res) {
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

    var Title = "Intake By Sponsorship Report";
    self.Title = Title;

}