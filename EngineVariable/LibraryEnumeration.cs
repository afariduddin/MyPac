using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Teq;

namespace EngineVariable
{

    public class EventType : Flag<char>
    {
        public static EventType News = new EventType('N', "News Publication");
        public static EventType Media = new EventType('M', "Media Exposure");
        public static EventType Press = new EventType('P', "Press Release");
        EventType(char code, string name) : base(code, name) { }
    }
    public class MaritalStatus : Flag<char>
    {
        public static MaritalStatus Single = new MaritalStatus('S', "Yeah Single");
        public static MaritalStatus Married = new MaritalStatus('M', "Stuck in a Marriage");
        public static MaritalStatus Complicated = new MaritalStatus('C', "It's Complicated");
        MaritalStatus(char code, string name) : base(code, name) { }
    }

    public class CourseType : Flag<int>
    {
        public static CourseType News = new CourseType(1, "Full Time");
        public static CourseType Media = new CourseType(2, "Part Time");
        public static CourseType Press = new CourseType(3, "Both");
        CourseType(int code, string name) : base(code, name) { }
    }
    
    public class NationalityType : Flag<int>
    {
        public static NationalityType Malaysian = new NationalityType(1, "Malaysian");
        public static NationalityType Other = new NationalityType(2, "Others");
        NationalityType(int code, string name) : base(code, name) { }
    }

    public class YesNoType : Flag<int>
    {
        public static YesNoType Yes = new YesNoType(1, "Yes");
        public static YesNoType No = new YesNoType(2, "No");
        YesNoType(int code, string name) : base(code, name) { }
    }

    public class PartTimerInterviewType : Flag<int>
    {
        public static PartTimerInterviewType Pending = new PartTimerInterviewType(0, "Pending");
        public static PartTimerInterviewType Pass = new PartTimerInterviewType(1, "Pass");
        public static PartTimerInterviewType Fail = new PartTimerInterviewType(2, "Fail");
        PartTimerInterviewType(int code, string name) : base(code, name) { }
    }

    public class GenderType : Flag<int>
    {
        public static GenderType Male = new GenderType(1, "Male");
        public static GenderType Female = new GenderType(2, "Female");
        GenderType(int code, string name) : base(code, name) { }
    }

    public class VoluntaryHourStatusType : Flag<int>
    {
        public static VoluntaryHourStatusType Pending = new VoluntaryHourStatusType(1, "Pending");
        public static VoluntaryHourStatusType Approve = new VoluntaryHourStatusType(2, "Approve");
        public static VoluntaryHourStatusType Reject = new VoluntaryHourStatusType(3, "Reject");
        VoluntaryHourStatusType(int code, string name) : base(code, name) { }
    }

    public class GlobalSettingType : Flag<int>
    {
        public static GlobalSettingType ReasonsForDeferment = new GlobalSettingType(0, "Reasons For Deferment");
        public static GlobalSettingType FieldOfStudy = new GlobalSettingType(1, "Field of Study");
        public static GlobalSettingType EducationLevel = new GlobalSettingType(2, "Education Level");
        public static GlobalSettingType PreferredLocation = new GlobalSettingType(3, "Preferred Location");
        public static GlobalSettingType Sector = new GlobalSettingType(4, "Sector");
        public static GlobalSettingType Position = new GlobalSettingType(5, "Position");
        public static GlobalSettingType PQLevelStart = new GlobalSettingType(6, "PQ Level Start");
        
        GlobalSettingType(int code, string name) : base(code, name) { }
    }

    public class ApplicationStatus : Flag<int>
    {
        public static ApplicationStatus Pending = new ApplicationStatus(1, "Pending");
        public static ApplicationStatus Terminated = new ApplicationStatus(2, "Terminated");
        //public static ApplicationStatus Accepted = new ApplicationStatus(3, "Accepted");
        public static ApplicationStatus SessionRejected = new ApplicationStatus(4, "Session Rejected");
        public static ApplicationStatus SessionAssigned = new ApplicationStatus(5, "Session Assigned");
        public static ApplicationStatus SessionAccepted = new ApplicationStatus(6, "Session Accepted");
        public static ApplicationStatus Complete = new ApplicationStatus(7, "Complete");
        ApplicationStatus(int code, string name) : base(code, name) { }
    }

    public class AssessmentInterviewStatus : Flag<int>
    {
        public static AssessmentInterviewStatus Pass = new AssessmentInterviewStatus(1, "Pass");
        public static AssessmentInterviewStatus Fail = new AssessmentInterviewStatus(2, "Fail");
        public static AssessmentInterviewStatus None = new AssessmentInterviewStatus(3, "None");
        AssessmentInterviewStatus(int code, string name) : base(code, name) { }
    }

    public class LevelStartPQ : Flag<int>
    {
        public static LevelStartPQ CAT = new LevelStartPQ(1, "CAT");
        public static LevelStartPQ AfterFoundation = new LevelStartPQ(2, "After Foundation");
        public static LevelStartPQ AfterDiploma = new LevelStartPQ(3, "After Diploma");
        public static LevelStartPQ AfterDegree = new LevelStartPQ(4, "After Degree");

        LevelStartPQ(int code, string name) : base(code, name) { }
    }

    public class ContractType : Flag<int>
    {
        public static ContractType PartTime = new ContractType(1, "Part Time");
        public static ContractType FullTime = new ContractType(2, "Full Time");
        ContractType(int code, string name) : base(code, name) { }
    }

    public class StatusType : Flag<int>
    {
        public static StatusType Pending = new StatusType(1, "Pending");
        public static StatusType Rejected = new StatusType(2, "Rejected");
        public static StatusType Accepted = new StatusType(3, "Accepted");
        StatusType(int code, string name) : base(code, name) { }
    }

    public class StudentStatusType : Flag<int>
    {
        public static StudentStatusType Active = new StudentStatusType(1, "Active");
        public static StudentStatusType Completed = new StudentStatusType(2, "Completed");
        public static StudentStatusType Terminated = new StudentStatusType(3, "Terminated");
        public static StudentStatusType Withdrawn = new StudentStatusType(4, "Withdrawn");
        StudentStatusType(int code, string name) : base(code, name) { }
    }



    public class AssessmentStatusType : Flag<int>
    {
        public static AssessmentStatusType Pending = new AssessmentStatusType(1, "Pending");
        public static AssessmentStatusType Accepted = new AssessmentStatusType(2, "Accepted");
        //public static AssessmentStatusType ConfirmedYPPB = new AssessmentStatusType(3, "Confirmed (YPPB)");
        public static AssessmentStatusType Declined = new AssessmentStatusType(4, "Declined");
        public static AssessmentStatusType CLOSent = new AssessmentStatusType(5, "CLO Issued");
        public static AssessmentStatusType Rejected = new AssessmentStatusType(6, "Rejected (Student)");
        public static AssessmentStatusType Complete = new AssessmentStatusType(7, "Complete");
        public static AssessmentStatusType InterviewInvited = new AssessmentStatusType(8, "Interview Invited");
        public static AssessmentStatusType InterviewRejected = new AssessmentStatusType(9, "Interview Rejected");
        public static AssessmentStatusType InterviewAccepted = new AssessmentStatusType(10, "Interview Accepted");
        public static AssessmentStatusType Pass = new AssessmentStatusType(11, "Pass");
        public static AssessmentStatusType Fail = new AssessmentStatusType(12, "Fail");
        AssessmentStatusType(int code, string name) : base(code, name) { }
    }


    public class AssessmentSubjectType : Flag<int>
    {
        //public static AssessmentSubjectType AbstractLogic = new AssessmentSubjectType(1, "Abstract Logic");
        //public static AssessmentSubjectType LogicalProcess = new AssessmentSubjectType(2, "Logical Process");
        //public static AssessmentSubjectType Numerical = new AssessmentSubjectType(3, "Numerical");
        //public static AssessmentSubjectType SpatialReasoning = new AssessmentSubjectType(4, "Spatial Reasoning");
        //public static AssessmentSubjectType SocialContext = new AssessmentSubjectType(5, "Social Context");
        public static AssessmentSubjectType TechnicalAssessment = new AssessmentSubjectType(4, "Technical Assessment");
        public static AssessmentSubjectType EnglishFoundation = new AssessmentSubjectType(5, "English Foundation");
        public static AssessmentSubjectType Listening = new AssessmentSubjectType(6, "Listening");
        public static AssessmentSubjectType Writing = new AssessmentSubjectType(7, "Writing");
        public static AssessmentSubjectType Speaking = new AssessmentSubjectType(8, "Speaking");
        public static AssessmentSubjectType Reading = new AssessmentSubjectType(9, "Reading");
        AssessmentSubjectType(int code, string name) : base(code, name) { }
    }
    //public class YPPBAssessmentStatusType : Flag<int>
    //{
    //    public static YPPBAssessmentStatusType Reject = new YPPBAssessmentStatusType(1, "Reject");
    //    public static YPPBAssessmentStatusType Confirmed = new YPPBAssessmentStatusType(2, "Confirmed");
    //    public static YPPBAssessmentStatusType PendingExam = new YPPBAssessmentStatusType(3, "Pending Exam");
    //    public static YPPBAssessmentStatusType PendingInterview = new YPPBAssessmentStatusType(4, "Pending Interview");
    //    public static YPPBAssessmentStatusType InvitationSent = new YPPBAssessmentStatusType(5, "Invitation Sent");
    //    public static YPPBAssessmentStatusType InterviewConfirmed = new YPPBAssessmentStatusType(6, "Interview Invitation Confirmed");
    //    YPPBAssessmentStatusType(int code, string name) : base(code, name) { }
    //}

    public class PartTimerAssessmentStatusType : Flag<int>
    {
        public static PartTimerAssessmentStatusType Reject = new PartTimerAssessmentStatusType(1, "Reject");
        public static PartTimerAssessmentStatusType Complete = new PartTimerAssessmentStatusType(2, "Complete");
        public static PartTimerAssessmentStatusType AssessmentInvitationSent = new PartTimerAssessmentStatusType(3, "Assessment Invitation Sent");
        public static PartTimerAssessmentStatusType AssessmentInvitationConfirmed = new PartTimerAssessmentStatusType(4, "Assessment Invitation Confirmed");
        public static PartTimerAssessmentStatusType AssessmentInvitationRejected = new PartTimerAssessmentStatusType(5, "Assessment Invitation Rejected");
        public static PartTimerAssessmentStatusType AssessmentPass = new PartTimerAssessmentStatusType(6, "Assessment Pass");
        //public static PartTimerAssessmentStatusType AssessmentFail = new PartTimerAssessmentStatusType(7, "Assessment Fail");
        public static PartTimerAssessmentStatusType CDPInvitationSent = new PartTimerAssessmentStatusType(8, "CDP Invitation Sent");
        public static PartTimerAssessmentStatusType CDPInvitationConfirmed = new PartTimerAssessmentStatusType(9, "CDP Invitation Confirmed");
        public static PartTimerAssessmentStatusType CDPInvitationRejected = new PartTimerAssessmentStatusType(10, "CDP Invitation Rejected");
        public static PartTimerAssessmentStatusType CDPPass = new PartTimerAssessmentStatusType(11, "CDP Pass");
        //public static PartTimerAssessmentStatusType CDPFail = new PartTimerAssessmentStatusType(12, "CDP Fail");
        public static PartTimerAssessmentStatusType InterviewInvitationSent = new PartTimerAssessmentStatusType(13, "Interview Invitation Sent");
        public static PartTimerAssessmentStatusType InterviewInvitationConfirmed = new PartTimerAssessmentStatusType(14, "Interview Invitation Confirmed");
        public static PartTimerAssessmentStatusType InterviewInvitationRejected = new PartTimerAssessmentStatusType(15, "Interview Invitation Rejected");
        //public static PartTimerAssessmentStatusType InterviewFail = new PartTimerAssessmentStatusType(16, "Interview Fail");
        public static PartTimerAssessmentStatusType Pending = new PartTimerAssessmentStatusType(17, "Pending");
        PartTimerAssessmentStatusType(int code, string name) : base(code, name) { }
    }

    //public class YPPBAssessmentSubjectType : Flag<int>
    //{
    //    public static YPPBAssessmentSubjectType Assessment1 = new YPPBAssessmentSubjectType(1, "Assessment 1");
    //    public static YPPBAssessmentSubjectType Assessment2 = new YPPBAssessmentSubjectType(2, "Assessment 2");
    //    public static YPPBAssessmentSubjectType Assessment3 = new YPPBAssessmentSubjectType(3, "Assessment 3");
    //    YPPBAssessmentSubjectType(int code, string name) : base(code, name) { }
    //}

    public class PartTimerAssessmentSubjectType : Flag<int>
    {
        public static PartTimerAssessmentSubjectType Assessment1 = new PartTimerAssessmentSubjectType(1, "Assessment 1");
        public static PartTimerAssessmentSubjectType Assessment2 = new PartTimerAssessmentSubjectType(2, "Assessment 2");
        public static PartTimerAssessmentSubjectType Assessment3 = new PartTimerAssessmentSubjectType(3, "Assessment 3");
        PartTimerAssessmentSubjectType(int code, string name) : base(code, name) { }
    }

    public class FinalisedApplicationStatusType : Flag<int>
    {
        public static FinalisedApplicationStatusType Pending = new FinalisedApplicationStatusType(2, "Pending");
        public static FinalisedApplicationStatusType Reject = new FinalisedApplicationStatusType(3, "Reject");
        public static FinalisedApplicationStatusType LOIssued = new FinalisedApplicationStatusType(4, "LO Issued");
        public static FinalisedApplicationStatusType StudentReject = new FinalisedApplicationStatusType(5, "Student Reject");
        public static FinalisedApplicationStatusType Confirmed = new FinalisedApplicationStatusType(6, "Confirmed");
        FinalisedApplicationStatusType(int code, string name) : base(code, name) { }
    }

    public class StudentCourseStatusType : Flag<int>
    {
        public static StudentCourseStatusType Active = new StudentCourseStatusType(1, "Active");
        public static StudentCourseStatusType Inactive = new StudentCourseStatusType(2, "Inactive");
        public static StudentCourseStatusType Completed = new StudentCourseStatusType(3, "Completed");
        public static StudentCourseStatusType Failed = new StudentCourseStatusType(4, "Failed");
        public static StudentCourseStatusType Deferred = new StudentCourseStatusType(5, "Deferred");
        public static StudentCourseStatusType Exempted = new StudentCourseStatusType(6, "Exempted");
        StudentCourseStatusType(int code, string name) : base(code, name) { }
    }

    public class ApplicationOverallStatusType : Flag<int>
    {
        public static ApplicationOverallStatusType Active = new ApplicationOverallStatusType(1, "Active");
        public static ApplicationOverallStatusType Inactive = new ApplicationOverallStatusType(2, "Inactive");
        public static ApplicationOverallStatusType Completed = new ApplicationOverallStatusType(3, "Completed");
        ApplicationOverallStatusType(int code, string name) : base(code, name) { }
    }
    public class ApplicationOverallProgressType : Flag<int>
    {
        public static ApplicationOverallProgressType Application = new ApplicationOverallProgressType(1, "Application");
        public static ApplicationOverallProgressType Assessment = new ApplicationOverallProgressType(2, "Assessment");
        public static ApplicationOverallProgressType PTAssessment = new ApplicationOverallProgressType(3, "PTAssessment");
        public static ApplicationOverallProgressType Finalised = new ApplicationOverallProgressType(4, "Finalised");
        public static ApplicationOverallProgressType StudentCourse = new ApplicationOverallProgressType(5, "StudentCourse");
        ApplicationOverallProgressType(int code, string name) : base(code, name) { }
    }
    public class EmailNotificationStatusType : Flag<int>
    {
        public static EmailNotificationStatusType Pending = new EmailNotificationStatusType(1, "Pending");
        public static EmailNotificationStatusType Sent = new EmailNotificationStatusType(2, "Sent");
        //public static EmailNotificationStatusType Retry = new EmailNotificationStatusType('R', "Retry");
        public static EmailNotificationStatusType Fail = new EmailNotificationStatusType(3, "Fail");
        EmailNotificationStatusType(int code, string name) : base(code, name) { }
    }
    public class CoachingStatusType : Flag<int>
    {
        public static CoachingStatusType Open = new CoachingStatusType(1, "Open");
        public static CoachingStatusType Closed = new CoachingStatusType(2, "Closed");
        //public static CoachingStatusType Confirmed = new CoachingStatusType(3, "Confirmed");
        CoachingStatusType(int code, string name) : base(code, name) { }
    }

    public class StudentCourseProgressType : Flag<int>
    {
        public static StudentCourseProgressType Attachment = new StudentCourseProgressType(1, "Attachment");
        public static StudentCourseProgressType Exam = new StudentCourseProgressType(2, "Exam");
        public static StudentCourseProgressType Attendance = new StudentCourseProgressType(3, "Attendance");
        StudentCourseProgressType(int code, string name) : base(code, name) { }
    }

    public class EmailResponseType : Flag<int>
    {
        public static EmailResponseType Unknown = new EmailResponseType(0, "Unknown");
        public static EmailResponseType AssessmentInvitation = new EmailResponseType(1, "Assessment Invitation");
        public static EmailResponseType InterviewInvitation = new EmailResponseType(2, "Interview Invitation");
        public static EmailResponseType CLO = new EmailResponseType(3, "CLO");
        public static EmailResponseType LO = new EmailResponseType(4, "LO");
        public static EmailResponseType PartTimerAssessment = new EmailResponseType(5, "PartTimerAssessment");
        public static EmailResponseType PartTimerCDP = new EmailResponseType(6, "PartTimerCDP");
        public static EmailResponseType PartTimerInterview = new EmailResponseType(7, "PartTimerInterview");
        EmailResponseType(int code, string name) : base(code, name) { }
    }

    public class CandidateType : Flag<int>
    {
        public static CandidateType Candidate = new CandidateType(1, "Candidate");
        public static CandidateType Student = new CandidateType(2, "Student");
        public static CandidateType Alumni = new CandidateType(3, "Alumni");
        CandidateType(int code, string name) : base(code, name) { }
    }
    public class PermissionType : Flag<int>
    {
        public static PermissionType RegistrationListView = new PermissionType(1, "Registration List - View");
        public static PermissionType RegistrationListEdit = new PermissionType(2, "Registration List - Edit");
        public static PermissionType ApplicationListView = new PermissionType(3, "Application List - View");
        public static PermissionType ApplicationListEdit = new PermissionType(4, "Application List - Edit");
        public static PermissionType AssessmentSessionListView = new PermissionType(5, "Assessment Session List - View");
        public static PermissionType AssessmentSessionListEdit = new PermissionType(6, "Assessment Session List - Edit");
        public static PermissionType AssessmentResultListView = new PermissionType(7, "Assessment Result List - View");
        public static PermissionType AssessmentResultListEdit = new PermissionType(8, "Assessment Result List - Edit");
        public static PermissionType PartTimerAssessmentSessionListView = new PermissionType(9, "Part Timer Assessment Result List - View");
        public static PermissionType PartTimerAssessmentSessionListEdit = new PermissionType(10, "Part Timer Assessment Result List - Edit");
        public static PermissionType PartTimerSessionManagementView = new PermissionType(11, "Part Timer Session Management - View");
        public static PermissionType PartTimerSessionManagementEdit = new PermissionType(12, "Part Timer Session Management - Edit");
        public static PermissionType FinalizedCandidateView = new PermissionType(13, "Finalized Candidate - View");
        public static PermissionType FinalizedCandidateEdit = new PermissionType(14, "Finalized Candidate List - Edit");
        public static PermissionType StudentProgressSummaryView = new PermissionType(15, "Student Progress Summary - View");
        public static PermissionType StudentProgressSummaryEdit = new PermissionType(16, "Student Progress Summary - Edit");
        public static PermissionType StudentProgressView = new PermissionType(17, "Student Progress - View");
        public static PermissionType StudentProgressEdit = new PermissionType(18, "Student Progress - Edit");
        public static PermissionType CounsellingView = new PermissionType(19, "Counselling/Mentoring - View");
        public static PermissionType CounsellingEdit = new PermissionType(20, "Counselling/Mentoring - Edit");
        public static PermissionType CounsellingAccess = new PermissionType(21, "Counselling/Mentoring - Limited Case Access");
        public static PermissionType VoluntaryHourView = new PermissionType(22, "Voluntary Hour - View");
        public static PermissionType VoluntaryHourEdit = new PermissionType(23, "Voluntary Hour - Edit");
        public static PermissionType AlumniView = new PermissionType(24, "Alumni Work Hour - View");
        public static PermissionType AlumniEdit = new PermissionType(25, "Alumni Work Hour - Edit");
        public static PermissionType ReportApplicationOverview = new PermissionType(26, "Application Overview - View");
        public static PermissionType ReportStudentIntakeSummary = new PermissionType(27, "Report Student Intake Summary - View");
        //public static PermissionType ReportDefermentSummary = new PermissionType(28, "Report Deferment Summary - View");
        //public static PermissionType ReportStudentWithdrawalSummary = new PermissionType(29, "Report Student Withdrawal Summary - View");
        public static PermissionType ReportStudentLocationSummary = new PermissionType(30, "Report Student Location Summary - View");
        public static PermissionType ReportActiveStudentSummary = new PermissionType(31, "Report Active Student Summary - View");
        //public static PermissionType ReportIntakeBySponsorship = new PermissionType(32, "Report Intake By Sponsorship - View");
        public static PermissionType ReportAlumniVoluntaryHourSummary  = new PermissionType(33, "Report Alumni Voluntary Hour Summary - View");
        public static PermissionType ReportCandidateSuccessRateSummary  = new PermissionType(34, "Report Candidate Success Rate Summary - View");
        public static PermissionType ReportStudentAttendanceAnalysis = new PermissionType(35, "Report Student Attendance Analysis - View");
        public static PermissionType ReportStudentExamAnalysis = new PermissionType(36, "Report Student Exam Analysis - View");
        public static PermissionType ReportStudentProgressSummary = new PermissionType(37, "Report Student Progress Summary - View");
        public static PermissionType ReportSemesterSummary = new PermissionType(38, "Report Semester Summary - View");
        public static PermissionType AuditLog = new PermissionType(39, "Audit Log - View");
        public static PermissionType UserGroupManagement = new PermissionType(40, "User Group Management - Manage");
        public static PermissionType UserManagement = new PermissionType(41, "User Management - Manage");
        public static PermissionType CourseManagement = new PermissionType(42, "Course Management - Manage");
        public static PermissionType TrainingServiceProviderManagement = new PermissionType(43, "Training Service Provider Management - Manage");
        public static PermissionType WarningLetterTemplateSetting = new PermissionType(44, "Warning Letter Template Setting - Manage");
        public static PermissionType EmailNotificationManagement = new PermissionType(45, "Email Notification Management - Manage");
        public static PermissionType GlobalSetting = new PermissionType(46, "Global Setting - Manage");
        public static PermissionType SponsorManagement = new PermissionType(47, "Sponsor Management");
        PermissionType(int code, string name) : base(code, name) { }
    }
    public class PartTimerSessionType : Flag<int>
    {
        public static PartTimerSessionType Assessment = new PartTimerSessionType(1, "Assessment");
        public static PartTimerSessionType CDP = new PartTimerSessionType(2, "CDP");
        public static PartTimerSessionType Interview = new PartTimerSessionType(3, "Interview");
        PartTimerSessionType(int code, string name) : base(code, name) { }
    }
}
