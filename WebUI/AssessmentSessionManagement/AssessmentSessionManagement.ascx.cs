using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq.Ajax;
using Teq.Data;
using EngineCommon;

public partial class AssessmentSessionManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(AssessmentSessionManagementAjaxGateway));
        AjaxLib.RegisterController("AssessmentSessionManagement", ClientID);
    }
}
public class AssessmentSessionManagementAjaxGateway : AjaxGatewayBase
{
    public AssessmentSessionManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<AssessmentSessionDetailTable> GetAssessmentSessionList(DateTime startDate, DateTime endDate, string location, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<AssessmentSessionDetailTable> lis = da.AssessmentSessionDetail.Search(startDate, endDate, location, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public AssessmentSessionMinimalizedEntity NewAssessmentSession()
    {
        AssessmentSessionRow dr = new AssessmentSessionTable().NewAssessmentSessionRow();
        AssessmentSessionMinimalizedEntity ett = new AssessmentSessionMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public AssessmentSessionMinimalizedEntity GetAssessmentSession(Guid id)
    {
        DA da = new DA();
        AssessmentSessionRow dr = da.AssessmentSession.GetByAssessmentSession_ID(id);
        if (dr == null) return null;
        else
        {
            AssessmentSessionMinimalizedEntity ett = new AssessmentSessionMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveAssessmentSession(AssessmentSessionMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyLocation(ett.AssessmentSession_Location));
        ActionLog log = WebLib.CreateLog("Save Assessment Session.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            AssessmentSessionRow dr;
            if (ett.AssessmentSession_ID == Guid.Empty)
            {
                dr = new AssessmentSessionTable().NewAssessmentSessionRow();
                ett.AssessmentSession_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.AssessmentSession_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.AssessmentSession_ID = Guid.NewGuid();
                ett.AssessmentSession_IsSent = false;
                //dr.AssessmentSession_CreatedDate = DateTime.Now;
            }
            else
            {
                dr = da.AssessmentSession.GetByAssessmentSession_ID(ett.AssessmentSession_ID);
                ett.AssessmentSession_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.AssessmentSession_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.AssessmentSession.Update(dr,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
    [AjaxMethod]
    public ErrorCodes VerifyLocation(string location)
    {
        if (String.IsNullOrEmpty(location)) return ErrorCodes.AssessmentSession_Location;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteAssessmentSession(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        AssessmentSessionRow dr = da.AssessmentSession.GetByAssessmentSession_ID(id);
        ActionLog log = WebLib.CreateLog("Delete Assessment Session.");
        if (dr != null)
        {
            dr.AssessmentSession_IsDeleted = true;
            da.AssessmentSession.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyAssessmentSessionApplicantRecord(Guid id)
    {
        DA da = new DA();
        if (da.AssessmentSessionApplicant.Get(id)) return ErrorCodes.AssessmentSession_RecordDelete;
        else return ErrorCodes.GEN_NoError;
    }
    
    [AjaxMethod]
    public ErrorCodes SendEmail(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Send Email For Assessment Session.");
        //da.Member.DeleteByCardNumber(cardNo);
        //AssessmentSessionDetailTable dt = da.AssessmentSessionDetail.Get(id);

      AssessmentSessionDetailRow asdRow =  da.AssessmentSessionDetail.Get(id);
        if(asdRow.AssessmentSession_AssignedStudent > 0)
        {
            AssessmentSessionApplicantTable dt = da.AssessmentSessionApplicant.GetByAssessmentSession_ID(id);
            EmailNotificationTable dtEmail = new EmailNotificationTable();

            AssessmentSessionRow drAssessmentSession = da.AssessmentSession.GetByAssessmentSession_ID(id);

            foreach (AssessmentSessionApplicantRow dr in dt.Rows)
            {
                EmailNotificationRow drEmail = dtEmail.NewEmailNotificationRow();
                ApplicationRow drApplication = da.Application.GetByApplication_ID(dr.Applicant_ID);


                drEmail.EmailNotification_CreatedDate = DateTime.Now;
                if (drAssessmentSession.AssessmentSession_IsInterview)
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_InterviewAssessmentInvitation(drApplication, drAssessmentSession);
                else
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_AssessmentInvitation(drApplication, drAssessmentSession);
                drEmail.EmailNotification_ID = Guid.NewGuid();
                drEmail.EmailNotification_Recipient = drApplication.Application_Email;
                drEmail.EmailNotification_RetryCount = 0;
                drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                drEmail.EmailNotification_StatusMessage = "";
                drEmail.Application_ID = dr.Applicant_ID;
                drEmail.EmailNotification_IsRead = false;

                if (drAssessmentSession.AssessmentSession_IsInterview)
                    drEmail.EmailNotification_Subject = "MyPAC: Assessment Interview Invitation";
                else
                    drEmail.EmailNotification_Subject = "MyPAC: Assessment Invitation";


                drAssessmentSession.AssessmentSession_IsSent = true;
                //dtEmail.Rows.Add(drEmail);
            }
            da.AssessmentSession.Update(drAssessmentSession, log);
            da.EmailNotification.Update(dtEmail, log);

            log.Save();
            return ErrorCodes.GEN_NoError;
        }else
        {
            return ErrorCodes.AssessmentSession_AssignedStudent;
        }
      
    }
}

public class AssessmentSessionDialogData
{
    public AssessmentSessionMinimalizedEntity Entity;
    public Dictionary<string, string> AssessmentSession;
}