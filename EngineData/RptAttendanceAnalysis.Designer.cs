using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptAttendanceAnalysisTable : DataTable {
// column indexes
public const int IntakeMonthColumnIndex = 0;
public const int IntakeYearColumnIndex = 1;
public const int IntakeDateColumnIndex = 2;
public const int FullNameColumnIndex = 3;
public const int DOBColumnIndex = 4;
public const int GenderColumnIndex = 5;
public const int NationalityColumnIndex = 6;
public const int ICNoColumnIndex = 7;
public const int EmailColumnIndex = 8;
public const int SponsorColumnIndex = 9;
public const int TSPColumnIndex = 10;
public const int CourseColumnIndex = 11;
public const int PaperColumnIndex = 12;
public const int TotalClassColumnIndex = 13;
public const int AttendedClassColumnIndex = 14;
public const int AttendanceRateColumnIndex = 15;
public const int FinalResultColumnIndex = 16;
public RptAttendanceAnalysisTable() {
TableName = "[RptAttendanceAnalysis]";
// column IntakeMonth
DataColumn IntakeMonthCol = new DataColumn("IntakeMonth", typeof(System.Int32));
IntakeMonthCol.ReadOnly = true;
IntakeMonthCol.AllowDBNull = false;
Columns.Add(IntakeMonthCol);
// column IntakeYear
DataColumn IntakeYearCol = new DataColumn("IntakeYear", typeof(System.Int32));
IntakeYearCol.ReadOnly = true;
IntakeYearCol.AllowDBNull = false;
Columns.Add(IntakeYearCol);
// column IntakeDate
DataColumn IntakeDateCol = new DataColumn("IntakeDate", typeof(System.String));
IntakeDateCol.ReadOnly = true;
IntakeDateCol.AllowDBNull = false;
Columns.Add(IntakeDateCol);
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
// column Nationality
DataColumn NationalityCol = new DataColumn("Nationality", typeof(System.String));
NationalityCol.ReadOnly = true;
NationalityCol.AllowDBNull = false;
Columns.Add(NationalityCol);
// column ICNo
DataColumn ICNoCol = new DataColumn("ICNo", typeof(System.String));
ICNoCol.ReadOnly = true;
ICNoCol.AllowDBNull = false;
Columns.Add(ICNoCol);
// column Email
DataColumn EmailCol = new DataColumn("Email", typeof(System.String));
EmailCol.ReadOnly = true;
EmailCol.AllowDBNull = false;
Columns.Add(EmailCol);
// column Sponsor
DataColumn SponsorCol = new DataColumn("Sponsor", typeof(System.String));
SponsorCol.ReadOnly = true;
SponsorCol.AllowDBNull = true;
Columns.Add(SponsorCol);
// column TSP
DataColumn TSPCol = new DataColumn("TSP", typeof(System.String));
TSPCol.ReadOnly = true;
TSPCol.AllowDBNull = false;
Columns.Add(TSPCol);
// column Course
DataColumn CourseCol = new DataColumn("Course", typeof(System.String));
CourseCol.ReadOnly = true;
CourseCol.AllowDBNull = false;
Columns.Add(CourseCol);
// column Paper
DataColumn PaperCol = new DataColumn("Paper", typeof(System.String));
PaperCol.ReadOnly = true;
PaperCol.AllowDBNull = false;
Columns.Add(PaperCol);
// column TotalClass
DataColumn TotalClassCol = new DataColumn("TotalClass", typeof(System.Int32));
TotalClassCol.ReadOnly = true;
TotalClassCol.AllowDBNull = true;
Columns.Add(TotalClassCol);
// column AttendedClass
DataColumn AttendedClassCol = new DataColumn("AttendedClass", typeof(System.Int32));
AttendedClassCol.ReadOnly = true;
AttendedClassCol.AllowDBNull = true;
Columns.Add(AttendedClassCol);
// column AttendanceRate
DataColumn AttendanceRateCol = new DataColumn("AttendanceRate", typeof(System.Int32));
AttendanceRateCol.ReadOnly = true;
AttendanceRateCol.AllowDBNull = true;
Columns.Add(AttendanceRateCol);
// column FinalResult
DataColumn FinalResultCol = new DataColumn("FinalResult", typeof(System.Decimal));
FinalResultCol.ReadOnly = true;
FinalResultCol.AllowDBNull = true;
Columns.Add(FinalResultCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptAttendanceAnalysisRow(builder);
}
public RptAttendanceAnalysisRow GetRptAttendanceAnalysisRow(int index) {
return (RptAttendanceAnalysisRow)Rows[index];
}
}
public partial class RptAttendanceAnalysisRow : DataRow {
internal RptAttendanceAnalysisRow(DataRowBuilder builder) : base(builder) {
}
public System.Int32 IntakeMonth {
get {
return (System.Int32)this["IntakeMonth"];
}
}
public System.Int32 IntakeYear {
get {
return (System.Int32)this["IntakeYear"];
}
}
public System.String IntakeDate {
get {
return (System.String)this["IntakeDate"];
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
public System.String Nationality {
get {
return (System.String)this["Nationality"];
}
}
public System.String ICNo {
get {
return (System.String)this["ICNo"];
}
}
public System.String Email {
get {
return (System.String)this["Email"];
}
}
public System.String Sponsor {
get {
if( IsNull("Sponsor") ) return "";
else return (System.String)this["Sponsor"];
}
}
public System.String TSP {
get {
return (System.String)this["TSP"];
}
}
public System.String Course {
get {
return (System.String)this["Course"];
}
}
public System.String Paper {
get {
return (System.String)this["Paper"];
}
}
public System.Int32? TotalClass {
get {
if( IsNull("TotalClass") ) return null;
else return (System.Int32)this["TotalClass"];
}
}
public System.Int32? AttendedClass {
get {
if( IsNull("AttendedClass") ) return null;
else return (System.Int32)this["AttendedClass"];
}
}
public System.Int32? AttendanceRate {
get {
if( IsNull("AttendanceRate") ) return null;
else return (System.Int32)this["AttendanceRate"];
}
}
public System.Decimal? FinalResult {
get {
if( IsNull("FinalResult") ) return null;
else return (System.Decimal)this["FinalResult"];
}
}
}
public partial class RptAttendanceAnalysisMinimalizedEntity {
public RptAttendanceAnalysisMinimalizedEntity() {}
public RptAttendanceAnalysisMinimalizedEntity(RptAttendanceAnalysisRow dr) {
this.IntakeMonth = dr.IntakeMonth;
this.IntakeYear = dr.IntakeYear;
this.IntakeDate = dr.IntakeDate;
this.FullName = dr.FullName;
this.DOB = dr.DOB;
this.Gender = dr.Gender;
this.Nationality = dr.Nationality;
this.ICNo = dr.ICNo;
this.Email = dr.Email;
this.Sponsor = dr.Sponsor;
this.TSP = dr.TSP;
this.Course = dr.Course;
this.Paper = dr.Paper;
this.TotalClass = dr.TotalClass;
this.AttendedClass = dr.AttendedClass;
this.AttendanceRate = dr.AttendanceRate;
this.FinalResult = dr.FinalResult;
}
public System.Int32 IntakeMonth;
public System.Int32 IntakeYear;
public System.String IntakeDate;
public System.String FullName;
public System.DateTime DOB;
public System.String Gender;
public System.String Nationality;
public System.String ICNo;
public System.String Email;
public System.String Sponsor;
public System.String TSP;
public System.String Course;
public System.String Paper;
public System.Int32? TotalClass;
public System.Int32? AttendedClass;
public System.Int32? AttendanceRate;
public System.Decimal? FinalResult;
}
public partial class RptAttendanceAnalysisAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptAttendanceAnalysisAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("IntakeMonth", "IntakeMonth");
tmap.ColumnMappings.Add("IntakeYear", "IntakeYear");
tmap.ColumnMappings.Add("IntakeDate", "IntakeDate");
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DOB", "DOB");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("Nationality", "Nationality");
tmap.ColumnMappings.Add("ICNo", "ICNo");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("Sponsor", "Sponsor");
tmap.ColumnMappings.Add("TSP", "TSP");
tmap.ColumnMappings.Add("Course", "Course");
tmap.ColumnMappings.Add("Paper", "Paper");
tmap.ColumnMappings.Add("TotalClass", "TotalClass");
tmap.ColumnMappings.Add("AttendedClass", "AttendedClass");
tmap.ColumnMappings.Add("AttendanceRate", "AttendanceRate");
tmap.ColumnMappings.Add("FinalResult", "FinalResult");
adapter.TableMappings.Add(tmap);
}
}
public RptAttendanceAnalysisRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptAttendanceAnalysis] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptAttendanceAnalysisTable tbl = new RptAttendanceAnalysisTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptAttendanceAnalysisRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptAttendanceAnalysis] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
