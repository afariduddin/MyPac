using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LO : System.Web.UI.Page
{
    public string CandidateName = "";
    public string CandidateIC = "";
    public string CandidateContact = "";
    public string CandidateEmail = "";
    public string CandidateAddress = "";
    public string CourseName = "";
    public string NumberOfPaper = "";
    public string TakenSubjects = "";
    public string TSP = "";
    public string SponsorshipExpiredDate = "";
    protected Guid ApplicationID
    {
        get
        {
            try
            {

                return Guid.Parse(Request["ApplicationID"]);
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DA da = new DA();
        ApplicationRow row = da.Application.GetByApplication_ID(ApplicationID);
        if (row != null)
        {
            CandidateName = row.Application_FullName;
            CandidateAddress = row.Application_Address1 + "<br />" + ((row.Application_Address2 == "") ? "" : row.Application_Address2 + "<br />") + row.Application_City + "<br />" + row.Application_State;
            CandidateIC = row.Application_IdentificationNumber;
            CandidateContact = row.Application_MobilePhonePrefix + "-" + row.Application_MobilePhoneNumber;
            CandidateEmail = row.Application_Email;

            NumberOfPaper = da.ApplicationCourseSubject.CountByApplication_ID(ApplicationID).ToString();
            //TakenSubjects = da.app
          CourseSubjectTable courseSubjectTbl =  da.CourseSubject.GetAll(row.Course_ID);
          ApplicationCourseSubjectTable appCourseSubjectTbl =  da.ApplicationCourseSubject.GetByApplication_ID(ApplicationID);
           
            foreach (CourseSubjectRow r in courseSubjectTbl.Rows)
            {
                foreach (ApplicationCourseSubjectRow appRow in appCourseSubjectTbl.Rows)
                {
                    if(appRow.CourseSubject_ID == r.CourseSubject_ID)
                    {
                        TakenSubjects += ", " + r.CourseSubject_Code + " - "+ r.CourseSubject_Name ;
                    }
                }
                // if(r.CourseSubject_ID)
                //  da.ApplicationCourseSubject.GetByCourseSubject_ID(r.)
            }
            if(TakenSubjects.Length >2)
            {
                TakenSubjects = TakenSubjects.Substring(2, TakenSubjects.Length-2);
            }

            CourseRow courseRow = da.Course.GetByCourse_ID(row.Course_ID);

            if (courseRow != null)
            {
                CourseName = courseRow.Course_Name;
            }
            TSPRow tspRow = da.TSP.GetByTSP_ID(row.TSP_ID);
            if (tspRow != null)
            {
                TSP = tspRow.TSP_CampusName;
            }

            AssessmentResultTable tbl = da.AssessmentResult.GetByApplication_ID(ApplicationID);
            if (tbl.Rows.Count > 0)
            {
                SponsorshipExpiredDate = tbl.GetAssessmentResultRow(0).AssessmentResult_ContractExpireDate.ToString("dd MMM yyyy");
                //CLODate = tbl.GetAssessmentResultRow(0).AssessmentResult_CLOIssueDate.ToString("dd MMM yyyy");
                //CLOExpiryDate = tbl.GetAssessmentResultRow(0).AssessmentResult_CLOIssueDate.AddDays(double.Parse(ConfigurationManager.AppSettings["CLOExpiryDay"].ToString())).ToString("dd MMM yyyy");
            }

            //  CLODate =
        }
    }
}