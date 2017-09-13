using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CoachingDetailTable : DataTable {
// column indexes
public const int Coaching_IDColumnIndex = 0;
public const int Coaching_DescriptionColumnIndex = 1;
public const int StudentCourse_IDColumnIndex = 2;
public const int Coaching_RemarkColumnIndex = 3;
public const int Coaching_DateColumnIndex = 4;
public const int Coaching_IsDeletedColumnIndex = 5;
public const int Coaching_StatusColumnIndex = 6;
public const int Coaching_CreatedDateColumnIndex = 7;
public const int Coaching_CreatedByColumnIndex = 8;
public const int Coaching_UpdatedDateColumnIndex = 9;
public const int Coaching_UpdatedByColumnIndex = 10;
public const int UserAccount_IDColumnIndex = 11;
public const int Student_IDColumnIndex = 12;
public const int CourseSubject_IDColumnIndex = 13;
public const int StudentCourse_StatusColumnIndex = 14;
public const int StudentCourse_RemarkColumnIndex = 15;
public const int TSP_IDColumnIndex = 16;
public const int Student_SubjectTakenColumnIndex = 17;
public const int Course_IDColumnIndex = 18;
public const int Student_StatusColumnIndex = 19;
public const int Student_RemarkColumnIndex = 20;
public const int Application_IDColumnIndex = 21;
public const int UserAccount_UserIDColumnIndex = 22;
public const int UserAccount_FullNameColumnIndex = 23;
public const int UserAccount_EmailColumnIndex = 24;
public const int UserAccount_ContactColumnIndex = 25;
public const int UserGroup_IDColumnIndex = 26;
public const int UserAccount_RemarkColumnIndex = 27;
public const int Application_DateColumnIndex = 28;
public const int Application_FullNameColumnIndex = 29;
public const int Candidate_IDColumnIndex = 30;
public const int Application_DOBColumnIndex = 31;
public const int Application_GenderColumnIndex = 32;
public const int Application_NationalityColumnIndex = 33;
public const int Application_IdentificationNumberColumnIndex = 34;
public const int Application_Address1ColumnIndex = 35;
public const int Application_Address2ColumnIndex = 36;
public const int Application_PostcodeColumnIndex = 37;
public const int Application_CityColumnIndex = 38;
public const int Application_StateColumnIndex = 39;
public const int Country_IDColumnIndex = 40;
public const int Application_EmailColumnIndex = 41;
public const int Application_CurrentFieldOfStudyColumnIndex = 42;
public const int Application_UniversityColumnIndex = 43;
public const int Application_CGPAColumnIndex = 44;
public const int Application_PQQualificationColumnIndex = 45;
public const int Application_SubmittedColumnIndex = 46;
public const int Application_StatusColumnIndex = 47;
public const int Application_SubmittedDateColumnIndex = 48;
public const int Application_FatherNameColumnIndex = 49;
public const int Application_MotherNameColumnIndex = 50;
public const int Application_ContractTypeColumnIndex = 51;
public const int Application_PhonePrefixColumnIndex = 52;
public const int Application_PhoneNumberColumnIndex = 53;
public const int Application_MobilePhonePrefixColumnIndex = 54;
public const int Application_MobilePhoneNumberColumnIndex = 55;
public const int TSP_CampusNameColumnIndex = 56;
public const int TSP_Address1ColumnIndex = 57;
public const int TSP_Address2ColumnIndex = 58;
public const int TSP_PostcodeColumnIndex = 59;
public const int TSP_CityColumnIndex = 60;
public const int TSP_StateColumnIndex = 61;
public const int TSP_CountryColumnIndex = 62;
public const int TSP_ContactPersonColumnIndex = 63;
public const int TSP_EmailColumnIndex = 64;
public const int TSP_ContactNumberColumnIndex = 65;
public const int TSP_CourseTypeColumnIndex = 66;
public const int TSP_RemarkColumnIndex = 67;
public const int CourseSubject_NameColumnIndex = 68;
public const int CourseSubject_CodeColumnIndex = 69;
public const int Application_OverallStatusColumnIndex = 70;
public const int Application_OverallProgressColumnIndex = 71;
public const int Application_CountryNameColumnIndex = 72;
public const int Application_IntakeMonthColumnIndex = 73;
public const int Application_IntakeYearColumnIndex = 74;
public const int Sponsor_CodeColumnIndex = 75;
public const int Sponsor_LabelColumnIndex = 76;
public const int Sponsor_IDColumnIndex = 77;
public CoachingDetailTable() {
TableName = "[CoachingDetail]";
// column Coaching_ID
DataColumn Coaching_IDCol = new DataColumn("Coaching_ID", typeof(System.Guid));
Coaching_IDCol.ReadOnly = true;
Coaching_IDCol.AllowDBNull = false;
Columns.Add(Coaching_IDCol);
// column Coaching_Description
DataColumn Coaching_DescriptionCol = new DataColumn("Coaching_Description", typeof(System.String));
Coaching_DescriptionCol.ReadOnly = true;
Coaching_DescriptionCol.AllowDBNull = false;
Columns.Add(Coaching_DescriptionCol);
// column StudentCourse_ID
DataColumn StudentCourse_IDCol = new DataColumn("StudentCourse_ID", typeof(System.Guid));
StudentCourse_IDCol.ReadOnly = true;
StudentCourse_IDCol.AllowDBNull = false;
Columns.Add(StudentCourse_IDCol);
// column Coaching_Remark
DataColumn Coaching_RemarkCol = new DataColumn("Coaching_Remark", typeof(System.String));
Coaching_RemarkCol.ReadOnly = true;
Coaching_RemarkCol.AllowDBNull = false;
Columns.Add(Coaching_RemarkCol);
// column Coaching_Date
DataColumn Coaching_DateCol = new DataColumn("Coaching_Date", typeof(System.DateTime));
Coaching_DateCol.DateTimeMode = DataSetDateTime.Utc;
Coaching_DateCol.ReadOnly = true;
Coaching_DateCol.AllowDBNull = false;
Columns.Add(Coaching_DateCol);
// column Coaching_IsDeleted
DataColumn Coaching_IsDeletedCol = new DataColumn("Coaching_IsDeleted", typeof(System.Boolean));
Coaching_IsDeletedCol.ReadOnly = true;
Coaching_IsDeletedCol.AllowDBNull = false;
Columns.Add(Coaching_IsDeletedCol);
// column Coaching_Status
DataColumn Coaching_StatusCol = new DataColumn("Coaching_Status", typeof(System.Int16));
Coaching_StatusCol.ReadOnly = true;
Coaching_StatusCol.AllowDBNull = false;
Columns.Add(Coaching_StatusCol);
// column Coaching_CreatedDate
DataColumn Coaching_CreatedDateCol = new DataColumn("Coaching_CreatedDate", typeof(System.DateTime));
Coaching_CreatedDateCol.DateTimeMode = DataSetDateTime.Utc;
Coaching_CreatedDateCol.ReadOnly = true;
Coaching_CreatedDateCol.AllowDBNull = false;
Columns.Add(Coaching_CreatedDateCol);
// column Coaching_CreatedBy
DataColumn Coaching_CreatedByCol = new DataColumn("Coaching_CreatedBy", typeof(System.String));
Coaching_CreatedByCol.ReadOnly = true;
Coaching_CreatedByCol.AllowDBNull = false;
Columns.Add(Coaching_CreatedByCol);
// column Coaching_UpdatedDate
DataColumn Coaching_UpdatedDateCol = new DataColumn("Coaching_UpdatedDate", typeof(System.DateTime));
Coaching_UpdatedDateCol.DateTimeMode = DataSetDateTime.Utc;
Coaching_UpdatedDateCol.ReadOnly = true;
Coaching_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Coaching_UpdatedDateCol);
// column Coaching_UpdatedBy
DataColumn Coaching_UpdatedByCol = new DataColumn("Coaching_UpdatedBy", typeof(System.String));
Coaching_UpdatedByCol.ReadOnly = true;
Coaching_UpdatedByCol.AllowDBNull = false;
Columns.Add(Coaching_UpdatedByCol);
// column UserAccount_ID
DataColumn UserAccount_IDCol = new DataColumn("UserAccount_ID", typeof(System.Guid));
UserAccount_IDCol.ReadOnly = true;
UserAccount_IDCol.AllowDBNull = false;
Columns.Add(UserAccount_IDCol);
// column Student_ID
DataColumn Student_IDCol = new DataColumn("Student_ID", typeof(System.Guid));
Student_IDCol.ReadOnly = true;
Student_IDCol.AllowDBNull = false;
Columns.Add(Student_IDCol);
// column CourseSubject_ID
DataColumn CourseSubject_IDCol = new DataColumn("CourseSubject_ID", typeof(System.Guid));
CourseSubject_IDCol.ReadOnly = true;
CourseSubject_IDCol.AllowDBNull = false;
Columns.Add(CourseSubject_IDCol);
// column StudentCourse_Status
DataColumn StudentCourse_StatusCol = new DataColumn("StudentCourse_Status", typeof(System.Int16));
StudentCourse_StatusCol.ReadOnly = true;
StudentCourse_StatusCol.AllowDBNull = false;
Columns.Add(StudentCourse_StatusCol);
// column StudentCourse_Remark
DataColumn StudentCourse_RemarkCol = new DataColumn("StudentCourse_Remark", typeof(System.String));
StudentCourse_RemarkCol.ReadOnly = true;
StudentCourse_RemarkCol.AllowDBNull = false;
Columns.Add(StudentCourse_RemarkCol);
// column TSP_ID
DataColumn TSP_IDCol = new DataColumn("TSP_ID", typeof(System.Guid));
TSP_IDCol.ReadOnly = true;
TSP_IDCol.AllowDBNull = false;
Columns.Add(TSP_IDCol);
// column Student_SubjectTaken
DataColumn Student_SubjectTakenCol = new DataColumn("Student_SubjectTaken", typeof(System.Int32));
Student_SubjectTakenCol.ReadOnly = true;
Student_SubjectTakenCol.AllowDBNull = false;
Columns.Add(Student_SubjectTakenCol);
// column Course_ID
DataColumn Course_IDCol = new DataColumn("Course_ID", typeof(System.Guid));
Course_IDCol.ReadOnly = true;
Course_IDCol.AllowDBNull = false;
Columns.Add(Course_IDCol);
// column Student_Status
DataColumn Student_StatusCol = new DataColumn("Student_Status", typeof(System.Int16));
Student_StatusCol.ReadOnly = true;
Student_StatusCol.AllowDBNull = false;
Columns.Add(Student_StatusCol);
// column Student_Remark
DataColumn Student_RemarkCol = new DataColumn("Student_Remark", typeof(System.String));
Student_RemarkCol.ReadOnly = true;
Student_RemarkCol.AllowDBNull = false;
Columns.Add(Student_RemarkCol);
// column Application_ID
DataColumn Application_IDCol = new DataColumn("Application_ID", typeof(System.Guid));
Application_IDCol.ReadOnly = true;
Application_IDCol.AllowDBNull = false;
Columns.Add(Application_IDCol);
// column UserAccount_UserID
DataColumn UserAccount_UserIDCol = new DataColumn("UserAccount_UserID", typeof(System.String));
UserAccount_UserIDCol.ReadOnly = true;
UserAccount_UserIDCol.AllowDBNull = false;
Columns.Add(UserAccount_UserIDCol);
// column UserAccount_FullName
DataColumn UserAccount_FullNameCol = new DataColumn("UserAccount_FullName", typeof(System.String));
UserAccount_FullNameCol.ReadOnly = true;
UserAccount_FullNameCol.AllowDBNull = false;
Columns.Add(UserAccount_FullNameCol);
// column UserAccount_Email
DataColumn UserAccount_EmailCol = new DataColumn("UserAccount_Email", typeof(System.String));
UserAccount_EmailCol.ReadOnly = true;
UserAccount_EmailCol.AllowDBNull = false;
Columns.Add(UserAccount_EmailCol);
// column UserAccount_Contact
DataColumn UserAccount_ContactCol = new DataColumn("UserAccount_Contact", typeof(System.String));
UserAccount_ContactCol.ReadOnly = true;
UserAccount_ContactCol.AllowDBNull = false;
Columns.Add(UserAccount_ContactCol);
// column UserGroup_ID
DataColumn UserGroup_IDCol = new DataColumn("UserGroup_ID", typeof(System.Guid));
UserGroup_IDCol.ReadOnly = true;
UserGroup_IDCol.AllowDBNull = false;
Columns.Add(UserGroup_IDCol);
// column UserAccount_Remark
DataColumn UserAccount_RemarkCol = new DataColumn("UserAccount_Remark", typeof(System.String));
UserAccount_RemarkCol.ReadOnly = true;
UserAccount_RemarkCol.AllowDBNull = false;
Columns.Add(UserAccount_RemarkCol);
// column Application_Date
DataColumn Application_DateCol = new DataColumn("Application_Date", typeof(System.DateTime));
Application_DateCol.DateTimeMode = DataSetDateTime.Utc;
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
Application_DOBCol.DateTimeMode = DataSetDateTime.Utc;
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
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = true;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Application_Email
DataColumn Application_EmailCol = new DataColumn("Application_Email", typeof(System.String));
Application_EmailCol.ReadOnly = true;
Application_EmailCol.AllowDBNull = false;
Columns.Add(Application_EmailCol);
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
// column Application_Submitted
DataColumn Application_SubmittedCol = new DataColumn("Application_Submitted", typeof(System.Boolean));
Application_SubmittedCol.ReadOnly = true;
Application_SubmittedCol.AllowDBNull = false;
Columns.Add(Application_SubmittedCol);
// column Application_Status
DataColumn Application_StatusCol = new DataColumn("Application_Status", typeof(System.Int16));
Application_StatusCol.ReadOnly = true;
Application_StatusCol.AllowDBNull = false;
Columns.Add(Application_StatusCol);
// column Application_SubmittedDate
DataColumn Application_SubmittedDateCol = new DataColumn("Application_SubmittedDate", typeof(System.DateTime));
Application_SubmittedDateCol.DateTimeMode = DataSetDateTime.Utc;
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
// column TSP_CampusName
DataColumn TSP_CampusNameCol = new DataColumn("TSP_CampusName", typeof(System.String));
TSP_CampusNameCol.ReadOnly = true;
TSP_CampusNameCol.AllowDBNull = false;
Columns.Add(TSP_CampusNameCol);
// column TSP_Address1
DataColumn TSP_Address1Col = new DataColumn("TSP_Address1", typeof(System.String));
TSP_Address1Col.ReadOnly = true;
TSP_Address1Col.AllowDBNull = false;
Columns.Add(TSP_Address1Col);
// column TSP_Address2
DataColumn TSP_Address2Col = new DataColumn("TSP_Address2", typeof(System.String));
TSP_Address2Col.ReadOnly = true;
TSP_Address2Col.AllowDBNull = false;
Columns.Add(TSP_Address2Col);
// column TSP_Postcode
DataColumn TSP_PostcodeCol = new DataColumn("TSP_Postcode", typeof(System.String));
TSP_PostcodeCol.ReadOnly = true;
TSP_PostcodeCol.AllowDBNull = false;
Columns.Add(TSP_PostcodeCol);
// column TSP_City
DataColumn TSP_CityCol = new DataColumn("TSP_City", typeof(System.String));
TSP_CityCol.ReadOnly = true;
TSP_CityCol.AllowDBNull = false;
Columns.Add(TSP_CityCol);
// column TSP_State
DataColumn TSP_StateCol = new DataColumn("TSP_State", typeof(System.String));
TSP_StateCol.ReadOnly = true;
TSP_StateCol.AllowDBNull = false;
Columns.Add(TSP_StateCol);
// column TSP_Country
DataColumn TSP_CountryCol = new DataColumn("TSP_Country", typeof(System.String));
TSP_CountryCol.ReadOnly = true;
TSP_CountryCol.AllowDBNull = false;
Columns.Add(TSP_CountryCol);
// column TSP_ContactPerson
DataColumn TSP_ContactPersonCol = new DataColumn("TSP_ContactPerson", typeof(System.String));
TSP_ContactPersonCol.ReadOnly = true;
TSP_ContactPersonCol.AllowDBNull = false;
Columns.Add(TSP_ContactPersonCol);
// column TSP_Email
DataColumn TSP_EmailCol = new DataColumn("TSP_Email", typeof(System.String));
TSP_EmailCol.ReadOnly = true;
TSP_EmailCol.AllowDBNull = false;
Columns.Add(TSP_EmailCol);
// column TSP_ContactNumber
DataColumn TSP_ContactNumberCol = new DataColumn("TSP_ContactNumber", typeof(System.String));
TSP_ContactNumberCol.ReadOnly = true;
TSP_ContactNumberCol.AllowDBNull = false;
Columns.Add(TSP_ContactNumberCol);
// column TSP_CourseType
DataColumn TSP_CourseTypeCol = new DataColumn("TSP_CourseType", typeof(System.Int16));
TSP_CourseTypeCol.ReadOnly = true;
TSP_CourseTypeCol.AllowDBNull = true;
Columns.Add(TSP_CourseTypeCol);
// column TSP_Remark
DataColumn TSP_RemarkCol = new DataColumn("TSP_Remark", typeof(System.String));
TSP_RemarkCol.ReadOnly = true;
TSP_RemarkCol.AllowDBNull = false;
Columns.Add(TSP_RemarkCol);
// column CourseSubject_Name
DataColumn CourseSubject_NameCol = new DataColumn("CourseSubject_Name", typeof(System.String));
CourseSubject_NameCol.ReadOnly = true;
CourseSubject_NameCol.AllowDBNull = false;
Columns.Add(CourseSubject_NameCol);
// column CourseSubject_Code
DataColumn CourseSubject_CodeCol = new DataColumn("CourseSubject_Code", typeof(System.String));
CourseSubject_CodeCol.ReadOnly = true;
CourseSubject_CodeCol.AllowDBNull = false;
Columns.Add(CourseSubject_CodeCol);
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
return new CoachingDetailRow(builder);
}
public CoachingDetailRow GetCoachingDetailRow(int index) {
return (CoachingDetailRow)Rows[index];
}
}
public partial class CoachingDetailRow : DataRow {
internal CoachingDetailRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Coaching_ID {
get {
return (System.Guid)this["Coaching_ID"];
}
}
public System.String Coaching_Description {
get {
return (System.String)this["Coaching_Description"];
}
}
public System.Guid StudentCourse_ID {
get {
return (System.Guid)this["StudentCourse_ID"];
}
}
public System.String Coaching_Remark {
get {
return (System.String)this["Coaching_Remark"];
}
}
public System.DateTime Coaching_Date {
get {
return (System.DateTime)this["Coaching_Date"];
}
}
public System.Boolean Coaching_IsDeleted {
get {
return (System.Boolean)this["Coaching_IsDeleted"];
}
}
public System.Int16 Coaching_Status {
get {
return (System.Int16)this["Coaching_Status"];
}
}
public System.DateTime Coaching_CreatedDate {
get {
return (System.DateTime)this["Coaching_CreatedDate"];
}
}
public System.String Coaching_CreatedBy {
get {
return (System.String)this["Coaching_CreatedBy"];
}
}
public System.DateTime Coaching_UpdatedDate {
get {
return (System.DateTime)this["Coaching_UpdatedDate"];
}
}
public System.String Coaching_UpdatedBy {
get {
return (System.String)this["Coaching_UpdatedBy"];
}
}
public System.Guid UserAccount_ID {
get {
return (System.Guid)this["UserAccount_ID"];
}
}
public System.Guid Student_ID {
get {
return (System.Guid)this["Student_ID"];
}
}
public System.Guid CourseSubject_ID {
get {
return (System.Guid)this["CourseSubject_ID"];
}
}
public System.Int16 StudentCourse_Status {
get {
return (System.Int16)this["StudentCourse_Status"];
}
}
public System.String StudentCourse_Remark {
get {
return (System.String)this["StudentCourse_Remark"];
}
}
public System.Guid TSP_ID {
get {
return (System.Guid)this["TSP_ID"];
}
}
public System.Int32 Student_SubjectTaken {
get {
return (System.Int32)this["Student_SubjectTaken"];
}
}
public System.Guid Course_ID {
get {
return (System.Guid)this["Course_ID"];
}
}
public System.Int16 Student_Status {
get {
return (System.Int16)this["Student_Status"];
}
}
public System.String Student_Remark {
get {
return (System.String)this["Student_Remark"];
}
}
public System.Guid Application_ID {
get {
return (System.Guid)this["Application_ID"];
}
}
public System.String UserAccount_UserID {
get {
return (System.String)this["UserAccount_UserID"];
}
}
public System.String UserAccount_FullName {
get {
return (System.String)this["UserAccount_FullName"];
}
}
public System.String UserAccount_Email {
get {
return (System.String)this["UserAccount_Email"];
}
}
public System.String UserAccount_Contact {
get {
return (System.String)this["UserAccount_Contact"];
}
}
public System.Guid UserGroup_ID {
get {
return (System.Guid)this["UserGroup_ID"];
}
}
public System.String UserAccount_Remark {
get {
return (System.String)this["UserAccount_Remark"];
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
public System.Guid Country_ID {
get {
return (System.Guid)this["Country_ID"];
}
}
public System.String Application_Email {
get {
return (System.String)this["Application_Email"];
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
public System.Boolean Application_Submitted {
get {
return (System.Boolean)this["Application_Submitted"];
}
}
public System.Int16 Application_Status {
get {
return (System.Int16)this["Application_Status"];
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
public System.String TSP_CampusName {
get {
return (System.String)this["TSP_CampusName"];
}
}
public System.String TSP_Address1 {
get {
return (System.String)this["TSP_Address1"];
}
}
public System.String TSP_Address2 {
get {
return (System.String)this["TSP_Address2"];
}
}
public System.String TSP_Postcode {
get {
return (System.String)this["TSP_Postcode"];
}
}
public System.String TSP_City {
get {
return (System.String)this["TSP_City"];
}
}
public System.String TSP_State {
get {
return (System.String)this["TSP_State"];
}
}
public System.String TSP_Country {
get {
return (System.String)this["TSP_Country"];
}
}
public System.String TSP_ContactPerson {
get {
return (System.String)this["TSP_ContactPerson"];
}
}
public System.String TSP_Email {
get {
return (System.String)this["TSP_Email"];
}
}
public System.String TSP_ContactNumber {
get {
return (System.String)this["TSP_ContactNumber"];
}
}
public System.Int16? TSP_CourseType {
get {
if( IsNull("TSP_CourseType") ) return null;
else return (System.Int16)this["TSP_CourseType"];
}
}
public System.String TSP_Remark {
get {
return (System.String)this["TSP_Remark"];
}
}
public System.String CourseSubject_Name {
get {
return (System.String)this["CourseSubject_Name"];
}
}
public System.String CourseSubject_Code {
get {
return (System.String)this["CourseSubject_Code"];
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
public partial class CoachingDetailMinimalizedEntity {
public CoachingDetailMinimalizedEntity() {}
public CoachingDetailMinimalizedEntity(CoachingDetailRow dr) {
this.Coaching_ID = dr.Coaching_ID;
this.Coaching_Description = dr.Coaching_Description;
this.StudentCourse_ID = dr.StudentCourse_ID;
this.Coaching_Remark = dr.Coaching_Remark;
this.Coaching_Date = dr.Coaching_Date;
this.Coaching_IsDeleted = dr.Coaching_IsDeleted;
this.Coaching_Status = dr.Coaching_Status;
this.Coaching_CreatedDate = dr.Coaching_CreatedDate;
this.Coaching_CreatedBy = dr.Coaching_CreatedBy;
this.Coaching_UpdatedDate = dr.Coaching_UpdatedDate;
this.Coaching_UpdatedBy = dr.Coaching_UpdatedBy;
this.UserAccount_ID = dr.UserAccount_ID;
this.Student_ID = dr.Student_ID;
this.CourseSubject_ID = dr.CourseSubject_ID;
this.StudentCourse_Status = dr.StudentCourse_Status;
this.StudentCourse_Remark = dr.StudentCourse_Remark;
this.TSP_ID = dr.TSP_ID;
this.Student_SubjectTaken = dr.Student_SubjectTaken;
this.Course_ID = dr.Course_ID;
this.Student_Status = dr.Student_Status;
this.Student_Remark = dr.Student_Remark;
this.Application_ID = dr.Application_ID;
this.UserAccount_UserID = dr.UserAccount_UserID;
this.UserAccount_FullName = dr.UserAccount_FullName;
this.UserAccount_Email = dr.UserAccount_Email;
this.UserAccount_Contact = dr.UserAccount_Contact;
this.UserGroup_ID = dr.UserGroup_ID;
this.UserAccount_Remark = dr.UserAccount_Remark;
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
this.Country_ID = dr.Country_ID;
this.Application_Email = dr.Application_Email;
this.Application_CurrentFieldOfStudy = dr.Application_CurrentFieldOfStudy;
this.Application_University = dr.Application_University;
this.Application_CGPA = dr.Application_CGPA;
this.Application_PQQualification = dr.Application_PQQualification;
this.Application_Submitted = dr.Application_Submitted;
this.Application_Status = dr.Application_Status;
this.Application_SubmittedDate = dr.Application_SubmittedDate;
this.Application_FatherName = dr.Application_FatherName;
this.Application_MotherName = dr.Application_MotherName;
this.Application_ContractType = dr.Application_ContractType;
this.Application_PhonePrefix = dr.Application_PhonePrefix;
this.Application_PhoneNumber = dr.Application_PhoneNumber;
this.Application_MobilePhonePrefix = dr.Application_MobilePhonePrefix;
this.Application_MobilePhoneNumber = dr.Application_MobilePhoneNumber;
this.TSP_CampusName = dr.TSP_CampusName;
this.TSP_Address1 = dr.TSP_Address1;
this.TSP_Address2 = dr.TSP_Address2;
this.TSP_Postcode = dr.TSP_Postcode;
this.TSP_City = dr.TSP_City;
this.TSP_State = dr.TSP_State;
this.TSP_Country = dr.TSP_Country;
this.TSP_ContactPerson = dr.TSP_ContactPerson;
this.TSP_Email = dr.TSP_Email;
this.TSP_ContactNumber = dr.TSP_ContactNumber;
this.TSP_CourseType = dr.TSP_CourseType;
this.TSP_Remark = dr.TSP_Remark;
this.CourseSubject_Name = dr.CourseSubject_Name;
this.CourseSubject_Code = dr.CourseSubject_Code;
this.Application_OverallStatus = dr.Application_OverallStatus;
this.Application_OverallProgress = dr.Application_OverallProgress;
this.Application_CountryName = dr.Application_CountryName;
this.Application_IntakeMonth = dr.Application_IntakeMonth;
this.Application_IntakeYear = dr.Application_IntakeYear;
this.Sponsor_Code = dr.Sponsor_Code;
this.Sponsor_Label = dr.Sponsor_Label;
this.Sponsor_ID = dr.Sponsor_ID;
}
public System.Guid Coaching_ID;
public System.String Coaching_Description;
public System.Guid StudentCourse_ID;
public System.String Coaching_Remark;
public System.DateTime Coaching_Date;
public System.Boolean Coaching_IsDeleted;
public System.Int16 Coaching_Status;
public System.DateTime Coaching_CreatedDate;
public System.String Coaching_CreatedBy;
public System.DateTime Coaching_UpdatedDate;
public System.String Coaching_UpdatedBy;
public System.Guid UserAccount_ID;
public System.Guid Student_ID;
public System.Guid CourseSubject_ID;
public System.Int16 StudentCourse_Status;
public System.String StudentCourse_Remark;
public System.Guid TSP_ID;
public System.Int32 Student_SubjectTaken;
public System.Guid Course_ID;
public System.Int16 Student_Status;
public System.String Student_Remark;
public System.Guid Application_ID;
public System.String UserAccount_UserID;
public System.String UserAccount_FullName;
public System.String UserAccount_Email;
public System.String UserAccount_Contact;
public System.Guid UserGroup_ID;
public System.String UserAccount_Remark;
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
public System.Guid Country_ID;
public System.String Application_Email;
public System.String Application_CurrentFieldOfStudy;
public System.String Application_University;
public System.String Application_CGPA;
public System.Boolean Application_PQQualification;
public System.Boolean Application_Submitted;
public System.Int16 Application_Status;
public System.DateTime Application_SubmittedDate;
public System.String Application_FatherName;
public System.String Application_MotherName;
public System.Int16 Application_ContractType;
public System.String Application_PhonePrefix;
public System.String Application_PhoneNumber;
public System.String Application_MobilePhonePrefix;
public System.String Application_MobilePhoneNumber;
public System.String TSP_CampusName;
public System.String TSP_Address1;
public System.String TSP_Address2;
public System.String TSP_Postcode;
public System.String TSP_City;
public System.String TSP_State;
public System.String TSP_Country;
public System.String TSP_ContactPerson;
public System.String TSP_Email;
public System.String TSP_ContactNumber;
public System.Int16? TSP_CourseType;
public System.String TSP_Remark;
public System.String CourseSubject_Name;
public System.String CourseSubject_Code;
public System.Int16 Application_OverallStatus;
public System.Int16 Application_OverallProgress;
public System.String Application_CountryName;
public System.Int32 Application_IntakeMonth;
public System.Int32 Application_IntakeYear;
public System.String Sponsor_Code;
public System.String Sponsor_Label;
public System.Guid Sponsor_ID;
}
public partial class CoachingDetailAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CoachingDetailAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("Coaching_ID", "Coaching_ID");
tmap.ColumnMappings.Add("Coaching_Description", "Coaching_Description");
tmap.ColumnMappings.Add("StudentCourse_ID", "StudentCourse_ID");
tmap.ColumnMappings.Add("Coaching_Remark", "Coaching_Remark");
tmap.ColumnMappings.Add("Coaching_Date", "Coaching_Date");
tmap.ColumnMappings.Add("Coaching_IsDeleted", "Coaching_IsDeleted");
tmap.ColumnMappings.Add("Coaching_Status", "Coaching_Status");
tmap.ColumnMappings.Add("Coaching_CreatedDate", "Coaching_CreatedDate");
tmap.ColumnMappings.Add("Coaching_CreatedBy", "Coaching_CreatedBy");
tmap.ColumnMappings.Add("Coaching_UpdatedDate", "Coaching_UpdatedDate");
tmap.ColumnMappings.Add("Coaching_UpdatedBy", "Coaching_UpdatedBy");
tmap.ColumnMappings.Add("UserAccount_ID", "UserAccount_ID");
tmap.ColumnMappings.Add("Student_ID", "Student_ID");
tmap.ColumnMappings.Add("CourseSubject_ID", "CourseSubject_ID");
tmap.ColumnMappings.Add("StudentCourse_Status", "StudentCourse_Status");
tmap.ColumnMappings.Add("StudentCourse_Remark", "StudentCourse_Remark");
tmap.ColumnMappings.Add("TSP_ID", "TSP_ID");
tmap.ColumnMappings.Add("Student_SubjectTaken", "Student_SubjectTaken");
tmap.ColumnMappings.Add("Course_ID", "Course_ID");
tmap.ColumnMappings.Add("Student_Status", "Student_Status");
tmap.ColumnMappings.Add("Student_Remark", "Student_Remark");
tmap.ColumnMappings.Add("Application_ID", "Application_ID");
tmap.ColumnMappings.Add("UserAccount_UserID", "UserAccount_UserID");
tmap.ColumnMappings.Add("UserAccount_FullName", "UserAccount_FullName");
tmap.ColumnMappings.Add("UserAccount_Email", "UserAccount_Email");
tmap.ColumnMappings.Add("UserAccount_Contact", "UserAccount_Contact");
tmap.ColumnMappings.Add("UserGroup_ID", "UserGroup_ID");
tmap.ColumnMappings.Add("UserAccount_Remark", "UserAccount_Remark");
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
tmap.ColumnMappings.Add("Country_ID", "Country_ID");
tmap.ColumnMappings.Add("Application_Email", "Application_Email");
tmap.ColumnMappings.Add("Application_CurrentFieldOfStudy", "Application_CurrentFieldOfStudy");
tmap.ColumnMappings.Add("Application_University", "Application_University");
tmap.ColumnMappings.Add("Application_CGPA", "Application_CGPA");
tmap.ColumnMappings.Add("Application_PQQualification", "Application_PQQualification");
tmap.ColumnMappings.Add("Application_Submitted", "Application_Submitted");
tmap.ColumnMappings.Add("Application_Status", "Application_Status");
tmap.ColumnMappings.Add("Application_SubmittedDate", "Application_SubmittedDate");
tmap.ColumnMappings.Add("Application_FatherName", "Application_FatherName");
tmap.ColumnMappings.Add("Application_MotherName", "Application_MotherName");
tmap.ColumnMappings.Add("Application_ContractType", "Application_ContractType");
tmap.ColumnMappings.Add("Application_PhonePrefix", "Application_PhonePrefix");
tmap.ColumnMappings.Add("Application_PhoneNumber", "Application_PhoneNumber");
tmap.ColumnMappings.Add("Application_MobilePhonePrefix", "Application_MobilePhonePrefix");
tmap.ColumnMappings.Add("Application_MobilePhoneNumber", "Application_MobilePhoneNumber");
tmap.ColumnMappings.Add("TSP_CampusName", "TSP_CampusName");
tmap.ColumnMappings.Add("TSP_Address1", "TSP_Address1");
tmap.ColumnMappings.Add("TSP_Address2", "TSP_Address2");
tmap.ColumnMappings.Add("TSP_Postcode", "TSP_Postcode");
tmap.ColumnMappings.Add("TSP_City", "TSP_City");
tmap.ColumnMappings.Add("TSP_State", "TSP_State");
tmap.ColumnMappings.Add("TSP_Country", "TSP_Country");
tmap.ColumnMappings.Add("TSP_ContactPerson", "TSP_ContactPerson");
tmap.ColumnMappings.Add("TSP_Email", "TSP_Email");
tmap.ColumnMappings.Add("TSP_ContactNumber", "TSP_ContactNumber");
tmap.ColumnMappings.Add("TSP_CourseType", "TSP_CourseType");
tmap.ColumnMappings.Add("TSP_Remark", "TSP_Remark");
tmap.ColumnMappings.Add("CourseSubject_Name", "CourseSubject_Name");
tmap.ColumnMappings.Add("CourseSubject_Code", "CourseSubject_Code");
tmap.ColumnMappings.Add("Application_OverallStatus", "Application_OverallStatus");
tmap.ColumnMappings.Add("Application_OverallProgress", "Application_OverallProgress");
tmap.ColumnMappings.Add("Application_CountryName", "Application_CountryName");
tmap.ColumnMappings.Add("Application_IntakeMonth", "Application_IntakeMonth");
tmap.ColumnMappings.Add("Application_IntakeYear", "Application_IntakeYear");
tmap.ColumnMappings.Add("Sponsor_Code", "Sponsor_Code");
tmap.ColumnMappings.Add("Sponsor_Label", "Sponsor_Label");
tmap.ColumnMappings.Add("Sponsor_ID", "Sponsor_ID");
adapter.TableMappings.Add(tmap);
}
}
public CoachingDetailRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [CoachingDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

CoachingDetailTable tbl = new CoachingDetailTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCoachingDetailRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [CoachingDetail] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
