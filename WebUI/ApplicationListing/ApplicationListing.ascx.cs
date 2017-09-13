using AjaxPro;
using EngineData;
using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using Teq.Ajax;
using Teq.Data;
using Teq;
using EngineCommon;
using OfficeOpenXml;

public partial class ApplicationListing : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(ApplicationListingAjaxGateway));
        AjaxLib.RegisterController("ApplicationListing", ClientID);
    }
}
public class ApplicationListingAjaxGateway : AjaxGatewayBase
{
    public ApplicationListingAjaxGateway()
    {
    }
    ////for excel export
    [AjaxMethod]
    public PagedDataList<RptCandidateApplicationMasterListTable> GetResult(DateTime startDate, DateTime endDate, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, Guid Location, int ApplicationStatusType, string CGPA, Guid CourseID, string AgeFrom, string AgeTo, bool isPaging, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<RptCandidateApplicationMasterListTable> lis = da.Reports.SearchCandidateApplicationMasterList(startDate, endDate, FullName, Gender, Email, ICNumber, State, ContractType, Location, ApplicationStatusType, CGPA, CourseID, AgeFrom, AgeTo, isPaging, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptCandidateApplicationMasterList"] = lis;

        return lis;
    }
    [AjaxMethod]
    public PagedDataList<ApplicationDetailTable> GetApplicationListing(DateTime? startDate, DateTime? endDate, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, Guid Location, int ApplicationStatusType, string CGPA, Guid CourseID,string AgeFrom,string AgeTo, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<ApplicationDetailTable> lis = da.ApplicationDetail.Search(startDate, endDate, FullName, Gender, Email, ICNumber, State, ContractType, Location, ApplicationStatusType, CGPA, CourseID,  AgeFrom,  AgeTo, BuildSqlOrders(col, asc), pg);
        return lis;
    }
    
    [AjaxMethod]
    public ApplicationStatus GetApplicationStatus()
    {
        ApplicationStatus log = new ApplicationStatus();
        DA da = new DA();

        log.Pending = da.Application.GetStatusCount(EngineVariable.ApplicationStatus.Pending.Code);
        log.Terminated = da.Application.GetStatusCount(EngineVariable.ApplicationStatus.Terminated.Code);
        log.Completed = da.Application.GetStatusCount(EngineVariable.ApplicationStatus.Complete.Code);

        return log;
    }

    [AjaxMethod]
    public ApplicationDialogData NewApplication()
    {
        ApplicationDialogData ret = new ApplicationDialogData();

        ApplicationRow dr = new ApplicationTable().NewApplicationRow();
        ret.Entity = new ApplicationMinimalizedEntity(dr);

        ret.Course = GetCourseName();
        ret.Subject = GetSubjectList(dr.Course_ID);
        ret.SelectedSubject = new List<string>();
        ret.Location = GetPreferredLocation();
        ret.YearList = GetYear();
        ret.Sector = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Sector);
        ret.Position = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Position);
        return ret;
    }

    [AjaxMethod]
    public ApplicationDialogData GetApplication(Guid ApplicationID)
    {
        DA da = new DA();
        ApplicationRow dr = da.Application.GetByApplication_ID(ApplicationID);
        if (dr == null) return null;
        else
        {
            ApplicationDialogData ret = new ApplicationDialogData();
            ret.Entity = new ApplicationMinimalizedEntity(dr);

            ret.Course = GetCourseName();
            ret.Subject = GetSubjectList(dr.Course_ID);
            //ret.SelectedSubject = GetSelectedSubjectList(dr.Application_ID);
            List<ApplicationCourseSubjectRow> drs = da.ApplicationCourseSubject.GetByApplication(ApplicationID);
            ret.SelectedSubject = new List<string>();
            foreach (ApplicationCourseSubjectRow cdr in drs)
            {
                ret.SelectedSubject.Add(cdr.CourseSubject_ID.ToString());
            }
            ret.Location = GetPreferredLocation();
            ret.Country = GetCountryList();
            ret.PQ = GetPQLevelStartList();
            ret.YearList = GetYear();
            ret.MonthList = GetMonth(dr.TSP_ID, dr.Application_IntakeYear);
            ret.Sector = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Sector);
            ret.Position = GetGlobalSetting((int)EngineVariable.GlobalSettingType.Position);
            return ret;
        }
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
    public Dictionary<string, string> GetCourseName()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        //List<CourseRow> list = da.Course.GetCourseDetail();
        CourseTable dt = da.Course.GetAll();
        //foreach (CourseRow r in list)
        foreach (CourseRow r in dt.Rows)
        {
            lis.Add(r.Course_ID.ToString(), r.Course_Name);
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

    //[AjaxMethod]
    //public List<string> GetSelectedSubjectList(Guid ApplicationID)
    //{
    //    DA da = new DA();
    //    ApplicationCourseSubjectTable dt = da.ApplicationCourseSubject.GetByApplication_ID(ApplicationID);
    //    List<string> list = new List<string>();
    //    foreach (ApplicationCourseSubjectRow r in dt.Rows)
    //    {
    //        list.Add(r.CourseSubject_ID.ToString());
    //    }

    //    return list;
    //}

    [AjaxMethod]
    public Dictionary<string, string> GetPreferredLocation()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<TSPRow> list = da.TSP.GetAll();
        foreach (TSPRow r in list)
        {
            lis.Add(r.TSP_ID.ToString(), r.TSP_CampusName + ", " + r.TSP_City);
        }

        return lis;
    }

    [AjaxMethod]
    public Dictionary<string, string> GetMonth(Guid TSPID, int SelectedYear)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        //DA da = new DA();
        //TSPRow dr = da.TSP.GetByTSP_ID(TSPID);
        //if (dr != null)
        //{
            //if (SelectedYear == DateTime.Now.Year)
            //{
            //    int CurrentMonth = DateTime.Now.Month;
            //    if (dr.TSP_IntakeJan && CurrentMonth <= 1)
            //        lis.Add("1", "January");
            //    if (dr.TSP_IntakeFeb && CurrentMonth <= 2)
            //        lis.Add("2", "February");
            //    if (dr.TSP_IntakeMar && CurrentMonth <= 3)
            //        lis.Add("3", "March");
            //    if (dr.TSP_IntakeApr && CurrentMonth <= 4)
            //        lis.Add("4", "April");
            //    if (dr.TSP_IntakeMay && CurrentMonth <= 5)
            //        lis.Add("5", "May");
            //    if (dr.TSP_IntakeJun && CurrentMonth <= 6)
            //        lis.Add("6", "June");
            //    if (dr.TSP_IntakeJul && CurrentMonth <= 7)
            //        lis.Add("7", "July");
            //    if (dr.TSP_IntakeAug && CurrentMonth <= 8)
            //        lis.Add("8", "August");
            //    if (dr.TSP_IntakeSep && CurrentMonth <= 9)
            //        lis.Add("9", "September");
            //    if (dr.TSP_IntakeOct && CurrentMonth <= 10)
            //        lis.Add("10", "October");
            //    if (dr.TSP_IntakeNov && CurrentMonth <= 11)
            //        lis.Add("11", "November");
            //    if (dr.TSP_IntakeDec && CurrentMonth <= 12)
            //        lis.Add("12", "December");
            //}
            //else
            //{
                //if (dr.TSP_IntakeJan)
                    lis.Add("1", "January");
                //if (dr.TSP_IntakeFeb)
                    lis.Add("2", "February");
                //if (dr.TSP_IntakeMar)
                    lis.Add("3", "March");
                //if (dr.TSP_IntakeApr)
                    lis.Add("4", "April");
                //if (dr.TSP_IntakeMay)
                    lis.Add("5", "May");
                //if (dr.TSP_IntakeJun)
                    lis.Add("6", "June");
                //if (dr.TSP_IntakeJul)
                    lis.Add("7", "July");
                //if (dr.TSP_IntakeAug)
                    lis.Add("8", "August");
                //if (dr.TSP_IntakeSep)
                    lis.Add("9", "September");
                //if (dr.TSP_IntakeOct)
                    lis.Add("10", "October");
                //if (dr.TSP_IntakeNov)
                    lis.Add("11", "November");
                //if (dr.TSP_IntakeDec)
                    lis.Add("12", "December");
            //}
        //}

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
    public Dictionary<string, string> GetSession()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        AssessmentSessionDetailTable dt = da.AssessmentSessionDetail.Get(DateTime.Now, false);
        foreach (AssessmentSessionDetailRow r in dt.Rows)
        {
            if(!r.AssessmentSession_IsSent) lis.Add(r.AssessmentSession_ID.ToString(), r.AssessmentSession_Location + ", " + r.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_DateTime) + " (" + r.AssessmentSession_AssignedStudent.ToString() + "/" + r.AssessmentSession_MaximumStudent.ToString() + ")");

        }

        return lis;
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
        
        string tempFileName = AjaxLib.FileUploadTempPath + ett.UploadFile.TemporaryName;
        
        FileInfo f = new FileInfo(tempFileName);
        if (f.Exists)
        {
            DA da = new DA();
            
            ExcelPackage p = new ExcelPackage(f);
            ExcelWorksheet w = p.Workbook.Worksheets[1];
            
            bool EOF = false;
            int RowNumber = 2;
            while (!EOF)
            {
                string ReqIdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                string Sector = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string Position = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);
                string Department = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 4] as ExcelRange).Value);
                string CompanyName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 5] as ExcelRange).Value);
                string CompanyContact = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 6] as ExcelRange).Value);
                string CompanyAddress = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 7] as ExcelRange).Value);
                string ReqFatherFullName = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 8] as ExcelRange).Value);
                string ReqFatherIC = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 9] as ExcelRange).Value);
                string ReqMotherFullName= LibraryCommon.GetExcelValue((w.Cells[RowNumber, 10] as ExcelRange).Value);
                string ReqMotherIC = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 11] as ExcelRange).Value);
                string ReqCombinedIncome = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 12] as ExcelRange).Value);
                string ReqCurrentFieldofStudy = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 13] as ExcelRange).Value);
                string ReqUniversity = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 14] as ExcelRange).Value);
                string ReqCGPA = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 15] as ExcelRange).Value);
                string ReqPQCourse = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 16] as ExcelRange).Value);
                string ReqRemainingSubject = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 17] as ExcelRange).Value);
                string ReqStudyPreference = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 18] as ExcelRange).Value);
                string ReqLocation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 19] as ExcelRange).Value);
                string ReqIntakeYear = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 20] as ExcelRange).Value);
                string ReqIntakeMonth = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 21] as ExcelRange).Value);
                string CurrentPQ = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 22] as ExcelRange).Value);
                string PQRegistrationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 23] as ExcelRange).Value);
                string PQStartDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 24] as ExcelRange).Value);
                string PQDeadLine = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 25] as ExcelRange).Value);
                string LevelStartedPQ = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 26] as ExcelRange).Value);
                string RegisteredNextExamSitting = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 27] as ExcelRange).Value);
                string NextExamSitting = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 28] as ExcelRange).Value);
                string CurrentFinancialAssistance = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 29] as ExcelRange).Value);
                string ScholarshipProvider = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 30] as ExcelRange).Value);
                string ScholarshipAmount = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 31] as ExcelRange).Value);
                string ApplicationDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 32] as ExcelRange).Value);

                if (ReqIdentificationNumber == "")
                {
                    EOF = true;
                }
                else
                {
                    bool RowHasError = false;

                      

                    if (ReqCGPA == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing CGPA. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqCombinedIncome == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Combined Income. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqCurrentFieldofStudy == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Current Field of Study. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqFatherIC == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Father's Identification. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqFatherFullName == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Father's Full Name. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqIdentificationNumber == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqIntakeMonth == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Intake Month. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqIntakeYear == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Intake Year. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqMotherFullName == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Mother's Full Name. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqMotherIC == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Mother's Identification. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqPQCourse == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing PQ Course. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqRemainingSubject == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Remaining Subject. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqStudyPreference == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Study Preference. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ReqUniversity == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing University. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    if (ApplicationDate == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Application Date. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    
                    //Check Data Validity
                    CandidateRow drCandidate = da.Candidate.GetByIdentificationNumber(ReqIdentificationNumber);

                    if (drCandidate == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Candidate does not exist. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        if (da.Application.GetByCandidate_ID(drCandidate.Candidate_ID).Rows.Count > 0)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Application already exist. IC - " + ReqIdentificationNumber));
                            RowHasError = true;
                        }
                    }
                    
                    DateTime? CandidatePQStartDate = LibraryCommon.ConvertDate(PQStartDate);
                    DateTime? CandidatePQDeadline = LibraryCommon.ConvertDate(PQDeadLine);
                    DateTime? CandidateNextExam = LibraryCommon.ConvertDate(NextExamSitting);
                    DateTime? CandidateApplicationDate = LibraryCommon.ConvertDate(ApplicationDate);

                    if (CandidateApplicationDate.HasValue == false)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Application Date. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }

                    decimal CandidateCombinedIncome = LibraryCommon.ConvertDecimal(ReqCombinedIncome);

                    CourseRow drCourse = da.Course.GetBy_CourseCode(ReqPQCourse);
                    CourseSubjectTable dtCourseSubject = null;

                    List<Guid> RemainingSubject = new List<Guid>();

                    if (drCourse == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid PQ Course Code. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        dtCourseSubject = da.CourseSubject.GetByCourse_ID(drCourse.Course_ID);

                        string[] CourseCode = ReqRemainingSubject.Split(new char[] { ';' });
                        foreach(string CC in CourseCode)
                        {
                            bool Found = false;
                            foreach(CourseSubjectRow drCourseSubject in dtCourseSubject.Rows)
                            {
                                if (drCourseSubject.CourseSubject_Code.ToUpper() == CC.Trim().ToUpper())
                                {
                                    RemainingSubject.Add(drCourseSubject.CourseSubject_ID);
                                    Found = true;
                                    break;
                                }
                            }

                            if (!Found)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Course Subject " + CC + ". IC - " + ReqIdentificationNumber));
                                RowHasError = true;
                                break;
                            }
                        }
                    }

                    EngineVariable.ContractType CandidateStudyPreference = EngineVariable.ContractType.FullTime;
                    if (ReqStudyPreference.Trim().ToUpper() == "PT")
                    {
                        CandidateStudyPreference = EngineVariable.ContractType.PartTime;
                    }
                    else if (ReqStudyPreference.Trim().ToUpper() == "FT")
                    {
                        CandidateStudyPreference = EngineVariable.ContractType.FullTime;
                    }
                    else
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Study Preference. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }

                    TSPRow drTSP = da.TSP.GetByName(ReqLocation);
                    if (drTSP == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid TSP. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }

                    int CandidateIntakeYear = LibraryCommon.ConvertInteger(ReqIntakeYear);

                    if (CandidateIntakeYear < 999)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Intake Year. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }

                    int CandidateIntakeMonth = LibraryCommon.ConvertInteger(ReqIntakeMonth);

                    if (CandidateIntakeMonth > 12 || CandidateIntakeMonth < 1)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Intake Month. IC - " + ReqIdentificationNumber));
                        RowHasError = true;
                    }

                    bool CandidateCurrentPQ = (CurrentPQ.ToUpper().Trim() == "Y" ? true : false);
                    bool CandidateRegisteredNextExam = (RegisteredNextExamSitting.ToUpper().Trim() == "Y" ? true : false);
                    bool CandidateFinancialAssistance = (CurrentFinancialAssistance.ToUpper().Trim() == "Y" ? true : false);

                    decimal CandidateScholarshipAmount = LibraryCommon.ConvertDecimal(ScholarshipAmount);
                    
                    if (!RowHasError)
                    {
                        ApplicationRow dr = new ApplicationTable().NewApplicationRow();

                        dr.Application_AcademicTranscriptFile = "";
                        dr.Application_AcademicTranscriptImage = "";
                        dr.Application_Address1 = drCandidate.Candidate_Address1;
                        dr.Application_Address2 = drCandidate.Candidate_Address2;
                        dr.Application_BirthCertificateFile = "";
                        dr.Application_BirthCertificateImage = "";
                        dr.Application_CGPA = ReqCGPA;
                        dr.Application_City = drCandidate.Candidate_City;
                        dr.Application_CombinedHouseholdIncome = CandidateCombinedIncome;
                        dr.Application_CompanyAddress = CompanyAddress;
                        dr.Application_CompanyContact = CompanyContact;
                        dr.Application_CompanyDepartment = Department;
                        dr.Application_CompanyName = CompanyName;
                        dr.Application_CompanyPosition = Position;
                        dr.Application_CompanySector = Sector;
                        dr.Application_ConfirmAgreeTermsAndCondition = true;
                        dr.Application_ConfirmReceiveMyPACNotice = true;
                        dr.Application_ContractType = (short)CandidateStudyPreference;
                        dr.Application_CreatedBy = "System";
                        dr.Application_CreatedDate = DateTime.Now;
                        dr.Application_CurrentFieldOfStudy = ReqCurrentFieldofStudy;
                        dr.Application_CurrentlyEmployed = (CompanyName == "" ? false : true);
                        dr.Application_Date = CandidateApplicationDate.Value;
                        dr.Application_DeclarationAgree = true;
                        dr.Application_Deleted = false;
                        dr.Application_DOB = drCandidate.Candidate_DOB;
                        dr.Application_Email = drCandidate.Candidate_Email;
                        dr.Application_FatherIdentification = ReqFatherIC;
                        dr.Application_FatherName = ReqFatherFullName;
                        dr.Application_FinalisedDate = EngineVariable.LibraryVariable.Empty_DateTime;
                        dr.Application_FinalisedStatus = (short)EngineVariable.FinalisedApplicationStatusType.Pending;
                        dr.Application_FullName = drCandidate.Candidate_FullName;
                        dr.Application_Gender = drCandidate.Candidate_Gender;
                        dr.Application_ID = Guid.NewGuid();
                        dr.Application_IdentificationFile = "";
                        dr.Application_IdentificationImage = "";
                        dr.Application_IdentificationNumber = drCandidate.Candidate_ICNumber;
                        dr.Application_IntakeMonth = CandidateIntakeMonth;
                        dr.Application_IntakeYear = CandidateIntakeYear;
                        dr.Application_IsAssessmentSessionAccepted = false;
                        dr.Application_LOIssueDate = EngineVariable.LibraryVariable.Empty_DateTime;
                        dr.Application_MobilePhoneNumber = drCandidate.Candidate_MobilePhoneNumber;
                        dr.Application_MobilePhonePrefix = drCandidate.Candidate_MobilePhonePrefix;
                        dr.Application_MotherIdentification = ReqMotherIC;
                        dr.Application_MotherName = ReqMotherFullName;
                        dr.Application_Nationality = (short)drCandidate.Candidate_Nationality;
                        dr.Application_NextExamSession = (CandidateNextExam.HasValue ? CandidateNextExam.Value : EngineVariable.LibraryVariable.Empty_DateTime);
                        dr.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Application;
                        dr.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Active;
                        dr.Application_PassportSizeFile = "";
                        dr.Application_PassportSizeImage = "";
                        dr.Application_PGRegistrationNumber = PQRegistrationNumber;
                        dr.Application_PhoneNumber = drCandidate.Candidate_PhoneNumber;
                        dr.Application_PhonePrefix = drCandidate.Candidate_PhonePrefix;
                        dr.Application_Postcode = drCandidate.Candidate_Postcode;
                        dr.Application_PQAcceptanceFile = "";
                        dr.Application_PQAcceptanceImage = "";
                        dr.Application_PQDeadline = (CandidatePQDeadline.HasValue ? CandidatePQDeadline.Value : EngineVariable.LibraryVariable.Empty_DateTime);
                        dr.Application_PQLevelStart = LevelStartedPQ;
                        dr.Application_PQQualification = CandidateCurrentPQ;
                        dr.Application_PQStartDate = (CandidatePQStartDate.HasValue ? CandidatePQStartDate.Value : EngineVariable.LibraryVariable.Empty_DateTime);
                        dr.Application_RegisteredNextExam = CandidateRegisteredNextExam;
                        dr.Application_ScholarshipCost = CandidateScholarshipAmount;
                        dr.Application_ScholarshipProvider = ScholarshipProvider;
                        dr.Sponsor_ID = Guid.Empty;
                        dr.Application_State = drCandidate.Candidate_State;
                        dr.Application_Status = (short)EngineVariable.ApplicationStatus.Pending;
                        dr.Application_Submitted = true;
                        dr.Application_SubmittedDate = CandidateApplicationDate.Value;
                        dr.Application_University = ReqUniversity;
                        dr.Application_UpdatedBy = "System";
                        dr.Application_UpdatedDate = DateTime.Now;
                        dr.Candidate_ID = drCandidate.Candidate_ID;
                        dr.Country_ID = drCandidate.Country_ID;
                        dr.Course_ID = drCourse.Course_ID;
                        dr.TSP_ID = drTSP.TSP_ID;

                        ApplicationCourseSubjectTable dt = new ApplicationCourseSubjectTable();

                        foreach(Guid SubjectID in RemainingSubject)
                        {
                            ApplicationCourseSubjectRow drApplicationCourseSubject = dt.NewApplicationCourseSubjectRow();
                            drApplicationCourseSubject.ApplicationCourseSubject_ID = Guid.NewGuid();
                            drApplicationCourseSubject.Application_ID = dr.Application_ID;
                            drApplicationCourseSubject.CourseSubject_ID = SubjectID;
                        }

                        da.Application.Update(dr, null);
                        da.ApplicationCourseSubject.Update(dt, null);
                    }
                }
                RowNumber += 1;
            }

        }
        ActionLog log = WebLib.CreateLog("Import Candidate.");
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes Reject(List<string> ApplicationIDs)
    {
        DA da = new DA();
        da.Application.SetReject(ApplicationIDs, WebLib.LoggedInUser.UserName);
        
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public AssessmentSessionApplicantMinimalizedEntity GetAssignedSession(string StudentID)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        AssessmentSessionApplicantTable dt = da.AssessmentSessionApplicant.GetByApplicant_ID(Guid.Parse(StudentID));
        AssessmentSessionApplicantMinimalizedEntity Entity = new AssessmentSessionApplicantMinimalizedEntity();
        if (dt.Rows.Count > 0)
        {
            Entity = new AssessmentSessionApplicantMinimalizedEntity((AssessmentSessionApplicantRow)dt.Rows[0]);
        }
        else
        {
            Entity.Applicant_ID = Guid.Parse(StudentID);
            Entity.AssessmentSessionApplicant_ID = Guid.Empty;
            Entity.AssessmentSession_ID = Guid.Empty;
        }

        return Entity;
    }
    
    [AjaxMethod]
    public ErrorCodes[] SaveSession(AssessmentSessionApplicantMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        if (errs.Count == 0)
        {
            DA da = new DA();
            ActionLog log = WebLib.CreateLog((ett.AssessmentSessionApplicant_ID == Guid.Empty ? "Create" : "Modify") + " Session.");
            
            ApplicationRow drApplication = da.Application.GetByApplication_ID(ett.Applicant_ID);
            if (drApplication != null)
            {
                if (drApplication.Application_Status == (short)EngineVariable.ApplicationStatus.SessionRejected || drApplication.Application_Status == (short)EngineVariable.ApplicationStatus.Pending)
                {
                    drApplication.Application_Status = (short)EngineVariable.ApplicationStatus.SessionAssigned;

                    AssessmentSessionApplicantRow dr;
                    if (ett.AssessmentSessionApplicant_ID == Guid.Empty)
                    {
                        dr = new AssessmentSessionApplicantTable().NewAssessmentSessionApplicantRow();
                        ett.AssessmentSessionApplicant_ID = Guid.NewGuid();
                    }
                    else
                        dr = da.AssessmentSessionApplicant.GetByAssessmentSessionApplicant_ID(ett.AssessmentSessionApplicant_ID);

                    ett.CopyTo(dr);
                    da.AssessmentSessionApplicant.Update(dr, log);


                    da.Application.Update(drApplication, log);

                    log.Save();
                }
                else
                {
                }
            }
            else
            {
                errs.Add(ErrorCodes.Application_Invalid);
            }

        }

        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] SaveBulkSession(BulkSessionDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();

        if (errs.Count == 0)
        {
            DA da = new DA();

            foreach (string ID in ett.StudentIDs)
            {
                ApplicationRow drApplication = da.Application.GetByApplication_ID(Guid.Parse(ID));
                if (drApplication.Application_Status == (short)EngineVariable.ApplicationStatus.SessionRejected || drApplication.Application_Status == (short)EngineVariable.ApplicationStatus.Pending)
                {
                    ActionLog log = WebLib.CreateLog("Assign Bulk Session");
                    AssessmentSessionApplicantRow dr = da.AssessmentSessionApplicant.Get(ett.SessionID, Guid.Parse(ID));
                    if (dr == null)
                    {
                        dr = new AssessmentSessionApplicantTable().NewAssessmentSessionApplicantRow();
                        dr.AssessmentSessionApplicant_ID = Guid.NewGuid();
                    }

                    dr.Applicant_ID = Guid.Parse(ID);
                    dr.AssessmentSession_ID = ett.SessionID;
                    da.AssessmentSessionApplicant.Update(dr, log);

                    drApplication.Application_Status = (short)EngineVariable.ApplicationStatus.SessionAssigned;

                    da.Application.Update(drApplication, log);
                    log.Save();
                }
            }
        }

        return errs.ToArray();
    }

    [AjaxMethod]
    public BulkSessionDialogData GetBulkAssignedSession()
    {
        BulkSessionDialogData Entity = new BulkSessionDialogData();
        Entity.SessionID = Guid.Empty;
        Entity.StudentIDs = new List<string>();

        return Entity;
    }
    


    [AjaxMethod]
    public ErrorCodes[] SaveApplication(ApplicationDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyFullName(ett.Entity.Application_FullName));
        AddError(errs, VerifyICNumber(ett.Entity.Application_IdentificationNumber));
      //  AddError(errs, VerifyEmail(ett.Entity.Application_Email));

        AddError(errs, VerifyFatherName(ett.Entity.Application_FatherName));
        AddError(errs, VerifyFatherIC(ett.Entity.Application_FatherIdentification));
        AddError(errs, VerifyMotherName(ett.Entity.Application_MotherName));
        AddError(errs, VerifyMotherIC(ett.Entity.Application_MotherIdentification));
        AddError(errs, VerifyCombineHouseholdIncome(ett.Entity.Application_CombinedHouseholdIncome));


        AddError(errs, VerifyAddress(ett.Entity.Application_Address1));
        AddError(errs, VerifyPostcode(ett.Entity.Application_Postcode));
        AddError(errs, VerifyCity(ett.Entity.Application_City));
        AddError(errs, VerifyState(ett.Entity.Application_State));
        AddError(errs, VerifyContact(ett.Entity.Application_PhoneNumber));
        AddError(errs, VerifyMobile(ett.Entity.Application_MobilePhoneNumber));
        AddError(errs, VerifyEmail(ett.Entity.Application_Email));

        AddError(errs, VerifyCurrentFieldOfStudy(ett.Entity.Application_CurrentFieldOfStudy.ToString()));
        AddError(errs, VerifyUniversity(ett.Entity.Application_University.ToString()));
        AddError(errs, VerifyCGPA(ett.Entity.Application_CGPA.ToString()));

        AddError(errs, VerifyMonth(ett.Entity.Application_IntakeMonth));
        AddError(errs, VerifyStatus(ett.Entity.Application_Status.ToString()));

        ActionLog log = WebLib.CreateLog((ett.Entity.Application_ID == Guid.Empty ? "Create" : "Modify") + " Application.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            ApplicationRow dr;
            if (ett.Entity.Application_ID == Guid.Empty)
            {
                dr = new ApplicationTable().NewApplicationRow();
                ett.Entity.Application_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Application_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.Application.GetByApplication_ID(ett.Entity.Application_ID);
                ett.Entity.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.Application_UpdatedDate = DateTime.Now;
            }

            da.ApplicationCourseSubject.DeleteByApplication(ett.Entity.Application_ID);
            ApplicationCourseSubjectTable dt = new ApplicationCourseSubjectTable();

            List<string> selectedSubjects = ett.SelectedSubject;
            foreach (string SelectedSubject in selectedSubjects)
            {
                ApplicationCourseSubjectRow row = dt.NewApplicationCourseSubjectRow();
                row.ApplicationCourseSubject_ID = Guid.NewGuid();
                row.Application_ID = ett.Entity.Application_ID;
                row.CourseSubject_ID = Guid.Parse(SelectedSubject);
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                string folderPath = ConfigurationManager.AppSettings["UploadedAttachmentsFolder"];
                string defaultSavePath = folderPath + "\\" + ett.Entity.Application_ID;
                Directory.CreateDirectory(defaultSavePath);

                if (ett.UploadIC != null)
                {
                    string ext = Path.GetExtension(ett.UploadIC.OriginalName);
                    //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                    string filename = ett.UploadIC.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.Application_IdentificationImage = ett.UploadIC.OriginalName;
                    ett.Entity.Application_IdentificationFile = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.UploadIC.TemporaryName, savePath);
                }
                if (ett.UploadBOC != null)
                {
                    string ext = Path.GetExtension(ett.UploadBOC.OriginalName);
                    // oldPath = defaultSavePath + "\\" + ett.Entity.Application_BirthCertificateImage;
                    string filename = ett.UploadBOC.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.Application_BirthCertificateImage = ett.UploadBOC.OriginalName;
                    ett.Entity.Application_BirthCertificateFile = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.UploadBOC.TemporaryName, savePath);
                }
                if (ett.UploadAC != null)
                {
                    string ext = Path.GetExtension(ett.UploadAC.OriginalName);
                    //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_AcademicTranscriptImage;
                    string filename = ett.UploadAC.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.Application_AcademicTranscriptImage = ett.UploadAC.OriginalName;
                    ett.Entity.Application_AcademicTranscriptFile = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.UploadAC.TemporaryName, savePath);
                }
                if (ett.UploadPhoto != null)
                {
                    string ext = Path.GetExtension(ett.UploadAC.OriginalName);
                    //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_PassportSizeImage;
                    string filename = ett.UploadPhoto.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.Application_PassportSizeImage = ett.UploadPhoto.OriginalName;
                    ett.Entity.Application_PassportSizeFile = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.UploadPhoto.TemporaryName, savePath);
                }
                if (ett.UploadPQ != null)
                {
                    string ext = Path.GetExtension(ett.UploadPQ.OriginalName);
                    //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_PassportSizeImage;
                    string filename = ett.UploadPQ.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.Application_PQAcceptanceImage = ett.UploadPQ.OriginalName;
                    ett.Entity.Application_PQAcceptanceFile = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.UploadPQ.TemporaryName, savePath);
                }

                ett.Entity.CopyTo(dr);
                da.Application.Update(dr,log);
                da.ApplicationCourseSubject.Update(dt,log);

                log.Save();
            }
        }

        return errs.ToArray();
    }

    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }

    [AjaxMethod]
    public ErrorCodes VerifyAddress(string Address)
    {
        if (String.IsNullOrEmpty(Address)) return ErrorCodes.Application_AddressRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyPostcode(string Postcode)
    {
        if (String.IsNullOrEmpty(Postcode)) return ErrorCodes.Application_PostcodeRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyCity(string City)
    {
        if (String.IsNullOrEmpty(City)) return ErrorCodes.Application_CityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyState(string State)
    {
        if (String.IsNullOrEmpty(State)) return ErrorCodes.Application_StateRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyContact(string Contact)
    {
        if (String.IsNullOrEmpty(Contact)) return ErrorCodes.Application_ContactRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMobile(string Mobile)
    {
        if (String.IsNullOrEmpty(Mobile)) return ErrorCodes.Application_MobileRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyEmail(string EmailAddress)
    {
        if (String.IsNullOrEmpty(EmailAddress)) return ErrorCodes.Application_EmailRequired;
        else if (!Teq.Lib.IsEmail(EmailAddress)) return ErrorCodes.Application_EmailInvalid;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMonth(int SelectedMonth)
    {
        if (SelectedMonth < 1) return ErrorCodes.CandidateApplication_IntakeMonthRequired;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyCurrentFieldOfStudy(string FoS)
    {
        if (String.IsNullOrEmpty(FoS)) return ErrorCodes.CandidateApplication_CurrentFieldOfStudyRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyUniversity(string University)
    {
        if (String.IsNullOrEmpty(University)) return ErrorCodes.CandidateApplication_UniversityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyCGPA(string CGPA)
    {
        if (String.IsNullOrEmpty(CGPA)) return ErrorCodes.CandidateApplication_CGPARequire;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyFatherName(string FatherName)
    {
        if (String.IsNullOrEmpty(FatherName)) return ErrorCodes.CandidateApplication_FatherNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyFatherIC(string FatherID)
    {
        if (String.IsNullOrEmpty(FatherID)) return ErrorCodes.CandidateApplication_FatherICRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMotherName(string MotherName)
    {
        if (String.IsNullOrEmpty(MotherName)) return ErrorCodes.CandidateApplication_MotherNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyMotherIC(string MotherID)
    {
        if (String.IsNullOrEmpty(MotherID)) return ErrorCodes.CandidateApplication_MotherICRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyCombineHouseholdIncome(decimal HouseHoldIncome)
    {
        if (HouseHoldIncome <= 0) return ErrorCodes.CandidateApplication_CombinedHouseholdIncomeRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyFullName(string fullname)
    {
        if (String.IsNullOrEmpty(fullname)) return ErrorCodes.Application_FullNameRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyNationality(int nationality)
    {
        if (nationality == -1) return ErrorCodes.Application_NationalityRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyICNumber(string icNum)
    {
        if (String.IsNullOrEmpty(icNum)) return ErrorCodes.Application_ICNumberRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyStatus(string status)
    {
        if ((status == "-1")) return ErrorCodes.Application_StatusRequired;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes VerifyRejectedApplication(Guid id)
    {
        DA da = new DA();
        ApplicationRow dr = da.Application.GetByApplication_ID(id);
        if (dr.Application_Status.ToString() == "2") return ErrorCodes.Application_Rejected;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes RejectApplication(Guid id)
    {
        DA da = new DA();
        ApplicationRow dr = da.Application.GetByApplication_ID(id);
        if (dr != null)
        {
            ActionLog log = WebLib.CreateLog("Reject Application.");
            dr.Application_Status = Int16.Parse("2");
            da.Application.Update(dr,log);
            log.Save();
        }
        return ErrorCodes.GEN_NoError;
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
    
}

public class ApplicationDialogData
{
    public ApplicationMinimalizedEntity Entity;
    public Dictionary<string, string> Course;
    public Dictionary<string, string> Subject;
    public List<string> SelectedSubject;
    public Dictionary<string, string> Location;
    public Dictionary<string, string> Country;
    public Dictionary<string, string> YearList;
    public Dictionary<string, string> MonthList;
    public Dictionary<string, string> PQ;
    public UploadedFile UploadIC;
    public UploadedFile UploadBOC;
    public UploadedFile UploadAC;
    public UploadedFile UploadPhoto;
    public UploadedFile UploadPQ;
    public Dictionary<string, string> Position;
    public Dictionary<string, string> Sector;
}

public class BulkSessionDialogData
{
    public Guid SessionID;
    public List<string> StudentIDs;
}

public class ApplicationStatus
{
    public string Pending;
    public string Terminated;
    public string Completed;
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}