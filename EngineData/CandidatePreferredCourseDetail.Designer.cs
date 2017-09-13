using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CandidatePreferredCourseDetailTable : DataTable {
// column indexes
public const int Candidate_IDColumnIndex = 0;
public const int Course_CodeColumnIndex = 1;
public const int Course_NameColumnIndex = 2;
public const int Course_ApplicableForApplyColumnIndex = 3;
public const int Course_RemarkColumnIndex = 4;
public const int Course_IsDeletedColumnIndex = 5;
public const int Course_CreatedDateColumnIndex = 6;
public const int Course_CreatedByColumnIndex = 7;
public const int Course_UpdatedDateColumnIndex = 8;
public const int Course_UpdatedByColumnIndex = 9;
public const int Course_IDColumnIndex = 10;
public CandidatePreferredCourseDetailTable() {
TableName = "[CandidatePreferredCourseDetail]";
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = true;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Course_Code
DataColumn Course_CodeCol = new DataColumn("Course_Code", typeof(System.String));
Course_CodeCol.ReadOnly = true;
Course_CodeCol.AllowDBNull = false;
Columns.Add(Course_CodeCol);
// column Course_Name
DataColumn Course_NameCol = new DataColumn("Course_Name", typeof(System.String));
Course_NameCol.ReadOnly = true;
Course_NameCol.AllowDBNull = false;
Columns.Add(Course_NameCol);
// column Course_ApplicableForApply
DataColumn Course_ApplicableForApplyCol = new DataColumn("Course_ApplicableForApply", typeof(System.Boolean));
Course_ApplicableForApplyCol.ReadOnly = true;
Course_ApplicableForApplyCol.AllowDBNull = false;
Columns.Add(Course_ApplicableForApplyCol);
// column Course_Remark
DataColumn Course_RemarkCol = new DataColumn("Course_Remark", typeof(System.String));
Course_RemarkCol.ReadOnly = true;
Course_RemarkCol.AllowDBNull = false;
Columns.Add(Course_RemarkCol);
// column Course_IsDeleted
DataColumn Course_IsDeletedCol = new DataColumn("Course_IsDeleted", typeof(System.Boolean));
Course_IsDeletedCol.ReadOnly = true;
Course_IsDeletedCol.AllowDBNull = false;
Columns.Add(Course_IsDeletedCol);
// column Course_CreatedDate
DataColumn Course_CreatedDateCol = new DataColumn("Course_CreatedDate", typeof(System.DateTime));
Course_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Course_CreatedDateCol.ReadOnly = true;
Course_CreatedDateCol.AllowDBNull = false;
Columns.Add(Course_CreatedDateCol);
// column Course_CreatedBy
DataColumn Course_CreatedByCol = new DataColumn("Course_CreatedBy", typeof(System.String));
Course_CreatedByCol.ReadOnly = true;
Course_CreatedByCol.AllowDBNull = false;
Columns.Add(Course_CreatedByCol);
// column Course_UpdatedDate
DataColumn Course_UpdatedDateCol = new DataColumn("Course_UpdatedDate", typeof(System.DateTime));
Course_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Course_UpdatedDateCol.ReadOnly = true;
Course_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Course_UpdatedDateCol);
// column Course_UpdatedBy
DataColumn Course_UpdatedByCol = new DataColumn("Course_UpdatedBy", typeof(System.String));
Course_UpdatedByCol.ReadOnly = true;
Course_UpdatedByCol.AllowDBNull = false;
Columns.Add(Course_UpdatedByCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CandidatePreferredCourseDetailRow(builder);
}
public CandidatePreferredCourseDetailRow GetCandidatePreferredCourseDetailRow(int index) {
return (CandidatePreferredCourseDetailRow)Rows[index];
}
}
public partial class CandidatePreferredCourseDetailRow : DataRow {
internal CandidatePreferredCourseDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
}
public System.String Course_Code {
get {
return (System.String)this["Course_Code"];
}
}
public System.String Course_Name {
get {
return (System.String)this["Course_Name"];
}
}
public System.Boolean Course_ApplicableForApply {
get {
return (System.Boolean)this["Course_ApplicableForApply"];
}
}
public System.String Course_Remark {
get {
return (System.String)this["Course_Remark"];
}
}
public System.Boolean Course_IsDeleted {
get {
return (System.Boolean)this["Course_IsDeleted"];
}
}
public System.DateTime Course_CreatedDate {
get {
return (System.DateTime)this["Course_CreatedDate"];
}
}
public System.String Course_CreatedBy {
get {
return (System.String)this["Course_CreatedBy"];
}
}
public System.DateTime Course_UpdatedDate {
get {
return (System.DateTime)this["Course_UpdatedDate"];
}
}
public System.String Course_UpdatedBy {
get {
return (System.String)this["Course_UpdatedBy"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
}
public partial class CandidatePreferredCourseDetailMinimalizedEntity {
public CandidatePreferredCourseDetailMinimalizedEntity() {}
public CandidatePreferredCourseDetailMinimalizedEntity(CandidatePreferredCourseDetailRow dr) {
this.Candidate_ID = dr.Candidate_ID;
this.Course_Code = dr.Course_Code;
this.Course_Name = dr.Course_Name;
this.Course_ApplicableForApply = dr.Course_ApplicableForApply;
this.Course_Remark = dr.Course_Remark;
this.Course_IsDeleted = dr.Course_IsDeleted;
this.Course_CreatedDate = dr.Course_CreatedDate;
this.Course_CreatedBy = dr.Course_CreatedBy;
this.Course_UpdatedDate = dr.Course_UpdatedDate;
this.Course_UpdatedBy = dr.Course_UpdatedBy;
this.Course_ID = dr.Course_ID;
}
public System.Guid Candidate_ID;
public System.String Course_Code;
public System.String Course_Name;
public System.Boolean Course_ApplicableForApply;
public System.String Course_Remark;
public System.Boolean Course_IsDeleted;
public System.DateTime Course_CreatedDate;
public System.String Course_CreatedBy;
public System.DateTime Course_UpdatedDate;
public System.String Course_UpdatedBy;
public System.Guid Course_ID;
}
public partial class CandidatePreferredCourseDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CandidatePreferredCourseDetailAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("Course_Code", "Course_Code");
tmap.ColumnMappings.Add("Course_Name", "Course_Name");
tmap.ColumnMappings.Add("Course_ApplicableForApply", "Course_ApplicableForApply");
tmap.ColumnMappings.Add("Course_Remark", "Course_Remark");
tmap.ColumnMappings.Add("Course_IsDeleted", "Course_IsDeleted");
tmap.ColumnMappings.Add("Course_CreatedDate", "Course_CreatedDate");
tmap.ColumnMappings.Add("Course_CreatedBy", "Course_CreatedBy");
tmap.ColumnMappings.Add("Course_UpdatedDate", "Course_UpdatedDate");
tmap.ColumnMappings.Add("Course_UpdatedBy", "Course_UpdatedBy");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
adapter.TableMappings.Add(tmap);
}
}
public CandidatePreferredCourseDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [CandidatePreferredCourseDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

CandidatePreferredCourseDetailTable tbl = new CandidatePreferredCourseDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCandidatePreferredCourseDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [CandidatePreferredCourseDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
