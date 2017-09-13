using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;
using OfficeOpenXml;
using System.IO;
using System.Web;
using EngineCommon;

public partial class EmailNotificationManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(EmailNotificationManagementAjaxGateway));
        AjaxLib.RegisterController("EmailNotificationManagement", ClientID);
    }
}

public class EmailNotificationManagementAjaxGateway : AjaxGatewayBase
{
    public EmailNotificationManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<EmailNotificationTable> GetEmailNotificationListing(DateTime? CreatedDateFrom, DateTime? CreatedDateTo, string SearchEmailRecipient, int SearchStatus, string SearchEmailSubject, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<EmailNotificationTable> lis = da.EmailNotification.Search(CreatedDateFrom, CreatedDateTo, SearchEmailRecipient, SearchStatus, SearchEmailSubject, BuildSqlOrders(col, asc), pg);

        return lis;
    }
    //[AjaxMethod]
    //public EmailNotificationMinimalizedEntity NewEmailNotification()
    //{
    //    EmailNotificationRow dr = new EmailNotificationTable().NewEmailNotificationRow();
    //    EmailNotificationMinimalizedEntity ett = new EmailNotificationMinimalizedEntity(dr);
    //    return ett;
    //}
    //[AjaxMethod]
    //public EmailNotificationMinimalizedEntity GetEmailNotification(Guid id)
    //{
    //    DA da = new DA();
    //    EmailNotificationRow dr = da.EmailNotification.GetByEmailNotification_ID(id);
    //    if (dr == null) return null;
    //    else
    //    {
    //        EmailNotificationMinimalizedEntity ett = new EmailNotificationMinimalizedEntity(dr);
    //        return ett;
    //    }
    //}
    
    //[AjaxMethod]
    //public ErrorCodes[] SaveEmailNotification(EmailNotificationMinimalizedEntity ett)
    //{
    //    List<ErrorCodes> errs = new List<ErrorCodes>();
    //    //AddError(errs, VerifyName(ett.EmailNotification_Name));
    //    //AddError(errs, VerifyModDate(ett.ModifiedDate));

    //    if (errs.Count == 0)
    //    {
    //        DA da = new DA();
    //        EmailNotificationRow dr;
    //        if (ett.EmailNotification_ID == Guid.Empty)
    //        {
    //            dr = new EmailNotificationTable().NewEmailNotificationRow();
    //            ett.EmailNotification_ID = Guid.NewGuid();
    //            dr.EmailNotification_CreatedDate = DateTime.Now;

    //        }
    //        else
    //        {
    //            dr = da.EmailNotification.GetByEmailNotification_ID(ett.EmailNotification_ID);
    //        }
    //        if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
    //        else
    //        {
    //            ett.CopyTo(dr);
    //            da.EmailNotification.Update(dr);
    //        }
    //    }

    //    return errs.ToArray();
    //}

    //[AjaxMethod]
    //public ErrorCodes DeleteEmailNotication(Guid id)
    //{
    //    DA da = new DA();
    //    EmailNotificationRow dr = da.EmailNotification.GetByEmailNotification_ID(id);
    //    if (dr != null)
    //    {
    //        da.EmailNotification.DeleteByEmailNotification_ID(id);
    //    }
    //    return ErrorCodes.GEN_NoError;
    //}

    [AjaxMethod]
    public ErrorCodes ResetRetryCount(Guid id)
    {
        DA da = new DA();
        EmailNotificationRow dr = da.EmailNotification.GetByEmailNotification_ID(id);
        ActionLog log = WebLib.CreateLog("Reset Email Notificaiton Retry Count.");
        if (dr != null)
        {
            dr.EmailNotification_RetryCount = 0;//Int16.Parse("2");
            da.EmailNotification.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
}