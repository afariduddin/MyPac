using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class GlobalSettingTable : DataTable {
// column indexes
public const int GlobalSetting_IDColumnIndex = 0;
public const int GlobalSetting_TypeColumnIndex = 1;
public const int GlobalSetting_ValueColumnIndex = 2;
public const int GlobalSetting_CreatedDateColumnIndex = 3;
public const int GlobalSetting_CreatedByColumnIndex = 4;
public const int GlobalSetting_UpdatedDateColumnIndex = 5;
public const int GlobalSetting_UpdatedByColumnIndex = 6;
public GlobalSettingTable() {
TableName = "[GlobalSetting]";
// column GlobalSetting_ID
DataColumn GlobalSetting_IDCol = new DataColumn("GlobalSetting_ID", typeof(System.Guid));
GlobalSetting_IDCol.ReadOnly = false;
GlobalSetting_IDCol.AllowDBNull = false;
Columns.Add(GlobalSetting_IDCol);
// column GlobalSetting_Type
DataColumn GlobalSetting_TypeCol = new DataColumn("GlobalSetting_Type", typeof(System.Int16));
GlobalSetting_TypeCol.ReadOnly = false;
GlobalSetting_TypeCol.AllowDBNull = false;
Columns.Add(GlobalSetting_TypeCol);
// column GlobalSetting_Value
DataColumn GlobalSetting_ValueCol = new DataColumn("GlobalSetting_Value", typeof(System.String));
GlobalSetting_ValueCol.ReadOnly = false;
GlobalSetting_ValueCol.AllowDBNull = false;
Columns.Add(GlobalSetting_ValueCol);
// column GlobalSetting_CreatedDate
DataColumn GlobalSetting_CreatedDateCol = new DataColumn("GlobalSetting_CreatedDate", typeof(System.DateTime));
GlobalSetting_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
GlobalSetting_CreatedDateCol.ReadOnly = false;
GlobalSetting_CreatedDateCol.AllowDBNull = false;
Columns.Add(GlobalSetting_CreatedDateCol);
// column GlobalSetting_CreatedBy
DataColumn GlobalSetting_CreatedByCol = new DataColumn("GlobalSetting_CreatedBy", typeof(System.String));
GlobalSetting_CreatedByCol.ReadOnly = false;
GlobalSetting_CreatedByCol.AllowDBNull = false;
Columns.Add(GlobalSetting_CreatedByCol);
// column GlobalSetting_UpdatedDate
DataColumn GlobalSetting_UpdatedDateCol = new DataColumn("GlobalSetting_UpdatedDate", typeof(System.DateTime));
GlobalSetting_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
GlobalSetting_UpdatedDateCol.ReadOnly = false;
GlobalSetting_UpdatedDateCol.AllowDBNull = false;
Columns.Add(GlobalSetting_UpdatedDateCol);
// column GlobalSetting_UpdatedBy
DataColumn GlobalSetting_UpdatedByCol = new DataColumn("GlobalSetting_UpdatedBy", typeof(System.String));
GlobalSetting_UpdatedByCol.ReadOnly = false;
GlobalSetting_UpdatedByCol.AllowDBNull = false;
Columns.Add(GlobalSetting_UpdatedByCol);
}
public GlobalSettingRow NewGlobalSettingRow() {
GlobalSettingRow row = (GlobalSettingRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(GlobalSettingRow row) {
row.GlobalSetting_ID = Guid.Empty;
row.GlobalSetting_Type = 0;
row.GlobalSetting_Value = "";
row.GlobalSetting_CreatedDate = DateTime.Now;
row.GlobalSetting_CreatedBy = "";
row.GlobalSetting_UpdatedDate = DateTime.Now;
row.GlobalSetting_UpdatedBy = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new GlobalSettingRow(builder);
}
public GlobalSettingRow GetGlobalSettingRow(int index) {
return (GlobalSettingRow)Rows[index];
}
}
public partial class GlobalSettingRow : DataRow {
internal GlobalSettingRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid GlobalSetting_ID {
get {
return (System.Guid)this["GlobalSetting_ID"];
}
set {
this["GlobalSetting_ID"] = value;
}
}
public System.Int16 GlobalSetting_Type {
get {
return (System.Int16)this["GlobalSetting_Type"];
}
set {
this["GlobalSetting_Type"] = value;
}
}
public System.String GlobalSetting_Value {
get {
return (System.String)this["GlobalSetting_Value"];
}
set {
this["GlobalSetting_Value"] = value;
}
}
public System.DateTime GlobalSetting_CreatedDate {
get {
return (System.DateTime)this["GlobalSetting_CreatedDate"];
}
set {
this["GlobalSetting_CreatedDate"] = value;
}
}
public System.String GlobalSetting_CreatedBy {
get {
return (System.String)this["GlobalSetting_CreatedBy"];
}
set {
if( value.Length > 50 ) this["GlobalSetting_CreatedBy"] = value.Substring(0, 50);
else this["GlobalSetting_CreatedBy"] = value;
}
}
public System.DateTime GlobalSetting_UpdatedDate {
get {
return (System.DateTime)this["GlobalSetting_UpdatedDate"];
}
set {
this["GlobalSetting_UpdatedDate"] = value;
}
}
public System.String GlobalSetting_UpdatedBy {
get {
return (System.String)this["GlobalSetting_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["GlobalSetting_UpdatedBy"] = value.Substring(0, 50);
else this["GlobalSetting_UpdatedBy"] = value;
}
}
}
public partial class GlobalSettingMinimalizedEntity {
public GlobalSettingMinimalizedEntity() {}
public GlobalSettingMinimalizedEntity(GlobalSettingRow dr) {
this.GlobalSetting_ID = dr.GlobalSetting_ID;
this.GlobalSetting_Type = dr.GlobalSetting_Type;
this.GlobalSetting_Value = dr.GlobalSetting_Value;
this.GlobalSetting_CreatedDate = dr.GlobalSetting_CreatedDate;
this.GlobalSetting_CreatedBy = dr.GlobalSetting_CreatedBy;
this.GlobalSetting_UpdatedDate = dr.GlobalSetting_UpdatedDate;
this.GlobalSetting_UpdatedBy = dr.GlobalSetting_UpdatedBy;
}
public void CopyTo(GlobalSettingRow dr) {
dr.GlobalSetting_ID = this.GlobalSetting_ID;
dr.GlobalSetting_Type = this.GlobalSetting_Type;
dr.GlobalSetting_Value = this.GlobalSetting_Value;
dr.GlobalSetting_CreatedDate = this.GlobalSetting_CreatedDate;
dr.GlobalSetting_CreatedBy = this.GlobalSetting_CreatedBy;
dr.GlobalSetting_UpdatedDate = this.GlobalSetting_UpdatedDate;
dr.GlobalSetting_UpdatedBy = this.GlobalSetting_UpdatedBy;
}
public System.Guid GlobalSetting_ID;
public System.Int16 GlobalSetting_Type;
public System.String GlobalSetting_Value;
public System.DateTime GlobalSetting_CreatedDate;
public System.String GlobalSetting_CreatedBy;
public System.DateTime GlobalSetting_UpdatedDate;
public System.String GlobalSetting_UpdatedBy;
}
public partial class GlobalSettingAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public GlobalSettingAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("GlobalSetting_ID", "GlobalSetting_ID");
tmap.ColumnMappings.Add("GlobalSetting_Type", "GlobalSetting_Type");
tmap.ColumnMappings.Add("GlobalSetting_Value", "GlobalSetting_Value");
tmap.ColumnMappings.Add("GlobalSetting_CreatedDate", "GlobalSetting_CreatedDate");
tmap.ColumnMappings.Add("GlobalSetting_CreatedBy", "GlobalSetting_CreatedBy");
tmap.ColumnMappings.Add("GlobalSetting_UpdatedDate", "GlobalSetting_UpdatedDate");
tmap.ColumnMappings.Add("GlobalSetting_UpdatedBy", "GlobalSetting_UpdatedBy");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [GlobalSetting] ([GlobalSetting_ID], [GlobalSetting_Type], [GlobalSetting_Value], [GlobalSetting_CreatedDate], [GlobalSetting_CreatedBy], [GlobalSetting_UpdatedDate], [GlobalSetting_UpdatedBy]) VALUES (@GlobalSetting_ID, @GlobalSetting_Type, @GlobalSetting_Value, @GlobalSetting_CreatedDate, @GlobalSetting_CreatedBy, @GlobalSetting_UpdatedDate, @GlobalSetting_UpdatedBy)");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_ID", SqlDbType.UniqueIdentifier, 0, "GlobalSetting_ID");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_Type", SqlDbType.SmallInt, 0, "GlobalSetting_Type");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_Value", SqlDbType.NVarChar, 0, "GlobalSetting_Value");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_CreatedDate", SqlDbType.DateTime, 0, "GlobalSetting_CreatedDate");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_CreatedBy", SqlDbType.NVarChar, 0, "GlobalSetting_CreatedBy");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_UpdatedDate", SqlDbType.DateTime, 0, "GlobalSetting_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@GlobalSetting_UpdatedBy", SqlDbType.NVarChar, 0, "GlobalSetting_UpdatedBy");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [GlobalSetting] SET [GlobalSetting_ID] = @GlobalSetting_ID, [GlobalSetting_Type] = @GlobalSetting_Type, [GlobalSetting_Value] = @GlobalSetting_Value, [GlobalSetting_CreatedDate] = @GlobalSetting_CreatedDate, [GlobalSetting_CreatedBy] = @GlobalSetting_CreatedBy, [GlobalSetting_UpdatedDate] = @GlobalSetting_UpdatedDate, [GlobalSetting_UpdatedBy] = @GlobalSetting_UpdatedBy WHERE [GlobalSetting_ID] = @o_GlobalSetting_ID");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_ID", SqlDbType.UniqueIdentifier, 0, "GlobalSetting_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_GlobalSetting_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "GlobalSetting_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_Type", SqlDbType.SmallInt, 0, "GlobalSetting_Type");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_Value", SqlDbType.NVarChar, 0, "GlobalSetting_Value");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_CreatedDate", SqlDbType.DateTime, 0, "GlobalSetting_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_CreatedBy", SqlDbType.NVarChar, 0, "GlobalSetting_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_UpdatedDate", SqlDbType.DateTime, 0, "GlobalSetting_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@GlobalSetting_UpdatedBy", SqlDbType.NVarChar, 0, "GlobalSetting_UpdatedBy");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [GlobalSetting] WHERE [GlobalSetting_ID] = @o_GlobalSetting_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_GlobalSetting_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "GlobalSetting_ID", DataRowVersion.Original, null));
}
public void Update(GlobalSettingTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(GlobalSettingRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public GlobalSettingRow GetByGlobalSetting_ID(System.Guid GlobalSetting_ID ) {
string sql = "SELECT * FROM [GlobalSetting] WHERE [GlobalSetting_ID] = @GlobalSetting_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("GlobalSetting_ID", GlobalSetting_ID);

GlobalSettingTable tbl = new GlobalSettingTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetGlobalSettingRow(0);
}
public int CountByGlobalSetting_ID(System.Guid GlobalSetting_ID ) {
string sql = "SELECT COUNT(*) FROM [GlobalSetting] WHERE [GlobalSetting_ID] = @GlobalSetting_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("GlobalSetting_ID", GlobalSetting_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByGlobalSetting_ID(System.Guid GlobalSetting_ID, IActivityLog log ) {
string sql = "DELETE FROM [GlobalSetting] WHERE [GlobalSetting_ID] = @GlobalSetting_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("GlobalSetting_ID", GlobalSetting_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
