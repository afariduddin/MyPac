using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class CoachingManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CoachingManagementAjaxGateway));
        AjaxLib.RegisterController("CoachingManagement", ClientID);
    }
}
public class CoachingManagementAjaxGateway : AjaxGatewayBase
{
    public CoachingManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<CoachingDetailTable> GetCoachingListing(string FullName, int Gender, string Email, string IC, string State, DateTime DateFrom, DateTime DateTo, int ContractType, int Status, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();
        Guid UserAccount_ID = Guid.Empty;
        
        if (WebLib.CheckPermission(EngineVariable.PermissionType.CounsellingAccess))
        {
            UserAccount_ID = WebLib.LoggedInUser.UserAccountID;
        }

        PagedDataList<CoachingDetailTable> lis = da.CoachingDetail.Search(UserAccount_ID, FullName, Gender, Email, IC, State, DateFrom, DateTo, ContractType, Status, BuildSqlOrders(col, asc), pg);
        return lis;
    }
    
    [AjaxMethod]
    public CoachingDetailMinimalizedEntity GetCoachingDetail(Guid id)
    {
        DA da = new DA();
        CoachingDetailRow dr = da.CoachingDetail.Get(id);
        if (dr == null) return null;
        else
        {
            CoachingDetailMinimalizedEntity ret = new CoachingDetailMinimalizedEntity(dr);
            return ret;
        }
    }

    [AjaxMethod]
    public CoachingDetailMinimalizedEntity NewCoachingDetail(Guid id)
    {
        CoachingDetailMinimalizedEntity ret = new CoachingDetailMinimalizedEntity();
        return ret;
    }

    [AjaxMethod]
    public ErrorCodes CloseCase(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        ActionLog log = WebLib.CreateLog("Close Case For Coaching");
        CoachingRow dr = da.Coaching.GetByCoaching_ID(id);
        if (dr != null)
        {
            dr.Coaching_Status = (short)EngineVariable.CoachingStatusType.Closed;
            da.Coaching.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveCoaching(CoachingDetailMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Coaching");
        if (errs.Count == 0)
        {
            DA da = new DA();
            CoachingRow dr;
            if (Guid.Empty.CompareTo(ett.Coaching_ID) == 0)
            {
                dr = new CoachingTable().NewCoachingRow();
                ett.Coaching_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Coaching_CreatedDate = DateTime.Now;
                ett.Coaching_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.Coaching.GetByCoaching_ID(ett.Coaching_ID);
                ett.Coaching_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Coaching_UpdatedDate = DateTime.Now;
            }

            ApplicationRow drApplication = da.Application.GetByApplication_ID(ett.Application_ID);

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                
                da.Coaching.Update(dr,log);
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
    public List<CoachingItemMinimalizedEntity> GetCoachingItemListing(Guid CoachingID)
    {
        List<CoachingItemMinimalizedEntity> lis = new List<CoachingItemMinimalizedEntity>();
        DA da = new DA();
        CoachingItemTable dt = da.CoachingItem.GetByCoaching_ID(CoachingID);

        foreach (CoachingItemRow dr in dt.Rows)
        {
            CoachingItemMinimalizedEntity l = new CoachingItemMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }

    [AjaxMethod]
    public CoachingItemMinimalizedEntity NewCoachingItem(Guid CoachingID)
    {
        CoachingItemRow dr = new CoachingItemTable().NewCoachingItemRow();
        dr.Coaching_ID = CoachingID;
        CoachingItemMinimalizedEntity ent = new CoachingItemMinimalizedEntity(dr);

        return ent;
    }
    [AjaxMethod]
    public CoachingItemMinimalizedEntity GetCoachingItem(Guid id)
    {
        DA da = new DA();
        CoachingItemRow dr = da.CoachingItem.GetByCoachingItem_ID(id);
        if (dr == null) return null;
        else
        {
            CoachingItemMinimalizedEntity Entity = new CoachingItemMinimalizedEntity(dr);
            return Entity;
        }
    }
    [AjaxMethod]
    public ErrorCodes DeleteCoachingItem(Guid id)
    {
        DA da = new DA();
        //da.Member.DeleteByCardNumber(cardNo);
        CoachingItemRow dr = da.CoachingItem.GetByCoachingItem_ID(id);
        ActionLog log = WebLib.CreateLog("Delete Coaching Item.");
        if (dr != null)
        {
            dr.Delete();
            da.CoachingItem.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyDescription(string Description)
    {
        if (String.IsNullOrEmpty(Description)) return ErrorCodes.Coaching_DescriptionRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes[] SaveCoachingItem(CoachingItemMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyDescription(ett.CoachingItem_Description));
        DA da = new DA();

        //CoachingItemRow drCoachingItem = da.CoachingItem.GetByCoachingItem_ID(ett.CoachingItem_ID);
        ActionLog log = WebLib.CreateLog("Save Coaching Item.");
        if (errs.Count == 0)
        {
            CoachingItemRow dr;
            if (ett.CoachingItem_ID == Guid.Empty)
            {
                dr = new CoachingItemTable().NewCoachingItemRow();
                ett.CoachingItem_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.CoachingItem_CreatedDate = DateTime.Now;
                ett.CoachingItem_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.CoachingItem.GetByCoachingItem_ID(ett.CoachingItem_ID);
            }
            ett.CoachingItem_UpdatedBy = WebLib.LoggedInUser.UserName;
            ett.CoachingItem_UpdatedDate = DateTime.Now;


            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.CoachingItem.Update(dr,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }

}