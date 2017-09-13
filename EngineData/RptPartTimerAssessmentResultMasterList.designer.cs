using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptPartTimerAssessmentResultMasterListTable : DataTable {
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
public const int Assessment1ColumnIndex = 12;
public const int Assessment2ColumnIndex = 13;
public const int Assessment3ColumnIndex = 14;
public const int AttendanceColumnIndex = 15;
public const int StatusColumnIndex = 16;
public const int SponsorColumnIndex = 17;
public RptPartTimerAssessmentResultMasterListTable() {
TableName = "[RptPartTimerAssessmentResultMasterList]";
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
// column Assessment1
DataColumn Assessment1Col = new DataColumn("Assessment1", typeof(System.Decimal));
Assessment1Col.ReadOnly = true;
Assessment1Col.AllowDBNull = false;
Columns.Add(Assessment1Col);
// column Assessment2
DataColumn Assessment2Col = new DataColumn("Assessment2", typeof(System.Decimal));
Assessment2Col.ReadOnly = true;
Assessment2Col.AllowDBNull = false;
Columns.Add(Assessment2Col);
// column Assessment3
DataColumn Assessment3Col = new DataColumn("Assessment3", typeof(System.Decimal));
Assessment3Col.ReadOnly = true;
Assessment3Col.AllowDBNull = false;
Columns.Add(Assessment3Col);
// column Attendance
DataColumn AttendanceCol = new DataColumn("Attendance", typeof(System.Decimal));
AttendanceCol.ReadOnly = true;
AttendanceCol.AllowDBNull = false;
Columns.Add(AttendanceCol);
// column Status
DataColumn StatusCol = new DataColumn("Status", typeof(System.String));
StatusCol.ReadOnly = true;
StatusCol.AllowDBNull = true;
Columns.Add(StatusCol);
// column Sponsor
DataColumn SponsorCol = new DataColumn("Sponsor", typeof(System.String));
SponsorCol.ReadOnly = true;
SponsorCol.AllowDBNull = true;
Columns.Add(SponsorCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptPartTimerAssessmentResultMasterListRow(builder);
}
public RptPartTimerAssessmentResultMasterListRow GetRptPartTimerAssessmentResultMasterListRow(int index) {
return (RptPartTimerAssessmentResultMasterListRow)Rows[index];
}
}
public partial class RptPartTimerAssessmentResultMasterListRow : DataRow {
internal RptPartTimerAssessmentResultMasterListRow(DataRowBuilder builder) : base(builder) {
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
public System.Decimal Assessment1 {
get {
return (System.Decimal)this["Assessment1"];
}
}
public System.Decimal Assessment2 {
get {
return (System.Decimal)this["Assessment2"];
}
}
public System.Decimal Assessment3 {
get {
return (System.Decimal)this["Assessment3"];
}
}
public System.Decimal Attendance {
get {
return (System.Decimal)this["Attendance"];
}
}
public System.String Status {
get {
if( IsNull("Status") ) return "";
else return (System.String)this["Status"];
}
}
public System.String Sponsor {
get {
if( IsNull("Sponsor") ) return "";
else return (System.String)this["Sponsor"];
}
}
}
public partial class RptPartTimerAssessmentResultMasterListMinimalizedEntity {
public RptPartTimerAssessmentResultMasterListMinimalizedEntity() {}
public RptPartTimerAssessmentResultMasterListMinimalizedEntity(RptPartTimerAssessmentResultMasterListRow dr) {
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
this.Assessment1 = dr.Assessment1;
this.Assessment2 = dr.Assessment2;
this.Assessment3 = dr.Assessment3;
this.Attendance = dr.Attendance;
this.Status = dr.Status;
this.Sponsor = dr.Sponsor;
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
public System.Decimal Assessment1;
public System.Decimal Assessment2;
public System.Decimal Assessment3;
public System.Decimal Attendance;
public System.String Status;
public System.String Sponsor;
}
public partial class RptPartTimerAssessmentResultMasterListAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptPartTimerAssessmentResultMasterListAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("Assessment1", "Assessment1");
tmap.ColumnMappings.Add("Assessment2", "Assessment2");
tmap.ColumnMappings.Add("Assessment3", "Assessment3");
tmap.ColumnMappings.Add("Attendance", "Attendance");
tmap.ColumnMappings.Add("Status", "Status");
tmap.ColumnMappings.Add("Sponsor", "Sponsor");
adapter.TableMappings.Add(tmap);
}
}
public RptPartTimerAssessmentResultMasterListRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptPartTimerAssessmentResultMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptPartTimerAssessmentResultMasterListTable tbl = new RptPartTimerAssessmentResultMasterListTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptPartTimerAssessmentResultMasterListRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptPartTimerAssessmentResultMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
