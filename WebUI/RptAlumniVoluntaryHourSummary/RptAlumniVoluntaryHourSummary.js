local.RptAlumniVoluntaryHourSummaryPageController = function (idPrefix) {
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

    //var cboSearchYearFrom = "#" + idPrefix + "_cboSearchYearFrom";
    //var cboSearchYearTo = "#" + idPrefix + "_cboSearchYearTo";
    //var chkSearchTSP = "#" + idPrefix + "_chkSearchTSP";
    //var chkSearchCourse = "#" + idPrefix + "_chkSearchCourse";
    var txtSearchDateFrom = "#" + idPrefix + "_dpSearchDateFrom";
    var txtSearchDateTo = "#" + idPrefix + "_dpSearchDateTo";
    var txtSearchFullName = "#" + idPrefix + "_txtSearchFullName";
    var selSearchGender = "#" + idPrefix + "_selSearchGender";
    var txtSearchEmail = "#" + idPrefix + "_txtSearchEmail";
    var txtSearchContactNum = "#" + idPrefix + "_txtSearchContactNum";
    var selSearchContractType = "#" + idPrefix + "_selSearchContractType";
    var chkSearchSponsorshipType = "#" + idPrefix + "_chkSearchSponsorshipType";
    var selSearchStatus = "#" + idPrefix + "_selSearchStatus";

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

        $(selSearchStatus).dropdownSelect({
            nullValue: -1,
            nullLabel: "- Select All -",
            choices: Enums.VoluntaryHourStatusType
        });

        BuildSurfaceListing();

        //var today = new Date();
        //for (year = 2012; year <= today.getFullYear() ; year++) {
        //    $(cboSearchYearFrom).append('<option val="' + year + '">' + year + '</option>');
        //    $(cboSearchYearTo).append('<option val="' + year + '">' + year + '</option>');
        //}

        $(btnExport).button({
            icons: { primary: "ui-icon-arrowthickstop-1-s" }
        }).attr('disabled', true);

        $(btnExport).attr('disabled', false).unbind().click(function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            var datefrom = $(txtSearchDateFrom).val() == "" ? null : $(txtSearchDateFrom).val();
            var dateTo = $(txtSearchDateTo).val() == "" ? null : $(txtSearchDateTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var contactNo = $(txtSearchContactNum).val();
            var contractType = $(selSearchContractType).val();
            //var sponsorshipType = $(chkSearchSponsorshipType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var statusType = $(selSearchStatus).val();

            if ((datefrom == null || dateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Enrollment Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (datefrom == null || dateTo == null) {
                teq.Context.Alert("<b>Enrollment Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            RptAlumniVoluntaryHourSummaryAjaxGateway.GetResult(datefrom, dateTo, fullname, gender, email, contactNo, contractType, sponsorshipType, statusType, false, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    window.open("ExportReport.aspx?ReportName=RptAlumniVoluntaryHourSummary");
                }
            });
        });

    }

    this.Activated = Activated;
    function Activated() {
        if (!local.ValidatePermission(FlagCodes.PermissionType.ReportAlumniVoluntaryHourSummary)) {
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
            Name: "Report - Alumni Voluntary Hour Summary",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;

        //TSPManagementAjaxGateway.GetAllTSP(function (res) {
        //    //teq.Common.Reveal(res);
        //    //alert(res.value.length)
        //    //val = res.value[0];
        //    //alert(val.Label);

        //    TSPList = [];
        //    for (i = 0; i < res.value.length; i++) {
        //        val = res.value[i];
        //        TSPList[val.Value] = val.Label;
        //    }

        //    $(chkSearchTSP).checkboxList(
        //    {
        //        columnSpacing: 20,
        //        valuesChanged: null,
        //        choices: TSPList, //Flags.TradeType,
        //        showLinks: true,
        //        columns: 2
        //    }
        //    );
        //});

        //CourseManagementAjaxGateway.GetAllCourses(function (res) {
        //    CourseList = [];
        //    for (i = 0; i < res.value.length; i++) {
        //        val = res.value[i];
        //        CourseList[val.Value] = val.Label;
        //    }

        //    $(chkSearchCourse).checkboxList(
        //    {
        //        columnSpacing: 20,
        //        valuesChanged: null,
        //        choices: CourseList, //Flags.TradeType,
        //        showLinks: true,
        //        columns: 2
        //    }
        //    );

        //});

        $(txtSearchDateFrom).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchDateFrom).datepicker('setDate', new Date(new Date().getFullYear(), 0, 1, 0, 0, 0));
        $(txtSearchDateTo).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
             showButtonPanel: true,yearRange: "-100:+5"
        });
        $(txtSearchDateTo).datepicker('setDate', new Date(new Date().getFullYear(), 11, 31, 0, 0, 0));


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

            var datefrom = $(txtSearchDateFrom).val() == "" ? null : $(txtSearchDateFrom).val();
            var dateTo = $(txtSearchDateTo).val() == "" ? null : $(txtSearchDateTo).val();
            var fullname = $(txtSearchFullName).val();
            var gender = $(selSearchGender).val();
            var email = $(txtSearchEmail).val();
            var contactNo = $(txtSearchContactNum).val();
            var contractType = $(selSearchContractType).val();
            //var sponsorshipType = $(chkSearchSponsorshipType).val();
            var sponsorshipType = $(chkSearchSponsorshipType).checkboxList("getValues");
            var statusType = $(selSearchStatus).val();

            if ((datefrom == null || dateTo == null) && sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Enrollment Date Range</b> and <b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            if (datefrom == null || dateTo == null) {
                teq.Context.Alert("<b>Enrollment Date Range</b> cannot be blank.");
                return false;
            }

            if (sponsorshipType.length <= 0) {
                teq.Context.Alert("<b>Sponsorship Type</b> cannot be blank.");
                return false;
            }

            RptAlumniVoluntaryHourSummaryAjaxGateway.GetResult(datefrom, dateTo, fullname, gender, email, contactNo, contractType, sponsorshipType, statusType, true, order.Columns, order.Directions, pg, function (res) {
                if (res.error == null)
                {
                    self.ListControlller.Populate(res.value);
                }
            });


        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td width=50px >No. </td>");
            htr.append("<td >Full Name</td>");
            htr.append("<td >D.O.B</td>");
            htr.append("<td >Gender</td>");
            htr.append("<td >IC No.</td>");
            htr.append("<td >Email</td>");
            htr.append("<td >Phone No</td>");
            htr.append("<td >Mobile No</td>");
            htr.append("<td >Enrollment Date</td>");
            htr.append("<td >Campus</td>");
            htr.append("<td >Campus City</td>");
            htr.append("<td >Contract Type</td>");
            htr.append("<td >Total Work Hour</td>");

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

            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");
                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.FullName + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.DateofBirth) + "</td>"));
                tr.append(("<td align=center>" + dr.Gender + "</td>"));
                tr.append(("<td align=center>" + dr.ICNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Email + "</td>"));
                tr.append(("<td align=center>" + dr.PhoneNumber + "</td>"));
                tr.append(("<td align=center>" + dr.Mobile + "</td>"));
                tr.append(("<td align=center>" + teq.Common.FormatDate(dr.EnrollmentDate) + "</td>"));
                tr.append(("<td align=center>" + dr.CampusName + "</td>"));
                tr.append(("<td align=center>" + dr.CampusCity + "</td>"));
                tr.append(("<td align=center>" + dr.ContractType + "</td>"));
                tr.append(("<td align=center>" + dr.TotalWorkHour + "</td>"));
                tbody.append(tr);
            }


        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }

        self.ListControlller.Initialize();
    }

    //var Title = "Student Intake Summary Report";
    var Title = "Alumni Voluntary Hour Summary Report";
    self.Title = Title;

}