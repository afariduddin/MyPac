using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;

public partial class CandidateChangeProfile : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateChangeProfileAjaxGateway));
        AjaxLib.RegisterController("CandidateChangeProfile", ClientID);
    }
}
public class CandidateChangeProfileAjaxGateway : AjaxGatewayBase
{
    public CandidateChangeProfileAjaxGateway()
    {
    }

    [AjaxMethod]
    public CandidateDialogData GetCandidate()
    {
        CandidateDialogData data = new CandidateDialogData();
        DA da = new DA();
        // UserAccountDetailRow row = da.UserAccountDetail.Get(WebLib.LoggedInUser.UserAccountID);
        CandidateRow row = da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);
        if (row != null)
        {
            data.Entity = new CandidateMinimalizedEntity(row);
            data.Course = GetCourseList();
            data.SelectedCourse = GetSelectedCourseList(row.Candidate_ID);
            data.Sector = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Sector);
            data.Position = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Position);
            data.Country = GetCountryList();
            data.Nationality = GetNationalityList();
        }
        return data;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetCountryList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CountryTable dtCountry = da.Country.GetAll();
        foreach (CountryRow r in dtCountry.Rows)
        {
            lis.Add(r.Country_ID.ToString(), r.Country_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetNationalityList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CountryTable dtCountry = da.Country.GetAll();
        foreach (CountryRow r in dtCountry.Rows)
        {
            lis.Add(r.Country_Name, r.Country_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveCandidate(CandidateDialogData data)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Candidate.");
        if (errs.Count == 0)
        {
            //UserAccountDetailMinimalizedEntity ett = new UserAccountDetailMinimalizedEntity();
            DA da = new DA();

            #region Education Level
            CandidateRow row = da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);

            if (row == null)
            {
                row = new CandidateTable().NewCandidateRow();
                data.Entity.Candidate_CreatedBy = WebLib.LoggedInUser.UserName;
                data.Entity.Candidate_CreatedDate = DateTime.Now;
                data.Entity.Candidate_ID = Guid.NewGuid();
            }

            data.Entity.Candidate_UpdatedDate = DateTime.Now;
            data.Entity.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;

            data.Entity.CopyTo(row);
            da.Candidate.Update(row,log);


            da.CandidatePreferredCourse.DeleteByCandidate_ID(row.Candidate_ID,log);
            foreach (string q in data.SelectedCourse)
            {
                if (q != "")
                {
                    CandidatePreferredCourseRow row2 = new CandidatePreferredCourseTable().NewCandidatePreferredCourseRow();
                    row2.Candidate_ID = row.Candidate_ID;
                    row2.Course_ID = Guid.Parse(q.Replace("\"", ""));
                    da.CandidatePreferredCourse.Update(row2,log);
                }


            }

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

    [AjaxMethod]
    public Dictionary<string, string> GetUserGroup()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<UserGroupRow> list = da.UserGroup.GetAll();
        foreach (UserGroupRow r in list)
        {
            lis.Add(r.UserGroup_ID.ToString(), r.UserGroup_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetCourseList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CourseTable dtCourse = da.Course.GetAll();
        foreach (CourseRow r in dtCourse.Rows)
        {
            lis.Add(r.Course_ID.ToString(), r.Course_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public List<string> GetSelectedCourseList(Guid CandidateID)
    {
        DA da = new DA();
        CandidatePreferredCourseTable dtCandidatePreferredCourse = da.CandidatePreferredCourse.GetByCandidate_ID(CandidateID);
        List<string> list = new List<string>();
        foreach (CandidatePreferredCourseRow r in dtCandidatePreferredCourse.Rows)
        {
            list.Add(r.Course_ID.ToString());
        }

        return list;
    }
    [AjaxMethod]
    public Dictionary<string, string> GetGlobalSetting(int SettingType)
    {
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get(SettingType);
        Dictionary<string, string> li = new Dictionary<string, string>();
        if (row != null)
        {
            string RawValue = row.GlobalSetting_Value;

            foreach (string SplitValue in RawValue.Split(new char[] { ';' }))
            {
                li.Add(SplitValue.Trim(), SplitValue.Trim());
            }
        }

        return li;
    }
}
public class CandidateDialogData
{
    public CandidateMinimalizedEntity Entity;
    public Dictionary<string, string> Course;
    public List<string> SelectedCourse;
    public Dictionary<string, string> Position;
    public Dictionary<string, string> Sector;
    public Dictionary<string, string> Country;
    public Dictionary<string, string> Nationality;
    //public Dictionary<string, string> UserGroup;
}