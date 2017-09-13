using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CountryTable : DataTable {
// column indexes
public const int Country_IDColumnIndex = 0;
public const int Country_NameColumnIndex = 1;
public CountryTable() {
TableName = "[Country]";
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = false;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Country_Name
DataColumn Country_NameCol = new DataColumn("Country_Name", typeof(System.String));
Country_NameCol.ReadOnly = false;
Country_NameCol.AllowDBNull = false;
Columns.Add(Country_NameCol);
}
public CountryRow NewCountryRow() {
CountryRow row = (CountryRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CountryRow row) {
row.Country_ID = Guid.Empty;
row.Country_Name = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CountryRow(builder);
}
public CountryRow GetCountryRow(int index) {
return (CountryRow)Rows[index];
}
}
public partial class CountryRow : DataRow {
internal CountryRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Country_ID {
get {
return (System.Guid)this["Country_ID"];
}
set {
this["Country_ID"] = value;
}
}
public System.String Country_Name {
get {
return (System.String)this["Country_Name"];
}
set {
if( value.Length > 50 ) this["Country_Name"] = value.Substring(0, 50);
else this["Country_Name"] = value;
}
}
}
public partial class CountryMinimalizedEntity {
public CountryMinimalizedEntity() {}
public CountryMinimalizedEntity(CountryRow dr) {
this.Country_ID = dr.Country_ID;
this.Country_Name = dr.Country_Name;
}
public void CopyTo(CountryRow dr) {
dr.Country_ID = this.Country_ID;
dr.Country_Name = this.Country_Name;
}
public System.Guid Country_ID;
public System.String Country_Name;
}
public partial class CountryAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CountryAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Country_ID", "Country_ID");
tmap.ColumnMappings.Add("Country_Name", "Country_Name");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Country] ([Country_ID], [Country_Name]) VALUES (@Country_ID, @Country_Name)");
adapter.InsertCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.InsertCommand.Parameters.Add("@Country_Name", SqlDbType.NVarChar, 0, "Country_Name");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Country] SET [Country_ID] = @Country_ID, [Country_Name] = @Country_Name WHERE [Country_ID] = @o_Country_ID");
adapter.UpdateCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Country_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Country_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Country_Name", SqlDbType.NVarChar, 0, "Country_Name");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Country] WHERE [Country_ID] = @o_Country_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Country_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Country_ID", DataRowVersion.Original, null));
}
public void Update(CountryTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CountryRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CountryRow GetByCountry_ID(System.Guid Country_ID ) {
string sql = "SELECT * FROM [Country] WHERE [Country_ID] = @Country_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Country_ID", Country_ID);

CountryTable tbl = new CountryTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCountryRow(0);
}
public int CountByCountry_ID(System.Guid Country_ID ) {
string sql = "SELECT COUNT(*) FROM [Country] WHERE [Country_ID] = @Country_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Country_ID", Country_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCountry_ID(System.Guid Country_ID, IActivityLog log ) {
string sql = "DELETE FROM [Country] WHERE [Country_ID] = @Country_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Country_ID", Country_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
