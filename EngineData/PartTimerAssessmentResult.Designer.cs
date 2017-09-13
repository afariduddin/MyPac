using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PartTimerAssessmentResultTable : DataTable {
// column indexes
public const int PartTimerAssessmentResult_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int PartTimerAssessmentResult_Assessment1ColumnIndex = 2;
public const int PartTimerAssessmentResult_Assessment2ColumnIndex = 3;
public const int PartTimerAssessmentResult_Assessment3ColumnIndex = 4;
public const int PartTimerAssessmentResult_AttendanceColumnIndex = 5;
public const int PartTimerAssessmentResult_StatusColumnIndex = 6;
public const int PartTimerAssessmentResult_CreatedDateColumnIndex = 7;
public const int PartTimerAssessmentResult_CreatedByColumnIndex = 8;
public const int PartTimerAssessmentResult_UpdatedByColumnIndex = 9;
public const int PartTimerAssessmentResult_UpdatedDateColumnIndex = 10;
public const int PartTimerAssessmentResult_IsDeletedColumnIndex = 11;
public const int PartTimerAssessmentResult_RemarkColumnIndex = 12;
public const int PartTimerAssessmentResult_InterviewResultColumnIndex = 13;
public const int PartTimerAssessmentResult_InterviewLocationColumnIndex = 14;
public PartTimerAssessmentResultTable() {
TableName = "[PartTimerAssessmentResult]";
// column PartTimerAssessmentResult_ID
DataColumn PartTimerAssessmentResult_IDCol = new DataColumn("PartTimerAssessmentResult_ID", typeof(System.Guid));
PartTimerAssessmentResult_IDCol.ReadOnly = false;
PartTimerAssessmentResult_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column PartTimerAssessmentResult_Assessment1
DataColumn PartTimerAssessmentResult_Assessment1Col = new DataColumn("PartTimerAssessmentResult_Assessment1", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment1Col.ReadOnly = false;
PartTimerAssessmentResult_Assessment1Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment1Col);
// column PartTimerAssessmentResult_Assessment2
DataColumn PartTimerAssessmentResult_Assessment2Col = new DataColumn("PartTimerAssessmentResult_Assessment2", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment2Col.ReadOnly = false;
PartTimerAssessmentResult_Assessment2Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment2Col);
// column PartTimerAssessmentResult_Assessment3
DataColumn PartTimerAssessmentResult_Assessment3Col = new DataColumn("PartTimerAssessmentResult_Assessment3", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment3Col.ReadOnly = false;
PartTimerAssessmentResult_Assessment3Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment3Col);
// column PartTimerAssessmentResult_Attendance
DataColumn PartTimerAssessmentResult_AttendanceCol = new DataColumn("PartTimerAssessmentResult_Attendance", typeof(System.Decimal));
PartTimerAssessmentResult_AttendanceCol.ReadOnly = false;
PartTimerAssessmentResult_AttendanceCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_AttendanceCol);
// column PartTimerAssessmentResult_Status
DataColumn PartTimerAssessmentResult_StatusCol = new DataColumn("PartTimerAssessmentResult_Status", typeof(System.Int16));
PartTimerAssessmentResult_StatusCol.ReadOnly = false;
PartTimerAssessmentResult_StatusCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_StatusCol);
// column PartTimerAssessmentResult_CreatedDate
DataColumn PartTimerAssessmentResult_CreatedDateCol = new DataColumn("PartTimerAssessmentResult_CreatedDate", typeof(System.DateTime));
PartTimerAssessmentResult_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentResult_CreatedDateCol.ReadOnly = false;
PartTimerAssessmentResult_CreatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_CreatedDateCol);
// column PartTimerAssessmentResult_CreatedBy
DataColumn PartTimerAssessmentResult_CreatedByCol = new DataColumn("PartTimerAssessmentResult_CreatedBy", typeof(System.String));
PartTimerAssessmentResult_CreatedByCol.ReadOnly = false;
PartTimerAssessmentResult_CreatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_CreatedByCol);
// column PartTimerAssessmentResult_UpdatedBy
DataColumn PartTimerAssessmentResult_UpdatedByCol = new DataColumn("PartTimerAssessmentResult_UpdatedBy", typeof(System.String));
PartTimerAssessmentResult_UpdatedByCol.ReadOnly = false;
PartTimerAssessmentResult_UpdatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_UpdatedByCol);
// column PartTimerAssessmentResult_UpdatedDate
DataColumn PartTimerAssessmentResult_UpdatedDateCol = new DataColumn("PartTimerAssessmentResult_UpdatedDate", typeof(System.DateTime));
PartTimerAssessmentResult_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentResult_UpdatedDateCol.ReadOnly = false;
PartTimerAssessmentResult_UpdatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_UpdatedDateCol);
// column PartTimerAssessmentResult_IsDeleted
DataColumn PartTimerAssessmentResult_IsDeletedCol = new DataColumn("PartTimerAssessmentResult_IsDeleted", typeof(System.Boolean));
PartTimerAssessmentResult_IsDeletedCol.ReadOnly = false;
PartTimerAssessmentResult_IsDeletedCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_IsDeletedCol);
// column PartTimerAssessmentResult_Remark
DataColumn PartTimerAssessmentResult_RemarkCol = new DataColumn("PartTimerAssessmentResult_Remark", typeof(System.String));
PartTimerAssessmentResult_RemarkCol.ReadOnly = false;
PartTimerAssessmentResult_RemarkCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_RemarkCol);
// column PartTimerAssessmentResult_InterviewResult
DataColumn PartTimerAssessmentResult_InterviewResultCol = new DataColumn("PartTimerAssessmentResult_InterviewResult", typeof(System.Int16));
PartTimerAssessmentResult_InterviewResultCol.ReadOnly = false;
PartTimerAssessmentResult_InterviewResultCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_InterviewResultCol);
// column PartTimerAssessmentResult_InterviewLocation
DataColumn PartTimerAssessmentResult_InterviewLocationCol = new DataColumn("PartTimerAssessmentResult_InterviewLocation", typeof(System.String));
PartTimerAssessmentResult_InterviewLocationCol.ReadOnly = false;
PartTimerAssessmentResult_InterviewLocationCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_InterviewLocationCol);
}
public PartTimerAssessmentResultRow NewPartTimerAssessmentResultRow() {
PartTimerAssessmentResultRow row = (PartTimerAssessmentResultRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(PartTimerAssessmentResultRow row) {
row.PartTimerAssessmentResult_ID = Guid.Empty;
row.Application_ID = Guid.Empty;
row.PartTimerAssessmentResult_Assessment1 = 0;
row.PartTimerAssessmentResult_Assessment2 = 0;
row.PartTimerAssessmentResult_Assessment3 = 0;
row.PartTimerAssessmentResult_Attendance = 0;
row.PartTimerAssessmentResult_Status = 0;
row.PartTimerAssessmentResult_CreatedDate = DateTime.Now;
row.PartTimerAssessmentResult_CreatedBy = "";
row.PartTimerAssessmentResult_UpdatedBy = "";
row.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;
row.PartTimerAssessmentResult_IsDeleted = false;
row.PartTimerAssessmentResult_Remark = "";
row.PartTimerAssessmentResult_InterviewResult = 0;
row.PartTimerAssessmentResult_InterviewLocation = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PartTimerAssessmentResultRow(builder);
}
public PartTimerAssessmentResultRow GetPartTimerAssessmentResultRow(int index) {
return (PartTimerAssessmentResultRow)Rows[index];
}
}
public partial class PartTimerAssessmentResultRow : DataRow {
internal PartTimerAssessmentResultRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid PartTimerAssessmentResult_ID {
get {
return (System.Guid)this["PartTimerAssessmentResult_ID"];
}
set {
this["PartTimerAssessmentResult_ID"] = value;
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
public System.Decimal PartTimerAssessmentResult_Assessment1 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment1"];
}
set {
this["PartTimerAssessmentResult_Assessment1"] = value;
}
}
public System.Decimal PartTimerAssessmentResult_Assessment2 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment2"];
}
set {
this["PartTimerAssessmentResult_Assessment2"] = value;
}
}
public System.Decimal PartTimerAssessmentResult_Assessment3 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment3"];
}
set {
this["PartTimerAssessmentResult_Assessment3"] = value;
}
}
public System.Decimal PartTimerAssessmentResult_Attendance {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Attendance"];
}
set {
this["PartTimerAssessmentResult_Attendance"] = value;
}
}
public System.Int16 PartTimerAssessmentResult_Status {
get {
return (System.Int16)this["PartTimerAssessmentResult_Status"];
}
set {
this["PartTimerAssessmentResult_Status"] = value;
}
}
public System.DateTime PartTimerAssessmentResult_CreatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentResult_CreatedDate"];
}
set {
this["PartTimerAssessmentResult_CreatedDate"] = value;
}
}
public System.String PartTimerAssessmentResult_CreatedBy {
get {
return (System.String)this["PartTimerAssessmentResult_CreatedBy"];
}
set {
if( value.Length > 50 ) this["PartTimerAssessmentResult_CreatedBy"] = value.Substring(0, 50);
else this["PartTimerAssessmentResult_CreatedBy"] = value;
}
}
public System.String PartTimerAssessmentResult_UpdatedBy {
get {
return (System.String)this["PartTimerAssessmentResult_UpdatedBy"];
}
set {
if( value.Length > 10 ) this["PartTimerAssessmentResult_UpdatedBy"] = value.Substring(0, 10);
else this["PartTimerAssessmentResult_UpdatedBy"] = value;
}
}
public System.DateTime PartTimerAssessmentResult_UpdatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentResult_UpdatedDate"];
}
set {
this["PartTimerAssessmentResult_UpdatedDate"] = value;
}
}
public System.Boolean PartTimerAssessmentResult_IsDeleted {
get {
return (System.Boolean)this["PartTimerAssessmentResult_IsDeleted"];
}
set {
this["PartTimerAssessmentResult_IsDeleted"] = value;
}
}
public System.String PartTimerAssessmentResult_Remark {
get {
return (System.String)this["PartTimerAssessmentResult_Remark"];
}
set {
if( value.Length > 250 ) this["PartTimerAssessmentResult_Remark"] = value.Substring(0, 250);
else this["PartTimerAssessmentResult_Remark"] = value;
}
}
public System.Int16 PartTimerAssessmentResult_InterviewResult {
get {
return (System.Int16)this["PartTimerAssessmentResult_InterviewResult"];
}
set {
this["PartTimerAssessmentResult_InterviewResult"] = value;
}
}
public System.String PartTimerAssessmentResult_InterviewLocation {
get {
return (System.String)this["PartTimerAssessmentResult_InterviewLocation"];
}
set {
if( value.Length > 250 ) this["PartTimerAssessmentResult_InterviewLocation"] = value.Substring(0, 250);
else this["PartTimerAssessmentResult_InterviewLocation"] = value;
}
}
}
public partial class PartTimerAssessmentResultMinimalizedEntity {
public PartTimerAssessmentResultMinimalizedEntity() {}
public PartTimerAssessmentResultMinimalizedEntity(PartTimerAssessmentResultRow dr) {
this.PartTimerAssessmentResult_ID = dr.PartTimerAssessmentResult_ID;
this.Application_ID = dr.Application_ID;
this.PartTimerAssessmentResult_Assessment1 = dr.PartTimerAssessmentResult_Assessment1;
this.PartTimerAssessmentResult_Assessment2 = dr.PartTimerAssessmentResult_Assessment2;
this.PartTimerAssessmentResult_Assessment3 = dr.PartTimerAssessmentResult_Assessment3;
this.PartTimerAssessmentResult_Attendance = dr.PartTimerAssessmentResult_Attendance;
this.PartTimerAssessmentResult_Status = dr.PartTimerAssessmentResult_Status;
this.PartTimerAssessmentResult_CreatedDate = dr.PartTimerAssessmentResult_CreatedDate;
this.PartTimerAssessmentResult_CreatedBy = dr.PartTimerAssessmentResult_CreatedBy;
this.PartTimerAssessmentResult_UpdatedBy = dr.PartTimerAssessmentResult_UpdatedBy;
this.PartTimerAssessmentResult_UpdatedDate = dr.PartTimerAssessmentResult_UpdatedDate;
this.PartTimerAssessmentResult_IsDeleted = dr.PartTimerAssessmentResult_IsDeleted;
this.PartTimerAssessmentResult_Remark = dr.PartTimerAssessmentResult_Remark;
this.PartTimerAssessmentResult_InterviewResult = dr.PartTimerAssessmentResult_InterviewResult;
this.PartTimerAssessmentResult_InterviewLocation = dr.PartTimerAssessmentResult_InterviewLocation;
}
public void CopyTo(PartTimerAssessmentResultRow dr) {
dr.PartTimerAssessmentResult_ID = this.PartTimerAssessmentResult_ID;
dr.Application_ID = this.Application_ID;
dr.PartTimerAssessmentResult_Assessment1 = this.PartTimerAssessmentResult_Assessment1;
dr.PartTimerAssessmentResult_Assessment2 = this.PartTimerAssessmentResult_Assessment2;
dr.PartTimerAssessmentResult_Assessment3 = this.PartTimerAssessmentResult_Assessment3;
dr.PartTimerAssessmentResult_Attendance = this.PartTimerAssessmentResult_Attendance;
dr.PartTimerAssessmentResult_Status = this.PartTimerAssessmentResult_Status;
dr.PartTimerAssessmentResult_CreatedDate = this.PartTimerAssessmentResult_CreatedDate;
dr.PartTimerAssessmentResult_CreatedBy = this.PartTimerAssessmentResult_CreatedBy;
dr.PartTimerAssessmentResult_UpdatedBy = this.PartTimerAssessmentResult_UpdatedBy;
dr.PartTimerAssessmentResult_UpdatedDate = this.PartTimerAssessmentResult_UpdatedDate;
dr.PartTimerAssessmentResult_IsDeleted = this.PartTimerAssessmentResult_IsDeleted;
dr.PartTimerAssessmentResult_Remark = this.PartTimerAssessmentResult_Remark;
dr.PartTimerAssessmentResult_InterviewResult = this.PartTimerAssessmentResult_InterviewResult;
dr.PartTimerAssessmentResult_InterviewLocation = this.PartTimerAssessmentResult_InterviewLocation;
}
public System.Guid PartTimerAssessmentResult_ID;
public System.Guid Application_ID;
public System.Decimal PartTimerAssessmentResult_Assessment1;
public System.Decimal PartTimerAssessmentResult_Assessment2;
public System.Decimal PartTimerAssessmentResult_Assessment3;
public System.Decimal PartTimerAssessmentResult_Attendance;
public System.Int16 PartTimerAssessmentResult_Status;
public System.DateTime PartTimerAssessmentResult_CreatedDate;
public System.String PartTimerAssessmentResult_CreatedBy;
public System.String PartTimerAssessmentResult_UpdatedBy;
public System.DateTime PartTimerAssessmentResult_UpdatedDate;
public System.Boolean PartTimerAssessmentResult_IsDeleted;
public System.String PartTimerAssessmentResult_Remark;
public System.Int16 PartTimerAssessmentResult_InterviewResult;
public System.String PartTimerAssessmentResult_InterviewLocation;
}
public partial class PartTimerAssessmentResultAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PartTimerAssessmentResultAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("PartTimerAssessmentResult_ID", "PartTimerAssessmentResult_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment1", "PartTimerAssessmentResult_Assessment1");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment2", "PartTimerAssessmentResult_Assessment2");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment3", "PartTimerAssessmentResult_Assessment3");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Attendance", "PartTimerAssessmentResult_Attendance");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Status", "PartTimerAssessmentResult_Status");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_CreatedDate", "PartTimerAssessmentResult_CreatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_CreatedBy", "PartTimerAssessmentResult_CreatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_UpdatedBy", "PartTimerAssessmentResult_UpdatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_UpdatedDate", "PartTimerAssessmentResult_UpdatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_IsDeleted", "PartTimerAssessmentResult_IsDeleted");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Remark", "PartTimerAssessmentResult_Remark");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_InterviewResult", "PartTimerAssessmentResult_InterviewResult");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_InterviewLocation", "PartTimerAssessmentResult_InterviewLocation");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [PartTimerAssessmentResult] ([PartTimerAssessmentResult_ID], [Application_ID], [PartTimerAssessmentResult_Assessment1], [PartTimerAssessmentResult_Assessment2], [PartTimerAssessmentResult_Assessment3], [PartTimerAssessmentResult_Attendance], [PartTimerAssessmentResult_Status], [PartTimerAssessmentResult_CreatedDate], [PartTimerAssessmentResult_CreatedBy], [PartTimerAssessmentResult_UpdatedBy], [PartTimerAssessmentResult_UpdatedDate], [PartTimerAssessmentResult_IsDeleted], [PartTimerAssessmentResult_Remark], [PartTimerAssessmentResult_InterviewResult], [PartTimerAssessmentResult_InterviewLocation]) VALUES (@PartTimerAssessmentResult_ID, @Application_ID, @PartTimerAssessmentResult_Assessment1, @PartTimerAssessmentResult_Assessment2, @PartTimerAssessmentResult_Assessment3, @PartTimerAssessmentResult_Attendance, @PartTimerAssessmentResult_Status, @PartTimerAssessmentResult_CreatedDate, @PartTimerAssessmentResult_CreatedBy, @PartTimerAssessmentResult_UpdatedBy, @PartTimerAssessmentResult_UpdatedDate, @PartTimerAssessmentResult_IsDeleted, @PartTimerAssessmentResult_Remark, @PartTimerAssessmentResult_InterviewResult, @PartTimerAssessmentResult_InterviewLocation)");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentResult_ID");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment1", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment1");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment2", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment2");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment3", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment3");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Attendance", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Attendance");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Status", SqlDbType.SmallInt, 0, "PartTimerAssessmentResult_Status");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_CreatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentResult_CreatedDate");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_CreatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_CreatedBy");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_UpdatedBy", SqlDbType.NChar, 0, "PartTimerAssessmentResult_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_UpdatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentResult_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_IsDeleted", SqlDbType.Bit, 0, "PartTimerAssessmentResult_IsDeleted");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_Remark", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_Remark");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_InterviewResult", SqlDbType.SmallInt, 0, "PartTimerAssessmentResult_InterviewResult");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentResult_InterviewLocation", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_InterviewLocation");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [PartTimerAssessmentResult] SET [PartTimerAssessmentResult_ID] = @PartTimerAssessmentResult_ID, [Application_ID] = @Application_ID, [PartTimerAssessmentResult_Assessment1] = @PartTimerAssessmentResult_Assessment1, [PartTimerAssessmentResult_Assessment2] = @PartTimerAssessmentResult_Assessment2, [PartTimerAssessmentResult_Assessment3] = @PartTimerAssessmentResult_Assessment3, [PartTimerAssessmentResult_Attendance] = @PartTimerAssessmentResult_Attendance, [PartTimerAssessmentResult_Status] = @PartTimerAssessmentResult_Status, [PartTimerAssessmentResult_CreatedDate] = @PartTimerAssessmentResult_CreatedDate, [PartTimerAssessmentResult_CreatedBy] = @PartTimerAssessmentResult_CreatedBy, [PartTimerAssessmentResult_UpdatedBy] = @PartTimerAssessmentResult_UpdatedBy, [PartTimerAssessmentResult_UpdatedDate] = @PartTimerAssessmentResult_UpdatedDate, [PartTimerAssessmentResult_IsDeleted] = @PartTimerAssessmentResult_IsDeleted, [PartTimerAssessmentResult_Remark] = @PartTimerAssessmentResult_Remark, [PartTimerAssessmentResult_InterviewResult] = @PartTimerAssessmentResult_InterviewResult, [PartTimerAssessmentResult_InterviewLocation] = @PartTimerAssessmentResult_InterviewLocation WHERE [PartTimerAssessmentResult_ID] = @o_PartTimerAssessmentResult_ID");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentResult_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentResult_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment1", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment1");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment2", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment2");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Assessment3", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Assessment3");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Attendance", SqlDbType.Decimal, 0, "PartTimerAssessmentResult_Attendance");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Status", SqlDbType.SmallInt, 0, "PartTimerAssessmentResult_Status");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_CreatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentResult_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_CreatedBy", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_UpdatedBy", SqlDbType.NChar, 0, "PartTimerAssessmentResult_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_UpdatedDate", SqlDbType.DateTime, 0, "PartTimerAssessmentResult_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_IsDeleted", SqlDbType.Bit, 0, "PartTimerAssessmentResult_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_Remark", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_Remark");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_InterviewResult", SqlDbType.SmallInt, 0, "PartTimerAssessmentResult_InterviewResult");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentResult_InterviewLocation", SqlDbType.NVarChar, 0, "PartTimerAssessmentResult_InterviewLocation");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [PartTimerAssessmentResult] WHERE [PartTimerAssessmentResult_ID] = @o_PartTimerAssessmentResult_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentResult_ID", DataRowVersion.Original, null));
}
public void Update(PartTimerAssessmentResultTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(PartTimerAssessmentResultRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public PartTimerAssessmentResultRow GetByPartTimerAssessmentResult_ID(System.Guid PartTimerAssessmentResult_ID ) {
string sql = "SELECT * FROM [PartTimerAssessmentResult] WHERE [PartTimerAssessmentResult_ID] = @PartTimerAssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentResult_ID", PartTimerAssessmentResult_ID);

PartTimerAssessmentResultTable tbl = new PartTimerAssessmentResultTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPartTimerAssessmentResultRow(0);
}
public int CountByPartTimerAssessmentResult_ID(System.Guid PartTimerAssessmentResult_ID ) {
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentResult] WHERE [PartTimerAssessmentResult_ID] = @PartTimerAssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentResult_ID", PartTimerAssessmentResult_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPartTimerAssessmentResult_ID(System.Guid PartTimerAssessmentResult_ID, IActivityLog log ) {
string sql = "DELETE FROM [PartTimerAssessmentResult] WHERE [PartTimerAssessmentResult_ID] = @PartTimerAssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentResult_ID", PartTimerAssessmentResult_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public PartTimerAssessmentResultTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [PartTimerAssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
PartTimerAssessmentResultTable tbl = new PartTimerAssessmentResultTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [PartTimerAssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
