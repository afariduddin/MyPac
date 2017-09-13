using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CoachingItemTable : DataTable {
// column indexes
public const int CoachingItem_IDColumnIndex = 0;
public const int Coaching_IDColumnIndex = 1;
public const int CoachingItem_DescriptionColumnIndex = 2;
public const int CoachingItem_RemarkColumnIndex = 3;
public const int CoachingItem_CreatedByColumnIndex = 4;
public const int CoachingItem_CreatedDateColumnIndex = 5;
public const int CoachingItem_UpdatedByColumnIndex = 6;
public const int CoachingItem_UpdatedDateColumnIndex = 7;
public const int CoachingItem_DateColumnIndex = 8;
public CoachingItemTable() {
TableName = "[CoachingItem]";
// column CoachingItem_ID
DataColumn CoachingItem_IDCol = new DataColumn("CoachingItem_ID", typeof(System.Guid));
CoachingItem_IDCol.ReadOnly = false;
CoachingItem_IDCol.AllowDBNull = false;
Columns.Add(CoachingItem_IDCol);
// column Coaching_ID
DataColumn Coaching_IDCol = new DataColumn("Coaching_ID", typeof(System.Guid));
Coaching_IDCol.ReadOnly = false;
Coaching_IDCol.AllowDBNull = false;
Columns.Add(Coaching_IDCol);
// column CoachingItem_Description
DataColumn CoachingItem_DescriptionCol = new DataColumn("CoachingItem_Description", typeof(System.String));
CoachingItem_DescriptionCol.ReadOnly = false;
CoachingItem_DescriptionCol.AllowDBNull = false;
Columns.Add(CoachingItem_DescriptionCol);
// column CoachingItem_Remark
DataColumn CoachingItem_RemarkCol = new DataColumn("CoachingItem_Remark", typeof(System.String));
CoachingItem_RemarkCol.ReadOnly = false;
CoachingItem_RemarkCol.AllowDBNull = false;
Columns.Add(CoachingItem_RemarkCol);
// column CoachingItem_CreatedBy
DataColumn CoachingItem_CreatedByCol = new DataColumn("CoachingItem_CreatedBy", typeof(System.String));
CoachingItem_CreatedByCol.ReadOnly = false;
CoachingItem_CreatedByCol.AllowDBNull = false;
Columns.Add(CoachingItem_CreatedByCol);
// column CoachingItem_CreatedDate
DataColumn CoachingItem_CreatedDateCol = new DataColumn("CoachingItem_CreatedDate", typeof(System.DateTime));
CoachingItem_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
CoachingItem_CreatedDateCol.ReadOnly = false;
CoachingItem_CreatedDateCol.AllowDBNull = false;
Columns.Add(CoachingItem_CreatedDateCol);
// column CoachingItem_UpdatedBy
DataColumn CoachingItem_UpdatedByCol = new DataColumn("CoachingItem_UpdatedBy", typeof(System.String));
CoachingItem_UpdatedByCol.ReadOnly = false;
CoachingItem_UpdatedByCol.AllowDBNull = false;
Columns.Add(CoachingItem_UpdatedByCol);
// column CoachingItem_UpdatedDate
DataColumn CoachingItem_UpdatedDateCol = new DataColumn("CoachingItem_UpdatedDate", typeof(System.DateTime));
CoachingItem_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
CoachingItem_UpdatedDateCol.ReadOnly = false;
CoachingItem_UpdatedDateCol.AllowDBNull = false;
Columns.Add(CoachingItem_UpdatedDateCol);
// column CoachingItem_Date
DataColumn CoachingItem_DateCol = new DataColumn("CoachingItem_Date", typeof(System.DateTime));
CoachingItem_DateCol.DateTimeMode = DataSetDateTime.Local;
CoachingItem_DateCol.ReadOnly = false;
CoachingItem_DateCol.AllowDBNull = false;
Columns.Add(CoachingItem_DateCol);
}
public CoachingItemRow NewCoachingItemRow() {
CoachingItemRow row = (CoachingItemRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CoachingItemRow row) {
row.CoachingItem_ID = Guid.Empty;
row.Coaching_ID = Guid.Empty;
row.CoachingItem_Description = "";
row.CoachingItem_Remark = "";
row.CoachingItem_CreatedBy = "";
row.CoachingItem_CreatedDate = DateTime.Now;
row.CoachingItem_UpdatedBy = "";
row.CoachingItem_UpdatedDate = DateTime.Now;
row.CoachingItem_Date = DateTime.Now;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CoachingItemRow(builder);
}
public CoachingItemRow GetCoachingItemRow(int index) {
return (CoachingItemRow)Rows[index];
}
}
public partial class CoachingItemRow : DataRow {
internal CoachingItemRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid CoachingItem_ID {
get {
return (System.Guid)this["CoachingItem_ID"];
}
set {
this["CoachingItem_ID"] = value;
}
}
public System.Guid Coaching_ID {
get {
return (System.Guid)this["Coaching_ID"];
}
set {
this["Coaching_ID"] = value;
}
}
public System.String CoachingItem_Description {
get {
return (System.String)this["CoachingItem_Description"];
}
set {
if( value.Length > 500 ) this["CoachingItem_Description"] = value.Substring(0, 500);
else this["CoachingItem_Description"] = value;
}
}
public System.String CoachingItem_Remark {
get {
return (System.String)this["CoachingItem_Remark"];
}
set {
if( value.Length > 250 ) this["CoachingItem_Remark"] = value.Substring(0, 250);
else this["CoachingItem_Remark"] = value;
}
}
public System.String CoachingItem_CreatedBy {
get {
return (System.String)this["CoachingItem_CreatedBy"];
}
set {
if( value.Length > 50 ) this["CoachingItem_CreatedBy"] = value.Substring(0, 50);
else this["CoachingItem_CreatedBy"] = value;
}
}
public System.DateTime CoachingItem_CreatedDate {
get {
return (System.DateTime)this["CoachingItem_CreatedDate"];
}
set {
this["CoachingItem_CreatedDate"] = value;
}
}
public System.String CoachingItem_UpdatedBy {
get {
return (System.String)this["CoachingItem_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["CoachingItem_UpdatedBy"] = value.Substring(0, 50);
else this["CoachingItem_UpdatedBy"] = value;
}
}
public System.DateTime CoachingItem_UpdatedDate {
get {
return (System.DateTime)this["CoachingItem_UpdatedDate"];
}
set {
this["CoachingItem_UpdatedDate"] = value;
}
}
public System.DateTime CoachingItem_Date {
get {
return (System.DateTime)this["CoachingItem_Date"];
}
set {
this["CoachingItem_Date"] = value;
}
}
}
public partial class CoachingItemMinimalizedEntity {
public CoachingItemMinimalizedEntity() {}
public CoachingItemMinimalizedEntity(CoachingItemRow dr) {
this.CoachingItem_ID = dr.CoachingItem_ID;
this.Coaching_ID = dr.Coaching_ID;
this.CoachingItem_Description = dr.CoachingItem_Description;
this.CoachingItem_Remark = dr.CoachingItem_Remark;
this.CoachingItem_CreatedBy = dr.CoachingItem_CreatedBy;
this.CoachingItem_CreatedDate = dr.CoachingItem_CreatedDate;
this.CoachingItem_UpdatedBy = dr.CoachingItem_UpdatedBy;
this.CoachingItem_UpdatedDate = dr.CoachingItem_UpdatedDate;
this.CoachingItem_Date = dr.CoachingItem_Date;
}
public void CopyTo(CoachingItemRow dr) {
dr.CoachingItem_ID = this.CoachingItem_ID;
dr.Coaching_ID = this.Coaching_ID;
dr.CoachingItem_Description = this.CoachingItem_Description;
dr.CoachingItem_Remark = this.CoachingItem_Remark;
dr.CoachingItem_CreatedBy = this.CoachingItem_CreatedBy;
dr.CoachingItem_CreatedDate = this.CoachingItem_CreatedDate;
dr.CoachingItem_UpdatedBy = this.CoachingItem_UpdatedBy;
dr.CoachingItem_UpdatedDate = this.CoachingItem_UpdatedDate;
dr.CoachingItem_Date = this.CoachingItem_Date;
}
public System.Guid CoachingItem_ID;
public System.Guid Coaching_ID;
public System.String CoachingItem_Description;
public System.String CoachingItem_Remark;
public System.String CoachingItem_CreatedBy;
public System.DateTime CoachingItem_CreatedDate;
public System.String CoachingItem_UpdatedBy;
public System.DateTime CoachingItem_UpdatedDate;
public System.DateTime CoachingItem_Date;
}
public partial class CoachingItemAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CoachingItemAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("CoachingItem_ID", "CoachingItem_ID");
tmap.ColumnMappings.Add("Coaching_ID", "Coaching_ID");
tmap.ColumnMappings.Add("CoachingItem_Description", "CoachingItem_Description");
tmap.ColumnMappings.Add("CoachingItem_Remark", "CoachingItem_Remark");
tmap.ColumnMappings.Add("CoachingItem_CreatedBy", "CoachingItem_CreatedBy");
tmap.ColumnMappings.Add("CoachingItem_CreatedDate", "CoachingItem_CreatedDate");
tmap.ColumnMappings.Add("CoachingItem_UpdatedBy", "CoachingItem_UpdatedBy");
tmap.ColumnMappings.Add("CoachingItem_UpdatedDate", "CoachingItem_UpdatedDate");
tmap.ColumnMappings.Add("CoachingItem_Date", "CoachingItem_Date");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [CoachingItem] ([CoachingItem_ID], [Coaching_ID], [CoachingItem_Description], [CoachingItem_Remark], [CoachingItem_CreatedBy], [CoachingItem_CreatedDate], [CoachingItem_UpdatedBy], [CoachingItem_UpdatedDate], [CoachingItem_Date]) VALUES (@CoachingItem_ID, @Coaching_ID, @CoachingItem_Description, @CoachingItem_Remark, @CoachingItem_CreatedBy, @CoachingItem_CreatedDate, @CoachingItem_UpdatedBy, @CoachingItem_UpdatedDate, @CoachingItem_Date)");
adapter.InsertCommand.Parameters.Add("@CoachingItem_ID", SqlDbType.UniqueIdentifier, 0, "CoachingItem_ID");
adapter.InsertCommand.Parameters.Add("@Coaching_ID", SqlDbType.UniqueIdentifier, 0, "Coaching_ID");
adapter.InsertCommand.Parameters.Add("@CoachingItem_Description", SqlDbType.NVarChar, 0, "CoachingItem_Description");
adapter.InsertCommand.Parameters.Add("@CoachingItem_Remark", SqlDbType.NVarChar, 0, "CoachingItem_Remark");
adapter.InsertCommand.Parameters.Add("@CoachingItem_CreatedBy", SqlDbType.NVarChar, 0, "CoachingItem_CreatedBy");
adapter.InsertCommand.Parameters.Add("@CoachingItem_CreatedDate", SqlDbType.DateTime, 0, "CoachingItem_CreatedDate");
adapter.InsertCommand.Parameters.Add("@CoachingItem_UpdatedBy", SqlDbType.NVarChar, 0, "CoachingItem_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@CoachingItem_UpdatedDate", SqlDbType.DateTime, 0, "CoachingItem_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@CoachingItem_Date", SqlDbType.DateTime, 0, "CoachingItem_Date");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [CoachingItem] SET [CoachingItem_ID] = @CoachingItem_ID, [Coaching_ID] = @Coaching_ID, [CoachingItem_Description] = @CoachingItem_Description, [CoachingItem_Remark] = @CoachingItem_Remark, [CoachingItem_CreatedBy] = @CoachingItem_CreatedBy, [CoachingItem_CreatedDate] = @CoachingItem_CreatedDate, [CoachingItem_UpdatedBy] = @CoachingItem_UpdatedBy, [CoachingItem_UpdatedDate] = @CoachingItem_UpdatedDate, [CoachingItem_Date] = @CoachingItem_Date WHERE [CoachingItem_ID] = @o_CoachingItem_ID");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_ID", SqlDbType.UniqueIdentifier, 0, "CoachingItem_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_CoachingItem_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CoachingItem_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Coaching_ID", SqlDbType.UniqueIdentifier, 0, "Coaching_ID");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_Description", SqlDbType.NVarChar, 0, "CoachingItem_Description");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_Remark", SqlDbType.NVarChar, 0, "CoachingItem_Remark");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_CreatedBy", SqlDbType.NVarChar, 0, "CoachingItem_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_CreatedDate", SqlDbType.DateTime, 0, "CoachingItem_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_UpdatedBy", SqlDbType.NVarChar, 0, "CoachingItem_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_UpdatedDate", SqlDbType.DateTime, 0, "CoachingItem_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@CoachingItem_Date", SqlDbType.DateTime, 0, "CoachingItem_Date");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [CoachingItem] WHERE [CoachingItem_ID] = @o_CoachingItem_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_CoachingItem_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CoachingItem_ID", DataRowVersion.Original, null));
}
public void Update(CoachingItemTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CoachingItemRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CoachingItemRow GetByCoachingItem_ID(System.Guid CoachingItem_ID ) {
string sql = "SELECT * FROM [CoachingItem] WHERE [CoachingItem_ID] = @CoachingItem_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CoachingItem_ID", CoachingItem_ID);

CoachingItemTable tbl = new CoachingItemTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCoachingItemRow(0);
}
public int CountByCoachingItem_ID(System.Guid CoachingItem_ID ) {
string sql = "SELECT COUNT(*) FROM [CoachingItem] WHERE [CoachingItem_ID] = @CoachingItem_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CoachingItem_ID", CoachingItem_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCoachingItem_ID(System.Guid CoachingItem_ID, IActivityLog log ) {
string sql = "DELETE FROM [CoachingItem] WHERE [CoachingItem_ID] = @CoachingItem_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CoachingItem_ID", CoachingItem_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public CoachingItemTable GetByCoaching_ID(System.Guid Coaching_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CoachingItem] WHERE [Coaching_ID] = @Coaching_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Coaching_ID", Coaching_ID);
CoachingItemTable tbl = new CoachingItemTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCoaching_ID(System.Guid Coaching_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CoachingItem] WHERE [Coaching_ID] = @Coaching_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Coaching_ID", Coaching_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCoaching_ID(System.Guid Coaching_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CoachingItem] WHERE [Coaching_ID] = @Coaching_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Coaching_ID", Coaching_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
