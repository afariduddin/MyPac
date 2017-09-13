using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptStudentProgressSummaryMasterListTable : DataTable {
// column indexes
public const int EnrollmentDateColumnIndex = 0;
public const int FullNameColumnIndex = 1;
public const int DOBColumnIndex = 2;
public const int GenderColumnIndex = 3;
public const int ICNumberColumnIndex = 4;
public const int NationalityColumnIndex = 5;
public const int EmailColumnIndex = 6;
public const int PhoneNumberColumnIndex = 7;
public const int MobileColumnIndex = 8;
public const int CampusNameColumnIndex = 9;
public const int CampusCityColumnIndex = 10;
public const int ContractTypeColumnIndex = 11;
public const int SponsorColumnIndex = 12;
public const int CompletedSubjectColumnIndex = 13;
public const int CurrentSubjectColumnIndex = 14;
public const int RemainingSubjectColumnIndex = 15;
public const int SubjectProgressColumnIndex = 16;
public const int CourseColumnIndex = 17;
public const int ContractExpiredDateColumnIndex = 18;
public const int ContractRemainingMonthColumnIndex = 19;
public RptStudentProgressSummaryMasterListTable() {
TableName = "[RptStudentProgressSummaryMasterList]";
// column EnrollmentDate
DataColumn EnrollmentDateCol = new DataColumn("EnrollmentDate", typeof(System.DateTime));
EnrollmentDateCol.DateTimeMode = DataSetDateTime.Utc;
EnrollmentDateCol.ReadOnly = true;
EnrollmentDateCol.AllowDBNull = false;
Columns.Add(EnrollmentDateCol);
// column FullName
DataColumn FullNameCol = new DataColumn("FullName", typeof(System.String));
FullNameCol.ReadOnly = true;
FullNameCol.AllowDBNull = false;
Columns.Add(FullNameCol);
// column DOB
DataColumn DOBCol = new DataColumn("DOB", typeof(System.DateTime));
DOBCol.DateTimeMode = DataSetDateTime.Utc;
DOBCol.ReadOnly = true;
DOBCol.AllowDBNull = false;
Columns.Add(DOBCol);
// column Gender
DataColumn GenderCol = new DataColumn("Gender", typeof(System.String));
GenderCol.ReadOnly = true;
GenderCol.AllowDBNull = false;
Columns.Add(GenderCol);
// column ICNumber
DataColumn ICNumberCol = new DataColumn("ICNumber", typeof(System.String));
ICNumberCol.ReadOnly = true;
ICNumberCol.AllowDBNull = false;
Columns.Add(ICNumberCol);
// column Nationality
DataColumn NationalityCol = new DataColumn("Nationality", typeof(System.String));
NationalityCol.ReadOnly = true;
NationalityCol.AllowDBNull = false;
Columns.Add(NationalityCol);
// column Email
DataColumn EmailCol = new DataColumn("Email", typeof(System.String));
EmailCol.ReadOnly = true;
EmailCol.AllowDBNull = false;
Columns.Add(EmailCol);
// column PhoneNumber
DataColumn PhoneNumberCol = new DataColumn("PhoneNumber", typeof(System.String));
PhoneNumberCol.ReadOnly = true;
PhoneNumberCol.AllowDBNull = false;
Columns.Add(PhoneNumberCol);
// column Mobile
DataColumn MobileCol = new DataColumn("Mobile", typeof(System.String));
MobileCol.ReadOnly = true;
MobileCol.AllowDBNull = false;
Columns.Add(MobileCol);
// column CampusName
DataColumn CampusNameCol = new DataColumn("CampusName", typeof(System.String));
CampusNameCol.ReadOnly = true;
CampusNameCol.AllowDBNull = false;
Columns.Add(CampusNameCol);
// column CampusCity
DataColumn CampusCityCol = new DataColumn("CampusCity", typeof(System.String));
CampusCityCol.ReadOnly = true;
CampusCityCol.AllowDBNull = false;
Columns.Add(CampusCityCol);
// column ContractType
DataColumn ContractTypeCol = new DataColumn("ContractType", typeof(System.String));
ContractTypeCol.ReadOnly = true;
ContractTypeCol.AllowDBNull = false;
Columns.Add(ContractTypeCol);
// column Sponsor
DataColumn SponsorCol = new DataColumn("Sponsor", typeof(System.String));
SponsorCol.ReadOnly = true;
SponsorCol.AllowDBNull = true;
Columns.Add(SponsorCol);
// column CompletedSubject
DataColumn CompletedSubjectCol = new DataColumn("CompletedSubject", typeof(System.Int32));
CompletedSubjectCol.ReadOnly = true;
CompletedSubjectCol.AllowDBNull = true;
Columns.Add(CompletedSubjectCol);
// column CurrentSubject
DataColumn CurrentSubjectCol = new DataColumn("CurrentSubject", typeof(System.Int32));
CurrentSubjectCol.ReadOnly = true;
CurrentSubjectCol.AllowDBNull = true;
Columns.Add(CurrentSubjectCol);
// column RemainingSubject
DataColumn RemainingSubjectCol = new DataColumn("RemainingSubject", typeof(System.Int32));
RemainingSubjectCol.ReadOnly = true;
RemainingSubjectCol.AllowDBNull = true;
Columns.Add(RemainingSubjectCol);
// column SubjectProgress
DataColumn SubjectProgressCol = new DataColumn("SubjectProgress", typeof(System.String));
SubjectProgressCol.ReadOnly = true;
SubjectProgressCol.AllowDBNull = true;
Columns.Add(SubjectProgressCol);
// column Course
DataColumn CourseCol = new DataColumn("Course", typeof(System.String));
CourseCol.ReadOnly = true;
CourseCol.AllowDBNull = false;
Columns.Add(CourseCol);
// column ContractExpiredDate
DataColumn ContractExpiredDateCol = new DataColumn("ContractExpiredDate", typeof(System.DateTime));
ContractExpiredDateCol.DateTimeMode = DataSetDateTime.Utc;
ContractExpiredDateCol.ReadOnly = true;
ContractExpiredDateCol.AllowDBNull = false;
Columns.Add(ContractExpiredDateCol);
// column ContractRemainingMonth
DataColumn ContractRemainingMonthCol = new DataColumn("ContractRemainingMonth", typeof(System.Int32));
ContractRemainingMonthCol.ReadOnly = true;
ContractRemainingMonthCol.AllowDBNull = true;
Columns.Add(ContractRemainingMonthCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptStudentProgressSummaryMasterListRow(builder);
}
public RptStudentProgressSummaryMasterListRow GetRptStudentProgressSummaryMasterListRow(int index) {
return (RptStudentProgressSummaryMasterListRow)Rows[index];
}
}
public partial class RptStudentProgressSummaryMasterListRow : DataRow {
internal RptStudentProgressSummaryMasterListRow(DataRowBuilder builder) : base(builder) {
}
public System.DateTime EnrollmentDate {
get {
return (System.DateTime)this["EnrollmentDate"];
}
}
public System.String FullName {
get {
return (System.String)this["FullName"];
}
}
public System.DateTime DOB {
get {
return (System.DateTime)this["DOB"];
}
}
public System.String Gender {
get {
return (System.String)this["Gender"];
}
}
public System.String ICNumber {
get {
return (System.String)this["ICNumber"];
}
}
public System.String Nationality {
get {
return (System.String)this["Nationality"];
}
}
public System.String Email {
get {
return (System.String)this["Email"];
}
}
public System.String PhoneNumber {
get {
return (System.String)this["PhoneNumber"];
}
}
public System.String Mobile {
get {
return (System.String)this["Mobile"];
}
}
public System.String CampusName {
get {
return (System.String)this["CampusName"];
}
}
public System.String CampusCity {
get {
return (System.String)this["CampusCity"];
}
}
public System.String ContractType {
get {
return (System.String)this["ContractType"];
}
}
public System.String Sponsor {
get {
if( IsNull("Sponsor") ) return "";
else return (System.String)this["Sponsor"];
}
}
public System.Int32? CompletedSubject {
get {
if( IsNull("CompletedSubject") ) return null;
else return (System.Int32)this["CompletedSubject"];
}
}
public System.Int32? CurrentSubject {
get {
if( IsNull("CurrentSubject") ) return null;
else return (System.Int32)this["CurrentSubject"];
}
}
public System.Int32? RemainingSubject {
get {
if( IsNull("RemainingSubject") ) return null;
else return (System.Int32)this["RemainingSubject"];
}
}
public System.String SubjectProgress {
get {
if( IsNull("SubjectProgress") ) return "";
else return (System.String)this["SubjectProgress"];
}
}
public System.String Course {
get {
return (System.String)this["Course"];
}
}
public System.DateTime ContractExpiredDate {
get {
return (System.DateTime)this["ContractExpiredDate"];
}
}
public System.Int32? ContractRemainingMonth {
get {
if( IsNull("ContractRemainingMonth") ) return null;
else return (System.Int32)this["ContractRemainingMonth"];
}
}
}
public partial class RptStudentProgressSummaryMasterListMinimalizedEntity {
public RptStudentProgressSummaryMasterListMinimalizedEntity() {}
public RptStudentProgressSummaryMasterListMinimalizedEntity(RptStudentProgressSummaryMasterListRow dr) {
this.EnrollmentDate = dr.EnrollmentDate;
this.FullName = dr.FullName;
this.DOB = dr.DOB;
this.Gender = dr.Gender;
this.ICNumber = dr.ICNumber;
this.Nationality = dr.Nationality;
this.Email = dr.Email;
this.PhoneNumber = dr.PhoneNumber;
this.Mobile = dr.Mobile;
this.CampusName = dr.CampusName;
this.CampusCity = dr.CampusCity;
this.ContractType = dr.ContractType;
this.Sponsor = dr.Sponsor;
this.CompletedSubject = dr.CompletedSubject;
this.CurrentSubject = dr.CurrentSubject;
this.RemainingSubject = dr.RemainingSubject;
this.SubjectProgress = dr.SubjectProgress;
this.Course = dr.Course;
this.ContractExpiredDate = dr.ContractExpiredDate;
this.ContractRemainingMonth = dr.ContractRemainingMonth;
}
public System.DateTime EnrollmentDate;
public System.String FullName;
public System.DateTime DOB;
public System.String Gender;
public System.String ICNumber;
public System.String Nationality;
public System.String Email;
public System.String PhoneNumber;
public System.String Mobile;
public System.String CampusName;
public System.String CampusCity;
public System.String ContractType;
public System.String Sponsor;
public System.Int32? CompletedSubject;
public System.Int32? CurrentSubject;
public System.Int32? RemainingSubject;
public System.String SubjectProgress;
public System.String Course;
public System.DateTime ContractExpiredDate;
public System.Int32? ContractRemainingMonth;
}
public partial class RptStudentProgressSummaryMasterListAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptStudentProgressSummaryMasterListAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("EnrollmentDate", "EnrollmentDate");
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DOB", "DOB");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("ICNumber", "ICNumber");
tmap.ColumnMappings.Add("Nationality", "Nationality");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
tmap.ColumnMappings.Add("Mobile", "Mobile");
tmap.ColumnMappings.Add("CampusName", "CampusName");
tmap.ColumnMappings.Add("CampusCity", "CampusCity");
tmap.ColumnMappings.Add("ContractType", "ContractType");
tmap.ColumnMappings.Add("Sponsor", "Sponsor");
tmap.ColumnMappings.Add("CompletedSubject", "CompletedSubject");
tmap.ColumnMappings.Add("CurrentSubject", "CurrentSubject");
tmap.ColumnMappings.Add("RemainingSubject", "RemainingSubject");
tmap.ColumnMappings.Add("SubjectProgress", "SubjectProgress");
tmap.ColumnMappings.Add("Course", "Course");
tmap.ColumnMappings.Add("ContractExpiredDate", "ContractExpiredDate");
tmap.ColumnMappings.Add("ContractRemainingMonth", "ContractRemainingMonth");
adapter.TableMappings.Add(tmap);
}
}
public RptStudentProgressSummaryMasterListRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptStudentProgressSummaryMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptStudentProgressSummaryMasterListTable tbl = new RptStudentProgressSummaryMasterListTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptStudentProgressSummaryMasterListRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptStudentProgressSummaryMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
