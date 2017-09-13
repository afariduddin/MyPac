using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class AssessmentSessionDetailTable : DataTable {
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
public const int AssessmentSession_AssignedStudentColumnIndex = 12;
public AssessmentSessionDetailTable() {
TableName = "[AssessmentSessionDetail]";
// column AssessmentSession_ID
DataColumn AssessmentSession_IDCol = new DataColumn("AssessmentSession_ID", typeof(System.Guid));
AssessmentSession_IDCol.ReadOnly = true;
AssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IDCol);
// column AssessmentSession_Location
DataColumn AssessmentSession_LocationCol = new DataColumn("AssessmentSession_Location", typeof(System.String));
AssessmentSession_LocationCol.ReadOnly = true;
AssessmentSession_LocationCol.AllowDBNull = false;
Columns.Add(AssessmentSession_LocationCol);
// column AssessmentSession_DateTime
DataColumn AssessmentSession_DateTimeCol = new DataColumn("AssessmentSession_DateTime", typeof(System.DateTime));
AssessmentSession_DateTimeCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_DateTimeCol.ReadOnly = true;
AssessmentSession_DateTimeCol.AllowDBNull = false;
Columns.Add(AssessmentSession_DateTimeCol);
// column AssessmentSession_MaximumStudent
DataColumn AssessmentSession_MaximumStudentCol = new DataColumn("AssessmentSession_MaximumStudent", typeof(System.Int32));
AssessmentSession_MaximumStudentCol.ReadOnly = true;
AssessmentSession_MaximumStudentCol.AllowDBNull = false;
Columns.Add(AssessmentSession_MaximumStudentCol);
// column AssessmentSession_Remark
DataColumn AssessmentSession_RemarkCol = new DataColumn("AssessmentSession_Remark", typeof(System.String));
AssessmentSession_RemarkCol.ReadOnly = true;
AssessmentSession_RemarkCol.AllowDBNull = false;
Columns.Add(AssessmentSession_RemarkCol);
// column AssessmentSession_CreatedBy
DataColumn AssessmentSession_CreatedByCol = new DataColumn("AssessmentSession_CreatedBy", typeof(System.String));
AssessmentSession_CreatedByCol.ReadOnly = true;
AssessmentSession_CreatedByCol.AllowDBNull = false;
Columns.Add(AssessmentSession_CreatedByCol);
// column AssessmentSession_CreatedDate
DataColumn AssessmentSession_CreatedDateCol = new DataColumn("AssessmentSession_CreatedDate", typeof(System.DateTime));
AssessmentSession_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_CreatedDateCol.ReadOnly = true;
AssessmentSession_CreatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentSession_CreatedDateCol);
// column AssessmentSession_UpdatedBy
DataColumn AssessmentSession_UpdatedByCol = new DataColumn("AssessmentSession_UpdatedBy", typeof(System.String));
AssessmentSession_UpdatedByCol.ReadOnly = true;
AssessmentSession_UpdatedByCol.AllowDBNull = false;
Columns.Add(AssessmentSession_UpdatedByCol);
// column AssessmentSession_UpdatedDate
DataColumn AssessmentSession_UpdatedDateCol = new DataColumn("AssessmentSession_UpdatedDate", typeof(System.DateTime));
AssessmentSession_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentSession_UpdatedDateCol.ReadOnly = true;
AssessmentSession_UpdatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentSession_UpdatedDateCol);
// column AssessmentSession_IsDeleted
DataColumn AssessmentSession_IsDeletedCol = new DataColumn("AssessmentSession_IsDeleted", typeof(System.Boolean));
AssessmentSession_IsDeletedCol.ReadOnly = true;
AssessmentSession_IsDeletedCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsDeletedCol);
// column AssessmentSession_IsInterview
DataColumn AssessmentSession_IsInterviewCol = new DataColumn("AssessmentSession_IsInterview", typeof(System.Boolean));
AssessmentSession_IsInterviewCol.ReadOnly = true;
AssessmentSession_IsInterviewCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsInterviewCol);
// column AssessmentSession_IsSent
DataColumn AssessmentSession_IsSentCol = new DataColumn("AssessmentSession_IsSent", typeof(System.Boolean));
AssessmentSession_IsSentCol.ReadOnly = true;
AssessmentSession_IsSentCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IsSentCol);
// column AssessmentSession_AssignedStudent
DataColumn AssessmentSession_AssignedStudentCol = new DataColumn("AssessmentSession_AssignedStudent", typeof(System.Int32));
AssessmentSession_AssignedStudentCol.ReadOnly = true;
AssessmentSession_AssignedStudentCol.AllowDBNull = true;
Columns.Add(AssessmentSession_AssignedStudentCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new AssessmentSessionDetailRow(builder);
}
public AssessmentSessionDetailRow GetAssessmentSessionDetailRow(int index) {
return (AssessmentSessionDetailRow)Rows[index];
}
}
public partial class AssessmentSessionDetailRow : DataRow {
internal AssessmentSessionDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid AssessmentSession_ID {
get {
return (System.Guid)this["AssessmentSession_ID"];
}
}
public System.String AssessmentSession_Location {
get {
return (System.String)this["AssessmentSession_Location"];
}
}
public System.DateTime AssessmentSession_DateTime {
get {
return (System.DateTime)this["AssessmentSession_DateTime"];
}
}
public System.Int32 AssessmentSession_MaximumStudent {
get {
return (System.Int32)this["AssessmentSession_MaximumStudent"];
}
}
public System.String AssessmentSession_Remark {
get {
return (System.String)this["AssessmentSession_Remark"];
}
}
public System.String AssessmentSession_CreatedBy {
get {
return (System.String)this["AssessmentSession_CreatedBy"];
}
}
public System.DateTime AssessmentSession_CreatedDate {
get {
return (System.DateTime)this["AssessmentSession_CreatedDate"];
}
}
public System.String AssessmentSession_UpdatedBy {
get {
return (System.String)this["AssessmentSession_UpdatedBy"];
}
}
public System.DateTime AssessmentSession_UpdatedDate {
get {
return (System.DateTime)this["AssessmentSession_UpdatedDate"];
}
}
public System.Boolean AssessmentSession_IsDeleted {
get {
return (System.Boolean)this["AssessmentSession_IsDeleted"];
}
}
public System.Boolean AssessmentSession_IsInterview {
get {
return (System.Boolean)this["AssessmentSession_IsInterview"];
}
}
public System.Boolean AssessmentSession_IsSent {
get {
return (System.Boolean)this["AssessmentSession_IsSent"];
}
}
public System.Int32? AssessmentSession_AssignedStudent {
get {
if( IsNull("AssessmentSession_AssignedStudent") ) return null;
else return (System.Int32)this["AssessmentSession_AssignedStudent"];
}
}
}
public partial class AssessmentSessionDetailMinimalizedEntity {
public AssessmentSessionDetailMinimalizedEntity() {}
public AssessmentSessionDetailMinimalizedEntity(AssessmentSessionDetailRow dr) {
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
this.AssessmentSession_AssignedStudent = dr.AssessmentSession_AssignedStudent;
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
public System.Int32? AssessmentSession_AssignedStudent;
}
public partial class AssessmentSessionDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public AssessmentSessionDetailAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("AssessmentSession_AssignedStudent", "AssessmentSession_AssignedStudent");
adapter.TableMappings.Add(tmap);
}
}
public AssessmentSessionDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [AssessmentSessionDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

AssessmentSessionDetailTable tbl = new AssessmentSessionDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetAssessmentSessionDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [AssessmentSessionDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
