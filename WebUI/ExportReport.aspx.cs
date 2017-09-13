using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EngineData;
using Teq.Data;
using OfficeOpenXml;

public partial class ExportReport : System.Web.UI.Page
{
    DataTable dt = null;
    public string ReportName
    {
        get
        {
            if (Request.QueryString["ReportName"] != null)
            {
                return Request.QueryString["ReportName"].ToString();
            }
            return "";
        }
    }
    public string ImgURL
    {
        get
        {
            if (Request.QueryString["ImgURL"] != null)
            {
                return Request.QueryString["ImgURL"].ToString();
            }
            return "";
        }
    }
    public string ExtraStr
    {
        get
        {
            if (Request.QueryString["ExtraStr"] != null)
            {
                return Request.QueryString["ExtraStr"].ToString();
            }
            return "";
        }
    }
    public string ReportType
    {
        get
        {
            if (Request.QueryString["ReportType"] != null)
            {
                return Request.QueryString["ReportType"].ToString();
            }
            return "";
        }
    }
    Type[] NUMERIC_TYPES = new[] { typeof(Byte), typeof(Decimal), typeof(Double),
        typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte),
        typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64)};

    protected void Page_Load(object sender, EventArgs e)
    {
        string tblName = "";
        
        if(!ReportName.Equals(""))
        {
            #region Report 01: RptStudentIntakeSummary
            if (ReportName.Equals("RptStudentIntakeSummary"))
            {
                tblName = "Student Intake Summary Report";
                Title = tblName;

                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];
                    
                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 02: RptActiveStudentSummary
            if (ReportName.Equals("RptStudentDefermentSummary"))
            {
                tblName = "Student Deferment Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 03: RptStudentWithdrawalSummary
            if (ReportName.Equals("RptStudentWithdrawalSummary"))
            {
                tblName = "Student Withdrawal Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];


                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 04: RptStudentLocationSummary
            if (ReportName.Equals("RptStudentLocationSummary"))
            {
                tblName = "Student Location Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];
                    

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 05: RptActiveStudentSummary
            if (ReportName.Equals("RptActiveStudentSummary"))
            {
                tblName = "Active Student Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 06: RptCandidateRegistrationMasterList
            if (ReportName.Equals("RptCandidateRegistrationMasterList"))
            {
                tblName = "Candidate Registration Master List";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptCandidateRegistrationMasterListTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["UserID"].ColumnName = "User ID";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DOB"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["ICNumber"].ColumnName = "IC Number";
                    dt.Columns["CurrentlyEmployed"].ColumnName = "Currently Employed";
                    dt.Columns["EducationLevel1"].ColumnName = "Education Level 1";
                    dt.Columns["FieldOfStudy1"].ColumnName = "Field Of Study 1";
                    dt.Columns["EducationLevel2"].ColumnName = "Education Level 2";
                    dt.Columns["FieldOfStudy2"].ColumnName = "Field Of Study 2";
                    dt.Columns["EducationLevel3"].ColumnName = "Education Level 3";
                    dt.Columns["FieldOfStudy3"].ColumnName = "Field Of Study 3";
                    dt.Columns["EducationLevel4"].ColumnName = "Education Level 4";
                    dt.Columns["FieldOfStudy4"].ColumnName = "Field Of Study 4";
                    dt.Columns["EducationLevel5"].ColumnName = "Education Level 5";
                    dt.Columns["FieldOfStudy5"].ColumnName = "Field Of Study 5";
                    dt.Columns["CurrentlyPursuingHighestLevel"].ColumnName = "Currently Pursuing Highest Level";
                    dt.Columns["HighestEducation"].ColumnName = "Highest Education";
                    dt.Columns["Address1"].ColumnName = "Address 1";
                    dt.Columns["Address2"].ColumnName = "Address 2";
                    dt.Columns["City"].ColumnName = "City";
                    dt.Columns["Country"].ColumnName = "Country";
                    //dt.Columns["PhonePrefix"].ColumnName = "Phone Prefix";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    //dt.Columns["MobilePhonePrefix"].ColumnName = "Mobile Phone Prefix";
                    dt.Columns["Mobile"].ColumnName = "Mobile Phone Number";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["BankName"].ColumnName = "Bank Name";
                    dt.Columns["BankAccountNumber"].ColumnName = "Bank Account Number";
                    dt.Columns["EmergencyContactName1"].ColumnName = "Emergency Contact 1";
                    dt.Columns["EmergencyContactNumber1"].ColumnName = "Emergency Contact 1 Number";
                    dt.Columns["EmergencyContactNumber1Alternative"].ColumnName = "Emergency Contact 1 Alternative Number";
                    dt.Columns["EmergencyContactRelationship1"].ColumnName = "Emergency Contact 1 Relationship";
                    dt.Columns["EmergencyContactName2"].ColumnName = "Emergency Contact 2";
                    dt.Columns["EmergencyContactNumber2"].ColumnName = "Emergency Contact 2 Number";
                    dt.Columns["EmergencyContactNumber2Alternative"].ColumnName = "Emergency Contact 2 Alternative Number";
                    dt.Columns["EmergencyContactRelationship2"].ColumnName = "Emergency Contact 2 Relationship";
                    dt.Columns["FatherGuardianName"].ColumnName = "Guardian 1 Name";
                    dt.Columns["FatherGuardianIC"].ColumnName = "Guardian 1 IC";
                    dt.Columns["FatherGuardianTypeOfOccupation"].ColumnName = "Guardian 1 Occupation";
                    dt.Columns["FatherGuardianEmployerName"].ColumnName = "Guardian 1 Employer Name";
                    dt.Columns["MotherGuardianName"].ColumnName = "Guardian 2 Name";
                    dt.Columns["MotherGuardianIC"].ColumnName = "Guardian 2 IC";
                    dt.Columns["MotherGuardianTypeOfOccupation"].ColumnName = "Guardian 2 Occupation";
                    dt.Columns["MotherGuardianEmployerName"].ColumnName = "Guardian 2 Employer Name";
                    dt.Columns["CreatedDate"].ColumnName = "Created Date";
                    dt.Columns["CreatedBy"].ColumnName = "Created By";
                    dt.Columns["UpdatedDate"].ColumnName = "Updated Date";
                    dt.Columns["UpdatedBy"].ColumnName = "Updated By";
                    dt.Columns["Postcode"].ColumnName = "Postcode";
                    dt.Columns["State"].ColumnName = "State";
                    dt.Columns["Nationality"].ColumnName = "Nationality";
                    dt.Columns["IsBumiputra"].ColumnName = "Is Bumiputra";
                    dt.Columns["Remark"].ColumnName = "Remark";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 07: RptCandidateApplicationMasterList
            if (ReportName.Equals("RptCandidateApplicationMasterList"))
            {
                tblName = "Candidate Application Master List";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptCandidateApplicationMasterListTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["Date"].ColumnName = "Date";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DOB"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["Nationality"].ColumnName = "Nationality";
                    dt.Columns["ICNumber"].ColumnName = "IC Number";
                    dt.Columns["Address1"].ColumnName = "Address 1";
                    dt.Columns["Address2"].ColumnName = "Address 2";
                    dt.Columns["Postcode"].ColumnName = "Postcode";
                    dt.Columns["City"].ColumnName = "City";
                    dt.Columns["State"].ColumnName = "State";
                    dt.Columns["Country"].ColumnName = "Country";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["FatherName"].ColumnName = "Father Name";
                    dt.Columns["FatherIdentification"].ColumnName = "Father IC";
                    dt.Columns["MotherName"].ColumnName = "Mother Name";
                    dt.Columns["MotherIdentification"].ColumnName = "Mother IC";
                    dt.Columns["CombinedHouseholdIncome"].ColumnName = "Combined Household Income";
                    dt.Columns["CurrentFieldOfStudy"].ColumnName = "Current Field Of Study";
                    dt.Columns["University"].ColumnName = "University";
                    dt.Columns["CGPA"].ColumnName = "CGPA";
                    dt.Columns["PQQualification"].ColumnName = "Has PQ Qualification";
                    dt.Columns["PGRegistrationNumber"].ColumnName = "PG Registration Number";
                    dt.Columns["PQStartDate"].ColumnName = "PQ Start Date";
                    dt.Columns["PQLevelStart"].ColumnName = "PQ Level Start";
                    dt.Columns["PQDeadline"].ColumnName = "PQ Deadline";
                    dt.Columns["RegisteredNextExam"].ColumnName = "Registered Next Exam";
                    dt.Columns["NextExamSession"].ColumnName = "Next Exam Session";
                    dt.Columns["ContractType"].ColumnName = "Contract Type";
                    dt.Columns["ScholarshipProvider"].ColumnName = "Scholarship Provider";
                    dt.Columns["ScholarshipCost"].ColumnName = "Scholarship Cost";
                    dt.Columns["Status"].ColumnName = "Status";
                    dt.Columns["CreatedDate"].ColumnName = "Created Date";
                    dt.Columns["CreatedBy"].ColumnName = "Created By";
                    dt.Columns["UpdatedDate"].ColumnName = "Updated Date";
                    dt.Columns["UpdatedBy"].ColumnName = "Updated By";
                    dt.Columns["SubmittedDate"].ColumnName = "Submitted Date";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    dt.Columns["Mobile"].ColumnName = "Mobile Phone Number";
                    dt.Columns["LOIssueDate"].ColumnName = "LO Issue Date";
                    dt.Columns["CampusName"].ColumnName = "Campus Name";
                    dt.Columns["CampusCity"].ColumnName = "Campus City";
                    dt.Columns["Sponsor"].ColumnName = "Sponsor";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 08: RptCandidateAssessmentResultMasterList
            if (ReportName.Equals("RptCandidateAssessmentResultMasterList"))
            {
                tblName = "Candidate Assessment Result Master List";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptCandidateAssessmentResultMasterListTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["EnrollmentDate"].ColumnName = "Enrollment Date";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DOB"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["ICNumber"].ColumnName = "IC Number";
                    dt.Columns["Nationality"].ColumnName = "Nationality";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    dt.Columns["Mobile"].ColumnName = "Mobile Phone Number";
                    dt.Columns["CampusName"].ColumnName = "Campus Name";
                    dt.Columns["CampusCity"].ColumnName = "Campus City";
                    dt.Columns["ContractType"].ColumnName = "Contract Type";
                    dt.Columns["Sponsor"].ColumnName = "Sponsor";
                    dt.Columns["TechnicalAssessment"].ColumnName = "Technical Assessment";
                    dt.Columns["EnglishFoundation"].ColumnName = "English Foundation";
                    dt.Columns["Listening"].ColumnName = "Listening";
                    dt.Columns["Writing"].ColumnName = "Writing";
                    dt.Columns["Speaking"].ColumnName = "Speaking";
                    dt.Columns["Reading"].ColumnName = "Reading";
                    dt.Columns["Interview"].ColumnName = "Interview";
                    dt.Columns["Status"].ColumnName = "Status";
                    dt.Columns["Sponsor"].ColumnName = "Sponsor";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 09: RptPartTimerAssessmentResultMasterList
            if (ReportName.Equals("RptPartTimerAssessmentResultMasterList"))
            {
                tblName = "Part-Timer Assessment Result Master List";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptPartTimerAssessmentResultMasterListTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["EnrollmentDate"].ColumnName = "Enrollment Date";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DOB"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["ICNumber"].ColumnName = "IC Number";
                    dt.Columns["Nationality"].ColumnName = "Nationality";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    dt.Columns["Mobile"].ColumnName = "Mobile Phone Number";
                    dt.Columns["CampusName"].ColumnName = "Campus Name";
                    dt.Columns["CampusCity"].ColumnName = "Campus City";
                    dt.Columns["ContractType"].ColumnName = "Contract Type";
                    dt.Columns["Assessment1"].ColumnName = "Assessment 1";
                    dt.Columns["Assessment2"].ColumnName = "Assessment 2";
                    dt.Columns["Assessment3"].ColumnName = "Assessment 3";
                    dt.Columns["Status"].ColumnName = "Status";
                    dt.Columns["Sponsor"].ColumnName = "Sponsor";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 10: RptStudentProgressSummaryMasterList
            if (ReportName.Equals("RptStudentProgressSummaryMasterList"))
            {
                tblName = "Student Progress Summary Master List";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptStudentProgressSummaryMasterListTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["EnrollmentDate"].ColumnName = "Enrollment Date";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DOB"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["ICNumber"].ColumnName = "IC Number";
                    dt.Columns["Nationality"].ColumnName = "Nationality";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    dt.Columns["Mobile"].ColumnName = "Mobile Phone Number";
                    dt.Columns["CampusName"].ColumnName = "Campus Name";
                    dt.Columns["CampusCity"].ColumnName = "Campus City";
                    dt.Columns["ContractType"].ColumnName = "Contract Type";
                    dt.Columns["Sponsor"].ColumnName = "Sponsor";
                    dt.Columns["CompletedSubject"].ColumnName = "Completed Subject";
                    dt.Columns["CurrentSubject"].ColumnName = "Current Subject";
                    dt.Columns["RemainingSubject"].ColumnName = "Remaining Subject";
                    dt.Columns["SubjectProgress"].ColumnName = "Subject Progress";
                    dt.Columns["Course"].ColumnName = "Course";
                    dt.Columns["ContractExpiredDate"].ColumnName = "Contract Expired Date";
                    dt.Columns["ContractRemainingMonth"].ColumnName = "Contract Remaining Period (Month)";


                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 11: RptAlumniVoluntaryHourSummary
            if (ReportName.Equals("RptAlumniVoluntaryHourSummary"))
            {
                tblName = "Alumni Voluntary Hour Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptAlumniVoluntaryHourSummaryTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["DateofBirth"].ColumnName = "DOB";
                    dt.Columns["Gender"].ColumnName = "Gender";
                    dt.Columns["ICNumber"].ColumnName = "Identification Number";
                    dt.Columns["Email"].ColumnName = "Email";
                    dt.Columns["PhoneNumber"].ColumnName = "Phone Number";
                    dt.Columns["Mobile"].ColumnName = "Mobile Number";
                    dt.Columns["EnrollmentDate"].ColumnName = "Enrollment Date";
                    dt.Columns["CampusName"].ColumnName = "Campus Name";
                    dt.Columns["CampusCity"].ColumnName = "Campus City";
                    dt.Columns["ContractType"].ColumnName = "Contract Type";
                    dt.Columns["TotalWorkHour"].ColumnName = "Total Work Hour";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 12: RptSuccessRateSummary
            if (ReportName.Equals("RptSuccessRateSummary"))
            {
                tblName = "Candidate Success Rate Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    dt.Columns.Remove("IntakeMonth");
                    dt.Columns.Remove("IntakeYear");

                    dt.AcceptChanges();
                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 13: RptAttendanceAnalysis
            if (ReportName.Equals("RptAttendanceAnalysis"))
            {
                tblName = "Student Attendance Analysis Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = ((PagedDataList<RptAttendanceAnalysisTable>)HttpContext.Current.Session[ReportName]).DataTable;

                    dt.Columns.Remove("IntakeMonth");
                    dt.Columns.Remove("IntakeYear");

                    dt.Columns["IntakeDate"].ColumnName = "Intake / Cohort";
                    dt.Columns["FullName"].ColumnName = "Full Name";
                    dt.Columns["ICNo"].ColumnName = "Identification Number";
                    dt.Columns["TotalClass"].ColumnName = "Total Class";
                    dt.Columns["AttendedClass"].ColumnName = "Attended Class";
                    dt.Columns["AttendanceRate"].ColumnName = "Attendance Rate";
                    dt.Columns["FinalResult"].ColumnName = "Final Result";

                    dt.AcceptChanges();

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 14: RptExamAnalysis
            if (ReportName.Equals("RptExamAnalysis"))
            {
                tblName = "Student Exam Analysis Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    //dt.Columns.Remove("IntakeMonth");
                    //dt.Columns.Remove("IntakeYear");

                    //dt.AcceptChanges();
                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 15: RptStudentProgressSummary
            if (ReportName.Equals("RptStudentProgressSummary"))
            {
                tblName = "Student Progress Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    DataTable tbl = (DataTable)HttpContext.Current.Session[ReportName];
                    tbl.TableName = tblName;


                    foreach(DataRow dr in tbl.Rows)
                    {
                        foreach(DataColumn dc in tbl.Columns)
                        {
                            dr[dc] = dr[dc].ToString().Replace("<br>", Environment.NewLine);
                        }
                    }

                    #region Special Handle for this report
                    int OFFSET_ROW = 3;
                    int STARTING_ROW_POSITION = 1;
                    int STARTING_COLUMN_POSITION = 3;

                    ExcelPackage p = new ExcelPackage();
                    #region Sheet
                    if (tbl.TableName.Length <= 0) tbl.TableName = "Report";
                    p.Workbook.Worksheets.Add((tbl.TableName.Length > 31 ? tbl.TableName.Substring(0, 31) : tbl.TableName));
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];

                    #endregion
                    #region Heading
                    string mergeTitleCol = "A1:" + ExcelColumnFromNumber(tbl.Columns.Count) + "1";
                    ws.Cells[mergeTitleCol].Merge = true;
                    ws.Cells[mergeTitleCol].Value = tbl.TableName;
                    ws.Cells[mergeTitleCol].Style.Font.Size = 22;
                    ws.Cells[mergeTitleCol].Style.Font.Bold = true;
                    ws.Row(1).Height = 30;
                    ws.Cells[mergeTitleCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[mergeTitleCol].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    #endregion

                    #region Populate From DataTable
                    int rowOccupy = 5;
                    if (tbl.Rows.Count > 0)
                    {
                        ws.Cells[ExcelColumnFromNumber(STARTING_ROW_POSITION) + (rowOccupy).ToString()].LoadFromDataTable(tbl, false);
                    }
                    #endregion

                    #region Header and FormatByColumn
                    //Loop for First Header Row
                    for (int col = 0; col < tbl.Columns.Count; col++)
                    {
                        string cell = ExcelColumnFromNumber(col + 1) + STARTING_COLUMN_POSITION;
                        string celldown = ExcelColumnFromNumber(col +1) + (STARTING_COLUMN_POSITION+1);
                        string cellright = ExcelColumnFromNumber(col + 3) + STARTING_COLUMN_POSITION;

                        if (tbl.Columns[col].ColumnName.IndexOf("-") == -1)
                        {
                            cell = cell + ":" + celldown;

                            ws.Column((col + 1)).AutoFit(5, 75);

                            ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            ws.Cells[cell].Merge = true;
                            ws.Cells[cell].Style.Font.Bold = true;
                            ws.Cells[cell].Value = tbl.Columns[col].ColumnName;
                            ws.Column((col + 1)).Width = tbl.Columns[col].ColumnName.Length + 5;
                        }
                        else {
                            cell = cell + ":" + cellright;

                            ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            ws.Cells[cell].Merge = true;
                            ws.Cells[cell].Style.Font.Bold = true;
                            string colName = tbl.Columns[col].ColumnName.Substring(0, tbl.Columns[col].ColumnName.IndexOf("-")) ;
                            ws.Cells[cell].Value = colName;

                            col = col + 2; //advancing 2 columns
                        }
                    }

                    //Loop for Second Header Row
                    for (int col = 0; col < tbl.Columns.Count; col++)
                    {
                        if(tbl.Columns[col].ColumnName.IndexOf("-") == -1) continue;

                        string cell = ExcelColumnFromNumber(col + 1) + (STARTING_COLUMN_POSITION + 1);

                        ws.Column((col + 1)).AutoFit(5, 75);

                        ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        ws.Cells[cell].Merge = true;
                        ws.Cells[cell].Style.Font.Bold = true;

                        string colName = tbl.Columns[col].ColumnName;
                        colName = colName.Substring(colName.IndexOf("-") + 1);
                        ws.Cells[cell].Value = colName;
                        ws.Column((col + 1)).Width = colName.Length + 5;


                        if (tbl.Columns[col].DataType == typeof(DateTime))
                        {
                            ws.Column(col + 1).Style.Numberformat.Format = "dd-MMM-yyyy, hh:mm AM/PM"; //"DD/MM/YYYY";
                            ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Column(col + 1).Width = 22;
                        }
                        else if (tbl.Columns[col].DataType == typeof(Double))
                        {
                            ws.Column(col + 1).Style.Numberformat.Format = "#,0.00";
                            ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            //ws.Column(col + 1).Width = 22;
                        }
                    }
                    #endregion

                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    Response.Charset = "";
                    Response.AppendHeader("Content-disposition", "attachment; filename=" + tbl.TableName.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
                    p.SaveAs(Response.OutputStream);
                    p.Dispose();
                    #endregion
                }
            }
            #endregion

            #region Report 16: RptSemesterSummary
            if (ReportName.Equals("RptSemesterSummary"))
            {
                tblName = "Semester Summary Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    DataTable tbl = (DataTable)HttpContext.Current.Session[ReportName];
                    tbl.TableName = tblName;

                    #region Special Handle for this report
                    int OFFSET_ROW = 3;
                    int STARTING_ROW_POSITION = 1;
                    int STARTING_COLUMN_POSITION = 3;
                    int mthCount = 0;
                    int testCount = 0;

                    ExcelPackage p = new ExcelPackage();
                    #region Sheet
                    if (tbl.TableName.Length <= 0) tbl.TableName = "Report";
                    p.Workbook.Worksheets.Add((tbl.TableName.Length > 31 ? tbl.TableName.Substring(0, 31) : tbl.TableName));
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];
                    #endregion

                    #region Heading
                    string mergeTitleCol = "A1:" + ExcelColumnFromNumber(tbl.Columns.Count) + "1";
                    ws.Cells[mergeTitleCol].Merge = true;
                    ws.Cells[mergeTitleCol].Value = tbl.TableName;
                    ws.Cells[mergeTitleCol].Style.Font.Size = 22;
                    ws.Cells[mergeTitleCol].Style.Font.Bold = true;
                    ws.Row(1).Height = 30;
                    ws.Cells[mergeTitleCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[mergeTitleCol].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    #endregion

                    #region Populate From DataTable
                    int rowOccupy = 5;
                    if (tbl.Rows.Count > 0)
                    {
                        ws.Cells[ExcelColumnFromNumber(STARTING_ROW_POSITION) + (rowOccupy).ToString()].LoadFromDataTable(tbl, false);
                    }
                    #endregion

                    #region column count for progress month and number of tests
                    for (int col = 0; col < tbl.Columns.Count; col++)
                    {
                        if (tbl.Columns[col].ColumnName.IndexOf("-Attn") != -1)
                        {
                            mthCount++; //check count for Progress Month
                        }
                        if (tbl.Columns[col].ColumnName.IndexOf("-Score") != -1)
                        {
                            testCount++; //check count for number of tests
                        }
                    }
                    #endregion

                    #region Header and FormatByColumn
                    //Loop for First Header Row
                    for (int col = 0; col < tbl.Columns.Count; col++)
                    {
                        string cell = ExcelColumnFromNumber(col + 1) + STARTING_COLUMN_POSITION;
                        string celldown = ExcelColumnFromNumber(col + 1) + (STARTING_COLUMN_POSITION + 1);
                        //string cellright = ExcelColumnFromNumber(col + 3) + STARTING_COLUMN_POSITION;
                        string cellright1 = ExcelColumnFromNumber(col + mthCount) + STARTING_COLUMN_POSITION;
                        string cellright2 = ExcelColumnFromNumber(col + testCount) + STARTING_COLUMN_POSITION;

                        if (tbl.Columns[col].ColumnName.IndexOf("-") == -1)
                        {
                            cell = cell + ":" + celldown;

                            ws.Column((col + 1)).AutoFit(5, 75);

                            ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            ws.Cells[cell].Merge = true;
                            ws.Cells[cell].Style.Font.Bold = true;
                            ws.Cells[cell].Value = tbl.Columns[col].ColumnName;
                            ws.Column((col + 1)).Width = tbl.Columns[col].ColumnName.Length + 5;
                        }
                        else if (tbl.Columns[col].ColumnName.IndexOf("-Attn") != -1)
                        { 
                            cell = cell + ":" + cellright1;

                            ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            ws.Cells[cell].Merge = true;
                            ws.Cells[cell].Style.Font.Bold = true;
                            string colName = "Attendance Rate";
                            ws.Cells[cell].Value = colName;

                            col = col + (mthCount - 1); //advancing columns based on mthCount
                        }
                        else if (tbl.Columns[col].ColumnName.IndexOf("-Score") != -1)
                        {
                            cell = cell + ":" + cellright2;

                            ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            ws.Cells[cell].Merge = true;
                            ws.Cells[cell].Style.Font.Bold = true;
                            string colName = "Test";
                            ws.Cells[cell].Value = colName;

                            col = col + (testCount - 1); //advancing columns based on mthCount
                        }
                    }

                    //Loop for Second Header Row
                    for (int col = 0; col < tbl.Columns.Count; col++)
                    {
                        if (tbl.Columns[col].ColumnName.IndexOf("-") == -1) continue;

                        string cell = ExcelColumnFromNumber(col + 1) + (STARTING_COLUMN_POSITION + 1);

                        ws.Column((col + 1)).AutoFit(5, 75);

                        ws.Cells[cell].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        ws.Cells[cell].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        ws.Cells[cell].Merge = true;
                        ws.Cells[cell].Style.Font.Bold = true;

                        string colName = tbl.Columns[col].ColumnName;
                        if (tbl.Columns[col].ColumnName.IndexOf("-Attn") != -1)
                        {
                            colName = colName.Substring(0, colName.IndexOf("-"));
                        }
                        else if (tbl.Columns[col].ColumnName.IndexOf("-Score") != -1)
                        {
                            colName = colName.Substring(colName.IndexOf("-")-1, 1); //Substring(int startIndex,int length)
                        }
                        
                        ws.Cells[cell].Value = colName;
                        ws.Column((col + 1)).Width = colName.Length + 5;


                        if (tbl.Columns[col].DataType == typeof(DateTime))
                        {
                            ws.Column(col + 1).Style.Numberformat.Format = "dd-MMM-yyyy, hh:mm AM/PM"; //"DD/MM/YYYY";
                            ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Column(col + 1).Width = 22;
                        }
                        else if (tbl.Columns[col].DataType == typeof(Double))
                        {
                            ws.Column(col + 1).Style.Numberformat.Format = "#,0.00";
                            ws.Column(col + 1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            //ws.Column(col + 1).Width = 22;
                        }
                    }
                    #endregion

                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    Response.Charset = "";
                    Response.AppendHeader("Content-disposition", "attachment; filename=" + tbl.TableName.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
                    p.SaveAs(Response.OutputStream);
                    p.Dispose();
                    #endregion
                }
            }
            #endregion

            #region Report 17: RptApplicationOverview
            if (ReportName.Equals("RptApplicationOverview"))
            {
                tblName = "Application Overview Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    SaveToExcel(tblName);
                }
            }
            #endregion

            #region Report 18: RptIntakeBySponsorship
            if (ReportName.Equals("RptIntakeBySponsorship"))
            {
                tblName = "Intake By Sponsorship Report";
                Title = tblName;
                if (HttpContext.Current.Session[ReportName] != null)
                {
                    dt = (DataTable)HttpContext.Current.Session[ReportName];

                    SaveToExcel(tblName);
                }
            }
            #endregion
            
        }
    }

    private void SaveToExcel(string tblName)
    {
        dt.TableName = tblName;
        if (dt.Columns.Contains("RowNum")) dt.Columns.Remove("RowNum");

        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ReadOnly) column.ReadOnly = false;

                if (row[column].Equals(DBNull.Value))
                {
                    //if (IsColumnNumeric(column)) row[column] = "";
                    if (column.DataType == typeof(String)) row[column] = "-";
                }
            }
        }
        ExportExcel ee = new ExportExcel();
        ee.Export(dt, ImgURL.Substring(ImgURL.LastIndexOf("/") + 1), ExtraStr);

        HttpContext.Current.Session[ReportName] = null;
    }


    private bool IsColumnNumeric(DataColumn col)
    {
        if (col == null) return false;
        
        return NUMERIC_TYPES.Contains(col.DataType);
    }
    private void ReplacebrToNextLine(DataColumn col)
    {
        string br = "<br>";
        foreach(DataRow row in dt.Rows)
        {
            string cell = row[col].ToString();
            if (cell.Contains(br))
            {
                row[col] = cell.Replace(br, "\r\n");
            }
        }
    }
    private void FormatTradeName(DataColumn col)
    {
        dt.Columns["Name"].ReadOnly = false;
        foreach (DataRow row in dt.Rows)
        {
            bool isFullySubmit = (bool)row["IsFullySubmit"];
            if (!isFullySubmit) row[col] = row[col] + " (*)";
        }
    }

    private string ExcelColumnFromNumber(int column)
    {
        string columnString = "";
        decimal columnNumber = column;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        return columnString;
    }
    /// <summary>
    /// A -> 1<br/>
    /// B -> 2<br/>
    /// C -> 3<br/>
    /// ...
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    private int NumberFromExcelColumn(string column)
    {
        int retVal = 0;
        string col = column.ToUpper();
        for (int iChar = col.Length - 1; iChar >= 0; iChar--)
        {
            char colPiece = col[iChar];
            int colNum = colPiece - 64;
            retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
        }
        return retVal;
    }
}