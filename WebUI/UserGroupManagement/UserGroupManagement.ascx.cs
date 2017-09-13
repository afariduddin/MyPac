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

public partial class UserGroupManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(UserGroupManagementAjaxGateway));
        AjaxLib.RegisterController("UserGroupManagement", ClientID);
    }
}
public class UserGroupManagementAjaxGateway : AjaxGatewayBase
{
    public UserGroupManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<UserGroupTable> GetUserGroupList(string name, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<UserGroupTable> lis = da.UserGroup.Search(name, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public UserGroupDialogData NewUserGroup()
    {
        UserGroupRow dr = new UserGroupTable().NewUserGroupRow();
        UserGroupDialogData ent = new UserGroupDialogData();

        ent.Entity = new UserGroupMinimalizedEntity(dr);
        ent.SelectedGroup = new List<string>();
        return ent;
    }
    [AjaxMethod]
    public UserGroupDialogData GetUserGroup(Guid id)
    {
        DA da = new DA();
        UserGroupRow dr = da.UserGroup.GetByUserGroup_ID(id);
        UserGroupDialogData ent = new UserGroupDialogData();
        if (dr == null) return null;
        else
        {
            ent.Entity = new UserGroupMinimalizedEntity(dr);
            ent.SelectedGroup = new List<string>();
            string[] Permissions = dr.UserGroup_Permission.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string Permission in Permissions)
            {
                ent.SelectedGroup.Add(Permission);
            }

            return ent;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveUserGroup(UserGroupDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyName(ett.Entity.UserGroup_Name));
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
        string Permission = "";
        ActionLog log = WebLib.CreateLog((ett.Entity.UserGroup_ID == Guid.Empty ? "Create" : "Modify") + " User Group.");
        foreach (string p in ett.SelectedGroup)
        {
            if (Permission != "")
                Permission += ";";

            Permission += p.ToString();
        }

        ett.Entity.UserGroup_Permission = Permission;

        if (errs.Count == 0)
        {
            DA da = new DA();
            UserGroupRow dr;
            if (ett.Entity.UserGroup_ID == Guid.Empty)
            {
                dr = new UserGroupTable().NewUserGroupRow();
                ett.Entity.UserGroup_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.UserGroup_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.UserGroup_ID = Guid.NewGuid();
                dr.UserGroup_CreatedDate = DateTime.Now;
                
            }
            else
            {
                dr = da.UserGroup.GetByUserGroup_ID(ett.Entity.UserGroup_ID);
                ett.Entity.UserGroup_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.UserGroup_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.Entity.CopyTo(dr);
                da.UserGroup.Update(dr,log);
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
        if (String.IsNullOrEmpty(name)) return ErrorCodes.UserGroup_Name;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteUserGroup(Guid id)
    {
        DA da = new DA();
        UserGroupRow dr = da.UserGroup.GetByUserGroup_ID(id);

        UserAccountTable dtUserAccount = da.UserAccount.GetByUserGroup_ID(id);
        if (dtUserAccount.Rows.Count > 0)
        {
            return ErrorCodes.UserGroup_InUse;
        }

        ActionLog log = WebLib.CreateLog("Delete User Group.");
        if (dr != null)
        {
            dr.UserGroup_IsDeleted = true;
            da.UserGroup.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}

public class UserGroupDialogData
{
    public UserGroupMinimalizedEntity Entity;
    public List<string> SelectedGroup;
}
