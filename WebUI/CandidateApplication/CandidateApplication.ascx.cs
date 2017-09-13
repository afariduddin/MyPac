using AjaxPro;
using EngineData;
using EngineVariable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq;
using Teq.Ajax;
public partial class CandidateApplication : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxLib.RegisterController("CandidateApplication", ClientID);
        Utility.RegisterTypeForAjax(typeof(CandidateApplicationManagementAjaxGateway));
    }
}

public class CandidateApplicationManagementAjaxGateway : AjaxGatewayBase
{
    private DA da = new DA();
    public CandidateApplicationManagementAjaxGateway()
    {
    }
    [AjaxMethod]
    public ApplicationMinimalizedEntity GetApplication()
    {
        if (WebLib.LoggedInUser != null)
        {
            ApplicationTable tbl = da.Application.GetBy(WebLib.LoggedInUser.CandidateID);

            if (tbl.Rows.Count > 0)
            {
                ApplicationRow drApplication = tbl.GetApplicationRow(0);
                ApplicationMinimalizedEntity ent = new ApplicationMinimalizedEntity(drApplication);
                return ent;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
        //WebLib.LoggedInUser.CandidateID
    }
    [AjaxMethod]
    public CandidateMinimalizedEntity GetCandidate()
    {
        if (WebLib.LoggedInUser != null)
        {

            CandidateRow row = da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);

            if (row!=null)
            {
                CandidateMinimalizedEntity ett = new CandidateMinimalizedEntity(row);
                return ett;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
        //WebLib.LoggedInUser.CandidateID
    }
    [AjaxMethod]
    public ErrorCodes[] SaveApplication(ApplicationData data)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
        AddError(errs, VerifyRequiredField(data.CourseID, ErrorCodes.CandidateApplication_CourseRequired));
        AddError(errs, VerifyRequiredField(data.FullName, ErrorCodes.CandidateApplication_FullNameRequired));
        AddError(errs, VerifyRequiredField(data.DOB, ErrorCodes.CandidateApplication_DOBRequired));
    
        AddError(errs, VerifyRequiredField(data.Gender, ErrorCodes.CandidateApplication_GenderRequired));
        AddError(errs, VerifyRequiredField(data.CurrentlyEmployed, ErrorCodes.CandidateApplication_CurrentlyEmployedRequired));
        AddError(errs, VerifyRequiredField(data.IC, ErrorCodes.CandidateApplication_ICRequired));


        AddError(errs, VerifyRequiredField(data.Address1, ErrorCodes.CandidateApplication_AddressRequired));
        if (VerifyDropDownField(data.Country, Guid.Empty.ToString(), ErrorCodes.CandidateApplication_CountryRequired) != ErrorCodes.GEN_NoError)
        {
            AddError(errs, VerifyDropDownField(data.Country, Guid.Empty.ToString(), ErrorCodes.CandidateApplication_CountryRequired));
        }
        AddError(errs, VerifyRequiredField(data.MobilePhoneNumber, ErrorCodes.CandidateApplication_MobilePhoneNumberRequired));
        AddError(errs, VerifyRequiredField(data.Email, ErrorCodes.CandidateApplication_EmailRequired));

        AddError(errs, VerifyRequiredField(data.FatherName, ErrorCodes.CandidateApplication_FatherNameRequired));
        AddError(errs, VerifyRequiredField(data.FatherIC, ErrorCodes.CandidateApplication_FatherICRequired));
        AddError(errs, VerifyRequiredField(data.MotherName, ErrorCodes.CandidateApplication_MotherNameRequired));
        AddError(errs, VerifyRequiredField(data.MotherIC, ErrorCodes.CandidateApplication_MotherICRequired));
        AddError(errs, VerifyRequiredField(data.CombinedHouseholdIncome, ErrorCodes.CandidateApplication_CombinedHouseholdIncomeRequired));
        AddError(errs, VerifyDecimal(data.CombinedHouseholdIncome, ErrorCodes.CandidateApplication_InvalidCombinedHouseholdIncome));
        AddError(errs, VerifyRequiredField(data.CurrentFieldOfStudy, ErrorCodes.CandidateApplication_CurrentFieldOfStudyRequired));
        AddError(errs, VerifyRequiredField(data.University, ErrorCodes.CandidateApplication_UniversityRequired));
        AddError(errs, VerifyRequiredField(data.CGPA, ErrorCodes.CandidateApplication_CGPARequire));
        AddError(errs, VerifyDecimal(data.CostCoveredByScholarship, ErrorCodes.CandidateApplication_InvalidCostCoveredByScholarship));
        //AddError(errs, VerifyRequiredField(data.WithPQ, ErrorCodes.CandidateRegistration_EmailRequired));

        AddError(errs, VerifyAttachment(data.FileIC, data.CurrentFileIC,ErrorCodes.CandidateApplication_ICFileRequired));
        AddError(errs, VerifyAttachment(data.FileBirthCertificate, data.CurrentFileBirthCertificate, ErrorCodes.CandidateApplication_BirthCertificateRequired));
        AddError(errs, VerifyAttachment(data.FileAcademicTranscript, data.CurrentFileAcademicTranscript, ErrorCodes.CandidateApplication_AcademicTranscriptRequired));
        AddError(errs, VerifyAttachment(data.FilePassport, data.CurrentFilePassport, ErrorCodes.CandidateApplication_PassportRequired));

        AddError(errs, (!data.Agree) ? ErrorCodes.CandidateApplication_AgreeRequired : ErrorCodes.GEN_NoError);
        AddError(errs, (!data.PDPA1) ? ErrorCodes.CandidateApplication_PDPARequired : ErrorCodes.GEN_NoError);
        AddError(errs, VerifyInteger(data.SelectedYear, ErrorCodes.CandidateApplication_IntakeYearRequired));
        AddError(errs, VerifyInteger(data.SelectedMonth, ErrorCodes.CandidateApplication_IntakeMonthRequired));
       CandidateRow candidateRow =  da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);
       if(candidateRow != null && data.Submitted)
        {
            AddError(errs, VerifyCandidateData(candidateRow));
        }


        ActionLog log = WebLib.CreateLog("Save Application.");
        if (data.PDPA1)
        {
            AddError(errs, (!data.PDPA2) ? ErrorCodes.CandidateApplication_PDPARequired : ErrorCodes.GEN_NoError);
        }

        if (errs.Count == 0)
        {
            ApplicationRow dr = null;
            if (data.ApplicationID == Guid.Empty)
            {
               dr = new ApplicationTable().NewApplicationRow();
                dr.Application_CreatedBy = WebLib.LoggedInUser.UserName;
                dr.Application_Date = DateTime.Now;
                dr.Application_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.Application.GetByApplication_ID(data.ApplicationID);
            }
           // dr.Application_AcademicTranscriptImage = "";
            dr.Application_Address1 = data.Address1;
            dr.Application_Address2 = data.Address2;
            //dr.Application_BirthCertificateImage = "";
            dr.Application_CGPA = data.CGPA;
            dr.Application_City = data.City;
            dr.Application_CombinedHouseholdIncome = decimal.Parse(data.CombinedHouseholdIncome);
            dr.Application_ConfirmAgreeTermsAndCondition = data.PDPA2;
            dr.Application_ConfirmReceiveMyPACNotice = data.PDPA1;
            dr.Application_DeclarationAgree = data.Agree;
            dr.Application_ContractType = (data.StudyPreferences == "") ? (short)0 : short.Parse(data.StudyPreferences);
            dr.Country_ID = Guid.Parse(data.Country);
            dr.Application_CurrentFieldOfStudy = data.CurrentFieldOfStudy;
            dr.Application_DOB = data.DOB.Value;
            dr.Application_Email = data.Email;
            dr.Application_FatherIdentification = data.FatherIC;
            dr.Application_FatherName = data.FatherName;
            dr.Application_FullName = data.FullName;
            dr.Application_Gender = short.Parse(data.Gender);
            //dr.Application_IdentificationImage = "";
            dr.Application_IdentificationNumber = data.IC;
            dr.Application_MobilePhoneNumber = data.MobilePhoneNumber;
            dr.Application_MobilePhonePrefix = data.MobilePhoneNumberPrefix;
            dr.Application_MotherIdentification = data.MotherIC;
            dr.Application_MotherName = data.MotherName;
            dr.Application_Nationality = short.Parse( NationalityType.Malaysian.Code.ToString());
            dr.Application_NextExamSession = (data.NextExam.HasValue)? data.NextExam.Value:EngineVariable.LibraryVariable.Empty_DateTime;
            //dr.Application_PassportSizeImage = "";
            dr.Application_PGRegistrationNumber = data.PQRegNo;
            dr.Application_PhoneNumber = data.PhoneNumber;
            dr.Application_PhonePrefix = data.PhoneNumberPrefix;
            dr.Application_Postcode = data.Postcode;
           // dr.Application_PQAcceptanceImage = "";
            dr.Application_PQDeadline = (data.PQDealine.HasValue) ? data.PQDealine.Value : EngineVariable.LibraryVariable.Empty_DateTime;
            //todo pq
            //dr.Application_PQLevelStart = (data.LevelStartPQ == null || data.LevelStartPQ=="") ? (short)0 : short.Parse( data.LevelStartPQ);
            dr.Application_PQLevelStart = data.LevelStartPQ;
            dr.Application_PQQualification = data.WithPQ;
            dr.Application_PQStartDate = (data.PQStartDate.HasValue) ? data.PQStartDate.Value : EngineVariable.LibraryVariable.Empty_DateTime;
            dr.Application_RegisteredNextExam = data.RegisteredNextExam;
            if(data.CostCoveredByScholarship == "")
            {
                data.CostCoveredByScholarship = "0";
            }
            dr.Application_ScholarshipCost = decimal.Parse(data.CostCoveredByScholarship);
            dr.Application_ScholarshipProvider = data.ScholarshipProvider;
            dr.Application_State = data.State;
            dr.Application_Status = (short)ApplicationStatus.Pending;
            dr.Application_Submitted = data.Submitted;
            if(data.Submitted)
            {
                dr.Application_SubmittedDate = DateTime.Now;
                dr.Application_OverallProgress = (short)ApplicationOverallProgressType.Application;
                dr.Application_OverallStatus = (short)ApplicationOverallStatusType.Active;

            }
            else
            {
                dr.Application_SubmittedDate = EngineVariable.LibraryVariable.Empty_DateTime;
            }
            dr.Application_University = data.University;
            dr.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
            dr.Application_UpdatedDate = DateTime.Now;
            dr.Candidate_ID = WebLib.LoggedInUser.CandidateID;
            dr.Course_ID = data.CourseID;
            dr.TSP_ID = Guid.Parse(data.TSP);

            dr.Application_IntakeMonth = int.Parse(data.SelectedMonth);
            dr.Application_IntakeYear = int.Parse(data.SelectedYear);

            dr.Application_CompanyPosition = data.Position;
            dr.Application_CompanySector = data.Sector;
            dr.Application_CompanyContact = data.CompanyContact;
            dr.Application_CompanyDepartment = data.Department;
            dr.Application_CompanyName = data.CompanyName;
            dr.Application_CompanyAddress = data.CompanyAddress;
            dr.Application_CurrentlyEmployed = (data.CurrentlyEmployed == "0") ? true : false;
            #region File Upload

            string folderPath = ConfigurationManager.AppSettings["UploadedAttachmentsFolder"];
            string defaultSavePath = folderPath + "\\" + dr.Application_ID;
            Directory.CreateDirectory(defaultSavePath);

            if (data.FileIC != null)
            {
                string ext = Path.GetExtension(data.FileIC.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FileIC.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Application_IdentificationImage = data.FileIC.OriginalName;
               dr.Application_IdentificationFile = filename;
                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FileIC.TemporaryName, savePath);
                }
                catch
                {

                }
               
            }

            if (data.FileBirthCertificate != null)
            {
                string ext = Path.GetExtension(data.FileBirthCertificate.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FileBirthCertificate.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Application_BirthCertificateImage = data.FileBirthCertificate.OriginalName;
                dr.Application_BirthCertificateFile = filename;

                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FileBirthCertificate.TemporaryName, savePath);
                }
                catch { }
               
            }

            if (data.FileAcademicTranscript != null)
            {
                string ext = Path.GetExtension(data.FileAcademicTranscript.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FileAcademicTranscript.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Application_AcademicTranscriptImage = data.FileAcademicTranscript.OriginalName;
                dr.Application_AcademicTranscriptFile = filename;
                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FileAcademicTranscript.TemporaryName, savePath);
                }
                catch { }
                
            }

            if (data.FilePassport != null)
            {
                string ext = Path.GetExtension(data.FilePassport.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FilePassport.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Application_PassportSizeImage = data.FilePassport.OriginalName;
                dr.Application_PassportSizeFile = filename;
                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FilePassport.TemporaryName, savePath);
                }
               catch
                { }
            }

            if (data.FilePQAcceptanceLetter != null)
            {
                string ext = Path.GetExtension(data.FilePQAcceptanceLetter.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FilePQAcceptanceLetter.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Application_PQAcceptanceImage = data.FilePQAcceptanceLetter.OriginalName;
                dr.Application_PQAcceptanceFile = filename;
                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FilePQAcceptanceLetter.TemporaryName, savePath);
                }
                catch { }
               
            }
            #endregion


            da.Application.Update(dr,log);

            string subjects = data.SelectedSubject.Replace("[", "").Replace("]", "");
            string[] sub = subjects.Split(",".ToCharArray());
            da.ApplicationCourseSubject.DeleteByApplication_ID(dr.Application_ID,log);
            foreach (string q in sub)
            {
                if(q != "")
                {
                    ApplicationCourseSubjectRow row = new ApplicationCourseSubjectTable().NewApplicationCourseSubjectRow();
                    row.ApplicationCourseSubject_ID = Guid.NewGuid();
                    row.Application_ID = dr.Application_ID;
                    row.CourseSubject_ID = Guid.Parse(q.Replace("\"", ""));
                    da.ApplicationCourseSubject.Update(row,log);

                }
            }
            log.Save();
        }

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
    public ErrorCodes VerifyUserID(string value)
    {
        if (String.IsNullOrEmpty(value)) return ErrorCodes.UserAccount_UserID;
        if (da.Candidate.GetByUserID(value) != null)
        {
            return ErrorCodes.UserAccount_DuplicateUserID;
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
    public ErrorCodes VerifyDecimal(string Input, ErrorCodes Error)
    {
        if (!String.IsNullOrEmpty(Input))
        {
            try
            {
                var test = decimal.Parse(Input);
                return ErrorCodes.GEN_NoError;
            }
            catch
            {
                return Error;
            }
        }
        else return ErrorCodes.GEN_NoError;

    }


    [AjaxMethod]
    public ErrorCodes VerifyInteger(string Input, ErrorCodes Error)
    {
        if (!String.IsNullOrEmpty(Input))
        {
            try
            {
                var test = int.Parse(Input);
                return ErrorCodes.GEN_NoError;
            }
            catch
            {
                return Error;
            }
        }
        else return ErrorCodes.GEN_NoError;

    }
    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(string value, ErrorCodes Error)
    {
        if (String.IsNullOrEmpty(value)) return Error;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(DateTime? value, ErrorCodes Error)
    {
        if (!value.HasValue)
        {
            return Error;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(Guid value, ErrorCodes Error)
    {
        if (value == Guid.Empty)
        {
            return Error;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyDropDownField(string value, string defaultValue, ErrorCodes Error)
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


    [AjaxMethod]
    public ErrorCodes VerifyCandidateData(CandidateRow value)
    {
        //if (String.IsNullOrEmpty(value)) return ErrorCodes.CandidateRegistration_PreferredQualificationRequired;
        //string returnvalue = value.Replace("[", "").Replace("]", "");
        //if (returnvalue.Trim() == "") return ErrorCodes.CandidateRegistration_PreferredQualificationRequired;

        if(String.IsNullOrEmpty(value.Candidate_FatherGuardianName) 
            || String.IsNullOrEmpty(value.Candidate_FatherGuardianIC)
            || String.IsNullOrEmpty(value.Candidate_FatherGuardianTypeOfOccupation)
            || String.IsNullOrEmpty(value.Candidate_FatherGuardianEmployerName)
            || String.IsNullOrEmpty(value.Candidate_FatherGuardianIC)
            || String.IsNullOrEmpty(value.Candidate_MotherGuardianName)
            || String.IsNullOrEmpty(value.Candidate_MotherGuardianIC)
            || String.IsNullOrEmpty(value.Candidate_MotherGuardianTypeOfOccupation)
            || String.IsNullOrEmpty(value.Candidate_MotherGuardianEmployerName)
            || String.IsNullOrEmpty(value.Candidate_MotherGuardianIC)
            ||String.IsNullOrEmpty(value.Candidate_BankName)
            || String.IsNullOrEmpty(value.Candidate_BankAccountNumber)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactName1)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactNumber1)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactRelationship1)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactName2)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactNumber2)
            || String.IsNullOrEmpty(value.Candidate_EmergencyContactRelationship2)
            )
        {
            return ErrorCodes.CandidateRegistration_AdditionalInfoRequired;
        }


        return ErrorCodes.GEN_NoError;
    }

    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }


    [AjaxMethod]
    public Dictionary<string, string> GetEducationLevelList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<UserGroupRow> list = da.UserGroup.GetAll();
        GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.EducationLevel);
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


        CourseTable tbl = da.Course.GetAll();
        foreach (CourseRow r in tbl.Rows)
        {
            if (r.Course_ApplicableForApply) lis.Add(r.Course_ID.ToString(), r.Course_Name);

        }



        return lis;


    }
    [AjaxMethod]
    public Dictionary<string, string> GetTSPList(Guid CourseID)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();


        //List<TSPRow> tbl = da.TSP.GetAll();
        
        //foreach (TSPRow r in tbl)
        //{
        //    lis.Add(r.TSP_ID.ToString(), r.TSP_CampusName);

        //}
        CourseTSPDetailTable tbl2 = da.CourseTSPDetail.GetBy(CourseID);
        foreach (CourseTSPDetailRow r in tbl2.Rows)
        {
            lis.Add(r.TSP_ID.ToString(), r.TSP_CampusName);
        }

        return lis;
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
    public Dictionary<string, string> GetYear()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();

        lis.Add(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString());
        lis.Add(DateTime.Now.AddYears(1).Year.ToString(), DateTime.Now.AddYears(1).Year.ToString());
        lis.Add(DateTime.Now.AddYears(2).Year.ToString(), DateTime.Now.AddYears(2).Year.ToString());

        return lis;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetMonth(Guid TSPID, int SelectedYear)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        TSPRow dr = da.TSP.GetByTSP_ID(TSPID);
        if (dr != null)
        {
            if (SelectedYear == DateTime.Now.Year)
            {
                int CurrentMonth = DateTime.Now.Month;
                if (dr.TSP_IntakeJan && CurrentMonth <= 1)
                    lis.Add("1", "January");
                if (dr.TSP_IntakeFeb && CurrentMonth <= 2)
                    lis.Add("2", "February");
                if (dr.TSP_IntakeMar && CurrentMonth <= 3)
                    lis.Add("3", "March");
                if (dr.TSP_IntakeApr && CurrentMonth <= 4)
                    lis.Add("4", "April");
                if (dr.TSP_IntakeMay && CurrentMonth <= 5)
                    lis.Add("5", "May");
                if (dr.TSP_IntakeJun && CurrentMonth <= 6)
                    lis.Add("6", "June");
                if (dr.TSP_IntakeJul && CurrentMonth <= 7)
                    lis.Add("7", "July");
                if (dr.TSP_IntakeAug && CurrentMonth <= 8)
                    lis.Add("8", "August");
                if (dr.TSP_IntakeSep && CurrentMonth <= 9)
                    lis.Add("9", "September");
                if (dr.TSP_IntakeOct && CurrentMonth <= 10)
                    lis.Add("10", "October");
                if (dr.TSP_IntakeNov && CurrentMonth <= 11)
                    lis.Add("11", "November");
                if (dr.TSP_IntakeDec && CurrentMonth <= 12)
                    lis.Add("12", "December");
            }
            else
            {
                if (dr.TSP_IntakeJan)
                    lis.Add("1", "January");
                if (dr.TSP_IntakeFeb)
                    lis.Add("2", "February");
                if (dr.TSP_IntakeMar)
                    lis.Add("3", "March");
                if (dr.TSP_IntakeApr)
                    lis.Add("4", "April");
                if (dr.TSP_IntakeMay)
                    lis.Add("5", "May");
                if (dr.TSP_IntakeJun)
                    lis.Add("6", "June");
                if (dr.TSP_IntakeJul)
                    lis.Add("7", "July");
                if (dr.TSP_IntakeAug)
                    lis.Add("8", "August");
                if (dr.TSP_IntakeSep)
                    lis.Add("9", "September");
                if (dr.TSP_IntakeOct)
                    lis.Add("10", "October");
                if (dr.TSP_IntakeNov)
                    lis.Add("11", "November");
                if (dr.TSP_IntakeDec)
                    lis.Add("12", "December");
            }
        }

        return lis;
    }
    
    [AjaxMethod]
    public Dictionary<string, string> GetSubjectList(Guid CourseID)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CourseSubjectTable dt = da.CourseSubject.GetAll(CourseID);
        foreach (CourseSubjectRow r in dt.Rows)
        {
            lis.Add(r.CourseSubject_ID.ToString(), r.CourseSubject_Code + " - " + r.CourseSubject_Name);
        }

        return lis;
    }
    [AjaxMethod]
    public List<string> GetSelectedSubjectList(Guid ApplicationID)
    {
        DA da = new DA();
        ApplicationCourseSubjectTable dt = da.ApplicationCourseSubject.GetByApplication_ID(ApplicationID);
        List<string> list = new List<string>();
        foreach (ApplicationCourseSubjectRow r in dt.Rows)
        {
            list.Add(r.CourseSubject_ID.ToString());
        }

        return list;
    }


    [AjaxMethod]
    public Dictionary<string, string> GetCountryList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CountryTable tbl = da.Country.GetAll();
        foreach (CountryRow r in tbl.Rows)
        {
            lis.Add(r.Country_ID.ToString(), r.Country_Name);
        }


        return lis;
    }


    [AjaxMethod]
    public Dictionary<string, string> GetPQLevelStartList()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        GlobalSettingRow row = da.GlobalSetting.Get((int)EngineVariable.GlobalSettingType.PQLevelStart);
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
    public ErrorCodes VerifyAttachment(UploadedFile attachment, string originalfilename,ErrorCodes code)
    {
        if (attachment == null && String.IsNullOrEmpty(originalfilename)) return code;
        else return ErrorCodes.GEN_NoError;
    }
}

public class ApplicationData
{
    public Guid CourseID = Guid.Empty;
    public Guid ApplicationID = Guid.Empty;
    public string FullName = "";
    public DateTime? DOB = null;
    public string Gender = "";
    public string IC = "";
    public string Address1 = "";
    public string Address2 = "";
    public string City = "";
    public string Postcode = "";
    public string State = "";
    public string Country = "";

    public string PhoneNumberPrefix = "";
    public string PhoneNumber = "";
    public string MobilePhoneNumberPrefix = "";
    public string MobilePhoneNumber = "";

    public string Email = "";
    public string FatherName = "";
    public string FatherIC = "";
    public string MotherName = "";
    public string MotherIC = "";
    public string CombinedHouseholdIncome = "";
    public string CurrentFieldOfStudy = "";
    public string University = "";
    public string CGPA = "";
    public bool WithPQ = false;
    public string PQRegNo = "";
    public DateTime? PQStartDate = null;
    public string LevelStartPQ = "";
    public DateTime? PQDealine = null;
    public bool RegisteredNextExam = false;

    public DateTime? NextExam = null;
    public string StudyPreferences = "";
    public string TSP = "";
    public string ScholarshipProvider = "";
    public string CostCoveredByScholarship = "";
    public bool Agree = false;
    public bool PDPA1 = false;
    public bool PDPA2 = false;
    public bool Submitted = false;
    public string SelectedSubject = "";

    public string SelectedMonth = "";
    public string SelectedYear = "";

    public UploadedFile FileIC;
    public string CurrentFileIC;

    public UploadedFile FileBirthCertificate;
    public string CurrentFileBirthCertificate;

    public UploadedFile FileAcademicTranscript;
    public string CurrentFileAcademicTranscript;

    public UploadedFile FilePassport;
    public string CurrentFilePassport;

    public UploadedFile FilePQAcceptanceLetter;
    public string CurrentFilePQAcceptanceLetter;
    public string Position = "";
    public string Sector = "";
    public string Department = "";
    public string CompanyName = "";
    public string CompanyContact = "";
    public string CompanyAddress = "";
    public string CurrentlyEmployed = "";
}