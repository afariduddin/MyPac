using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class VoluntaryHourApproval : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(VoluntaryHourApprovalAjaxGateway));
        AjaxLib.RegisterController("VoluntaryHourApproval", ClientID);
    }
}


public class VoluntaryHourApprovalAjaxGateway : AjaxGatewayBase
{
    public VoluntaryHourApprovalAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<VoluntaryHourDetailTable> GetVoluntaryHourListing(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState, int SearchStatus, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<VoluntaryHourDetailTable> lis = da.VoluntaryHourDetail.Search(SearchFullName, SearchGender, SearchEmail, SearchICNumber, SearchState, SearchStatus, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public VoluntaryHourDetailMinimalizedEntity NewVoluntaryHour()
    {
        VoluntaryHourDetailMinimalizedEntity ent = new VoluntaryHourDetailMinimalizedEntity();
        return ent;
    }

    [AjaxMethod]
    public VoluntaryHourDetailMinimalizedEntity GetVoluntaryHour(Guid id)
    {
        DA da = new DA();
        VoluntaryHourDetailRow dr = da.VoluntaryHourDetail.Get(id);
        if (dr == null) return null;
        else
        {
            VoluntaryHourDetailMinimalizedEntity ent = new VoluntaryHourDetailMinimalizedEntity(dr);
            return ent;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveVoluntaryHour(VoluntaryHourDetailMinimalizedEntity ent)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Voluntary Hour.");
        if (errs.Count == 0)
        {
            DA da = new DA();

            VoluntaryHourRow dr = da.VoluntaryHour.GetByVoluntaryHour_ID(ent.VoluntaryHour_ID);
            if (dr == null)
            {
                dr = new VoluntaryHourTable().NewVoluntaryHourRow();
                ent.VoluntaryHour_CreatedBy = WebLib.LoggedInUser.UserName;
                ent.Candidate_ID = Guid.NewGuid();
                ent.VoluntaryHour_CreatedDate = DateTime.Now;
            }

            ent.VoluntaryHour_UpdatedBy = WebLib.LoggedInUser.UserName;
            ent.VoluntaryHour_UpdatedDate = DateTime.Now;

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ent.CopyTo(dr);
                da.VoluntaryHour.Update(dr,log);
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