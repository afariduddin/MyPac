using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentProgressSummaryDetailTable : DataTable {
// column indexes
public const int Student_IDColumnIndex = 0;
public const int TSP_IDColumnIndex = 1;
public const int Student_SubjectTakenColumnIndex = 2;
public const int Course_IDColumnIndex = 3;
public const int Student_StatusColumnIndex = 4;
public const int Student_RemarkColumnIndex = 5;
public const int Application_IDColumnIndex = 6;
public const int Student_CreatedDateColumnIndex = 7;
public const int Student_UpdatedDateColumnIndex = 8;
public const int Student_CreatedByColumnIndex = 9;
public const int Student_UpdatedByColumnIndex = 10;
public const int Student_EnrollmentDateColumnIndex = 11;
public const int Student_ContractExpiredDateColumnIndex = 12;
public const int TSP_CampusNameColumnIndex = 13;
public const int Application_FullNameColumnIndex = 14;
public const int Application_GenderColumnIndex = 15;
public const int Application_PhonePrefixColumnIndex = 16;
public const int Application_PhoneNumberColumnIndex = 17;
public const int Application_EmailColumnIndex = 18;
public const int CurrentSubjectColumnIndex = 19;
public const int CompletedSubjectColumnIndex = 20;
public const int RemainingSubjectColumnIndex = 21;
public const int Application_ContractTypeColumnIndex = 22;
public const int Application_DOBColumnIndex = 23;
public const int Application_IdentificationNumberColumnIndex = 24;
public const int Application_NationalityColumnIndex = 25;
public const int Application_MobilePhonePrefixColumnIndex = 26;
public const int Application_MobilePhoneNumberColumnIndex = 27;
public const int Application_OverallStatusColumnIndex = 28;
public const int Application_OverallProgressColumnIndex = 29;
public const int WarningLetterCountColumnIndex = 30;
public const int Sponsor_IDColumnIndex = 31;
public const int Sponsor_CodeColumnIndex = 32;
public const int Sponsor_LabelColumnIndex = 33;
public StudentProgressSummaryDetailTable() {
TableName = "[StudentProgressSummaryDetail]";
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = true;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = true;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Student_SubjectTaken
DataColumn Student_SubjectTakenCol = new DataColumn("Student_SubjectTaken", typeof(System.Int32));
Student_SubjectTakenCol.ReadOnly = true;
Student_SubjectTakenCol.AllowDBNull = false;
Columns.Add(Student_SubjectTakenCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Student_Status
DataColumn Student_StatusCol = new DataColumn("Student_Status", typeof(System.Int16));
Student_StatusCol.ReadOnly = true;
Student_StatusCol.AllowDBNull = false;
Columns.Add(Student_StatusCol);
// column Student_Remark
DataColumn Student_RemarkCol = new DataColumn("Student_Remark", typeof(System.String));
Student_RemarkCol.ReadOnly = true;
Student_RemarkCol.AllowDBNull = false;
Columns.Add(Student_RemarkCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = true;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column Student_CreatedDate
DataColumn Student_CreatedDateCol = new DataColumn("Student_CreatedDate", typeof(System.DateTime));
Student_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Student_CreatedDateCol.ReadOnly = true;
Student_CreatedDateCol.AllowDBNull = false;
Columns.Add(Student_CreatedDateCol);
// column Student_UpdatedDate
DataColumn Student_UpdatedDateCol = new DataColumn("Student_UpdatedDate", typeof(System.DateTime));
Student_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Student_UpdatedDateCol.ReadOnly = true;
Student_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Student_UpdatedDateCol);
// column Student_CreatedBy
DataColumn Student_CreatedByCol = new DataColumn("Student_CreatedBy", typeof(System.String));
Student_CreatedByCol.ReadOnly = true;
Student_CreatedByCol.AllowDBNull = false;
Columns.Add(Student_CreatedByCol);
// column Student_UpdatedBy
DataColumn Student_UpdatedByCol = new DataColumn("Student_UpdatedBy", typeof(System.String));
Student_UpdatedByCol.ReadOnly = true;
Student_UpdatedByCol.AllowDBNull = false;
Columns.Add(Student_UpdatedByCol);
// column Student_EnrollmentDate
DataColumn Student_EnrollmentDateCol = new DataColumn("Student_EnrollmentDate", typeof(System.DateTime));
Student_EnrollmentDateCol.DateTimeMode = DataSetDateTime.Local;
Student_EnrollmentDateCol.ReadOnly = true;
Student_EnrollmentDateCol.AllowDBNull = false;
Columns.Add(Student_EnrollmentDateCol);
// column Student_ContractExpiredDate
DataColumn Student_ContractExpiredDateCol = new DataColumn("Student_ContractExpiredDate", typeof(System.DateTime));
Student_ContractExpiredDateCol.DateTimeMode = DataSetDateTime.Local;
Student_ContractExpiredDateCol.ReadOnly = true;
Student_ContractExpiredDateCol.AllowDBNull = false;
Columns.Add(Student_ContractExpiredDateCol);
// column TSP_CampusName
DataColumn TSP_CampusNameCol = new DataColumn("TSP_CampusName", typeof(System.String));
TSP_CampusNameCol.ReadOnly = true;
TSP_CampusNameCol.AllowDBNull = false;
Columns.Add(TSP_CampusNameCol);
// column Application_FullName
DataColumn Application_FullNameCol = new DataColumn("Application_FullName", typeof(System.String));
Application_FullNameCol.ReadOnly = true;
Application_FullNameCol.AllowDBNull = false;
Columns.Add(Application_FullNameCol);
// column Application_Gender
DataColumn Application_GenderCol = new DataColumn("Application_Gender", typeof(System.Int16));
Application_GenderCol.ReadOnly = true;
Application_GenderCol.AllowDBNull = false;
Columns.Add(Application_GenderCol);
// column Application_PhonePrefix
DataColumn Application_PhonePrefixCol = new DataColumn("Application_PhonePrefix", typeof(System.String));
Application_PhonePrefixCol.ReadOnly = true;
Application_PhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_PhonePrefixCol);
// column Application_PhoneNumber
DataColumn Application_PhoneNumberCol = new DataColumn("Application_PhoneNumber", typeof(System.String));
Application_PhoneNumberCol.ReadOnly = true;
Application_PhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_PhoneNumberCol);
// column Application_Email
DataColumn Application_EmailCol = new DataColumn("Application_Email", typeof(System.String));
Application_EmailCol.ReadOnly = true;
Application_EmailCol.AllowDBNull = false;
Columns.Add(Application_EmailCol);
// column CurrentSubject
DataColumn CurrentSubjectCol = new DataColumn("CurrentSubject", typeof(System.Int32));
CurrentSubjectCol.ReadOnly = true;
CurrentSubjectCol.AllowDBNull = true;
Columns.Add(CurrentSubjectCol);
// column CompletedSubject
DataColumn CompletedSubjectCol = new DataColumn("CompletedSubject", typeof(System.Int32));
CompletedSubjectCol.ReadOnly = true;
CompletedSubjectCol.AllowDBNull = true;
Columns.Add(CompletedSubjectCol);
// column RemainingSubject
DataColumn RemainingSubjectCol = new DataColumn("RemainingSubject", typeof(System.Int32));
RemainingSubjectCol.ReadOnly = true;
RemainingSubjectCol.AllowDBNull = true;
Columns.Add(RemainingSubjectCol);
// column Application_ContractType
DataColumn Application_ContractTypeCol = new DataColumn("Application_ContractType", typeof(System.Int16));
Application_ContractTypeCol.ReadOnly = true;
Application_ContractTypeCol.AllowDBNull = false;
Columns.Add(Application_ContractTypeCol);
// column Application_DOB
DataColumn Application_DOBCol = new DataColumn("Application_DOB", typeof(System.DateTime));
Application_DOBCol.DateTimeMode = DataSetDateTime.Local;
Application_DOBCol.ReadOnly = true;
Application_DOBCol.AllowDBNull = false;
Columns.Add(Application_DOBCol);
// column Application_IdentificationNumber
DataColumn Application_IdentificationNumberCol = new DataColumn("Application_IdentificationNumber", typeof(System.String));
Application_IdentificationNumberCol.ReadOnly = true;
Application_IdentificationNumberCol.AllowDBNull = false;
Columns.Add(Application_IdentificationNumberCol);
// column Application_Nationality
DataColumn Application_NationalityCol = new DataColumn("Application_Nationality", typeof(System.Int16));
Application_NationalityCol.ReadOnly = true;
Application_NationalityCol.AllowDBNull = false;
Columns.Add(Application_NationalityCol);
// column Application_MobilePhonePrefix
DataColumn Application_MobilePhonePrefixCol = new DataColumn("Application_MobilePhonePrefix", typeof(System.String));
Application_MobilePhonePrefixCol.ReadOnly = true;
Application_MobilePhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_MobilePhonePrefixCol);
// column Application_MobilePhoneNumber
DataColumn Application_MobilePhoneNumberCol = new DataColumn("Application_MobilePhoneNumber", typeof(System.String));
Application_MobilePhoneNumberCol.ReadOnly = true;
Application_MobilePhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_MobilePhoneNumberCol);
// column Application_OverallStatus
DataColumn Application_OverallStatusCol = new DataColumn("Application_OverallStatus", typeof(System.Int16));
Application_OverallStatusCol.ReadOnly = true;
Application_OverallStatusCol.AllowDBNull = false;
Columns.Add(Application_OverallStatusCol);
// column Application_OverallProgress
DataColumn Application_OverallProgressCol = new DataColumn("Application_OverallProgress", typeof(System.Int16));
Application_OverallProgressCol.ReadOnly = true;
Application_OverallProgressCol.AllowDBNull = false;
Columns.Add(Application_OverallProgressCol);
// column WarningLetterCount
DataColumn WarningLetterCountCol = new DataColumn("WarningLetterCount", typeof(System.Int32));
WarningLetterCountCol.ReadOnly = true;
WarningLetterCountCol.AllowDBNull = true;
Columns.Add(WarningLetterCountCol);
// column Sponsor_ID
DataColumn Sponsor_IDCol = new DataColumn("Sponsor_ID", typeof(System.Guid));
Sponsor_IDCol.ReadOnly = true;
Sponsor_IDCol.AllowDBNull = false;
Columns.Add(Sponsor_IDCol);
// column Sponsor_Code
DataColumn Sponsor_CodeCol = new DataColumn("Sponsor_Code", typeof(System.String));
Sponsor_CodeCol.ReadOnly = true;
Sponsor_CodeCol.AllowDBNull = false;
Columns.Add(Sponsor_CodeCol);
// column Sponsor_Label
DataColumn Sponsor_LabelCol = new DataColumn("Sponsor_Label", typeof(System.String));
Sponsor_LabelCol.ReadOnly = true;
Sponsor_LabelCol.AllowDBNull = false;
Columns.Add(Sponsor_LabelCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentProgressSummaryDetailRow(builder);
}
public StudentProgressSummaryDetailRow GetStudentProgressSummaryDetailRow(int index) {
return (StudentProgressSummaryDetailRow)Rows[index];
}
}
public partial class StudentProgressSummaryDetailRow : DataRow {
internal StudentProgressSummaryDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Student_ID {
get {
return (System.Guid)this["Student_ID"];
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
}
public System.Int32 Student_SubjectTaken {
get {
return (System.Int32)this["Student_SubjectTaken"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
public System.Int16 Student_Status {
get {
return (System.Int16)this["Student_Status"];
}
}
public System.String Student_Remark {
get {
return (System.String)this["Student_Remark"];
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
}
public System.DateTime Student_CreatedDate {
get {
return (System.DateTime)this["Student_CreatedDate"];
}
}
public System.DateTime Student_UpdatedDate {
get {
return (System.DateTime)this["Student_UpdatedDate"];
}
}
public System.String Student_CreatedBy {
get {
return (System.String)this["Student_CreatedBy"];
}
}
public System.String Student_UpdatedBy {
get {
return (System.String)this["Student_UpdatedBy"];
}
}
public System.DateTime Student_EnrollmentDate {
get {
return (System.DateTime)this["Student_EnrollmentDate"];
}
}
public System.DateTime Student_ContractExpiredDate {
get {
return (System.DateTime)this["Student_ContractExpiredDate"];
}
}
public System.String TSP_CampusName {
get {
return (System.String)this["TSP_CampusName"];
}
}
public System.String Application_FullName {
get {
return (System.String)this["Application_FullName"];
}
}
public System.Int16 Application_Gender {
get {
return (System.Int16)this["Application_Gender"];
}
}
public System.String Application_PhonePrefix {
get {
return (System.String)this["Application_PhonePrefix"];
}
}
public System.String Application_PhoneNumber {
get {
return (System.String)this["Application_PhoneNumber"];
}
}
public System.String Application_Email {
get {
return (System.String)this["Application_Email"];
}
}
public System.Int32? CurrentSubject {
get {
if( IsNull("CurrentSubject") ) return null;
else return (System.Int32)this["CurrentSubject"];
}
}
public System.Int32? CompletedSubject {
get {
if( IsNull("CompletedSubject") ) return null;
else return (System.Int32)this["CompletedSubject"];
}
}
public System.Int32? RemainingSubject {
get {
if( IsNull("RemainingSubject") ) return null;
else return (System.Int32)this["RemainingSubject"];
}
}
public System.Int16 Application_ContractType {
get {
return (System.Int16)this["Application_ContractType"];
}
}
public System.DateTime Application_DOB {
get {
return (System.DateTime)this["Application_DOB"];
}
}
public System.String Application_IdentificationNumber {
get {
return (System.String)this["Application_IdentificationNumber"];
}
}
public System.Int16 Application_Nationality {
get {
return (System.Int16)this["Application_Nationality"];
}
}
public System.String Application_MobilePhonePrefix {
get {
return (System.String)this["Application_MobilePhonePrefix"];
}
}
public System.String Application_MobilePhoneNumber {
get {
return (System.String)this["Application_MobilePhoneNumber"];
}
}
public System.Int16 Application_OverallStatus {
get {
return (System.Int16)this["Application_OverallStatus"];
}
}
public System.Int16 Application_OverallProgress {
get {
return (System.Int16)this["Application_OverallProgress"];
}
}
public System.Int32? WarningLetterCount {
get {
if( IsNull("WarningLetterCount") ) return null;
else return (System.Int32)this["WarningLetterCount"];
}
}
public System.Guid Sponsor_ID {
get {
return (System.Guid)this["Sponsor_ID"];
}
}
public System.String Sponsor_Code {
get {
return (System.String)this["Sponsor_Code"];
}
}
public System.String Sponsor_Label {
get {
return (System.String)this["Sponsor_Label"];
}
}
}
public partial class StudentProgressSummaryDetailMinimalizedEntity {
public StudentProgressSummaryDetailMinimalizedEntity() {}
public StudentProgressSummaryDetailMinimalizedEntity(StudentProgressSummaryDetailRow dr) {
this.Student_ID = dr.Student_ID;
this.TSP_ID = dr.TSP_ID;
this.Student_SubjectTaken = dr.Student_SubjectTaken;
this.Course_ID = dr.Course_ID;
this.Student_Status = dr.Student_Status;
this.Student_Remark = dr.Student_Remark;
this.Application_ID = dr.Application_ID;
this.Student_CreatedDate = dr.Student_CreatedDate;
this.Student_UpdatedDate = dr.Student_UpdatedDate;
this.Student_CreatedBy = dr.Student_CreatedBy;
this.Student_UpdatedBy = dr.Student_UpdatedBy;
this.Student_EnrollmentDate = dr.Student_EnrollmentDate;
this.Student_ContractExpiredDate = dr.Student_ContractExpiredDate;
this.TSP_CampusName = dr.TSP_CampusName;
this.Application_FullName = dr.Application_FullName;
this.Application_Gender = dr.Application_Gender;
this.Application_PhonePrefix = dr.Application_PhonePrefix;
this.Application_PhoneNumber = dr.Application_PhoneNumber;
this.Application_Email = dr.Application_Email;
this.CurrentSubject = dr.CurrentSubject;
this.CompletedSubject = dr.CompletedSubject;
this.RemainingSubject = dr.RemainingSubject;
this.Application_ContractType = dr.Application_ContractType;
this.Application_DOB = dr.Application_DOB;
this.Application_IdentificationNumber = dr.Application_IdentificationNumber;
this.Application_Nationality = dr.Application_Nationality;
this.Application_MobilePhonePrefix = dr.Application_MobilePhonePrefix;
this.Application_MobilePhoneNumber = dr.Application_MobilePhoneNumber;
this.Application_OverallStatus = dr.Application_OverallStatus;
this.Application_OverallProgress = dr.Application_OverallProgress;
this.WarningLetterCount = dr.WarningLetterCount;
this.Sponsor_ID = dr.Sponsor_ID;
this.Sponsor_Code = dr.Sponsor_Code;
this.Sponsor_Label = dr.Sponsor_Label;
}
public System.Guid Student_ID;
public System.Guid TSP_ID;
public System.Int32 Student_SubjectTaken;
public System.Guid Course_ID;
public System.Int16 Student_Status;
public System.String Student_Remark;
public System.Guid Application_ID;
public System.DateTime Student_CreatedDate;
public System.DateTime Student_UpdatedDate;
public System.String Student_CreatedBy;
public System.String Student_UpdatedBy;
public System.DateTime Student_EnrollmentDate;
public System.DateTime Student_ContractExpiredDate;
public System.String TSP_CampusName;
public System.String Application_FullName;
public System.Int16 Application_Gender;
public System.String Application_PhonePrefix;
public System.String Application_PhoneNumber;
public System.String Application_Email;
public System.Int32? CurrentSubject;
public System.Int32? CompletedSubject;
public System.Int32? RemainingSubject;
public System.Int16 Application_ContractType;
public System.DateTime Application_DOB;
public System.String Application_IdentificationNumber;
public System.Int16 Application_Nationality;
public System.String Application_MobilePhonePrefix;
public System.String Application_MobilePhoneNumber;
public System.Int16 Application_OverallStatus;
public System.Int16 Application_OverallProgress;
public System.Int32? WarningLetterCount;
public System.Guid Sponsor_ID;
public System.String Sponsor_Code;
public System.String Sponsor_Label;
}
public partial class StudentProgressSummaryDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentProgressSummaryDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Student_ID", "Student_ID");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("Student_SubjectTaken", "Student_SubjectTaken");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("Student_Status", "Student_Status");
tmap.ColumnMappings.Add("Student_Remark", "Student_Remark");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("Student_CreatedDate", "Student_CreatedDate");
tmap.ColumnMappings.Add("Student_UpdatedDate", "Student_UpdatedDate");
tmap.ColumnMappings.Add("Student_CreatedBy", "Student_CreatedBy");
tmap.ColumnMappings.Add("Student_UpdatedBy", "Student_UpdatedBy");
tmap.ColumnMappings.Add("Student_EnrollmentDate", "Student_EnrollmentDate");
tmap.ColumnMappings.Add("Student_ContractExpiredDate", "Student_ContractExpiredDate");
tmap.ColumnMappings.Add("TSP_CampusName", "TSP_CampusName");
tmap.ColumnMappings.Add("Application_FullName", "Application_FullName");
tmap.ColumnMappings.Add("Application_Gender", "Application_Gender");
tmap.ColumnMappings.Add("Application_PhonePrefix", "Application_PhonePrefix");
tmap.ColumnMappings.Add("Application_PhoneNumber", "Application_PhoneNumber");
tmap.ColumnMappings.Add("Application_Email", "Application_Email");
tmap.ColumnMappings.Add("CurrentSubject", "CurrentSubject");
tmap.ColumnMappings.Add("CompletedSubject", "CompletedSubject");
tmap.ColumnMappings.Add("RemainingSubject", "RemainingSubject");
tmap.ColumnMappings.Add("Application_ContractType", "Application_ContractType");
tmap.ColumnMappings.Add("Application_DOB", "Application_DOB");
tmap.ColumnMappings.Add("Application_IdentificationNumber", "Application_IdentificationNumber");
tmap.ColumnMappings.Add("Application_Nationality", "Application_Nationality");
tmap.ColumnMappings.Add("Application_MobilePhonePrefix", "Application_MobilePhonePrefix");
tmap.ColumnMappings.Add("Application_MobilePhoneNumber", "Application_MobilePhoneNumber");
tmap.ColumnMappings.Add("Application_OverallStatus", "Application_OverallStatus");
tmap.ColumnMappings.Add("Application_OverallProgress", "Application_OverallProgress");
tmap.ColumnMappings.Add("WarningLetterCount", "WarningLetterCount");
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
tmap.ColumnMappings.Add("Sponsor_Code", "Sponsor_Code");
tmap.ColumnMappings.Add("Sponsor_Label", "Sponsor_Label");
adapter.TableMappings.Add(tmap);
}
}
public StudentProgressSummaryDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [StudentProgressSummaryDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

StudentProgressSummaryDetailTable tbl = new StudentProgressSummaryDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentProgressSummaryDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [StudentProgressSummaryDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
