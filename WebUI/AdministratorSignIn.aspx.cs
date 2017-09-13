using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class AdministratorSignIn : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(AdministratorSignInAjaxGateway));
        AjaxLib.IncludeCoreScripts();
        AjaxLib.IncludeCustomScripts("~/Components/Enumerations.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/ErrorCodes.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/local.js");
        AjaxLib.IncludeCustomScripts("~/Components/custom.js");
    }
}

public class AdministratorSignInAjaxGateway : AjaxGatewayBase
{
    public AdministratorSignInAjaxGateway()
    {
    }
    [AjaxMethod]
    public ErrorCodes[] SignIn(string SignInID, string Password)
    {
        //UserAccountEntity ent = new UserAccountEntity();
        List<ErrorCodes> errs = new List<ErrorCodes>();

        if (SignInID == "")
            AddError(errs, ErrorCodes.UserAccount_UserID);

        if (errs.Count == 0)
        {
            DA da = new DA();
            UserAccountRow dr = da.UserAccount.GetByUserID(SignInID);

            if (dr == null)
            {
                AddError(errs, ErrorCodes.UserAccount_InvalidAccount);
            }
            else if (dr.UserAccount_Password != Password)
            {
                AddError(errs, ErrorCodes.UserAccount_InvalidAccount);
            }
            else
            {
                LoggedInUser l = new LoggedInUser();

                l.FullName = dr.UserAccount_FullName;
                l.UserGroupID = dr.UserGroup_ID;
                l.UserName = dr.UserAccount_UserID;
                l.UserAccountID = dr.UserAccount_ID;

                UserGroupRow drUserGroup = da.UserGroup.GetByUserGroup_ID(dr.UserGroup_ID);

                l.AccessRight = drUserGroup.UserGroup_Permission;
                WebLib.LoggedInUser = l;
                ActionLog log = WebLib.CreateLog("Sign In.");
                log.Save();
            }
        }
        
        //ent.l = WebLib.LoggedInUser;
        //return errs.ToArray();
        return errs.ToArray();
    }
    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
}