using System;
using System.Configuration;
using Teq.Data;
namespace EngineData {
public partial class DA{
ActivityLogAdapter  _ActivityLog;
public ActivityLogAdapter ActivityLog {
get { if(  _ActivityLog== null ) _ActivityLog = new ActivityLogAdapter(this); return  _ActivityLog; }
}
ActivityLogColumnAdapter  _ActivityLogColumn;
public ActivityLogColumnAdapter ActivityLogColumn {
get { if(  _ActivityLogColumn== null ) _ActivityLogColumn = new ActivityLogColumnAdapter(this); return  _ActivityLogColumn; }
}
ActivityLogTransactionAdapter  _ActivityLogTransaction;
public ActivityLogTransactionAdapter ActivityLogTransaction {
get { if(  _ActivityLogTransaction== null ) _ActivityLogTransaction = new ActivityLogTransactionAdapter(this); return  _ActivityLogTransaction; }
}
ApplicationAdapter  _Application;
public ApplicationAdapter Application {
get { if(  _Application== null ) _Application = new ApplicationAdapter(this); return  _Application; }
}
ApplicationCourseSubjectAdapter  _ApplicationCourseSubject;
public ApplicationCourseSubjectAdapter ApplicationCourseSubject {
get { if(  _ApplicationCourseSubject== null ) _ApplicationCourseSubject = new ApplicationCourseSubjectAdapter(this); return  _ApplicationCourseSubject; }
}
AssessmentResultAdapter  _AssessmentResult;
public AssessmentResultAdapter AssessmentResult {
get { if(  _AssessmentResult== null ) _AssessmentResult = new AssessmentResultAdapter(this); return  _AssessmentResult; }
}
AssessmentSessionAdapter  _AssessmentSession;
public AssessmentSessionAdapter AssessmentSession {
get { if(  _AssessmentSession== null ) _AssessmentSession = new AssessmentSessionAdapter(this); return  _AssessmentSession; }
}
AssessmentSessionApplicantAdapter  _AssessmentSessionApplicant;
public AssessmentSessionApplicantAdapter AssessmentSessionApplicant {
get { if(  _AssessmentSessionApplicant== null ) _AssessmentSessionApplicant = new AssessmentSessionApplicantAdapter(this); return  _AssessmentSessionApplicant; }
}
CandidateAdapter  _Candidate;
public CandidateAdapter Candidate {
get { if(  _Candidate== null ) _Candidate = new CandidateAdapter(this); return  _Candidate; }
}
CandidatePreferredCourseAdapter  _CandidatePreferredCourse;
public CandidatePreferredCourseAdapter CandidatePreferredCourse {
get { if(  _CandidatePreferredCourse== null ) _CandidatePreferredCourse = new CandidatePreferredCourseAdapter(this); return  _CandidatePreferredCourse; }
}
CoachingAdapter  _Coaching;
public CoachingAdapter Coaching {
get { if(  _Coaching== null ) _Coaching = new CoachingAdapter(this); return  _Coaching; }
}
CoachingItemAdapter  _CoachingItem;
public CoachingItemAdapter CoachingItem {
get { if(  _CoachingItem== null ) _CoachingItem = new CoachingItemAdapter(this); return  _CoachingItem; }
}
CountryAdapter  _Country;
public CountryAdapter Country {
get { if(  _Country== null ) _Country = new CountryAdapter(this); return  _Country; }
}
CourseAdapter  _Course;
public CourseAdapter Course {
get { if(  _Course== null ) _Course = new CourseAdapter(this); return  _Course; }
}
CourseSubjectAdapter  _CourseSubject;
public CourseSubjectAdapter CourseSubject {
get { if(  _CourseSubject== null ) _CourseSubject = new CourseSubjectAdapter(this); return  _CourseSubject; }
}
CourseTSPAdapter  _CourseTSP;
public CourseTSPAdapter CourseTSP {
get { if(  _CourseTSP== null ) _CourseTSP = new CourseTSPAdapter(this); return  _CourseTSP; }
}
EmailNotificationAdapter  _EmailNotification;
public EmailNotificationAdapter EmailNotification {
get { if(  _EmailNotification== null ) _EmailNotification = new EmailNotificationAdapter(this); return  _EmailNotification; }
}
GlobalSettingAdapter  _GlobalSetting;
public GlobalSettingAdapter GlobalSetting {
get { if(  _GlobalSetting== null ) _GlobalSetting = new GlobalSettingAdapter(this); return  _GlobalSetting; }
}
PartTimerAssessmentResultAdapter  _PartTimerAssessmentResult;
public PartTimerAssessmentResultAdapter PartTimerAssessmentResult {
get { if(  _PartTimerAssessmentResult== null ) _PartTimerAssessmentResult = new PartTimerAssessmentResultAdapter(this); return  _PartTimerAssessmentResult; }
}
PartTimerAssessmentSessionAdapter  _PartTimerAssessmentSession;
public PartTimerAssessmentSessionAdapter PartTimerAssessmentSession {
get { if(  _PartTimerAssessmentSession== null ) _PartTimerAssessmentSession = new PartTimerAssessmentSessionAdapter(this); return  _PartTimerAssessmentSession; }
}
PartTimerAssessmentSessionApplicantAdapter  _PartTimerAssessmentSessionApplicant;
public PartTimerAssessmentSessionApplicantAdapter PartTimerAssessmentSessionApplicant {
get { if(  _PartTimerAssessmentSessionApplicant== null ) _PartTimerAssessmentSessionApplicant = new PartTimerAssessmentSessionApplicantAdapter(this); return  _PartTimerAssessmentSessionApplicant; }
}
PermissionAdapter  _Permission;
public PermissionAdapter Permission {
get { if(  _Permission== null ) _Permission = new PermissionAdapter(this); return  _Permission; }
}
SponsorAdapter  _Sponsor;
public SponsorAdapter Sponsor {
get { if(  _Sponsor== null ) _Sponsor = new SponsorAdapter(this); return  _Sponsor; }
}
StudentAdapter  _Student;
public StudentAdapter Student {
get { if(  _Student== null ) _Student = new StudentAdapter(this); return  _Student; }
}
StudentCourseAdapter  _StudentCourse;
public StudentCourseAdapter StudentCourse {
get { if(  _StudentCourse== null ) _StudentCourse = new StudentCourseAdapter(this); return  _StudentCourse; }
}
StudentCourseAttachmentAdapter  _StudentCourseAttachment;
public StudentCourseAttachmentAdapter StudentCourseAttachment {
get { if(  _StudentCourseAttachment== null ) _StudentCourseAttachment = new StudentCourseAttachmentAdapter(this); return  _StudentCourseAttachment; }
}
StudentCourseProgressAdapter  _StudentCourseProgress;
public StudentCourseProgressAdapter StudentCourseProgress {
get { if(  _StudentCourseProgress== null ) _StudentCourseProgress = new StudentCourseProgressAdapter(this); return  _StudentCourseProgress; }
}
StudentWarningLetterAdapter  _StudentWarningLetter;
public StudentWarningLetterAdapter StudentWarningLetter {
get { if(  _StudentWarningLetter== null ) _StudentWarningLetter = new StudentWarningLetterAdapter(this); return  _StudentWarningLetter; }
}
TSPAdapter  _TSP;
public TSPAdapter TSP {
get { if(  _TSP== null ) _TSP = new TSPAdapter(this); return  _TSP; }
}
UserAccountAdapter  _UserAccount;
public UserAccountAdapter UserAccount {
get { if(  _UserAccount== null ) _UserAccount = new UserAccountAdapter(this); return  _UserAccount; }
}
UserGroupAdapter  _UserGroup;
public UserGroupAdapter UserGroup {
get { if(  _UserGroup== null ) _UserGroup = new UserGroupAdapter(this); return  _UserGroup; }
}
VoluntaryHourAdapter  _VoluntaryHour;
public VoluntaryHourAdapter VoluntaryHour {
get { if(  _VoluntaryHour== null ) _VoluntaryHour = new VoluntaryHourAdapter(this); return  _VoluntaryHour; }
}
WarningLetterAdapter  _WarningLetter;
public WarningLetterAdapter WarningLetter {
get { if(  _WarningLetter== null ) _WarningLetter = new WarningLetterAdapter(this); return  _WarningLetter; }
}
WorkHistoryAdapter  _WorkHistory;
public WorkHistoryAdapter WorkHistory {
get { if(  _WorkHistory== null ) _WorkHistory = new WorkHistoryAdapter(this); return  _WorkHistory; }
}
ApplicationDetailAdapter  _ApplicationDetail;
public ApplicationDetailAdapter ApplicationDetail {
get { if(  _ApplicationDetail== null ) _ApplicationDetail = new ApplicationDetailAdapter(this); return  _ApplicationDetail; }
}
AssessmentResultDetailAdapter  _AssessmentResultDetail;
public AssessmentResultDetailAdapter AssessmentResultDetail {
get { if(  _AssessmentResultDetail== null ) _AssessmentResultDetail = new AssessmentResultDetailAdapter(this); return  _AssessmentResultDetail; }
}
AssessmentSessionDetailAdapter  _AssessmentSessionDetail;
public AssessmentSessionDetailAdapter AssessmentSessionDetail {
get { if(  _AssessmentSessionDetail== null ) _AssessmentSessionDetail = new AssessmentSessionDetailAdapter(this); return  _AssessmentSessionDetail; }
}
CandidatePreferredCourseDetailAdapter  _CandidatePreferredCourseDetail;
public CandidatePreferredCourseDetailAdapter CandidatePreferredCourseDetail {
get { if(  _CandidatePreferredCourseDetail== null ) _CandidatePreferredCourseDetail = new CandidatePreferredCourseDetailAdapter(this); return  _CandidatePreferredCourseDetail; }
}
CoachingDetailAdapter  _CoachingDetail;
public CoachingDetailAdapter CoachingDetail {
get { if(  _CoachingDetail== null ) _CoachingDetail = new CoachingDetailAdapter(this); return  _CoachingDetail; }
}
CourseTSPDetailAdapter  _CourseTSPDetail;
public CourseTSPDetailAdapter CourseTSPDetail {
get { if(  _CourseTSPDetail== null ) _CourseTSPDetail = new CourseTSPDetailAdapter(this); return  _CourseTSPDetail; }
}
PartTimerAssessmentResultDetailAdapter  _PartTimerAssessmentResultDetail;
public PartTimerAssessmentResultDetailAdapter PartTimerAssessmentResultDetail {
get { if(  _PartTimerAssessmentResultDetail== null ) _PartTimerAssessmentResultDetail = new PartTimerAssessmentResultDetailAdapter(this); return  _PartTimerAssessmentResultDetail; }
}
PartTimerAssessmentSessionDetailAdapter  _PartTimerAssessmentSessionDetail;
public PartTimerAssessmentSessionDetailAdapter PartTimerAssessmentSessionDetail {
get { if(  _PartTimerAssessmentSessionDetail== null ) _PartTimerAssessmentSessionDetail = new PartTimerAssessmentSessionDetailAdapter(this); return  _PartTimerAssessmentSessionDetail; }
}
StudentCourseDetailAdapter  _StudentCourseDetail;
public StudentCourseDetailAdapter StudentCourseDetail {
get { if(  _StudentCourseDetail== null ) _StudentCourseDetail = new StudentCourseDetailAdapter(this); return  _StudentCourseDetail; }
}
StudentProgressSummaryDetailAdapter  _StudentProgressSummaryDetail;
public StudentProgressSummaryDetailAdapter StudentProgressSummaryDetail {
get { if(  _StudentProgressSummaryDetail== null ) _StudentProgressSummaryDetail = new StudentProgressSummaryDetailAdapter(this); return  _StudentProgressSummaryDetail; }
}
StudentWarningLetterDetailAdapter  _StudentWarningLetterDetail;
public StudentWarningLetterDetailAdapter StudentWarningLetterDetail {
get { if(  _StudentWarningLetterDetail== null ) _StudentWarningLetterDetail = new StudentWarningLetterDetailAdapter(this); return  _StudentWarningLetterDetail; }
}
UserAccountDetailAdapter  _UserAccountDetail;
public UserAccountDetailAdapter UserAccountDetail {
get { if(  _UserAccountDetail== null ) _UserAccountDetail = new UserAccountDetailAdapter(this); return  _UserAccountDetail; }
}
VoluntaryHourDetailAdapter  _VoluntaryHourDetail;
public VoluntaryHourDetailAdapter VoluntaryHourDetail {
get { if(  _VoluntaryHourDetail== null ) _VoluntaryHourDetail = new VoluntaryHourDetailAdapter(this); return  _VoluntaryHourDetail; }
}
WorkHistoryDetailAdapter  _WorkHistoryDetail;
public WorkHistoryDetailAdapter WorkHistoryDetail {
get { if(  _WorkHistoryDetail== null ) _WorkHistoryDetail = new WorkHistoryDetailAdapter(this); return  _WorkHistoryDetail; }
}
}
}
