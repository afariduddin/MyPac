using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teq;

namespace EngineData
{
    public class ErrorCodes : Flag<string>
    {
        public static ErrorCodes GEN_NoError = new ErrorCodes("GEN_NoError", "Success.");
        public static ErrorCodes GEN_RecordNotFound = new ErrorCodes("GEN_RecordNotFound", "Selected record no longer exists.");
        public static ErrorCodes GEN_InvalidValue = new ErrorCodes("GEN_InvalidValue", "The form contains errors. Please revise the form and try again.");
        public static ErrorCodes GEN_NoLogin = new ErrorCodes("GEN_NoLogin", "Login required.");
        public static ErrorCodes GEN_NoPermission = new ErrorCodes("GEN_NoPermission", "No Permission to perform this task.");

        public static ErrorCodes GCM_NameRequired = new ErrorCodes("GCM_NameRequired", "Name is required.");
        public static ErrorCodes GCM_NameTooLong = new ErrorCodes("GCM_NameTooLong", "Name is too long. Should be less than 20 characters.");
        public static ErrorCodes GCM_ModDateFuture = new ErrorCodes("GCM_ModDateFuture", "Modified date cannot be set to future.");
        public static ErrorCodes GCM_TypeRequired = new ErrorCodes("GCM_TypeRequired", "Type is required.");
        public static ErrorCodes GCM_CountryRequired = new ErrorCodes("GCM_CountryRequired", "Country is required.");
        public static ErrorCodes GCM_StateRequired = new ErrorCodes("GCM_StateRequired", "State is required.");
        public static ErrorCodes GCM_FileRequired = new ErrorCodes("GCM_FileRequired", "Please upload a file.");
        public static ErrorCodes GCM_SunYatSungPls = new ErrorCodes("GCM_SunYatSungPls", "Only SunYatSung.jpg is allowed.");
        public static ErrorCodes GCM_UserAbortedProcess = new ErrorCodes("GCM_UserAbortedProcess", "User aborted the process.");

        public static ErrorCodes MBM_NameRequired = new ErrorCodes("MBM_NameRequired", "Name is required.");



        public static ErrorCodes UserGroup_Name = new ErrorCodes("UserGroup_Name", "Name is required.");
        public static ErrorCodes UserGroup_InUse = new ErrorCodes("UserGroup_Name", "User Group is current in use. Please remove all associated User Account and try again.");
        public static ErrorCodes Course_Name = new ErrorCodes("Course_Name", "Name is required.");
        public static ErrorCodes Course_Code = new ErrorCodes("Course_Code", "Code is required.");
        public static ErrorCodes Course_CodeDuplicate = new ErrorCodes("Course_Code", "Course Code already exist.");
        public static ErrorCodes CourseSubject_Code = new ErrorCodes("CourseSubject_Code", "Code already exist.");
        
        public static ErrorCodes Sponsor_Label = new ErrorCodes("Sponsor_Label", "Label is required.");
        public static ErrorCodes Sponsor_Code = new ErrorCodes("Sponsor_Code", "Code is required.");
        public static ErrorCodes Sponsor_CodeDuplicate = new ErrorCodes("Sponsor_CodeDuplicate", "Code already exist.");

        public static ErrorCodes UserAccount_Name = new ErrorCodes("UserAccount_Name", "Name is required.");
        public static ErrorCodes UserAccount_UserID = new ErrorCodes("UserAccount_UserID", "User ID is required.");
        public static ErrorCodes UserAccount_DuplicateUserID = new ErrorCodes("UserAccount_DuplicateUserID", "User ID is duplicated, please choose another.");
        public static ErrorCodes UserAccount_UserGroupRequired = new ErrorCodes("UserAccount_UserGroupRequired", "Please select User Group.");

        public static ErrorCodes UserAccount_InvalidAccount = new ErrorCodes("UserAccount_InvalidAccount", "Invalid User ID or Password. Please check your sign in credentials.");

        public static ErrorCodes UserAccount_NewPasswordNotMatched = new ErrorCodes("UserGroup_Password", "New Password does not match.");
        public static ErrorCodes UserAccount_CurrentPasswordMatched = new ErrorCodes("UserGroup_Password", "New Password cannot be the same as current password.");
        public static ErrorCodes UserAccount_CurrentPasswordNotMatched = new ErrorCodes("UserGroup_Password", "Current Password is incorrect.");

        public static ErrorCodes CandidateRegistration_DuplicateUserID = new ErrorCodes("CandidateRegistration_DuplicateUserID", "User ID is duplicated, please choose another.");
        public static ErrorCodes CandidateRegistration_PasswordRequired = new ErrorCodes("CandidateRegistration_PasswordRequired", "Password is required.");
        public static ErrorCodes CandidateRegistration_ConfirmPasswordRequired = new ErrorCodes("CandidateRegistration_ConfirmPasswordRequired", "Confirm Password is required.");
        public static ErrorCodes CandidateRegistration_PasswordNotMatched = new ErrorCodes("CandidateRegistration_PasswordNotMatched", "Password does not match with confirm password.");
        public static ErrorCodes CandidateRegistration_FullNameRequired = new ErrorCodes("CandidateRegistration_FullNameRequired", "Full Name is required.");
        public static ErrorCodes CandidateRegistration_DOBRequired = new ErrorCodes("CandidateRegistration_DOBRequired", "Date of Birth is required.");
        public static ErrorCodes CandidateRegistration_EthnicityRequired = new ErrorCodes("CandidateRegistration_EthnicityRequired", "Ethnicity is required.");
        public static ErrorCodes CandidateRegistration_Bumiputra = new ErrorCodes("CandidateRegistration_Bumiputra", "Only bumiputra are eligible to register.");
        public static ErrorCodes CandidateRegistration_BumiputraRequired = new ErrorCodes("CandidateRegistration_Bumiputra", "Bumiputra is required.");
        public static ErrorCodes CandidateRegistration_GenderRequired = new ErrorCodes("CandidateRegistration_GenderRequired", "Gender is required.");
        public static ErrorCodes CandidateRegistration_NationalityRequired = new ErrorCodes("CandidateRegistration_NationalityRequired", "Nationality is required.");
        public static ErrorCodes CandidateRegistration_ICRequired = new ErrorCodes("CandidateRegistration_ICRequired", "IC is required.");
        public static ErrorCodes CandidateRegistration_DuplicateIC = new ErrorCodes("CandidateRegistration_DuplicateIC", "IC is duplicated, please choose another.");
        public static ErrorCodes CandidateRegistration_CurrentlyEmployedRequired = new ErrorCodes("CandidateRegistration_CurrentlyEmployedRequired", "Currently Employed is required.");
        public static ErrorCodes CandidateRegistration_PreferredQualificationRequired = new ErrorCodes("CandidateRegistration_PreferredQualificationRequired", "Preferred Qualification is required.");
        public static ErrorCodes CandidateRegistration_EducationHistoryRequired = new ErrorCodes("CandidateRegistration_EducationHistoryRequired", "Education History is required.");
        public static ErrorCodes CandidateRegistration_HighestEducationRequired = new ErrorCodes("CandidateRegistration_HighestEducationRequired", "Highest Edication is required.");
        public static ErrorCodes CandidateRegistration_AddressRequired = new ErrorCodes("CandidateRegistration_AddressRequired", "Address is required.");
        public static ErrorCodes CandidateRegistration_CountryRequired = new ErrorCodes("CandidateRegistration_Country", "Country is required.");
        public static ErrorCodes CandidateRegistration_JobSectorRequired = new ErrorCodes("CandidateRegistration_SectorRequired", "Job Sector is required.");
        public static ErrorCodes CandidateRegistration_JobPositionRequired = new ErrorCodes("CandidateRegistration_JobPositionRequired", "Job Position is required.");

        public static ErrorCodes CandidateRegistration_MobilePhoneNumberRequired = new ErrorCodes("CandidateRegistration_MobilePhoneNumberRequired", "Mobile Phone Number is required.");
        public static ErrorCodes CandidateRegistration_EmailRequired = new ErrorCodes("CandidateRegistration_EmailRequired", "Email is required.");
        public static ErrorCodes CandidateRegistration_ValidEmailRequired = new ErrorCodes("CandidateRegistration_ValidEmailRequired", "Email is invalid.");
        public static ErrorCodes CandidateRegistration_PDPARequired = new ErrorCodes("CandidateRegistration_PDPARequired", "PDPA acknowledgement is required.");
        public static ErrorCodes CandidateRegistration_AdditionalInfoRequired = new ErrorCodes("CandidateRegistration_AdditionalInfoRequired", "Please fill up all your Parent/Guardian Information and Additional Information in your Profile Page before submitting.");
        public static ErrorCodes CandidateRegistration_InvalidCaptcha = new ErrorCodes("CandidateRegistration_InvalidCaptcha", "Invalid Captcha is detected.");

        public static ErrorCodes Candidate_InvalidAccount = new ErrorCodes("Candidate_InvalidAccount", "Invalid User ID or Password. Please check your sign in credentials.");
        public static ErrorCodes Candidate_UserID = new ErrorCodes("Candidate_UserID", "User ID is required.");
        public static ErrorCodes Candidate_NewPasswordNotMatched = new ErrorCodes("Candidate_Password", "New Password does not match.");
        public static ErrorCodes Candidate_CurrentPasswordMatched = new ErrorCodes("Candidate_Password", "New Password cannot be the same as current password.");
        public static ErrorCodes Candidate_CurrentPasswordNotMatched = new ErrorCodes("Candidate_Password", "Current Password is incorrect.");
        public static ErrorCodes Candidate_InvalidSignInID = new ErrorCodes("Candidate_InvalidSignInID", "Invalid User ID.");

        public static ErrorCodes AssessmentSession_Location = new ErrorCodes("AssessmentSession_Location", "Location is required.");
        public static ErrorCodes AssessmentSession_RecordDelete = new ErrorCodes("AssessmentSession_RecordDelete", "This record cannot be deleted as it is been used.");
        public static ErrorCodes AssessmentSession_AssignedStudent = new ErrorCodes("AssessmentSession_AssignedStudent", "No student assigned to this session.");

        public static ErrorCodes Application_StatusRequired = new ErrorCodes("Application_StatusRequired", "Status is required.");
        public static ErrorCodes Application_FullNameRequired = new ErrorCodes("Application_FullNameRequired", "Full Name is required.");
        public static ErrorCodes Application_NationalityRequired = new ErrorCodes("Application_NationalityRequired", "Nationality is required.");
        public static ErrorCodes Application_ICNumberRequired = new ErrorCodes("Application_ICNumberRequired", "IC Number is required.");
        public static ErrorCodes Application_PostcodeRequired = new ErrorCodes("Application_PostcodeRequired", "Postcode is required.");

        public static ErrorCodes Application_CityRequired = new ErrorCodes("Application_CityRequired", "City is required.");
        public static ErrorCodes Application_StateRequired = new ErrorCodes("Application_StateRequired", "State is required.");
        public static ErrorCodes Application_AddressRequired = new ErrorCodes("Application_AddressRequired", "Address is required.");

        public static ErrorCodes Application_Invalid = new ErrorCodes("Application_Invalid", "Invalid Application Detail.");

        public static ErrorCodes WarningLetter_Required = new ErrorCodes("WarningLetter_Required", "Please select a Warning Letter template.");

        public static ErrorCodes Application_MobileRequired = new ErrorCodes("Application_MobileRequired", "Mobile Number is required.");
        public static ErrorCodes Application_ContactRequired = new ErrorCodes("Application_ContactRequired", "Contact Number is required.");
        public static ErrorCodes Application_EmailRequired = new ErrorCodes("Application_EmailRequired", "Email is required.");
        public static ErrorCodes Application_EmailInvalid = new ErrorCodes("Application_EmailInvalid", "Invalid Email address.");

        public static ErrorCodes Coaching_DescriptionRequired = new ErrorCodes("Coaching_DescriptionRequired", "Description is required.");

        public static ErrorCodes Application_EthnicityRequired = new ErrorCodes("Application_EthnicityRequired", "Ethnicity is required.");
        public static ErrorCodes Application_Rejected = new ErrorCodes("Application_Rejected", "The selected application had been rejected.");

        public static ErrorCodes TSP_InUse = new ErrorCodes("TSP_InUse", "Training Service Provider is currently in use. Please delete all associated Course and try again.");
        public static ErrorCodes TSP_Name = new ErrorCodes("TSP_Name", "Campus Name cannot be empty.");
        public static ErrorCodes TSP_Type = new ErrorCodes("TSP_Type", "Please select a Course Type.");

        public static ErrorCodes CandidateApplication_CourseRequired = new ErrorCodes("CandidateApplication_CourseRequired", "Course is required.");
        public static ErrorCodes CandidateApplication_FullNameRequired = new ErrorCodes("CandidateApplication_FullNameRequired", "Full Name is required.");
        public static ErrorCodes CandidateApplication_DOBRequired = new ErrorCodes("CandidateApplication_DOBRequired", "Date of Birth is required.");

        public static ErrorCodes CandidateApplication_GenderRequired = new ErrorCodes("CandidateApplication_GenderRequired", "Gender is required.");
        public static ErrorCodes CandidateApplication_ICRequired = new ErrorCodes("CandidateApplication_ICRequired", "IC is required.");
        public static ErrorCodes CandidateApplication_CurrentlyEmployedRequired = new ErrorCodes("CandidateApplication_CurrentlyEmployedRequired", "Currently Employed is required.");

        public static ErrorCodes CandidateApplication_AddressRequired = new ErrorCodes("CandidateApplication_AddressRequired", "Address is required.");
        public static ErrorCodes CandidateApplication_CountryRequired = new ErrorCodes("CandidateApplication_Country", "Country is required.");
        public static ErrorCodes CandidateApplication_MobilePhoneNumberRequired = new ErrorCodes("CandidateApplication_MobilePhoneNumberRequired", "Mobile Phone Number is required.");
        public static ErrorCodes CandidateApplication_EmailRequired = new ErrorCodes("CandidateApplication_EmailRequired", "Email is required.");

        public static ErrorCodes CandidateApplication_FatherNameRequired = new ErrorCodes("CandidateApplication_FatherNameRequired", "Father Name is required.");
        public static ErrorCodes CandidateApplication_FatherICRequired = new ErrorCodes("CandidateApplication_FatherICRequired", "Father IC is required.");
        public static ErrorCodes CandidateApplication_MotherNameRequired = new ErrorCodes("CandidateApplication_MotherNameRequired", "Mother Name is required.");
        public static ErrorCodes CandidateApplication_MotherICRequired = new ErrorCodes("CandidateApplication_MotherICRequired", "Mother IC is required.");
        public static ErrorCodes CandidateApplication_CombinedHouseholdIncomeRequired = new ErrorCodes("CandidateApplication_CombinedHouseholdIncomeRequired", "Combined Household Income is required.");
        public static ErrorCodes CandidateApplication_InvalidCombinedHouseholdIncome = new ErrorCodes("CandidateApplication_InvalidCombinedHouseholdIncome", "Invalid input for Combined Household Income.");
        public static ErrorCodes CandidateApplication_CurrentFieldOfStudyRequired = new ErrorCodes("CandidateApplication_CurrentFieldOfStudyRequired", "Current Field Of Study is required.");
        public static ErrorCodes CandidateApplication_UniversityRequired = new ErrorCodes("CandidateApplication_UniversityRequired", "University is required.");
        public static ErrorCodes CandidateApplication_CGPARequire = new ErrorCodes("CandidateApplication_CGPARequire", "CGPA is required.");
        public static ErrorCodes CandidateApplication_AgreeRequired = new ErrorCodes("CandidateApplication_AgreeRequired", "Agree declaration is required.");
        public static ErrorCodes CandidateApplication_PDPARequired = new ErrorCodes("CandidateApplication_PDPARequired", "PDPA acknowledgement is required.");
        public static ErrorCodes CandidateApplication_IntakeMonthRequired = new ErrorCodes("CandidateApplication_IntakeMonth", "Prefered Intake Month is required.");
        public static ErrorCodes CandidateApplication_IntakeYearRequired = new ErrorCodes("CandidateApplication_IntakeYear", "Prefered Intake Year is required.");

        public static ErrorCodes CandidateApplication_InvalidCostCoveredByScholarship = new ErrorCodes("CandidateApplication_InvalidCostCoveredByScholarship", "Invalid input for Cost Covered By Scholarship.");
        public static ErrorCodes CandidateApplication_ICFileRequired = new ErrorCodes("CandidateApplication_ICFileRequired", "Please Upload Identification.");
        public static ErrorCodes CandidateApplication_BirthCertificateRequired = new ErrorCodes("CandidateApplication_BirthCertificateRequired", "Please Upload Birth Certificate.");
        public static ErrorCodes CandidateApplication_AcademicTranscriptRequired = new ErrorCodes("CandidateApplication_AcademicTranscriptRequired", "Please Upload Academic Transcript.");
        public static ErrorCodes CandidateApplication_PassportRequired = new ErrorCodes("CandidateApplication_PassportRequired", "Please Upload Passport.");

        public static ErrorCodes StudentCourse_Terminated = new ErrorCodes("StudentCourse_Terminated", "The selected student had been terminated.");

        public static ErrorCodes StudentProgressSummary_Terminated = new ErrorCodes("StudentProgressSummary_Terminated", "The selected student had been terminated.");

        public static ErrorCodes VoluntaryHour_TitleRequired = new ErrorCodes("VoluntaryHour_TitleRequired", "Title is required.");
        public static ErrorCodes VoluntaryHour_WorkHourRequired = new ErrorCodes("VoluntaryHour_WorkHourRequired", "Minimum of 1 Work Hour.");

        public static ErrorCodes WorkHistory_CompanyNameRequired = new ErrorCodes("WorkHistory_CompanyNameRequired", "Company Name is required.");
        public static ErrorCodes WorkHistory_JobTitleRequired = new ErrorCodes("WorkHistory_JobTitleRequired", "Job Title is required.");
        public static ErrorCodes WorkHistory_InvalidDateRange = new ErrorCodes("WorkHistory_InvalidDateRange", "Error! \"Work From\" is later than \"Work To\".");
        public static ErrorCodes WorkHistory_EmptyStartDate = new ErrorCodes("WorkHistory_EmptyStartDate", "Minimum of \"Work From\" is required.");

        public static ErrorCodes ExcelImport_InvalidRequiredField = new ErrorCodes("ExcelImport_InvalidRequiredField", " is required.");

        public static ErrorCodes WarningLetter_NameRequired = new ErrorCodes("WarningLetter_NameRequired", "Template Name is required.");
        public static ErrorCodes WarningLetter_SubjectRequired = new ErrorCodes("WarningLetter_SubjectRequired", "Template Subject is required.");

        public static ErrorCodes PartTimerAssessmentSession_Location = new ErrorCodes("PartTimerAssessmentSession_Location", "Invalid Location.");
        public static ErrorCodes PartTimerAssessmentSession_Type = new ErrorCodes("PartTimerAssessmentSession_Location", "Please select a Session Type.");
        public static ErrorCodes PartTimerAssessmentSession_RecordDelete = new ErrorCodes("PartTimerAssessmentSession_RecordDelete", "This record cannot be deleted as it is been used.");
        public static ErrorCodes PartTimerAssessmentSession_AssignedStudent = new ErrorCodes("PartTimerAssessmentSession_AssignedStudent", "No student assigned to this session.");

        public static ErrorCodes StudentCourseAttachment_Name = new ErrorCodes("StudentCourseAttachment_Name", "Name is required.");
        public static ErrorCodes StudentCourseAttachment_Attachment = new ErrorCodes("StudentCourseAttachment_Attachment", "Attachment is required.");


        public static ErrorCodes CandidateMIA_MIARequired = new ErrorCodes("CandidateMIA_MIARequired", "MIA Account Number is required.");
        public static ErrorCodes CandidateMIA_ICFileRequired = new ErrorCodes("CandidateMIA_ICFileRequired", "Please Upload MIA Certificate.");
        public static ErrorCodes CandidateMIA_AgreeRequired = new ErrorCodes("CandidateMIA_AgreeRequired", "Agree declaration is required.");
        #region
        public ErrorCodes(string code, string name) : base(code, name)
        {
        }
        /*
        public static ErrorCodes Parse(string name)
        {
            return Parse<ErrorCodes>(name);
        }
        public static ErrorCodes[] GetValues()
        {
            return Flag<string>.GetValues<ErrorCodes>();
        }
        public static implicit operator string(ErrorCodes x)
        {
            return x.Code;
        }
        public static implicit operator ErrorCodes(string x)
        {
            return Find<ErrorCodes>(x);
        } 
        */
        #endregion
    }
    /*
    public enum xErrorCodes
    {
        GEN_NoError = 0, // Success must meet Ajax teq.Context.SuccessErrorCode
        GEN_RecordNotFound = 1,
        GEN_InvalidValue = 2,

        GCM_NameRequired = 101001,
        GCM_NameTooLong = 101002,
        GCM_ModDateFuture = 101003,
        GCM_TypeRequired = 101004,
        GCM_CountryRequired = 101005,
        GCM_StateRequired = 101006,

        MBM_NameRequired = 102001,
    }
    public static class ErrorMessages
    {
        static ErrorMessages()
        {
            msgs.Add(ErrorCodes.GEN_NoError, "Success.");
            msgs.Add(ErrorCodes.GEN_RecordNotFound, "Selected record no longer exists.");
            msgs.Add(ErrorCodes.GEN_InvalidValue, "The form contains errors. Please revise the form and try again.");

            msgs.Add(ErrorCodes.GCM_NameRequired, "Name is required.");
            msgs.Add(ErrorCodes.GCM_NameTooLong, "Name is too long. Should be less than 20 characters.");
            msgs.Add(ErrorCodes.GCM_ModDateFuture, "Modified date cannot be set to future.");
            msgs.Add(ErrorCodes.GCM_TypeRequired, "Type is required.");
            msgs.Add(ErrorCodes.GCM_CountryRequired, "Country is required.");
            msgs.Add(ErrorCodes.GCM_StateRequired, "State is required.");

            msgs.Add(ErrorCodes.MBM_NameRequired, "Name is required.");
        }
        static Dictionary<ErrorCodes, string> msgs = new Dictionary<ErrorCodes, string>();
        public static string Get(ErrorCodes key)
        {
            return msgs[key];
        }
    }
    */
}
