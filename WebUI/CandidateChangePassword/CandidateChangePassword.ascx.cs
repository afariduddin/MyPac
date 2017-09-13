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

public partial class CandidateChangePassword : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateChangePasswordAjaxGateway));
        AjaxLib.RegisterController("CandidateChangePassword", ClientID);
    }
}

public class CandidateChangePasswordAjaxGateway : AjaxGatewayBase
{
    public CandidateChangePasswordAjaxGateway()
    {
    }
    [AjaxMethod]
    public ErrorCodes[] SavePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
    {
        //
        // string NewPassword = "";

        // string ConfirmPassword = "";

        ActionLog log = WebLib.CreateLog("Candidate Save Password.");
        List<ErrorCodes> errs = new List<ErrorCodes>();

        if (ConfirmPassword != NewPassword)
        {
            AddError(errs, ErrorCodes.Candidate_NewPasswordNotMatched);
        }

        DA da = new DA();
       CandidateRow row=  da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);
       // UserAccountRow row = da.UserAccount.GetByUserAccount_ID(WebLib.LoggedInUser.UserAccountID);

        if (row.Candidate_Password != CurrentPassword)
        {
            AddError(errs, ErrorCodes.Candidate_CurrentPasswordNotMatched);
        }

        if (row.Candidate_Password == NewPassword)
        {
            AddError(errs, ErrorCodes.Candidate_CurrentPasswordMatched);
        }

        if (errs.Count == 0)
        {


            if (row != null)
            {
                row.Candidate_Password = NewPassword;
                row.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;
                row.Candidate_UpdatedDate = DateTime.Now;
            }
            da.Candidate.Update(row,log);
        }
        log.Save();
        return errs.ToArray();
    }
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
}

public class CandidateChangePasswordDialogData
{
    public string CurrentPassword = "";
    public string NewPassword = "";
    public string ConfirmPassword = "";
    public CandidateChangePasswordDialogData()
    {
    }
}