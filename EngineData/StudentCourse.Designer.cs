using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentCourseTable : DataTable {
// column indexes
public const int StudentCourse_IDColumnIndex = 0;
public const int Student_IDColumnIndex = 1;
public const int CourseSubject_IDColumnIndex = 2;
public const int StudentCourse_StatusColumnIndex = 3;
public const int StudentCourse_CreatedDateColumnIndex = 4;
public const int StudentCourse_UpdatedDateColumnIndex = 5;
public const int StudentCourse_CreatedByColumnIndex = 6;
public const int StudentCourse_UpdatedByColumnIndex = 7;
public const int StudentCourse_RemarkColumnIndex = 8;
public const int StudentCourse_DefermentReasonColumnIndex = 9;
public StudentCourseTable() {
TableName = "[StudentCourse]";
// column StudentCourse_ID
DataColumn StudentCourse_IDCol = new DataColumn("StudentCourse_ID", typeof(System.Guid));
StudentCourse_IDCol.ReadOnly = false;
StudentCourse_IDCol.AllowDBNull = false;
Columns.Add(StudentCourse_IDCol);
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = false;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column CourseSubject_ID
DataColumn CourseSubject_IDCol = new DataColumn("CourseSubject_ID", typeof(System.Guid));
CourseSubject_IDCol.ReadOnly = false;
CourseSubject_IDCol.AllowDBNull = false;
Columns.Add(CourseSubject_IDCol);
// column StudentCourse_Status
DataColumn StudentCourse_StatusCol = new DataColumn("StudentCourse_Status", typeof(System.Int16));
StudentCourse_StatusCol.ReadOnly = false;
StudentCourse_StatusCol.AllowDBNull = false;
Columns.Add(StudentCourse_StatusCol);
// column StudentCourse_CreatedDate
DataColumn StudentCourse_CreatedDateCol = new DataColumn("StudentCourse_CreatedDate", typeof(System.DateTime));
StudentCourse_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourse_CreatedDateCol.ReadOnly = false;
StudentCourse_CreatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourse_CreatedDateCol);
// column StudentCourse_UpdatedDate
DataColumn StudentCourse_UpdatedDateCol = new DataColumn("StudentCourse_UpdatedDate", typeof(System.DateTime));
StudentCourse_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourse_UpdatedDateCol.ReadOnly = false;
StudentCourse_UpdatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourse_UpdatedDateCol);
// column StudentCourse_CreatedBy
DataColumn StudentCourse_CreatedByCol = new DataColumn("StudentCourse_CreatedBy", typeof(System.String));
StudentCourse_CreatedByCol.ReadOnly = false;
StudentCourse_CreatedByCol.AllowDBNull = false;
Columns.Add(StudentCourse_CreatedByCol);
// column StudentCourse_UpdatedBy
DataColumn StudentCourse_UpdatedByCol = new DataColumn("StudentCourse_UpdatedBy", typeof(System.String));
StudentCourse_UpdatedByCol.ReadOnly = false;
StudentCourse_UpdatedByCol.AllowDBNull = false;
Columns.Add(StudentCourse_UpdatedByCol);
// column StudentCourse_Remark
DataColumn StudentCourse_RemarkCol = new DataColumn("StudentCourse_Remark", typeof(System.String));
StudentCourse_RemarkCol.ReadOnly = false;
StudentCourse_RemarkCol.AllowDBNull = false;
Columns.Add(StudentCourse_RemarkCol);
// column StudentCourse_DefermentReason
DataColumn StudentCourse_DefermentReasonCol = new DataColumn("StudentCourse_DefermentReason", typeof(System.String));
StudentCourse_DefermentReasonCol.ReadOnly = false;
StudentCourse_DefermentReasonCol.AllowDBNull = false;
Columns.Add(StudentCourse_DefermentReasonCol);
}
public StudentCourseRow NewStudentCourseRow() {
StudentCourseRow row = (StudentCourseRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(StudentCourseRow row) {
row.StudentCourse_ID = Guid.Empty;
row.Student_ID = Guid.Empty;
row.CourseSubject_ID = Guid.Empty;
row.StudentCourse_Status = 0;
row.StudentCourse_CreatedDate = DateTime.Now;
row.StudentCourse_UpdatedDate = DateTime.Now;
row.StudentCourse_CreatedBy = "";
row.StudentCourse_UpdatedBy = "";
row.StudentCourse_Remark = "";
row.StudentCourse_DefermentReason = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentCourseRow(builder);
}
public StudentCourseRow GetStudentCourseRow(int index) {
return (StudentCourseRow)Rows[index];
}
}
public partial class StudentCourseRow : DataRow {
internal StudentCourseRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid StudentCourse_ID {
get {
return (System.Guid)this["StudentCourse_ID"];
}
set {
this["StudentCourse_ID"] = value;
}
}
public System.Guid Student_ID {
get {
return (System.Guid)this["Student_ID"];
}
set {
this["Student_ID"] = value;
}
}
public System.Guid CourseSubject_ID {
get {
return (System.Guid)this["CourseSubject_ID"];
}
set {
this["CourseSubject_ID"] = value;
}
}
public System.Int16 StudentCourse_Status {
get {
return (System.Int16)this["StudentCourse_Status"];
}
set {
this["StudentCourse_Status"] = value;
}
}
public System.DateTime StudentCourse_CreatedDate {
get {
return (System.DateTime)this["StudentCourse_CreatedDate"];
}
set {
this["StudentCourse_CreatedDate"] = value;
}
}
public System.DateTime StudentCourse_UpdatedDate {
get {
return (System.DateTime)this["StudentCourse_UpdatedDate"];
}
set {
this["StudentCourse_UpdatedDate"] = value;
}
}
public System.String StudentCourse_CreatedBy {
get {
return (System.String)this["StudentCourse_CreatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourse_CreatedBy"] = value.Substring(0, 50);
else this["StudentCourse_CreatedBy"] = value;
}
}
public System.String StudentCourse_UpdatedBy {
get {
return (System.String)this["StudentCourse_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourse_UpdatedBy"] = value.Substring(0, 50);
else this["StudentCourse_UpdatedBy"] = value;
}
}
public System.String StudentCourse_Remark {
get {
return (System.String)this["StudentCourse_Remark"];
}
set {
if( value.Length > 250 ) this["StudentCourse_Remark"] = value.Substring(0, 250);
else this["StudentCourse_Remark"] = value;
}
}
public System.String StudentCourse_DefermentReason {
get {
return (System.String)this["StudentCourse_DefermentReason"];
}
set {
if( value.Length > 1000 ) this["StudentCourse_DefermentReason"] = value.Substring(0, 1000);
else this["StudentCourse_DefermentReason"] = value;
}
}
}
public partial class StudentCourseMinimalizedEntity {
public StudentCourseMinimalizedEntity() {}
public StudentCourseMinimalizedEntity(StudentCourseRow dr) {
this.StudentCourse_ID = dr.StudentCourse_ID;
this.Student_ID = dr.Student_ID;
this.CourseSubject_ID = dr.CourseSubject_ID;
this.StudentCourse_Status = dr.StudentCourse_Status;
this.StudentCourse_CreatedDate = dr.StudentCourse_CreatedDate;
this.StudentCourse_UpdatedDate = dr.StudentCourse_UpdatedDate;
this.StudentCourse_CreatedBy = dr.StudentCourse_CreatedBy;
this.StudentCourse_UpdatedBy = dr.StudentCourse_UpdatedBy;
this.StudentCourse_Remark = dr.StudentCourse_Remark;
this.StudentCourse_DefermentReason = dr.StudentCourse_DefermentReason;
}
public void CopyTo(StudentCourseRow dr) {
dr.StudentCourse_ID = this.StudentCourse_ID;
dr.Student_ID = this.Student_ID;
dr.CourseSubject_ID = this.CourseSubject_ID;
dr.StudentCourse_Status = this.StudentCourse_Status;
dr.StudentCourse_CreatedDate = this.StudentCourse_CreatedDate;
dr.StudentCourse_UpdatedDate = this.StudentCourse_UpdatedDate;
dr.StudentCourse_CreatedBy = this.StudentCourse_CreatedBy;
dr.StudentCourse_UpdatedBy = this.StudentCourse_UpdatedBy;
dr.StudentCourse_Remark = this.StudentCourse_Remark;
dr.StudentCourse_DefermentReason = this.StudentCourse_DefermentReason;
}
public System.Guid StudentCourse_ID;
public System.Guid Student_ID;
public System.Guid CourseSubject_ID;
public System.Int16 StudentCourse_Status;
public System.DateTime StudentCourse_CreatedDate;
public System.DateTime StudentCourse_UpdatedDate;
public System.String StudentCourse_CreatedBy;
public System.String StudentCourse_UpdatedBy;
public System.String StudentCourse_Remark;
public System.String StudentCourse_DefermentReason;
}
public partial class StudentCourseAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentCourseAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("StudentCourse_ID", "StudentCourse_ID");
tmap.ColumnMappings.Add("Student_ID", "Student_ID");
tmap.ColumnMappings.Add("CourseSubject_ID", "CourseSubject_ID");
tmap.ColumnMappings.Add("StudentCourse_Status", "StudentCourse_Status");
tmap.ColumnMappings.Add("StudentCourse_CreatedDate", "StudentCourse_CreatedDate");
tmap.ColumnMappings.Add("StudentCourse_UpdatedDate", "StudentCourse_UpdatedDate");
tmap.ColumnMappings.Add("StudentCourse_CreatedBy", "StudentCourse_CreatedBy");
tmap.ColumnMappings.Add("StudentCourse_UpdatedBy", "StudentCourse_UpdatedBy");
tmap.ColumnMappings.Add("StudentCourse_Remark", "StudentCourse_Remark");
tmap.ColumnMappings.Add("StudentCourse_DefermentReason", "StudentCourse_DefermentReason");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [StudentCourse] ([StudentCourse_ID], [Student_ID], [CourseSubject_ID], [StudentCourse_Status], [StudentCourse_CreatedDate], [StudentCourse_UpdatedDate], [StudentCourse_CreatedBy], [StudentCourse_UpdatedBy], [StudentCourse_Remark], [StudentCourse_DefermentReason]) VALUES (@StudentCourse_ID, @Student_ID, @CourseSubject_ID, @StudentCourse_Status, @StudentCourse_CreatedDate, @StudentCourse_UpdatedDate, @StudentCourse_CreatedBy, @StudentCourse_UpdatedBy, @StudentCourse_Remark, @StudentCourse_DefermentReason)");
adapter.InsertCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.InsertCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.InsertCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
adapter.InsertCommand.Parameters.Add("@StudentCourse_Status", SqlDbType.SmallInt, 0, "StudentCourse_Status");
adapter.InsertCommand.Parameters.Add("@StudentCourse_CreatedDate", SqlDbType.DateTime, 0, "StudentCourse_CreatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourse_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourse_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourse_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourse_CreatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourse_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourse_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourse_Remark", SqlDbType.NVarChar, 0, "StudentCourse_Remark");
adapter.InsertCommand.Parameters.Add("@StudentCourse_DefermentReason", SqlDbType.NVarChar, 0, "StudentCourse_DefermentReason");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [StudentCourse] SET [StudentCourse_ID] = @StudentCourse_ID, [Student_ID] = @Student_ID, [CourseSubject_ID] = @CourseSubject_ID, [StudentCourse_Status] = @StudentCourse_Status, [StudentCourse_CreatedDate] = @StudentCourse_CreatedDate, [StudentCourse_UpdatedDate] = @StudentCourse_UpdatedDate, [StudentCourse_CreatedBy] = @StudentCourse_CreatedBy, [StudentCourse_UpdatedBy] = @StudentCourse_UpdatedBy, [StudentCourse_Remark] = @StudentCourse_Remark, [StudentCourse_DefermentReason] = @StudentCourse_DefermentReason WHERE [StudentCourse_ID] = @o_StudentCourse_ID");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourse_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_Status", SqlDbType.SmallInt, 0, "StudentCourse_Status");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_CreatedDate", SqlDbType.DateTime, 0, "StudentCourse_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourse_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourse_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourse_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_Remark", SqlDbType.NVarChar, 0, "StudentCourse_Remark");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_DefermentReason", SqlDbType.NVarChar, 0, "StudentCourse_DefermentReason");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [StudentCourse] WHERE [StudentCourse_ID] = @o_StudentCourse_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourse_ID", DataRowVersion.Original, null));
}
public void Update(StudentCourseTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(StudentCourseRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public StudentCourseRow GetByStudentCourse_ID(System.Guid StudentCourse_ID ) {
string sql = "SELECT * FROM [StudentCourse] WHERE [StudentCourse_ID] = @StudentCourse_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);

StudentCourseTable tbl = new StudentCourseTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentCourseRow(0);
}
public int CountByStudentCourse_ID(System.Guid StudentCourse_ID ) {
string sql = "SELECT COUNT(*) FROM [StudentCourse] WHERE [StudentCourse_ID] = @StudentCourse_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByStudentCourse_ID(System.Guid StudentCourse_ID, IActivityLog log ) {
string sql = "DELETE FROM [StudentCourse] WHERE [StudentCourse_ID] = @StudentCourse_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public StudentCourseTable GetByStudent_ID(System.Guid Student_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [StudentCourse] WHERE [Student_ID] = @Student_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Student_ID", Student_ID);
StudentCourseTable tbl = new StudentCourseTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByStudent_ID(System.Guid Student_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [StudentCourse] WHERE [Student_ID] = @Student_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Student_ID", Student_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByStudent_ID(System.Guid Student_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [StudentCourse] WHERE [Student_ID] = @Student_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Student_ID", Student_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public StudentCourseTable GetByCourseSubject_ID(System.Guid CourseSubject_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [StudentCourse] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
StudentCourseTable tbl = new StudentCourseTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourseSubject_ID(System.Guid CourseSubject_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [StudentCourse] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourseSubject_ID(System.Guid CourseSubject_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [StudentCourse] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
