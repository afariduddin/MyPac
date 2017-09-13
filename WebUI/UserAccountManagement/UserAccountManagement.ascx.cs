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


public partial class UserAccountManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(UserAccountManagementAjaxGateway));
        AjaxLib.RegisterController("UserAccountManagement", ClientID);

    }
}
public class UserAccountManagementAjaxGateway : AjaxGatewayBase
{
    public UserAccountManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<UserAccountDetailTable> GetUserAccountList(string name, string userid, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<UserAccountDetailTable> lis = da.UserAccountDetail.Search(name, userid, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public UserAccountDialogData NewUserAccount()
    {
        //UserAccountRow dr = new UserAccountTable().NewUserAccountRow();
        //UserAccountMinimalizedEntity ett = new UserAccountMinimalizedEntity(dr);
        //return ett;

        UserAccountDialogData ret = new UserAccountDialogData();

        UserAccountRow dr = new UserAccountTable().NewUserAccountRow();
        ret.Entity = new UserAccountMinimalizedEntity(dr);

        ret.UserGroup = GetUserGroup();
      //  ret.States = new Dictionary<string, string>(); // GetStates(ret.Entity.Country);

        return ret;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetUserGroup()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<UserGroupRow> list = da.UserGroup.GetAll();
       foreach(UserGroupRow r in list)
        {
            lis.Add(r.UserGroup_ID.ToString(),r.UserGroup_Name);
        }
 
        return lis;
    }
    [AjaxMethod]
    public UserAccountDialogData GetUserAccount(Guid id)
    {
        DA da = new DA();
        UserAccountRow dr = da.UserAccount.GetByUserAccount_ID(id);
        if (dr == null) return null;
        else
        {
            //UserAccountMinimalizedEntity ett = new UserAccountMinimalizedEntity(dr);
            //return ett;

            UserAccountDialogData ret = new UserAccountDialogData();

       
            ret.Entity = new UserAccountMinimalizedEntity(dr);

            ret.UserGroup = GetUserGroup();
            return ret;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveUserAccount(UserAccountMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyName(ett.UserAccount_FullName));
        AddError(errs, VerifyUserID(ett.UserAccount_UserID,ett.UserAccount_ID));
        AddError(errs, VerifyUserGroup(ett.UserGroup_ID));
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
        ActionLog log = WebLib.CreateLog((ett.UserAccount_ID == Guid.Empty ? "Create" : "Modify") + " User Account.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            UserAccountRow dr;
            if (ett.UserAccount_ID == Guid.Empty)
            {
                dr = new UserAccountTable().NewUserAccountRow();
                ett.UserAccount_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.UserAccount_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.UserAccount_ID = Guid.NewGuid();
                ett.UserAccount_Password = ett.UserAccount_UserID;
                dr.UserAccount_CreatedDate = DateTime.Now;

            }
            else
            {
                dr = da.UserAccount.GetByUserAccount_ID(ett.UserAccount_ID);
                ett.UserAccount_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.UserAccount_UpdatedDate = DateTime.Now;
                //dr.ModifiedBy = "someone";
                //dr.ModifiedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.UserAccount.Update(dr,log);
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
    public ErrorCodes VerifyName(string name)
    {
        if (String.IsNullOrEmpty(name)) return ErrorCodes.UserAccount_Name;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyUserGroup(Guid ID)
    {
        if (ID== Guid.Empty) return ErrorCodes.UserAccount_UserGroupRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyUserID(string userid,Guid id)
    {
        DA da = new DA();
        UserAccountRow row = null;
        if (String.IsNullOrEmpty(userid)) return ErrorCodes.UserAccount_UserID;

        row = da.UserAccount.GetByUserID(userid);
        if (row != null)
        {
            if (id == null)
            {
                return ErrorCodes.UserAccount_DuplicateUserID;
            }
            else
            {
                if (id != row.UserAccount_ID)
                {
                    return ErrorCodes.UserAccount_DuplicateUserID;
                }
            }
        }
        return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteUserAccount(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete User Account.");
        //da.Member.DeleteByCardNumber(cardNo);
        UserAccountRow dr = da.UserAccount.GetByUserAccount_ID(id);
        if (dr != null)
        {
            dr.UserAccount_IsDeleted = true;
            da.UserAccount.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes ResetPassword(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        ActionLog log = WebLib.CreateLog("Reset Password.");
        UserAccountRow dr = da.UserAccount.GetByUserAccount_ID(id);
        if (dr != null)
        {
            dr.UserAccount_Password = dr.UserAccount_UserID;
            da.UserAccount.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}

public class UserAccountDialogData
{
    public UserAccountMinimalizedEntity Entity;
    public Dictionary<string, string> UserGroup;
}