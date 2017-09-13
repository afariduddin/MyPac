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

public partial class StudentProgressSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(StudentProgressSummaryAjaxGateway));
        AjaxLib.RegisterController("StudentProgressSummary", ClientID);
      
        //AjaxLib.RegisterController("AssessmentResult", ClientID);
    }
}
public class StudentProgressSummaryAjaxGateway : AjaxGatewayBase
{
    public StudentProgressSummaryAjaxGateway()
    {
    }
    #region Student Progress Summary
    //for excel export
    [AjaxMethod]
    public PagedDataList<RptStudentProgressSummaryMasterListTable> GetResult(string FullName, int Gender, string Email, string ContactNum, DateTime CreatedDateFrom, DateTime CreatedDateTo, int ContractType, int Status, string[] sponsorID, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, bool isPaging, string IC, string[] TSPIDs, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }
        string TSPIDJoin = "";
        foreach (string tt in TSPIDs)
        {
            TSPIDJoin += tt + ",";
        }

        PagedDataList<RptStudentProgressSummaryMasterListTable> lis = da.Reports.SearchStudentProgressSummaryMasterList(FullName, Gender, Email, ContactNum, CreatedDateFrom, CreatedDateTo, ContractType, Status, sponsorIDJoin, EnrollmentDateFrom, EnrollmentDateTo, isPaging,IC, TSPIDJoin, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptStudentProgressSummaryMasterList"] = lis;

        return lis;
    }
    [AjaxMethod]
    public PagedDataList<StudentProgressSummaryDetailTable> GetAssessmentResultListing(string FullName, int Gender, string Email, string ContactNum, DateTime CreatedDateFrom, DateTime CreatedDateTo, int ContractType, int Status, string[] sponsorID, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo,string IC, string[] TSPID, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }
        string TSPJoin = "";
        foreach (string tt in TSPID)
        {
            TSPJoin += tt + ",";
        }

        PagedDataList<StudentProgressSummaryDetailTable> lis = da.StudentProgressSummaryDetail.Search(FullName, Gender, Email, ContactNum, CreatedDateFrom, CreatedDateTo, ContractType, Status, sponsorIDJoin, EnrollmentDateFrom, EnrollmentDateTo,IC, TSPJoin, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    //[AjaxMethod]
    //public Dictionary<string, string> GetCourse()
    //{
    //    Dictionary<string, string> lis = new Dictionary<string, string>();
    //    DA da = new DA();
    //    CourseTable tbl = da.Course.GetAll();
    //    foreach (CourseRow r in tbl.Rows)
    //    {
    //        lis.Add(r.Course_ID.ToString(), r.Course_Name);
    //    }
    //    return lis;
    //}

    [AjaxMethod]
    public StudentProgressDetailResultDialogData GetStudentProgressSummaryDetail(Guid id)
    {
        DA da = new DA();
        StudentProgressSummaryDetailRow dr = da.StudentProgressSummaryDetail.Get(id);
        if (dr == null) return null;
        else
        {
            StudentProgressDetailResultDialogData ret = new StudentProgressDetailResultDialogData();
            ret.Entity = new StudentProgressSummaryDetailMinimalizedEntity(dr);
            ret.Sponsor = GetSponsor();
            return ret;
        }
    }

    [AjaxMethod]
    public StudentProgressDetailResultDialogData NewStudentProgressSummaryDetail(Guid id)
    {
        StudentProgressDetailResultDialogData ret = new StudentProgressDetailResultDialogData();
        ret.Entity = new StudentProgressSummaryDetailMinimalizedEntity();
        ret.Sponsor = GetSponsor();
        return ret;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveStudentProgressSummary(StudentProgressSummaryDetailMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog((ett.Student_ID == Guid.Empty ? "Create" : "Modify") + " Student Progress Summary.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            StudentRow dr;
            ApplicationRow drApplication = da.Application.GetByApplication_ID(ett.Application_ID);


            if (Guid.Empty.CompareTo(ett.Student_ID) == 0)
            {
                dr = new StudentTable().NewStudentRow();
                ett.Student_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Student_CreatedDate = DateTime.Now;
                ett.Student_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.Student.GetByStudent_ID(ett.Student_ID);
                ett.Student_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Student_UpdatedDate = DateTime.Now;
            }
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.Student.Update(dr, log);
                
                if (drApplication != null)
                {
                    drApplication.Sponsor_ID = ett.Sponsor_ID;

                    if (dr.Student_Status == (int)EngineVariable.StudentStatusType.Completed)
                        drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Completed;
                    else if (dr.Student_Status == (int)EngineVariable.StudentStatusType.Terminated || dr.Student_Status == (int)EngineVariable.StudentStatusType.Withdrawn)
                        drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Inactive;
                    else if (dr.Student_Status == (int)EngineVariable.StudentStatusType.Active)
                        drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Active;

                    da.Application.Update(drApplication, log);
                }
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
    public ErrorCodes VerifyTerminatedStudent(Guid id)
    {
        DA da = new DA();
        StudentRow dr =  da.Student.GetByStudent_ID(id);
        if (dr.Student_Status.ToString() == EngineVariable.StudentStatusType.Terminated.Code.ToString()) return ErrorCodes.StudentProgressSummary_Terminated;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes TerminateStudent(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Terminate Student.");
        StudentRow dr = da.Student.GetByStudent_ID(id);
        if (dr != null)
        {
            dr.Student_Status = Int16.Parse(EngineVariable.StudentStatusType.Terminated.Code.ToString());
            da.Student.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
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
        string currentUser = WebLib.LoggedInUser.UserName;
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
                string EnrollmentDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                //string ContractExpiryDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);

                if (IdentificationNumber == "" && EnrollmentDate == "")
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
                    if (EnrollmentDate == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Enrollment Date. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    //if (ContractExpiryDate == "")
                    //{
                    //    errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Contract Expiry Date. IC - " + IdentificationNumber));
                    //    RowHasError = true;
                    //}

                    //Check Data Validity
                    ApplicationRow drApplication = da.Application.GetBy(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active);
                    StudentRow drStudent = null;
                    if (drApplication == null)
                    {
                        errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Application Does Not Exist. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        StudentTable dtStudent = da.Student.GetByApplication_ID(drApplication.Application_ID);
                        if (dtStudent.Rows.Count > 0)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Student Already Registered. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        if (drApplication.Application_FinalisedStatus != (short)EngineVariable.FinalisedApplicationStatusType.Confirmed)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Finalised Application Status. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }

                        DateTime? CandidateEnrollmentDate = LibraryCommon.ConvertDate(EnrollmentDate);
                        //DateTime? CandidateContractExpiryDate = LibraryCommon.ConvertDate(ContractExpiryDate);

                        if (CandidateEnrollmentDate.HasValue == false)
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Enrollment Date. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }
                        //if (CandidateContractExpiryDate.HasValue == false)
                        //{
                        //    errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Invalid Contract Expiry Date. IC - " + IdentificationNumber));
                        //    RowHasError = true;
                        //}

                        AssessmentResultTable dtAssessmentResult = da.AssessmentResult.GetByApplication_ID(drApplication.Application_ID);
                        AssessmentResultRow drAssessmentResult = null;
                        if (dtAssessmentResult.Rows.Count > 0)
                        {
                            drAssessmentResult = (AssessmentResultRow)dtAssessmentResult.Rows[0];
                        }
                        else
                        {
                            errs.Add(new ErrorCodes("InvalidField", "Row " + RowNumber.ToString() + ": Missing Assessment Result Record. IC - " + IdentificationNumber));
                            RowHasError = true;
                        }


                        if (!RowHasError)
                        {

                            //drAssessmentResult.AssessmentResult_ContractExpireDate = CandidateContractExpiryDate.Value;

                            //da.AssessmentResult.Update(drAssessmentResult, null);

                            drStudent = new StudentTable().NewStudentRow();
                            drStudent.Student_ID = Guid.NewGuid();
                            drStudent.TSP_ID = drApplication.TSP_ID;
                            drStudent.Student_SubjectTaken = 0;
                            drStudent.Course_ID = drApplication.Course_ID;
                            drStudent.Student_Status = (short)EngineVariable.StudentStatusType.Active;
                            drStudent.Student_Remark = "";
                            drStudent.Application_ID = drApplication.Application_ID;
                            drStudent.Student_CreatedDate = DateTime.Now;
                            drStudent.Student_UpdatedDate = DateTime.Now;
                            drStudent.Student_CreatedBy = currentUser;
                            drStudent.Student_UpdatedBy = currentUser;
                            drStudent.Student_EnrollmentDate = CandidateEnrollmentDate.Value;
                            drStudent.Student_ContractExpiredDate = drAssessmentResult.AssessmentResult_ContractExpireDate;

                            drApplication.Application_OverallProgress = (short)EngineVariable.ApplicationOverallProgressType.StudentCourse;

                            ApplicationCourseSubjectTable dtApplicationCourseSubject = da.ApplicationCourseSubject.GetByApplication_ID(drApplication.Application_ID);
                            StudentCourseTable dtStudentCourse = new StudentCourseTable();

                            CourseSubjectTable dtCourseSubject = da.CourseSubject.GetByCourse_ID(drApplication.Course_ID);
                            foreach (CourseSubjectRow drCourseSubject in dtCourseSubject.Rows)
                            {
                                StudentCourseRow drStudentCourse = dtStudentCourse.NewStudentCourseRow();

                                bool isExempted = true;
                                foreach (ApplicationCourseSubjectRow drApplicationCourseSubject in dtApplicationCourseSubject.Rows)
                                {
                                    if (drCourseSubject.CourseSubject_ID.CompareTo(drApplicationCourseSubject.CourseSubject_ID) == 0)
                                    {
                                        isExempted = false;
                                        break;
                                    }
                                }

                                drStudentCourse.StudentCourse_ID = Guid.NewGuid();
                                drStudentCourse.Student_ID = drStudent.Student_ID;
                                drStudentCourse.CourseSubject_ID = drCourseSubject.CourseSubject_ID;
                                if (isExempted)
                                    drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Exempted;
                                else
                                    drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Inactive;
                                drStudentCourse.StudentCourse_CreatedDate = DateTime.Now;
                                drStudentCourse.StudentCourse_UpdatedDate = DateTime.Now;
                                drStudentCourse.StudentCourse_CreatedBy = currentUser;
                                drStudentCourse.StudentCourse_UpdatedBy = currentUser;
                                drStudentCourse.StudentCourse_Remark = "";
                                drStudentCourse.StudentCourse_DefermentReason = "";
                            }

                            da.StudentCourse.Update(dtStudentCourse, null);
                            da.Application.Update(drApplication, null);
                            da.Student.Update(drStudent, null);


                        }
                    }
                }
                RowNumber += 1;
            }
        }
        ActionLog log = WebLib.CreateLog("Import Student Progress Summary.");
        log.Save();
        return errs.ToArray();
    }
    #endregion

    [AjaxMethod]
    public Dictionary<string, string> GetSponsor()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
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


    #region Student Warning Letter
    [AjaxMethod]
    public StudentWarningLetterDialogData NewStudentWarningLetter(Guid id)
    {
        StudentWarningLetterDialogData ret = new StudentWarningLetterDialogData();

        ret.WarningLetterTemplate = GetWarningLetterTemplate();

        return ret;
    }

    [AjaxMethod]
    public StudentWarningLetterDialogData GetStudentWarningLetter(Guid id)
    {
        DA da = new DA();
        StudentProgressSummaryDetailRow dr = da.StudentProgressSummaryDetail.Get(id);
        if (dr == null) return null;
        else
        {
            StudentWarningLetterDialogData ret = new StudentWarningLetterDialogData();

            ret.Entity = new StudentProgressSummaryDetailMinimalizedEntity(dr);

            ret.WarningLetterTemplate = GetWarningLetterTemplate();

            //StudentWarningLetterRow drs = da.StudentWarningLetter.GetByStudentID(dr.Student_ID);
            //if (drs != null)
            //{
            //    ret.SelectedWarningLetter = drs.WarningLetter_ID.ToString();
            //}
            //else
            //{
            //    Guid emptyGuid = new Guid();
            //    ret.SelectedWarningLetter = emptyGuid.ToString();
            //}
            Guid emptyGuid = new Guid();
           ret.SelectedWarningLetter = emptyGuid.ToString();
            return ret;
        }
    }

    [AjaxMethod]
    public ErrorCodes VerifyWarningLetterTemplate(string WarningLetterID)
    {
        if (WarningLetterID == Guid.Empty.ToString()) return ErrorCodes.WarningLetter_Required;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public Dictionary<string, string> GetWarningLetterTemplate()
    {
        Dictionary<string, string> lis = new Dictionary<string, string>();
        DA da = new DA();
        List<WarningLetterRow> list = da.WarningLetter.GetWarningLetterList();
        foreach (WarningLetterRow r in list)
        {
            lis.Add(r.WarningLetter_ID.ToString(), r.WarningLetter_Name);
        }

        return lis;
    }

    [AjaxMethod]
    public ErrorCodes[] SaveStudentWarningLetter(StudentWarningLetterDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();

        errs.Add(VerifyWarningLetterTemplate(ett.SelectedWarningLetter));

        ActionLog log = WebLib.CreateLog("Save Student Warning Letter.");
        if (errs.Count == 0)
        {
            DA da = new DA();

            //da.StudentWarningLetter.DeleteByStudentID(ett.Entity.Student_ID);

            StudentWarningLetterRow ds = new StudentWarningLetterTable().NewStudentWarningLetterRow();

            WarningLetterRow dr = da.WarningLetter.GetByWarningLetter_ID(Guid.Parse(ett.SelectedWarningLetter));
            EmailNotificationRow dt = new EmailNotificationTable().NewEmailNotificationRow();

            ds.StudentWarningLetter_ID = Guid.NewGuid();
            ds.Student_ID = ett.Entity.Student_ID;
            ds.WarningLetter_ID = Guid.Parse(ett.SelectedWarningLetter);
            ds.StudentWarningLetter_CreatedBy = WebLib.LoggedInUser.UserName;
            ds.StudentWarningLetter_CreatedDate = DateTime.Now;

            dt.EmailNotification_ID = Guid.NewGuid();
            dt.EmailNotification_Status = (short)EngineVariable.EmailNotificationStatusType.Pending;
            dt.EmailNotification_Recipient = ett.Entity.Application_Email;
            dt.EmailNotification_Subject = dr.WarningLetter_Subject;
            dt.EmailNotification_EmailContent = GetEmailContent_WarningLetter(ett);
            dt.EmailNotification_RetryCount = 0;
            dt.EmailNotification_CreatedDate = DateTime.Now;

            ds.EmailNotification_ID = dt.EmailNotification_ID;
            da.StudentWarningLetter.Update(ds, log);
            da.EmailNotification.Update(dt, log);
        }

        log.Save();
        return errs.ToArray();
    }

    public static string GetEmailContent_WarningLetter(StudentWarningLetterDialogData ett)
    {

        DA da = new DA();

        ApplicationRow drApplication = da.Application.GetByApplication_ID(ett.Entity.Application_ID);
        CourseRow drCourse = da.Course.GetByCourse_ID(drApplication.Course_ID);
        TSPRow drTSP = da.TSP.GetByTSP_ID(drApplication.TSP_ID);
        WarningLetterRow drWarningLetter = da.WarningLetter.GetByWarningLetter_ID(Guid.Parse(ett.SelectedWarningLetter));

        SponsorRow drSponsor = da.Sponsor.GetBySponsor_ID(drApplication.Sponsor_ID);
        string Sponsor = "";
        if (drSponsor != null)
        {
            Sponsor = drSponsor.Sponsor_Label;
        }

        string content = drWarningLetter.WarningLetter_Body.ToString();

        content = content.Replace("{FullName}", drApplication.Application_FullName);
        content = content.Replace("{Course}", drCourse.Course_Name);
        content = content.Replace("{TSP}", drTSP.TSP_CampusName + ", " + drTSP.TSP_City);
        content = content.Replace("{Sponsor}", Sponsor);

        return content;
    }
    #endregion

    #region Warning Letter List

    [AjaxMethod]
    public List<StudentWarningLetterDetailMinimalizedEntity> GetWarningLetterList(Guid StudentID)
    {
        List<StudentWarningLetterDetailMinimalizedEntity> lis = new List<StudentWarningLetterDetailMinimalizedEntity>();
        DA da = new DA();
        StudentWarningLetterDetailTable dt = da.StudentWarningLetterDetail.GetByStudentID(StudentID);
        foreach (StudentWarningLetterDetailRow dr in dt.Rows)
        {
            StudentWarningLetterDetailMinimalizedEntity l = new StudentWarningLetterDetailMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }
    #endregion
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}

public class StudentWarningLetterDialogData
{
    public StudentProgressSummaryDetailMinimalizedEntity Entity;
    public Dictionary<string, string> WarningLetterTemplate;
    public string SelectedWarningLetter;
}
public class StudentProgressDetailResultDialogData
{
    public StudentProgressSummaryDetailMinimalizedEntity Entity;
    public Dictionary<string, string> Sponsor;
}