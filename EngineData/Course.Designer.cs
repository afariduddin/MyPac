using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CourseTable : DataTable {
// column indexes
public const int Course_IDColumnIndex = 0;
public const int Course_CodeColumnIndex = 1;
public const int Course_NameColumnIndex = 2;
public const int Course_ApplicableForApplyColumnIndex = 3;
public const int Course_RemarkColumnIndex = 4;
public const int Course_IsDeletedColumnIndex = 5;
public const int Course_CreatedDateColumnIndex = 6;
public const int Course_CreatedByColumnIndex = 7;
public const int Course_UpdatedDateColumnIndex = 8;
public const int Course_UpdatedByColumnIndex = 9;
public CourseTable() {
TableName = "[Course]";
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Course_Code
DataColumn Course_CodeCol = new DataColumn("Course_Code", typeof(System.String));
Course_CodeCol.ReadOnly = false;
Course_CodeCol.AllowDBNull = false;
Columns.Add(Course_CodeCol);
// column Course_Name
DataColumn Course_NameCol = new DataColumn("Course_Name", typeof(System.String));
Course_NameCol.ReadOnly = false;
Course_NameCol.AllowDBNull = false;
Columns.Add(Course_NameCol);
// column Course_ApplicableForApply
DataColumn Course_ApplicableForApplyCol = new DataColumn("Course_ApplicableForApply", typeof(System.Boolean));
Course_ApplicableForApplyCol.ReadOnly = false;
Course_ApplicableForApplyCol.AllowDBNull = false;
Columns.Add(Course_ApplicableForApplyCol);
// column Course_Remark
DataColumn Course_RemarkCol = new DataColumn("Course_Remark", typeof(System.String));
Course_RemarkCol.ReadOnly = false;
Course_RemarkCol.AllowDBNull = false;
Columns.Add(Course_RemarkCol);
// column Course_IsDeleted
DataColumn Course_IsDeletedCol = new DataColumn("Course_IsDeleted", typeof(System.Boolean));
Course_IsDeletedCol.ReadOnly = false;
Course_IsDeletedCol.AllowDBNull = false;
Columns.Add(Course_IsDeletedCol);
// column Course_CreatedDate
DataColumn Course_CreatedDateCol = new DataColumn("Course_CreatedDate", typeof(System.DateTime));
Course_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Course_CreatedDateCol.ReadOnly = false;
Course_CreatedDateCol.AllowDBNull = false;
Columns.Add(Course_CreatedDateCol);
// column Course_CreatedBy
DataColumn Course_CreatedByCol = new DataColumn("Course_CreatedBy", typeof(System.String));
Course_CreatedByCol.ReadOnly = false;
Course_CreatedByCol.AllowDBNull = false;
Columns.Add(Course_CreatedByCol);
// column Course_UpdatedDate
DataColumn Course_UpdatedDateCol = new DataColumn("Course_UpdatedDate", typeof(System.DateTime));
Course_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Course_UpdatedDateCol.ReadOnly = false;
Course_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Course_UpdatedDateCol);
// column Course_UpdatedBy
DataColumn Course_UpdatedByCol = new DataColumn("Course_UpdatedBy", typeof(System.String));
Course_UpdatedByCol.ReadOnly = false;
Course_UpdatedByCol.AllowDBNull = false;
Columns.Add(Course_UpdatedByCol);
}
public CourseRow NewCourseRow() {
CourseRow row = (CourseRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CourseRow row) {
row.Course_ID = Guid.Empty;
row.Course_Code = "";
row.Course_Name = "";
row.Course_ApplicableForApply = false;
row.Course_Remark = "";
row.Course_IsDeleted = false;
row.Course_CreatedDate = DateTime.Now;
row.Course_CreatedBy = "";
row.Course_UpdatedDate = DateTime.Now;
row.Course_UpdatedBy = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CourseRow(builder);
}
public CourseRow GetCourseRow(int index) {
return (CourseRow)Rows[index];
}
}
public partial class CourseRow : DataRow {
internal CourseRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
set {
this["Course_ID"] = value;
}
}
public System.String Course_Code {
get {
return (System.String)this["Course_Code"];
}
set {
if( value.Length > 50 ) this["Course_Code"] = value.Substring(0, 50);
else this["Course_Code"] = value;
}
}
public System.String Course_Name {
get {
return (System.String)this["Course_Name"];
}
set {
if( value.Length > 50 ) this["Course_Name"] = value.Substring(0, 50);
else this["Course_Name"] = value;
}
}
public System.Boolean Course_ApplicableForApply {
get {
return (System.Boolean)this["Course_ApplicableForApply"];
}
set {
this["Course_ApplicableForApply"] = value;
}
}
public System.String Course_Remark {
get {
return (System.String)this["Course_Remark"];
}
set {
if( value.Length > 1000 ) this["Course_Remark"] = value.Substring(0, 1000);
else this["Course_Remark"] = value;
}
}
public System.Boolean Course_IsDeleted {
get {
return (System.Boolean)this["Course_IsDeleted"];
}
set {
this["Course_IsDeleted"] = value;
}
}
public System.DateTime Course_CreatedDate {
get {
return (System.DateTime)this["Course_CreatedDate"];
}
set {
this["Course_CreatedDate"] = value;
}
}
public System.String Course_CreatedBy {
get {
return (System.String)this["Course_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Course_CreatedBy"] = value.Substring(0, 50);
else this["Course_CreatedBy"] = value;
}
}
public System.DateTime Course_UpdatedDate {
get {
return (System.DateTime)this["Course_UpdatedDate"];
}
set {
this["Course_UpdatedDate"] = value;
}
}
public System.String Course_UpdatedBy {
get {
return (System.String)this["Course_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Course_UpdatedBy"] = value.Substring(0, 50);
else this["Course_UpdatedBy"] = value;
}
}
}
public partial class CourseMinimalizedEntity {
public CourseMinimalizedEntity() {}
public CourseMinimalizedEntity(CourseRow dr) {
this.Course_ID = dr.Course_ID;
this.Course_Code = dr.Course_Code;
this.Course_Name = dr.Course_Name;
this.Course_ApplicableForApply = dr.Course_ApplicableForApply;
this.Course_Remark = dr.Course_Remark;
this.Course_IsDeleted = dr.Course_IsDeleted;
this.Course_CreatedDate = dr.Course_CreatedDate;
this.Course_CreatedBy = dr.Course_CreatedBy;
this.Course_UpdatedDate = dr.Course_UpdatedDate;
this.Course_UpdatedBy = dr.Course_UpdatedBy;
}
public void CopyTo(CourseRow dr) {
dr.Course_ID = this.Course_ID;
dr.Course_Code = this.Course_Code;
dr.Course_Name = this.Course_Name;
dr.Course_ApplicableForApply = this.Course_ApplicableForApply;
dr.Course_Remark = this.Course_Remark;
dr.Course_IsDeleted = this.Course_IsDeleted;
dr.Course_CreatedDate = this.Course_CreatedDate;
dr.Course_CreatedBy = this.Course_CreatedBy;
dr.Course_UpdatedDate = this.Course_UpdatedDate;
dr.Course_UpdatedBy = this.Course_UpdatedBy;
}
public System.Guid Course_ID;
public System.String Course_Code;
public System.String Course_Name;
public System.Boolean Course_ApplicableForApply;
public System.String Course_Remark;
public System.Boolean Course_IsDeleted;
public System.DateTime Course_CreatedDate;
public System.String Course_CreatedBy;
public System.DateTime Course_UpdatedDate;
public System.String Course_UpdatedBy;
}
public partial class CourseAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CourseAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("Course_Code", "Course_Code");
tmap.ColumnMappings.Add("Course_Name", "Course_Name");
tmap.ColumnMappings.Add("Course_ApplicableForApply", "Course_ApplicableForApply");
tmap.ColumnMappings.Add("Course_Remark", "Course_Remark");
tmap.ColumnMappings.Add("Course_IsDeleted", "Course_IsDeleted");
tmap.ColumnMappings.Add("Course_CreatedDate", "Course_CreatedDate");
tmap.ColumnMappings.Add("Course_CreatedBy", "Course_CreatedBy");
tmap.ColumnMappings.Add("Course_UpdatedDate", "Course_UpdatedDate");
tmap.ColumnMappings.Add("Course_UpdatedBy", "Course_UpdatedBy");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Course] ([Course_ID], [Course_Code], [Course_Name], [Course_ApplicableForApply], [Course_Remark], [Course_IsDeleted], [Course_CreatedDate], [Course_CreatedBy], [Course_UpdatedDate], [Course_UpdatedBy]) VALUES (@Course_ID, @Course_Code, @Course_Name, @Course_ApplicableForApply, @Course_Remark, @Course_IsDeleted, @Course_CreatedDate, @Course_CreatedBy, @Course_UpdatedDate, @Course_UpdatedBy)");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.InsertCommand.Parameters.Add("@Course_Code", SqlDbType.NVarChar, 0, "Course_Code");
adapter.InsertCommand.Parameters.Add("@Course_Name", SqlDbType.NVarChar, 0, "Course_Name");
adapter.InsertCommand.Parameters.Add("@Course_ApplicableForApply", SqlDbType.Bit, 0, "Course_ApplicableForApply");
adapter.InsertCommand.Parameters.Add("@Course_Remark", SqlDbType.NVarChar, 0, "Course_Remark");
adapter.InsertCommand.Parameters.Add("@Course_IsDeleted", SqlDbType.Bit, 0, "Course_IsDeleted");
adapter.InsertCommand.Parameters.Add("@Course_CreatedDate", SqlDbType.DateTime, 0, "Course_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Course_CreatedBy", SqlDbType.NVarChar, 0, "Course_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Course_UpdatedDate", SqlDbType.DateTime, 0, "Course_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Course_UpdatedBy", SqlDbType.NVarChar, 0, "Course_UpdatedBy");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Course] SET [Course_ID] = @Course_ID, [Course_Code] = @Course_Code, [Course_Name] = @Course_Name, [Course_ApplicableForApply] = @Course_ApplicableForApply, [Course_Remark] = @Course_Remark, [Course_IsDeleted] = @Course_IsDeleted, [Course_CreatedDate] = @Course_CreatedDate, [Course_CreatedBy] = @Course_CreatedBy, [Course_UpdatedDate] = @Course_UpdatedDate, [Course_UpdatedBy] = @Course_UpdatedBy WHERE [Course_ID] = @o_Course_ID");
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Course_Code", SqlDbType.NVarChar, 0, "Course_Code");
adapter.UpdateCommand.Parameters.Add("@Course_Name", SqlDbType.NVarChar, 0, "Course_Name");
adapter.UpdateCommand.Parameters.Add("@Course_ApplicableForApply", SqlDbType.Bit, 0, "Course_ApplicableForApply");
adapter.UpdateCommand.Parameters.Add("@Course_Remark", SqlDbType.NVarChar, 0, "Course_Remark");
adapter.UpdateCommand.Parameters.Add("@Course_IsDeleted", SqlDbType.Bit, 0, "Course_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@Course_CreatedDate", SqlDbType.DateTime, 0, "Course_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Course_CreatedBy", SqlDbType.NVarChar, 0, "Course_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Course_UpdatedDate", SqlDbType.DateTime, 0, "Course_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Course_UpdatedBy", SqlDbType.NVarChar, 0, "Course_UpdatedBy");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Course] WHERE [Course_ID] = @o_Course_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
}
public void Update(CourseTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CourseRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CourseRow GetByCourse_ID(System.Guid Course_ID ) {
string sql = "SELECT * FROM [Course] WHERE [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Course_ID", Course_ID);

CourseTable tbl = new CourseTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCourseRow(0);
}
public int CountByCourse_ID(System.Guid Course_ID ) {
string sql = "SELECT COUNT(*) FROM [Course] WHERE [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Course_ID", Course_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
string sql = "DELETE FROM [Course] WHERE [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Course_ID", Course_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
