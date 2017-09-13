using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class WorkHistoryDetailTable : DataTable {
// column indexes
public const int WorkHistory_IDColumnIndex = 0;
public const int Application_IDColumnIndex = 1;
public const int WorkHistory_CompanyNameColumnIndex = 2;
public const int WorkHistory_JobTitleColumnIndex = 3;
public const int WorkHistory_StartDateColumnIndex = 4;
public const int WorkHistory_ResignDateColumnIndex = 5;
public const int WorkHistory_DescriptionColumnIndex = 6;
public const int WorkHistory_CreatedByColumnIndex = 7;
public const int WorkHistory_CreatedDateColumnIndex = 8;
public const int WorkHistory_UpdatedByColumnIndex = 9;
public const int WorkHistory_UpdatedDateColumnIndex = 10;
public const int WorkHistory_IsDeletedColumnIndex = 11;
public const int Application_FinalisedDateColumnIndex = 12;
public const int Application_LOIssueDateColumnIndex = 13;
public const int Application_FinalisedStatusColumnIndex = 14;
public const int Application_MobilePhoneNumberColumnIndex = 15;
public const int Application_MobilePhonePrefixColumnIndex = 16;
public const int Application_PhoneNumberColumnIndex = 17;
public const int Application_PhonePrefixColumnIndex = 18;
public const int Application_ContractTypeColumnIndex = 19;
public const int Application_MotherNameColumnIndex = 20;
public const int Application_FatherNameColumnIndex = 21;
public const int Application_SubmittedDateColumnIndex = 22;
public const int Application_UpdatedByColumnIndex = 23;
public const int Application_CreatedByColumnIndex = 24;
public const int Application_UpdatedDateColumnIndex = 25;
public const int Application_CreatedDateColumnIndex = 26;
public const int Application_StatusColumnIndex = 27;
public const int Application_DeletedColumnIndex = 28;
public const int Application_SubmittedColumnIndex = 29;
public const int Application_ConfirmAgreeTermsAndConditionColumnIndex = 30;
public const int Application_ConfirmReceiveMyPACNoticeColumnIndex = 31;
public const int Application_DeclarationAgreeColumnIndex = 32;
public const int Application_PQAcceptanceImageColumnIndex = 33;
public const int Application_PassportSizeImageColumnIndex = 34;
public const int Application_AcademicTranscriptImageColumnIndex = 35;
public const int Application_BirthCertificateImageColumnIndex = 36;
public const int Application_IdentificationImageColumnIndex = 37;
public const int Application_ScholarshipCostColumnIndex = 38;
public const int Application_ScholarshipProviderColumnIndex = 39;
public const int TSP_IDColumnIndex = 40;
public const int Application_NextExamSessionColumnIndex = 41;
public const int Application_RegisteredNextExamColumnIndex = 42;
public const int Application_PQDeadlineColumnIndex = 43;
public const int Application_PQLevelStartColumnIndex = 44;
public const int Application_PQStartDateColumnIndex = 45;
public const int Application_PGRegistrationNumberColumnIndex = 46;
public const int Application_PQQualificationColumnIndex = 47;
public const int Application_CGPAColumnIndex = 48;
public const int Application_UniversityColumnIndex = 49;
public const int Application_CurrentFieldOfStudyColumnIndex = 50;
public const int Application_CombinedHouseholdIncomeColumnIndex = 51;
public const int Application_MotherIdentificationColumnIndex = 52;
public const int Application_FatherIdentificationColumnIndex = 53;
public const int Application_EmailColumnIndex = 54;
public const int Country_IDColumnIndex = 55;
public const int Application_StateColumnIndex = 56;
public const int Application_CityColumnIndex = 57;
public const int Application_PostcodeColumnIndex = 58;
public const int Application_Address2ColumnIndex = 59;
public const int Application_Address1ColumnIndex = 60;
public const int Application_IdentificationNumberColumnIndex = 61;
public const int Application_NationalityColumnIndex = 62;
public const int Application_GenderColumnIndex = 63;
public const int Application_DOBColumnIndex = 64;
public const int Candidate_IDColumnIndex = 65;
public const int Application_OverallStatusColumnIndex = 66;
public const int Application_OverallProgressColumnIndex = 67;
public const int Application_FullNameColumnIndex = 68;
public const int Application_DateColumnIndex = 69;
public const int Course_IDColumnIndex = 70;
public const int Application_CountryNameColumnIndex = 71;
public const int Application_IntakeMonthColumnIndex = 72;
public const int Application_IntakeYearColumnIndex = 73;
public const int Sponsor_IDColumnIndex = 74;
public const int Sponsor_CodeColumnIndex = 75;
public const int Sponsor_LabelColumnIndex = 76;
public WorkHistoryDetailTable() {
TableName = "[WorkHistoryDetail]";
// column WorkHistory_ID
DataColumn WorkHistory_IDCol = new DataColumn("WorkHistory_ID", typeof(System.Guid));
WorkHistory_IDCol.ReadOnly = true;
WorkHistory_IDCol.AllowDBNull = false;
Columns.Add(WorkHistory_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = true;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column WorkHistory_CompanyName
DataColumn WorkHistory_CompanyNameCol = new DataColumn("WorkHistory_CompanyName", typeof(System.String));
WorkHistory_CompanyNameCol.ReadOnly = true;
WorkHistory_CompanyNameCol.AllowDBNull = false;
Columns.Add(WorkHistory_CompanyNameCol);
// column WorkHistory_JobTitle
DataColumn WorkHistory_JobTitleCol = new DataColumn("WorkHistory_JobTitle", typeof(System.String));
WorkHistory_JobTitleCol.ReadOnly = true;
WorkHistory_JobTitleCol.AllowDBNull = false;
Columns.Add(WorkHistory_JobTitleCol);
// column WorkHistory_StartDate
DataColumn WorkHistory_StartDateCol = new DataColumn("WorkHistory_StartDate", typeof(System.DateTime));
WorkHistory_StartDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_StartDateCol.ReadOnly = true;
WorkHistory_StartDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_StartDateCol);
// column WorkHistory_ResignDate
DataColumn WorkHistory_ResignDateCol = new DataColumn("WorkHistory_ResignDate", typeof(System.DateTime));
WorkHistory_ResignDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_ResignDateCol.ReadOnly = true;
WorkHistory_ResignDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_ResignDateCol);
// column WorkHistory_Description
DataColumn WorkHistory_DescriptionCol = new DataColumn("WorkHistory_Description", typeof(System.String));
WorkHistory_DescriptionCol.ReadOnly = true;
WorkHistory_DescriptionCol.AllowDBNull = false;
Columns.Add(WorkHistory_DescriptionCol);
// column WorkHistory_CreatedBy
DataColumn WorkHistory_CreatedByCol = new DataColumn("WorkHistory_CreatedBy", typeof(System.String));
WorkHistory_CreatedByCol.ReadOnly = true;
WorkHistory_CreatedByCol.AllowDBNull = false;
Columns.Add(WorkHistory_CreatedByCol);
// column WorkHistory_CreatedDate
DataColumn WorkHistory_CreatedDateCol = new DataColumn("WorkHistory_CreatedDate", typeof(System.DateTime));
WorkHistory_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_CreatedDateCol.ReadOnly = true;
WorkHistory_CreatedDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_CreatedDateCol);
// column WorkHistory_UpdatedBy
DataColumn WorkHistory_UpdatedByCol = new DataColumn("WorkHistory_UpdatedBy", typeof(System.String));
WorkHistory_UpdatedByCol.ReadOnly = true;
WorkHistory_UpdatedByCol.AllowDBNull = false;
Columns.Add(WorkHistory_UpdatedByCol);
// column WorkHistory_UpdatedDate
DataColumn WorkHistory_UpdatedDateCol = new DataColumn("WorkHistory_UpdatedDate", typeof(System.DateTime));
WorkHistory_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
WorkHistory_UpdatedDateCol.ReadOnly = true;
WorkHistory_UpdatedDateCol.AllowDBNull = false;
Columns.Add(WorkHistory_UpdatedDateCol);
// column WorkHistory_IsDeleted
DataColumn WorkHistory_IsDeletedCol = new DataColumn("WorkHistory_IsDeleted", typeof(System.Boolean));
WorkHistory_IsDeletedCol.ReadOnly = true;
WorkHistory_IsDeletedCol.AllowDBNull = false;
Columns.Add(WorkHistory_IsDeletedCol);
// column Application_FinalisedDate
DataColumn Application_FinalisedDateCol = new DataColumn("Application_FinalisedDate", typeof(System.DateTime));
Application_FinalisedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_FinalisedDateCol.ReadOnly = true;
Application_FinalisedDateCol.AllowDBNull = false;
Columns.Add(Application_FinalisedDateCol);
// column Application_LOIssueDate
DataColumn Application_LOIssueDateCol = new DataColumn("Application_LOIssueDate", typeof(System.DateTime));
Application_LOIssueDateCol.DateTimeMode = DataSetDateTime.Local;
Application_LOIssueDateCol.ReadOnly = true;
Application_LOIssueDateCol.AllowDBNull = false;
Columns.Add(Application_LOIssueDateCol);
// column Application_FinalisedStatus
DataColumn Application_FinalisedStatusCol = new DataColumn("Application_FinalisedStatus", typeof(System.Int16));
Application_FinalisedStatusCol.ReadOnly = true;
Application_FinalisedStatusCol.AllowDBNull = false;
Columns.Add(Application_FinalisedStatusCol);
// column Application_MobilePhoneNumber
DataColumn Application_MobilePhoneNumberCol = new DataColumn("Application_MobilePhoneNumber", typeof(System.String));
Application_MobilePhoneNumberCol.ReadOnly = true;
Application_MobilePhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_MobilePhoneNumberCol);
// column Application_MobilePhonePrefix
DataColumn Application_MobilePhonePrefixCol = new DataColumn("Application_MobilePhonePrefix", typeof(System.String));
Application_MobilePhonePrefixCol.ReadOnly = true;
Application_MobilePhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_MobilePhonePrefixCol);
// column Application_PhoneNumber
DataColumn Application_PhoneNumberCol = new DataColumn("Application_PhoneNumber", typeof(System.String));
Application_PhoneNumberCol.ReadOnly = true;
Application_PhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_PhoneNumberCol);
// column Application_PhonePrefix
DataColumn Application_PhonePrefixCol = new DataColumn("Application_PhonePrefix", typeof(System.String));
Application_PhonePrefixCol.ReadOnly = true;
Application_PhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_PhonePrefixCol);
// column Application_ContractType
DataColumn Application_ContractTypeCol = new DataColumn("Application_ContractType", typeof(System.Int16));
Application_ContractTypeCol.ReadOnly = true;
Application_ContractTypeCol.AllowDBNull = false;
Columns.Add(Application_ContractTypeCol);
// column Application_MotherName
DataColumn Application_MotherNameCol = new DataColumn("Application_MotherName", typeof(System.String));
Application_MotherNameCol.ReadOnly = true;
Application_MotherNameCol.AllowDBNull = false;
Columns.Add(Application_MotherNameCol);
// column Application_FatherName
DataColumn Application_FatherNameCol = new DataColumn("Application_FatherName", typeof(System.String));
Application_FatherNameCol.ReadOnly = true;
Application_FatherNameCol.AllowDBNull = false;
Columns.Add(Application_FatherNameCol);
// column Application_SubmittedDate
DataColumn Application_SubmittedDateCol = new DataColumn("Application_SubmittedDate", typeof(System.DateTime));
Application_SubmittedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_SubmittedDateCol.ReadOnly = true;
Application_SubmittedDateCol.AllowDBNull = false;
Columns.Add(Application_SubmittedDateCol);
// column Application_UpdatedBy
DataColumn Application_UpdatedByCol = new DataColumn("Application_UpdatedBy", typeof(System.String));
Application_UpdatedByCol.ReadOnly = true;
Application_UpdatedByCol.AllowDBNull = false;
Columns.Add(Application_UpdatedByCol);
// column Application_CreatedBy
DataColumn Application_CreatedByCol = new DataColumn("Application_CreatedBy", typeof(System.String));
Application_CreatedByCol.ReadOnly = true;
Application_CreatedByCol.AllowDBNull = false;
Columns.Add(Application_CreatedByCol);
// column Application_UpdatedDate
DataColumn Application_UpdatedDateCol = new DataColumn("Application_UpdatedDate", typeof(System.DateTime));
Application_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_UpdatedDateCol.ReadOnly = true;
Application_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Application_UpdatedDateCol);
// column Application_CreatedDate
DataColumn Application_CreatedDateCol = new DataColumn("Application_CreatedDate", typeof(System.DateTime));
Application_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_CreatedDateCol.ReadOnly = true;
Application_CreatedDateCol.AllowDBNull = false;
Columns.Add(Application_CreatedDateCol);
// column Application_Status
DataColumn Application_StatusCol = new DataColumn("Application_Status", typeof(System.Int16));
Application_StatusCol.ReadOnly = true;
Application_StatusCol.AllowDBNull = false;
Columns.Add(Application_StatusCol);
// column Application_Deleted
DataColumn Application_DeletedCol = new DataColumn("Application_Deleted", typeof(System.Boolean));
Application_DeletedCol.ReadOnly = true;
Application_DeletedCol.AllowDBNull = false;
Columns.Add(Application_DeletedCol);
// column Application_Submitted
DataColumn Application_SubmittedCol = new DataColumn("Application_Submitted", typeof(System.Boolean));
Application_SubmittedCol.ReadOnly = true;
Application_SubmittedCol.AllowDBNull = false;
Columns.Add(Application_SubmittedCol);
// column Application_ConfirmAgreeTermsAndCondition
DataColumn Application_ConfirmAgreeTermsAndConditionCol = new DataColumn("Application_ConfirmAgreeTermsAndCondition", typeof(System.Boolean));
Application_ConfirmAgreeTermsAndConditionCol.ReadOnly = true;
Application_ConfirmAgreeTermsAndConditionCol.AllowDBNull = false;
Columns.Add(Application_ConfirmAgreeTermsAndConditionCol);
// column Application_ConfirmReceiveMyPACNotice
DataColumn Application_ConfirmReceiveMyPACNoticeCol = new DataColumn("Application_ConfirmReceiveMyPACNotice", typeof(System.Boolean));
Application_ConfirmReceiveMyPACNoticeCol.ReadOnly = true;
Application_ConfirmReceiveMyPACNoticeCol.AllowDBNull = false;
Columns.Add(Application_ConfirmReceiveMyPACNoticeCol);
// column Application_DeclarationAgree
DataColumn Application_DeclarationAgreeCol = new DataColumn("Application_DeclarationAgree", typeof(System.Boolean));
Application_DeclarationAgreeCol.ReadOnly = true;
Application_DeclarationAgreeCol.AllowDBNull = false;
Columns.Add(Application_DeclarationAgreeCol);
// column Application_PQAcceptanceImage
DataColumn Application_PQAcceptanceImageCol = new DataColumn("Application_PQAcceptanceImage", typeof(System.String));
Application_PQAcceptanceImageCol.ReadOnly = true;
Application_PQAcceptanceImageCol.AllowDBNull = false;
Columns.Add(Application_PQAcceptanceImageCol);
// column Application_PassportSizeImage
DataColumn Application_PassportSizeImageCol = new DataColumn("Application_PassportSizeImage", typeof(System.String));
Application_PassportSizeImageCol.ReadOnly = true;
Application_PassportSizeImageCol.AllowDBNull = false;
Columns.Add(Application_PassportSizeImageCol);
// column Application_AcademicTranscriptImage
DataColumn Application_AcademicTranscriptImageCol = new DataColumn("Application_AcademicTranscriptImage", typeof(System.String));
Application_AcademicTranscriptImageCol.ReadOnly = true;
Application_AcademicTranscriptImageCol.AllowDBNull = false;
Columns.Add(Application_AcademicTranscriptImageCol);
// column Application_BirthCertificateImage
DataColumn Application_BirthCertificateImageCol = new DataColumn("Application_BirthCertificateImage", typeof(System.String));
Application_BirthCertificateImageCol.ReadOnly = true;
Application_BirthCertificateImageCol.AllowDBNull = false;
Columns.Add(Application_BirthCertificateImageCol);
// column Application_IdentificationImage
DataColumn Application_IdentificationImageCol = new DataColumn("Application_IdentificationImage", typeof(System.String));
Application_IdentificationImageCol.ReadOnly = true;
Application_IdentificationImageCol.AllowDBNull = false;
Columns.Add(Application_IdentificationImageCol);
// column Application_ScholarshipCost
DataColumn Application_ScholarshipCostCol = new DataColumn("Application_ScholarshipCost", typeof(System.Decimal));
Application_ScholarshipCostCol.ReadOnly = true;
Application_ScholarshipCostCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipCostCol);
// column Application_ScholarshipProvider
DataColumn Application_ScholarshipProviderCol = new DataColumn("Application_ScholarshipProvider", typeof(System.String));
Application_ScholarshipProviderCol.ReadOnly = true;
Application_ScholarshipProviderCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipProviderCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = true;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Application_NextExamSession
DataColumn Application_NextExamSessionCol = new DataColumn("Application_NextExamSession", typeof(System.DateTime));
Application_NextExamSessionCol.DateTimeMode = DataSetDateTime.Local;
Application_NextExamSessionCol.ReadOnly = true;
Application_NextExamSessionCol.AllowDBNull = false;
Columns.Add(Application_NextExamSessionCol);
// column Application_RegisteredNextExam
DataColumn Application_RegisteredNextExamCol = new DataColumn("Application_RegisteredNextExam", typeof(System.Boolean));
Application_RegisteredNextExamCol.ReadOnly = true;
Application_RegisteredNextExamCol.AllowDBNull = false;
Columns.Add(Application_RegisteredNextExamCol);
// column Application_PQDeadline
DataColumn Application_PQDeadlineCol = new DataColumn("Application_PQDeadline", typeof(System.DateTime));
Application_PQDeadlineCol.DateTimeMode = DataSetDateTime.Local;
Application_PQDeadlineCol.ReadOnly = true;
Application_PQDeadlineCol.AllowDBNull = false;
Columns.Add(Application_PQDeadlineCol);
// column Application_PQLevelStart
DataColumn Application_PQLevelStartCol = new DataColumn("Application_PQLevelStart", typeof(System.String));
Application_PQLevelStartCol.ReadOnly = true;
Application_PQLevelStartCol.AllowDBNull = false;
Columns.Add(Application_PQLevelStartCol);
// column Application_PQStartDate
DataColumn Application_PQStartDateCol = new DataColumn("Application_PQStartDate", typeof(System.DateTime));
Application_PQStartDateCol.DateTimeMode = DataSetDateTime.Local;
Application_PQStartDateCol.ReadOnly = true;
Application_PQStartDateCol.AllowDBNull = false;
Columns.Add(Application_PQStartDateCol);
// column Application_PGRegistrationNumber
DataColumn Application_PGRegistrationNumberCol = new DataColumn("Application_PGRegistrationNumber", typeof(System.String));
Application_PGRegistrationNumberCol.ReadOnly = true;
Application_PGRegistrationNumberCol.AllowDBNull = false;
Columns.Add(Application_PGRegistrationNumberCol);
// column Application_PQQualification
DataColumn Application_PQQualificationCol = new DataColumn("Application_PQQualification", typeof(System.Boolean));
Application_PQQualificationCol.ReadOnly = true;
Application_PQQualificationCol.AllowDBNull = false;
Columns.Add(Application_PQQualificationCol);
// column Application_CGPA
DataColumn Application_CGPACol = new DataColumn("Application_CGPA", typeof(System.String));
Application_CGPACol.ReadOnly = true;
Application_CGPACol.AllowDBNull = false;
Columns.Add(Application_CGPACol);
// column Application_University
DataColumn Application_UniversityCol = new DataColumn("Application_University", typeof(System.String));
Application_UniversityCol.ReadOnly = true;
Application_UniversityCol.AllowDBNull = false;
Columns.Add(Application_UniversityCol);
// column Application_CurrentFieldOfStudy
DataColumn Application_CurrentFieldOfStudyCol = new DataColumn("Application_CurrentFieldOfStudy", typeof(System.String));
Application_CurrentFieldOfStudyCol.ReadOnly = true;
Application_CurrentFieldOfStudyCol.AllowDBNull = false;
Columns.Add(Application_CurrentFieldOfStudyCol);
// column Application_CombinedHouseholdIncome
DataColumn Application_CombinedHouseholdIncomeCol = new DataColumn("Application_CombinedHouseholdIncome", typeof(System.Decimal));
Application_CombinedHouseholdIncomeCol.ReadOnly = true;
Application_CombinedHouseholdIncomeCol.AllowDBNull = false;
Columns.Add(Application_CombinedHouseholdIncomeCol);
// column Application_MotherIdentification
DataColumn Application_MotherIdentificationCol = new DataColumn("Application_MotherIdentification", typeof(System.String));
Application_MotherIdentificationCol.ReadOnly = true;
Application_MotherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_MotherIdentificationCol);
// column Application_FatherIdentification
DataColumn Application_FatherIdentificationCol = new DataColumn("Application_FatherIdentification", typeof(System.String));
Application_FatherIdentificationCol.ReadOnly = true;
Application_FatherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_FatherIdentificationCol);
// column Application_Email
DataColumn Application_EmailCol = new DataColumn("Application_Email", typeof(System.String));
Application_EmailCol.ReadOnly = true;
Application_EmailCol.AllowDBNull = false;
Columns.Add(Application_EmailCol);
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = true;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Application_State
DataColumn Application_StateCol = new DataColumn("Application_State", typeof(System.String));
Application_StateCol.ReadOnly = true;
Application_StateCol.AllowDBNull = false;
Columns.Add(Application_StateCol);
// column Application_City
DataColumn Application_CityCol = new DataColumn("Application_City", typeof(System.String));
Application_CityCol.ReadOnly = true;
Application_CityCol.AllowDBNull = false;
Columns.Add(Application_CityCol);
// column Application_Postcode
DataColumn Application_PostcodeCol = new DataColumn("Application_Postcode", typeof(System.String));
Application_PostcodeCol.ReadOnly = true;
Application_PostcodeCol.AllowDBNull = false;
Columns.Add(Application_PostcodeCol);
// column Application_Address2
DataColumn Application_Address2Col = new DataColumn("Application_Address2", typeof(System.String));
Application_Address2Col.ReadOnly = true;
Application_Address2Col.AllowDBNull = false;
Columns.Add(Application_Address2Col);
// column Application_Address1
DataColumn Application_Address1Col = new DataColumn("Application_Address1", typeof(System.String));
Application_Address1Col.ReadOnly = true;
Application_Address1Col.AllowDBNull = false;
Columns.Add(Application_Address1Col);
// column Application_IdentificationNumber
DataColumn Application_IdentificationNumberCol = new DataColumn("Application_IdentificationNumber", typeof(System.String));
Application_IdentificationNumberCol.ReadOnly = true;
Application_IdentificationNumberCol.AllowDBNull = false;
Columns.Add(Application_IdentificationNumberCol);
// column Application_Nationality
DataColumn Application_NationalityCol = new DataColumn("Application_Nationality", typeof(System.Int16));
Application_NationalityCol.ReadOnly = true;
Application_NationalityCol.AllowDBNull = false;
Columns.Add(Application_NationalityCol);
// column Application_Gender
DataColumn Application_GenderCol = new DataColumn("Application_Gender", typeof(System.Int16));
Application_GenderCol.ReadOnly = true;
Application_GenderCol.AllowDBNull = false;
Columns.Add(Application_GenderCol);
// column Application_DOB
DataColumn Application_DOBCol = new DataColumn("Application_DOB", typeof(System.DateTime));
Application_DOBCol.DateTimeMode = DataSetDateTime.Local;
Application_DOBCol.ReadOnly = true;
Application_DOBCol.AllowDBNull = false;
Columns.Add(Application_DOBCol);
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = true;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Application_OverallStatus
DataColumn Application_OverallStatusCol = new DataColumn("Application_OverallStatus", typeof(System.Int16));
Application_OverallStatusCol.ReadOnly = true;
Application_OverallStatusCol.AllowDBNull = false;
Columns.Add(Application_OverallStatusCol);
// column Application_OverallProgress
DataColumn Application_OverallProgressCol = new DataColumn("Application_OverallProgress", typeof(System.Int16));
Application_OverallProgressCol.ReadOnly = true;
Application_OverallProgressCol.AllowDBNull = false;
Columns.Add(Application_OverallProgressCol);
// column Application_FullName
DataColumn Application_FullNameCol = new DataColumn("Application_FullName", typeof(System.String));
Application_FullNameCol.ReadOnly = true;
Application_FullNameCol.AllowDBNull = false;
Columns.Add(Application_FullNameCol);
// column Application_Date
DataColumn Application_DateCol = new DataColumn("Application_Date", typeof(System.DateTime));
Application_DateCol.DateTimeMode = DataSetDateTime.Local;
Application_DateCol.ReadOnly = true;
Application_DateCol.AllowDBNull = false;
Columns.Add(Application_DateCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Application_CountryName
DataColumn Application_CountryNameCol = new DataColumn("Application_CountryName", typeof(System.String));
Application_CountryNameCol.ReadOnly = true;
Application_CountryNameCol.AllowDBNull = true;
Columns.Add(Application_CountryNameCol);
// column Application_IntakeMonth
DataColumn Application_IntakeMonthCol = new DataColumn("Application_IntakeMonth", typeof(System.Int32));
Application_IntakeMonthCol.ReadOnly = true;
Application_IntakeMonthCol.AllowDBNull = false;
Columns.Add(Application_IntakeMonthCol);
// column Application_IntakeYear
DataColumn Application_IntakeYearCol = new DataColumn("Application_IntakeYear", typeof(System.Int32));
Application_IntakeYearCol.ReadOnly = true;
Application_IntakeYearCol.AllowDBNull = false;
Columns.Add(Application_IntakeYearCol);
// column Sponsor_ID
DataColumn Sponsor_IDCol = new DataColumn("Sponsor_ID", typeof(System.Guid));
Sponsor_IDCol.ReadOnly = true;
Sponsor_IDCol.AllowDBNull = false;
Columns.Add(Sponsor_IDCol);
// column Sponsor_Code
DataColumn Sponsor_CodeCol = new DataColumn("Sponsor_Code", typeof(System.String));
Sponsor_CodeCol.ReadOnly = true;
Sponsor_CodeCol.AllowDBNull = false;
Columns.Add(Sponsor_CodeCol);
// column Sponsor_Label
DataColumn Sponsor_LabelCol = new DataColumn("Sponsor_Label", typeof(System.String));
Sponsor_LabelCol.ReadOnly = true;
Sponsor_LabelCol.AllowDBNull = false;
Columns.Add(Sponsor_LabelCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new WorkHistoryDetailRow(builder);
}
public WorkHistoryDetailRow GetWorkHistoryDetailRow(int index) {
return (WorkHistoryDetailRow)Rows[index];
}
}
public partial class WorkHistoryDetailRow : DataRow {
internal WorkHistoryDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid WorkHistory_ID {
get {
return (System.Guid)this["WorkHistory_ID"];
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
}
public System.String WorkHistory_CompanyName {
get {
return (System.String)this["WorkHistory_CompanyName"];
}
}
public System.String WorkHistory_JobTitle {
get {
return (System.String)this["WorkHistory_JobTitle"];
}
}
public System.DateTime WorkHistory_StartDate {
get {
return (System.DateTime)this["WorkHistory_StartDate"];
}
}
public System.DateTime WorkHistory_ResignDate {
get {
return (System.DateTime)this["WorkHistory_ResignDate"];
}
}
public System.String WorkHistory_Description {
get {
return (System.String)this["WorkHistory_Description"];
}
}
public System.String WorkHistory_CreatedBy {
get {
return (System.String)this["WorkHistory_CreatedBy"];
}
}
public System.DateTime WorkHistory_CreatedDate {
get {
return (System.DateTime)this["WorkHistory_CreatedDate"];
}
}
public System.String WorkHistory_UpdatedBy {
get {
return (System.String)this["WorkHistory_UpdatedBy"];
}
}
public System.DateTime WorkHistory_UpdatedDate {
get {
return (System.DateTime)this["WorkHistory_UpdatedDate"];
}
}
public System.Boolean WorkHistory_IsDeleted {
get {
return (System.Boolean)this["WorkHistory_IsDeleted"];
}
}
public System.DateTime Application_FinalisedDate {
get {
return (System.DateTime)this["Application_FinalisedDate"];
}
}
public System.DateTime Application_LOIssueDate {
get {
return (System.DateTime)this["Application_LOIssueDate"];
}
}
public System.Int16 Application_FinalisedStatus {
get {
return (System.Int16)this["Application_FinalisedStatus"];
}
}
public System.String Application_MobilePhoneNumber {
get {
return (System.String)this["Application_MobilePhoneNumber"];
}
}
public System.String Application_MobilePhonePrefix {
get {
return (System.String)this["Application_MobilePhonePrefix"];
}
}
public System.String Application_PhoneNumber {
get {
return (System.String)this["Application_PhoneNumber"];
}
}
public System.String Application_PhonePrefix {
get {
return (System.String)this["Application_PhonePrefix"];
}
}
public System.Int16 Application_ContractType {
get {
return (System.Int16)this["Application_ContractType"];
}
}
public System.String Application_MotherName {
get {
return (System.String)this["Application_MotherName"];
}
}
public System.String Application_FatherName {
get {
return (System.String)this["Application_FatherName"];
}
}
public System.DateTime Application_SubmittedDate {
get {
return (System.DateTime)this["Application_SubmittedDate"];
}
}
public System.String Application_UpdatedBy {
get {
return (System.String)this["Application_UpdatedBy"];
}
}
public System.String Application_CreatedBy {
get {
return (System.String)this["Application_CreatedBy"];
}
}
public System.DateTime Application_UpdatedDate {
get {
return (System.DateTime)this["Application_UpdatedDate"];
}
}
public System.DateTime Application_CreatedDate {
get {
return (System.DateTime)this["Application_CreatedDate"];
}
}
public System.Int16 Application_Status {
get {
return (System.Int16)this["Application_Status"];
}
}
public System.Boolean Application_Deleted {
get {
return (System.Boolean)this["Application_Deleted"];
}
}
public System.Boolean Application_Submitted {
get {
return (System.Boolean)this["Application_Submitted"];
}
}
public System.Boolean Application_ConfirmAgreeTermsAndCondition {
get {
return (System.Boolean)this["Application_ConfirmAgreeTermsAndCondition"];
}
}
public System.Boolean Application_ConfirmReceiveMyPACNotice {
get {
return (System.Boolean)this["Application_ConfirmReceiveMyPACNotice"];
}
}
public System.Boolean Application_DeclarationAgree {
get {
return (System.Boolean)this["Application_DeclarationAgree"];
}
}
public System.String Application_PQAcceptanceImage {
get {
return (System.String)this["Application_PQAcceptanceImage"];
}
}
public System.String Application_PassportSizeImage {
get {
return (System.String)this["Application_PassportSizeImage"];
}
}
public System.String Application_AcademicTranscriptImage {
get {
return (System.String)this["Application_AcademicTranscriptImage"];
}
}
public System.String Application_BirthCertificateImage {
get {
return (System.String)this["Application_BirthCertificateImage"];
}
}
public System.String Application_IdentificationImage {
get {
return (System.String)this["Application_IdentificationImage"];
}
}
public System.Decimal Application_ScholarshipCost {
get {
return (System.Decimal)this["Application_ScholarshipCost"];
}
}
public System.String Application_ScholarshipProvider {
get {
return (System.String)this["Application_ScholarshipProvider"];
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
}
public System.DateTime Application_NextExamSession {
get {
return (System.DateTime)this["Application_NextExamSession"];
}
}
public System.Boolean Application_RegisteredNextExam {
get {
return (System.Boolean)this["Application_RegisteredNextExam"];
}
}
public System.DateTime Application_PQDeadline {
get {
return (System.DateTime)this["Application_PQDeadline"];
}
}
public System.String Application_PQLevelStart {
get {
return (System.String)this["Application_PQLevelStart"];
}
}
public System.DateTime Application_PQStartDate {
get {
return (System.DateTime)this["Application_PQStartDate"];
}
}
public System.String Application_PGRegistrationNumber {
get {
return (System.String)this["Application_PGRegistrationNumber"];
}
}
public System.Boolean Application_PQQualification {
get {
return (System.Boolean)this["Application_PQQualification"];
}
}
public System.String Application_CGPA {
get {
return (System.String)this["Application_CGPA"];
}
}
public System.String Application_University {
get {
return (System.String)this["Application_University"];
}
}
public System.String Application_CurrentFieldOfStudy {
get {
return (System.String)this["Application_CurrentFieldOfStudy"];
}
}
public System.Decimal Application_CombinedHouseholdIncome {
get {
return (System.Decimal)this["Application_CombinedHouseholdIncome"];
}
}
public System.String Application_MotherIdentification {
get {
return (System.String)this["Application_MotherIdentification"];
}
}
public System.String Application_FatherIdentification {
get {
return (System.String)this["Application_FatherIdentification"];
}
}
public System.String Application_Email {
get {
return (System.String)this["Application_Email"];
}
}
public System.Guid Country_ID {
get {
return (System.Guid)this["Country_ID"];
}
}
public System.String Application_State {
get {
return (System.String)this["Application_State"];
}
}
public System.String Application_City {
get {
return (System.String)this["Application_City"];
}
}
public System.String Application_Postcode {
get {
return (System.String)this["Application_Postcode"];
}
}
public System.String Application_Address2 {
get {
return (System.String)this["Application_Address2"];
}
}
public System.String Application_Address1 {
get {
return (System.String)this["Application_Address1"];
}
}
public System.String Application_IdentificationNumber {
get {
return (System.String)this["Application_IdentificationNumber"];
}
}
public System.Int16 Application_Nationality {
get {
return (System.Int16)this["Application_Nationality"];
}
}
public System.Int16 Application_Gender {
get {
return (System.Int16)this["Application_Gender"];
}
}
public System.DateTime Application_DOB {
get {
return (System.DateTime)this["Application_DOB"];
}
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
}
public System.Int16 Application_OverallStatus {
get {
return (System.Int16)this["Application_OverallStatus"];
}
}
public System.Int16 Application_OverallProgress {
get {
return (System.Int16)this["Application_OverallProgress"];
}
}
public System.String Application_FullName {
get {
return (System.String)this["Application_FullName"];
}
}
public System.DateTime Application_Date {
get {
return (System.DateTime)this["Application_Date"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
public System.String Application_CountryName {
get {
if( IsNull("Application_CountryName") ) return "";
else return (System.String)this["Application_CountryName"];
}
}
public System.Int32 Application_IntakeMonth {
get {
return (System.Int32)this["Application_IntakeMonth"];
}
}
public System.Int32 Application_IntakeYear {
get {
return (System.Int32)this["Application_IntakeYear"];
}
}
public System.Guid Sponsor_ID {
get {
return (System.Guid)this["Sponsor_ID"];
}
}
public System.String Sponsor_Code {
get {
return (System.String)this["Sponsor_Code"];
}
}
public System.String Sponsor_Label {
get {
return (System.String)this["Sponsor_Label"];
}
}
}
public partial class WorkHistoryDetailMinimalizedEntity {
public WorkHistoryDetailMinimalizedEntity() {}
public WorkHistoryDetailMinimalizedEntity(WorkHistoryDetailRow dr) {
this.WorkHistory_ID = dr.WorkHistory_ID;
this.Application_ID = dr.Application_ID;
this.WorkHistory_CompanyName = dr.WorkHistory_CompanyName;
this.WorkHistory_JobTitle = dr.WorkHistory_JobTitle;
this.WorkHistory_StartDate = dr.WorkHistory_StartDate;
this.WorkHistory_ResignDate = dr.WorkHistory_ResignDate;
this.WorkHistory_Description = dr.WorkHistory_Description;
this.WorkHistory_CreatedBy = dr.WorkHistory_CreatedBy;
this.WorkHistory_CreatedDate = dr.WorkHistory_CreatedDate;
this.WorkHistory_UpdatedBy = dr.WorkHistory_UpdatedBy;
this.WorkHistory_UpdatedDate = dr.WorkHistory_UpdatedDate;
this.WorkHistory_IsDeleted = dr.WorkHistory_IsDeleted;
this.Application_FinalisedDate = dr.Application_FinalisedDate;
this.Application_LOIssueDate = dr.Application_LOIssueDate;
this.Application_FinalisedStatus = dr.Application_FinalisedStatus;
this.Application_MobilePhoneNumber = dr.Application_MobilePhoneNumber;
this.Application_MobilePhonePrefix = dr.Application_MobilePhonePrefix;
this.Application_PhoneNumber = dr.Application_PhoneNumber;
this.Application_PhonePrefix = dr.Application_PhonePrefix;
this.Application_ContractType = dr.Application_ContractType;
this.Application_MotherName = dr.Application_MotherName;
this.Application_FatherName = dr.Application_FatherName;
this.Application_SubmittedDate = dr.Application_SubmittedDate;
this.Application_UpdatedBy = dr.Application_UpdatedBy;
this.Application_CreatedBy = dr.Application_CreatedBy;
this.Application_UpdatedDate = dr.Application_UpdatedDate;
this.Application_CreatedDate = dr.Application_CreatedDate;
this.Application_Status = dr.Application_Status;
this.Application_Deleted = dr.Application_Deleted;
this.Application_Submitted = dr.Application_Submitted;
this.Application_ConfirmAgreeTermsAndCondition = dr.Application_ConfirmAgreeTermsAndCondition;
this.Application_ConfirmReceiveMyPACNotice = dr.Application_ConfirmReceiveMyPACNotice;
this.Application_DeclarationAgree = dr.Application_DeclarationAgree;
this.Application_PQAcceptanceImage = dr.Application_PQAcceptanceImage;
this.Application_PassportSizeImage = dr.Application_PassportSizeImage;
this.Application_AcademicTranscriptImage = dr.Application_AcademicTranscriptImage;
this.Application_BirthCertificateImage = dr.Application_BirthCertificateImage;
this.Application_IdentificationImage = dr.Application_IdentificationImage;
this.Application_ScholarshipCost = dr.Application_ScholarshipCost;
this.Application_ScholarshipProvider = dr.Application_ScholarshipProvider;
this.TSP_ID = dr.TSP_ID;
this.Application_NextExamSession = dr.Application_NextExamSession;
this.Application_RegisteredNextExam = dr.Application_RegisteredNextExam;
this.Application_PQDeadline = dr.Application_PQDeadline;
this.Application_PQLevelStart = dr.Application_PQLevelStart;
this.Application_PQStartDate = dr.Application_PQStartDate;
this.Application_PGRegistrationNumber = dr.Application_PGRegistrationNumber;
this.Application_PQQualification = dr.Application_PQQualification;
this.Application_CGPA = dr.Application_CGPA;
this.Application_University = dr.Application_University;
this.Application_CurrentFieldOfStudy = dr.Application_CurrentFieldOfStudy;
this.Application_CombinedHouseholdIncome = dr.Application_CombinedHouseholdIncome;
this.Application_MotherIdentification = dr.Application_MotherIdentification;
this.Application_FatherIdentification = dr.Application_FatherIdentification;
this.Application_Email = dr.Application_Email;
this.Country_ID = dr.Country_ID;
this.Application_State = dr.Application_State;
this.Application_City = dr.Application_City;
this.Application_Postcode = dr.Application_Postcode;
this.Application_Address2 = dr.Application_Address2;
this.Application_Address1 = dr.Application_Address1;
this.Application_IdentificationNumber = dr.Application_IdentificationNumber;
this.Application_Nationality = dr.Application_Nationality;
this.Application_Gender = dr.Application_Gender;
this.Application_DOB = dr.Application_DOB;
this.Candidate_ID = dr.Candidate_ID;
this.Application_OverallStatus = dr.Application_OverallStatus;
this.Application_OverallProgress = dr.Application_OverallProgress;
this.Application_FullName = dr.Application_FullName;
this.Application_Date = dr.Application_Date;
this.Course_ID = dr.Course_ID;
this.Application_CountryName = dr.Application_CountryName;
this.Application_IntakeMonth = dr.Application_IntakeMonth;
this.Application_IntakeYear = dr.Application_IntakeYear;
this.Sponsor_ID = dr.Sponsor_ID;
this.Sponsor_Code = dr.Sponsor_Code;
this.Sponsor_Label = dr.Sponsor_Label;
}
public System.Guid WorkHistory_ID;
public System.Guid Application_ID;
public System.String WorkHistory_CompanyName;
public System.String WorkHistory_JobTitle;
public System.DateTime WorkHistory_StartDate;
public System.DateTime WorkHistory_ResignDate;
public System.String WorkHistory_Description;
public System.String WorkHistory_CreatedBy;
public System.DateTime WorkHistory_CreatedDate;
public System.String WorkHistory_UpdatedBy;
public System.DateTime WorkHistory_UpdatedDate;
public System.Boolean WorkHistory_IsDeleted;
public System.DateTime Application_FinalisedDate;
public System.DateTime Application_LOIssueDate;
public System.Int16 Application_FinalisedStatus;
public System.String Application_MobilePhoneNumber;
public System.String Application_MobilePhonePrefix;
public System.String Application_PhoneNumber;
public System.String Application_PhonePrefix;
public System.Int16 Application_ContractType;
public System.String Application_MotherName;
public System.String Application_FatherName;
public System.DateTime Application_SubmittedDate;
public System.String Application_UpdatedBy;
public System.String Application_CreatedBy;
public System.DateTime Application_UpdatedDate;
public System.DateTime Application_CreatedDate;
public System.Int16 Application_Status;
public System.Boolean Application_Deleted;
public System.Boolean Application_Submitted;
public System.Boolean Application_ConfirmAgreeTermsAndCondition;
public System.Boolean Application_ConfirmReceiveMyPACNotice;
public System.Boolean Application_DeclarationAgree;
public System.String Application_PQAcceptanceImage;
public System.String Application_PassportSizeImage;
public System.String Application_AcademicTranscriptImage;
public System.String Application_BirthCertificateImage;
public System.String Application_IdentificationImage;
public System.Decimal Application_ScholarshipCost;
public System.String Application_ScholarshipProvider;
public System.Guid TSP_ID;
public System.DateTime Application_NextExamSession;
public System.Boolean Application_RegisteredNextExam;
public System.DateTime Application_PQDeadline;
public System.String Application_PQLevelStart;
public System.DateTime Application_PQStartDate;
public System.String Application_PGRegistrationNumber;
public System.Boolean Application_PQQualification;
public System.String Application_CGPA;
public System.String Application_University;
public System.String Application_CurrentFieldOfStudy;
public System.Decimal Application_CombinedHouseholdIncome;
public System.String Application_MotherIdentification;
public System.String Application_FatherIdentification;
public System.String Application_Email;
public System.Guid Country_ID;
public System.String Application_State;
public System.String Application_City;
public System.String Application_Postcode;
public System.String Application_Address2;
public System.String Application_Address1;
public System.String Application_IdentificationNumber;
public System.Int16 Application_Nationality;
public System.Int16 Application_Gender;
public System.DateTime Application_DOB;
public System.Guid Candidate_ID;
public System.Int16 Application_OverallStatus;
public System.Int16 Application_OverallProgress;
public System.String Application_FullName;
public System.DateTime Application_Date;
public System.Guid Course_ID;
public System.String Application_CountryName;
public System.Int32 Application_IntakeMonth;
public System.Int32 Application_IntakeYear;
public System.Guid Sponsor_ID;
public System.String Sponsor_Code;
public System.String Sponsor_Label;
}
public partial class WorkHistoryDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public WorkHistoryDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("WorkHistory_ID", "WorkHistory_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("WorkHistory_CompanyName", "WorkHistory_CompanyName");
tmap.ColumnMappings.Add("WorkHistory_JobTitle", "WorkHistory_JobTitle");
tmap.ColumnMappings.Add("WorkHistory_StartDate", "WorkHistory_StartDate");
tmap.ColumnMappings.Add("WorkHistory_ResignDate", "WorkHistory_ResignDate");
tmap.ColumnMappings.Add("WorkHistory_Description", "WorkHistory_Description");
tmap.ColumnMappings.Add("WorkHistory_CreatedBy", "WorkHistory_CreatedBy");
tmap.ColumnMappings.Add("WorkHistory_CreatedDate", "WorkHistory_CreatedDate");
tmap.ColumnMappings.Add("WorkHistory_UpdatedBy", "WorkHistory_UpdatedBy");
tmap.ColumnMappings.Add("WorkHistory_UpdatedDate", "WorkHistory_UpdatedDate");
tmap.ColumnMappings.Add("WorkHistory_IsDeleted", "WorkHistory_IsDeleted");
tmap.ColumnMappings.Add("Application_FinalisedDate", "Application_FinalisedDate");
tmap.ColumnMappings.Add("Application_LOIssueDate", "Application_LOIssueDate");
tmap.ColumnMappings.Add("Application_FinalisedStatus", "Application_FinalisedStatus");
tmap.ColumnMappings.Add("Application_MobilePhoneNumber", "Application_MobilePhoneNumber");
tmap.ColumnMappings.Add("Application_MobilePhonePrefix", "Application_MobilePhonePrefix");
tmap.ColumnMappings.Add("Application_PhoneNumber", "Application_PhoneNumber");
tmap.ColumnMappings.Add("Application_PhonePrefix", "Application_PhonePrefix");
tmap.ColumnMappings.Add("Application_ContractType", "Application_ContractType");
tmap.ColumnMappings.Add("Application_MotherName", "Application_MotherName");
tmap.ColumnMappings.Add("Application_FatherName", "Application_FatherName");
tmap.ColumnMappings.Add("Application_SubmittedDate", "Application_SubmittedDate");
tmap.ColumnMappings.Add("Application_UpdatedBy", "Application_UpdatedBy");
tmap.ColumnMappings.Add("Application_CreatedBy", "Application_CreatedBy");
tmap.ColumnMappings.Add("Application_UpdatedDate", "Application_UpdatedDate");
tmap.ColumnMappings.Add("Application_CreatedDate", "Application_CreatedDate");
tmap.ColumnMappings.Add("Application_Status", "Application_Status");
tmap.ColumnMappings.Add("Application_Deleted", "Application_Deleted");
tmap.ColumnMappings.Add("Application_Submitted", "Application_Submitted");
tmap.ColumnMappings.Add("Application_ConfirmAgreeTermsAndCondition", "Application_ConfirmAgreeTermsAndCondition");
tmap.ColumnMappings.Add("Application_ConfirmReceiveMyPACNotice", "Application_ConfirmReceiveMyPACNotice");
tmap.ColumnMappings.Add("Application_DeclarationAgree", "Application_DeclarationAgree");
tmap.ColumnMappings.Add("Application_PQAcceptanceImage", "Application_PQAcceptanceImage");
tmap.ColumnMappings.Add("Application_PassportSizeImage", "Application_PassportSizeImage");
tmap.ColumnMappings.Add("Application_AcademicTranscriptImage", "Application_AcademicTranscriptImage");
tmap.ColumnMappings.Add("Application_BirthCertificateImage", "Application_BirthCertificateImage");
tmap.ColumnMappings.Add("Application_IdentificationImage", "Application_IdentificationImage");
tmap.ColumnMappings.Add("Application_ScholarshipCost", "Application_ScholarshipCost");
tmap.ColumnMappings.Add("Application_ScholarshipProvider", "Application_ScholarshipProvider");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("Application_NextExamSession", "Application_NextExamSession");
tmap.ColumnMappings.Add("Application_RegisteredNextExam", "Application_RegisteredNextExam");
tmap.ColumnMappings.Add("Application_PQDeadline", "Application_PQDeadline");
tmap.ColumnMappings.Add("Application_PQLevelStart", "Application_PQLevelStart");
tmap.ColumnMappings.Add("Application_PQStartDate", "Application_PQStartDate");
tmap.ColumnMappings.Add("Application_PGRegistrationNumber", "Application_PGRegistrationNumber");
tmap.ColumnMappings.Add("Application_PQQualification", "Application_PQQualification");
tmap.ColumnMappings.Add("Application_CGPA", "Application_CGPA");
tmap.ColumnMappings.Add("Application_University", "Application_University");
tmap.ColumnMappings.Add("Application_CurrentFieldOfStudy", "Application_CurrentFieldOfStudy");
tmap.ColumnMappings.Add("Application_CombinedHouseholdIncome", "Application_CombinedHouseholdIncome");
tmap.ColumnMappings.Add("Application_MotherIdentification", "Application_MotherIdentification");
tmap.ColumnMappings.Add("Application_FatherIdentification", "Application_FatherIdentification");
tmap.ColumnMappings.Add("Application_Email", "Application_Email");
tmap.ColumnMappings.Add("Country_ID", "Country_ID");
tmap.ColumnMappings.Add("Application_State", "Application_State");
tmap.ColumnMappings.Add("Application_City", "Application_City");
tmap.ColumnMappings.Add("Application_Postcode", "Application_Postcode");
tmap.ColumnMappings.Add("Application_Address2", "Application_Address2");
tmap.ColumnMappings.Add("Application_Address1", "Application_Address1");
tmap.ColumnMappings.Add("Application_IdentificationNumber", "Application_IdentificationNumber");
tmap.ColumnMappings.Add("Application_Nationality", "Application_Nationality");
tmap.ColumnMappings.Add("Application_Gender", "Application_Gender");
tmap.ColumnMappings.Add("Application_DOB", "Application_DOB");
tmap.ColumnMappings.Add("Candidate_ID", "Candidate_ID");
tmap.ColumnMappings.Add("Application_OverallStatus", "Application_OverallStatus");
tmap.ColumnMappings.Add("Application_OverallProgress", "Application_OverallProgress");
tmap.ColumnMappings.Add("Application_FullName", "Application_FullName");
tmap.ColumnMappings.Add("Application_Date", "Application_Date");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("Application_CountryName", "Application_CountryName");
tmap.ColumnMappings.Add("Application_IntakeMonth", "Application_IntakeMonth");
tmap.ColumnMappings.Add("Application_IntakeYear", "Application_IntakeYear");
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
tmap.ColumnMappings.Add("Sponsor_Code", "Sponsor_Code");
tmap.ColumnMappings.Add("Sponsor_Label", "Sponsor_Label");
adapter.TableMappings.Add(tmap);
}
}
public WorkHistoryDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [WorkHistoryDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

WorkHistoryDetailTable tbl = new WorkHistoryDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetWorkHistoryDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [WorkHistoryDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
