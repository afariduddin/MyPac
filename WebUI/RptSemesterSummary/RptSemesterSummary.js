local.RptSemesterSummaryPageController = function (idPrefix) {
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
    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";
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
        $(selSearchGender).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.GenderType
        });

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

        BuildSurfaceListing();

        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var intakefrom = $(txtSearchIntakeFrom).val() == "" ? null : $(txtSearchIntakeFrom).val();
            var intakeTo = $(txtSearchIntakeTo).val() == "" ? null : $(txtSearchIntakeTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var contractType = $(selSearchContractType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            //var tsp = $(chkSearchTSP).checkboxList("getValues");
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
            RptSemesterSummaryAjaxGateway.GetResult(intakefrom, intakeTo, fullname, gender, contractType, sponsorshipType,
                false, order.Columns, order.Directions, pg, function (res) {
                    if (res.error == null) {
                        window.open("ExportReport.aspx?ReportName=RptSemesterSummary");
                    }
                });
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportSemesterSummary)) {
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
            Name: "Report - Semester Summary",
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
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var contractType = $(selSearchContractType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            //var tsp = $(chkSearchTSP).checkboxList("getValues");
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

            RptSemesterSummaryAjaxGateway.GetResult(intakefrom, intakeTo, fullname, gender, contractType, sponsorshipType,
                true, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null)
                {
                    self.ListControlller.Populate(res.value);
                }
            });


        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var mthCount = 0;
            var testCount = 0;
            for (var i = 0; i < tbl.Columns.length; i++) {
                var col = tbl.Columns[i];
                if (col.Name.indexOf("-Attn") > 0) {
                    mthCount++; //check count for Progress Month
                }
                if (col.Name.indexOf("-Score") > 0) {
                    testCount++; //check count for number of tests
                }
            }

            var htr = $("<tr></tr>");

            //Loop for first TR
            for (var i = 0; i < tbl.Columns.length; i++) {
                var col = tbl.Columns[i];
                if (col.Name.indexOf("-Attn") > 0) {
                    var colName = "Attendance Rate";
                    //htr.append(("<td colspan=3 align=center>" + colName + "</td>"));
                    htr.append(("<td colspan=" + mthCount + " align=center>" + colName + "</td>"));
                    i = i + (mthCount - 1);
                }
                else if (col.Name.indexOf("-Score") > 0) {
                    var colName = "Test";
                    //htr.append(("<td colspan=3 align=center>" + colName + "</td>"));
                    htr.append(("<td colspan=" + testCount + " align=center>" + colName + "</td>"));
                    i = i + (testCount - 1);
                }
                else {
                    htr.append(("<td rowspan=2 align=center>" + col.Name + "</td>"));
                }
            }

            //Loop for second tr
            var htr2 = $("<tr></tr>");
            for (var i = 0; i < tbl.Columns.length; i++) {
                var col = tbl.Columns[i];
                if (col.Name.indexOf("-Attn") > 0) {
                    var colName = col.Name.substring(0, col.Name.indexOf("-"))
                    htr2.append(("<td align=center>" + colName + "</td>"));
                }
                if (col.Name.indexOf("-Score") > 0) {
                    var colName = col.Name.substring(col.Name.indexOf("-")-1, col.Name.indexOf("-"))
                    htr2.append(("<td align=center>" + colName + "</td>"));
                }
            }

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);
            thead.append(htr2);

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

                    var colValue = teq.Common.FormatString(dr[col.Name]);

                    if (col.Name.indexOf("Date") > 0) colValue = teq.Common.FormatDate(new Date(colValue));
                    //if (col.Name.indexOf("FinalResult") > 0) colValue = teq.Common.FormatFixedDigits(colValue,2);
                    //if (col.Name.indexOf("-Score") > 0 && colValue >= 0) colValue = Math.round(colValue);
                    //if (col.Name.indexOf("Result") > 0 && colValue >= 0) colValue = Math.round(colValue);

                    tr.append(("<td align=center>" + colValue + "</td>"));
                }
                tbody.append(tr);
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    var Title = "Semester Summary Report";
    self.Title = Title;

}