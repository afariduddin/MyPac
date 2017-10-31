using AjaxPro;
using EngineCommon;
using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq.Ajax;
using Teq;
using System.Configuration;

public partial class CandidateRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxLib.IncludeCoreScripts();
        AjaxLib.IncludeCustomScripts("~/Components/ErrorCodes.Js.aspx");
        Utility.RegisterTypeForAjax(typeof(CandidateRegistrationManagementAjaxGateway));
    }
}
public class CandidateRegistrationManagementAjaxGateway : AjaxGatewayBase
{
    private DA da = new DA();
    public CandidateRegistrationManagementAjaxGateway()
    {
    }
    //[AjaxMethod]
    //public PagedDataList<GlobalSettingTable> GetGlobalSettingList(string name, string userid, int[] col, bool[] asc, int pg)
    //{
    //    DA da = new DA();

    //    PagedDataList<GlobalSettingTable> lis = da.GlobalSetting.Search(name, userid, BuildSqlOrders(col, asc), pg);
    //    return lis;
    //}

    //[AjaxMethod]
    //public GlobalSettingDialogData NewGlobalSetting()
    //{

    //    return new GlobalSettingDialogData();
    //}


    //[AjaxMethod]
    //public GlobalSettingDialogData GetGlobalSetting()
    //{
    //    //DA da = new DA();
    //    //GlobalSettingRow dr = da.GlobalSetting.GetByGlobalSetting_ID(id);
    //    //if (dr == null) return null;
    //    //else
    //    //{
    //    //    //GlobalSettingMinimalizedEntity ett = new GlobalSettingMinimalizedEntity(dr);
    //    //    //return ett;

    //    //    GlobalSettingDialogData ret = new GlobalSettingDialogData();


    //    //    ret.Entity = new GlobalSettingMinimalizedEntity(dr);


    //    //    return ret;
    //    //}
    //    GlobalSettingDialogData data = new GlobalSettingDialogData();
    //    DA da = new DA();
    //    GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
    //    if (row != null)
    //    {
    //        data.EducationLevel = row.GlobalSetting_Value;
    //    }
    //    row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.FieldOfStudy);
    //    if (row != null)
    //    {
    //        data.FieldOfStudy = row.GlobalSetting_Value;
    //    }

    //    row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PreferredLocation);
    //    if (row != null)
    //    {
    //        data.PreferredLocation = row.GlobalSetting_Value;
    //    }
    //    row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.ReasonsForDeferment);
    //    if (row != null)
    //    {
    //        data.ReasonsForDeferment = row.GlobalSetting_Value;
    //    }

    //    return data;
    //}

    [AjaxMethod]
    public ErrorCodes[] SaveCandidateRegistration(CandidateRegistrationData data)
    {
        ActionLog log = WebLib.CreateLog("Candidate Registration.");
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
     
        AddError(errs, VerifyUserID(data.UserID));
        AddError(errs, VerifyBumiPutra(data.BumiPutra));
        AddError(errs, VerifyPassword(data.Password, data.ConfirmPassword));
        AddError(errs, VerifyRequiredField(data.FullName, ErrorCodes.CandidateRegistration_FullNameRequired));
        AddError(errs, VerifyRequiredField(data.DOB, ErrorCodes.CandidateRegistration_DOBRequired));
        AddError(errs, VerifyBumiPutra(data.BumiPutra));
        AddError(errs, VerifyRequiredField(data.Ethnicity, ErrorCodes.CandidateRegistration_EthnicityRequired));
        AddError(errs, VerifyRequiredField(data.Gender, ErrorCodes.CandidateRegistration_GenderRequired));
        AddError(errs, VerifyRequiredField(data.Nationality, ErrorCodes.CandidateRegistration_NationalityRequired));
        //AddError(errs, VerifyRequiredField(data.IC, ErrorCodes.CandidateRegistration_ICRequired));
        AddError(errs, VerifyIC(data.IC));
        AddError(errs, VerifyRequiredField(data.CurrentlyEmployed, ErrorCodes.CandidateRegistration_CurrentlyEmployedRequired));
        if(data.CurrentlyEmployed == "0")
        {
            AddError(errs, VerifyRequiredField(data.Sector, ErrorCodes.CandidateRegistration_JobSectorRequired));
            AddError(errs, VerifyRequiredField(data.Position, ErrorCodes.CandidateRegistration_JobPositionRequired));
        }
        AddError(errs, VerifyPreferredQualification(data.PreferredQualification));

        AddError(errs, VerifyDropDownField(data.EducationLevel1, "", ErrorCodes.CandidateRegistration_EducationHistoryRequired));
        if (VerifyDropDownField(data.EducationLevel1, "", ErrorCodes.CandidateRegistration_EducationHistoryRequired) != ErrorCodes.GEN_NoError)
        {
            AddError(errs, VerifyDropDownField(data.FieldOfStudy1, "", ErrorCodes.CandidateRegistration_EducationHistoryRequired));
        }
        AddError(errs, VerifyRequiredField(data.HighestEducation, ErrorCodes.CandidateRegistration_HighestEducationRequired));
        AddError(errs, VerifyRequiredField(data.Address1, ErrorCodes.CandidateRegistration_AddressRequired));
        if (VerifyDropDownField(data.Country, Guid.Empty.ToString(), ErrorCodes.CandidateRegistration_CountryRequired) != ErrorCodes.GEN_NoError)
        {
            AddError(errs, VerifyDropDownField(data.Country, Guid.Empty.ToString(), ErrorCodes.CandidateRegistration_CountryRequired));
        }
        AddError(errs, VerifyRequiredField(data.MobilePhoneNumber, ErrorCodes.CandidateRegistration_MobilePhoneNumberRequired));
        AddError(errs, VerifyEmail(data.Email));
        AddError(errs, (!data.PDPA1) ? ErrorCodes.CandidateRegistration_PDPARequired : ErrorCodes.GEN_NoError);
        if (data.PDPA1)
        {
            AddError(errs, (!data.PDPA2) ? ErrorCodes.CandidateRegistration_PDPARequired : ErrorCodes.GEN_NoError);
        }
        string EncodedResponse = data.ReCaptchaResponse;
        bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse, ConfigurationManager.AppSettings["ReCaptchaPrivateKey"]) == "True" ? true : false);
        if (!IsCaptchaValid && data.IsCaptchaVerified.ToLower() != "true")
        {
            if(!IsCaptchaValid)
            {
                AddError(errs, ErrorCodes.CandidateRegistration_InvalidCaptcha);
            }
           
        }
        if (errs.Count == 0)
        {
            CandidateRow dr = new CandidateTable().NewCandidateRow();
            dr.Candidate_ID = Guid.NewGuid();
            dr.Candidate_Address1 = data.Address1;
            dr.Candidate_Address2 = data.Address2;
            dr.Candidate_City = data.City;
            //todo country (done)
            //dr.Candidate_Country = data.Country;
            dr.Candidate_StudyCountry = data.UniversityCountry;
            dr.Country_ID = Guid.Parse(data.Country);
            dr.Candidate_CurrentlyEmployed = (data.CurrentlyEmployed == "0") ? true : false;
            dr.Candidate_CurrentlyPursuingHighestLevel = data.CurrentlyPursuing;
            dr.Candidate_IsBumiputra = data.BumiPutra.Equals("0");
            dr.Candidate_DOB = data.DOB.Value;
            dr.Candidate_EducationLevel1 = data.EducationLevel1;
            dr.Candidate_EducationLevel2 = data.EducationLevel2;
            dr.Candidate_EducationLevel3 = data.EducationLevel3;
            dr.Candidate_EducationLevel4 = data.EducationLevel4;
            dr.Candidate_EducationLevel5 = data.EducationLevel5;
            dr.Candidate_Email = data.Email;
            dr.Candidate_FieldOfStudy1 = data.FieldOfStudy1;
            dr.Candidate_FieldOfStudy2 = data.FieldOfStudy2;
            dr.Candidate_FieldOfStudy3 = data.FieldOfStudy3;
            dr.Candidate_FieldOfStudy4 = data.FieldOfStudy4;
            dr.Candidate_FieldOfStudy5 = data.FieldOfStudy5;
            dr.Candidate_FullName = data.FullName;
            dr.Candidate_Gender = ((data.Gender == "1") ? (short)EngineVariable.GenderType.Male : (short)EngineVariable.GenderType.Female);
            dr.Candidate_HighestEducation = data.HighestEducation;
            dr.Candidate_ICNumber = data.IC;
            dr.Candidate_MobilePhoneNumber = data.MobilePhoneNumber;
            dr.Candidate_MobilePhonePrefix = data.MobilePhoneNumberPrefix;
            dr.Candidate_Nationality = data.Nationality;
            dr.Candidate_Password = data.Password;
            dr.Candidate_PhoneNumber = data.PhoneNumber;
            dr.Candidate_PhonePrefix = data.PhoneNumberPrefix;
            dr.Candidate_Postcode = data.Postcode;
            dr.Candidate_State = data.State;
            dr.Candidate_UserID = data.UserID;
            dr.Candidate_OtherEthnicity = data.Ethnicity;
            if(data.CurrentlyEmployed == "0")
            {
                dr.Candidate_Position = data.Position;
                dr.Candidate_Sector = data.Sector;
            }else
            {
                dr.Candidate_Position = "";
                dr.Candidate_Sector = "";
            }
         

            da.Candidate.Update(dr,log);

            string qualifications = data.PreferredQualification.Replace("[", "").Replace("]", "");
            string[] qua = qualifications.Split(",".ToCharArray());
            foreach (string q in qua)
            {
                if (q != "")
                {
                    CandidatePreferredCourseRow row = new CandidatePreferredCourseTable().NewCandidatePreferredCourseRow();
                    row.Candidate_ID = dr.Candidate_ID;
                    row.Course_ID = Guid.Parse(q.Replace("\"", ""));
                    da.CandidatePreferredCourse.Update(row,log);
                }
            }

            EmailNotificationTable dtEmail = new EmailNotificationTable();
            EmailNotificationRow drEmail = dtEmail.NewEmailNotificationRow();
            drEmail.EmailNotification_CreatedDate = DateTime.Now;
            drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_Registration(dr);
            drEmail.EmailNotification_ID = Guid.NewGuid();
            drEmail.EmailNotification_Recipient = dr.Candidate_Email;
            drEmail.EmailNotification_RetryCount = 0;
            drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
            drEmail.EmailNotification_StatusMessage = "";
            drEmail.EmailNotification_Subject = "MyPAC: Account Registration";
            drEmail.Application_ID = Guid.Empty;
            drEmail.EmailNotification_IsRead = false;
            da.EmailNotification.Update(dtEmail,log);
        }
        log.Save();
        return errs.ToArray();
    }
    [AjaxMethod]
    public ErrorCodes VerifyBumiPutra(string BumiPutra)
    {
        
        if (String.IsNullOrEmpty(BumiPutra)) return ErrorCodes.CandidateRegistration_BumiputraRequired;
        if (!BumiPutra.Equals("0")) return ErrorCodes.CandidateRegistration_Bumiputra;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyEmail(string Email)
    {

        if (String.IsNullOrEmpty(Email)) return ErrorCodes.CandidateRegistration_EmailRequired;
        if (!Teq.Lib.IsEmail(Email)) return ErrorCodes.CandidateRegistration_ValidEmailRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyUserID(string value)
    {
        if (String.IsNullOrEmpty(value)) return ErrorCodes.UserAccount_UserID;
        if(da.Candidate.GetByUserID(value) != null)
        {
            return ErrorCodes.UserAccount_DuplicateUserID;
        }
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyIC(string value)
    {
        if (String.IsNullOrEmpty(value)) return ErrorCodes.CandidateRegistration_ICRequired;
        if (da.Candidate.GetByIdentificationNumber(value) != null)
        {
            return ErrorCodes.CandidateRegistration_DuplicateIC;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyPassword(string Password, string ConfirmPassword)
    {
        if (String.IsNullOrEmpty(Password)) return ErrorCodes.CandidateRegistration_PasswordRequired;
        if (String.IsNullOrEmpty(ConfirmPassword)) return ErrorCodes.CandidateRegistration_ConfirmPasswordRequired;
       
        if (Password != ConfirmPassword)
        {
            return ErrorCodes.CandidateRegistration_PasswordNotMatched;
        }
       
        
        return ErrorCodes.GEN_NoError;
    }


    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(string value,ErrorCodes Error)
    {
        if (String.IsNullOrEmpty(value)) return Error;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(DateTime? value, ErrorCodes Error)
    {
        if(!value.HasValue)
        {
            return Error;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyDropDownField(string value,string defaultValue, ErrorCodes Error)
    {
        if (String.IsNullOrEmpty(value)) return Error;
        else if (value == defaultValue) return Error;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyPreferredQualification(string value)
    {
        if (String.IsNullOrEmpty(value)) return ErrorCodes.CandidateRegistration_PreferredQualificationRequired;
       string returnvalue = value.Replace("[", "").Replace("]", "");
       if (returnvalue.Trim() == "") return ErrorCodes.CandidateRegistration_PreferredQualificationRequired;

        return ErrorCodes.GEN_NoError;
    }


    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }

    [AjaxMethod]
    public Dictionary<string, string> GetSectorList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Sector);
        if (row != null)
        {
            string[] values = row.GlobalSetting_Value.Split(";".ToCharArray());
            foreach (var r in values)
            {
                lis.Add(r, r);
            }
        }


        return lis;
    }
    [AjaxMethod]
    public Dictionary<string, string> GetPositionList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.Position);
        if (row != null)
        {
            string[] values = row.GlobalSetting_Value.Split(";".ToCharArray());
            foreach (var r in values)
            {
                lis.Add(r, r);
            }
        }


        return lis;
    }
    [AjaxMethod]
    public Dictionary<string, string> GetEducationLevelList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<UserGroupRow> list = da.UserGroup.GetAll();
     GlobalSettingRow row =   da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
           if(row!= null)
           {
              string[] values = row.GlobalSetting_Value.Split(";".ToCharArray());
              foreach (var  r in values)
              {
                  lis.Add(r, r);
              }
           }
      
 
        return lis;
    }
       [AjaxMethod]
       public Dictionary<string, string> GetFieldOfStudyList()
       {
           Dictionary<string, string> lis = new Dictionary<string, string>();
           DA da = new DA();
           List<UserGroupRow> list = da.UserGroup.GetAll();
           GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.FieldOfStudy);
           if (row != null)
           {
               string[] values = row.GlobalSetting_Value.Split(";".ToCharArray());
               foreach (var r in values)
               {
                   lis.Add(r, r);
               }
           }


           return lis;
       }
       [AjaxMethod]
       public Dictionary<string, string> GetCourseList()
       {
           Dictionary<string, string> lis = new Dictionary<string, string>();
           DA da = new DA();
        

       CourseTable tbl =    da.Course.GetAll();
           foreach(CourseRow r in tbl.Rows)
           {
               if (r.Course_ApplicableForApply) lis.Add(r.Course_ID.ToString(), r.Course_Name);
              
           }
  


           return lis;
       }

    [AjaxMethod]
    public Dictionary<string, string> GetCountryList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CountryTable tbl = da.Country.GetAll();
        foreach(CountryRow r in tbl.Rows)
        {
            lis.Add(r.Country_ID.ToString(), r.Country_Name);
        }
        //List<UserGroupRow> list = da.UserGroup.GetAll();
        //GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
        //if (row != null)
        //{
        //    string[] values = row.GlobalSetting_Value.Split(";".ToCharArray());
        //    foreach (var r in values)
        //    {
        //        lis.Add(r, r);
        //    }
        //}


        return lis;
    }
    //[AjaxMethod]
    //public ErrorCodes DeleteGlobalSetting(Guid id)
    //{
    //    DA da = new DA();
    //    //da.Member.DeleteByCardNumber(cardNo);
    //    GlobalSettingRow dr = da.GlobalSetting.GetByGlobalSetting_ID(id);
    //    if (dr != null)
    //    {
    //        dr.GlobalSetting_IsDeleted = true;
    //        da.GlobalSetting.Update(dr);
    //    }
    //    return ErrorCodes.GEN_NoError;
    //}


}

public class CandidateRegistrationData
{
    public string UserID = "";
    public string Password = "";
    public string ConfirmPassword = "";
    public string FullName = "";
    public DateTime? DOB = null;
    public string BumiPutra = "";
    public string Gender = "";
    public string Nationality = "";
    public string IC = "";
    public string CurrentlyEmployed = "";
    public string EducationLevel1 = "";
    public string FieldOfStudy1 = "";

    public string EducationLevel2 = "";
    public string FieldOfStudy2 = "";

    public string EducationLevel3 = "";
    public string FieldOfStudy3 = "";

    public string EducationLevel4 = "";
    public string FieldOfStudy4 = "";

    public string EducationLevel5 = "";
    public string FieldOfStudy5 = "";

    public bool CurrentlyPursuing =false;
    public string HighestEducation = "";
    public string Address1 = "";
    public string Address2 = "";
    public string City = "";
    public string State = "";
    public string Postcode = "";
    public string Country = "";
    public string PhoneNumberPrefix = "";
    public string PhoneNumber = "";
    public string MobilePhoneNumberPrefix = "";
    public string MobilePhoneNumber = "";
    public string Email = "";
    public bool PDPA1 = false;
    public bool PDPA2 = false;
    public string PreferredQualification = "";
    public string Ethnicity = "";
    public string Position = "";
    public string Sector = "";
    public string UniversityCountry = "";
    public string ReCaptchaResponse = "";
    public string IsCaptchaVerified = "";
}