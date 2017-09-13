using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class ActivityLogColumnTable : DataTable {
// column indexes
public const int ActivityLogColumn_IDColumnIndex = 0;
public const int ActivityLogTransaction_IDColumnIndex = 1;
public const int ActivityLogColumn_ColumnNameColumnIndex = 2;
public const int ActivityLogColumn_OriginalValueColumnIndex = 3;
public const int ActivityLogColumn_NewValueColumnIndex = 4;
public ActivityLogColumnTable() {
TableName = "[ActivityLogColumn]";
// column ActivityLogColumn_ID
DataColumn ActivityLogColumn_IDCol = new DataColumn("ActivityLogColumn_ID", typeof(System.Guid));
ActivityLogColumn_IDCol.ReadOnly = false;
ActivityLogColumn_IDCol.AllowDBNull = false;
Columns.Add(ActivityLogColumn_IDCol);
// column ActivityLogTransaction_ID
DataColumn ActivityLogTransaction_IDCol = new DataColumn("ActivityLogTransaction_ID", typeof(System.Guid));
ActivityLogTransaction_IDCol.ReadOnly = false;
ActivityLogTransaction_IDCol.AllowDBNull = false;
Columns.Add(ActivityLogTransaction_IDCol);
// column ActivityLogColumn_ColumnName
DataColumn ActivityLogColumn_ColumnNameCol = new DataColumn("ActivityLogColumn_ColumnName", typeof(System.String));
ActivityLogColumn_ColumnNameCol.ReadOnly = false;
ActivityLogColumn_ColumnNameCol.AllowDBNull = false;
Columns.Add(ActivityLogColumn_ColumnNameCol);
// column ActivityLogColumn_OriginalValue
DataColumn ActivityLogColumn_OriginalValueCol = new DataColumn("ActivityLogColumn_OriginalValue", typeof(System.String));
ActivityLogColumn_OriginalValueCol.ReadOnly = false;
ActivityLogColumn_OriginalValueCol.AllowDBNull = true;
Columns.Add(ActivityLogColumn_OriginalValueCol);
// column ActivityLogColumn_NewValue
DataColumn ActivityLogColumn_NewValueCol = new DataColumn("ActivityLogColumn_NewValue", typeof(System.String));
ActivityLogColumn_NewValueCol.ReadOnly = false;
ActivityLogColumn_NewValueCol.AllowDBNull = true;
Columns.Add(ActivityLogColumn_NewValueCol);
}
public ActivityLogColumnRow NewActivityLogColumnRow() {
ActivityLogColumnRow row = (ActivityLogColumnRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(ActivityLogColumnRow row) {
row.ActivityLogColumn_ID = Guid.Empty;
row.ActivityLogTransaction_ID = Guid.Empty;
row.ActivityLogColumn_ColumnName = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new ActivityLogColumnRow(builder);
}
public ActivityLogColumnRow GetActivityLogColumnRow(int index) {
return (ActivityLogColumnRow)Rows[index];
}
}
public partial class ActivityLogColumnRow : DataRow {
internal ActivityLogColumnRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid ActivityLogColumn_ID {
get {
return (System.Guid)this["ActivityLogColumn_ID"];
}
set {
this["ActivityLogColumn_ID"] = value;
}
}
public System.Guid ActivityLogTransaction_ID {
get {
return (System.Guid)this["ActivityLogTransaction_ID"];
}
set {
this["ActivityLogTransaction_ID"] = value;
}
}
public System.String ActivityLogColumn_ColumnName {
get {
return (System.String)this["ActivityLogColumn_ColumnName"];
}
set {
if( value.Length > 100 ) this["ActivityLogColumn_ColumnName"] = value.Substring(0, 100);
else this["ActivityLogColumn_ColumnName"] = value;
}
}
public System.String ActivityLogColumn_OriginalValue {
get {
if( IsNull("ActivityLogColumn_OriginalValue") ) return "";
else return (System.String)this["ActivityLogColumn_OriginalValue"];
}
set {
if( string.IsNullOrEmpty(value) ) SetNull(Table.Columns["ActivityLogColumn_OriginalValue"]);
else{
if( value.Length > 1000 ) this["ActivityLogColumn_OriginalValue"] = value.Substring(0, 1000);
else this["ActivityLogColumn_OriginalValue"] = value;
}
}
}
public System.String ActivityLogColumn_NewValue {
get {
if( IsNull("ActivityLogColumn_NewValue") ) return "";
else return (System.String)this["ActivityLogColumn_NewValue"];
}
set {
if( string.IsNullOrEmpty(value) ) SetNull(Table.Columns["ActivityLogColumn_NewValue"]);
else{
if( value.Length > 1000 ) this["ActivityLogColumn_NewValue"] = value.Substring(0, 1000);
else this["ActivityLogColumn_NewValue"] = value;
}
}
}
}
public partial class ActivityLogColumnMinimalizedEntity {
public ActivityLogColumnMinimalizedEntity() {}
public ActivityLogColumnMinimalizedEntity(ActivityLogColumnRow dr) {
this.ActivityLogColumn_ID = dr.ActivityLogColumn_ID;
this.ActivityLogTransaction_ID = dr.ActivityLogTransaction_ID;
this.ActivityLogColumn_ColumnName = dr.ActivityLogColumn_ColumnName;
this.ActivityLogColumn_OriginalValue = dr.ActivityLogColumn_OriginalValue;
this.ActivityLogColumn_NewValue = dr.ActivityLogColumn_NewValue;
}
public void CopyTo(ActivityLogColumnRow dr) {
dr.ActivityLogColumn_ID = this.ActivityLogColumn_ID;
dr.ActivityLogTransaction_ID = this.ActivityLogTransaction_ID;
dr.ActivityLogColumn_ColumnName = this.ActivityLogColumn_ColumnName;
dr.ActivityLogColumn_OriginalValue = this.ActivityLogColumn_OriginalValue;
dr.ActivityLogColumn_NewValue = this.ActivityLogColumn_NewValue;
}
public System.Guid ActivityLogColumn_ID;
public System.Guid ActivityLogTransaction_ID;
public System.String ActivityLogColumn_ColumnName;
public System.String ActivityLogColumn_OriginalValue;
public System.String ActivityLogColumn_NewValue;
}
public partial class ActivityLogColumnAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public ActivityLogColumnAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("ActivityLogColumn_ID", "ActivityLogColumn_ID");
tmap.ColumnMappings.Add("ActivityLogTransaction_ID", "ActivityLogTransaction_ID");
tmap.ColumnMappings.Add("ActivityLogColumn_ColumnName", "ActivityLogColumn_ColumnName");
tmap.ColumnMappings.Add("ActivityLogColumn_OriginalValue", "ActivityLogColumn_OriginalValue");
tmap.ColumnMappings.Add("ActivityLogColumn_NewValue", "ActivityLogColumn_NewValue");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [ActivityLogColumn] ([ActivityLogColumn_ID], [ActivityLogTransaction_ID], [ActivityLogColumn_ColumnName], [ActivityLogColumn_OriginalValue], [ActivityLogColumn_NewValue]) VALUES (@ActivityLogColumn_ID, @ActivityLogTransaction_ID, @ActivityLogColumn_ColumnName, @ActivityLogColumn_OriginalValue, @ActivityLogColumn_NewValue)");
adapter.InsertCommand.Parameters.Add("@ActivityLogColumn_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogColumn_ID");
adapter.InsertCommand.Parameters.Add("@ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogTransaction_ID");
adapter.InsertCommand.Parameters.Add("@ActivityLogColumn_ColumnName", SqlDbType.NVarChar, 0, "ActivityLogColumn_ColumnName");
adapter.InsertCommand.Parameters.Add("@ActivityLogColumn_OriginalValue", SqlDbType.NVarChar, 0, "ActivityLogColumn_OriginalValue");
adapter.InsertCommand.Parameters.Add("@ActivityLogColumn_NewValue", SqlDbType.NVarChar, 0, "ActivityLogColumn_NewValue");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [ActivityLogColumn] SET [ActivityLogColumn_ID] = @ActivityLogColumn_ID, [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID, [ActivityLogColumn_ColumnName] = @ActivityLogColumn_ColumnName, [ActivityLogColumn_OriginalValue] = @ActivityLogColumn_OriginalValue, [ActivityLogColumn_NewValue] = @ActivityLogColumn_NewValue WHERE [ActivityLogColumn_ID] = @o_ActivityLogColumn_ID");
adapter.UpdateCommand.Parameters.Add("@ActivityLogColumn_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogColumn_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_ActivityLogColumn_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLogColumn_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@ActivityLogTransaction_ID", SqlDbType.UniqueIdentifier, 0, "ActivityLogTransaction_ID");
adapter.UpdateCommand.Parameters.Add("@ActivityLogColumn_ColumnName", SqlDbType.NVarChar, 0, "ActivityLogColumn_ColumnName");
adapter.UpdateCommand.Parameters.Add("@ActivityLogColumn_OriginalValue", SqlDbType.NVarChar, 0, "ActivityLogColumn_OriginalValue");
adapter.UpdateCommand.Parameters.Add("@ActivityLogColumn_NewValue", SqlDbType.NVarChar, 0, "ActivityLogColumn_NewValue");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [ActivityLogColumn] WHERE [ActivityLogColumn_ID] = @o_ActivityLogColumn_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_ActivityLogColumn_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "ActivityLogColumn_ID", DataRowVersion.Original, null));
}
public void Update(ActivityLogColumnTable tbl) {
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(ActivityLogColumnRow dr) {
 DA.ExecuteAdapter(Adapter, dr);
}
public ActivityLogColumnRow GetByActivityLogColumn_ID(System.Guid ActivityLogColumn_ID ) {
string sql = "SELECT * FROM [ActivityLogColumn] WHERE [ActivityLogColumn_ID] = @ActivityLogColumn_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogColumn_ID", ActivityLogColumn_ID);

ActivityLogColumnTable tbl = new ActivityLogColumnTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetActivityLogColumnRow(0);
}
public int CountByActivityLogColumn_ID(System.Guid ActivityLogColumn_ID ) {
string sql = "SELECT COUNT(*) FROM [ActivityLogColumn] WHERE [ActivityLogColumn_ID] = @ActivityLogColumn_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogColumn_ID", ActivityLogColumn_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByActivityLogColumn_ID(System.Guid ActivityLogColumn_ID ) {
string sql = "DELETE FROM [ActivityLogColumn] WHERE [ActivityLogColumn_ID] = @ActivityLogColumn_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("ActivityLogColumn_ID", ActivityLogColumn_ID);

return DA.ExecuteNonQuery(com);
}
public ActivityLogColumnTable GetByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [ActivityLogColumn] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);
ActivityLogColumnTable tbl = new ActivityLogColumnTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [ActivityLogColumn] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByActivityLogTransaction_ID(System.Guid ActivityLogTransaction_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [ActivityLogColumn] WHERE [ActivityLogTransaction_ID] = @ActivityLogTransaction_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("ActivityLogTransaction_ID", ActivityLogTransaction_ID);
return DA.ExecuteNonQuery(fcom);
}
}
}
