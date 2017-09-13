using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class AssessmentSessionTable : DataTable {
// column indexes
public const int AssessmentSession_IDColumnIndex = 0;
public const int AssessmentSession_LocationColumnIndex = 1;
public const int AssessmentSession_DateTimeColumnIndex = 2;
public const int AssessmentSession_MaximumStudentColumnIndex = 3;
public const int AssessmentSession_RemarkColumnIndex = 4;
public const int AssessmentSession_CreatedByColumnIndex = 5;
public const int AssessmentSession_CreatedDateColumnIndex = 6;
public const int AssessmentSession_UpdatedByColumnIndex = 7;
public const int AssessmentSession_UpdatedDateColumnIndex = 8;
public const int AssessmentSession_IsDeletedColumnIndex = 9;
public const int AssessmentSession_IsInterviewColumnIndex = 10;
public const int AssessmentSession_IsSentColumnIndex = 11;
public AssessmentSessionTable() {
TableName = "[AssessmentSession]";
// column AssessmentSession_ID
DataColumn AssessmentSession_IDCol = new DataColumn("AssessmentSession_ID", typeof(System.Guid));
AssessmentSession_IDCol.ReadOnly = false;
AssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IDCol);
// column AssessmentSession_Location
DataColumn AssessmentSession_LocationCol = new DataColumn("AssessmentSession_Location", typeof(System.String));
AssessmentSession_LocationCol.ReadOnly = false;
AssessmentSession_LocationCol.AllowDBNull = false;
Columns.Add(AssessmentSession_LocationCol);
// column AssessmentSession_DateTime
DataColumn AssessmentSession_DateTimeCol = new DataColumn("AssessmentSession_DateTime", typeof(System.DateTime));
AssessmentSession_DateTimeCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_DateTimeCol.ReadOnly = false;
AssessmentSession_DateTimeCol.AllowDBNull = false;
Columns.Add(AssessmentSession_DateTimeCol);
// column AssessmentSession_MaximumStudent
DataColumn AssessmentSession_MaximumStudentCol = new DataColumn("AssessmentSession_MaximumStudent", typeof(System.Int32));
AssessmentSession_MaximumStudentCol.ReadOnly = false;
AssessmentSession_MaximumStudentCol.AllowDBNull = false;
Columns.Add(AssessmentSession_MaximumStudentCol);
// column AssessmentSession_Remark
DataColumn AssessmentSession_RemarkCol = new DataColumn("AssessmentSession_Remark", typeof(System.String));
AssessmentSession_RemarkCol.ReadOnly = false;
AssessmentSession_RemarkCol.AllowDBNull = false;
Columns.Add(AssessmentSession_RemarkCol);
// column AssessmentSession_CreatedBy
DataColumn AssessmentSession_CreatedByCol = new DataColumn("AssessmentSession_CreatedBy", typeof(System.String));
AssessmentSession_CreatedByCol.ReadOnly = false;
AssessmentSession_CreatedByCol.AllowDBNull = false;
Columns.Add(AssessmentSession_CreatedByCol);
// column AssessmentSession_CreatedDate
DataColumn AssessmentSession_CreatedDateCol = new DataColumn("AssessmentSession_CreatedDate", typeof(System.DateTime));
AssessmentSession_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_CreatedDateCol.ReadOnly = false;
AssessmentSession_CreatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentSession_CreatedDateCol);
// column AssessmentSession_UpdatedBy
DataColumn AssessmentSession_UpdatedByCol = new DataColumn("AssessmentSession_UpdatedBy", typeof(System.String));
AssessmentSession_UpdatedByCol.ReadOnly = false;
AssessmentSession_UpdatedByCol.AllowDBNull = false;
Columns.Add(AssessmentSession_UpdatedByCol);
// column AssessmentSession_UpdatedDate
DataColumn AssessmentSession_UpdatedDateCol = new DataColumn("AssessmentSession_UpdatedDate", typeof(System.DateTime));
AssessmentSession_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_UpdatedDateCol.ReadOnly = false;
AssessmentSession_UpdatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentSession_UpdatedDateCol);
// column AssessmentSession_IsDeleted
DataColumn AssessmentSession_IsDeletedCol = new DataColumn("AssessmentSession_IsDeleted", typeof(System.Boolean));
AssessmentSession_IsDeletedCol.ReadOnly = false;
AssessmentSession_IsDeletedCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsDeletedCol);
// column AssessmentSession_IsInterview
DataColumn AssessmentSession_IsInterviewCol = new DataColumn("AssessmentSession_IsInterview", typeof(System.Boolean));
AssessmentSession_IsInterviewCol.ReadOnly = false;
AssessmentSession_IsInterviewCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsInterviewCol);
// column AssessmentSession_IsSent
DataColumn AssessmentSession_IsSentCol = new DataColumn("AssessmentSession_IsSent", typeof(System.Boolean));
AssessmentSession_IsSentCol.ReadOnly = false;
AssessmentSession_IsSentCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsSentCol);
}
public AssessmentSessionRow NewAssessmentSessionRow() {
AssessmentSessionRow row = (AssessmentSessionRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(AssessmentSessionRow row) {
row.AssessmentSession_ID = Guid.Empty;
row.AssessmentSession_Location = "";
row.AssessmentSession_DateTime = DateTime.Now;
row.AssessmentSession_MaximumStudent = 0;
row.AssessmentSession_Remark = "";
row.AssessmentSession_CreatedBy = "";
row.AssessmentSession_CreatedDate = DateTime.Now;
row.AssessmentSession_UpdatedBy = "";
row.AssessmentSession_UpdatedDate = DateTime.Now;
row.AssessmentSession_IsDeleted = false;
row.AssessmentSession_IsInterview = false;
row.AssessmentSession_IsSent = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new AssessmentSessionRow(builder);
}
public AssessmentSessionRow GetAssessmentSessionRow(int index) {
return (AssessmentSessionRow)Rows[index];
}
}
public partial class AssessmentSessionRow : DataRow {
internal AssessmentSessionRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid AssessmentSession_ID {
get {
return (System.Guid)this["AssessmentSession_ID"];
}
set {
this["AssessmentSession_ID"] = value;
}
}
public System.String AssessmentSession_Location {
get {
return (System.String)this["AssessmentSession_Location"];
}
set {
if( value.Length > 150 ) this["AssessmentSession_Location"] = value.Substring(0, 150);
else this["AssessmentSession_Location"] = value;
}
}
public System.DateTime AssessmentSession_DateTime {
get {
return (System.DateTime)this["AssessmentSession_DateTime"];
}
set {
this["AssessmentSession_DateTime"] = value;
}
}
public System.Int32 AssessmentSession_MaximumStudent {
get {
return (System.Int32)this["AssessmentSession_MaximumStudent"];
}
set {
this["AssessmentSession_MaximumStudent"] = value;
}
}
public System.String AssessmentSession_Remark {
get {
return (System.String)this["AssessmentSession_Remark"];
}
set {
if( value.Length > 250 ) this["AssessmentSession_Remark"] = value.Substring(0, 250);
else this["AssessmentSession_Remark"] = value;
}
}
public System.String AssessmentSession_CreatedBy {
get {
return (System.String)this["AssessmentSession_CreatedBy"];
}
set {
if( value.Length > 50 ) this["AssessmentSession_CreatedBy"] = value.Substring(0, 50);
else this["AssessmentSession_CreatedBy"] = value;
}
}
public System.DateTime AssessmentSession_CreatedDate {
get {
return (System.DateTime)this["AssessmentSession_CreatedDate"];
}
set {
this["AssessmentSession_CreatedDate"] = value;
}
}
public System.String AssessmentSession_UpdatedBy {
get {
return (System.String)this["AssessmentSession_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["AssessmentSession_UpdatedBy"] = value.Substring(0, 50);
else this["AssessmentSession_UpdatedBy"] = value;
}
}
public System.DateTime AssessmentSession_UpdatedDate {
get {
return (System.DateTime)this["AssessmentSession_UpdatedDate"];
}
set {
this["AssessmentSession_UpdatedDate"] = value;
}
}
public System.Boolean AssessmentSession_IsDeleted {
get {
return (System.Boolean)this["AssessmentSession_IsDeleted"];
}
set {
this["AssessmentSession_IsDeleted"] = value;
}
}
public System.Boolean AssessmentSession_IsInterview {
get {
return (System.Boolean)this["AssessmentSession_IsInterview"];
}
set {
this["AssessmentSession_IsInterview"] = value;
}
}
public System.Boolean AssessmentSession_IsSent {
get {
return (System.Boolean)this["AssessmentSession_IsSent"];
}
set {
this["AssessmentSession_IsSent"] = value;
}
}
}
public partial class AssessmentSessionMinimalizedEntity {
public AssessmentSessionMinimalizedEntity() {}
public AssessmentSessionMinimalizedEntity(AssessmentSessionRow dr) {
this.AssessmentSession_ID = dr.AssessmentSession_ID;
this.AssessmentSession_Location = dr.AssessmentSession_Location;
this.AssessmentSession_DateTime = dr.AssessmentSession_DateTime;
this.AssessmentSession_MaximumStudent = dr.AssessmentSession_MaximumStudent;
this.AssessmentSession_Remark = dr.AssessmentSession_Remark;
this.AssessmentSession_CreatedBy = dr.AssessmentSession_CreatedBy;
this.AssessmentSession_CreatedDate = dr.AssessmentSession_CreatedDate;
this.AssessmentSession_UpdatedBy = dr.AssessmentSession_UpdatedBy;
this.AssessmentSession_UpdatedDate = dr.AssessmentSession_UpdatedDate;
this.AssessmentSession_IsDeleted = dr.AssessmentSession_IsDeleted;
this.AssessmentSession_IsInterview = dr.AssessmentSession_IsInterview;
this.AssessmentSession_IsSent = dr.AssessmentSession_IsSent;
}
public void CopyTo(AssessmentSessionRow dr) {
dr.AssessmentSession_ID = this.AssessmentSession_ID;
dr.AssessmentSession_Location = this.AssessmentSession_Location;
dr.AssessmentSession_DateTime = this.AssessmentSession_DateTime;
dr.AssessmentSession_MaximumStudent = this.AssessmentSession_MaximumStudent;
dr.AssessmentSession_Remark = this.AssessmentSession_Remark;
dr.AssessmentSession_CreatedBy = this.AssessmentSession_CreatedBy;
dr.AssessmentSession_CreatedDate = this.AssessmentSession_CreatedDate;
dr.AssessmentSession_UpdatedBy = this.AssessmentSession_UpdatedBy;
dr.AssessmentSession_UpdatedDate = this.AssessmentSession_UpdatedDate;
dr.AssessmentSession_IsDeleted = this.AssessmentSession_IsDeleted;
dr.AssessmentSession_IsInterview = this.AssessmentSession_IsInterview;
dr.AssessmentSession_IsSent = this.AssessmentSession_IsSent;
}
public System.Guid AssessmentSession_ID;
public System.String AssessmentSession_Location;
public System.DateTime AssessmentSession_DateTime;
public System.Int32 AssessmentSession_MaximumStudent;
public System.String AssessmentSession_Remark;
public System.String AssessmentSession_CreatedBy;
public System.DateTime AssessmentSession_CreatedDate;
public System.String AssessmentSession_UpdatedBy;
public System.DateTime AssessmentSession_UpdatedDate;
public System.Boolean AssessmentSession_IsDeleted;
public System.Boolean AssessmentSession_IsInterview;
public System.Boolean AssessmentSession_IsSent;
}
public partial class AssessmentSessionAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public AssessmentSessionAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("AssessmentSession_ID", "AssessmentSession_ID");
tmap.ColumnMappings.Add("AssessmentSession_Location", "AssessmentSession_Location");
tmap.ColumnMappings.Add("AssessmentSession_DateTime", "AssessmentSession_DateTime");
tmap.ColumnMappings.Add("AssessmentSession_MaximumStudent", "AssessmentSession_MaximumStudent");
tmap.ColumnMappings.Add("AssessmentSession_Remark", "AssessmentSession_Remark");
tmap.ColumnMappings.Add("AssessmentSession_CreatedBy", "AssessmentSession_CreatedBy");
tmap.ColumnMappings.Add("AssessmentSession_CreatedDate", "AssessmentSession_CreatedDate");
tmap.ColumnMappings.Add("AssessmentSession_UpdatedBy", "AssessmentSession_UpdatedBy");
tmap.ColumnMappings.Add("AssessmentSession_UpdatedDate", "AssessmentSession_UpdatedDate");
tmap.ColumnMappings.Add("AssessmentSession_IsDeleted", "AssessmentSession_IsDeleted");
tmap.ColumnMappings.Add("AssessmentSession_IsInterview", "AssessmentSession_IsInterview");
tmap.ColumnMappings.Add("AssessmentSession_IsSent", "AssessmentSession_IsSent");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [AssessmentSession] ([AssessmentSession_ID], [AssessmentSession_Location], [AssessmentSession_DateTime], [AssessmentSession_MaximumStudent], [AssessmentSession_Remark], [AssessmentSession_CreatedBy], [AssessmentSession_CreatedDate], [AssessmentSession_UpdatedBy], [AssessmentSession_UpdatedDate], [AssessmentSession_IsDeleted], [AssessmentSession_IsInterview], [AssessmentSession_IsSent]) VALUES (@AssessmentSession_ID, @AssessmentSession_Location, @AssessmentSession_DateTime, @AssessmentSession_MaximumStudent, @AssessmentSession_Remark, @AssessmentSession_CreatedBy, @AssessmentSession_CreatedDate, @AssessmentSession_UpdatedBy, @AssessmentSession_UpdatedDate, @AssessmentSession_IsDeleted, @AssessmentSession_IsInterview, @AssessmentSession_IsSent)");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSession_ID");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_Location", SqlDbType.NVarChar, 0, "AssessmentSession_Location");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_DateTime", SqlDbType.DateTime, 0, "AssessmentSession_DateTime");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_MaximumStudent", SqlDbType.Int, 0, "AssessmentSession_MaximumStudent");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_Remark", SqlDbType.NVarChar, 0, "AssessmentSession_Remark");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_CreatedBy", SqlDbType.NVarChar, 0, "AssessmentSession_CreatedBy");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_CreatedDate", SqlDbType.DateTime, 0, "AssessmentSession_CreatedDate");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_UpdatedBy", SqlDbType.NVarChar, 0, "AssessmentSession_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_UpdatedDate", SqlDbType.DateTime, 0, "AssessmentSession_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_IsDeleted", SqlDbType.Bit, 0, "AssessmentSession_IsDeleted");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_IsInterview", SqlDbType.Bit, 0, "AssessmentSession_IsInterview");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_IsSent", SqlDbType.Bit, 0, "AssessmentSession_IsSent");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [AssessmentSession] SET [AssessmentSession_ID] = @AssessmentSession_ID, [AssessmentSession_Location] = @AssessmentSession_Location, [AssessmentSession_DateTime] = @AssessmentSession_DateTime, [AssessmentSession_MaximumStudent] = @AssessmentSession_MaximumStudent, [AssessmentSession_Remark] = @AssessmentSession_Remark, [AssessmentSession_CreatedBy] = @AssessmentSession_CreatedBy, [AssessmentSession_CreatedDate] = @AssessmentSession_CreatedDate, [AssessmentSession_UpdatedBy] = @AssessmentSession_UpdatedBy, [AssessmentSession_UpdatedDate] = @AssessmentSession_UpdatedDate, [AssessmentSession_IsDeleted] = @AssessmentSession_IsDeleted, [AssessmentSession_IsInterview] = @AssessmentSession_IsInterview, [AssessmentSession_IsSent] = @AssessmentSession_IsSent WHERE [AssessmentSession_ID] = @o_AssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentSession_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_Location", SqlDbType.NVarChar, 0, "AssessmentSession_Location");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_DateTime", SqlDbType.DateTime, 0, "AssessmentSession_DateTime");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_MaximumStudent", SqlDbType.Int, 0, "AssessmentSession_MaximumStudent");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_Remark", SqlDbType.NVarChar, 0, "AssessmentSession_Remark");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_CreatedBy", SqlDbType.NVarChar, 0, "AssessmentSession_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_CreatedDate", SqlDbType.DateTime, 0, "AssessmentSession_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_UpdatedBy", SqlDbType.NVarChar, 0, "AssessmentSession_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_UpdatedDate", SqlDbType.DateTime, 0, "AssessmentSession_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_IsDeleted", SqlDbType.Bit, 0, "AssessmentSession_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_IsInterview", SqlDbType.Bit, 0, "AssessmentSession_IsInterview");
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_IsSent", SqlDbType.Bit, 0, "AssessmentSession_IsSent");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [AssessmentSession] WHERE [AssessmentSession_ID] = @o_AssessmentSession_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentSession_ID", DataRowVersion.Original, null));
}
public void Update(AssessmentSessionTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(AssessmentSessionRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public AssessmentSessionRow GetByAssessmentSession_ID(System.Guid AssessmentSession_ID ) {
string sql = "SELECT * FROM [AssessmentSession] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);

AssessmentSessionTable tbl = new AssessmentSessionTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetAssessmentSessionRow(0);
}
public int CountByAssessmentSession_ID(System.Guid AssessmentSession_ID ) {
string sql = "SELECT COUNT(*) FROM [AssessmentSession] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByAssessmentSession_ID(System.Guid AssessmentSession_ID, IActivityLog log ) {
string sql = "DELETE FROM [AssessmentSession] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
