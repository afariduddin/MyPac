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

public partial class CandidateWorkHistory : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateWorkHistoryAjaxGateway));
        AjaxLib.RegisterController("CandidateWorkHistory", ClientID);
    }
}
public class CandidateWorkHistoryAjaxGateway : AjaxGatewayBase
{
    public CandidateWorkHistoryAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<WorkHistoryDetailTable> GetCandidateWorkHistoryList(string CompanyName, string JobTitle, DateTime startDate, DateTime endDate, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<WorkHistoryDetailTable> lis = da.WorkHistoryDetail.Search(WebLib.LoggedInUser.CandidateID, CompanyName, JobTitle, startDate, endDate, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public WorkHistoryMinimalizedEntity NewWorkHistory()
    {
        WorkHistoryRow dr = new WorkHistoryTable().NewWorkHistoryRow();
        WorkHistoryMinimalizedEntity ett = new WorkHistoryMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public WorkHistoryMinimalizedEntity GetWorkHistory(Guid id)
    {
        DA da = new DA();
        WorkHistoryRow dr = da.WorkHistory.GetByWorkHistory_ID(id);
        if (dr == null) return null;
        else
        {
            WorkHistoryMinimalizedEntity ett = new WorkHistoryMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveWorkHistory(WorkHistoryMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyCompanyName(ett.WorkHistory_CompanyName));
        AddError(errs, VerifyJobTitle(ett.WorkHistory_JobTitle));
        AddError(errs, VerifyDateRange(ett.WorkHistory_StartDate, ett.WorkHistory_ResignDate));
        ActionLog log = WebLib.CreateLog("Save Work History.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            WorkHistoryRow dr;
            if (ett.WorkHistory_ID == Guid.Empty)
            {
                dr = new WorkHistoryTable().NewWorkHistoryRow();
                ett.WorkHistory_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.WorkHistory_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.WorkHistory_ID = Guid.NewGuid();
                WorkHistoryDetailRow ds = da.WorkHistoryDetail.GetBy(WebLib.LoggedInUser.CandidateID);
                ett.Application_ID = ds.Application_ID;
            }
            else
            {
                dr = da.WorkHistory.GetByWorkHistory_ID(ett.WorkHistory_ID);
                ett.WorkHistory_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.WorkHistory_UpdatedDate = DateTime.Now;
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
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
    [AjaxMethod]
    public ErrorCodes VerifyCompanyName(string CompanyName)
    {
        if (String.IsNullOrEmpty(CompanyName)) return ErrorCodes.WorkHistory_CompanyNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyJobTitle(string JobTitle)
    {
        if (String.IsNullOrEmpty(JobTitle)) return ErrorCodes.WorkHistory_JobTitleRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyDateRange(DateTime StartDate, DateTime EndDate)
    {
        DateTime dt = DateTime.Parse("1900-01-01 00:00:00.000"); //if EndDate is not entered
        if (StartDate > EndDate && EndDate > dt) return ErrorCodes.WorkHistory_InvalidDateRange;
        if (StartDate == DateTime.MinValue) return ErrorCodes.WorkHistory_EmptyStartDate;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteWorkHistory(Guid id)
    {
        DA da = new DA();
        WorkHistoryRow dr = da.WorkHistory.GetByWorkHistory_ID(id);
        ActionLog log = WebLib.CreateLog("Delete Work History.");
        if (dr != null)
        {
            dr.WorkHistory_IsDeleted = true;
            da.WorkHistory.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}