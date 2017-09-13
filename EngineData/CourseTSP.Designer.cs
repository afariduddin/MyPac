using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CourseTSPTable : DataTable {
// column indexes
public const int CourseTSP_IDColumnIndex = 0;
public const int Course_IDColumnIndex = 1;
public const int TSP_IDColumnIndex = 2;
public CourseTSPTable() {
TableName = "[CourseTSP]";
// column CourseTSP_ID
DataColumn CourseTSP_IDCol = new DataColumn("CourseTSP_ID", typeof(System.Guid));
CourseTSP_IDCol.ReadOnly = false;
CourseTSP_IDCol.AllowDBNull = false;
Columns.Add(CourseTSP_IDCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = false;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
}
public CourseTSPRow NewCourseTSPRow() {
CourseTSPRow row = (CourseTSPRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CourseTSPRow row) {
row.CourseTSP_ID = Guid.Empty;
row.Course_ID = Guid.Empty;
row.TSP_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CourseTSPRow(builder);
}
public CourseTSPRow GetCourseTSPRow(int index) {
return (CourseTSPRow)Rows[index];
}
}
public partial class CourseTSPRow : DataRow {
internal CourseTSPRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid CourseTSP_ID {
get {
return (System.Guid)this["CourseTSP_ID"];
}
set {
this["CourseTSP_ID"] = value;
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
set {
this["Course_ID"] = value;
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
set {
this["TSP_ID"] = value;
}
}
}
public partial class CourseTSPMinimalizedEntity {
public CourseTSPMinimalizedEntity() {}
public CourseTSPMinimalizedEntity(CourseTSPRow dr) {
this.CourseTSP_ID = dr.CourseTSP_ID;
this.Course_ID = dr.Course_ID;
this.TSP_ID = dr.TSP_ID;
}
public void CopyTo(CourseTSPRow dr) {
dr.CourseTSP_ID = this.CourseTSP_ID;
dr.Course_ID = this.Course_ID;
dr.TSP_ID = this.TSP_ID;
}
public System.Guid CourseTSP_ID;
public System.Guid Course_ID;
public System.Guid TSP_ID;
}
public partial class CourseTSPAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CourseTSPAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("CourseTSP_ID", "CourseTSP_ID");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [CourseTSP] ([CourseTSP_ID], [Course_ID], [TSP_ID]) VALUES (@CourseTSP_ID, @Course_ID, @TSP_ID)");
adapter.InsertCommand.Parameters.Add("@CourseTSP_ID", SqlDbType.UniqueIdentifier, 0, "CourseTSP_ID");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.InsertCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [CourseTSP] SET [CourseTSP_ID] = @CourseTSP_ID, [Course_ID] = @Course_ID, [TSP_ID] = @TSP_ID WHERE [CourseTSP_ID] = @o_CourseTSP_ID");
adapter.UpdateCommand.Parameters.Add("@CourseTSP_ID", SqlDbType.UniqueIdentifier, 0, "CourseTSP_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_CourseTSP_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CourseTSP_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [CourseTSP] WHERE [CourseTSP_ID] = @o_CourseTSP_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_CourseTSP_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "CourseTSP_ID", DataRowVersion.Original, null));
}
public void Update(CourseTSPTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CourseTSPRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CourseTSPRow GetByCourseTSP_ID(System.Guid CourseTSP_ID ) {
string sql = "SELECT * FROM [CourseTSP] WHERE [CourseTSP_ID] = @CourseTSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseTSP_ID", CourseTSP_ID);

CourseTSPTable tbl = new CourseTSPTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCourseTSPRow(0);
}
public int CountByCourseTSP_ID(System.Guid CourseTSP_ID ) {
string sql = "SELECT COUNT(*) FROM [CourseTSP] WHERE [CourseTSP_ID] = @CourseTSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseTSP_ID", CourseTSP_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCourseTSP_ID(System.Guid CourseTSP_ID, IActivityLog log ) {
string sql = "DELETE FROM [CourseTSP] WHERE [CourseTSP_ID] = @CourseTSP_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("CourseTSP_ID", CourseTSP_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public CourseTSPTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CourseTSP] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
CourseTSPTable tbl = new CourseTSPTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CourseTSP] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CourseTSP] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public CourseTSPTable GetByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CourseTSP] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
CourseTSPTable tbl = new CourseTSPTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CourseTSP] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByTSP_ID(System.Guid TSP_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CourseTSP] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
