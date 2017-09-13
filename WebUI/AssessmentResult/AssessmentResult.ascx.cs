using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using System.Web;
using Teq.Ajax;
using Teq.Data;
using OfficeOpenXml;
using System.IO;
using EngineCommon;

public partial class AssessmentResult : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(AssessmentResultAjaxGateway));
        AjaxLib.RegisterController("AssessmentResult", ClientID);
    }
}
public class AssessmentResultAjaxGateway : AjaxGatewayBase
{
    public AssessmentResultAjaxGateway()
    {
    }
    //for excel export
    [AjaxMethod]
    public PagedDataList<RptCandidateAssessmentResultMasterListTable> GetResult(string FullName, int Gender, string Email, string IC, string State, float Score, string Location, DateTime DateFrom, DateTime DateTo, int ContractType, int ExamType, int Status, string[] sponsorID, bool isPaging, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        Guid SelectedLocation = Guid.Empty;
        if (Location != "")
            SelectedLocation = Guid.Parse(Location);

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }
        PagedDataList<RptCandidateAssessmentResultMasterListTable> lis = da.Reports.SearchCandidateAssessmentResultMasterList(FullName, Gender, Email, IC, State, Score, SelectedLocation, DateFrom, DateTo, ContractType, ExamType, Status, sponsorIDJoin, isPaging, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptCandidateAssessmentResultMasterList"] = lis;

        return lis;
    }
    [AjaxMethod]
    public PagedDataList<AssessmentResultDetailTable> GetAssessmentResultListing(string FullName, int Gender, string Email, string IC, string State, float Score, string Location, DateTime DateFrom, DateTime DateTo, int ContractType, int ExamType, int Status, string[] sponsorID, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        Guid SelectedLocation = Guid.Empty;
        if (Location != "")
            SelectedLocation = Guid.Parse(Location);

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }

        PagedDataList<AssessmentResultDetailTable> lis = da.AssessmentResultDetail.Search(FullName, Gender, Email, IC, State, Score, SelectedLocation, DateFrom, DateTo, ContractType, ExamType, Status, sponsorIDJoin, BuildSqlOrders(col, asc), pg);
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
    public AssessmentResultDialogData GetAssessmentResultDetail(Guid id)
    {
        DA da = new DA();
        AssessmentResultDetailRow dr = da.AssessmentResultDetail.Get(id);
        if (dr == null) return null;
        else
        {
            //AssessmentResultDetailMinimalizedEntity ret = new AssessmentResultDetailMinimalizedEntity(dr);
            AssessmentResultDialogData ret = new AssessmentResultDialogData();
            ret.Entity = new AssessmentResultDetailMinimalizedEntity(dr);
            ret.Sponsor = GetSponsor();
            return ret;
        }
    }

    [AjaxMethod]
    public Dictionary<string, string> GetSponsor()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        lis.Add(Guid.Empty.ToString(), "Not Available");
        DA da = new DA();
        //List<CourseRow> list = da.Course.GetCourseDetail();
        SponsorTable dt = da.Sponsor.Get();
        //foreach (CourseRow r in list)
        foreach (SponsorRow r in dt.Rows)
        {
            lis.Add(r.Sponsor_ID.ToString(), r.Sponsor_Code);
        }

        return lis;
    }

    [AjaxMethod]
    public AssessmentResultDialogData NewAssessmentResultDetail(Guid id)
    {
        //AssessmentResultDetailMinimalizedEntity ret = new AssessmentResultDetailMinimalizedEntity();
        AssessmentResultDialogData ret = new AssessmentResultDialogData();
        ret.Entity = new AssessmentResultDetailMinimalizedEntity();
        ret.Sponsor = GetSponsor();
        return ret;
    }

    [AjaxMethod]
    public ErrorCodes SendCLO(List<string> AssessmentIDs)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Send CLO.");
        foreach (string AssessmentID in AssessmentIDs)
        {
            AssessmentResultRow dr = da.AssessmentResult.GetByAssessmentResult_ID(Guid.Parse(AssessmentID));
            if (dr != null)
            {
                if (dr.AssessmentResult_Status == (short)EngineVariable.AssessmentStatusType.Accepted)
                {
                    dr.AssessmentResult_Status = (short)EngineVariable.AssessmentStatusType.CLOSent;
                    dr.AssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                    dr.AssessmentResult_UpdatedDate = DateTime.Now;
                    dr.AssessmentResult_CLOIssueDate = DateTime.Now;
                    da.AssessmentResult.Update(dr,log);

                    ApplicationRow drApplication = da.Application.GetByApplication_ID(dr.Application_ID);

                    //if (drApplication.Application_ContractType == (short)EngineVariable.ContractType.FullTime)
                        //drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Finalised;
                    
                    EmailNotificationRow drEmail = new EmailNotificationTable().NewEmailNotificationRow();

                    drEmail.EmailNotification_CreatedDate = DateTime.Now;
                    drEmail.EmailNotification_EmailContent = LibraryCommon.GetEmailContent_ConditionalLetterOfOffer(drApplication);
                    drEmail.EmailNotification_ID = Guid.NewGuid();
                    drEmail.EmailNotification_Recipient = drApplication.Application_Email;
                    drEmail.EmailNotification_RetryCount = 0;
                    drEmail.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
                    drEmail.EmailNotification_StatusMessage = "";
                    drEmail.EmailNotification_Subject = "MyPAC: Conditional Letter of Offer";
                    drEmail.Application_ID = dr.Application_ID;
                    drEmail.EmailNotification_IsRead = false;

                    da.Application.Update(drApplication,log);
                    da.EmailNotification.Update(drEmail,log);
                }
            }
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveAssessmentResult(AssessmentResultDetailMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Assessment Result.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            AssessmentResultRow dr;
            if (Guid.Empty.CompareTo(ett.AssessmentResult_ID) == 0)
            {
                dr = new AssessmentResultTable().NewAssessmentResultRow();
                ett.AssessmentResult_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.AssessmentResult_CreatedDate = DateTime.Now;
                ett.AssessmentResult_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.AssessmentResult.GetByAssessmentResult_ID(ett.AssessmentResult_ID);
                ett.AssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.AssessmentResult_UpdatedDate = DateTime.Now;
            }

            ApplicationRow drApplication = da.Application.GetByApplication_ID(ett.Application_ID);

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);

                drApplication.Application_UpdatedBy = WebLib.LoggedInUser.UserName;
                drApplication.Application_UpdatedDate = DateTime.Now;

                ett.Application_UpdatedBy = drApplication.Application_UpdatedBy;
                ett.Application_UpdatedDate = drApplication.Application_UpdatedDate;
                drApplication.Sponsor_ID = ett.Sponsor_ID;

                da.AssessmentResult.Update(dr,log);
                da.Application.Update(drApplication,log);
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
    public ErrorCodes[] SaveSession(AssessmentSessionApplicantMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Session.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            AssessmentSessionApplicantRow dr;
            if (ett.AssessmentSessionApplicant_ID == Guid.Empty)
            {
                dr = new AssessmentSessionApplicantTable().NewAssessmentSessionApplicantRow();
                ett.AssessmentSessionApplicant_ID = Guid.NewGuid();
            }
            else
                dr = da.AssessmentSessionApplicant.GetByAssessmentSessionApplicant_ID(ett.AssessmentSessionApplicant_ID);

            ett.CopyTo(dr);
            da.AssessmentSessionApplicant.Update(dr,log);

            AssessmentResultRow drAssessmentResult = da.AssessmentResult.GetByAssessmentResult_ID(ett.Applicant_ID);
            drAssessmentResult.AssessmentResult_Status = (short)EngineVariable.AssessmentStatusType.InterviewInvited;

            da.AssessmentResult.Update(drAssessmentResult,log);
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] SaveBulkSession(BulkSessionDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Bulk Session.");
        if (errs.Count == 0)
        {
            DA da = new DA();

            foreach (string ID in ett.AssessmentIDs)
            {
                AssessmentResultRow drAssessmentResult = da.AssessmentResult.GetByAssessmentResult_ID(Guid.Parse(ID));
                if (drAssessmentResult.AssessmentResult_Status == (int)EngineVariable.AssessmentStatusType.Pass || drAssessmentResult.AssessmentResult_Status == (int)EngineVariable.AssessmentStatusType.InterviewRejected)
                {
                    AssessmentSessionApplicantRow dr = da.AssessmentSessionApplicant.Get(ett.SessionID, drAssessmentResult.Application_ID);
                    if (dr == null)
                    {
                        dr = new AssessmentSessionApplicantTable().NewAssessmentSessionApplicantRow();
                        dr.AssessmentSessionApplicant_ID = Guid.NewGuid();
                        
                    }
                    dr.Applicant_ID = drAssessmentResult.Application_ID;
                    dr.AssessmentSession_ID = ett.SessionID;
                    da.AssessmentSessionApplicant.Update(dr,log);

                    drAssessmentResult.AssessmentResult_Status = (short)EngineVariable.AssessmentStatusType.InterviewInvited;
                    da.AssessmentResult.Update(drAssessmentResult,log);
                }
            }
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public Dictionary<string, string> GetSession()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        AssessmentSessionDetailTable dt = da.AssessmentSessionDetail.Get(DateTime.Now, true);
        foreach (AssessmentSessionDetailRow r in dt.Rows)
        {
            lis.Add(r.AssessmentSession_ID.ToString(), r.AssessmentSession_Location + ", " + r.AssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_DateTime) + " (" + r.AssessmentSession_AssignedStudent.ToString() + "/" + r.AssessmentSession_MaximumStudent.ToString() + ")");
        }

        return lis;
    }


    [AjaxMethod]
    public BulkSessionDialogData GetBulkAssignedSession()
    {
        BulkSessionDialogData Entity = new BulkSessionDialogData();
        Entity.SessionID = Guid.Empty;
        Entity.AssessmentIDs = new List<string>();

        return Entity;
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

            ExcelPackage p = new ExcelPackage(f);
            ExcelWorksheet w = p.Workbook.Worksheets[1];

            if (LibraryCommon.GetExcelValue((w.Cells[1, 4] as ExcelRange).Value) == "") //Interview
            {
                bool EOF = false;
                int RowNumber = 2;
                while (!EOF)
                {
                    string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                    string InterviewResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                    string OverallResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);

                    if (IdentificationNumber == "" && InterviewResult == "" && OverallResult == "")
                    {
                        EOF = true;
                    }
                    else
                    {
                        bool RowHasError = false;
                        //Check Required Field
                        if (IdentificationNumber == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (InterviewResult == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Interview Result. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (OverallResult == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Overall Result. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        //Check Date Validity
                        ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                        AssessmentResultRow drAssessmentResult = null;
                        if (drApplication == null)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Application Does Not Exist. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        else
                        {
                            AssessmentResultTable dtAssessmentResult = da.AssessmentResult.GetByApplication_ID(drApplication.Application_ID);
                            if (dtAssessmentResult.Rows.Count == 0)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Assessment Result Does Not Exist. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                            else
                            {
                                drAssessmentResult = (AssessmentResultRow)dtAssessmentResult.Rows[0];

                                if (drAssessmentResult.AssessmentResult_Status != (short)EngineVariable.AssessmentStatusType.InterviewAccepted)
                                {
                                    errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Assessment Result. IC - " + IdentificationNumber));
                                    RowHasError = true;
                                }
                            }
                        }

                        EngineVariable.AssessmentInterviewStatus CandidateInterviewStatus = EngineVariable.AssessmentInterviewStatus.None;
                        if (InterviewResult == "P")
                        {
                            CandidateInterviewStatus = EngineVariable.AssessmentInterviewStatus.Pass;
                        }
                        else if (InterviewResult == "F")
                        {
                            CandidateInterviewStatus = EngineVariable.AssessmentInterviewStatus.Fail;
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Interview Result. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }


                        EngineVariable.AssessmentStatusType CandidateAssessmentStatus = EngineVariable.AssessmentStatusType.Declined;
                        Guid CandidateSponsor = Guid.Empty;

                        if (OverallResult == "R")
                            CandidateAssessmentStatus = EngineVariable.AssessmentStatusType.Rejected;
                        else
                        {
                            CandidateAssessmentStatus = EngineVariable.AssessmentStatusType.Accepted;
                            SponsorRow drSponsor = da.Sponsor.Get(OverallResult);
                            if (drSponsor != null)
                                CandidateSponsor = drSponsor.Sponsor_ID;
                            else
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Overall Result. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                        }
                        //else if (OverallResult == "AM")
                        //{
                        //    CandidateAssessmentStatus = EngineVariable.AssessmentStatusType.Accepted;
                        //    CandidateSponsor = EngineVariable.SponsorType.MyPAC; ;
                        //}

                        if (!RowHasError)
                        {
                            drAssessmentResult.AssessmentResult_Interview = (short)CandidateInterviewStatus;
                            
                            drAssessmentResult.AssessmentResult_Status = (short)CandidateAssessmentStatus;
                            drAssessmentResult.AssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                            drAssessmentResult.AssessmentResult_UpdatedDate = DateTime.Now;
                            da.AssessmentResult.Update(drAssessmentResult, null);

                            if (drAssessmentResult.AssessmentResult_Status == (short)EngineVariable.AssessmentStatusType.Accepted)
                            {
                                if (drApplication.Application_ContractType == (short)EngineVariable.ContractType.PartTime)
                                    drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.PTAssessment;
                                else
                                    drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Assessment;
                            }
                            else
                            {
                                drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Assessment;
                                drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Inactive;
                            }

                            drApplication.Sponsor_ID = CandidateSponsor;
                            da.Application.Update(drApplication, null);
                        }
                    }
                    RowNumber += 1;
                }
            }
            else //Assessment Result
            {
                AssessmentResultTable dt = new AssessmentResultTable();

                bool EOF = false;
                int RowNumber = 2;
                while (!EOF)
                {
                    string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                    string AssessmentDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                    string EnrollmentDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);
                    string TechnicalAssessment = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 4] as ExcelRange).Value);
                    string EnglishFoundation = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 5] as ExcelRange).Value);
                    string Listening = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 6] as ExcelRange).Value);
                    string Writing = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 7] as ExcelRange).Value);
                    string Speaking = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 8] as ExcelRange).Value);
                    string Reading = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 9] as ExcelRange).Value);
                    string EPTOverall = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 10] as ExcelRange).Value);
                    string OverallResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 11] as ExcelRange).Value);
                    string ContractExpiryDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 12] as ExcelRange).Value);

                    if (IdentificationNumber == "" && AssessmentDate == "" && EnrollmentDate == "" && IdentificationNumber == "" && OverallResult == "" && ContractExpiryDate == "")
                    {
                        EOF = true;
                    }
                    else
                    {
                        bool RowHasError = false;
                        //Check Required Field
                        if (IdentificationNumber == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (AssessmentDate == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Assessment Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (EnrollmentDate == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Enrollment Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (OverallResult == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Overall Result. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (ContractExpiryDate == "")
                        {
                            errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Contract Expiry Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        //Check Date Validity
                        DateTime? CandidateAssessmentDate = LibraryCommon.ConvertDate(AssessmentDate);
                        DateTime? CandidateEnrollmentDate = LibraryCommon.ConvertDate(EnrollmentDate);
                        DateTime? CandidateContractExpiryDate = LibraryCommon.ConvertDate(ContractExpiryDate);

                        if (CandidateAssessmentDate.HasValue == false)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Assessment Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        if (CandidateEnrollmentDate.HasValue == false)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Enrollment Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        if (CandidateContractExpiryDate.HasValue == false)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Contract Expiry Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                        if (drApplication == null)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Application Does Not Exist. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        else
                        {
                            if (drApplication.Application_Status != (int)EngineVariable.ApplicationStatus.SessionAccepted)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Applicant Status. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                        }

                        bool CandidateOverallResult = false;
                        if (OverallResult == "P")
                        {
                            CandidateOverallResult = true;
                        }
                        else if (OverallResult == "F")
                        {
                            CandidateOverallResult = false;
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Overall Result. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        AssessmentResultRow drAssessmentResult = da.AssessmentResult.Get(IdentificationNumber);
                        if (drAssessmentResult != null)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Assessment Result Already Exist. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        decimal CandidateTechnicalAssessment = LibraryCommon.ConvertDecimal(TechnicalAssessment);
                        decimal CandidateEnglishFoundation = LibraryCommon.ConvertDecimal(EnglishFoundation);
                        decimal CandidateListening = LibraryCommon.ConvertDecimal(Listening);
                        decimal CandidateWriting = LibraryCommon.ConvertDecimal(Writing);
                        decimal CandidateSpeaking = LibraryCommon.ConvertDecimal(Speaking);
                        decimal CandidateReading = LibraryCommon.ConvertDecimal(Reading);
                        decimal CandidateEPTOverall = LibraryCommon.ConvertDecimal(EPTOverall);

                        if (!RowHasError)
                        {
                            AssessmentResultRow dr = dt.NewAssessmentResultRow();

                            dr.Application_ID = drApplication.Application_ID;
                            dr.AssessmentResult_AverageScore = 0;
                            dr.AssessmentResult_CLOIssueDate = EngineVariable.LibraryVariable.Empty_DateTime;
                            dr.AssessmentResult_CreatedBy = WebLib.LoggedInUser.UserName;
                            dr.AssessmentResult_CreatedDate = DateTime.Now;
                            dr.AssessmentResult_Date = CandidateAssessmentDate.Value;
                            dr.AssessmentResult_EnglishFoundation = CandidateEnglishFoundation;
                            dr.AssessmentResult_EPTSummary = CandidateEPTOverall;
                            dr.AssessmentResult_ExpectedEnrollmentDate = CandidateEnrollmentDate.Value;
                            dr.AssessmentResult_ID = Guid.NewGuid();
                            dr.AssessmentResult_Interview = (short)EngineVariable.AssessmentInterviewStatus.None;
                            dr.AssessmentResult_Listening = CandidateListening;
                            dr.AssessmentResult_Reading = CandidateReading;
                            dr.AssessmentResult_Remark = "";
                            dr.AssessmentResult_Speaking = CandidateSpeaking;
                            dr.AssessmentResult_Status = CandidateOverallResult ? (short)EngineVariable.AssessmentStatusType.Pass : (short)EngineVariable.AssessmentStatusType.Fail;
                            dr.AssessmentResult_TechnicalAssessment = CandidateTechnicalAssessment;
                            dr.AssessmentResult_TotalScore = 0;
                            dr.AssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                            dr.AssessmentResult_UpdatedDate = DateTime.Now;
                            dr.AssessmentResult_Writing = CandidateWriting;
                            dr.AssessmentResult_ContractExpireDate = CandidateContractExpiryDate.Value;

                            drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Assessment;
                            drApplication.Application_Status = (short)EngineVariable.ApplicationStatus.Complete;
                            da.Application.Update(drApplication, null);
                        }
                    }
                    RowNumber += 1;
                }

                da.AssessmentResult.Update(dt, null);
            }
        }
        ActionLog log = WebLib.CreateLog("Import Assessment Result.");
        log.Save();
        return errs.ToArray();
    }
}

public class AssessmentResultDialogData
{
    public AssessmentResultDetailMinimalizedEntity Entity;
    public Dictionary<string, string> Sponsor;
}


    public class BulkSessionDialogData
{
    public Guid SessionID;
    public List<string> AssessmentIDs;
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}