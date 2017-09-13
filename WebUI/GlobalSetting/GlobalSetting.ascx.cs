using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;

public partial class GlobalSetting : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(GlobalSettingManagementAjaxGateway));
        AjaxLib.RegisterController("GlobalSetting", ClientID);
    }
}
public class GlobalSettingManagementAjaxGateway : AjaxGatewayBase
{
    public GlobalSettingManagementAjaxGateway()
    {
    }

    [AjaxMethod]
    public GlobalSettingDialogData NewGlobalSetting()
    {
       
        return new GlobalSettingDialogData();
    }
    
    [AjaxMethod]
    public List<string> GetGlobalSetting_ByType(int SettingType)
    {
        //DA da = new DA();
        //GlobalSettingRow dr = da.GlobalSetting.GetByGlobalSetting_ID(id);
        //if (dr == null) return null;
        //else
        //{
        //    //GlobalSettingMinimalizedEntity ett = new GlobalSettingMinimalizedEntity(dr);
        //    //return ett;

        //    GlobalSettingDialogData ret = new GlobalSettingDialogData();


        //    ret.Entity = new GlobalSettingMinimalizedEntity(dr);


        //    return ret;
        //}
        GlobalSettingDialogData data = new GlobalSettingDialogData();
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get(SettingType);
        List<string> li = new List<string>();
        if (row != null)
        {
            string RawValue = row.GlobalSetting_Value;

            foreach (string SplitValue in RawValue.Split(new char[] { ';' }))
            {
                li.Add(SplitValue.Trim());
            }
        }

        return li;
    }

    [AjaxMethod]
    public GlobalSettingDialogData GetGlobalSetting()
    {
        //DA da = new DA();
        //GlobalSettingRow dr = da.GlobalSetting.GetByGlobalSetting_ID(id);
        //if (dr == null) return null;
        //else
        //{
        //    //GlobalSettingMinimalizedEntity ett = new GlobalSettingMinimalizedEntity(dr);
        //    //return ett;

        //    GlobalSettingDialogData ret = new GlobalSettingDialogData();


        //    ret.Entity = new GlobalSettingMinimalizedEntity(dr);


        //    return ret;
        //}
        GlobalSettingDialogData data = new GlobalSettingDialogData();
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
        if (row != null)
        {
            data.EducationLevel = row.GlobalSetting_Value;
        }
        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.FieldOfStudy);
        if (row != null)
        {
            data.FieldOfStudy = row.GlobalSetting_Value;
        }

        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PreferredLocation);
        if (row != null)
        {
            data.PreferredLocation = row.GlobalSetting_Value;
        }
        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.ReasonsForDeferment);
        if (row != null)
        {
            data.ReasonsForDeferment = row.GlobalSetting_Value;
        }
        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Sector);
        if (row != null)
        {
            data.Sector = row.GlobalSetting_Value;
        }
        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Position);
        if (row != null)
        {
            data.Position = row.GlobalSetting_Value;
        }
        row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PQLevelStart);
        if (row != null)
        {
            data.PQLevelStart = row.GlobalSetting_Value;
        }
        return data;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveGlobalSetting(GlobalSettingDialogData data)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
        ActionLog log = WebLib.CreateLog("Save Global Setting.");
        if (errs.Count == 0)
        {
            //DA da = new DA();
            //GlobalSettingRow dr;
            //if (ett.GlobalSetting_ID == Guid.Empty)
            //{
            //    dr = new GlobalSettingTable().NewGlobalSettingRow();
            //    ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
            //    ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
            //    ett.GlobalSetting_ID = Guid.NewGuid();
            //    dr.GlobalSetting_CreatedDate = DateTime.Now;

            //}
            //else
            //{
            //    dr = da.GlobalSetting.GetByGlobalSetting_ID(ett.GlobalSetting_ID);
            //    ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
            //    ett.GlobalSetting_UpdatedDate = DateTime.Now;
            //    //dr.ModifiedBy = "someone";
            //    //dr.ModifiedDate = DateTime.Now;
            //}
            //if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            //else
            //{
            //    ett.CopyTo(dr);
            //    da.GlobalSetting.Update(dr);
            //}
            GlobalSettingMinimalizedEntity ett = new GlobalSettingMinimalizedEntity();
            DA da = new DA();

            #region Education Level
            GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.EducationLevel;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.EducationLevel;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.EducationLevel;
                ett.GlobalSetting_Value = data.EducationLevel;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;

               
            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion


            #region FieldOfStudy
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.FieldOfStudy);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.FieldOfStudy;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.FieldOfStudy;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.FieldOfStudy;
                ett.GlobalSetting_Value = data.FieldOfStudy;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion




            #region FieldOfStudy
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PreferredLocation);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.PreferredLocation;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.PreferredLocation;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.PreferredLocation;
                ett.GlobalSetting_Value = data.PreferredLocation;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion




            #region reasons for deferment
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.ReasonsForDeferment);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.ReasonsForDeferment;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.ReasonsForDeferment;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.ReasonsForDeferment;
                ett.GlobalSetting_Value = data.ReasonsForDeferment;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion

            #region sector
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Sector);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.Sector;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.Sector;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.Sector;
                ett.GlobalSetting_Value = data.Sector;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion

            #region position
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Position);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.Position;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.Position;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.Position;
                ett.GlobalSetting_Value = data.Position;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion

            #region pq level start
            row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PQLevelStart);
            if (row != null)
            {
                ett.GlobalSetting_UpdatedDate = DateTime.Now;
                ett.GlobalSetting_CreatedDate = row.GlobalSetting_CreatedDate;
                ett.GlobalSetting_Value = data.PQLevelStart;
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.PQLevelStart;
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = row.GlobalSetting_ID;

            }
            else
            {
                row = new GlobalSettingTable().NewGlobalSettingRow();
                ett.GlobalSetting_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.GlobalSetting_ID = Guid.NewGuid();
                ett.GlobalSetting_Type = (short)EngineVariable.GlobalSettingType.PQLevelStart;
                ett.GlobalSetting_Value = data.PQLevelStart;
                ett.GlobalSetting_CreatedDate = DateTime.Now;
                ett.GlobalSetting_UpdatedDate = DateTime.Now;


            }
            ett.CopyTo(row);
            da.GlobalSetting.Update(row,log);

            #endregion
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

public class GlobalSettingDialogData
{
    //public GlobalSettingMinimalizedEntity Entity;
    //public Dictionary<string, string> UserGroup;
    public string EducationLevel = "";
    public string FieldOfStudy = "";
    public string PreferredLocation = "";
    public string ReasonsForDeferment = "";
    public string Sector = "";
    public string Position = "";
    public string PQLevelStart = "";
    public GlobalSettingDialogData()
    {
       
    }
}