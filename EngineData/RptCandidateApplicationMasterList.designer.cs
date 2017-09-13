using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptCandidateApplicationMasterListTable : DataTable {
// column indexes
public const int DateColumnIndex = 0;
public const int FullNameColumnIndex = 1;
public const int DOBColumnIndex = 2;
public const int GenderColumnIndex = 3;
public const int NationalityColumnIndex = 4;
public const int ICNumberColumnIndex = 5;
public const int Address1ColumnIndex = 6;
public const int Address2ColumnIndex = 7;
public const int PostcodeColumnIndex = 8;
public const int CityColumnIndex = 9;
public const int StateColumnIndex = 10;
public const int CountryColumnIndex = 11;
public const int EmailColumnIndex = 12;
public const int FatherNameColumnIndex = 13;
public const int FatherIdentificationColumnIndex = 14;
public const int MotherNameColumnIndex = 15;
public const int MotherIdentificationColumnIndex = 16;
public const int CombinedHouseholdIncomeColumnIndex = 17;
public const int CurrentFieldOfStudyColumnIndex = 18;
public const int UniversityColumnIndex = 19;
public const int CGPAColumnIndex = 20;
public const int PQQualificationColumnIndex = 21;
public const int PGRegistrationNumberColumnIndex = 22;
public const int PQStartDateColumnIndex = 23;
public const int PQLevelStartColumnIndex = 24;
public const int PQDeadlineColumnIndex = 25;
public const int RegisteredNextExamColumnIndex = 26;
public const int NextExamSessionColumnIndex = 27;
public const int ContractTypeColumnIndex = 28;
public const int ScholarshipProviderColumnIndex = 29;
public const int ScholarshipCostColumnIndex = 30;
public const int StatusColumnIndex = 31;
public const int CreatedDateColumnIndex = 32;
public const int CreatedByColumnIndex = 33;
public const int UpdatedDateColumnIndex = 34;
public const int UpdatedByColumnIndex = 35;
public const int SubmittedDateColumnIndex = 36;
public const int PhoneNumberColumnIndex = 37;
public const int MobileColumnIndex = 38;
public const int LOIssueDateColumnIndex = 39;
public const int CampusNameColumnIndex = 40;
public const int CampusCityColumnIndex = 41;
public const int SponsorColumnIndex = 42;
public RptCandidateApplicationMasterListTable() {
TableName = "[RptCandidateApplicationMasterList]";
// column Date
DataColumn DateCol = new DataColumn("Date", typeof(System.DateTime));
DateCol.DateTimeMode = DataSetDateTime.Utc;
DateCol.ReadOnly = true;
DateCol.AllowDBNull = false;
Columns.Add(DateCol);
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
// column Nationality
DataColumn NationalityCol = new DataColumn("Nationality", typeof(System.String));
NationalityCol.ReadOnly = true;
NationalityCol.AllowDBNull = false;
Columns.Add(NationalityCol);
// column ICNumber
DataColumn ICNumberCol = new DataColumn("ICNumber", typeof(System.String));
ICNumberCol.ReadOnly = true;
ICNumberCol.AllowDBNull = false;
Columns.Add(ICNumberCol);
// column Address1
DataColumn Address1Col = new DataColumn("Address1", typeof(System.String));
Address1Col.ReadOnly = true;
Address1Col.AllowDBNull = false;
Columns.Add(Address1Col);
// column Address2
DataColumn Address2Col = new DataColumn("Address2", typeof(System.String));
Address2Col.ReadOnly = true;
Address2Col.AllowDBNull = false;
Columns.Add(Address2Col);
// column Postcode
DataColumn PostcodeCol = new DataColumn("Postcode", typeof(System.String));
PostcodeCol.ReadOnly = true;
PostcodeCol.AllowDBNull = false;
Columns.Add(PostcodeCol);
// column City
DataColumn CityCol = new DataColumn("City", typeof(System.String));
CityCol.ReadOnly = true;
CityCol.AllowDBNull = false;
Columns.Add(CityCol);
// column State
DataColumn StateCol = new DataColumn("State", typeof(System.String));
StateCol.ReadOnly = true;
StateCol.AllowDBNull = false;
Columns.Add(StateCol);
// column Country
DataColumn CountryCol = new DataColumn("Country", typeof(System.String));
CountryCol.ReadOnly = true;
CountryCol.AllowDBNull = false;
Columns.Add(CountryCol);
// column Email
DataColumn EmailCol = new DataColumn("Email", typeof(System.String));
EmailCol.ReadOnly = true;
EmailCol.AllowDBNull = false;
Columns.Add(EmailCol);
// column FatherName
DataColumn FatherNameCol = new DataColumn("FatherName", typeof(System.String));
FatherNameCol.ReadOnly = true;
FatherNameCol.AllowDBNull = false;
Columns.Add(FatherNameCol);
// column FatherIdentification
DataColumn FatherIdentificationCol = new DataColumn("FatherIdentification", typeof(System.String));
FatherIdentificationCol.ReadOnly = true;
FatherIdentificationCol.AllowDBNull = false;
Columns.Add(FatherIdentificationCol);
// column MotherName
DataColumn MotherNameCol = new DataColumn("MotherName", typeof(System.String));
MotherNameCol.ReadOnly = true;
MotherNameCol.AllowDBNull = false;
Columns.Add(MotherNameCol);
// column MotherIdentification
DataColumn MotherIdentificationCol = new DataColumn("MotherIdentification", typeof(System.String));
MotherIdentificationCol.ReadOnly = true;
MotherIdentificationCol.AllowDBNull = false;
Columns.Add(MotherIdentificationCol);
// column CombinedHouseholdIncome
DataColumn CombinedHouseholdIncomeCol = new DataColumn("CombinedHouseholdIncome", typeof(System.Decimal));
CombinedHouseholdIncomeCol.ReadOnly = true;
CombinedHouseholdIncomeCol.AllowDBNull = false;
Columns.Add(CombinedHouseholdIncomeCol);
// column CurrentFieldOfStudy
DataColumn CurrentFieldOfStudyCol = new DataColumn("CurrentFieldOfStudy", typeof(System.String));
CurrentFieldOfStudyCol.ReadOnly = true;
CurrentFieldOfStudyCol.AllowDBNull = false;
Columns.Add(CurrentFieldOfStudyCol);
// column University
DataColumn UniversityCol = new DataColumn("University", typeof(System.String));
UniversityCol.ReadOnly = true;
UniversityCol.AllowDBNull = false;
Columns.Add(UniversityCol);
// column CGPA
DataColumn CGPACol = new DataColumn("CGPA", typeof(System.String));
CGPACol.ReadOnly = true;
CGPACol.AllowDBNull = false;
Columns.Add(CGPACol);
// column PQQualification
DataColumn PQQualificationCol = new DataColumn("PQQualification", typeof(System.String));
PQQualificationCol.ReadOnly = true;
PQQualificationCol.AllowDBNull = false;
Columns.Add(PQQualificationCol);
// column PGRegistrationNumber
DataColumn PGRegistrationNumberCol = new DataColumn("PGRegistrationNumber", typeof(System.String));
PGRegistrationNumberCol.ReadOnly = true;
PGRegistrationNumberCol.AllowDBNull = false;
Columns.Add(PGRegistrationNumberCol);
// column PQStartDate
DataColumn PQStartDateCol = new DataColumn("PQStartDate", typeof(System.DateTime));
PQStartDateCol.DateTimeMode = DataSetDateTime.Utc;
PQStartDateCol.ReadOnly = true;
PQStartDateCol.AllowDBNull = false;
Columns.Add(PQStartDateCol);
// column PQLevelStart
DataColumn PQLevelStartCol = new DataColumn("PQLevelStart", typeof(System.String));
PQLevelStartCol.ReadOnly = true;
PQLevelStartCol.AllowDBNull = true;
Columns.Add(PQLevelStartCol);
// column PQDeadline
DataColumn PQDeadlineCol = new DataColumn("PQDeadline", typeof(System.DateTime));
PQDeadlineCol.DateTimeMode = DataSetDateTime.Utc;
PQDeadlineCol.ReadOnly = true;
PQDeadlineCol.AllowDBNull = false;
Columns.Add(PQDeadlineCol);
// column RegisteredNextExam
DataColumn RegisteredNextExamCol = new DataColumn("RegisteredNextExam", typeof(System.String));
RegisteredNextExamCol.ReadOnly = true;
RegisteredNextExamCol.AllowDBNull = false;
Columns.Add(RegisteredNextExamCol);
// column NextExamSession
DataColumn NextExamSessionCol = new DataColumn("NextExamSession", typeof(System.DateTime));
NextExamSessionCol.DateTimeMode = DataSetDateTime.Utc;
NextExamSessionCol.ReadOnly = true;
NextExamSessionCol.AllowDBNull = false;
Columns.Add(NextExamSessionCol);
// column ContractType
DataColumn ContractTypeCol = new DataColumn("ContractType", typeof(System.String));
ContractTypeCol.ReadOnly = true;
ContractTypeCol.AllowDBNull = false;
Columns.Add(ContractTypeCol);
// column ScholarshipProvider
DataColumn ScholarshipProviderCol = new DataColumn("ScholarshipProvider", typeof(System.String));
ScholarshipProviderCol.ReadOnly = true;
ScholarshipProviderCol.AllowDBNull = false;
Columns.Add(ScholarshipProviderCol);
// column ScholarshipCost
DataColumn ScholarshipCostCol = new DataColumn("ScholarshipCost", typeof(System.Decimal));
ScholarshipCostCol.ReadOnly = true;
ScholarshipCostCol.AllowDBNull = false;
Columns.Add(ScholarshipCostCol);
// column Status
DataColumn StatusCol = new DataColumn("Status", typeof(System.String));
StatusCol.ReadOnly = true;
StatusCol.AllowDBNull = true;
Columns.Add(StatusCol);
// column CreatedDate
DataColumn CreatedDateCol = new DataColumn("CreatedDate", typeof(System.DateTime));
CreatedDateCol.DateTimeMode = DataSetDateTime.Utc;
CreatedDateCol.ReadOnly = true;
CreatedDateCol.AllowDBNull = false;
Columns.Add(CreatedDateCol);
// column CreatedBy
DataColumn CreatedByCol = new DataColumn("CreatedBy", typeof(System.String));
CreatedByCol.ReadOnly = true;
CreatedByCol.AllowDBNull = false;
Columns.Add(CreatedByCol);
// column UpdatedDate
DataColumn UpdatedDateCol = new DataColumn("UpdatedDate", typeof(System.DateTime));
UpdatedDateCol.DateTimeMode = DataSetDateTime.Utc;
UpdatedDateCol.ReadOnly = true;
UpdatedDateCol.AllowDBNull = false;
Columns.Add(UpdatedDateCol);
// column UpdatedBy
DataColumn UpdatedByCol = new DataColumn("UpdatedBy", typeof(System.String));
UpdatedByCol.ReadOnly = true;
UpdatedByCol.AllowDBNull = false;
Columns.Add(UpdatedByCol);
// column SubmittedDate
DataColumn SubmittedDateCol = new DataColumn("SubmittedDate", typeof(System.DateTime));
SubmittedDateCol.DateTimeMode = DataSetDateTime.Utc;
SubmittedDateCol.ReadOnly = true;
SubmittedDateCol.AllowDBNull = false;
Columns.Add(SubmittedDateCol);
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
// column LOIssueDate
DataColumn LOIssueDateCol = new DataColumn("LOIssueDate", typeof(System.DateTime));
LOIssueDateCol.DateTimeMode = DataSetDateTime.Utc;
LOIssueDateCol.ReadOnly = true;
LOIssueDateCol.AllowDBNull = false;
Columns.Add(LOIssueDateCol);
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
// column Sponsor
DataColumn SponsorCol = new DataColumn("Sponsor", typeof(System.String));
SponsorCol.ReadOnly = true;
SponsorCol.AllowDBNull = true;
Columns.Add(SponsorCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptCandidateApplicationMasterListRow(builder);
}
public RptCandidateApplicationMasterListRow GetRptCandidateApplicationMasterListRow(int index) {
return (RptCandidateApplicationMasterListRow)Rows[index];
}
}
public partial class RptCandidateApplicationMasterListRow : DataRow {
internal RptCandidateApplicationMasterListRow(DataRowBuilder builder) : base(builder) {
}
public System.DateTime Date {
get {
return (System.DateTime)this["Date"];
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
public System.String Nationality {
get {
return (System.String)this["Nationality"];
}
}
public System.String ICNumber {
get {
return (System.String)this["ICNumber"];
}
}
public System.String Address1 {
get {
return (System.String)this["Address1"];
}
}
public System.String Address2 {
get {
return (System.String)this["Address2"];
}
}
public System.String Postcode {
get {
return (System.String)this["Postcode"];
}
}
public System.String City {
get {
return (System.String)this["City"];
}
}
public System.String State {
get {
return (System.String)this["State"];
}
}
public System.String Country {
get {
return (System.String)this["Country"];
}
}
public System.String Email {
get {
return (System.String)this["Email"];
}
}
public System.String FatherName {
get {
return (System.String)this["FatherName"];
}
}
public System.String FatherIdentification {
get {
return (System.String)this["FatherIdentification"];
}
}
public System.String MotherName {
get {
return (System.String)this["MotherName"];
}
}
public System.String MotherIdentification {
get {
return (System.String)this["MotherIdentification"];
}
}
public System.Decimal CombinedHouseholdIncome {
get {
return (System.Decimal)this["CombinedHouseholdIncome"];
}
}
public System.String CurrentFieldOfStudy {
get {
return (System.String)this["CurrentFieldOfStudy"];
}
}
public System.String University {
get {
return (System.String)this["University"];
}
}
public System.String CGPA {
get {
return (System.String)this["CGPA"];
}
}
public System.String PQQualification {
get {
return (System.String)this["PQQualification"];
}
}
public System.String PGRegistrationNumber {
get {
return (System.String)this["PGRegistrationNumber"];
}
}
public System.DateTime PQStartDate {
get {
return (System.DateTime)this["PQStartDate"];
}
}
public System.String PQLevelStart {
get {
if( IsNull("PQLevelStart") ) return "";
else return (System.String)this["PQLevelStart"];
}
}
public System.DateTime PQDeadline {
get {
return (System.DateTime)this["PQDeadline"];
}
}
public System.String RegisteredNextExam {
get {
return (System.String)this["RegisteredNextExam"];
}
}
public System.DateTime NextExamSession {
get {
return (System.DateTime)this["NextExamSession"];
}
}
public System.String ContractType {
get {
return (System.String)this["ContractType"];
}
}
public System.String ScholarshipProvider {
get {
return (System.String)this["ScholarshipProvider"];
}
}
public System.Decimal ScholarshipCost {
get {
return (System.Decimal)this["ScholarshipCost"];
}
}
public System.String Status {
get {
if( IsNull("Status") ) return "";
else return (System.String)this["Status"];
}
}
public System.DateTime CreatedDate {
get {
return (System.DateTime)this["CreatedDate"];
}
}
public System.String CreatedBy {
get {
return (System.String)this["CreatedBy"];
}
}
public System.DateTime UpdatedDate {
get {
return (System.DateTime)this["UpdatedDate"];
}
}
public System.String UpdatedBy {
get {
return (System.String)this["UpdatedBy"];
}
}
public System.DateTime SubmittedDate {
get {
return (System.DateTime)this["SubmittedDate"];
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
public System.DateTime LOIssueDate {
get {
return (System.DateTime)this["LOIssueDate"];
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
public System.String Sponsor {
get {
if( IsNull("Sponsor") ) return "";
else return (System.String)this["Sponsor"];
}
}
}
public partial class RptCandidateApplicationMasterListMinimalizedEntity {
public RptCandidateApplicationMasterListMinimalizedEntity() {}
public RptCandidateApplicationMasterListMinimalizedEntity(RptCandidateApplicationMasterListRow dr) {
this.Date = dr.Date;
this.FullName = dr.FullName;
this.DOB = dr.DOB;
this.Gender = dr.Gender;
this.Nationality = dr.Nationality;
this.ICNumber = dr.ICNumber;
this.Address1 = dr.Address1;
this.Address2 = dr.Address2;
this.Postcode = dr.Postcode;
this.City = dr.City;
this.State = dr.State;
this.Country = dr.Country;
this.Email = dr.Email;
this.FatherName = dr.FatherName;
this.FatherIdentification = dr.FatherIdentification;
this.MotherName = dr.MotherName;
this.MotherIdentification = dr.MotherIdentification;
this.CombinedHouseholdIncome = dr.CombinedHouseholdIncome;
this.CurrentFieldOfStudy = dr.CurrentFieldOfStudy;
this.University = dr.University;
this.CGPA = dr.CGPA;
this.PQQualification = dr.PQQualification;
this.PGRegistrationNumber = dr.PGRegistrationNumber;
this.PQStartDate = dr.PQStartDate;
this.PQLevelStart = dr.PQLevelStart;
this.PQDeadline = dr.PQDeadline;
this.RegisteredNextExam = dr.RegisteredNextExam;
this.NextExamSession = dr.NextExamSession;
this.ContractType = dr.ContractType;
this.ScholarshipProvider = dr.ScholarshipProvider;
this.ScholarshipCost = dr.ScholarshipCost;
this.Status = dr.Status;
this.CreatedDate = dr.CreatedDate;
this.CreatedBy = dr.CreatedBy;
this.UpdatedDate = dr.UpdatedDate;
this.UpdatedBy = dr.UpdatedBy;
this.SubmittedDate = dr.SubmittedDate;
this.PhoneNumber = dr.PhoneNumber;
this.Mobile = dr.Mobile;
this.LOIssueDate = dr.LOIssueDate;
this.CampusName = dr.CampusName;
this.CampusCity = dr.CampusCity;
this.Sponsor = dr.Sponsor;
}
public System.DateTime Date;
public System.String FullName;
public System.DateTime DOB;
public System.String Gender;
public System.String Nationality;
public System.String ICNumber;
public System.String Address1;
public System.String Address2;
public System.String Postcode;
public System.String City;
public System.String State;
public System.String Country;
public System.String Email;
public System.String FatherName;
public System.String FatherIdentification;
public System.String MotherName;
public System.String MotherIdentification;
public System.Decimal CombinedHouseholdIncome;
public System.String CurrentFieldOfStudy;
public System.String University;
public System.String CGPA;
public System.String PQQualification;
public System.String PGRegistrationNumber;
public System.DateTime PQStartDate;
public System.String PQLevelStart;
public System.DateTime PQDeadline;
public System.String RegisteredNextExam;
public System.DateTime NextExamSession;
public System.String ContractType;
public System.String ScholarshipProvider;
public System.Decimal ScholarshipCost;
public System.String Status;
public System.DateTime CreatedDate;
public System.String CreatedBy;
public System.DateTime UpdatedDate;
public System.String UpdatedBy;
public System.DateTime SubmittedDate;
public System.String PhoneNumber;
public System.String Mobile;
public System.DateTime LOIssueDate;
public System.String CampusName;
public System.String CampusCity;
public System.String Sponsor;
}
public partial class RptCandidateApplicationMasterListAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptCandidateApplicationMasterListAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Date", "Date");
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DOB", "DOB");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("Nationality", "Nationality");
tmap.ColumnMappings.Add("ICNumber", "ICNumber");
tmap.ColumnMappings.Add("Address1", "Address1");
tmap.ColumnMappings.Add("Address2", "Address2");
tmap.ColumnMappings.Add("Postcode", "Postcode");
tmap.ColumnMappings.Add("City", "City");
tmap.ColumnMappings.Add("State", "State");
tmap.ColumnMappings.Add("Country", "Country");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("FatherName", "FatherName");
tmap.ColumnMappings.Add("FatherIdentification", "FatherIdentification");
tmap.ColumnMappings.Add("MotherName", "MotherName");
tmap.ColumnMappings.Add("MotherIdentification", "MotherIdentification");
tmap.ColumnMappings.Add("CombinedHouseholdIncome", "CombinedHouseholdIncome");
tmap.ColumnMappings.Add("CurrentFieldOfStudy", "CurrentFieldOfStudy");
tmap.ColumnMappings.Add("University", "University");
tmap.ColumnMappings.Add("CGPA", "CGPA");
tmap.ColumnMappings.Add("PQQualification", "PQQualification");
tmap.ColumnMappings.Add("PGRegistrationNumber", "PGRegistrationNumber");
tmap.ColumnMappings.Add("PQStartDate", "PQStartDate");
tmap.ColumnMappings.Add("PQLevelStart", "PQLevelStart");
tmap.ColumnMappings.Add("PQDeadline", "PQDeadline");
tmap.ColumnMappings.Add("RegisteredNextExam", "RegisteredNextExam");
tmap.ColumnMappings.Add("NextExamSession", "NextExamSession");
tmap.ColumnMappings.Add("ContractType", "ContractType");
tmap.ColumnMappings.Add("ScholarshipProvider", "ScholarshipProvider");
tmap.ColumnMappings.Add("ScholarshipCost", "ScholarshipCost");
tmap.ColumnMappings.Add("Status", "Status");
tmap.ColumnMappings.Add("CreatedDate", "CreatedDate");
tmap.ColumnMappings.Add("CreatedBy", "CreatedBy");
tmap.ColumnMappings.Add("UpdatedDate", "UpdatedDate");
tmap.ColumnMappings.Add("UpdatedBy", "UpdatedBy");
tmap.ColumnMappings.Add("SubmittedDate", "SubmittedDate");
tmap.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
tmap.ColumnMappings.Add("Mobile", "Mobile");
tmap.ColumnMappings.Add("LOIssueDate", "LOIssueDate");
tmap.ColumnMappings.Add("CampusName", "CampusName");
tmap.ColumnMappings.Add("CampusCity", "CampusCity");
tmap.ColumnMappings.Add("Sponsor", "Sponsor");
adapter.TableMappings.Add(tmap);
}
}
public RptCandidateApplicationMasterListRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptCandidateApplicationMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptCandidateApplicationMasterListTable tbl = new RptCandidateApplicationMasterListTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptCandidateApplicationMasterListRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptCandidateApplicationMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
