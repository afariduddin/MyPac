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

public partial class CandidateVoluntaryWork : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateVoluntaryWorkAjaxGateway));
        AjaxLib.RegisterController("CandidateVoluntaryWork", ClientID);
    }
}
public class CandidateVoluntaryWorkAjaxGateway : AjaxGatewayBase
{
    public CandidateVoluntaryWorkAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<VoluntaryHourDetailTable> GetCandidateVoluntaryWorkList(DateTime startDate, DateTime endDate, string title, int startHour, int endHour, int VoluntaryHourStatusType, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<VoluntaryHourDetailTable> lis = da.VoluntaryHourDetail.Search2(WebLib.LoggedInUser.CandidateID, startDate, endDate, title, startHour, endHour, VoluntaryHourStatusType, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public VoluntaryHourMinimalizedEntity NewVoluntaryWork()
    {
        VoluntaryHourRow dr = new VoluntaryHourTable().NewVoluntaryHourRow();
        VoluntaryHourMinimalizedEntity ett = new VoluntaryHourMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public VoluntaryHourMinimalizedEntity GetVoluntaryWork(Guid id)
    {
        DA da = new DA();
        VoluntaryHourRow dr = da.VoluntaryHour.GetByVoluntaryHour_ID(id);
        if (dr == null) return null;
        else
        {
            VoluntaryHourMinimalizedEntity ett = new VoluntaryHourMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveVoluntaryWork(VoluntaryHourMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyTitle(ett.VoluntaryHour_Title));
        AddError(errs, VerifyWorkHour(ett.VoluntaryHour_Duration));
        ActionLog log = WebLib.CreateLog("Save Voluntary Work.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            VoluntaryHourRow dr;
            ApplicationRow drApplication = da.Application.GetBy(WebLib.LoggedInUser.CandidateID, EngineVariable.ApplicationOverallStatusType.Completed);

            if (drApplication == null)
            {
                errs.Add(ErrorCodes.GEN_RecordNotFound);
            }
            else
            {
                if (ett.VoluntaryHour_ID == Guid.Empty)
                {
                    dr = new VoluntaryHourTable().NewVoluntaryHourRow();
                    ett.VoluntaryHour_CreatedBy = WebLib.LoggedInUser.UserName;
                    ett.VoluntaryHour_UpdatedBy = WebLib.LoggedInUser.UserName;
                    ett.VoluntaryHour_ID = Guid.NewGuid();
                    ett.Application_ID = drApplication.Application_ID;
                    ett.VoluntaryHour_Status = (short)EngineVariable.VoluntaryHourStatusType.Pending;
                }
                else
                {
                    dr = da.VoluntaryHour.GetByVoluntaryHour_ID(ett.VoluntaryHour_ID);
                    ett.VoluntaryHour_UpdatedBy = WebLib.LoggedInUser.UserName;
                    ett.VoluntaryHour_UpdatedDate = DateTime.Now;
                }

                if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
                else
                {
                    ett.CopyTo(dr);
                    da.VoluntaryHour.Update(dr,log);
                }
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
    public ErrorCodes VerifyTitle(string title)
    {
        if (String.IsNullOrEmpty(title)) return ErrorCodes.VoluntaryHour_TitleRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyWorkHour(long workHours)
    {
        if (workHours <= 0) return ErrorCodes.VoluntaryHour_WorkHourRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteVoluntaryWork(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Voluntary Work.");
        VoluntaryHourRow dr = da.VoluntaryHour.GetByVoluntaryHour_ID(id);
        if (dr != null)
        {
            dr.VoluntaryHour_IsDeleted = true;
            da.VoluntaryHour.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}