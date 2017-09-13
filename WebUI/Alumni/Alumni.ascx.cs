using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class Alumni : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(AlumniAjaxGateway));
        AjaxLib.RegisterController("Alumni", ClientID);
    }
}


public class AlumniAjaxGateway : AjaxGatewayBase
{
    public AlumniAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<WorkHistoryDetailTable> GetWorkHistoryListing(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<WorkHistoryDetailTable> lis = da.WorkHistoryDetail.Search(SearchFullName, SearchGender, SearchEmail, SearchICNumber, SearchState, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public WorkHistoryDetailMinimalizedEntity NewWorkHistory()
    {
        WorkHistoryDetailMinimalizedEntity ent = new WorkHistoryDetailMinimalizedEntity();
        return ent;
    }

    [AjaxMethod]
    public WorkHistoryDetailMinimalizedEntity GetWorkHistory(Guid id)
    {
        DA da = new DA();
        WorkHistoryDetailRow dr = da.WorkHistoryDetail.Get(id);
        if (dr == null) return null;
        else
        {
            WorkHistoryDetailMinimalizedEntity ent = new WorkHistoryDetailMinimalizedEntity(dr);
            return ent;
        }
    }

    //[AjaxMethod]
    //public int ValidatePermission()
    //{
    //    if (EngineCommon.LibraryCommon.Validate_AccessRight(WebLib.LoggedInUser.AccessRight, EngineVariable.PermissionType.AlumniView))
    //        return 0;
    //    else return 1;

    //}

    [AjaxMethod]
    public ErrorCodes[] SaveWorkHistory(WorkHistoryDetailMinimalizedEntity ent)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Work History.");
        if (errs.Count == 0)
        {
            DA da = new DA();

            WorkHistoryRow dr = da.WorkHistory.GetByWorkHistory_ID(ent.WorkHistory_ID);
            if (dr == null)
            {
                dr = new WorkHistoryTable().NewWorkHistoryRow();
                ent.WorkHistory_CreatedBy = WebLib.LoggedInUser.UserName;
                ent.WorkHistory_ID = Guid.NewGuid();
                ent.WorkHistory_CreatedDate = DateTime.Now;
            }

            ent.WorkHistory_UpdatedBy = WebLib.LoggedInUser.UserName;
            ent.WorkHistory_UpdatedDate = DateTime.Now;

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ent.CopyTo(dr);
                da.WorkHistory.Update(dr,log);
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
}