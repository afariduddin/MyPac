/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateCourseMonitoringPageController = function (idPrefix) {


    //#region Elements
    var self = this;
    var divModuleBtn = "#" + idPrefix + "_divModuleBtn";
    var divReportContent = "#" + idPrefix + "_divReportContent";
    var spanTitle = "#" + idPrefix + "_spanTitle";
    //var btnSearch = "#" + idPrefix + "_btnSearch";
    var btnAssign = "#" + idPrefix + "_btnAssign";
    //var divSearch = "#" + idPrefix + "_divSearch";
    var btnShowSearch = "#" + idPrefix + "_btnShowSearch";
    var btnShowSearch_SpanIcon = "#" + idPrefix + "_btnShowSearch_SpanIcon";
    var SearchImageicon = $("<img src='Resource/ToggleSearchIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var ArrowImageicon = $("<img src='Resource/ToggleSearchUpIcon.png' style='width:16px; height:16px; vertical-align:middle;'/ >")
    var btnShowSearch_SpanArrowIcon = "#" + idPrefix + "_btnShowSearch_SpanArrowIcon";
    var btnPinSearch = "#" + idPrefix + "_btnPinSearch";

    var divList = "#" + idPrefix + "_divList";
    var thdList = "#" + idPrefix + "_thdList";
    var tbdList = "#" + idPrefix + "_tbdList";
    var tblPager = "#" + idPrefix + "_tblPager";

    this.Initialize = Initialize;
    function Initialize() {
        $(btnAssign).button();
        BuildSurfaceListing();
    }

    this.Activated = Activated;
    function Activated() {
        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home",
            Link: local.aspxContent_CandidateDashboard1
        };
        navigationTrails.push(navigationTrail);
        navigationTrail = {
            Name: "Course Monitoring",
            Link: "#"
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        local.AdvancedSearchMode = null;
    }

    this.Shown = function () {
    }

    function BuildSurfaceListing() {
        self.ListControlller = new teq.EntityListController();

        self.ListControlller.divList = $(divList);
        self.ListControlller.tblPager = $(tblPager);
        //self.ListControlller.divSearch = $(divSearch);
        //self.ListControlller.btnSearch = $(btnSearch);
        //self.ListControlller.btnToggleSearch = $(btnShowSearch);

        //self.ListControlller.btnPinSearch = $(btnPinSearch);

        self.ListControlller.AutoSearch = true;
        self.ListControlller.AutoDropSearch = false;

        self.ListControlller.MultiSelector.SelectedRowClass = "Selected";

        self.ListControlller.SearchDelegate = function () {
            var order = self.ListControlller.ListOrderManager.GetOrder();
            var pg = self.ListControlller.CurrentPage;

            CandidateCourseMonitoringAjaxGateway.GetStudentProgressList(order.Columns, order.Directions, pg, function (res) {
                if (res.error == null) {
                    self.ListControlller.Populate(res.value);
                }
            });
        }

        self.ListControlller.PopulateHeaderDelegate = function (tbl) {
            var ctd = $("<td align=center/>");

            var htr = $("<tr></tr>");
            htr.append("<td >No. </td>");
            htr.append("<td >Code</td>");
            htr.append("<td >Subject</td>");
            htr.append("<td >Absent Count</td>");
            htr.append("<td >Latest Exam Score</td>");
            htr.append("<td >Status</td>");

            var thead = $(thdList);
            thead.empty();
            thead.append(htr);
        }

        self.ListControlller.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdList);
            tbody.empty();
            for (var i = 0; i < tbl.Rows.length; i++) {
                var dr = tbl.Rows[i];
                var tr = $("<tr></tr>");

                tr.append(("<td align=center>" + dr.RowNum + ".</td>"));
                tr.append(("<td align=center>" + dr.CourseSubject_Code + "</td>"));
                tr.append(("<td align=center>" + dr.CourseSubject_Name + "</td>"));
                tr.append(("<td align=center>" + dr.Absent_Count + "</td>"));
                tr.append(("<td align=center>" + dr.LatestExamScore + "</td>"));
                tr.append(("<td align=center>" + FlagNames.StudentCourseStatusType[dr.StudentCourse_Status] + "</td>"));
                tbody.append(tr);
            }
        }

        self.ListControlller.NewDelegate = function () {
            //buildSurfaceDataDialog();
        }
        self.ListControlller.Initialize();
    }
}