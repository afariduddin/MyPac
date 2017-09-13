using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentWarningLetterTable : DataTable {
// column indexes
public const int StudentWarningLetter_IDColumnIndex = 0;
public const int Student_IDColumnIndex = 1;
public const int WarningLetter_IDColumnIndex = 2;
public const int StudentWarningLetter_CreatedDateColumnIndex = 3;
public const int StudentWarningLetter_CreatedByColumnIndex = 4;
public const int EmailNotification_IDColumnIndex = 5;
public StudentWarningLetterTable() {
TableName = "[StudentWarningLetter]";
// column StudentWarningLetter_ID
DataColumn StudentWarningLetter_IDCol = new DataColumn("StudentWarningLetter_ID", typeof(System.Guid));
StudentWarningLetter_IDCol.ReadOnly = false;
StudentWarningLetter_IDCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_IDCol);
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = false;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column WarningLetter_ID
DataColumn WarningLetter_IDCol = new DataColumn("WarningLetter_ID", typeof(System.Guid));
WarningLetter_IDCol.ReadOnly = false;
WarningLetter_IDCol.AllowDBNull = false;
Columns.Add(WarningLetter_IDCol);
// column StudentWarningLetter_CreatedDate
DataColumn StudentWarningLetter_CreatedDateCol = new DataColumn("StudentWarningLetter_CreatedDate", typeof(System.DateTime));
StudentWarningLetter_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentWarningLetter_CreatedDateCol.ReadOnly = false;
StudentWarningLetter_CreatedDateCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_CreatedDateCol);
// column StudentWarningLetter_CreatedBy
DataColumn StudentWarningLetter_CreatedByCol = new DataColumn("StudentWarningLetter_CreatedBy", typeof(System.String));
StudentWarningLetter_CreatedByCol.ReadOnly = false;
StudentWarningLetter_CreatedByCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_CreatedByCol);
// column EmailNotification_ID
DataColumn EmailNotification_IDCol = new DataColumn("EmailNotification_ID", typeof(System.Guid));
EmailNotification_IDCol.ReadOnly = false;
EmailNotification_IDCol.AllowDBNull = false;
Columns.Add(EmailNotification_IDCol);
}
public StudentWarningLetterRow NewStudentWarningLetterRow() {
StudentWarningLetterRow row = (StudentWarningLetterRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(StudentWarningLetterRow row) {
row.StudentWarningLetter_ID = Guid.Empty;
row.Student_ID = Guid.Empty;
row.WarningLetter_ID = Guid.Empty;
row.StudentWarningLetter_CreatedDate = DateTime.Now;
row.StudentWarningLetter_CreatedBy = "";
row.EmailNotification_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentWarningLetterRow(builder);
}
public StudentWarningLetterRow GetStudentWarningLetterRow(int index) {
return (StudentWarningLetterRow)Rows[index];
}
}
public partial class StudentWarningLetterRow : DataRow {
internal StudentWarningLetterRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid StudentWarningLetter_ID {
get {
return (System.Guid)this["StudentWarningLetter_ID"];
}
set {
this["StudentWarningLetter_ID"] = value;
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
public System.Guid WarningLetter_ID {
get {
return (System.Guid)this["WarningLetter_ID"];
}
set {
this["WarningLetter_ID"] = value;
}
}
public System.DateTime StudentWarningLetter_CreatedDate {
get {
return (System.DateTime)this["StudentWarningLetter_CreatedDate"];
}
set {
this["StudentWarningLetter_CreatedDate"] = value;
}
}
public System.String StudentWarningLetter_CreatedBy {
get {
return (System.String)this["StudentWarningLetter_CreatedBy"];
}
set {
if( value.Length > 50 ) this["StudentWarningLetter_CreatedBy"] = value.Substring(0, 50);
else this["StudentWarningLetter_CreatedBy"] = value;
}
}
public System.Guid EmailNotification_ID {
get {
return (System.Guid)this["EmailNotification_ID"];
}
set {
this["EmailNotification_ID"] = value;
}
}
}
public partial class StudentWarningLetterMinimalizedEntity {
public StudentWarningLetterMinimalizedEntity() {}
public StudentWarningLetterMinimalizedEntity(StudentWarningLetterRow dr) {
this.StudentWarningLetter_ID = dr.StudentWarningLetter_ID;
this.Student_ID = dr.Student_ID;
this.WarningLetter_ID = dr.WarningLetter_ID;
this.StudentWarningLetter_CreatedDate = dr.StudentWarningLetter_CreatedDate;
this.StudentWarningLetter_CreatedBy = dr.StudentWarningLetter_CreatedBy;
this.EmailNotification_ID = dr.EmailNotification_ID;
}
public void CopyTo(StudentWarningLetterRow dr) {
dr.StudentWarningLetter_ID = this.StudentWarningLetter_ID;
dr.Student_ID = this.Student_ID;
dr.WarningLetter_ID = this.WarningLetter_ID;
dr.StudentWarningLetter_CreatedDate = this.StudentWarningLetter_CreatedDate;
dr.StudentWarningLetter_CreatedBy = this.StudentWarningLetter_CreatedBy;
dr.EmailNotification_ID = this.EmailNotification_ID;
}
public System.Guid StudentWarningLetter_ID;
public System.Guid Student_ID;
public System.Guid WarningLetter_ID;
public System.DateTime StudentWarningLetter_CreatedDate;
public System.String StudentWarningLetter_CreatedBy;
public System.Guid EmailNotification_ID;
}
public partial class StudentWarningLetterAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentWarningLetterAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("StudentWarningLetter_ID", "StudentWarningLetter_ID");
tmap.ColumnMappings.Add("Student_ID", "Student_ID");
tmap.ColumnMappings.Add("WarningLetter_ID", "WarningLetter_ID");
tmap.ColumnMappings.Add("StudentWarningLetter_CreatedDate", "StudentWarningLetter_CreatedDate");
tmap.ColumnMappings.Add("StudentWarningLetter_CreatedBy", "StudentWarningLetter_CreatedBy");
tmap.ColumnMappings.Add("EmailNotification_ID", "EmailNotification_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [StudentWarningLetter] ([StudentWarningLetter_ID], [Student_ID], [WarningLetter_ID], [StudentWarningLetter_CreatedDate], [StudentWarningLetter_CreatedBy], [EmailNotification_ID]) VALUES (@StudentWarningLetter_ID, @Student_ID, @WarningLetter_ID, @StudentWarningLetter_CreatedDate, @StudentWarningLetter_CreatedBy, @EmailNotification_ID)");
adapter.InsertCommand.Parameters.Add("@StudentWarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "StudentWarningLetter_ID");
adapter.InsertCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.InsertCommand.Parameters.Add("@WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "WarningLetter_ID");
adapter.InsertCommand.Parameters.Add("@StudentWarningLetter_CreatedDate", SqlDbType.DateTime, 0, "StudentWarningLetter_CreatedDate");
adapter.InsertCommand.Parameters.Add("@StudentWarningLetter_CreatedBy", SqlDbType.NVarChar, 0, "StudentWarningLetter_CreatedBy");
adapter.InsertCommand.Parameters.Add("@EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, "EmailNotification_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [StudentWarningLetter] SET [StudentWarningLetter_ID] = @StudentWarningLetter_ID, [Student_ID] = @Student_ID, [WarningLetter_ID] = @WarningLetter_ID, [StudentWarningLetter_CreatedDate] = @StudentWarningLetter_CreatedDate, [StudentWarningLetter_CreatedBy] = @StudentWarningLetter_CreatedBy, [EmailNotification_ID] = @EmailNotification_ID WHERE [StudentWarningLetter_ID] = @o_StudentWarningLetter_ID");
adapter.UpdateCommand.Parameters.Add("@StudentWarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "StudentWarningLetter_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_StudentWarningLetter_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentWarningLetter_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Student_ID", SqlDbType.UniqueIdentifier, 0, "Student_ID");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "WarningLetter_ID");
adapter.UpdateCommand.Parameters.Add("@StudentWarningLetter_CreatedDate", SqlDbType.DateTime, 0, "StudentWarningLetter_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@StudentWarningLetter_CreatedBy", SqlDbType.NVarChar, 0, "StudentWarningLetter_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, "EmailNotification_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [StudentWarningLetter] WHERE [StudentWarningLetter_ID] = @o_StudentWarningLetter_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_StudentWarningLetter_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "StudentWarningLetter_ID", DataRowVersion.Original, null));
}
public void Update(StudentWarningLetterTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(StudentWarningLetterRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public StudentWarningLetterRow GetByStudentWarningLetter_ID(System.Guid StudentWarningLetter_ID ) {
string sql = "SELECT * FROM [StudentWarningLetter] WHERE [StudentWarningLetter_ID] = @StudentWarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentWarningLetter_ID", StudentWarningLetter_ID);

StudentWarningLetterTable tbl = new StudentWarningLetterTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentWarningLetterRow(0);
}
public int CountByStudentWarningLetter_ID(System.Guid StudentWarningLetter_ID ) {
string sql = "SELECT COUNT(*) FROM [StudentWarningLetter] WHERE [StudentWarningLetter_ID] = @StudentWarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentWarningLetter_ID", StudentWarningLetter_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByStudentWarningLetter_ID(System.Guid StudentWarningLetter_ID, IActivityLog log ) {
string sql = "DELETE FROM [StudentWarningLetter] WHERE [StudentWarningLetter_ID] = @StudentWarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("StudentWarningLetter_ID", StudentWarningLetter_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
