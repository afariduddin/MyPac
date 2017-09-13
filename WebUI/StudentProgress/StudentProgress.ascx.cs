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
using Teq;
using System.Configuration;
using System.Globalization;

public partial class StudentProgress : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(StudentProgressAjaxGateway));
        AjaxLib.RegisterController("StudentProgress", ClientID);
    }
}
public class StudentProgressAjaxGateway : AjaxGatewayBase
{
    public StudentProgressAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<StudentCourseDetailTable> GetStudentProgressList(DateTime startDate, DateTime endDate, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, int StudentCourseStatusType, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        PagedDataList<StudentCourseDetailTable> lis = da.StudentCourseDetail.Search(startDate, endDate, FullName, Gender, Email, ICNumber, State, ContractType, StudentCourseStatusType, BuildSqlOrders(col, asc), pg);
        return lis;
    }

    [AjaxMethod]
    public StudentCourseMinimalizedEntity NewStudentProgress()
    {
        StudentCourseRow dr = new StudentCourseTable().NewStudentCourseRow();
        StudentCourseMinimalizedEntity ett = new StudentCourseMinimalizedEntity(dr);
        return ett;
    }
    [AjaxMethod]
    public StudentCourseDetailMinimalizedEntity GetStudentProgress(Guid id)
    {
        DA da = new DA();
        StudentCourseDetailRow dr = da.StudentCourseDetail.GetBy(id);
        if (dr == null) return null;
        else
        {
            StudentCourseDetailMinimalizedEntity ett = new StudentCourseDetailMinimalizedEntity(dr);
            return ett;
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
    public Dictionary<string, string> GetCoaching()
    {
        DA da = new DA();
        UserAccountTable tbl = da.UserAccount.GetAll();
        Dictionary<string, string> li = new Dictionary<string, string>();
        foreach(UserAccountRow r in tbl.Rows)
        {
            li.Add(r.UserAccount_ID.ToString(), r.UserAccount_FullName);
        }

        return li;
    }

    [AjaxMethod]
    public List<StudentAttendance> GetAttendanceHistory(Guid StudentCourse_ID)
    {
        List<StudentAttendance> ls = new List<StudentAttendance>();
        DA da = new DA();
        System.Data.DataTable dtAttendance = da.StudentCourse.GetStudentAttendanceHistory(StudentCourse_ID);

        foreach (System.Data.DataRow dr in dtAttendance.Rows)
        {
            StudentAttendance s = new StudentAttendance();
            s.AttendanceDate = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)dr[0]) + "-" + dr[1].ToString();
            s.TotalClass = dr[2].ToString();
            s.AttendedClass = dr[3].ToString();

            ls.Add(s);
        }
        return ls;
    }

    [AjaxMethod]
    public List<StudentExam> GetExamHistory(Guid StudentCourse_ID)
    {
        List<StudentExam> le = new List<StudentExam>();
        DA da = new DA();
        System.Data.DataTable dtExam = da.StudentCourse.GetStudentExamHistory(StudentCourse_ID);

        foreach (System.Data.DataRow dr in dtExam.Rows)
        {
            StudentExam s = new StudentExam();
            s.ExamDate = ((DateTime)dr[0]).ToString(EngineVariable.LibraryVariable.Format_Date);
            s.ExamScore = ((decimal)dr[1]).ToString(EngineVariable.LibraryVariable.Format_Number);
            s.IsFinal = ((bool)dr[2]) ? "Final" : "";

            le.Add(s);
        }
        
        return le;
    }
    

    [AjaxMethod]
    public ErrorCodes[] SaveStudentCourse(StudentCourseDetailMinimalizedEntity ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        ActionLog log = WebLib.CreateLog((ett.StudentCourse_ID == Guid.Empty ? "Create" : "Modify") + " Student Course.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            StudentCourseRow dr;
            if (ett.StudentCourse_ID == Guid.Empty)
            {
                dr = new StudentCourseTable().NewStudentCourseRow();
                ett.StudentCourse_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.StudentCourse_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.StudentCourse_ID = Guid.NewGuid();
            }
            else
            {
                dr = da.StudentCourse.GetByStudentCourse_ID(ett.StudentCourse_ID);
                ett.StudentCourse_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.StudentCourse_UpdatedDate = DateTime.Now;
            }

            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                ett.CopyTo(dr);
                da.StudentCourse.Update(dr,log);

                //if(ett.Coaching_UserAccount_ID.Value == Guid.Empty)
                //{
                //  CoachingTable coachingTbl =   da.Coaching.GetByStudentCourse_ID(dr.StudentCourse_ID);
                //    if(coachingTbl.Rows.Count > 0)
                //    {
                //        coachingTbl.GetCoachingRow(0).Coaching_IsDeleted = true;
                //        da.Coaching.Update(coachingTbl.GetCoachingRow(0));
                //    }
                //}else
                //{
                //    CoachingTable coachingTbl = da.Coaching.GetByStudentCourse_ID(dr.StudentCourse_ID);
                //    if (coachingTbl.Rows.Count > 0)
                //    {
                //        coachingTbl.GetCoachingRow(0).UserAccount_ID = ett.Coaching_UserAccount_ID.Value;
                //        coachingTbl.GetCoachingRow(0).Coaching_Remark = ett.Coaching_Remark;
                //        coachingTbl.GetCoachingRow(0).Coaching_Description = ett.Coaching_Description;
                //        da.Coaching.Update(coachingTbl.GetCoachingRow(0));
                //    }
                //    else
                //    {
                //        CoachingRow r = new CoachingTable().NewCoachingRow();
                //        r.Coaching_CreatedBy = WebLib.LoggedInUser.UserName;
                //        r.Coaching_UpdatedBy = WebLib.LoggedInUser.UserName;
                //       r.Coaching_Remark = ett.Coaching_Remark;
                //        r.Coaching_Description = ett.Coaching_Description;
                //        r.Coaching_Status = short.Parse(EngineVariable.CoachingStatusType.Open.Code.ToString());
                //        r.Coaching_ID = Guid.NewGuid();
                //        r.UserAccount_ID = ett.Coaching_UserAccount_ID.Value;
                //        r.StudentCourse_ID = dr.StudentCourse_ID;
                //        da.Coaching.Update(r);
                //    }
                //}
            }
        }

        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes[] SaveCoaching(StudentCourseDetailMinimalizedEntity ett)
    {
        ActionLog log = WebLib.CreateLog("Save Coaching.");
        List<ErrorCodes> errs = new List<ErrorCodes>();
        if (errs.Count == 0)
        {
            DA da = new DA();
            //if (ett.Coaching_UserAccount_ID.Value == Guid.Empty)
            //{
            //    CoachingTable coachingTbl = da.Coaching.GetByStudentCourse_ID(ett.StudentCourse_ID);
            //    if (coachingTbl.Rows.Count > 0)
            //    {
            //        coachingTbl.GetCoachingRow(0).Coaching_IsDeleted = true;
            //        da.Coaching.Update(coachingTbl.GetCoachingRow(0),log);
            //    }
            //}
            //else
            //{
            //    CoachingTable coachingTbl = da.Coaching.GetByStudentCourse_ID(ett.StudentCourse_ID);
            //    if (coachingTbl.Rows.Count > 0)
            //    {
            //        coachingTbl.GetCoachingRow(0).UserAccount_ID = ett.Coaching_UserAccount_ID.Value;
            //        coachingTbl.GetCoachingRow(0).Coaching_Remark = ett.Coaching_Remark;
            //        coachingTbl.GetCoachingRow(0).Coaching_Description = ett.Coaching_Description;
            //        coachingTbl.GetCoachingRow(0).Coaching_IsDeleted = false;
            //        da.Coaching.Update(coachingTbl.GetCoachingRow(0),log);
            //    }
            //    else
            //    {
            //        CoachingRow r = new CoachingTable().NewCoachingRow();
            //        r.Coaching_CreatedBy = WebLib.LoggedInUser.UserName;
            //        r.Coaching_UpdatedBy = WebLib.LoggedInUser.UserName;
            //        r.Coaching_Remark = ett.Coaching_Remark;
            //        r.Coaching_Description = ett.Coaching_Description;
            //        r.Coaching_Status = short.Parse(EngineVariable.CoachingStatusType.Open.Code.ToString());
            //        r.Coaching_ID = Guid.NewGuid();
            //        r.UserAccount_ID = ett.Coaching_UserAccount_ID.Value;
            //        r.StudentCourse_ID = ett.StudentCourse_ID;
            //        da.Coaching.Update(r,log);
            //    }
            //}
            CoachingRow r = new CoachingTable().NewCoachingRow();
            r.Coaching_CreatedBy = WebLib.LoggedInUser.UserName;
            r.Coaching_UpdatedBy = WebLib.LoggedInUser.UserName;
            r.Coaching_Remark = ett.Coaching_Remark;
            r.Coaching_Description = ett.Coaching_Description;
            r.Coaching_Status = short.Parse(EngineVariable.CoachingStatusType.Open.Code.ToString());
            r.Coaching_ID = Guid.NewGuid();
            r.UserAccount_ID = ett.Coaching_UserAccount_ID.Value;
            r.StudentCourse_ID = ett.StudentCourse_ID;
            da.Coaching.Update(r, log);
        }
        log.Save();
        return errs.ToArray();
    }


    [AjaxMethod]
    public List<StudentCourseAttachmentMinimalizedEntity> GetAttachmentList(Guid StudentCourse_ID)
    {
        
        List<StudentCourseAttachmentMinimalizedEntity> lis = new List<StudentCourseAttachmentMinimalizedEntity>();
        DA da = new DA();
        StudentCourseAttachmentTable dt = da.StudentCourseAttachment.GetBy(StudentCourse_ID);

        foreach (StudentCourseAttachmentRow dr in dt.Rows)
        {
            StudentCourseAttachmentMinimalizedEntity l = new StudentCourseAttachmentMinimalizedEntity(dr);
            lis.Add(l);
        }
        return lis;
    }


    [AjaxMethod]
    public ErrorCodes VerifyTerminatedStudent(Guid id)
    {
        DA da = new DA();
        StudentCourseRow dr = da.StudentCourse.GetByStudentCourse_ID(id);
        if (dr.StudentCourse_Status.ToString() == "3") return ErrorCodes.StudentCourse_Terminated;
        else return ErrorCodes.GEN_NoError;
    }
    [AjaxMethod]
    public ErrorCodes TerminateStudent(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Terminate Student.");
        StudentCourseRow dr = da.StudentCourse.GetByStudentCourse_ID(id);
        if (dr != null)
        {
            dr.StudentCourse_Status = Int16.Parse("3");
            da.StudentCourse.Update(dr,log);
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
                string SubjectCode = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 2] as ExcelRange).Value);
                string AttendanceMonth = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 3] as ExcelRange).Value);
                string TotalClasses = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 4] as ExcelRange).Value);
                string Attendance = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 5] as ExcelRange).Value);
                string ExamDate = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 6] as ExcelRange).Value);
                string ExamScore = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 7] as ExcelRange).Value);
                string IsFinal = LibraryCommon.GetExcelValue((w.Cells[RowNumber, 8] as ExcelRange).Value);

                StudentCourseProgressTable dtStudentCourseProgress = new StudentCourseProgressTable();

                if (IdentificationNumber == "" && SubjectCode == "")
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
                    if (SubjectCode == "")
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Missing Subject Code. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    
                    //Check Data Validity
                    StudentCourseRow drStudentCourse = da.StudentCourse.Get(IdentificationNumber, EngineVariable.ApplicationOverallStatusType.Active, SubjectCode);
                    if (drStudentCourse == null)
                    {
                        errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Invalid Student Record Or Course Subject. IC - " + IdentificationNumber));
                        RowHasError = true;
                    }
                    else
                    {
                        if (AttendanceMonth != "" && TotalClasses != "")
                        {
                            DateTime? CandidateAttendanceMonth = LibraryCommon.ConvertMonthYear(AttendanceMonth);
                            int CandidateTotalClass = LibraryCommon.ConvertInteger(TotalClasses);
                            int CandidateAttendance = LibraryCommon.ConvertInteger(Attendance);

                            if (!CandidateAttendanceMonth.HasValue)
                            {
                                errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Invalid Candidate Result Date. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }

                            if (!RowHasError)
                            {
                                StudentCourseProgressRow drStudentCourseProgress = dtStudentCourseProgress.NewStudentCourseProgressRow();

                                drStudentCourseProgress.StudentCourseProgress_ID = Guid.NewGuid();
                                drStudentCourseProgress.StudentCourseProgress_CreatedDate = DateTime.Now;
                                drStudentCourseProgress.StudentCourseProgress_UpdatedDate = DateTime.Now;
                                drStudentCourseProgress.StudentCourseProgress_CreatedBy = WebLib.LoggedInUser.UserName;
                                drStudentCourseProgress.StudentCourseProgress_UpdatedBy = WebLib.LoggedInUser.UserName;
                                drStudentCourseProgress.StudentCourseProgress_Description = "";
                                drStudentCourseProgress.StudentCourseProgress_Type = (short)EngineVariable.StudentCourseProgressType.Attendance;
                                drStudentCourseProgress.StudentCourseProgress_Remark = "";
                                drStudentCourseProgress.StudentCourseProgress_Date = CandidateAttendanceMonth.Value;
                                drStudentCourseProgress.StudentCourseProgress_IsDeleted = false;
                                drStudentCourseProgress.StudentCourse_ID = drStudentCourse.StudentCourse_ID;
                                drStudentCourseProgress.StudentCourseProgress_TotalClass = CandidateTotalClass;
                                drStudentCourseProgress.StudentCourseProgress_AttendedClass = CandidateAttendance;
                                drStudentCourseProgress.StudentCourseProgress_ExamIsFinal = false;
                                drStudentCourseProgress.StudentCourseProgress_ExamScore = 0;

                                da.StudentCourseProgress.Update(dtStudentCourseProgress, null);

                                if (drStudentCourse.StudentCourse_Status == (short)EngineVariable.StudentCourseStatusType.Inactive)
                                {
                                    drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Active;
                                    da.StudentCourse.Update(drStudentCourse, null);
                                }
                            }
                        }

                        if (ExamDate != "" && ExamScore != "")
                        {
                            DateTime? CandidateExamDate = LibraryCommon.ConvertDate(ExamDate);
                            decimal CandidateExamScore = LibraryCommon.ConvertDecimal(ExamScore);
                            bool CandidateIsFinal = false;

                            if (CandidateExamDate == null)
                            {
                                errs.Add(new ErrorCodes("InvalidRequiredField", "Row " + RowNumber.ToString() + ": Invalid Candidate Exam Date. IC - " + IdentificationNumber));
                                RowHasError = true;
                            }

                            if (IsFinal.ToUpper() == "Y")
                                CandidateIsFinal = true;

                            if (!RowHasError)
                            {
                                StudentCourseProgressRow drStudentCourseProgress = dtStudentCourseProgress.NewStudentCourseProgressRow();

                                drStudentCourseProgress.StudentCourseProgress_ID = Guid.NewGuid();
                                drStudentCourseProgress.StudentCourseProgress_CreatedDate = DateTime.Now;
                                drStudentCourseProgress.StudentCourseProgress_UpdatedDate = DateTime.Now;
                                drStudentCourseProgress.StudentCourseProgress_CreatedBy = WebLib.LoggedInUser.UserName;
                                drStudentCourseProgress.StudentCourseProgress_UpdatedBy = WebLib.LoggedInUser.UserName;
                                drStudentCourseProgress.StudentCourseProgress_Description = "";
                                drStudentCourseProgress.StudentCourseProgress_Type = (short)EngineVariable.StudentCourseProgressType.Exam;
                                drStudentCourseProgress.StudentCourseProgress_Remark = "";
                                drStudentCourseProgress.StudentCourseProgress_Date = new DateTime(CandidateExamDate.Value.Year, CandidateExamDate.Value.Month, CandidateExamDate.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                                drStudentCourseProgress.StudentCourseProgress_IsDeleted = false;
                                drStudentCourseProgress.StudentCourse_ID = drStudentCourse.StudentCourse_ID;
                                drStudentCourseProgress.StudentCourseProgress_TotalClass = 0;
                                drStudentCourseProgress.StudentCourseProgress_AttendedClass = 0;
                                drStudentCourseProgress.StudentCourseProgress_ExamIsFinal = CandidateIsFinal;
                                drStudentCourseProgress.StudentCourseProgress_ExamScore = CandidateExamScore;

                                if (drStudentCourse.StudentCourse_Status == (short)EngineVariable.StudentCourseStatusType.Inactive)
                                {
                                    drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Active;
                                    da.StudentCourse.Update(drStudentCourse, null);
                                }

                                if (CandidateIsFinal) //Check if need to recreate a new Student Progress Row
                                {
                                    if (CandidateExamScore < EngineVariable.LibraryVariable.MinimumExamPassingMark)
                                        drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Failed;
                                    else
                                        drStudentCourse.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Completed;

                                    da.StudentCourse.Update(drStudentCourse, null);

                                    if (drStudentCourse.StudentCourse_Status == (short)EngineVariable.StudentCourseStatusType.Failed)
                                    {
                                        StudentCourseRow r = new StudentCourseTable().NewStudentCourseRow();

                                        r.StudentCourse_ID = Guid.NewGuid();
                                        r.Student_ID = drStudentCourse.Student_ID;
                                        r.CourseSubject_ID = drStudentCourse.CourseSubject_ID;
                                        r.StudentCourse_Status = (short)EngineVariable.StudentCourseStatusType.Inactive;
                                        r.StudentCourse_CreatedDate = DateTime.Now;
                                        r.StudentCourse_UpdatedDate = DateTime.Now;
                                        r.StudentCourse_CreatedBy = WebLib.LoggedInUser.UserName;
                                        r.StudentCourse_UpdatedBy = WebLib.LoggedInUser.UserName;
                                        r.StudentCourse_Remark = "";
                                        r.StudentCourse_DefermentReason = "";

                                        da.StudentCourse.Update(r, null);
                                    }
                                    else
                                    {
                                        StudentCourseTable dt = da.StudentCourse.Get_RemainingSubject(drStudentCourse.Student_ID);
                                        if (dt.Rows.Count == 0)
                                        {
                                            StudentRow drStudent = da.Student.GetByStudent_ID(drStudentCourse.Student_ID);
                                            ApplicationRow drApplication = da.Application.GetByApplication_ID(drStudent.Application_ID);

                                            drApplication.Application_OverallStatus = (short)EngineVariable.ApplicationOverallStatusType.Completed;
                                            da.Application.Update(drApplication, null);

                                            drStudent.Student_Status = (short)EngineVariable.StudentStatusType.Completed;
                                            da.Student.Update(drStudent, null);
                                        }
                                    }
                                }

                                da.StudentCourseProgress.Update(dtStudentCourseProgress, null);
                            }
                        }
                    }
                }
                RowNumber += 1;
            }
        }
        ActionLog log = WebLib.CreateLog("Import Student Progress.");
        log.Save();
        return errs.ToArray();
    }

    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }
    [AjaxMethod]
    public ErrorCodes VerifyName(string name)
    {
        if (String.IsNullOrEmpty(name)) return ErrorCodes.StudentCourseAttachment_Name;
        else
        {
            return ErrorCodes.GEN_NoError;
        }
    }

    [AjaxMethod]
    public ErrorCodes VerifyAttachment(UploadedFile attachment, string originalfilename)
    {
        if (attachment == null && String.IsNullOrEmpty(originalfilename)) return ErrorCodes.StudentCourseAttachment_Attachment;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public AttachmentDialogData NewAttachment(Guid StudentCourse_ID)
    {
        AttachmentDialogData data = new AttachmentDialogData();

       data.Entity = new StudentCourseAttachmentMinimalizedEntity();
        data.Entity.StudentCourse_ID = StudentCourse_ID;
        return data;

        //CourseDialogData ret = new CourseDialogData();

        //CourseRow dr = new CourseTable().NewCourseRow();
        //ret.Entity = new CourseMinimalizedEntity(dr);

        //ret.TSP = GetTSP();
        //ret.SelectedTSP = new List<string>();
        //return ret;
    }
    [AjaxMethod]
    public AttachmentDialogData GetAttachment(Guid id)
    {
        AttachmentDialogData data = new AttachmentDialogData();
        DA da = new DA();
        StudentCourseAttachmentRow dr = da.StudentCourseAttachment.GetByStudentCourseAttachment_ID(id);
        if (dr == null) return null;
        else
        {


            data.Entity = new StudentCourseAttachmentMinimalizedEntity(dr);



            return data;
        }
    }


    [AjaxMethod]
    public ErrorCodes[] SaveAttachment(AttachmentDialogData ett)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        AddError(errs, VerifyName(ett.Entity.StudentCourseAttachment_Name));
        AddError(errs, VerifyAttachment(ett.Attachment, ett.Entity.StudentCourseAttachment_OriginalFileName));
        //AddError(errs, VerifyModDate(ett.Entity.ModifiedDate));
        ActionLog log = WebLib.CreateLog((ett.Entity.StudentCourseAttachment_ID == Guid.Empty ? "Create" : "Modify") + " Attachment.");
        if (errs.Count == 0)
        {
            DA da = new DA();
            StudentCourseAttachmentRow dr;
            if (ett.Entity.StudentCourseAttachment_ID == Guid.Empty)
            {
                dr = new StudentCourseAttachmentTable().NewStudentCourseAttachmentRow();
                ett.Entity.StudentCourseAttachment_CreatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.StudentCourseAttachment_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.StudentCourseAttachment_ID = Guid.NewGuid();
                ett.Entity.StudentCourseAttachment_OriginalFileName = "";
                ett.Entity.StudentCourseAttachment_PhysicalFileName = "";
                dr.StudentCourseAttachment_CreatedDate = DateTime.Now;

            }
            else
            {
                dr = da.StudentCourseAttachment.GetByStudentCourseAttachment_ID(ett.Entity.StudentCourseAttachment_ID);
                ett.Entity.StudentCourseAttachment_UpdatedBy = WebLib.LoggedInUser.UserName;
                ett.Entity.StudentCourseAttachment_UpdatedDate = DateTime.Now;
            }

    
            if (dr == null) errs.Add(ErrorCodes.GEN_RecordNotFound);
            else
            {
                string folderPath = ConfigurationManager.AppSettings["StudentCourseAttachmentFolder"];
                string defaultSavePath = folderPath + "\\" + ett.Entity.StudentCourseAttachment_ID;
                Directory.CreateDirectory(defaultSavePath);

                if (ett.Attachment != null)
                {
                    string ext = Path.GetExtension(ett.Attachment.OriginalName);
                    //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                    string filename = ett.Attachment.TemporaryName + ext;
                    string savePath = defaultSavePath + "\\" + filename;
                    //if (File.Exists(oldPath)) File.Delete(oldPath);
                    ett.Entity.StudentCourseAttachment_OriginalFileName = ett.Attachment.OriginalName;
                    ett.Entity.StudentCourseAttachment_PhysicalFileName = filename;
                    File.Move(AjaxLib.FileUploadTempPath + ett.Attachment.TemporaryName, savePath);
                }


                ett.Entity.CopyTo(dr);
                da.StudentCourseAttachment.Update(dr,log);
            }
        }
        log.Save();
        return errs.ToArray();
    }

    [AjaxMethod]
    public ErrorCodes DeleteAttachment(Guid id)
    {
        DA da = new DA();
        ActionLog log = WebLib.CreateLog("Delete Attachment For Student Progress.");
        //da.Member.DeleteByCardNumber(cardNo);
        StudentCourseAttachmentRow dr = da.StudentCourseAttachment.GetByStudentCourseAttachment_ID(id);
        if (dr != null)
        {
            dr.StudentCourseAttachment_IsDeleted = true;
            da.StudentCourseAttachment.Update(dr,log);
        }
        log.Save();
        return ErrorCodes.GEN_NoError;
    }
}

public class ImportData
{
    public Teq.UploadedFile UploadFile = new Teq.UploadedFile();
}

public class AttachmentDialogData
{
    public StudentCourseAttachmentMinimalizedEntity Entity;
    public UploadedFile Attachment;
}

public class StudentAttendance
{
    public string AttendanceDate;
    public string TotalClass;
    public string AttendedClass;
}

public class StudentExam
{
    public string ExamDate;
    public string ExamScore;
    public string IsFinal;
}