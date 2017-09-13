using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StudentWarningLetterDetailTable : DataTable {
// column indexes
public const int StudentWarningLetter_IDColumnIndex = 0;
public const int Student_IDColumnIndex = 1;
public const int WarningLetter_IDColumnIndex = 2;
public const int StudentWarningLetter_CreatedDateColumnIndex = 3;
public const int StudentWarningLetter_CreatedByColumnIndex = 4;
public const int EmailNotification_IDColumnIndex = 5;
public const int EmailNotification_SubjectColumnIndex = 6;
public const int EmailNotification_EmailContentColumnIndex = 7;
public const int EmailNotification_StatusColumnIndex = 8;
public const int EmailNotification_CreatedDateColumnIndex = 9;
public StudentWarningLetterDetailTable() {
TableName = "[StudentWarningLetterDetail]";
// column StudentWarningLetter_ID
DataColumn StudentWarningLetter_IDCol = new DataColumn("StudentWarningLetter_ID", typeof(System.Guid));
StudentWarningLetter_IDCol.ReadOnly = true;
StudentWarningLetter_IDCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_IDCol);
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = true;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column WarningLetter_ID
DataColumn WarningLetter_IDCol = new DataColumn("WarningLetter_ID", typeof(System.Guid));
WarningLetter_IDCol.ReadOnly = true;
WarningLetter_IDCol.AllowDBNull = false;
Columns.Add(WarningLetter_IDCol);
// column StudentWarningLetter_CreatedDate
DataColumn StudentWarningLetter_CreatedDateCol = new DataColumn("StudentWarningLetter_CreatedDate", typeof(System.DateTime));
StudentWarningLetter_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
StudentWarningLetter_CreatedDateCol.ReadOnly = true;
StudentWarningLetter_CreatedDateCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_CreatedDateCol);
// column StudentWarningLetter_CreatedBy
DataColumn StudentWarningLetter_CreatedByCol = new DataColumn("StudentWarningLetter_CreatedBy", typeof(System.String));
StudentWarningLetter_CreatedByCol.ReadOnly = true;
StudentWarningLetter_CreatedByCol.AllowDBNull = false;
Columns.Add(StudentWarningLetter_CreatedByCol);
// column EmailNotification_ID
DataColumn EmailNotification_IDCol = new DataColumn("EmailNotification_ID", typeof(System.Guid));
EmailNotification_IDCol.ReadOnly = true;
EmailNotification_IDCol.AllowDBNull = false;
Columns.Add(EmailNotification_IDCol);
// column EmailNotification_Subject
DataColumn EmailNotification_SubjectCol = new DataColumn("EmailNotification_Subject", typeof(System.String));
EmailNotification_SubjectCol.ReadOnly = true;
EmailNotification_SubjectCol.AllowDBNull = false;
Columns.Add(EmailNotification_SubjectCol);
// column EmailNotification_EmailContent
DataColumn EmailNotification_EmailContentCol = new DataColumn("EmailNotification_EmailContent", typeof(System.String));
EmailNotification_EmailContentCol.ReadOnly = true;
EmailNotification_EmailContentCol.AllowDBNull = false;
Columns.Add(EmailNotification_EmailContentCol);
// column EmailNotification_Status
DataColumn EmailNotification_StatusCol = new DataColumn("EmailNotification_Status", typeof(System.Int16));
EmailNotification_StatusCol.ReadOnly = true;
EmailNotification_StatusCol.AllowDBNull = false;
Columns.Add(EmailNotification_StatusCol);
// column EmailNotification_CreatedDate
DataColumn EmailNotification_CreatedDateCol = new DataColumn("EmailNotification_CreatedDate", typeof(System.DateTime));
EmailNotification_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
EmailNotification_CreatedDateCol.ReadOnly = true;
EmailNotification_CreatedDateCol.AllowDBNull = false;
Columns.Add(EmailNotification_CreatedDateCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new StudentWarningLetterDetailRow(builder);
}
public StudentWarningLetterDetailRow GetStudentWarningLetterDetailRow(int index) {
return (StudentWarningLetterDetailRow)Rows[index];
}
}
public partial class StudentWarningLetterDetailRow : DataRow {
internal StudentWarningLetterDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid StudentWarningLetter_ID {
get {
return (System.Guid)this["StudentWarningLetter_ID"];
}
}
public System.Guid Student_ID {
get {
return (System.Guid)this["Student_ID"];
}
}
public System.Guid WarningLetter_ID {
get {
return (System.Guid)this["WarningLetter_ID"];
}
}
public System.DateTime StudentWarningLetter_CreatedDate {
get {
return (System.DateTime)this["StudentWarningLetter_CreatedDate"];
}
}
public System.String StudentWarningLetter_CreatedBy {
get {
return (System.String)this["StudentWarningLetter_CreatedBy"];
}
}
public System.Guid EmailNotification_ID {
get {
return (System.Guid)this["EmailNotification_ID"];
}
}
public System.String EmailNotification_Subject {
get {
return (System.String)this["EmailNotification_Subject"];
}
}
public System.String EmailNotification_EmailContent {
get {
return (System.String)this["EmailNotification_EmailContent"];
}
}
public System.Int16 EmailNotification_Status {
get {
return (System.Int16)this["EmailNotification_Status"];
}
}
public System.DateTime EmailNotification_CreatedDate {
get {
return (System.DateTime)this["EmailNotification_CreatedDate"];
}
}
}
public partial class StudentWarningLetterDetailMinimalizedEntity {
public StudentWarningLetterDetailMinimalizedEntity() {}
public StudentWarningLetterDetailMinimalizedEntity(StudentWarningLetterDetailRow dr) {
this.StudentWarningLetter_ID = dr.StudentWarningLetter_ID;
this.Student_ID = dr.Student_ID;
this.WarningLetter_ID = dr.WarningLetter_ID;
this.StudentWarningLetter_CreatedDate = dr.StudentWarningLetter_CreatedDate;
this.StudentWarningLetter_CreatedBy = dr.StudentWarningLetter_CreatedBy;
this.EmailNotification_ID = dr.EmailNotification_ID;
this.EmailNotification_Subject = dr.EmailNotification_Subject;
this.EmailNotification_EmailContent = dr.EmailNotification_EmailContent;
this.EmailNotification_Status = dr.EmailNotification_Status;
this.EmailNotification_CreatedDate = dr.EmailNotification_CreatedDate;
}
public System.Guid StudentWarningLetter_ID;
public System.Guid Student_ID;
public System.Guid WarningLetter_ID;
public System.DateTime StudentWarningLetter_CreatedDate;
public System.String StudentWarningLetter_CreatedBy;
public System.Guid EmailNotification_ID;
public System.String EmailNotification_Subject;
public System.String EmailNotification_EmailContent;
public System.Int16 EmailNotification_Status;
public System.DateTime EmailNotification_CreatedDate;
}
public partial class StudentWarningLetterDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StudentWarningLetterDetailAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("EmailNotification_Subject", "EmailNotification_Subject");
tmap.ColumnMappings.Add("EmailNotification_EmailContent", "EmailNotification_EmailContent");
tmap.ColumnMappings.Add("EmailNotification_Status", "EmailNotification_Status");
tmap.ColumnMappings.Add("EmailNotification_CreatedDate", "EmailNotification_CreatedDate");
adapter.TableMappings.Add(tmap);
}
}
public StudentWarningLetterDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [StudentWarningLetterDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

StudentWarningLetterDetailTable tbl = new StudentWarningLetterDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetStudentWarningLetterDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [StudentWarningLetterDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
