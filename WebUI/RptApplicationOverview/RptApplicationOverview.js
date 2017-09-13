local.RptApplicationOverviewPageController = function (idPrefix) {
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    var btnSearch = "#" + idPrefix + "_btnSearch";

    var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

    var txtSearchFrom = "#" + idPrefix + "_dpSearchFrom";
    var txtSearchTo = "#" + idPrefix + "_dpSearchTo";
    //var chkSearchTSP = "#" + idPrefix + "_chkSearchTSP";

    var btnExport = "#" + idPrefix + "_btnExport";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {

        BuildSurfaceListing();

        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).click(function () {
            SearchReport(true);
        });
        
    }

    this.Activated = Activated;
    function Activated() {
        //Todo
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportStudentProgressSummary)) {
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
            Name: "Report - Application Overview",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        $(txtSearchFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));


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

            $(btnExport).attr('disabled', false); //Enable the Export button


            SearchReport(false);

            /*
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var intakefrom = $(txtSearchFrom).val() == "" ? null : $(txtSearchFrom).val();
            var intakeTo = $(txtSearchTo).val() == "" ? null : $(txtSearchTo).val();

            if (intakefrom == null || intakeTo == null) {
                teq.Context.Alert("<b>Application Date Range</b> cannot be blank.");
                return false;
            }
            RptApplicationOverviewAjaxGateway.GetResult(intakefrom, intakeTo, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null)
                {
                    self.ListControlller.Populate(res.value);
                }
            });
            */
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var htr = $("<tr></tr>");

            //Loop for first TR
            for (var i = 0; i < tbl.Columns.length; i++) {
                var col = tbl.Columns[i];
                htr.append(("<td rowspan=2 align=center>" + col.Name + "</td>"));
            }


            var thead = $(thdList);
            thead.empty();
            thead.append(htr);
            //thead.append(htr2);


            //$(btnShowSearch).click();
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                for (var j = 0; j < tbl.Columns.length; j++) {
                    var col = tbl.Columns[j];

                    //var colValue = teq.Common.FormatString(dr[col.Name]);
                    var colValue = dr[col.Name];
                    
                    if (col.Name.indexOf("Date") > 0) colValue = teq.Common.FormatDate(new Date(colValue));
                    //if (col.Name.indexOf("Result") > 0) colValue = Math.round(colValue);

                    if (i + 1 == tbl.Rows.length) {//Last Row, Means Total Row

                        if (colValue == -1) colValue = ""; //Do not display -1
                        colValue = "<b>" + colValue + "<b>";

                    }

                    tr.append(("<td align=center>" + colValue + "</td>"));
                }
                tbody.append(tr);
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();

        //Yip - Hide Paging
        $(tblPager).hide();
    }
    function SearchReport(IsExport) {
        var order = self.ListControlller.ListOrderManager.GetOrder();
        var pg = self.ListControlller.CurrentPage;

        var intakefrom = $(txtSearchFrom).val() == "" ? null : $(txtSearchFrom).val();
        var intakeTo = $(txtSearchTo).val() == "" ? null : $(txtSearchTo).val();

        if (intakefrom == null || intakeTo == null) {
            teq.Context.Alert("<b>Application Date Range</b> cannot be blank.");
            return false;
        }
        if (!IsExport) {
            RptApplicationOverviewAjaxGateway.GetResult(intakefrom, intakeTo, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }
        else {
            RptApplicationOverviewAjaxGateway.GetResult(intakefrom, intakeTo, true, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptApplicationOverview");
                }
            });
            
        }
    }

    //var Title = "Student Intake Summary Report";
    var Title = "Student Progress Summary Report";
    self.Title = Title;

}