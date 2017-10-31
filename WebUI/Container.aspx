<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Container.aspx.cs" Inherits="Container" %>
<%@ Register src="~/Blank/Blank.ascx" tagname="Blank" tagprefix="uc1" %>

<%@ Register src="~/CourseManagement/CourseManagement.ascx" tagname="CourseManagement" tagprefix="uc1" %>
<%@ Register src="~/RegistrationListing/RegistrationListing.ascx" tagname="RegistrationListing" tagprefix="uc1" %>
<%@ Register src="~/Dashboard/Dashboard.ascx" tagname="Dashboard" tagprefix="uc1" %>
<%@ Register Src="~/ReportStudentSummary/ReportStudentSummary.ascx" TagName="ReportStudentSummary" TagPrefix="uc1" %>
<%@ Register Src="~/UserAccountManagement/UserAccountManagement.ascx" TagPrefix="uc1" TagName="UserAccountManagement" %>
<%@ Register Src="~/UserGroupManagement/UserGroupManagement.ascx" TagPrefix="uc1" TagName="UserGroupManagement" %>
<%@ Register Src="~/ChangeProfile/ChangeProfile.ascx" TagPrefix="uc1" TagName="ChangeProfile" %>
<%@ Register Src="~/ChangePassword/ChangePassword.ascx" TagPrefix="uc1" TagName="ChangePassword" %>
<%@ Register Src="~/TSPManagement/TSPManagement.ascx" TagPrefix="uc1" TagName="TSPManagement" %>
<%@ Register Src="~/ApplicationListing/ApplicationListing.ascx" TagPrefix="uc1" TagName="ApplicationListing" %>
<%@ Register Src="~/AssessmentSessionManagement/AssessmentSessionManagement.ascx" TagPrefix="uc1" TagName="AssessmentSessionManagement" %>
<%@ Register Src="~/AssessmentResult/AssessmentResult.ascx" TagPrefix="uc1" TagName="AssessmentResult" %>
<%@ Register Src="~/PartTimerCandidate/PartTimerCandidate.ascx" TagPrefix="uc1" TagName="PartTimerCandidate" %>
<%@ Register Src="~/FinalisedCandidate/FinalisedCandidate.ascx" TagPrefix="uc1" TagName="FinalisedCandidate" %>
<%@ Register Src="~/StudentProgress/StudentProgress.ascx" TagPrefix="uc1" TagName="StudentProgress" %>
<%@ Register Src="~/CoachingManagement/CoachingManagement.ascx" TagPrefix="uc1" TagName="CoachingManagement" %>
<%@ Register Src="~/VoluntaryHourApproval/VoluntaryHourApproval.ascx" TagPrefix="uc1" TagName="VoluntaryHourApproval" %>
<%@ Register Src="~/StudentProgressSummary/StudentProgressSummary.ascx" TagPrefix="uc1" TagName="StudentProgressSummary" %>
<%@ Register Src="~/GlobalSetting/GlobalSetting.ascx" TagPrefix="uc1" TagName="GlobalSetting" %>
<%@ Register Src="~/PreferredLocationManagement/PreferredLocationManagement.ascx" TagPrefix="uc1" TagName="PreferredLocationManagement" %>
<%@ Register Src="~/WarningLetter/WarningLetter.ascx" TagPrefix="uc1" TagName="WarningLetter" %>
<%@ Register Src="~/EmailNotificationManagement/EmailNotificationManagement.ascx" TagPrefix="uc1" TagName="EmailNotificationManagement" %>
<%@ Register Src="~/Alumni/Alumni.ascx" TagPrefix="uc1" TagName="Alumni" %>
<%@ Register Src="~/PartTimerSessionManagement/PartTimerSessionManagement.ascx" TagPrefix="uc1" TagName="PartTimerSessionManagement" %>
<%@ Register Src="~/RptStudentIntakeSummary/RptStudentIntakeSummary.ascx" TagPrefix="uc1" TagName="RptStudentIntakeSummary" %>
<%@ Register Src="~/RptStudentLocationSummary/RptStudentLocationSummary.ascx" TagPrefix="uc1" TagName="RptStudentLocationSummary" %>
<%@ Register Src="~/RptAlumniVoluntaryHourSummary/RptAlumniVoluntaryHourSummary.ascx" TagPrefix="uc1" TagName="RptAlumniVoluntaryHourSummary" %>
<%@ Register Src="~/RptStudentWithdrawalSummary/RptStudentWithdrawalSummary.ascx" TagPrefix="uc1" TagName="RptStudentWithdrawalSummary" %>
<%@ Register Src="~/RptActiveStudentSummary/RptActiveStudentSummary.ascx" TagPrefix="uc1" TagName="RptActiveStudentSummary" %>
<%@ Register Src="~/RptSuccessRateSummary/RptSuccessRateSummary.ascx" TagPrefix="uc1" TagName="RptSuccessRateSummary" %>
<%@ Register Src="~/RptAttendanceAnalysis/RptAttendanceAnalysis.ascx" TagPrefix="uc1" TagName="RptAttendanceAnalysis" %>
<%@ Register Src="~/RptExamAnalysis/RptExamAnalysis.ascx" TagPrefix="uc1" TagName="RptExamAnalysis" %>
<%@ Register Src="~/RptStudentDefermentSummary/RptStudentDefermentSummary.ascx" TagPrefix="uc1" TagName="RptStudentDefermentSummary" %>
<%@ Register Src="~/RptStudentProgressSummary/RptStudentProgressSummary.ascx" TagPrefix="uc1" TagName="RptStudentProgressSummary" %>
<%@ Register Src="~/RptSemesterSummary/RptSemesterSummary.ascx" TagPrefix="uc1" TagName="RptSemesterSummary" %>
<%@ Register Src="~/ActivityLog/ActivityLog.ascx" TagPrefix="uc1" TagName="ActivityLog" %>
<%@ Register Src="~/RptApplicationOverview/RptApplicationOverview.ascx" TagPrefix="uc1" TagName="RptApplicationOverview" %>
<%@ Register Src="~/RptIntakeBySponsorship/RptIntakeBySponsorship.ascx" TagPrefix="uc1" TagName="RptIntakeBySponsorship" %>
<%@ Register Src="~/Sponsor/Sponsor.ascx" TagPrefix="uc1" TagName="Sponsor" %>



<asp:Content ID="Content2" ContentPlaceHolderID="formContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="aspxContent" Runat="Server">
    <div id="divLoggedIn" class="loggedIn">
        <div style="background-image: url('Resource/background.png'); background-repeat:repeat-x; height: 5px">&nbsp;</div>
        <div style="background-color:#ffffff; color:#000000; width:100%; padding-bottom:5px;">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; height: 40px">
                <tr valign="middle">
                    <td style="padding-left: 10px; vertical-align: middle" width="10px"><img src="Resource/mypac_logo_small.png" /></td>
                    <td style="font-weight:normal; font-size:20px; padding-left:10px;">
                        
                         Candidate Registration System<%--MyPAC Candidate Database System--%></td>
                    <td align="right" style="padding-right:10px;">
                        <div id="divLoggedInInfo" style="display:none; height:inherit;  text-align:right; ">
                            Logged in as <span id="LoginName"></span> &#149; <a href="#" id="btnLogOut" title="Logout from the system"  style="cursor:pointer;"> Logout </a>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div id="menu" class="mainMenu">
                <div style=" WIDTH:100%; HEIGHT:100%; overflow-y:auto;overflow-x:hidden;">
                    <div id="mnu_Dashb2" class="menu">
                        <div id="tt_Dash2" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-register.png" height="20px" alt="" />
                            <span class="menu-title">REGISTRATION / APPLICATION</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' ></span>
                        </div>
                        <div id="it_tt_Dash2" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_RegistrationListing);">Registration List</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_ApplicationListing);">Application List</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_AssessmentSessionManagement);">Assessment Session Management</span>
                            </div>
                        </div>
                    </div>
                    
                    <div id="mnu_Dashb3" class="menu">
                        <div id="tt_Dash3" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-account.png" height="20px" alt="" />
                            <span class="menu-title">ASSESSMENT PROCESS</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' ></span>
                        </div>
                        <div id="it_tt_Dash3" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_AssessmentResult);">Assessment Result</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_PartTimerCandidate);">Part-Timer Assessment Result</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_PartTimerSessionManagement);">Part-Timer Assessment Session Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_FinalisedCandidate);">Finalised Candidate</span>
                            </div>
                        </div>
                    </div>

                    <div id="mnu_ScholarInformation" class="menu">
                        <div id="tt_ScholarInformation" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-student.png" height="20px" alt="Road Info" />
                            <span class="menu-title">SCHOLAR - INFORMATION</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' ></span>
                        </div>

                        <div id="it_tt_ScholarInformation" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item">Scholar - Details</span>
                            </div>

                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item">Scholar Progress - Full Time</span>
                            </div>

                            <%-- <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span 
                                    class="item" 
                                    onclick="teq.Context.ShowPage(local.aspxContent_ProgressPartTime);">
                                    Scholar Progress - Part Time
                                </span>
                            </div> --%>
                             <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CoachingManagement);">Counselling & Monitoring</span>
                            </div>
                        </div>
                    </div>

                    <div id="mnu_Dashb1" class="menu">
                        <div id="tt_Dash1" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-student.png" height="20px" alt="Road Info" />
                            <span class="menu-title">STUDENT / COUNSELLING</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' ></span>
                        </div>
                        <div id="it_tt_Dash1" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_StudentProgressSummary);">Student Progress Summary</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_StudentProgress);">Student Progress</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CoachingManagement);">Counselling / Mentoring</span>
                            </div>
                        </div>
                    </div>
                    
                    <div id="mnu_Dashb7" class="menu">
                        <div id="tt_Dash7" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-alumni.png" height="20px" alt="ALUMNI" />
                            <span class="menu-title">ALUMNI MANAGEMENT</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n'></span>
                        </div>
                        <div id="it_tt_Dash7" class="menu-dropdown">
                            <div style="padding:3px;POSITION:relative;">
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_VoluntaryHourApproval);">Voluntary Hour Approval</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_Alumni);">Alumni Work History</span>
                            </div>
                        </div>
                    </div>

                    <div id="mnu_Dashb5" class="menu">
                        <div id="tt_Dash5" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-report.png" height="20px" alt="REPORTS" />
                            <span class="menu-title">REPORTS</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n'></span>
                        </div>
                        <div id="it_tt_Dash5" class="menu-dropdown">                            
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptApplicationOverview);">Application Overview Report</span>
                            </div>                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptStudentIntakeSummary);">Student Intake Summary Report</span>
                            </div>
<%--                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptStudentDefermentSummary);">Student Deferment Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptStudentWithdrawalSummary);">Student Withdrawal Summary Report</span>
                            </div>--%>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptStudentLocationSummary);">Student Location Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptActiveStudentSummary);">Active Student Summary Report</span>
                            </div>
<%--                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptIntakeBySponsorship);">Intake By Sponsorship Report</span>
                            </div>--%>
                            
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptAlumniVoluntaryHourSummary);">Alumni Voluntary Hour Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptSuccessRateSummary);">Candidate Success Rate Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptAttendanceAnalysis);">Student Attendance Analysis Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptExamAnalysis);">Student Exam Analysis Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptStudentProgressSummary);">Student Progress Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item"onclick="teq.Context.ShowPage(local.aspxContent_RptSemesterSummary);">Semester Summary Report</span>
                            </div>
                            
                            <!--
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_ReportStudentSummary1);">Registered Students Summary Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_Blank1);">Student Attendance Detail Report</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_Blank1);">English Enhancement Programme Report</span>
                            </div>
                                -->
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_ActivityLog);">User Audit Log Report</span>
                            </div>
                        </div>
                    </div>

                    <div id="mnu_Dashb11" class="menu">
                        <div id="tt_Dash11" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-setup.png" height="20px" alt="Work list" />
                            <span class="menu-title">SYSTEM SETUP</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' ></span>
                        </div>
                        <div id="it_tt_Dash11" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_UserGroupManagement);">User Group Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_Sponsor);">Sponsor Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_UserAccountManagement);">User Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CourseManagement);">Course Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_TSPManagement);">Training Service Provider Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_WarningLetter);">Warning Letter Template Setting</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_EmailNotificationManagement);">Email Notification Management</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_GlobalSetting);local.aspxContent_GlobalSetting.PopulateData();">Global Setting</span>
                            </div>
                        </div>
                    </div>

                    <div id="mnu_Dashb10" class="menu">
                        <div id="tt_Dash10" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-account.png" height="20px" alt="Work list" />
                            <span class="menu-title">MY ACCOUNT</span>
                            <span class='triangle ui-icon ui-icon-triangle-1-n' style=''></span>
                        </div>
                        <div id="it_tt_Dash10" class="menu-dropdown">
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_ChangeProfile);">Profile</span>
                            </div>
                            <div>
                                <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                                <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_ChangePassword);">Change Password</span>
                            </div>
                        </div>
                    </div>
                </div>
        </div>

        <div id="divToggleMenu" align="center" class="menuToggle">            
            <table cellpadding="0" cellspacing="0" style="height:inherit;">
                <tr valign="middle">
                    <td >
                        <img id="imgToggle" src="Resource/arrow-left.png" style="height:18px; width:18px; max-height:9px; max-width:9px; " alt="expand" />
                    </td>
                </tr>
            </table>
            
        </div>

        <div id="mainContent" style="WIDTH:78.8%; HEIGHT:99%;  float:left;" >   
            <div id="navigationTrails" style="WIDTH:100%; HEIGHT:3%; padding-bottom:10px;"></div>

            <div style="overflow-y:auto; width:100%; HEIGHT:92%; padding-top:5px;">
                <uc1:Blank ID="Blank1" runat="server" />
                <uc1:RegistrationListing ID="RegistrationListing" runat="server" />
                <uc1:CourseManagement ID="CourseManagement" runat="server" />
                <uc1:Dashboard ID="Dashboard1" runat="server" />

                <uc1:UserAccountManagement ID="UserAccountManagement" runat="server" />
                <uc1:UserGroupManagement ID="UserGroupManagement" runat="server" />
                <uc1:ChangeProfile runat="server" ID="ChangeProfile" />
                <uc1:ChangePassword runat="server" ID="ChangePassword" />
                <uc1:TSPManagement runat="server" ID="TSPManagement" />
                <uc1:ApplicationListing runat="server" ID="ApplicationListing" />
                <uc1:AssessmentSessionManagement runat="server" ID="AssessmentSessionManagement" />
                <uc1:AssessmentResult runat="server" ID="AssessmentResult" />
                <uc1:PartTimerCandidate runat="server" ID="PartTimerCandidate" />
                <uc1:FinalisedCandidate runat="server" ID="FinalisedCandidate" />
                <uc1:StudentProgress runat="server" ID="StudentProgress" />
                <uc1:CoachingManagement runat="server" ID="CoachingManagement" />
                <uc1:VoluntaryHourApproval runat="server" ID="VoluntaryHourApproval" />
                <uc1:StudentProgressSummary runat="server" ID="StudentProgressSummary" />
                <uc1:GlobalSetting runat="server" ID="GlobalSetting" />
                <uc1:PreferredLocationManagement runat="server" ID="PreferredLocationManagement" />
                <uc1:WarningLetter runat="server" ID="WarningLetter" />
                <uc1:EmailNotificationManagement runat="server" ID="EmailNotificationManagement" />           
                <uc1:Alumni runat="server" ID="Alumni" />
                <uc1:PartTimerSessionManagement runat="server" ID="PartTimerSessionManagement" />
                <uc1:Sponsor runat="server" ID="Sponsor" />

                <uc1:RptAlumniVoluntaryHourSummary ID="RptAlumniVoluntaryHourSummary" runat="server" />
                <uc1:RptStudentIntakeSummary ID="RptStudentIntakeSummary" runat="server" />                
                <uc1:RptStudentLocationSummary ID="RptStudentLocationSummary" runat="server" />
                <uc1:RptStudentWithdrawalSummary ID="RptStudentWithdrawalSummary" runat="server" />
                <uc1:RptActiveStudentSummary ID="RptActiveStudentSummary" runat="server" />
                <uc1:RptSuccessRateSummary ID="RptSuccessRateSummary" runat="server" />
                <uc1:RptAttendanceAnalysis ID="RptAttendanceAnalysis" runat="server" />
                <uc1:RptExamAnalysis ID="RptExamAnalysis" runat="server" />
                <uc1:RptStudentDefermentSummary ID="RptStudentDefermentSummary" runat="server"/>
                <uc1:RptStudentProgressSummary ID="RptStudentProgressSummary" runat="server" />
                <uc1:RptSemesterSummary ID="RptSemesterSummary" runat="server" />
                <uc1:ActivityLog ID="ActivityLog" runat="server" />
                <uc1:RptApplicationOverview ID="RptApplicationOverview" runat="server" />
                <uc1:RptIntakeBySponsorship runat="server" ID="RptIntakeBySponsorship" />
            </div>
        </div>        
    </div>
    <div id="advanceSearch"></div>
    <script type="text/javascript">
        $(function () {
            local.InitAjaxPro();
            //teq.Context.ShowPage(local.aspxContent_Blank1);

            teq.Context.ShowPage(local.aspxContent_Dashboard1);
            
            //teq.Context.ShowPage(local.aspxContent_RptStudentProgressSummary);
            //teq.Context.ShowPage(local.aspxContent_EmailNotificationManagement);
            //teq.Context.ShowPage(local.aspxContent_RptStudentWithdrawalSummary);
            //teq.Context.ShowPage(local.aspxContent_RptAttendanceAnalysis);
            //teq.Context.ShowPage(local.aspxContent_RptStudentDefermentSummary);
            //teq.Context.ShowPage(local.aspxContent_ReportStudentSummary1);
            //teq.Context.ShowPage(local.aspxContent_CourseManagement1);
            //teq.Context.ShowPage(local.aspxContent_RptSemesterSummary);
            //teq.Context.ShowPage(local.aspxContent_RptApplicationOverview);

            local.ContainerInit();
        });

        local.AdvancedSearchMode = null;
        local.AdvancedSearchModule = null;
        local.Permission = null;
        local.CurrentUser = null;

        local.ValidatePermission = function(PermissionCode)
        {
            ContainerAjaxGateway.ValidateSession(function (res) {
                if (res.value.length == 0) {
                }
                else
                {
                    window.location.href = "AdministratorSignIn.aspx";
                }
            });

            var l = local.Permission.AccessRight.split(";");
            if (l.indexOf(PermissionCode.toString()) > -1) {
                return true;
            }
            else
                return false;
        }
        local.ContainerInit = function () {

            ContainerAjaxGateway.GetLogin(function (res) {
                if (res.value.l == null) {
                    window.location.href = "AdministratorSignIn.aspx";
                }
                else {
                    $('#LoginName').text(res.value.l.UserName);

                    local.CurrentUser = res.value.l.UserName;

                    local.Permission = res.value.l;

                    $('#divLoggedIn').show();
                    $('#divLoggedInInfo').show();
                    $('#divMyPresetFilter').show();

                    //alert(res.value.Code);
                    $('#mnu_Dashb8').hide();
                    $('#mnu_Dashb4').hide();
                    //$('#mnu_Dashb7').hide();
                }
            });

            var hide = true;

            //divToggleMenu 
            {
                $("#divToggleMenu").attr("title", "Hide The Menu Bar");
                //$("#toggle").css("background", "url('Resource/btnToggleMenu.png')");
                //$("#divToggleMenu").append(imgToggle);
                //$("#toggle").button({
                //    icons: { primary: "ui-icon-circle-arrow-w" },
                //    text: false
                //});
                $("#imgToggle").hide();
                $("#divToggleMenu").mouseenter(function () {

                    //imgToggle.attr("src", "Resource/btnToggleMenu.png");
                    //imgToggle.animate({ opacity: 1 }, 10);

                    $("#imgToggle").show();
                    $("#divToggleMenu").css("background-color", "rgb(68,68,68)");


                })
                $("#divToggleMenu").mouseleave(function () {

                    //imgToggle.attr("src", "Resource/btnToggleMenu_hover.png");
                    //imgToggle.animate({ opacity: 0.5 }, 10);
                    //$(this).animate({ opacity: 1 }, 10);
                    //if (hide != false) {
                    $("#divToggleMenu").css("background-color", "transparent");
                    $("#imgToggle").hide();
                    //}


                })

                $("#divToggleMenu").on('click', function (e) {
                    e.preventDefault();

                    if (hide == true) {
                        $("#divToggleMenu").attr("title", "Expand The Menu Bar");
                        //$("#toggle").button({
                        //    icons: { primary: "ui-icon-circle-arrow-e" },
                        //    text: false
                        //});
                        $("#divToggleMenu").css("background-color", "rgb(68,68,68)");
                        $("#imgToggle").hide();
                        $("#imgToggle").attr("src", "Resource/arrow-right.png");
                        $('#menu').hide("slide", function () {
                            $('#mainContent').css("width", '98.9%');

                        });
                        hide = false;

                        //document.getElementById("gisframe").width = 1250;
                    }
                    else {
                        $('#mainContent').css("width", '78.8%');
                        $("#divToggleMenu").attr("title", "Hide The Menu Bar");
                        //$("#toggle").button({
                        //    icons: { primary: "ui-icon-circle-arrow-w" },
                        //    text: false
                        //});
                        $("#divToggleMenu").css("background-color", "transparent");
                        $("#imgToggle").hide();
                        $("#imgToggle").attr("src", "Resource/arrow-left.png");
                        $('#menu').show("slide", function () {
                            $('#mainContent').css("width", '78.8%');

                        });
                        hide = true;
                        //alert(window.innerWidth)

                        //document.getElementById("gisframe").width = 1000;
                    }




                });


            }
            var imgToggle = $(" <img src='Resource/btnToggleMenu.png' style='width:80%;' /> ")
            //var imgToggleHide = $(" <img src='Resource/btnToggleMenu.png' /> ")

            $("#toggle").attr("title", "Hide The Menu Bar");
            //$("#toggle").css("background", "url('Resource/btnToggleMenu.png')");
            $("#toggle").append(imgToggle);
            //$("#toggle").button({
            //    icons: { primary: "ui-icon-circle-arrow-w" },
            //    text: false
            //});

            $("#toggle").mouseout(function () {

                //imgToggle.attr("src", "Resource/btnToggleMenu.png");
                imgToggle.animate({ opacity: 1 }, 10);

            })
            $("#toggle").mouseover(function () {

                //imgToggle.attr("src", "Resource/btnToggleMenu_hover.png");
                imgToggle.animate({ opacity: 0.5 }, 10);
                //$(this).animate({ opacity: 1 }, 10);

            })

            $('#toggle').on('click', function (e) {
                e.preventDefault();

                if (hide == true) {
                    $("#toggle").attr("title", "Expand The Menu Bar");
                    //$("#toggle").button({
                    //    icons: { primary: "ui-icon-circle-arrow-e" },
                    //    text: false
                    //});
                    $('#menu').hide("slide", function () {
                        $('#mainContent').css("width", '97.9%');

                    });
                    hide = false;

                }
                else {
                    $('#mainContent').css("width", '77.9%');
                    $("#toggle").attr("title", "Hide The Menu Bar");
                    //$("#toggle").button({
                    //    icons: { primary: "ui-icon-circle-arrow-w" },
                    //    text: false
                    //});
                    $('#menu').show("slide", function () {
                        $('#mainContent').css("width", '77.9%');

                    });
                    hide = true;
                }




            });
            var divAdvanceSearch = $("#advanceSearch");

            $("#btnSignIn").on('click', function () {
                var SignInID = $('#txtSigninID');
                var Password = $('#txtPassword');

                ContainerAjaxGateway.SignIn(SignInID.val(), Password.val(), function (res) {
                    if (res.value.errs.length == 0) {
                        $('#divLoggin').hide();
                        $('#divLoggedIn').show();
                        $('#divLoggedInInfo').show();
                        $('#divMyPresetFilter').show();
                        $('#LoginName').text(SignInID.val());
                        local.Permission = res.value.l;
                    }
                    else {
                        var errMessage = "";
                        for (var x = 0; x < res.value.errs.length; x++) {
                            if (x > 0)
                                errMessage += "<br>";
                            errMessage += res.value.errs[x].Name;
                        }
                        teq.Context.Alert(errMessage, null, function () {
                        });
                    }
                });


                //}

                ////$('#divLoggin').hide();
                //if ($('#txtLoginId').val().toLowerCase() == "new") {
                //    local.BuildAdvancedSearchDialogController(, function (res) {

                //        $('#divLoggedIn').show();
                //        $('#divLoggedInInfo').show();
                //        $('#divMyPresetFilter').show();
                //    });
                //}
                //else {
                //    $('#divLoggedIn').show();
                //    $('#divLoggedInInfo').show();
                //    $('#divMyPresetFilter').show();
                //}
            });

            $("#btnLogOut").on('click', function () {
                ContainerAjaxGateway.SignOut(function (res) {
                    window.location = "AdministratorSignIn.aspx";
                });
            });

            {
                $("#divMyPresetFilter").mousedown(function () {

                    //$(this).animate({ opacity: 0.3 }, 10);

                })
                //$("#divMyPresetFilter").mouseup(function () {

                //    $(this).animate({ opacity: 1 }, 10);

                //})
                $("#divMyPresetFilter").mouseleave(function () {

                    //$(this).animate({ opacity: 1 }, 10);

                })
                $("#divMyPresetFilter").mouseenter(function () {

                    // $(this).animate({ opacity: 0.6 }, 10);

                })
            }

            $("#divMyPresetFilter").on('click', function () {
                local.AdvancedSearchMode = null;
                local.BuildAdvancedSearchDialogController(divAdvanceSearch);
            });

            {
                $(".button").mousedown(function () {

                    $(this).animate({ opacity: 0.1 }, 10);

                })
                $(".button").mouseup(function () {

                    $(this).animate({ opacity: 1 }, 10);

                })
                $(".button").mouseout(function () {

                    $(this).animate({ opacity: 1 }, 10);

                })
                $(".button").mouseenter(function () {

                    $(this).animate({ opacity: 0.8 }, 10);

                })
            }


        }
        local.navigationTrailsBuild = function (navigationTrails) {

            var divNavigationTrails = $("#navigationTrails");
            divNavigationTrails.empty();
            var span = $("<span>");
            var table = $("<table cellpadding='0' cellspacing='0' style='width:100%;'>");
            var tr = $("<tr vallign='middle'>");
            var td = $("<td class='breadCrumb'>");
            table.append(tr);
            tr.append(td);

            var spanhome = $("<span style='width:12px;height:12px; padding:2px 0px 0px 0px; vertical-align:top; '>");
            spanhome.button({
                icons: { primary: "ui-icon-home" },
                text: false
            });
            spanhome.click(function () {
                //teq.Context.ShowPage(local.aspxContent_Blank1);
                teq.Context.ShowPage(local.aspxContent_Dashboard1);
            });
            td.append(spanhome);
            td.append("&nbsp;");
            td.append(span);


            divNavigationTrails.append(table);
            for (i = 0 ; i < navigationTrails.length ; i++) {
                var navigationTrail = navigationTrails[i];

                if (navigationTrails.length == 1 || i == (navigationTrails.length - 1)) {


                    addLink(span, false);

                }
                else {
                    addLink(span, true);

                }



            }


            function addLink(span, next) {

                var spaninner = $("<span >");
                span.append(spaninner);
                if (next) {
                    span.append(" > ");

                }
                var spanInnerByID = $("#spanNavigation_" + i);
                spaninner.css("cursor", "pointer");
                spaninner.html(navigationTrail.Name);
                var link = navigationTrail.Link;
                spaninner.click(function () {
                    teq.Context.ShowPage(link);
                });

                //span.append(spanInnerByID);
                {//set animation
                    spaninner.mousedown(function () {

                        $(this).animate({ opacity: 0.1 }, 10);

                    })
                    spaninner.mouseup(function () {

                        $(this).animate({ opacity: 1 }, 10);

                    })
                    spaninner.mouseout(function () {

                        $(this).animate({ opacity: 1 }, 10);

                    })
                    spaninner.mouseenter(function () {

                        $(this).animate({ opacity: 0.8 }, 10);

                    })
                }

            }




        }
        local.ShowPage = function (page, callback) {

            var _callBack = null;
            _callBack = callback;
            var _page = null;
            _page = page;
            var divAdvanceSearch = $('#advanceSearch');
            local.BuildAdvancedSearchDialogController(divAdvanceSearch, null, function () {

                if (_callBack != null) _callBack();
                if (_page != null) teq.Context.ShowPage(_page, true);
            });
        }

        function ToggleDashMenu(obj) {
            if ($('#it_' + obj.id).is(":visible")) {
                $('#it_' + obj.id).slideUp();
                $('#' + obj.id).children(".ui-icon").removeClass("ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
            }
            else {
                $('#it_' + obj.id).slideDown();
                $('#' + obj.id).children(".ui-icon").removeClass("ui-icon-triangle-1-n").addClass("ui-icon-triangle-1-s");
            }
        }

    </script>
</asp:Content>
       
    
