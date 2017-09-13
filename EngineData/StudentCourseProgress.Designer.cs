using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentCourseProgressTable : DataTable {
// column indexes
public const int StudentCourseProgress_IDColumnIndex = 0;
public const int StudentCourseProgress_CreatedDateColumnIndex = 1;
public const int StudentCourseProgress_UpdatedDateColumnIndex = 2;
public const int StudentCourseProgress_CreatedByColumnIndex = 3;
public const int StudentCourseProgress_UpdatedByColumnIndex = 4;
public const int StudentCourseProgress_DescriptionColumnIndex = 5;
public const int StudentCourseProgress_TypeColumnIndex = 6;
public const int StudentCourseProgress_RemarkColumnIndex = 7;
public const int StudentCourseProgress_DateColumnIndex = 8;
public const int StudentCourseProgress_IsDeletedColumnIndex = 9;
public const int StudentCourse_IDColumnIndex = 10;
public const int StudentCourseProgress_TotalClassColumnIndex = 11;
public const int StudentCourseProgress_AttendedClassColumnIndex = 12;
public const int StudentCourseProgress_ExamIsFinalColumnIndex = 13;
public const int StudentCourseProgress_ExamScoreColumnIndex = 14;
public StudentCourseProgressTable() {
TableName = "[StudentCourseProgress]";
// column StudentCourseProgress_ID
DataColumn StudentCourseProgress_IDCol = new DataColumn("StudentCourseProgress_ID", typeof(System.Guid));
StudentCourseProgress_IDCol.ReadOnly = false;
StudentCourseProgress_IDCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_IDCol);
// column StudentCourseProgress_CreatedDate
DataColumn StudentCourseProgress_CreatedDateCol = new DataColumn("StudentCourseProgress_CreatedDate", typeof(System.DateTime));
StudentCourseProgress_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourseProgress_CreatedDateCol.ReadOnly = false;
StudentCourseProgress_CreatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_CreatedDateCol);
// column StudentCourseProgress_UpdatedDate
DataColumn StudentCourseProgress_UpdatedDateCol = new DataColumn("StudentCourseProgress_UpdatedDate", typeof(System.DateTime));
StudentCourseProgress_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourseProgress_UpdatedDateCol.ReadOnly = false;
StudentCourseProgress_UpdatedDateCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_UpdatedDateCol);
// column StudentCourseProgress_CreatedBy
DataColumn StudentCourseProgress_CreatedByCol = new DataColumn("StudentCourseProgress_CreatedBy", typeof(System.String));
StudentCourseProgress_CreatedByCol.ReadOnly = false;
StudentCourseProgress_CreatedByCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_CreatedByCol);
// column StudentCourseProgress_UpdatedBy
DataColumn StudentCourseProgress_UpdatedByCol = new DataColumn("StudentCourseProgress_UpdatedBy", typeof(System.String));
StudentCourseProgress_UpdatedByCol.ReadOnly = false;
StudentCourseProgress_UpdatedByCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_UpdatedByCol);
// column StudentCourseProgress_Description
DataColumn StudentCourseProgress_DescriptionCol = new DataColumn("StudentCourseProgress_Description", typeof(System.String));
StudentCourseProgress_DescriptionCol.ReadOnly = false;
StudentCourseProgress_DescriptionCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_DescriptionCol);
// column StudentCourseProgress_Type
DataColumn StudentCourseProgress_TypeCol = new DataColumn("StudentCourseProgress_Type", typeof(System.Int16));
StudentCourseProgress_TypeCol.ReadOnly = false;
StudentCourseProgress_TypeCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_TypeCol);
// column StudentCourseProgress_Remark
DataColumn StudentCourseProgress_RemarkCol = new DataColumn("StudentCourseProgress_Remark", typeof(System.String));
StudentCourseProgress_RemarkCol.ReadOnly = false;
StudentCourseProgress_RemarkCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_RemarkCol);
// column StudentCourseProgress_Date
DataColumn StudentCourseProgress_DateCol = new DataColumn("StudentCourseProgress_Date", typeof(System.DateTime));
StudentCourseProgress_DateCol.DateTimeMode = DataSetDateTime.Local;
StudentCourseProgress_DateCol.ReadOnly = false;
StudentCourseProgress_DateCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_DateCol);
// column StudentCourseProgress_IsDeleted
DataColumn StudentCourseProgress_IsDeletedCol = new DataColumn("StudentCourseProgress_IsDeleted", typeof(System.Boolean));
StudentCourseProgress_IsDeletedCol.ReadOnly = false;
StudentCourseProgress_IsDeletedCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_IsDeletedCol);
// column StudentCourse_ID
DataColumn StudentCourse_IDCol = new DataColumn("StudentCourse_ID", typeof(System.Guid));
StudentCourse_IDCol.ReadOnly = false;
StudentCourse_IDCol.AllowDBNull = false;
Columns.Add(StudentCourse_IDCol);
// column StudentCourseProgress_TotalClass
DataColumn StudentCourseProgress_TotalClassCol = new DataColumn("StudentCourseProgress_TotalClass", typeof(System.Int32));
StudentCourseProgress_TotalClassCol.ReadOnly = false;
StudentCourseProgress_TotalClassCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_TotalClassCol);
// column StudentCourseProgress_AttendedClass
DataColumn StudentCourseProgress_AttendedClassCol = new DataColumn("StudentCourseProgress_AttendedClass", typeof(System.Int32));
StudentCourseProgress_AttendedClassCol.ReadOnly = false;
StudentCourseProgress_AttendedClassCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_AttendedClassCol);
// column StudentCourseProgress_ExamIsFinal
DataColumn StudentCourseProgress_ExamIsFinalCol = new DataColumn("StudentCourseProgress_ExamIsFinal", typeof(System.Boolean));
StudentCourseProgress_ExamIsFinalCol.ReadOnly = false;
StudentCourseProgress_ExamIsFinalCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_ExamIsFinalCol);
// column StudentCourseProgress_ExamScore
DataColumn StudentCourseProgress_ExamScoreCol = new DataColumn("StudentCourseProgress_ExamScore", typeof(System.Decimal));
StudentCourseProgress_ExamScoreCol.ReadOnly = false;
StudentCourseProgress_ExamScoreCol.AllowDBNull = false;
Columns.Add(StudentCourseProgress_ExamScoreCol);
}
public StudentCourseProgressRow NewStudentCourseProgressRow() {
StudentCourseProgressRow row = (StudentCourseProgressRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(StudentCourseProgressRow row) {
row.StudentCourseProgress_ID = Guid.Empty;
row.StudentCourseProgress_CreatedDate = DateTime.Now;
row.StudentCourseProgress_UpdatedDate = DateTime.Now;
row.StudentCourseProgress_CreatedBy = "";
row.StudentCourseProgress_UpdatedBy = "";
row.StudentCourseProgress_Description = "";
row.StudentCourseProgress_Type = 0;
row.StudentCourseProgress_Remark = "";
row.StudentCourseProgress_Date = DateTime.Now;
row.StudentCourseProgress_IsDeleted = false;
row.StudentCourse_ID = Guid.Empty;
row.StudentCourseProgress_TotalClass = 0;
row.StudentCourseProgress_AttendedClass = 0;
row.StudentCourseProgress_ExamIsFinal = false;
row.StudentCourseProgress_ExamScore = 0;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentCourseProgressRow(builder);
}
public StudentCourseProgressRow GetStudentCourseProgressRow(int index) {
return (StudentCourseProgressRow)Rows[index];
}
}
public partial class StudentCourseProgressRow : DataRow {
internal StudentCourseProgressRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid StudentCourseProgress_ID {
get {
return (System.Guid)this["StudentCourseProgress_ID"];
}
set {
this["StudentCourseProgress_ID"] = value;
}
}
public System.DateTime StudentCourseProgress_CreatedDate {
get {
return (System.DateTime)this["StudentCourseProgress_CreatedDate"];
}
set {
this["StudentCourseProgress_CreatedDate"] = value;
}
}
public System.DateTime StudentCourseProgress_UpdatedDate {
get {
return (System.DateTime)this["StudentCourseProgress_UpdatedDate"];
}
set {
this["StudentCourseProgress_UpdatedDate"] = value;
}
}
public System.String StudentCourseProgress_CreatedBy {
get {
return (System.String)this["StudentCourseProgress_CreatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourseProgress_CreatedBy"] = value.Substring(0, 50);
else this["StudentCourseProgress_CreatedBy"] = value;
}
}
public System.String StudentCourseProgress_UpdatedBy {
get {
return (System.String)this["StudentCourseProgress_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["StudentCourseProgress_UpdatedBy"] = value.Substring(0, 50);
else this["StudentCourseProgress_UpdatedBy"] = value;
}
}
public System.String StudentCourseProgress_Description {
get {
return (System.String)this["StudentCourseProgress_Description"];
}
set {
if( value.Length > 250 ) this["StudentCourseProgress_Description"] = value.Substring(0, 250);
else this["StudentCourseProgress_Description"] = value;
}
}
public System.Int16 StudentCourseProgress_Type {
get {
return (System.Int16)this["StudentCourseProgress_Type"];
}
set {
this["StudentCourseProgress_Type"] = value;
}
}
public System.String StudentCourseProgress_Remark {
get {
return (System.String)this["StudentCourseProgress_Remark"];
}
set {
if( value.Length > 250 ) this["StudentCourseProgress_Remark"] = value.Substring(0, 250);
else this["StudentCourseProgress_Remark"] = value;
}
}
public System.DateTime StudentCourseProgress_Date {
get {
return (System.DateTime)this["StudentCourseProgress_Date"];
}
set {
this["StudentCourseProgress_Date"] = value;
}
}
public System.Boolean StudentCourseProgress_IsDeleted {
get {
return (System.Boolean)this["StudentCourseProgress_IsDeleted"];
}
set {
this["StudentCourseProgress_IsDeleted"] = value;
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
public System.Int32 StudentCourseProgress_TotalClass {
get {
return (System.Int32)this["StudentCourseProgress_TotalClass"];
}
set {
this["StudentCourseProgress_TotalClass"] = value;
}
}
public System.Int32 StudentCourseProgress_AttendedClass {
get {
return (System.Int32)this["StudentCourseProgress_AttendedClass"];
}
set {
this["StudentCourseProgress_AttendedClass"] = value;
}
}
public System.Boolean StudentCourseProgress_ExamIsFinal {
get {
return (System.Boolean)this["StudentCourseProgress_ExamIsFinal"];
}
set {
this["StudentCourseProgress_ExamIsFinal"] = value;
}
}
public System.Decimal StudentCourseProgress_ExamScore {
get {
return (System.Decimal)this["StudentCourseProgress_ExamScore"];
}
set {
this["StudentCourseProgress_ExamScore"] = value;
}
}
}
public partial class StudentCourseProgressMinimalizedEntity {
public StudentCourseProgressMinimalizedEntity() {}
public StudentCourseProgressMinimalizedEntity(StudentCourseProgressRow dr) {
this.StudentCourseProgress_ID = dr.StudentCourseProgress_ID;
this.StudentCourseProgress_CreatedDate = dr.StudentCourseProgress_CreatedDate;
this.StudentCourseProgress_UpdatedDate = dr.StudentCourseProgress_UpdatedDate;
this.StudentCourseProgress_CreatedBy = dr.StudentCourseProgress_CreatedBy;
this.StudentCourseProgress_UpdatedBy = dr.StudentCourseProgress_UpdatedBy;
this.StudentCourseProgress_Description = dr.StudentCourseProgress_Description;
this.StudentCourseProgress_Type = dr.StudentCourseProgress_Type;
this.StudentCourseProgress_Remark = dr.StudentCourseProgress_Remark;
this.StudentCourseProgress_Date = dr.StudentCourseProgress_Date;
this.StudentCourseProgress_IsDeleted = dr.StudentCourseProgress_IsDeleted;
this.StudentCourse_ID = dr.StudentCourse_ID;
this.StudentCourseProgress_TotalClass = dr.StudentCourseProgress_TotalClass;
this.StudentCourseProgress_AttendedClass = dr.StudentCourseProgress_AttendedClass;
this.StudentCourseProgress_ExamIsFinal = dr.StudentCourseProgress_ExamIsFinal;
this.StudentCourseProgress_ExamScore = dr.StudentCourseProgress_ExamScore;
}
public void CopyTo(StudentCourseProgressRow dr) {
dr.StudentCourseProgress_ID = this.StudentCourseProgress_ID;
dr.StudentCourseProgress_CreatedDate = this.StudentCourseProgress_CreatedDate;
dr.StudentCourseProgress_UpdatedDate = this.StudentCourseProgress_UpdatedDate;
dr.StudentCourseProgress_CreatedBy = this.StudentCourseProgress_CreatedBy;
dr.StudentCourseProgress_UpdatedBy = this.StudentCourseProgress_UpdatedBy;
dr.StudentCourseProgress_Description = this.StudentCourseProgress_Description;
dr.StudentCourseProgress_Type = this.StudentCourseProgress_Type;
dr.StudentCourseProgress_Remark = this.StudentCourseProgress_Remark;
dr.StudentCourseProgress_Date = this.StudentCourseProgress_Date;
dr.StudentCourseProgress_IsDeleted = this.StudentCourseProgress_IsDeleted;
dr.StudentCourse_ID = this.StudentCourse_ID;
dr.StudentCourseProgress_TotalClass = this.StudentCourseProgress_TotalClass;
dr.StudentCourseProgress_AttendedClass = this.StudentCourseProgress_AttendedClass;
dr.StudentCourseProgress_ExamIsFinal = this.StudentCourseProgress_ExamIsFinal;
dr.StudentCourseProgress_ExamScore = this.StudentCourseProgress_ExamScore;
}
public System.Guid StudentCourseProgress_ID;
public System.DateTime StudentCourseProgress_CreatedDate;
public System.DateTime StudentCourseProgress_UpdatedDate;
public System.String StudentCourseProgress_CreatedBy;
public System.String StudentCourseProgress_UpdatedBy;
public System.String StudentCourseProgress_Description;
public System.Int16 StudentCourseProgress_Type;
public System.String StudentCourseProgress_Remark;
public System.DateTime StudentCourseProgress_Date;
public System.Boolean StudentCourseProgress_IsDeleted;
public System.Guid StudentCourse_ID;
public System.Int32 StudentCourseProgress_TotalClass;
public System.Int32 StudentCourseProgress_AttendedClass;
public System.Boolean StudentCourseProgress_ExamIsFinal;
public System.Decimal StudentCourseProgress_ExamScore;
}
public partial class StudentCourseProgressAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentCourseProgressAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("StudentCourseProgress_ID", "StudentCourseProgress_ID");
tmap.ColumnMappings.Add("StudentCourseProgress_CreatedDate", "StudentCourseProgress_CreatedDate");
tmap.ColumnMappings.Add("StudentCourseProgress_UpdatedDate", "StudentCourseProgress_UpdatedDate");
tmap.ColumnMappings.Add("StudentCourseProgress_CreatedBy", "StudentCourseProgress_CreatedBy");
tmap.ColumnMappings.Add("StudentCourseProgress_UpdatedBy", "StudentCourseProgress_UpdatedBy");
tmap.ColumnMappings.Add("StudentCourseProgress_Description", "StudentCourseProgress_Description");
tmap.ColumnMappings.Add("StudentCourseProgress_Type", "StudentCourseProgress_Type");
tmap.ColumnMappings.Add("StudentCourseProgress_Remark", "StudentCourseProgress_Remark");
tmap.ColumnMappings.Add("StudentCourseProgress_Date", "StudentCourseProgress_Date");
tmap.ColumnMappings.Add("StudentCourseProgress_IsDeleted", "StudentCourseProgress_IsDeleted");
tmap.ColumnMappings.Add("StudentCourse_ID", "StudentCourse_ID");
tmap.ColumnMappings.Add("StudentCourseProgress_TotalClass", "StudentCourseProgress_TotalClass");
tmap.ColumnMappings.Add("StudentCourseProgress_AttendedClass", "StudentCourseProgress_AttendedClass");
tmap.ColumnMappings.Add("StudentCourseProgress_ExamIsFinal", "StudentCourseProgress_ExamIsFinal");
tmap.ColumnMappings.Add("StudentCourseProgress_ExamScore", "StudentCourseProgress_ExamScore");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [StudentCourseProgress] ([StudentCourseProgress_ID], [StudentCourseProgress_CreatedDate], [StudentCourseProgress_UpdatedDate], [StudentCourseProgress_CreatedBy], [StudentCourseProgress_UpdatedBy], [StudentCourseProgress_Description], [StudentCourseProgress_Type], [StudentCourseProgress_Remark], [StudentCourseProgress_Date], [StudentCourseProgress_IsDeleted], [StudentCourse_ID], [StudentCourseProgress_TotalClass], [StudentCourseProgress_AttendedClass], [StudentCourseProgress_ExamIsFinal], [StudentCourseProgress_ExamScore]) VALUES (@StudentCourseProgress_ID, @StudentCourseProgress_CreatedDate, @StudentCourseProgress_UpdatedDate, @StudentCourseProgress_CreatedBy, @StudentCourseProgress_UpdatedBy, @StudentCourseProgress_Description, @StudentCourseProgress_Type, @StudentCourseProgress_Remark, @StudentCourseProgress_Date, @StudentCourseProgress_IsDeleted, @StudentCourse_ID, @StudentCourseProgress_TotalClass, @StudentCourseProgress_AttendedClass, @StudentCourseProgress_ExamIsFinal, @StudentCourseProgress_ExamScore)");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourseProgress_ID");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_CreatedDate", SqlDbType.DateTime, 0, "StudentCourseProgress_CreatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourseProgress_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourseProgress_CreatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourseProgress_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_Description", SqlDbType.NVarChar, 0, "StudentCourseProgress_Description");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_Type", SqlDbType.SmallInt, 0, "StudentCourseProgress_Type");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_Remark", SqlDbType.NVarChar, 0, "StudentCourseProgress_Remark");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_Date", SqlDbType.DateTime, 0, "StudentCourseProgress_Date");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_IsDeleted", SqlDbType.Bit, 0, "StudentCourseProgress_IsDeleted");
adapter.InsertCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_TotalClass", SqlDbType.Int, 0, "StudentCourseProgress_TotalClass");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_AttendedClass", SqlDbType.Int, 0, "StudentCourseProgress_AttendedClass");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_ExamIsFinal", SqlDbType.Bit, 0, "StudentCourseProgress_ExamIsFinal");
adapter.InsertCommand.Parameters.Add("@StudentCourseProgress_ExamScore", SqlDbType.Decimal, 0, "StudentCourseProgress_ExamScore");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [StudentCourseProgress] SET [StudentCourseProgress_ID] = @StudentCourseProgress_ID, [StudentCourseProgress_CreatedDate] = @StudentCourseProgress_CreatedDate, [StudentCourseProgress_UpdatedDate] = @StudentCourseProgress_UpdatedDate, [StudentCourseProgress_CreatedBy] = @StudentCourseProgress_CreatedBy, [StudentCourseProgress_UpdatedBy] = @StudentCourseProgress_UpdatedBy, [StudentCourseProgress_Description] = @StudentCourseProgress_Description, [StudentCourseProgress_Type] = @StudentCourseProgress_Type, [StudentCourseProgress_Remark] = @StudentCourseProgress_Remark, [StudentCourseProgress_Date] = @StudentCourseProgress_Date, [StudentCourseProgress_IsDeleted] = @StudentCourseProgress_IsDeleted, [StudentCourse_ID] = @StudentCourse_ID, [StudentCourseProgress_TotalClass] = @StudentCourseProgress_TotalClass, [StudentCourseProgress_AttendedClass] = @StudentCourseProgress_AttendedClass, [StudentCourseProgress_ExamIsFinal] = @StudentCourseProgress_ExamIsFinal, [StudentCourseProgress_ExamScore] = @StudentCourseProgress_ExamScore WHERE [StudentCourseProgress_ID] = @o_StudentCourseProgress_ID");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourseProgress_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_StudentCourseProgress_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourseProgress_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_CreatedDate", SqlDbType.DateTime, 0, "StudentCourseProgress_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_UpdatedDate", SqlDbType.DateTime, 0, "StudentCourseProgress_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_CreatedBy", SqlDbType.NVarChar, 0, "StudentCourseProgress_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_UpdatedBy", SqlDbType.NVarChar, 0, "StudentCourseProgress_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_Description", SqlDbType.NVarChar, 0, "StudentCourseProgress_Description");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_Type", SqlDbType.SmallInt, 0, "StudentCourseProgress_Type");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_Remark", SqlDbType.NVarChar, 0, "StudentCourseProgress_Remark");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_Date", SqlDbType.DateTime, 0, "StudentCourseProgress_Date");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_IsDeleted", SqlDbType.Bit, 0, "StudentCourseProgress_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@StudentCourse_ID", SqlDbType.UniqueIdentifier, 0, "StudentCourse_ID");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_TotalClass", SqlDbType.Int, 0, "StudentCourseProgress_TotalClass");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_AttendedClass", SqlDbType.Int, 0, "StudentCourseProgress_AttendedClass");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_ExamIsFinal", SqlDbType.Bit, 0, "StudentCourseProgress_ExamIsFinal");
adapter.UpdateCommand.Parameters.Add("@StudentCourseProgress_ExamScore", SqlDbType.Decimal, 0, "StudentCourseProgress_ExamScore");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [StudentCourseProgress] WHERE [StudentCourseProgress_ID] = @o_StudentCourseProgress_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_StudentCourseProgress_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentCourseProgress_ID", DataRowVersion.Original, null));
}
public void Update(StudentCourseProgressTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(StudentCourseProgressRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public StudentCourseProgressRow GetByStudentCourseProgress_ID(System.Guid StudentCourseProgress_ID ) {
string sql = "SELECT * FROM [StudentCourseProgress] WHERE [StudentCourseProgress_ID] = @StudentCourseProgress_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseProgress_ID", StudentCourseProgress_ID);

StudentCourseProgressTable tbl = new StudentCourseProgressTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentCourseProgressRow(0);
}
public int CountByStudentCourseProgress_ID(System.Guid StudentCourseProgress_ID ) {
string sql = "SELECT COUNT(*) FROM [StudentCourseProgress] WHERE [StudentCourseProgress_ID] = @StudentCourseProgress_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseProgress_ID", StudentCourseProgress_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByStudentCourseProgress_ID(System.Guid StudentCourseProgress_ID, IActivityLog log ) {
string sql = "DELETE FROM [StudentCourseProgress] WHERE [StudentCourseProgress_ID] = @StudentCourseProgress_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentCourseProgress_ID", StudentCourseProgress_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public StudentCourseProgressTable GetByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [StudentCourseProgress] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
StudentCourseProgressTable tbl = new StudentCourseProgressTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByStudentCourse_ID(System.Guid StudentCourse_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [StudentCourseProgress] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByStudentCourse_ID(System.Guid StudentCourse_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [StudentCourseProgress] WHERE [StudentCourse_ID] = @StudentCourse_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
