using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PartTimerAssessmentSessionTable : DataTable {
// column indexes
public const int PartTimerAssessmentSession_IDColumnIndex = 0;
public const int PartTimerAssessmentSession_LocationColumnIndex = 1;
public const int PartTimerAssessmentSession_DateTimeColumnIndex = 2;
public const int PartTimerAssessmentSession_MaximumStudentColumnIndex = 3;
public const int PartTimerAssessmentSession_RemarkColumnIndex = 4;
public const int PartTimerAssessmentSession_CreatedByColumnIndex = 5;
public const int PartTimerAssessmentSession_CreatedDateColumnIndex = 6;
public const int PartTimerAssessmentSession_UpdatedByColumnIndex = 7;
public const int PartTimerAssessmentSession_UpdatedDateColumnIndex = 8;
public const int PartTimerAssessmentSession_IsDeletedColumnIndex = 9;
public const int PartTimerAssessmentSession_SessionTypeColumnIndex = 10;
public const int PartTimerAssessmentSession_IsSentColumnIndex = 11;
public PartTimerAssessmentSessionTable() {
TableName = "[PartTimerAssessmentSession]";
// column PartTimerAssessmentSession_ID
DataColumn PartTimerAssessmentSession_IDCol = new DataColumn("PartTimerAssessmentSession_ID", typeof(System.Guid));
PartTimerAssessmentSession_IDCol.ReadOnly = false;
PartTimerAssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IDCol);
// column PartTimerAssessmentSession_Location
DataColumn PartTimerAssessmentSession_LocationCol = new DataColumn("PartTimerAssessmentSession_Location", typeof(System.String));
PartTimerAssessmentSession_LocationCol.ReadOnly = false;
PartTimerAssessmentSession_LocationCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_LocationCol);
// column PartTimerAssessmentSession_DateTime
DataColumn PartTimerAssessmentSession_DateTimeCol = new DataColumn("PartTimerAssessmentSession_DateTime", typeof(System.DateTime));
PartTimerAssessmentSession_DateTimeCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_DateTimeCol.ReadOnly = false;
PartTimerAssessmentSession_DateTimeCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_DateTimeCol);
// column PartTimerAssessmentSession_MaximumStudent
DataColumn PartTimerAssessmentSession_MaximumStudentCol = new DataColumn("PartTimerAssessmentSession_MaximumStudent", typeof(System.Int32));
PartTimerAssessmentSession_MaximumStudentCol.ReadOnly = false;
PartTimerAssessmentSession_MaximumStudentCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_MaximumStudentCol);
// column PartTimerAssessmentSession_Remark
DataColumn PartTimerAssessmentSession_RemarkCol = new DataColumn("PartTimerAssessmentSession_Remark", typeof(System.String));
PartTimerAssessmentSession_RemarkCol.ReadOnly = false;
PartTimerAssessmentSession_RemarkCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_RemarkCol);
// column PartTimerAssessmentSession_CreatedBy
DataColumn PartTimerAssessmentSession_CreatedByCol = new DataColumn("PartTimerAssessmentSession_CreatedBy", typeof(System.String));
PartTimerAssessmentSession_CreatedByCol.ReadOnly = false;
PartTimerAssessmentSession_CreatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_CreatedByCol);
// column PartTimerAssessmentSession_CreatedDate
DataColumn PartTimerAssessmentSession_CreatedDateCol = new DataColumn("PartTimerAssessmentSession_CreatedDate", typeof(System.DateTime));
PartTimerAssessmentSession_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_CreatedDateCol.ReadOnly = false;
PartTimerAssessmentSession_CreatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_CreatedDateCol);
// column PartTimerAssessmentSession_UpdatedBy
DataColumn PartTimerAssessmentSession_UpdatedByCol = new DataColumn("PartTimerAssessmentSession_UpdatedBy", typeof(System.String));
PartTimerAssessmentSession_UpdatedByCol.ReadOnly = false;
PartTimerAssessmentSession_UpdatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_UpdatedByCol);
// column PartTimerAssessmentSession_UpdatedDate
DataColumn PartTimerAssessmentSession_UpdatedDateCol = new DataColumn("PartTimerAssessmentSession_UpdatedDate", typeof(System.DateTime));
PartTimerAssessmentSession_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_UpdatedDateCol.ReadOnly = false;
PartTimerAssessmentSession_UpdatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_UpdatedDateCol);
// column PartTimerAssessmentSession_IsDeleted
DataColumn PartTimerAssessmentSession_IsDeletedCol = new DataColumn("PartTimerAssessmentSession_IsDeleted", typeof(System.Boolean));
PartTimerAssessmentSession_IsDeletedCol.ReadOnly = false;
PartTimerAssessmentSession_IsDeletedCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IsDeletedCol);
// column PartTimerAssessmentSession_SessionType
DataColumn PartTimerAssessmentSession_SessionTypeCol = new DataColumn("PartTimerAssessmentSession_SessionType", typeof(System.Int16));
PartTimerAssessmentSession_SessionTypeCol.ReadOnly = false;
PartTimerAssessmentSession_SessionTypeCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_SessionTypeCol);
// column PartTimerAssessmentSession_IsSent
DataColumn PartTimerAssessmentSession_IsSentCol = new DataColumn("PartTimerAssessmentSession_IsSent", typeof(System.Boolean));
PartTimerAssessmentSession_IsSentCol.ReadOnly = false;
PartTimerAssessmentSession_IsSentCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IsSentCol);
}
public PartTimerAssessmentSessionRow NewPartTimerAssessmentSessionRow() {
PartTimerAssessmentSessionRow row = (PartTimerAssessmentSessionRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(PartTimerAssessmentSessionRow row) {
row.PartTimerAssessmentSession_ID = Guid.Empty;
row.PartTimerAssessmentSession_Location = "";
row.PartTimerAssessmentSession_DateTime = DateTime.Now;
row.PartTimerAssessmentSession_MaximumStudent = 0;
row.PartTimerAssessmentSession_Remark = "";
row.PartTimerAssessmentSession_CreatedBy = "";
row.PartTimerAssessmentSession_CreatedDate = DateTime.Now;
row.PartTimerAssessmentSession_UpdatedBy = "";
row.PartTimerAssessmentSession_UpdatedDate = DateTime.Now;
row.PartTimerAssessmentSession_IsDeleted = false;
row.PartTimerAssessmentSession_SessionType = 0;
row.PartTimerAssessmentSession_IsSent = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PartTimerAssessmentSessionRow(builder);
}
public PartTimerAssessmentSessionRow GetPartTimerAssessmentSessionRow(int index) {
return (PartTimerAssessmentSessionRow)Rows[index];
}
}
public partial class PartTimerAssessmentSessionRow : DataRow {
internal PartTimerAssessmentSessionRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid PartTimerAssessmentSession_ID {
get {
return (System.Guid)this["PartTimerAssessmentSession_ID"];
}
set {
this["PartTimerAssessmentSession_ID"] = value;
}
}
public System.String PartTimerAssessmentSession_Location {
get {
return (System.String)this["PartTimerAssessmentSession_Location"];
}
set {
if( value.Length > 150 ) this["PartTimerAssessmentSession_Location"] = value.Substring(0, 150);
else this["PartTimerAssessmentSession_Location"] = value;
}
}
public System.DateTime PartTimerAssessmentSession_DateTime {
get {
return (System.DateTime)this["PartTimerAssessmentSession_DateTime"];
}
set {
this["PartTimerAssessmentSession_DateTime"] = value;
}
}
public System.Int32 PartTimerAssessmentSession_MaximumStudent {
get {
return (System.Int32)this["PartTimerAssessmentSession_MaximumStudent"];
}
set {
this["PartTimerAssessmentSession_MaximumStudent"] = value;
}
}
public System.String PartTimerAssessmentSession_Remark {
get {
return (System.String)this["PartTimerAssessmentSession_Remark"];
}
set {
if( value.Length > 250 ) this["PartTimerAssessmentSession_Remark"] = value.Substring(0, 250);
else this["PartTimerAssessmentSession_Remark"] = value;
}
}
public System.String PartTimerAssessmentSession_CreatedBy {
get {
return (System.String)this["PartTimerAssessmentSession_CreatedBy"];
}
set {
if( value.Length > 50 ) this["PartTimerAssessmentSession_CreatedBy"] = value.Substring(0, 50);
else this["PartTimerAssessmentSession_CreatedBy"] = value;
}
}
public System.DateTime PartTimerAssessmentSession_CreatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentSession_CreatedDate"];
}
set {
this["PartTimerAssessmentSession_CreatedDate"] = value;
}
}
public System.String PartTimerAssessmentSession_UpdatedBy {
get {
return (System.String)this["PartTimerAssessmentSession_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["PartTimerAssessmentSession_UpdatedBy"] = value.Substring(0, 50);
else this["PartTimerAssessmentSession_UpdatedBy"] = value;
}
}
public System.DateTime PartTimerAssessmentSession_UpdatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentSession_UpdatedDate"];
}
set {
this["PartTimerAssessmentSession_UpdatedDate"] = value;
}
}
public System.Boolean PartTimerAssessmentSession_IsDeleted {
get {
return (System.Boolean)this["PartTimerAssessmentSession_IsDeleted"];
}
set {
this["PartTimerAssessmentSession_IsDeleted"] = value;
}
}
public System.Int16 PartTimerAssessmentSession_SessionType {
get {
return (System.Int16)this["PartTimerAssessmentSession_SessionType"];
}
set {
this["PartTimerAssessmentSession_SessionType"] = value;
}
}
public System.Boolean PartTimerAssessmentSession_IsSent {
get {
return (System.Boolean)this["PartTimerAssessmentSession_IsSent"];
}
set {
this["PartTimerAssessmentSession_IsSent"] = value;
}
}
}
public partial class PartTimerAssessmentSessionMinimalizedEntity {
public PartTimerAssessmentSessionMinimalizedEntity() {}
public PartTimerAssessmentSessionMinimalizedEntity(PartTimerAssessmentSessionRow dr) {
this.PartTimerAssessmentSession_ID = dr.PartTimerAssessmentSession_ID;
this.PartTimerAssessmentSession_Location = dr.PartTimerAssessmentSession_Location;
this.PartTimerAssessmentSession_DateTime = dr.PartTimerAssessmentSession_DateTime;
this.PartTimerAssessmentSession_MaximumStudent = dr.PartTimerAssessmentSession_MaximumStudent;
this.PartTimerAssessmentSession_Remark = dr.PartTimerAssessmentSession_Remark;
this.PartTimerAssessmentSession_CreatedBy = dr.PartTimerAssessmentSession_CreatedBy;
this.PartTimerAssessmentSession_CreatedDate = dr.PartTimerAssessmentSession_CreatedDate;
this.PartTimerAssessmentSession_UpdatedBy = dr.PartTimerAssessmentSession_UpdatedBy;
this.PartTimerAssessmentSession_UpdatedDate = dr.PartTimerAssessmentSession_UpdatedDate;
this.PartTimerAssessmentSession_IsDeleted = dr.PartTimerAssessmentSession_IsDeleted;
this.PartTimerAssessmentSession_SessionType = dr.PartTimerAssessmentSession_SessionType;
this.PartTimerAssessmentSession_IsSent = dr.PartTimerAssessmentSession_IsSent;
}
public void CopyTo(PartTimerAssessmentSessionRow dr) {
dr.PartTimerAssessmentSession_ID = this.PartTimerAssessmentSession_ID;
dr.PartTimerAssessmentSession_Location = this.PartTimerAssessmentSession_Location;
dr.PartTimerAssessmentSession_DateTime = this.PartTimerAssessmentSession_DateTime;
dr.PartTimerAssessmentSession_MaximumStudent = this.PartTimerAssessmentSession_MaximumStudent;
dr.PartTimerAssessmentSession_Remark = this.PartTimerAssessmentSession_Remark;
dr.PartTimerAssessmentSession_CreatedBy = this.PartTimerAssessmentSession_CreatedBy;
dr.PartTimerAssessmentSession_CreatedDate = this.PartTimerAssessmentSession_CreatedDate;
dr.PartTimerAssessmentSession_UpdatedBy = this.PartTimerAssessmentSession_UpdatedBy;
dr.PartTimerAssessmentSession_UpdatedDate = this.PartTimerAssessmentSession_UpdatedDate;
dr.PartTimerAssessmentSession_IsDeleted = this.PartTimerAssessmentSession_IsDeleted;
dr.PartTimerAssessmentSession_SessionType = this.PartTimerAssessmentSession_SessionType;
dr.PartTimerAssessmentSession_IsSent = this.PartTimerAssessmentSession_IsSent;
}
public System.Guid PartTimerAssessmentSession_ID;
public System.String PartTimerAssessmentSession_Location;
public System.DateTime PartTimerAssessmentSession_DateTime;
public System.Int32 PartTimerAssessmentSession_MaximumStudent;
public System.String PartTimerAssessmentSession_Remark;
public System.String PartTimerAssessmentSession_CreatedBy;
public System.DateTime PartTimerAssessmentSession_CreatedDate;
public System.String PartTimerAssessmentSession_UpdatedBy;
public System.DateTime PartTimerAssessmentSession_UpdatedDate;
public System.Boolean PartTimerAssessmentSession_IsDeleted;
public System.Int16 PartTimerAssessmentSession_SessionType;
public System.Boolean PartTimerAssessmentSession_IsSent;
}
public partial class PartTimerAssessmentSessionAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PartTimerAssessmentSessionAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("PartTimerAssessmentSession_ID", "PartTimerAssessmentSession_ID");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_Location", "PartTimerAssessmentSession_Location");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_DateTime", "PartTimerAssessmentSession_DateTime");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_MaximumStudent", "PartTimerAssessmentSession_MaximumStudent");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_Remark", "PartTimerAssessmentSession_Remark");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_CreatedBy", "PartTimerAssessmentSession_CreatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_CreatedDate", "PartTimerAssessmentSession_CreatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_UpdatedBy", "PartTimerAssessmentSession_UpdatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_UpdatedDate", "PartTimerAssessmentSession_UpdatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_IsDeleted", "PartTimerAssessmentSession_IsDeleted");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_SessionType", "PartTimerAssessmentSession_SessionType");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_IsSent", "PartTimerAssessmentSession_IsSent");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [PartTimerAssessmentSession] ([PartTimerAssessmentSession_ID], [PartTimerAssessmentSession_Location], [PartTimerAssessmentSession_DateTime], [PartTimerAssessmentSession_MaximumStudent], [PartTimerAssessmentSession_Remark], [PartTimerAssessmentSession_CreatedBy], [PartTimerAssessmentSession_CreatedDate], [PartTimerAssessmentSession_UpdatedBy], [PartTimerAssessmentSession_UpdatedDate], [PartTimerAssessmentSession_IsDeleted], [PartTimerAssessmentSession_SessionType], [PartTimerAssessmentSession_IsSent]) VALUES (@PartTimerAssessmentSession_ID, @PartTimerAssessmentSession_Location, @PartTimerAssessmentSession_DateTime, @PartTimerAssessmentSession_MaximumStudent, @PartTimerAssessmentSession_Remark, @PartTimerAssessmentSession_CreatedBy, @PartTimerAssessmentSession_CreatedDate, @PartTimerAssessmentSession_UpdatedBy, @PartTimerAssessmentSession_UpdatedDate, @PartTimerAssessmentSession_IsDeleted, @PartTimerAssessmentSession_SessionType, @PartTimerAssessmentSession_IsSent)");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSession_ID");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_Location", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_Location");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_DateTime", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_DateTime");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_MaximumStudent", SqlDbType.Int, 0, "PartTimerAssessmentSession_MaximumStudent");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_Remark", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_Remark");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_CreatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_CreatedBy");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_CreatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_CreatedDate");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_UpdatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_UpdatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_IsDeleted", SqlDbType.Bit, 0, "PartTimerAssessmentSession_IsDeleted");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_SessionType", SqlDbType.SmallInt, 0, "PartTimerAssessmentSession_SessionType");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_IsSent", SqlDbType.Bit, 0, "PartTimerAssessmentSession_IsSent");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [PartTimerAssessmentSession] SET [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID, [PartTimerAssessmentSession_Location] = @PartTimerAssessmentSession_Location, [PartTimerAssessmentSession_DateTime] = @PartTimerAssessmentSession_DateTime, [PartTimerAssessmentSession_MaximumStudent] = @PartTimerAssessmentSession_MaximumStudent, [PartTimerAssessmentSession_Remark] = @PartTimerAssessmentSession_Remark, [PartTimerAssessmentSession_CreatedBy] = @PartTimerAssessmentSession_CreatedBy, [PartTimerAssessmentSession_CreatedDate] = @PartTimerAssessmentSession_CreatedDate, [PartTimerAssessmentSession_UpdatedBy] = @PartTimerAssessmentSession_UpdatedBy, [PartTimerAssessmentSession_UpdatedDate] = @PartTimerAssessmentSession_UpdatedDate, [PartTimerAssessmentSession_IsDeleted] = @PartTimerAssessmentSession_IsDeleted, [PartTimerAssessmentSession_SessionType] = @PartTimerAssessmentSession_SessionType, [PartTimerAssessmentSession_IsSent] = @PartTimerAssessmentSession_IsSent WHERE [PartTimerAssessmentSession_ID] = @o_PartTimerAssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentSession_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_Location", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_Location");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_DateTime", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_DateTime");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_MaximumStudent", SqlDbType.Int, 0, "PartTimerAssessmentSession_MaximumStudent");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_Remark", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_Remark");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_CreatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_CreatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_UpdatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentSession_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_UpdatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentSession_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_IsDeleted", SqlDbType.Bit, 0, "PartTimerAssessmentSession_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_SessionType", SqlDbType.SmallInt, 0, "PartTimerAssessmentSession_SessionType");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_IsSent", SqlDbType.Bit, 0, "PartTimerAssessmentSession_IsSent");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [PartTimerAssessmentSession] WHERE [PartTimerAssessmentSession_ID] = @o_PartTimerAssessmentSession_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentSession_ID", DataRowVersion.Original, null));
}
public void Update(PartTimerAssessmentSessionTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(PartTimerAssessmentSessionRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public PartTimerAssessmentSessionRow GetByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID ) {
string sql = "SELECT * FROM [PartTimerAssessmentSession] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);

PartTimerAssessmentSessionTable tbl = new PartTimerAssessmentSessionTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPartTimerAssessmentSessionRow(0);
}
public int CountByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID ) {
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentSession] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID, IActivityLog log ) {
string sql = "DELETE FROM [PartTimerAssessmentSession] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
