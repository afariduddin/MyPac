using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class WorkHistoryTable : DataTable {
// column indexes
public const int WorkHistory_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int WorkHistory_CompanyNameColumnIndex = 2;
public const int WorkHistory_JobTitleColumnIndex = 3;
public const int WorkHistory_StartDateColumnIndex = 4;
public const int WorkHistory_ResignDateColumnIndex = 5;
public const int WorkHistory_DescriptionColumnIndex = 6;
public const int WorkHistory_CreatedByColumnIndex = 7;
public const int WorkHistory_CreatedDateColumnIndex = 8;
public const int WorkHistory_UpdatedByColumnIndex = 9;
public const int WorkHistory_UpdatedDateColumnIndex = 10;
public const int WorkHistory_IsDeletedColumnIndex = 11;
public WorkHistoryTable() {
TableName = "[WorkHistory]";
// column WorkHistory_ID
DataColumn WorkHistory_IDCol = new DataColumn("WorkHistory_ID", typeof(System.Guid));
WorkHistory_IDCol.ReadOnly = false;
WorkHistory_IDCol.AllowDBNull = false;
Columns.Add(WorkHistory_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column WorkHistory_CompanyName
DataColumn WorkHistory_CompanyNameCol = new DataColumn("WorkHistory_CompanyName", typeof(System.String));
WorkHistory_CompanyNameCol.ReadOnly = false;
WorkHistory_CompanyNameCol.AllowDBNull = false;
Columns.Add(WorkHistory_CompanyNameCol);
// column WorkHistory_JobTitle
DataColumn WorkHistory_JobTitleCol = new DataColumn("WorkHistory_JobTitle", typeof(System.String));
WorkHistory_JobTitleCol.ReadOnly = false;
WorkHistory_JobTitleCol.AllowDBNull = false;
Columns.Add(WorkHistory_JobTitleCol);
// column WorkHistory_StartDate
DataColumn WorkHistory_StartDateCol = new DataColumn("WorkHistory_StartDate", typeof(System.DateTime));
WorkHistory_StartDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_StartDateCol.ReadOnly = false;
WorkHistory_StartDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_StartDateCol);
// column WorkHistory_ResignDate
DataColumn WorkHistory_ResignDateCol = new DataColumn("WorkHistory_ResignDate", typeof(System.DateTime));
WorkHistory_ResignDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_ResignDateCol.ReadOnly = false;
WorkHistory_ResignDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_ResignDateCol);
// column WorkHistory_Description
DataColumn WorkHistory_DescriptionCol = new DataColumn("WorkHistory_Description", typeof(System.String));
WorkHistory_DescriptionCol.ReadOnly = false;
WorkHistory_DescriptionCol.AllowDBNull = false;
Columns.Add(WorkHistory_DescriptionCol);
// column WorkHistory_CreatedBy
DataColumn WorkHistory_CreatedByCol = new DataColumn("WorkHistory_CreatedBy", typeof(System.String));
WorkHistory_CreatedByCol.ReadOnly = false;
WorkHistory_CreatedByCol.AllowDBNull = false;
Columns.Add(WorkHistory_CreatedByCol);
// column WorkHistory_CreatedDate
DataColumn WorkHistory_CreatedDateCol = new DataColumn("WorkHistory_CreatedDate", typeof(System.DateTime));
WorkHistory_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_CreatedDateCol.ReadOnly = false;
WorkHistory_CreatedDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_CreatedDateCol);
// column WorkHistory_UpdatedBy
DataColumn WorkHistory_UpdatedByCol = new DataColumn("WorkHistory_UpdatedBy", typeof(System.String));
WorkHistory_UpdatedByCol.ReadOnly = false;
WorkHistory_UpdatedByCol.AllowDBNull = false;
Columns.Add(WorkHistory_UpdatedByCol);
// column WorkHistory_UpdatedDate
DataColumn WorkHistory_UpdatedDateCol = new DataColumn("WorkHistory_UpdatedDate", typeof(System.DateTime));
WorkHistory_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_UpdatedDateCol.ReadOnly = false;
WorkHistory_UpdatedDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_UpdatedDateCol);
// column WorkHistory_IsDeleted
DataColumn WorkHistory_IsDeletedCol = new DataColumn("WorkHistory_IsDeleted", typeof(System.Boolean));
WorkHistory_IsDeletedCol.ReadOnly = false;
WorkHistory_IsDeletedCol.AllowDBNull = false;
Columns.Add(WorkHistory_IsDeletedCol);
}
public WorkHistoryRow NewWorkHistoryRow() {
WorkHistoryRow row = (WorkHistoryRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(WorkHistoryRow row) {
row.WorkHistory_ID = Guid.Empty;
row.Application_ID = Guid.Empty;
row.WorkHistory_CompanyName = "";
row.WorkHistory_JobTitle = "";
row.WorkHistory_StartDate = DateTime.Now;
row.WorkHistory_ResignDate = DateTime.Now;
row.WorkHistory_Description = "";
row.WorkHistory_CreatedBy = "";
row.WorkHistory_CreatedDate = DateTime.Now;
row.WorkHistory_UpdatedBy = "";
row.WorkHistory_UpdatedDate = DateTime.Now;
row.WorkHistory_IsDeleted = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new WorkHistoryRow(builder);
}
public WorkHistoryRow GetWorkHistoryRow(int index) {
return (WorkHistoryRow)Rows[index];
}
}
public partial class WorkHistoryRow : DataRow {
internal WorkHistoryRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid WorkHistory_ID {
get {
return (System.Guid)this["WorkHistory_ID"];
}
set {
this["WorkHistory_ID"] = value;
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
public System.String WorkHistory_CompanyName {
get {
return (System.String)this["WorkHistory_CompanyName"];
}
set {
if( value.Length > 100 ) this["WorkHistory_CompanyName"] = value.Substring(0, 100);
else this["WorkHistory_CompanyName"] = value;
}
}
public System.String WorkHistory_JobTitle {
get {
return (System.String)this["WorkHistory_JobTitle"];
}
set {
if( value.Length > 100 ) this["WorkHistory_JobTitle"] = value.Substring(0, 100);
else this["WorkHistory_JobTitle"] = value;
}
}
public System.DateTime WorkHistory_StartDate {
get {
return (System.DateTime)this["WorkHistory_StartDate"];
}
set {
this["WorkHistory_StartDate"] = value;
}
}
public System.DateTime WorkHistory_ResignDate {
get {
return (System.DateTime)this["WorkHistory_ResignDate"];
}
set {
this["WorkHistory_ResignDate"] = value;
}
}
public System.String WorkHistory_Description {
get {
return (System.String)this["WorkHistory_Description"];
}
set {
if( value.Length > 250 ) this["WorkHistory_Description"] = value.Substring(0, 250);
else this["WorkHistory_Description"] = value;
}
}
public System.String WorkHistory_CreatedBy {
get {
return (System.String)this["WorkHistory_CreatedBy"];
}
set {
if( value.Length > 50 ) this["WorkHistory_CreatedBy"] = value.Substring(0, 50);
else this["WorkHistory_CreatedBy"] = value;
}
}
public System.DateTime WorkHistory_CreatedDate {
get {
return (System.DateTime)this["WorkHistory_CreatedDate"];
}
set {
this["WorkHistory_CreatedDate"] = value;
}
}
public System.String WorkHistory_UpdatedBy {
get {
return (System.String)this["WorkHistory_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["WorkHistory_UpdatedBy"] = value.Substring(0, 50);
else this["WorkHistory_UpdatedBy"] = value;
}
}
public System.DateTime WorkHistory_UpdatedDate {
get {
return (System.DateTime)this["WorkHistory_UpdatedDate"];
}
set {
this["WorkHistory_UpdatedDate"] = value;
}
}
public System.Boolean WorkHistory_IsDeleted {
get {
return (System.Boolean)this["WorkHistory_IsDeleted"];
}
set {
this["WorkHistory_IsDeleted"] = value;
}
}
}
public partial class WorkHistoryMinimalizedEntity {
public WorkHistoryMinimalizedEntity() {}
public WorkHistoryMinimalizedEntity(WorkHistoryRow dr) {
this.WorkHistory_ID = dr.WorkHistory_ID;
this.Application_ID = dr.Application_ID;
this.WorkHistory_CompanyName = dr.WorkHistory_CompanyName;
this.WorkHistory_JobTitle = dr.WorkHistory_JobTitle;
this.WorkHistory_StartDate = dr.WorkHistory_StartDate;
this.WorkHistory_ResignDate = dr.WorkHistory_ResignDate;
this.WorkHistory_Description = dr.WorkHistory_Description;
this.WorkHistory_CreatedBy = dr.WorkHistory_CreatedBy;
this.WorkHistory_CreatedDate = dr.WorkHistory_CreatedDate;
this.WorkHistory_UpdatedBy = dr.WorkHistory_UpdatedBy;
this.WorkHistory_UpdatedDate = dr.WorkHistory_UpdatedDate;
this.WorkHistory_IsDeleted = dr.WorkHistory_IsDeleted;
}
public void CopyTo(WorkHistoryRow dr) {
dr.WorkHistory_ID = this.WorkHistory_ID;
dr.Application_ID = this.Application_ID;
dr.WorkHistory_CompanyName = this.WorkHistory_CompanyName;
dr.WorkHistory_JobTitle = this.WorkHistory_JobTitle;
dr.WorkHistory_StartDate = this.WorkHistory_StartDate;
dr.WorkHistory_ResignDate = this.WorkHistory_ResignDate;
dr.WorkHistory_Description = this.WorkHistory_Description;
dr.WorkHistory_CreatedBy = this.WorkHistory_CreatedBy;
dr.WorkHistory_CreatedDate = this.WorkHistory_CreatedDate;
dr.WorkHistory_UpdatedBy = this.WorkHistory_UpdatedBy;
dr.WorkHistory_UpdatedDate = this.WorkHistory_UpdatedDate;
dr.WorkHistory_IsDeleted = this.WorkHistory_IsDeleted;
}
public System.Guid WorkHistory_ID;
public System.Guid Application_ID;
public System.String WorkHistory_CompanyName;
public System.String WorkHistory_JobTitle;
public System.DateTime WorkHistory_StartDate;
public System.DateTime WorkHistory_ResignDate;
public System.String WorkHistory_Description;
public System.String WorkHistory_CreatedBy;
public System.DateTime WorkHistory_CreatedDate;
public System.String WorkHistory_UpdatedBy;
public System.DateTime WorkHistory_UpdatedDate;
public System.Boolean WorkHistory_IsDeleted;
}
public partial class WorkHistoryAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public WorkHistoryAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("WorkHistory_ID", "WorkHistory_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("WorkHistory_CompanyName", "WorkHistory_CompanyName");
tmap.ColumnMappings.Add("WorkHistory_JobTitle", "WorkHistory_JobTitle");
tmap.ColumnMappings.Add("WorkHistory_StartDate", "WorkHistory_StartDate");
tmap.ColumnMappings.Add("WorkHistory_ResignDate", "WorkHistory_ResignDate");
tmap.ColumnMappings.Add("WorkHistory_Description", "WorkHistory_Description");
tmap.ColumnMappings.Add("WorkHistory_CreatedBy", "WorkHistory_CreatedBy");
tmap.ColumnMappings.Add("WorkHistory_CreatedDate", "WorkHistory_CreatedDate");
tmap.ColumnMappings.Add("WorkHistory_UpdatedBy", "WorkHistory_UpdatedBy");
tmap.ColumnMappings.Add("WorkHistory_UpdatedDate", "WorkHistory_UpdatedDate");
tmap.ColumnMappings.Add("WorkHistory_IsDeleted", "WorkHistory_IsDeleted");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [WorkHistory] ([WorkHistory_ID], [Application_ID], [WorkHistory_CompanyName], [WorkHistory_JobTitle], [WorkHistory_StartDate], [WorkHistory_ResignDate], [WorkHistory_Description], [WorkHistory_CreatedBy], [WorkHistory_CreatedDate], [WorkHistory_UpdatedBy], [WorkHistory_UpdatedDate], [WorkHistory_IsDeleted]) VALUES (@WorkHistory_ID, @Application_ID, @WorkHistory_CompanyName, @WorkHistory_JobTitle, @WorkHistory_StartDate, @WorkHistory_ResignDate, @WorkHistory_Description, @WorkHistory_CreatedBy, @WorkHistory_CreatedDate, @WorkHistory_UpdatedBy, @WorkHistory_UpdatedDate, @WorkHistory_IsDeleted)");
adapter.InsertCommand.Parameters.Add("@WorkHistory_ID", SqlDbType.UniqueIdentifier, 0, "WorkHistory_ID");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@WorkHistory_CompanyName", SqlDbType.NVarChar, 0, "WorkHistory_CompanyName");
adapter.InsertCommand.Parameters.Add("@WorkHistory_JobTitle", SqlDbType.NVarChar, 0, "WorkHistory_JobTitle");
adapter.InsertCommand.Parameters.Add("@WorkHistory_StartDate", SqlDbType.DateTime, 0, "WorkHistory_StartDate");
adapter.InsertCommand.Parameters.Add("@WorkHistory_ResignDate", SqlDbType.DateTime, 0, "WorkHistory_ResignDate");
adapter.InsertCommand.Parameters.Add("@WorkHistory_Description", SqlDbType.NVarChar, 0, "WorkHistory_Description");
adapter.InsertCommand.Parameters.Add("@WorkHistory_CreatedBy", SqlDbType.NVarChar, 0, "WorkHistory_CreatedBy");
adapter.InsertCommand.Parameters.Add("@WorkHistory_CreatedDate", SqlDbType.DateTime, 0, "WorkHistory_CreatedDate");
adapter.InsertCommand.Parameters.Add("@WorkHistory_UpdatedBy", SqlDbType.NVarChar, 0, "WorkHistory_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@WorkHistory_UpdatedDate", SqlDbType.DateTime, 0, "WorkHistory_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@WorkHistory_IsDeleted", SqlDbType.Bit, 0, "WorkHistory_IsDeleted");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [WorkHistory] SET [WorkHistory_ID] = @WorkHistory_ID, [Application_ID] = @Application_ID, [WorkHistory_CompanyName] = @WorkHistory_CompanyName, [WorkHistory_JobTitle] = @WorkHistory_JobTitle, [WorkHistory_StartDate] = @WorkHistory_StartDate, [WorkHistory_ResignDate] = @WorkHistory_ResignDate, [WorkHistory_Description] = @WorkHistory_Description, [WorkHistory_CreatedBy] = @WorkHistory_CreatedBy, [WorkHistory_CreatedDate] = @WorkHistory_CreatedDate, [WorkHistory_UpdatedBy] = @WorkHistory_UpdatedBy, [WorkHistory_UpdatedDate] = @WorkHistory_UpdatedDate, [WorkHistory_IsDeleted] = @WorkHistory_IsDeleted WHERE [WorkHistory_ID] = @o_WorkHistory_ID");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_ID", SqlDbType.UniqueIdentifier, 0, "WorkHistory_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_WorkHistory_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "WorkHistory_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_CompanyName", SqlDbType.NVarChar, 0, "WorkHistory_CompanyName");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_JobTitle", SqlDbType.NVarChar, 0, "WorkHistory_JobTitle");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_StartDate", SqlDbType.DateTime, 0, "WorkHistory_StartDate");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_ResignDate", SqlDbType.DateTime, 0, "WorkHistory_ResignDate");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_Description", SqlDbType.NVarChar, 0, "WorkHistory_Description");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_CreatedBy", SqlDbType.NVarChar, 0, "WorkHistory_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_CreatedDate", SqlDbType.DateTime, 0, "WorkHistory_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_UpdatedBy", SqlDbType.NVarChar, 0, "WorkHistory_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_UpdatedDate", SqlDbType.DateTime, 0, "WorkHistory_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@WorkHistory_IsDeleted", SqlDbType.Bit, 0, "WorkHistory_IsDeleted");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [WorkHistory] WHERE [WorkHistory_ID] = @o_WorkHistory_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_WorkHistory_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "WorkHistory_ID", DataRowVersion.Original, null));
}
public void Update(WorkHistoryTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(WorkHistoryRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public WorkHistoryRow GetByWorkHistory_ID(System.Guid WorkHistory_ID ) {
string sql = "SELECT * FROM [WorkHistory] WHERE [WorkHistory_ID] = @WorkHistory_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WorkHistory_ID", WorkHistory_ID);

WorkHistoryTable tbl = new WorkHistoryTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetWorkHistoryRow(0);
}
public int CountByWorkHistory_ID(System.Guid WorkHistory_ID ) {
string sql = "SELECT COUNT(*) FROM [WorkHistory] WHERE [WorkHistory_ID] = @WorkHistory_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WorkHistory_ID", WorkHistory_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByWorkHistory_ID(System.Guid WorkHistory_ID, IActivityLog log ) {
string sql = "DELETE FROM [WorkHistory] WHERE [WorkHistory_ID] = @WorkHistory_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WorkHistory_ID", WorkHistory_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public WorkHistoryTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [WorkHistory] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
WorkHistoryTable tbl = new WorkHistoryTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [WorkHistory] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [WorkHistory] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
