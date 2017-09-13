using EngineData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CLO : System.Web.UI.Page
{
    public string CandidateName = "";
    public string Address = "";
    public string CLODate = "";
    public string CLOExpiryDate = "";
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
         ApplicationRow row =   da.Application.GetByApplication_ID(ApplicationID);
        if(row != null)
        {
            CandidateName = row.Application_FullName;
            Address = row.Application_Address1 + "<br />" + ((row.Application_Address2 == "")? "" : row.Application_Address2 + "<br />") + row.Application_City + "<br />" + row.Application_State;
           AssessmentResultTable tbl = da.AssessmentResult.GetByApplication_ID(ApplicationID);
            if(tbl.Rows.Count  >0)
            {
                CLODate = tbl.GetAssessmentResultRow(0).AssessmentResult_CLOIssueDate.ToString("dd MMM yyyy");
                CLOExpiryDate = tbl.GetAssessmentResultRow(0).AssessmentResult_CLOIssueDate.AddDays(double.Parse(ConfigurationManager.AppSettings["CLOExpiryDay"].ToString())).ToString("dd MMM yyyy");
            }

          //  CLODate =
        }
        //DA da = new DA();
        //ActionLog log = WebLib.CreateLog("Read Email Notification.");
        //EmailNotificationRow row = da.EmailNotification.GetByEmailNotification_ID(EmailNotificationID);
        //if(row != null)
        //{
        //    litContent.Text = row.EmailNotification_EmailContent;
        //    row.EmailNotification_IsRead = true;
        //    da.EmailNotification.Update(row, log);
        //    log.Save();
        //}else
        //{
        //    litContent.Text = "<h1>Content not found.</h1>";
        //}
    }
}