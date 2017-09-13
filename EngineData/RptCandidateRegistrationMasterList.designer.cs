using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class RptCandidateRegistrationMasterListTable : DataTable {
// column indexes
public const int UserIDColumnIndex = 0;
public const int FullNameColumnIndex = 1;
public const int DOBColumnIndex = 2;
public const int GenderColumnIndex = 3;
public const int ICNumberColumnIndex = 4;
public const int CurrentlyEmployedColumnIndex = 5;
public const int EducationLevel1ColumnIndex = 6;
public const int FieldOfStudy1ColumnIndex = 7;
public const int EducationLevel2ColumnIndex = 8;
public const int FieldOfStudy2ColumnIndex = 9;
public const int EducationLevel3ColumnIndex = 10;
public const int FieldOfStudy3ColumnIndex = 11;
public const int EducationLevel4ColumnIndex = 12;
public const int FieldOfStudy4ColumnIndex = 13;
public const int EducationLevel5ColumnIndex = 14;
public const int FieldOfStudy5ColumnIndex = 15;
public const int CurrentlyPursuingHighestLevelColumnIndex = 16;
public const int HighestEducationColumnIndex = 17;
public const int Address1ColumnIndex = 18;
public const int Address2ColumnIndex = 19;
public const int CityColumnIndex = 20;
public const int CountryColumnIndex = 21;
public const int PhoneNumberColumnIndex = 22;
public const int MobileColumnIndex = 23;
public const int EmailColumnIndex = 24;
public const int BankNameColumnIndex = 25;
public const int BankAccountNumberColumnIndex = 26;
public const int EmergencyContactName1ColumnIndex = 27;
public const int EmergencyContactNumber1ColumnIndex = 28;
public const int EmergencyContactNumber1AlternativeColumnIndex = 29;
public const int EmergencyContactRelationship1ColumnIndex = 30;
public const int EmergencyContactName2ColumnIndex = 31;
public const int EmergencyContactNumber2ColumnIndex = 32;
public const int EmergencyContactNumber2AlternativeColumnIndex = 33;
public const int EmergencyContactRelationship2ColumnIndex = 34;
public const int FatherGuardianNameColumnIndex = 35;
public const int FatherGuardianICColumnIndex = 36;
public const int FatherGuardianTypeOfOccupationColumnIndex = 37;
public const int FatherGuardianEmployerNameColumnIndex = 38;
public const int MotherGuardianNameColumnIndex = 39;
public const int MotherGuardianICColumnIndex = 40;
public const int MotherGuardianTypeOfOccupationColumnIndex = 41;
public const int MotherGuardianEmployerNameColumnIndex = 42;
public const int CreatedDateColumnIndex = 43;
public const int CreatedByColumnIndex = 44;
public const int UpdatedDateColumnIndex = 45;
public const int UpdatedbyColumnIndex = 46;
public const int PostcodeColumnIndex = 47;
public const int StateColumnIndex = 48;
public const int NationalityColumnIndex = 49;
public const int IsBumiputraColumnIndex = 50;
public const int RemarkColumnIndex = 51;
public RptCandidateRegistrationMasterListTable() {
TableName = "[RptCandidateRegistrationMasterList]";
// column UserID
DataColumn UserIDCol = new DataColumn("UserID", typeof(System.String));
UserIDCol.ReadOnly = true;
UserIDCol.AllowDBNull = false;
Columns.Add(UserIDCol);
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
// column CurrentlyEmployed
DataColumn CurrentlyEmployedCol = new DataColumn("CurrentlyEmployed", typeof(System.String));
CurrentlyEmployedCol.ReadOnly = true;
CurrentlyEmployedCol.AllowDBNull = false;
Columns.Add(CurrentlyEmployedCol);
// column EducationLevel1
DataColumn EducationLevel1Col = new DataColumn("EducationLevel1", typeof(System.String));
EducationLevel1Col.ReadOnly = true;
EducationLevel1Col.AllowDBNull = false;
Columns.Add(EducationLevel1Col);
// column FieldOfStudy1
DataColumn FieldOfStudy1Col = new DataColumn("FieldOfStudy1", typeof(System.String));
FieldOfStudy1Col.ReadOnly = true;
FieldOfStudy1Col.AllowDBNull = false;
Columns.Add(FieldOfStudy1Col);
// column EducationLevel2
DataColumn EducationLevel2Col = new DataColumn("EducationLevel2", typeof(System.String));
EducationLevel2Col.ReadOnly = true;
EducationLevel2Col.AllowDBNull = false;
Columns.Add(EducationLevel2Col);
// column FieldOfStudy2
DataColumn FieldOfStudy2Col = new DataColumn("FieldOfStudy2", typeof(System.String));
FieldOfStudy2Col.ReadOnly = true;
FieldOfStudy2Col.AllowDBNull = false;
Columns.Add(FieldOfStudy2Col);
// column EducationLevel3
DataColumn EducationLevel3Col = new DataColumn("EducationLevel3", typeof(System.String));
EducationLevel3Col.ReadOnly = true;
EducationLevel3Col.AllowDBNull = false;
Columns.Add(EducationLevel3Col);
// column FieldOfStudy3
DataColumn FieldOfStudy3Col = new DataColumn("FieldOfStudy3", typeof(System.String));
FieldOfStudy3Col.ReadOnly = true;
FieldOfStudy3Col.AllowDBNull = false;
Columns.Add(FieldOfStudy3Col);
// column EducationLevel4
DataColumn EducationLevel4Col = new DataColumn("EducationLevel4", typeof(System.String));
EducationLevel4Col.ReadOnly = true;
EducationLevel4Col.AllowDBNull = false;
Columns.Add(EducationLevel4Col);
// column FieldOfStudy4
DataColumn FieldOfStudy4Col = new DataColumn("FieldOfStudy4", typeof(System.String));
FieldOfStudy4Col.ReadOnly = true;
FieldOfStudy4Col.AllowDBNull = false;
Columns.Add(FieldOfStudy4Col);
// column EducationLevel5
DataColumn EducationLevel5Col = new DataColumn("EducationLevel5", typeof(System.String));
EducationLevel5Col.ReadOnly = true;
EducationLevel5Col.AllowDBNull = false;
Columns.Add(EducationLevel5Col);
// column FieldOfStudy5
DataColumn FieldOfStudy5Col = new DataColumn("FieldOfStudy5", typeof(System.String));
FieldOfStudy5Col.ReadOnly = true;
FieldOfStudy5Col.AllowDBNull = false;
Columns.Add(FieldOfStudy5Col);
// column CurrentlyPursuingHighestLevel
DataColumn CurrentlyPursuingHighestLevelCol = new DataColumn("CurrentlyPursuingHighestLevel", typeof(System.String));
CurrentlyPursuingHighestLevelCol.ReadOnly = true;
CurrentlyPursuingHighestLevelCol.AllowDBNull = false;
Columns.Add(CurrentlyPursuingHighestLevelCol);
// column HighestEducation
DataColumn HighestEducationCol = new DataColumn("HighestEducation", typeof(System.String));
HighestEducationCol.ReadOnly = true;
HighestEducationCol.AllowDBNull = false;
Columns.Add(HighestEducationCol);
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
// column City
DataColumn CityCol = new DataColumn("City", typeof(System.String));
CityCol.ReadOnly = true;
CityCol.AllowDBNull = false;
Columns.Add(CityCol);
// column Country
DataColumn CountryCol = new DataColumn("Country", typeof(System.String));
CountryCol.ReadOnly = true;
CountryCol.AllowDBNull = false;
Columns.Add(CountryCol);
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
// column Email
DataColumn EmailCol = new DataColumn("Email", typeof(System.String));
EmailCol.ReadOnly = true;
EmailCol.AllowDBNull = false;
Columns.Add(EmailCol);
// column BankName
DataColumn BankNameCol = new DataColumn("BankName", typeof(System.String));
BankNameCol.ReadOnly = true;
BankNameCol.AllowDBNull = false;
Columns.Add(BankNameCol);
// column BankAccountNumber
DataColumn BankAccountNumberCol = new DataColumn("BankAccountNumber", typeof(System.String));
BankAccountNumberCol.ReadOnly = true;
BankAccountNumberCol.AllowDBNull = false;
Columns.Add(BankAccountNumberCol);
// column EmergencyContactName1
DataColumn EmergencyContactName1Col = new DataColumn("EmergencyContactName1", typeof(System.String));
EmergencyContactName1Col.ReadOnly = true;
EmergencyContactName1Col.AllowDBNull = false;
Columns.Add(EmergencyContactName1Col);
// column EmergencyContactNumber1
DataColumn EmergencyContactNumber1Col = new DataColumn("EmergencyContactNumber1", typeof(System.String));
EmergencyContactNumber1Col.ReadOnly = true;
EmergencyContactNumber1Col.AllowDBNull = false;
Columns.Add(EmergencyContactNumber1Col);
// column EmergencyContactNumber1Alternative
DataColumn EmergencyContactNumber1AlternativeCol = new DataColumn("EmergencyContactNumber1Alternative", typeof(System.String));
EmergencyContactNumber1AlternativeCol.ReadOnly = true;
EmergencyContactNumber1AlternativeCol.AllowDBNull = false;
Columns.Add(EmergencyContactNumber1AlternativeCol);
// column EmergencyContactRelationship1
DataColumn EmergencyContactRelationship1Col = new DataColumn("EmergencyContactRelationship1", typeof(System.String));
EmergencyContactRelationship1Col.ReadOnly = true;
EmergencyContactRelationship1Col.AllowDBNull = false;
Columns.Add(EmergencyContactRelationship1Col);
// column EmergencyContactName2
DataColumn EmergencyContactName2Col = new DataColumn("EmergencyContactName2", typeof(System.String));
EmergencyContactName2Col.ReadOnly = true;
EmergencyContactName2Col.AllowDBNull = false;
Columns.Add(EmergencyContactName2Col);
// column EmergencyContactNumber2
DataColumn EmergencyContactNumber2Col = new DataColumn("EmergencyContactNumber2", typeof(System.String));
EmergencyContactNumber2Col.ReadOnly = true;
EmergencyContactNumber2Col.AllowDBNull = false;
Columns.Add(EmergencyContactNumber2Col);
// column EmergencyContactNumber2Alternative
DataColumn EmergencyContactNumber2AlternativeCol = new DataColumn("EmergencyContactNumber2Alternative", typeof(System.String));
EmergencyContactNumber2AlternativeCol.ReadOnly = true;
EmergencyContactNumber2AlternativeCol.AllowDBNull = false;
Columns.Add(EmergencyContactNumber2AlternativeCol);
// column EmergencyContactRelationship2
DataColumn EmergencyContactRelationship2Col = new DataColumn("EmergencyContactRelationship2", typeof(System.String));
EmergencyContactRelationship2Col.ReadOnly = true;
EmergencyContactRelationship2Col.AllowDBNull = false;
Columns.Add(EmergencyContactRelationship2Col);
// column FatherGuardianName
DataColumn FatherGuardianNameCol = new DataColumn("FatherGuardianName", typeof(System.String));
FatherGuardianNameCol.ReadOnly = true;
FatherGuardianNameCol.AllowDBNull = false;
Columns.Add(FatherGuardianNameCol);
// column FatherGuardianIC
DataColumn FatherGuardianICCol = new DataColumn("FatherGuardianIC", typeof(System.String));
FatherGuardianICCol.ReadOnly = true;
FatherGuardianICCol.AllowDBNull = false;
Columns.Add(FatherGuardianICCol);
// column FatherGuardianTypeOfOccupation
DataColumn FatherGuardianTypeOfOccupationCol = new DataColumn("FatherGuardianTypeOfOccupation", typeof(System.String));
FatherGuardianTypeOfOccupationCol.ReadOnly = true;
FatherGuardianTypeOfOccupationCol.AllowDBNull = false;
Columns.Add(FatherGuardianTypeOfOccupationCol);
// column FatherGuardianEmployerName
DataColumn FatherGuardianEmployerNameCol = new DataColumn("FatherGuardianEmployerName", typeof(System.String));
FatherGuardianEmployerNameCol.ReadOnly = true;
FatherGuardianEmployerNameCol.AllowDBNull = false;
Columns.Add(FatherGuardianEmployerNameCol);
// column MotherGuardianName
DataColumn MotherGuardianNameCol = new DataColumn("MotherGuardianName", typeof(System.String));
MotherGuardianNameCol.ReadOnly = true;
MotherGuardianNameCol.AllowDBNull = false;
Columns.Add(MotherGuardianNameCol);
// column MotherGuardianIC
DataColumn MotherGuardianICCol = new DataColumn("MotherGuardianIC", typeof(System.String));
MotherGuardianICCol.ReadOnly = true;
MotherGuardianICCol.AllowDBNull = false;
Columns.Add(MotherGuardianICCol);
// column MotherGuardianTypeOfOccupation
DataColumn MotherGuardianTypeOfOccupationCol = new DataColumn("MotherGuardianTypeOfOccupation", typeof(System.String));
MotherGuardianTypeOfOccupationCol.ReadOnly = true;
MotherGuardianTypeOfOccupationCol.AllowDBNull = false;
Columns.Add(MotherGuardianTypeOfOccupationCol);
// column MotherGuardianEmployerName
DataColumn MotherGuardianEmployerNameCol = new DataColumn("MotherGuardianEmployerName", typeof(System.String));
MotherGuardianEmployerNameCol.ReadOnly = true;
MotherGuardianEmployerNameCol.AllowDBNull = false;
Columns.Add(MotherGuardianEmployerNameCol);
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
// column Updatedby
DataColumn UpdatedbyCol = new DataColumn("Updatedby", typeof(System.String));
UpdatedbyCol.ReadOnly = true;
UpdatedbyCol.AllowDBNull = false;
Columns.Add(UpdatedbyCol);
// column Postcode
DataColumn PostcodeCol = new DataColumn("Postcode", typeof(System.String));
PostcodeCol.ReadOnly = true;
PostcodeCol.AllowDBNull = false;
Columns.Add(PostcodeCol);
// column State
DataColumn StateCol = new DataColumn("State", typeof(System.String));
StateCol.ReadOnly = true;
StateCol.AllowDBNull = false;
Columns.Add(StateCol);
// column Nationality
DataColumn NationalityCol = new DataColumn("Nationality", typeof(System.String));
NationalityCol.ReadOnly = true;
NationalityCol.AllowDBNull = false;
Columns.Add(NationalityCol);
// column IsBumiputra
DataColumn IsBumiputraCol = new DataColumn("IsBumiputra", typeof(System.String));
IsBumiputraCol.ReadOnly = true;
IsBumiputraCol.AllowDBNull = false;
Columns.Add(IsBumiputraCol);
// column Remark
DataColumn RemarkCol = new DataColumn("Remark", typeof(System.String));
RemarkCol.ReadOnly = true;
RemarkCol.AllowDBNull = false;
Columns.Add(RemarkCol);
}
protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
return new RptCandidateRegistrationMasterListRow(builder);
}
public RptCandidateRegistrationMasterListRow GetRptCandidateRegistrationMasterListRow(int index) {
return (RptCandidateRegistrationMasterListRow)Rows[index];
}
}
public partial class RptCandidateRegistrationMasterListRow : DataRow {
internal RptCandidateRegistrationMasterListRow(DataRowBuilder builder) : base(builder) {
}
public System.String UserID {
get {
return (System.String)this["UserID"];
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
public System.String CurrentlyEmployed {
get {
return (System.String)this["CurrentlyEmployed"];
}
}
public System.String EducationLevel1 {
get {
return (System.String)this["EducationLevel1"];
}
}
public System.String FieldOfStudy1 {
get {
return (System.String)this["FieldOfStudy1"];
}
}
public System.String EducationLevel2 {
get {
return (System.String)this["EducationLevel2"];
}
}
public System.String FieldOfStudy2 {
get {
return (System.String)this["FieldOfStudy2"];
}
}
public System.String EducationLevel3 {
get {
return (System.String)this["EducationLevel3"];
}
}
public System.String FieldOfStudy3 {
get {
return (System.String)this["FieldOfStudy3"];
}
}
public System.String EducationLevel4 {
get {
return (System.String)this["EducationLevel4"];
}
}
public System.String FieldOfStudy4 {
get {
return (System.String)this["FieldOfStudy4"];
}
}
public System.String EducationLevel5 {
get {
return (System.String)this["EducationLevel5"];
}
}
public System.String FieldOfStudy5 {
get {
return (System.String)this["FieldOfStudy5"];
}
}
public System.String CurrentlyPursuingHighestLevel {
get {
return (System.String)this["CurrentlyPursuingHighestLevel"];
}
}
public System.String HighestEducation {
get {
return (System.String)this["HighestEducation"];
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
public System.String City {
get {
return (System.String)this["City"];
}
}
public System.String Country {
get {
return (System.String)this["Country"];
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
public System.String Email {
get {
return (System.String)this["Email"];
}
}
public System.String BankName {
get {
return (System.String)this["BankName"];
}
}
public System.String BankAccountNumber {
get {
return (System.String)this["BankAccountNumber"];
}
}
public System.String EmergencyContactName1 {
get {
return (System.String)this["EmergencyContactName1"];
}
}
public System.String EmergencyContactNumber1 {
get {
return (System.String)this["EmergencyContactNumber1"];
}
}
public System.String EmergencyContactNumber1Alternative {
get {
return (System.String)this["EmergencyContactNumber1Alternative"];
}
}
public System.String EmergencyContactRelationship1 {
get {
return (System.String)this["EmergencyContactRelationship1"];
}
}
public System.String EmergencyContactName2 {
get {
return (System.String)this["EmergencyContactName2"];
}
}
public System.String EmergencyContactNumber2 {
get {
return (System.String)this["EmergencyContactNumber2"];
}
}
public System.String EmergencyContactNumber2Alternative {
get {
return (System.String)this["EmergencyContactNumber2Alternative"];
}
}
public System.String EmergencyContactRelationship2 {
get {
return (System.String)this["EmergencyContactRelationship2"];
}
}
public System.String FatherGuardianName {
get {
return (System.String)this["FatherGuardianName"];
}
}
public System.String FatherGuardianIC {
get {
return (System.String)this["FatherGuardianIC"];
}
}
public System.String FatherGuardianTypeOfOccupation {
get {
return (System.String)this["FatherGuardianTypeOfOccupation"];
}
}
public System.String FatherGuardianEmployerName {
get {
return (System.String)this["FatherGuardianEmployerName"];
}
}
public System.String MotherGuardianName {
get {
return (System.String)this["MotherGuardianName"];
}
}
public System.String MotherGuardianIC {
get {
return (System.String)this["MotherGuardianIC"];
}
}
public System.String MotherGuardianTypeOfOccupation {
get {
return (System.String)this["MotherGuardianTypeOfOccupation"];
}
}
public System.String MotherGuardianEmployerName {
get {
return (System.String)this["MotherGuardianEmployerName"];
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
public System.String Updatedby {
get {
return (System.String)this["Updatedby"];
}
}
public System.String Postcode {
get {
return (System.String)this["Postcode"];
}
}
public System.String State {
get {
return (System.String)this["State"];
}
}
public System.String Nationality {
get {
return (System.String)this["Nationality"];
}
}
public System.String IsBumiputra {
get {
return (System.String)this["IsBumiputra"];
}
}
public System.String Remark {
get {
return (System.String)this["Remark"];
}
}
}
public partial class RptCandidateRegistrationMasterListMinimalizedEntity {
public RptCandidateRegistrationMasterListMinimalizedEntity() {}
public RptCandidateRegistrationMasterListMinimalizedEntity(RptCandidateRegistrationMasterListRow dr) {
this.UserID = dr.UserID;
this.FullName = dr.FullName;
this.DOB = dr.DOB;
this.Gender = dr.Gender;
this.ICNumber = dr.ICNumber;
this.CurrentlyEmployed = dr.CurrentlyEmployed;
this.EducationLevel1 = dr.EducationLevel1;
this.FieldOfStudy1 = dr.FieldOfStudy1;
this.EducationLevel2 = dr.EducationLevel2;
this.FieldOfStudy2 = dr.FieldOfStudy2;
this.EducationLevel3 = dr.EducationLevel3;
this.FieldOfStudy3 = dr.FieldOfStudy3;
this.EducationLevel4 = dr.EducationLevel4;
this.FieldOfStudy4 = dr.FieldOfStudy4;
this.EducationLevel5 = dr.EducationLevel5;
this.FieldOfStudy5 = dr.FieldOfStudy5;
this.CurrentlyPursuingHighestLevel = dr.CurrentlyPursuingHighestLevel;
this.HighestEducation = dr.HighestEducation;
this.Address1 = dr.Address1;
this.Address2 = dr.Address2;
this.City = dr.City;
this.Country = dr.Country;
this.PhoneNumber = dr.PhoneNumber;
this.Mobile = dr.Mobile;
this.Email = dr.Email;
this.BankName = dr.BankName;
this.BankAccountNumber = dr.BankAccountNumber;
this.EmergencyContactName1 = dr.EmergencyContactName1;
this.EmergencyContactNumber1 = dr.EmergencyContactNumber1;
this.EmergencyContactNumber1Alternative = dr.EmergencyContactNumber1Alternative;
this.EmergencyContactRelationship1 = dr.EmergencyContactRelationship1;
this.EmergencyContactName2 = dr.EmergencyContactName2;
this.EmergencyContactNumber2 = dr.EmergencyContactNumber2;
this.EmergencyContactNumber2Alternative = dr.EmergencyContactNumber2Alternative;
this.EmergencyContactRelationship2 = dr.EmergencyContactRelationship2;
this.FatherGuardianName = dr.FatherGuardianName;
this.FatherGuardianIC = dr.FatherGuardianIC;
this.FatherGuardianTypeOfOccupation = dr.FatherGuardianTypeOfOccupation;
this.FatherGuardianEmployerName = dr.FatherGuardianEmployerName;
this.MotherGuardianName = dr.MotherGuardianName;
this.MotherGuardianIC = dr.MotherGuardianIC;
this.MotherGuardianTypeOfOccupation = dr.MotherGuardianTypeOfOccupation;
this.MotherGuardianEmployerName = dr.MotherGuardianEmployerName;
this.CreatedDate = dr.CreatedDate;
this.CreatedBy = dr.CreatedBy;
this.UpdatedDate = dr.UpdatedDate;
this.Updatedby = dr.Updatedby;
this.Postcode = dr.Postcode;
this.State = dr.State;
this.Nationality = dr.Nationality;
this.IsBumiputra = dr.IsBumiputra;
this.Remark = dr.Remark;
}
public System.String UserID;
public System.String FullName;
public System.DateTime DOB;
public System.String Gender;
public System.String ICNumber;
public System.String CurrentlyEmployed;
public System.String EducationLevel1;
public System.String FieldOfStudy1;
public System.String EducationLevel2;
public System.String FieldOfStudy2;
public System.String EducationLevel3;
public System.String FieldOfStudy3;
public System.String EducationLevel4;
public System.String FieldOfStudy4;
public System.String EducationLevel5;
public System.String FieldOfStudy5;
public System.String CurrentlyPursuingHighestLevel;
public System.String HighestEducation;
public System.String Address1;
public System.String Address2;
public System.String City;
public System.String Country;
public System.String PhoneNumber;
public System.String Mobile;
public System.String Email;
public System.String BankName;
public System.String BankAccountNumber;
public System.String EmergencyContactName1;
public System.String EmergencyContactNumber1;
public System.String EmergencyContactNumber1Alternative;
public System.String EmergencyContactRelationship1;
public System.String EmergencyContactName2;
public System.String EmergencyContactNumber2;
public System.String EmergencyContactNumber2Alternative;
public System.String EmergencyContactRelationship2;
public System.String FatherGuardianName;
public System.String FatherGuardianIC;
public System.String FatherGuardianTypeOfOccupation;
public System.String FatherGuardianEmployerName;
public System.String MotherGuardianName;
public System.String MotherGuardianIC;
public System.String MotherGuardianTypeOfOccupation;
public System.String MotherGuardianEmployerName;
public System.DateTime CreatedDate;
public System.String CreatedBy;
public System.DateTime UpdatedDate;
public System.String Updatedby;
public System.String Postcode;
public System.String State;
public System.String Nationality;
public System.String IsBumiputra;
public System.String Remark;
}
public partial class RptCandidateRegistrationMasterListAdapter:AdapterBase {
SqlDataAdapter adapter;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public RptCandidateRegistrationMasterListAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();
{
// columns mapping
DataTableMapping tmap = new DataTableMapping();
tmap.SourceTable = "Table";
tmap.DataSetTable = "";
tmap.ColumnMappings.Add("UserID", "UserID");
tmap.ColumnMappings.Add("FullName", "FullName");
tmap.ColumnMappings.Add("DOB", "DOB");
tmap.ColumnMappings.Add("Gender", "Gender");
tmap.ColumnMappings.Add("ICNumber", "ICNumber");
tmap.ColumnMappings.Add("CurrentlyEmployed", "CurrentlyEmployed");
tmap.ColumnMappings.Add("EducationLevel1", "EducationLevel1");
tmap.ColumnMappings.Add("FieldOfStudy1", "FieldOfStudy1");
tmap.ColumnMappings.Add("EducationLevel2", "EducationLevel2");
tmap.ColumnMappings.Add("FieldOfStudy2", "FieldOfStudy2");
tmap.ColumnMappings.Add("EducationLevel3", "EducationLevel3");
tmap.ColumnMappings.Add("FieldOfStudy3", "FieldOfStudy3");
tmap.ColumnMappings.Add("EducationLevel4", "EducationLevel4");
tmap.ColumnMappings.Add("FieldOfStudy4", "FieldOfStudy4");
tmap.ColumnMappings.Add("EducationLevel5", "EducationLevel5");
tmap.ColumnMappings.Add("FieldOfStudy5", "FieldOfStudy5");
tmap.ColumnMappings.Add("CurrentlyPursuingHighestLevel", "CurrentlyPursuingHighestLevel");
tmap.ColumnMappings.Add("HighestEducation", "HighestEducation");
tmap.ColumnMappings.Add("Address1", "Address1");
tmap.ColumnMappings.Add("Address2", "Address2");
tmap.ColumnMappings.Add("City", "City");
tmap.ColumnMappings.Add("Country", "Country");
tmap.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
tmap.ColumnMappings.Add("Mobile", "Mobile");
tmap.ColumnMappings.Add("Email", "Email");
tmap.ColumnMappings.Add("BankName", "BankName");
tmap.ColumnMappings.Add("BankAccountNumber", "BankAccountNumber");
tmap.ColumnMappings.Add("EmergencyContactName1", "EmergencyContactName1");
tmap.ColumnMappings.Add("EmergencyContactNumber1", "EmergencyContactNumber1");
tmap.ColumnMappings.Add("EmergencyContactNumber1Alternative", "EmergencyContactNumber1Alternative");
tmap.ColumnMappings.Add("EmergencyContactRelationship1", "EmergencyContactRelationship1");
tmap.ColumnMappings.Add("EmergencyContactName2", "EmergencyContactName2");
tmap.ColumnMappings.Add("EmergencyContactNumber2", "EmergencyContactNumber2");
tmap.ColumnMappings.Add("EmergencyContactNumber2Alternative", "EmergencyContactNumber2Alternative");
tmap.ColumnMappings.Add("EmergencyContactRelationship2", "EmergencyContactRelationship2");
tmap.ColumnMappings.Add("FatherGuardianName", "FatherGuardianName");
tmap.ColumnMappings.Add("FatherGuardianIC", "FatherGuardianIC");
tmap.ColumnMappings.Add("FatherGuardianTypeOfOccupation", "FatherGuardianTypeOfOccupation");
tmap.ColumnMappings.Add("FatherGuardianEmployerName", "FatherGuardianEmployerName");
tmap.ColumnMappings.Add("MotherGuardianName", "MotherGuardianName");
tmap.ColumnMappings.Add("MotherGuardianIC", "MotherGuardianIC");
tmap.ColumnMappings.Add("MotherGuardianTypeOfOccupation", "MotherGuardianTypeOfOccupation");
tmap.ColumnMappings.Add("MotherGuardianEmployerName", "MotherGuardianEmployerName");
tmap.ColumnMappings.Add("CreatedDate", "CreatedDate");
tmap.ColumnMappings.Add("CreatedBy", "CreatedBy");
tmap.ColumnMappings.Add("UpdatedDate", "UpdatedDate");
tmap.ColumnMappings.Add("Updatedby", "Updatedby");
tmap.ColumnMappings.Add("Postcode", "Postcode");
tmap.ColumnMappings.Add("State", "State");
tmap.ColumnMappings.Add("Nationality", "Nationality");
tmap.ColumnMappings.Add("IsBumiputra", "IsBumiputra");
tmap.ColumnMappings.Add("Remark", "Remark");
adapter.TableMappings.Add(tmap);
}
}
public RptCandidateRegistrationMasterListRow GetByPrimaryKeys( ) {
string sql = "SELECT * FROM [RptCandidateRegistrationMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

RptCandidateRegistrationMasterListTable tbl = new RptCandidateRegistrationMasterListTable();
DA.ExecuteQuery(com, tbl);
if( tbl.Rows.Count == 0 ) return null;
else return tbl.GetRptCandidateRegistrationMasterListRow(0);
}
public int CountByPrimaryKeys( ) {
string sql = "SELECT COUNT(*) FROM [RptCandidateRegistrationMasterList] WHERE ";
SqlCommand com = new SqlCommand(sql);

return DA.ExecuteInt32(com);
}
}
}
