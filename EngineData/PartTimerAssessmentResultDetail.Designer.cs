using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class PartTimerAssessmentResultDetailTable : DataTable {
// column indexes
public const int AssessmentResult_ExpectedEnrollmentDateColumnIndex = 0;
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
public const int PartTimerAssessmentResult_IDColumnIndex = 62;
public const int Application_IDColumnIndex = 63;
public const int PartTimerAssessmentResult_Assessment1ColumnIndex = 64;
public const int PartTimerAssessmentResult_Assessment2ColumnIndex = 65;
public const int PartTimerAssessmentResult_Assessment3ColumnIndex = 66;
public const int PartTimerAssessmentResult_AttendanceColumnIndex = 67;
public const int PartTimerAssessmentResult_StatusColumnIndex = 68;
public const int PartTimerAssessmentResult_CreatedDateColumnIndex = 69;
public const int PartTimerAssessmentResult_CreatedByColumnIndex = 70;
public const int PartTimerAssessmentResult_UpdatedByColumnIndex = 71;
public const int PartTimerAssessmentResult_UpdatedDateColumnIndex = 72;
public const int PartTimerAssessmentResult_IsDeletedColumnIndex = 73;
public const int PartTimerAssessmentResult_RemarkColumnIndex = 74;
public const int PartTimerAssessmentResult_InterviewResultColumnIndex = 75;
public const int PartTimerAssessmentResult_InterviewLocationColumnIndex = 76;
public const int Sponsor_CodeColumnIndex = 77;
public const int Sponsor_LabelColumnIndex = 78;
public const int Sponsor_IDColumnIndex = 79;
public PartTimerAssessmentResultDetailTable() {
TableName = "[PartTimerAssessmentResultDetail]";
// column AssessmentResult_ExpectedEnrollmentDate
DataColumn AssessmentResult_ExpectedEnrollmentDateCol = new DataColumn("AssessmentResult_ExpectedEnrollmentDate", typeof(System.DateTime));
AssessmentResult_ExpectedEnrollmentDateCol.DateTimeMode = DataSetDateTime.Local;
AssessmentResult_ExpectedEnrollmentDateCol.ReadOnly = true;
AssessmentResult_ExpectedEnrollmentDateCol.AllowDBNull = false;
Columns.Add(AssessmentResult_ExpectedEnrollmentDateCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Application_Date
DataColumn Application_DateCol = new DataColumn("Application_Date", typeof(System.DateTime));
Application_DateCol.DateTimeMode = DataSetDateTime.Local;
Application_DateCol.ReadOnly = true;
Application_DateCol.AllowDBNull = false;
Columns.Add(Application_DateCol);
// column Application_FullName
DataColumn Application_FullNameCol = new DataColumn("Application_FullName", typeof(System.String));
Application_FullNameCol.ReadOnly = true;
Application_FullNameCol.AllowDBNull = false;
Columns.Add(Application_FullNameCol);
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = true;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Application_DOB
DataColumn Application_DOBCol = new DataColumn("Application_DOB", typeof(System.DateTime));
Application_DOBCol.DateTimeMode = DataSetDateTime.Local;
Application_DOBCol.ReadOnly = true;
Application_DOBCol.AllowDBNull = false;
Columns.Add(Application_DOBCol);
// column Application_Gender
DataColumn Application_GenderCol = new DataColumn("Application_Gender", typeof(System.Int16));
Application_GenderCol.ReadOnly = true;
Application_GenderCol.AllowDBNull = false;
Columns.Add(Application_GenderCol);
// column Application_Nationality
DataColumn Application_NationalityCol = new DataColumn("Application_Nationality", typeof(System.Int16));
Application_NationalityCol.ReadOnly = true;
Application_NationalityCol.AllowDBNull = false;
Columns.Add(Application_NationalityCol);
// column Application_IdentificationNumber
DataColumn Application_IdentificationNumberCol = new DataColumn("Application_IdentificationNumber", typeof(System.String));
Application_IdentificationNumberCol.ReadOnly = true;
Application_IdentificationNumberCol.AllowDBNull = false;
Columns.Add(Application_IdentificationNumberCol);
// column Application_Address1
DataColumn Application_Address1Col = new DataColumn("Application_Address1", typeof(System.String));
Application_Address1Col.ReadOnly = true;
Application_Address1Col.AllowDBNull = false;
Columns.Add(Application_Address1Col);
// column Application_Address2
DataColumn Application_Address2Col = new DataColumn("Application_Address2", typeof(System.String));
Application_Address2Col.ReadOnly = true;
Application_Address2Col.AllowDBNull = false;
Columns.Add(Application_Address2Col);
// column Application_Postcode
DataColumn Application_PostcodeCol = new DataColumn("Application_Postcode", typeof(System.String));
Application_PostcodeCol.ReadOnly = true;
Application_PostcodeCol.AllowDBNull = false;
Columns.Add(Application_PostcodeCol);
// column Application_City
DataColumn Application_CityCol = new DataColumn("Application_City", typeof(System.String));
Application_CityCol.ReadOnly = true;
Application_CityCol.AllowDBNull = false;
Columns.Add(Application_CityCol);
// column Application_State
DataColumn Application_StateCol = new DataColumn("Application_State", typeof(System.String));
Application_StateCol.ReadOnly = true;
Application_StateCol.AllowDBNull = false;
Columns.Add(Application_StateCol);
// column Application_Email
DataColumn Application_EmailCol = new DataColumn("Application_Email", typeof(System.String));
Application_EmailCol.ReadOnly = true;
Application_EmailCol.AllowDBNull = false;
Columns.Add(Application_EmailCol);
// column Application_FatherIdentification
DataColumn Application_FatherIdentificationCol = new DataColumn("Application_FatherIdentification", typeof(System.String));
Application_FatherIdentificationCol.ReadOnly = true;
Application_FatherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_FatherIdentificationCol);
// column Application_MotherIdentification
DataColumn Application_MotherIdentificationCol = new DataColumn("Application_MotherIdentification", typeof(System.String));
Application_MotherIdentificationCol.ReadOnly = true;
Application_MotherIdentificationCol.AllowDBNull = false;
Columns.Add(Application_MotherIdentificationCol);
// column Application_CombinedHouseholdIncome
DataColumn Application_CombinedHouseholdIncomeCol = new DataColumn("Application_CombinedHouseholdIncome", typeof(System.Decimal));
Application_CombinedHouseholdIncomeCol.ReadOnly = true;
Application_CombinedHouseholdIncomeCol.AllowDBNull = false;
Columns.Add(Application_CombinedHouseholdIncomeCol);
// column Application_CurrentFieldOfStudy
DataColumn Application_CurrentFieldOfStudyCol = new DataColumn("Application_CurrentFieldOfStudy", typeof(System.String));
Application_CurrentFieldOfStudyCol.ReadOnly = true;
Application_CurrentFieldOfStudyCol.AllowDBNull = false;
Columns.Add(Application_CurrentFieldOfStudyCol);
// column Application_University
DataColumn Application_UniversityCol = new DataColumn("Application_University", typeof(System.String));
Application_UniversityCol.ReadOnly = true;
Application_UniversityCol.AllowDBNull = false;
Columns.Add(Application_UniversityCol);
// column Application_CGPA
DataColumn Application_CGPACol = new DataColumn("Application_CGPA", typeof(System.String));
Application_CGPACol.ReadOnly = true;
Application_CGPACol.AllowDBNull = false;
Columns.Add(Application_CGPACol);
// column Application_PQQualification
DataColumn Application_PQQualificationCol = new DataColumn("Application_PQQualification", typeof(System.Boolean));
Application_PQQualificationCol.ReadOnly = true;
Application_PQQualificationCol.AllowDBNull = false;
Columns.Add(Application_PQQualificationCol);
// column Application_PGRegistrationNumber
DataColumn Application_PGRegistrationNumberCol = new DataColumn("Application_PGRegistrationNumber", typeof(System.String));
Application_PGRegistrationNumberCol.ReadOnly = true;
Application_PGRegistrationNumberCol.AllowDBNull = false;
Columns.Add(Application_PGRegistrationNumberCol);
// column Application_PQStartDate
DataColumn Application_PQStartDateCol = new DataColumn("Application_PQStartDate", typeof(System.DateTime));
Application_PQStartDateCol.DateTimeMode = DataSetDateTime.Local;
Application_PQStartDateCol.ReadOnly = true;
Application_PQStartDateCol.AllowDBNull = false;
Columns.Add(Application_PQStartDateCol);
// column Application_PQDeadline
DataColumn Application_PQDeadlineCol = new DataColumn("Application_PQDeadline", typeof(System.DateTime));
Application_PQDeadlineCol.DateTimeMode = DataSetDateTime.Local;
Application_PQDeadlineCol.ReadOnly = true;
Application_PQDeadlineCol.AllowDBNull = false;
Columns.Add(Application_PQDeadlineCol);
// column Application_RegisteredNextExam
DataColumn Application_RegisteredNextExamCol = new DataColumn("Application_RegisteredNextExam", typeof(System.Boolean));
Application_RegisteredNextExamCol.ReadOnly = true;
Application_RegisteredNextExamCol.AllowDBNull = false;
Columns.Add(Application_RegisteredNextExamCol);
// column Application_NextExamSession
DataColumn Application_NextExamSessionCol = new DataColumn("Application_NextExamSession", typeof(System.DateTime));
Application_NextExamSessionCol.DateTimeMode = DataSetDateTime.Local;
Application_NextExamSessionCol.ReadOnly = true;
Application_NextExamSessionCol.AllowDBNull = false;
Columns.Add(Application_NextExamSessionCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = true;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Application_ScholarshipProvider
DataColumn Application_ScholarshipProviderCol = new DataColumn("Application_ScholarshipProvider", typeof(System.String));
Application_ScholarshipProviderCol.ReadOnly = true;
Application_ScholarshipProviderCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipProviderCol);
// column Application_ScholarshipCost
DataColumn Application_ScholarshipCostCol = new DataColumn("Application_ScholarshipCost", typeof(System.Decimal));
Application_ScholarshipCostCol.ReadOnly = true;
Application_ScholarshipCostCol.AllowDBNull = false;
Columns.Add(Application_ScholarshipCostCol);
// column Application_IdentificationImage
DataColumn Application_IdentificationImageCol = new DataColumn("Application_IdentificationImage", typeof(System.String));
Application_IdentificationImageCol.ReadOnly = true;
Application_IdentificationImageCol.AllowDBNull = false;
Columns.Add(Application_IdentificationImageCol);
// column Application_BirthCertificateImage
DataColumn Application_BirthCertificateImageCol = new DataColumn("Application_BirthCertificateImage", typeof(System.String));
Application_BirthCertificateImageCol.ReadOnly = true;
Application_BirthCertificateImageCol.AllowDBNull = false;
Columns.Add(Application_BirthCertificateImageCol);
// column Application_AcademicTranscriptImage
DataColumn Application_AcademicTranscriptImageCol = new DataColumn("Application_AcademicTranscriptImage", typeof(System.String));
Application_AcademicTranscriptImageCol.ReadOnly = true;
Application_AcademicTranscriptImageCol.AllowDBNull = false;
Columns.Add(Application_AcademicTranscriptImageCol);
// column Application_PassportSizeImage
DataColumn Application_PassportSizeImageCol = new DataColumn("Application_PassportSizeImage", typeof(System.String));
Application_PassportSizeImageCol.ReadOnly = true;
Application_PassportSizeImageCol.AllowDBNull = false;
Columns.Add(Application_PassportSizeImageCol);
// column Application_PQAcceptanceImage
DataColumn Application_PQAcceptanceImageCol = new DataColumn("Application_PQAcceptanceImage", typeof(System.String));
Application_PQAcceptanceImageCol.ReadOnly = true;
Application_PQAcceptanceImageCol.AllowDBNull = false;
Columns.Add(Application_PQAcceptanceImageCol);
// column Application_DeclarationAgree
DataColumn Application_DeclarationAgreeCol = new DataColumn("Application_DeclarationAgree", typeof(System.Boolean));
Application_DeclarationAgreeCol.ReadOnly = true;
Application_DeclarationAgreeCol.AllowDBNull = false;
Columns.Add(Application_DeclarationAgreeCol);
// column Application_ConfirmReceiveMyPACNotice
DataColumn Application_ConfirmReceiveMyPACNoticeCol = new DataColumn("Application_ConfirmReceiveMyPACNotice", typeof(System.Boolean));
Application_ConfirmReceiveMyPACNoticeCol.ReadOnly = true;
Application_ConfirmReceiveMyPACNoticeCol.AllowDBNull = false;
Columns.Add(Application_ConfirmReceiveMyPACNoticeCol);
// column Application_ConfirmAgreeTermsAndCondition
DataColumn Application_ConfirmAgreeTermsAndConditionCol = new DataColumn("Application_ConfirmAgreeTermsAndCondition", typeof(System.Boolean));
Application_ConfirmAgreeTermsAndConditionCol.ReadOnly = true;
Application_ConfirmAgreeTermsAndConditionCol.AllowDBNull = false;
Columns.Add(Application_ConfirmAgreeTermsAndConditionCol);
// column Application_Submitted
DataColumn Application_SubmittedCol = new DataColumn("Application_Submitted", typeof(System.Boolean));
Application_SubmittedCol.ReadOnly = true;
Application_SubmittedCol.AllowDBNull = false;
Columns.Add(Application_SubmittedCol);
// column Application_Deleted
DataColumn Application_DeletedCol = new DataColumn("Application_Deleted", typeof(System.Boolean));
Application_DeletedCol.ReadOnly = true;
Application_DeletedCol.AllowDBNull = false;
Columns.Add(Application_DeletedCol);
// column Application_Status
DataColumn Application_StatusCol = new DataColumn("Application_Status", typeof(System.Int16));
Application_StatusCol.ReadOnly = true;
Application_StatusCol.AllowDBNull = false;
Columns.Add(Application_StatusCol);
// column Application_CreatedDate
DataColumn Application_CreatedDateCol = new DataColumn("Application_CreatedDate", typeof(System.DateTime));
Application_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_CreatedDateCol.ReadOnly = true;
Application_CreatedDateCol.AllowDBNull = false;
Columns.Add(Application_CreatedDateCol);
// column Application_UpdatedDate
DataColumn Application_UpdatedDateCol = new DataColumn("Application_UpdatedDate", typeof(System.DateTime));
Application_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_UpdatedDateCol.ReadOnly = true;
Application_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Application_UpdatedDateCol);
// column Application_CreatedBy
DataColumn Application_CreatedByCol = new DataColumn("Application_CreatedBy", typeof(System.String));
Application_CreatedByCol.ReadOnly = true;
Application_CreatedByCol.AllowDBNull = false;
Columns.Add(Application_CreatedByCol);
// column Application_UpdatedBy
DataColumn Application_UpdatedByCol = new DataColumn("Application_UpdatedBy", typeof(System.String));
Application_UpdatedByCol.ReadOnly = true;
Application_UpdatedByCol.AllowDBNull = false;
Columns.Add(Application_UpdatedByCol);
// column Application_SubmittedDate
DataColumn Application_SubmittedDateCol = new DataColumn("Application_SubmittedDate", typeof(System.DateTime));
Application_SubmittedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_SubmittedDateCol.ReadOnly = true;
Application_SubmittedDateCol.AllowDBNull = false;
Columns.Add(Application_SubmittedDateCol);
// column Application_FatherName
DataColumn Application_FatherNameCol = new DataColumn("Application_FatherName", typeof(System.String));
Application_FatherNameCol.ReadOnly = true;
Application_FatherNameCol.AllowDBNull = false;
Columns.Add(Application_FatherNameCol);
// column Application_MotherName
DataColumn Application_MotherNameCol = new DataColumn("Application_MotherName", typeof(System.String));
Application_MotherNameCol.ReadOnly = true;
Application_MotherNameCol.AllowDBNull = false;
Columns.Add(Application_MotherNameCol);
// column Application_ContractType
DataColumn Application_ContractTypeCol = new DataColumn("Application_ContractType", typeof(System.Int16));
Application_ContractTypeCol.ReadOnly = true;
Application_ContractTypeCol.AllowDBNull = false;
Columns.Add(Application_ContractTypeCol);
// column Application_PhonePrefix
DataColumn Application_PhonePrefixCol = new DataColumn("Application_PhonePrefix", typeof(System.String));
Application_PhonePrefixCol.ReadOnly = true;
Application_PhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_PhonePrefixCol);
// column Application_PhoneNumber
DataColumn Application_PhoneNumberCol = new DataColumn("Application_PhoneNumber", typeof(System.String));
Application_PhoneNumberCol.ReadOnly = true;
Application_PhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_PhoneNumberCol);
// column Application_MobilePhonePrefix
DataColumn Application_MobilePhonePrefixCol = new DataColumn("Application_MobilePhonePrefix", typeof(System.String));
Application_MobilePhonePrefixCol.ReadOnly = true;
Application_MobilePhonePrefixCol.AllowDBNull = false;
Columns.Add(Application_MobilePhonePrefixCol);
// column Application_MobilePhoneNumber
DataColumn Application_MobilePhoneNumberCol = new DataColumn("Application_MobilePhoneNumber", typeof(System.String));
Application_MobilePhoneNumberCol.ReadOnly = true;
Application_MobilePhoneNumberCol.AllowDBNull = false;
Columns.Add(Application_MobilePhoneNumberCol);
// column Application_FinalisedStatus
DataColumn Application_FinalisedStatusCol = new DataColumn("Application_FinalisedStatus", typeof(System.Int16));
Application_FinalisedStatusCol.ReadOnly = true;
Application_FinalisedStatusCol.AllowDBNull = false;
Columns.Add(Application_FinalisedStatusCol);
// column Application_LOIssueDate
DataColumn Application_LOIssueDateCol = new DataColumn("Application_LOIssueDate", typeof(System.DateTime));
Application_LOIssueDateCol.DateTimeMode = DataSetDateTime.Local;
Application_LOIssueDateCol.ReadOnly = true;
Application_LOIssueDateCol.AllowDBNull = false;
Columns.Add(Application_LOIssueDateCol);
// column Application_FinalisedDate
DataColumn Application_FinalisedDateCol = new DataColumn("Application_FinalisedDate", typeof(System.DateTime));
Application_FinalisedDateCol.DateTimeMode = DataSetDateTime.Local;
Application_FinalisedDateCol.ReadOnly = true;
Application_FinalisedDateCol.AllowDBNull = false;
Columns.Add(Application_FinalisedDateCol);
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
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = true;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Application_PQLevelStart
DataColumn Application_PQLevelStartCol = new DataColumn("Application_PQLevelStart", typeof(System.String));
Application_PQLevelStartCol.ReadOnly = true;
Application_PQLevelStartCol.AllowDBNull = false;
Columns.Add(Application_PQLevelStartCol);
// column PartTimerAssessmentResult_ID
DataColumn PartTimerAssessmentResult_IDCol = new DataColumn("PartTimerAssessmentResult_ID", typeof(System.Guid));
PartTimerAssessmentResult_IDCol.ReadOnly = true;
PartTimerAssessmentResult_IDCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_IDCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = true;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column PartTimerAssessmentResult_Assessment1
DataColumn PartTimerAssessmentResult_Assessment1Col = new DataColumn("PartTimerAssessmentResult_Assessment1", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment1Col.ReadOnly = true;
PartTimerAssessmentResult_Assessment1Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment1Col);
// column PartTimerAssessmentResult_Assessment2
DataColumn PartTimerAssessmentResult_Assessment2Col = new DataColumn("PartTimerAssessmentResult_Assessment2", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment2Col.ReadOnly = true;
PartTimerAssessmentResult_Assessment2Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment2Col);
// column PartTimerAssessmentResult_Assessment3
DataColumn PartTimerAssessmentResult_Assessment3Col = new DataColumn("PartTimerAssessmentResult_Assessment3", typeof(System.Decimal));
PartTimerAssessmentResult_Assessment3Col.ReadOnly = true;
PartTimerAssessmentResult_Assessment3Col.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_Assessment3Col);
// column PartTimerAssessmentResult_Attendance
DataColumn PartTimerAssessmentResult_AttendanceCol = new DataColumn("PartTimerAssessmentResult_Attendance", typeof(System.Decimal));
PartTimerAssessmentResult_AttendanceCol.ReadOnly = true;
PartTimerAssessmentResult_AttendanceCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_AttendanceCol);
// column PartTimerAssessmentResult_Status
DataColumn PartTimerAssessmentResult_StatusCol = new DataColumn("PartTimerAssessmentResult_Status", typeof(System.Int16));
PartTimerAssessmentResult_StatusCol.ReadOnly = true;
PartTimerAssessmentResult_StatusCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_StatusCol);
// column PartTimerAssessmentResult_CreatedDate
DataColumn PartTimerAssessmentResult_CreatedDateCol = new DataColumn("PartTimerAssessmentResult_CreatedDate", typeof(System.DateTime));
PartTimerAssessmentResult_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentResult_CreatedDateCol.ReadOnly = true;
PartTimerAssessmentResult_CreatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_CreatedDateCol);
// column PartTimerAssessmentResult_CreatedBy
DataColumn PartTimerAssessmentResult_CreatedByCol = new DataColumn("PartTimerAssessmentResult_CreatedBy", typeof(System.String));
PartTimerAssessmentResult_CreatedByCol.ReadOnly = true;
PartTimerAssessmentResult_CreatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_CreatedByCol);
// column PartTimerAssessmentResult_UpdatedBy
DataColumn PartTimerAssessmentResult_UpdatedByCol = new DataColumn("PartTimerAssessmentResult_UpdatedBy", typeof(System.String));
PartTimerAssessmentResult_UpdatedByCol.ReadOnly = true;
PartTimerAssessmentResult_UpdatedByCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_UpdatedByCol);
// column PartTimerAssessmentResult_UpdatedDate
DataColumn PartTimerAssessmentResult_UpdatedDateCol = new DataColumn("PartTimerAssessmentResult_UpdatedDate", typeof(System.DateTime));
PartTimerAssessmentResult_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
PartTimerAssessmentResult_UpdatedDateCol.ReadOnly = true;
PartTimerAssessmentResult_UpdatedDateCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_UpdatedDateCol);
// column PartTimerAssessmentResult_IsDeleted
DataColumn PartTimerAssessmentResult_IsDeletedCol = new DataColumn("PartTimerAssessmentResult_IsDeleted", typeof(System.Boolean));
PartTimerAssessmentResult_IsDeletedCol.ReadOnly = true;
PartTimerAssessmentResult_IsDeletedCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_IsDeletedCol);
// column PartTimerAssessmentResult_Remark
DataColumn PartTimerAssessmentResult_RemarkCol = new DataColumn("PartTimerAssessmentResult_Remark", typeof(System.String));
PartTimerAssessmentResult_RemarkCol.ReadOnly = true;
PartTimerAssessmentResult_RemarkCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_RemarkCol);
// column PartTimerAssessmentResult_InterviewResult
DataColumn PartTimerAssessmentResult_InterviewResultCol = new DataColumn("PartTimerAssessmentResult_InterviewResult", typeof(System.Int16));
PartTimerAssessmentResult_InterviewResultCol.ReadOnly = true;
PartTimerAssessmentResult_InterviewResultCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_InterviewResultCol);
// column PartTimerAssessmentResult_InterviewLocation
DataColumn PartTimerAssessmentResult_InterviewLocationCol = new DataColumn("PartTimerAssessmentResult_InterviewLocation", typeof(System.String));
PartTimerAssessmentResult_InterviewLocationCol.ReadOnly = true;
PartTimerAssessmentResult_InterviewLocationCol.AllowDBNull = false;
Columns.Add(PartTimerAssessmentResult_InterviewLocationCol);
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
// column Sponsor_ID
DataColumn Sponsor_IDCol = new DataColumn("Sponsor_ID", typeof(System.Guid));
Sponsor_IDCol.ReadOnly = true;
Sponsor_IDCol.AllowDBNull = false;
Columns.Add(Sponsor_IDCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new PartTimerAssessmentResultDetailRow(builder);
}
public PartTimerAssessmentResultDetailRow GetPartTimerAssessmentResultDetailRow(int index) {
return (PartTimerAssessmentResultDetailRow)Rows[index];
}
}
public partial class PartTimerAssessmentResultDetailRow : DataRow {
internal PartTimerAssessmentResultDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.DateTime AssessmentResult_ExpectedEnrollmentDate {
get {
return (System.DateTime)this["AssessmentResult_ExpectedEnrollmentDate"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
public System.DateTime Application_Date {
get {
return (System.DateTime)this["Application_Date"];
}
}
public System.String Application_FullName {
get {
return (System.String)this["Application_FullName"];
}
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
}
public System.DateTime Application_DOB {
get {
return (System.DateTime)this["Application_DOB"];
}
}
public System.Int16 Application_Gender {
get {
return (System.Int16)this["Application_Gender"];
}
}
public System.Int16 Application_Nationality {
get {
return (System.Int16)this["Application_Nationality"];
}
}
public System.String Application_IdentificationNumber {
get {
return (System.String)this["Application_IdentificationNumber"];
}
}
public System.String Application_Address1 {
get {
return (System.String)this["Application_Address1"];
}
}
public System.String Application_Address2 {
get {
return (System.String)this["Application_Address2"];
}
}
public System.String Application_Postcode {
get {
return (System.String)this["Application_Postcode"];
}
}
public System.String Application_City {
get {
return (System.String)this["Application_City"];
}
}
public System.String Application_State {
get {
return (System.String)this["Application_State"];
}
}
public System.String Application_Email {
get {
return (System.String)this["Application_Email"];
}
}
public System.String Application_FatherIdentification {
get {
return (System.String)this["Application_FatherIdentification"];
}
}
public System.String Application_MotherIdentification {
get {
return (System.String)this["Application_MotherIdentification"];
}
}
public System.Decimal Application_CombinedHouseholdIncome {
get {
return (System.Decimal)this["Application_CombinedHouseholdIncome"];
}
}
public System.String Application_CurrentFieldOfStudy {
get {
return (System.String)this["Application_CurrentFieldOfStudy"];
}
}
public System.String Application_University {
get {
return (System.String)this["Application_University"];
}
}
public System.String Application_CGPA {
get {
return (System.String)this["Application_CGPA"];
}
}
public System.Boolean Application_PQQualification {
get {
return (System.Boolean)this["Application_PQQualification"];
}
}
public System.String Application_PGRegistrationNumber {
get {
return (System.String)this["Application_PGRegistrationNumber"];
}
}
public System.DateTime Application_PQStartDate {
get {
return (System.DateTime)this["Application_PQStartDate"];
}
}
public System.DateTime Application_PQDeadline {
get {
return (System.DateTime)this["Application_PQDeadline"];
}
}
public System.Boolean Application_RegisteredNextExam {
get {
return (System.Boolean)this["Application_RegisteredNextExam"];
}
}
public System.DateTime Application_NextExamSession {
get {
return (System.DateTime)this["Application_NextExamSession"];
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
}
public System.String Application_ScholarshipProvider {
get {
return (System.String)this["Application_ScholarshipProvider"];
}
}
public System.Decimal Application_ScholarshipCost {
get {
return (System.Decimal)this["Application_ScholarshipCost"];
}
}
public System.String Application_IdentificationImage {
get {
return (System.String)this["Application_IdentificationImage"];
}
}
public System.String Application_BirthCertificateImage {
get {
return (System.String)this["Application_BirthCertificateImage"];
}
}
public System.String Application_AcademicTranscriptImage {
get {
return (System.String)this["Application_AcademicTranscriptImage"];
}
}
public System.String Application_PassportSizeImage {
get {
return (System.String)this["Application_PassportSizeImage"];
}
}
public System.String Application_PQAcceptanceImage {
get {
return (System.String)this["Application_PQAcceptanceImage"];
}
}
public System.Boolean Application_DeclarationAgree {
get {
return (System.Boolean)this["Application_DeclarationAgree"];
}
}
public System.Boolean Application_ConfirmReceiveMyPACNotice {
get {
return (System.Boolean)this["Application_ConfirmReceiveMyPACNotice"];
}
}
public System.Boolean Application_ConfirmAgreeTermsAndCondition {
get {
return (System.Boolean)this["Application_ConfirmAgreeTermsAndCondition"];
}
}
public System.Boolean Application_Submitted {
get {
return (System.Boolean)this["Application_Submitted"];
}
}
public System.Boolean Application_Deleted {
get {
return (System.Boolean)this["Application_Deleted"];
}
}
public System.Int16 Application_Status {
get {
return (System.Int16)this["Application_Status"];
}
}
public System.DateTime Application_CreatedDate {
get {
return (System.DateTime)this["Application_CreatedDate"];
}
}
public System.DateTime Application_UpdatedDate {
get {
return (System.DateTime)this["Application_UpdatedDate"];
}
}
public System.String Application_CreatedBy {
get {
return (System.String)this["Application_CreatedBy"];
}
}
public System.String Application_UpdatedBy {
get {
return (System.String)this["Application_UpdatedBy"];
}
}
public System.DateTime Application_SubmittedDate {
get {
return (System.DateTime)this["Application_SubmittedDate"];
}
}
public System.String Application_FatherName {
get {
return (System.String)this["Application_FatherName"];
}
}
public System.String Application_MotherName {
get {
return (System.String)this["Application_MotherName"];
}
}
public System.Int16 Application_ContractType {
get {
return (System.Int16)this["Application_ContractType"];
}
}
public System.String Application_PhonePrefix {
get {
return (System.String)this["Application_PhonePrefix"];
}
}
public System.String Application_PhoneNumber {
get {
return (System.String)this["Application_PhoneNumber"];
}
}
public System.String Application_MobilePhonePrefix {
get {
return (System.String)this["Application_MobilePhonePrefix"];
}
}
public System.String Application_MobilePhoneNumber {
get {
return (System.String)this["Application_MobilePhoneNumber"];
}
}
public System.Int16 Application_FinalisedStatus {
get {
return (System.Int16)this["Application_FinalisedStatus"];
}
}
public System.DateTime Application_LOIssueDate {
get {
return (System.DateTime)this["Application_LOIssueDate"];
}
}
public System.DateTime Application_FinalisedDate {
get {
return (System.DateTime)this["Application_FinalisedDate"];
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
public System.Guid Country_ID {
get {
return (System.Guid)this["Country_ID"];
}
}
public System.String Application_PQLevelStart {
get {
return (System.String)this["Application_PQLevelStart"];
}
}
public System.Guid PartTimerAssessmentResult_ID {
get {
return (System.Guid)this["PartTimerAssessmentResult_ID"];
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
}
public System.Decimal PartTimerAssessmentResult_Assessment1 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment1"];
}
}
public System.Decimal PartTimerAssessmentResult_Assessment2 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment2"];
}
}
public System.Decimal PartTimerAssessmentResult_Assessment3 {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Assessment3"];
}
}
public System.Decimal PartTimerAssessmentResult_Attendance {
get {
return (System.Decimal)this["PartTimerAssessmentResult_Attendance"];
}
}
public System.Int16 PartTimerAssessmentResult_Status {
get {
return (System.Int16)this["PartTimerAssessmentResult_Status"];
}
}
public System.DateTime PartTimerAssessmentResult_CreatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentResult_CreatedDate"];
}
}
public System.String PartTimerAssessmentResult_CreatedBy {
get {
return (System.String)this["PartTimerAssessmentResult_CreatedBy"];
}
}
public System.String PartTimerAssessmentResult_UpdatedBy {
get {
return (System.String)this["PartTimerAssessmentResult_UpdatedBy"];
}
}
public System.DateTime PartTimerAssessmentResult_UpdatedDate {
get {
return (System.DateTime)this["PartTimerAssessmentResult_UpdatedDate"];
}
}
public System.Boolean PartTimerAssessmentResult_IsDeleted {
get {
return (System.Boolean)this["PartTimerAssessmentResult_IsDeleted"];
}
}
public System.String PartTimerAssessmentResult_Remark {
get {
return (System.String)this["PartTimerAssessmentResult_Remark"];
}
}
public System.Int16 PartTimerAssessmentResult_InterviewResult {
get {
return (System.Int16)this["PartTimerAssessmentResult_InterviewResult"];
}
}
public System.String PartTimerAssessmentResult_InterviewLocation {
get {
return (System.String)this["PartTimerAssessmentResult_InterviewLocation"];
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
public System.Guid Sponsor_ID {
get {
return (System.Guid)this["Sponsor_ID"];
}
}
}
public partial class PartTimerAssessmentResultDetailMinimalizedEntity {
public PartTimerAssessmentResultDetailMinimalizedEntity() {}
public PartTimerAssessmentResultDetailMinimalizedEntity(PartTimerAssessmentResultDetailRow dr) {
this.AssessmentResult_ExpectedEnrollmentDate = dr.AssessmentResult_ExpectedEnrollmentDate;
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
this.PartTimerAssessmentResult_ID = dr.PartTimerAssessmentResult_ID;
this.Application_ID = dr.Application_ID;
this.PartTimerAssessmentResult_Assessment1 = dr.PartTimerAssessmentResult_Assessment1;
this.PartTimerAssessmentResult_Assessment2 = dr.PartTimerAssessmentResult_Assessment2;
this.PartTimerAssessmentResult_Assessment3 = dr.PartTimerAssessmentResult_Assessment3;
this.PartTimerAssessmentResult_Attendance = dr.PartTimerAssessmentResult_Attendance;
this.PartTimerAssessmentResult_Status = dr.PartTimerAssessmentResult_Status;
this.PartTimerAssessmentResult_CreatedDate = dr.PartTimerAssessmentResult_CreatedDate;
this.PartTimerAssessmentResult_CreatedBy = dr.PartTimerAssessmentResult_CreatedBy;
this.PartTimerAssessmentResult_UpdatedBy = dr.PartTimerAssessmentResult_UpdatedBy;
this.PartTimerAssessmentResult_UpdatedDate = dr.PartTimerAssessmentResult_UpdatedDate;
this.PartTimerAssessmentResult_IsDeleted = dr.PartTimerAssessmentResult_IsDeleted;
this.PartTimerAssessmentResult_Remark = dr.PartTimerAssessmentResult_Remark;
this.PartTimerAssessmentResult_InterviewResult = dr.PartTimerAssessmentResult_InterviewResult;
this.PartTimerAssessmentResult_InterviewLocation = dr.PartTimerAssessmentResult_InterviewLocation;
this.Sponsor_Code = dr.Sponsor_Code;
this.Sponsor_Label = dr.Sponsor_Label;
this.Sponsor_ID = dr.Sponsor_ID;
}
public System.DateTime AssessmentResult_ExpectedEnrollmentDate;
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
public System.Guid PartTimerAssessmentResult_ID;
public System.Guid Application_ID;
public System.Decimal PartTimerAssessmentResult_Assessment1;
public System.Decimal PartTimerAssessmentResult_Assessment2;
public System.Decimal PartTimerAssessmentResult_Assessment3;
public System.Decimal PartTimerAssessmentResult_Attendance;
public System.Int16 PartTimerAssessmentResult_Status;
public System.DateTime PartTimerAssessmentResult_CreatedDate;
public System.String PartTimerAssessmentResult_CreatedBy;
public System.String PartTimerAssessmentResult_UpdatedBy;
public System.DateTime PartTimerAssessmentResult_UpdatedDate;
public System.Boolean PartTimerAssessmentResult_IsDeleted;
public System.String PartTimerAssessmentResult_Remark;
public System.Int16 PartTimerAssessmentResult_InterviewResult;
public System.String PartTimerAssessmentResult_InterviewLocation;
public System.String Sponsor_Code;
public System.String Sponsor_Label;
public System.Guid Sponsor_ID;
}
public partial class PartTimerAssessmentResultDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public PartTimerAssessmentResultDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("AssessmentResult_ExpectedEnrollmentDate", "AssessmentResult_ExpectedEnrollmentDate");
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
tmap.ColumnMappings.Add("PartTimerAssessmentResult_ID", "PartTimerAssessmentResult_ID");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment1", "PartTimerAssessmentResult_Assessment1");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment2", "PartTimerAssessmentResult_Assessment2");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Assessment3", "PartTimerAssessmentResult_Assessment3");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Attendance", "PartTimerAssessmentResult_Attendance");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Status", "PartTimerAssessmentResult_Status");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_CreatedDate", "PartTimerAssessmentResult_CreatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_CreatedBy", "PartTimerAssessmentResult_CreatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_UpdatedBy", "PartTimerAssessmentResult_UpdatedBy");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_UpdatedDate", "PartTimerAssessmentResult_UpdatedDate");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_IsDeleted", "PartTimerAssessmentResult_IsDeleted");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_Remark", "PartTimerAssessmentResult_Remark");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_InterviewResult", "PartTimerAssessmentResult_InterviewResult");
tmap.ColumnMappings.Add("PartTimerAssessmentResult_InterviewLocation", "PartTimerAssessmentResult_InterviewLocation");
tmap.ColumnMappings.Add("Sponsor_Code", "Sponsor_Code");
tmap.ColumnMappings.Add("Sponsor_Label", "Sponsor_Label");
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
adapter.TableMappings.Add(tmap);
}
}
public PartTimerAssessmentResultDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [PartTimerAssessmentResultDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

PartTimerAssessmentResultDetailTable tbl = new PartTimerAssessmentResultDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetPartTimerAssessmentResultDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [PartTimerAssessmentResultDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
