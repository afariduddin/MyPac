using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class EmailNotificationTable : DataTable {
// column indexes
public const int EmailNotification_IDColumnIndex = 0;
public const int EmailNotification_StatusColumnIndex = 1;
public const int EmailNotification_RecipientColumnIndex = 2;
public const int EmailNotification_SubjectColumnIndex = 3;
public const int EmailNotification_EmailContentColumnIndex = 4;
public const int EmailNotification_RetryCountColumnIndex = 5;
public const int EmailNotification_StatusMessageColumnIndex = 6;
public const int EmailNotification_CreatedDateColumnIndex = 7;
public const int Application_IDColumnIndex = 8;
public const int EmailNotification_IsReadColumnIndex = 9;
public EmailNotificationTable() {
TableName = "[EmailNotification]";
// column EmailNotification_ID
DataColumn EmailNotification_IDCol = new DataColumn("EmailNotification_ID", typeof(System.Guid));
EmailNotification_IDCol.ReadOnly = false;
EmailNotification_IDCol.AllowDBNull = false;
Columns.Add(EmailNotification_IDCol);
// column EmailNotification_Status
DataColumn EmailNotification_StatusCol = new DataColumn("EmailNotification_Status", typeof(System.Int16));
EmailNotification_StatusCol.ReadOnly = false;
EmailNotification_StatusCol.AllowDBNull = false;
Columns.Add(EmailNotification_StatusCol);
// column EmailNotification_Recipient
DataColumn EmailNotification_RecipientCol = new DataColumn("EmailNotification_Recipient", typeof(System.String));
EmailNotification_RecipientCol.ReadOnly = false;
EmailNotification_RecipientCol.AllowDBNull = false;
Columns.Add(EmailNotification_RecipientCol);
// column EmailNotification_Subject
DataColumn EmailNotification_SubjectCol = new DataColumn("EmailNotification_Subject", typeof(System.String));
EmailNotification_SubjectCol.ReadOnly = false;
EmailNotification_SubjectCol.AllowDBNull = false;
Columns.Add(EmailNotification_SubjectCol);
// column EmailNotification_EmailContent
DataColumn EmailNotification_EmailContentCol = new DataColumn("EmailNotification_EmailContent", typeof(System.String));
EmailNotification_EmailContentCol.ReadOnly = false;
EmailNotification_EmailContentCol.AllowDBNull = false;
Columns.Add(EmailNotification_EmailContentCol);
// column EmailNotification_RetryCount
DataColumn EmailNotification_RetryCountCol = new DataColumn("EmailNotification_RetryCount", typeof(System.Int32));
EmailNotification_RetryCountCol.ReadOnly = false;
EmailNotification_RetryCountCol.AllowDBNull = false;
Columns.Add(EmailNotification_RetryCountCol);
// column EmailNotification_StatusMessage
DataColumn EmailNotification_StatusMessageCol = new DataColumn("EmailNotification_StatusMessage", typeof(System.String));
EmailNotification_StatusMessageCol.ReadOnly = false;
EmailNotification_StatusMessageCol.AllowDBNull = false;
Columns.Add(EmailNotification_StatusMessageCol);
// column EmailNotification_CreatedDate
DataColumn EmailNotification_CreatedDateCol = new DataColumn("EmailNotification_CreatedDate", typeof(System.DateTime));
EmailNotification_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
EmailNotification_CreatedDateCol.ReadOnly = false;
EmailNotification_CreatedDateCol.AllowDBNull = false;
Columns.Add(EmailNotification_CreatedDateCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column EmailNotification_IsRead
DataColumn EmailNotification_IsReadCol = new DataColumn("EmailNotification_IsRead", typeof(System.Boolean));
EmailNotification_IsReadCol.ReadOnly = false;
EmailNotification_IsReadCol.AllowDBNull = false;
Columns.Add(EmailNotification_IsReadCol);
}
public EmailNotificationRow NewEmailNotificationRow() {
EmailNotificationRow row = (EmailNotificationRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(EmailNotificationRow row) {
row.EmailNotification_ID = Guid.Empty;
row.EmailNotification_Status = 0;
row.EmailNotification_Recipient = "";
row.EmailNotification_Subject = "";
row.EmailNotification_EmailContent = "";
row.EmailNotification_RetryCount = 0;
row.EmailNotification_StatusMessage = "";
row.EmailNotification_CreatedDate = DateTime.Now;
row.Application_ID = Guid.Empty;
row.EmailNotification_IsRead = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new EmailNotificationRow(builder);
}
public EmailNotificationRow GetEmailNotificationRow(int index) {
return (EmailNotificationRow)Rows[index];
}
}
public partial class EmailNotificationRow : DataRow {
internal EmailNotificationRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid EmailNotification_ID {
get {
return (System.Guid)this["EmailNotification_ID"];
}
set {
this["EmailNotification_ID"] = value;
}
}
public System.Int16 EmailNotification_Status {
get {
return (System.Int16)this["EmailNotification_Status"];
}
set {
this["EmailNotification_Status"] = value;
}
}
public System.String EmailNotification_Recipient {
get {
return (System.String)this["EmailNotification_Recipient"];
}
set {
this["EmailNotification_Recipient"] = value;
}
}
public System.String EmailNotification_Subject {
get {
return (System.String)this["EmailNotification_Subject"];
}
set {
this["EmailNotification_Subject"] = value;
}
}
public System.String EmailNotification_EmailContent {
get {
return (System.String)this["EmailNotification_EmailContent"];
}
set {
this["EmailNotification_EmailContent"] = value;
}
}
public System.Int32 EmailNotification_RetryCount {
get {
return (System.Int32)this["EmailNotification_RetryCount"];
}
set {
this["EmailNotification_RetryCount"] = value;
}
}
public System.String EmailNotification_StatusMessage {
get {
return (System.String)this["EmailNotification_StatusMessage"];
}
set {
this["EmailNotification_StatusMessage"] = value;
}
}
public System.DateTime EmailNotification_CreatedDate {
get {
return (System.DateTime)this["EmailNotification_CreatedDate"];
}
set {
this["EmailNotification_CreatedDate"] = value;
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
public System.Boolean EmailNotification_IsRead {
get {
return (System.Boolean)this["EmailNotification_IsRead"];
}
set {
this["EmailNotification_IsRead"] = value;
}
}
}
public partial class EmailNotificationMinimalizedEntity {
public EmailNotificationMinimalizedEntity() {}
public EmailNotificationMinimalizedEntity(EmailNotificationRow dr) {
this.EmailNotification_ID = dr.EmailNotification_ID;
this.EmailNotification_Status = dr.EmailNotification_Status;
this.EmailNotification_Recipient = dr.EmailNotification_Recipient;
this.EmailNotification_Subject = dr.EmailNotification_Subject;
this.EmailNotification_EmailContent = dr.EmailNotification_EmailContent;
this.EmailNotification_RetryCount = dr.EmailNotification_RetryCount;
this.EmailNotification_StatusMessage = dr.EmailNotification_StatusMessage;
this.EmailNotification_CreatedDate = dr.EmailNotification_CreatedDate;
this.Application_ID = dr.Application_ID;
this.EmailNotification_IsRead = dr.EmailNotification_IsRead;
}
public void CopyTo(EmailNotificationRow dr) {
dr.EmailNotification_ID = this.EmailNotification_ID;
dr.EmailNotification_Status = this.EmailNotification_Status;
dr.EmailNotification_Recipient = this.EmailNotification_Recipient;
dr.EmailNotification_Subject = this.EmailNotification_Subject;
dr.EmailNotification_EmailContent = this.EmailNotification_EmailContent;
dr.EmailNotification_RetryCount = this.EmailNotification_RetryCount;
dr.EmailNotification_StatusMessage = this.EmailNotification_StatusMessage;
dr.EmailNotification_CreatedDate = this.EmailNotification_CreatedDate;
dr.Application_ID = this.Application_ID;
dr.EmailNotification_IsRead = this.EmailNotification_IsRead;
}
public System.Guid EmailNotification_ID;
public System.Int16 EmailNotification_Status;
public System.String EmailNotification_Recipient;
public System.String EmailNotification_Subject;
public System.String EmailNotification_EmailContent;
public System.Int32 EmailNotification_RetryCount;
public System.String EmailNotification_StatusMessage;
public System.DateTime EmailNotification_CreatedDate;
public System.Guid Application_ID;
public System.Boolean EmailNotification_IsRead;
}
public partial class EmailNotificationAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public EmailNotificationAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("EmailNotification_ID", "EmailNotification_ID");
tmap.ColumnMappings.Add("EmailNotification_Status", "EmailNotification_Status");
tmap.ColumnMappings.Add("EmailNotification_Recipient", "EmailNotification_Recipient");
tmap.ColumnMappings.Add("EmailNotification_Subject", "EmailNotification_Subject");
tmap.ColumnMappings.Add("EmailNotification_EmailContent", "EmailNotification_EmailContent");
tmap.ColumnMappings.Add("EmailNotification_RetryCount", "EmailNotification_RetryCount");
tmap.ColumnMappings.Add("EmailNotification_StatusMessage", "EmailNotification_StatusMessage");
tmap.ColumnMappings.Add("EmailNotification_CreatedDate", "EmailNotification_CreatedDate");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("EmailNotification_IsRead", "EmailNotification_IsRead");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [EmailNotification] ([EmailNotification_ID], [EmailNotification_Status], [EmailNotification_Recipient], [EmailNotification_Subject], [EmailNotification_EmailContent], [EmailNotification_RetryCount], [EmailNotification_StatusMessage], [EmailNotification_CreatedDate], [Application_ID], [EmailNotification_IsRead]) VALUES (@EmailNotification_ID, @EmailNotification_Status, @EmailNotification_Recipient, @EmailNotification_Subject, @EmailNotification_EmailContent, @EmailNotification_RetryCount, @EmailNotification_StatusMessage, @EmailNotification_CreatedDate, @Application_ID, @EmailNotification_IsRead)");
adapter.InsertCommand.Parameters.Add("@EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, "EmailNotification_ID");
adapter.InsertCommand.Parameters.Add("@EmailNotification_Status", SqlDbType.SmallInt, 0, "EmailNotification_Status");
adapter.InsertCommand.Parameters.Add("@EmailNotification_Recipient", SqlDbType.NVarChar, 0, "EmailNotification_Recipient");
adapter.InsertCommand.Parameters.Add("@EmailNotification_Subject", SqlDbType.NVarChar, 0, "EmailNotification_Subject");
adapter.InsertCommand.Parameters.Add("@EmailNotification_EmailContent", SqlDbType.NVarChar, 0, "EmailNotification_EmailContent");
adapter.InsertCommand.Parameters.Add("@EmailNotification_RetryCount", SqlDbType.Int, 0, "EmailNotification_RetryCount");
adapter.InsertCommand.Parameters.Add("@EmailNotification_StatusMessage", SqlDbType.NVarChar, 0, "EmailNotification_StatusMessage");
adapter.InsertCommand.Parameters.Add("@EmailNotification_CreatedDate", SqlDbType.DateTime, 0, "EmailNotification_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@EmailNotification_IsRead", SqlDbType.Bit, 0, "EmailNotification_IsRead");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [EmailNotification] SET [EmailNotification_ID] = @EmailNotification_ID, [EmailNotification_Status] = @EmailNotification_Status, [EmailNotification_Recipient] = @EmailNotification_Recipient, [EmailNotification_Subject] = @EmailNotification_Subject, [EmailNotification_EmailContent] = @EmailNotification_EmailContent, [EmailNotification_RetryCount] = @EmailNotification_RetryCount, [EmailNotification_StatusMessage] = @EmailNotification_StatusMessage, [EmailNotification_CreatedDate] = @EmailNotification_CreatedDate, [Application_ID] = @Application_ID, [EmailNotification_IsRead] = @EmailNotification_IsRead WHERE [EmailNotification_ID] = @o_EmailNotification_ID");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, "EmailNotification_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "EmailNotification_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@EmailNotification_Status", SqlDbType.SmallInt, 0, "EmailNotification_Status");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_Recipient", SqlDbType.NVarChar, 0, "EmailNotification_Recipient");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_Subject", SqlDbType.NVarChar, 0, "EmailNotification_Subject");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_EmailContent", SqlDbType.NVarChar, 0, "EmailNotification_EmailContent");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_RetryCount", SqlDbType.Int, 0, "EmailNotification_RetryCount");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_StatusMessage", SqlDbType.NVarChar, 0, "EmailNotification_StatusMessage");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_CreatedDate", SqlDbType.DateTime, 0, "EmailNotification_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@EmailNotification_IsRead", SqlDbType.Bit, 0, "EmailNotification_IsRead");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [EmailNotification] WHERE [EmailNotification_ID] = @o_EmailNotification_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_EmailNotification_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "EmailNotification_ID", DataRowVersion.Original, null));
}
public void Update(EmailNotificationTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(EmailNotificationRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public EmailNotificationRow GetByEmailNotification_ID(System.Guid EmailNotification_ID ) {
string sql = "SELECT * FROM [EmailNotification] WHERE [EmailNotification_ID] = @EmailNotification_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("EmailNotification_ID", EmailNotification_ID);

EmailNotificationTable tbl = new EmailNotificationTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetEmailNotificationRow(0);
}
public int CountByEmailNotification_ID(System.Guid EmailNotification_ID ) {
string sql = "SELECT COUNT(*) FROM [EmailNotification] WHERE [EmailNotification_ID] = @EmailNotification_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("EmailNotification_ID", EmailNotification_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByEmailNotification_ID(System.Guid EmailNotification_ID, IActivityLog log ) {
string sql = "DELETE FROM [EmailNotification] WHERE [EmailNotification_ID] = @EmailNotification_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("EmailNotification_ID", EmailNotification_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public EmailNotificationTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [EmailNotification] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
EmailNotificationTable tbl = new EmailNotificationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [EmailNotification] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [EmailNotification] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
