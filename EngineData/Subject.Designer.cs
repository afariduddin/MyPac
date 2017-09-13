using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class SubjectTable : DataTable {
// column indexes
public const int Subject_IDColumnIndex = 0;
public const int Subject_NameColumnIndex = 1;
public const int Court_IDColumnIndex = 2;
public const int Subject_IsDeletedColumnIndex = 3;
public const int Subject_CreatedDateColumnIndex = 4;
public const int Subject_CreatedByColumnIndex = 5;
public const int Subject_UpdatedDateColumnIndex = 6;
public const int Subject_UpdatedByColumnIndex = 7;
public SubjectTable() {
TableName = "[Subject]";
// column Subject_ID
DataColumn Subject_IDCol = new DataColumn("Subject_ID", typeof(System.Guid));
Subject_IDCol.ReadOnly = false;
Subject_IDCol.AllowDBNull = false;
Columns.Add(Subject_IDCol);
// column Subject_Name
DataColumn Subject_NameCol = new DataColumn("Subject_Name", typeof(System.String));
Subject_NameCol.ReadOnly = false;
Subject_NameCol.AllowDBNull = false;
Columns.Add(Subject_NameCol);
// column Court_ID
DataColumn Court_IDCol = new DataColumn("Court_ID", typeof(System.Guid));
Court_IDCol.ReadOnly = false;
Court_IDCol.AllowDBNull = true;
Columns.Add(Court_IDCol);
// column Subject_IsDeleted
DataColumn Subject_IsDeletedCol = new DataColumn("Subject_IsDeleted", typeof(System.Boolean));
Subject_IsDeletedCol.ReadOnly = false;
Subject_IsDeletedCol.AllowDBNull = false;
Columns.Add(Subject_IsDeletedCol);
// column Subject_CreatedDate
DataColumn Subject_CreatedDateCol = new DataColumn("Subject_CreatedDate", typeof(System.DateTime));
Subject_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Subject_CreatedDateCol.ReadOnly = false;
Subject_CreatedDateCol.AllowDBNull = false;
Columns.Add(Subject_CreatedDateCol);
// column Subject_CreatedBy
DataColumn Subject_CreatedByCol = new DataColumn("Subject_CreatedBy", typeof(System.String));
Subject_CreatedByCol.ReadOnly = false;
Subject_CreatedByCol.AllowDBNull = false;
Columns.Add(Subject_CreatedByCol);
// column Subject_UpdatedDate
DataColumn Subject_UpdatedDateCol = new DataColumn("Subject_UpdatedDate", typeof(System.DateTime));
Subject_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Subject_UpdatedDateCol.ReadOnly = false;
Subject_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Subject_UpdatedDateCol);
// column Subject_UpdatedBy
DataColumn Subject_UpdatedByCol = new DataColumn("Subject_UpdatedBy", typeof(System.String));
Subject_UpdatedByCol.ReadOnly = false;
Subject_UpdatedByCol.AllowDBNull = false;
Columns.Add(Subject_UpdatedByCol);
}
public SubjectRow NewSubjectRow() {
SubjectRow row = (SubjectRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(SubjectRow row) {
row.Subject_ID = Guid.Empty;
row.Subject_Name = "";
row.Subject_IsDeleted = false;
row.Subject_CreatedDate = DateTime.Now;
row.Subject_CreatedBy = "";
row.Subject_UpdatedDate = DateTime.Now;
row.Subject_UpdatedBy = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new SubjectRow(builder);
}
public SubjectRow GetSubjectRow(int index) {
return (SubjectRow)Rows[index];
}
}
public partial class SubjectRow : DataRow {
internal SubjectRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Subject_ID {
get {
return (System.Guid)this["Subject_ID"];
}
set {
this["Subject_ID"] = value;
}
}
public System.String Subject_Name {
get {
return (System.String)this["Subject_Name"];
}
set {
if( value.Length > 100 ) this["Subject_Name"] = value.Substring(0, 100);
else this["Subject_Name"] = value;
}
}
public System.Guid? Court_ID {
get {
if( IsNull("Court_ID") ) return null;
else return (System.Guid)this["Court_ID"];
}
set {
if( value.HasValue ) this["Court_ID"] = value;
else SetNull(Table.Columns["Court_ID"]);
}
}
public System.Boolean Subject_IsDeleted {
get {
return (System.Boolean)this["Subject_IsDeleted"];
}
set {
this["Subject_IsDeleted"] = value;
}
}
public System.DateTime Subject_CreatedDate {
get {
return (System.DateTime)this["Subject_CreatedDate"];
}
set {
this["Subject_CreatedDate"] = value;
}
}
public System.String Subject_CreatedBy {
get {
return (System.String)this["Subject_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Subject_CreatedBy"] = value.Substring(0, 50);
else this["Subject_CreatedBy"] = value;
}
}
public System.DateTime Subject_UpdatedDate {
get {
return (System.DateTime)this["Subject_UpdatedDate"];
}
set {
this["Subject_UpdatedDate"] = value;
}
}
public System.String Subject_UpdatedBy {
get {
return (System.String)this["Subject_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Subject_UpdatedBy"] = value.Substring(0, 50);
else this["Subject_UpdatedBy"] = value;
}
}
}
public partial class SubjectMinimalizedEntity {
public SubjectMinimalizedEntity() {}
public SubjectMinimalizedEntity(SubjectRow dr) {
this.Subject_ID = dr.Subject_ID;
this.Subject_Name = dr.Subject_Name;
this.Court_ID = dr.Court_ID;
this.Subject_IsDeleted = dr.Subject_IsDeleted;
this.Subject_CreatedDate = dr.Subject_CreatedDate;
this.Subject_CreatedBy = dr.Subject_CreatedBy;
this.Subject_UpdatedDate = dr.Subject_UpdatedDate;
this.Subject_UpdatedBy = dr.Subject_UpdatedBy;
}
public void CopyTo(SubjectRow dr) {
dr.Subject_ID = this.Subject_ID;
dr.Subject_Name = this.Subject_Name;
dr.Court_ID = this.Court_ID;
dr.Subject_IsDeleted = this.Subject_IsDeleted;
dr.Subject_CreatedDate = this.Subject_CreatedDate;
dr.Subject_CreatedBy = this.Subject_CreatedBy;
dr.Subject_UpdatedDate = this.Subject_UpdatedDate;
dr.Subject_UpdatedBy = this.Subject_UpdatedBy;
}
public System.Guid Subject_ID;
public System.String Subject_Name;
public System.Guid? Court_ID;
public System.Boolean Subject_IsDeleted;
public System.DateTime Subject_CreatedDate;
public System.String Subject_CreatedBy;
public System.DateTime Subject_UpdatedDate;
public System.String Subject_UpdatedBy;
}
public partial class SubjectAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public SubjectAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Subject_ID", "Subject_ID");
tmap.ColumnMappings.Add("Subject_Name", "Subject_Name");
tmap.ColumnMappings.Add("Court_ID", "Court_ID");
tmap.ColumnMappings.Add("Subject_IsDeleted", "Subject_IsDeleted");
tmap.ColumnMappings.Add("Subject_CreatedDate", "Subject_CreatedDate");
tmap.ColumnMappings.Add("Subject_CreatedBy", "Subject_CreatedBy");
tmap.ColumnMappings.Add("Subject_UpdatedDate", "Subject_UpdatedDate");
tmap.ColumnMappings.Add("Subject_UpdatedBy", "Subject_UpdatedBy");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Subject] ([Subject_ID], [Subject_Name], [Court_ID], [Subject_IsDeleted], [Subject_CreatedDate], [Subject_CreatedBy], [Subject_UpdatedDate], [Subject_UpdatedBy]) VALUES (@Subject_ID, @Subject_Name, @Court_ID, @Subject_IsDeleted, @Subject_CreatedDate, @Subject_CreatedBy, @Subject_UpdatedDate, @Subject_UpdatedBy)");
adapter.InsertCommand.Parameters.Add("@Subject_ID", SqlDbType.UniqueIdentifier, 0, "Subject_ID");
adapter.InsertCommand.Parameters.Add("@Subject_Name", SqlDbType.NVarChar, 0, "Subject_Name");
adapter.InsertCommand.Parameters.Add("@Court_ID", SqlDbType.UniqueIdentifier, 0, "Court_ID");
adapter.InsertCommand.Parameters.Add("@Subject_IsDeleted", SqlDbType.Bit, 0, "Subject_IsDeleted");
adapter.InsertCommand.Parameters.Add("@Subject_CreatedDate", SqlDbType.DateTime, 0, "Subject_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Subject_CreatedBy", SqlDbType.NVarChar, 0, "Subject_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Subject_UpdatedDate", SqlDbType.DateTime, 0, "Subject_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Subject_UpdatedBy", SqlDbType.NVarChar, 0, "Subject_UpdatedBy");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Subject] SET [Subject_ID] = @Subject_ID, [Subject_Name] = @Subject_Name, [Court_ID] = @Court_ID, [Subject_IsDeleted] = @Subject_IsDeleted, [Subject_CreatedDate] = @Subject_CreatedDate, [Subject_CreatedBy] = @Subject_CreatedBy, [Subject_UpdatedDate] = @Subject_UpdatedDate, [Subject_UpdatedBy] = @Subject_UpdatedBy WHERE [Subject_ID] = @o_Subject_ID");
adapter.UpdateCommand.Parameters.Add("@Subject_ID", SqlDbType.UniqueIdentifier, 0, "Subject_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Subject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Subject_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Subject_Name", SqlDbType.NVarChar, 0, "Subject_Name");
adapter.UpdateCommand.Parameters.Add("@Court_ID", SqlDbType.UniqueIdentifier, 0, "Court_ID");
adapter.UpdateCommand.Parameters.Add("@Subject_IsDeleted", SqlDbType.Bit, 0, "Subject_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@Subject_CreatedDate", SqlDbType.DateTime, 0, "Subject_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Subject_CreatedBy", SqlDbType.NVarChar, 0, "Subject_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Subject_UpdatedDate", SqlDbType.DateTime, 0, "Subject_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Subject_UpdatedBy", SqlDbType.NVarChar, 0, "Subject_UpdatedBy");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Subject] WHERE [Subject_ID] = @o_Subject_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Subject_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Subject_ID", DataRowVersion.Original, null));
}
public void Update(SubjectTable tbl) {
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(SubjectRow dr) {
 DA.ExecuteAdapter(Adapter, dr);
}
public SubjectRow GetBySubject_ID(System.Guid Subject_ID ) {
string sql = "SELECT * FROM [Subject] WHERE [Subject_ID] = @Subject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Subject_ID", Subject_ID);

SubjectTable tbl = new SubjectTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetSubjectRow(0);
}
public int CountBySubject_ID(System.Guid Subject_ID ) {
string sql = "SELECT COUNT(*) FROM [Subject] WHERE [Subject_ID] = @Subject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Subject_ID", Subject_ID);

return DA.ExecuteInt32(com);
}
public int DeleteBySubject_ID(System.Guid Subject_ID ) {
string sql = "DELETE FROM [Subject] WHERE [Subject_ID] = @Subject_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Subject_ID", Subject_ID);

return DA.ExecuteNonQuery(com);
}
}
}
