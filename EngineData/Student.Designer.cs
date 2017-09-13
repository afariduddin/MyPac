using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentTable : DataTable {
// column indexes
public const int Student_IDColumnIndex = 0;
public const int TSP_IDColumnIndex = 1;
public const int Student_SubjectTakenColumnIndex = 2;
public const int Course_IDColumnIndex = 3;
public const int Student_StatusColumnIndex = 4;
public const int Student_RemarkColumnIndex = 5;
public const int Application_IDColumnIndex = 6;
public const int Student_CreatedDateColumnIndex = 7;
public const int Student_UpdatedDateColumnIndex = 8;
public const int Student_CreatedByColumnIndex = 9;
public const int Student_UpdatedByColumnIndex = 10;
public const int Student_EnrollmentDateColumnIndex = 11;
public const int Student_ContractExpiredDateColumnIndex = 12;
public StudentTable() {
TableName = "[Student]";
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = false;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = false;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Student_SubjectTaken
DataColumn Student_SubjectTakenCol = new DataColumn("Student_SubjectTaken", typeof(System.Int32));
Student_SubjectTakenCol.ReadOnly = false;
Student_SubjectTakenCol.AllowDBNull = false;
Columns.Add(Student_SubjectTakenCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Student_Status
DataColumn Student_StatusCol = new DataColumn("Student_Status", typeof(System.Int16));
Student_StatusCol.ReadOnly = false;
Student_StatusCol.AllowDBNull = false;
Columns.Add(Student_StatusCol);
// column Student_Remark
DataColumn Student_RemarkCol = new DataColumn("Student_Remark", typeof(System.String));
Student_RemarkCol.ReadOnly = false;
Student_RemarkCol.AllowDBNull = false;
Columns.Add(Student_RemarkCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column Student_CreatedDate
DataColumn Student_CreatedDateCol = new DataColumn("Student_CreatedDate", typeof(System.DateTime));
Student_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Student_CreatedDateCol.ReadOnly = false;
Student_CreatedDateCol.AllowDBNull = false;
Columns.Add(Student_CreatedDateCol);
// column Student_UpdatedDate
DataColumn Student_UpdatedDateCol = new DataColumn("Student_UpdatedDate", typeof(System.DateTime));
Student_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Student_UpdatedDateCol.ReadOnly = false;
Student_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Student_UpdatedDateCol);
// column Student_CreatedBy
DataColumn Student_CreatedByCol = new DataColumn("Student_CreatedBy", typeof(System.String));
Student_CreatedByCol.ReadOnly = false;
Student_CreatedByCol.AllowDBNull = false;
Columns.Add(Student_CreatedByCol);
// column Student_UpdatedBy
DataColumn Student_UpdatedByCol = new DataColumn("Student_UpdatedBy", typeof(System.String));
Student_UpdatedByCol.ReadOnly = false;
Student_UpdatedByCol.AllowDBNull = false;
Columns.Add(Student_UpdatedByCol);
// column Student_EnrollmentDate
DataColumn Student_EnrollmentDateCol = new DataColumn("Student_EnrollmentDate", typeof(System.DateTime));
Student_EnrollmentDateCol.DateTimeMode = DataSetDateTime.Local;
Student_EnrollmentDateCol.ReadOnly = false;
Student_EnrollmentDateCol.AllowDBNull = false;
Columns.Add(Student_EnrollmentDateCol);
// column Student_ContractExpiredDate
DataColumn Student_ContractExpiredDateCol = new DataColumn("Student_ContractExpiredDate", typeof(System.DateTime));
Student_ContractExpiredDateCol.DateTimeMode = DataSetDateTime.Local;
Student_ContractExpiredDateCol.ReadOnly = false;
Student_ContractExpiredDateCol.AllowDBNull = false;
Columns.Add(Student_ContractExpiredDateCol);
}
public StudentRow NewStudentRow() {
StudentRow row = (StudentRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(StudentRow row) {
row.Student_ID = Guid.Empty;
row.TSP_ID = Guid.Empty;
row.Student_SubjectTaken = 0;
row.Course_ID = Guid.Empty;
row.Student_Status = 0;
row.Student_Remark = "";
row.Application_ID = Guid.Empty;
row.Student_CreatedDate = DateTime.Now;
row.Student_UpdatedDate = DateTime.Now;
row.Student_CreatedBy = "";
row.Student_UpdatedBy = "";
row.Student_EnrollmentDate = DateTime.Now;
row.Student_ContractExpiredDate = DateTime.Now;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentRow(builder);
}
public StudentRow GetStudentRow(int index) {
return (StudentRow)Rows[index];
}
}
public partial class StudentRow : DataRow {
internal StudentRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Student_ID {
get {
return (System.Guid)this["Student_ID"];
}
set {
this["Student_ID"] = value;
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
set {
this["TSP_ID"] = value;
}
}
public System.Int32 Student_SubjectTaken {
get {
return (System.Int32)this["Student_SubjectTaken"];
}
set {
this["Student_SubjectTaken"] = value;
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
set {
this["Course_ID"] = value;
}
}
public System.Int16 Student_Status {
get {
return (System.Int16)this["Student_Status"];
}
set {
this["Student_Status"] = value;
}
}
public System.String Student_Remark {
get {
return (System.String)this["Student_Remark"];
}
set {
if( value.Length > 250 ) this["Student_Remark"] = value.Substring(0, 250);
else this["Student_Remark"] = value;
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
public System.DateTime Student_CreatedDate {
get {
return (System.DateTime)this["Student_CreatedDate"];
}
set {
this["Student_CreatedDate"] = value;
}
}
public System.DateTime Student_UpdatedDate {
get {
return (System.DateTime)this["Student_UpdatedDate"];
}
set {
this["Student_UpdatedDate"] = value;
}
}
public System.String Student_CreatedBy {
get {
return (System.String)this["Student_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Student_CreatedBy"] = value.Substring(0, 50);
else this["Student_CreatedBy"] = value;
}
}
public System.String Student_UpdatedBy {
get {
return (System.String)this["Student_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Student_UpdatedBy"] = value.Substring(0, 50);
else this["Student_UpdatedBy"] = value;
}
}
public System.DateTime Student_EnrollmentDate {
get {
return (System.DateTime)this["Student_EnrollmentDate"];
}
set {
this["Student_EnrollmentDate"] = value;
}
}
public System.DateTime Student_ContractExpiredDate {
get {
return (System.DateTime)this["Student_ContractExpiredDate"];
}
set {
this["Student_ContractExpiredDate"] = value;
}
}
}
public partial class StudentMinimalizedEntity {
public StudentMinimalizedEntity() {}
public StudentMinimalizedEntity(StudentRow dr) {
this.Student_ID = dr.Student_ID;
this.TSP_ID = dr.TSP_ID;
this.Student_SubjectTaken = dr.Student_SubjectTaken;
this.Course_ID = dr.Course_ID;
this.Student_Status = dr.Student_Status;
this.Student_Remark = dr.Student_Remark;
this.Application_ID = dr.Application_ID;
this.Student_CreatedDate = dr.Student_CreatedDate;
this.Student_UpdatedDate = dr.Student_UpdatedDate;
this.Student_CreatedBy = dr.Student_CreatedBy;
this.Student_UpdatedBy = dr.Student_UpdatedBy;
this.Student_EnrollmentDate = dr.Student_EnrollmentDate;
this.Student_ContractExpiredDate = dr.Student_ContractExpiredDate;
}
public void CopyTo(StudentRow dr) {
dr.Student_ID = this.Student_ID;
dr.TSP_ID = this.TSP_ID;
dr.Student_SubjectTaken = this.Student_SubjectTaken;
dr.Course_ID = this.Course_ID;
dr.Student_Status = this.Student_Status;
dr.Student_Remark = this.Student_Remark;
dr.Application_ID = this.Application_ID;
dr.Student_CreatedDate = this.Student_CreatedDate;
dr.Student_UpdatedDate = this.Student_UpdatedDate;
dr.Student_CreatedBy = this.Student_CreatedBy;
dr.Student_UpdatedBy = this.Student_UpdatedBy;
dr.Student_EnrollmentDate = this.Student_EnrollmentDate;
dr.Student_ContractExpiredDate = this.Student_ContractExpiredDate;
}
public System.Guid Student_ID;
public System.Guid TSP_ID;
public System.Int32 Student_SubjectTaken;
public System.Guid Course_ID;
public System.Int16 Student_Status;
public System.String Student_Remark;
public System.Guid Application_ID;
public System.DateTime Student_CreatedDate;
public System.DateTime Student_UpdatedDate;
public System.String Student_CreatedBy;
public System.String Student_UpdatedBy;
public System.DateTime Student_EnrollmentDate;
public System.DateTime Student_ContractExpiredDate;
}
public partial class StudentAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Student_ID", "Student_ID");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("Student_SubjectTaken", "Student_SubjectTaken");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("Student_Status", "Student_Status");
tmap.ColumnMappings.Add("Student_Remark", "Student_Remark");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("Student_CreatedDate", "Student_CreatedDate");
tmap.ColumnMappings.Add("Student_UpdatedDate", "Student_UpdatedDate");
tmap.ColumnMappings.Add("Student_CreatedBy", "Student_CreatedBy");
tmap.ColumnMappings.Add("Student_UpdatedBy", "Student_UpdatedBy");
tmap.ColumnMappings.Add("Student_EnrollmentDate", "Student_EnrollmentDate");
tmap.ColumnMappings.Add("Student_ContractExpiredDate", "Student_ContractExpiredDate");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Student] ([Student_ID], [TSP_ID], [Student_SubjectTaken], [Course_ID], [Student_Status], [Student_Remark], [Application_ID], [Student_CreatedDate], [Student_UpdatedDate], [Student_CreatedBy], [Student_UpdatedBy], [Student_EnrollmentDate], [Student_ContractExpiredDate]) VALUES (@Student_ID, @TSP_ID, @Student_SubjectTaken, @Course_ID, @Student_Status, @Student_Remark, @Application_ID, @Student_CreatedDate, @Student_UpdatedDate, @Student_CreatedBy, @Student_UpdatedBy, @Student_EnrollmentDate, @Student_ContractExpiredDate)");
adapter.InsertCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.InsertCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.InsertCommand.Parameters.Add("@Student_SubjectTaken", SqlDbType.Int, 0, "Student_SubjectTaken");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.InsertCommand.Parameters.Add("@Student_Status", SqlDbType.SmallInt, 0, "Student_Status");
adapter.InsertCommand.Parameters.Add("@Student_Remark", SqlDbType.NVarChar, 0, "Student_Remark");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@Student_CreatedDate", SqlDbType.DateTime, 0, "Student_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Student_UpdatedDate", SqlDbType.DateTime, 0, "Student_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Student_CreatedBy", SqlDbType.NVarChar, 0, "Student_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Student_UpdatedBy", SqlDbType.NVarChar, 0, "Student_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@Student_EnrollmentDate", SqlDbType.DateTime, 0, "Student_EnrollmentDate");
adapter.InsertCommand.Parameters.Add("@Student_ContractExpiredDate", SqlDbType.DateTime, 0, "Student_ContractExpiredDate");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Student] SET [Student_ID] = @Student_ID, [TSP_ID] = @TSP_ID, [Student_SubjectTaken] = @Student_SubjectTaken, [Course_ID] = @Course_ID, [Student_Status] = @Student_Status, [Student_Remark] = @Student_Remark, [Application_ID] = @Application_ID, [Student_CreatedDate] = @Student_CreatedDate, [Student_UpdatedDate] = @Student_UpdatedDate, [Student_CreatedBy] = @Student_CreatedBy, [Student_UpdatedBy] = @Student_UpdatedBy, [Student_EnrollmentDate] = @Student_EnrollmentDate, [Student_ContractExpiredDate] = @Student_ContractExpiredDate WHERE [Student_ID] = @o_Student_ID");
adapter.UpdateCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Student_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Student_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.UpdateCommand.Parameters.Add("@Student_SubjectTaken", SqlDbType.Int, 0, "Student_SubjectTaken");
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add("@Student_Status", SqlDbType.SmallInt, 0, "Student_Status");
adapter.UpdateCommand.Parameters.Add("@Student_Remark", SqlDbType.NVarChar, 0, "Student_Remark");
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@Student_CreatedDate", SqlDbType.DateTime, 0, "Student_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Student_UpdatedDate", SqlDbType.DateTime, 0, "Student_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Student_CreatedBy", SqlDbType.NVarChar, 0, "Student_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Student_UpdatedBy", SqlDbType.NVarChar, 0, "Student_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@Student_EnrollmentDate", SqlDbType.DateTime, 0, "Student_EnrollmentDate");
adapter.UpdateCommand.Parameters.Add("@Student_ContractExpiredDate", SqlDbType.DateTime, 0, "Student_ContractExpiredDate");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Student] WHERE [Student_ID] = @o_Student_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Student_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Student_ID", DataRowVersion.Original, null));
}
public void Update(StudentTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(StudentRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public StudentRow GetByStudent_ID(System.Guid Student_ID ) {
string sql = "SELECT * FROM [Student] WHERE [Student_ID] = @Student_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Student_ID", Student_ID);

StudentTable tbl = new StudentTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentRow(0);
}
public int CountByStudent_ID(System.Guid Student_ID ) {
string sql = "SELECT COUNT(*) FROM [Student] WHERE [Student_ID] = @Student_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Student_ID", Student_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByStudent_ID(System.Guid Student_ID, IActivityLog log ) {
string sql = "DELETE FROM [Student] WHERE [Student_ID] = @Student_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Student_ID", Student_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public StudentTable GetByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Student] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
StudentTable tbl = new StudentTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Student] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByTSP_ID(System.Guid TSP_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Student] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public StudentTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Student] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
StudentTable tbl = new StudentTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Student] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Student] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public StudentTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Student] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
StudentTable tbl = new StudentTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Student] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Student] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
