using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class ActivityLogTable : DataTable {
// column indexes
public const int ActivityLog_IDColumnIndex = 0;
public const int ActivityLog_UserNameColumnIndex = 1;
public const int ActivityLog_DateTimeColumnIndex = 2;
public const int ActivityLog_DescriptionColumnIndex = 3;
public const int ActivityLog_IPAddressColumnIndex = 4;
public ActivityLogTable() {
TableName = "[ActivityLog]";
// column ActivityLog_ID
DataColumn ActivityLog_IDCol = new DataColumn("ActivityLog_ID", typeof(System.Guid));
ActivityLog_IDCol.ReadOnly = false;
ActivityLog_IDCol.AllowDBNull = false;
Columns.Add(ActivityLog_IDCol);
// column ActivityLog_UserName
DataColumn ActivityLog_UserNameCol = new DataColumn("ActivityLog_UserName", typeof(System.String));
ActivityLog_UserNameCol.ReadOnly = false;
ActivityLog_UserNameCol.AllowDBNull = false;
Columns.Add(ActivityLog_UserNameCol);
// column ActivityLog_DateTime
DataColumn ActivityLog_DateTimeCol = new DataColumn("ActivityLog_DateTime", typeof(System.DateTime));
ActivityLog_DateTimeCol.DateTimeMode = DataSetDateTime.Local;
ActivityLog_DateTimeCol.ReadOnly = false;
ActivityLog_DateTimeCol.AllowDBNull = false;
Columns.Add(ActivityLog_DateTimeCol);
// column ActivityLog_Description
DataColumn ActivityLog_DescriptionCol = new DataColumn("ActivityLog_Description", typeof(System.String));
ActivityLog_DescriptionCol.ReadOnly = false;
ActivityLog_DescriptionCol.AllowDBNull = false;
Columns.Add(ActivityLog_DescriptionCol);
// column ActivityLog_IPAddress
DataColumn ActivityLog_IPAddressCol = new DataColumn("ActivityLog_IPAddress", typeof(System.String));
ActivityLog_IPAddressCol.ReadOnly = false;
ActivityLog_IPAddressCol.AllowDBNull = false;
Columns.Add(ActivityLog_IPAddressCol);
}
public ActivityLogRow NewActivityLogRow() {
ActivityLogRow row = (ActivityLogRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(ActivityLogRow row) {
row.ActivityLog_ID = Guid.Empty;
row.ActivityLog_UserName = "";
row.ActivityLog_DateTime = DateTime.Now;
row.ActivityLog_Description = "";
row.ActivityLog_IPAddress = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new ActivityLogRow(builder);
}
public ActivityLogRow GetActivityLogRow(int index) {
return (ActivityLogRow)Rows[index];
}
}
public partial class ActivityLogRow : DataRow {
internal ActivityLogRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid ActivityLog_ID {
get {
return (System.Guid)this["ActivityLog_ID"];
}
set {
this["ActivityLog_ID"] = value;
}
}
public System.String ActivityLog_UserName {
get {
return (System.String)this["ActivityLog_UserName"];
}
set {
if( value.Length > 50 ) this["ActivityLog_UserName"] = value.Substring(0, 50);
else this["ActivityLog_UserName"] = value;
}
}
public System.DateTime ActivityLog_DateTime {
get {
return (System.DateTime)this["ActivityLog_DateTime"];
}
set {
this["ActivityLog_DateTime"] = value;
}
}
public System.String ActivityLog_Description {
get {
return (System.String)this["ActivityLog_Description"];
}
set {
if( value.Length > 500 ) this["ActivityLog_Description"] = value.Substring(0, 500);
else this["ActivityLog_Description"] = value;
}
}
public System.String ActivityLog_IPAddress {
get {
return (System.String)this["ActivityLog_IPAddress"];
}
set {
if( value.Length > 50 ) this["ActivityLog_IPAddress"] = value.Substring(0, 50);
else this["ActivityLog_IPAddress"] = value;
}
}
}
public partial class ActivityLogMinimalizedEntity {
public ActivityLogMinimalizedEntity() {}
public ActivityLogMinimalizedEntity(ActivityLogRow dr) {
this.ActivityLog_ID = dr.ActivityLog_ID;
this.ActivityLog_UserName = dr.ActivityLog_UserName;
this.ActivityLog_DateTime = dr.ActivityLog_DateTime;
this.ActivityLog_Description = dr.ActivityLog_Description;
this.ActivityLog_IPAddress = dr.ActivityLog_IPAddress;
}
public void CopyTo(ActivityLogRow dr) {
dr.ActivityLog_ID = this.ActivityLog_ID;
dr.ActivityLog_UserName = this.ActivityLog_UserName;
dr.ActivityLog_DateTime = this.ActivityLog_DateTime;
dr.ActivityLog_Description = this.ActivityLog_Description;
dr.ActivityLog_IPAddress = this.ActivityLog_IPAddress;
}
public System.Guid ActivityLog_ID;
public System.String ActivityLog_UserName;
public System.DateTime ActivityLog_DateTime;
public System.String ActivityLog_Description;
public System.String ActivityLog_IPAddress;
}
public partial class ActivityLogAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public ActivityLogAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("ActivityLog_ID", "ActivityLog_ID");
tmap.ColumnMappings.Add("ActivityLog_UserName", "ActivityLog_UserName");
tmap.ColumnMappings.Add("ActivityLog_DateTime", "ActivityLog_DateTime");
tmap.ColumnMappings.Add("ActivityLog_Description", "ActivityLog_Description");
tmap.ColumnMappings.Add("ActivityLog_IPAddress", "ActivityLog_IPAddress");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [ActivityLog] ([ActivityLog_ID], [ActivityLog_UserName], [ActivityLog_DateTime], [ActivityLog_Description], [ActivityLog_IPAddress]) VALUES (@ActivityLog_ID, @ActivityLog_UserName, @ActivityLog_DateTime, @ActivityLog_Description, @ActivityLog_IPAddress)");
adapter.InsertCommand.Parameters.Add("@ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLog_ID");
adapter.InsertCommand.Parameters.Add("@ActivityLog_UserName", SqlDbType.NVarChar, 0, "ActivityLog_UserName");
adapter.InsertCommand.Parameters.Add("@ActivityLog_DateTime", SqlDbType.DateTime, 0, "ActivityLog_DateTime");
adapter.InsertCommand.Parameters.Add("@ActivityLog_Description", SqlDbType.NVarChar, 0, "ActivityLog_Description");
adapter.InsertCommand.Parameters.Add("@ActivityLog_IPAddress", SqlDbType.NVarChar, 0, "ActivityLog_IPAddress");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [ActivityLog] SET [ActivityLog_ID] = @ActivityLog_ID, [ActivityLog_UserName] = @ActivityLog_UserName, [ActivityLog_DateTime] = @ActivityLog_DateTime, [ActivityLog_Description] = @ActivityLog_Description, [ActivityLog_IPAddress] = @ActivityLog_IPAddress WHERE [ActivityLog_ID] = @o_ActivityLog_ID");
adapter.UpdateCommand.Parameters.Add("@ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLog_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLog_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@ActivityLog_UserName", SqlDbType.NVarChar, 0, "ActivityLog_UserName");
adapter.UpdateCommand.Parameters.Add("@ActivityLog_DateTime", SqlDbType.DateTime, 0, "ActivityLog_DateTime");
adapter.UpdateCommand.Parameters.Add("@ActivityLog_Description", SqlDbType.NVarChar, 0, "ActivityLog_Description");
adapter.UpdateCommand.Parameters.Add("@ActivityLog_IPAddress", SqlDbType.NVarChar, 0, "ActivityLog_IPAddress");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [ActivityLog] WHERE [ActivityLog_ID] = @o_ActivityLog_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLog_ID", DataRowVersion.Original, null));
}
public void Update(ActivityLogTable tbl) {
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(ActivityLogRow dr) {
 DA.ExecuteAdapter(Adapter, dr);
}
public ActivityLogRow GetByActivityLog_ID(System.Guid ActivityLog_ID ) {
string sql = "SELECT * FROM [ActivityLog] WHERE [ActivityLog_ID] = @ActivityLog_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);

ActivityLogTable tbl = new ActivityLogTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetActivityLogRow(0);
}
public int CountByActivityLog_ID(System.Guid ActivityLog_ID ) {
string sql = "SELECT COUNT(*) FROM [ActivityLog] WHERE [ActivityLog_ID] = @ActivityLog_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByActivityLog_ID(System.Guid ActivityLog_ID ) {
string sql = "DELETE FROM [ActivityLog] WHERE [ActivityLog_ID] = @ActivityLog_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);

return DA.ExecuteNonQuery(com);
}
}
}
