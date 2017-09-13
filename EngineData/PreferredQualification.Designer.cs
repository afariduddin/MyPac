using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PreferredQualificationTable : DataTable {
// column indexes
public const int Candidate_IDColumnIndex = 0;
public const int Course_IDColumnIndex = 1;
public PreferredQualificationTable() {
TableName = "[PreferredQualification]";
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = false;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
}
public PreferredQualificationRow NewPreferredQualificationRow() {
PreferredQualificationRow row = (PreferredQualificationRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(PreferredQualificationRow row) {
row.Candidate_ID = Guid.Empty;
row.Course_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PreferredQualificationRow(builder);
}
public PreferredQualificationRow GetPreferredQualificationRow(int index) {
return (PreferredQualificationRow)Rows[index];
}
}
public partial class PreferredQualificationRow : DataRow {
internal PreferredQualificationRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
set {
this["Candidate_ID"] = value;
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
}
public partial class PreferredQualificationMinimalizedEntity {
public PreferredQualificationMinimalizedEntity() {}
public PreferredQualificationMinimalizedEntity(PreferredQualificationRow dr) {
this.Candidate_ID = dr.Candidate_ID;
this.Course_ID = dr.Course_ID;
}
public void CopyTo(PreferredQualificationRow dr) {
dr.Candidate_ID = this.Candidate_ID;
dr.Course_ID = this.Course_ID;
}
public System.Guid Candidate_ID;
public System.Guid Course_ID;
}
public partial class PreferredQualificationAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PreferredQualificationAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Candidate_ID", "Candidate_ID");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [PreferredQualification] ([Candidate_ID], [Course_ID]) VALUES (@Candidate_ID, @Course_ID)");
adapter.InsertCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [PreferredQualification] SET [Candidate_ID] = @Candidate_ID, [Course_ID] = @Course_ID WHERE [Candidate_ID] = @o_Candidate_ID AND [Course_ID] = @o_Course_ID");
adapter.UpdateCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [PreferredQualification] WHERE [Candidate_ID] = @o_Candidate_ID AND [Course_ID] = @o_Course_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
}
public void Update(PreferredQualificationTable tbl) {
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(PreferredQualificationRow dr) {
 DA.ExecuteAdapter(Adapter, dr);
}
public PreferredQualificationRow GetByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID ) {
string sql = "SELECT * FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

PreferredQualificationTable tbl = new PreferredQualificationTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPreferredQualificationRow(0);
}
public int CountByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID ) {
string sql = "SELECT COUNT(*) FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID ) {
string sql = "DELETE FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

return DA.ExecuteNonQuery(com);
}
public PreferredQualificationTable GetByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
PreferredQualificationTable tbl = new PreferredQualificationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [PreferredQualification] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
return DA.ExecuteNonQuery(fcom);
}
public PreferredQualificationTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [PreferredQualification] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
PreferredQualificationTable tbl = new PreferredQualificationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [PreferredQualification] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [PreferredQualification] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteNonQuery(fcom);
}
}
}
