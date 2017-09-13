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


public partial class Sponsor : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(SponsorAjaxGateway));
        AjaxLib.RegisterController("Sponsor", ClientID);

    }
}
public class SponsorAjaxGateway : AjaxGatewayBase
{
    public SponsorAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<SponsorTable> GetSponsorList(string code, string label, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<SponsorTable> lis = da.Sponsor.Search(code, label, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public SponsorMinimalizedEntity NewSponsor()
    {
        //UserAccountRow dr = new UserAccountTable().NewUserAccountRow();
        //UserAccountMinimalizedEntity ett = new UserAccountMinimalizedEntity(dr);
        //return ett;

        SponsorMinimalizedEntity ret = new SponsorMinimalizedEntity();

        SponsorRow dr = new SponsorTable().NewSponsorRow();
        ret = new SponsorMinimalizedEntity(dr);
      //  ret.States = new Dictionary<string, string>(); // GetStates(ret.Entity.Country);

        return ret;
    }
    [AjaxMethod]
    public SponsorMinimalizedEntity GetSponsor(Guid id)
    {
        DA da = new DA();
        SponsorRow dr = da.Sponsor.GetBySponsor_ID(id);
        if (dr == null) return null;
        else
        {
            SponsorMinimalizedEntity ret = new SponsorMinimalizedEntity();
            ret = new SponsorMinimalizedEntity(dr);
            return ret;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveSponsor(SponsorMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyCode(ett.Sponsor_Code, ett.Sponsor_ID));
        AddError(errs, VerifyLabel(ett.Sponsor_Label));

        ActionLog log = WebLib.CreateLog((ett.Sponsor_ID == Guid.Empty ? "Create" : "Modify") + " Sponsor.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            SponsorRow dr;
            if (ett.Sponsor_ID == Guid.Empty)
            {
                dr = new SponsorTable().NewSponsorRow();
                ett.Sponsor_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Sponsor_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Sponsor_ID = Guid.NewGuid();
                dr.Sponsor_Created = DateTime.Now;
                dr.Sponsor_Updated = DateTime.Now;

            }
            else
            {
                dr = da.Sponsor.GetBySponsor_ID(ett.Sponsor_ID);
                ett.Sponsor_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Sponsor_Updated = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.Sponsor.Update(dr, log);
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
    public ErrorCodes VerifyCode(string Code, Guid ID)
    {
        if (String.IsNullOrEmpty(Code)) return ErrorCodes.Sponsor_Code;

        DA da = new DA();
        SponsorRow row = null;
        row = da.Sponsor.Get(Code);
        if (row != null)
        {
            if (ID == null)
            {
                return ErrorCodes.Sponsor_CodeDuplicate;
            }
            else
            {
                if (ID != row.Sponsor_ID)
                {
                    return ErrorCodes.Sponsor_CodeDuplicate;
                }
            }
        }
        return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyLabel(string Label)
    {
        if (Label == "") return ErrorCodes.Sponsor_Label;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes DeleteSponsor(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Sponsor.");
        SponsorRow dr = da.Sponsor.GetBySponsor_ID(id);
        if (dr != null)
        {
            dr.Sponsor_IsDeleted = true;
            da.Sponsor.Update(dr, log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public List<Teq.ValuePair> GetAllSponsor()
    {
        DA da = new DA();
        List<Teq.ValuePair> vps = new List<Teq.ValuePair>();
        Teq.ValuePair vpD = new Teq.ValuePair("Not Assigned", Guid.Empty);
        vps.Add(vpD);

        SponsorTable tbl = da.Sponsor.Get();
        foreach (SponsorRow r in tbl.Rows)
        {
            Teq.ValuePair vp = new Teq.ValuePair(r.Sponsor_Code, r.Sponsor_ID);
            vps.Add(vp);
        }

        return vps;

    }
}