using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class UserAccountTable : DataTable {
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
public UserAccountTable() {
TableName = "[UserAccount]";
// column UserAccount_ID
DataColumn UserAccount_IDCol = new DataColumn("UserAccount_ID", typeof(System.Guid));
UserAccount_IDCol.ReadOnly = false;
UserAccount_IDCol.AllowDBNull = false;
Columns.Add(UserAccount_IDCol);
// column UserAccount_UserID
DataColumn UserAccount_UserIDCol = new DataColumn("UserAccount_UserID", typeof(System.String));
UserAccount_UserIDCol.ReadOnly = false;
UserAccount_UserIDCol.AllowDBNull = false;
Columns.Add(UserAccount_UserIDCol);
// column UserAccount_Password
DataColumn UserAccount_PasswordCol = new DataColumn("UserAccount_Password", typeof(System.String));
UserAccount_PasswordCol.ReadOnly = false;
UserAccount_PasswordCol.AllowDBNull = false;
Columns.Add(UserAccount_PasswordCol);
// column UserAccount_FullName
DataColumn UserAccount_FullNameCol = new DataColumn("UserAccount_FullName", typeof(System.String));
UserAccount_FullNameCol.ReadOnly = false;
UserAccount_FullNameCol.AllowDBNull = false;
Columns.Add(UserAccount_FullNameCol);
// column UserAccount_Email
DataColumn UserAccount_EmailCol = new DataColumn("UserAccount_Email", typeof(System.String));
UserAccount_EmailCol.ReadOnly = false;
UserAccount_EmailCol.AllowDBNull = false;
Columns.Add(UserAccount_EmailCol);
// column UserAccount_Contact
DataColumn UserAccount_ContactCol = new DataColumn("UserAccount_Contact", typeof(System.String));
UserAccount_ContactCol.ReadOnly = false;
UserAccount_ContactCol.AllowDBNull = false;
Columns.Add(UserAccount_ContactCol);
// column UserGroup_ID
DataColumn UserGroup_IDCol = new DataColumn("UserGroup_ID", typeof(System.Guid));
UserGroup_IDCol.ReadOnly = false;
UserGroup_IDCol.AllowDBNull = false;
Columns.Add(UserGroup_IDCol);
// column UserAccount_IsEnabled
DataColumn UserAccount_IsEnabledCol = new DataColumn("UserAccount_IsEnabled", typeof(System.Boolean));
UserAccount_IsEnabledCol.ReadOnly = false;
UserAccount_IsEnabledCol.AllowDBNull = false;
Columns.Add(UserAccount_IsEnabledCol);
// column UserAccount_IsDeleted
DataColumn UserAccount_IsDeletedCol = new DataColumn("UserAccount_IsDeleted", typeof(System.Boolean));
UserAccount_IsDeletedCol.ReadOnly = false;
UserAccount_IsDeletedCol.AllowDBNull = false;
Columns.Add(UserAccount_IsDeletedCol);
// column UserAccount_Remark
DataColumn UserAccount_RemarkCol = new DataColumn("UserAccount_Remark", typeof(System.String));
UserAccount_RemarkCol.ReadOnly = false;
UserAccount_RemarkCol.AllowDBNull = false;
Columns.Add(UserAccount_RemarkCol);
// column UserAccount_CreatedDate
DataColumn UserAccount_CreatedDateCol = new DataColumn("UserAccount_CreatedDate", typeof(System.DateTime));
UserAccount_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserAccount_CreatedDateCol.ReadOnly = false;
UserAccount_CreatedDateCol.AllowDBNull = false;
Columns.Add(UserAccount_CreatedDateCol);
// column UserAccount_CreatedBy
DataColumn UserAccount_CreatedByCol = new DataColumn("UserAccount_CreatedBy", typeof(System.String));
UserAccount_CreatedByCol.ReadOnly = false;
UserAccount_CreatedByCol.AllowDBNull = false;
Columns.Add(UserAccount_CreatedByCol);
// column UserAccount_UpdatedDate
DataColumn UserAccount_UpdatedDateCol = new DataColumn("UserAccount_UpdatedDate", typeof(System.DateTime));
UserAccount_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
UserAccount_UpdatedDateCol.ReadOnly = false;
UserAccount_UpdatedDateCol.AllowDBNull = false;
Columns.Add(UserAccount_UpdatedDateCol);
// column UserAccount_UpdatedBy
DataColumn UserAccount_UpdatedByCol = new DataColumn("UserAccount_UpdatedBy", typeof(System.String));
UserAccount_UpdatedByCol.ReadOnly = false;
UserAccount_UpdatedByCol.AllowDBNull = false;
Columns.Add(UserAccount_UpdatedByCol);
}
public UserAccountRow NewUserAccountRow() {
UserAccountRow row = (UserAccountRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(UserAccountRow row) {
row.UserAccount_ID = Guid.Empty;
row.UserAccount_UserID = "";
row.UserAccount_Password = "";
row.UserAccount_FullName = "";
row.UserAccount_Email = "";
row.UserAccount_Contact = "";
row.UserGroup_ID = Guid.Empty;
row.UserAccount_IsEnabled = false;
row.UserAccount_IsDeleted = false;
row.UserAccount_Remark = "";
row.UserAccount_CreatedDate = DateTime.Now;
row.UserAccount_CreatedBy = "";
row.UserAccount_UpdatedDate = DateTime.Now;
row.UserAccount_UpdatedBy = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new UserAccountRow(builder);
}
public UserAccountRow GetUserAccountRow(int index) {
return (UserAccountRow)Rows[index];
}
}
public partial class UserAccountRow : DataRow {
internal UserAccountRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid UserAccount_ID {
get {
return (System.Guid)this["UserAccount_ID"];
}
set {
this["UserAccount_ID"] = value;
}
}
public System.String UserAccount_UserID {
get {
return (System.String)this["UserAccount_UserID"];
}
set {
if( value.Length > 50 ) this["UserAccount_UserID"] = value.Substring(0, 50);
else this["UserAccount_UserID"] = value;
}
}
public System.String UserAccount_Password {
get {
return (System.String)this["UserAccount_Password"];
}
set {
if( value.Length > 50 ) this["UserAccount_Password"] = value.Substring(0, 50);
else this["UserAccount_Password"] = value;
}
}
public System.String UserAccount_FullName {
get {
return (System.String)this["UserAccount_FullName"];
}
set {
if( value.Length > 100 ) this["UserAccount_FullName"] = value.Substring(0, 100);
else this["UserAccount_FullName"] = value;
}
}
public System.String UserAccount_Email {
get {
return (System.String)this["UserAccount_Email"];
}
set {
if( value.Length > 100 ) this["UserAccount_Email"] = value.Substring(0, 100);
else this["UserAccount_Email"] = value;
}
}
public System.String UserAccount_Contact {
get {
return (System.String)this["UserAccount_Contact"];
}
set {
if( value.Length > 50 ) this["UserAccount_Contact"] = value.Substring(0, 50);
else this["UserAccount_Contact"] = value;
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
public System.Boolean UserAccount_IsEnabled {
get {
return (System.Boolean)this["UserAccount_IsEnabled"];
}
set {
this["UserAccount_IsEnabled"] = value;
}
}
public System.Boolean UserAccount_IsDeleted {
get {
return (System.Boolean)this["UserAccount_IsDeleted"];
}
set {
this["UserAccount_IsDeleted"] = value;
}
}
public System.String UserAccount_Remark {
get {
return (System.String)this["UserAccount_Remark"];
}
set {
if( value.Length > 1000 ) this["UserAccount_Remark"] = value.Substring(0, 1000);
else this["UserAccount_Remark"] = value;
}
}
public System.DateTime UserAccount_CreatedDate {
get {
return (System.DateTime)this["UserAccount_CreatedDate"];
}
set {
this["UserAccount_CreatedDate"] = value;
}
}
public System.String UserAccount_CreatedBy {
get {
return (System.String)this["UserAccount_CreatedBy"];
}
set {
if( value.Length > 50 ) this["UserAccount_CreatedBy"] = value.Substring(0, 50);
else this["UserAccount_CreatedBy"] = value;
}
}
public System.DateTime UserAccount_UpdatedDate {
get {
return (System.DateTime)this["UserAccount_UpdatedDate"];
}
set {
this["UserAccount_UpdatedDate"] = value;
}
}
public System.String UserAccount_UpdatedBy {
get {
return (System.String)this["UserAccount_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["UserAccount_UpdatedBy"] = value.Substring(0, 50);
else this["UserAccount_UpdatedBy"] = value;
}
}
}
public partial class UserAccountMinimalizedEntity {
public UserAccountMinimalizedEntity() {}
public UserAccountMinimalizedEntity(UserAccountRow dr) {
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
}
public void CopyTo(UserAccountRow dr) {
dr.UserAccount_ID = this.UserAccount_ID;
dr.UserAccount_UserID = this.UserAccount_UserID;
dr.UserAccount_Password = this.UserAccount_Password;
dr.UserAccount_FullName = this.UserAccount_FullName;
dr.UserAccount_Email = this.UserAccount_Email;
dr.UserAccount_Contact = this.UserAccount_Contact;
dr.UserGroup_ID = this.UserGroup_ID;
dr.UserAccount_IsEnabled = this.UserAccount_IsEnabled;
dr.UserAccount_IsDeleted = this.UserAccount_IsDeleted;
dr.UserAccount_Remark = this.UserAccount_Remark;
dr.UserAccount_CreatedDate = this.UserAccount_CreatedDate;
dr.UserAccount_CreatedBy = this.UserAccount_CreatedBy;
dr.UserAccount_UpdatedDate = this.UserAccount_UpdatedDate;
dr.UserAccount_UpdatedBy = this.UserAccount_UpdatedBy;
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
}
public partial class UserAccountAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public UserAccountAdapter(DA da):base(da) {
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
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [UserAccount] ([UserAccount_ID], [UserAccount_UserID], [UserAccount_Password], [UserAccount_FullName], [UserAccount_Email], [UserAccount_Contact], [UserGroup_ID], [UserAccount_IsEnabled], [UserAccount_IsDeleted], [UserAccount_Remark], [UserAccount_CreatedDate], [UserAccount_CreatedBy], [UserAccount_UpdatedDate], [UserAccount_UpdatedBy]) VALUES (@UserAccount_ID, @UserAccount_UserID, @UserAccount_Password, @UserAccount_FullName, @UserAccount_Email, @UserAccount_Contact, @UserGroup_ID, @UserAccount_IsEnabled, @UserAccount_IsDeleted, @UserAccount_Remark, @UserAccount_CreatedDate, @UserAccount_CreatedBy, @UserAccount_UpdatedDate, @UserAccount_UpdatedBy)");
adapter.InsertCommand.Parameters.Add("@UserAccount_ID", SqlDbType.UniqueIdentifier, 0, "UserAccount_ID");
adapter.InsertCommand.Parameters.Add("@UserAccount_UserID", SqlDbType.NVarChar, 0, "UserAccount_UserID");
adapter.InsertCommand.Parameters.Add("@UserAccount_Password", SqlDbType.NVarChar, 0, "UserAccount_Password");
adapter.InsertCommand.Parameters.Add("@UserAccount_FullName", SqlDbType.NVarChar, 0, "UserAccount_FullName");
adapter.InsertCommand.Parameters.Add("@UserAccount_Email", SqlDbType.NVarChar, 0, "UserAccount_Email");
adapter.InsertCommand.Parameters.Add("@UserAccount_Contact", SqlDbType.NVarChar, 0, "UserAccount_Contact");
adapter.InsertCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
adapter.InsertCommand.Parameters.Add("@UserAccount_IsEnabled", SqlDbType.Bit, 0, "UserAccount_IsEnabled");
adapter.InsertCommand.Parameters.Add("@UserAccount_IsDeleted", SqlDbType.Bit, 0, "UserAccount_IsDeleted");
adapter.InsertCommand.Parameters.Add("@UserAccount_Remark", SqlDbType.NVarChar, 0, "UserAccount_Remark");
adapter.InsertCommand.Parameters.Add("@UserAccount_CreatedDate", SqlDbType.DateTime, 0, "UserAccount_CreatedDate");
adapter.InsertCommand.Parameters.Add("@UserAccount_CreatedBy", SqlDbType.NVarChar, 0, "UserAccount_CreatedBy");
adapter.InsertCommand.Parameters.Add("@UserAccount_UpdatedDate", SqlDbType.DateTime, 0, "UserAccount_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@UserAccount_UpdatedBy", SqlDbType.NVarChar, 0, "UserAccount_UpdatedBy");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [UserAccount] SET [UserAccount_ID] = @UserAccount_ID, [UserAccount_UserID] = @UserAccount_UserID, [UserAccount_Password] = @UserAccount_Password, [UserAccount_FullName] = @UserAccount_FullName, [UserAccount_Email] = @UserAccount_Email, [UserAccount_Contact] = @UserAccount_Contact, [UserGroup_ID] = @UserGroup_ID, [UserAccount_IsEnabled] = @UserAccount_IsEnabled, [UserAccount_IsDeleted] = @UserAccount_IsDeleted, [UserAccount_Remark] = @UserAccount_Remark, [UserAccount_CreatedDate] = @UserAccount_CreatedDate, [UserAccount_CreatedBy] = @UserAccount_CreatedBy, [UserAccount_UpdatedDate] = @UserAccount_UpdatedDate, [UserAccount_UpdatedBy] = @UserAccount_UpdatedBy WHERE [UserAccount_ID] = @o_UserAccount_ID");
adapter.UpdateCommand.Parameters.Add("@UserAccount_ID", SqlDbType.UniqueIdentifier, 0, "UserAccount_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_UserAccount_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "UserAccount_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@UserAccount_UserID", SqlDbType.NVarChar, 0, "UserAccount_UserID");
adapter.UpdateCommand.Parameters.Add("@UserAccount_Password", SqlDbType.NVarChar, 0, "UserAccount_Password");
adapter.UpdateCommand.Parameters.Add("@UserAccount_FullName", SqlDbType.NVarChar, 0, "UserAccount_FullName");
adapter.UpdateCommand.Parameters.Add("@UserAccount_Email", SqlDbType.NVarChar, 0, "UserAccount_Email");
adapter.UpdateCommand.Parameters.Add("@UserAccount_Contact", SqlDbType.NVarChar, 0, "UserAccount_Contact");
adapter.UpdateCommand.Parameters.Add("@UserGroup_ID", SqlDbType.UniqueIdentifier, 0, "UserGroup_ID");
adapter.UpdateCommand.Parameters.Add("@UserAccount_IsEnabled", SqlDbType.Bit, 0, "UserAccount_IsEnabled");
adapter.UpdateCommand.Parameters.Add("@UserAccount_IsDeleted", SqlDbType.Bit, 0, "UserAccount_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@UserAccount_Remark", SqlDbType.NVarChar, 0, "UserAccount_Remark");
adapter.UpdateCommand.Parameters.Add("@UserAccount_CreatedDate", SqlDbType.DateTime, 0, "UserAccount_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@UserAccount_CreatedBy", SqlDbType.NVarChar, 0, "UserAccount_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@UserAccount_UpdatedDate", SqlDbType.DateTime, 0, "UserAccount_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@UserAccount_UpdatedBy", SqlDbType.NVarChar, 0, "UserAccount_UpdatedBy");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [UserAccount] WHERE [UserAccount_ID] = @o_UserAccount_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_UserAccount_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "UserAccount_ID", DataRowVersion.Original, null));
}
public void Update(UserAccountTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(UserAccountRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public UserAccountRow GetByUserAccount_ID(System.Guid UserAccount_ID ) {
string sql = "SELECT * FROM [UserAccount] WHERE [UserAccount_ID] = @UserAccount_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);

UserAccountTable tbl = new UserAccountTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetUserAccountRow(0);
}
public int CountByUserAccount_ID(System.Guid UserAccount_ID ) {
string sql = "SELECT COUNT(*) FROM [UserAccount] WHERE [UserAccount_ID] = @UserAccount_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByUserAccount_ID(System.Guid UserAccount_ID, IActivityLog log ) {
string sql = "DELETE FROM [UserAccount] WHERE [UserAccount_ID] = @UserAccount_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("UserAccount_ID", UserAccount_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public UserAccountTable GetByUserGroup_ID(System.Guid UserGroup_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [UserAccount] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
UserAccountTable tbl = new UserAccountTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByUserGroup_ID(System.Guid UserGroup_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [UserAccount] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByUserGroup_ID(System.Guid UserGroup_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [UserAccount] WHERE [UserGroup_ID] = @UserGroup_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
