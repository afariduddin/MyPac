using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class UserAccountDetailTable : DataTable {
// column indexes
public const int UserAccount_IDColumnIndex = 0;
public const int UserAccount_UserIDColumnIndex = 1;
public const int UserAccount_PasswordColumnIndex = 2;
public const int UserAccount_FullNameColumnIndex = 3;
public const int UserAccount_EmailColumnIndex = 4;
public const int UserAccount_ContactColumnIndex = 5;
public const int UserGroup_IDColumnIndex = 6;
public const int UserAccount_IsEnabledColumnIndex = 7;
public const int UserAccount_IsDeletedColumnIndex = 8;
public const int UserAccount_RemarkColumnIndex = 9;
public const int UserAccount_CreatedDateColumnIndex = 10;
public const int UserAccount_CreatedByColumnIndex = 11;
public const int UserAccount_UpdatedDateColumnIndex = 12;
public const int UserAccount_UpdatedByColumnIndex = 13;
public const int UserGroup_NameColumnIndex = 14;
public const int UserGroup_IsDeletedColumnIndex = 15;
public const int UserGroup_PermissionColumnIndex = 16;
public UserAccountDetailTable() {
TableName = "[UserAccountDetail]";
// column UserAccount_ID
DataColumn UserAccount_IDCol = new DataColumn("UserAccount_ID", typeof(System.Guid));
UserAccount_IDCol.ReadOnly = true;
UserAccount_IDCol.AllowDBNull = false;
Columns.Add(UserAccount_IDCol);
// column UserAccount_UserID
DataColumn UserAccount_UserIDCol = new DataColumn("UserAccount_UserID", typeof(System.String));
UserAccount_UserIDCol.ReadOnly = true;
UserAccount_UserIDCol.AllowDBNull = false;
Columns.Add(UserAccount_UserIDCol);
// column UserAccount_Password
DataColumn UserAccount_PasswordCol = new DataColumn("UserAccount_Password", typeof(System.String));
UserAccount_PasswordCol.ReadOnly = true;
UserAccount_PasswordCol.AllowDBNull = false;
Columns.Add(UserAccount_PasswordCol);
// column UserAccount_FullName
DataColumn UserAccount_FullNameCol = new DataColumn("UserAccount_FullName", typeof(System.String));
UserAccount_FullNameCol.ReadOnly = true;
UserAccount_FullNameCol.AllowDBNull = false;
Columns.Add(UserAccount_FullNameCol);
// column UserAccount_Email
DataColumn UserAccount_EmailCol = new DataColumn("UserAccount_Email", typeof(System.String));
UserAccount_EmailCol.ReadOnly = true;
UserAccount_EmailCol.AllowDBNull = false;
Columns.Add(UserAccount_EmailCol);
// column UserAccount_Contact
DataColumn UserAccount_ContactCol = new DataColumn("UserAccount_Contact", typeof(System.String));
UserAccount_ContactCol.ReadOnly = true;
UserAccount_ContactCol.AllowDBNull = false;
Columns.Add(UserAccount_ContactCol);
// column UserGroup_ID
DataColumn UserGroup_IDCol = new DataColumn("UserGroup_ID", typeof(System.Guid));
UserGroup_IDCol.ReadOnly = true;
UserGroup_IDCol.AllowDBNull = false;
Columns.Add(UserGroup_IDCol);
// column UserAccount_IsEnabled
DataColumn UserAccount_IsEnabledCol = new DataColumn("UserAccount_IsEnabled", typeof(System.Boolean));
UserAccount_IsEnabledCol.ReadOnly = true;
UserAccount_IsEnabledCol.AllowDBNull = false;
Columns.Add(UserAccount_IsEnabledCol);
// column UserAccount_IsDeleted
DataColumn UserAccount_IsDeletedCol = new DataColumn("UserAccount_IsDeleted", typeof(System.Boolean));
UserAccount_IsDeletedCol.ReadOnly = true;
UserAccount_IsDeletedCol.AllowDBNull = false;
Columns.Add(UserAccount_IsDeletedCol);
// column UserAccount_Remark
DataColumn UserAccount_RemarkCol = new DataColumn("UserAccount_Remark", typeof(System.String));
UserAccount_RemarkCol.ReadOnly = true;
UserAccount_RemarkCol.AllowDBNull = false;
Columns.Add(UserAccount_RemarkCol);
// column UserAccount_CreatedDate
DataColumn UserAccount_CreatedDateCol = new DataColumn("UserAccount_CreatedDate", typeof(System.DateTime));
UserAccount_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserAccount_CreatedDateCol.ReadOnly = true;
UserAccount_CreatedDateCol.AllowDBNull = false;
Columns.Add(UserAccount_CreatedDateCol);
// column UserAccount_CreatedBy
DataColumn UserAccount_CreatedByCol = new DataColumn("UserAccount_CreatedBy", typeof(System.String));
UserAccount_CreatedByCol.ReadOnly = true;
UserAccount_CreatedByCol.AllowDBNull = false;
Columns.Add(UserAccount_CreatedByCol);
// column UserAccount_UpdatedDate
DataColumn UserAccount_UpdatedDateCol = new DataColumn("UserAccount_UpdatedDate", typeof(System.DateTime));
UserAccount_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserAccount_UpdatedDateCol.ReadOnly = true;
UserAccount_UpdatedDateCol.AllowDBNull = false;
Columns.Add(UserAccount_UpdatedDateCol);
// column UserAccount_UpdatedBy
DataColumn UserAccount_UpdatedByCol = new DataColumn("UserAccount_UpdatedBy", typeof(System.String));
UserAccount_UpdatedByCol.ReadOnly = true;
UserAccount_UpdatedByCol.AllowDBNull = false;
Columns.Add(UserAccount_UpdatedByCol);
// column UserGroup_Name
DataColumn UserGroup_NameCol = new DataColumn("UserGroup_Name", typeof(System.String));
UserGroup_NameCol.ReadOnly = true;
UserGroup_NameCol.AllowDBNull = false;
Columns.Add(UserGroup_NameCol);
// column UserGroup_IsDeleted
DataColumn UserGroup_IsDeletedCol = new DataColumn("UserGroup_IsDeleted", typeof(System.Boolean));
UserGroup_IsDeletedCol.ReadOnly = true;
UserGroup_IsDeletedCol.AllowDBNull = false;
Columns.Add(UserGroup_IsDeletedCol);
// column UserGroup_Permission
DataColumn UserGroup_PermissionCol = new DataColumn("UserGroup_Permission", typeof(System.String));
UserGroup_PermissionCol.ReadOnly = true;
UserGroup_PermissionCol.AllowDBNull = false;
Columns.Add(UserGroup_PermissionCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new UserAccountDetailRow(builder);
}
public UserAccountDetailRow GetUserAccountDetailRow(int index) {
return (UserAccountDetailRow)Rows[index];
}
}
public partial class UserAccountDetailRow : DataRow {
internal UserAccountDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid UserAccount_ID {
get {
return (System.Guid)this["UserAccount_ID"];
}
}
public System.String UserAccount_UserID {
get {
return (System.String)this["UserAccount_UserID"];
}
}
public System.String UserAccount_Password {
get {
return (System.String)this["UserAccount_Password"];
}
}
public System.String UserAccount_FullName {
get {
return (System.String)this["UserAccount_FullName"];
}
}
public System.String UserAccount_Email {
get {
return (System.String)this["UserAccount_Email"];
}
}
public System.String UserAccount_Contact {
get {
return (System.String)this["UserAccount_Contact"];
}
}
public System.Guid UserGroup_ID {
get {
return (System.Guid)this["UserGroup_ID"];
}
}
public System.Boolean UserAccount_IsEnabled {
get {
return (System.Boolean)this["UserAccount_IsEnabled"];
}
}
public System.Boolean UserAccount_IsDeleted {
get {
return (System.Boolean)this["UserAccount_IsDeleted"];
}
}
public System.String UserAccount_Remark {
get {
return (System.String)this["UserAccount_Remark"];
}
}
public System.DateTime UserAccount_CreatedDate {
get {
return (System.DateTime)this["UserAccount_CreatedDate"];
}
}
public System.String UserAccount_CreatedBy {
get {
return (System.String)this["UserAccount_CreatedBy"];
}
}
public System.DateTime UserAccount_UpdatedDate {
get {
return (System.DateTime)this["UserAccount_UpdatedDate"];
}
}
public System.String UserAccount_UpdatedBy {
get {
return (System.String)this["UserAccount_UpdatedBy"];
}
}
public System.String UserGroup_Name {
get {
return (System.String)this["UserGroup_Name"];
}
}
public System.Boolean UserGroup_IsDeleted {
get {
return (System.Boolean)this["UserGroup_IsDeleted"];
}
}
public System.String UserGroup_Permission {
get {
return (System.String)this["UserGroup_Permission"];
}
}
}
public partial class UserAccountDetailMinimalizedEntity {
public UserAccountDetailMinimalizedEntity() {}
public UserAccountDetailMinimalizedEntity(UserAccountDetailRow dr) {
this.UserAccount_ID = dr.UserAccount_ID;
this.UserAccount_UserID = dr.UserAccount_UserID;
this.UserAccount_Password = dr.UserAccount_Password;
this.UserAccount_FullName = dr.UserAccount_FullName;
this.UserAccount_Email = dr.UserAccount_Email;
this.UserAccount_Contact = dr.UserAccount_Contact;
this.UserGroup_ID = dr.UserGroup_ID;
this.UserAccount_IsEnabled = dr.UserAccount_IsEnabled;
this.UserAccount_IsDeleted = dr.UserAccount_IsDeleted;
this.UserAccount_Remark = dr.UserAccount_Remark;
this.UserAccount_CreatedDate = dr.UserAccount_CreatedDate;
this.UserAccount_CreatedBy = dr.UserAccount_CreatedBy;
this.UserAccount_UpdatedDate = dr.UserAccount_UpdatedDate;
this.UserAccount_UpdatedBy = dr.UserAccount_UpdatedBy;
this.UserGroup_Name = dr.UserGroup_Name;
this.UserGroup_IsDeleted = dr.UserGroup_IsDeleted;
this.UserGroup_Permission = dr.UserGroup_Permission;
}
public System.Guid UserAccount_ID;
public System.String UserAccount_UserID;
public System.String UserAccount_Password;
public System.String UserAccount_FullName;
public System.String UserAccount_Email;
public System.String UserAccount_Contact;
public System.Guid UserGroup_ID;
public System.Boolean UserAccount_IsEnabled;
public System.Boolean UserAccount_IsDeleted;
public System.String UserAccount_Remark;
public System.DateTime UserAccount_CreatedDate;
public System.String UserAccount_CreatedBy;
public System.DateTime UserAccount_UpdatedDate;
public System.String UserAccount_UpdatedBy;
public System.String UserGroup_Name;
public System.Boolean UserGroup_IsDeleted;
public System.String UserGroup_Permission;
}
public partial class UserAccountDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public UserAccountDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("UserAccount_ID", "UserAccount_ID");
tmap.ColumnMappings.Add("UserAccount_UserID", "UserAccount_UserID");
tmap.ColumnMappings.Add("UserAccount_Password", "UserAccount_Password");
tmap.ColumnMappings.Add("UserAccount_FullName", "UserAccount_FullName");
tmap.ColumnMappings.Add("UserAccount_Email", "UserAccount_Email");
tmap.ColumnMappings.Add("UserAccount_Contact", "UserAccount_Contact");
tmap.ColumnMappings.Add("UserGroup_ID", "UserGroup_ID");
tmap.ColumnMappings.Add("UserAccount_IsEnabled", "UserAccount_IsEnabled");
tmap.ColumnMappings.Add("UserAccount_IsDeleted", "UserAccount_IsDeleted");
tmap.ColumnMappings.Add("UserAccount_Remark", "UserAccount_Remark");
tmap.ColumnMappings.Add("UserAccount_CreatedDate", "UserAccount_CreatedDate");
tmap.ColumnMappings.Add("UserAccount_CreatedBy", "UserAccount_CreatedBy");
tmap.ColumnMappings.Add("UserAccount_UpdatedDate", "UserAccount_UpdatedDate");
tmap.ColumnMappings.Add("UserAccount_UpdatedBy", "UserAccount_UpdatedBy");
tmap.ColumnMappings.Add("UserGroup_Name", "UserGroup_Name");
tmap.ColumnMappings.Add("UserGroup_IsDeleted", "UserGroup_IsDeleted");
tmap.ColumnMappings.Add("UserGroup_Permission", "UserGroup_Permission");
adapter.TableMappings.Add(tmap);
}
}
public UserAccountDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [UserAccountDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

UserAccountDetailTable tbl = new UserAccountDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetUserAccountDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [UserAccountDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
