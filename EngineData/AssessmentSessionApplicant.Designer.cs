using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class AssessmentSessionApplicantTable : DataTable {
// column indexes
public const int AssessmentSessionApplicant_IDColumnIndex = 0;
public const int AssessmentSession_IDColumnIndex = 1;
public const int Applicant_IDColumnIndex = 2;
public AssessmentSessionApplicantTable() {
TableName = "[AssessmentSessionApplicant]";
// column AssessmentSessionApplicant_ID
DataColumn AssessmentSessionApplicant_IDCol = new DataColumn("AssessmentSessionApplicant_ID", typeof(System.Guid));
AssessmentSessionApplicant_IDCol.ReadOnly = false;
AssessmentSessionApplicant_IDCol.AllowDBNull = false;
Columns.Add(AssessmentSessionApplicant_IDCol);
// column AssessmentSession_ID
DataColumn AssessmentSession_IDCol = new DataColumn("AssessmentSession_ID", typeof(System.Guid));
AssessmentSession_IDCol.ReadOnly = false;
AssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(AssessmentSession_IDCol);
// column Applicant_ID
DataColumn Applicant_IDCol = new DataColumn("Applicant_ID", typeof(System.Guid));
Applicant_IDCol.ReadOnly = false;
Applicant_IDCol.AllowDBNull = false;
Columns.Add(Applicant_IDCol);
}
public AssessmentSessionApplicantRow NewAssessmentSessionApplicantRow() {
AssessmentSessionApplicantRow row = (AssessmentSessionApplicantRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(AssessmentSessionApplicantRow row) {
row.AssessmentSessionApplicant_ID = Guid.Empty;
row.AssessmentSession_ID = Guid.Empty;
row.Applicant_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new AssessmentSessionApplicantRow(builder);
}
public AssessmentSessionApplicantRow GetAssessmentSessionApplicantRow(int index) {
return (AssessmentSessionApplicantRow)Rows[index];
}
}
public partial class AssessmentSessionApplicantRow : DataRow {
internal AssessmentSessionApplicantRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid AssessmentSessionApplicant_ID {
get {
return (System.Guid)this["AssessmentSessionApplicant_ID"];
}
set {
this["AssessmentSessionApplicant_ID"] = value;
}
}
public System.Guid AssessmentSession_ID {
get {
return (System.Guid)this["AssessmentSession_ID"];
}
set {
this["AssessmentSession_ID"] = value;
}
}
public System.Guid Applicant_ID {
get {
return (System.Guid)this["Applicant_ID"];
}
set {
this["Applicant_ID"] = value;
}
}
}
public partial class AssessmentSessionApplicantMinimalizedEntity {
public AssessmentSessionApplicantMinimalizedEntity() {}
public AssessmentSessionApplicantMinimalizedEntity(AssessmentSessionApplicantRow dr) {
this.AssessmentSessionApplicant_ID = dr.AssessmentSessionApplicant_ID;
this.AssessmentSession_ID = dr.AssessmentSession_ID;
this.Applicant_ID = dr.Applicant_ID;
}
public void CopyTo(AssessmentSessionApplicantRow dr) {
dr.AssessmentSessionApplicant_ID = this.AssessmentSessionApplicant_ID;
dr.AssessmentSession_ID = this.AssessmentSession_ID;
dr.Applicant_ID = this.Applicant_ID;
}
public System.Guid AssessmentSessionApplicant_ID;
public System.Guid AssessmentSession_ID;
public System.Guid Applicant_ID;
}
public partial class AssessmentSessionApplicantAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public AssessmentSessionApplicantAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("AssessmentSessionApplicant_ID", "AssessmentSessionApplicant_ID");
tmap.ColumnMappings.Add("AssessmentSession_ID", "AssessmentSession_ID");
tmap.ColumnMappings.Add("Applicant_ID", "Applicant_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [AssessmentSessionApplicant] ([AssessmentSessionApplicant_ID], [AssessmentSession_ID], [Applicant_ID]) VALUES (@AssessmentSessionApplicant_ID, @AssessmentSession_ID, @Applicant_ID)");
adapter.InsertCommand.Parameters.Add("@AssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSessionApplicant_ID");
adapter.InsertCommand.Parameters.Add("@AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSession_ID");
adapter.InsertCommand.Parameters.Add("@Applicant_ID", SqlDbType.UniqueIdentifier, 0, "Applicant_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [AssessmentSessionApplicant] SET [AssessmentSessionApplicant_ID] = @AssessmentSessionApplicant_ID, [AssessmentSession_ID] = @AssessmentSession_ID, [Applicant_ID] = @Applicant_ID WHERE [AssessmentSessionApplicant_ID] = @o_AssessmentSessionApplicant_ID");
adapter.UpdateCommand.Parameters.Add("@AssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSessionApplicant_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_AssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentSessionApplicant_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@AssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add("@Applicant_ID", SqlDbType.UniqueIdentifier, 0, "Applicant_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [AssessmentSessionApplicant] WHERE [AssessmentSessionApplicant_ID] = @o_AssessmentSessionApplicant_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_AssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentSessionApplicant_ID", DataRowVersion.Original, null));
}
public void Update(AssessmentSessionApplicantTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(AssessmentSessionApplicantRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public AssessmentSessionApplicantRow GetByAssessmentSessionApplicant_ID(System.Guid AssessmentSessionApplicant_ID ) {
string sql = "SELECT * FROM [AssessmentSessionApplicant] WHERE [AssessmentSessionApplicant_ID] = @AssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSessionApplicant_ID", AssessmentSessionApplicant_ID);

AssessmentSessionApplicantTable tbl = new AssessmentSessionApplicantTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetAssessmentSessionApplicantRow(0);
}
public int CountByAssessmentSessionApplicant_ID(System.Guid AssessmentSessionApplicant_ID ) {
string sql = "SELECT COUNT(*) FROM [AssessmentSessionApplicant] WHERE [AssessmentSessionApplicant_ID] = @AssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSessionApplicant_ID", AssessmentSessionApplicant_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByAssessmentSessionApplicant_ID(System.Guid AssessmentSessionApplicant_ID, IActivityLog log ) {
string sql = "DELETE FROM [AssessmentSessionApplicant] WHERE [AssessmentSessionApplicant_ID] = @AssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentSessionApplicant_ID", AssessmentSessionApplicant_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public AssessmentSessionApplicantTable GetByAssessmentSession_ID(System.Guid AssessmentSession_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [AssessmentSessionApplicant] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);
AssessmentSessionApplicantTable tbl = new AssessmentSessionApplicantTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByAssessmentSession_ID(System.Guid AssessmentSession_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [AssessmentSessionApplicant] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByAssessmentSession_ID(System.Guid AssessmentSession_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [AssessmentSessionApplicant] WHERE [AssessmentSession_ID] = @AssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("AssessmentSession_ID", AssessmentSession_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public AssessmentSessionApplicantTable GetByApplicant_ID(System.Guid Applicant_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [AssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
AssessmentSessionApplicantTable tbl = new AssessmentSessionApplicantTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplicant_ID(System.Guid Applicant_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [AssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplicant_ID(System.Guid Applicant_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [AssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
