using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class UserGroupTable : DataTable {
// column indexes
public const int UserGroup_IDColumnIndex = 0;
public const int UserGroup_NameColumnIndex = 1;
public const int UserGroup_RemarkColumnIndex = 2;
public const int UserGroup_IsDeletedColumnIndex = 3;
public const int UserGroup_CreatedDateColumnIndex = 4;
public const int UserGroup_CreatedByColumnIndex = 5;
public const int UserGroup_UpdatedDateColumnIndex = 6;
public const int UserGroup_UpdatedByColumnIndex = 7;
public const int UserGroup_PermissionColumnIndex = 8;
public UserGroupTable() {
TableName = "[UserGroup]";
// column UserGroup_ID
DataColumn UserGroup_IDCol = new DataColumn("UserGroup_ID", typeof(System.Guid));
UserGroup_IDCol.ReadOnly = false;
UserGroup_IDCol.AllowDBNull = false;
Columns.Add(UserGroup_IDCol);
// column UserGroup_Name
DataColumn UserGroup_NameCol = new DataColumn("UserGroup_Name", typeof(System.String));
UserGroup_NameCol.ReadOnly = false;
UserGroup_NameCol.AllowDBNull = false;
Columns.Add(UserGroup_NameCol);
// column UserGroup_Remark
DataColumn UserGroup_RemarkCol = new DataColumn("UserGroup_Remark", typeof(System.String));
UserGroup_RemarkCol.ReadOnly = false;
UserGroup_RemarkCol.AllowDBNull = false;
Columns.Add(UserGroup_RemarkCol);
// column UserGroup_IsDeleted
DataColumn UserGroup_IsDeletedCol = new DataColumn("UserGroup_IsDeleted", typeof(System.Boolean));
UserGroup_IsDeletedCol.ReadOnly = false;
UserGroup_IsDeletedCol.AllowDBNull = false;
Columns.Add(UserGroup_IsDeletedCol);
// column UserGroup_CreatedDate
DataColumn UserGroup_CreatedDateCol = new DataColumn("UserGroup_CreatedDate", typeof(System.DateTime));
UserGroup_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserGroup_CreatedDateCol.ReadOnly = false;
UserGroup_CreatedDateCol.AllowDBNull = false;
Columns.Add(UserGroup_CreatedDateCol);
// column UserGroup_CreatedBy
DataColumn UserGroup_CreatedByCol = new DataColumn("UserGroup_CreatedBy", typeof(System.String));
UserGroup_CreatedByCol.ReadOnly = false;
UserGroup_CreatedByCol.AllowDBNull = false;
Columns.Add(UserGroup_CreatedByCol);
// column UserGroup_UpdatedDate
DataColumn UserGroup_UpdatedDateCol = new DataColumn("UserGroup_UpdatedDate", typeof(System.DateTime));
UserGroup_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserGroup_UpdatedDateCol.ReadOnly = false;
UserGroup_UpdatedDateCol.AllowDBNull = false;
Columns.Add(UserGroup_UpdatedDateCol);
// column UserGroup_UpdatedBy
DataColumn UserGroup_UpdatedByCol = new DataColumn("UserGroup_UpdatedBy", typeof(System.String));
UserGroup_UpdatedByCol.ReadOnly = false;
UserGroup_UpdatedByCol.AllowDBNull = false;
Columns.Add(UserGroup_UpdatedByCol);
// column UserGroup_Permission
DataColumn UserGroup_PermissionCol = new DataColumn("UserGroup_Permission", typeof(System.String));
UserGroup_PermissionCol.ReadOnly = false;
UserGroup_PermissionCol.AllowDBNull = false;
Columns.Add(UserGroup_PermissionCol);
}
public UserGroupRow NewUserGroupRow() {
UserGroupRow row = (UserGroupRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(UserGroupRow row) {
row.UserGroup_ID = Guid.Empty;
row.UserGroup_Name = "";
row.UserGroup_Remark = "";
row.UserGroup_IsDeleted = false;
row.UserGroup_CreatedDate = DateTime.Now;
row.UserGroup_CreatedBy = "";
row.UserGroup_UpdatedDate = DateTime.Now;
row.UserGroup_UpdatedBy = "";
row.UserGroup_Permission = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new UserGroupRow(builder);
}
public UserGroupRow GetUserGroupRow(int index) {
return (UserGroupRow)Rows[index];
}
}
public partial class UserGroupRow : DataRow {
internal UserGroupRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid UserGroup_ID {
get {
return (System.Guid)this["UserGroup_ID"];
}
set {
this["UserGroup_ID"] = value;
}
}
public System.String UserGroup_Name {
get {
return (System.String)this["UserGroup_Name"];
}
set {
if( value.Length > 50 ) this["UserGroup_Name"] = value.Substring(0, 50);
else this["UserGroup_Name"] = value;
}
}
public System.String UserGroup_Remark {
get {
return (System.String)this["UserGroup_Remark"];
}
set {
if( value.Length > 1000 ) this["UserGroup_Remark"] = value.Substring(0, 1000);
else this["UserGroup_Remark"] = value;
}
}
public System.Boolean UserGroup_IsDeleted {
get {
return (System.Boolean)this["UserGroup_IsDeleted"];
}
set {
this["UserGroup_IsDeleted"] = value;
}
}
public System.DateTime UserGroup_CreatedDate {
get {
return (System.DateTime)this["UserGroup_CreatedDate"];
}
set {
this["UserGroup_CreatedDate"] = value;
}
}
public System.String UserGroup_CreatedBy {
get {
return (System.String)this["UserGroup_CreatedBy"];
}
set {
if( value.Length > 50 ) this["UserGroup_CreatedBy"] = value.Substring(0, 50);
else this["UserGroup_CreatedBy"] = value;
}
}
public System.DateTime UserGroup_UpdatedDate {
get {
return (System.DateTime)this["UserGroup_UpdatedDate"];
}
set {
this["UserGroup_UpdatedDate"] = value;
}
}
public System.String UserGroup_UpdatedBy {
get {
return (System.String)this["UserGroup_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["UserGroup_UpdatedBy"] = value.Substring(0, 50);
else this["UserGroup_UpdatedBy"] = value;
}
}
public System.String UserGroup_Permission {
get {
return (System.String)this["UserGroup_Permission"];
}
set {
this["UserGroup_Permission"] = value;
}
}
}
public partial class UserGroupMinimalizedEntity {
public UserGroupMinimalizedEntity() {}
public UserGroupMinimalizedEntity(UserGroupRow dr) {
this.UserGroup_ID = dr.UserGroup_ID;
this.UserGroup_Name = dr.UserGroup_Name;
this.UserGroup_Remark = dr.UserGroup_Remark;
this.UserGroup_IsDeleted = dr.UserGroup_IsDeleted;
this.UserGroup_CreatedDate = dr.UserGroup_CreatedDate;
this.UserGroup_CreatedBy = dr.UserGroup_CreatedBy;
this.UserGroup_UpdatedDate = dr.UserGroup_UpdatedDate;
this.UserGroup_UpdatedBy = dr.UserGroup_UpdatedBy;
this.UserGroup_Permission = dr.UserGroup_Permission;
}
public void CopyTo(UserGroupRow dr) {
dr.UserGroup_ID = this.UserGroup_ID;
dr.UserGroup_Name = this.UserGroup_Name;
dr.UserGroup_Remark = this.UserGroup_Remark;
dr.UserGroup_IsDeleted = this.UserGroup_IsDeleted;
dr.UserGroup_CreatedDate = this.UserGroup_CreatedDate;
dr.UserGroup_CreatedBy = this.UserGroup_CreatedBy;
dr.UserGroup_UpdatedDate = this.UserGroup_UpdatedDate;
dr.UserGroup_UpdatedBy = this.UserGroup_UpdatedBy;
dr.UserGroup_Permission = this.UserGroup_Permission;
}
public System.Guid UserGroup_ID;
public System.String UserGroup_Name;
public System.String UserGroup_Remark;
public System.Boolean UserGroup_IsDeleted;
public System.DateTime UserGroup_CreatedDate;
public System.String UserGroup_CreatedBy;
public System.DateTime UserGroup_UpdatedDate;
public System.String UserGroup_UpdatedBy;
public System.String UserGroup_Permission;
}
public partial class UserGroupAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public UserGroupAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("UserGroup_ID", "UserGroup_ID");
tmap.ColumnMappings.Add("UserGroup_Name", "UserGroup_Name");
tmap.ColumnMappings.Add("UserGroup_Remark", "UserGroup_Remark");
tmap.ColumnMappings.Add("UserGroup_IsDeleted", "UserGroup_IsDeleted");
tmap.ColumnMappings.Add("UserGroup_CreatedDate", "UserGroup_CreatedDate");
tmap.ColumnMappings.Add("UserGroup_CreatedBy", "UserGroup_CreatedBy");
tmap.ColumnMappings.Add("UserGroup_UpdatedDate", "UserGroup_UpdatedDate");
tmap.ColumnMappings.Add("UserGroup_UpdatedBy", "UserGroup_UpdatedBy");
tmap.ColumnMappings.Add("UserGroup_Permission", "UserGroup_Permission");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [UserGroup] ([UserGroup_ID], [UserGroup_Name], [UserGroup_Remark], [UserGroup_IsDeleted], [UserGroup_CreatedDate], [UserGroup_CreatedBy], [UserGroup_UpdatedDate], [UserGroup_UpdatedBy], [UserGroup_Permission]) VALUES (@UserGroup_ID, @UserGroup_Name, @UserGroup_Remark, @UserGroup_IsDeleted, @UserGroup_CreatedDate, @UserGroup_CreatedBy, @UserGroup_UpdatedDate, @UserGroup_UpdatedBy, @UserGroup_Permission)");
adapter.InsertCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
adapter.InsertCommand.Parameters.Add("@UserGroup_Name", SqlDbType.NVarChar, 0, "UserGroup_Name");
adapter.InsertCommand.Parameters.Add("@UserGroup_Remark", SqlDbType.NVarChar, 0, "UserGroup_Remark");
adapter.InsertCommand.Parameters.Add("@UserGroup_IsDeleted", SqlDbType.Bit, 0, "UserGroup_IsDeleted");
adapter.InsertCommand.Parameters.Add("@UserGroup_CreatedDate", SqlDbType.DateTime, 0, "UserGroup_CreatedDate");
adapter.InsertCommand.Parameters.Add("@UserGroup_CreatedBy", SqlDbType.NVarChar, 0, "UserGroup_CreatedBy");
adapter.InsertCommand.Parameters.Add("@UserGroup_UpdatedDate", SqlDbType.DateTime, 0, "UserGroup_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@UserGroup_UpdatedBy", SqlDbType.NVarChar, 0, "UserGroup_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@UserGroup_Permission", SqlDbType.NVarChar, 0, "UserGroup_Permission");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [UserGroup] SET [UserGroup_ID] = @UserGroup_ID, [UserGroup_Name] = @UserGroup_Name, [UserGroup_Remark] = @UserGroup_Remark, [UserGroup_IsDeleted] = @UserGroup_IsDeleted, [UserGroup_CreatedDate] = @UserGroup_CreatedDate, [UserGroup_CreatedBy] = @UserGroup_CreatedBy, [UserGroup_UpdatedDate] = @UserGroup_UpdatedDate, [UserGroup_UpdatedBy] = @UserGroup_UpdatedBy, [UserGroup_Permission] = @UserGroup_Permission WHERE [UserGroup_ID] = @o_UserGroup_ID");
adapter.UpdateCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_UserGroup_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "UserGroup_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@UserGroup_Name", SqlDbType.NVarChar, 0, "UserGroup_Name");
adapter.UpdateCommand.Parameters.Add("@UserGroup_Remark", SqlDbType.NVarChar, 0, "UserGroup_Remark");
adapter.UpdateCommand.Parameters.Add("@UserGroup_IsDeleted", SqlDbType.Bit, 0, "UserGroup_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@UserGroup_CreatedDate", SqlDbType.DateTime, 0, "UserGroup_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@UserGroup_CreatedBy", SqlDbType.NVarChar, 0, "UserGroup_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@UserGroup_UpdatedDate", SqlDbType.DateTime, 0, "UserGroup_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@UserGroup_UpdatedBy", SqlDbType.NVarChar, 0, "UserGroup_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@UserGroup_Permission", SqlDbType.NVarChar, 0, "UserGroup_Permission");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [UserGroup] WHERE [UserGroup_ID] = @o_UserGroup_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_UserGroup_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "UserGroup_ID", DataRowVersion.Original, null));
}
public void Update(UserGroupTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(UserGroupRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public UserGroupRow GetByUserGroup_ID(System.Guid UserGroup_ID ) {
string sql = "SELECT * FROM [UserGroup] WHERE [UserGroup_ID] = @UserGroup_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);

UserGroupTable tbl = new UserGroupTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetUserGroupRow(0);
}
public int CountByUserGroup_ID(System.Guid UserGroup_ID ) {
string sql = "SELECT COUNT(*) FROM [UserGroup] WHERE [UserGroup_ID] = @UserGroup_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByUserGroup_ID(System.Guid UserGroup_ID, IActivityLog log ) {
string sql = "DELETE FROM [UserGroup] WHERE [UserGroup_ID] = @UserGroup_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
