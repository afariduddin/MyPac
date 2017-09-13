using System;
using Teq.Ajax;
using AjaxPro;
using EngineData;
using System.Collections.Generic;
using EngineVariable;
using EngineCommon;

public partial class CandidateContainer : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateContainerAjaxGateway));       
        AjaxLib.IncludeCoreScripts();
        AjaxLib.IncludeCustomScripts("~/Components/Enumerations.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/ErrorCodes.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/local.js");
        AjaxLib.IncludeCustomScripts("~/Components/custom.js");
    }
}

public class CandidateContainerAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public ErrorCodes[] SignOut()
    {
        WebLib.LoggedInUser = null;
        List<ErrorCodes> errs = new List<ErrorCodes>();
        return errs.ToArray();
    }

    [AjaxMethod]
    public List<ErrorCodes> ValidateSession()
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        if (WebLib.LoggedInUser == null)
        {
            errs.Add(ErrorCodes.GEN_NoLogin);
        }
        else
        {
        }
        return errs;
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
            }else
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


    [AjaxMethod]
    //public CandidateType GetCandidateType(string SignInID)
    public UserEntity GetCandidateType()
    {
        UserEntity ent = new UserEntity();
        if (WebLib.LoggedInUser != null)
        {
            string SignInID = WebLib.LoggedInUser.UserName;

           

            ent.UserID = SignInID;

            //CandidateType ret = EngineVariable.CandidateType.Candidate;
            DA da = new DA();
            CandidateRow dr = da.Candidate.GetByUserID(SignInID);

            if (dr != null)
            {
                ApplicationTable appTable = da.Application.GetByCandidate_ID(dr.Candidate_ID);
                if (appTable.Rows.Count > 0)
                {
                    ApplicationRow appRow = appTable.GetApplicationRow(0);
                    if (appRow != null)
                    {
                        if (appRow.Application_OverallStatus == EngineVariable.ApplicationOverallStatusType.Completed.Code)
                        {
                            ent.ret = EngineVariable.CandidateType.Alumni;
                        }
                        else if (appRow.Application_OverallProgress == EngineVariable.ApplicationOverallProgressType.StudentCourse.Code)
                        {
                            ent.ret = EngineVariable.CandidateType.Student;
                        }
                    }
                }
            }
        }
        else
        {
            
            ent.UserID = "";
            ent.ret = EngineVariable.CandidateType.Candidate;
        }


        return ent;
    }
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
}
public class UserEntity
{
    public CandidateType ret = EngineVariable.CandidateType.Candidate;
    public string UserID = "";
}