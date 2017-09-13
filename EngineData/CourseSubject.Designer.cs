using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CourseSubjectTable : DataTable {
// column indexes
public const int Course_IDColumnIndex = 0;
public const int CourseSubject_IDColumnIndex = 1;
public const int CourseSubject_NameColumnIndex = 2;
public const int CourseSubject_CreatedByColumnIndex = 3;
public const int CourseSubject_UpdatedByColumnIndex = 4;
public const int CourseSubject_CreatedDateColumnIndex = 5;
public const int CourseSubject_UpdatedDateColumnIndex = 6;
public const int CourseSubject_CodeColumnIndex = 7;
public CourseSubjectTable() {
TableName = "[CourseSubject]";
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column CourseSubject_ID
DataColumn CourseSubject_IDCol = new DataColumn("CourseSubject_ID", typeof(System.Guid));
CourseSubject_IDCol.ReadOnly = false;
CourseSubject_IDCol.AllowDBNull = false;
Columns.Add(CourseSubject_IDCol);
// column CourseSubject_Name
DataColumn CourseSubject_NameCol = new DataColumn("CourseSubject_Name", typeof(System.String));
CourseSubject_NameCol.ReadOnly = false;
CourseSubject_NameCol.AllowDBNull = false;
Columns.Add(CourseSubject_NameCol);
// column CourseSubject_CreatedBy
DataColumn CourseSubject_CreatedByCol = new DataColumn("CourseSubject_CreatedBy", typeof(System.String));
CourseSubject_CreatedByCol.ReadOnly = false;
CourseSubject_CreatedByCol.AllowDBNull = false;
Columns.Add(CourseSubject_CreatedByCol);
// column CourseSubject_UpdatedBy
DataColumn CourseSubject_UpdatedByCol = new DataColumn("CourseSubject_UpdatedBy", typeof(System.String));
CourseSubject_UpdatedByCol.ReadOnly = false;
CourseSubject_UpdatedByCol.AllowDBNull = false;
Columns.Add(CourseSubject_UpdatedByCol);
// column CourseSubject_CreatedDate
DataColumn CourseSubject_CreatedDateCol = new DataColumn("CourseSubject_CreatedDate", typeof(System.DateTime));
CourseSubject_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
CourseSubject_CreatedDateCol.ReadOnly = false;
CourseSubject_CreatedDateCol.AllowDBNull = false;
Columns.Add(CourseSubject_CreatedDateCol);
// column CourseSubject_UpdatedDate
DataColumn CourseSubject_UpdatedDateCol = new DataColumn("CourseSubject_UpdatedDate", typeof(System.DateTime));
CourseSubject_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
CourseSubject_UpdatedDateCol.ReadOnly = false;
CourseSubject_UpdatedDateCol.AllowDBNull = false;
Columns.Add(CourseSubject_UpdatedDateCol);
// column CourseSubject_Code
DataColumn CourseSubject_CodeCol = new DataColumn("CourseSubject_Code", typeof(System.String));
CourseSubject_CodeCol.ReadOnly = false;
CourseSubject_CodeCol.AllowDBNull = false;
Columns.Add(CourseSubject_CodeCol);
}
public CourseSubjectRow NewCourseSubjectRow() {
CourseSubjectRow row = (CourseSubjectRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CourseSubjectRow row) {
row.Course_ID = Guid.Empty;
row.CourseSubject_ID = Guid.Empty;
row.CourseSubject_Name = "";
row.CourseSubject_CreatedBy = "";
row.CourseSubject_UpdatedBy = "";
row.CourseSubject_CreatedDate = DateTime.Now;
row.CourseSubject_UpdatedDate = DateTime.Now;
row.CourseSubject_Code = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CourseSubjectRow(builder);
}
public CourseSubjectRow GetCourseSubjectRow(int index) {
return (CourseSubjectRow)Rows[index];
}
}
public partial class CourseSubjectRow : DataRow {
internal CourseSubjectRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
set {
this["Course_ID"] = value;
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
public System.String CourseSubject_Name {
get {
return (System.String)this["CourseSubject_Name"];
}
set {
if( value.Length > 250 ) this["CourseSubject_Name"] = value.Substring(0, 250);
else this["CourseSubject_Name"] = value;
}
}
public System.String CourseSubject_CreatedBy {
get {
return (System.String)this["CourseSubject_CreatedBy"];
}
set {
if( value.Length > 50 ) this["CourseSubject_CreatedBy"] = value.Substring(0, 50);
else this["CourseSubject_CreatedBy"] = value;
}
}
public System.String CourseSubject_UpdatedBy {
get {
return (System.String)this["CourseSubject_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["CourseSubject_UpdatedBy"] = value.Substring(0, 50);
else this["CourseSubject_UpdatedBy"] = value;
}
}
public System.DateTime CourseSubject_CreatedDate {
get {
return (System.DateTime)this["CourseSubject_CreatedDate"];
}
set {
this["CourseSubject_CreatedDate"] = value;
}
}
public System.DateTime CourseSubject_UpdatedDate {
get {
return (System.DateTime)this["CourseSubject_UpdatedDate"];
}
set {
this["CourseSubject_UpdatedDate"] = value;
}
}
public System.String CourseSubject_Code {
get {
return (System.String)this["CourseSubject_Code"];
}
set {
if( value.Length > 50 ) this["CourseSubject_Code"] = value.Substring(0, 50);
else this["CourseSubject_Code"] = value;
}
}
}
public partial class CourseSubjectMinimalizedEntity {
public CourseSubjectMinimalizedEntity() {}
public CourseSubjectMinimalizedEntity(CourseSubjectRow dr) {
this.Course_ID = dr.Course_ID;
this.CourseSubject_ID = dr.CourseSubject_ID;
this.CourseSubject_Name = dr.CourseSubject_Name;
this.CourseSubject_CreatedBy = dr.CourseSubject_CreatedBy;
this.CourseSubject_UpdatedBy = dr.CourseSubject_UpdatedBy;
this.CourseSubject_CreatedDate = dr.CourseSubject_CreatedDate;
this.CourseSubject_UpdatedDate = dr.CourseSubject_UpdatedDate;
this.CourseSubject_Code = dr.CourseSubject_Code;
}
public void CopyTo(CourseSubjectRow dr) {
dr.Course_ID = this.Course_ID;
dr.CourseSubject_ID = this.CourseSubject_ID;
dr.CourseSubject_Name = this.CourseSubject_Name;
dr.CourseSubject_CreatedBy = this.CourseSubject_CreatedBy;
dr.CourseSubject_UpdatedBy = this.CourseSubject_UpdatedBy;
dr.CourseSubject_CreatedDate = this.CourseSubject_CreatedDate;
dr.CourseSubject_UpdatedDate = this.CourseSubject_UpdatedDate;
dr.CourseSubject_Code = this.CourseSubject_Code;
}
public System.Guid Course_ID;
public System.Guid CourseSubject_ID;
public System.String CourseSubject_Name;
public System.String CourseSubject_CreatedBy;
public System.String CourseSubject_UpdatedBy;
public System.DateTime CourseSubject_CreatedDate;
public System.DateTime CourseSubject_UpdatedDate;
public System.String CourseSubject_Code;
}
public partial class CourseSubjectAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CourseSubjectAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("CourseSubject_ID", "CourseSubject_ID");
tmap.ColumnMappings.Add("CourseSubject_Name", "CourseSubject_Name");
tmap.ColumnMappings.Add("CourseSubject_CreatedBy", "CourseSubject_CreatedBy");
tmap.ColumnMappings.Add("CourseSubject_UpdatedBy", "CourseSubject_UpdatedBy");
tmap.ColumnMappings.Add("CourseSubject_CreatedDate", "CourseSubject_CreatedDate");
tmap.ColumnMappings.Add("CourseSubject_UpdatedDate", "CourseSubject_UpdatedDate");
tmap.ColumnMappings.Add("CourseSubject_Code", "CourseSubject_Code");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [CourseSubject] ([Course_ID], [CourseSubject_ID], [CourseSubject_Name], [CourseSubject_CreatedBy], [CourseSubject_UpdatedBy], [CourseSubject_CreatedDate], [CourseSubject_UpdatedDate], [CourseSubject_Code]) VALUES (@Course_ID, @CourseSubject_ID, @CourseSubject_Name, @CourseSubject_CreatedBy, @CourseSubject_UpdatedBy, @CourseSubject_CreatedDate, @CourseSubject_UpdatedDate, @CourseSubject_Code)");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.InsertCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
adapter.InsertCommand.Parameters.Add("@CourseSubject_Name", SqlDbType.NVarChar, 0, "CourseSubject_Name");
adapter.InsertCommand.Parameters.Add("@CourseSubject_CreatedBy", SqlDbType.NVarChar, 0, "CourseSubject_CreatedBy");
adapter.InsertCommand.Parameters.Add("@CourseSubject_UpdatedBy", SqlDbType.NVarChar, 0, "CourseSubject_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@CourseSubject_CreatedDate", SqlDbType.DateTime, 0, "CourseSubject_CreatedDate");
adapter.InsertCommand.Parameters.Add("@CourseSubject_UpdatedDate", SqlDbType.DateTime, 0, "CourseSubject_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@CourseSubject_Code", SqlDbType.NVarChar, 0, "CourseSubject_Code");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [CourseSubject] SET [Course_ID] = @Course_ID, [CourseSubject_ID] = @CourseSubject_ID, [CourseSubject_Name] = @CourseSubject_Name, [CourseSubject_CreatedBy] = @CourseSubject_CreatedBy, [CourseSubject_UpdatedBy] = @CourseSubject_UpdatedBy, [CourseSubject_CreatedDate] = @CourseSubject_CreatedDate, [CourseSubject_UpdatedDate] = @CourseSubject_UpdatedDate, [CourseSubject_Code] = @CourseSubject_Code WHERE [CourseSubject_ID] = @o_CourseSubject_ID");
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CourseSubject_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@CourseSubject_Name", SqlDbType.NVarChar, 0, "CourseSubject_Name");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_CreatedBy", SqlDbType.NVarChar, 0, "CourseSubject_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_UpdatedBy", SqlDbType.NVarChar, 0, "CourseSubject_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_CreatedDate", SqlDbType.DateTime, 0, "CourseSubject_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_UpdatedDate", SqlDbType.DateTime, 0, "CourseSubject_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_Code", SqlDbType.NVarChar, 0, "CourseSubject_Code");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [CourseSubject] WHERE [CourseSubject_ID] = @o_CourseSubject_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CourseSubject_ID", DataRowVersion.Original, null));
}
public void Update(CourseSubjectTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CourseSubjectRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CourseSubjectRow GetByCourseSubject_ID(System.Guid CourseSubject_ID ) {
string sql = "SELECT * FROM [CourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);

CourseSubjectTable tbl = new CourseSubjectTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCourseSubjectRow(0);
}
public int CountByCourseSubject_ID(System.Guid CourseSubject_ID ) {
string sql = "SELECT COUNT(*) FROM [CourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCourseSubject_ID(System.Guid CourseSubject_ID, IActivityLog log ) {
string sql = "DELETE FROM [CourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public CourseSubjectTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CourseSubject] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
CourseSubjectTable tbl = new CourseSubjectTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CourseSubject] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CourseSubject] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
