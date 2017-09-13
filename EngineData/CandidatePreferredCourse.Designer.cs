using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CandidatePreferredCourseTable : DataTable {
// column indexes
public const int Candidate_IDColumnIndex = 0;
public const int Course_IDColumnIndex = 1;
public CandidatePreferredCourseTable() {
TableName = "[CandidatePreferredCourse]";
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
public CandidatePreferredCourseRow NewCandidatePreferredCourseRow() {
CandidatePreferredCourseRow row = (CandidatePreferredCourseRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CandidatePreferredCourseRow row) {
row.Candidate_ID = Guid.Empty;
row.Course_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CandidatePreferredCourseRow(builder);
}
public CandidatePreferredCourseRow GetCandidatePreferredCourseRow(int index) {
return (CandidatePreferredCourseRow)Rows[index];
}
}
public partial class CandidatePreferredCourseRow : DataRow {
internal CandidatePreferredCourseRow(DataRowBuilder builder) : base(builder) {
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
public partial class CandidatePreferredCourseMinimalizedEntity {
public CandidatePreferredCourseMinimalizedEntity() {}
public CandidatePreferredCourseMinimalizedEntity(CandidatePreferredCourseRow dr) {
this.Candidate_ID = dr.Candidate_ID;
this.Course_ID = dr.Course_ID;
}
public void CopyTo(CandidatePreferredCourseRow dr) {
dr.Candidate_ID = this.Candidate_ID;
dr.Course_ID = this.Course_ID;
}
public System.Guid Candidate_ID;
public System.Guid Course_ID;
}
public partial class CandidatePreferredCourseAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CandidatePreferredCourseAdapter(DA da):base(da) {
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
adapter.InsertCommand = new SqlCommand("INSERT INTO [CandidatePreferredCourse] ([Candidate_ID], [Course_ID]) VALUES (@Candidate_ID, @Course_ID)");
adapter.InsertCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [CandidatePreferredCourse] SET [Candidate_ID] = @Candidate_ID, [Course_ID] = @Course_ID WHERE [Candidate_ID] = @o_Candidate_ID AND [Course_ID] = @o_Course_ID");
adapter.UpdateCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @o_Candidate_ID AND [Course_ID] = @o_Course_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Course_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Course_ID", DataRowVersion.Original, null));
}
public void Update(CandidatePreferredCourseTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CandidatePreferredCourseRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CandidatePreferredCourseRow GetByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID ) {
string sql = "SELECT * FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

CandidatePreferredCourseTable tbl = new CandidatePreferredCourseTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCandidatePreferredCourseRow(0);
}
public int CountByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID ) {
string sql = "SELECT COUNT(*) FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByPrimaryKeys(System.Guid Candidate_ID, System.Guid Course_ID, IActivityLog log ) {
string sql = "DELETE FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID AND [Course_ID] = @Course_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
com.Parameters.AddWithValue("Course_ID", Course_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public CandidatePreferredCourseTable GetByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
CandidatePreferredCourseTable tbl = new CandidatePreferredCourseTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCandidate_ID(System.Guid Candidate_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CandidatePreferredCourse] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public CandidatePreferredCourseTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [CandidatePreferredCourse] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
CandidatePreferredCourseTable tbl = new CandidatePreferredCourseTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [CandidatePreferredCourse] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [CandidatePreferredCourse] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
