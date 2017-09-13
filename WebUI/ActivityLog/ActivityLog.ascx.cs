using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class ActivityLog : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(ActivityLogAjaxGateway));
        AjaxLib.RegisterController("ActivityLog", ClientID);
    }
}

public class ActivityLogAjaxGateway : AjaxGatewayBase
{
    public ActivityLogAjaxGateway()
    {
    }

    [AjaxMethod]
    public PagedDataList<ActivityLogTable> GetActivityLogListing(DateTime? From, DateTime? To, string UserID, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<ActivityLogTable> lis = da.ActivityLog.Search(From, To, UserID, BuildSqlOrders(col, asc), pg);
        return lis;
    }
    [AjaxMethod]
    public List<ActivityLogTransactionMinimalizedEntity> GetActivityLogTransaction(Guid LogID)
    {
        DA da = new DA();

        List<ActivityLogTransactionMinimalizedEntity> lis = new List<ActivityLogTransactionMinimalizedEntity>();
        ActivityLogTransactionTable dt = da.ActivityLogTransaction.GetByActivityLog_ID(LogID);

        foreach (ActivityLogTransactionRow dr in dt.Rows)
        {
            ActivityLogTransactionMinimalizedEntity l = new ActivityLogTransactionMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }
    [AjaxMethod]
    public List<ActivityLogColumnMinimalizedEntity> GetActivityLogColumn(Guid TransactionID)
    {
        DA da = new DA();

        List<ActivityLogColumnMinimalizedEntity> lis = new List<ActivityLogColumnMinimalizedEntity>();
        ActivityLogColumnTable dt = da.ActivityLogColumn.GetByActivityLogTransaction_ID(TransactionID);

        foreach (ActivityLogColumnRow dr in dt.Rows)
        {
            ActivityLogColumnMinimalizedEntity l = new ActivityLogColumnMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }
}