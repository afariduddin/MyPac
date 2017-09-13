local.RptExamAnalysisPageController = function (idPrefix) {
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

    var txtSearchIntakeFrom = "#" + idPrefix + "_dpSearchIntakeFrom";
    var txtSearchIntakeTo = "#" + idPrefix + "_dpSearchIntakeTo";
    var selSearchCourse = "#" + idPrefix + "_selSearchCourse";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";
    var chkSearchTSP = "#" + idPrefix + "_chkSearchTSP";

    var btnExport = "#" + idPrefix + "_btnExport";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    var searchShown = true;
    var SettingType;

    this.Initialize = Initialize;
    function Initialize() {

        $(selSearchContractType).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.ContractType
        });

        //$(selSearchSponsorshipType).dropdownSelect({
        //    nullValue: -1,
        //    nullLabel: "- Select All -",
        //    choices: Enums.SponsorType
        //});
        SponsorAjaxGateway.GetAllSponsor(function (res) {
            //teq.Common.Reveal(res);
            //alert(res.value.length)
            //val = res.value[0];
            //alert(val.Label);
            //alert(res.length);
            SponsorList = [];
            for (i = 0; i < res.value.length; i++) {
                val = res.value[i];
                SponsorList[val.Value] = val.Label;
            }
            $(chkSearchSponsorshipType).checkboxList(
            {
                columnSpacing: 20,
                valuesChanged: null,
                choices: SponsorList, //Flags.TradeType,
                showLinks: true,
                columns: 1
            }
            );
        });

        TSPManagementAjaxGateway.GetAllTSP(function (res) {

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

        CourseManagementAjaxGateway.GetAllCourses(function (res) {
            CourseList = [];
            for (i = 0; i < res.value.length; i++) {
                val = res.value[i];
                CourseList[val.Value] = val.Label;
            }

            $(selSearchCourse).dropdownSelect(
            {
                choices: CourseList, //Flags.TradeType,
            }
            );

        });

        BuildSurfaceListing();

        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {

            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var intakefrom = $(txtSearchIntakeFrom).val() == "" ? null : $(txtSearchIntakeFrom).val();
            var intakeTo = $(txtSearchIntakeTo).val() == "" ? null : $(txtSearchIntakeTo).val();

            var course = $(selSearchCourse).val();
            var contractType = $(selSearchContractType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            //var statusType = $(selSearchStatus).val();

            if ((intakefrom == null || intakeTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Intake Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (intakefrom == null || intakeTo == null) {
                teq.Context.Alert("<b>Intake Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            RptExamAnalysisAjaxGateway.GetResult(intakefrom, intakeTo, contractType, sponsorshipType, tsp, course, true, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptExamAnalysis");
                }
            });
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportStudentExamAnalysis)) {
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
            Name: "Report - Student Exam Analysis",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        $(txtSearchIntakeFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchIntakeFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchIntakeTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true, yearRange: "-100:+5"
        });
        $(txtSearchIntakeTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));



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

            var intakefrom = $(txtSearchIntakeFrom).val() == "" ? null : $(txtSearchIntakeFrom).val();
            var intakeTo = $(txtSearchIntakeTo).val() == "" ? null : $(txtSearchIntakeTo).val();

            var course = $(selSearchCourse).val();
            var contractType = $(selSearchContractType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            //var statusType = $(selSearchStatus).val();

            if ((intakefrom == null || intakeTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Intake Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (intakefrom == null || intakeTo == null) {
                teq.Context.Alert("<b>Intake Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            RptExamAnalysisAjaxGateway.GetResult(intakefrom, intakeTo, contractType, sponsorshipType, tsp, course, false, function (res) {
                if (res.error == null)
                {
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

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                for (var j = 0; j < tbl.Columns.length; j++) {
                    var col = tbl.Columns[j];
                    tr.append(("<td align=center>" + dr[col.Name] + "</td>"));
                }
                tbody.append(tr);
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    //var Title = "Student Intake Summary Report";
    var Title = "Student Exam Analysis Report";
    self.Title = Title;

}