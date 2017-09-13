using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class VoluntaryHourTable : DataTable {
// column indexes
public const int VoluntaryHour_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int VoluntaryHour_TypeColumnIndex = 2;
public const int VoluntaryHour_DurationColumnIndex = 3;
public const int VoluntaryHour_StatusColumnIndex = 4;
public const int VoluntaryHour_DescriptionColumnIndex = 5;
public const int VoluntaryHour_CreatedByColumnIndex = 6;
public const int VoluntaryHour_CreatedDateColumnIndex = 7;
public const int VoluntaryHour_UpdatedByColumnIndex = 8;
public const int VoluntaryHour_UpdatedDateColumnIndex = 9;
public const int VoluntaryHour_IsDeletedColumnIndex = 10;
public const int VoluntaryHour_RemarkColumnIndex = 11;
public const int VoluntaryHour_DateColumnIndex = 12;
public const int VoluntaryHour_TitleColumnIndex = 13;
public VoluntaryHourTable() {
TableName = "[VoluntaryHour]";
// column VoluntaryHour_ID
DataColumn VoluntaryHour_IDCol = new DataColumn("VoluntaryHour_ID", typeof(System.Guid));
VoluntaryHour_IDCol.ReadOnly = false;
VoluntaryHour_IDCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column VoluntaryHour_Type
DataColumn VoluntaryHour_TypeCol = new DataColumn("VoluntaryHour_Type", typeof(System.Int16));
VoluntaryHour_TypeCol.ReadOnly = false;
VoluntaryHour_TypeCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_TypeCol);
// column VoluntaryHour_Duration
DataColumn VoluntaryHour_DurationCol = new DataColumn("VoluntaryHour_Duration", typeof(System.Int64));
VoluntaryHour_DurationCol.ReadOnly = false;
VoluntaryHour_DurationCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_DurationCol);
// column VoluntaryHour_Status
DataColumn VoluntaryHour_StatusCol = new DataColumn("VoluntaryHour_Status", typeof(System.Int16));
VoluntaryHour_StatusCol.ReadOnly = false;
VoluntaryHour_StatusCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_StatusCol);
// column VoluntaryHour_Description
DataColumn VoluntaryHour_DescriptionCol = new DataColumn("VoluntaryHour_Description", typeof(System.String));
VoluntaryHour_DescriptionCol.ReadOnly = false;
VoluntaryHour_DescriptionCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_DescriptionCol);
// column VoluntaryHour_CreatedBy
DataColumn VoluntaryHour_CreatedByCol = new DataColumn("VoluntaryHour_CreatedBy", typeof(System.String));
VoluntaryHour_CreatedByCol.ReadOnly = false;
VoluntaryHour_CreatedByCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_CreatedByCol);
// column VoluntaryHour_CreatedDate
DataColumn VoluntaryHour_CreatedDateCol = new DataColumn("VoluntaryHour_CreatedDate", typeof(System.DateTime));
VoluntaryHour_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
VoluntaryHour_CreatedDateCol.ReadOnly = false;
VoluntaryHour_CreatedDateCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_CreatedDateCol);
// column VoluntaryHour_UpdatedBy
DataColumn VoluntaryHour_UpdatedByCol = new DataColumn("VoluntaryHour_UpdatedBy", typeof(System.String));
VoluntaryHour_UpdatedByCol.ReadOnly = false;
VoluntaryHour_UpdatedByCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_UpdatedByCol);
// column VoluntaryHour_UpdatedDate
DataColumn VoluntaryHour_UpdatedDateCol = new DataColumn("VoluntaryHour_UpdatedDate", typeof(System.DateTime));
VoluntaryHour_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
VoluntaryHour_UpdatedDateCol.ReadOnly = false;
VoluntaryHour_UpdatedDateCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_UpdatedDateCol);
// column VoluntaryHour_IsDeleted
DataColumn VoluntaryHour_IsDeletedCol = new DataColumn("VoluntaryHour_IsDeleted", typeof(System.Boolean));
VoluntaryHour_IsDeletedCol.ReadOnly = false;
VoluntaryHour_IsDeletedCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_IsDeletedCol);
// column VoluntaryHour_Remark
DataColumn VoluntaryHour_RemarkCol = new DataColumn("VoluntaryHour_Remark", typeof(System.String));
VoluntaryHour_RemarkCol.ReadOnly = false;
VoluntaryHour_RemarkCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_RemarkCol);
// column VoluntaryHour_Date
DataColumn VoluntaryHour_DateCol = new DataColumn("VoluntaryHour_Date", typeof(System.DateTime));
VoluntaryHour_DateCol.DateTimeMode = DataSetDateTime.Local;
VoluntaryHour_DateCol.ReadOnly = false;
VoluntaryHour_DateCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_DateCol);
// column VoluntaryHour_Title
DataColumn VoluntaryHour_TitleCol = new DataColumn("VoluntaryHour_Title", typeof(System.String));
VoluntaryHour_TitleCol.ReadOnly = false;
VoluntaryHour_TitleCol.AllowDBNull = false;
Columns.Add(VoluntaryHour_TitleCol);
}
public VoluntaryHourRow NewVoluntaryHourRow() {
VoluntaryHourRow row = (VoluntaryHourRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(VoluntaryHourRow row) {
row.VoluntaryHour_ID = Guid.Empty;
row.Application_ID = Guid.Empty;
row.VoluntaryHour_Type = 0;
row.VoluntaryHour_Duration = 0;
row.VoluntaryHour_Status = 0;
row.VoluntaryHour_Description = "";
row.VoluntaryHour_CreatedBy = "";
row.VoluntaryHour_CreatedDate = DateTime.Now;
row.VoluntaryHour_UpdatedBy = "";
row.VoluntaryHour_UpdatedDate = DateTime.Now;
row.VoluntaryHour_IsDeleted = false;
row.VoluntaryHour_Remark = "";
row.VoluntaryHour_Date = DateTime.Now;
row.VoluntaryHour_Title = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new VoluntaryHourRow(builder);
}
public VoluntaryHourRow GetVoluntaryHourRow(int index) {
return (VoluntaryHourRow)Rows[index];
}
}
public partial class VoluntaryHourRow : DataRow {
internal VoluntaryHourRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid VoluntaryHour_ID {
get {
return (System.Guid)this["VoluntaryHour_ID"];
}
set {
this["VoluntaryHour_ID"] = value;
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
set {
this["Application_ID"] = value;
}
}
public System.Int16 VoluntaryHour_Type {
get {
return (System.Int16)this["VoluntaryHour_Type"];
}
set {
this["VoluntaryHour_Type"] = value;
}
}
public System.Int64 VoluntaryHour_Duration {
get {
return (System.Int64)this["VoluntaryHour_Duration"];
}
set {
this["VoluntaryHour_Duration"] = value;
}
}
public System.Int16 VoluntaryHour_Status {
get {
return (System.Int16)this["VoluntaryHour_Status"];
}
set {
this["VoluntaryHour_Status"] = value;
}
}
public System.String VoluntaryHour_Description {
get {
return (System.String)this["VoluntaryHour_Description"];
}
set {
if( value.Length > 250 ) this["VoluntaryHour_Description"] = value.Substring(0, 250);
else this["VoluntaryHour_Description"] = value;
}
}
public System.String VoluntaryHour_CreatedBy {
get {
return (System.String)this["VoluntaryHour_CreatedBy"];
}
set {
if( value.Length > 50 ) this["VoluntaryHour_CreatedBy"] = value.Substring(0, 50);
else this["VoluntaryHour_CreatedBy"] = value;
}
}
public System.DateTime VoluntaryHour_CreatedDate {
get {
return (System.DateTime)this["VoluntaryHour_CreatedDate"];
}
set {
this["VoluntaryHour_CreatedDate"] = value;
}
}
public System.String VoluntaryHour_UpdatedBy {
get {
return (System.String)this["VoluntaryHour_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["VoluntaryHour_UpdatedBy"] = value.Substring(0, 50);
else this["VoluntaryHour_UpdatedBy"] = value;
}
}
public System.DateTime VoluntaryHour_UpdatedDate {
get {
return (System.DateTime)this["VoluntaryHour_UpdatedDate"];
}
set {
this["VoluntaryHour_UpdatedDate"] = value;
}
}
public System.Boolean VoluntaryHour_IsDeleted {
get {
return (System.Boolean)this["VoluntaryHour_IsDeleted"];
}
set {
this["VoluntaryHour_IsDeleted"] = value;
}
}
public System.String VoluntaryHour_Remark {
get {
return (System.String)this["VoluntaryHour_Remark"];
}
set {
if( value.Length > 250 ) this["VoluntaryHour_Remark"] = value.Substring(0, 250);
else this["VoluntaryHour_Remark"] = value;
}
}
public System.DateTime VoluntaryHour_Date {
get {
return (System.DateTime)this["VoluntaryHour_Date"];
}
set {
this["VoluntaryHour_Date"] = value;
}
}
public System.String VoluntaryHour_Title {
get {
return (System.String)this["VoluntaryHour_Title"];
}
set {
if( value.Length > 100 ) this["VoluntaryHour_Title"] = value.Substring(0, 100);
else this["VoluntaryHour_Title"] = value;
}
}
}
public partial class VoluntaryHourMinimalizedEntity {
public VoluntaryHourMinimalizedEntity() {}
public VoluntaryHourMinimalizedEntity(VoluntaryHourRow dr) {
this.VoluntaryHour_ID = dr.VoluntaryHour_ID;
this.Application_ID = dr.Application_ID;
this.VoluntaryHour_Type = dr.VoluntaryHour_Type;
this.VoluntaryHour_Duration = dr.VoluntaryHour_Duration;
this.VoluntaryHour_Status = dr.VoluntaryHour_Status;
this.VoluntaryHour_Description = dr.VoluntaryHour_Description;
this.VoluntaryHour_CreatedBy = dr.VoluntaryHour_CreatedBy;
this.VoluntaryHour_CreatedDate = dr.VoluntaryHour_CreatedDate;
this.VoluntaryHour_UpdatedBy = dr.VoluntaryHour_UpdatedBy;
this.VoluntaryHour_UpdatedDate = dr.VoluntaryHour_UpdatedDate;
this.VoluntaryHour_IsDeleted = dr.VoluntaryHour_IsDeleted;
this.VoluntaryHour_Remark = dr.VoluntaryHour_Remark;
this.VoluntaryHour_Date = dr.VoluntaryHour_Date;
this.VoluntaryHour_Title = dr.VoluntaryHour_Title;
}
public void CopyTo(VoluntaryHourRow dr) {
dr.VoluntaryHour_ID = this.VoluntaryHour_ID;
dr.Application_ID = this.Application_ID;
dr.VoluntaryHour_Type = this.VoluntaryHour_Type;
dr.VoluntaryHour_Duration = this.VoluntaryHour_Duration;
dr.VoluntaryHour_Status = this.VoluntaryHour_Status;
dr.VoluntaryHour_Description = this.VoluntaryHour_Description;
dr.VoluntaryHour_CreatedBy = this.VoluntaryHour_CreatedBy;
dr.VoluntaryHour_CreatedDate = this.VoluntaryHour_CreatedDate;
dr.VoluntaryHour_UpdatedBy = this.VoluntaryHour_UpdatedBy;
dr.VoluntaryHour_UpdatedDate = this.VoluntaryHour_UpdatedDate;
dr.VoluntaryHour_IsDeleted = this.VoluntaryHour_IsDeleted;
dr.VoluntaryHour_Remark = this.VoluntaryHour_Remark;
dr.VoluntaryHour_Date = this.VoluntaryHour_Date;
dr.VoluntaryHour_Title = this.VoluntaryHour_Title;
}
public System.Guid VoluntaryHour_ID;
public System.Guid Application_ID;
public System.Int16 VoluntaryHour_Type;
public System.Int64 VoluntaryHour_Duration;
public System.Int16 VoluntaryHour_Status;
public System.String VoluntaryHour_Description;
public System.String VoluntaryHour_CreatedBy;
public System.DateTime VoluntaryHour_CreatedDate;
public System.String VoluntaryHour_UpdatedBy;
public System.DateTime VoluntaryHour_UpdatedDate;
public System.Boolean VoluntaryHour_IsDeleted;
public System.String VoluntaryHour_Remark;
public System.DateTime VoluntaryHour_Date;
public System.String VoluntaryHour_Title;
}
public partial class VoluntaryHourAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public VoluntaryHourAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("VoluntaryHour_ID", "VoluntaryHour_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("VoluntaryHour_Type", "VoluntaryHour_Type");
tmap.ColumnMappings.Add("VoluntaryHour_Duration", "VoluntaryHour_Duration");
tmap.ColumnMappings.Add("VoluntaryHour_Status", "VoluntaryHour_Status");
tmap.ColumnMappings.Add("VoluntaryHour_Description", "VoluntaryHour_Description");
tmap.ColumnMappings.Add("VoluntaryHour_CreatedBy", "VoluntaryHour_CreatedBy");
tmap.ColumnMappings.Add("VoluntaryHour_CreatedDate", "VoluntaryHour_CreatedDate");
tmap.ColumnMappings.Add("VoluntaryHour_UpdatedBy", "VoluntaryHour_UpdatedBy");
tmap.ColumnMappings.Add("VoluntaryHour_UpdatedDate", "VoluntaryHour_UpdatedDate");
tmap.ColumnMappings.Add("VoluntaryHour_IsDeleted", "VoluntaryHour_IsDeleted");
tmap.ColumnMappings.Add("VoluntaryHour_Remark", "VoluntaryHour_Remark");
tmap.ColumnMappings.Add("VoluntaryHour_Date", "VoluntaryHour_Date");
tmap.ColumnMappings.Add("VoluntaryHour_Title", "VoluntaryHour_Title");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [VoluntaryHour] ([VoluntaryHour_ID], [Application_ID], [VoluntaryHour_Type], [VoluntaryHour_Duration], [VoluntaryHour_Status], [VoluntaryHour_Description], [VoluntaryHour_CreatedBy], [VoluntaryHour_CreatedDate], [VoluntaryHour_UpdatedBy], [VoluntaryHour_UpdatedDate], [VoluntaryHour_IsDeleted], [VoluntaryHour_Remark], [VoluntaryHour_Date], [VoluntaryHour_Title]) VALUES (@VoluntaryHour_ID, @Application_ID, @VoluntaryHour_Type, @VoluntaryHour_Duration, @VoluntaryHour_Status, @VoluntaryHour_Description, @VoluntaryHour_CreatedBy, @VoluntaryHour_CreatedDate, @VoluntaryHour_UpdatedBy, @VoluntaryHour_UpdatedDate, @VoluntaryHour_IsDeleted, @VoluntaryHour_Remark, @VoluntaryHour_Date, @VoluntaryHour_Title)");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_ID", SqlDbType.UniqueIdentifier, 0, "VoluntaryHour_ID");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Type", SqlDbType.SmallInt, 0, "VoluntaryHour_Type");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Duration", SqlDbType.BigInt, 0, "VoluntaryHour_Duration");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Status", SqlDbType.SmallInt, 0, "VoluntaryHour_Status");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Description", SqlDbType.NVarChar, 0, "VoluntaryHour_Description");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_CreatedBy", SqlDbType.NVarChar, 0, "VoluntaryHour_CreatedBy");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_CreatedDate", SqlDbType.DateTime, 0, "VoluntaryHour_CreatedDate");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_UpdatedBy", SqlDbType.NVarChar, 0, "VoluntaryHour_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_UpdatedDate", SqlDbType.DateTime, 0, "VoluntaryHour_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_IsDeleted", SqlDbType.Bit, 0, "VoluntaryHour_IsDeleted");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Remark", SqlDbType.NVarChar, 0, "VoluntaryHour_Remark");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Date", SqlDbType.DateTime, 0, "VoluntaryHour_Date");
adapter.InsertCommand.Parameters.Add("@VoluntaryHour_Title", SqlDbType.NVarChar, 0, "VoluntaryHour_Title");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [VoluntaryHour] SET [VoluntaryHour_ID] = @VoluntaryHour_ID, [Application_ID] = @Application_ID, [VoluntaryHour_Type] = @VoluntaryHour_Type, [VoluntaryHour_Duration] = @VoluntaryHour_Duration, [VoluntaryHour_Status] = @VoluntaryHour_Status, [VoluntaryHour_Description] = @VoluntaryHour_Description, [VoluntaryHour_CreatedBy] = @VoluntaryHour_CreatedBy, [VoluntaryHour_CreatedDate] = @VoluntaryHour_CreatedDate, [VoluntaryHour_UpdatedBy] = @VoluntaryHour_UpdatedBy, [VoluntaryHour_UpdatedDate] = @VoluntaryHour_UpdatedDate, [VoluntaryHour_IsDeleted] = @VoluntaryHour_IsDeleted, [VoluntaryHour_Remark] = @VoluntaryHour_Remark, [VoluntaryHour_Date] = @VoluntaryHour_Date, [VoluntaryHour_Title] = @VoluntaryHour_Title WHERE [VoluntaryHour_ID] = @o_VoluntaryHour_ID");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_ID", SqlDbType.UniqueIdentifier, 0, "VoluntaryHour_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_VoluntaryHour_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "VoluntaryHour_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Type", SqlDbType.SmallInt, 0, "VoluntaryHour_Type");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Duration", SqlDbType.BigInt, 0, "VoluntaryHour_Duration");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Status", SqlDbType.SmallInt, 0, "VoluntaryHour_Status");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Description", SqlDbType.NVarChar, 0, "VoluntaryHour_Description");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_CreatedBy", SqlDbType.NVarChar, 0, "VoluntaryHour_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_CreatedDate", SqlDbType.DateTime, 0, "VoluntaryHour_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_UpdatedBy", SqlDbType.NVarChar, 0, "VoluntaryHour_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_UpdatedDate", SqlDbType.DateTime, 0, "VoluntaryHour_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_IsDeleted", SqlDbType.Bit, 0, "VoluntaryHour_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Remark", SqlDbType.NVarChar, 0, "VoluntaryHour_Remark");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Date", SqlDbType.DateTime, 0, "VoluntaryHour_Date");
adapter.UpdateCommand.Parameters.Add("@VoluntaryHour_Title", SqlDbType.NVarChar, 0, "VoluntaryHour_Title");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [VoluntaryHour] WHERE [VoluntaryHour_ID] = @o_VoluntaryHour_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_VoluntaryHour_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "VoluntaryHour_ID", DataRowVersion.Original, null));
}
public void Update(VoluntaryHourTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(VoluntaryHourRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public VoluntaryHourRow GetByVoluntaryHour_ID(System.Guid VoluntaryHour_ID ) {
string sql = "SELECT * FROM [VoluntaryHour] WHERE [VoluntaryHour_ID] = @VoluntaryHour_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("VoluntaryHour_ID", VoluntaryHour_ID);

VoluntaryHourTable tbl = new VoluntaryHourTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetVoluntaryHourRow(0);
}
public int CountByVoluntaryHour_ID(System.Guid VoluntaryHour_ID ) {
string sql = "SELECT COUNT(*) FROM [VoluntaryHour] WHERE [VoluntaryHour_ID] = @VoluntaryHour_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("VoluntaryHour_ID", VoluntaryHour_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByVoluntaryHour_ID(System.Guid VoluntaryHour_ID, IActivityLog log ) {
string sql = "DELETE FROM [VoluntaryHour] WHERE [VoluntaryHour_ID] = @VoluntaryHour_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("VoluntaryHour_ID", VoluntaryHour_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public VoluntaryHourTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [VoluntaryHour] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
VoluntaryHourTable tbl = new VoluntaryHourTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [VoluntaryHour] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [VoluntaryHour] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
