using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq.Ajax;
using Teq.Data;
using AjaxPro;
using EngineData;

public partial class CandidateDashboard : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateDashboardAjaxGateway));
        AjaxLib.RegisterController("CandidateDashboard", ClientID);
    }
}
public class CandidateDashboardAjaxGateway : AjaxGatewayBase
{
    public class DashboardSubjectAttn
    {
        public Guid SubjectID;
        public string SubjectCode;
        public string SubjectName;
        public string CourseCode;
        public string CourseName;
        public DashboardSubjectAttnMonth[] Months;
    }
    public class DashboardSubjectAttnMonth
    {
        public int TotalClass;
        public int AttendedClass;
    }
    public class DashboardDataPack
    {
        //public DataTable Appointments;
        public DataTable SubjectsStatus;
        public float CourseProgress;
        public string[] AttnMonths;
        public DashboardSubjectAttn[] SubjectAttns;
        public int AttnTotalClass;
        public int AttnAttendedClass;
        public PagedDataList<DataTable> EmailNotifications;
    }
    [AjaxMethod]
    public DashboardDataPack GetDashboardDataPack()
    {
        if (WebLib.LoggedInUser == null) return null;

        DashboardDataPack dp = new DashboardDataPack();

        DA da = new DA();
        Guid sId = da.Student.GetStudentIDByCandidateID(WebLib.LoggedInUser.CandidateID);
        //dp.Appointments = da.Coaching.GetActiveAppointment(sId);
        dp.SubjectsStatus = da.StudentCourse.GetSubjectsStatus(sId);
        if (dp.SubjectsStatus.Rows.Count == 0) dp.CourseProgress = 0f;
        else dp.CourseProgress = 1f * da.StudentCourse.CountCompletedSubjects(sId) / dp.SubjectsStatus.Rows.Count;

        int numOfMths = 6;
        DateTime dtf = DateTime.Today.AddMonths(-numOfMths);
        DateTime dtt = DateTime.Today.AddMonths(-1);
        dtf = new DateTime(dtf.Year, dtf.Month, 1);
        dtt = new DateTime(dtt.Year, dtt.Month, 1).AddMonths(1);
        //dtf = dtf.AddMonths(6); // JK:tmp
        //dtt = dtt.AddMonths(6); // JK:tmp
        DataTable attn = da.StudentCourseProgress.GetAttendanceSummary(sId, dtf, dtt);
        DataTable subNm = da.StudentCourse.GetSubjectsName(sId);

        dp.AttnMonths = new string[numOfMths];
        List<DashboardSubjectAttn> lis = new List<DashboardSubjectAttn>();
        for (int i = 0; i < numOfMths; i++)
        {
            DateTime dtf2 = dtf.AddMonths(i);
            DateTime dtt2 = dtf2.AddMonths(1);
            dp.AttnMonths[i] = dtf2.ToString("MMM");
            foreach (DataRow attnDr in attn.Rows)
            {
                Guid scId = (Guid)attnDr["StudentCourse_ID"];
                DateTime dt = (DateTime)attnDr["StudentCourseProgress_Date"];
                int totalCls = (int)attnDr["StudentCourseProgress_TotalClass"];
                int attndCls = (int)attnDr["StudentCourseProgress_AttendedClass"];
                if (dtf2 <= dt && dt < dtt2)
                {
                    DashboardSubjectAttn itm = FindDashboardSubjectAttn(lis, scId, subNm, numOfMths);
                    itm.Months[i].TotalClass += totalCls;
                    itm.Months[i].AttendedClass += attndCls;
                    dp.AttnTotalClass += totalCls;
                    dp.AttnAttendedClass += attndCls;
                }
            }
        }
        dp.SubjectAttns = lis.ToArray();

        return dp;
    }
    DashboardSubjectAttn FindDashboardSubjectAttn(List<DashboardSubjectAttn> lis, Guid scId, DataTable subNm, int numOfMths)
    {
        foreach (DashboardSubjectAttn i in lis)
        {
            if (i.SubjectID == scId) return i;
        }

        DashboardSubjectAttn itm = new DashboardSubjectAttn();
        itm.SubjectID = scId;
        foreach (DataRow subNmDr in subNm.Rows)
        {
            Guid scId2 = (Guid)subNmDr["StudentCourse_ID"];
            if (scId == scId2)
            {
                itm.SubjectCode = subNmDr["CourseSubject_Code"].ToString();
                itm.SubjectName = subNmDr["CourseSubject_Name"].ToString();
                itm.CourseCode = subNmDr["Course_Code"].ToString();
                itm.CourseName = subNmDr["Course_Name"].ToString();
                break;
            }
        }
        itm.Months = new DashboardSubjectAttnMonth[numOfMths];
        for (int i = 0; i < numOfMths; i++) itm.Months[i] = new DashboardSubjectAttnMonth();
        lis.Add(itm);
        return itm;
    }
    [AjaxMethod]
    public PagedDataList<EmailNotificationTable> GetEmailNotifications(int pg)
    {
        if (WebLib.LoggedInUser == null) return new PagedDataList<EmailNotificationTable>(new EmailNotificationTable());
        else
        {
            DA da = new DA();
            return da.EmailNotification.GetForCandidateDashboard(WebLib.LoggedInUser.CandidateID, pg);
        }
    }
    [AjaxMethod]
    public PagedDataList<StudentWarningLetterDetailTable> GetWarningLetters(int pg)
    {
        if (WebLib.LoggedInUser == null) return new PagedDataList<StudentWarningLetterDetailTable>(new StudentWarningLetterDetailTable());
        else
        {
            DA da = new DA();
            Guid sId = da.Student.GetStudentIDByCandidateID(WebLib.LoggedInUser.CandidateID);
            // return da.WarningLetter.GetForCandidateDashboard(sId, pg);
            return da.StudentWarningLetterDetail.GetForCandidateDashboard(sId, pg);
        }
    }
}