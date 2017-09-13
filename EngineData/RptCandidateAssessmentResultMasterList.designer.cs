using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptCandidateAssessmentResultMasterListTable : DataTable {
// column indexes
public const int EnrollmentDateColumnIndex = 0;
public const int FullNameColumnIndex = 1;
public const int DOBColumnIndex = 2;
public const int GenderColumnIndex = 3;
public const int ICNumberColumnIndex = 4;
public const int NationalityColumnIndex = 5;
public const int EmailColumnIndex = 6;
public const int PhoneNumberColumnIndex = 7;
public const int MobileColumnIndex = 8;
public const int CampusNameColumnIndex = 9;
public const int CampusCityColumnIndex = 10;
public const int ContractTypeColumnIndex = 11;
public const int TechnicalAssessmentColumnIndex = 12;
public const int EnglishFoundationColumnIndex = 13;
public const int ListeningColumnIndex = 14;
public const int WritingColumnIndex = 15;
public const int SpeakingColumnIndex = 16;
public const int ReadingColumnIndex = 17;
public const int InterviewColumnIndex = 18;
public const int StatusColumnIndex = 19;
public const int SponsorColumnIndex = 20;
public RptCandidateAssessmentResultMasterListTable() {
TableName = "[RptCandidateAssessmentResultMasterList]";
// column EnrollmentDate
DataColumn EnrollmentDateCol = new DataColumn("EnrollmentDate", typeof(System.DateTime));
EnrollmentDateCol.DateTimeMode = DataSetDateTime.Utc;
EnrollmentDateCol.ReadOnly = true;
EnrollmentDateCol.AllowDBNull = false;
Columns.Add(EnrollmentDateCol);
// column FullName
DataColumn FullNameCol = new DataColumn("FullName", typeof(System.String));
FullNameCol.ReadOnly = true;
FullNameCol.AllowDBNull = false;
Columns.Add(FullNameCol);
// column DOB
DataColumn DOBCol = new DataColumn("DOB", typeof(System.DateTime));
DOBCol.DateTimeMode = DataSetDateTime.Utc;
DOBCol.ReadOnly = true;
DOBCol.AllowDBNull = false;
Columns.Add(DOBCol);
// column Gender
DataColumn GenderCol = new DataColumn("Gender", typeof(System.String));
GenderCol.ReadOnly = true;
GenderCol.AllowDBNull = false;
Columns.Add(GenderCol);
// column ICNumber
DataColumn ICNumberCol = new DataColumn("ICNumber", typeof(System.String));
ICNumberCol.ReadOnly = true;
ICNumberCol.AllowDBNull = false;
Columns.Add(ICNumberCol);
// column Nationality
DataColumn NationalityCol = new DataColumn("Nationality", typeof(System.String));
NationalityCol.ReadOnly = true;
NationalityCol.AllowDBNull = false;
Columns.Add(NationalityCol);
// column Email
DataColumn EmailCol = new DataColumn("Email", typeof(System.String));
EmailCol.ReadOnly = true;
EmailCol.AllowDBNull = false;
Columns.Add(EmailCol);
// column PhoneNumber
DataColumn PhoneNumberCol = new DataColumn("PhoneNumber", typeof(System.String));
PhoneNumberCol.ReadOnly = true;
PhoneNumberCol.AllowDBNull = false;
Columns.Add(PhoneNumberCol);
// column Mobile
DataColumn MobileCol = new DataColumn("Mobile", typeof(System.String));
MobileCol.ReadOnly = true;
MobileCol.AllowDBNull = false;
Columns.Add(MobileCol);
// column CampusName
DataColumn CampusNameCol = new DataColumn("CampusName", typeof(System.String));
CampusNameCol.ReadOnly = true;
CampusNameCol.AllowDBNull = false;
Columns.Add(CampusNameCol);
// column CampusCity
DataColumn CampusCityCol = new DataColumn("CampusCity", typeof(System.String));
CampusCityCol.ReadOnly = true;
CampusCityCol.AllowDBNull = false;
Columns.Add(CampusCityCol);
// column ContractType
DataColumn ContractTypeCol = new DataColumn("ContractType", typeof(System.String));
ContractTypeCol.ReadOnly = true;
ContractTypeCol.AllowDBNull = false;
Columns.Add(ContractTypeCol);
// column TechnicalAssessment
DataColumn TechnicalAssessmentCol = new DataColumn("TechnicalAssessment", typeof(System.Decimal));
TechnicalAssessmentCol.ReadOnly = true;
TechnicalAssessmentCol.AllowDBNull = false;
Columns.Add(TechnicalAssessmentCol);
// column EnglishFoundation
DataColumn EnglishFoundationCol = new DataColumn("EnglishFoundation", typeof(System.Decimal));
EnglishFoundationCol.ReadOnly = true;
EnglishFoundationCol.AllowDBNull = false;
Columns.Add(EnglishFoundationCol);
// column Listening
DataColumn ListeningCol = new DataColumn("Listening", typeof(System.Decimal));
ListeningCol.ReadOnly = true;
ListeningCol.AllowDBNull = false;
Columns.Add(ListeningCol);
// column Writing
DataColumn WritingCol = new DataColumn("Writing", typeof(System.Decimal));
WritingCol.ReadOnly = true;
WritingCol.AllowDBNull = false;
Columns.Add(WritingCol);
// column Speaking
DataColumn SpeakingCol = new DataColumn("Speaking", typeof(System.Decimal));
SpeakingCol.ReadOnly = true;
SpeakingCol.AllowDBNull = false;
Columns.Add(SpeakingCol);
// column Reading
DataColumn ReadingCol = new DataColumn("Reading", typeof(System.Decimal));
ReadingCol.ReadOnly = true;
ReadingCol.AllowDBNull = false;
Columns.Add(ReadingCol);
// column Interview
DataColumn InterviewCol = new DataColumn("Interview", typeof(System.String));
InterviewCol.ReadOnly = true;
InterviewCol.AllowDBNull = false;
Columns.Add(InterviewCol);
// column Status
DataColumn StatusCol = new DataColumn("Status", typeof(System.String));
StatusCol.ReadOnly = true;
StatusCol.AllowDBNull = true;
Columns.Add(StatusCol);
// column Sponsor
DataColumn SponsorCol = new DataColumn("Sponsor", typeof(System.String));
SponsorCol.ReadOnly = true;
SponsorCol.AllowDBNull = true;
Columns.Add(SponsorCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptCandidateAssessmentResultMasterListRow(builder);
}
public RptCandidateAssessmentResultMasterListRow GetRptCandidateAssessmentResultMasterListRow(int index) {
return (RptCandidateAssessmentResultMasterListRow)Rows[index];
}
}
public partial class RptCandidateAssessmentResultMasterListRow : DataRow {
internal RptCandidateAssessmentResultMasterListRow(DataRowBuilder builder) : base(builder) {
}
public System.DateTime EnrollmentDate {
get {
return (System.DateTime)this["EnrollmentDate"];
}
}
public System.String FullName {
get {
return (System.String)this["FullName"];
}
}
public System.DateTime DOB {
get {
return (System.DateTime)this["DOB"];
}
}
public System.String Gender {
get {
return (System.String)this["Gender"];
}
}
public System.String ICNumber {
get {
return (System.String)this["ICNumber"];
}
}
public System.String Nationality {
get {
return (System.String)this["Nationality"];
}
}
public System.String Email {
get {
return (System.String)this["Email"];
}
}
public System.String PhoneNumber {
get {
return (System.String)this["PhoneNumber"];
}
}
public System.String Mobile {
get {
return (System.String)this["Mobile"];
}
}
public System.String CampusName {
get {
return (System.String)this["CampusName"];
}
}
public System.String CampusCity {
get {
return (System.String)this["CampusCity"];
}
}
public System.String ContractType {
get {
return (System.String)this["ContractType"];
}
}
public System.Decimal TechnicalAssessment {
get {
return (System.Decimal)this["TechnicalAssessment"];
}
}
public System.Decimal EnglishFoundation {
get {
return (System.Decimal)this["EnglishFoundation"];
}
}
public System.Decimal Listening {
get {
return (System.Decimal)this["Listening"];
}
}
public System.Decimal Writing {
get {
return (System.Decimal)this["Writing"];
}
}
public System.Decimal Speaking {
get {
return (System.Decimal)this["Speaking"];
}
}
public System.Decimal Reading {
get {
return (System.Decimal)this["Reading"];
}
}
public System.String Interview {
get {
return (System.String)this["Interview"];
}
}
public System.String Status {
get {
if( IsNull("Status") ) return "";
else return (System.String)this["Status"];
}
}
public System.String Sponsor {
get {
if( IsNull("Sponsor") ) return "";
else return (System.String)this["Sponsor"];
}
}
}
public partial class RptCandidateAssessmentResultMasterListMinimalizedEntity {
public RptCandidateAssessmentResultMasterListMinimalizedEntity() {}
public RptCandidateAssessmentResultMasterListMinimalizedEntity(RptCandidateAssessmentResultMasterListRow dr) {
this.EnrollmentDate = dr.EnrollmentDate;
this.FullName = dr.FullName;
this.DOB = dr.DOB;
this.Gender = dr.Gender;
this.ICNumber = dr.ICNumber;
this.Nationality = dr.Nationality;
this.Email = dr.Email;
this.PhoneNumber = dr.PhoneNumber;
this.Mobile = dr.Mobile;
this.CampusName = dr.CampusName;
this.CampusCity = dr.CampusCity;
this.ContractType = dr.ContractType;
this.TechnicalAssessment = dr.TechnicalAssessment;
this.EnglishFoundation = dr.EnglishFoundation;
this.Listening = dr.Listening;
this.Writing = dr.Writing;
this.Speaking = dr.Speaking;
this.Reading = dr.Reading;
this.Interview = dr.Interview;
this.Status = dr.Status;
this.Sponsor = dr.Sponsor;
}
public System.DateTime EnrollmentDate;
public System.String FullName;
public System.DateTime DOB;
public System.String Gender;
public System.String ICNumber;
public System.String Nationality;
public System.String Email;
public System.String PhoneNumber;
public System.String Mobile;
public System.String CampusName;
public System.String CampusCity;
public System.String ContractType;
public System.Decimal TechnicalAssessment;
public System.Decimal EnglishFoundation;
public System.Decimal Listening;
public System.Decimal Writing;
public System.Decimal Speaking;
public System.Decimal Reading;
public System.String Interview;
public System.String Status;
public System.String Sponsor;
}
public partial class RptCandidateAssessmentResultMasterListAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptCandidateAssessmentResultMasterListAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("EnrollmentDate", "EnrollmentDate");
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DOB", "DOB");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("ICNumber", "ICNumber");
tmap.ColumnMappings.Add("Nationality", "Nationality");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
tmap.ColumnMappings.Add("Mobile", "Mobile");
tmap.ColumnMappings.Add("CampusName", "CampusName");
tmap.ColumnMappings.Add("CampusCity", "CampusCity");
tmap.ColumnMappings.Add("ContractType", "ContractType");
tmap.ColumnMappings.Add("TechnicalAssessment", "TechnicalAssessment");
tmap.ColumnMappings.Add("EnglishFoundation", "EnglishFoundation");
tmap.ColumnMappings.Add("Listening", "Listening");
tmap.ColumnMappings.Add("Writing", "Writing");
tmap.ColumnMappings.Add("Speaking", "Speaking");
tmap.ColumnMappings.Add("Reading", "Reading");
tmap.ColumnMappings.Add("Interview", "Interview");
tmap.ColumnMappings.Add("Status", "Status");
tmap.ColumnMappings.Add("Sponsor", "Sponsor");
adapter.TableMappings.Add(tmap);
}
}
public RptCandidateAssessmentResultMasterListRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptCandidateAssessmentResultMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptCandidateAssessmentResultMasterListTable tbl = new RptCandidateAssessmentResultMasterListTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptCandidateAssessmentResultMasterListRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptCandidateAssessmentResultMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
