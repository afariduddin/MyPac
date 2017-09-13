local.RptAttendanceAnalysisPageController = function (idPrefix) {
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
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            //var statusType = $(selSearchStatus).val();

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }
            RptAttendanceAnalysisAjaxGateway.GetResult(intakefrom, intakeTo, fullname, gender, contractType, sponsorshipType, tsp,
                false, order.Columns, order.Directions, pg, function (res) {
                    if (res.error == null) {
                        window.open("ExportReport.aspx?ReportName=RptAttendanceAnalysis");
                    }
                });
        });
    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportStudentAttendanceAnalysis)) {
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
            Name: "Report - Student Attendance Analysis",
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
            var tsp = $(chkSearchTSP).checkboxList("getValues");
            //var statusType = $(selSearchStatus).val();

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            RptAttendanceAnalysisAjaxGateway.GetResult(intakefrom, intakeTo, fullname, gender, contractType, sponsorshipType, tsp,
                true, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null)
                {
                    self.ListControlller.Populate(res.value);
                }
            });


        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td>Cohort / Intake</td>");
            htr.append("<td>Full Name</td>");
            htr.append("<td>Date of Birth</td>");
            htr.append("<td>Gender</td>");
            htr.append("<td>Nationality</td>");
            htr.append("<td>IC No</td>");
            htr.append("<td>Email</td>");
            htr.append("<td>Sponsor</td>");
            htr.append("<td>TSP</td>");
            htr.append("<td>Course and Paper</td>");
            htr.append("<td>Total Class</td>");
            htr.append("<td>Attended Class</td>");
            htr.append("<td>Attendance Rate</td>");
            htr.append("<td>Final Result</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);

            //$(btnShowSearch).click();
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.IntakeDate + "</td>"));
                tr.append(("<td align=center>" + dr.FullName + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.DOB) + "</td>"));
                tr.append(("<td align=center>" + dr.Gender + "</td>"));
                tr.append(("<td align=center>" + dr.Nationality + "</td>"));
                tr.append(("<td align=center>" + dr.ICNo + "</td>"));
                tr.append(("<td align=center>" + dr.Email + "</td>"));
                tr.append(("<td align=center>" + dr.Sponsor + "</td>"));
                tr.append(("<td align=center>" + dr.TSP + "</td>"));
                tr.append(("<td align=center>" + dr.Course + " - "+dr.Paper+"</td>"));
                tr.append(("<td align=center>" + dr.TotalClass + "</td>"));
                tr.append(("<td align=center>" + dr.AttendedClass + "</td>"));
                tr.append(("<td align=center>" + dr.AttendanceRate + "%</td>"));
                tr.append(("<td align=center>" + (dr.FinalResult+"" == "null" ? "" : Math.round(dr.FinalResult) + "") + "</td>"));
                tbody.append(tr);
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    //var Title = "Student Intake Summary Report";
    var Title = "Student Attendance Analysis Report";
    self.Title = Title;

}