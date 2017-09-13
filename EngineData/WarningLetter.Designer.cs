using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class WarningLetterTable : DataTable {
// column indexes
public const int WarningLetter_IDColumnIndex = 0;
public const int WarningLetter_NameColumnIndex = 1;
public const int WarningLetter_SubjectColumnIndex = 2;
public const int WarningLetter_BodyColumnIndex = 3;
public const int WarningLetter_CreatedDateColumnIndex = 4;
public const int WarningLetter_CreatedByColumnIndex = 5;
public const int WarningLetter_UpdatedDateColumnIndex = 6;
public const int WarningLetter_UpdatedByColumnIndex = 7;
public const int WarningLetter_DeletedColumnIndex = 8;
public WarningLetterTable() {
TableName = "[WarningLetter]";
// column WarningLetter_ID
DataColumn WarningLetter_IDCol = new DataColumn("WarningLetter_ID", typeof(System.Guid));
WarningLetter_IDCol.ReadOnly = false;
WarningLetter_IDCol.AllowDBNull = false;
Columns.Add(WarningLetter_IDCol);
// column WarningLetter_Name
DataColumn WarningLetter_NameCol = new DataColumn("WarningLetter_Name", typeof(System.String));
WarningLetter_NameCol.ReadOnly = false;
WarningLetter_NameCol.AllowDBNull = false;
Columns.Add(WarningLetter_NameCol);
// column WarningLetter_Subject
DataColumn WarningLetter_SubjectCol = new DataColumn("WarningLetter_Subject", typeof(System.String));
WarningLetter_SubjectCol.ReadOnly = false;
WarningLetter_SubjectCol.AllowDBNull = false;
Columns.Add(WarningLetter_SubjectCol);
// column WarningLetter_Body
DataColumn WarningLetter_BodyCol = new DataColumn("WarningLetter_Body", typeof(System.String));
WarningLetter_BodyCol.ReadOnly = false;
WarningLetter_BodyCol.AllowDBNull = false;
Columns.Add(WarningLetter_BodyCol);
// column WarningLetter_CreatedDate
DataColumn WarningLetter_CreatedDateCol = new DataColumn("WarningLetter_CreatedDate", typeof(System.DateTime));
WarningLetter_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
WarningLetter_CreatedDateCol.ReadOnly = false;
WarningLetter_CreatedDateCol.AllowDBNull = true;
Columns.Add(WarningLetter_CreatedDateCol);
// column WarningLetter_CreatedBy
DataColumn WarningLetter_CreatedByCol = new DataColumn("WarningLetter_CreatedBy", typeof(System.String));
WarningLetter_CreatedByCol.ReadOnly = false;
WarningLetter_CreatedByCol.AllowDBNull = true;
Columns.Add(WarningLetter_CreatedByCol);
// column WarningLetter_UpdatedDate
DataColumn WarningLetter_UpdatedDateCol = new DataColumn("WarningLetter_UpdatedDate", typeof(System.DateTime));
WarningLetter_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
WarningLetter_UpdatedDateCol.ReadOnly = false;
WarningLetter_UpdatedDateCol.AllowDBNull = true;
Columns.Add(WarningLetter_UpdatedDateCol);
// column WarningLetter_UpdatedBy
DataColumn WarningLetter_UpdatedByCol = new DataColumn("WarningLetter_UpdatedBy", typeof(System.String));
WarningLetter_UpdatedByCol.ReadOnly = false;
WarningLetter_UpdatedByCol.AllowDBNull = true;
Columns.Add(WarningLetter_UpdatedByCol);
// column WarningLetter_Deleted
DataColumn WarningLetter_DeletedCol = new DataColumn("WarningLetter_Deleted", typeof(System.Boolean));
WarningLetter_DeletedCol.ReadOnly = false;
WarningLetter_DeletedCol.AllowDBNull = false;
Columns.Add(WarningLetter_DeletedCol);
}
public WarningLetterRow NewWarningLetterRow() {
WarningLetterRow row = (WarningLetterRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(WarningLetterRow row) {
row.WarningLetter_ID = Guid.Empty;
row.WarningLetter_Name = "";
row.WarningLetter_Subject = "";
row.WarningLetter_Body = "";
row.WarningLetter_Deleted = false;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new WarningLetterRow(builder);
}
public WarningLetterRow GetWarningLetterRow(int index) {
return (WarningLetterRow)Rows[index];
}
}
public partial class WarningLetterRow : DataRow {
internal WarningLetterRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid WarningLetter_ID {
get {
return (System.Guid)this["WarningLetter_ID"];
}
set {
this["WarningLetter_ID"] = value;
}
}
public System.String WarningLetter_Name {
get {
return (System.String)this["WarningLetter_Name"];
}
set {
if( value.Length > 300 ) this["WarningLetter_Name"] = value.Substring(0, 300);
else this["WarningLetter_Name"] = value;
}
}
public System.String WarningLetter_Subject {
get {
return (System.String)this["WarningLetter_Subject"];
}
set {
if( value.Length > 300 ) this["WarningLetter_Subject"] = value.Substring(0, 300);
else this["WarningLetter_Subject"] = value;
}
}
public System.String WarningLetter_Body {
get {
return (System.String)this["WarningLetter_Body"];
}
set {
this["WarningLetter_Body"] = value;
}
}
public System.DateTime? WarningLetter_CreatedDate {
get {
if( IsNull("WarningLetter_CreatedDate") ) return null;
else return (System.DateTime)this["WarningLetter_CreatedDate"];
}
set {
if( value.HasValue ) this["WarningLetter_CreatedDate"] = value;
else SetNull(Table.Columns["WarningLetter_CreatedDate"]);
}
}
public System.String WarningLetter_CreatedBy {
get {
if( IsNull("WarningLetter_CreatedBy") ) return "";
else return (System.String)this["WarningLetter_CreatedBy"];
}
set {
if( string.IsNullOrEmpty(value) ) SetNull(Table.Columns["WarningLetter_CreatedBy"]);
else{
if( value.Length > 50 ) this["WarningLetter_CreatedBy"] = value.Substring(0, 50);
else this["WarningLetter_CreatedBy"] = value;
}
}
}
public System.DateTime? WarningLetter_UpdatedDate {
get {
if( IsNull("WarningLetter_UpdatedDate") ) return null;
else return (System.DateTime)this["WarningLetter_UpdatedDate"];
}
set {
if( value.HasValue ) this["WarningLetter_UpdatedDate"] = value;
else SetNull(Table.Columns["WarningLetter_UpdatedDate"]);
}
}
public System.String WarningLetter_UpdatedBy {
get {
if( IsNull("WarningLetter_UpdatedBy") ) return "";
else return (System.String)this["WarningLetter_UpdatedBy"];
}
set {
if( string.IsNullOrEmpty(value) ) SetNull(Table.Columns["WarningLetter_UpdatedBy"]);
else{
if( value.Length > 50 ) this["WarningLetter_UpdatedBy"] = value.Substring(0, 50);
else this["WarningLetter_UpdatedBy"] = value;
}
}
}
public System.Boolean WarningLetter_Deleted {
get {
return (System.Boolean)this["WarningLetter_Deleted"];
}
set {
this["WarningLetter_Deleted"] = value;
}
}
}
public partial class WarningLetterMinimalizedEntity {
public WarningLetterMinimalizedEntity() {}
public WarningLetterMinimalizedEntity(WarningLetterRow dr) {
this.WarningLetter_ID = dr.WarningLetter_ID;
this.WarningLetter_Name = dr.WarningLetter_Name;
this.WarningLetter_Subject = dr.WarningLetter_Subject;
this.WarningLetter_Body = dr.WarningLetter_Body;
this.WarningLetter_CreatedDate = dr.WarningLetter_CreatedDate;
this.WarningLetter_CreatedBy = dr.WarningLetter_CreatedBy;
this.WarningLetter_UpdatedDate = dr.WarningLetter_UpdatedDate;
this.WarningLetter_UpdatedBy = dr.WarningLetter_UpdatedBy;
this.WarningLetter_Deleted = dr.WarningLetter_Deleted;
}
public void CopyTo(WarningLetterRow dr) {
dr.WarningLetter_ID = this.WarningLetter_ID;
dr.WarningLetter_Name = this.WarningLetter_Name;
dr.WarningLetter_Subject = this.WarningLetter_Subject;
dr.WarningLetter_Body = this.WarningLetter_Body;
dr.WarningLetter_CreatedDate = this.WarningLetter_CreatedDate;
dr.WarningLetter_CreatedBy = this.WarningLetter_CreatedBy;
dr.WarningLetter_UpdatedDate = this.WarningLetter_UpdatedDate;
dr.WarningLetter_UpdatedBy = this.WarningLetter_UpdatedBy;
dr.WarningLetter_Deleted = this.WarningLetter_Deleted;
}
public System.Guid WarningLetter_ID;
public System.String WarningLetter_Name;
public System.String WarningLetter_Subject;
public System.String WarningLetter_Body;
public System.DateTime? WarningLetter_CreatedDate;
public System.String WarningLetter_CreatedBy;
public System.DateTime? WarningLetter_UpdatedDate;
public System.String WarningLetter_UpdatedBy;
public System.Boolean WarningLetter_Deleted;
}
public partial class WarningLetterAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public WarningLetterAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("WarningLetter_ID", "WarningLetter_ID");
tmap.ColumnMappings.Add("WarningLetter_Name", "WarningLetter_Name");
tmap.ColumnMappings.Add("WarningLetter_Subject", "WarningLetter_Subject");
tmap.ColumnMappings.Add("WarningLetter_Body", "WarningLetter_Body");
tmap.ColumnMappings.Add("WarningLetter_CreatedDate", "WarningLetter_CreatedDate");
tmap.ColumnMappings.Add("WarningLetter_CreatedBy", "WarningLetter_CreatedBy");
tmap.ColumnMappings.Add("WarningLetter_UpdatedDate", "WarningLetter_UpdatedDate");
tmap.ColumnMappings.Add("WarningLetter_UpdatedBy", "WarningLetter_UpdatedBy");
tmap.ColumnMappings.Add("WarningLetter_Deleted", "WarningLetter_Deleted");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [WarningLetter] ([WarningLetter_ID], [WarningLetter_Name], [WarningLetter_Subject], [WarningLetter_Body], [WarningLetter_CreatedDate], [WarningLetter_CreatedBy], [WarningLetter_UpdatedDate], [WarningLetter_UpdatedBy], [WarningLetter_Deleted]) VALUES (@WarningLetter_ID, @WarningLetter_Name, @WarningLetter_Subject, @WarningLetter_Body, @WarningLetter_CreatedDate, @WarningLetter_CreatedBy, @WarningLetter_UpdatedDate, @WarningLetter_UpdatedBy, @WarningLetter_Deleted)");
adapter.InsertCommand.Parameters.Add("@WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "WarningLetter_ID");
adapter.InsertCommand.Parameters.Add("@WarningLetter_Name", SqlDbType.NVarChar, 0, "WarningLetter_Name");
adapter.InsertCommand.Parameters.Add("@WarningLetter_Subject", SqlDbType.NVarChar, 0, "WarningLetter_Subject");
adapter.InsertCommand.Parameters.Add("@WarningLetter_Body", SqlDbType.NVarChar, 0, "WarningLetter_Body");
adapter.InsertCommand.Parameters.Add("@WarningLetter_CreatedDate", SqlDbType.DateTime, 0, "WarningLetter_CreatedDate");
adapter.InsertCommand.Parameters.Add("@WarningLetter_CreatedBy", SqlDbType.NVarChar, 0, "WarningLetter_CreatedBy");
adapter.InsertCommand.Parameters.Add("@WarningLetter_UpdatedDate", SqlDbType.DateTime, 0, "WarningLetter_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@WarningLetter_UpdatedBy", SqlDbType.NVarChar, 0, "WarningLetter_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@WarningLetter_Deleted", SqlDbType.Bit, 0, "WarningLetter_Deleted");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [WarningLetter] SET [WarningLetter_ID] = @WarningLetter_ID, [WarningLetter_Name] = @WarningLetter_Name, [WarningLetter_Subject] = @WarningLetter_Subject, [WarningLetter_Body] = @WarningLetter_Body, [WarningLetter_CreatedDate] = @WarningLetter_CreatedDate, [WarningLetter_CreatedBy] = @WarningLetter_CreatedBy, [WarningLetter_UpdatedDate] = @WarningLetter_UpdatedDate, [WarningLetter_UpdatedBy] = @WarningLetter_UpdatedBy, [WarningLetter_Deleted] = @WarningLetter_Deleted WHERE [WarningLetter_ID] = @o_WarningLetter_ID");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, "WarningLetter_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "WarningLetter_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@WarningLetter_Name", SqlDbType.NVarChar, 0, "WarningLetter_Name");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_Subject", SqlDbType.NVarChar, 0, "WarningLetter_Subject");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_Body", SqlDbType.NVarChar, 0, "WarningLetter_Body");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_CreatedDate", SqlDbType.DateTime, 0, "WarningLetter_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_CreatedBy", SqlDbType.NVarChar, 0, "WarningLetter_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_UpdatedDate", SqlDbType.DateTime, 0, "WarningLetter_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_UpdatedBy", SqlDbType.NVarChar, 0, "WarningLetter_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@WarningLetter_Deleted", SqlDbType.Bit, 0, "WarningLetter_Deleted");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [WarningLetter] WHERE [WarningLetter_ID] = @o_WarningLetter_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_WarningLetter_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "WarningLetter_ID", DataRowVersion.Original, null));
}
public void Update(WarningLetterTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(WarningLetterRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public WarningLetterRow GetByWarningLetter_ID(System.Guid WarningLetter_ID ) {
string sql = "SELECT * FROM [WarningLetter] WHERE [WarningLetter_ID] = @WarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WarningLetter_ID", WarningLetter_ID);

WarningLetterTable tbl = new WarningLetterTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetWarningLetterRow(0);
}
public int CountByWarningLetter_ID(System.Guid WarningLetter_ID ) {
string sql = "SELECT COUNT(*) FROM [WarningLetter] WHERE [WarningLetter_ID] = @WarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WarningLetter_ID", WarningLetter_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByWarningLetter_ID(System.Guid WarningLetter_ID, IActivityLog log ) {
string sql = "DELETE FROM [WarningLetter] WHERE [WarningLetter_ID] = @WarningLetter_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("WarningLetter_ID", WarningLetter_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
