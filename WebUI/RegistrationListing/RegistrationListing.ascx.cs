using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using Teq.Ajax;
using Teq.Data;
using OfficeOpenXml;
using System.IO;
using System.Web;
using EngineCommon;

public partial class RegistrationListing : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RegistrationListingAjaxGateway));
        AjaxLib.RegisterController("RegistrationListing", ClientID);
    }
}

public class RegistrationListingAjaxGateway : AjaxGatewayBase
{
    public RegistrationListingAjaxGateway()
    {
    }
    //for excel export
    [AjaxMethod] 
    public PagedDataList<RptCandidateRegistrationMasterListTable> GetResult(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState,
    string SearchCourseID, int SearchCurrentlyEmployed, DateTime RegisterDateFrom, DateTime RegisterDateTo, bool isPaging, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        Guid SelectedCourse = Guid.Empty;
        if (SearchCourseID != "")
            SelectedCourse = Guid.Parse(SearchCourseID);

        int Employed;
        if ((int)EngineVariable.YesNoType.Yes == SearchCurrentlyEmployed)
            Employed = 1;
        else if ((int)EngineVariable.YesNoType.No == SearchCurrentlyEmployed)
            Employed = 0;
        else
            Employed = -1;

        PagedDataList<RptCandidateRegistrationMasterListTable> lis = da.Reports.SearchCandidateRegistrationMasterList(SearchFullName, SearchGender, SearchEmail, SearchICNumber, SearchState, SelectedCourse, Employed, RegisterDateFrom, RegisterDateTo, isPaging, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptCandidateRegistrationMasterList"] = lis;

        return lis;
    }
    [AjaxMethod]
    public PagedDataList<CandidateTable> GetCandidateListing(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState, string SearchCourseID, int SearchCurrentlyEmployed, DateTime? RegisterDateFrom, DateTime? RegisterDateTo, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        Guid SelectedCourse = Guid.Empty;
        if (SearchCourseID != "")
            SelectedCourse = Guid.Parse(SearchCourseID);

        PagedDataList<CandidateTable> lis = da.Candidate.Search(SearchFullName, SearchGender, SearchEmail, SearchICNumber, SearchState, SelectedCourse, SearchCurrentlyEmployed, RegisterDateFrom, RegisterDateTo, BuildSqlOrders(col, asc), pg);

        foreach (CandidateRow dr in  lis.DataTable.Rows)
        {
            dr.Candidate_Password = "";
        }

        return lis;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetCourse()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        CourseTable tbl = da.Course.GetAll();
        foreach (CourseRow r in tbl.Rows)
        {
            lis.Add(r.Course_ID.ToString(), r.Course_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public CandidateDialogData GetCandidate(Guid id)
    {
        DA da = new DA();
        CandidateRow dr = da.Candidate.GetByCandidate_ID(id);
        if (dr == null) return null;
        else
        {
            CandidateDialogData ret = new CandidateDialogData();

            ret.Entity = new CandidateMinimalizedEntity(dr);
            ret.Course = GetCourseList();
            ret.SelectedCourse = GetSelectedCourseList(dr.Candidate_ID);
            ret.Country = GetCountryList();
            ret.Sector = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Sector);
            ret.Position = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Position);
            return ret;
        }
    }


    [AjaxMethod]
    public ErrorCodes VerifyFullname(string Fullname)
    {
        if (String.IsNullOrEmpty(Fullname)) return ErrorCodes.Application_FullNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyEthnicity(string Ethnicity)
    {
        if (String.IsNullOrEmpty(Ethnicity)) return ErrorCodes.Application_EthnicityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyIdentification(string Identification)
    {
        if (String.IsNullOrEmpty(Identification)) return ErrorCodes.Application_ICNumberRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyAddress(string Address1)
    {
        if (String.IsNullOrEmpty(Address1)) return ErrorCodes.Application_AddressRequired;
        else return ErrorCodes.GEN_NoError;
    }


    [AjaxMethod]
    public ErrorCodes VerifyPostcode(string Postcode)
    {
        if (String.IsNullOrEmpty(Postcode)) return ErrorCodes.Application_PostcodeRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyState(string State)
    {
        if (String.IsNullOrEmpty(State)) return ErrorCodes.Application_StateRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyCity(string City)
    {
        if (String.IsNullOrEmpty(City)) return ErrorCodes.Application_CityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMobile(string Mobile)
    {
        if (String.IsNullOrEmpty(Mobile)) return ErrorCodes.Application_MobileRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyContact(string Contact)
    {
        if (String.IsNullOrEmpty(Contact)) return ErrorCodes.Application_ContactRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyEmail(string Email)
    {
        if (String.IsNullOrEmpty(Email)) return ErrorCodes.Application_EmailRequired;
        else if (!Teq.Lib.IsEmail(Email)) return ErrorCodes.Application_EmailInvalid;
        else return ErrorCodes.GEN_NoError;
    }


    [AjaxMethod]
    public ErrorCodes[] SaveCandidate(CandidateDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();

        AddError(errs, VerifyFullname(ett.Entity.Candidate_FullName));

        AddError(errs, VerifyIdentification(ett.Entity.Candidate_ICNumber));
        AddError(errs, VerifyEthnicity(ett.Entity.Candidate_OtherEthnicity));
        AddError(errs, VerifyAddress(ett.Entity.Candidate_Address1));
        AddError(errs, VerifyPostcode(ett.Entity.Candidate_Postcode));
        AddError(errs, VerifyCity(ett.Entity.Candidate_City));
        AddError(errs, VerifyState(ett.Entity.Candidate_State));
        AddError(errs, VerifyContact(ett.Entity.Candidate_PhoneNumber));
        AddError(errs, VerifyMobile(ett.Entity.Candidate_MobilePhoneNumber));
        AddError(errs, VerifyEmail(ett.Entity.Candidate_Email));

        ActionLog log = WebLib.CreateLog((ett.Entity.Candidate_ID == Guid.Empty ? "Create" : "Modify") + " Candidate.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            CandidateRow dr;
            if (ett.Entity.Candidate_ID == Guid.Empty)
            {
                dr = new CandidateTable().NewCandidateRow();
                ett.Entity.Candidate_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Candidate_ID = Guid.NewGuid();
                dr.Candidate_CreatedDate = DateTime.Now;
            }
            else
            {
                dr = da.Candidate.GetByCandidate_ID(ett.Entity.Candidate_ID);
                ett.Entity.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Candidate_UpdatedDate = DateTime.Now;
            }

            da.CandidatePreferredCourse.DeleteByCandidate(ett.Entity.Candidate_ID);
            CandidatePreferredCourseTable dt = new CandidatePreferredCourseTable();

            List<string> SelectedCourses = ett.SelectedCourse;
            foreach (string SelectedCourse in SelectedCourses)
            {
                CandidatePreferredCourseRow row = dt.NewCandidatePreferredCourseRow();
                row.Candidate_ID = ett.Entity.Candidate_ID;
                row.Course_ID = Guid.Parse(SelectedCourse);
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.Entity.CopyTo(dr);
                da.Candidate.Update(dr,log);
                da.CandidatePreferredCourse.Update(dt,log);
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
    public ErrorCodes DeleteCandidate(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Candidate.");
        TSPRow dr = da.TSP.GetByTSP_ID(id);
        if (dr != null)
        {
            dr.TSP_IsDeleted = true;
            da.TSP.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
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

    [AjaxMethod]
    public ImportData NewImport()
    {
        ImportData data = new ImportData();
        return data;
    }

    [AjaxMethod]
    public ErrorCodes[] Import(ImportData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //excel file
        string tempFileName = AjaxLib.FileUploadTempPath + ett.UploadFile.TemporaryName;
        //todo process the tempFileName (excel)
        FileInfo f = new FileInfo(tempFileName);
        if (f.Exists)
        {
            DA da = new DA();
            CandidateTable dt = new CandidateTable();
            EmailNotificationTable dtEmail = new EmailNotificationTable();

            ExcelPackage p = new ExcelPackage(f);
            ExcelWorksheet w = p.Workbook.Worksheets[1];

            CountryRow drCountry = da.Country.Get("Malaysia");
            Guid CandidateCountry = Guid.Empty;
            String CandidateNationality = "";

            if (drCountry != null)
                CandidateCountry = drCountry.Country_ID;

            bool EOF = false;
            int RowNumber = 2;
            while (!EOF)
            {
                string UserID = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                string FullName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string DOB = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);
                string Gender = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 4] as ExcelRange).Value);
                string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 5] as ExcelRange).Value);
                string Address1 = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 6] as ExcelRange).Value);
                string Address2 = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 7] as ExcelRange).Value);
                string Postcode = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 8] as ExcelRange).Value);
                string City = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 9] as ExcelRange).Value);
                string State = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 10] as ExcelRange).Value);
                string Country = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 11] as ExcelRange).Value);
                string PhonePrefix = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 12] as ExcelRange).Value);
                string Phone = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 13] as ExcelRange).Value);
                string MobilePrefix = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 14] as ExcelRange).Value);
                string Mobile = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 15] as ExcelRange).Value);
                string Email = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 16] as ExcelRange).Value);
                string Nationality = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 17] as ExcelRange).Value);
                string Bumiputra = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 18] as ExcelRange).Value);
                string Remark = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 19] as ExcelRange).Value);
                string CurrentlyEmployed = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 20] as ExcelRange).Value);
                string CurrentlyPersuingHighestEducation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 21] as ExcelRange).Value);
                string HighestEducation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 22] as ExcelRange).Value);
                string BankName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 23] as ExcelRange).Value);
                string BankAccountNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 24] as ExcelRange).Value);
                string FirstEmergencyContact = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 26] as ExcelRange).Value);
                string FirstEmergencyContactRelation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 26] as ExcelRange).Value);
                string FirstEmergencyContactNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 27] as ExcelRange).Value);
                string FirstEmergencyAlternateContactNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 28] as ExcelRange).Value);
                string SecondEmergencyContact = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 29] as ExcelRange).Value);
                string SecondEmergencyContactRelation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 30] as ExcelRange).Value);
                string SecondEmergencyContactNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 31] as ExcelRange).Value);
                string SecondEmergencyAlternateContactNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 32] as ExcelRange).Value);
                string FatherName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 33] as ExcelRange).Value);
                string FatherIdentification = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 34] as ExcelRange).Value);
                string FatherOccupation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 35] as ExcelRange).Value);
                string FatherEmployerName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 36] as ExcelRange).Value);
                string MotherName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 37] as ExcelRange).Value);
                string MotherIdentification = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 38] as ExcelRange).Value);
                string MotherOccupation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 39] as ExcelRange).Value);
                string MotherEmployerName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 40] as ExcelRange).Value);

                if (FullName == "" && DOB == "" && Gender == "" && IdentificationNumber == "" && MobilePrefix == "" && Mobile == "" && Email == "" && Nationality == "" && Bumiputra == "")
                {
                    EOF = true;
                }
                else
                {
                    bool RowHasError = false;
                    //Check Required Field
                    if (FullName == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Full Name. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (DOB == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Date of Birth. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (Gender == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Gender. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (IdentificationNumber == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (MobilePrefix == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Mobile Prefix. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (Mobile == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Mobile. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (Email == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Email. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (Nationality == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Nationality. IC - " + IdentificationNumber));
                        RowHasError = true;
                    } else {
                        CandidateNationality = da.Country.Get(Nationality).Country_Name;
                    }

                    if (Bumiputra == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Bumiputra. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    //Check Data Validity
                    if (Country == "")
                        Country = "Malaysia";

                    if (Country != "Malaysia")
                    {
                        CandidateCountry = Guid.Empty;
                        drCountry = da.Country.Get(Country);

                        if (drCountry != null)
                            CandidateCountry = drCountry.Country_ID;
                    }
                    if (CandidateCountry.CompareTo(Guid.Empty) == 0)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Country. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    DateTime? CandidateDOB = LibraryCommon.ConvertDate(DOB);

                    if (!Teq.Lib.IsEmail(Email))
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Email. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        if (UserID == "")
                            UserID = Email;
                    }
                    if (!CandidateDOB.HasValue)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Date of Birth. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    EngineVariable.GenderType CandidateGender = LibraryCommon.ConvertGender(Gender);
                    if (CandidateGender == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Gender. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    if (da.Candidate.GetByUserID(UserID) != null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Duplicate User ID. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    if (da.Candidate.GetByIdentificationNumber(IdentificationNumber) != null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Duplicate Identification Number. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    //EngineVariable.NationalityType CandidateNationality = LibraryCommon.ConvertNationality(Nationality);
                    //if (CandidateNationality == null)
                    //{
                    //    errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Nationality. IC - " + IdentificationNumber));
                    //    RowHasError = true;
                    //}

                    bool? CandidateIsBumiputra = LibraryCommon.ConvertBoolean(Bumiputra);
                    if (!CandidateIsBumiputra.HasValue)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Bumiputra Status. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    bool? CandidateIsEmployed = LibraryCommon.ConvertBoolean(CurrentlyEmployed);
                    if (!CandidateIsEmployed.HasValue)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Is Employed Status. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    bool? CandidateIsPersuing = LibraryCommon.ConvertBoolean(CurrentlyPersuingHighestEducation);
                    if (!CandidateIsPersuing.HasValue)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Is Persuing Highest Education Status. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    if (!RowHasError)
                    {
                        CandidateRow dr = new CandidateTable().NewCandidateRow();

                        dr.Candidate_ID = Guid.NewGuid();
                        dr.Candidate_UserID = UserID;
                        dr.Candidate_Password = Teq.Lib.Random.Next(10000, 100000).ToString();
                        dr.Candidate_FullName = FullName;
                        dr.Candidate_DOB = CandidateDOB.Value;
                        dr.Candidate_Gender = (short)CandidateGender;
                        dr.Candidate_ICNumber = IdentificationNumber;
                        dr.Candidate_CurrentlyEmployed = CandidateIsEmployed.Value;
                        dr.Candidate_EducationLevel1 = "";
                        dr.Candidate_FieldOfStudy1 = "";
                        dr.Candidate_EducationLevel2 = "";
                        dr.Candidate_FieldOfStudy2 = "";
                        dr.Candidate_EducationLevel3 = "";
                        dr.Candidate_FieldOfStudy3 = "";
                        dr.Candidate_EducationLevel4 = "";
                        dr.Candidate_FieldOfStudy4 = "";
                        dr.Candidate_EducationLevel5 = "";
                        dr.Candidate_FieldOfStudy5 = "";
                        dr.Candidate_CurrentlyPursuingHighestLevel = CandidateIsPersuing.Value;
                        dr.Candidate_HighestEducation = HighestEducation;
                        dr.Candidate_Address1 = Address1;
                        dr.Candidate_Address2 = Address2;
                        dr.Candidate_City = City;
                        dr.Country_ID = CandidateCountry;
                        dr.Candidate_PhonePrefix = PhonePrefix;
                        dr.Candidate_PhoneNumber = Phone;
                        dr.Candidate_MobilePhonePrefix = MobilePrefix;
                        dr.Candidate_MobilePhoneNumber = Mobile;
                        dr.Candidate_Email = Email;
                        dr.Candidate_BankName = BankName;
                        dr.Candidate_BankAccountNumber = BankAccountNumber;
                        dr.Candidate_EmergencyContactName1 = FirstEmergencyContact;
                        dr.Candidate_EmergencyContactNumber1 = FirstEmergencyContactNumber;
                        dr.Candidate_EmergencyContactNumber1Alternative = FirstEmergencyAlternateContactNumber;
                        dr.Candidate_EmergencyContactRelationship1 = FirstEmergencyContactRelation;
                        dr.Candidate_EmergencyContactName2 = SecondEmergencyContact;
                        dr.Candidate_EmergencyContactNumber2 = SecondEmergencyContactNumber;
                        dr.Candidate_EmergencyContactNumber2Alternative = SecondEmergencyAlternateContactNumber;
                        dr.Candidate_EmergencyContactRelationship2 = SecondEmergencyContactRelation;
                        dr.Candidate_FatherGuardianName = FatherName;
                        dr.Candidate_FatherGuardianIC = FatherIdentification;
                        dr.Candidate_FatherGuardianTypeOfOccupation = FatherOccupation;
                        dr.Candidate_FatherGuardianEmployerName = FatherEmployerName;
                        dr.Candidate_MotherGuardianName = MotherName;
                        dr.Candidate_MotherGuardianIC = MotherIdentification;
                        dr.Candidate_MotherGuardianTypeOfOccupation = MotherOccupation;
                        dr.Candidate_MotherGuardianEmployerName = MotherEmployerName;
                        dr.Candidate_IsDeleted = false;
                        dr.Candidate_CreatedDate = DateTime.Now;
                        dr.Candidate_CreatedBy = WebLib.LoggedInUser.UserName;
                        dr.Candidate_UpdatedDate = DateTime.Now;
                        dr.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;
                        dr.Candidate_Postcode = Postcode;
                        dr.Candidate_State = State;
                        dr.Candidate_Nationality = CandidateNationality;
                        dr.Candidate_IsBumiputra = CandidateIsBumiputra.Value;
                        dr.Candidate_Remark = Remark;
                        dr.Candidate_MIA = "";
                        dr.Candidate_MIAImage = "";
                        dr.Candidate_MIAFile = "";

                        EmailNotificationRow drEmail = new EmailNotificationTable().NewEmailNotificationRow();
                        drEmail.EmailNotification_CreatedDate = DateTime.Now;
                        drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_RegistrationImport(dr);
                        drEmail.EmailNotification_ID = Guid.NewGuid();
                        drEmail.EmailNotification_Recipient = Email;
                        drEmail.EmailNotification_RetryCount = 0;
                        drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                        drEmail.EmailNotification_StatusMessage = "";
                        drEmail.EmailNotification_Subject = "MyPAC: New Account Registration";
                        drEmail.Application_ID = Guid.Empty;
                        drEmail.EmailNotification_IsRead = false;

                        da.Candidate.Update(dr, null);
                        da.EmailNotification.Update(drEmail, null);
                    }
                }
                RowNumber += 1;
            }

        }
        ActionLog log = WebLib.CreateLog("Import Candidate.");
        log.Save();
        return errs.ToArray();
    }
}

public class CandidateDialogData
{
    public CandidateMinimalizedEntity Entity;
    public Dictionary<string, string> Course;
    public Dictionary<string, string> Country;
    public Dictionary<string, string> Position;
    public Dictionary<string, string> Sector;
    public List<string> SelectedCourse;
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}