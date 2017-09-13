using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class AssessmentResultTable : DataTable {
// column indexes
public const int AssessmentResult_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int AssessmentResult_ListeningColumnIndex = 2;
public const int AssessmentResult_WritingColumnIndex = 3;
public const int AssessmentResult_SpeakingColumnIndex = 4;
public const int AssessmentResult_ReadingColumnIndex = 5;
public const int AssessmentResult_StatusColumnIndex = 6;
public const int AssessmentResult_CreatedByColumnIndex = 7;
public const int AssessmentResult_CreatedDateColumnIndex = 8;
public const int AssessmentResult_UpdatedByColumnIndex = 9;
public const int AssessmentResult_UpdatedDateColumnIndex = 10;
public const int AssessmentResult_TotalScoreColumnIndex = 11;
public const int AssessmentResult_AverageScoreColumnIndex = 12;
public const int AssessmentResult_DateColumnIndex = 13;
public const int AssessmentResult_CLOIssueDateColumnIndex = 14;
public const int AssessmentResult_TechnicalAssessmentColumnIndex = 15;
public const int AssessmentResult_EnglishFoundationColumnIndex = 16;
public const int AssessmentResult_EPTSummaryColumnIndex = 17;
public const int AssessmentResult_RemarkColumnIndex = 18;
public const int AssessmentResult_ExpectedEnrollmentDateColumnIndex = 19;
public const int AssessmentResult_InterviewColumnIndex = 20;
public const int AssessmentResult_ContractExpireDateColumnIndex = 21;
public AssessmentResultTable() {
TableName = "[AssessmentResult]";
// column AssessmentResult_ID
DataColumn AssessmentResult_IDCol = new DataColumn("AssessmentResult_ID", typeof(System.Guid));
AssessmentResult_IDCol.ReadOnly = false;
AssessmentResult_IDCol.AllowDBNull = false;
Columns.Add(AssessmentResult_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column AssessmentResult_Listening
DataColumn AssessmentResult_ListeningCol = new DataColumn("AssessmentResult_Listening", typeof(System.Decimal));
AssessmentResult_ListeningCol.ReadOnly = false;
AssessmentResult_ListeningCol.AllowDBNull = false;
Columns.Add(AssessmentResult_ListeningCol);
// column AssessmentResult_Writing
DataColumn AssessmentResult_WritingCol = new DataColumn("AssessmentResult_Writing", typeof(System.Decimal));
AssessmentResult_WritingCol.ReadOnly = false;
AssessmentResult_WritingCol.AllowDBNull = false;
Columns.Add(AssessmentResult_WritingCol);
// column AssessmentResult_Speaking
DataColumn AssessmentResult_SpeakingCol = new DataColumn("AssessmentResult_Speaking", typeof(System.Decimal));
AssessmentResult_SpeakingCol.ReadOnly = false;
AssessmentResult_SpeakingCol.AllowDBNull = false;
Columns.Add(AssessmentResult_SpeakingCol);
// column AssessmentResult_Reading
DataColumn AssessmentResult_ReadingCol = new DataColumn("AssessmentResult_Reading", typeof(System.Decimal));
AssessmentResult_ReadingCol.ReadOnly = false;
AssessmentResult_ReadingCol.AllowDBNull = false;
Columns.Add(AssessmentResult_ReadingCol);
// column AssessmentResult_Status
DataColumn AssessmentResult_StatusCol = new DataColumn("AssessmentResult_Status", typeof(System.Int16));
AssessmentResult_StatusCol.ReadOnly = false;
AssessmentResult_StatusCol.AllowDBNull = false;
Columns.Add(AssessmentResult_StatusCol);
// column AssessmentResult_CreatedBy
DataColumn AssessmentResult_CreatedByCol = new DataColumn("AssessmentResult_CreatedBy", typeof(System.String));
AssessmentResult_CreatedByCol.ReadOnly = false;
AssessmentResult_CreatedByCol.AllowDBNull = false;
Columns.Add(AssessmentResult_CreatedByCol);
// column AssessmentResult_CreatedDate
DataColumn AssessmentResult_CreatedDateCol = new DataColumn("AssessmentResult_CreatedDate", typeof(System.DateTime));
AssessmentResult_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_CreatedDateCol.ReadOnly = false;
AssessmentResult_CreatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_CreatedDateCol);
// column AssessmentResult_UpdatedBy
DataColumn AssessmentResult_UpdatedByCol = new DataColumn("AssessmentResult_UpdatedBy", typeof(System.String));
AssessmentResult_UpdatedByCol.ReadOnly = false;
AssessmentResult_UpdatedByCol.AllowDBNull = false;
Columns.Add(AssessmentResult_UpdatedByCol);
// column AssessmentResult_UpdatedDate
DataColumn AssessmentResult_UpdatedDateCol = new DataColumn("AssessmentResult_UpdatedDate", typeof(System.DateTime));
AssessmentResult_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_UpdatedDateCol.ReadOnly = false;
AssessmentResult_UpdatedDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_UpdatedDateCol);
// column AssessmentResult_TotalScore
DataColumn AssessmentResult_TotalScoreCol = new DataColumn("AssessmentResult_TotalScore", typeof(System.Decimal));
AssessmentResult_TotalScoreCol.ReadOnly = false;
AssessmentResult_TotalScoreCol.AllowDBNull = false;
Columns.Add(AssessmentResult_TotalScoreCol);
// column AssessmentResult_AverageScore
DataColumn AssessmentResult_AverageScoreCol = new DataColumn("AssessmentResult_AverageScore", typeof(System.Decimal));
AssessmentResult_AverageScoreCol.ReadOnly = false;
AssessmentResult_AverageScoreCol.AllowDBNull = false;
Columns.Add(AssessmentResult_AverageScoreCol);
// column AssessmentResult_Date
DataColumn AssessmentResult_DateCol = new DataColumn("AssessmentResult_Date", typeof(System.DateTime));
AssessmentResult_DateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_DateCol.ReadOnly = false;
AssessmentResult_DateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_DateCol);
// column AssessmentResult_CLOIssueDate
DataColumn AssessmentResult_CLOIssueDateCol = new DataColumn("AssessmentResult_CLOIssueDate", typeof(System.DateTime));
AssessmentResult_CLOIssueDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_CLOIssueDateCol.ReadOnly = false;
AssessmentResult_CLOIssueDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_CLOIssueDateCol);
// column AssessmentResult_TechnicalAssessment
DataColumn AssessmentResult_TechnicalAssessmentCol = new DataColumn("AssessmentResult_TechnicalAssessment", typeof(System.Decimal));
AssessmentResult_TechnicalAssessmentCol.ReadOnly = false;
AssessmentResult_TechnicalAssessmentCol.AllowDBNull = false;
Columns.Add(AssessmentResult_TechnicalAssessmentCol);
// column AssessmentResult_EnglishFoundation
DataColumn AssessmentResult_EnglishFoundationCol = new DataColumn("AssessmentResult_EnglishFoundation", typeof(System.Decimal));
AssessmentResult_EnglishFoundationCol.ReadOnly = false;
AssessmentResult_EnglishFoundationCol.AllowDBNull = false;
Columns.Add(AssessmentResult_EnglishFoundationCol);
// column AssessmentResult_EPTSummary
DataColumn AssessmentResult_EPTSummaryCol = new DataColumn("AssessmentResult_EPTSummary", typeof(System.Decimal));
AssessmentResult_EPTSummaryCol.ReadOnly = false;
AssessmentResult_EPTSummaryCol.AllowDBNull = false;
Columns.Add(AssessmentResult_EPTSummaryCol);
// column AssessmentResult_Remark
DataColumn AssessmentResult_RemarkCol = new DataColumn("AssessmentResult_Remark", typeof(System.String));
AssessmentResult_RemarkCol.ReadOnly = false;
AssessmentResult_RemarkCol.AllowDBNull = false;
Columns.Add(AssessmentResult_RemarkCol);
// column AssessmentResult_ExpectedEnrollmentDate
DataColumn AssessmentResult_ExpectedEnrollmentDateCol = new DataColumn("AssessmentResult_ExpectedEnrollmentDate", typeof(System.DateTime));
AssessmentResult_ExpectedEnrollmentDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_ExpectedEnrollmentDateCol.ReadOnly = false;
AssessmentResult_ExpectedEnrollmentDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_ExpectedEnrollmentDateCol);
// column AssessmentResult_Interview
DataColumn AssessmentResult_InterviewCol = new DataColumn("AssessmentResult_Interview", typeof(System.Int16));
AssessmentResult_InterviewCol.ReadOnly = false;
AssessmentResult_InterviewCol.AllowDBNull = false;
Columns.Add(AssessmentResult_InterviewCol);
// column AssessmentResult_ContractExpireDate
DataColumn AssessmentResult_ContractExpireDateCol = new DataColumn("AssessmentResult_ContractExpireDate", typeof(System.DateTime));
AssessmentResult_ContractExpireDateCol.DateTimeMode = DataSetDateTime.Utc;
AssessmentResult_ContractExpireDateCol.ReadOnly = false;
AssessmentResult_ContractExpireDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_ContractExpireDateCol);
}
public AssessmentResultRow NewAssessmentResultRow() {
AssessmentResultRow row = (AssessmentResultRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(AssessmentResultRow row) {
row.AssessmentResult_ID = Guid.Empty;
row.Application_ID = Guid.Empty;
row.AssessmentResult_Listening = 0;
row.AssessmentResult_Writing = 0;
row.AssessmentResult_Speaking = 0;
row.AssessmentResult_Reading = 0;
row.AssessmentResult_Status = 0;
row.AssessmentResult_CreatedBy = "";
row.AssessmentResult_CreatedDate = DateTime.Now;
row.AssessmentResult_UpdatedBy = "";
row.AssessmentResult_UpdatedDate = DateTime.Now;
row.AssessmentResult_TotalScore = 0;
row.AssessmentResult_AverageScore = 0;
row.AssessmentResult_Date = DateTime.Now;
row.AssessmentResult_CLOIssueDate = DateTime.Now;
row.AssessmentResult_TechnicalAssessment = 0;
row.AssessmentResult_EnglishFoundation = 0;
row.AssessmentResult_EPTSummary = 0;
row.AssessmentResult_Remark = "";
row.AssessmentResult_ExpectedEnrollmentDate = DateTime.Now;
row.AssessmentResult_Interview = 0;
row.AssessmentResult_ContractExpireDate = DateTime.Now;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new AssessmentResultRow(builder);
}
public AssessmentResultRow GetAssessmentResultRow(int index) {
return (AssessmentResultRow)Rows[index];
}
}
public partial class AssessmentResultRow : DataRow {
internal AssessmentResultRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid AssessmentResult_ID {
get {
return (System.Guid)this["AssessmentResult_ID"];
}
set {
this["AssessmentResult_ID"] = value;
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
set {
this["Application_ID"] = value;
}
}
public System.Decimal AssessmentResult_Listening {
get {
return (System.Decimal)this["AssessmentResult_Listening"];
}
set {
this["AssessmentResult_Listening"] = value;
}
}
public System.Decimal AssessmentResult_Writing {
get {
return (System.Decimal)this["AssessmentResult_Writing"];
}
set {
this["AssessmentResult_Writing"] = value;
}
}
public System.Decimal AssessmentResult_Speaking {
get {
return (System.Decimal)this["AssessmentResult_Speaking"];
}
set {
this["AssessmentResult_Speaking"] = value;
}
}
public System.Decimal AssessmentResult_Reading {
get {
return (System.Decimal)this["AssessmentResult_Reading"];
}
set {
this["AssessmentResult_Reading"] = value;
}
}
public System.Int16 AssessmentResult_Status {
get {
return (System.Int16)this["AssessmentResult_Status"];
}
set {
this["AssessmentResult_Status"] = value;
}
}
public System.String AssessmentResult_CreatedBy {
get {
return (System.String)this["AssessmentResult_CreatedBy"];
}
set {
if( value.Length > 50 ) this["AssessmentResult_CreatedBy"] = value.Substring(0, 50);
else this["AssessmentResult_CreatedBy"] = value;
}
}
public System.DateTime AssessmentResult_CreatedDate {
get {
return (System.DateTime)this["AssessmentResult_CreatedDate"];
}
set {
this["AssessmentResult_CreatedDate"] = value;
}
}
public System.String AssessmentResult_UpdatedBy {
get {
return (System.String)this["AssessmentResult_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["AssessmentResult_UpdatedBy"] = value.Substring(0, 50);
else this["AssessmentResult_UpdatedBy"] = value;
}
}
public System.DateTime AssessmentResult_UpdatedDate {
get {
return (System.DateTime)this["AssessmentResult_UpdatedDate"];
}
set {
this["AssessmentResult_UpdatedDate"] = value;
}
}
public System.Decimal AssessmentResult_TotalScore {
get {
return (System.Decimal)this["AssessmentResult_TotalScore"];
}
set {
this["AssessmentResult_TotalScore"] = value;
}
}
public System.Decimal AssessmentResult_AverageScore {
get {
return (System.Decimal)this["AssessmentResult_AverageScore"];
}
set {
this["AssessmentResult_AverageScore"] = value;
}
}
public System.DateTime AssessmentResult_Date {
get {
return (System.DateTime)this["AssessmentResult_Date"];
}
set {
this["AssessmentResult_Date"] = value;
}
}
public System.DateTime AssessmentResult_CLOIssueDate {
get {
return (System.DateTime)this["AssessmentResult_CLOIssueDate"];
}
set {
this["AssessmentResult_CLOIssueDate"] = value;
}
}
public System.Decimal AssessmentResult_TechnicalAssessment {
get {
return (System.Decimal)this["AssessmentResult_TechnicalAssessment"];
}
set {
this["AssessmentResult_TechnicalAssessment"] = value;
}
}
public System.Decimal AssessmentResult_EnglishFoundation {
get {
return (System.Decimal)this["AssessmentResult_EnglishFoundation"];
}
set {
this["AssessmentResult_EnglishFoundation"] = value;
}
}
public System.Decimal AssessmentResult_EPTSummary {
get {
return (System.Decimal)this["AssessmentResult_EPTSummary"];
}
set {
this["AssessmentResult_EPTSummary"] = value;
}
}
public System.String AssessmentResult_Remark {
get {
return (System.String)this["AssessmentResult_Remark"];
}
set {
if( value.Length > 250 ) this["AssessmentResult_Remark"] = value.Substring(0, 250);
else this["AssessmentResult_Remark"] = value;
}
}
public System.DateTime AssessmentResult_ExpectedEnrollmentDate {
get {
return (System.DateTime)this["AssessmentResult_ExpectedEnrollmentDate"];
}
set {
this["AssessmentResult_ExpectedEnrollmentDate"] = value;
}
}
public System.Int16 AssessmentResult_Interview {
get {
return (System.Int16)this["AssessmentResult_Interview"];
}
set {
this["AssessmentResult_Interview"] = value;
}
}
public System.DateTime AssessmentResult_ContractExpireDate {
get {
return (System.DateTime)this["AssessmentResult_ContractExpireDate"];
}
set {
this["AssessmentResult_ContractExpireDate"] = value;
}
}
}
public partial class AssessmentResultMinimalizedEntity {
public AssessmentResultMinimalizedEntity() {}
public AssessmentResultMinimalizedEntity(AssessmentResultRow dr) {
this.AssessmentResult_ID = dr.AssessmentResult_ID;
this.Application_ID = dr.Application_ID;
this.AssessmentResult_Listening = dr.AssessmentResult_Listening;
this.AssessmentResult_Writing = dr.AssessmentResult_Writing;
this.AssessmentResult_Speaking = dr.AssessmentResult_Speaking;
this.AssessmentResult_Reading = dr.AssessmentResult_Reading;
this.AssessmentResult_Status = dr.AssessmentResult_Status;
this.AssessmentResult_CreatedBy = dr.AssessmentResult_CreatedBy;
this.AssessmentResult_CreatedDate = dr.AssessmentResult_CreatedDate;
this.AssessmentResult_UpdatedBy = dr.AssessmentResult_UpdatedBy;
this.AssessmentResult_UpdatedDate = dr.AssessmentResult_UpdatedDate;
this.AssessmentResult_TotalScore = dr.AssessmentResult_TotalScore;
this.AssessmentResult_AverageScore = dr.AssessmentResult_AverageScore;
this.AssessmentResult_Date = dr.AssessmentResult_Date;
this.AssessmentResult_CLOIssueDate = dr.AssessmentResult_CLOIssueDate;
this.AssessmentResult_TechnicalAssessment = dr.AssessmentResult_TechnicalAssessment;
this.AssessmentResult_EnglishFoundation = dr.AssessmentResult_EnglishFoundation;
this.AssessmentResult_EPTSummary = dr.AssessmentResult_EPTSummary;
this.AssessmentResult_Remark = dr.AssessmentResult_Remark;
this.AssessmentResult_ExpectedEnrollmentDate = dr.AssessmentResult_ExpectedEnrollmentDate;
this.AssessmentResult_Interview = dr.AssessmentResult_Interview;
this.AssessmentResult_ContractExpireDate = dr.AssessmentResult_ContractExpireDate;
}
public void CopyTo(AssessmentResultRow dr) {
dr.AssessmentResult_ID = this.AssessmentResult_ID;
dr.Application_ID = this.Application_ID;
dr.AssessmentResult_Listening = this.AssessmentResult_Listening;
dr.AssessmentResult_Writing = this.AssessmentResult_Writing;
dr.AssessmentResult_Speaking = this.AssessmentResult_Speaking;
dr.AssessmentResult_Reading = this.AssessmentResult_Reading;
dr.AssessmentResult_Status = this.AssessmentResult_Status;
dr.AssessmentResult_CreatedBy = this.AssessmentResult_CreatedBy;
dr.AssessmentResult_CreatedDate = this.AssessmentResult_CreatedDate;
dr.AssessmentResult_UpdatedBy = this.AssessmentResult_UpdatedBy;
dr.AssessmentResult_UpdatedDate = this.AssessmentResult_UpdatedDate;
dr.AssessmentResult_TotalScore = this.AssessmentResult_TotalScore;
dr.AssessmentResult_AverageScore = this.AssessmentResult_AverageScore;
dr.AssessmentResult_Date = this.AssessmentResult_Date;
dr.AssessmentResult_CLOIssueDate = this.AssessmentResult_CLOIssueDate;
dr.AssessmentResult_TechnicalAssessment = this.AssessmentResult_TechnicalAssessment;
dr.AssessmentResult_EnglishFoundation = this.AssessmentResult_EnglishFoundation;
dr.AssessmentResult_EPTSummary = this.AssessmentResult_EPTSummary;
dr.AssessmentResult_Remark = this.AssessmentResult_Remark;
dr.AssessmentResult_ExpectedEnrollmentDate = this.AssessmentResult_ExpectedEnrollmentDate;
dr.AssessmentResult_Interview = this.AssessmentResult_Interview;
dr.AssessmentResult_ContractExpireDate = this.AssessmentResult_ContractExpireDate;
}
public System.Guid AssessmentResult_ID;
public System.Guid Application_ID;
public System.Decimal AssessmentResult_Listening;
public System.Decimal AssessmentResult_Writing;
public System.Decimal AssessmentResult_Speaking;
public System.Decimal AssessmentResult_Reading;
public System.Int16 AssessmentResult_Status;
public System.String AssessmentResult_CreatedBy;
public System.DateTime AssessmentResult_CreatedDate;
public System.String AssessmentResult_UpdatedBy;
public System.DateTime AssessmentResult_UpdatedDate;
public System.Decimal AssessmentResult_TotalScore;
public System.Decimal AssessmentResult_AverageScore;
public System.DateTime AssessmentResult_Date;
public System.DateTime AssessmentResult_CLOIssueDate;
public System.Decimal AssessmentResult_TechnicalAssessment;
public System.Decimal AssessmentResult_EnglishFoundation;
public System.Decimal AssessmentResult_EPTSummary;
public System.String AssessmentResult_Remark;
public System.DateTime AssessmentResult_ExpectedEnrollmentDate;
public System.Int16 AssessmentResult_Interview;
public System.DateTime AssessmentResult_ContractExpireDate;
}
public partial class AssessmentResultAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public AssessmentResultAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("AssessmentResult_ID", "AssessmentResult_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("AssessmentResult_Listening", "AssessmentResult_Listening");
tmap.ColumnMappings.Add("AssessmentResult_Writing", "AssessmentResult_Writing");
tmap.ColumnMappings.Add("AssessmentResult_Speaking", "AssessmentResult_Speaking");
tmap.ColumnMappings.Add("AssessmentResult_Reading", "AssessmentResult_Reading");
tmap.ColumnMappings.Add("AssessmentResult_Status", "AssessmentResult_Status");
tmap.ColumnMappings.Add("AssessmentResult_CreatedBy", "AssessmentResult_CreatedBy");
tmap.ColumnMappings.Add("AssessmentResult_CreatedDate", "AssessmentResult_CreatedDate");
tmap.ColumnMappings.Add("AssessmentResult_UpdatedBy", "AssessmentResult_UpdatedBy");
tmap.ColumnMappings.Add("AssessmentResult_UpdatedDate", "AssessmentResult_UpdatedDate");
tmap.ColumnMappings.Add("AssessmentResult_TotalScore", "AssessmentResult_TotalScore");
tmap.ColumnMappings.Add("AssessmentResult_AverageScore", "AssessmentResult_AverageScore");
tmap.ColumnMappings.Add("AssessmentResult_Date", "AssessmentResult_Date");
tmap.ColumnMappings.Add("AssessmentResult_CLOIssueDate", "AssessmentResult_CLOIssueDate");
tmap.ColumnMappings.Add("AssessmentResult_TechnicalAssessment", "AssessmentResult_TechnicalAssessment");
tmap.ColumnMappings.Add("AssessmentResult_EnglishFoundation", "AssessmentResult_EnglishFoundation");
tmap.ColumnMappings.Add("AssessmentResult_EPTSummary", "AssessmentResult_EPTSummary");
tmap.ColumnMappings.Add("AssessmentResult_Remark", "AssessmentResult_Remark");
tmap.ColumnMappings.Add("AssessmentResult_ExpectedEnrollmentDate", "AssessmentResult_ExpectedEnrollmentDate");
tmap.ColumnMappings.Add("AssessmentResult_Interview", "AssessmentResult_Interview");
tmap.ColumnMappings.Add("AssessmentResult_ContractExpireDate", "AssessmentResult_ContractExpireDate");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [AssessmentResult] ([AssessmentResult_ID], [Application_ID], [AssessmentResult_Listening], [AssessmentResult_Writing], [AssessmentResult_Speaking], [AssessmentResult_Reading], [AssessmentResult_Status], [AssessmentResult_CreatedBy], [AssessmentResult_CreatedDate], [AssessmentResult_UpdatedBy], [AssessmentResult_UpdatedDate], [AssessmentResult_TotalScore], [AssessmentResult_AverageScore], [AssessmentResult_Date], [AssessmentResult_CLOIssueDate], [AssessmentResult_TechnicalAssessment], [AssessmentResult_EnglishFoundation], [AssessmentResult_EPTSummary], [AssessmentResult_Remark], [AssessmentResult_ExpectedEnrollmentDate], [AssessmentResult_Interview], [AssessmentResult_ContractExpireDate]) VALUES (@AssessmentResult_ID, @Application_ID, @AssessmentResult_Listening, @AssessmentResult_Writing, @AssessmentResult_Speaking, @AssessmentResult_Reading, @AssessmentResult_Status, @AssessmentResult_CreatedBy, @AssessmentResult_CreatedDate, @AssessmentResult_UpdatedBy, @AssessmentResult_UpdatedDate, @AssessmentResult_TotalScore, @AssessmentResult_AverageScore, @AssessmentResult_Date, @AssessmentResult_CLOIssueDate, @AssessmentResult_TechnicalAssessment, @AssessmentResult_EnglishFoundation, @AssessmentResult_EPTSummary, @AssessmentResult_Remark, @AssessmentResult_ExpectedEnrollmentDate, @AssessmentResult_Interview, @AssessmentResult_ContractExpireDate)");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentResult_ID");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Listening", SqlDbType.Decimal, 0, "AssessmentResult_Listening");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Writing", SqlDbType.Decimal, 0, "AssessmentResult_Writing");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Speaking", SqlDbType.Decimal, 0, "AssessmentResult_Speaking");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Reading", SqlDbType.Decimal, 0, "AssessmentResult_Reading");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Status", SqlDbType.SmallInt, 0, "AssessmentResult_Status");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_CreatedBy", SqlDbType.NVarChar, 0, "AssessmentResult_CreatedBy");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_CreatedDate", SqlDbType.DateTime, 0, "AssessmentResult_CreatedDate");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_UpdatedBy", SqlDbType.NVarChar, 0, "AssessmentResult_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_UpdatedDate", SqlDbType.DateTime, 0, "AssessmentResult_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_TotalScore", SqlDbType.Decimal, 0, "AssessmentResult_TotalScore");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_AverageScore", SqlDbType.Decimal, 0, "AssessmentResult_AverageScore");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Date", SqlDbType.DateTime, 0, "AssessmentResult_Date");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_CLOIssueDate", SqlDbType.DateTime, 0, "AssessmentResult_CLOIssueDate");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_TechnicalAssessment", SqlDbType.Decimal, 0, "AssessmentResult_TechnicalAssessment");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_EnglishFoundation", SqlDbType.Decimal, 0, "AssessmentResult_EnglishFoundation");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_EPTSummary", SqlDbType.Decimal, 0, "AssessmentResult_EPTSummary");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Remark", SqlDbType.NVarChar, 0, "AssessmentResult_Remark");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_ExpectedEnrollmentDate", SqlDbType.DateTime, 0, "AssessmentResult_ExpectedEnrollmentDate");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_Interview", SqlDbType.SmallInt, 0, "AssessmentResult_Interview");
adapter.InsertCommand.Parameters.Add("@AssessmentResult_ContractExpireDate", SqlDbType.DateTime, 0, "AssessmentResult_ContractExpireDate");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [AssessmentResult] SET [AssessmentResult_ID] = @AssessmentResult_ID, [Application_ID] = @Application_ID, [AssessmentResult_Listening] = @AssessmentResult_Listening, [AssessmentResult_Writing] = @AssessmentResult_Writing, [AssessmentResult_Speaking] = @AssessmentResult_Speaking, [AssessmentResult_Reading] = @AssessmentResult_Reading, [AssessmentResult_Status] = @AssessmentResult_Status, [AssessmentResult_CreatedBy] = @AssessmentResult_CreatedBy, [AssessmentResult_CreatedDate] = @AssessmentResult_CreatedDate, [AssessmentResult_UpdatedBy] = @AssessmentResult_UpdatedBy, [AssessmentResult_UpdatedDate] = @AssessmentResult_UpdatedDate, [AssessmentResult_TotalScore] = @AssessmentResult_TotalScore, [AssessmentResult_AverageScore] = @AssessmentResult_AverageScore, [AssessmentResult_Date] = @AssessmentResult_Date, [AssessmentResult_CLOIssueDate] = @AssessmentResult_CLOIssueDate, [AssessmentResult_TechnicalAssessment] = @AssessmentResult_TechnicalAssessment, [AssessmentResult_EnglishFoundation] = @AssessmentResult_EnglishFoundation, [AssessmentResult_EPTSummary] = @AssessmentResult_EPTSummary, [AssessmentResult_Remark] = @AssessmentResult_Remark, [AssessmentResult_ExpectedEnrollmentDate] = @AssessmentResult_ExpectedEnrollmentDate, [AssessmentResult_Interview] = @AssessmentResult_Interview, [AssessmentResult_ContractExpireDate] = @AssessmentResult_ContractExpireDate WHERE [AssessmentResult_ID] = @o_AssessmentResult_ID");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, "AssessmentResult_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_AssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentResult_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Listening", SqlDbType.Decimal, 0, "AssessmentResult_Listening");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Writing", SqlDbType.Decimal, 0, "AssessmentResult_Writing");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Speaking", SqlDbType.Decimal, 0, "AssessmentResult_Speaking");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Reading", SqlDbType.Decimal, 0, "AssessmentResult_Reading");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Status", SqlDbType.SmallInt, 0, "AssessmentResult_Status");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_CreatedBy", SqlDbType.NVarChar, 0, "AssessmentResult_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_CreatedDate", SqlDbType.DateTime, 0, "AssessmentResult_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_UpdatedBy", SqlDbType.NVarChar, 0, "AssessmentResult_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_UpdatedDate", SqlDbType.DateTime, 0, "AssessmentResult_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_TotalScore", SqlDbType.Decimal, 0, "AssessmentResult_TotalScore");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_AverageScore", SqlDbType.Decimal, 0, "AssessmentResult_AverageScore");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Date", SqlDbType.DateTime, 0, "AssessmentResult_Date");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_CLOIssueDate", SqlDbType.DateTime, 0, "AssessmentResult_CLOIssueDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_TechnicalAssessment", SqlDbType.Decimal, 0, "AssessmentResult_TechnicalAssessment");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_EnglishFoundation", SqlDbType.Decimal, 0, "AssessmentResult_EnglishFoundation");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_EPTSummary", SqlDbType.Decimal, 0, "AssessmentResult_EPTSummary");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Remark", SqlDbType.NVarChar, 0, "AssessmentResult_Remark");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_ExpectedEnrollmentDate", SqlDbType.DateTime, 0, "AssessmentResult_ExpectedEnrollmentDate");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_Interview", SqlDbType.SmallInt, 0, "AssessmentResult_Interview");
adapter.UpdateCommand.Parameters.Add("@AssessmentResult_ContractExpireDate", SqlDbType.DateTime, 0, "AssessmentResult_ContractExpireDate");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [AssessmentResult] WHERE [AssessmentResult_ID] = @o_AssessmentResult_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_AssessmentResult_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "AssessmentResult_ID", DataRowVersion.Original, null));
}
public void Update(AssessmentResultTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(AssessmentResultRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public AssessmentResultRow GetByAssessmentResult_ID(System.Guid AssessmentResult_ID ) {
string sql = "SELECT * FROM [AssessmentResult] WHERE [AssessmentResult_ID] = @AssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentResult_ID", AssessmentResult_ID);

AssessmentResultTable tbl = new AssessmentResultTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetAssessmentResultRow(0);
}
public int CountByAssessmentResult_ID(System.Guid AssessmentResult_ID ) {
string sql = "SELECT COUNT(*) FROM [AssessmentResult] WHERE [AssessmentResult_ID] = @AssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentResult_ID", AssessmentResult_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByAssessmentResult_ID(System.Guid AssessmentResult_ID, IActivityLog log ) {
string sql = "DELETE FROM [AssessmentResult] WHERE [AssessmentResult_ID] = @AssessmentResult_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("AssessmentResult_ID", AssessmentResult_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public AssessmentResultTable GetByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [AssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
AssessmentResultTable tbl = new AssessmentResultTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByApplication_ID(System.Guid Application_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [AssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [AssessmentResult] WHERE [Application_ID] = @Application_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Application_ID", Application_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
