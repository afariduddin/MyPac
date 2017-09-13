using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class TSPManagement : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(TSPManagementAjaxGateway));
        AjaxLib.RegisterController("TSPManagement", ClientID);
    }
}

public class TSPManagementAjaxGateway : AjaxGatewayBase
{
    public TSPManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<TSPTable> GetTSPList(string name, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<TSPTable> lis = da.TSP.Search(name, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public TSPMinimalizedEntity NewTSP()
    {
        TSPRow dr = new TSPTable().NewTSPRow();
        TSPMinimalizedEntity ett = new TSPMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public TSPMinimalizedEntity GetTSP(Guid id)
    {
        DA da = new DA();
        TSPRow dr = da.TSP.GetByTSP_ID(id);
        if (dr == null) return null;
        else
        {
            TSPMinimalizedEntity ett = new TSPMinimalizedEntity(dr);
            return ett;
        }
    }

    [AjaxMethod]
    public ErrorCodes VerifyName(string name)
    {
        if (String.IsNullOrEmpty(name)) return ErrorCodes.TSP_Name;
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }
    [AjaxMethod]
    public ErrorCodes VerifyType(short? CourseType)
    {
        if (CourseType.HasValue == false || CourseType.Value == -1)
        {
            return ErrorCodes.TSP_Type;
        }
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }

    [AjaxMethod]
    public ErrorCodes[] SaveTSP(TSPMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyName(ett.TSP_CampusName));
        AddError(errs, VerifyType(ett.TSP_CourseType));
        //AddError(errs, VerifyModDate(ett.ModifiedDate));

        ett.SelectedMonth = ett.CheckedMonths;
        ActionLog log = WebLib.CreateLog("Save TSP.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            TSPRow dr;
            if (ett.TSP_ID == Guid.Empty)
            {
                dr = new TSPTable().NewTSPRow();
                ett.TSP_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.TSP_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.TSP_ID = Guid.NewGuid();
                dr.TSP_CreatedDate = DateTime.Now;

            }
            else
            {
                dr = da.TSP.GetByTSP_ID(ett.TSP_ID);
                ett.TSP_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.TSP_UpdatedDate = DateTime.Now;
                //dr.ModifiedBy = "someone";
                //dr.ModifiedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.TSP.Update(dr,log);
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
    public ErrorCodes DeleteTSP(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete TSP.");
        //da.Member.DeleteByCardNumber(cardNo);
        TSPRow dr = da.TSP.GetByTSP_ID(id);
        CourseTable dtCourse = da.Course.Get_ActiveByTSP(id);
        if (dtCourse.Rows.Count > 0)
        {
            return ErrorCodes.TSP_InUse;
        }

        if (dr != null)
        {
            dr.TSP_IsDeleted = true;
            da.TSP.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public Dictionary<string, string> getMonth()
    {
        Dictionary<string, string> d = new Dictionary<string, string>();
        d.Add("1", "January");
        d.Add("2", "February");
        d.Add("3", "March");
        d.Add("4", "April");
        d.Add("5", "May");
        d.Add("6", "June");
        d.Add("7", "July");
        d.Add("8", "August");
        d.Add("9", "September");
        d.Add("10", "October");
        d.Add("11", "November");
        d.Add("12", "December");

        return d;
    }

    [AjaxMethod]
    public List<Teq.ValuePair> GetAllTSP()
    {
        DA da = new DA();
        List<Teq.ValuePair> vps = new List<Teq.ValuePair>();

        List<TSPRow> rows = da.TSP.GetAll();
        foreach(TSPRow r in rows)
        {
            Teq.ValuePair vp = new Teq.ValuePair(r.TSP_CampusName, r.TSP_ID);
            vps.Add(vp);
        }

        return vps;

    }
}