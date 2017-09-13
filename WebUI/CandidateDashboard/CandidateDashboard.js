/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateDashboardPageController = function (idPrefix)
{
    var divNextMeeting = "#" + idPrefix + "_divNextMeeting";
    var divProgressWrap = "#" + idPrefix + "_divProgressWrap";
    var spnProgressTitle = "#" + idPrefix + "_spnProgressTitle";
    var divCourseBadges = "#" + idPrefix + "_divCourseBadges";
    var divAttnWrap = "#" + idPrefix + "_divAttnWrap";
    var theadAttn = "#" + idPrefix + "_theadAttn";
    var tbodyAttn = "#" + idPrefix + "_tbodyAttn";
    var trAttnMeter = "#" + idPrefix + "_trAttnMeter";

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize()
    {
        //var hasAppt = true;
        //if (hasAppt)
        //{
        //    $(divNextMeeting).show();
        //    $(divNextMeeting).empty();
        //    AppendAppt();
        //    AppendAppt();
        //}
        //else $(divNextMeeting).hide();

        //$(spnProgressTitle).text("Course Progress - 30% completed");
        //$(divCourseBadges).append(BuildBadge("Accounting in Business", 1));
        //$(divCourseBadges).append(BuildBadge("Management Accounting", 2));
        //$(divCourseBadges).append(BuildBadge("Financial Accounting", 3));
        //$(divCourseBadges).append(BuildBadge("Corporate and Business Law", 4));

        //BuildAttnThead(["July", "August", "September"]);
        //$(tbodyAttn).empty();
        //AppendAttnTbody("Accounting in Business - Paper 1", ["98%", "87%", "95%"]);
        //AppendAttnTbody("Accounting in Business - Paper 2", ["98%", "87%", "95%"]);
        //AppendAttnTbody("Accounting in Business - Paper 3", ["98%", "87%", "95%"]);
        //BuildChart(0.78);

    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated()
    {
        local.AdvancedSearchMode = null;

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home > Dashboard",
            Link: local.aspxContent_CandidateDashboard1
        };
        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);

        Populate();
    }
    //#endregion

    function Populate()
    {
        CandidateDashboardAjaxGateway.GetDashboardDataPack(function (res)
        {
            if (res.error == null)
            {
                var dp = res.value;
                if (dp != null)
                {
                    Populate_Appt(dp);
                    Populate_Badges(dp);
                    Populate_Attn(dp);
                }
            }
        });
        PopulateEml();
        PopulateWarn();
    }
    function Populate_Appt(dp)
    {
        if (true) $(divNextMeeting).hide(); // section not required. always hide.
        return;

        if (dp.Appointments.Rows.length == 0) $(divNextMeeting).hide();
        else
        {
            $(divNextMeeting).show();
            $(divNextMeeting).empty();
            for (var i = 0; i < dp.Appointments.Rows.length; i++) {
                var dr = dp.Appointments.Rows[i];
                AppendAppt(dr.Coaching_Date, dr.Course_Code, dr.Course_Name, dr.CourseSubject_Code, dr.CourseSubject_Name, dr.Coaching_Description);
            }
        }
    }
    function Populate_Badges(dp)
    {
        if (dp.SubjectsStatus.Rows.length == 0) $(divProgressWrap).hide();
        else $(divProgressWrap).show();

        $(spnProgressTitle).text("Course Progress - " + Math.round(dp.CourseProgress * 100) + "% completed");
        $(divCourseBadges).empty();
        for( var i=0; i<dp.SubjectsStatus.Rows.length; i++)
        {
            var dr = dp.SubjectsStatus.Rows[i];
            $(divCourseBadges).append(BuildBadge("[" + dr.CourseSubject_Code + "] " + dr.CourseSubject_Name, dr.StudentCourse_Status));
        }
    }
    function Populate_Attn(dp)
    {
        if (dp.SubjectAttns.length == 0) $(divAttnWrap).hide();
        else $(divAttnWrap).show();

        if (dp.AttnTotalClass == 0) BuildChart(0);
        else BuildChart(dp.AttnAttendedClass / dp.AttnTotalClass);

        BuildAttnThead(dp.AttnMonths);
        $(tbodyAttn).empty();
        for (var i = 0; i < dp.SubjectAttns.length; i++)
        {
            var sAtn = dp.SubjectAttns[i];
            var paper = sAtn.CourseCode + "-" + sAtn.CourseName + "<br>(" + sAtn.SubjectCode + "-" + sAtn.SubjectName + ")";
            var val = [];
            for (var j = 0; j < sAtn.Months.length; j++)
            {
                var sam = sAtn.Months[j];
                if (sam.TotalClass == 0) val[j] = "-";
                else val[j] = sam.AttendedClass + "/" + sam.TotalClass + "<br>(" + Math.round(100 * sam.AttendedClass / sam.TotalClass) + "%)";
            }
            AppendAttnTbody(paper, val);
        }
    }
    function AppendAppt(dt, courseCode, courseName, paperCode, paperName, desc) // not used
    {
        var msg = "A meeting with your mentor has been scheduled on " + teq.Common.FormatDateTime(dt) + " for " + courseCode + "-" + courseName + " (" + paperCode + "-" + paperName + ").<br />" + desc;
        var div = $("<div class=\"ui-corner-all\" style=\"background-color:#fffbab; margin:0px 50px 20px 50px; border:solid 1px #000000; padding:20px; font-size:20px; font-style:italic;\"></div>");
        div.html(msg);

        $(divNextMeeting).append(div);
    }
    function BuildBadge(courseName, status)
    {
        var imgName = "";
        if (status == FlagCodes.StudentCourseStatusType.Active) imgName = "frame-Active";
        else if (status == FlagCodes.StudentCourseStatusType.Inactive) imgName = "frame-Inactive";
        else if (status == FlagCodes.StudentCourseStatusType.Completed ||
            status == FlagCodes.StudentCourseStatusType.Exempted) imgName = "frame-Completed";

        var html =
            "<div style='display:inline-table; text-align:center; width:128px; height:60px; padding-top:68px; background-repeat:no-repeat; background-position:center top; background-image:url(components/css/global/" + imgName + ".png); margin:0px 5px 0px 5px;' alt='" + FlagNames.StudentCourseStatusType[status] + "'>" +
            "   " + courseName + 
            "</div>";
        return html;
    }
    function BuildAttnThead(mths)
    {
        var tr = $("<tr>");
        tr.append("<td style='padding-left:20px;padding-right:20px;'>Paper</td>"); //font-size:16px;

        for( var i=0; i<mths.length; i++)
        {
            tr.append("<td style='padding-left:20px;padding-right:20px;'>" + mths[i] + "</td>"); //font-size:16px;
        }

        $(theadAttn).empty();
        $(theadAttn).append(tr);
    }
    function AppendAttnTbody(paperName, attnPercs)
    {
        var tr = $("<tr>");
        tr.append("<td style='padding-left:20px;padding-right:20px;text-align:left;'>" + paperName + "</td>"); //font-size:16px; 

        for (var i = 0; i < attnPercs.length; i++) {
            tr.append("<td style='padding-left:20px;padding-right:20px;'>" + attnPercs[i] + "</td>"); //font-size:16px;
        }

        $(tbodyAttn).append(tr);
    }
    function BuildChart(perc)
    {
        var lbl = Math.round(perc * 100) + "%";
        $(trAttnMeter).empty();
        for (var i = 0; i < lbl.length; i++)
        {
            $(trAttnMeter).append("<td style=\"background-color:#000;padding:5px;padding-bottom:0px;font-size:100px;font-weight:bold;color:#FFF;font-family:'Courier New';line-height:100px;\">" + lbl[i] + "</td>");
        }
    }

    var divEmlWrap = "#" + idPrefix + "_divEmlWrap";
    var thdEmlList = "#" + idPrefix + "_thdEmlList";
    var tbdEmlList = "#" + idPrefix + "_tbdEmlList";
    var tblEmlPager = "#" + idPrefix + "_tblEmlPager";
    var emlListCtrl;
    function PopulateEml()
    {
        emlListCtrl = new teq.EntityListController();
        //#region Settings
        emlListCtrl.AutoSearch = true;
        //#endregion
        //#region Elements
        emlListCtrl.divList = $(divEmlWrap);
        emlListCtrl.tblPager = $(tblEmlPager);
        //#endregion
        //#region Delegates
        emlListCtrl.SearchDelegate = function () {
            var pg = emlListCtrl.CurrentPage;
            CandidateDashboardAjaxGateway.GetEmailNotifications(pg, function (res) {
                if (res.error == null) emlListCtrl.Populate(res.value);
            });
        }
        emlListCtrl.PopulateHeaderDelegate = function (tbl) {
            teq.Common.BuildColumnIndexes(tbl);

            var htr = $("<tr></tr>");
            htr.append("<td>No.</td>");
            htr.append("<td>Date</td>");
            htr.append("<td>Subject</td>");

            var thead = $(thdEmlList);
            thead.empty();
            thead.append(htr);
        }
        emlListCtrl.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdEmlList);
            tbody.empty();

            if (tbl.Rows.length == 0) {
                var tr = $("<tr></tr>");
                tr.append("<td colspan=3 style='text-align:center;'><br><br>There's no email notification.<br><br><br></td>");
                tbody.append(tr);
            }
            else
            {
                for (var i = 0; i < tbl.Rows.length; i++) {
                    var dr = tbl.Rows[i];

                    var colNo = dr.RowNum;
                    var colDt = teq.Common.FormatDateTime(dr.EmailNotification_CreatedDate);
                    var colSub = dr.EmailNotification_Subject;
                    if (!dr.EmailNotification_IsRead) {
                        colNo = "<b>" + colNo + "</b>";
                        colDt = "<b>" + colDt + "</b>";
                        colSub = "<b>" + colSub + "</b>";
                    }

                    var tr = $("<tr></tr>");
                    tr.append("<td style='text-align:center;'>" + colNo + "</td>");
                    tr.append("<td style='text-align:center;'>" + colDt + "</td>");
                    tr.append($("<td style='text-align:left;'></td>").append(buildLnk(colSub, dr)));
                    tbody.append(tr);

                    function buildLnk(colSub2, dr2) {
                        var lnk = $("<a href='javascript:;'>" + colSub2 + "</a>");
                        lnk.click(function () {
                            window.open("PopupEmailNotification.aspx?id=" + dr2.EmailNotification_ID);
                        });
                        return lnk;
                    }
                }
            }
        }
        //#endregion
        emlListCtrl.Initialize();
    }

    var divWarnWrap = "#" + idPrefix + "_divWarnWrap";
    var thdWarnList = "#" + idPrefix + "_thdWarnList";
    var tbdWarnList = "#" + idPrefix + "_tbdWarnList";
    var tblWarnPager = "#" + idPrefix + "_tblWarnPager";
    var warnListCtrl;
    function PopulateWarn() {
        warnListCtrl = new teq.EntityListController();
        //#region Settings
        warnListCtrl.AutoSearch = true;
        //#endregion
        //#region Elements
        warnListCtrl.divList = $(divWarnWrap);
        warnListCtrl.tblPager = $(tblWarnPager);
        //#endregion
        //#region Delegates
        warnListCtrl.SearchDelegate = function () {
            var pg = warnListCtrl.CurrentPage;
            CandidateDashboardAjaxGateway.GetWarningLetters(pg, function (res) {
                if (res.error == null) warnListCtrl.Populate(res.value);
            });
        }
        warnListCtrl.PopulateHeaderDelegate = function (tbl) {
            teq.Common.BuildColumnIndexes(tbl);

            var htr = $("<tr></tr>");
            htr.append("<td>No.</td>");
            htr.append("<td>Date</td>");
            htr.append("<td>Subject</td>");

            var thead = $(thdWarnList);
            thead.empty();
            thead.append(htr);
        }
        warnListCtrl.PopulateDataDelegate = function (tbl) {
            var tbody = $(tbdWarnList);
            tbody.empty();

            if (tbl.Rows.length == 0) {
                var tr = $("<tr></tr>");
                tr.append("<td colspan=3 style='text-align:center;'><br><br>There's no warning letters.<br><br><br></td>");
                tbody.append(tr);
            }
            else {
                for (var i = 0; i < tbl.Rows.length; i++) {
                    var dr = tbl.Rows[i];

                    var colNo = dr.RowNum;
                    var colDt = teq.Common.FormatDateTime(dr.StudentWarningLetter_CreatedDate);
                    var colSub = dr.EmailNotification_Subject;

                    var tr = $("<tr></tr>");
                    tr.append("<td style='text-align:center;'>" + colNo + "</td>");
                    tr.append("<td style='text-align:center;'>" + colDt + "</td>");
                    tr.append($("<td style='text-align:left;'></td>").append(buildLnk(colSub, dr)));
                    tbody.append(tr);

                    function buildLnk(colSub2, dr2) {
                        var lnk = $("<a href='javascript:;'>" + colSub2 + "</a>");
                        lnk.click(function () {
                            window.open("PopupEmailNotification.aspx?id=" + dr2.EmailNotification_ID);
                        });
                        return lnk;
                    }
                }
            }
        }
        //#endregion
        warnListCtrl.Initialize();
    }
}