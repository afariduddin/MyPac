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

public partial class PartTimerSessionManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(PartTimerSessionManagementAjaxGateway));
        AjaxLib.RegisterController("PartTimerSessionManagement", ClientID);
    }
}
public class PartTimerSessionManagementAjaxGateway : AjaxGatewayBase
{
    public PartTimerSessionManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<PartTimerAssessmentSessionDetailTable> GetPartTimerAssessmentSessionList(DateTime startDate, DateTime endDate, string location, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<PartTimerAssessmentSessionDetailTable> lis = da.PartTimerAssessmentSessionDetail.Search(startDate, endDate, location, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public PartTimerAssessmentSessionMinimalizedEntity NewPartTimerAssessmentSession()
    {
        PartTimerAssessmentSessionRow dr = new PartTimerAssessmentSessionTable().NewPartTimerAssessmentSessionRow();
        PartTimerAssessmentSessionMinimalizedEntity ett = new PartTimerAssessmentSessionMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public PartTimerAssessmentSessionMinimalizedEntity GetPartTimerAssessmentSession(Guid id)
    {
        DA da = new DA();
        PartTimerAssessmentSessionRow dr = da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(id);
        if (dr == null) return null;
        else
        {
            PartTimerAssessmentSessionMinimalizedEntity ett = new PartTimerAssessmentSessionMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SavePartTimerAssessmentSession(PartTimerAssessmentSessionMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyLocation(ett.PartTimerAssessmentSession_Location));
        AddError(errs, VerifyType(ett.PartTimerAssessmentSession_SessionType));
        ActionLog log = WebLib.CreateLog((ett.PartTimerAssessmentSession_ID == Guid.Empty ? "Create" : "Modify")+" Part Timer Assessment Session.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            PartTimerAssessmentSessionRow dr;
            if (ett.PartTimerAssessmentSession_ID == Guid.Empty)
            {
                dr = new PartTimerAssessmentSessionTable().NewPartTimerAssessmentSessionRow();
                ett.PartTimerAssessmentSession_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.PartTimerAssessmentSession_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.PartTimerAssessmentSession_ID = Guid.NewGuid();
                //dr.AssessmentSession_CreatedDate = DateTime.Now;
            }
            else
            {
                dr = da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(ett.PartTimerAssessmentSession_ID);
                ett.PartTimerAssessmentSession_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.PartTimerAssessmentSession_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.PartTimerAssessmentSession.Update(dr,log);
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
        if (String.IsNullOrEmpty(location)) return ErrorCodes.PartTimerAssessmentSession_Location;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyType(short SessionType)
    {
        if (SessionType == -1) return ErrorCodes.PartTimerAssessmentSession_Type;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeletePartTimerAssessmentSession(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Part Timer Assessment Session.");
        PartTimerAssessmentSessionRow dr = da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(id);
        if (dr != null)
        {
            dr.PartTimerAssessmentSession_IsDeleted = true;
            da.PartTimerAssessmentSession.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyPartTimerAssessmentSessionApplicantRecord(Guid id)
    {
        DA da = new DA();
        if (da.PartTimerAssessmentSessionApplicant.Get(id)) return ErrorCodes.PartTimerAssessmentSession_RecordDelete;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes SendEmail(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Send Email For Part Timer Session Invitation.");
        //da.Member.DeleteByCardNumber(cardNo);
        //AssessmentSessionDetailTable dt = da.AssessmentSessionDetail.Get(id);
       PartTimerAssessmentSessionDetailRow ptasRow =  da.PartTimerAssessmentSessionDetail.Get(id);
        if(ptasRow.PartTimerAssessmentSession_AssignedStudent > 0)
        {
            PartTimerAssessmentSessionApplicantTable dt = da.PartTimerAssessmentSessionApplicant.GetByPartTimerAssessmentSession_ID(id);
            EmailNotificationTable dtEmail = new EmailNotificationTable();
            PartTimerAssessmentSessionRow drPartTimerAssessment = da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(id);
            foreach (PartTimerAssessmentSessionApplicantRow dr in dt.Rows)
            {
                EmailNotificationRow drEmail = dtEmail.NewEmailNotificationRow();
                ApplicationRow drApplication = da.Application.GetByApplication_ID(dr.Applicant_ID);


                drEmail.EmailNotification_CreatedDate = DateTime.Now;
                if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Assessment)
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_PartTimerAssessment(drApplication, drPartTimerAssessment);
                else if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.CDP)
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_PartTimerCDP(drApplication, drPartTimerAssessment);
                else if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Interview)
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_PartTimerInterview(drApplication, drPartTimerAssessment);
                drEmail.EmailNotification_ID = Guid.NewGuid();
                drEmail.EmailNotification_Recipient = drApplication.Application_Email;
                drEmail.EmailNotification_RetryCount = 0;
                drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                drEmail.EmailNotification_StatusMessage = "";
                drEmail.Application_ID = dr.Applicant_ID;
                drEmail.EmailNotification_IsRead = false;
                if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Assessment)
                    drEmail.EmailNotification_Subject = "MyPAC: Part-Timer Assessment Invitation";
                else if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.CDP)
                    drEmail.EmailNotification_Subject = "MyPAC: Part-Timer CDP Invitation";
                else if (drPartTimerAssessment.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Interview)
                    drEmail.EmailNotification_Subject = "MyPAC: Part-Timer Interview Invitation";


                drPartTimerAssessment.PartTimerAssessmentSession_IsSent = true;
                //dtEmail.Rows.Add(drEmail);
            }
            da.PartTimerAssessmentSession.Update(drPartTimerAssessment, log);
            da.EmailNotification.Update(dtEmail, log);

            log.Save();
            return ErrorCodes.GEN_NoError;
        }
        else
        {
            return ErrorCodes.PartTimerAssessmentSession_AssignedStudent;
        }
       
    }
    //[AjaxMethod]
    //public int AssignedStudent(Guid id)
    //{
    //    DA da = new DA();
    //    AssessmentSessionDetailAdapter dr = da.AssessmentSessionDetail;
    //    if (int.Parse(dr.GetAssignedStudent(id).ToString()) > 0) return int.Parse(dr.GetAssignedStudent(id).ToString());
    //    else return 0;
    //}
    
}

public class PartTimerAssessmentSessionDialogData
{
    public PartTimerAssessmentSessionMinimalizedEntity Entity;
    public Dictionary<string, string> PartTimerAssessmentSession;
}