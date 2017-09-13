using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class ActivityLogTransactionTable : DataTable {
// column indexes
public const int ActivityLogTransaction_IDColumnIndex = 0;
public const int ActivityLog_IDColumnIndex = 1;
public const int DescriptionColumnIndex = 2;
public ActivityLogTransactionTable() {
TableName = "[ActivityLogTransaction]";
// column ActivityLogTransaction_ID
DataColumn ActivityLogTransaction_IDCol = new DataColumn("ActivityLogTransaction_ID", typeof(System.Guid));
ActivityLogTransaction_IDCol.ReadOnly = false;
ActivityLogTransaction_IDCol.AllowDBNull = false;
Columns.Add(ActivityLogTransaction_IDCol);
// column ActivityLog_ID
DataColumn ActivityLog_IDCol = new DataColumn("ActivityLog_ID", typeof(System.Guid));
ActivityLog_IDCol.ReadOnly = false;
ActivityLog_IDCol.AllowDBNull = false;
Columns.Add(ActivityLog_IDCol);
// column Description
DataColumn DescriptionCol = new DataColumn("Description", typeof(System.String));
DescriptionCol.ReadOnly = false;
DescriptionCol.AllowDBNull = false;
Columns.Add(DescriptionCol);
}
public ActivityLogTransactionRow NewActivityLogTransactionRow() {
ActivityLogTransactionRow row = (ActivityLogTransactionRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(ActivityLogTransactionRow row) {
row.ActivityLogTransaction_ID = Guid.Empty;
row.ActivityLog_ID = Guid.Empty;
row.Description = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new ActivityLogTransactionRow(builder);
}
public ActivityLogTransactionRow GetActivityLogTransactionRow(int index) {
return (ActivityLogTransactionRow)Rows[index];
}
}
public partial class ActivityLogTransactionRow : DataRow {
internal ActivityLogTransactionRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid ActivityLogTransaction_ID {
get {
return (System.Guid)this["ActivityLogTransaction_ID"];
}
set {
this["ActivityLogTransaction_ID"] = value;
}
}
public System.Guid ActivityLog_ID {
get {
return (System.Guid)this["ActivityLog_ID"];
}
set {
this["ActivityLog_ID"] = value;
}
}
public System.String Description {
get {
return (System.String)this["Description"];
}
set {
if( value.Length > 500 ) this["Description"] = value.Substring(0, 500);
else this["Description"] = value;
}
}
}
public partial class ActivityLogTransactionMinimalizedEntity {
public ActivityLogTransactionMinimalizedEntity() {}
public ActivityLogTransactionMinimalizedEntity(ActivityLogTransactionRow dr) {
this.ActivityLogTransaction_ID = dr.ActivityLogTransaction_ID;
this.ActivityLog_ID = dr.ActivityLog_ID;
this.Description = dr.Description;
}
public void CopyTo(ActivityLogTransactionRow dr) {
dr.ActivityLogTransaction_ID = this.ActivityLogTransaction_ID;
dr.ActivityLog_ID = this.ActivityLog_ID;
dr.Description = this.Description;
}
public System.Guid ActivityLogTransaction_ID;
public System.Guid ActivityLog_ID;
public System.String Description;
}
public partial class ActivityLogTransactionAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public ActivityLogTransactionAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("ActivityLogTransaction_ID", "ActivityLogTransaction_ID");
tmap.ColumnMappings.Add("ActivityLog_ID", "ActivityLog_ID");
tmap.ColumnMappings.Add("Description", "Description");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [ActivityLogTransaction] ([ActivityLogTransaction_ID], [ActivityLog_ID], [Description]) VALUES (@ActivityLogTransaction_ID, @ActivityLog_ID, @Description)");
adapter.InsertCommand.Parameters.Add("@ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogTransaction_ID");
adapter.InsertCommand.Parameters.Add("@ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLog_ID");
adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 0, "Description");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [ActivityLogTransaction] SET [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID, [ActivityLog_ID] = @ActivityLog_ID, [Description] = @Description WHERE [ActivityLogTransaction_ID] = @o_ActivityLogTransaction_ID");
adapter.UpdateCommand.Parameters.Add("@ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogTransaction_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLogTransaction_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@ActivityLog_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLog_ID");
adapter.UpdateCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 0, "Description");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [ActivityLogTransaction] WHERE [ActivityLogTransaction_ID] = @o_ActivityLogTransaction_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLogTransaction_ID", DataRowVersion.Original, null));
}
public void Update(ActivityLogTransactionTable tbl) {
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(ActivityLogTransactionRow dr) {
 DA.ExecuteAdapter(Adapter, dr);
}
public ActivityLogTransactionRow GetByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
string sql = "SELECT * FROM [ActivityLogTransaction] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);

ActivityLogTransactionTable tbl = new ActivityLogTransactionTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetActivityLogTransactionRow(0);
}
public int CountByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
string sql = "SELECT COUNT(*) FROM [ActivityLogTransaction] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
string sql = "DELETE FROM [ActivityLogTransaction] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);

return DA.ExecuteNonQuery(com);
}
public ActivityLogTransactionTable GetByActivityLog_ID(System.Guid ActivityLog_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [ActivityLogTransaction] WHERE [ActivityLog_ID] = @ActivityLog_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);
ActivityLogTransactionTable tbl = new ActivityLogTransactionTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByActivityLog_ID(System.Guid ActivityLog_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [ActivityLogTransaction] WHERE [ActivityLog_ID] = @ActivityLog_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByActivityLog_ID(System.Guid ActivityLog_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [ActivityLogTransaction] WHERE [ActivityLog_ID] = @ActivityLog_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLog_ID", ActivityLog_ID);
return DA.ExecuteNonQuery(fcom);
}
}
}
