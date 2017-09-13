using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class SponsorTable : DataTable {
// column indexes
public const int Sponsor_IDColumnIndex = 0;
public const int Sponsor_CodeColumnIndex = 1;
public const int Sponsor_LabelColumnIndex = 2;
public const int Sponsor_IsDeletedColumnIndex = 3;
public const int Sponsor_UpdatedColumnIndex = 4;
public const int Sponsor_UpdatedByColumnIndex = 5;
public const int Sponsor_CreatedColumnIndex = 6;
public const int Sponsor_CreatedByColumnIndex = 7;
public SponsorTable() {
TableName = "[Sponsor]";
// column Sponsor_ID
DataColumn Sponsor_IDCol = new DataColumn("Sponsor_ID", typeof(System.Guid));
Sponsor_IDCol.ReadOnly = false;
Sponsor_IDCol.AllowDBNull = false;
Columns.Add(Sponsor_IDCol);
// column Sponsor_Code
DataColumn Sponsor_CodeCol = new DataColumn("Sponsor_Code", typeof(System.String));
Sponsor_CodeCol.ReadOnly = false;
Sponsor_CodeCol.AllowDBNull = false;
Columns.Add(Sponsor_CodeCol);
// column Sponsor_Label
DataColumn Sponsor_LabelCol = new DataColumn("Sponsor_Label", typeof(System.String));
Sponsor_LabelCol.ReadOnly = false;
Sponsor_LabelCol.AllowDBNull = false;
Columns.Add(Sponsor_LabelCol);
// column Sponsor_IsDeleted
DataColumn Sponsor_IsDeletedCol = new DataColumn("Sponsor_IsDeleted", typeof(System.Boolean));
Sponsor_IsDeletedCol.ReadOnly = false;
Sponsor_IsDeletedCol.AllowDBNull = false;
Columns.Add(Sponsor_IsDeletedCol);
// column Sponsor_Updated
DataColumn Sponsor_UpdatedCol = new DataColumn("Sponsor_Updated", typeof(System.DateTime));
Sponsor_UpdatedCol.DateTimeMode = DataSetDateTime.Utc;
Sponsor_UpdatedCol.ReadOnly = false;
Sponsor_UpdatedCol.AllowDBNull = false;
Columns.Add(Sponsor_UpdatedCol);
// column Sponsor_UpdatedBy
DataColumn Sponsor_UpdatedByCol = new DataColumn("Sponsor_UpdatedBy", typeof(System.String));
Sponsor_UpdatedByCol.ReadOnly = false;
Sponsor_UpdatedByCol.AllowDBNull = false;
Columns.Add(Sponsor_UpdatedByCol);
// column Sponsor_Created
DataColumn Sponsor_CreatedCol = new DataColumn("Sponsor_Created", typeof(System.DateTime));
Sponsor_CreatedCol.DateTimeMode = DataSetDateTime.Utc;
Sponsor_CreatedCol.ReadOnly = false;
Sponsor_CreatedCol.AllowDBNull = false;
Columns.Add(Sponsor_CreatedCol);
// column Sponsor_CreatedBy
DataColumn Sponsor_CreatedByCol = new DataColumn("Sponsor_CreatedBy", typeof(System.String));
Sponsor_CreatedByCol.ReadOnly = false;
Sponsor_CreatedByCol.AllowDBNull = false;
Columns.Add(Sponsor_CreatedByCol);
}
public SponsorRow NewSponsorRow() {
SponsorRow row = (SponsorRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(SponsorRow row) {
row.Sponsor_ID = Guid.Empty;
row.Sponsor_Code = "";
row.Sponsor_Label = "";
row.Sponsor_IsDeleted = false;
row.Sponsor_Updated = DateTime.Now;
row.Sponsor_UpdatedBy = "";
row.Sponsor_Created = DateTime.Now;
row.Sponsor_CreatedBy = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new SponsorRow(builder);
}
public SponsorRow GetSponsorRow(int index) {
return (SponsorRow)Rows[index];
}
}
public partial class SponsorRow : DataRow {
internal SponsorRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Sponsor_ID {
get {
return (System.Guid)this["Sponsor_ID"];
}
set {
this["Sponsor_ID"] = value;
}
}
public System.String Sponsor_Code {
get {
return (System.String)this["Sponsor_Code"];
}
set {
if( value.Length > 50 ) this["Sponsor_Code"] = value.Substring(0, 50);
else this["Sponsor_Code"] = value;
}
}
public System.String Sponsor_Label {
get {
return (System.String)this["Sponsor_Label"];
}
set {
if( value.Length > 250 ) this["Sponsor_Label"] = value.Substring(0, 250);
else this["Sponsor_Label"] = value;
}
}
public System.Boolean Sponsor_IsDeleted {
get {
return (System.Boolean)this["Sponsor_IsDeleted"];
}
set {
this["Sponsor_IsDeleted"] = value;
}
}
public System.DateTime Sponsor_Updated {
get {
return (System.DateTime)this["Sponsor_Updated"];
}
set {
this["Sponsor_Updated"] = value;
}
}
public System.String Sponsor_UpdatedBy {
get {
return (System.String)this["Sponsor_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Sponsor_UpdatedBy"] = value.Substring(0, 50);
else this["Sponsor_UpdatedBy"] = value;
}
}
public System.DateTime Sponsor_Created {
get {
return (System.DateTime)this["Sponsor_Created"];
}
set {
this["Sponsor_Created"] = value;
}
}
public System.String Sponsor_CreatedBy {
get {
return (System.String)this["Sponsor_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Sponsor_CreatedBy"] = value.Substring(0, 50);
else this["Sponsor_CreatedBy"] = value;
}
}
}
public partial class SponsorMinimalizedEntity {
public SponsorMinimalizedEntity() {}
public SponsorMinimalizedEntity(SponsorRow dr) {
this.Sponsor_ID = dr.Sponsor_ID;
this.Sponsor_Code = dr.Sponsor_Code;
this.Sponsor_Label = dr.Sponsor_Label;
this.Sponsor_IsDeleted = dr.Sponsor_IsDeleted;
this.Sponsor_Updated = dr.Sponsor_Updated;
this.Sponsor_UpdatedBy = dr.Sponsor_UpdatedBy;
this.Sponsor_Created = dr.Sponsor_Created;
this.Sponsor_CreatedBy = dr.Sponsor_CreatedBy;
}
public void CopyTo(SponsorRow dr) {
dr.Sponsor_ID = this.Sponsor_ID;
dr.Sponsor_Code = this.Sponsor_Code;
dr.Sponsor_Label = this.Sponsor_Label;
dr.Sponsor_IsDeleted = this.Sponsor_IsDeleted;
dr.Sponsor_Updated = this.Sponsor_Updated;
dr.Sponsor_UpdatedBy = this.Sponsor_UpdatedBy;
dr.Sponsor_Created = this.Sponsor_Created;
dr.Sponsor_CreatedBy = this.Sponsor_CreatedBy;
}
public System.Guid Sponsor_ID;
public System.String Sponsor_Code;
public System.String Sponsor_Label;
public System.Boolean Sponsor_IsDeleted;
public System.DateTime Sponsor_Updated;
public System.String Sponsor_UpdatedBy;
public System.DateTime Sponsor_Created;
public System.String Sponsor_CreatedBy;
}
public partial class SponsorAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public SponsorAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
tmap.ColumnMappings.Add("Sponsor_Code", "Sponsor_Code");
tmap.ColumnMappings.Add("Sponsor_Label", "Sponsor_Label");
tmap.ColumnMappings.Add("Sponsor_IsDeleted", "Sponsor_IsDeleted");
tmap.ColumnMappings.Add("Sponsor_Updated", "Sponsor_Updated");
tmap.ColumnMappings.Add("Sponsor_UpdatedBy", "Sponsor_UpdatedBy");
tmap.ColumnMappings.Add("Sponsor_Created", "Sponsor_Created");
tmap.ColumnMappings.Add("Sponsor_CreatedBy", "Sponsor_CreatedBy");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Sponsor] ([Sponsor_ID], [Sponsor_Code], [Sponsor_Label], [Sponsor_IsDeleted], [Sponsor_Updated], [Sponsor_UpdatedBy], [Sponsor_Created], [Sponsor_CreatedBy]) VALUES (@Sponsor_ID, @Sponsor_Code, @Sponsor_Label, @Sponsor_IsDeleted, @Sponsor_Updated, @Sponsor_UpdatedBy, @Sponsor_Created, @Sponsor_CreatedBy)");
adapter.InsertCommand.Parameters.Add("@Sponsor_ID", SqlDbType.UniqueIdentifier, 0, "Sponsor_ID");
adapter.InsertCommand.Parameters.Add("@Sponsor_Code", SqlDbType.NVarChar, 0, "Sponsor_Code");
adapter.InsertCommand.Parameters.Add("@Sponsor_Label", SqlDbType.NVarChar, 0, "Sponsor_Label");
adapter.InsertCommand.Parameters.Add("@Sponsor_IsDeleted", SqlDbType.Bit, 0, "Sponsor_IsDeleted");
adapter.InsertCommand.Parameters.Add("@Sponsor_Updated", SqlDbType.DateTime, 0, "Sponsor_Updated");
adapter.InsertCommand.Parameters.Add("@Sponsor_UpdatedBy", SqlDbType.NVarChar, 0, "Sponsor_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@Sponsor_Created", SqlDbType.DateTime, 0, "Sponsor_Created");
adapter.InsertCommand.Parameters.Add("@Sponsor_CreatedBy", SqlDbType.NVarChar, 0, "Sponsor_CreatedBy");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Sponsor] SET [Sponsor_ID] = @Sponsor_ID, [Sponsor_Code] = @Sponsor_Code, [Sponsor_Label] = @Sponsor_Label, [Sponsor_IsDeleted] = @Sponsor_IsDeleted, [Sponsor_Updated] = @Sponsor_Updated, [Sponsor_UpdatedBy] = @Sponsor_UpdatedBy, [Sponsor_Created] = @Sponsor_Created, [Sponsor_CreatedBy] = @Sponsor_CreatedBy WHERE [Sponsor_ID] = @o_Sponsor_ID");
adapter.UpdateCommand.Parameters.Add("@Sponsor_ID", SqlDbType.UniqueIdentifier, 0, "Sponsor_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Sponsor_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Sponsor_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Sponsor_Code", SqlDbType.NVarChar, 0, "Sponsor_Code");
adapter.UpdateCommand.Parameters.Add("@Sponsor_Label", SqlDbType.NVarChar, 0, "Sponsor_Label");
adapter.UpdateCommand.Parameters.Add("@Sponsor_IsDeleted", SqlDbType.Bit, 0, "Sponsor_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@Sponsor_Updated", SqlDbType.DateTime, 0, "Sponsor_Updated");
adapter.UpdateCommand.Parameters.Add("@Sponsor_UpdatedBy", SqlDbType.NVarChar, 0, "Sponsor_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@Sponsor_Created", SqlDbType.DateTime, 0, "Sponsor_Created");
adapter.UpdateCommand.Parameters.Add("@Sponsor_CreatedBy", SqlDbType.NVarChar, 0, "Sponsor_CreatedBy");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Sponsor] WHERE [Sponsor_ID] = @o_Sponsor_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Sponsor_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Sponsor_ID", DataRowVersion.Original, null));
}
public void Update(SponsorTable tbl, IActivityLog log)
        {
            Log(tbl, log);
            DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(SponsorRow dr, IActivityLog log)
        {
            Log(dr, log);
            DA.ExecuteAdapter(Adapter, dr);
}
public SponsorRow GetBySponsor_ID(System.Guid Sponsor_ID ) {
string sql = "SELECT * FROM [Sponsor] WHERE [Sponsor_ID] = @Sponsor_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Sponsor_ID", Sponsor_ID);

SponsorTable tbl = new SponsorTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetSponsorRow(0);
}
public int CountBySponsor_ID(System.Guid Sponsor_ID ) {
string sql = "SELECT COUNT(*) FROM [Sponsor] WHERE [Sponsor_ID] = @Sponsor_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Sponsor_ID", Sponsor_ID);

return DA.ExecuteInt32(com);
}
public int DeleteBySponsor_ID(System.Guid Sponsor_ID ) {
string sql = "DELETE FROM [Sponsor] WHERE [Sponsor_ID] = @Sponsor_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Sponsor_ID", Sponsor_ID);

return DA.ExecuteNonQuery(com);
}
}
}
