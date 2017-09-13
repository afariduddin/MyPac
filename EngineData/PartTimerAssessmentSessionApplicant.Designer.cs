using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PartTimerAssessmentSessionApplicantTable : DataTable {
// column indexes
public const int PartTimerAssessmentSessionApplicant_IDColumnIndex = 0;
public const int PartTimerAssessmentSession_IDColumnIndex = 1;
public const int Applicant_IDColumnIndex = 2;
public PartTimerAssessmentSessionApplicantTable() {
TableName = "[PartTimerAssessmentSessionApplicant]";
// column PartTimerAssessmentSessionApplicant_ID
DataColumn PartTimerAssessmentSessionApplicant_IDCol = new DataColumn("PartTimerAssessmentSessionApplicant_ID", typeof(System.Guid));
PartTimerAssessmentSessionApplicant_IDCol.ReadOnly = false;
PartTimerAssessmentSessionApplicant_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSessionApplicant_IDCol);
// column PartTimerAssessmentSession_ID
DataColumn PartTimerAssessmentSession_IDCol = new DataColumn("PartTimerAssessmentSession_ID", typeof(System.Guid));
PartTimerAssessmentSession_IDCol.ReadOnly = false;
PartTimerAssessmentSession_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentSession_IDCol);
// column Applicant_ID
DataColumn Applicant_IDCol = new DataColumn("Applicant_ID", typeof(System.Guid));
Applicant_IDCol.ReadOnly = false;
Applicant_IDCol.AllowDBNull = false;
Columns.Add(Applicant_IDCol);
}
public PartTimerAssessmentSessionApplicantRow NewPartTimerAssessmentSessionApplicantRow() {
PartTimerAssessmentSessionApplicantRow row = (PartTimerAssessmentSessionApplicantRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(PartTimerAssessmentSessionApplicantRow row) {
row.PartTimerAssessmentSessionApplicant_ID = Guid.Empty;
row.PartTimerAssessmentSession_ID = Guid.Empty;
row.Applicant_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PartTimerAssessmentSessionApplicantRow(builder);
}
public PartTimerAssessmentSessionApplicantRow GetPartTimerAssessmentSessionApplicantRow(int index) {
return (PartTimerAssessmentSessionApplicantRow)Rows[index];
}
}
public partial class PartTimerAssessmentSessionApplicantRow : DataRow {
internal PartTimerAssessmentSessionApplicantRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid PartTimerAssessmentSessionApplicant_ID {
get {
return (System.Guid)this["PartTimerAssessmentSessionApplicant_ID"];
}
set {
this["PartTimerAssessmentSessionApplicant_ID"] = value;
}
}
public System.Guid PartTimerAssessmentSession_ID {
get {
return (System.Guid)this["PartTimerAssessmentSession_ID"];
}
set {
this["PartTimerAssessmentSession_ID"] = value;
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
public partial class PartTimerAssessmentSessionApplicantMinimalizedEntity {
public PartTimerAssessmentSessionApplicantMinimalizedEntity() {}
public PartTimerAssessmentSessionApplicantMinimalizedEntity(PartTimerAssessmentSessionApplicantRow dr) {
this.PartTimerAssessmentSessionApplicant_ID = dr.PartTimerAssessmentSessionApplicant_ID;
this.PartTimerAssessmentSession_ID = dr.PartTimerAssessmentSession_ID;
this.Applicant_ID = dr.Applicant_ID;
}
public void CopyTo(PartTimerAssessmentSessionApplicantRow dr) {
dr.PartTimerAssessmentSessionApplicant_ID = this.PartTimerAssessmentSessionApplicant_ID;
dr.PartTimerAssessmentSession_ID = this.PartTimerAssessmentSession_ID;
dr.Applicant_ID = this.Applicant_ID;
}
public System.Guid PartTimerAssessmentSessionApplicant_ID;
public System.Guid PartTimerAssessmentSession_ID;
public System.Guid Applicant_ID;
}
public partial class PartTimerAssessmentSessionApplicantAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PartTimerAssessmentSessionApplicantAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("PartTimerAssessmentSessionApplicant_ID", "PartTimerAssessmentSessionApplicant_ID");
tmap.ColumnMappings.Add("PartTimerAssessmentSession_ID", "PartTimerAssessmentSession_ID");
tmap.ColumnMappings.Add("Applicant_ID", "Applicant_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [PartTimerAssessmentSessionApplicant] ([PartTimerAssessmentSessionApplicant_ID], [PartTimerAssessmentSession_ID], [Applicant_ID]) VALUES (@PartTimerAssessmentSessionApplicant_ID, @PartTimerAssessmentSession_ID, @Applicant_ID)");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSessionApplicant_ID");
adapter.InsertCommand.Parameters.Add("@PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSession_ID");
adapter.InsertCommand.Parameters.Add("@Applicant_ID", SqlDbType.UniqueIdentifier, 0, "Applicant_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [PartTimerAssessmentSessionApplicant] SET [PartTimerAssessmentSessionApplicant_ID] = @PartTimerAssessmentSessionApplicant_ID, [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID, [Applicant_ID] = @Applicant_ID WHERE [PartTimerAssessmentSessionApplicant_ID] = @o_PartTimerAssessmentSessionApplicant_ID");
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSessionApplicant_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentSessionApplicant_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@PartTimerAssessmentSession_ID", SqlDbType.UniqueIdentifier, 0, "PartTimerAssessmentSession_ID");
adapter.UpdateCommand.Parameters.Add("@Applicant_ID", SqlDbType.UniqueIdentifier, 0, "Applicant_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSessionApplicant_ID] = @o_PartTimerAssessmentSessionApplicant_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_PartTimerAssessmentSessionApplicant_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "PartTimerAssessmentSessionApplicant_ID", DataRowVersion.Original, null));
}
public void Update(PartTimerAssessmentSessionApplicantTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(PartTimerAssessmentSessionApplicantRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public PartTimerAssessmentSessionApplicantRow GetByPartTimerAssessmentSessionApplicant_ID(System.Guid PartTimerAssessmentSessionApplicant_ID ) {
string sql = "SELECT * FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSessionApplicant_ID] = @PartTimerAssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSessionApplicant_ID", PartTimerAssessmentSessionApplicant_ID);

PartTimerAssessmentSessionApplicantTable tbl = new PartTimerAssessmentSessionApplicantTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPartTimerAssessmentSessionApplicantRow(0);
}
public int CountByPartTimerAssessmentSessionApplicant_ID(System.Guid PartTimerAssessmentSessionApplicant_ID ) {
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSessionApplicant_ID] = @PartTimerAssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSessionApplicant_ID", PartTimerAssessmentSessionApplicant_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPartTimerAssessmentSessionApplicant_ID(System.Guid PartTimerAssessmentSessionApplicant_ID, IActivityLog log ) {
string sql = "DELETE FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSessionApplicant_ID] = @PartTimerAssessmentSessionApplicant_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("PartTimerAssessmentSessionApplicant_ID", PartTimerAssessmentSessionApplicant_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public PartTimerAssessmentSessionApplicantTable GetByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
PartTimerAssessmentSessionApplicantTable tbl = new PartTimerAssessmentSessionApplicantTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByPartTimerAssessmentSession_ID(System.Guid PartTimerAssessmentSession_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [PartTimerAssessmentSessionApplicant] WHERE [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public PartTimerAssessmentSessionApplicantTable GetByApplicant_ID(System.Guid Applicant_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [PartTimerAssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
PartTimerAssessmentSessionApplicantTable tbl = new PartTimerAssessmentSessionApplicantTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplicant_ID(System.Guid Applicant_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplicant_ID(System.Guid Applicant_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [PartTimerAssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
