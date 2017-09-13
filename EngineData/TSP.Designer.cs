using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class TSPTable : DataTable {
// column indexes
public const int TSP_IDColumnIndex = 0;
public const int TSP_CampusNameColumnIndex = 1;
public const int TSP_Address1ColumnIndex = 2;
public const int TSP_Address2ColumnIndex = 3;
public const int TSP_PostcodeColumnIndex = 4;
public const int TSP_CityColumnIndex = 5;
public const int TSP_StateColumnIndex = 6;
public const int TSP_CountryColumnIndex = 7;
public const int TSP_ContactPersonColumnIndex = 8;
public const int TSP_EmailColumnIndex = 9;
public const int TSP_ContactNumberColumnIndex = 10;
public const int TSP_CourseTypeColumnIndex = 11;
public const int TSP_RemarkColumnIndex = 12;
public const int TSP_IsDeletedColumnIndex = 13;
public const int TSP_CreatedDateColumnIndex = 14;
public const int TSP_CreatedByColumnIndex = 15;
public const int TSP_UpdatedDateColumnIndex = 16;
public const int TSP_UpdatedByColumnIndex = 17;
public const int TSP_IntakeJanColumnIndex = 18;
public const int TSP_IntakeFebColumnIndex = 19;
public const int TSP_IntakeMarColumnIndex = 20;
public const int TSP_IntakeAprColumnIndex = 21;
public const int TSP_IntakeMayColumnIndex = 22;
public const int TSP_IntakeJunColumnIndex = 23;
public const int TSP_IntakeJulColumnIndex = 24;
public const int TSP_IntakeAugColumnIndex = 25;
public const int TSP_IntakeSepColumnIndex = 26;
public const int TSP_IntakeOctColumnIndex = 27;
public const int TSP_IntakeNovColumnIndex = 28;
public const int TSP_IntakeDecColumnIndex = 29;
public TSPTable() {
TableName = "[TSP]";
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = false;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column TSP_CampusName
DataColumn TSP_CampusNameCol = new DataColumn("TSP_CampusName", typeof(System.String));
TSP_CampusNameCol.ReadOnly = false;
TSP_CampusNameCol.AllowDBNull = false;
Columns.Add(TSP_CampusNameCol);
// column TSP_Address1
DataColumn TSP_Address1Col = new DataColumn("TSP_Address1", typeof(System.String));
TSP_Address1Col.ReadOnly = false;
TSP_Address1Col.AllowDBNull = false;
Columns.Add(TSP_Address1Col);
// column TSP_Address2
DataColumn TSP_Address2Col = new DataColumn("TSP_Address2", typeof(System.String));
TSP_Address2Col.ReadOnly = false;
TSP_Address2Col.AllowDBNull = false;
Columns.Add(TSP_Address2Col);
// column TSP_Postcode
DataColumn TSP_PostcodeCol = new DataColumn("TSP_Postcode", typeof(System.String));
TSP_PostcodeCol.ReadOnly = false;
TSP_PostcodeCol.AllowDBNull = false;
Columns.Add(TSP_PostcodeCol);
// column TSP_City
DataColumn TSP_CityCol = new DataColumn("TSP_City", typeof(System.String));
TSP_CityCol.ReadOnly = false;
TSP_CityCol.AllowDBNull = false;
Columns.Add(TSP_CityCol);
// column TSP_State
DataColumn TSP_StateCol = new DataColumn("TSP_State", typeof(System.String));
TSP_StateCol.ReadOnly = false;
TSP_StateCol.AllowDBNull = false;
Columns.Add(TSP_StateCol);
// column TSP_Country
DataColumn TSP_CountryCol = new DataColumn("TSP_Country", typeof(System.String));
TSP_CountryCol.ReadOnly = false;
TSP_CountryCol.AllowDBNull = false;
Columns.Add(TSP_CountryCol);
// column TSP_ContactPerson
DataColumn TSP_ContactPersonCol = new DataColumn("TSP_ContactPerson", typeof(System.String));
TSP_ContactPersonCol.ReadOnly = false;
TSP_ContactPersonCol.AllowDBNull = false;
Columns.Add(TSP_ContactPersonCol);
// column TSP_Email
DataColumn TSP_EmailCol = new DataColumn("TSP_Email", typeof(System.String));
TSP_EmailCol.ReadOnly = false;
TSP_EmailCol.AllowDBNull = false;
Columns.Add(TSP_EmailCol);
// column TSP_ContactNumber
DataColumn TSP_ContactNumberCol = new DataColumn("TSP_ContactNumber", typeof(System.String));
TSP_ContactNumberCol.ReadOnly = false;
TSP_ContactNumberCol.AllowDBNull = false;
Columns.Add(TSP_ContactNumberCol);
// column TSP_CourseType
DataColumn TSP_CourseTypeCol = new DataColumn("TSP_CourseType", typeof(System.Int16));
TSP_CourseTypeCol.ReadOnly = false;
TSP_CourseTypeCol.AllowDBNull = true;
Columns.Add(TSP_CourseTypeCol);
// column TSP_Remark
DataColumn TSP_RemarkCol = new DataColumn("TSP_Remark", typeof(System.String));
TSP_RemarkCol.ReadOnly = false;
TSP_RemarkCol.AllowDBNull = false;
Columns.Add(TSP_RemarkCol);
// column TSP_IsDeleted
DataColumn TSP_IsDeletedCol = new DataColumn("TSP_IsDeleted", typeof(System.Boolean));
TSP_IsDeletedCol.ReadOnly = false;
TSP_IsDeletedCol.AllowDBNull = false;
Columns.Add(TSP_IsDeletedCol);
// column TSP_CreatedDate
DataColumn TSP_CreatedDateCol = new DataColumn("TSP_CreatedDate", typeof(System.DateTime));
TSP_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
TSP_CreatedDateCol.ReadOnly = false;
TSP_CreatedDateCol.AllowDBNull = false;
Columns.Add(TSP_CreatedDateCol);
// column TSP_CreatedBy
DataColumn TSP_CreatedByCol = new DataColumn("TSP_CreatedBy", typeof(System.String));
TSP_CreatedByCol.ReadOnly = false;
TSP_CreatedByCol.AllowDBNull = false;
Columns.Add(TSP_CreatedByCol);
// column TSP_UpdatedDate
DataColumn TSP_UpdatedDateCol = new DataColumn("TSP_UpdatedDate", typeof(System.DateTime));
TSP_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
TSP_UpdatedDateCol.ReadOnly = false;
TSP_UpdatedDateCol.AllowDBNull = false;
Columns.Add(TSP_UpdatedDateCol);
// column TSP_UpdatedBy
DataColumn TSP_UpdatedByCol = new DataColumn("TSP_UpdatedBy", typeof(System.String));
TSP_UpdatedByCol.ReadOnly = false;
TSP_UpdatedByCol.AllowDBNull = false;
Columns.Add(TSP_UpdatedByCol);
// column TSP_IntakeJan
DataColumn TSP_IntakeJanCol = new DataColumn("TSP_IntakeJan", typeof(System.Boolean));
TSP_IntakeJanCol.ReadOnly = false;
TSP_IntakeJanCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJanCol);
// column TSP_IntakeFeb
DataColumn TSP_IntakeFebCol = new DataColumn("TSP_IntakeFeb", typeof(System.Boolean));
TSP_IntakeFebCol.ReadOnly = false;
TSP_IntakeFebCol.AllowDBNull = false;
Columns.Add(TSP_IntakeFebCol);
// column TSP_IntakeMar
DataColumn TSP_IntakeMarCol = new DataColumn("TSP_IntakeMar", typeof(System.Boolean));
TSP_IntakeMarCol.ReadOnly = false;
TSP_IntakeMarCol.AllowDBNull = false;
Columns.Add(TSP_IntakeMarCol);
// column TSP_IntakeApr
DataColumn TSP_IntakeAprCol = new DataColumn("TSP_IntakeApr", typeof(System.Boolean));
TSP_IntakeAprCol.ReadOnly = false;
TSP_IntakeAprCol.AllowDBNull = false;
Columns.Add(TSP_IntakeAprCol);
// column TSP_IntakeMay
DataColumn TSP_IntakeMayCol = new DataColumn("TSP_IntakeMay", typeof(System.Boolean));
TSP_IntakeMayCol.ReadOnly = false;
TSP_IntakeMayCol.AllowDBNull = false;
Columns.Add(TSP_IntakeMayCol);
// column TSP_IntakeJun
DataColumn TSP_IntakeJunCol = new DataColumn("TSP_IntakeJun", typeof(System.Boolean));
TSP_IntakeJunCol.ReadOnly = false;
TSP_IntakeJunCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJunCol);
// column TSP_IntakeJul
DataColumn TSP_IntakeJulCol = new DataColumn("TSP_IntakeJul", typeof(System.Boolean));
TSP_IntakeJulCol.ReadOnly = false;
TSP_IntakeJulCol.AllowDBNull = false;
Columns.Add(TSP_IntakeJulCol);
// column TSP_IntakeAug
DataColumn TSP_IntakeAugCol = new DataColumn("TSP_IntakeAug", typeof(System.Boolean));
TSP_IntakeAugCol.ReadOnly = false;
TSP_IntakeAugCol.AllowDBNull = false;
Columns.Add(TSP_IntakeAugCol);
// column TSP_IntakeSep
DataColumn TSP_IntakeSepCol = new DataColumn("TSP_IntakeSep", typeof(System.Boolean));
TSP_IntakeSepCol.ReadOnly = false;
TSP_IntakeSepCol.AllowDBNull = false;
Columns.Add(TSP_IntakeSepCol);
// column TSP_IntakeOct
DataColumn TSP_IntakeOctCol = new DataColumn("TSP_IntakeOct", typeof(System.Boolean));
TSP_IntakeOctCol.ReadOnly = false;
TSP_IntakeOctCol.AllowDBNull = false;
Columns.Add(TSP_IntakeOctCol);
// column TSP_IntakeNov
DataColumn TSP_IntakeNovCol = new DataColumn("TSP_IntakeNov", typeof(System.Boolean));
TSP_IntakeNovCol.ReadOnly = false;
TSP_IntakeNovCol.AllowDBNull = false;
Columns.Add(TSP_IntakeNovCol);
// column TSP_IntakeDec
DataColumn TSP_IntakeDecCol = new DataColumn("TSP_IntakeDec", typeof(System.Boolean));
TSP_IntakeDecCol.ReadOnly = false;
TSP_IntakeDecCol.AllowDBNull = false;
Columns.Add(TSP_IntakeDecCol);
}
public TSPRow NewTSPRow() {
TSPRow row = (TSPRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(TSPRow row) {
row.TSP_ID = Guid.Empty;
row.TSP_CampusName = "";
row.TSP_Address1 = "";
row.TSP_Address2 = "";
row.TSP_Postcode = "";
row.TSP_City = "";
row.TSP_State = "";
row.TSP_Country = "";
row.TSP_ContactPerson = "";
row.TSP_Email = "";
row.TSP_ContactNumber = "";
row.TSP_Remark = "";
row.TSP_IsDeleted = false;
row.TSP_CreatedDate = DateTime.Now;
row.TSP_CreatedBy = "";
row.TSP_UpdatedDate = DateTime.Now;
row.TSP_UpdatedBy = "";
row.TSP_IntakeJan = false;
row.TSP_IntakeFeb = false;
row.TSP_IntakeMar = false;
row.TSP_IntakeApr = false;
row.TSP_IntakeMay = false;
row.TSP_IntakeJun = false;
row.TSP_IntakeJul = false;
row.TSP_IntakeAug = false;
row.TSP_IntakeSep = false;
row.TSP_IntakeOct = false;
row.TSP_IntakeNov = false;
row.TSP_IntakeDec = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new TSPRow(builder);
}
public TSPRow GetTSPRow(int index) {
return (TSPRow)Rows[index];
}
}
public partial class TSPRow : DataRow {
internal TSPRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
set {
this["TSP_ID"] = value;
}
}
public System.String TSP_CampusName {
get {
return (System.String)this["TSP_CampusName"];
}
set {
if( value.Length > 100 ) this["TSP_CampusName"] = value.Substring(0, 100);
else this["TSP_CampusName"] = value;
}
}
public System.String TSP_Address1 {
get {
return (System.String)this["TSP_Address1"];
}
set {
if( value.Length > 50 ) this["TSP_Address1"] = value.Substring(0, 50);
else this["TSP_Address1"] = value;
}
}
public System.String TSP_Address2 {
get {
return (System.String)this["TSP_Address2"];
}
set {
if( value.Length > 50 ) this["TSP_Address2"] = value.Substring(0, 50);
else this["TSP_Address2"] = value;
}
}
public System.String TSP_Postcode {
get {
return (System.String)this["TSP_Postcode"];
}
set {
if( value.Length > 50 ) this["TSP_Postcode"] = value.Substring(0, 50);
else this["TSP_Postcode"] = value;
}
}
public System.String TSP_City {
get {
return (System.String)this["TSP_City"];
}
set {
if( value.Length > 50 ) this["TSP_City"] = value.Substring(0, 50);
else this["TSP_City"] = value;
}
}
public System.String TSP_State {
get {
return (System.String)this["TSP_State"];
}
set {
if( value.Length > 50 ) this["TSP_State"] = value.Substring(0, 50);
else this["TSP_State"] = value;
}
}
public System.String TSP_Country {
get {
return (System.String)this["TSP_Country"];
}
set {
if( value.Length > 50 ) this["TSP_Country"] = value.Substring(0, 50);
else this["TSP_Country"] = value;
}
}
public System.String TSP_ContactPerson {
get {
return (System.String)this["TSP_ContactPerson"];
}
set {
if( value.Length > 100 ) this["TSP_ContactPerson"] = value.Substring(0, 100);
else this["TSP_ContactPerson"] = value;
}
}
public System.String TSP_Email {
get {
return (System.String)this["TSP_Email"];
}
set {
if( value.Length > 50 ) this["TSP_Email"] = value.Substring(0, 50);
else this["TSP_Email"] = value;
}
}
public System.String TSP_ContactNumber {
get {
return (System.String)this["TSP_ContactNumber"];
}
set {
if( value.Length > 50 ) this["TSP_ContactNumber"] = value.Substring(0, 50);
else this["TSP_ContactNumber"] = value;
}
}
public System.Int16? TSP_CourseType {
get {
if( IsNull("TSP_CourseType") ) return null;
else return (System.Int16)this["TSP_CourseType"];
}
set {
if( value.HasValue ) this["TSP_CourseType"] = value;
else SetNull(Table.Columns["TSP_CourseType"]);
}
}
public System.String TSP_Remark {
get {
return (System.String)this["TSP_Remark"];
}
set {
if( value.Length > 1000 ) this["TSP_Remark"] = value.Substring(0, 1000);
else this["TSP_Remark"] = value;
}
}
public System.Boolean TSP_IsDeleted {
get {
return (System.Boolean)this["TSP_IsDeleted"];
}
set {
this["TSP_IsDeleted"] = value;
}
}
public System.DateTime TSP_CreatedDate {
get {
return (System.DateTime)this["TSP_CreatedDate"];
}
set {
this["TSP_CreatedDate"] = value;
}
}
public System.String TSP_CreatedBy {
get {
return (System.String)this["TSP_CreatedBy"];
}
set {
if( value.Length > 50 ) this["TSP_CreatedBy"] = value.Substring(0, 50);
else this["TSP_CreatedBy"] = value;
}
}
public System.DateTime TSP_UpdatedDate {
get {
return (System.DateTime)this["TSP_UpdatedDate"];
}
set {
this["TSP_UpdatedDate"] = value;
}
}
public System.String TSP_UpdatedBy {
get {
return (System.String)this["TSP_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["TSP_UpdatedBy"] = value.Substring(0, 50);
else this["TSP_UpdatedBy"] = value;
}
}
public System.Boolean TSP_IntakeJan {
get {
return (System.Boolean)this["TSP_IntakeJan"];
}
set {
this["TSP_IntakeJan"] = value;
}
}
public System.Boolean TSP_IntakeFeb {
get {
return (System.Boolean)this["TSP_IntakeFeb"];
}
set {
this["TSP_IntakeFeb"] = value;
}
}
public System.Boolean TSP_IntakeMar {
get {
return (System.Boolean)this["TSP_IntakeMar"];
}
set {
this["TSP_IntakeMar"] = value;
}
}
public System.Boolean TSP_IntakeApr {
get {
return (System.Boolean)this["TSP_IntakeApr"];
}
set {
this["TSP_IntakeApr"] = value;
}
}
public System.Boolean TSP_IntakeMay {
get {
return (System.Boolean)this["TSP_IntakeMay"];
}
set {
this["TSP_IntakeMay"] = value;
}
}
public System.Boolean TSP_IntakeJun {
get {
return (System.Boolean)this["TSP_IntakeJun"];
}
set {
this["TSP_IntakeJun"] = value;
}
}
public System.Boolean TSP_IntakeJul {
get {
return (System.Boolean)this["TSP_IntakeJul"];
}
set {
this["TSP_IntakeJul"] = value;
}
}
public System.Boolean TSP_IntakeAug {
get {
return (System.Boolean)this["TSP_IntakeAug"];
}
set {
this["TSP_IntakeAug"] = value;
}
}
public System.Boolean TSP_IntakeSep {
get {
return (System.Boolean)this["TSP_IntakeSep"];
}
set {
this["TSP_IntakeSep"] = value;
}
}
public System.Boolean TSP_IntakeOct {
get {
return (System.Boolean)this["TSP_IntakeOct"];
}
set {
this["TSP_IntakeOct"] = value;
}
}
public System.Boolean TSP_IntakeNov {
get {
return (System.Boolean)this["TSP_IntakeNov"];
}
set {
this["TSP_IntakeNov"] = value;
}
}
public System.Boolean TSP_IntakeDec {
get {
return (System.Boolean)this["TSP_IntakeDec"];
}
set {
this["TSP_IntakeDec"] = value;
}
}
}
public partial class TSPMinimalizedEntity {
public TSPMinimalizedEntity() {}
public TSPMinimalizedEntity(TSPRow dr) {
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
public void CopyTo(TSPRow dr) {
dr.TSP_ID = this.TSP_ID;
dr.TSP_CampusName = this.TSP_CampusName;
dr.TSP_Address1 = this.TSP_Address1;
dr.TSP_Address2 = this.TSP_Address2;
dr.TSP_Postcode = this.TSP_Postcode;
dr.TSP_City = this.TSP_City;
dr.TSP_State = this.TSP_State;
dr.TSP_Country = this.TSP_Country;
dr.TSP_ContactPerson = this.TSP_ContactPerson;
dr.TSP_Email = this.TSP_Email;
dr.TSP_ContactNumber = this.TSP_ContactNumber;
dr.TSP_CourseType = this.TSP_CourseType;
dr.TSP_Remark = this.TSP_Remark;
dr.TSP_IsDeleted = this.TSP_IsDeleted;
dr.TSP_CreatedDate = this.TSP_CreatedDate;
dr.TSP_CreatedBy = this.TSP_CreatedBy;
dr.TSP_UpdatedDate = this.TSP_UpdatedDate;
dr.TSP_UpdatedBy = this.TSP_UpdatedBy;
dr.TSP_IntakeJan = this.TSP_IntakeJan;
dr.TSP_IntakeFeb = this.TSP_IntakeFeb;
dr.TSP_IntakeMar = this.TSP_IntakeMar;
dr.TSP_IntakeApr = this.TSP_IntakeApr;
dr.TSP_IntakeMay = this.TSP_IntakeMay;
dr.TSP_IntakeJun = this.TSP_IntakeJun;
dr.TSP_IntakeJul = this.TSP_IntakeJul;
dr.TSP_IntakeAug = this.TSP_IntakeAug;
dr.TSP_IntakeSep = this.TSP_IntakeSep;
dr.TSP_IntakeOct = this.TSP_IntakeOct;
dr.TSP_IntakeNov = this.TSP_IntakeNov;
dr.TSP_IntakeDec = this.TSP_IntakeDec;
}
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
public partial class TSPAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public TSPAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
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
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [TSP] ([TSP_ID], [TSP_CampusName], [TSP_Address1], [TSP_Address2], [TSP_Postcode], [TSP_City], [TSP_State], [TSP_Country], [TSP_ContactPerson], [TSP_Email], [TSP_ContactNumber], [TSP_CourseType], [TSP_Remark], [TSP_IsDeleted], [TSP_CreatedDate], [TSP_CreatedBy], [TSP_UpdatedDate], [TSP_UpdatedBy], [TSP_IntakeJan], [TSP_IntakeFeb], [TSP_IntakeMar], [TSP_IntakeApr], [TSP_IntakeMay], [TSP_IntakeJun], [TSP_IntakeJul], [TSP_IntakeAug], [TSP_IntakeSep], [TSP_IntakeOct], [TSP_IntakeNov], [TSP_IntakeDec]) VALUES (@TSP_ID, @TSP_CampusName, @TSP_Address1, @TSP_Address2, @TSP_Postcode, @TSP_City, @TSP_State, @TSP_Country, @TSP_ContactPerson, @TSP_Email, @TSP_ContactNumber, @TSP_CourseType, @TSP_Remark, @TSP_IsDeleted, @TSP_CreatedDate, @TSP_CreatedBy, @TSP_UpdatedDate, @TSP_UpdatedBy, @TSP_IntakeJan, @TSP_IntakeFeb, @TSP_IntakeMar, @TSP_IntakeApr, @TSP_IntakeMay, @TSP_IntakeJun, @TSP_IntakeJul, @TSP_IntakeAug, @TSP_IntakeSep, @TSP_IntakeOct, @TSP_IntakeNov, @TSP_IntakeDec)");
adapter.InsertCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.InsertCommand.Parameters.Add("@TSP_CampusName", SqlDbType.NVarChar, 0, "TSP_CampusName");
adapter.InsertCommand.Parameters.Add("@TSP_Address1", SqlDbType.NVarChar, 0, "TSP_Address1");
adapter.InsertCommand.Parameters.Add("@TSP_Address2", SqlDbType.NVarChar, 0, "TSP_Address2");
adapter.InsertCommand.Parameters.Add("@TSP_Postcode", SqlDbType.NVarChar, 0, "TSP_Postcode");
adapter.InsertCommand.Parameters.Add("@TSP_City", SqlDbType.NVarChar, 0, "TSP_City");
adapter.InsertCommand.Parameters.Add("@TSP_State", SqlDbType.NVarChar, 0, "TSP_State");
adapter.InsertCommand.Parameters.Add("@TSP_Country", SqlDbType.NVarChar, 0, "TSP_Country");
adapter.InsertCommand.Parameters.Add("@TSP_ContactPerson", SqlDbType.NVarChar, 0, "TSP_ContactPerson");
adapter.InsertCommand.Parameters.Add("@TSP_Email", SqlDbType.NVarChar, 0, "TSP_Email");
adapter.InsertCommand.Parameters.Add("@TSP_ContactNumber", SqlDbType.NVarChar, 0, "TSP_ContactNumber");
adapter.InsertCommand.Parameters.Add("@TSP_CourseType", SqlDbType.SmallInt, 0, "TSP_CourseType");
adapter.InsertCommand.Parameters.Add("@TSP_Remark", SqlDbType.NVarChar, 0, "TSP_Remark");
adapter.InsertCommand.Parameters.Add("@TSP_IsDeleted", SqlDbType.Bit, 0, "TSP_IsDeleted");
adapter.InsertCommand.Parameters.Add("@TSP_CreatedDate", SqlDbType.DateTime, 0, "TSP_CreatedDate");
adapter.InsertCommand.Parameters.Add("@TSP_CreatedBy", SqlDbType.NVarChar, 0, "TSP_CreatedBy");
adapter.InsertCommand.Parameters.Add("@TSP_UpdatedDate", SqlDbType.DateTime, 0, "TSP_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@TSP_UpdatedBy", SqlDbType.NVarChar, 0, "TSP_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeJan", SqlDbType.Bit, 0, "TSP_IntakeJan");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeFeb", SqlDbType.Bit, 0, "TSP_IntakeFeb");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeMar", SqlDbType.Bit, 0, "TSP_IntakeMar");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeApr", SqlDbType.Bit, 0, "TSP_IntakeApr");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeMay", SqlDbType.Bit, 0, "TSP_IntakeMay");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeJun", SqlDbType.Bit, 0, "TSP_IntakeJun");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeJul", SqlDbType.Bit, 0, "TSP_IntakeJul");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeAug", SqlDbType.Bit, 0, "TSP_IntakeAug");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeSep", SqlDbType.Bit, 0, "TSP_IntakeSep");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeOct", SqlDbType.Bit, 0, "TSP_IntakeOct");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeNov", SqlDbType.Bit, 0, "TSP_IntakeNov");
adapter.InsertCommand.Parameters.Add("@TSP_IntakeDec", SqlDbType.Bit, 0, "TSP_IntakeDec");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [TSP] SET [TSP_ID] = @TSP_ID, [TSP_CampusName] = @TSP_CampusName, [TSP_Address1] = @TSP_Address1, [TSP_Address2] = @TSP_Address2, [TSP_Postcode] = @TSP_Postcode, [TSP_City] = @TSP_City, [TSP_State] = @TSP_State, [TSP_Country] = @TSP_Country, [TSP_ContactPerson] = @TSP_ContactPerson, [TSP_Email] = @TSP_Email, [TSP_ContactNumber] = @TSP_ContactNumber, [TSP_CourseType] = @TSP_CourseType, [TSP_Remark] = @TSP_Remark, [TSP_IsDeleted] = @TSP_IsDeleted, [TSP_CreatedDate] = @TSP_CreatedDate, [TSP_CreatedBy] = @TSP_CreatedBy, [TSP_UpdatedDate] = @TSP_UpdatedDate, [TSP_UpdatedBy] = @TSP_UpdatedBy, [TSP_IntakeJan] = @TSP_IntakeJan, [TSP_IntakeFeb] = @TSP_IntakeFeb, [TSP_IntakeMar] = @TSP_IntakeMar, [TSP_IntakeApr] = @TSP_IntakeApr, [TSP_IntakeMay] = @TSP_IntakeMay, [TSP_IntakeJun] = @TSP_IntakeJun, [TSP_IntakeJul] = @TSP_IntakeJul, [TSP_IntakeAug] = @TSP_IntakeAug, [TSP_IntakeSep] = @TSP_IntakeSep, [TSP_IntakeOct] = @TSP_IntakeOct, [TSP_IntakeNov] = @TSP_IntakeNov, [TSP_IntakeDec] = @TSP_IntakeDec WHERE [TSP_ID] = @o_TSP_ID");
adapter.UpdateCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_TSP_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "TSP_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@TSP_CampusName", SqlDbType.NVarChar, 0, "TSP_CampusName");
adapter.UpdateCommand.Parameters.Add("@TSP_Address1", SqlDbType.NVarChar, 0, "TSP_Address1");
adapter.UpdateCommand.Parameters.Add("@TSP_Address2", SqlDbType.NVarChar, 0, "TSP_Address2");
adapter.UpdateCommand.Parameters.Add("@TSP_Postcode", SqlDbType.NVarChar, 0, "TSP_Postcode");
adapter.UpdateCommand.Parameters.Add("@TSP_City", SqlDbType.NVarChar, 0, "TSP_City");
adapter.UpdateCommand.Parameters.Add("@TSP_State", SqlDbType.NVarChar, 0, "TSP_State");
adapter.UpdateCommand.Parameters.Add("@TSP_Country", SqlDbType.NVarChar, 0, "TSP_Country");
adapter.UpdateCommand.Parameters.Add("@TSP_ContactPerson", SqlDbType.NVarChar, 0, "TSP_ContactPerson");
adapter.UpdateCommand.Parameters.Add("@TSP_Email", SqlDbType.NVarChar, 0, "TSP_Email");
adapter.UpdateCommand.Parameters.Add("@TSP_ContactNumber", SqlDbType.NVarChar, 0, "TSP_ContactNumber");
adapter.UpdateCommand.Parameters.Add("@TSP_CourseType", SqlDbType.SmallInt, 0, "TSP_CourseType");
adapter.UpdateCommand.Parameters.Add("@TSP_Remark", SqlDbType.NVarChar, 0, "TSP_Remark");
adapter.UpdateCommand.Parameters.Add("@TSP_IsDeleted", SqlDbType.Bit, 0, "TSP_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@TSP_CreatedDate", SqlDbType.DateTime, 0, "TSP_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@TSP_CreatedBy", SqlDbType.NVarChar, 0, "TSP_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@TSP_UpdatedDate", SqlDbType.DateTime, 0, "TSP_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@TSP_UpdatedBy", SqlDbType.NVarChar, 0, "TSP_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeJan", SqlDbType.Bit, 0, "TSP_IntakeJan");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeFeb", SqlDbType.Bit, 0, "TSP_IntakeFeb");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeMar", SqlDbType.Bit, 0, "TSP_IntakeMar");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeApr", SqlDbType.Bit, 0, "TSP_IntakeApr");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeMay", SqlDbType.Bit, 0, "TSP_IntakeMay");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeJun", SqlDbType.Bit, 0, "TSP_IntakeJun");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeJul", SqlDbType.Bit, 0, "TSP_IntakeJul");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeAug", SqlDbType.Bit, 0, "TSP_IntakeAug");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeSep", SqlDbType.Bit, 0, "TSP_IntakeSep");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeOct", SqlDbType.Bit, 0, "TSP_IntakeOct");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeNov", SqlDbType.Bit, 0, "TSP_IntakeNov");
adapter.UpdateCommand.Parameters.Add("@TSP_IntakeDec", SqlDbType.Bit, 0, "TSP_IntakeDec");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [TSP] WHERE [TSP_ID] = @o_TSP_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_TSP_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "TSP_ID", DataRowVersion.Original, null));
}
public void Update(TSPTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(TSPRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public TSPRow GetByTSP_ID(System.Guid TSP_ID ) {
string sql = "SELECT * FROM [TSP] WHERE [TSP_ID] = @TSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("TSP_ID", TSP_ID);

TSPTable tbl = new TSPTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetTSPRow(0);
}
public int CountByTSP_ID(System.Guid TSP_ID ) {
string sql = "SELECT COUNT(*) FROM [TSP] WHERE [TSP_ID] = @TSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("TSP_ID", TSP_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByTSP_ID(System.Guid TSP_ID, IActivityLog log ) {
string sql = "DELETE FROM [TSP] WHERE [TSP_ID] = @TSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("TSP_ID", TSP_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
