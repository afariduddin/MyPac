using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using EngineCommon;
using Teq.Ajax;
using Teq.Data;

public partial class FinalisedCandidate : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(FinalisedCandidateAjaxGateway));
        AjaxLib.RegisterController("FinalisedCandidate", ClientID);
    }
}
public class FinalisedCandidateAjaxGateway : AjaxGatewayBase
{
    public FinalisedCandidateAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<ApplicationDetailTable> GetFinalisedCandidateList(string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, int FinalisedApplicationStatusType, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<ApplicationDetailTable> lis = da.ApplicationDetail.Search(FullName, Gender, Email, ICNumber, State, ContractType, FinalisedApplicationStatusType, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public ApplicationMinimalizedEntity NewFinalisedCandidate()
    {
        ApplicationRow dr = new ApplicationTable().NewApplicationRow();
        ApplicationMinimalizedEntity ett = new ApplicationMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public ApplicationMinimalizedEntity GetFinalisedCandidate(Guid id)
    {
        DA da = new DA();
        ApplicationRow dr = da.Application.GetByApplication_ID(id);
        if (dr == null) return null;
        else
        {
            ApplicationMinimalizedEntity ett = new ApplicationMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveFinalisedCandidate(ApplicationMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyFullName(ett.Application_FullName));
        AddError(errs, VerifyNationality(ett.Application_Nationality));
        AddError(errs, VerifyICNumber(ett.Application_IdentificationNumber));
        AddError(errs, VerifyMobileNumber(ett.Application_MobilePhonePrefix, ett.Application_MobilePhoneNumber));
        AddError(errs, VerifyEmail(ett.Application_Email));
        ActionLog log = WebLib.CreateLog("Save Finalised Candidate.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            ApplicationRow dr;
            if (ett.Application_ID == Guid.Empty)
            {
                dr = new ApplicationTable().NewApplicationRow();
                ett.Application_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Application_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.Application.GetByApplication_ID(ett.Application_ID);
                ett.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Application_UpdatedDate = DateTime.Now;
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.Application.Update(dr,log);
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
    public ErrorCodes VerifyFullName(string fullname)
    {
        if (String.IsNullOrEmpty(fullname)) return ErrorCodes.Application_FullNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    //public ErrorCodes VerifyNationality(int nationality)
    public ErrorCodes VerifyNationality(string nationality)
    {
        //if (nationality == -1) return ErrorCodes.Application_NationalityRequired;
        if (String.IsNullOrEmpty(nationality)) return ErrorCodes.Application_NationalityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyICNumber(string icNum)
    {
        if (String.IsNullOrEmpty(icNum)) return ErrorCodes.Application_ICNumberRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyEmail(string email)
    {
        if (String.IsNullOrEmpty(email)) return ErrorCodes.Application_EmailRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMobileNumber(string mobilePrefix, string MobileNum)
    {
        if (String.IsNullOrEmpty(mobilePrefix) || String.IsNullOrEmpty(MobileNum)) return ErrorCodes.CandidateApplication_MobilePhoneNumberRequired;
        else return ErrorCodes.GEN_NoError;
    }
    
    [AjaxMethod]
    public ErrorCodes SendLO(List<string> ApplicationIDs)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Send LO.");
        foreach (string ApplicationID in ApplicationIDs)
        {
            ApplicationRow dr = da.Application.GetByApplication_ID(Guid.Parse(ApplicationID));
            if (dr != null)
            {
                if (dr.Application_FinalisedStatus == (short)EngineVariable.FinalisedApplicationStatusType.Pending)
                {
                    dr.Application_FinalisedStatus = (short)EngineVariable.FinalisedApplicationStatusType.LOIssued;
                    dr.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                    dr.Application_UpdatedDate = DateTime.Now;
                    dr.Application_LOIssueDate = DateTime.Now;
                    
                    EmailNotificationRow drEmail = new EmailNotificationTable().NewEmailNotificationRow();

                    drEmail.EmailNotification_CreatedDate = DateTime.Now;
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_LetterOfOffer(dr);
                    drEmail.EmailNotification_ID = Guid.NewGuid();
                    drEmail.EmailNotification_Recipient = dr.Application_Email;
                    drEmail.EmailNotification_RetryCount = 0;
                    drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                    drEmail.EmailNotification_StatusMessage = "";
                    drEmail.EmailNotification_Subject = "MyPAC: Letter of Offer";
                    drEmail.Application_ID = dr.Application_ID;
                    drEmail.EmailNotification_IsRead = false;

                    da.Application.Update(dr,log);
                    da.EmailNotification.Update(drEmail,log);
                }
            }
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    //[AjaxMethod]
    //public ErrorCodes VerifyRejectedApplication(Guid id)
    //{
    //    DA da = new DA();
    //    ApplicationRow dr = da.Application.GetByApplication_ID(id);
    //    if (dr.Application_Status.ToString() == "2") return ErrorCodes.Application_Rejected;
    //    else return ErrorCodes.GEN_NoError;
    //}
    //[AjaxMethod]
    //public ErrorCodes RejectApplication(Guid id)
    //{
    //    DA da = new DA();
    //    ApplicationRow dr = da.Application.GetByApplication_ID(id);
    //    if (dr != null)
    //    {
    //        dr.Application_Status = Int16.Parse("2");
    //        da.Application.Update(dr);
    //    }
    //    return ErrorCodes.GEN_NoError;
    //}

    [AjaxMethod]
    public int ValidatePermission(int AccessType)
    {
        if (EngineCommon.LibraryCommon.Validate_AccessRight(WebLib.LoggedInUser.AccessRight, EngineVariable.PermissionType.Find<EngineVariable.PermissionType>(AccessType)))
            return 0;
        else return 1;
    }
}