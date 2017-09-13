using System;
using Teq.Ajax;
using AjaxPro;
using EngineData;
using System.Collections.Generic;
using EngineVariable;
using EngineCommon;


public partial class CandidateSignIn : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateSignInAjaxGateway));
        AjaxLib.IncludeCoreScripts();
        AjaxLib.IncludeCustomScripts("~/Components/Enumerations.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/ErrorCodes.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/local.js");
        AjaxLib.IncludeCustomScripts("~/Components/custom.js");
    }
}
public class CandidateSignInAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public ErrorCodes[] SignIn(string SignInID, string Password)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();

        if (SignInID == "")
            AddError(errs, ErrorCodes.Candidate_UserID);

        if (errs.Count == 0)
        {
            DA da = new DA();
            CandidateRow dr = da.Candidate.GetByUserID(SignInID);

            if (dr == null)
            {
                AddError(errs, ErrorCodes.Candidate_InvalidAccount);
            }
            else if (dr.Candidate_Password != Password)
            {
                AddError(errs, ErrorCodes.Candidate_InvalidAccount);
            }
            else
            {
                LoggedInUser l = new LoggedInUser();

                l.FullName = dr.Candidate_FullName;
                l.UserGroupID = Guid.Empty;
                l.UserName = dr.Candidate_UserID;
                l.CandidateID = dr.Candidate_ID;
                WebLib.LoggedInUser = l;
                ActionLog log = WebLib.CreateLog("Sign In (Candidate).");
                log.Save();
            }
        }

        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] RetrievePassword(string SignInID)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Candidate Retrieve Password.");
        if (SignInID == "")
            AddError(errs, ErrorCodes.Candidate_UserID);

        if (errs.Count == 0)
        {
            DA da = new DA();
            CandidateRow dr = da.Candidate.GetByUserID(SignInID);

            if (dr == null)
            {
                AddError(errs, ErrorCodes.Candidate_InvalidSignInID);
            }
            else
            {
                //prepare email content

                EmailNotificationTable dtEmail = new EmailNotificationTable();
                EmailNotificationRow drEmail = dtEmail.NewEmailNotificationRow();
                drEmail.EmailNotification_CreatedDate = DateTime.Now;
                drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_CandidatePasswordRetrieve(dr);
                drEmail.EmailNotification_ID = Guid.NewGuid();
                drEmail.EmailNotification_Recipient = dr.Candidate_Email;
                drEmail.EmailNotification_RetryCount = 0;
                drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                drEmail.EmailNotification_StatusMessage = "";
                drEmail.EmailNotification_Subject = "MyPAC: Password Retrieve";
                drEmail.Application_ID = Guid.Empty;
                drEmail.EmailNotification_IsRead = false;
                da.EmailNotification.Update(dtEmail, log);
                log.Save();
            }
        }

        return errs.ToArray();
    }
    
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
}