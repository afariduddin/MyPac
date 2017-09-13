using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CourseTSPDetailTable : DataTable {
// column indexes
public const int CourseTSP_IDColumnIndex = 0;
public const int Course_IDColumnIndex = 1;
public const int TSP_IDColumnIndex = 2;
public const int TSP_CampusNameColumnIndex = 3;
public const int TSP_Address1ColumnIndex = 4;
public const int TSP_Address2ColumnIndex = 5;
public const int TSP_PostcodeColumnIndex = 6;
public const int TSP_CityColumnIndex = 7;
public const int TSP_StateColumnIndex = 8;
public const int TSP_CountryColumnIndex = 9;
public const int TSP_ContactPersonColumnIndex = 10;
public const int TSP_EmailColumnIndex = 11;
public const int TSP_ContactNumberColumnIndex = 12;
public const int TSP_CourseTypeColumnIndex = 13;
public const int TSP_RemarkColumnIndex = 14;
public const int TSP_IsDeletedColumnIndex = 15;
public const int TSP_CreatedDateColumnIndex = 16;
public const int TSP_CreatedByColumnIndex = 17;
public const int TSP_UpdatedDateColumnIndex = 18;
public const int TSP_UpdatedByColumnIndex = 19;
public const int TSP_IntakeJanColumnIndex = 20;
public const int TSP_IntakeFebColumnIndex = 21;
public const int TSP_IntakeMarColumnIndex = 22;
public const int TSP_IntakeAprColumnIndex = 23;
public const int TSP_IntakeMayColumnIndex = 24;
public const int TSP_IntakeJunColumnIndex = 25;
public const int TSP_IntakeJulColumnIndex = 26;
public const int TSP_IntakeAugColumnIndex = 27;
public const int TSP_IntakeSepColumnIndex = 28;
public const int TSP_IntakeOctColumnIndex = 29;
public const int TSP_IntakeNovColumnIndex = 30;
public const int TSP_IntakeDecColumnIndex = 31;
public CourseTSPDetailTable() {
TableName = "[CourseTSPDetail]";
// column CourseTSP_ID
DataColumn CourseTSP_IDCol = new DataColumn("CourseTSP_ID", typeof(System.Guid));
CourseTSP_IDCol.ReadOnly = true;
CourseTSP_IDCol.AllowDBNull = false;
Columns.Add(CourseTSP_IDCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = true;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column TSP_CampusName
DataColumn TSP_CampusNameCol = new DataColumn("TSP_CampusName", typeof(System.String));
TSP_CampusNameCol.ReadOnly = true;
TSP_CampusNameCol.AllowDBNull = false;
Columns.Add(TSP_CampusNameCol);
// column TSP_Address1
DataColumn TSP_Address1Col = new DataColumn("TSP_Address1", typeof(System.String));
TSP_Address1Col.ReadOnly = true;
TSP_Address1Col.AllowDBNull = false;
Columns.Add(TSP_Address1Col);
// column TSP_Address2
DataColumn TSP_Address2Col = new DataColumn("TSP_Address2", typeof(System.String));
TSP_Address2Col.ReadOnly = true;
TSP_Address2Col.AllowDBNull = false;
Columns.Add(TSP_Address2Col);
// column TSP_Postcode
DataColumn TSP_PostcodeCol = new DataColumn("TSP_Postcode", typeof(System.String));
TSP_PostcodeCol.ReadOnly = true;
TSP_PostcodeCol.AllowDBNull = false;
Columns.Add(TSP_PostcodeCol);
// column TSP_City
DataColumn TSP_CityCol = new DataColumn("TSP_City", typeof(System.String));
TSP_CityCol.ReadOnly = true;
TSP_CityCol.AllowDBNull = false;
Columns.Add(TSP_CityCol);
// column TSP_State
DataColumn TSP_StateCol = new DataColumn("TSP_State", typeof(System.String));
TSP_StateCol.ReadOnly = true;
TSP_StateCol.AllowDBNull = false;
Columns.Add(TSP_StateCol);
// column TSP_Country
DataColumn TSP_CountryCol = new DataColumn("TSP_Country", typeof(System.String));
TSP_CountryCol.ReadOnly = true;
TSP_CountryCol.AllowDBNull = false;
Columns.Add(TSP_CountryCol);
// column TSP_ContactPerson
DataColumn TSP_ContactPersonCol = new DataColumn("TSP_ContactPerson", typeof(System.String));
TSP_ContactPersonCol.ReadOnly = true;
TSP_ContactPersonCol.AllowDBNull = false;
Columns.Add(TSP_ContactPersonCol);
// column TSP_Email
DataColumn TSP_EmailCol = new DataColumn("TSP_Email", typeof(System.String));
TSP_EmailCol.ReadOnly = true;
TSP_EmailCol.AllowDBNull = false;
Columns.Add(TSP_EmailCol);
// column TSP_ContactNumber
DataColumn TSP_ContactNumberCol = new DataColumn("TSP_ContactNumber", typeof(System.String));
TSP_ContactNumberCol.ReadOnly = true;
TSP_ContactNumberCol.AllowDBNull = false;
Columns.Add(TSP_ContactNumberCol);
// column TSP_CourseType
DataColumn TSP_CourseTypeCol = new DataColumn("TSP_CourseType", typeof(System.Int16));
TSP_CourseTypeCol.ReadOnly = true;
TSP_CourseTypeCol.AllowDBNull = true;
Columns.Add(TSP_CourseTypeCol);
// column TSP_Remark
DataColumn TSP_RemarkCol = new DataColumn("TSP_Remark", typeof(System.String));
TSP_RemarkCol.ReadOnly = true;
TSP_RemarkCol.AllowDBNull = false;
Columns.Add(TSP_RemarkCol);
// column TSP_IsDeleted
DataColumn TSP_IsDeletedCol = new DataColumn("TSP_IsDeleted", typeof(System.Boolean));
TSP_IsDeletedCol.ReadOnly = true;
TSP_IsDeletedCol.AllowDBNull = false;
Columns.Add(TSP_IsDeletedCol);
// column TSP_CreatedDate
DataColumn TSP_CreatedDateCol = new DataColumn("TSP_CreatedDate", typeof(System.DateTime));
TSP_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
TSP_CreatedDateCol.ReadOnly = true;
TSP_CreatedDateCol.AllowDBNull = false;
Columns.Add(TSP_CreatedDateCol);
// column TSP_CreatedBy
DataColumn TSP_CreatedByCol = new DataColumn("TSP_CreatedBy", typeof(System.String));
TSP_CreatedByCol.ReadOnly = true;
TSP_CreatedByCol.AllowDBNull = false;
Columns.Add(TSP_CreatedByCol);
// column TSP_UpdatedDate
DataColumn TSP_UpdatedDateCol = new DataColumn("TSP_UpdatedDate", typeof(System.DateTime));
TSP_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
TSP_UpdatedDateCol.ReadOnly = true;
TSP_UpdatedDateCol.AllowDBNull = false;
Columns.Add(TSP_UpdatedDateCol);
// column TSP_UpdatedBy
DataColumn TSP_UpdatedByCol = new DataColumn("TSP_UpdatedBy", typeof(System.String));
TSP_UpdatedByCol.ReadOnly = true;
TSP_UpdatedByCol.AllowDBNull = false;
Columns.Add(TSP_UpdatedByCol);
// column TSP_IntakeJan
DataColumn TSP_IntakeJanCol = new DataColumn("TSP_IntakeJan", typeof(System.Boolean));
TSP_IntakeJanCol.ReadOnly = true;
TSP_IntakeJanCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJanCol);
// column TSP_IntakeFeb
DataColumn TSP_IntakeFebCol = new DataColumn("TSP_IntakeFeb", typeof(System.Boolean));
TSP_IntakeFebCol.ReadOnly = true;
TSP_IntakeFebCol.AllowDBNull = false;
Columns.Add(TSP_IntakeFebCol);
// column TSP_IntakeMar
DataColumn TSP_IntakeMarCol = new DataColumn("TSP_IntakeMar", typeof(System.Boolean));
TSP_IntakeMarCol.ReadOnly = true;
TSP_IntakeMarCol.AllowDBNull = false;
Columns.Add(TSP_IntakeMarCol);
// column TSP_IntakeApr
DataColumn TSP_IntakeAprCol = new DataColumn("TSP_IntakeApr", typeof(System.Boolean));
TSP_IntakeAprCol.ReadOnly = true;
TSP_IntakeAprCol.AllowDBNull = false;
Columns.Add(TSP_IntakeAprCol);
// column TSP_IntakeMay
DataColumn TSP_IntakeMayCol = new DataColumn("TSP_IntakeMay", typeof(System.Boolean));
TSP_IntakeMayCol.ReadOnly = true;
TSP_IntakeMayCol.AllowDBNull = false;
Columns.Add(TSP_IntakeMayCol);
// column TSP_IntakeJun
DataColumn TSP_IntakeJunCol = new DataColumn("TSP_IntakeJun", typeof(System.Boolean));
TSP_IntakeJunCol.ReadOnly = true;
TSP_IntakeJunCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJunCol);
// column TSP_IntakeJul
DataColumn TSP_IntakeJulCol = new DataColumn("TSP_IntakeJul", typeof(System.Boolean));
TSP_IntakeJulCol.ReadOnly = true;
TSP_IntakeJulCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJulCol);
// column TSP_IntakeAug
DataColumn TSP_IntakeAugCol = new DataColumn("TSP_IntakeAug", typeof(System.Boolean));
TSP_IntakeAugCol.ReadOnly = true;
TSP_IntakeAugCol.AllowDBNull = false;
Columns.Add(TSP_IntakeAugCol);
// column TSP_IntakeSep
DataColumn TSP_IntakeSepCol = new DataColumn("TSP_IntakeSep", typeof(System.Boolean));
TSP_IntakeSepCol.ReadOnly = true;
TSP_IntakeSepCol.AllowDBNull = false;
Columns.Add(TSP_IntakeSepCol);
// column TSP_IntakeOct
DataColumn TSP_IntakeOctCol = new DataColumn("TSP_IntakeOct", typeof(System.Boolean));
TSP_IntakeOctCol.ReadOnly = true;
TSP_IntakeOctCol.AllowDBNull = false;
Columns.Add(TSP_IntakeOctCol);
// column TSP_IntakeNov
DataColumn TSP_IntakeNovCol = new DataColumn("TSP_IntakeNov", typeof(System.Boolean));
TSP_IntakeNovCol.ReadOnly = true;
TSP_IntakeNovCol.AllowDBNull = false;
Columns.Add(TSP_IntakeNovCol);
// column TSP_IntakeDec
DataColumn TSP_IntakeDecCol = new DataColumn("TSP_IntakeDec", typeof(System.Boolean));
TSP_IntakeDecCol.ReadOnly = true;
TSP_IntakeDecCol.AllowDBNull = false;
Columns.Add(TSP_IntakeDecCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CourseTSPDetailRow(builder);
}
public CourseTSPDetailRow GetCourseTSPDetailRow(int index) {
return (CourseTSPDetailRow)Rows[index];
}
}
public partial class CourseTSPDetailRow : DataRow {
internal CourseTSPDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid CourseTSP_ID {
get {
return (System.Guid)this["CourseTSP_ID"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
}
public System.String TSP_CampusName {
get {
return (System.String)this["TSP_CampusName"];
}
}
public System.String TSP_Address1 {
get {
return (System.String)this["TSP_Address1"];
}
}
public System.String TSP_Address2 {
get {
return (System.String)this["TSP_Address2"];
}
}
public System.String TSP_Postcode {
get {
return (System.String)this["TSP_Postcode"];
}
}
public System.String TSP_City {
get {
return (System.String)this["TSP_City"];
}
}
public System.String TSP_State {
get {
return (System.String)this["TSP_State"];
}
}
public System.String TSP_Country {
get {
return (System.String)this["TSP_Country"];
}
}
public System.String TSP_ContactPerson {
get {
return (System.String)this["TSP_ContactPerson"];
}
}
public System.String TSP_Email {
get {
return (System.String)this["TSP_Email"];
}
}
public System.String TSP_ContactNumber {
get {
return (System.String)this["TSP_ContactNumber"];
}
}
public System.Int16? TSP_CourseType {
get {
if( IsNull("TSP_CourseType") ) return null;
else return (System.Int16)this["TSP_CourseType"];
}
}
public System.String TSP_Remark {
get {
return (System.String)this["TSP_Remark"];
}
}
public System.Boolean TSP_IsDeleted {
get {
return (System.Boolean)this["TSP_IsDeleted"];
}
}
public System.DateTime TSP_CreatedDate {
get {
return (System.DateTime)this["TSP_CreatedDate"];
}
}
public System.String TSP_CreatedBy {
get {
return (System.String)this["TSP_CreatedBy"];
}
}
public System.DateTime TSP_UpdatedDate {
get {
return (System.DateTime)this["TSP_UpdatedDate"];
}
}
public System.String TSP_UpdatedBy {
get {
return (System.String)this["TSP_UpdatedBy"];
}
}
public System.Boolean TSP_IntakeJan {
get {
return (System.Boolean)this["TSP_IntakeJan"];
}
}
public System.Boolean TSP_IntakeFeb {
get {
return (System.Boolean)this["TSP_IntakeFeb"];
}
}
public System.Boolean TSP_IntakeMar {
get {
return (System.Boolean)this["TSP_IntakeMar"];
}
}
public System.Boolean TSP_IntakeApr {
get {
return (System.Boolean)this["TSP_IntakeApr"];
}
}
public System.Boolean TSP_IntakeMay {
get {
return (System.Boolean)this["TSP_IntakeMay"];
}
}
public System.Boolean TSP_IntakeJun {
get {
return (System.Boolean)this["TSP_IntakeJun"];
}
}
public System.Boolean TSP_IntakeJul {
get {
return (System.Boolean)this["TSP_IntakeJul"];
}
}
public System.Boolean TSP_IntakeAug {
get {
return (System.Boolean)this["TSP_IntakeAug"];
}
}
public System.Boolean TSP_IntakeSep {
get {
return (System.Boolean)this["TSP_IntakeSep"];
}
}
public System.Boolean TSP_IntakeOct {
get {
return (System.Boolean)this["TSP_IntakeOct"];
}
}
public System.Boolean TSP_IntakeNov {
get {
return (System.Boolean)this["TSP_IntakeNov"];
}
}
public System.Boolean TSP_IntakeDec {
get {
return (System.Boolean)this["TSP_IntakeDec"];
}
}
}
public partial class CourseTSPDetailMinimalizedEntity {
public CourseTSPDetailMinimalizedEntity() {}
public CourseTSPDetailMinimalizedEntity(CourseTSPDetailRow dr) {
this.CourseTSP_ID = dr.CourseTSP_ID;
this.Course_ID = dr.Course_ID;
this.TSP_ID = dr.TSP_ID;
this.TSP_CampusName = dr.TSP_CampusName;
this.TSP_Address1 = dr.TSP_Address1;
this.TSP_Address2 = dr.TSP_Address2;
this.TSP_Postcode = dr.TSP_Postcode;
this.TSP_City = dr.TSP_City;
this.TSP_State = dr.TSP_State;
this.TSP_Country = dr.TSP_Country;
this.TSP_ContactPerson = dr.TSP_ContactPerson;
this.TSP_Email = dr.TSP_Email;
this.TSP_ContactNumber = dr.TSP_ContactNumber;
this.TSP_CourseType = dr.TSP_CourseType;
this.TSP_Remark = dr.TSP_Remark;
this.TSP_IsDeleted = dr.TSP_IsDeleted;
this.TSP_CreatedDate = dr.TSP_CreatedDate;
this.TSP_CreatedBy = dr.TSP_CreatedBy;
this.TSP_UpdatedDate = dr.TSP_UpdatedDate;
this.TSP_UpdatedBy = dr.TSP_UpdatedBy;
this.TSP_IntakeJan = dr.TSP_IntakeJan;
this.TSP_IntakeFeb = dr.TSP_IntakeFeb;
this.TSP_IntakeMar = dr.TSP_IntakeMar;
this.TSP_IntakeApr = dr.TSP_IntakeApr;
this.TSP_IntakeMay = dr.TSP_IntakeMay;
this.TSP_IntakeJun = dr.TSP_IntakeJun;
this.TSP_IntakeJul = dr.TSP_IntakeJul;
this.TSP_IntakeAug = dr.TSP_IntakeAug;
this.TSP_IntakeSep = dr.TSP_IntakeSep;
this.TSP_IntakeOct = dr.TSP_IntakeOct;
this.TSP_IntakeNov = dr.TSP_IntakeNov;
this.TSP_IntakeDec = dr.TSP_IntakeDec;
}
public System.Guid CourseTSP_ID;
public System.Guid Course_ID;
public System.Guid TSP_ID;
public System.String TSP_CampusName;
public System.String TSP_Address1;
public System.String TSP_Address2;
public System.String TSP_Postcode;
public System.String TSP_City;
public System.String TSP_State;
public System.String TSP_Country;
public System.String TSP_ContactPerson;
public System.String TSP_Email;
public System.String TSP_ContactNumber;
public System.Int16? TSP_CourseType;
public System.String TSP_Remark;
public System.Boolean TSP_IsDeleted;
public System.DateTime TSP_CreatedDate;
public System.String TSP_CreatedBy;
public System.DateTime TSP_UpdatedDate;
public System.String TSP_UpdatedBy;
public System.Boolean TSP_IntakeJan;
public System.Boolean TSP_IntakeFeb;
public System.Boolean TSP_IntakeMar;
public System.Boolean TSP_IntakeApr;
public System.Boolean TSP_IntakeMay;
public System.Boolean TSP_IntakeJun;
public System.Boolean TSP_IntakeJul;
public System.Boolean TSP_IntakeAug;
public System.Boolean TSP_IntakeSep;
public System.Boolean TSP_IntakeOct;
public System.Boolean TSP_IntakeNov;
public System.Boolean TSP_IntakeDec;
}
public partial class CourseTSPDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CourseTSPDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("CourseTSP_ID", "CourseTSP_ID");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("TSP_CampusName", "TSP_CampusName");
tmap.ColumnMappings.Add("TSP_Address1", "TSP_Address1");
tmap.ColumnMappings.Add("TSP_Address2", "TSP_Address2");
tmap.ColumnMappings.Add("TSP_Postcode", "TSP_Postcode");
tmap.ColumnMappings.Add("TSP_City", "TSP_City");
tmap.ColumnMappings.Add("TSP_State", "TSP_State");
tmap.ColumnMappings.Add("TSP_Country", "TSP_Country");
tmap.ColumnMappings.Add("TSP_ContactPerson", "TSP_ContactPerson");
tmap.ColumnMappings.Add("TSP_Email", "TSP_Email");
tmap.ColumnMappings.Add("TSP_ContactNumber", "TSP_ContactNumber");
tmap.ColumnMappings.Add("TSP_CourseType", "TSP_CourseType");
tmap.ColumnMappings.Add("TSP_Remark", "TSP_Remark");
tmap.ColumnMappings.Add("TSP_IsDeleted", "TSP_IsDeleted");
tmap.ColumnMappings.Add("TSP_CreatedDate", "TSP_CreatedDate");
tmap.ColumnMappings.Add("TSP_CreatedBy", "TSP_CreatedBy");
tmap.ColumnMappings.Add("TSP_UpdatedDate", "TSP_UpdatedDate");
tmap.ColumnMappings.Add("TSP_UpdatedBy", "TSP_UpdatedBy");
tmap.ColumnMappings.Add("TSP_IntakeJan", "TSP_IntakeJan");
tmap.ColumnMappings.Add("TSP_IntakeFeb", "TSP_IntakeFeb");
tmap.ColumnMappings.Add("TSP_IntakeMar", "TSP_IntakeMar");
tmap.ColumnMappings.Add("TSP_IntakeApr", "TSP_IntakeApr");
tmap.ColumnMappings.Add("TSP_IntakeMay", "TSP_IntakeMay");
tmap.ColumnMappings.Add("TSP_IntakeJun", "TSP_IntakeJun");
tmap.ColumnMappings.Add("TSP_IntakeJul", "TSP_IntakeJul");
tmap.ColumnMappings.Add("TSP_IntakeAug", "TSP_IntakeAug");
tmap.ColumnMappings.Add("TSP_IntakeSep", "TSP_IntakeSep");
tmap.ColumnMappings.Add("TSP_IntakeOct", "TSP_IntakeOct");
tmap.ColumnMappings.Add("TSP_IntakeNov", "TSP_IntakeNov");
tmap.ColumnMappings.Add("TSP_IntakeDec", "TSP_IntakeDec");
adapter.TableMappings.Add(tmap);
}
}
public CourseTSPDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [CourseTSPDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

CourseTSPDetailTable tbl = new CourseTSPDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCourseTSPDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [CourseTSPDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
