using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class CandidateTable : DataTable {
// column indexes
public const int Candidate_IDColumnIndex = 0;
public const int Candidate_UserIDColumnIndex = 1;
public const int Candidate_PasswordColumnIndex = 2;
public const int Candidate_FullNameColumnIndex = 3;
public const int Candidate_DOBColumnIndex = 4;
public const int Candidate_GenderColumnIndex = 5;
public const int Candidate_ICNumberColumnIndex = 6;
public const int Candidate_CurrentlyEmployedColumnIndex = 7;
public const int Candidate_EducationLevel1ColumnIndex = 8;
public const int Candidate_FieldOfStudy1ColumnIndex = 9;
public const int Candidate_EducationLevel2ColumnIndex = 10;
public const int Candidate_FieldOfStudy2ColumnIndex = 11;
public const int Candidate_EducationLevel3ColumnIndex = 12;
public const int Candidate_FieldOfStudy3ColumnIndex = 13;
public const int Candidate_EducationLevel4ColumnIndex = 14;
public const int Candidate_FieldOfStudy4ColumnIndex = 15;
public const int Candidate_EducationLevel5ColumnIndex = 16;
public const int Candidate_FieldOfStudy5ColumnIndex = 17;
public const int Candidate_CurrentlyPursuingHighestLevelColumnIndex = 18;
public const int Candidate_HighestEducationColumnIndex = 19;
public const int Candidate_Address1ColumnIndex = 20;
public const int Candidate_Address2ColumnIndex = 21;
public const int Candidate_CityColumnIndex = 22;
public const int Candidate_PhonePrefixColumnIndex = 23;
public const int Candidate_PhoneNumberColumnIndex = 24;
public const int Candidate_MobilePhonePrefixColumnIndex = 25;
public const int Candidate_MobilePhoneNumberColumnIndex = 26;
public const int Candidate_EmailColumnIndex = 27;
public const int Candidate_BankNameColumnIndex = 28;
public const int Candidate_BankAccountNumberColumnIndex = 29;
public const int Candidate_EmergencyContactName1ColumnIndex = 30;
public const int Candidate_EmergencyContactNumber1ColumnIndex = 31;
public const int Candidate_EmergencyContactNumber1AlternativeColumnIndex = 32;
public const int Candidate_EmergencyContactRelationship1ColumnIndex = 33;
public const int Candidate_EmergencyContactName2ColumnIndex = 34;
public const int Candidate_EmergencyContactNumber2ColumnIndex = 35;
public const int Candidate_EmergencyContactNumber2AlternativeColumnIndex = 36;
public const int Candidate_EmergencyContactRelationship2ColumnIndex = 37;
public const int Candidate_FatherGuardianNameColumnIndex = 38;
public const int Candidate_FatherGuardianICColumnIndex = 39;
public const int Candidate_FatherGuardianTypeOfOccupationColumnIndex = 40;
public const int Candidate_FatherGuardianEmployerNameColumnIndex = 41;
public const int Candidate_MotherGuardianNameColumnIndex = 42;
public const int Candidate_MotherGuardianICColumnIndex = 43;
public const int Candidate_MotherGuardianTypeOfOccupationColumnIndex = 44;
public const int Candidate_MotherGuardianEmployerNameColumnIndex = 45;
public const int Candidate_IsDeletedColumnIndex = 46;
public const int Candidate_CreatedDateColumnIndex = 47;
public const int Candidate_CreatedByColumnIndex = 48;
public const int Candidate_UpdatedDateColumnIndex = 49;
public const int Candidate_UpdatedByColumnIndex = 50;
public const int Candidate_PostcodeColumnIndex = 51;
public const int Candidate_StateColumnIndex = 52;
public const int Candidate_NationalityColumnIndex = 53;
public const int Candidate_IsBumiputraColumnIndex = 54;
public const int Candidate_RemarkColumnIndex = 55;
public const int Candidate_OtherEthnicityColumnIndex = 56;
public const int Country_IDColumnIndex = 57;
public const int Candidate_PositionColumnIndex = 58;
public const int Candidate_SectorColumnIndex = 59;
public const int Candidate_MotherIncomeColumnIndex = 60;
public const int Candidate_FatherIncomeColumnIndex = 61;
public const int Candidate_StudyCountryColumnIndex = 62;
public const int Candidate_MIAColumnIndex = 63;
public const int Candidate_MIAImageColumnIndex = 64;
public const int Candidate_MIAFileColumnIndex = 65;
public CandidateTable() {
TableName = "[Candidate]";
// column Candidate_ID
DataColumn Candidate_IDCol = new DataColumn("Candidate_ID", typeof(System.Guid));
Candidate_IDCol.ReadOnly = false;
Candidate_IDCol.AllowDBNull = false;
Columns.Add(Candidate_IDCol);
// column Candidate_UserID
DataColumn Candidate_UserIDCol = new DataColumn("Candidate_UserID", typeof(System.String));
Candidate_UserIDCol.ReadOnly = false;
Candidate_UserIDCol.AllowDBNull = false;
Columns.Add(Candidate_UserIDCol);
// column Candidate_Password
DataColumn Candidate_PasswordCol = new DataColumn("Candidate_Password", typeof(System.String));
Candidate_PasswordCol.ReadOnly = false;
Candidate_PasswordCol.AllowDBNull = false;
Columns.Add(Candidate_PasswordCol);
// column Candidate_FullName
DataColumn Candidate_FullNameCol = new DataColumn("Candidate_FullName", typeof(System.String));
Candidate_FullNameCol.ReadOnly = false;
Candidate_FullNameCol.AllowDBNull = false;
Columns.Add(Candidate_FullNameCol);
// column Candidate_DOB
DataColumn Candidate_DOBCol = new DataColumn("Candidate_DOB", typeof(System.DateTime));
Candidate_DOBCol.DateTimeMode = DataSetDateTime.Local;
Candidate_DOBCol.ReadOnly = false;
Candidate_DOBCol.AllowDBNull = false;
Columns.Add(Candidate_DOBCol);
// column Candidate_Gender
DataColumn Candidate_GenderCol = new DataColumn("Candidate_Gender", typeof(System.Int16));
Candidate_GenderCol.ReadOnly = false;
Candidate_GenderCol.AllowDBNull = false;
Columns.Add(Candidate_GenderCol);
// column Candidate_ICNumber
DataColumn Candidate_ICNumberCol = new DataColumn("Candidate_ICNumber", typeof(System.String));
Candidate_ICNumberCol.ReadOnly = false;
Candidate_ICNumberCol.AllowDBNull = false;
Columns.Add(Candidate_ICNumberCol);
// column Candidate_CurrentlyEmployed
DataColumn Candidate_CurrentlyEmployedCol = new DataColumn("Candidate_CurrentlyEmployed", typeof(System.Boolean));
Candidate_CurrentlyEmployedCol.ReadOnly = false;
Candidate_CurrentlyEmployedCol.AllowDBNull = false;
Columns.Add(Candidate_CurrentlyEmployedCol);
// column Candidate_EducationLevel1
DataColumn Candidate_EducationLevel1Col = new DataColumn("Candidate_EducationLevel1", typeof(System.String));
Candidate_EducationLevel1Col.ReadOnly = false;
Candidate_EducationLevel1Col.AllowDBNull = false;
Columns.Add(Candidate_EducationLevel1Col);
// column Candidate_FieldOfStudy1
DataColumn Candidate_FieldOfStudy1Col = new DataColumn("Candidate_FieldOfStudy1", typeof(System.String));
Candidate_FieldOfStudy1Col.ReadOnly = false;
Candidate_FieldOfStudy1Col.AllowDBNull = false;
Columns.Add(Candidate_FieldOfStudy1Col);
// column Candidate_EducationLevel2
DataColumn Candidate_EducationLevel2Col = new DataColumn("Candidate_EducationLevel2", typeof(System.String));
Candidate_EducationLevel2Col.ReadOnly = false;
Candidate_EducationLevel2Col.AllowDBNull = false;
Columns.Add(Candidate_EducationLevel2Col);
// column Candidate_FieldOfStudy2
DataColumn Candidate_FieldOfStudy2Col = new DataColumn("Candidate_FieldOfStudy2", typeof(System.String));
Candidate_FieldOfStudy2Col.ReadOnly = false;
Candidate_FieldOfStudy2Col.AllowDBNull = false;
Columns.Add(Candidate_FieldOfStudy2Col);
// column Candidate_EducationLevel3
DataColumn Candidate_EducationLevel3Col = new DataColumn("Candidate_EducationLevel3", typeof(System.String));
Candidate_EducationLevel3Col.ReadOnly = false;
Candidate_EducationLevel3Col.AllowDBNull = false;
Columns.Add(Candidate_EducationLevel3Col);
// column Candidate_FieldOfStudy3
DataColumn Candidate_FieldOfStudy3Col = new DataColumn("Candidate_FieldOfStudy3", typeof(System.String));
Candidate_FieldOfStudy3Col.ReadOnly = false;
Candidate_FieldOfStudy3Col.AllowDBNull = false;
Columns.Add(Candidate_FieldOfStudy3Col);
// column Candidate_EducationLevel4
DataColumn Candidate_EducationLevel4Col = new DataColumn("Candidate_EducationLevel4", typeof(System.String));
Candidate_EducationLevel4Col.ReadOnly = false;
Candidate_EducationLevel4Col.AllowDBNull = false;
Columns.Add(Candidate_EducationLevel4Col);
// column Candidate_FieldOfStudy4
DataColumn Candidate_FieldOfStudy4Col = new DataColumn("Candidate_FieldOfStudy4", typeof(System.String));
Candidate_FieldOfStudy4Col.ReadOnly = false;
Candidate_FieldOfStudy4Col.AllowDBNull = false;
Columns.Add(Candidate_FieldOfStudy4Col);
// column Candidate_EducationLevel5
DataColumn Candidate_EducationLevel5Col = new DataColumn("Candidate_EducationLevel5", typeof(System.String));
Candidate_EducationLevel5Col.ReadOnly = false;
Candidate_EducationLevel5Col.AllowDBNull = false;
Columns.Add(Candidate_EducationLevel5Col);
// column Candidate_FieldOfStudy5
DataColumn Candidate_FieldOfStudy5Col = new DataColumn("Candidate_FieldOfStudy5", typeof(System.String));
Candidate_FieldOfStudy5Col.ReadOnly = false;
Candidate_FieldOfStudy5Col.AllowDBNull = false;
Columns.Add(Candidate_FieldOfStudy5Col);
// column Candidate_CurrentlyPursuingHighestLevel
DataColumn Candidate_CurrentlyPursuingHighestLevelCol = new DataColumn("Candidate_CurrentlyPursuingHighestLevel", typeof(System.Boolean));
Candidate_CurrentlyPursuingHighestLevelCol.ReadOnly = false;
Candidate_CurrentlyPursuingHighestLevelCol.AllowDBNull = false;
Columns.Add(Candidate_CurrentlyPursuingHighestLevelCol);
// column Candidate_HighestEducation
DataColumn Candidate_HighestEducationCol = new DataColumn("Candidate_HighestEducation", typeof(System.String));
Candidate_HighestEducationCol.ReadOnly = false;
Candidate_HighestEducationCol.AllowDBNull = false;
Columns.Add(Candidate_HighestEducationCol);
// column Candidate_Address1
DataColumn Candidate_Address1Col = new DataColumn("Candidate_Address1", typeof(System.String));
Candidate_Address1Col.ReadOnly = false;
Candidate_Address1Col.AllowDBNull = false;
Columns.Add(Candidate_Address1Col);
// column Candidate_Address2
DataColumn Candidate_Address2Col = new DataColumn("Candidate_Address2", typeof(System.String));
Candidate_Address2Col.ReadOnly = false;
Candidate_Address2Col.AllowDBNull = false;
Columns.Add(Candidate_Address2Col);
// column Candidate_City
DataColumn Candidate_CityCol = new DataColumn("Candidate_City", typeof(System.String));
Candidate_CityCol.ReadOnly = false;
Candidate_CityCol.AllowDBNull = false;
Columns.Add(Candidate_CityCol);
// column Candidate_PhonePrefix
DataColumn Candidate_PhonePrefixCol = new DataColumn("Candidate_PhonePrefix", typeof(System.String));
Candidate_PhonePrefixCol.ReadOnly = false;
Candidate_PhonePrefixCol.AllowDBNull = false;
Columns.Add(Candidate_PhonePrefixCol);
// column Candidate_PhoneNumber
DataColumn Candidate_PhoneNumberCol = new DataColumn("Candidate_PhoneNumber", typeof(System.String));
Candidate_PhoneNumberCol.ReadOnly = false;
Candidate_PhoneNumberCol.AllowDBNull = false;
Columns.Add(Candidate_PhoneNumberCol);
// column Candidate_MobilePhonePrefix
DataColumn Candidate_MobilePhonePrefixCol = new DataColumn("Candidate_MobilePhonePrefix", typeof(System.String));
Candidate_MobilePhonePrefixCol.ReadOnly = false;
Candidate_MobilePhonePrefixCol.AllowDBNull = false;
Columns.Add(Candidate_MobilePhonePrefixCol);
// column Candidate_MobilePhoneNumber
DataColumn Candidate_MobilePhoneNumberCol = new DataColumn("Candidate_MobilePhoneNumber", typeof(System.String));
Candidate_MobilePhoneNumberCol.ReadOnly = false;
Candidate_MobilePhoneNumberCol.AllowDBNull = false;
Columns.Add(Candidate_MobilePhoneNumberCol);
// column Candidate_Email
DataColumn Candidate_EmailCol = new DataColumn("Candidate_Email", typeof(System.String));
Candidate_EmailCol.ReadOnly = false;
Candidate_EmailCol.AllowDBNull = false;
Columns.Add(Candidate_EmailCol);
// column Candidate_BankName
DataColumn Candidate_BankNameCol = new DataColumn("Candidate_BankName", typeof(System.String));
Candidate_BankNameCol.ReadOnly = false;
Candidate_BankNameCol.AllowDBNull = false;
Columns.Add(Candidate_BankNameCol);
// column Candidate_BankAccountNumber
DataColumn Candidate_BankAccountNumberCol = new DataColumn("Candidate_BankAccountNumber", typeof(System.String));
Candidate_BankAccountNumberCol.ReadOnly = false;
Candidate_BankAccountNumberCol.AllowDBNull = false;
Columns.Add(Candidate_BankAccountNumberCol);
// column Candidate_EmergencyContactName1
DataColumn Candidate_EmergencyContactName1Col = new DataColumn("Candidate_EmergencyContactName1", typeof(System.String));
Candidate_EmergencyContactName1Col.ReadOnly = false;
Candidate_EmergencyContactName1Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactName1Col);
// column Candidate_EmergencyContactNumber1
DataColumn Candidate_EmergencyContactNumber1Col = new DataColumn("Candidate_EmergencyContactNumber1", typeof(System.String));
Candidate_EmergencyContactNumber1Col.ReadOnly = false;
Candidate_EmergencyContactNumber1Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactNumber1Col);
// column Candidate_EmergencyContactNumber1Alternative
DataColumn Candidate_EmergencyContactNumber1AlternativeCol = new DataColumn("Candidate_EmergencyContactNumber1Alternative", typeof(System.String));
Candidate_EmergencyContactNumber1AlternativeCol.ReadOnly = false;
Candidate_EmergencyContactNumber1AlternativeCol.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactNumber1AlternativeCol);
// column Candidate_EmergencyContactRelationship1
DataColumn Candidate_EmergencyContactRelationship1Col = new DataColumn("Candidate_EmergencyContactRelationship1", typeof(System.String));
Candidate_EmergencyContactRelationship1Col.ReadOnly = false;
Candidate_EmergencyContactRelationship1Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactRelationship1Col);
// column Candidate_EmergencyContactName2
DataColumn Candidate_EmergencyContactName2Col = new DataColumn("Candidate_EmergencyContactName2", typeof(System.String));
Candidate_EmergencyContactName2Col.ReadOnly = false;
Candidate_EmergencyContactName2Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactName2Col);
// column Candidate_EmergencyContactNumber2
DataColumn Candidate_EmergencyContactNumber2Col = new DataColumn("Candidate_EmergencyContactNumber2", typeof(System.String));
Candidate_EmergencyContactNumber2Col.ReadOnly = false;
Candidate_EmergencyContactNumber2Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactNumber2Col);
// column Candidate_EmergencyContactNumber2Alternative
DataColumn Candidate_EmergencyContactNumber2AlternativeCol = new DataColumn("Candidate_EmergencyContactNumber2Alternative", typeof(System.String));
Candidate_EmergencyContactNumber2AlternativeCol.ReadOnly = false;
Candidate_EmergencyContactNumber2AlternativeCol.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactNumber2AlternativeCol);
// column Candidate_EmergencyContactRelationship2
DataColumn Candidate_EmergencyContactRelationship2Col = new DataColumn("Candidate_EmergencyContactRelationship2", typeof(System.String));
Candidate_EmergencyContactRelationship2Col.ReadOnly = false;
Candidate_EmergencyContactRelationship2Col.AllowDBNull = false;
Columns.Add(Candidate_EmergencyContactRelationship2Col);
// column Candidate_FatherGuardianName
DataColumn Candidate_FatherGuardianNameCol = new DataColumn("Candidate_FatherGuardianName", typeof(System.String));
Candidate_FatherGuardianNameCol.ReadOnly = false;
Candidate_FatherGuardianNameCol.AllowDBNull = false;
Columns.Add(Candidate_FatherGuardianNameCol);
// column Candidate_FatherGuardianIC
DataColumn Candidate_FatherGuardianICCol = new DataColumn("Candidate_FatherGuardianIC", typeof(System.String));
Candidate_FatherGuardianICCol.ReadOnly = false;
Candidate_FatherGuardianICCol.AllowDBNull = false;
Columns.Add(Candidate_FatherGuardianICCol);
// column Candidate_FatherGuardianTypeOfOccupation
DataColumn Candidate_FatherGuardianTypeOfOccupationCol = new DataColumn("Candidate_FatherGuardianTypeOfOccupation", typeof(System.String));
Candidate_FatherGuardianTypeOfOccupationCol.ReadOnly = false;
Candidate_FatherGuardianTypeOfOccupationCol.AllowDBNull = false;
Columns.Add(Candidate_FatherGuardianTypeOfOccupationCol);
// column Candidate_FatherGuardianEmployerName
DataColumn Candidate_FatherGuardianEmployerNameCol = new DataColumn("Candidate_FatherGuardianEmployerName", typeof(System.String));
Candidate_FatherGuardianEmployerNameCol.ReadOnly = false;
Candidate_FatherGuardianEmployerNameCol.AllowDBNull = false;
Columns.Add(Candidate_FatherGuardianEmployerNameCol);
// column Candidate_MotherGuardianName
DataColumn Candidate_MotherGuardianNameCol = new DataColumn("Candidate_MotherGuardianName", typeof(System.String));
Candidate_MotherGuardianNameCol.ReadOnly = false;
Candidate_MotherGuardianNameCol.AllowDBNull = false;
Columns.Add(Candidate_MotherGuardianNameCol);
// column Candidate_MotherGuardianIC
DataColumn Candidate_MotherGuardianICCol = new DataColumn("Candidate_MotherGuardianIC", typeof(System.String));
Candidate_MotherGuardianICCol.ReadOnly = false;
Candidate_MotherGuardianICCol.AllowDBNull = false;
Columns.Add(Candidate_MotherGuardianICCol);
// column Candidate_MotherGuardianTypeOfOccupation
DataColumn Candidate_MotherGuardianTypeOfOccupationCol = new DataColumn("Candidate_MotherGuardianTypeOfOccupation", typeof(System.String));
Candidate_MotherGuardianTypeOfOccupationCol.ReadOnly = false;
Candidate_MotherGuardianTypeOfOccupationCol.AllowDBNull = false;
Columns.Add(Candidate_MotherGuardianTypeOfOccupationCol);
// column Candidate_MotherGuardianEmployerName
DataColumn Candidate_MotherGuardianEmployerNameCol = new DataColumn("Candidate_MotherGuardianEmployerName", typeof(System.String));
Candidate_MotherGuardianEmployerNameCol.ReadOnly = false;
Candidate_MotherGuardianEmployerNameCol.AllowDBNull = false;
Columns.Add(Candidate_MotherGuardianEmployerNameCol);
// column Candidate_IsDeleted
DataColumn Candidate_IsDeletedCol = new DataColumn("Candidate_IsDeleted", typeof(System.Boolean));
Candidate_IsDeletedCol.ReadOnly = false;
Candidate_IsDeletedCol.AllowDBNull = false;
Columns.Add(Candidate_IsDeletedCol);
// column Candidate_CreatedDate
DataColumn Candidate_CreatedDateCol = new DataColumn("Candidate_CreatedDate", typeof(System.DateTime));
Candidate_CreatedDateCol.DateTimeMode = DataSetDateTime.Local;
Candidate_CreatedDateCol.ReadOnly = false;
Candidate_CreatedDateCol.AllowDBNull = false;
Columns.Add(Candidate_CreatedDateCol);
// column Candidate_CreatedBy
DataColumn Candidate_CreatedByCol = new DataColumn("Candidate_CreatedBy", typeof(System.String));
Candidate_CreatedByCol.ReadOnly = false;
Candidate_CreatedByCol.AllowDBNull = false;
Columns.Add(Candidate_CreatedByCol);
// column Candidate_UpdatedDate
DataColumn Candidate_UpdatedDateCol = new DataColumn("Candidate_UpdatedDate", typeof(System.DateTime));
Candidate_UpdatedDateCol.DateTimeMode = DataSetDateTime.Local;
Candidate_UpdatedDateCol.ReadOnly = false;
Candidate_UpdatedDateCol.AllowDBNull = false;
Columns.Add(Candidate_UpdatedDateCol);
// column Candidate_UpdatedBy
DataColumn Candidate_UpdatedByCol = new DataColumn("Candidate_UpdatedBy", typeof(System.String));
Candidate_UpdatedByCol.ReadOnly = false;
Candidate_UpdatedByCol.AllowDBNull = false;
Columns.Add(Candidate_UpdatedByCol);
// column Candidate_Postcode
DataColumn Candidate_PostcodeCol = new DataColumn("Candidate_Postcode", typeof(System.String));
Candidate_PostcodeCol.ReadOnly = false;
Candidate_PostcodeCol.AllowDBNull = false;
Columns.Add(Candidate_PostcodeCol);
// column Candidate_State
DataColumn Candidate_StateCol = new DataColumn("Candidate_State", typeof(System.String));
Candidate_StateCol.ReadOnly = false;
Candidate_StateCol.AllowDBNull = false;
Columns.Add(Candidate_StateCol);
// column Candidate_Nationality
DataColumn Candidate_NationalityCol = new DataColumn("Candidate_Nationality", typeof(System.Int32));
Candidate_NationalityCol.ReadOnly = false;
Candidate_NationalityCol.AllowDBNull = false;
Columns.Add(Candidate_NationalityCol);
// column Candidate_IsBumiputra
DataColumn Candidate_IsBumiputraCol = new DataColumn("Candidate_IsBumiputra", typeof(System.Boolean));
Candidate_IsBumiputraCol.ReadOnly = false;
Candidate_IsBumiputraCol.AllowDBNull = false;
Columns.Add(Candidate_IsBumiputraCol);
// column Candidate_Remark
DataColumn Candidate_RemarkCol = new DataColumn("Candidate_Remark", typeof(System.String));
Candidate_RemarkCol.ReadOnly = false;
Candidate_RemarkCol.AllowDBNull = false;
Columns.Add(Candidate_RemarkCol);
// column Candidate_OtherEthnicity
DataColumn Candidate_OtherEthnicityCol = new DataColumn("Candidate_OtherEthnicity", typeof(System.String));
Candidate_OtherEthnicityCol.ReadOnly = false;
Candidate_OtherEthnicityCol.AllowDBNull = false;
Columns.Add(Candidate_OtherEthnicityCol);
// column Country_ID
DataColumn Country_IDCol = new DataColumn("Country_ID", typeof(System.Guid));
Country_IDCol.ReadOnly = false;
Country_IDCol.AllowDBNull = false;
Columns.Add(Country_IDCol);
// column Candidate_Position
DataColumn Candidate_PositionCol = new DataColumn("Candidate_Position", typeof(System.String));
Candidate_PositionCol.ReadOnly = false;
Candidate_PositionCol.AllowDBNull = false;
Columns.Add(Candidate_PositionCol);
// column Candidate_Sector
DataColumn Candidate_SectorCol = new DataColumn("Candidate_Sector", typeof(System.String));
Candidate_SectorCol.ReadOnly = false;
Candidate_SectorCol.AllowDBNull = false;
Columns.Add(Candidate_SectorCol);
// column Candidate_MotherIncome
DataColumn Candidate_MotherIncomeCol = new DataColumn("Candidate_MotherIncome", typeof(System.Decimal));
Candidate_MotherIncomeCol.ReadOnly = false;
Candidate_MotherIncomeCol.AllowDBNull = false;
Columns.Add(Candidate_MotherIncomeCol);
// column Candidate_FatherIncome
DataColumn Candidate_FatherIncomeCol = new DataColumn("Candidate_FatherIncome", typeof(System.Decimal));
Candidate_FatherIncomeCol.ReadOnly = false;
Candidate_FatherIncomeCol.AllowDBNull = false;
Columns.Add(Candidate_FatherIncomeCol);
// column Candidate_StudyCountry
DataColumn Candidate_StudyCountryCol = new DataColumn("Candidate_StudyCountry", typeof(System.String));
Candidate_StudyCountryCol.ReadOnly = false;
Candidate_StudyCountryCol.AllowDBNull = false;
Columns.Add(Candidate_StudyCountryCol);
// column Candidate_MIA
DataColumn Candidate_MIACol = new DataColumn("Candidate_MIA", typeof(System.String));
Candidate_MIACol.ReadOnly = false;
Candidate_MIACol.AllowDBNull = false;
Columns.Add(Candidate_MIACol);
// column Candidate_MIAImage
DataColumn Candidate_MIAImageCol = new DataColumn("Candidate_MIAImage", typeof(System.String));
Candidate_MIAImageCol.ReadOnly = false;
Candidate_MIAImageCol.AllowDBNull = false;
Columns.Add(Candidate_MIAImageCol);
// column Candidate_MIAFile
DataColumn Candidate_MIAFileCol = new DataColumn("Candidate_MIAFile", typeof(System.String));
Candidate_MIAFileCol.ReadOnly = false;
Candidate_MIAFileCol.AllowDBNull = false;
Columns.Add(Candidate_MIAFileCol);
}
public CandidateRow NewCandidateRow() {
CandidateRow row = (CandidateRow)NewRow();
SetDefaultValues(row);
row.OverrideDefaultValues();
Rows.Add(row);
return row;
}
void SetDefaultValues(CandidateRow row) {
row.Candidate_ID = Guid.Empty;
row.Candidate_UserID = "";
row.Candidate_Password = "";
row.Candidate_FullName = "";
row.Candidate_DOB = DateTime.Now;
row.Candidate_Gender = 0;
row.Candidate_ICNumber = "";
row.Candidate_CurrentlyEmployed = false;
row.Candidate_EducationLevel1 = "";
row.Candidate_FieldOfStudy1 = "";
row.Candidate_EducationLevel2 = "";
row.Candidate_FieldOfStudy2 = "";
row.Candidate_EducationLevel3 = "";
row.Candidate_FieldOfStudy3 = "";
row.Candidate_EducationLevel4 = "";
row.Candidate_FieldOfStudy4 = "";
row.Candidate_EducationLevel5 = "";
row.Candidate_FieldOfStudy5 = "";
row.Candidate_CurrentlyPursuingHighestLevel = false;
row.Candidate_HighestEducation = "";
row.Candidate_Address1 = "";
row.Candidate_Address2 = "";
row.Candidate_City = "";
row.Candidate_PhonePrefix = "";
row.Candidate_PhoneNumber = "";
row.Candidate_MobilePhonePrefix = "";
row.Candidate_MobilePhoneNumber = "";
row.Candidate_Email = "";
row.Candidate_BankName = "";
row.Candidate_BankAccountNumber = "";
row.Candidate_EmergencyContactName1 = "";
row.Candidate_EmergencyContactNumber1 = "";
row.Candidate_EmergencyContactNumber1Alternative = "";
row.Candidate_EmergencyContactRelationship1 = "";
row.Candidate_EmergencyContactName2 = "";
row.Candidate_EmergencyContactNumber2 = "";
row.Candidate_EmergencyContactNumber2Alternative = "";
row.Candidate_EmergencyContactRelationship2 = "";
row.Candidate_FatherGuardianName = "";
row.Candidate_FatherGuardianIC = "";
row.Candidate_FatherGuardianTypeOfOccupation = "";
row.Candidate_FatherGuardianEmployerName = "";
row.Candidate_MotherGuardianName = "";
row.Candidate_MotherGuardianIC = "";
row.Candidate_MotherGuardianTypeOfOccupation = "";
row.Candidate_MotherGuardianEmployerName = "";
row.Candidate_IsDeleted = false;
row.Candidate_CreatedDate = DateTime.Now;
row.Candidate_CreatedBy = "";
row.Candidate_UpdatedDate = DateTime.Now;
row.Candidate_UpdatedBy = "";
row.Candidate_Postcode = "";
row.Candidate_State = "";
row.Candidate_Nationality = 0;
row.Candidate_IsBumiputra = false;
row.Candidate_Remark = "";
row.Candidate_OtherEthnicity = "";
row.Country_ID = Guid.Empty;
row.Candidate_Position = "";
row.Candidate_Sector = "";
row.Candidate_MotherIncome = 0;
row.Candidate_FatherIncome = 0;
row.Candidate_StudyCountry = "";
row.Candidate_MIA = "";
row.Candidate_MIAImage = "";
row.Candidate_MIAFile = "";
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new CandidateRow(builder);
}
public CandidateRow GetCandidateRow(int index) {
return (CandidateRow)Rows[index];
}
}
public partial class CandidateRow : DataRow {
internal CandidateRow(DataRowBuilder builder) : base(builder) {
}
public System.Guid Candidate_ID {
get {
return (System.Guid)this["Candidate_ID"];
}
set {
this["Candidate_ID"] = value;
}
}
public System.String Candidate_UserID {
get {
return (System.String)this["Candidate_UserID"];
}
set {
if( value.Length > 50 ) this["Candidate_UserID"] = value.Substring(0, 50);
else this["Candidate_UserID"] = value;
}
}
public System.String Candidate_Password {
get {
return (System.String)this["Candidate_Password"];
}
set {
if( value.Length > 100 ) this["Candidate_Password"] = value.Substring(0, 100);
else this["Candidate_Password"] = value;
}
}
public System.String Candidate_FullName {
get {
return (System.String)this["Candidate_FullName"];
}
set {
if( value.Length > 250 ) this["Candidate_FullName"] = value.Substring(0, 250);
else this["Candidate_FullName"] = value;
}
}
public System.DateTime Candidate_DOB {
get {
return (System.DateTime)this["Candidate_DOB"];
}
set {
this["Candidate_DOB"] = value;
}
}
public System.Int16 Candidate_Gender {
get {
return (System.Int16)this["Candidate_Gender"];
}
set {
this["Candidate_Gender"] = value;
}
}
public System.String Candidate_ICNumber {
get {
return (System.String)this["Candidate_ICNumber"];
}
set {
if( value.Length > 50 ) this["Candidate_ICNumber"] = value.Substring(0, 50);
else this["Candidate_ICNumber"] = value;
}
}
public System.Boolean Candidate_CurrentlyEmployed {
get {
return (System.Boolean)this["Candidate_CurrentlyEmployed"];
}
set {
this["Candidate_CurrentlyEmployed"] = value;
}
}
public System.String Candidate_EducationLevel1 {
get {
return (System.String)this["Candidate_EducationLevel1"];
}
set {
if( value.Length > 50 ) this["Candidate_EducationLevel1"] = value.Substring(0, 50);
else this["Candidate_EducationLevel1"] = value;
}
}
public System.String Candidate_FieldOfStudy1 {
get {
return (System.String)this["Candidate_FieldOfStudy1"];
}
set {
if( value.Length > 50 ) this["Candidate_FieldOfStudy1"] = value.Substring(0, 50);
else this["Candidate_FieldOfStudy1"] = value;
}
}
public System.String Candidate_EducationLevel2 {
get {
return (System.String)this["Candidate_EducationLevel2"];
}
set {
if( value.Length > 50 ) this["Candidate_EducationLevel2"] = value.Substring(0, 50);
else this["Candidate_EducationLevel2"] = value;
}
}
public System.String Candidate_FieldOfStudy2 {
get {
return (System.String)this["Candidate_FieldOfStudy2"];
}
set {
if( value.Length > 50 ) this["Candidate_FieldOfStudy2"] = value.Substring(0, 50);
else this["Candidate_FieldOfStudy2"] = value;
}
}
public System.String Candidate_EducationLevel3 {
get {
return (System.String)this["Candidate_EducationLevel3"];
}
set {
if( value.Length > 50 ) this["Candidate_EducationLevel3"] = value.Substring(0, 50);
else this["Candidate_EducationLevel3"] = value;
}
}
public System.String Candidate_FieldOfStudy3 {
get {
return (System.String)this["Candidate_FieldOfStudy3"];
}
set {
if( value.Length > 50 ) this["Candidate_FieldOfStudy3"] = value.Substring(0, 50);
else this["Candidate_FieldOfStudy3"] = value;
}
}
public System.String Candidate_EducationLevel4 {
get {
return (System.String)this["Candidate_EducationLevel4"];
}
set {
if( value.Length > 50 ) this["Candidate_EducationLevel4"] = value.Substring(0, 50);
else this["Candidate_EducationLevel4"] = value;
}
}
public System.String Candidate_FieldOfStudy4 {
get {
return (System.String)this["Candidate_FieldOfStudy4"];
}
set {
if( value.Length > 50 ) this["Candidate_FieldOfStudy4"] = value.Substring(0, 50);
else this["Candidate_FieldOfStudy4"] = value;
}
}
public System.String Candidate_EducationLevel5 {
get {
return (System.String)this["Candidate_EducationLevel5"];
}
set {
if( value.Length > 50 ) this["Candidate_EducationLevel5"] = value.Substring(0, 50);
else this["Candidate_EducationLevel5"] = value;
}
}
public System.String Candidate_FieldOfStudy5 {
get {
return (System.String)this["Candidate_FieldOfStudy5"];
}
set {
if( value.Length > 50 ) this["Candidate_FieldOfStudy5"] = value.Substring(0, 50);
else this["Candidate_FieldOfStudy5"] = value;
}
}
public System.Boolean Candidate_CurrentlyPursuingHighestLevel {
get {
return (System.Boolean)this["Candidate_CurrentlyPursuingHighestLevel"];
}
set {
this["Candidate_CurrentlyPursuingHighestLevel"] = value;
}
}
public System.String Candidate_HighestEducation {
get {
return (System.String)this["Candidate_HighestEducation"];
}
set {
if( value.Length > 100 ) this["Candidate_HighestEducation"] = value.Substring(0, 100);
else this["Candidate_HighestEducation"] = value;
}
}
public System.String Candidate_Address1 {
get {
return (System.String)this["Candidate_Address1"];
}
set {
if( value.Length > 100 ) this["Candidate_Address1"] = value.Substring(0, 100);
else this["Candidate_Address1"] = value;
}
}
public System.String Candidate_Address2 {
get {
return (System.String)this["Candidate_Address2"];
}
set {
if( value.Length > 100 ) this["Candidate_Address2"] = value.Substring(0, 100);
else this["Candidate_Address2"] = value;
}
}
public System.String Candidate_City {
get {
return (System.String)this["Candidate_City"];
}
set {
if( value.Length > 100 ) this["Candidate_City"] = value.Substring(0, 100);
else this["Candidate_City"] = value;
}
}
public System.String Candidate_PhonePrefix {
get {
return (System.String)this["Candidate_PhonePrefix"];
}
set {
if( value.Length > 50 ) this["Candidate_PhonePrefix"] = value.Substring(0, 50);
else this["Candidate_PhonePrefix"] = value;
}
}
public System.String Candidate_PhoneNumber {
get {
return (System.String)this["Candidate_PhoneNumber"];
}
set {
if( value.Length > 50 ) this["Candidate_PhoneNumber"] = value.Substring(0, 50);
else this["Candidate_PhoneNumber"] = value;
}
}
public System.String Candidate_MobilePhonePrefix {
get {
return (System.String)this["Candidate_MobilePhonePrefix"];
}
set {
if( value.Length > 50 ) this["Candidate_MobilePhonePrefix"] = value.Substring(0, 50);
else this["Candidate_MobilePhonePrefix"] = value;
}
}
public System.String Candidate_MobilePhoneNumber {
get {
return (System.String)this["Candidate_MobilePhoneNumber"];
}
set {
if( value.Length > 50 ) this["Candidate_MobilePhoneNumber"] = value.Substring(0, 50);
else this["Candidate_MobilePhoneNumber"] = value;
}
}
public System.String Candidate_Email {
get {
return (System.String)this["Candidate_Email"];
}
set {
if( value.Length > 50 ) this["Candidate_Email"] = value.Substring(0, 50);
else this["Candidate_Email"] = value;
}
}
public System.String Candidate_BankName {
get {
return (System.String)this["Candidate_BankName"];
}
set {
if( value.Length > 100 ) this["Candidate_BankName"] = value.Substring(0, 100);
else this["Candidate_BankName"] = value;
}
}
public System.String Candidate_BankAccountNumber {
get {
return (System.String)this["Candidate_BankAccountNumber"];
}
set {
if( value.Length > 50 ) this["Candidate_BankAccountNumber"] = value.Substring(0, 50);
else this["Candidate_BankAccountNumber"] = value;
}
}
public System.String Candidate_EmergencyContactName1 {
get {
return (System.String)this["Candidate_EmergencyContactName1"];
}
set {
if( value.Length > 100 ) this["Candidate_EmergencyContactName1"] = value.Substring(0, 100);
else this["Candidate_EmergencyContactName1"] = value;
}
}
public System.String Candidate_EmergencyContactNumber1 {
get {
return (System.String)this["Candidate_EmergencyContactNumber1"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactNumber1"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactNumber1"] = value;
}
}
public System.String Candidate_EmergencyContactNumber1Alternative {
get {
return (System.String)this["Candidate_EmergencyContactNumber1Alternative"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactNumber1Alternative"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactNumber1Alternative"] = value;
}
}
public System.String Candidate_EmergencyContactRelationship1 {
get {
return (System.String)this["Candidate_EmergencyContactRelationship1"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactRelationship1"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactRelationship1"] = value;
}
}
public System.String Candidate_EmergencyContactName2 {
get {
return (System.String)this["Candidate_EmergencyContactName2"];
}
set {
if( value.Length > 100 ) this["Candidate_EmergencyContactName2"] = value.Substring(0, 100);
else this["Candidate_EmergencyContactName2"] = value;
}
}
public System.String Candidate_EmergencyContactNumber2 {
get {
return (System.String)this["Candidate_EmergencyContactNumber2"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactNumber2"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactNumber2"] = value;
}
}
public System.String Candidate_EmergencyContactNumber2Alternative {
get {
return (System.String)this["Candidate_EmergencyContactNumber2Alternative"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactNumber2Alternative"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactNumber2Alternative"] = value;
}
}
public System.String Candidate_EmergencyContactRelationship2 {
get {
return (System.String)this["Candidate_EmergencyContactRelationship2"];
}
set {
if( value.Length > 50 ) this["Candidate_EmergencyContactRelationship2"] = value.Substring(0, 50);
else this["Candidate_EmergencyContactRelationship2"] = value;
}
}
public System.String Candidate_FatherGuardianName {
get {
return (System.String)this["Candidate_FatherGuardianName"];
}
set {
if( value.Length > 100 ) this["Candidate_FatherGuardianName"] = value.Substring(0, 100);
else this["Candidate_FatherGuardianName"] = value;
}
}
public System.String Candidate_FatherGuardianIC {
get {
return (System.String)this["Candidate_FatherGuardianIC"];
}
set {
if( value.Length > 50 ) this["Candidate_FatherGuardianIC"] = value.Substring(0, 50);
else this["Candidate_FatherGuardianIC"] = value;
}
}
public System.String Candidate_FatherGuardianTypeOfOccupation {
get {
return (System.String)this["Candidate_FatherGuardianTypeOfOccupation"];
}
set {
if( value.Length > 50 ) this["Candidate_FatherGuardianTypeOfOccupation"] = value.Substring(0, 50);
else this["Candidate_FatherGuardianTypeOfOccupation"] = value;
}
}
public System.String Candidate_FatherGuardianEmployerName {
get {
return (System.String)this["Candidate_FatherGuardianEmployerName"];
}
set {
if( value.Length > 100 ) this["Candidate_FatherGuardianEmployerName"] = value.Substring(0, 100);
else this["Candidate_FatherGuardianEmployerName"] = value;
}
}
public System.String Candidate_MotherGuardianName {
get {
return (System.String)this["Candidate_MotherGuardianName"];
}
set {
if( value.Length > 100 ) this["Candidate_MotherGuardianName"] = value.Substring(0, 100);
else this["Candidate_MotherGuardianName"] = value;
}
}
public System.String Candidate_MotherGuardianIC {
get {
return (System.String)this["Candidate_MotherGuardianIC"];
}
set {
if( value.Length > 50 ) this["Candidate_MotherGuardianIC"] = value.Substring(0, 50);
else this["Candidate_MotherGuardianIC"] = value;
}
}
public System.String Candidate_MotherGuardianTypeOfOccupation {
get {
return (System.String)this["Candidate_MotherGuardianTypeOfOccupation"];
}
set {
if( value.Length > 50 ) this["Candidate_MotherGuardianTypeOfOccupation"] = value.Substring(0, 50);
else this["Candidate_MotherGuardianTypeOfOccupation"] = value;
}
}
public System.String Candidate_MotherGuardianEmployerName {
get {
return (System.String)this["Candidate_MotherGuardianEmployerName"];
}
set {
if( value.Length > 100 ) this["Candidate_MotherGuardianEmployerName"] = value.Substring(0, 100);
else this["Candidate_MotherGuardianEmployerName"] = value;
}
}
public System.Boolean Candidate_IsDeleted {
get {
return (System.Boolean)this["Candidate_IsDeleted"];
}
set {
this["Candidate_IsDeleted"] = value;
}
}
public System.DateTime Candidate_CreatedDate {
get {
return (System.DateTime)this["Candidate_CreatedDate"];
}
set {
this["Candidate_CreatedDate"] = value;
}
}
public System.String Candidate_CreatedBy {
get {
return (System.String)this["Candidate_CreatedBy"];
}
set {
if( value.Length > 50 ) this["Candidate_CreatedBy"] = value.Substring(0, 50);
else this["Candidate_CreatedBy"] = value;
}
}
public System.DateTime Candidate_UpdatedDate {
get {
return (System.DateTime)this["Candidate_UpdatedDate"];
}
set {
this["Candidate_UpdatedDate"] = value;
}
}
public System.String Candidate_UpdatedBy {
get {
return (System.String)this["Candidate_UpdatedBy"];
}
set {
if( value.Length > 50 ) this["Candidate_UpdatedBy"] = value.Substring(0, 50);
else this["Candidate_UpdatedBy"] = value;
}
}
public System.String Candidate_Postcode {
get {
return (System.String)this["Candidate_Postcode"];
}
set {
if( value.Length > 10 ) this["Candidate_Postcode"] = value.Substring(0, 10);
else this["Candidate_Postcode"] = value;
}
}
public System.String Candidate_State {
get {
return (System.String)this["Candidate_State"];
}
set {
if( value.Length > 50 ) this["Candidate_State"] = value.Substring(0, 50);
else this["Candidate_State"] = value;
}
}
public System.Int32 Candidate_Nationality {
get {
return (System.Int32)this["Candidate_Nationality"];
}
set {
this["Candidate_Nationality"] = value;
}
}
public System.Boolean Candidate_IsBumiputra {
get {
return (System.Boolean)this["Candidate_IsBumiputra"];
}
set {
this["Candidate_IsBumiputra"] = value;
}
}
public System.String Candidate_Remark {
get {
return (System.String)this["Candidate_Remark"];
}
set {
if( value.Length > 250 ) this["Candidate_Remark"] = value.Substring(0, 250);
else this["Candidate_Remark"] = value;
}
}
public System.String Candidate_OtherEthnicity {
get {
return (System.String)this["Candidate_OtherEthnicity"];
}
set {
if( value.Length > 50 ) this["Candidate_OtherEthnicity"] = value.Substring(0, 50);
else this["Candidate_OtherEthnicity"] = value;
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
public System.String Candidate_Position {
get {
return (System.String)this["Candidate_Position"];
}
set {
if( value.Length > 100 ) this["Candidate_Position"] = value.Substring(0, 100);
else this["Candidate_Position"] = value;
}
}
public System.String Candidate_Sector {
get {
return (System.String)this["Candidate_Sector"];
}
set {
if( value.Length > 100 ) this["Candidate_Sector"] = value.Substring(0, 100);
else this["Candidate_Sector"] = value;
}
}
public System.Decimal Candidate_MotherIncome {
get {
return (System.Decimal)this["Candidate_MotherIncome"];
}
set {
this["Candidate_MotherIncome"] = value;
}
}
public System.Decimal Candidate_FatherIncome {
get {
return (System.Decimal)this["Candidate_FatherIncome"];
}
set {
this["Candidate_FatherIncome"] = value;
}
}
public System.String Candidate_StudyCountry {
get {
return (System.String)this["Candidate_StudyCountry"];
}
set {
if( value.Length > 200 ) this["Candidate_StudyCountry"] = value.Substring(0, 200);
else this["Candidate_StudyCountry"] = value;
}
}
public System.String Candidate_MIA {
get {
return (System.String)this["Candidate_MIA"];
}
set {
if( value.Length > 250 ) this["Candidate_MIA"] = value.Substring(0, 250);
else this["Candidate_MIA"] = value;
}
}
public System.String Candidate_MIAImage {
get {
return (System.String)this["Candidate_MIAImage"];
}
set {
if( value.Length > 100 ) this["Candidate_MIAImage"] = value.Substring(0, 100);
else this["Candidate_MIAImage"] = value;
}
}
public System.String Candidate_MIAFile {
get {
return (System.String)this["Candidate_MIAFile"];
}
set {
if( value.Length > 100 ) this["Candidate_MIAFile"] = value.Substring(0, 100);
else this["Candidate_MIAFile"] = value;
}
}
}
public partial class CandidateMinimalizedEntity {
public CandidateMinimalizedEntity() {}
public CandidateMinimalizedEntity(CandidateRow dr) {
this.Candidate_ID = dr.Candidate_ID;
this.Candidate_UserID = dr.Candidate_UserID;
this.Candidate_Password = dr.Candidate_Password;
this.Candidate_FullName = dr.Candidate_FullName;
this.Candidate_DOB = dr.Candidate_DOB;
this.Candidate_Gender = dr.Candidate_Gender;
this.Candidate_ICNumber = dr.Candidate_ICNumber;
this.Candidate_CurrentlyEmployed = dr.Candidate_CurrentlyEmployed;
this.Candidate_EducationLevel1 = dr.Candidate_EducationLevel1;
this.Candidate_FieldOfStudy1 = dr.Candidate_FieldOfStudy1;
this.Candidate_EducationLevel2 = dr.Candidate_EducationLevel2;
this.Candidate_FieldOfStudy2 = dr.Candidate_FieldOfStudy2;
this.Candidate_EducationLevel3 = dr.Candidate_EducationLevel3;
this.Candidate_FieldOfStudy3 = dr.Candidate_FieldOfStudy3;
this.Candidate_EducationLevel4 = dr.Candidate_EducationLevel4;
this.Candidate_FieldOfStudy4 = dr.Candidate_FieldOfStudy4;
this.Candidate_EducationLevel5 = dr.Candidate_EducationLevel5;
this.Candidate_FieldOfStudy5 = dr.Candidate_FieldOfStudy5;
this.Candidate_CurrentlyPursuingHighestLevel = dr.Candidate_CurrentlyPursuingHighestLevel;
this.Candidate_HighestEducation = dr.Candidate_HighestEducation;
this.Candidate_Address1 = dr.Candidate_Address1;
this.Candidate_Address2 = dr.Candidate_Address2;
this.Candidate_City = dr.Candidate_City;
this.Candidate_PhonePrefix = dr.Candidate_PhonePrefix;
this.Candidate_PhoneNumber = dr.Candidate_PhoneNumber;
this.Candidate_MobilePhonePrefix = dr.Candidate_MobilePhonePrefix;
this.Candidate_MobilePhoneNumber = dr.Candidate_MobilePhoneNumber;
this.Candidate_Email = dr.Candidate_Email;
this.Candidate_BankName = dr.Candidate_BankName;
this.Candidate_BankAccountNumber = dr.Candidate_BankAccountNumber;
this.Candidate_EmergencyContactName1 = dr.Candidate_EmergencyContactName1;
this.Candidate_EmergencyContactNumber1 = dr.Candidate_EmergencyContactNumber1;
this.Candidate_EmergencyContactNumber1Alternative = dr.Candidate_EmergencyContactNumber1Alternative;
this.Candidate_EmergencyContactRelationship1 = dr.Candidate_EmergencyContactRelationship1;
this.Candidate_EmergencyContactName2 = dr.Candidate_EmergencyContactName2;
this.Candidate_EmergencyContactNumber2 = dr.Candidate_EmergencyContactNumber2;
this.Candidate_EmergencyContactNumber2Alternative = dr.Candidate_EmergencyContactNumber2Alternative;
this.Candidate_EmergencyContactRelationship2 = dr.Candidate_EmergencyContactRelationship2;
this.Candidate_FatherGuardianName = dr.Candidate_FatherGuardianName;
this.Candidate_FatherGuardianIC = dr.Candidate_FatherGuardianIC;
this.Candidate_FatherGuardianTypeOfOccupation = dr.Candidate_FatherGuardianTypeOfOccupation;
this.Candidate_FatherGuardianEmployerName = dr.Candidate_FatherGuardianEmployerName;
this.Candidate_MotherGuardianName = dr.Candidate_MotherGuardianName;
this.Candidate_MotherGuardianIC = dr.Candidate_MotherGuardianIC;
this.Candidate_MotherGuardianTypeOfOccupation = dr.Candidate_MotherGuardianTypeOfOccupation;
this.Candidate_MotherGuardianEmployerName = dr.Candidate_MotherGuardianEmployerName;
this.Candidate_IsDeleted = dr.Candidate_IsDeleted;
this.Candidate_CreatedDate = dr.Candidate_CreatedDate;
this.Candidate_CreatedBy = dr.Candidate_CreatedBy;
this.Candidate_UpdatedDate = dr.Candidate_UpdatedDate;
this.Candidate_UpdatedBy = dr.Candidate_UpdatedBy;
this.Candidate_Postcode = dr.Candidate_Postcode;
this.Candidate_State = dr.Candidate_State;
this.Candidate_Nationality = dr.Candidate_Nationality;
this.Candidate_IsBumiputra = dr.Candidate_IsBumiputra;
this.Candidate_Remark = dr.Candidate_Remark;
this.Candidate_OtherEthnicity = dr.Candidate_OtherEthnicity;
this.Country_ID = dr.Country_ID;
this.Candidate_Position = dr.Candidate_Position;
this.Candidate_Sector = dr.Candidate_Sector;
this.Candidate_MotherIncome = dr.Candidate_MotherIncome;
this.Candidate_FatherIncome = dr.Candidate_FatherIncome;
this.Candidate_StudyCountry = dr.Candidate_StudyCountry;
this.Candidate_MIA = dr.Candidate_MIA;
this.Candidate_MIAImage = dr.Candidate_MIAImage;
this.Candidate_MIAFile = dr.Candidate_MIAFile;
}
public void CopyTo(CandidateRow dr) {
dr.Candidate_ID = this.Candidate_ID;
dr.Candidate_UserID = this.Candidate_UserID;
dr.Candidate_Password = this.Candidate_Password;
dr.Candidate_FullName = this.Candidate_FullName;
dr.Candidate_DOB = this.Candidate_DOB;
dr.Candidate_Gender = this.Candidate_Gender;
dr.Candidate_ICNumber = this.Candidate_ICNumber;
dr.Candidate_CurrentlyEmployed = this.Candidate_CurrentlyEmployed;
dr.Candidate_EducationLevel1 = this.Candidate_EducationLevel1;
dr.Candidate_FieldOfStudy1 = this.Candidate_FieldOfStudy1;
dr.Candidate_EducationLevel2 = this.Candidate_EducationLevel2;
dr.Candidate_FieldOfStudy2 = this.Candidate_FieldOfStudy2;
dr.Candidate_EducationLevel3 = this.Candidate_EducationLevel3;
dr.Candidate_FieldOfStudy3 = this.Candidate_FieldOfStudy3;
dr.Candidate_EducationLevel4 = this.Candidate_EducationLevel4;
dr.Candidate_FieldOfStudy4 = this.Candidate_FieldOfStudy4;
dr.Candidate_EducationLevel5 = this.Candidate_EducationLevel5;
dr.Candidate_FieldOfStudy5 = this.Candidate_FieldOfStudy5;
dr.Candidate_CurrentlyPursuingHighestLevel = this.Candidate_CurrentlyPursuingHighestLevel;
dr.Candidate_HighestEducation = this.Candidate_HighestEducation;
dr.Candidate_Address1 = this.Candidate_Address1;
dr.Candidate_Address2 = this.Candidate_Address2;
dr.Candidate_City = this.Candidate_City;
dr.Candidate_PhonePrefix = this.Candidate_PhonePrefix;
dr.Candidate_PhoneNumber = this.Candidate_PhoneNumber;
dr.Candidate_MobilePhonePrefix = this.Candidate_MobilePhonePrefix;
dr.Candidate_MobilePhoneNumber = this.Candidate_MobilePhoneNumber;
dr.Candidate_Email = this.Candidate_Email;
dr.Candidate_BankName = this.Candidate_BankName;
dr.Candidate_BankAccountNumber = this.Candidate_BankAccountNumber;
dr.Candidate_EmergencyContactName1 = this.Candidate_EmergencyContactName1;
dr.Candidate_EmergencyContactNumber1 = this.Candidate_EmergencyContactNumber1;
dr.Candidate_EmergencyContactNumber1Alternative = this.Candidate_EmergencyContactNumber1Alternative;
dr.Candidate_EmergencyContactRelationship1 = this.Candidate_EmergencyContactRelationship1;
dr.Candidate_EmergencyContactName2 = this.Candidate_EmergencyContactName2;
dr.Candidate_EmergencyContactNumber2 = this.Candidate_EmergencyContactNumber2;
dr.Candidate_EmergencyContactNumber2Alternative = this.Candidate_EmergencyContactNumber2Alternative;
dr.Candidate_EmergencyContactRelationship2 = this.Candidate_EmergencyContactRelationship2;
dr.Candidate_FatherGuardianName = this.Candidate_FatherGuardianName;
dr.Candidate_FatherGuardianIC = this.Candidate_FatherGuardianIC;
dr.Candidate_FatherGuardianTypeOfOccupation = this.Candidate_FatherGuardianTypeOfOccupation;
dr.Candidate_FatherGuardianEmployerName = this.Candidate_FatherGuardianEmployerName;
dr.Candidate_MotherGuardianName = this.Candidate_MotherGuardianName;
dr.Candidate_MotherGuardianIC = this.Candidate_MotherGuardianIC;
dr.Candidate_MotherGuardianTypeOfOccupation = this.Candidate_MotherGuardianTypeOfOccupation;
dr.Candidate_MotherGuardianEmployerName = this.Candidate_MotherGuardianEmployerName;
dr.Candidate_IsDeleted = this.Candidate_IsDeleted;
dr.Candidate_CreatedDate = this.Candidate_CreatedDate;
dr.Candidate_CreatedBy = this.Candidate_CreatedBy;
dr.Candidate_UpdatedDate = this.Candidate_UpdatedDate;
dr.Candidate_UpdatedBy = this.Candidate_UpdatedBy;
dr.Candidate_Postcode = this.Candidate_Postcode;
dr.Candidate_State = this.Candidate_State;
dr.Candidate_Nationality = this.Candidate_Nationality;
dr.Candidate_IsBumiputra = this.Candidate_IsBumiputra;
dr.Candidate_Remark = this.Candidate_Remark;
dr.Candidate_OtherEthnicity = this.Candidate_OtherEthnicity;
dr.Country_ID = this.Country_ID;
dr.Candidate_Position = this.Candidate_Position;
dr.Candidate_Sector = this.Candidate_Sector;
dr.Candidate_MotherIncome = this.Candidate_MotherIncome;
dr.Candidate_FatherIncome = this.Candidate_FatherIncome;
dr.Candidate_StudyCountry = this.Candidate_StudyCountry;
dr.Candidate_MIA = this.Candidate_MIA;
dr.Candidate_MIAImage = this.Candidate_MIAImage;
dr.Candidate_MIAFile = this.Candidate_MIAFile;
}
public System.Guid Candidate_ID;
public System.String Candidate_UserID;
public System.String Candidate_Password;
public System.String Candidate_FullName;
public System.DateTime Candidate_DOB;
public System.Int16 Candidate_Gender;
public System.String Candidate_ICNumber;
public System.Boolean Candidate_CurrentlyEmployed;
public System.String Candidate_EducationLevel1;
public System.String Candidate_FieldOfStudy1;
public System.String Candidate_EducationLevel2;
public System.String Candidate_FieldOfStudy2;
public System.String Candidate_EducationLevel3;
public System.String Candidate_FieldOfStudy3;
public System.String Candidate_EducationLevel4;
public System.String Candidate_FieldOfStudy4;
public System.String Candidate_EducationLevel5;
public System.String Candidate_FieldOfStudy5;
public System.Boolean Candidate_CurrentlyPursuingHighestLevel;
public System.String Candidate_HighestEducation;
public System.String Candidate_Address1;
public System.String Candidate_Address2;
public System.String Candidate_City;
public System.String Candidate_PhonePrefix;
public System.String Candidate_PhoneNumber;
public System.String Candidate_MobilePhonePrefix;
public System.String Candidate_MobilePhoneNumber;
public System.String Candidate_Email;
public System.String Candidate_BankName;
public System.String Candidate_BankAccountNumber;
public System.String Candidate_EmergencyContactName1;
public System.String Candidate_EmergencyContactNumber1;
public System.String Candidate_EmergencyContactNumber1Alternative;
public System.String Candidate_EmergencyContactRelationship1;
public System.String Candidate_EmergencyContactName2;
public System.String Candidate_EmergencyContactNumber2;
public System.String Candidate_EmergencyContactNumber2Alternative;
public System.String Candidate_EmergencyContactRelationship2;
public System.String Candidate_FatherGuardianName;
public System.String Candidate_FatherGuardianIC;
public System.String Candidate_FatherGuardianTypeOfOccupation;
public System.String Candidate_FatherGuardianEmployerName;
public System.String Candidate_MotherGuardianName;
public System.String Candidate_MotherGuardianIC;
public System.String Candidate_MotherGuardianTypeOfOccupation;
public System.String Candidate_MotherGuardianEmployerName;
public System.Boolean Candidate_IsDeleted;
public System.DateTime Candidate_CreatedDate;
public System.String Candidate_CreatedBy;
public System.DateTime Candidate_UpdatedDate;
public System.String Candidate_UpdatedBy;
public System.String Candidate_Postcode;
public System.String Candidate_State;
public System.Int32 Candidate_Nationality;
public System.Boolean Candidate_IsBumiputra;
public System.String Candidate_Remark;
public System.String Candidate_OtherEthnicity;
public System.Guid Country_ID;
public System.String Candidate_Position;
public System.String Candidate_Sector;
public System.Decimal Candidate_MotherIncome;
public System.Decimal Candidate_FatherIncome;
public System.String Candidate_StudyCountry;
public System.String Candidate_MIA;
public System.String Candidate_MIAImage;
public System.String Candidate_MIAFile;
}
public partial class CandidateAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public CandidateAdapter(DA da):base(da) {
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
tmap.ColumnMappings.Add("Candidate_UserID", "Candidate_UserID");
tmap.ColumnMappings.Add("Candidate_Password", "Candidate_Password");
tmap.ColumnMappings.Add("Candidate_FullName", "Candidate_FullName");
tmap.ColumnMappings.Add("Candidate_DOB", "Candidate_DOB");
tmap.ColumnMappings.Add("Candidate_Gender", "Candidate_Gender");
tmap.ColumnMappings.Add("Candidate_ICNumber", "Candidate_ICNumber");
tmap.ColumnMappings.Add("Candidate_CurrentlyEmployed", "Candidate_CurrentlyEmployed");
tmap.ColumnMappings.Add("Candidate_EducationLevel1", "Candidate_EducationLevel1");
tmap.ColumnMappings.Add("Candidate_FieldOfStudy1", "Candidate_FieldOfStudy1");
tmap.ColumnMappings.Add("Candidate_EducationLevel2", "Candidate_EducationLevel2");
tmap.ColumnMappings.Add("Candidate_FieldOfStudy2", "Candidate_FieldOfStudy2");
tmap.ColumnMappings.Add("Candidate_EducationLevel3", "Candidate_EducationLevel3");
tmap.ColumnMappings.Add("Candidate_FieldOfStudy3", "Candidate_FieldOfStudy3");
tmap.ColumnMappings.Add("Candidate_EducationLevel4", "Candidate_EducationLevel4");
tmap.ColumnMappings.Add("Candidate_FieldOfStudy4", "Candidate_FieldOfStudy4");
tmap.ColumnMappings.Add("Candidate_EducationLevel5", "Candidate_EducationLevel5");
tmap.ColumnMappings.Add("Candidate_FieldOfStudy5", "Candidate_FieldOfStudy5");
tmap.ColumnMappings.Add("Candidate_CurrentlyPursuingHighestLevel", "Candidate_CurrentlyPursuingHighestLevel");
tmap.ColumnMappings.Add("Candidate_HighestEducation", "Candidate_HighestEducation");
tmap.ColumnMappings.Add("Candidate_Address1", "Candidate_Address1");
tmap.ColumnMappings.Add("Candidate_Address2", "Candidate_Address2");
tmap.ColumnMappings.Add("Candidate_City", "Candidate_City");
tmap.ColumnMappings.Add("Candidate_PhonePrefix", "Candidate_PhonePrefix");
tmap.ColumnMappings.Add("Candidate_PhoneNumber", "Candidate_PhoneNumber");
tmap.ColumnMappings.Add("Candidate_MobilePhonePrefix", "Candidate_MobilePhonePrefix");
tmap.ColumnMappings.Add("Candidate_MobilePhoneNumber", "Candidate_MobilePhoneNumber");
tmap.ColumnMappings.Add("Candidate_Email", "Candidate_Email");
tmap.ColumnMappings.Add("Candidate_BankName", "Candidate_BankName");
tmap.ColumnMappings.Add("Candidate_BankAccountNumber", "Candidate_BankAccountNumber");
tmap.ColumnMappings.Add("Candidate_EmergencyContactName1", "Candidate_EmergencyContactName1");
tmap.ColumnMappings.Add("Candidate_EmergencyContactNumber1", "Candidate_EmergencyContactNumber1");
tmap.ColumnMappings.Add("Candidate_EmergencyContactNumber1Alternative", "Candidate_EmergencyContactNumber1Alternative");
tmap.ColumnMappings.Add("Candidate_EmergencyContactRelationship1", "Candidate_EmergencyContactRelationship1");
tmap.ColumnMappings.Add("Candidate_EmergencyContactName2", "Candidate_EmergencyContactName2");
tmap.ColumnMappings.Add("Candidate_EmergencyContactNumber2", "Candidate_EmergencyContactNumber2");
tmap.ColumnMappings.Add("Candidate_EmergencyContactNumber2Alternative", "Candidate_EmergencyContactNumber2Alternative");
tmap.ColumnMappings.Add("Candidate_EmergencyContactRelationship2", "Candidate_EmergencyContactRelationship2");
tmap.ColumnMappings.Add("Candidate_FatherGuardianName", "Candidate_FatherGuardianName");
tmap.ColumnMappings.Add("Candidate_FatherGuardianIC", "Candidate_FatherGuardianIC");
tmap.ColumnMappings.Add("Candidate_FatherGuardianTypeOfOccupation", "Candidate_FatherGuardianTypeOfOccupation");
tmap.ColumnMappings.Add("Candidate_FatherGuardianEmployerName", "Candidate_FatherGuardianEmployerName");
tmap.ColumnMappings.Add("Candidate_MotherGuardianName", "Candidate_MotherGuardianName");
tmap.ColumnMappings.Add("Candidate_MotherGuardianIC", "Candidate_MotherGuardianIC");
tmap.ColumnMappings.Add("Candidate_MotherGuardianTypeOfOccupation", "Candidate_MotherGuardianTypeOfOccupation");
tmap.ColumnMappings.Add("Candidate_MotherGuardianEmployerName", "Candidate_MotherGuardianEmployerName");
tmap.ColumnMappings.Add("Candidate_IsDeleted", "Candidate_IsDeleted");
tmap.ColumnMappings.Add("Candidate_CreatedDate", "Candidate_CreatedDate");
tmap.ColumnMappings.Add("Candidate_CreatedBy", "Candidate_CreatedBy");
tmap.ColumnMappings.Add("Candidate_UpdatedDate", "Candidate_UpdatedDate");
tmap.ColumnMappings.Add("Candidate_UpdatedBy", "Candidate_UpdatedBy");
tmap.ColumnMappings.Add("Candidate_Postcode", "Candidate_Postcode");
tmap.ColumnMappings.Add("Candidate_State", "Candidate_State");
tmap.ColumnMappings.Add("Candidate_Nationality", "Candidate_Nationality");
tmap.ColumnMappings.Add("Candidate_IsBumiputra", "Candidate_IsBumiputra");
tmap.ColumnMappings.Add("Candidate_Remark", "Candidate_Remark");
tmap.ColumnMappings.Add("Candidate_OtherEthnicity", "Candidate_OtherEthnicity");
tmap.ColumnMappings.Add("Country_ID", "Country_ID");
tmap.ColumnMappings.Add("Candidate_Position", "Candidate_Position");
tmap.ColumnMappings.Add("Candidate_Sector", "Candidate_Sector");
tmap.ColumnMappings.Add("Candidate_MotherIncome", "Candidate_MotherIncome");
tmap.ColumnMappings.Add("Candidate_FatherIncome", "Candidate_FatherIncome");
tmap.ColumnMappings.Add("Candidate_StudyCountry", "Candidate_StudyCountry");
tmap.ColumnMappings.Add("Candidate_MIA", "Candidate_MIA");
tmap.ColumnMappings.Add("Candidate_MIAImage", "Candidate_MIAImage");
tmap.ColumnMappings.Add("Candidate_MIAFile", "Candidate_MIAFile");
adapter.TableMappings.Add(tmap);
}
// insert command
adapter.InsertCommand = new SqlCommand("INSERT INTO [Candidate] ([Candidate_ID], [Candidate_UserID], [Candidate_Password], [Candidate_FullName], [Candidate_DOB], [Candidate_Gender], [Candidate_ICNumber], [Candidate_CurrentlyEmployed], [Candidate_EducationLevel1], [Candidate_FieldOfStudy1], [Candidate_EducationLevel2], [Candidate_FieldOfStudy2], [Candidate_EducationLevel3], [Candidate_FieldOfStudy3], [Candidate_EducationLevel4], [Candidate_FieldOfStudy4], [Candidate_EducationLevel5], [Candidate_FieldOfStudy5], [Candidate_CurrentlyPursuingHighestLevel], [Candidate_HighestEducation], [Candidate_Address1], [Candidate_Address2], [Candidate_City], [Candidate_PhonePrefix], [Candidate_PhoneNumber], [Candidate_MobilePhonePrefix], [Candidate_MobilePhoneNumber], [Candidate_Email], [Candidate_BankName], [Candidate_BankAccountNumber], [Candidate_EmergencyContactName1], [Candidate_EmergencyContactNumber1], [Candidate_EmergencyContactNumber1Alternative], [Candidate_EmergencyContactRelationship1], [Candidate_EmergencyContactName2], [Candidate_EmergencyContactNumber2], [Candidate_EmergencyContactNumber2Alternative], [Candidate_EmergencyContactRelationship2], [Candidate_FatherGuardianName], [Candidate_FatherGuardianIC], [Candidate_FatherGuardianTypeOfOccupation], [Candidate_FatherGuardianEmployerName], [Candidate_MotherGuardianName], [Candidate_MotherGuardianIC], [Candidate_MotherGuardianTypeOfOccupation], [Candidate_MotherGuardianEmployerName], [Candidate_IsDeleted], [Candidate_CreatedDate], [Candidate_CreatedBy], [Candidate_UpdatedDate], [Candidate_UpdatedBy], [Candidate_Postcode], [Candidate_State], [Candidate_Nationality], [Candidate_IsBumiputra], [Candidate_Remark], [Candidate_OtherEthnicity], [Country_ID], [Candidate_Position], [Candidate_Sector], [Candidate_MotherIncome], [Candidate_FatherIncome], [Candidate_StudyCountry], [Candidate_MIA], [Candidate_MIAImage], [Candidate_MIAFile]) VALUES (@Candidate_ID, @Candidate_UserID, @Candidate_Password, @Candidate_FullName, @Candidate_DOB, @Candidate_Gender, @Candidate_ICNumber, @Candidate_CurrentlyEmployed, @Candidate_EducationLevel1, @Candidate_FieldOfStudy1, @Candidate_EducationLevel2, @Candidate_FieldOfStudy2, @Candidate_EducationLevel3, @Candidate_FieldOfStudy3, @Candidate_EducationLevel4, @Candidate_FieldOfStudy4, @Candidate_EducationLevel5, @Candidate_FieldOfStudy5, @Candidate_CurrentlyPursuingHighestLevel, @Candidate_HighestEducation, @Candidate_Address1, @Candidate_Address2, @Candidate_City, @Candidate_PhonePrefix, @Candidate_PhoneNumber, @Candidate_MobilePhonePrefix, @Candidate_MobilePhoneNumber, @Candidate_Email, @Candidate_BankName, @Candidate_BankAccountNumber, @Candidate_EmergencyContactName1, @Candidate_EmergencyContactNumber1, @Candidate_EmergencyContactNumber1Alternative, @Candidate_EmergencyContactRelationship1, @Candidate_EmergencyContactName2, @Candidate_EmergencyContactNumber2, @Candidate_EmergencyContactNumber2Alternative, @Candidate_EmergencyContactRelationship2, @Candidate_FatherGuardianName, @Candidate_FatherGuardianIC, @Candidate_FatherGuardianTypeOfOccupation, @Candidate_FatherGuardianEmployerName, @Candidate_MotherGuardianName, @Candidate_MotherGuardianIC, @Candidate_MotherGuardianTypeOfOccupation, @Candidate_MotherGuardianEmployerName, @Candidate_IsDeleted, @Candidate_CreatedDate, @Candidate_CreatedBy, @Candidate_UpdatedDate, @Candidate_UpdatedBy, @Candidate_Postcode, @Candidate_State, @Candidate_Nationality, @Candidate_IsBumiputra, @Candidate_Remark, @Candidate_OtherEthnicity, @Country_ID, @Candidate_Position, @Candidate_Sector, @Candidate_MotherIncome, @Candidate_FatherIncome, @Candidate_StudyCountry, @Candidate_MIA, @Candidate_MIAImage, @Candidate_MIAFile)");
adapter.InsertCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.InsertCommand.Parameters.Add("@Candidate_UserID", SqlDbType.NVarChar, 0, "Candidate_UserID");
adapter.InsertCommand.Parameters.Add("@Candidate_Password", SqlDbType.NVarChar, 0, "Candidate_Password");
adapter.InsertCommand.Parameters.Add("@Candidate_FullName", SqlDbType.NVarChar, 0, "Candidate_FullName");
adapter.InsertCommand.Parameters.Add("@Candidate_DOB", SqlDbType.DateTime, 0, "Candidate_DOB");
adapter.InsertCommand.Parameters.Add("@Candidate_Gender", SqlDbType.SmallInt, 0, "Candidate_Gender");
adapter.InsertCommand.Parameters.Add("@Candidate_ICNumber", SqlDbType.NVarChar, 0, "Candidate_ICNumber");
adapter.InsertCommand.Parameters.Add("@Candidate_CurrentlyEmployed", SqlDbType.Bit, 0, "Candidate_CurrentlyEmployed");
adapter.InsertCommand.Parameters.Add("@Candidate_EducationLevel1", SqlDbType.NVarChar, 0, "Candidate_EducationLevel1");
adapter.InsertCommand.Parameters.Add("@Candidate_FieldOfStudy1", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy1");
adapter.InsertCommand.Parameters.Add("@Candidate_EducationLevel2", SqlDbType.NVarChar, 0, "Candidate_EducationLevel2");
adapter.InsertCommand.Parameters.Add("@Candidate_FieldOfStudy2", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy2");
adapter.InsertCommand.Parameters.Add("@Candidate_EducationLevel3", SqlDbType.NVarChar, 0, "Candidate_EducationLevel3");
adapter.InsertCommand.Parameters.Add("@Candidate_FieldOfStudy3", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy3");
adapter.InsertCommand.Parameters.Add("@Candidate_EducationLevel4", SqlDbType.NVarChar, 0, "Candidate_EducationLevel4");
adapter.InsertCommand.Parameters.Add("@Candidate_FieldOfStudy4", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy4");
adapter.InsertCommand.Parameters.Add("@Candidate_EducationLevel5", SqlDbType.NVarChar, 0, "Candidate_EducationLevel5");
adapter.InsertCommand.Parameters.Add("@Candidate_FieldOfStudy5", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy5");
adapter.InsertCommand.Parameters.Add("@Candidate_CurrentlyPursuingHighestLevel", SqlDbType.Bit, 0, "Candidate_CurrentlyPursuingHighestLevel");
adapter.InsertCommand.Parameters.Add("@Candidate_HighestEducation", SqlDbType.NVarChar, 0, "Candidate_HighestEducation");
adapter.InsertCommand.Parameters.Add("@Candidate_Address1", SqlDbType.NVarChar, 0, "Candidate_Address1");
adapter.InsertCommand.Parameters.Add("@Candidate_Address2", SqlDbType.NVarChar, 0, "Candidate_Address2");
adapter.InsertCommand.Parameters.Add("@Candidate_City", SqlDbType.NVarChar, 0, "Candidate_City");
adapter.InsertCommand.Parameters.Add("@Candidate_PhonePrefix", SqlDbType.NVarChar, 0, "Candidate_PhonePrefix");
adapter.InsertCommand.Parameters.Add("@Candidate_PhoneNumber", SqlDbType.NVarChar, 0, "Candidate_PhoneNumber");
adapter.InsertCommand.Parameters.Add("@Candidate_MobilePhonePrefix", SqlDbType.NVarChar, 0, "Candidate_MobilePhonePrefix");
adapter.InsertCommand.Parameters.Add("@Candidate_MobilePhoneNumber", SqlDbType.NVarChar, 0, "Candidate_MobilePhoneNumber");
adapter.InsertCommand.Parameters.Add("@Candidate_Email", SqlDbType.NVarChar, 0, "Candidate_Email");
adapter.InsertCommand.Parameters.Add("@Candidate_BankName", SqlDbType.NVarChar, 0, "Candidate_BankName");
adapter.InsertCommand.Parameters.Add("@Candidate_BankAccountNumber", SqlDbType.NVarChar, 0, "Candidate_BankAccountNumber");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactName1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactName1");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactNumber1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber1");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactNumber1Alternative", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber1Alternative");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactRelationship1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactRelationship1");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactName2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactName2");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactNumber2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber2");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactNumber2Alternative", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber2Alternative");
adapter.InsertCommand.Parameters.Add("@Candidate_EmergencyContactRelationship2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactRelationship2");
adapter.InsertCommand.Parameters.Add("@Candidate_FatherGuardianName", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianName");
adapter.InsertCommand.Parameters.Add("@Candidate_FatherGuardianIC", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianIC");
adapter.InsertCommand.Parameters.Add("@Candidate_FatherGuardianTypeOfOccupation", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianTypeOfOccupation");
adapter.InsertCommand.Parameters.Add("@Candidate_FatherGuardianEmployerName", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianEmployerName");
adapter.InsertCommand.Parameters.Add("@Candidate_MotherGuardianName", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianName");
adapter.InsertCommand.Parameters.Add("@Candidate_MotherGuardianIC", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianIC");
adapter.InsertCommand.Parameters.Add("@Candidate_MotherGuardianTypeOfOccupation", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianTypeOfOccupation");
adapter.InsertCommand.Parameters.Add("@Candidate_MotherGuardianEmployerName", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianEmployerName");
adapter.InsertCommand.Parameters.Add("@Candidate_IsDeleted", SqlDbType.Bit, 0, "Candidate_IsDeleted");
adapter.InsertCommand.Parameters.Add("@Candidate_CreatedDate", SqlDbType.DateTime, 0, "Candidate_CreatedDate");
adapter.InsertCommand.Parameters.Add("@Candidate_CreatedBy", SqlDbType.NVarChar, 0, "Candidate_CreatedBy");
adapter.InsertCommand.Parameters.Add("@Candidate_UpdatedDate", SqlDbType.DateTime, 0, "Candidate_UpdatedDate");
adapter.InsertCommand.Parameters.Add("@Candidate_UpdatedBy", SqlDbType.NVarChar, 0, "Candidate_UpdatedBy");
adapter.InsertCommand.Parameters.Add("@Candidate_Postcode", SqlDbType.NVarChar, 0, "Candidate_Postcode");
adapter.InsertCommand.Parameters.Add("@Candidate_State", SqlDbType.NVarChar, 0, "Candidate_State");
adapter.InsertCommand.Parameters.Add("@Candidate_Nationality", SqlDbType.Int, 0, "Candidate_Nationality");
adapter.InsertCommand.Parameters.Add("@Candidate_IsBumiputra", SqlDbType.Bit, 0, "Candidate_IsBumiputra");
adapter.InsertCommand.Parameters.Add("@Candidate_Remark", SqlDbType.NVarChar, 0, "Candidate_Remark");
adapter.InsertCommand.Parameters.Add("@Candidate_OtherEthnicity", SqlDbType.NVarChar, 0, "Candidate_OtherEthnicity");
adapter.InsertCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.InsertCommand.Parameters.Add("@Candidate_Position", SqlDbType.NVarChar, 0, "Candidate_Position");
adapter.InsertCommand.Parameters.Add("@Candidate_Sector", SqlDbType.NVarChar, 0, "Candidate_Sector");
adapter.InsertCommand.Parameters.Add("@Candidate_MotherIncome", SqlDbType.Decimal, 0, "Candidate_MotherIncome");
adapter.InsertCommand.Parameters.Add("@Candidate_FatherIncome", SqlDbType.Decimal, 0, "Candidate_FatherIncome");
adapter.InsertCommand.Parameters.Add("@Candidate_StudyCountry", SqlDbType.NVarChar, 0, "Candidate_StudyCountry");
adapter.InsertCommand.Parameters.Add("@Candidate_MIA", SqlDbType.NVarChar, 0, "Candidate_MIA");
adapter.InsertCommand.Parameters.Add("@Candidate_MIAImage", SqlDbType.NVarChar, 0, "Candidate_MIAImage");
adapter.InsertCommand.Parameters.Add("@Candidate_MIAFile", SqlDbType.NVarChar, 0, "Candidate_MIAFile");
// update command
adapter.UpdateCommand = new SqlCommand("UPDATE [Candidate] SET [Candidate_ID] = @Candidate_ID, [Candidate_UserID] = @Candidate_UserID, [Candidate_Password] = @Candidate_Password, [Candidate_FullName] = @Candidate_FullName, [Candidate_DOB] = @Candidate_DOB, [Candidate_Gender] = @Candidate_Gender, [Candidate_ICNumber] = @Candidate_ICNumber, [Candidate_CurrentlyEmployed] = @Candidate_CurrentlyEmployed, [Candidate_EducationLevel1] = @Candidate_EducationLevel1, [Candidate_FieldOfStudy1] = @Candidate_FieldOfStudy1, [Candidate_EducationLevel2] = @Candidate_EducationLevel2, [Candidate_FieldOfStudy2] = @Candidate_FieldOfStudy2, [Candidate_EducationLevel3] = @Candidate_EducationLevel3, [Candidate_FieldOfStudy3] = @Candidate_FieldOfStudy3, [Candidate_EducationLevel4] = @Candidate_EducationLevel4, [Candidate_FieldOfStudy4] = @Candidate_FieldOfStudy4, [Candidate_EducationLevel5] = @Candidate_EducationLevel5, [Candidate_FieldOfStudy5] = @Candidate_FieldOfStudy5, [Candidate_CurrentlyPursuingHighestLevel] = @Candidate_CurrentlyPursuingHighestLevel, [Candidate_HighestEducation] = @Candidate_HighestEducation, [Candidate_Address1] = @Candidate_Address1, [Candidate_Address2] = @Candidate_Address2, [Candidate_City] = @Candidate_City, [Candidate_PhonePrefix] = @Candidate_PhonePrefix, [Candidate_PhoneNumber] = @Candidate_PhoneNumber, [Candidate_MobilePhonePrefix] = @Candidate_MobilePhonePrefix, [Candidate_MobilePhoneNumber] = @Candidate_MobilePhoneNumber, [Candidate_Email] = @Candidate_Email, [Candidate_BankName] = @Candidate_BankName, [Candidate_BankAccountNumber] = @Candidate_BankAccountNumber, [Candidate_EmergencyContactName1] = @Candidate_EmergencyContactName1, [Candidate_EmergencyContactNumber1] = @Candidate_EmergencyContactNumber1, [Candidate_EmergencyContactNumber1Alternative] = @Candidate_EmergencyContactNumber1Alternative, [Candidate_EmergencyContactRelationship1] = @Candidate_EmergencyContactRelationship1, [Candidate_EmergencyContactName2] = @Candidate_EmergencyContactName2, [Candidate_EmergencyContactNumber2] = @Candidate_EmergencyContactNumber2, [Candidate_EmergencyContactNumber2Alternative] = @Candidate_EmergencyContactNumber2Alternative, [Candidate_EmergencyContactRelationship2] = @Candidate_EmergencyContactRelationship2, [Candidate_FatherGuardianName] = @Candidate_FatherGuardianName, [Candidate_FatherGuardianIC] = @Candidate_FatherGuardianIC, [Candidate_FatherGuardianTypeOfOccupation] = @Candidate_FatherGuardianTypeOfOccupation, [Candidate_FatherGuardianEmployerName] = @Candidate_FatherGuardianEmployerName, [Candidate_MotherGuardianName] = @Candidate_MotherGuardianName, [Candidate_MotherGuardianIC] = @Candidate_MotherGuardianIC, [Candidate_MotherGuardianTypeOfOccupation] = @Candidate_MotherGuardianTypeOfOccupation, [Candidate_MotherGuardianEmployerName] = @Candidate_MotherGuardianEmployerName, [Candidate_IsDeleted] = @Candidate_IsDeleted, [Candidate_CreatedDate] = @Candidate_CreatedDate, [Candidate_CreatedBy] = @Candidate_CreatedBy, [Candidate_UpdatedDate] = @Candidate_UpdatedDate, [Candidate_UpdatedBy] = @Candidate_UpdatedBy, [Candidate_Postcode] = @Candidate_Postcode, [Candidate_State] = @Candidate_State, [Candidate_Nationality] = @Candidate_Nationality, [Candidate_IsBumiputra] = @Candidate_IsBumiputra, [Candidate_Remark] = @Candidate_Remark, [Candidate_OtherEthnicity] = @Candidate_OtherEthnicity, [Country_ID] = @Country_ID, [Candidate_Position] = @Candidate_Position, [Candidate_Sector] = @Candidate_Sector, [Candidate_MotherIncome] = @Candidate_MotherIncome, [Candidate_FatherIncome] = @Candidate_FatherIncome, [Candidate_StudyCountry] = @Candidate_StudyCountry, [Candidate_MIA] = @Candidate_MIA, [Candidate_MIAImage] = @Candidate_MIAImage, [Candidate_MIAFile] = @Candidate_MIAFile WHERE [Candidate_ID] = @o_Candidate_ID");
adapter.UpdateCommand.Parameters.Add("@Candidate_ID", SqlDbType.UniqueIdentifier, 0, "Candidate_ID");
adapter.UpdateCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
adapter.UpdateCommand.Parameters.Add("@Candidate_UserID", SqlDbType.NVarChar, 0, "Candidate_UserID");
adapter.UpdateCommand.Parameters.Add("@Candidate_Password", SqlDbType.NVarChar, 0, "Candidate_Password");
adapter.UpdateCommand.Parameters.Add("@Candidate_FullName", SqlDbType.NVarChar, 0, "Candidate_FullName");
adapter.UpdateCommand.Parameters.Add("@Candidate_DOB", SqlDbType.DateTime, 0, "Candidate_DOB");
adapter.UpdateCommand.Parameters.Add("@Candidate_Gender", SqlDbType.SmallInt, 0, "Candidate_Gender");
adapter.UpdateCommand.Parameters.Add("@Candidate_ICNumber", SqlDbType.NVarChar, 0, "Candidate_ICNumber");
adapter.UpdateCommand.Parameters.Add("@Candidate_CurrentlyEmployed", SqlDbType.Bit, 0, "Candidate_CurrentlyEmployed");
adapter.UpdateCommand.Parameters.Add("@Candidate_EducationLevel1", SqlDbType.NVarChar, 0, "Candidate_EducationLevel1");
adapter.UpdateCommand.Parameters.Add("@Candidate_FieldOfStudy1", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy1");
adapter.UpdateCommand.Parameters.Add("@Candidate_EducationLevel2", SqlDbType.NVarChar, 0, "Candidate_EducationLevel2");
adapter.UpdateCommand.Parameters.Add("@Candidate_FieldOfStudy2", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy2");
adapter.UpdateCommand.Parameters.Add("@Candidate_EducationLevel3", SqlDbType.NVarChar, 0, "Candidate_EducationLevel3");
adapter.UpdateCommand.Parameters.Add("@Candidate_FieldOfStudy3", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy3");
adapter.UpdateCommand.Parameters.Add("@Candidate_EducationLevel4", SqlDbType.NVarChar, 0, "Candidate_EducationLevel4");
adapter.UpdateCommand.Parameters.Add("@Candidate_FieldOfStudy4", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy4");
adapter.UpdateCommand.Parameters.Add("@Candidate_EducationLevel5", SqlDbType.NVarChar, 0, "Candidate_EducationLevel5");
adapter.UpdateCommand.Parameters.Add("@Candidate_FieldOfStudy5", SqlDbType.NVarChar, 0, "Candidate_FieldOfStudy5");
adapter.UpdateCommand.Parameters.Add("@Candidate_CurrentlyPursuingHighestLevel", SqlDbType.Bit, 0, "Candidate_CurrentlyPursuingHighestLevel");
adapter.UpdateCommand.Parameters.Add("@Candidate_HighestEducation", SqlDbType.NVarChar, 0, "Candidate_HighestEducation");
adapter.UpdateCommand.Parameters.Add("@Candidate_Address1", SqlDbType.NVarChar, 0, "Candidate_Address1");
adapter.UpdateCommand.Parameters.Add("@Candidate_Address2", SqlDbType.NVarChar, 0, "Candidate_Address2");
adapter.UpdateCommand.Parameters.Add("@Candidate_City", SqlDbType.NVarChar, 0, "Candidate_City");
adapter.UpdateCommand.Parameters.Add("@Candidate_PhonePrefix", SqlDbType.NVarChar, 0, "Candidate_PhonePrefix");
adapter.UpdateCommand.Parameters.Add("@Candidate_PhoneNumber", SqlDbType.NVarChar, 0, "Candidate_PhoneNumber");
adapter.UpdateCommand.Parameters.Add("@Candidate_MobilePhonePrefix", SqlDbType.NVarChar, 0, "Candidate_MobilePhonePrefix");
adapter.UpdateCommand.Parameters.Add("@Candidate_MobilePhoneNumber", SqlDbType.NVarChar, 0, "Candidate_MobilePhoneNumber");
adapter.UpdateCommand.Parameters.Add("@Candidate_Email", SqlDbType.NVarChar, 0, "Candidate_Email");
adapter.UpdateCommand.Parameters.Add("@Candidate_BankName", SqlDbType.NVarChar, 0, "Candidate_BankName");
adapter.UpdateCommand.Parameters.Add("@Candidate_BankAccountNumber", SqlDbType.NVarChar, 0, "Candidate_BankAccountNumber");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactName1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactName1");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactNumber1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber1");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactNumber1Alternative", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber1Alternative");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactRelationship1", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactRelationship1");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactName2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactName2");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactNumber2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber2");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactNumber2Alternative", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactNumber2Alternative");
adapter.UpdateCommand.Parameters.Add("@Candidate_EmergencyContactRelationship2", SqlDbType.NVarChar, 0, "Candidate_EmergencyContactRelationship2");
adapter.UpdateCommand.Parameters.Add("@Candidate_FatherGuardianName", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianName");
adapter.UpdateCommand.Parameters.Add("@Candidate_FatherGuardianIC", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianIC");
adapter.UpdateCommand.Parameters.Add("@Candidate_FatherGuardianTypeOfOccupation", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianTypeOfOccupation");
adapter.UpdateCommand.Parameters.Add("@Candidate_FatherGuardianEmployerName", SqlDbType.NVarChar, 0, "Candidate_FatherGuardianEmployerName");
adapter.UpdateCommand.Parameters.Add("@Candidate_MotherGuardianName", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianName");
adapter.UpdateCommand.Parameters.Add("@Candidate_MotherGuardianIC", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianIC");
adapter.UpdateCommand.Parameters.Add("@Candidate_MotherGuardianTypeOfOccupation", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianTypeOfOccupation");
adapter.UpdateCommand.Parameters.Add("@Candidate_MotherGuardianEmployerName", SqlDbType.NVarChar, 0, "Candidate_MotherGuardianEmployerName");
adapter.UpdateCommand.Parameters.Add("@Candidate_IsDeleted", SqlDbType.Bit, 0, "Candidate_IsDeleted");
adapter.UpdateCommand.Parameters.Add("@Candidate_CreatedDate", SqlDbType.DateTime, 0, "Candidate_CreatedDate");
adapter.UpdateCommand.Parameters.Add("@Candidate_CreatedBy", SqlDbType.NVarChar, 0, "Candidate_CreatedBy");
adapter.UpdateCommand.Parameters.Add("@Candidate_UpdatedDate", SqlDbType.DateTime, 0, "Candidate_UpdatedDate");
adapter.UpdateCommand.Parameters.Add("@Candidate_UpdatedBy", SqlDbType.NVarChar, 0, "Candidate_UpdatedBy");
adapter.UpdateCommand.Parameters.Add("@Candidate_Postcode", SqlDbType.NVarChar, 0, "Candidate_Postcode");
adapter.UpdateCommand.Parameters.Add("@Candidate_State", SqlDbType.NVarChar, 0, "Candidate_State");
adapter.UpdateCommand.Parameters.Add("@Candidate_Nationality", SqlDbType.Int, 0, "Candidate_Nationality");
adapter.UpdateCommand.Parameters.Add("@Candidate_IsBumiputra", SqlDbType.Bit, 0, "Candidate_IsBumiputra");
adapter.UpdateCommand.Parameters.Add("@Candidate_Remark", SqlDbType.NVarChar, 0, "Candidate_Remark");
adapter.UpdateCommand.Parameters.Add("@Candidate_OtherEthnicity", SqlDbType.NVarChar, 0, "Candidate_OtherEthnicity");
adapter.UpdateCommand.Parameters.Add("@Country_ID", SqlDbType.UniqueIdentifier, 0, "Country_ID");
adapter.UpdateCommand.Parameters.Add("@Candidate_Position", SqlDbType.NVarChar, 0, "Candidate_Position");
adapter.UpdateCommand.Parameters.Add("@Candidate_Sector", SqlDbType.NVarChar, 0, "Candidate_Sector");
adapter.UpdateCommand.Parameters.Add("@Candidate_MotherIncome", SqlDbType.Decimal, 0, "Candidate_MotherIncome");
adapter.UpdateCommand.Parameters.Add("@Candidate_FatherIncome", SqlDbType.Decimal, 0, "Candidate_FatherIncome");
adapter.UpdateCommand.Parameters.Add("@Candidate_StudyCountry", SqlDbType.NVarChar, 0, "Candidate_StudyCountry");
adapter.UpdateCommand.Parameters.Add("@Candidate_MIA", SqlDbType.NVarChar, 0, "Candidate_MIA");
adapter.UpdateCommand.Parameters.Add("@Candidate_MIAImage", SqlDbType.NVarChar, 0, "Candidate_MIAImage");
adapter.UpdateCommand.Parameters.Add("@Candidate_MIAFile", SqlDbType.NVarChar, 0, "Candidate_MIAFile");
// delete command
adapter.DeleteCommand = new SqlCommand("DELETE FROM [Candidate] WHERE [Candidate_ID] = @o_Candidate_ID");
adapter.DeleteCommand.Parameters.Add(new SqlParameter("@o_Candidate_ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, false, 0, 0, "Candidate_ID", DataRowVersion.Original, null));
}
public void Update(CandidateTable tbl, IActivityLog log) {
Log(tbl, log);
DA.ExecuteAdapter(Adapter, tbl);
}
public void Update(CandidateRow dr, IActivityLog log) {
Log(dr, log);
DA.ExecuteAdapter(Adapter, dr);
}
public CandidateRow GetByCandidate_ID(System.Guid Candidate_ID ) {
string sql = "SELECT * FROM [Candidate] WHERE [Candidate_ID] = @Candidate_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);

CandidateTable tbl = new CandidateTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetCandidateRow(0);
}
public int CountByCandidate_ID(System.Guid Candidate_ID ) {
string sql = "SELECT COUNT(*) FROM [Candidate] WHERE [Candidate_ID] = @Candidate_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);

return DA.ExecuteInt32(com);
}
public int DeleteByCandidate_ID(System.Guid Candidate_ID, IActivityLog log ) {
string sql = "DELETE FROM [Candidate] WHERE [Candidate_ID] = @Candidate_ID";
SqlCommand com = new SqlCommand(sql);
com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);

if(log!=null) log.AddTransaction(com);
return DA.ExecuteNonQuery(com);
}
}
}
