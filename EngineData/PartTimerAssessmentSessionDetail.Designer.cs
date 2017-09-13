using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PartTimerAssessmentSessionDetailTable : DataTable {
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
public const int PartTimerAssessmentSession_AssignedStudentColumnIndex = 12;
public PartTimerAssessmentSessionDetailTable() {
TableName = "[PartTimerAssessmentSessionDetail]";
// column PartTimerAssessmentSession_ID
DataColumn PartTimerAssessmentSession_IDCol = new DataColumn("PartTimerAssessmentSession_ID", typeof(System.Guid));
PartTimerAssessmentSession_IDCol.ReadOnly = true;
PartTimerAssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IDCol);
// column PartTimerAssessmentSession_Location
DataColumn PartTimerAssessmentSession_LocationCol = new DataColumn("PartTimerAssessmentSession_Location", typeof(System.String));
PartTimerAssessmentSession_LocationCol.ReadOnly = true;
PartTimerAssessmentSession_LocationCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_LocationCol);
// column PartTimerAssessmentSession_DateTime
DataColumn PartTimerAssessmentSession_DateTimeCol = new DataColumn("PartTimerAssessmentSession_DateTime", typeof(System.DateTime));
PartTimerAssessmentSession_DateTimeCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_DateTimeCol.ReadOnly = true;
PartTimerAssessmentSession_DateTimeCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_DateTimeCol);
// column PartTimerAssessmentSession_MaximumStudent
DataColumn PartTimerAssessmentSession_MaximumStudentCol = new DataColumn("PartTimerAssessmentSession_MaximumStudent", typeof(System.Int32));
PartTimerAssessmentSession_MaximumStudentCol.ReadOnly = true;
PartTimerAssessmentSession_MaximumStudentCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_MaximumStudentCol);
// column PartTimerAssessmentSession_Remark
DataColumn PartTimerAssessmentSession_RemarkCol = new DataColumn("PartTimerAssessmentSession_Remark", typeof(System.String));
PartTimerAssessmentSession_RemarkCol.ReadOnly = true;
PartTimerAssessmentSession_RemarkCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_RemarkCol);
// column PartTimerAssessmentSession_CreatedBy
DataColumn PartTimerAssessmentSession_CreatedByCol = new DataColumn("PartTimerAssessmentSession_CreatedBy", typeof(System.String));
PartTimerAssessmentSession_CreatedByCol.ReadOnly = true;
PartTimerAssessmentSession_CreatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_CreatedByCol);
// column PartTimerAssessmentSession_CreatedDate
DataColumn PartTimerAssessmentSession_CreatedDateCol = new DataColumn("PartTimerAssessmentSession_CreatedDate", typeof(System.DateTime));
PartTimerAssessmentSession_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_CreatedDateCol.ReadOnly = true;
PartTimerAssessmentSession_CreatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_CreatedDateCol);
// column PartTimerAssessmentSession_UpdatedBy
DataColumn PartTimerAssessmentSession_UpdatedByCol = new DataColumn("PartTimerAssessmentSession_UpdatedBy", typeof(System.String));
PartTimerAssessmentSession_UpdatedByCol.ReadOnly = true;
PartTimerAssessmentSession_UpdatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_UpdatedByCol);
// column PartTimerAssessmentSession_UpdatedDate
DataColumn PartTimerAssessmentSession_UpdatedDateCol = new DataColumn("PartTimerAssessmentSession_UpdatedDate", typeof(System.DateTime));
PartTimerAssessmentSession_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentSession_UpdatedDateCol.ReadOnly = true;
PartTimerAssessmentSession_UpdatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_UpdatedDateCol);
// column PartTimerAssessmentSession_IsDeleted
DataColumn PartTimerAssessmentSession_IsDeletedCol = new DataColumn("PartTimerAssessmentSession_IsDeleted", typeof(System.Boolean));
PartTimerAssessmentSession_IsDeletedCol.ReadOnly = true;
PartTimerAssessmentSession_IsDeletedCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IsDeletedCol);
// column PartTimerAssessmentSession_SessionType
DataColumn PartTimerAssessmentSession_SessionTypeCol = new DataColumn("PartTimerAssessmentSession_SessionType", typeof(System.Int16));
PartTimerAssessmentSession_SessionTypeCol.ReadOnly = true;
PartTimerAssessmentSession_SessionTypeCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_SessionTypeCol);
// column PartTimerAssessmentSession_IsSent
DataColumn PartTimerAssessmentSession_IsSentCol = new DataColumn("PartTimerAssessmentSession_IsSent", typeof(System.Boolean));
PartTimerAssessmentSession_IsSentCol.ReadOnly = true;
PartTimerAssessmentSession_IsSentCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IsSentCol);
// column PartTimerAssessmentSession_AssignedStudent
DataColumn PartTimerAssessmentSession_AssignedStudentCol = new DataColumn("PartTimerAssessmentSession_AssignedStudent", typeof(System.Int32));
PartTimerAssessmentSession_AssignedStudentCol.ReadOnly = true;
PartTimerAssessmentSession_AssignedStudentCol.AllowDBNull = true;
Columns.Add(PartTimerAssessmentSession_AssignedStudentCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PartTimerAssessmentSessionDetailRow(builder);
}
public PartTimerAssessmentSessionDetailRow GetPartTimerAssessmentSessionDetailRow(int index) {
return (PartTimerAssessmentSessionDetailRow)Rows[index];
}
}
public partial class PartTimerAssessmentSessionDetailRow : DataRow {
internal PartTimerAssessmentSessionDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid PartTimerAssessmentSession_ID {
get {
return (System.Guid)this["PartTimerAssessmentSession_ID"];
}
}
public System.String PartTimerAssessmentSession_Location {
get {
return (System.String)this["PartTimerAssessmentSession_Location"];
}
}
public System.DateTime PartTimerAssessmentSession_DateTime {
get {
return (System.DateTime)this["PartTimerAssessmentSession_DateTime"];
}
}
public System.Int32 PartTimerAssessmentSession_MaximumStudent {
get {
return (System.Int32)this["PartTimerAssessmentSession_MaximumStudent"];
}
}
public System.String PartTimerAssessmentSession_Remark {
get {
return (System.String)this["PartTimerAssessmentSession_Remark"];
}
}
public System.String PartTimerAssessmentSession_CreatedBy {
get {
return (System.String)this["PartTimerAssessmentSession_CreatedBy"];
}
}
public System.DateTime PartTimerAssessmentSession_CreatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentSession_CreatedDate"];
}
}
public System.String PartTimerAssessmentSession_UpdatedBy {
get {
return (System.String)this["PartTimerAssessmentSession_UpdatedBy"];
}
}
public System.DateTime PartTimerAssessmentSession_UpdatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentSession_UpdatedDate"];
}
}
public System.Boolean PartTimerAssessmentSession_IsDeleted {
get {
return (System.Boolean)this["PartTimerAssessmentSession_IsDeleted"];
}
}
public System.Int16 PartTimerAssessmentSession_SessionType {
get {
return (System.Int16)this["PartTimerAssessmentSession_SessionType"];
}
}
public System.Boolean PartTimerAssessmentSession_IsSent {
get {
return (System.Boolean)this["PartTimerAssessmentSession_IsSent"];
}
}
public System.Int32? PartTimerAssessmentSession_AssignedStudent {
get {
if( IsNull("PartTimerAssessmentSession_AssignedStudent") ) return null;
else return (System.Int32)this["PartTimerAssessmentSession_AssignedStudent"];
}
}
}
public partial class PartTimerAssessmentSessionDetailMinimalizedEntity {
public PartTimerAssessmentSessionDetailMinimalizedEntity() {}
public PartTimerAssessmentSessionDetailMinimalizedEntity(PartTimerAssessmentSessionDetailRow dr) {
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
this.PartTimerAssessmentSession_AssignedStudent = dr.PartTimerAssessmentSession_AssignedStudent;
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
public System.Int32? PartTimerAssessmentSession_AssignedStudent;
}
public partial class PartTimerAssessmentSessionDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PartTimerAssessmentSessionDetailAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("PartTimerAssessmentSession_AssignedStudent", "PartTimerAssessmentSession_AssignedStudent");
adapter.TableMappings.Add(tmap);
}
}
public PartTimerAssessmentSessionDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [PartTimerAssessmentSessionDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

PartTimerAssessmentSessionDetailTable tbl = new PartTimerAssessmentSessionDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPartTimerAssessmentSessionDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentSessionDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
