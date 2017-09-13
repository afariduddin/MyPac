using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;

public partial class ChangeProfile : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(ChangeProfileAjaxGateway));
        AjaxLib.RegisterController("ChangeProfile", ClientID);
    }
}
public class ChangeProfileAjaxGateway : AjaxGatewayBase
{
    public ChangeProfileAjaxGateway()
    {
    }

    [AjaxMethod]
    public UserAccountDetailMinimalizedEntity GetUserAccount()
    {
        UserAccountDetailMinimalizedEntity data = new UserAccountDetailMinimalizedEntity();
        DA da = new DA();
        UserAccountDetailRow row = da.UserAccountDetail.Get(WebLib.LoggedInUser.UserAccountID);
        if (row != null)
        {
            data = new UserAccountDetailMinimalizedEntity(row);
        }
        return data;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveUserAccount(UserAccountDetailMinimalizedEntity data)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save User Account.");
        if (errs.Count == 0)
        {
            //UserAccountDetailMinimalizedEntity ett = new UserAccountDetailMinimalizedEntity();
            DA da = new DA();

            #region Education Level
            UserAccountRow row = da.UserAccount.Get(WebLib.LoggedInUser.UserAccountID);
            
            if (row == null)
            {
                row = new UserAccountTable().NewUserAccountRow();
                data.UserAccount_CreatedBy = WebLib.LoggedInUser.UserName;
                data.UserAccount_CreatedDate = DateTime.Now;
                data.UserAccount_ID = Guid.NewGuid();
            }

            data.UserAccount_UpdatedDate = DateTime.Now;
            data.UserAccount_UpdatedBy = WebLib.LoggedInUser.UserName;

            data.CopyTo(row);
            da.UserAccount.Update(row,null);

            #endregion
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