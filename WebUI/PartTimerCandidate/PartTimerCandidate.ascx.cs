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

public partial class PartTimerCandidate : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(PartTimerAssessmentResultAjaxGateway));
        AjaxLib.RegisterController("PartTimerCandidate", ClientID);
    }
}
public class PartTimerAssessmentResultAjaxGateway : AjaxGatewayBase
{
    public PartTimerAssessmentResultAjaxGateway()
    {
    }

    #region PartTimerAssessmentResult
    //for excel export
    [AjaxMethod]
    public PagedDataList<RptPartTimerAssessmentResultMasterListTable> GetResult(string FullName, int Gender, string Email, string IC, string State, float Score, string Location, DateTime AssessmentDateFrom, DateTime AssessmentDateTo, int ContractType, int SubjectType, int Status, string[] sponsorID, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, bool isPaging, int[] col, bool[] asc, int pg)
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

        PagedDataList<RptPartTimerAssessmentResultMasterListTable> lis = da.Reports.SearchPartTimerAssessmentResultMasterList(FullName, Gender, Email, IC, State, Score, SelectedLocation, AssessmentDateFrom, AssessmentDateTo, ContractType, SubjectType, Status, sponsorIDJoin, EnrollmentDateFrom, EnrollmentDateTo, isPaging, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptPartTimerAssessmentResultMasterList"] = lis;

        return lis;
    }
    [AjaxMethod]
    public PagedDataList<PartTimerAssessmentResultDetailTable> GetPartTimerAssessmentResultListing(string FullName, int Gender, string Email, string IC, string State, float Score, string Location, DateTime AssessmentDateFrom, DateTime AssessmentDateTo, int ContractType, int SubjectType, int Status, string[] sponsorID, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, int[] col, bool[] asc, int pg)
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

        PagedDataList<PartTimerAssessmentResultDetailTable> lis = da.PartTimerAssessmentResultDetail.Search(FullName, Gender, Email, IC, State, Score, SelectedLocation, AssessmentDateFrom, AssessmentDateTo, ContractType, SubjectType, Status, sponsorIDJoin, EnrollmentDateFrom, EnrollmentDateTo, BuildSqlOrders(col, asc), pg);
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
    public PartTimerAssessmentResultDetailMinimalizedEntity GetPartTimerAssessmentResultDetail(Guid id)
    {
        DA da = new DA();
        PartTimerAssessmentResultDetailRow dr = da.PartTimerAssessmentResultDetail.Get(id);
        if (dr == null) return null;
        else
        {
            PartTimerAssessmentResultDetailMinimalizedEntity ret = new PartTimerAssessmentResultDetailMinimalizedEntity(dr);
            return ret;
        }
    }

    [AjaxMethod]
    public PartTimerAssessmentResultDetailMinimalizedEntity NewPartTimerAssessmentResultDetail(Guid id)
    {
        PartTimerAssessmentResultDetailMinimalizedEntity ret = new PartTimerAssessmentResultDetailMinimalizedEntity();
        return ret;
    }

    [AjaxMethod]
    public ErrorCodes[] SavePartTimerAssessment(PartTimerAssessmentResultDetailMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Part Timer Assessment.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            PartTimerAssessmentResultRow dr;
            if (Guid.Empty.CompareTo(ett.PartTimerAssessmentResult_ID) == 0)
            {
                dr = new PartTimerAssessmentResultTable().NewPartTimerAssessmentResultRow();
                ett.PartTimerAssessmentResult_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.PartTimerAssessmentResult_CreatedDate = DateTime.Now;
                ett.PartTimerAssessmentResult_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.PartTimerAssessmentResult.GetByPartTimerAssessmentResult_ID(ett.PartTimerAssessmentResult_ID);
                ett.PartTimerAssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.PartTimerAssessmentResult.Update(dr,log);
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

            bool EOF = false;
            int RowNumber = 2;
            while (!EOF)
            {
                string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                string Assessment1 = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string Assessment2 = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);
                string Assessment3 = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 4] as ExcelRange).Value);
                string OverallResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 5] as ExcelRange).Value);

                if (IdentificationNumber == "" && OverallResult == "")
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
                    if (OverallResult == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    //Check Data Validity
                    if (da.Candidate.GetByIdentificationNumber(IdentificationNumber) == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Identification Number does not exist. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    
                    decimal AssessmentScore1 = LibraryCommon.ConvertDecimal(Assessment1);
                    decimal AssessmentScore2 = LibraryCommon.ConvertDecimal(Assessment1);
                    decimal AssessmentScore3 = LibraryCommon.ConvertDecimal(Assessment1);

                    ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                    PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                    if (drApplication == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Missing Application. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(drApplication.Application_ID);
                        if (dtPartTimerAssessmentResult.Rows.Count > 0)
                        {
                            drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];

                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Complete || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Reject)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Either candidate has Completed Assessment or Rejected. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status != (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentInvitationConfirmed)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Candidate must accept Assessment Invitation first. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("Error", "Row " + RowNumber.ToString() + ": Missing Previous Part Timer Assessment Record. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                    }

                    EngineVariable.PartTimerAssessmentStatusType CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;

                    if (OverallResult == "A")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.AssessmentPass;
                    else if (OverallResult == "R")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;
                    else
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Overall Result. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }


                    if (!RowHasError)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Assessment1 = AssessmentScore1;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Assessment2 = AssessmentScore2;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Assessment3 = AssessmentScore3;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)CandidateOverallResult;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;

                        da.Application.Update(drApplication, null);
                        da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, null);
                    }
                }
                RowNumber += 1;
            }

        }
        ActionLog log = WebLib.CreateLog("Import Part-Timer Assessment Result.");
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] ImportCDP(ImportData ett)
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
                string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                string Attendance = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string OverallResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);

                if (IdentificationNumber == "" && OverallResult == "" && Attendance == "")
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
                    if (OverallResult == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    //Check Data Validity
                    if (da.Candidate.GetByIdentificationNumber(IdentificationNumber) == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Identification Number does not exist. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    decimal AssessmentAttendance = LibraryCommon.ConvertDecimal(Attendance);

                    ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                    PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                    if (drApplication == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Missing Application. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(drApplication.Application_ID);
                        if (dtPartTimerAssessmentResult.Rows.Count > 0)
                        {
                            drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];

                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Complete || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Reject)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Either candidate has Completed Assessment or Rejected. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status != (short)EngineVariable.PartTimerAssessmentStatusType.CDPInvitationConfirmed)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Candidate must accept CDP Invitation first. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("Error", "Row " + RowNumber.ToString() + ": Missing Previous Part Timer Assessment Record. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                    }

                    EngineVariable.PartTimerAssessmentStatusType CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;

                    if (OverallResult == "A")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.CDPPass;
                    else if (OverallResult == "R")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;
                    else
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Overall Result. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }


                    if (!RowHasError)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Attendance = AssessmentAttendance;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)CandidateOverallResult;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;

                        da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, null);
                        da.Application.Update(drApplication, null);
                    }
                }
                RowNumber += 1;
            }


        }
        ActionLog log = WebLib.CreateLog("Import Part-Timer CDP Result.");
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] ImportInterview(ImportData ett)
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

            bool EOF = false;
            int RowNumber = 2;
            while (!EOF)
            {
                string IdentificationNumber = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 1] as ExcelRange).Value);
                string InterviewResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string OverallResult = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);

                if (IdentificationNumber == "" && OverallResult == "" && InterviewResult == "")
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
                    if (OverallResult == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Identification Number. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    if (InterviewResult == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Interview Result. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    //Check Data Validity
                    if (da.Candidate.GetByIdentificationNumber(IdentificationNumber) == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Identification Number does not exist. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    short CandidateInterviewResult = 0;
                    if (InterviewResult == "P")
                        CandidateInterviewResult = (short)EngineVariable.PartTimerInterviewType.Pass;
                    else if (InterviewResult == "F")
                        CandidateInterviewResult = (short)EngineVariable.PartTimerInterviewType.Fail;
                    else
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Interview Result. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }

                    ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                    PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                    if (drApplication == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Missing Application. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(drApplication.Application_ID);
                        if (dtPartTimerAssessmentResult.Rows.Count > 0)
                        {
                            drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];

                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Complete || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Reject)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Either candidate has Completed Assessment or Rejected. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                            if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status != (short)EngineVariable.PartTimerAssessmentStatusType.InterviewInvitationConfirmed)
                            {
                                errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Candidate must accept Interview Invitation first. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("Error", "Row " + RowNumber.ToString() + ": Missing Previous Part Timer Assessment Record. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                    }

                    EngineVariable.PartTimerAssessmentStatusType CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;

                    if (OverallResult == "A")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Complete;
                    else if (OverallResult == "R")
                        CandidateOverallResult = EngineVariable.PartTimerAssessmentStatusType.Reject;
                    else
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Overall Result. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }


                    if (!RowHasError)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_InterviewResult = (short)CandidateInterviewResult;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)CandidateOverallResult;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedBy = WebLib.LoggedInUser.UserName;
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;

                        if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Complete)
                        {
                            drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.Finalised;
                            drApplication.Application_FinalisedStatus = (short)EngineVariable.FinalisedApplicationStatusType.Pending;
                        }
                        else if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Reject)
                        {
                            drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Inactive;
                        }
                        da.Application.Update(drApplication, null);
                        da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, null);
                    }
                }
                RowNumber += 1;
            }
        }
        ActionLog log = WebLib.CreateLog("Import Part-Timer Interview Result.");
        log.Save();
        return errs.ToArray();
    }
    #endregion

    #region For Setting Assessment Session
    [AjaxMethod]
    public Dictionary<string, string> GetSession()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        PartTimerAssessmentSessionDetailTable dt = da.PartTimerAssessmentSessionDetail.Get(DateTime.Now /*, false*/);
        foreach (PartTimerAssessmentSessionDetailRow r in dt.Rows)
        {
            if(!r.PartTimerAssessmentSession_IsSent) lis.Add(r.PartTimerAssessmentSession_ID.ToString(), EngineVariable.PartTimerSessionType.Find<EngineVariable.PartTimerSessionType>(r.PartTimerAssessmentSession_SessionType).Name + ": " + r.PartTimerAssessmentSession_Location + ", " + r.PartTimerAssessmentSession_DateTime.ToString(EngineVariable.LibraryVariable.Format_DateTime) + " (" + r.PartTimerAssessmentSession_AssignedStudent.ToString() + "/" + r.PartTimerAssessmentSession_MaximumStudent.ToString() + ")");

        }

        return lis;
    }

    [AjaxMethod]
    public PartTimerAssessmentSessionApplicantMinimalizedEntity GetAssignedSession(string StudentID)
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        PartTimerAssessmentSessionApplicantTable dt = da.PartTimerAssessmentSessionApplicant.GetByApplicant_ID(Guid.Parse(StudentID));
        PartTimerAssessmentSessionApplicantMinimalizedEntity Entity = new PartTimerAssessmentSessionApplicantMinimalizedEntity();
        if (dt.Rows.Count > 0)
        {
            Entity = new PartTimerAssessmentSessionApplicantMinimalizedEntity((PartTimerAssessmentSessionApplicantRow)dt.Rows[0]);
        }
        else
        {
            Entity.Applicant_ID = Guid.Parse(StudentID);
            Entity.PartTimerAssessmentSessionApplicant_ID = Guid.Empty;
            Entity.PartTimerAssessmentSession_ID = Guid.Empty;
        }

        return Entity;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveSession(PartTimerAssessmentSessionApplicantMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Session For Part Timer Candidate.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            bool isValid = false;
            PartTimerAssessmentSessionRow drPartTimerAssessmentSession = (PartTimerAssessmentSessionRow)da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(ett.PartTimerAssessmentSession_ID);
            PartTimerAssessmentResultRow drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)da.PartTimerAssessmentResult.GetByApplication_ID(ett.Applicant_ID).Rows[0];
            if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Assessment)
            {
                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Pending || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentInvitationRejected)
                { 
                    drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentInvitationSent;
                    isValid = true;
                }
            }
            else if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.CDP)
            {
                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentPass || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.CDPInvitationRejected)
                { 
                    drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.CDPInvitationSent;
                    isValid = true;
                }
            }
            else if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Interview)
            {
                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.CDPPass || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.InterviewInvitationRejected)
                { 
                    drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.InterviewInvitationSent;
                    isValid = true;
                }
            }

            if (isValid)
            {

                PartTimerAssessmentSessionApplicantRow dr = da.PartTimerAssessmentSessionApplicant.Get(ett.Applicant_ID, ett.PartTimerAssessmentSession_ID);
                
                if (dr == null)
                {
                    dr = new PartTimerAssessmentSessionApplicantTable().NewPartTimerAssessmentSessionApplicantRow();
                    ett.PartTimerAssessmentSessionApplicant_ID = Guid.NewGuid();
                }
                else
                    dr = da.PartTimerAssessmentSessionApplicant.GetByPartTimerAssessmentSessionApplicant_ID(ett.PartTimerAssessmentSessionApplicant_ID);

                ett.CopyTo(dr);
                da.PartTimerAssessmentSessionApplicant.Update(dr,log);
                da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] SaveBulkSession(BulkSessionDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog("Save Bulk Session For Part Timer Candidate.");
        if (errs.Count == 0)
        {
            DA da = new DA();

            PartTimerAssessmentSessionRow drPartTimerAssessmentSession = da.PartTimerAssessmentSession.GetByPartTimerAssessmentSession_ID(ett.PartTimerAssessmentSessionID);
            foreach (string ID in ett.ApplicationIDs)
            {
                bool isValid = false;
                PartTimerAssessmentResultRow drPartTimerAssessmentResult = da.PartTimerAssessmentResult.Get(Guid.Parse(ID));

                if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Assessment)
                {
                    if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.Pending)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentInvitationSent;
                        isValid = true;
                    }
                }
                else if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.CDP)
                {
                    if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.AssessmentPass)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.CDPInvitationSent;
                        isValid = true;
                    }
                }
                else if (drPartTimerAssessmentSession.PartTimerAssessmentSession_SessionType == (short)EngineVariable.PartTimerSessionType.Interview)
                {
                    if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)EngineVariable.PartTimerAssessmentStatusType.CDPPass)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.InterviewInvitationSent;
                        isValid = true;
                    }
                }

                if (isValid)
                {
                    PartTimerAssessmentSessionApplicantRow dr = da.PartTimerAssessmentSessionApplicant.Get(Guid.Parse(ID), ett.PartTimerAssessmentSessionID);
                    if (dr == null)
                    {
                        dr = new PartTimerAssessmentSessionApplicantTable().NewPartTimerAssessmentSessionApplicantRow();
                        dr.Applicant_ID = Guid.Parse(ID);
                        dr.PartTimerAssessmentSessionApplicant_ID = Guid.NewGuid();
                    }
                    dr.PartTimerAssessmentSession_ID = ett.PartTimerAssessmentSessionID;

                    da.PartTimerAssessmentSessionApplicant.Update(dr,log);
                    da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult,log);
                }
                
                //PartTimerAssessmentSessionApplicantTable dt = da.PartTimerAssessmentSessionApplicant.GetByApplicant_ID(Guid.Parse(ID));
                //PartTimerAssessmentSessionApplicantRow dr;
                //if (dt.Rows.Count > 0)
                //{
                //    dr = (PartTimerAssessmentSessionApplicantRow)dt.Rows[0];
                //}
                //else
                //{
                //    dr = new PartTimerAssessmentSessionApplicantTable().NewPartTimerAssessmentSessionApplicantRow();
                //    dr.Applicant_ID = Guid.Parse(ID);
                //    dr.PartTimerAssessmentSessionApplicant_ID = Guid.NewGuid();
                //}

                //dr.PartTimerAssessmentSession_ID = ett.SessionID;
                //da.PartTimerAssessmentSessionApplicant.Update(dr);

                //ApplicationRow drApplication = da.Application.GetByApplication_ID(dr.Applicant_ID);
                //drApplication.Application_Status = (short)EngineVariable.ApplicationStatus.SessionAssigned;

                //da.Application.Update(drApplication);
            }
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public BulkSessionDialogData GetBulkAssignedSession()
    {
        BulkSessionDialogData Entity = new BulkSessionDialogData();
        Entity.PartTimerAssessmentSessionID = Guid.Empty;
        Entity.ApplicationIDs = new List<string>();

        return Entity;
    }
    #endregion
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}

public class BulkSessionDialogData
{
    public Guid PartTimerAssessmentSessionID;
    public List<string> ApplicationIDs;
}