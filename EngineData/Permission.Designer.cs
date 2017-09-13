using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PermissionTable : DataTable {
// column indexes
public const int Permission_IDColumnIndex = 0;
public const int Permission_TypeColumnIndex = 1;
public const int Permission_IsCheckedColumnIndex = 2;
public const int Permission_CreatedDateColumnIndex = 3;
public const int Permission_CreatedByColumnIndex = 4;
public const int Permission_UpdatedDateColumnIndex = 5;
public const int Permission_UpdatedByColumnIndex = 6;
public const int UserGroup_IDColumnIndex = 7;
public PermissionTable() {
TableName = "[Permission]";
// column Permission_ID
DataColumn Permission_IDCol = new DataColumn("Permission_ID", typeof(System.Guid));
Permission_IDCol.ReadOnly = false;
Permission_IDCol.AllowDBNull = false;
Columns.Add(Permission_IDCol);
// column Permission_Type
DataColumn Permission_TypeCol = new DataColumn("Permission_Type", typeof(System.Int16));
Permission_TypeCol.ReadOnly = false;
Permission_TypeCol.AllowDBNull = false;
Columns.Add(Permission_TypeCol);
// column Permission_IsChecked
DataColumn Permission_IsCheckedCol = new DataColumn("Permission_IsChecked", typeof(System.Boolean));
Permission_IsCheckedCol.ReadOnly = false;
Permission_IsCheckedCol.AllowDBNull = false;
Columns.Add(Permission_IsCheckedCol);
// column Permission_CreatedDate
DataColumn Permission_CreatedDateCol = new DataColumn("Permission_CreatedDate", typeof(System.DateTime));
Permission_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Permission_CreatedDateCol.ReadOnly = false;
Permission_CreatedDateCol.AllowDBNull = false;
Columns.Add(Permission_CreatedDateCol);
// column Permission_CreatedBy
DataColumn Permission_CreatedByCol = new DataColumn("Permission_CreatedBy", typeof(System.String));
Permission_CreatedByCol.ReadOnly = false;
Permission_CreatedByCol.AllowDBNull = false;
Columns.Add(Permission_CreatedByCol);
// column Permission_UpdatedDate
DataColumn Permission_UpdatedDateCol = new DataColumn("Permission_UpdatedDate", typeof(System.DateTime));
Permission_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Permission_UpdatedDateCol.ReadOnly = false;
Permission_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Permission_UpdatedDateCol);
// column Permission_UpdatedBy
DataColumn Permission_UpdatedByCol = new DataColumn("Permission_UpdatedBy", typeof(System.String));
Permission_UpdatedByCol.ReadOnly = false;
Permission_UpdatedByCol.AllowDBNull = false;
Columns.Add(Permission_UpdatedByCol);
// column UserGroup_ID
DataColumn UserGroup_IDCol = new DataColumn("UserGroup_ID", typeof(System.Guid));
UserGroup_IDCol.ReadOnly = false;
UserGroup_IDCol.AllowDBNull = false;
Columns.Add(UserGroup_IDCol);
}
public PermissionRow NewPermissionRow() {
PermissionRow row = (PermissionRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(PermissionRow row) {
row.Permission_ID = Guid.Empty;
row.Permission_Type = 0;
row.Permission_IsChecked = false;
row.Permission_CreatedDate = DateTime.Now;
row.Permission_CreatedBy = "";
row.Permission_UpdatedDate = DateTime.Now;
row.Permission_UpdatedBy = "";
row.UserGroup_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PermissionRow(builder);
}
public PermissionRow GetPermissionRow(int index) {
return (PermissionRow)Rows[index];
}
}
public partial class PermissionRow : DataRow {
internal PermissionRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Permission_ID {
get {
return (System.Guid)this["Permission_ID"];
}
set {
this["Permission_ID"] = value;
}
}
public System.Int16 Permission_Type {
get {
return (System.Int16)this["Permission_Type"];
}
set {
this["Permission_Type"] = value;
}
}
public System.Boolean Permission_IsChecked {
get {
return (System.Boolean)this["Permission_IsChecked"];
}
set {
this["Permission_IsChecked"] = value;
}
}
public System.DateTime Permission_CreatedDate {
get {
return (System.DateTime)this["Permission_CreatedDate"];
}
set {
this["Permission_CreatedDate"] = value;
}
}
public System.String Permission_CreatedBy {
get {
return (System.String)this["Permission_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Permission_CreatedBy"] = value.Substring(0, 50);
else this["Permission_CreatedBy"] = value;
}
}
public System.DateTime Permission_UpdatedDate {
get {
return (System.DateTime)this["Permission_UpdatedDate"];
}
set {
this["Permission_UpdatedDate"] = value;
}
}
public System.String Permission_UpdatedBy {
get {
return (System.String)this["Permission_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Permission_UpdatedBy"] = value.Substring(0, 50);
else this["Permission_UpdatedBy"] = value;
}
}
public System.Guid UserGroup_ID {
get {
return (System.Guid)this["UserGroup_ID"];
}
set {
this["UserGroup_ID"] = value;
}
}
}
public partial class PermissionMinimalizedEntity {
public PermissionMinimalizedEntity() {}
public PermissionMinimalizedEntity(PermissionRow dr) {
this.Permission_ID = dr.Permission_ID;
this.Permission_Type = dr.Permission_Type;
this.Permission_IsChecked = dr.Permission_IsChecked;
this.Permission_CreatedDate = dr.Permission_CreatedDate;
this.Permission_CreatedBy = dr.Permission_CreatedBy;
this.Permission_UpdatedDate = dr.Permission_UpdatedDate;
this.Permission_UpdatedBy = dr.Permission_UpdatedBy;
this.UserGroup_ID = dr.UserGroup_ID;
}
public void CopyTo(PermissionRow dr) {
dr.Permission_ID = this.Permission_ID;
dr.Permission_Type = this.Permission_Type;
dr.Permission_IsChecked = this.Permission_IsChecked;
dr.Permission_CreatedDate = this.Permission_CreatedDate;
dr.Permission_CreatedBy = this.Permission_CreatedBy;
dr.Permission_UpdatedDate = this.Permission_UpdatedDate;
dr.Permission_UpdatedBy = this.Permission_UpdatedBy;
dr.UserGroup_ID = this.UserGroup_ID;
}
public System.Guid Permission_ID;
public System.Int16 Permission_Type;
public System.Boolean Permission_IsChecked;
public System.DateTime Permission_CreatedDate;
public System.String Permission_CreatedBy;
public System.DateTime Permission_UpdatedDate;
public System.String Permission_UpdatedBy;
public System.Guid UserGroup_ID;
}
public partial class PermissionAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PermissionAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Permission_ID", "Permission_ID");
tmap.ColumnMappings.Add("Permission_Type", "Permission_Type");
tmap.ColumnMappings.Add("Permission_IsChecked", "Permission_IsChecked");
tmap.ColumnMappings.Add("Permission_CreatedDate", "Permission_CreatedDate");
tmap.ColumnMappings.Add("Permission_CreatedBy", "Permission_CreatedBy");
tmap.ColumnMappings.Add("Permission_UpdatedDate", "Permission_UpdatedDate");
tmap.ColumnMappings.Add("Permission_UpdatedBy", "Permission_UpdatedBy");
tmap.ColumnMappings.Add("UserGroup_ID", "UserGroup_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Permission] ([Permission_ID], [Permission_Type], [Permission_IsChecked], [Permission_CreatedDate], [Permission_CreatedBy], [Permission_UpdatedDate], [Permission_UpdatedBy], [UserGroup_ID]) VALUES (@Permission_ID, @Permission_Type, @Permission_IsChecked, @Permission_CreatedDate, @Permission_CreatedBy, @Permission_UpdatedDate, @Permission_UpdatedBy, @UserGroup_ID)");
adapter.InsertCommand.Parameters.Add("@Permission_ID", SqlDbType.UniqueIdentifier, 0, "Permission_ID");
adapter.InsertCommand.Parameters.Add("@Permission_Type", SqlDbType.SmallInt, 0, "Permission_Type");
adapter.InsertCommand.Parameters.Add("@Permission_IsChecked", SqlDbType.Bit, 0, "Permission_IsChecked");
adapter.InsertCommand.Parameters.Add("@Permission_CreatedDate", SqlDbType.DateTime, 0, "Permission_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Permission_CreatedBy", SqlDbType.NVarChar, 0, "Permission_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Permission_UpdatedDate", SqlDbType.DateTime, 0, "Permission_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Permission_UpdatedBy", SqlDbType.NVarChar, 0, "Permission_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Permission] SET [Permission_ID] = @Permission_ID, [Permission_Type] = @Permission_Type, [Permission_IsChecked] = @Permission_IsChecked, [Permission_CreatedDate] = @Permission_CreatedDate, [Permission_CreatedBy] = @Permission_CreatedBy, [Permission_UpdatedDate] = @Permission_UpdatedDate, [Permission_UpdatedBy] = @Permission_UpdatedBy, [UserGroup_ID] = @UserGroup_ID WHERE [Permission_ID] = @o_Permission_ID");
adapter.UpdateCommand.Parameters.Add("@Permission_ID", SqlDbType.UniqueIdentifier, 0, "Permission_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Permission_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Permission_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Permission_Type", SqlDbType.SmallInt, 0, "Permission_Type");
adapter.UpdateCommand.Parameters.Add("@Permission_IsChecked", SqlDbType.Bit, 0, "Permission_IsChecked");
adapter.UpdateCommand.Parameters.Add("@Permission_CreatedDate", SqlDbType.DateTime, 0, "Permission_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Permission_CreatedBy", SqlDbType.NVarChar, 0, "Permission_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Permission_UpdatedDate", SqlDbType.DateTime, 0, "Permission_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Permission_UpdatedBy", SqlDbType.NVarChar, 0, "Permission_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Permission] WHERE [Permission_ID] = @o_Permission_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Permission_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Permission_ID", DataRowVersion.Original, null));
}
public void Update(PermissionTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(PermissionRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public PermissionRow GetByPermission_ID(System.Guid Permission_ID ) {
string sql = "SELECT * FROM [Permission] WHERE [Permission_ID] = @Permission_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Permission_ID", Permission_ID);

PermissionTable tbl = new PermissionTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPermissionRow(0);
}
public int CountByPermission_ID(System.Guid Permission_ID ) {
string sql = "SELECT COUNT(*) FROM [Permission] WHERE [Permission_ID] = @Permission_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Permission_ID", Permission_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPermission_ID(System.Guid Permission_ID, IActivityLog log ) {
string sql = "DELETE FROM [Permission] WHERE [Permission_ID] = @Permission_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Permission_ID", Permission_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public PermissionTable GetByUserGroup_ID(System.Guid UserGroup_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Permission] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
PermissionTable tbl = new PermissionTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByUserGroup_ID(System.Guid UserGroup_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Permission] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByUserGroup_ID(System.Guid UserGroup_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Permission] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
