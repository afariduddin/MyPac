using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class ApplicationTable : DataTable {
// column indexes
public const int Application_IDColumnIndex = 0;
public const int Course_IDColumnIndex = 1;
public const int Application_DateColumnIndex = 2;
public const int Application_FullNameColumnIndex = 3;
public const int Candidate_IDColumnIndex = 4;
public const int Application_DOBColumnIndex = 5;
public const int Application_GenderColumnIndex = 6;
public const int Application_NationalityColumnIndex = 7;
public const int Application_IdentificationNumberColumnIndex = 8;
public const int Application_Address1ColumnIndex = 9;
public const int Application_Address2ColumnIndex = 10;
public const int Application_PostcodeColumnIndex = 11;
public const int Application_CityColumnIndex = 12;
public const int Application_StateColumnIndex = 13;
public const int Application_EmailColumnIndex = 14;
public const int Application_FatherIdentificationColumnIndex = 15;
public const int Application_MotherIdentificationColumnIndex = 16;
public const int Application_CombinedHouseholdIncomeColumnIndex = 17;
public const int Application_CurrentFieldOfStudyColumnIndex = 18;
public const int Application_UniversityColumnIndex = 19;
public const int Application_CGPAColumnIndex = 20;
public const int Application_PQQualificationColumnIndex = 21;
public const int Application_PGRegistrationNumberColumnIndex = 22;
public const int Application_PQStartDateColumnIndex = 23;
public const int Application_PQDeadlineColumnIndex = 24;
public const int Application_RegisteredNextExamColumnIndex = 25;
public const int Application_NextExamSessionColumnIndex = 26;
public const int TSP_IDColumnIndex = 27;
public const int Application_ScholarshipProviderColumnIndex = 28;
public const int Application_ScholarshipCostColumnIndex = 29;
public const int Application_IdentificationImageColumnIndex = 30;
public const int Application_BirthCertificateImageColumnIndex = 31;
public const int Application_AcademicTranscriptImageColumnIndex = 32;
public const int Application_PassportSizeImageColumnIndex = 33;
public const int Application_PQAcceptanceImageColumnIndex = 34;
public const int Application_DeclarationAgreeColumnIndex = 35;
public const int Application_ConfirmReceiveMyPACNoticeColumnIndex = 36;
public const int Application_ConfirmAgreeTermsAndConditionColumnIndex = 37;
public const int Application_SubmittedColumnIndex = 38;
public const int Application_DeletedColumnIndex = 39;
public const int Application_StatusColumnIndex = 40;
public const int Application_CreatedDateColumnIndex = 41;
public const int Application_UpdatedDateColumnIndex = 42;
public const int Application_CreatedByColumnIndex = 43;
public const int Application_UpdatedByColumnIndex = 44;
public const int Application_SubmittedDateColumnIndex = 45;
public const int Application_FatherNameColumnIndex = 46;
public const int Application_MotherNameColumnIndex = 47;
public const int Application_ContractTypeColumnIndex = 48;
public const int Application_PhonePrefixColumnIndex = 49;
public const int Application_PhoneNumberColumnIndex = 50;
public const int Application_MobilePhonePrefixColumnIndex = 51;
public const int Application_MobilePhoneNumberColumnIndex = 52;
public const int Application_FinalisedStatusColumnIndex = 53;
public const int Application_LOIssueDateColumnIndex = 54;
public const int Application_FinalisedDateColumnIndex = 55;
public const int Application_OverallStatusColumnIndex = 56;
public const int Application_OverallProgressColumnIndex = 57;
public const int Application_IntakeMonthColumnIndex = 58;
public const int Application_IntakeYearColumnIndex = 59;
public const int Country_IDColumnIndex = 60;
public const int Application_PQLevelStartColumnIndex = 61;
public const int Application_IdentificationFileColumnIndex = 62;
public const int Application_BirthCertificateFileColumnIndex = 63;
public const int Application_AcademicTranscriptFileColumnIndex = 64;
public const int Application_PassportSizeFileColumnIndex = 65;
public const int Application_PQAcceptanceFileColumnIndex = 66;
public const int Application_CurrentlyEmployedColumnIndex = 67;
public const int Application_CompanyNameColumnIndex = 68;
public const int Application_CompanyContactColumnIndex = 69;
public const int Application_CompanyAddressColumnIndex = 70;
public const int Application_CompanyPositionColumnIndex = 71;
public const int Application_CompanySectorColumnIndex = 72;
public const int Application_CompanyDepartmentColumnIndex = 73;
public const int Application_IsAssessmentSessionAcceptedColumnIndex = 74;
public const int Sponsor_IDColumnIndex = 75;
public ApplicationTable() {
TableName = "[Application]";
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = false;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = false;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Application_Date
DataColumn Application_DateCol = new DataColumn("Application_Date", typeof(System.DateTime));
Application_DateCol.DateTimeMode = DataSetDateTime.Local;
Application_DateCol.ReadOnly = false;
Application_DateCol.AllowDBNull = false;
Columns.Add(Application_DateCol);
// column Application_FullName
DataColumn Application_FullNameCol = new DataColumn("Application_FullName", typeof(System.String));
Application_FullNameCol.ReadOnly = false;
Application_FullNameCol.AllowDBNull = false;
Columns.Add(Application_FullNameCol);
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = false;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Application_DOB
DataColumn Application_DOBCol = new DataColumn("Application_DOB", typeof(System.DateTime));
Application_DOBCol.DateTimeMode = DataSetDateTime.Local;
Application_DOBCol.ReadOnly = false;
Application_DOBCol.AllowDBNull = false;
Columns.Add(Application_DOBCol);
// column Application_Gender
DataColumn Application_GenderCol = new DataColumn("Application_Gender", typeof(System.Int16));
Application_GenderCol.ReadOnly = false;
Application_GenderCol.AllowDBNull = false;
Columns.Add(Application_GenderCol);
// column Application_Nationality
DataColumn Application_NationalityCol = new DataColumn("Application_Nationality", typeof(System.Int16));
Application_NationalityCol.ReadOnly = false;
Application_NationalityCol.AllowDBNull = false;
Columns.Add(Application_NationalityCol);
// column Application_IdentificationNumber
DataColumn Application_IdentificationNumberCol = new DataColumn("Application_IdentificationNumber", typeof(System.String));
Application_IdentificationNumberCol.ReadOnly = false;
Application_IdentificationNumberCol.AllowDBNull = false;
Columns.Add(Application_IdentificationNumberCol);
// column Application_Address1
DataColumn Application_Address1Col = new DataColumn("Application_Address1", typeof(System.String));
Application_Address1Col.ReadOnly = false;
Application_Address1Col.AllowDBNull = false;
Columns.Add(Application_Address1Col);
// column Application_Address2
DataColumn Application_Address2Col = new DataColumn("Application_Address2", typeof(System.String));
Application_Address2Col.ReadOnly = false;
Application_Address2Col.AllowDBNull = false;
Columns.Add(Application_Address2Col);
// column Application_Postcode
DataColumn Application_PostcodeCol = new DataColumn("Application_Postcode", typeof(System.String));
Application_PostcodeCol.ReadOnly = false;
Application_PostcodeCol.AllowDBNull = false;
Columns.Add(Application_PostcodeCol);
// column Application_City
DataColumn Application_CityCol = new DataColumn("Application_City", typeof(System.String));
Application_CityCol.ReadOnly = false;
Application_CityCol.AllowDBNull = false;
Columns.Add(Application_CityCol);
// column Application_State
DataColumn Application_StateCol = new DataColumn("Application_State", typeof(System.String));
Application_StateCol.ReadOnly = false;
Application_StateCol.AllowDBNull = false;
Columns.Add(Application_StateCol);
// column Application_Email
DataColumn Application_EmailCol = new DataColumn("Application_Email", typeof(System.String));
Application_EmailCol.ReadOnly = false;
Application_EmailCol.AllowDBNull = false;
Columns.Add(Application_EmailCol);
// column Application_FatherIdentification
DataColumn Application_FatherIdentificationCol = new DataColumn("Application_FatherIdentification", typeof(System.String));
Application_FatherIdentificationCol.ReadOnly = false;
Application_FatherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_FatherIdentificationCol);
// column Application_MotherIdentification
DataColumn Application_MotherIdentificationCol = new DataColumn("Application_MotherIdentification", typeof(System.String));
Application_MotherIdentificationCol.ReadOnly = false;
Application_MotherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_MotherIdentificationCol);
// column Application_CombinedHouseholdIncome
DataColumn Application_CombinedHouseholdIncomeCol = new DataColumn("Application_CombinedHouseholdIncome", typeof(System.Decimal));
Application_CombinedHouseholdIncomeCol.ReadOnly = false;
Application_CombinedHouseholdIncomeCol.AllowDBNull = false;
Columns.Add(Application_CombinedHouseholdIncomeCol);
// column Application_CurrentFieldOfStudy
DataColumn Application_CurrentFieldOfStudyCol = new DataColumn("Application_CurrentFieldOfStudy", typeof(System.String));
Application_CurrentFieldOfStudyCol.ReadOnly = false;
Application_CurrentFieldOfStudyCol.AllowDBNull = false;
Columns.Add(Application_CurrentFieldOfStudyCol);
// column Application_University
DataColumn Application_UniversityCol = new DataColumn("Application_University", typeof(System.String));
Application_UniversityCol.ReadOnly = false;
Application_UniversityCol.AllowDBNull = false;
Columns.Add(Application_UniversityCol);
// column Application_CGPA
DataColumn Application_CGPACol = new DataColumn("Application_CGPA", typeof(System.String));
Application_CGPACol.ReadOnly = false;
Application_CGPACol.AllowDBNull = false;
Columns.Add(Application_CGPACol);
// column Application_PQQualification
DataColumn Application_PQQualificationCol = new DataColumn("Application_PQQualification", typeof(System.Boolean));
Application_PQQualificationCol.ReadOnly = false;
Application_PQQualificationCol.AllowDBNull = false;
Columns.Add(Application_PQQualificationCol);
// column Application_PGRegistrationNumber
DataColumn Application_PGRegistrationNumberCol = new DataColumn("Application_PGRegistrationNumber", typeof(System.String));
Application_PGRegistrationNumberCol.ReadOnly = false;
Application_PGRegistrationNumberCol.AllowDBNull = false;
Columns.Add(Application_PGRegistrationNumberCol);
// column Application_PQStartDate
DataColumn Application_PQStartDateCol = new DataColumn("Application_PQStartDate", typeof(System.DateTime));
Application_PQStartDateCol.DateTimeMode = DataSetDateTime.Local;
Application_PQStartDateCol.ReadOnly = false;
Application_PQStartDateCol.AllowDBNull = false;
Columns.Add(Application_PQStartDateCol);
// column Application_PQDeadline
DataColumn Application_PQDeadlineCol = new DataColumn("Application_PQDeadline", typeof(System.DateTime));
Application_PQDeadlineCol.DateTimeMode = DataSetDateTime.Local;
Application_PQDeadlineCol.ReadOnly = false;
Application_PQDeadlineCol.AllowDBNull = false;
Columns.Add(Application_PQDeadlineCol);
// column Application_RegisteredNextExam
DataColumn Application_RegisteredNextExamCol = new DataColumn("Application_RegisteredNextExam", typeof(System.Boolean));
Application_RegisteredNextExamCol.ReadOnly = false;
Application_RegisteredNextExamCol.AllowDBNull = false;
Columns.Add(Application_RegisteredNextExamCol);
// column Application_NextExamSession
DataColumn Application_NextExamSessionCol = new DataColumn("Application_NextExamSession", typeof(System.DateTime));
Application_NextExamSessionCol.DateTimeMode = DataSetDateTime.Local;
Application_NextExamSessionCol.ReadOnly = false;
Application_NextExamSessionCol.AllowDBNull = false;
Columns.Add(Application_NextExamSessionCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = false;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Application_ScholarshipProvider
DataColumn Application_ScholarshipProviderCol = new DataColumn("Application_ScholarshipProvider", typeof(System.String));
Application_ScholarshipProviderCol.ReadOnly = false;
Application_ScholarshipProviderCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipProviderCol);
// column Application_ScholarshipCost
DataColumn Application_ScholarshipCostCol = new DataColumn("Application_ScholarshipCost", typeof(System.Decimal));
Application_ScholarshipCostCol.ReadOnly = false;
Application_ScholarshipCostCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipCostCol);
// column Application_IdentificationImage
DataColumn Application_IdentificationImageCol = new DataColumn("Application_IdentificationImage", typeof(System.String));
Application_IdentificationImageCol.ReadOnly = false;
Application_IdentificationImageCol.AllowDBNull = false;
Columns.Add(Application_IdentificationImageCol);
// column Application_BirthCertificateImage
DataColumn Application_BirthCertificateImageCol = new DataColumn("Application_BirthCertificateImage", typeof(System.String));
Application_BirthCertificateImageCol.ReadOnly = false;
Application_BirthCertificateImageCol.AllowDBNull = false;
Columns.Add(Application_BirthCertificateImageCol);
// column Application_AcademicTranscriptImage
DataColumn Application_AcademicTranscriptImageCol = new DataColumn("Application_AcademicTranscriptImage", typeof(System.String));
Application_AcademicTranscriptImageCol.ReadOnly = false;
Application_AcademicTranscriptImageCol.AllowDBNull = false;
Columns.Add(Application_AcademicTranscriptImageCol);
// column Application_PassportSizeImage
DataColumn Application_PassportSizeImageCol = new DataColumn("Application_PassportSizeImage", typeof(System.String));
Application_PassportSizeImageCol.ReadOnly = false;
Application_PassportSizeImageCol.AllowDBNull = false;
Columns.Add(Application_PassportSizeImageCol);
// column Application_PQAcceptanceImage
DataColumn Application_PQAcceptanceImageCol = new DataColumn("Application_PQAcceptanceImage", typeof(System.String));
Application_PQAcceptanceImageCol.ReadOnly = false;
Application_PQAcceptanceImageCol.AllowDBNull = false;
Columns.Add(Application_PQAcceptanceImageCol);
// column Application_DeclarationAgree
DataColumn Application_DeclarationAgreeCol = new DataColumn("Application_DeclarationAgree", typeof(System.Boolean));
Application_DeclarationAgreeCol.ReadOnly = false;
Application_DeclarationAgreeCol.AllowDBNull = false;
Columns.Add(Application_DeclarationAgreeCol);
// column Application_ConfirmReceiveMyPACNotice
DataColumn Application_ConfirmReceiveMyPACNoticeCol = new DataColumn("Application_ConfirmReceiveMyPACNotice", typeof(System.Boolean));
Application_ConfirmReceiveMyPACNoticeCol.ReadOnly = false;
Application_ConfirmReceiveMyPACNoticeCol.AllowDBNull = false;
Columns.Add(Application_ConfirmReceiveMyPACNoticeCol);
// column Application_ConfirmAgreeTermsAndCondition
DataColumn Application_ConfirmAgreeTermsAndConditionCol = new DataColumn("Application_ConfirmAgreeTermsAndCondition", typeof(System.Boolean));
Application_ConfirmAgreeTermsAndConditionCol.ReadOnly = false;
Application_ConfirmAgreeTermsAndConditionCol.AllowDBNull = false;
Columns.Add(Application_ConfirmAgreeTermsAndConditionCol);
// column Application_Submitted
DataColumn Application_SubmittedCol = new DataColumn("Application_Submitted", typeof(System.Boolean));
Application_SubmittedCol.ReadOnly = false;
Application_SubmittedCol.AllowDBNull = false;
Columns.Add(Application_SubmittedCol);
// column Application_Deleted
DataColumn Application_DeletedCol = new DataColumn("Application_Deleted", typeof(System.Boolean));
Application_DeletedCol.ReadOnly = false;
Application_DeletedCol.AllowDBNull = false;
Columns.Add(Application_DeletedCol);
// column Application_Status
DataColumn Application_StatusCol = new DataColumn("Application_Status", typeof(System.Int16));
Application_StatusCol.ReadOnly = false;
Application_StatusCol.AllowDBNull = false;
Columns.Add(Application_StatusCol);
// column Application_CreatedDate
DataColumn Application_CreatedDateCol = new DataColumn("Application_CreatedDate", typeof(System.DateTime));
Application_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_CreatedDateCol.ReadOnly = false;
Application_CreatedDateCol.AllowDBNull = false;
Columns.Add(Application_CreatedDateCol);
// column Application_UpdatedDate
DataColumn Application_UpdatedDateCol = new DataColumn("Application_UpdatedDate", typeof(System.DateTime));
Application_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_UpdatedDateCol.ReadOnly = false;
Application_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Application_UpdatedDateCol);
// column Application_CreatedBy
DataColumn Application_CreatedByCol = new DataColumn("Application_CreatedBy", typeof(System.String));
Application_CreatedByCol.ReadOnly = false;
Application_CreatedByCol.AllowDBNull = false;
Columns.Add(Application_CreatedByCol);
// column Application_UpdatedBy
DataColumn Application_UpdatedByCol = new DataColumn("Application_UpdatedBy", typeof(System.String));
Application_UpdatedByCol.ReadOnly = false;
Application_UpdatedByCol.AllowDBNull = false;
Columns.Add(Application_UpdatedByCol);
// column Application_SubmittedDate
DataColumn Application_SubmittedDateCol = new DataColumn("Application_SubmittedDate", typeof(System.DateTime));
Application_SubmittedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_SubmittedDateCol.ReadOnly = false;
Application_SubmittedDateCol.AllowDBNull = false;
Columns.Add(Application_SubmittedDateCol);
// column Application_FatherName
DataColumn Application_FatherNameCol = new DataColumn("Application_FatherName", typeof(System.String));
Application_FatherNameCol.ReadOnly = false;
Application_FatherNameCol.AllowDBNull = false;
Columns.Add(Application_FatherNameCol);
// column Application_MotherName
DataColumn Application_MotherNameCol = new DataColumn("Application_MotherName", typeof(System.String));
Application_MotherNameCol.ReadOnly = false;
Application_MotherNameCol.AllowDBNull = false;
Columns.Add(Application_MotherNameCol);
// column Application_ContractType
DataColumn Application_ContractTypeCol = new DataColumn("Application_ContractType", typeof(System.Int16));
Application_ContractTypeCol.ReadOnly = false;
Application_ContractTypeCol.AllowDBNull = false;
Columns.Add(Application_ContractTypeCol);
// column Application_PhonePrefix
DataColumn Application_PhonePrefixCol = new DataColumn("Application_PhonePrefix", typeof(System.String));
Application_PhonePrefixCol.ReadOnly = false;
Application_PhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_PhonePrefixCol);
// column Application_PhoneNumber
DataColumn Application_PhoneNumberCol = new DataColumn("Application_PhoneNumber", typeof(System.String));
Application_PhoneNumberCol.ReadOnly = false;
Application_PhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_PhoneNumberCol);
// column Application_MobilePhonePrefix
DataColumn Application_MobilePhonePrefixCol = new DataColumn("Application_MobilePhonePrefix", typeof(System.String));
Application_MobilePhonePrefixCol.ReadOnly = false;
Application_MobilePhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_MobilePhonePrefixCol);
// column Application_MobilePhoneNumber
DataColumn Application_MobilePhoneNumberCol = new DataColumn("Application_MobilePhoneNumber", typeof(System.String));
Application_MobilePhoneNumberCol.ReadOnly = false;
Application_MobilePhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_MobilePhoneNumberCol);
// column Application_FinalisedStatus
DataColumn Application_FinalisedStatusCol = new DataColumn("Application_FinalisedStatus", typeof(System.Int16));
Application_FinalisedStatusCol.ReadOnly = false;
Application_FinalisedStatusCol.AllowDBNull = false;
Columns.Add(Application_FinalisedStatusCol);
// column Application_LOIssueDate
DataColumn Application_LOIssueDateCol = new DataColumn("Application_LOIssueDate", typeof(System.DateTime));
Application_LOIssueDateCol.DateTimeMode = DataSetDateTime.Local;
Application_LOIssueDateCol.ReadOnly = false;
Application_LOIssueDateCol.AllowDBNull = false;
Columns.Add(Application_LOIssueDateCol);
// column Application_FinalisedDate
DataColumn Application_FinalisedDateCol = new DataColumn("Application_FinalisedDate", typeof(System.DateTime));
Application_FinalisedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_FinalisedDateCol.ReadOnly = false;
Application_FinalisedDateCol.AllowDBNull = false;
Columns.Add(Application_FinalisedDateCol);
// column Application_OverallStatus
DataColumn Application_OverallStatusCol = new DataColumn("Application_OverallStatus", typeof(System.Int16));
Application_OverallStatusCol.ReadOnly = false;
Application_OverallStatusCol.AllowDBNull = false;
Columns.Add(Application_OverallStatusCol);
// column Application_OverallProgress
DataColumn Application_OverallProgressCol = new DataColumn("Application_OverallProgress", typeof(System.Int16));
Application_OverallProgressCol.ReadOnly = false;
Application_OverallProgressCol.AllowDBNull = false;
Columns.Add(Application_OverallProgressCol);
// column Application_IntakeMonth
DataColumn Application_IntakeMonthCol = new DataColumn("Application_IntakeMonth", typeof(System.Int32));
Application_IntakeMonthCol.ReadOnly = false;
Application_IntakeMonthCol.AllowDBNull = false;
Columns.Add(Application_IntakeMonthCol);
// column Application_IntakeYear
DataColumn Application_IntakeYearCol = new DataColumn("Application_IntakeYear", typeof(System.Int32));
Application_IntakeYearCol.ReadOnly = false;
Application_IntakeYearCol.AllowDBNull = false;
Columns.Add(Application_IntakeYearCol);
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = false;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Application_PQLevelStart
DataColumn Application_PQLevelStartCol = new DataColumn("Application_PQLevelStart", typeof(System.String));
Application_PQLevelStartCol.ReadOnly = false;
Application_PQLevelStartCol.AllowDBNull = false;
Columns.Add(Application_PQLevelStartCol);
// column Application_IdentificationFile
DataColumn Application_IdentificationFileCol = new DataColumn("Application_IdentificationFile", typeof(System.String));
Application_IdentificationFileCol.ReadOnly = false;
Application_IdentificationFileCol.AllowDBNull = false;
Columns.Add(Application_IdentificationFileCol);
// column Application_BirthCertificateFile
DataColumn Application_BirthCertificateFileCol = new DataColumn("Application_BirthCertificateFile", typeof(System.String));
Application_BirthCertificateFileCol.ReadOnly = false;
Application_BirthCertificateFileCol.AllowDBNull = false;
Columns.Add(Application_BirthCertificateFileCol);
// column Application_AcademicTranscriptFile
DataColumn Application_AcademicTranscriptFileCol = new DataColumn("Application_AcademicTranscriptFile", typeof(System.String));
Application_AcademicTranscriptFileCol.ReadOnly = false;
Application_AcademicTranscriptFileCol.AllowDBNull = false;
Columns.Add(Application_AcademicTranscriptFileCol);
// column Application_PassportSizeFile
DataColumn Application_PassportSizeFileCol = new DataColumn("Application_PassportSizeFile", typeof(System.String));
Application_PassportSizeFileCol.ReadOnly = false;
Application_PassportSizeFileCol.AllowDBNull = false;
Columns.Add(Application_PassportSizeFileCol);
// column Application_PQAcceptanceFile
DataColumn Application_PQAcceptanceFileCol = new DataColumn("Application_PQAcceptanceFile", typeof(System.String));
Application_PQAcceptanceFileCol.ReadOnly = false;
Application_PQAcceptanceFileCol.AllowDBNull = false;
Columns.Add(Application_PQAcceptanceFileCol);
// column Application_CurrentlyEmployed
DataColumn Application_CurrentlyEmployedCol = new DataColumn("Application_CurrentlyEmployed", typeof(System.Boolean));
Application_CurrentlyEmployedCol.ReadOnly = false;
Application_CurrentlyEmployedCol.AllowDBNull = false;
Columns.Add(Application_CurrentlyEmployedCol);
// column Application_CompanyName
DataColumn Application_CompanyNameCol = new DataColumn("Application_CompanyName", typeof(System.String));
Application_CompanyNameCol.ReadOnly = false;
Application_CompanyNameCol.AllowDBNull = false;
Columns.Add(Application_CompanyNameCol);
// column Application_CompanyContact
DataColumn Application_CompanyContactCol = new DataColumn("Application_CompanyContact", typeof(System.String));
Application_CompanyContactCol.ReadOnly = false;
Application_CompanyContactCol.AllowDBNull = false;
Columns.Add(Application_CompanyContactCol);
// column Application_CompanyAddress
DataColumn Application_CompanyAddressCol = new DataColumn("Application_CompanyAddress", typeof(System.String));
Application_CompanyAddressCol.ReadOnly = false;
Application_CompanyAddressCol.AllowDBNull = false;
Columns.Add(Application_CompanyAddressCol);
// column Application_CompanyPosition
DataColumn Application_CompanyPositionCol = new DataColumn("Application_CompanyPosition", typeof(System.String));
Application_CompanyPositionCol.ReadOnly = false;
Application_CompanyPositionCol.AllowDBNull = false;
Columns.Add(Application_CompanyPositionCol);
// column Application_CompanySector
DataColumn Application_CompanySectorCol = new DataColumn("Application_CompanySector", typeof(System.String));
Application_CompanySectorCol.ReadOnly = false;
Application_CompanySectorCol.AllowDBNull = false;
Columns.Add(Application_CompanySectorCol);
// column Application_CompanyDepartment
DataColumn Application_CompanyDepartmentCol = new DataColumn("Application_CompanyDepartment", typeof(System.String));
Application_CompanyDepartmentCol.ReadOnly = false;
Application_CompanyDepartmentCol.AllowDBNull = false;
Columns.Add(Application_CompanyDepartmentCol);
// column Application_IsAssessmentSessionAccepted
DataColumn Application_IsAssessmentSessionAcceptedCol = new DataColumn("Application_IsAssessmentSessionAccepted", typeof(System.Boolean));
Application_IsAssessmentSessionAcceptedCol.ReadOnly = false;
Application_IsAssessmentSessionAcceptedCol.AllowDBNull = false;
Columns.Add(Application_IsAssessmentSessionAcceptedCol);
// column Sponsor_ID
DataColumn Sponsor_IDCol = new DataColumn("Sponsor_ID", typeof(System.Guid));
Sponsor_IDCol.ReadOnly = false;
Sponsor_IDCol.AllowDBNull = false;
Columns.Add(Sponsor_IDCol);
}
public ApplicationRow NewApplicationRow() {
ApplicationRow row = (ApplicationRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(ApplicationRow row) {
row.Application_ID = Guid.Empty;
row.Course_ID = Guid.Empty;
row.Application_Date = DateTime.Now;
row.Application_FullName = "";
row.Candidate_ID = Guid.Empty;
row.Application_DOB = DateTime.Now;
row.Application_Gender = 0;
row.Application_Nationality = 0;
row.Application_IdentificationNumber = "";
row.Application_Address1 = "";
row.Application_Address2 = "";
row.Application_Postcode = "";
row.Application_City = "";
row.Application_State = "";
row.Application_Email = "";
row.Application_FatherIdentification = "";
row.Application_MotherIdentification = "";
row.Application_CombinedHouseholdIncome = 0;
row.Application_CurrentFieldOfStudy = "";
row.Application_University = "";
row.Application_CGPA = "";
row.Application_PQQualification = false;
row.Application_PGRegistrationNumber = "";
row.Application_PQStartDate = DateTime.Now;
row.Application_PQDeadline = DateTime.Now;
row.Application_RegisteredNextExam = false;
row.Application_NextExamSession = DateTime.Now;
row.TSP_ID = Guid.Empty;
row.Application_ScholarshipProvider = "";
row.Application_ScholarshipCost = 0;
row.Application_IdentificationImage = "";
row.Application_BirthCertificateImage = "";
row.Application_AcademicTranscriptImage = "";
row.Application_PassportSizeImage = "";
row.Application_PQAcceptanceImage = "";
row.Application_DeclarationAgree = false;
row.Application_ConfirmReceiveMyPACNotice = false;
row.Application_ConfirmAgreeTermsAndCondition = false;
row.Application_Submitted = false;
row.Application_Deleted = false;
row.Application_Status = 0;
row.Application_CreatedDate = DateTime.Now;
row.Application_UpdatedDate = DateTime.Now;
row.Application_CreatedBy = "";
row.Application_UpdatedBy = "";
row.Application_SubmittedDate = DateTime.Now;
row.Application_FatherName = "";
row.Application_MotherName = "";
row.Application_ContractType = 0;
row.Application_PhonePrefix = "";
row.Application_PhoneNumber = "";
row.Application_MobilePhonePrefix = "";
row.Application_MobilePhoneNumber = "";
row.Application_FinalisedStatus = 0;
row.Application_LOIssueDate = DateTime.Now;
row.Application_FinalisedDate = DateTime.Now;
row.Application_OverallStatus = 0;
row.Application_OverallProgress = 0;
row.Application_IntakeMonth = 0;
row.Application_IntakeYear = 0;
row.Country_ID = Guid.Empty;
row.Application_PQLevelStart = "";
row.Application_IdentificationFile = "";
row.Application_BirthCertificateFile = "";
row.Application_AcademicTranscriptFile = "";
row.Application_PassportSizeFile = "";
row.Application_PQAcceptanceFile = "";
row.Application_CurrentlyEmployed = false;
row.Application_CompanyName = "";
row.Application_CompanyContact = "";
row.Application_CompanyAddress = "";
row.Application_CompanyPosition = "";
row.Application_CompanySector = "";
row.Application_CompanyDepartment = "";
row.Application_IsAssessmentSessionAccepted = false;
row.Sponsor_ID = Guid.Empty;
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new ApplicationRow(builder);
}
public ApplicationRow GetApplicationRow(int index) {
return (ApplicationRow)Rows[index];
}
}
public partial class ApplicationRow : DataRow {
internal ApplicationRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
set {
this["Application_ID"] = value;
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
public System.DateTime Application_Date {
get {
return (System.DateTime)this["Application_Date"];
}
set {
this["Application_Date"] = value;
}
}
public System.String Application_FullName {
get {
return (System.String)this["Application_FullName"];
}
set {
if( value.Length > 250 ) this["Application_FullName"] = value.Substring(0, 250);
else this["Application_FullName"] = value;
}
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
set {
this["Candidate_ID"] = value;
}
}
public System.DateTime Application_DOB {
get {
return (System.DateTime)this["Application_DOB"];
}
set {
this["Application_DOB"] = value;
}
}
public System.Int16 Application_Gender {
get {
return (System.Int16)this["Application_Gender"];
}
set {
this["Application_Gender"] = value;
}
}
public System.Int16 Application_Nationality {
get {
return (System.Int16)this["Application_Nationality"];
}
set {
this["Application_Nationality"] = value;
}
}
public System.String Application_IdentificationNumber {
get {
return (System.String)this["Application_IdentificationNumber"];
}
set {
if( value.Length > 50 ) this["Application_IdentificationNumber"] = value.Substring(0, 50);
else this["Application_IdentificationNumber"] = value;
}
}
public System.String Application_Address1 {
get {
return (System.String)this["Application_Address1"];
}
set {
if( value.Length > 100 ) this["Application_Address1"] = value.Substring(0, 100);
else this["Application_Address1"] = value;
}
}
public System.String Application_Address2 {
get {
return (System.String)this["Application_Address2"];
}
set {
if( value.Length > 100 ) this["Application_Address2"] = value.Substring(0, 100);
else this["Application_Address2"] = value;
}
}
public System.String Application_Postcode {
get {
return (System.String)this["Application_Postcode"];
}
set {
if( value.Length > 50 ) this["Application_Postcode"] = value.Substring(0, 50);
else this["Application_Postcode"] = value;
}
}
public System.String Application_City {
get {
return (System.String)this["Application_City"];
}
set {
if( value.Length > 100 ) this["Application_City"] = value.Substring(0, 100);
else this["Application_City"] = value;
}
}
public System.String Application_State {
get {
return (System.String)this["Application_State"];
}
set {
if( value.Length > 50 ) this["Application_State"] = value.Substring(0, 50);
else this["Application_State"] = value;
}
}
public System.String Application_Email {
get {
return (System.String)this["Application_Email"];
}
set {
if( value.Length > 50 ) this["Application_Email"] = value.Substring(0, 50);
else this["Application_Email"] = value;
}
}
public System.String Application_FatherIdentification {
get {
return (System.String)this["Application_FatherIdentification"];
}
set {
if( value.Length > 50 ) this["Application_FatherIdentification"] = value.Substring(0, 50);
else this["Application_FatherIdentification"] = value;
}
}
public System.String Application_MotherIdentification {
get {
return (System.String)this["Application_MotherIdentification"];
}
set {
if( value.Length > 50 ) this["Application_MotherIdentification"] = value.Substring(0, 50);
else this["Application_MotherIdentification"] = value;
}
}
public System.Decimal Application_CombinedHouseholdIncome {
get {
return (System.Decimal)this["Application_CombinedHouseholdIncome"];
}
set {
this["Application_CombinedHouseholdIncome"] = value;
}
}
public System.String Application_CurrentFieldOfStudy {
get {
return (System.String)this["Application_CurrentFieldOfStudy"];
}
set {
if( value.Length > 100 ) this["Application_CurrentFieldOfStudy"] = value.Substring(0, 100);
else this["Application_CurrentFieldOfStudy"] = value;
}
}
public System.String Application_University {
get {
return (System.String)this["Application_University"];
}
set {
if( value.Length > 150 ) this["Application_University"] = value.Substring(0, 150);
else this["Application_University"] = value;
}
}
public System.String Application_CGPA {
get {
return (System.String)this["Application_CGPA"];
}
set {
if( value.Length > 50 ) this["Application_CGPA"] = value.Substring(0, 50);
else this["Application_CGPA"] = value;
}
}
public System.Boolean Application_PQQualification {
get {
return (System.Boolean)this["Application_PQQualification"];
}
set {
this["Application_PQQualification"] = value;
}
}
public System.String Application_PGRegistrationNumber {
get {
return (System.String)this["Application_PGRegistrationNumber"];
}
set {
if( value.Length > 50 ) this["Application_PGRegistrationNumber"] = value.Substring(0, 50);
else this["Application_PGRegistrationNumber"] = value;
}
}
public System.DateTime Application_PQStartDate {
get {
return (System.DateTime)this["Application_PQStartDate"];
}
set {
this["Application_PQStartDate"] = value;
}
}
public System.DateTime Application_PQDeadline {
get {
return (System.DateTime)this["Application_PQDeadline"];
}
set {
this["Application_PQDeadline"] = value;
}
}
public System.Boolean Application_RegisteredNextExam {
get {
return (System.Boolean)this["Application_RegisteredNextExam"];
}
set {
this["Application_RegisteredNextExam"] = value;
}
}
public System.DateTime Application_NextExamSession {
get {
return (System.DateTime)this["Application_NextExamSession"];
}
set {
this["Application_NextExamSession"] = value;
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
public System.String Application_ScholarshipProvider {
get {
return (System.String)this["Application_ScholarshipProvider"];
}
set {
if( value.Length > 150 ) this["Application_ScholarshipProvider"] = value.Substring(0, 150);
else this["Application_ScholarshipProvider"] = value;
}
}
public System.Decimal Application_ScholarshipCost {
get {
return (System.Decimal)this["Application_ScholarshipCost"];
}
set {
this["Application_ScholarshipCost"] = value;
}
}
public System.String Application_IdentificationImage {
get {
return (System.String)this["Application_IdentificationImage"];
}
set {
if( value.Length > 50 ) this["Application_IdentificationImage"] = value.Substring(0, 50);
else this["Application_IdentificationImage"] = value;
}
}
public System.String Application_BirthCertificateImage {
get {
return (System.String)this["Application_BirthCertificateImage"];
}
set {
if( value.Length > 50 ) this["Application_BirthCertificateImage"] = value.Substring(0, 50);
else this["Application_BirthCertificateImage"] = value;
}
}
public System.String Application_AcademicTranscriptImage {
get {
return (System.String)this["Application_AcademicTranscriptImage"];
}
set {
if( value.Length > 50 ) this["Application_AcademicTranscriptImage"] = value.Substring(0, 50);
else this["Application_AcademicTranscriptImage"] = value;
}
}
public System.String Application_PassportSizeImage {
get {
return (System.String)this["Application_PassportSizeImage"];
}
set {
if( value.Length > 50 ) this["Application_PassportSizeImage"] = value.Substring(0, 50);
else this["Application_PassportSizeImage"] = value;
}
}
public System.String Application_PQAcceptanceImage {
get {
return (System.String)this["Application_PQAcceptanceImage"];
}
set {
if( value.Length > 50 ) this["Application_PQAcceptanceImage"] = value.Substring(0, 50);
else this["Application_PQAcceptanceImage"] = value;
}
}
public System.Boolean Application_DeclarationAgree {
get {
return (System.Boolean)this["Application_DeclarationAgree"];
}
set {
this["Application_DeclarationAgree"] = value;
}
}
public System.Boolean Application_ConfirmReceiveMyPACNotice {
get {
return (System.Boolean)this["Application_ConfirmReceiveMyPACNotice"];
}
set {
this["Application_ConfirmReceiveMyPACNotice"] = value;
}
}
public System.Boolean Application_ConfirmAgreeTermsAndCondition {
get {
return (System.Boolean)this["Application_ConfirmAgreeTermsAndCondition"];
}
set {
this["Application_ConfirmAgreeTermsAndCondition"] = value;
}
}
public System.Boolean Application_Submitted {
get {
return (System.Boolean)this["Application_Submitted"];
}
set {
this["Application_Submitted"] = value;
}
}
public System.Boolean Application_Deleted {
get {
return (System.Boolean)this["Application_Deleted"];
}
set {
this["Application_Deleted"] = value;
}
}
public System.Int16 Application_Status {
get {
return (System.Int16)this["Application_Status"];
}
set {
this["Application_Status"] = value;
}
}
public System.DateTime Application_CreatedDate {
get {
return (System.DateTime)this["Application_CreatedDate"];
}
set {
this["Application_CreatedDate"] = value;
}
}
public System.DateTime Application_UpdatedDate {
get {
return (System.DateTime)this["Application_UpdatedDate"];
}
set {
this["Application_UpdatedDate"] = value;
}
}
public System.String Application_CreatedBy {
get {
return (System.String)this["Application_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Application_CreatedBy"] = value.Substring(0, 50);
else this["Application_CreatedBy"] = value;
}
}
public System.String Application_UpdatedBy {
get {
return (System.String)this["Application_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Application_UpdatedBy"] = value.Substring(0, 50);
else this["Application_UpdatedBy"] = value;
}
}
public System.DateTime Application_SubmittedDate {
get {
return (System.DateTime)this["Application_SubmittedDate"];
}
set {
this["Application_SubmittedDate"] = value;
}
}
public System.String Application_FatherName {
get {
return (System.String)this["Application_FatherName"];
}
set {
if( value.Length > 100 ) this["Application_FatherName"] = value.Substring(0, 100);
else this["Application_FatherName"] = value;
}
}
public System.String Application_MotherName {
get {
return (System.String)this["Application_MotherName"];
}
set {
if( value.Length > 100 ) this["Application_MotherName"] = value.Substring(0, 100);
else this["Application_MotherName"] = value;
}
}
public System.Int16 Application_ContractType {
get {
return (System.Int16)this["Application_ContractType"];
}
set {
this["Application_ContractType"] = value;
}
}
public System.String Application_PhonePrefix {
get {
return (System.String)this["Application_PhonePrefix"];
}
set {
if( value.Length > 50 ) this["Application_PhonePrefix"] = value.Substring(0, 50);
else this["Application_PhonePrefix"] = value;
}
}
public System.String Application_PhoneNumber {
get {
return (System.String)this["Application_PhoneNumber"];
}
set {
if( value.Length > 50 ) this["Application_PhoneNumber"] = value.Substring(0, 50);
else this["Application_PhoneNumber"] = value;
}
}
public System.String Application_MobilePhonePrefix {
get {
return (System.String)this["Application_MobilePhonePrefix"];
}
set {
if( value.Length > 50 ) this["Application_MobilePhonePrefix"] = value.Substring(0, 50);
else this["Application_MobilePhonePrefix"] = value;
}
}
public System.String Application_MobilePhoneNumber {
get {
return (System.String)this["Application_MobilePhoneNumber"];
}
set {
if( value.Length > 50 ) this["Application_MobilePhoneNumber"] = value.Substring(0, 50);
else this["Application_MobilePhoneNumber"] = value;
}
}
public System.Int16 Application_FinalisedStatus {
get {
return (System.Int16)this["Application_FinalisedStatus"];
}
set {
this["Application_FinalisedStatus"] = value;
}
}
public System.DateTime Application_LOIssueDate {
get {
return (System.DateTime)this["Application_LOIssueDate"];
}
set {
this["Application_LOIssueDate"] = value;
}
}
public System.DateTime Application_FinalisedDate {
get {
return (System.DateTime)this["Application_FinalisedDate"];
}
set {
this["Application_FinalisedDate"] = value;
}
}
public System.Int16 Application_OverallStatus {
get {
return (System.Int16)this["Application_OverallStatus"];
}
set {
this["Application_OverallStatus"] = value;
}
}
public System.Int16 Application_OverallProgress {
get {
return (System.Int16)this["Application_OverallProgress"];
}
set {
this["Application_OverallProgress"] = value;
}
}
public System.Int32 Application_IntakeMonth {
get {
return (System.Int32)this["Application_IntakeMonth"];
}
set {
this["Application_IntakeMonth"] = value;
}
}
public System.Int32 Application_IntakeYear {
get {
return (System.Int32)this["Application_IntakeYear"];
}
set {
this["Application_IntakeYear"] = value;
}
}
public System.Guid Country_ID {
get {
return (System.Guid)this["Country_ID"];
}
set {
this["Country_ID"] = value;
}
}
public System.String Application_PQLevelStart {
get {
return (System.String)this["Application_PQLevelStart"];
}
set {
if( value.Length > 100 ) this["Application_PQLevelStart"] = value.Substring(0, 100);
else this["Application_PQLevelStart"] = value;
}
}
public System.String Application_IdentificationFile {
get {
return (System.String)this["Application_IdentificationFile"];
}
set {
if( value.Length > 100 ) this["Application_IdentificationFile"] = value.Substring(0, 100);
else this["Application_IdentificationFile"] = value;
}
}
public System.String Application_BirthCertificateFile {
get {
return (System.String)this["Application_BirthCertificateFile"];
}
set {
if( value.Length > 100 ) this["Application_BirthCertificateFile"] = value.Substring(0, 100);
else this["Application_BirthCertificateFile"] = value;
}
}
public System.String Application_AcademicTranscriptFile {
get {
return (System.String)this["Application_AcademicTranscriptFile"];
}
set {
if( value.Length > 100 ) this["Application_AcademicTranscriptFile"] = value.Substring(0, 100);
else this["Application_AcademicTranscriptFile"] = value;
}
}
public System.String Application_PassportSizeFile {
get {
return (System.String)this["Application_PassportSizeFile"];
}
set {
if( value.Length > 100 ) this["Application_PassportSizeFile"] = value.Substring(0, 100);
else this["Application_PassportSizeFile"] = value;
}
}
public System.String Application_PQAcceptanceFile {
get {
return (System.String)this["Application_PQAcceptanceFile"];
}
set {
if( value.Length > 100 ) this["Application_PQAcceptanceFile"] = value.Substring(0, 100);
else this["Application_PQAcceptanceFile"] = value;
}
}
public System.Boolean Application_CurrentlyEmployed {
get {
return (System.Boolean)this["Application_CurrentlyEmployed"];
}
set {
this["Application_CurrentlyEmployed"] = value;
}
}
public System.String Application_CompanyName {
get {
return (System.String)this["Application_CompanyName"];
}
set {
if( value.Length > 250 ) this["Application_CompanyName"] = value.Substring(0, 250);
else this["Application_CompanyName"] = value;
}
}
public System.String Application_CompanyContact {
get {
return (System.String)this["Application_CompanyContact"];
}
set {
if( value.Length > 250 ) this["Application_CompanyContact"] = value.Substring(0, 250);
else this["Application_CompanyContact"] = value;
}
}
public System.String Application_CompanyAddress {
get {
return (System.String)this["Application_CompanyAddress"];
}
set {
if( value.Length > 500 ) this["Application_CompanyAddress"] = value.Substring(0, 500);
else this["Application_CompanyAddress"] = value;
}
}
public System.String Application_CompanyPosition {
get {
return (System.String)this["Application_CompanyPosition"];
}
set {
if( value.Length > 250 ) this["Application_CompanyPosition"] = value.Substring(0, 250);
else this["Application_CompanyPosition"] = value;
}
}
public System.String Application_CompanySector {
get {
return (System.String)this["Application_CompanySector"];
}
set {
if( value.Length > 250 ) this["Application_CompanySector"] = value.Substring(0, 250);
else this["Application_CompanySector"] = value;
}
}
public System.String Application_CompanyDepartment {
get {
return (System.String)this["Application_CompanyDepartment"];
}
set {
if( value.Length > 250 ) this["Application_CompanyDepartment"] = value.Substring(0, 250);
else this["Application_CompanyDepartment"] = value;
}
}
public System.Boolean Application_IsAssessmentSessionAccepted {
get {
return (System.Boolean)this["Application_IsAssessmentSessionAccepted"];
}
set {
this["Application_IsAssessmentSessionAccepted"] = value;
}
}
public System.Guid Sponsor_ID {
get {
return (System.Guid)this["Sponsor_ID"];
}
set {
this["Sponsor_ID"] = value;
}
}
}
public partial class ApplicationMinimalizedEntity {
public ApplicationMinimalizedEntity() {}
public ApplicationMinimalizedEntity(ApplicationRow dr) {
this.Application_ID = dr.Application_ID;
this.Course_ID = dr.Course_ID;
this.Application_Date = dr.Application_Date;
this.Application_FullName = dr.Application_FullName;
this.Candidate_ID = dr.Candidate_ID;
this.Application_DOB = dr.Application_DOB;
this.Application_Gender = dr.Application_Gender;
this.Application_Nationality = dr.Application_Nationality;
this.Application_IdentificationNumber = dr.Application_IdentificationNumber;
this.Application_Address1 = dr.Application_Address1;
this.Application_Address2 = dr.Application_Address2;
this.Application_Postcode = dr.Application_Postcode;
this.Application_City = dr.Application_City;
this.Application_State = dr.Application_State;
this.Application_Email = dr.Application_Email;
this.Application_FatherIdentification = dr.Application_FatherIdentification;
this.Application_MotherIdentification = dr.Application_MotherIdentification;
this.Application_CombinedHouseholdIncome = dr.Application_CombinedHouseholdIncome;
this.Application_CurrentFieldOfStudy = dr.Application_CurrentFieldOfStudy;
this.Application_University = dr.Application_University;
this.Application_CGPA = dr.Application_CGPA;
this.Application_PQQualification = dr.Application_PQQualification;
this.Application_PGRegistrationNumber = dr.Application_PGRegistrationNumber;
this.Application_PQStartDate = dr.Application_PQStartDate;
this.Application_PQDeadline = dr.Application_PQDeadline;
this.Application_RegisteredNextExam = dr.Application_RegisteredNextExam;
this.Application_NextExamSession = dr.Application_NextExamSession;
this.TSP_ID = dr.TSP_ID;
this.Application_ScholarshipProvider = dr.Application_ScholarshipProvider;
this.Application_ScholarshipCost = dr.Application_ScholarshipCost;
this.Application_IdentificationImage = dr.Application_IdentificationImage;
this.Application_BirthCertificateImage = dr.Application_BirthCertificateImage;
this.Application_AcademicTranscriptImage = dr.Application_AcademicTranscriptImage;
this.Application_PassportSizeImage = dr.Application_PassportSizeImage;
this.Application_PQAcceptanceImage = dr.Application_PQAcceptanceImage;
this.Application_DeclarationAgree = dr.Application_DeclarationAgree;
this.Application_ConfirmReceiveMyPACNotice = dr.Application_ConfirmReceiveMyPACNotice;
this.Application_ConfirmAgreeTermsAndCondition = dr.Application_ConfirmAgreeTermsAndCondition;
this.Application_Submitted = dr.Application_Submitted;
this.Application_Deleted = dr.Application_Deleted;
this.Application_Status = dr.Application_Status;
this.Application_CreatedDate = dr.Application_CreatedDate;
this.Application_UpdatedDate = dr.Application_UpdatedDate;
this.Application_CreatedBy = dr.Application_CreatedBy;
this.Application_UpdatedBy = dr.Application_UpdatedBy;
this.Application_SubmittedDate = dr.Application_SubmittedDate;
this.Application_FatherName = dr.Application_FatherName;
this.Application_MotherName = dr.Application_MotherName;
this.Application_ContractType = dr.Application_ContractType;
this.Application_PhonePrefix = dr.Application_PhonePrefix;
this.Application_PhoneNumber = dr.Application_PhoneNumber;
this.Application_MobilePhonePrefix = dr.Application_MobilePhonePrefix;
this.Application_MobilePhoneNumber = dr.Application_MobilePhoneNumber;
this.Application_FinalisedStatus = dr.Application_FinalisedStatus;
this.Application_LOIssueDate = dr.Application_LOIssueDate;
this.Application_FinalisedDate = dr.Application_FinalisedDate;
this.Application_OverallStatus = dr.Application_OverallStatus;
this.Application_OverallProgress = dr.Application_OverallProgress;
this.Application_IntakeMonth = dr.Application_IntakeMonth;
this.Application_IntakeYear = dr.Application_IntakeYear;
this.Country_ID = dr.Country_ID;
this.Application_PQLevelStart = dr.Application_PQLevelStart;
this.Application_IdentificationFile = dr.Application_IdentificationFile;
this.Application_BirthCertificateFile = dr.Application_BirthCertificateFile;
this.Application_AcademicTranscriptFile = dr.Application_AcademicTranscriptFile;
this.Application_PassportSizeFile = dr.Application_PassportSizeFile;
this.Application_PQAcceptanceFile = dr.Application_PQAcceptanceFile;
this.Application_CurrentlyEmployed = dr.Application_CurrentlyEmployed;
this.Application_CompanyName = dr.Application_CompanyName;
this.Application_CompanyContact = dr.Application_CompanyContact;
this.Application_CompanyAddress = dr.Application_CompanyAddress;
this.Application_CompanyPosition = dr.Application_CompanyPosition;
this.Application_CompanySector = dr.Application_CompanySector;
this.Application_CompanyDepartment = dr.Application_CompanyDepartment;
this.Application_IsAssessmentSessionAccepted = dr.Application_IsAssessmentSessionAccepted;
this.Sponsor_ID = dr.Sponsor_ID;
}
public void CopyTo(ApplicationRow dr) {
dr.Application_ID = this.Application_ID;
dr.Course_ID = this.Course_ID;
dr.Application_Date = this.Application_Date;
dr.Application_FullName = this.Application_FullName;
dr.Candidate_ID = this.Candidate_ID;
dr.Application_DOB = this.Application_DOB;
dr.Application_Gender = this.Application_Gender;
dr.Application_Nationality = this.Application_Nationality;
dr.Application_IdentificationNumber = this.Application_IdentificationNumber;
dr.Application_Address1 = this.Application_Address1;
dr.Application_Address2 = this.Application_Address2;
dr.Application_Postcode = this.Application_Postcode;
dr.Application_City = this.Application_City;
dr.Application_State = this.Application_State;
dr.Application_Email = this.Application_Email;
dr.Application_FatherIdentification = this.Application_FatherIdentification;
dr.Application_MotherIdentification = this.Application_MotherIdentification;
dr.Application_CombinedHouseholdIncome = this.Application_CombinedHouseholdIncome;
dr.Application_CurrentFieldOfStudy = this.Application_CurrentFieldOfStudy;
dr.Application_University = this.Application_University;
dr.Application_CGPA = this.Application_CGPA;
dr.Application_PQQualification = this.Application_PQQualification;
dr.Application_PGRegistrationNumber = this.Application_PGRegistrationNumber;
dr.Application_PQStartDate = this.Application_PQStartDate;
dr.Application_PQDeadline = this.Application_PQDeadline;
dr.Application_RegisteredNextExam = this.Application_RegisteredNextExam;
dr.Application_NextExamSession = this.Application_NextExamSession;
dr.TSP_ID = this.TSP_ID;
dr.Application_ScholarshipProvider = this.Application_ScholarshipProvider;
dr.Application_ScholarshipCost = this.Application_ScholarshipCost;
dr.Application_IdentificationImage = this.Application_IdentificationImage;
dr.Application_BirthCertificateImage = this.Application_BirthCertificateImage;
dr.Application_AcademicTranscriptImage = this.Application_AcademicTranscriptImage;
dr.Application_PassportSizeImage = this.Application_PassportSizeImage;
dr.Application_PQAcceptanceImage = this.Application_PQAcceptanceImage;
dr.Application_DeclarationAgree = this.Application_DeclarationAgree;
dr.Application_ConfirmReceiveMyPACNotice = this.Application_ConfirmReceiveMyPACNotice;
dr.Application_ConfirmAgreeTermsAndCondition = this.Application_ConfirmAgreeTermsAndCondition;
dr.Application_Submitted = this.Application_Submitted;
dr.Application_Deleted = this.Application_Deleted;
dr.Application_Status = this.Application_Status;
dr.Application_CreatedDate = this.Application_CreatedDate;
dr.Application_UpdatedDate = this.Application_UpdatedDate;
dr.Application_CreatedBy = this.Application_CreatedBy;
dr.Application_UpdatedBy = this.Application_UpdatedBy;
dr.Application_SubmittedDate = this.Application_SubmittedDate;
dr.Application_FatherName = this.Application_FatherName;
dr.Application_MotherName = this.Application_MotherName;
dr.Application_ContractType = this.Application_ContractType;
dr.Application_PhonePrefix = this.Application_PhonePrefix;
dr.Application_PhoneNumber = this.Application_PhoneNumber;
dr.Application_MobilePhonePrefix = this.Application_MobilePhonePrefix;
dr.Application_MobilePhoneNumber = this.Application_MobilePhoneNumber;
dr.Application_FinalisedStatus = this.Application_FinalisedStatus;
dr.Application_LOIssueDate = this.Application_LOIssueDate;
dr.Application_FinalisedDate = this.Application_FinalisedDate;
dr.Application_OverallStatus = this.Application_OverallStatus;
dr.Application_OverallProgress = this.Application_OverallProgress;
dr.Application_IntakeMonth = this.Application_IntakeMonth;
dr.Application_IntakeYear = this.Application_IntakeYear;
dr.Country_ID = this.Country_ID;
dr.Application_PQLevelStart = this.Application_PQLevelStart;
dr.Application_IdentificationFile = this.Application_IdentificationFile;
dr.Application_BirthCertificateFile = this.Application_BirthCertificateFile;
dr.Application_AcademicTranscriptFile = this.Application_AcademicTranscriptFile;
dr.Application_PassportSizeFile = this.Application_PassportSizeFile;
dr.Application_PQAcceptanceFile = this.Application_PQAcceptanceFile;
dr.Application_CurrentlyEmployed = this.Application_CurrentlyEmployed;
dr.Application_CompanyName = this.Application_CompanyName;
dr.Application_CompanyContact = this.Application_CompanyContact;
dr.Application_CompanyAddress = this.Application_CompanyAddress;
dr.Application_CompanyPosition = this.Application_CompanyPosition;
dr.Application_CompanySector = this.Application_CompanySector;
dr.Application_CompanyDepartment = this.Application_CompanyDepartment;
dr.Application_IsAssessmentSessionAccepted = this.Application_IsAssessmentSessionAccepted;
dr.Sponsor_ID = this.Sponsor_ID;
}
public System.Guid Application_ID;
public System.Guid Course_ID;
public System.DateTime Application_Date;
public System.String Application_FullName;
public System.Guid Candidate_ID;
public System.DateTime Application_DOB;
public System.Int16 Application_Gender;
public System.Int16 Application_Nationality;
public System.String Application_IdentificationNumber;
public System.String Application_Address1;
public System.String Application_Address2;
public System.String Application_Postcode;
public System.String Application_City;
public System.String Application_State;
public System.String Application_Email;
public System.String Application_FatherIdentification;
public System.String Application_MotherIdentification;
public System.Decimal Application_CombinedHouseholdIncome;
public System.String Application_CurrentFieldOfStudy;
public System.String Application_University;
public System.String Application_CGPA;
public System.Boolean Application_PQQualification;
public System.String Application_PGRegistrationNumber;
public System.DateTime Application_PQStartDate;
public System.DateTime Application_PQDeadline;
public System.Boolean Application_RegisteredNextExam;
public System.DateTime Application_NextExamSession;
public System.Guid TSP_ID;
public System.String Application_ScholarshipProvider;
public System.Decimal Application_ScholarshipCost;
public System.String Application_IdentificationImage;
public System.String Application_BirthCertificateImage;
public System.String Application_AcademicTranscriptImage;
public System.String Application_PassportSizeImage;
public System.String Application_PQAcceptanceImage;
public System.Boolean Application_DeclarationAgree;
public System.Boolean Application_ConfirmReceiveMyPACNotice;
public System.Boolean Application_ConfirmAgreeTermsAndCondition;
public System.Boolean Application_Submitted;
public System.Boolean Application_Deleted;
public System.Int16 Application_Status;
public System.DateTime Application_CreatedDate;
public System.DateTime Application_UpdatedDate;
public System.String Application_CreatedBy;
public System.String Application_UpdatedBy;
public System.DateTime Application_SubmittedDate;
public System.String Application_FatherName;
public System.String Application_MotherName;
public System.Int16 Application_ContractType;
public System.String Application_PhonePrefix;
public System.String Application_PhoneNumber;
public System.String Application_MobilePhonePrefix;
public System.String Application_MobilePhoneNumber;
public System.Int16 Application_FinalisedStatus;
public System.DateTime Application_LOIssueDate;
public System.DateTime Application_FinalisedDate;
public System.Int16 Application_OverallStatus;
public System.Int16 Application_OverallProgress;
public System.Int32 Application_IntakeMonth;
public System.Int32 Application_IntakeYear;
public System.Guid Country_ID;
public System.String Application_PQLevelStart;
public System.String Application_IdentificationFile;
public System.String Application_BirthCertificateFile;
public System.String Application_AcademicTranscriptFile;
public System.String Application_PassportSizeFile;
public System.String Application_PQAcceptanceFile;
public System.Boolean Application_CurrentlyEmployed;
public System.String Application_CompanyName;
public System.String Application_CompanyContact;
public System.String Application_CompanyAddress;
public System.String Application_CompanyPosition;
public System.String Application_CompanySector;
public System.String Application_CompanyDepartment;
public System.Boolean Application_IsAssessmentSessionAccepted;
public System.Guid Sponsor_ID;
}
public partial class ApplicationAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public ApplicationAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("Application_Date", "Application_Date");
tmap.ColumnMappings.Add("Application_FullName", "Application_FullName");
tmap.ColumnMappings.Add("Candidate_ID", "Candidate_ID");
tmap.ColumnMappings.Add("Application_DOB", "Application_DOB");
tmap.ColumnMappings.Add("Application_Gender", "Application_Gender");
tmap.ColumnMappings.Add("Application_Nationality", "Application_Nationality");
tmap.ColumnMappings.Add("Application_IdentificationNumber", "Application_IdentificationNumber");
tmap.ColumnMappings.Add("Application_Address1", "Application_Address1");
tmap.ColumnMappings.Add("Application_Address2", "Application_Address2");
tmap.ColumnMappings.Add("Application_Postcode", "Application_Postcode");
tmap.ColumnMappings.Add("Application_City", "Application_City");
tmap.ColumnMappings.Add("Application_State", "Application_State");
tmap.ColumnMappings.Add("Application_Email", "Application_Email");
tmap.ColumnMappings.Add("Application_FatherIdentification", "Application_FatherIdentification");
tmap.ColumnMappings.Add("Application_MotherIdentification", "Application_MotherIdentification");
tmap.ColumnMappings.Add("Application_CombinedHouseholdIncome", "Application_CombinedHouseholdIncome");
tmap.ColumnMappings.Add("Application_CurrentFieldOfStudy", "Application_CurrentFieldOfStudy");
tmap.ColumnMappings.Add("Application_University", "Application_University");
tmap.ColumnMappings.Add("Application_CGPA", "Application_CGPA");
tmap.ColumnMappings.Add("Application_PQQualification", "Application_PQQualification");
tmap.ColumnMappings.Add("Application_PGRegistrationNumber", "Application_PGRegistrationNumber");
tmap.ColumnMappings.Add("Application_PQStartDate", "Application_PQStartDate");
tmap.ColumnMappings.Add("Application_PQDeadline", "Application_PQDeadline");
tmap.ColumnMappings.Add("Application_RegisteredNextExam", "Application_RegisteredNextExam");
tmap.ColumnMappings.Add("Application_NextExamSession", "Application_NextExamSession");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("Application_ScholarshipProvider", "Application_ScholarshipProvider");
tmap.ColumnMappings.Add("Application_ScholarshipCost", "Application_ScholarshipCost");
tmap.ColumnMappings.Add("Application_IdentificationImage", "Application_IdentificationImage");
tmap.ColumnMappings.Add("Application_BirthCertificateImage", "Application_BirthCertificateImage");
tmap.ColumnMappings.Add("Application_AcademicTranscriptImage", "Application_AcademicTranscriptImage");
tmap.ColumnMappings.Add("Application_PassportSizeImage", "Application_PassportSizeImage");
tmap.ColumnMappings.Add("Application_PQAcceptanceImage", "Application_PQAcceptanceImage");
tmap.ColumnMappings.Add("Application_DeclarationAgree", "Application_DeclarationAgree");
tmap.ColumnMappings.Add("Application_ConfirmReceiveMyPACNotice", "Application_ConfirmReceiveMyPACNotice");
tmap.ColumnMappings.Add("Application_ConfirmAgreeTermsAndCondition", "Application_ConfirmAgreeTermsAndCondition");
tmap.ColumnMappings.Add("Application_Submitted", "Application_Submitted");
tmap.ColumnMappings.Add("Application_Deleted", "Application_Deleted");
tmap.ColumnMappings.Add("Application_Status", "Application_Status");
tmap.ColumnMappings.Add("Application_CreatedDate", "Application_CreatedDate");
tmap.ColumnMappings.Add("Application_UpdatedDate", "Application_UpdatedDate");
tmap.ColumnMappings.Add("Application_CreatedBy", "Application_CreatedBy");
tmap.ColumnMappings.Add("Application_UpdatedBy", "Application_UpdatedBy");
tmap.ColumnMappings.Add("Application_SubmittedDate", "Application_SubmittedDate");
tmap.ColumnMappings.Add("Application_FatherName", "Application_FatherName");
tmap.ColumnMappings.Add("Application_MotherName", "Application_MotherName");
tmap.ColumnMappings.Add("Application_ContractType", "Application_ContractType");
tmap.ColumnMappings.Add("Application_PhonePrefix", "Application_PhonePrefix");
tmap.ColumnMappings.Add("Application_PhoneNumber", "Application_PhoneNumber");
tmap.ColumnMappings.Add("Application_MobilePhonePrefix", "Application_MobilePhonePrefix");
tmap.ColumnMappings.Add("Application_MobilePhoneNumber", "Application_MobilePhoneNumber");
tmap.ColumnMappings.Add("Application_FinalisedStatus", "Application_FinalisedStatus");
tmap.ColumnMappings.Add("Application_LOIssueDate", "Application_LOIssueDate");
tmap.ColumnMappings.Add("Application_FinalisedDate", "Application_FinalisedDate");
tmap.ColumnMappings.Add("Application_OverallStatus", "Application_OverallStatus");
tmap.ColumnMappings.Add("Application_OverallProgress", "Application_OverallProgress");
tmap.ColumnMappings.Add("Application_IntakeMonth", "Application_IntakeMonth");
tmap.ColumnMappings.Add("Application_IntakeYear", "Application_IntakeYear");
tmap.ColumnMappings.Add("Country_ID", "Country_ID");
tmap.ColumnMappings.Add("Application_PQLevelStart", "Application_PQLevelStart");
tmap.ColumnMappings.Add("Application_IdentificationFile", "Application_IdentificationFile");
tmap.ColumnMappings.Add("Application_BirthCertificateFile", "Application_BirthCertificateFile");
tmap.ColumnMappings.Add("Application_AcademicTranscriptFile", "Application_AcademicTranscriptFile");
tmap.ColumnMappings.Add("Application_PassportSizeFile", "Application_PassportSizeFile");
tmap.ColumnMappings.Add("Application_PQAcceptanceFile", "Application_PQAcceptanceFile");
tmap.ColumnMappings.Add("Application_CurrentlyEmployed", "Application_CurrentlyEmployed");
tmap.ColumnMappings.Add("Application_CompanyName", "Application_CompanyName");
tmap.ColumnMappings.Add("Application_CompanyContact", "Application_CompanyContact");
tmap.ColumnMappings.Add("Application_CompanyAddress", "Application_CompanyAddress");
tmap.ColumnMappings.Add("Application_CompanyPosition", "Application_CompanyPosition");
tmap.ColumnMappings.Add("Application_CompanySector", "Application_CompanySector");
tmap.ColumnMappings.Add("Application_CompanyDepartment", "Application_CompanyDepartment");
tmap.ColumnMappings.Add("Application_IsAssessmentSessionAccepted", "Application_IsAssessmentSessionAccepted");
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Application] ([Application_ID], [Course_ID], [Application_Date], [Application_FullName], [Candidate_ID], [Application_DOB], [Application_Gender], [Application_Nationality], [Application_IdentificationNumber], [Application_Address1], [Application_Address2], [Application_Postcode], [Application_City], [Application_State], [Application_Email], [Application_FatherIdentification], [Application_MotherIdentification], [Application_CombinedHouseholdIncome], [Application_CurrentFieldOfStudy], [Application_University], [Application_CGPA], [Application_PQQualification], [Application_PGRegistrationNumber], [Application_PQStartDate], [Application_PQDeadline], [Application_RegisteredNextExam], [Application_NextExamSession], [TSP_ID], [Application_ScholarshipProvider], [Application_ScholarshipCost], [Application_IdentificationImage], [Application_BirthCertificateImage], [Application_AcademicTranscriptImage], [Application_PassportSizeImage], [Application_PQAcceptanceImage], [Application_DeclarationAgree], [Application_ConfirmReceiveMyPACNotice], [Application_ConfirmAgreeTermsAndCondition], [Application_Submitted], [Application_Deleted], [Application_Status], [Application_CreatedDate], [Application_UpdatedDate], [Application_CreatedBy], [Application_UpdatedBy], [Application_SubmittedDate], [Application_FatherName], [Application_MotherName], [Application_ContractType], [Application_PhonePrefix], [Application_PhoneNumber], [Application_MobilePhonePrefix], [Application_MobilePhoneNumber], [Application_FinalisedStatus], [Application_LOIssueDate], [Application_FinalisedDate], [Application_OverallStatus], [Application_OverallProgress], [Application_IntakeMonth], [Application_IntakeYear], [Country_ID], [Application_PQLevelStart], [Application_IdentificationFile], [Application_BirthCertificateFile], [Application_AcademicTranscriptFile], [Application_PassportSizeFile], [Application_PQAcceptanceFile], [Application_CurrentlyEmployed], [Application_CompanyName], [Application_CompanyContact], [Application_CompanyAddress], [Application_CompanyPosition], [Application_CompanySector], [Application_CompanyDepartment], [Application_IsAssessmentSessionAccepted], [Sponsor_ID]) VALUES (@Application_ID, @Course_ID, @Application_Date, @Application_FullName, @Candidate_ID, @Application_DOB, @Application_Gender, @Application_Nationality, @Application_IdentificationNumber, @Application_Address1, @Application_Address2, @Application_Postcode, @Application_City, @Application_State, @Application_Email, @Application_FatherIdentification, @Application_MotherIdentification, @Application_CombinedHouseholdIncome, @Application_CurrentFieldOfStudy, @Application_University, @Application_CGPA, @Application_PQQualification, @Application_PGRegistrationNumber, @Application_PQStartDate, @Application_PQDeadline, @Application_RegisteredNextExam, @Application_NextExamSession, @TSP_ID, @Application_ScholarshipProvider, @Application_ScholarshipCost, @Application_IdentificationImage, @Application_BirthCertificateImage, @Application_AcademicTranscriptImage, @Application_PassportSizeImage, @Application_PQAcceptanceImage, @Application_DeclarationAgree, @Application_ConfirmReceiveMyPACNotice, @Application_ConfirmAgreeTermsAndCondition, @Application_Submitted, @Application_Deleted, @Application_Status, @Application_CreatedDate, @Application_UpdatedDate, @Application_CreatedBy, @Application_UpdatedBy, @Application_SubmittedDate, @Application_FatherName, @Application_MotherName, @Application_ContractType, @Application_PhonePrefix, @Application_PhoneNumber, @Application_MobilePhonePrefix, @Application_MobilePhoneNumber, @Application_FinalisedStatus, @Application_LOIssueDate, @Application_FinalisedDate, @Application_OverallStatus, @Application_OverallProgress, @Application_IntakeMonth, @Application_IntakeYear, @Country_ID, @Application_PQLevelStart, @Application_IdentificationFile, @Application_BirthCertificateFile, @Application_AcademicTranscriptFile, @Application_PassportSizeFile, @Application_PQAcceptanceFile, @Application_CurrentlyEmployed, @Application_CompanyName, @Application_CompanyContact, @Application_CompanyAddress, @Application_CompanyPosition, @Application_CompanySector, @Application_CompanyDepartment, @Application_IsAssessmentSessionAccepted, @Sponsor_ID)");
adapter.InsertCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.InsertCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.InsertCommand.Parameters.Add("@Application_Date", SqlDbType.DateTime, 0, "Application_Date");
adapter.InsertCommand.Parameters.Add("@Application_FullName", SqlDbType.NVarChar, 0, "Application_FullName");
adapter.InsertCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.InsertCommand.Parameters.Add("@Application_DOB", SqlDbType.DateTime, 0, "Application_DOB");
adapter.InsertCommand.Parameters.Add("@Application_Gender", SqlDbType.SmallInt, 0, "Application_Gender");
adapter.InsertCommand.Parameters.Add("@Application_Nationality", SqlDbType.SmallInt, 0, "Application_Nationality");
adapter.InsertCommand.Parameters.Add("@Application_IdentificationNumber", SqlDbType.NVarChar, 0, "Application_IdentificationNumber");
adapter.InsertCommand.Parameters.Add("@Application_Address1", SqlDbType.NVarChar, 0, "Application_Address1");
adapter.InsertCommand.Parameters.Add("@Application_Address2", SqlDbType.NVarChar, 0, "Application_Address2");
adapter.InsertCommand.Parameters.Add("@Application_Postcode", SqlDbType.NVarChar, 0, "Application_Postcode");
adapter.InsertCommand.Parameters.Add("@Application_City", SqlDbType.NVarChar, 0, "Application_City");
adapter.InsertCommand.Parameters.Add("@Application_State", SqlDbType.NVarChar, 0, "Application_State");
adapter.InsertCommand.Parameters.Add("@Application_Email", SqlDbType.NVarChar, 0, "Application_Email");
adapter.InsertCommand.Parameters.Add("@Application_FatherIdentification", SqlDbType.NVarChar, 0, "Application_FatherIdentification");
adapter.InsertCommand.Parameters.Add("@Application_MotherIdentification", SqlDbType.NVarChar, 0, "Application_MotherIdentification");
adapter.InsertCommand.Parameters.Add("@Application_CombinedHouseholdIncome", SqlDbType.Decimal, 0, "Application_CombinedHouseholdIncome");
adapter.InsertCommand.Parameters.Add("@Application_CurrentFieldOfStudy", SqlDbType.NVarChar, 0, "Application_CurrentFieldOfStudy");
adapter.InsertCommand.Parameters.Add("@Application_University", SqlDbType.NVarChar, 0, "Application_University");
adapter.InsertCommand.Parameters.Add("@Application_CGPA", SqlDbType.NVarChar, 0, "Application_CGPA");
adapter.InsertCommand.Parameters.Add("@Application_PQQualification", SqlDbType.Bit, 0, "Application_PQQualification");
adapter.InsertCommand.Parameters.Add("@Application_PGRegistrationNumber", SqlDbType.NVarChar, 0, "Application_PGRegistrationNumber");
adapter.InsertCommand.Parameters.Add("@Application_PQStartDate", SqlDbType.DateTime, 0, "Application_PQStartDate");
adapter.InsertCommand.Parameters.Add("@Application_PQDeadline", SqlDbType.DateTime, 0, "Application_PQDeadline");
adapter.InsertCommand.Parameters.Add("@Application_RegisteredNextExam", SqlDbType.Bit, 0, "Application_RegisteredNextExam");
adapter.InsertCommand.Parameters.Add("@Application_NextExamSession", SqlDbType.DateTime, 0, "Application_NextExamSession");
adapter.InsertCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.InsertCommand.Parameters.Add("@Application_ScholarshipProvider", SqlDbType.NVarChar, 0, "Application_ScholarshipProvider");
adapter.InsertCommand.Parameters.Add("@Application_ScholarshipCost", SqlDbType.Decimal, 0, "Application_ScholarshipCost");
adapter.InsertCommand.Parameters.Add("@Application_IdentificationImage", SqlDbType.NVarChar, 0, "Application_IdentificationImage");
adapter.InsertCommand.Parameters.Add("@Application_BirthCertificateImage", SqlDbType.NVarChar, 0, "Application_BirthCertificateImage");
adapter.InsertCommand.Parameters.Add("@Application_AcademicTranscriptImage", SqlDbType.NVarChar, 0, "Application_AcademicTranscriptImage");
adapter.InsertCommand.Parameters.Add("@Application_PassportSizeImage", SqlDbType.NVarChar, 0, "Application_PassportSizeImage");
adapter.InsertCommand.Parameters.Add("@Application_PQAcceptanceImage", SqlDbType.NVarChar, 0, "Application_PQAcceptanceImage");
adapter.InsertCommand.Parameters.Add("@Application_DeclarationAgree", SqlDbType.Bit, 0, "Application_DeclarationAgree");
adapter.InsertCommand.Parameters.Add("@Application_ConfirmReceiveMyPACNotice", SqlDbType.Bit, 0, "Application_ConfirmReceiveMyPACNotice");
adapter.InsertCommand.Parameters.Add("@Application_ConfirmAgreeTermsAndCondition", SqlDbType.Bit, 0, "Application_ConfirmAgreeTermsAndCondition");
adapter.InsertCommand.Parameters.Add("@Application_Submitted", SqlDbType.Bit, 0, "Application_Submitted");
adapter.InsertCommand.Parameters.Add("@Application_Deleted", SqlDbType.Bit, 0, "Application_Deleted");
adapter.InsertCommand.Parameters.Add("@Application_Status", SqlDbType.SmallInt, 0, "Application_Status");
adapter.InsertCommand.Parameters.Add("@Application_CreatedDate", SqlDbType.DateTime, 0, "Application_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Application_UpdatedDate", SqlDbType.DateTime, 0, "Application_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Application_CreatedBy", SqlDbType.NVarChar, 0, "Application_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Application_UpdatedBy", SqlDbType.NVarChar, 0, "Application_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@Application_SubmittedDate", SqlDbType.DateTime, 0, "Application_SubmittedDate");
adapter.InsertCommand.Parameters.Add("@Application_FatherName", SqlDbType.NVarChar, 0, "Application_FatherName");
adapter.InsertCommand.Parameters.Add("@Application_MotherName", SqlDbType.NVarChar, 0, "Application_MotherName");
adapter.InsertCommand.Parameters.Add("@Application_ContractType", SqlDbType.SmallInt, 0, "Application_ContractType");
adapter.InsertCommand.Parameters.Add("@Application_PhonePrefix", SqlDbType.NVarChar, 0, "Application_PhonePrefix");
adapter.InsertCommand.Parameters.Add("@Application_PhoneNumber", SqlDbType.NVarChar, 0, "Application_PhoneNumber");
adapter.InsertCommand.Parameters.Add("@Application_MobilePhonePrefix", SqlDbType.NVarChar, 0, "Application_MobilePhonePrefix");
adapter.InsertCommand.Parameters.Add("@Application_MobilePhoneNumber", SqlDbType.NVarChar, 0, "Application_MobilePhoneNumber");
adapter.InsertCommand.Parameters.Add("@Application_FinalisedStatus", SqlDbType.SmallInt, 0, "Application_FinalisedStatus");
adapter.InsertCommand.Parameters.Add("@Application_LOIssueDate", SqlDbType.DateTime, 0, "Application_LOIssueDate");
adapter.InsertCommand.Parameters.Add("@Application_FinalisedDate", SqlDbType.DateTime, 0, "Application_FinalisedDate");
adapter.InsertCommand.Parameters.Add("@Application_OverallStatus", SqlDbType.SmallInt, 0, "Application_OverallStatus");
adapter.InsertCommand.Parameters.Add("@Application_OverallProgress", SqlDbType.SmallInt, 0, "Application_OverallProgress");
adapter.InsertCommand.Parameters.Add("@Application_IntakeMonth", SqlDbType.Int, 0, "Application_IntakeMonth");
adapter.InsertCommand.Parameters.Add("@Application_IntakeYear", SqlDbType.Int, 0, "Application_IntakeYear");
adapter.InsertCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.InsertCommand.Parameters.Add("@Application_PQLevelStart", SqlDbType.NVarChar, 0, "Application_PQLevelStart");
adapter.InsertCommand.Parameters.Add("@Application_IdentificationFile", SqlDbType.NVarChar, 0, "Application_IdentificationFile");
adapter.InsertCommand.Parameters.Add("@Application_BirthCertificateFile", SqlDbType.NVarChar, 0, "Application_BirthCertificateFile");
adapter.InsertCommand.Parameters.Add("@Application_AcademicTranscriptFile", SqlDbType.NVarChar, 0, "Application_AcademicTranscriptFile");
adapter.InsertCommand.Parameters.Add("@Application_PassportSizeFile", SqlDbType.NVarChar, 0, "Application_PassportSizeFile");
adapter.InsertCommand.Parameters.Add("@Application_PQAcceptanceFile", SqlDbType.NVarChar, 0, "Application_PQAcceptanceFile");
adapter.InsertCommand.Parameters.Add("@Application_CurrentlyEmployed", SqlDbType.Bit, 0, "Application_CurrentlyEmployed");
adapter.InsertCommand.Parameters.Add("@Application_CompanyName", SqlDbType.NVarChar, 0, "Application_CompanyName");
adapter.InsertCommand.Parameters.Add("@Application_CompanyContact", SqlDbType.NVarChar, 0, "Application_CompanyContact");
adapter.InsertCommand.Parameters.Add("@Application_CompanyAddress", SqlDbType.NVarChar, 0, "Application_CompanyAddress");
adapter.InsertCommand.Parameters.Add("@Application_CompanyPosition", SqlDbType.NVarChar, 0, "Application_CompanyPosition");
adapter.InsertCommand.Parameters.Add("@Application_CompanySector", SqlDbType.NVarChar, 0, "Application_CompanySector");
adapter.InsertCommand.Parameters.Add("@Application_CompanyDepartment", SqlDbType.NVarChar, 0, "Application_CompanyDepartment");
adapter.InsertCommand.Parameters.Add("@Application_IsAssessmentSessionAccepted", SqlDbType.Bit, 0, "Application_IsAssessmentSessionAccepted");
adapter.InsertCommand.Parameters.Add("@Sponsor_ID", SqlDbType.UniqueIdentifier, 0, "Sponsor_ID");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Application] SET [Application_ID] = @Application_ID, [Course_ID] = @Course_ID, [Application_Date] = @Application_Date, [Application_FullName] = @Application_FullName, [Candidate_ID] = @Candidate_ID, [Application_DOB] = @Application_DOB, [Application_Gender] = @Application_Gender, [Application_Nationality] = @Application_Nationality, [Application_IdentificationNumber] = @Application_IdentificationNumber, [Application_Address1] = @Application_Address1, [Application_Address2] = @Application_Address2, [Application_Postcode] = @Application_Postcode, [Application_City] = @Application_City, [Application_State] = @Application_State, [Application_Email] = @Application_Email, [Application_FatherIdentification] = @Application_FatherIdentification, [Application_MotherIdentification] = @Application_MotherIdentification, [Application_CombinedHouseholdIncome] = @Application_CombinedHouseholdIncome, [Application_CurrentFieldOfStudy] = @Application_CurrentFieldOfStudy, [Application_University] = @Application_University, [Application_CGPA] = @Application_CGPA, [Application_PQQualification] = @Application_PQQualification, [Application_PGRegistrationNumber] = @Application_PGRegistrationNumber, [Application_PQStartDate] = @Application_PQStartDate, [Application_PQDeadline] = @Application_PQDeadline, [Application_RegisteredNextExam] = @Application_RegisteredNextExam, [Application_NextExamSession] = @Application_NextExamSession, [TSP_ID] = @TSP_ID, [Application_ScholarshipProvider] = @Application_ScholarshipProvider, [Application_ScholarshipCost] = @Application_ScholarshipCost, [Application_IdentificationImage] = @Application_IdentificationImage, [Application_BirthCertificateImage] = @Application_BirthCertificateImage, [Application_AcademicTranscriptImage] = @Application_AcademicTranscriptImage, [Application_PassportSizeImage] = @Application_PassportSizeImage, [Application_PQAcceptanceImage] = @Application_PQAcceptanceImage, [Application_DeclarationAgree] = @Application_DeclarationAgree, [Application_ConfirmReceiveMyPACNotice] = @Application_ConfirmReceiveMyPACNotice, [Application_ConfirmAgreeTermsAndCondition] = @Application_ConfirmAgreeTermsAndCondition, [Application_Submitted] = @Application_Submitted, [Application_Deleted] = @Application_Deleted, [Application_Status] = @Application_Status, [Application_CreatedDate] = @Application_CreatedDate, [Application_UpdatedDate] = @Application_UpdatedDate, [Application_CreatedBy] = @Application_CreatedBy, [Application_UpdatedBy] = @Application_UpdatedBy, [Application_SubmittedDate] = @Application_SubmittedDate, [Application_FatherName] = @Application_FatherName, [Application_MotherName] = @Application_MotherName, [Application_ContractType] = @Application_ContractType, [Application_PhonePrefix] = @Application_PhonePrefix, [Application_PhoneNumber] = @Application_PhoneNumber, [Application_MobilePhonePrefix] = @Application_MobilePhonePrefix, [Application_MobilePhoneNumber] = @Application_MobilePhoneNumber, [Application_FinalisedStatus] = @Application_FinalisedStatus, [Application_LOIssueDate] = @Application_LOIssueDate, [Application_FinalisedDate] = @Application_FinalisedDate, [Application_OverallStatus] = @Application_OverallStatus, [Application_OverallProgress] = @Application_OverallProgress, [Application_IntakeMonth] = @Application_IntakeMonth, [Application_IntakeYear] = @Application_IntakeYear, [Country_ID] = @Country_ID, [Application_PQLevelStart] = @Application_PQLevelStart, [Application_IdentificationFile] = @Application_IdentificationFile, [Application_BirthCertificateFile] = @Application_BirthCertificateFile, [Application_AcademicTranscriptFile] = @Application_AcademicTranscriptFile, [Application_PassportSizeFile] = @Application_PassportSizeFile, [Application_PQAcceptanceFile] = @Application_PQAcceptanceFile, [Application_CurrentlyEmployed] = @Application_CurrentlyEmployed, [Application_CompanyName] = @Application_CompanyName, [Application_CompanyContact] = @Application_CompanyContact, [Application_CompanyAddress] = @Application_CompanyAddress, [Application_CompanyPosition] = @Application_CompanyPosition, [Application_CompanySector] = @Application_CompanySector, [Application_CompanyDepartment] = @Application_CompanyDepartment, [Application_IsAssessmentSessionAccepted] = @Application_IsAssessmentSessionAccepted, [Sponsor_ID] = @Sponsor_ID WHERE [Application_ID] = @o_Application_ID");
adapter.UpdateCommand.Parameters.Add("@Application_ID", SqlDbType.UniqueIdentifier, 0, "Application_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Application_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Application_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Course_ID", SqlDbType.UniqueIdentifier, 0, "Course_ID");
adapter.UpdateCommand.Parameters.Add("@Application_Date", SqlDbType.DateTime, 0, "Application_Date");
adapter.UpdateCommand.Parameters.Add("@Application_FullName", SqlDbType.NVarChar, 0, "Application_FullName");
adapter.UpdateCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.UpdateCommand.Parameters.Add("@Application_DOB", SqlDbType.DateTime, 0, "Application_DOB");
adapter.UpdateCommand.Parameters.Add("@Application_Gender", SqlDbType.SmallInt, 0, "Application_Gender");
adapter.UpdateCommand.Parameters.Add("@Application_Nationality", SqlDbType.SmallInt, 0, "Application_Nationality");
adapter.UpdateCommand.Parameters.Add("@Application_IdentificationNumber", SqlDbType.NVarChar, 0, "Application_IdentificationNumber");
adapter.UpdateCommand.Parameters.Add("@Application_Address1", SqlDbType.NVarChar, 0, "Application_Address1");
adapter.UpdateCommand.Parameters.Add("@Application_Address2", SqlDbType.NVarChar, 0, "Application_Address2");
adapter.UpdateCommand.Parameters.Add("@Application_Postcode", SqlDbType.NVarChar, 0, "Application_Postcode");
adapter.UpdateCommand.Parameters.Add("@Application_City", SqlDbType.NVarChar, 0, "Application_City");
adapter.UpdateCommand.Parameters.Add("@Application_State", SqlDbType.NVarChar, 0, "Application_State");
adapter.UpdateCommand.Parameters.Add("@Application_Email", SqlDbType.NVarChar, 0, "Application_Email");
adapter.UpdateCommand.Parameters.Add("@Application_FatherIdentification", SqlDbType.NVarChar, 0, "Application_FatherIdentification");
adapter.UpdateCommand.Parameters.Add("@Application_MotherIdentification", SqlDbType.NVarChar, 0, "Application_MotherIdentification");
adapter.UpdateCommand.Parameters.Add("@Application_CombinedHouseholdIncome", SqlDbType.Decimal, 0, "Application_CombinedHouseholdIncome");
adapter.UpdateCommand.Parameters.Add("@Application_CurrentFieldOfStudy", SqlDbType.NVarChar, 0, "Application_CurrentFieldOfStudy");
adapter.UpdateCommand.Parameters.Add("@Application_University", SqlDbType.NVarChar, 0, "Application_University");
adapter.UpdateCommand.Parameters.Add("@Application_CGPA", SqlDbType.NVarChar, 0, "Application_CGPA");
adapter.UpdateCommand.Parameters.Add("@Application_PQQualification", SqlDbType.Bit, 0, "Application_PQQualification");
adapter.UpdateCommand.Parameters.Add("@Application_PGRegistrationNumber", SqlDbType.NVarChar, 0, "Application_PGRegistrationNumber");
adapter.UpdateCommand.Parameters.Add("@Application_PQStartDate", SqlDbType.DateTime, 0, "Application_PQStartDate");
adapter.UpdateCommand.Parameters.Add("@Application_PQDeadline", SqlDbType.DateTime, 0, "Application_PQDeadline");
adapter.UpdateCommand.Parameters.Add("@Application_RegisteredNextExam", SqlDbType.Bit, 0, "Application_RegisteredNextExam");
adapter.UpdateCommand.Parameters.Add("@Application_NextExamSession", SqlDbType.DateTime, 0, "Application_NextExamSession");
adapter.UpdateCommand.Parameters.Add("@TSP_ID", SqlDbType.UniqueIdentifier, 0, "TSP_ID");
adapter.UpdateCommand.Parameters.Add("@Application_ScholarshipProvider", SqlDbType.NVarChar, 0, "Application_ScholarshipProvider");
adapter.UpdateCommand.Parameters.Add("@Application_ScholarshipCost", SqlDbType.Decimal, 0, "Application_ScholarshipCost");
adapter.UpdateCommand.Parameters.Add("@Application_IdentificationImage", SqlDbType.NVarChar, 0, "Application_IdentificationImage");
adapter.UpdateCommand.Parameters.Add("@Application_BirthCertificateImage", SqlDbType.NVarChar, 0, "Application_BirthCertificateImage");
adapter.UpdateCommand.Parameters.Add("@Application_AcademicTranscriptImage", SqlDbType.NVarChar, 0, "Application_AcademicTranscriptImage");
adapter.UpdateCommand.Parameters.Add("@Application_PassportSizeImage", SqlDbType.NVarChar, 0, "Application_PassportSizeImage");
adapter.UpdateCommand.Parameters.Add("@Application_PQAcceptanceImage", SqlDbType.NVarChar, 0, "Application_PQAcceptanceImage");
adapter.UpdateCommand.Parameters.Add("@Application_DeclarationAgree", SqlDbType.Bit, 0, "Application_DeclarationAgree");
adapter.UpdateCommand.Parameters.Add("@Application_ConfirmReceiveMyPACNotice", SqlDbType.Bit, 0, "Application_ConfirmReceiveMyPACNotice");
adapter.UpdateCommand.Parameters.Add("@Application_ConfirmAgreeTermsAndCondition", SqlDbType.Bit, 0, "Application_ConfirmAgreeTermsAndCondition");
adapter.UpdateCommand.Parameters.Add("@Application_Submitted", SqlDbType.Bit, 0, "Application_Submitted");
adapter.UpdateCommand.Parameters.Add("@Application_Deleted", SqlDbType.Bit, 0, "Application_Deleted");
adapter.UpdateCommand.Parameters.Add("@Application_Status", SqlDbType.SmallInt, 0, "Application_Status");
adapter.UpdateCommand.Parameters.Add("@Application_CreatedDate", SqlDbType.DateTime, 0, "Application_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Application_UpdatedDate", SqlDbType.DateTime, 0, "Application_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Application_CreatedBy", SqlDbType.NVarChar, 0, "Application_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Application_UpdatedBy", SqlDbType.NVarChar, 0, "Application_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@Application_SubmittedDate", SqlDbType.DateTime, 0, "Application_SubmittedDate");
adapter.UpdateCommand.Parameters.Add("@Application_FatherName", SqlDbType.NVarChar, 0, "Application_FatherName");
adapter.UpdateCommand.Parameters.Add("@Application_MotherName", SqlDbType.NVarChar, 0, "Application_MotherName");
adapter.UpdateCommand.Parameters.Add("@Application_ContractType", SqlDbType.SmallInt, 0, "Application_ContractType");
adapter.UpdateCommand.Parameters.Add("@Application_PhonePrefix", SqlDbType.NVarChar, 0, "Application_PhonePrefix");
adapter.UpdateCommand.Parameters.Add("@Application_PhoneNumber", SqlDbType.NVarChar, 0, "Application_PhoneNumber");
adapter.UpdateCommand.Parameters.Add("@Application_MobilePhonePrefix", SqlDbType.NVarChar, 0, "Application_MobilePhonePrefix");
adapter.UpdateCommand.Parameters.Add("@Application_MobilePhoneNumber", SqlDbType.NVarChar, 0, "Application_MobilePhoneNumber");
adapter.UpdateCommand.Parameters.Add("@Application_FinalisedStatus", SqlDbType.SmallInt, 0, "Application_FinalisedStatus");
adapter.UpdateCommand.Parameters.Add("@Application_LOIssueDate", SqlDbType.DateTime, 0, "Application_LOIssueDate");
adapter.UpdateCommand.Parameters.Add("@Application_FinalisedDate", SqlDbType.DateTime, 0, "Application_FinalisedDate");
adapter.UpdateCommand.Parameters.Add("@Application_OverallStatus", SqlDbType.SmallInt, 0, "Application_OverallStatus");
adapter.UpdateCommand.Parameters.Add("@Application_OverallProgress", SqlDbType.SmallInt, 0, "Application_OverallProgress");
adapter.UpdateCommand.Parameters.Add("@Application_IntakeMonth", SqlDbType.Int, 0, "Application_IntakeMonth");
adapter.UpdateCommand.Parameters.Add("@Application_IntakeYear", SqlDbType.Int, 0, "Application_IntakeYear");
adapter.UpdateCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.UpdateCommand.Parameters.Add("@Application_PQLevelStart", SqlDbType.NVarChar, 0, "Application_PQLevelStart");
adapter.UpdateCommand.Parameters.Add("@Application_IdentificationFile", SqlDbType.NVarChar, 0, "Application_IdentificationFile");
adapter.UpdateCommand.Parameters.Add("@Application_BirthCertificateFile", SqlDbType.NVarChar, 0, "Application_BirthCertificateFile");
adapter.UpdateCommand.Parameters.Add("@Application_AcademicTranscriptFile", SqlDbType.NVarChar, 0, "Application_AcademicTranscriptFile");
adapter.UpdateCommand.Parameters.Add("@Application_PassportSizeFile", SqlDbType.NVarChar, 0, "Application_PassportSizeFile");
adapter.UpdateCommand.Parameters.Add("@Application_PQAcceptanceFile", SqlDbType.NVarChar, 0, "Application_PQAcceptanceFile");
adapter.UpdateCommand.Parameters.Add("@Application_CurrentlyEmployed", SqlDbType.Bit, 0, "Application_CurrentlyEmployed");
adapter.UpdateCommand.Parameters.Add("@Application_CompanyName", SqlDbType.NVarChar, 0, "Application_CompanyName");
adapter.UpdateCommand.Parameters.Add("@Application_CompanyContact", SqlDbType.NVarChar, 0, "Application_CompanyContact");
adapter.UpdateCommand.Parameters.Add("@Application_CompanyAddress", SqlDbType.NVarChar, 0, "Application_CompanyAddress");
adapter.UpdateCommand.Parameters.Add("@Application_CompanyPosition", SqlDbType.NVarChar, 0, "Application_CompanyPosition");
adapter.UpdateCommand.Parameters.Add("@Application_CompanySector", SqlDbType.NVarChar, 0, "Application_CompanySector");
adapter.UpdateCommand.Parameters.Add("@Application_CompanyDepartment", SqlDbType.NVarChar, 0, "Application_CompanyDepartment");
adapter.UpdateCommand.Parameters.Add("@Application_IsAssessmentSessionAccepted", SqlDbType.Bit, 0, "Application_IsAssessmentSessionAccepted");
adapter.UpdateCommand.Parameters.Add("@Sponsor_ID", SqlDbType.UniqueIdentifier, 0, "Sponsor_ID");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Application] WHERE [Application_ID] = @o_Application_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Application_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Application_ID", DataRowVersion.Original, null));
}
public void Update(ApplicationTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(ApplicationRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public ApplicationRow GetByApplication_ID(System.Guid Application_ID ) {
string sql = "SELECT * FROM [Application] WHERE [Application_ID] = @Application_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Application_ID", Application_ID);

ApplicationTable tbl = new ApplicationTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetApplicationRow(0);
}
public int CountByApplication_ID(System.Guid Application_ID ) {
string sql = "SELECT COUNT(*) FROM [Application] WHERE [Application_ID] = @Application_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Application_ID", Application_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByApplication_ID(System.Guid Application_ID, IActivityLog log ) {
string sql = "DELETE FROM [Application] WHERE [Application_ID] = @Application_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Application_ID", Application_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
public ApplicationTable GetByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Application] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
ApplicationTable tbl = new ApplicationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCourse_ID(System.Guid Course_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Application] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCourse_ID(System.Guid Course_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Application] WHERE [Course_ID] = @Course_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Course_ID", Course_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public ApplicationTable GetByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Application] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
ApplicationTable tbl = new ApplicationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByCandidate_ID(System.Guid Candidate_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Application] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByCandidate_ID(System.Guid Candidate_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Application] WHERE [Candidate_ID] = @Candidate_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
public ApplicationTable GetByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT * FROM [Application] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
ApplicationTable tbl = new ApplicationTable();
DA.ExecuteQuery(fcom, tbl);
return tbl;
}
public int CountByTSP_ID(System.Guid TSP_ID ) {
SqlCommand fcom = new SqlCommand();
string sql = "SELECT COUNT(*) FROM [Application] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
return DA.ExecuteInt32(fcom);
}
public int DeleteByTSP_ID(System.Guid TSP_ID, IActivityLog log ) {
SqlCommand fcom = new SqlCommand();
string sql = "DELETE FROM [Application] WHERE [TSP_ID] = @TSP_ID";
fcom.CommandText = sql;
fcom.Parameters.AddWithValue("TSP_ID", TSP_ID);
if(log!=null) log.AddTransaction(fcom);
return DA.ExecuteNonQuery(fcom);
}
}
}
