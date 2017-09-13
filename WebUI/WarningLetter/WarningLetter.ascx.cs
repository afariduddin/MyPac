using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;

public partial class WarningLetter : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(WarningLetterAjaxGateway));
        AjaxLib.RegisterController("WarningLetter", ClientID);
    }
}
public class WarningLetterAjaxGateway : AjaxGatewayBase
{
    public WarningLetterAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<WarningLetterTable> GetWarningLetterList(string WarningLetterName, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<WarningLetterTable> lis = da.WarningLetter.Search(WarningLetterName, BuildSqlOrders(col, asc), pg);

        return lis;
    }
    [AjaxMethod]
    public WarningLetterMinimalizedEntity NewWarningLetter()
    {
        WarningLetterRow dr = new WarningLetterTable().NewWarningLetterRow();
        WarningLetterMinimalizedEntity ett = new WarningLetterMinimalizedEntity(dr);

        return ett;
    }
    [AjaxMethod]
    public WarningLetterMinimalizedEntity GetWarningLetter(Guid id)
    {
        DA da = new DA();
        WarningLetterRow dr = da.WarningLetter.GetByWarningLetter_ID(id);
        if (dr == null) return null;
        else
        {
            WarningLetterMinimalizedEntity ett = new WarningLetterMinimalizedEntity(dr);
            return ett;
        }
    }
    [AjaxMethod]
    public ErrorCodes[] SaveWarningLetter(WarningLetterMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyWarningLetterName(ett.WarningLetter_Name));
        AddError(errs, VerifyWarningLetterSubject(ett.WarningLetter_Subject));
        ActionLog log = WebLib.CreateLog((ett.WarningLetter_ID == Guid.Empty ? "Create" : "Modify") + " Warning Letter.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            WarningLetterRow dr;
            if (ett.WarningLetter_ID == Guid.Empty)
            {
                dr = new WarningLetterTable().NewWarningLetterRow();
                ett.WarningLetter_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.WarningLetter_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.WarningLetter_ID = Guid.NewGuid();
                ett.WarningLetter_CreatedDate = DateTime.Now;
            }
            else
            {
                dr = da.WarningLetter.GetByWarningLetter_ID(ett.WarningLetter_ID);
                ett.WarningLetter_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.WarningLetter_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.WarningLetter.Update(dr,log);
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
    public ErrorCodes VerifyWarningLetterName(string name)
    {
        if (String.IsNullOrEmpty(name)) return ErrorCodes.WarningLetter_NameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyWarningLetterSubject(string subject)
    {
        if (String.IsNullOrEmpty(subject)) return ErrorCodes.WarningLetter_SubjectRequired;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes DeleteWarningLetter(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Warning Letter.");
        WarningLetterRow dr = da.WarningLetter.GetByWarningLetter_ID(id);
        if (dr != null)
        {
            dr.WarningLetter_Deleted = true;
            da.WarningLetter.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}