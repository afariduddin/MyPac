using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class Container : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(ContainerAjaxGateway));
        AjaxLib.IncludeCoreScripts();
        AjaxLib.IncludeCKEditorScripts();
        AjaxLib.IncludeCustomScripts("~/Components/Enumerations.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/ErrorCodes.Js.aspx");
        AjaxLib.IncludeCustomScripts("~/Components/local.js");
        AjaxLib.IncludeCustomScripts("~/Components/custom.js");
    }
}

public class ContainerAjaxGateway : AjaxGatewayBase
{

    public ContainerAjaxGateway()
    {
    }

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
        else {
        }
        return errs;
    }
    
    [AjaxMethod]
    public UserAccountEntity GetLogin()
    {
        UserAccountEntity ent = new UserAccountEntity();
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //string SignInID = WebLib.LoggedInUser.UserName;

        LoggedInUser l = WebLib.LoggedInUser;
        //l.FullName = dr.UserAccount_FullName;
        //l.UserGroupID = dr.UserGroup_ID;
        //l.UserName = dr.UserAccount_UserID;
        //l.UserAccountID = dr.UserAccount_ID;

        //UserGroupRow drUserGroup = da.UserGroup.GetByUserGroup_ID(dr.UserGroup_ID);

        //l.AccessRight = drUserGroup.UserGroup_Permission;
        //WebLib.LoggedInUser = l;
        //ActionLog log = WebLib.CreateLog("Sign In.");
        //log.Save();

        ent.errs = errs.ToArray();
        ent.l = WebLib.LoggedInUser;
        //return errs.ToArray();
        return ent;
    }
}

public class UserAccountEntity
{
    public LoggedInUser l = new LoggedInUser();
    public ErrorCodes[] errs;
}