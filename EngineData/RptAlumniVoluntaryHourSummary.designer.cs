using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptAlumniVoluntaryHourSummaryTable : DataTable {
// column indexes
public const int FullNameColumnIndex = 0;
public const int DateofBirthColumnIndex = 1;
public const int GenderColumnIndex = 2;
public const int ICNumberColumnIndex = 3;
public const int EmailColumnIndex = 4;
public const int PhoneNumberColumnIndex = 5;
public const int MobileColumnIndex = 6;
public const int EnrollmentDateColumnIndex = 7;
public const int CampusNameColumnIndex = 8;
public const int CampusCityColumnIndex = 9;
public const int ContractTypeColumnIndex = 10;
public const int TotalWorkHourColumnIndex = 11;
public RptAlumniVoluntaryHourSummaryTable() {
TableName = "[RptAlumniVoluntaryHourSummary]";
// column FullName
DataColumn FullNameCol = new DataColumn("FullName", typeof(System.String));
FullNameCol.ReadOnly = true;
FullNameCol.AllowDBNull = false;
Columns.Add(FullNameCol);
// column DateofBirth
DataColumn DateofBirthCol = new DataColumn("DateofBirth", typeof(System.DateTime));
DateofBirthCol.DateTimeMode = DataSetDateTime.Utc;
DateofBirthCol.ReadOnly = true;
DateofBirthCol.AllowDBNull = false;
Columns.Add(DateofBirthCol);
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
// column EnrollmentDate
DataColumn EnrollmentDateCol = new DataColumn("EnrollmentDate", typeof(System.DateTime));
EnrollmentDateCol.DateTimeMode = DataSetDateTime.Utc;
EnrollmentDateCol.ReadOnly = true;
EnrollmentDateCol.AllowDBNull = false;
Columns.Add(EnrollmentDateCol);
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
// column TotalWorkHour
DataColumn TotalWorkHourCol = new DataColumn("TotalWorkHour", typeof(System.Int64));
TotalWorkHourCol.ReadOnly = true;
TotalWorkHourCol.AllowDBNull = false;
Columns.Add(TotalWorkHourCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptAlumniVoluntaryHourSummaryRow(builder);
}
public RptAlumniVoluntaryHourSummaryRow GetRptAlumniVoluntaryHourSummaryRow(int index) {
return (RptAlumniVoluntaryHourSummaryRow)Rows[index];
}
}
public partial class RptAlumniVoluntaryHourSummaryRow : DataRow {
internal RptAlumniVoluntaryHourSummaryRow(DataRowBuilder builder) : base(builder) {
}
public System.String FullName {
get {
return (System.String)this["FullName"];
}
}
public System.DateTime DateofBirth {
get {
return (System.DateTime)this["DateofBirth"];
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
public System.DateTime EnrollmentDate {
get {
return (System.DateTime)this["EnrollmentDate"];
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
public System.Int64 TotalWorkHour {
get {
return (System.Int64)this["TotalWorkHour"];
}
}
}
public partial class RptAlumniVoluntaryHourSummaryMinimalizedEntity {
public RptAlumniVoluntaryHourSummaryMinimalizedEntity() {}
public RptAlumniVoluntaryHourSummaryMinimalizedEntity(RptAlumniVoluntaryHourSummaryRow dr) {
this.FullName = dr.FullName;
this.DateofBirth = dr.DateofBirth;
this.Gender = dr.Gender;
this.ICNumber = dr.ICNumber;
this.Email = dr.Email;
this.PhoneNumber = dr.PhoneNumber;
this.Mobile = dr.Mobile;
this.EnrollmentDate = dr.EnrollmentDate;
this.CampusName = dr.CampusName;
this.CampusCity = dr.CampusCity;
this.ContractType = dr.ContractType;
this.TotalWorkHour = dr.TotalWorkHour;
}
public System.String FullName;
public System.DateTime DateofBirth;
public System.String Gender;
public System.String ICNumber;
public System.String Email;
public System.String PhoneNumber;
public System.String Mobile;
public System.DateTime EnrollmentDate;
public System.String CampusName;
public System.String CampusCity;
public System.String ContractType;
public System.Int64 TotalWorkHour;
}
public partial class RptAlumniVoluntaryHourSummaryAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptAlumniVoluntaryHourSummaryAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DateofBirth", "DateofBirth");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("ICNumber", "ICNumber");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
tmap.ColumnMappings.Add("Mobile", "Mobile");
tmap.ColumnMappings.Add("EnrollmentDate", "EnrollmentDate");
tmap.ColumnMappings.Add("CampusName", "CampusName");
tmap.ColumnMappings.Add("CampusCity", "CampusCity");
tmap.ColumnMappings.Add("ContractType", "ContractType");
tmap.ColumnMappings.Add("TotalWorkHour", "TotalWorkHour");
adapter.TableMappings.Add(tmap);
}
}
public RptAlumniVoluntaryHourSummaryRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptAlumniVoluntaryHourSummary] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptAlumniVoluntaryHourSummaryTable tbl = new RptAlumniVoluntaryHourSummaryTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptAlumniVoluntaryHourSummaryRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptAlumniVoluntaryHourSummary] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
