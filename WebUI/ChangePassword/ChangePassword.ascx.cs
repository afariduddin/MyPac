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

public partial class ChangePassword : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(ChangePasswordAjaxGateway));
        AjaxLib.RegisterController("ChangePassword", ClientID);
    }
}
public class ChangePasswordAjaxGateway : AjaxGatewayBase
{
    public ChangePasswordAjaxGateway()
    {
    }

    [AjaxMethod]
    //public ErrorCodes[] SavePassword(ChangePasswordDialogData data)
    public ErrorCodes[] SavePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Password.");
        if (ConfirmPassword != NewPassword)
        {
            AddError(errs, ErrorCodes.UserAccount_NewPasswordNotMatched);
        }

        DA da = new DA();
        UserAccountRow row = da.UserAccount.GetByUserAccount_ID(WebLib.LoggedInUser.UserAccountID);

        if (row.UserAccount_Password != CurrentPassword)
        {
            AddError(errs, ErrorCodes.UserAccount_CurrentPasswordNotMatched);
        }

        if (row.UserAccount_Password == NewPassword)
        {
            AddError(errs, ErrorCodes.UserAccount_CurrentPasswordMatched);
        }

        if (errs.Count == 0)
        {


            if (row != null)
            {
                row.UserAccount_Password = NewPassword;
                row.UserAccount_UpdatedBy = WebLib.LoggedInUser.UserName;
                row.UserAccount_UpdatedDate = DateTime.Now;
            }
            da.UserAccount.Update(row,log);
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

public class ChangePasswordDialogData
{
    public string CurrentPassword = "";
    public string NewPassword = "";
    public string ConfirmPassword = "";
    public ChangePasswordDialogData()
    {
    }
}