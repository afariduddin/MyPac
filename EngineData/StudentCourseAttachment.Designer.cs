using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentCourseAttachmentTable : DataTable {
// column indexes
public const int StudentCourseAttachment_IDColumnIndex = 0;
public const int StudentCourseAttachment_NameColumnIndex = 1;
public const int StudentCourseAttachment_OriginalFileNameColumnIndex = 2;
public const int StudentCourseAttachment_PhysicalFileNameColumnIndex = 3;
public const int StudentCourseAttachment_RemarkColumnIndex = 4;
public const int StudentCourseAttachment_CreatedDateColumnIndex = 5;
public const int StudentCourseAttachment_UpdatedDateColumnIndex = 6;
public const int StudentCourseAttachment_CreatedByColumnIndex = 7;
public const int StudentCourseAttachment_UpdatedByColumnIndex = 8;
public const int StudentCourseAttachment_IsDeletedColumnIndex = 9;
public const int StudentCourse_IDColumnIndex = 10;
public StudentCourseAttachmentTable() {
TableName = "[StudentCourseAttachment]";
// column StudentCourseAttachment_ID
DataColumn StudentCourseAttachment_IDCol = new DataColumn("StudentCourseAttachment_ID", typeof(System.Guid));
StudentCourseAttachment_IDCol.ReadOnly = false;
StudentCourseAttachment_IDCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_IDCol);
// column StudentCourseAttachment_Name
DataColumn StudentCourseAttachment_NameCol = new DataColumn("StudentCourseAttachment_Name", typeof(System.String));
StudentCourseAttachment_NameCol.ReadOnly = false;
StudentCourseAttachment_NameCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_NameCol);
// column StudentCourseAttachment_OriginalFileName
DataColumn StudentCourseAttachment_OriginalFileNameCol = new DataColumn("StudentCourseAttachment_OriginalFileName", typeof(System.String));
StudentCourseAttachment_OriginalFileNameCol.ReadOnly = false;
StudentCourseAttachment_OriginalFileNameCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_OriginalFileNameCol);
// column StudentCourseAttachment_PhysicalFileName
DataColumn StudentCourseAttachment_PhysicalFileNameCol = new DataColumn("StudentCourseAttachment_PhysicalFileName", typeof(System.String));
StudentCourseAttachment_PhysicalFileNameCol.ReadOnly = false;
StudentCourseAttachment_PhysicalFileNameCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_PhysicalFileNameCol);
// column StudentCourseAttachment_Remark
DataColumn StudentCourseAttachment_RemarkCol = new DataColumn("StudentCourseAttachment_Remark", typeof(System.String));
StudentCourseAttachment_RemarkCol.ReadOnly = false;
StudentCourseAttachment_RemarkCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_RemarkCol);
// column StudentCourseAttachment_CreatedDate
DataColumn StudentCourseAttachment_CreatedDateCol = new DataColumn("StudentCourseAttachment_CreatedDate", typeof(System.DateTime));
StudentCourseAttachment_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourseAttachment_CreatedDateCol.ReadOnly = false;
StudentCourseAttachment_CreatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_CreatedDateCol);
// column StudentCourseAttachment_UpdatedDate
DataColumn StudentCourseAttachment_UpdatedDateCol = new DataColumn("StudentCourseAttachment_UpdatedDate", typeof(System.DateTime));
StudentCourseAttachment_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourseAttachment_UpdatedDateCol.ReadOnly = false;
StudentCourseAttachment_UpdatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_UpdatedDateCol);
// column StudentCourseAttachment_CreatedBy
DataColumn StudentCourseAttachment_CreatedByCol = new DataColumn("StudentCourseAttachment_CreatedBy", typeof(System.String));
StudentCourseAttachment_CreatedByCol.ReadOnly = false;
StudentCourseAttachment_CreatedByCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_CreatedByCol);
// column StudentCourseAttachment_UpdatedBy
DataColumn StudentCourseAttachment_UpdatedByCol = new DataColumn("StudentCourseAttachment_UpdatedBy", typeof(System.String));
StudentCourseAttachment_UpdatedByCol.ReadOnly = false;
StudentCourseAttachment_UpdatedByCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_UpdatedByCol);
// column StudentCourseAttachment_IsDeleted
DataColumn StudentCourseAttachment_IsDeletedCol = new DataColumn("StudentCourseAttachment_IsDeleted", typeof(System.Boolean));
StudentCourseAttachment_IsDeletedCol.ReadOnly = false;
StudentCourseAttachment_IsDeletedCol.AllowDBNull = false;
Columns.Add(StudentCourseAttachment_IsDeletedCol);
// column StudentCourse_ID
DataColumn StudentCourse_IDCol = new DataColumn("StudentCourse_ID", typeof(System.Guid));
StudentCourse_IDCol.ReadOnly = false;
StudentCourse_IDCol.AllowDBNull = false;
Columns.Add(StudentCourse_IDCol);
}
public StudentCourseAttachmentRow NewStudentCourseAttachmentRow() {
StudentCourseAttachmentRow row = (StudentCourseAttachmentRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(StudentCourseAttachmentRow row) {
row.StudentCourseAttachment_ID = Guid.Empty;
row.StudentCourseAttachment_Name = "";
row.StudentCourseAttachment_OriginalFileName = "";
row.StudentCourseAttachment_PhysicalFileName = "";
row.StudentCourseAttachment_Remark = "";
row.StudentCourseAttachment_CreatedDate = DateTime.Now;
row.StudentCourseAttachment_UpdatedDate = DateTime.Now;
row.StudentCourseAttachment_CreatedBy = "";
row.StudentCourseAttachment_UpdatedBy = "";
row.StudentCourseAttachment_IsDeleted = false;
row.StudentCourse_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentCourseAttachmentRow(builder);
}
public StudentCourseAttachmentRow GetStudentCourseAttachmentRow(int index) {
return (StudentCourseAttachmentRow)Rows[index];
}
}
public partial class StudentCourseAttachmentRow : DataRow {
internal StudentCourseAttachmentRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid StudentCourseAttachment_ID {
get {
return (System.Guid)this["StudentCourseAttachment_ID"];
}
set {
this["StudentCourseAttachment_ID"] = value;
}
}
public System.String StudentCourseAttachment_Name {
get {
return (System.String)this["StudentCourseAttachment_Name"];
}
set {
if( value.Length > 250 ) this["StudentCourseAttachment_Name"] = value.Substring(0, 250);
else this["StudentCourseAttachment_Name"] = value;
}
}
public System.String StudentCourseAttachment_OriginalFileName {
get {
return (System.String)this["StudentCourseAttachment_OriginalFileName"];
}
set {
if( value.Length > 250 ) this["StudentCourseAttachment_OriginalFileName"] = value.Substring(0, 250);
else this["StudentCourseAttachment_OriginalFileName"] = value;
}
}
public System.String StudentCourseAttachment_PhysicalFileName {
get {
return (System.String)this["StudentCourseAttachment_PhysicalFileName"];
}
set {
if( value.Length > 250 ) this["StudentCourseAttachment_PhysicalFileName"] = value.Substring(0, 250);
else this["StudentCourseAttachment_PhysicalFileName"] = value;
}
}
public System.String StudentCourseAttachment_Remark {
get {
return (System.String)this["StudentCourseAttachment_Remark"];
}
set {
if( value.Length > 1000 ) this["StudentCourseAttachment_Remark"] = value.Substring(0, 1000);
else this["StudentCourseAttachment_Remark"] = value;
}
}
public System.DateTime StudentCourseAttachment_CreatedDate {
get {
return (System.DateTime)this["StudentCourseAttachment_CreatedDate"];
}
set {
this["StudentCourseAttachment_CreatedDate"] = value;
}
}
public System.DateTime StudentCourseAttachment_UpdatedDate {
get {
return (System.DateTime)this["StudentCourseAttachment_UpdatedDate"];
}
set {
this["StudentCourseAttachment_UpdatedDate"] = value;
}
}
public System.String StudentCourseAttachment_CreatedBy {
get {
return (System.String)this["StudentCourseAttachment_CreatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourseAttachment_CreatedBy"] = value.Substring(0, 50);
else this["StudentCourseAttachment_CreatedBy"] = value;
}
}
public System.String StudentCourseAttachment_UpdatedBy {
get {
return (System.String)this["StudentCourseAttachment_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourseAttachment_UpdatedBy"] = value.Substring(0, 50);
else this["StudentCourseAttachment_UpdatedBy"] = value;
}
}
public System.Boolean StudentCourseAttachment_IsDeleted {
get {
return (System.Boolean)this["StudentCourseAttachment_IsDeleted"];
}
set {
this["StudentCourseAttachment_IsDeleted"] = value;
}
}
public System.Guid StudentCourse_ID {
get {
return (System.Guid)this["StudentCourse_ID"];
}
set {
this["StudentCourse_ID"] = value;
}
}
}
public partial class StudentCourseAttachmentMinimalizedEntity {
public StudentCourseAttachmentMinimalizedEntity() {}
public StudentCourseAttachmentMinimalizedEntity(StudentCourseAttachmentRow dr) {
this.StudentCourseAttachment_ID = dr.StudentCourseAttachment_ID;
this.StudentCourseAttachment_Name = dr.StudentCourseAttachment_Name;
this.StudentCourseAttachment_OriginalFileName = dr.StudentCourseAttachment_OriginalFileName;
this.StudentCourseAttachment_PhysicalFileName = dr.StudentCourseAttachment_PhysicalFileName;
this.StudentCourseAttachment_Remark = dr.StudentCourseAttachment_Remark;
this.StudentCourseAttachment_CreatedDate = dr.StudentCourseAttachment_CreatedDate;
this.StudentCourseAttachment_UpdatedDate = dr.StudentCourseAttachment_UpdatedDate;
this.StudentCourseAttachment_CreatedBy = dr.StudentCourseAttachment_CreatedBy;
this.StudentCourseAttachment_UpdatedBy = dr.StudentCourseAttachment_UpdatedBy;
this.StudentCourseAttachment_IsDeleted = dr.StudentCourseAttachment_IsDeleted;
this.StudentCourse_ID = dr.StudentCourse_ID;
}
public void CopyTo(StudentCourseAttachmentRow dr) {
dr.StudentCourseAttachment_ID = this.StudentCourseAttachment_ID;
dr.StudentCourseAttachment_Name = this.StudentCourseAttachment_Name;
dr.StudentCourseAttachment_OriginalFileName = this.StudentCourseAttachment_OriginalFileName;
dr.StudentCourseAttachment_PhysicalFileName = this.StudentCourseAttachment_PhysicalFileName;
dr.StudentCourseAttachment_Remark = this.StudentCourseAttachment_Remark;
dr.StudentCourseAttachment_CreatedDate = this.StudentCourseAttachment_CreatedDate;
dr.StudentCourseAttachment_UpdatedDate = this.StudentCourseAttachment_UpdatedDate;
dr.StudentCourseAttachment_CreatedBy = this.StudentCourseAttachment_CreatedBy;
dr.StudentCourseAttachment_UpdatedBy = this.StudentCourseAttachment_UpdatedBy;
dr.StudentCourseAttachment_IsDeleted = this.StudentCourseAttachment_IsDeleted;
dr.StudentCourse_ID = this.StudentCourse_ID;
}
public System.Guid StudentCourseAttachment_ID;
public System.String StudentCourseAttachment_Name;
public System.String StudentCourseAttachment_OriginalFileName;
public System.String StudentCourseAttachment_PhysicalFileName;
public System.String StudentCourseAttachment_Remark;
public System.DateTime StudentCourseAttachment_CreatedDate;
public System.DateTime StudentCourseAttachment_UpdatedDate;
public System.String StudentCourseAttachment_CreatedBy;
public System.String StudentCourseAttachment_UpdatedBy;
public System.Boolean StudentCourseAttachment_IsDeleted;
public System.Guid StudentCourse_ID;
}
public partial class StudentCourseAttachmentAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentCourseAttachmentAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("StudentCourseAttachment_ID", "StudentCourseAttachment_ID");
tmap.ColumnMappings.Add("StudentCourseAttachment_Name", "StudentCourseAttachment_Name");
tmap.ColumnMappings.Add("StudentCourseAttachment_OriginalFileName", "StudentCourseAttachment_OriginalFileName");
tmap.ColumnMappings.Add("StudentCourseAttachment_PhysicalFileName", "StudentCourseAttachment_PhysicalFileName");
tmap.ColumnMappings.Add("StudentCourseAttachment_Remark", "StudentCourseAttachment_Remark");
tmap.ColumnMappings.Add("StudentCourseAttachment_CreatedDate", "StudentCourseAttachment_CreatedDate");
tmap.ColumnMappings.Add("StudentCourseAttachment_UpdatedDate", "StudentCourseAttachment_UpdatedDate");
tmap.ColumnMappings.Add("StudentCourseAttachment_CreatedBy", "StudentCourseAttachment_CreatedBy");
tmap.ColumnMappings.Add("StudentCourseAttachment_UpdatedBy", "StudentCourseAttachment_UpdatedBy");
tmap.ColumnMappings.Add("StudentCourseAttachment_IsDeleted", "StudentCourseAttachment_IsDeleted");
tmap.ColumnMappings.Add("StudentCourse_ID", "StudentCourse_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [StudentCourseAttachment] ([StudentCourseAttachment_ID], [StudentCourseAttachment_Name], [StudentCourseAttachment_OriginalFileName], [StudentCourseAttachment_PhysicalFileName], [StudentCourseAttachment_Remark], [StudentCourseAttachment_CreatedDate], [StudentCourseAttachment_UpdatedDate], [StudentCourseAttachment_CreatedBy], [StudentCourseAttachment_UpdatedBy], [StudentCourseAttachment_IsDeleted], [StudentCourse_ID]) VALUES (@StudentCourseAttachment_ID, @StudentCourseAttachment_Name, @StudentCourseAttachment_OriginalFileName, @StudentCourseAttachment_PhysicalFileName, @StudentCourseAttachment_Remark, @StudentCourseAttachment_CreatedDate, @StudentCourseAttachment_UpdatedDate, @StudentCourseAttachment_CreatedBy, @StudentCourseAttachment_UpdatedBy, @StudentCourseAttachment_IsDeleted, @StudentCourse_ID)");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourseAttachment_ID");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_Name", SqlDbType.NVarChar, 0, "StudentCourseAttachment_Name");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_OriginalFileName", SqlDbType.NVarChar, 0, "StudentCourseAttachment_OriginalFileName");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_PhysicalFileName", SqlDbType.NVarChar, 0, "StudentCourseAttachment_PhysicalFileName");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_Remark", SqlDbType.NVarChar, 0, "StudentCourseAttachment_Remark");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_CreatedDate", SqlDbType.DateTime, 0, "StudentCourseAttachment_CreatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourseAttachment_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourseAttachment_CreatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourseAttachment_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourseAttachment_IsDeleted", SqlDbType.Bit, 0, "StudentCourseAttachment_IsDeleted");
adapter.InsertCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [StudentCourseAttachment] SET [StudentCourseAttachment_ID] = @StudentCourseAttachment_ID, [StudentCourseAttachment_Name] = @StudentCourseAttachment_Name, [StudentCourseAttachment_OriginalFileName] = @StudentCourseAttachment_OriginalFileName, [StudentCourseAttachment_PhysicalFileName] = @StudentCourseAttachment_PhysicalFileName, [StudentCourseAttachment_Remark] = @StudentCourseAttachment_Remark, [StudentCourseAttachment_CreatedDate] = @StudentCourseAttachment_CreatedDate, [StudentCourseAttachment_UpdatedDate] = @StudentCourseAttachment_UpdatedDate, [StudentCourseAttachment_CreatedBy] = @StudentCourseAttachment_CreatedBy, [StudentCourseAttachment_UpdatedBy] = @StudentCourseAttachment_UpdatedBy, [StudentCourseAttachment_IsDeleted] = @StudentCourseAttachment_IsDeleted, [StudentCourse_ID] = @StudentCourse_ID WHERE [StudentCourseAttachment_ID] = @o_StudentCourseAttachment_ID");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourseAttachment_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_StudentCourseAttachment_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourseAttachment_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_Name", SqlDbType.NVarChar, 0, "StudentCourseAttachment_Name");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_OriginalFileName", SqlDbType.NVarChar, 0, "StudentCourseAttachment_OriginalFileName");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_PhysicalFileName", SqlDbType.NVarChar, 0, "StudentCourseAttachment_PhysicalFileName");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_Remark", SqlDbType.NVarChar, 0, "StudentCourseAttachment_Remark");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_CreatedDate", SqlDbType.DateTime, 0, "StudentCourseAttachment_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourseAttachment_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourseAttachment_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourseAttachment_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourseAttachment_IsDeleted", SqlDbType.Bit, 0, "StudentCourseAttachment_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [StudentCourseAttachment] WHERE [StudentCourseAttachment_ID] = @o_StudentCourseAttachment_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_StudentCourseAttachment_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourseAttachment_ID", DataRowVersion.Original, null));
}
public void Update(StudentCourseAttachmentTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(StudentCourseAttachmentRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public StudentCourseAttachmentRow GetByStudentCourseAttachment_ID(System.Guid StudentCourseAttachment_ID ) {
string sql = "SELECT * FROM [StudentCourseAttachment] WHERE [StudentCourseAttachment_ID] = @StudentCourseAttachment_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseAttachment_ID", StudentCourseAttachment_ID);

StudentCourseAttachmentTable tbl = new StudentCourseAttachmentTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentCourseAttachmentRow(0);
}
public int CountByStudentCourseAttachment_ID(System.Guid StudentCourseAttachment_ID ) {
string sql = "SELECT COUNT(*) FROM [StudentCourseAttachment] WHERE [StudentCourseAttachment_ID] = @StudentCourseAttachment_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseAttachment_ID", StudentCourseAttachment_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByStudentCourseAttachment_ID(System.Guid StudentCourseAttachment_ID, IActivityLog log ) {
string sql = "DELETE FROM [StudentCourseAttachment] WHERE [StudentCourseAttachment_ID] = @StudentCourseAttachment_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseAttachment_ID", StudentCourseAttachment_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public StudentCourseAttachmentTable GetByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [StudentCourseAttachment] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
StudentCourseAttachmentTable tbl = new StudentCourseAttachmentTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [StudentCourseAttachment] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByStudentCourse_ID(System.Guid StudentCourse_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [StudentCourseAttachment] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
