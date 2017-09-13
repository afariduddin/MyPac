using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class ApplicationCourseSubjectTable : DataTable {
// column indexes
public const int ApplicationCourseSubject_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int CourseSubject_IDColumnIndex = 2;
public ApplicationCourseSubjectTable() {
TableName = "[ApplicationCourseSubject]";
// column ApplicationCourseSubject_ID
DataColumn ApplicationCourseSubject_IDCol = new DataColumn("ApplicationCourseSubject_ID", typeof(System.Guid));
ApplicationCourseSubject_IDCol.ReadOnly = false;
ApplicationCourseSubject_IDCol.AllowDBNull = false;
Columns.Add(ApplicationCourseSubject_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column CourseSubject_ID
DataColumn CourseSubject_IDCol = new DataColumn("CourseSubject_ID", typeof(System.Guid));
CourseSubject_IDCol.ReadOnly = false;
CourseSubject_IDCol.AllowDBNull = false;
Columns.Add(CourseSubject_IDCol);
}
public ApplicationCourseSubjectRow NewApplicationCourseSubjectRow() {
ApplicationCourseSubjectRow row = (ApplicationCourseSubjectRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(ApplicationCourseSubjectRow row) {
row.ApplicationCourseSubject_ID = Guid.Empty;
row.Application_ID = Guid.Empty;
row.CourseSubject_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new ApplicationCourseSubjectRow(builder);
}
public ApplicationCourseSubjectRow GetApplicationCourseSubjectRow(int index) {
return (ApplicationCourseSubjectRow)Rows[index];
}
}
public partial class ApplicationCourseSubjectRow : DataRow {
internal ApplicationCourseSubjectRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid ApplicationCourseSubject_ID {
get {
return (System.Guid)this["ApplicationCourseSubject_ID"];
}
set {
this["ApplicationCourseSubject_ID"] = value;
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
public System.Guid CourseSubject_ID {
get {
return (System.Guid)this["CourseSubject_ID"];
}
set {
this["CourseSubject_ID"] = value;
}
}
}
public partial class ApplicationCourseSubjectMinimalizedEntity {
public ApplicationCourseSubjectMinimalizedEntity() {}
public ApplicationCourseSubjectMinimalizedEntity(ApplicationCourseSubjectRow dr) {
this.ApplicationCourseSubject_ID = dr.ApplicationCourseSubject_ID;
this.Application_ID = dr.Application_ID;
this.CourseSubject_ID = dr.CourseSubject_ID;
}
public void CopyTo(ApplicationCourseSubjectRow dr) {
dr.ApplicationCourseSubject_ID = this.ApplicationCourseSubject_ID;
dr.Application_ID = this.Application_ID;
dr.CourseSubject_ID = this.CourseSubject_ID;
}
public System.Guid ApplicationCourseSubject_ID;
public System.Guid Application_ID;
public System.Guid CourseSubject_ID;
}
public partial class ApplicationCourseSubjectAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public ApplicationCourseSubjectAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("ApplicationCourseSubject_ID", "ApplicationCourseSubject_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("CourseSubject_ID", "CourseSubject_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [ApplicationCourseSubject] ([ApplicationCourseSubject_ID], [Application_ID], [CourseSubject_ID]) VALUES (@ApplicationCourseSubject_ID, @Application_ID, @CourseSubject_ID)");
adapter.InsertCommand.Parameters.Add("@ApplicationCourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "ApplicationCourseSubject_ID");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [ApplicationCourseSubject] SET [ApplicationCourseSubject_ID] = @ApplicationCourseSubject_ID, [Application_ID] = @Application_ID, [CourseSubject_ID] = @CourseSubject_ID WHERE [ApplicationCourseSubject_ID] = @o_ApplicationCourseSubject_ID");
adapter.UpdateCommand.Parameters.Add("@ApplicationCourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "ApplicationCourseSubject_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_ApplicationCourseSubject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ApplicationCourseSubject_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@CourseSubject_ID", SqlDbType.UniqueIdentifier, 0, "CourseSubject_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [ApplicationCourseSubject] WHERE [ApplicationCourseSubject_ID] = @o_ApplicationCourseSubject_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_ApplicationCourseSubject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ApplicationCourseSubject_ID", DataRowVersion.Original, null));
}
public void Update(ApplicationCourseSubjectTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(ApplicationCourseSubjectRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public ApplicationCourseSubjectRow GetByApplicationCourseSubject_ID(System.Guid ApplicationCourseSubject_ID ) {
string sql = "SELECT * FROM [ApplicationCourseSubject] WHERE [ApplicationCourseSubject_ID] = @ApplicationCourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ApplicationCourseSubject_ID", ApplicationCourseSubject_ID);

ApplicationCourseSubjectTable tbl = new ApplicationCourseSubjectTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetApplicationCourseSubjectRow(0);
}
public int CountByApplicationCourseSubject_ID(System.Guid ApplicationCourseSubject_ID ) {
string sql = "SELECT COUNT(*) FROM [ApplicationCourseSubject] WHERE [ApplicationCourseSubject_ID] = @ApplicationCourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ApplicationCourseSubject_ID", ApplicationCourseSubject_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByApplicationCourseSubject_ID(System.Guid ApplicationCourseSubject_ID, IActivityLog log ) {
string sql = "DELETE FROM [ApplicationCourseSubject] WHERE [ApplicationCourseSubject_ID] = @ApplicationCourseSubject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ApplicationCourseSubject_ID", ApplicationCourseSubject_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public ApplicationCourseSubjectTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [ApplicationCourseSubject] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
ApplicationCourseSubjectTable tbl = new ApplicationCourseSubjectTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [ApplicationCourseSubject] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [ApplicationCourseSubject] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public ApplicationCourseSubjectTable GetByCourseSubject_ID(System.Guid CourseSubject_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [ApplicationCourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
ApplicationCourseSubjectTable tbl = new ApplicationCourseSubjectTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourseSubject_ID(System.Guid CourseSubject_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [ApplicationCourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourseSubject_ID(System.Guid CourseSubject_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [ApplicationCourseSubject] WHERE [CourseSubject_ID] = @CourseSubject_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("CourseSubject_ID", CourseSubject_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
