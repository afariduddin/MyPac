using System;
using System.Data.SqlClient;
using System.Data;
using Teq.Data;
using System.Collections.Generic;

namespace EngineData
{
    public class ReportsAdapter : AdapterBase
    {
        SqlDataAdapter adapter;
        public SqlDataAdapter Adapter
        {
            get { return adapter; }
        }
        public ReportsAdapter(DA da)
            : base(da)
        {
            InitializeAdapter();
        }
        void InitializeAdapter()
        {
            adapter = new SqlDataAdapter();
        }

        #region Report 01: Student Intake Summary Report
        public DataTable SearchStudentIntakeSummary(int YearFrom, int YearTo, string TSPIDs, string CourseIDs, string Sponsors, string Statuses, bool isPaging, SqlOrder[] ordering, int pg)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);
            DataTable dt = new DataTable();
            string sql = @"select distinct DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear, TSP.TSP_CampusName as TSP, Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake', Count(Student.Application_ID) as ActiveCount, COALESCE(Sponsor_Code, '') AS Sponsor_Code from Student Inner Join Application App on Student.Application_ID = App.Application_ID  and App.Application_Deleted = 0 LEFT OUTER JOIN SPONSOR on App.Sponsor_ID = Sponsor.Sponsor_ID Inner Join TSP on TSP.TSP_ID = Student.TSP_ID Where 1=1 and Student.Student_EnrollmentDate >= @DateFrom and Student.Student_EnrollmentDate <= @DateTo and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 and CHARINDEX( ',' + cast(Student.Course_ID as varchar(36)) + ',', ',' + @COURSEID + ',' ) > 0 and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 and CHARINDEX( ',' + cast(Student.Student_Status as char(1)) + ',', ',' + @Status + ',' ) > 0  group by Student.Student_EnrollmentDate, TSP.TSP_CampusName, Sponsor_Code ORDER BY IntakeYear, IntakeMonth";
            
            //select distinct
            //	DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
            //	DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear,
            //	TSP.TSP_CampusName as TSP,
            //	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake',
            //	Count(AppMale.Application_Gender) as Male,
            //	Count(AppFemale.Application_Gender) as Female,
            //	Count(App.Application_Gender) as Total
            //from 
            //Student
            //Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
            //Left Join Application AppMale on Student.Application_ID = AppMale.Application_ID and AppMale.Application_Gender = 1
            //Left Join Application AppFemale on Student.Application_ID = AppFemale.Application_ID and AppFemale.Application_Gender = 2
            //Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
            //Where 
            //1=1
            //and Student.Student_EnrollmentDate >= @DateFrom
            //and Student.Student_EnrollmentDate <= @DateTo
            //and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
            //and CHARINDEX( ',' + cast(Student.Course_ID as varchar(36)) + ',', ',' + @COURSEID + ',' ) > 0 
            //group by 
            //Student.Student_EnrollmentDate,
            //TSP.TSP_CampusName
            //) RptStudentIntakeSummary";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            cmd.Parameters.AddWithValue("TSPID", TSPIDs);
            cmd.Parameters.AddWithValue("COURSEID", CourseIDs);
            cmd.Parameters.AddWithValue("SPONSORID", Sponsors);
            cmd.Parameters.AddWithValue("Status", Statuses);

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 02 - Student Deferment Summary Report
        public DataTable SearchStudentDefermentSummary(int YearFrom, int YearTo, string TSPIDs, string CourseIDs)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);

            DataTable dt = new DataTable();

            string sql = @"
select distinct
	DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
	DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear,
	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake',
	StudentCourse.StudentCourse_DefermentReason as Reason,
	count(StudentCourse.CourseSubject_ID) as TotalDeferred
from 
Student
Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
Inner Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID and StudentCourse.StudentCourse_Status = 5
Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
Where 
1=1
and Student.Student_EnrollmentDate >= @DateFrom
and Student.Student_EnrollmentDate <= @DateTo
and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
and CHARINDEX( ',' + cast(Student.Course_ID as varchar(36)) + ',', ',' + @COURSEID + ',' ) > 0 
and StudentCourse.StudentCourse_DefermentReason != ''
group by
Student.Student_EnrollmentDate,
StudentCourse.StudentCourse_DefermentReason
";

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            cmd.Parameters.AddWithValue("TSPID", TSPIDs);
            cmd.Parameters.AddWithValue("COURSEID", CourseIDs);

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 03 - Student Withdrawal Summary Report
        public DataTable SearchStudentWithdrawalSummary(int YearFrom, int YearTo, string TSPs, string Sponsorships)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);
            DataTable dt = new DataTable();
            string sql = @"
                select 
	DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
	DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear,
	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake',
	                --TSP.TSP_CampusName as TSP,
	                Course.Course_Name,
	                Course.Course_Code,
	                Count(Student.Application_ID) as Withdrawal
                from 
                Student
                Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
                Left Join TSP on TSP.TSP_ID = Student.TSP_ID
                Inner Join Course on Course.Course_ID = Student.Course_ID
                Where 
                1=1
and Student.Student_EnrollmentDate >= @DateFrom
and Student.Student_EnrollmentDate <= @DateTo
                and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
                and CHARINDEX( ',' + cast(App.Application_Sponsor as char(1)) + ',', ',' + @SPONSORID + ',' ) > 0 
                and Student.Student_Status = 4 -- Means Withdrawn
                group by 
Student.Student_EnrollmentDate,
                Course.Course_Name,
                Course.Course_Code
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            cmd.Parameters.Add(new SqlParameter("TSPID", TSPs));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", Sponsorships));

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 04 - Student Location Summary Report
        public DataTable SearchStudentLocationSummary(int YearFrom, int YearTo)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);

            DataTable dt = new DataTable();
            string sql = "SELECT DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth,  DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear, Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake', App.Application_State as 'State', ";
            sql += " Count(Student.Application_ID) as TotalIntake FROM Student Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0 WHERE  1=1";
            sql += " AND Student.Student_EnrollmentDate >= @DateFrom AND Student.Student_EnrollmentDate <= @DateTo AND App.Application_State != '' GROUP BY Student.Student_EnrollmentDate, App.Application_State";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 05 - Active Student Summary Report
        public DataTable SearchActiveStudentSummary(int YearFrom, int YearTo, string TSPs, string Sponsorships)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);
            DataTable dt = new DataTable();
            string sql = @"
                    select 
	DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
	DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear,
	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake',
	                    --TSP.TSP_CampusName as TSP,
	                    Course.Course_Name,
	                    Course.Course_Code,
	                    Count(Student.Application_ID) as ActiveCount
                    from 
                    Student
                    Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
                    Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
                    Inner Join Course on Course.Course_ID = Student.Course_ID
                    Where 
                    1=1
and Student.Student_EnrollmentDate >= @DateFrom
and Student.Student_EnrollmentDate <= @DateTo
                    and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
                    and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
                    and Student.Student_Status = 1 -- Means Active
                    group by 
Student.Student_EnrollmentDate,
                    Course.Course_Name,
                    Course.Course_Code
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            cmd.Parameters.Add(new SqlParameter("TSPID", TSPs));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", Sponsorships));

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 06: Candidate Registration Master List
        public PagedDataList<RptCandidateRegistrationMasterListTable> SearchCandidateRegistrationMasterList(string fullname, int gender, string email, string icNum, string state,
    Guid CourseID, int CurrentlyEmployed, DateTime RegisterDateFrom, DateTime RegisterDateTo, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
SELECT Distinct
Candidate_UserID as 'UserID',
Candidate_FullName as 'FullName',
Candidate_DOB as 'DOB',
Case
	when Candidate_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
Candidate_ICNumber as 'ICNumber',
Case
	when Candidate_CurrentlyEmployed = 1 then 'Yes'
	Else 'No'
End As 'CurrentlyEmployed',
Candidate_EducationLevel1 as 'EducationLevel1',
Candidate_FieldOfStudy1 as 'FieldOfStudy1',
Candidate_EducationLevel2 as 'EducationLevel2',
Candidate_FieldOfStudy2 as 'FieldOfStudy2',
Candidate_EducationLevel3 as 'EducationLevel3',
Candidate_FieldOfStudy3 as 'FieldOfStudy3',
Candidate_EducationLevel4 as 'EducationLevel4',
Candidate_FieldOfStudy4 as 'FieldOfStudy4',
Candidate_EducationLevel5 as 'EducationLevel5',
Candidate_FieldOfStudy5 as 'FieldOfStudy5',
Case
	when Candidate_CurrentlyPursuingHighestLevel = 1 then 'Yes'
	Else 'No'
End As 'CurrentlyPursuingHighestLevel',
Candidate_HighestEducation as 'HighestEducation',
Candidate_Address1 as 'Address1',
Candidate_Address2 as 'Address2',
Candidate_City as 'City',
Country.Country_Name as 'Country',
Candidate_PhonePrefix+' '+Candidate_PhoneNumber as 'PhoneNumber',
Candidate_MobilePhonePrefix+' '+Candidate_MobilePhoneNumber as 'Mobile',
Candidate_Email as 'Email',
Candidate_BankName as 'BankName',
Candidate_BankAccountNumber as 'BankAccountNumber',
Candidate_EmergencyContactName1 as 'EmergencyContactName1',
Candidate_EmergencyContactNumber1 as 'EmergencyContactNumber1',
Candidate_EmergencyContactNumber1Alternative as 'EmergencyContactNumber1Alternative',
Candidate_EmergencyContactRelationship1 as 'EmergencyContactRelationship1',
Candidate_EmergencyContactName2 as 'EmergencyContactName2',
Candidate_EmergencyContactNumber2 as 'EmergencyContactNumber2',
Candidate_EmergencyContactNumber2Alternative as 'EmergencyContactNumber2Alternative',
Candidate_EmergencyContactRelationship2 as 'EmergencyContactRelationship2',
Candidate_FatherGuardianName as 'FatherGuardianName',
Candidate_FatherGuardianIC as 'FatherGuardianIC',
Candidate_FatherGuardianTypeOfOccupation as 'FatherGuardianTypeOfOccupation',
Candidate_FatherGuardianEmployerName as 'FatherGuardianEmployerName',
Candidate_MotherGuardianName as 'MotherGuardianName',
Candidate_MotherGuardianIC as 'MotherGuardianIC',
Candidate_MotherGuardianTypeOfOccupation as 'MotherGuardianTypeOfOccupation',
Candidate_MotherGuardianEmployerName as 'MotherGuardianEmployerName',
Candidate_CreatedDate as 'CreatedDate',
Candidate_CreatedBy as 'CreatedBy',
Candidate_UpdatedDate as 'UpdatedDate',
Candidate_UpdatedBy as 'Updatedby',
Candidate_Postcode as 'Postcode',
Candidate_State as 'State',
Case
	when Candidate_Nationality = 1 then 'Malaysian'
	Else 'Others'
End As 'Nationality',
Case
	when Candidate_IsBumiputra = 1 then 'Yes'
	Else 'No'
End As 'IsBumiputra',
Candidate_Remark as 'Remark'

From Candidate 
LEFT JOIN Country on Country.Country_ID = Candidate.Country_ID
LEFT JOIN CandidatePreferredCourse on CandidatePreferredCourse.Candidate_ID = Candidate.Candidate_ID
Where Candidate_IsDeleted = 0 
and 1=1
and Candidate_CreatedDate >= @RegisterDateFrom 
and Candidate_CreatedDate <= @RegisterDateTo
and Candidate_FullName like @Fullname
and (Candidate_Gender = @Gender OR @Gender = -1)
and Candidate_Email like @Email
and Candidate_ICNumber like @ICNumber
and Candidate_State like @State
and (CandidatePreferredCourse.Course_ID = @CourseID OR @CourseID = '00000000-0000-0000-0000-000000000000')
and (Candidate_CurrentlyEmployed = @CurrentlyEmployed OR @CurrentlyEmployed = -1)
) RptCandidateRegistrationMasterList";

            com.Parameters.AddWithValue("@RegisterDateFrom", RegisterDateFrom);
            com.Parameters.AddWithValue("@RegisterDateTo", RegisterDateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + fullname + "%");
            com.Parameters.AddWithValue("@Gender", gender);
            com.Parameters.AddWithValue("@Email", "%" + email + "%");
            com.Parameters.AddWithValue("@ICNumber", "%" + icNum + "%");
            com.Parameters.AddWithValue("@State", "%" + state + "%");
            com.Parameters.AddWithValue("@CourseID", CourseID);
            com.Parameters.AddWithValue("@CurrentlyEmployed", CurrentlyEmployed);

            //int RecPerPage = int.MaxValue;
            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptCandidateRegistrationMasterListTable> lis = DA.GetPagedDataList<RptCandidateRegistrationMasterListTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 07: Candidate Application Master List
        public PagedDataList<RptCandidateApplicationMasterListTable> SearchCandidateApplicationMasterList(DateTime ApplicationDateFrom, DateTime ApplicationDateTo, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, Guid Location, int ApplicationStatusType, string CGPA, Guid CourseID, string AgeFrom, string AgeTo, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
SELECT
Application_Date as 'Date' ,
Application_FullName as 'FullName',
Application_DOB as 'DOB',
Case
	when Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
Case
	when Application_Nationality = 1 then 'Malaysian'
	Else 'Others'
End As 'Nationality',
Application_IdentificationNumber as 'ICNumber',
Application_Address1 as 'Address1',
Application_Address2 as 'Address2',
Application_Postcode as 'Postcode',
Application_City as 'City',
Application_State as 'State',
ApplicationDetail.Country_Name AS 'Country',
Application_Email as 'Email',
Application_FatherName as 'FatherName',
Application_FatherIdentification as 'FatherIdentification',
Application_MotherName as 'MotherName',
Application_MotherIdentification as 'MotherIdentification',
Application_CombinedHouseholdIncome as 'CombinedHouseholdIncome',
Application_CurrentFieldOfStudy as 'CurrentFieldOfStudy',
Application_University as 'University',
Application_CGPA as 'CGPA',
Case
	when Application_PQQualification = 1 then 'Yes'
	Else 'No'
End As 'PQQualification',
Application_PGRegistrationNumber as 'PGRegistrationNumber',
Application_PQStartDate as 'PQStartDate',
Application_PQLevelStart As 'PQLevelStart',
Application_PQDeadline as 'PQDeadline',
Case
	when Application_RegisteredNextExam = 1 then 'Yes'
	Else 'No'
End As 'RegisteredNextExam',
Application_NextExamSession as 'NextExamSession',
Case
	when Application_ContractType = 1 then 'Part Time'
	Else 'Full Time'
End As 'ContractType',
Application_ScholarshipProvider as 'ScholarshipProvider',
Application_ScholarshipCost as 'ScholarshipCost',
Case
	when Application_Status = 1 then 'Pending'
	when Application_Status = 2 then 'Terminated'
	when Application_Status = 3 then 'Accepted'
	when Application_Status = 4 then 'Session Rejected'
	when Application_Status = 5 then 'Session Assigned'
	when Application_Status = 6 then 'Session Accepted'
	when Application_Status = 7 then 'Complete'
End As 'Status',
Application_CreatedDate as 'CreatedDate',
Application_CreatedBy as 'CreatedBy',
Application_UpdatedDate as 'UpdatedDate',
Application_UpdatedBy as 'UpdatedBy',
Application_SubmittedDate as 'SubmittedDate',
Application_PhonePrefix+' '+Application_PhoneNumber as 'PhoneNumber',
Application_MobilePhonePrefix+' '+Application_MobilePhoneNumber as 'Mobile',
Application_LOIssueDate as 'LOIssueDate',
Application_CampusName as 'CampusName',
Application_City as 'CampusCity',
Case
	when Application_Sponsor = 1 then 'MyPAC'
	when Application_Sponsor = 2 then 'YPPB'
End As 'Sponsor'

FROM ApplicationDetail 
WHERE Application_Deleted = 0
and 1=1

and Application_Date >= @ApplicationDateFrom 
and Application_Date <= @ApplicationDateTo
and Application_FullName like @Fullname
and (Application_Gender = @Gender OR @Gender = -1)
and Application_Email like @Email
and Application_IdentificationNumber like @ICNumber
and Application_State like @State
and (Application_Status = @Status OR @Status = -1)
and (Application_ContractType = @ContractType OR @ContractType = -1)
and [ApplicationDetail].TSP_ID = 
	case when @Location != '00000000-0000-0000-0000-000000000000' then @Location
	else [ApplicationDetail].TSP_ID
	end
and  (Application_CGPA <= @CGPA or @CGPA = '')
and  (Course_ID = @CourseID OR @CourseID = '00000000-0000-0000-0000-000000000000')
and (dbo.GetAge(Application_DOB) >= @AgeFrom or @AgeFrom = -1)
and (dbo.GetAge(Application_DOB) <= @AgeTo or @AgeTo = -1)
) RptCandidateApplicationMasterList";

            com.Parameters.AddWithValue("@ApplicationDateFrom", ApplicationDateFrom);
            com.Parameters.AddWithValue("@ApplicationDateTo", ApplicationDateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + FullName + "%");
            com.Parameters.AddWithValue("@Gender", Gender);
            com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            com.Parameters.AddWithValue("@ICNumber", "%" + ICNumber + "%");
            com.Parameters.AddWithValue("@State", "%" + State + "%");
            com.Parameters.AddWithValue("@ContractType", ContractType);
            com.Parameters.AddWithValue("@Status", ApplicationStatusType);
            com.Parameters.AddWithValue("@Location", Location);
            com.Parameters.AddWithValue("@CGPA", CGPA);
            com.Parameters.AddWithValue("@CourseID", CourseID);

            int ageFrom = -1;
            int.TryParse(AgeFrom, out ageFrom);
            if (ageFrom == 0)
                ageFrom = -1;
            com.Parameters.AddWithValue("@AgeFrom", ageFrom);

            
            int ageTo = -1;
            int.TryParse(AgeTo, out ageTo);
            if (ageTo == 0)
                ageTo = -1;
            com.Parameters.AddWithValue("@AgeTo", ageTo);
            ////if (AgeFrom.Length > 0)
            ////{
            ////    int number=0;
            ////    int.TryParse(AgeFrom, out number);
            ////    com.Parameters.AddWithValue("@AgeFrom", number);

            ////}
            ////if (AgeTo.Length > 0)
            ////{
            ////    int number=0;
            ////    int.TryParse(AgeTo, out number);
            ////    com.Parameters.AddWithValue("@AgeTo", number);

            ////}

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptCandidateApplicationMasterListTable> lis = DA.GetPagedDataList<RptCandidateApplicationMasterListTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 08: Candidate Assessment Result Master List
        public PagedDataList<RptCandidateAssessmentResultMasterListTable> SearchCandidateAssessmentResultMasterList(string FullName, int Gender, string Email, string IC, string State, float Score, Guid Location, DateTime DateFrom, DateTime DateTo, int ContractType, int ExamType, int Status, string sponsorIDs, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
SELECT
AssessmentResult_Date as 'EnrollmentDate',
Application_FullName as 'FullName',
Application_DOB as 'DOB',
Case
	when Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
Application_IdentificationNumber as 'ICNumber',
Case
	when Application_Nationality = 1 then 'Malaysian'
	Else 'Others'
End As 'Nationality',
Application_Email as 'Email',
Application_PhonePrefix+' '+Application_PhoneNumber as 'PhoneNumber',
Application_MobilePhonePrefix+' '+Application_MobilePhoneNumber as 'Mobile',
TSP_CampusName as 'CampusName',
TSP_City as 'CampusCity',
Case
	when Application_ContractType = 1 then 'Part Time'
	Else 'Full Time'
End As 'ContractType',
AssessmentResult_TechnicalAssessment as 'TechnicalAssessment',
AssessmentResult_EnglishFoundation as 'EnglishFoundation',
AssessmentResult_Listening as 'Listening',
AssessmentResult_Writing as 'Writing',
AssessmentResult_Speaking as 'Speaking',
AssessmentResult_Reading as 'Reading',
Case
	when AssessmentResult_Interview = 1 then 'Yes'
	else 'No'
End As 'Interview',
Case
	when AssessmentResult_Status = 1 then 'Pending'
	when AssessmentResult_Status = 2 then 'Confirmed (MyPAC)'
	when AssessmentResult_Status = 3 then 'Confirmed (YPPB)'
	when AssessmentResult_Status = 4 then 'Declined'
	when AssessmentResult_Status = 5 then 'CLO Issued'
	when AssessmentResult_Status = 6 then 'Rejected (Student)'
	when AssessmentResult_Status = 7 then 'Complete'
	when AssessmentResult_Status = 8 then 'Interview Invited'
	when AssessmentResult_Status = 9 then 'Interview Rejected'
	when AssessmentResult_Status = 10 then 'Interview Accepted'
	when AssessmentResult_Status = 11 then 'Pass'
	when AssessmentResult_Status = 12 then 'Fail'
End As 'Status',
COALESCE (Sponsor_Label, '') AS Sponsor_Label

FROM AssessmentResult
INNER JOIN Application ON AssessmentResult.Application_ID = Application.Application_ID
INNER JOIN TSP ON Application.TSP_ID = TSP.TSP_ID 
LEFT JOIN Sponsor ON Application.Sponsor_ID = Sponsor.Sponsor_ID 
WHERE Application_Deleted = 0
and 1=1

and AssessmentResult_Date >= @AssessmentDateFrom 
and AssessmentResult_Date <= @AssessmentDateTo
and Application_FullName like @Fullname
and (Application_Gender = @Gender OR @Gender = -1)
and Application_Email like @Email
and Application_IdentificationNumber like @ICNumber
and Application_State like @State
and (Application_ContractType = @ContractType OR @ContractType = -1)
and [Application].TSP_ID = 
	case when @Location != '00000000-0000-0000-0000-000000000000' then @Location
	else [Application].TSP_ID
	end
and (AssessmentResult_Status = @Status OR @Status = -1)
and (
AssessmentResult_Listening >= 
	case when @ExamType = 6 then @Score
	when @ExamType = -1 then AssessmentResult_Listening
	end
OR AssessmentResult_Writing >=
	case when @ExamType = 7 then @Score
	when @ExamType = -1 then AssessmentResult_Writing
	end
OR AssessmentResult_Speaking >=
	case when @ExamType = 8 then @Score
	when @ExamType = -1 then AssessmentResult_Speaking
	end
OR AssessmentResult_Reading >=
	case when @ExamType = 9 then @Score
	when @ExamType = -1 then AssessmentResult_Reading
	end
)
and CHARINDEX( ',' + cast(Sponsor.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0
) RptCandidateAssessmentResultMasterList";

            com.Parameters.AddWithValue("@AssessmentDateFrom", DateFrom);
            com.Parameters.AddWithValue("@AssessmentDateTo", DateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + FullName + "%");
            com.Parameters.AddWithValue("@Gender", Gender);
            com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            com.Parameters.AddWithValue("@ICNumber", "%" + IC + "%");
            com.Parameters.AddWithValue("@State", "%" + State + "%");
            com.Parameters.AddWithValue("@ContractType", ContractType);
            com.Parameters.AddWithValue("@Location", Location);
            com.Parameters.AddWithValue("@Status", Status);
            com.Parameters.AddWithValue("@ExamType", ExamType);
            com.Parameters.AddWithValue("@Score", Score);
            com.Parameters.AddWithValue("SPONSORID", sponsorIDs);

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptCandidateAssessmentResultMasterListTable> lis = DA.GetPagedDataList<RptCandidateAssessmentResultMasterListTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 09: Part-Timer Assessment Result Master List
        public PagedDataList<RptPartTimerAssessmentResultMasterListTable> SearchPartTimerAssessmentResultMasterList(string FullName, int Gender, string Email, string IC, string State, float Score, Guid Location, DateTime AssessmentDateFrom, DateTime AssessmentDateTo, int ContractType, int SubjectType, int Status, string sponsorIDs, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
SELECT
AssessmentResult_ExpectedEnrollmentDate as 'EnrollmentDate',
Application_FullName as 'FullName',
Application_DOB as 'DOB',
Case
	when Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
Application_IdentificationNumber as 'ICNumber',
Case
	when Application_Nationality = 1 then 'Malaysian'
	Else 'Others'
End As 'Nationality',
Application_Email as 'Email',
Application_PhonePrefix+' '+Application_PhoneNumber as 'PhoneNumber',
Application_MobilePhonePrefix+' '+Application_MobilePhoneNumber as 'Mobile',
TSP_CampusName as 'CampusName',
TSP_City as 'CampusCity',
Case
	when Application_ContractType = 1 then 'Part Time'
	Else 'Full Time'
End As 'ContractType',
PartTimerAssessmentResult_Assessment1 as 'Assessment1',
PartTimerAssessmentResult_Assessment2 as 'Assessment2',
PartTimerAssessmentResult_Assessment3 as 'Assessment3',
PartTimerAssessmentResult_Attendance as 'Attendance',
Case
	when PartTimerAssessmentResult_Status = 1 then 'Reject'
	when PartTimerAssessmentResult_Status = 2 then 'Confirmed'
	when PartTimerAssessmentResult_Status = 3 then 'Pending Exam'
	when PartTimerAssessmentResult_Status = 4 then 'Pending Interview'
	when PartTimerAssessmentResult_Status = 5 then 'Invitation Sent'
	when PartTimerAssessmentResult_Status = 6 then 'InterviewInvitation Confirmed'
End As 'Status',
COALESCE(Sponsor_Label, '') AS Sponsor_Label

From PartTimerAssessmentResult 
INNER JOIN Application ON PartTimerAssessmentResult.Application_ID = Application.Application_ID
INNER JOIN TSP ON Application.TSP_ID = TSP.TSP_ID
INNER JOIN AssessmentResult ON AssessmentResult.Application_ID = Application.Application_ID
LEFT JOIN Sponsor ON Application.Sponsor_ID = Sponsor.Sponsor_ID
WHERE Application_Deleted = 0
and 1=1

and PartTimerAssessmentResult_CreatedDate >= @AssessmentDateFrom 
and PartTimerAssessmentResult_CreatedDate <= @AssessmentDateTo
and AssessmentResult_ExpectedEnrollmentDate >= @EnrollmentDateFrom 
and AssessmentResult_ExpectedEnrollmentDate <= @EnrollmentDateTo
and Application_FullName like @Fullname
and (Application_Gender = @Gender OR @Gender = -1)
and Application_Email like @Email
and Application_IdentificationNumber like @ICNumber
and Application_State like @State
and (Application_ContractType = @ContractType OR @ContractType = -1)
and [Application].TSP_ID = 
	case when @Location != '00000000-0000-0000-0000-000000000000' then @Location
	else [Application].TSP_ID
	end
and (PartTimerAssessmentResult_Status = @Status OR @Status = -1)
and (
PartTimerAssessmentResult_Assessment1 >= 
	case when @SubjectType = 1 then @Score
	when @SubjectType = -1 then PartTimerAssessmentResult_Assessment1
	end
OR PartTimerAssessmentResult_Assessment2 >=
	case when @SubjectType = 2 then @Score
	when @SubjectType = -1 then PartTimerAssessmentResult_Assessment2
	end
OR PartTimerAssessmentResult_Assessment3 >=
	case when @SubjectType = 3 then @Score
	when @SubjectType = -1 then PartTimerAssessmentResult_Assessment3
	end
)
and CHARINDEX( ',' + cast([Application].Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0
) RptPartTimerAssessmentResultMasterList";

            com.Parameters.AddWithValue("@AssessmentDateFrom", AssessmentDateFrom);
            com.Parameters.AddWithValue("@AssessmentDateTo", AssessmentDateTo);
            com.Parameters.AddWithValue("@EnrollmentDateFrom", EnrollmentDateFrom);
            com.Parameters.AddWithValue("@EnrollmentDateTo", EnrollmentDateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + FullName + "%");
            com.Parameters.AddWithValue("@Gender", Gender);
            com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            com.Parameters.AddWithValue("@ICNumber", "%" + IC + "%");
            com.Parameters.AddWithValue("@State", "%" + State + "%");
            com.Parameters.AddWithValue("@ContractType", ContractType);
            com.Parameters.AddWithValue("@Location", Location);
            com.Parameters.AddWithValue("@Status", Status);
            com.Parameters.AddWithValue("@SubjectType", SubjectType);
            com.Parameters.AddWithValue("@Score", Score);
            com.Parameters.AddWithValue("SPONSORID", sponsorIDs);

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptPartTimerAssessmentResultMasterListTable> lis = DA.GetPagedDataList<RptPartTimerAssessmentResultMasterListTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 10: Student Progress Summary Master List
        public PagedDataList<RptStudentProgressSummaryMasterListTable> SearchStudentProgressSummaryMasterList(string FullName, int Gender, string Email, string ContactNum, DateTime CreatedDateFrom, DateTime CreatedDateTo, int ContractType, int Status, string sponsorIDs, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, bool isPaging,string IC, string TSPIDs, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
SELECT distinct
Student_EnrollmentDate as 'EnrollmentDate',
Application_FullName as 'FullName',
Application_DOB as 'DOB',
Case
	when Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
Application_IdentificationNumber as 'ICNumber',
Case
	when Application_Nationality = 1 then 'Malaysian'
	Else 'Others'
End As 'Nationality',
Application_Email as 'Email',
Application_PhonePrefix+' '+Application_PhoneNumber as 'PhoneNumber',
Application_MobilePhonePrefix+' '+Application_MobilePhoneNumber as 'Mobile',
TSP_CampusName as 'CampusName',
TSP_City as 'CampusCity',
Case
	when Application_ContractType = 1 then 'Part Time'
	Else 'Full Time'
End As 'ContractType',
COALESCE(Sponsor_Label, '') AS Sponsor_Label,
COALESCE(CompletedSubject,0) as 'CompletedSubject',
COALESCE(CurrentSubject,0) as 'CurrentSubject',
COALESCE(RemainingSubject,0) as 'RemainingSubject',
StudentPaper.SubjectProgress,
Course.Course_Name as 'Course',
Student_ContractExpiredDate as 'ContractExpiredDate',
case
	when GETDATE() <= Student_ContractExpiredDate then (DATEDIFF(MONTH, GETDATE(), Student_ContractExpiredDate)-1)
	else 0
END As 'ContractRemainingMonth'

From Student inner join TSP on Student.TSP_ID = TSP.TSP_ID
inner join Application on Application.Application_ID = Student.Application_ID LEFT OUTER JOIN 
(SELECT Student_ID, COUNT(*) AS CurrentSubject FROM StudentCourse where StudentCourse_Status = 1  group by Student_ID) 
StudentCourse1 ON StudentCourse1.Student_ID = Student.Student_ID LEFT OUTER JOIN 
(SELECT Student_ID, COUNT(*) AS CompletedSubject FROM StudentCourse where StudentCourse_Status = 3  group by Student_ID) 
StudentCourse2 ON StudentCourse2.Student_ID = Student.Student_ID LEFT OUTER JOIN 
(SELECT Student_ID, COUNT(*) AS RemainingSubject FROM StudentCourse where (StudentCourse_Status = 1 or StudentCourse_Status = 2)  group by Student_ID) 
StudentCourse3 ON StudentCourse3.Student_ID = Student.Student_ID
Inner Join Course on Course.Course_ID = Student.Course_ID
LEFT OUTER JOIN Sponsor ON Sponsor.Sponsor_ID = [Application].Sponsor_ID 
Inner Join
(
select Student.Student_ID, COALESCE(substring(
	(
	SELECT ','+ 
	case
		when StudentCourse_Status = 1 then CourseSubject_Code + ': Undertaking' 
		when StudentCourse_Status = 2 then CourseSubject_Code + ': Inactive'
		when StudentCourse_Status = 3 then CourseSubject_Code + ': Completed'
		when StudentCourse_Status = 6 then CourseSubject_Code + ': Exempted'
		end as [data()]
	FROM StudentCourse
	Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
	and StudentCourse.Student_ID = Student.Student_ID
	for xml path('')),2,1000),'') as 'SubjectProgress'
	From Student
) StudentPaper on StudentPaper.Student_ID = Student.Student_ID
left outer Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID
left outer Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
where 1=1

and Student_CreatedDate >= @CreatedDateFrom 
and Student_CreatedDate <= @CreatedDateTo
and Student_EnrollmentDate >= @EnrollmentDateFrom 
and Student_EnrollmentDate <= @EnrollmentDateTo
and Application_FullName like @Fullname
and (Application_Gender = @Gender OR @Gender = -1)
and Application_Email like @Email
and (Application_PhoneNumber LIKE @ContactNum or Application_PhonePrefix like @ContactNum)
and (Application_ContractType = @ContractType OR @ContractType = -1)
and (Student_Status = @Status OR @Status = -1)
and CHARINDEX( ',' + cast([Application].Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0
and CHARINDEX( ',' + cast([Application].TSP_ID as varchar(36)) + ',', ',' + @TSPIDs + ',' ) > 0
and (Application_IdentificationNumber like @IC)
) RptStudentProgressSummaryMasterList";

            com.Parameters.AddWithValue("@CreatedDateFrom", CreatedDateFrom);
            com.Parameters.AddWithValue("@CreatedDateTo", CreatedDateTo);
            com.Parameters.AddWithValue("@EnrollmentDateFrom", EnrollmentDateFrom);
            com.Parameters.AddWithValue("@EnrollmentDateTo", EnrollmentDateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + FullName + "%");
            com.Parameters.AddWithValue("@Gender", Gender);
            com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            com.Parameters.AddWithValue("@ContactNum", "%" + ContactNum + "%");
            com.Parameters.AddWithValue("@ContractType", ContractType);
            com.Parameters.AddWithValue("@Status", Status);
            com.Parameters.AddWithValue("@SPONSORID", sponsorIDs);
            com.Parameters.AddWithValue("@TSPIDs", TSPIDs);
            com.Parameters.AddWithValue("@IC", "%" +IC+ "%");

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptStudentProgressSummaryMasterListTable> lis = DA.GetPagedDataList<RptStudentProgressSummaryMasterListTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 11: Alumni Voluntary Hour Summary Report
        public PagedDataList<RptAlumniVoluntaryHourSummaryTable> SearchAlumniVoluntaryHourSummary(DateTime EntrollmentDateFrom, DateTime EntrollmentDateTo,
    string fullname, int gender, string email, string contactNum, int contractType, string sponsorIDs, int status, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
select 
App.Application_FullName as 'FullName',
App.Application_DOB as 'DateofBirth',
Case
	when App.Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
App.Application_IdentificationNumber as 'ICNumber',
App.Application_Email as 'Email',
App.Application_PhonePrefix+' '+App.Application_PhoneNumber as 'PhoneNumber',
App.Application_MobilePhonePrefix+' '+App.Application_MobilePhoneNumber as 'Mobile',
Student.Student_EnrollmentDate as 'EnrollmentDate',
TSP.TSP_CampusName as 'CampusName',
TSP.TSP_City as 'CampusCity',
Case 
	When App.Application_ContractType = 1 then 'Part Time'
	Else 'Full Time'
End as 'ContractType',
ISNULL(VH.TotalHours, 0) as TotalWorkHour

from 
Student
Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0 AND App.Application_OverallStatus = @ApplicationOverallStatus  
Left Join 
(
select VoluntaryHour.Application_ID, Sum(VoluntaryHour.VoluntaryHour_duration) as TotalHours
From VoluntaryHour Group By VoluntaryHour.Application_ID
) VH on VH.Application_ID = App.Application_ID
Inner Join TSP on TSP.TSP_ID = Student.TSP_ID

Where 
1=1 

and (Student.Student_Status = @Status OR @Status = -1) 
and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
and Student.Student_EnrollmentDate >= @EntrollmentDateFrom 
and Student.Student_EnrollmentDate <= @EnrollmentDateTo
and App.Application_FullName like @Fullname
and App.Application_Email like @Email
and (App.Application_PhoneNumber like @ContactNumber OR App.Application_MobilePhoneNumber like @ContactNumber)
and (App.Application_Gender = @Gender OR @Gender = -1)
and (App.Application_ContractType = @ContractType OR @ContractType = -1)

) RptAlumniVoluntaryHourSummary";

            com.Parameters.AddWithValue("@ApplicationOverallStatus", (short)EngineVariable.ApplicationOverallStatusType.Completed);
            com.Parameters.AddWithValue("@Status", status);
            com.Parameters.AddWithValue("SPONSORID", sponsorIDs);
            com.Parameters.AddWithValue("@EntrollmentDateFrom", EntrollmentDateFrom);
            com.Parameters.AddWithValue("@EnrollmentDateTo", EntrollmentDateTo);
            com.Parameters.AddWithValue("@Fullname", "%" + fullname + "%");
            com.Parameters.AddWithValue("@Gender", gender);
            com.Parameters.AddWithValue("@Email", "%" + email + "%");
            com.Parameters.AddWithValue("@ContactNumber", "%" + contactNum + "%");
            com.Parameters.AddWithValue("@ContractType", contractType);

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptAlumniVoluntaryHourSummaryTable> lis = DA.GetPagedDataList<RptAlumniVoluntaryHourSummaryTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 12 - Success Rate Summary Report
        public DataTable SearchSuccessRateSummary(DateTime intakeDF, DateTime intakeDT, DateTime enrolDF, DateTime enrolDT,
            string fullname, string email, string contact, string sponsor, int gender, int contracttype)
        {
            DataTable dt = new DataTable();
            string sql = @"
                    select 
                    App.Application_IntakeMonth as IntakeMonth, 
                    App.Application_IntakeYear as IntakeYear,	
                    Concat(Convert(Char(3),DATENAME(month, Concat('2000-',App.Application_IntakeMonth,'-1'))),' ',App.Application_IntakeYear) AS 'Intake',
                    Course.Course_Name as 'CourseName',
                    Course.Course_Code as 'CourseCode',
                    Count(App.Application_FullName) as 'TotalApplicants',
                    Count(StuEnroll.Application_ID) as 'TotalEnroll',
                    Count(StuComplete.Application_ID) as 'TotalComplete',
                    (Count(StuComplete.Application_ID) / Count(StuEnroll.Application_ID)) * 100 as 'CompleteRate'
                    from 
                    Application App
                    Left Join Course on Course.Course_ID = App.Course_ID

                    Left Join Student StuEnroll on StuEnroll.Application_ID = App.Application_ID and StuEnroll.Student_Status = 1 
                    and StuEnroll.Student_EnrollmentDate >= @EnrollmentDateFrom 
                    and StuEnroll.Student_EnrollmentDate <= @EnrollmentDateTo

                    Left Join Student StuComplete on StuComplete.Application_ID = App.Application_ID and StuComplete.Student_Status = 2
                    Where 
                    1=1
                    and App.Application_Deleted = 0
                    and CONVERT(date, CONCAT(Application_IntakeYear,'-',Application_IntakeMonth,'-01')) >= @IntakeDateFrom
                    and CONVERT(date, CONCAT(Application_IntakeYear,'-',Application_IntakeMonth,'-01')) <= @IntakeDateTo
                    and App.Application_FullName like @Fullname
                    and App.Application_Email like @Email
                    and (App.Application_PhoneNumber like @ContactNumber OR App.Application_MobilePhoneNumber like @ContactNumber)
                    and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
                    and (App.Application_Gender = @Gender OR @Gender = -1)
                    and (App.Application_ContractType = @ContractType OR @ContractType = -1)

                    group by 
                    App.Application_IntakeMonth, 
                    App.Application_IntakeYear,
                    Course.Course_Name,
                    Course.Course_Code
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("IntakeDateFrom", intakeDF));
            cmd.Parameters.Add(new SqlParameter("IntakeDateTo", intakeDT));
            cmd.Parameters.Add(new SqlParameter("EnrollmentDateFrom", enrolDF));
            cmd.Parameters.Add(new SqlParameter("EnrollmentDateTo", enrolDT));
            cmd.Parameters.Add(new SqlParameter("Fullname", "%" + fullname + "%"));
            cmd.Parameters.Add(new SqlParameter("Email", "%" + email + "%"));
            cmd.Parameters.Add(new SqlParameter("ContactNumber", "%" + contact + "%"));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", sponsor));
            cmd.Parameters.Add(new SqlParameter("Gender", gender));
            cmd.Parameters.Add(new SqlParameter("ContractType", contracttype));

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 13: Attendance Analysis Report
        public PagedDataList<RptAttendanceAnalysisTable> SearchAttendanceAnalysis(DateTime IntakeDateFrom, DateTime IntakeDateTo,
    string fullname, int gender, int contractType, string sponsorIDs, string tsps, bool isPaging, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(1, true);
            SqlCommand com = new SqlCommand();
            string sql = @" (
                        select 
	DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
	DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear,
	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'IntakeDate',
            App.Application_FullName as 'FullName',
            App.Application_DOB	as 'DOB',
            Case
	            when App.Application_Gender = 1 then 'Male'
	            Else 'Female'
            End As 'Gender',
            Case
	            when App.Application_Nationality = 1 then 'Malaysian'
	            Else 'Others'
            End As 'Nationality',
            App.Application_IdentificationNumber as 'ICNo',
            App.Application_Email	as 'Email',
            COALESCE(Sponsor_Code, '') AS 'Sponsor',
            TSP.TSP_CampusName as 'TSP',
            Course.Course_Code as Course,
            CourseSubject.CourseSubject_Code as 'Paper',
            TotalClass.TotalClass,
            TotalClass.AttendedClass,
            Case
	            When TotalClass.TotalClass > 0 then (TotalClass.AttendedClass * 100) / TotalClass.TotalClass 
	            Else 0
            End as 'AttendanceRate',
            COALESCE(FinalResult.Score, 0) as 'FinalResult'
            from 
            Student
            Inner Join Course on Course.Course_ID = Student.Course_ID
            Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
            LEFT OUTER JOIN Sponsor on App.Sponsor_ID = Sponsor.Sponsor_ID
            Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
            Inner Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID
            Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
            Inner Join(	
	            select Progress.StudentCourse_ID, 
	            Sum(Progress.StudentCourseProgress_TotalClass) as 'TotalClass',
	            Sum(Progress.StudentCourseProgress_AttendedClass) as 'AttendedClass'	
	              from StudentCourseProgress as Progress
	            Inner Join StudentCourse on StudentCourse.StudentCourse_ID = Progress.StudentCourse_ID
	            Where Progress.StudentCourseProgress_IsDeleted = 0
	            Group By Progress.StudentCourse_ID
            ) TotalClass on TotalClass.StudentCourse_ID = StudentCourse.StudentCourse_ID
            Left Join(	
	            SELECT StudentCourseProgress_ExamScore AS Score, StudentCourse.StudentCourse_ID FROM StudentCourse LEFT JOIN StudentCourseProgress
ON StudentCourse.StudentCourse_ID = StudentCourseProgress.StudentCourse_ID
WHERE StudentCourseProgress.StudentCourseProgress_ExamIsFinal = 1
            ) FinalResult on FinalResult.StudentCourse_ID = StudentCourse.StudentCourse_ID
            Where 
            1=1
            and App.Application_Deleted = 0
and Student.Student_EnrollmentDate >= @DateFrom
and Student.Student_EnrollmentDate <= @DateTo
            and App.Application_FullName like @Fullname
            and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
            and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
            and (App.Application_Gender = @Gender OR @Gender = -1)
            and (App.Application_ContractType = @ContractType OR @ContractType = -1)

            ) RptAttendanceAnalysis";

            com.Parameters.AddWithValue("@DateFrom", IntakeDateFrom);
            com.Parameters.AddWithValue("@DateTo", IntakeDateTo);
            com.Parameters.AddWithValue("Fullname", "%" + fullname + "%");
            com.Parameters.AddWithValue("SPONSORID", sponsorIDs);
            com.Parameters.AddWithValue("TSPID", tsps);
            com.Parameters.AddWithValue("Gender", gender);
            com.Parameters.AddWithValue("ContractType", contractType);

            int RecPerPage = isPaging ? EngineVariable.LibraryVariable.Page_Size : int.MaxValue;

            PagedDataList<RptAttendanceAnalysisTable> lis = DA.GetPagedDataList<RptAttendanceAnalysisTable>(sql, com, def, ordering, RecPerPage, pg);

            return lis;
        }
        #endregion

        #region Report 14 - Exam Analysis Report
        public DataTable SearchExamAnalysis(DateTime intakeDF, DateTime intakeDT, string sponsor, int contracttype, string tsp, string courseid)
        {
            DataTable dt = new DataTable();
            string sql = @"
                    select 
                    Paper.CourseSubject_Code as 'Paper', 
                    COALESCE(Sponsor_Code, '') AS 'Sponsor',
                    Count (Pass.StudentCourse_ID) as 'TotalPass',
                    Count (Fail.StudentCourse_ID) as 'TotalFail'

                    from
                    Student
                    Inner Join StudentCourse SC on SC.Student_ID = Student.Student_ID

                    Left Join StudentCourseProgress Pass on Pass.StudentCourse_ID = SC.StudentCourse_ID
                    and Pass.StudentCourseProgress_ExamIsFinal = 1 and Pass.StudentCourseProgress_ExamScore >= 50

                    Left Join StudentCourseProgress Fail on Pass.StudentCourse_ID = SC.StudentCourse_ID
                    and Pass.StudentCourseProgress_ExamIsFinal = 1 and Pass.StudentCourseProgress_ExamScore < 50

                    Inner Join CourseSubject Paper on Paper.CourseSubject_ID = SC.CourseSubject_ID
                    Inner Join Application App on App.Application_ID = Student.Application_ID
                    LEFT OUTER JOIN Sponsor on App.Sponsor_ID = Sponsor.Sponsor_ID
                    Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
                    where
                    1=1
                    and App.Application_Deleted = 0
                    and Paper.Course_ID = @CourseID
and Student.Student_EnrollmentDate >= @IntakeDateFrom
and Student.Student_EnrollmentDate <= @IntakeDateTo
                    and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
                    and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
                    and (App.Application_ContractType = @ContractType OR @ContractType = -1)

                    Group by Paper.CourseSubject_Code, Sponsor_Code
                    Order by Sponsor_Code, Paper.CourseSubject_Code
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("IntakeDateFrom", intakeDF));
            cmd.Parameters.Add(new SqlParameter("IntakeDateTo", intakeDT));
            cmd.Parameters.Add(new SqlParameter("ContractType", contracttype));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", sponsor));
            cmd.Parameters.Add(new SqlParameter("TSPID", tsp));
            cmd.Parameters.Add(new SqlParameter("CourseID", courseid));


            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 15 - Student Progress Summary Report
        public DataTable SearchStudentProgressSummary(DateTime intakeDF, DateTime intakeDT, string fullname, string sponsor, int gender, int contracttype)
        {
            DataTable dt = new DataTable();
            string sql = @"

select 
App.Application_FullName as 'FullName',
App.Application_DOB as 'DateofBirth',
Case
	when App.Application_Gender = 1 then 'Male'
	Else 'Female'
End As 'Gender',
App.Application_IdentificationNumber as 'ICNumber',
App.Application_Email as 'Email',
App.Application_PhonePrefix+' '+App.Application_PhoneNumber as 'PhoneNumber',
App.Application_MobilePhonePrefix+' '+App.Application_MobilePhoneNumber as 'Mobile',
COALESCE(Sponsor_Code, '') AS 'Sponsor',
Concat(Convert(Char(3),DATENAME(month, Concat('2000-',App.Application_IntakeMonth,'-1'))),' ',App.Application_IntakeYear) AS 'Cohort',
Student.Student_EnrollmentDate as 'StartDate',
Student.Student_ContractExpiredDate as 'EndDate',
StudentPaper.ExemptedPaper, 
COALESCE(StudentPaperComplete.CompletedPaper, '') AS 'Completed Paper',
COALESCE(StudentPaperRemaining.RemainingPaper, '') AS 'Remaining Paper',
CourseSubject.CourseSubject_Code as PaperName,
--Progress.StudentCourseProgress_Date as ProgressDate,
right(convert(varchar, Progress.StudentCourseProgress_Date, 106), 8) as ProgressDate,
Progress.StudentCourseProgress_TotalClass as TotalClass,
Progress.StudentCourseProgress_AttendedClass as AttendedClass,
Case
	When Progress.StudentCourseProgress_TotalClass > 0 then (Progress.StudentCourseProgress_AttendedClass * 100 / Progress.StudentCourseProgress_TotalClass)
	Else 0
End  as Attendance,
Progress.StudentCourseProgress_ExamIsFinal as Final,
Progress.StudentCourseProgress_ExamScore as Score

from 
Student
Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
LEFT OUTER JOIN Sponsor on Sponsor.Sponsor_ID = App.Sponsor_ID 
Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
Left Join
(
	select Student.Student_ID, substring(
	(
	SELECT ','+CourseSubject.CourseSubject_Code as [data()] 
	FROM StudentCourse
	Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
	Where 1=1
	and StudentCourse.Student_ID = Student.Student_ID
	and StudentCourse.StudentCourse_Status = 6 -- Exempted Paper Status
	for xml path('')),2,1000)[ExemptedPaper]
	From Student
) StudentPaper on StudentPaper.Student_ID = Student.Student_ID
Left Join
(
	select Student.Student_ID, substring(
	(
	SELECT ','+CourseSubject.CourseSubject_Code as [data()] 
	FROM StudentCourse
	Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
	Where 1=1
	and StudentCourse.Student_ID = Student.Student_ID
	and StudentCourse.StudentCourse_Status = 3 -- Completed
	for xml path('')),2,1000)[CompletedPaper]
	From Student
) StudentPaperComplete on StudentPaperComplete.Student_ID = Student.Student_ID
Left Join
(
	select Student.Student_ID, substring(
	(
	SELECT ','+CourseSubject.CourseSubject_Code as [data()] 
	FROM StudentCourse
	Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
	Where 1=1
	and StudentCourse.Student_ID = Student.Student_ID
	and (StudentCourse.StudentCourse_Status = 2 OR StudentCourse.StudentCourse_Status = 1)
	for xml path('')),2,1000)[RemainingPaper]
	From Student
) StudentPaperRemaining on StudentPaperRemaining.Student_ID = Student.Student_ID
Left Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID
Inner Join StudentCourseProgress Progress on Progress.StudentCourse_ID = StudentCourse.StudentCourse_ID --and Progress.StudentCourseProgress_TotalClass > 0
--Left Join StudentCourseProgress FinalExam on FinalExam.StudentCourse_ID = StudentCourse.StudentCourse_ID and FinalExam.StudentCourseProgress_ExamIsFinal = 1
Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
Where 
1=1
and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
and CONVERT(date, CONCAT(Application_IntakeYear,'-',Application_IntakeMonth,'-01')) >= @IntakeDateFrom
and CONVERT(date, CONCAT(Application_IntakeYear,'-',Application_IntakeMonth,'-01')) <= @IntakeDateTo
and App.Application_FullName like @Fullname
and (App.Application_Gender = @Gender OR @Gender = -1)
and (App.Application_ContractType = @ContractType OR @ContractType = -1)


order by App.Application_IdentificationNumber, Progress.StudentCourseProgress_Date, CourseSubject.CourseSubject_Code
            ";

//            select
//                App.Application_FullName as 'FullName',
//                App.Application_DOB as 'DateofBirth',
//                Case
//                    when App.Application_Gender = 1 then 'Male'
//                    Else 'Female'
//                End As 'Gender',
//                App.Application_IdentificationNumber as 'ICNumber',
//                App.Application_Email as 'Email',
//                App.Application_PhonePrefix + ' ' + App.Application_PhoneNumber as 'PhoneNumber',
//                App.Application_MobilePhonePrefix + ' ' + App.Application_MobilePhoneNumber as 'Mobile',
//                Case
//                    When App.Application_Sponsor = 1 Then 'MyPAC'
//                    When App.Application_Sponsor = 2 Then 'YPPB'
//                End as 'Sponsor',
//	Concat(Convert(Char(3), DATENAME(month, Concat('2000-', DATEPART(MM, Student.Student_EnrollmentDate), '-1'))), ' ', DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Cohort',
//                Student.Student_EnrollmentDate as 'StartDate',
//                Student.Student_ContractExpiredDate as 'EndDate',
//                StudentPaper.ExemptedPaper, 
//                CourseSubject.CourseSubject_Code as PaperName,
//                --Progress.StudentCourseProgress_Date as ProgressDate,
//                right(convert(varchar, Progress.StudentCourseProgress_Date, 106), 8) as ProgressDate,
//                Progress.StudentCourseProgress_TotalClass as TotalClass,
//                Progress.StudentCourseProgress_AttendedClass as AttendedClass,
//                Case
//                    When Progress.StudentCourseProgress_TotalClass > 0 then(Progress.StudentCourseProgress_AttendedClass * 100 / Progress.StudentCourseProgress_TotalClass)
//                    Else 0
//                End as Attendance,
//                Progress.StudentCourseProgress_ExamIsFinal as Final,
//                Progress.StudentCourseProgress_ExamScore as Score

//                from
//                Student
//                Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
//                Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
//                Left Join
//                (
//                    select Student.Student_ID, substring(
//                    (
//                    SELECT ',' + CourseSubject.CourseSubject_Code as [data()]
//                    FROM StudentCourse
//                    Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
//                    Where 1 = 1
//                    and StudentCourse.Student_ID = Student.Student_ID
//                    and StudentCourse.StudentCourse_Status = 6-- Exempted Paper Status
//                    for xml path('')),2,1000)[ExemptedPaper]
//        From Student
//                ) StudentPaper on StudentPaper.Student_ID = Student.Student_ID
//                Left Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID
//                Inner Join StudentCourseProgress Progress on Progress.StudentCourse_ID = StudentCourse.StudentCourse_ID--and Progress.StudentCourseProgress_TotalClass > 0
//                --Left Join StudentCourseProgress FinalExam on FinalExam.StudentCourse_ID = StudentCourse.StudentCourse_ID and FinalExam.StudentCourseProgress_ExamIsFinal = 1
//                Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
//                Where
//                1=1
//                and CHARINDEX( ',' + cast(App.Application_Sponsor as char(1)) + ',', ',' + @SPONSORID + ',' ) > 0 
//and Student.Student_EnrollmentDate >= @IntakeDateFrom
//and Student.Student_EnrollmentDate <= @IntakeDateTo
//                and App.Application_FullName like @Fullname
//                and (App.Application_Gender = @Gender OR @Gender = -1)
//                and(App.Application_ContractType = @ContractType OR @ContractType = -1)


//                order by App.Application_FullName, Progress.StudentCourseProgress_Date
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("IntakeDateFrom", intakeDF));
            cmd.Parameters.Add(new SqlParameter("IntakeDateTo", intakeDT));
            cmd.Parameters.Add(new SqlParameter("ContractType", contracttype));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", sponsor));
            cmd.Parameters.Add(new SqlParameter("Gender", gender));
            cmd.Parameters.Add(new SqlParameter("Fullname", "%" + fullname + "%"));


            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 16 - Semester Summary Report
        public DataTable SearchSemesterSummary(DateTime intakeDF, DateTime intakeDT, string fullname, string sponsor, int gender, int contracttype)
        {
            DataTable dt = new DataTable();
            string sql = @"
                select distinct 
                App.Application_FullName as 'FullName',
                App.Application_DOB as 'DateofBirth',
                Case
	                when App.Application_Gender = 1 then 'Male'
	                Else 'Female'
                End As 'Gender',
                App.Application_IdentificationNumber as 'ICNumber',
                App.Application_Email as 'Email',
                App.Application_PhonePrefix+' '+App.Application_PhoneNumber as 'PhoneNumber',
                App.Application_MobilePhonePrefix+' '+App.Application_MobilePhoneNumber as 'Mobile',
                Case 
	                When App.Application_ContractType = 1 then 'Part Time'
	                Else 'Full Time'
                End as 'ContractType',
                COALESCE(Sponsor_Code, '') AS 'Sponsor',
	Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Cohort',
                Student.Student_EnrollmentDate as 'StartDate',
                Case 
	                When Student.Student_Status = 6 then 'Yes'
	                Else 'No'
                End as Withdrawal,
                CourseSubject.CourseSubject_Code as PaperName,
                convert(datetime, TotalClass.ProgressMonth, 103) as 'ProgressDate',
                TotalClass.ProgressMonth,
                TotalClass.TotalClass,
                TotalClass.AttendedClass,
                Case
	                When TotalClass.TotalClass > 0 then (TotalClass.AttendedClass * 100) / TotalClass.TotalClass 
	                Else null
                End as 'AttendanceRate',
                TestResult.Score as TestScore,
                FinalResult.Score as FinalResult
                from 
                Student
                Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0
                Inner Join TSP on TSP.TSP_ID = Student.TSP_ID
                LEFT OUTER JOIN Sponsor on Sponsor.Sponsor_ID = App.Sponsor_ID
                Left Join StudentCourse on StudentCourse.Student_ID = Student.Student_ID
                Left Join(	
	                select Progress.StudentCourse_ID, 
	                convert(char(3), Progress.StudentCourseProgress_Date, 0)+' '+CAST(YEAR(Progress.StudentCourseProgress_Date) AS VARCHAR(4)) as ProgressMonth,
	                Sum(Progress.StudentCourseProgress_TotalClass) as 'TotalClass',
	                Sum(Progress.StudentCourseProgress_AttendedClass) as 'AttendedClass'	
	                from StudentCourseProgress as Progress
	                Inner Join StudentCourse on StudentCourse.StudentCourse_ID = Progress.StudentCourse_ID
	                Where Progress.StudentCourseProgress_IsDeleted = 0
	                Group By Progress.StudentCourse_ID, 
	                convert(char(3), Progress.StudentCourseProgress_Date, 0)+' '+CAST(YEAR(Progress.StudentCourseProgress_Date) AS VARCHAR(4))
                ) TotalClass on TotalClass.StudentCourse_ID = StudentCourse.StudentCourse_ID
                Left Join(	
	                select Progress.StudentCourse_ID, Progress.StudentCourseProgress_ExamScore as 'Score'
	                from StudentCourseProgress as Progress
	                Inner Join StudentCourse on StudentCourse.StudentCourse_ID = Progress.StudentCourse_ID
	                Where Progress.StudentCourseProgress_IsDeleted = 0
	                and Progress.StudentCourseProgress_ExamIsFinal = 1
                ) FinalResult on FinalResult.StudentCourse_ID = StudentCourse.StudentCourse_ID
                Left Join(	
	                select Progress.StudentCourse_ID, Progress.StudentCourseProgress_ExamScore as 'Score'
	                from StudentCourseProgress as Progress
	                Inner Join StudentCourse on StudentCourse.StudentCourse_ID = Progress.StudentCourse_ID
	                Where Progress.StudentCourseProgress_IsDeleted = 0
	                and Progress.StudentCourseProgress_ExamIsFinal = 0
                ) TestResult on TestResult.StudentCourse_ID = StudentCourse.StudentCourse_ID
                Inner Join CourseSubject on CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
                Where 
                1=1

                and CHARINDEX( ',' + cast(App.Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 
and Student.Student_EnrollmentDate >= @IntakeDateFrom
and Student.Student_EnrollmentDate <= @IntakeDateTo
                and App.Application_FullName like @Fullname
                and (App.Application_Gender = @Gender OR @Gender = -1)
                and (App.Application_ContractType = @ContractType OR @ContractType = -1)
                and TotalClass.ProgressMonth IS NOT NULL
                order by App.Application_FullName, ProgressDate, PaperName
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("IntakeDateFrom", intakeDF));
            cmd.Parameters.Add(new SqlParameter("IntakeDateTo", intakeDT));
            cmd.Parameters.Add(new SqlParameter("ContractType", contracttype));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", sponsor));
            cmd.Parameters.Add(new SqlParameter("Gender", gender));
            cmd.Parameters.Add(new SqlParameter("Fullname", "%" + fullname + "%"));


            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 17 - Application Overview
        public DataTable SearchApplicationOverview(int Month, int Year)
        {
            DataTable dt = new DataTable();
            string sql = @"
                    Select 
                    Count(C.Candidate_ID) as 'Total Register',
                    Count(A.Application_ID) as 'Total Apply',
                    Case	
	                    when (Count(C.Candidate_ID) > 0 )then Count(A.Application_ID)*100 / Count(C.Candidate_ID)
	                    else 0
                    End as 'Register Rate(%)',
                    Count(S.Student_ID) as 'Total Success',
                    Count(A.Application_ID) - Count(S.Student_ID) as 'Total Rejected',
                    Case	
	                    when (Count(A.Candidate_ID) > 0 )then Count(S.Student_ID)*100 / Count(A.Application_ID)
	                    else 0
                    End as 'Application Success Rate(%)',
                    Count(S1.Student_ID) as 'Total Active',
                    Count(S2.Student_ID) as 'Total Completed',
                    Count(S3.Student_ID) as 'Total Terminated',
                    Count(S4.Student_ID) as 'Total Withdrawn',
                    Case	
	                    when (Count(S.Student_ID) > 0 )then Count(S2.Student_ID)*100 / Count(S.Student_ID)
	                    else 0
                    End as 'Student Complete Rate(%)'

                    from Candidate C
                    Left Join Application A on A.Candidate_ID = C.Candidate_ID
                    Left Join Student S on S.Application_ID = A.Application_ID
                    Left Join Student S1 on S1.Application_ID = A.Application_ID and S1.Student_Status = 1 -- Active
                    Left Join Student S2 on S2.Application_ID = A.Application_ID and S2.Student_Status = 2 -- Complete
                    Left Join Student S3 on S3.Application_ID = A.Application_ID and S3.Student_Status = 3 -- Terminated
                    Left Join Student S4 on S4.Application_ID = A.Application_ID and S4.Student_Status = 4 -- Withdrawn
                    where 
                    1=1
                    and Month(C.Candidate_CreatedDate) = @Month 
                    and Year(C.Candidate_CreatedDate) = @Year 
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add(new SqlParameter("Month", Month));
            cmd.Parameters.Add(new SqlParameter("Year", Year));


            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion

        #region Report 18 - Intake By Sponsorhsip
        public DataTable SearchIntakeBySponsorship(int YearFrom, int YearTo, string TSPs, string Sponsorships)
        {
            DateTime DateFrom = new DateTime(YearFrom, 1, 1, 0, 0, 0);
            DateTime DateTo = new DateTime(YearTo, 12, 31, 0, 0, 0);
            DataTable dt = new DataTable();
            string sql = @"select 
DATEPART(MM, Student.Student_EnrollmentDate) as IntakeMonth, 
DATEPART(YYYY, Student.Student_EnrollmentDate) as IntakeYear, 
Concat(Convert(Char(3),DATENAME(month, Concat('2000-',DATEPART(MM, Student.Student_EnrollmentDate),'-1'))),' ',DATEPART(YYYY, Student.Student_EnrollmentDate)) AS 'Intake', 
Count(Student.Application_ID) as ActiveCount, Sponsor.Sponsor_Code, Sponsor.Sponsor_Label 
from Student Inner Join Application App on Student.Application_ID = App.Application_ID and App.Application_Deleted = 0 
LEFT Join Sponsor ON Sponsor.Sponsor_ID = [Application].Sponsor_ID
Inner Join TSP on TSP.TSP_ID = Student.TSP_ID 
Inner Join Course on Course.Course_ID = Student.Course_ID Where 1=1
and Student.Student_EnrollmentDate >= @DateFrom 
and Student.Student_EnrollmentDate <= @DateTo 
and CHARINDEX( ',' + cast(TSP.TSP_ID as varchar(36)) + ',', ',' + @TSPID + ',' ) > 0 
and CHARINDEX( ',' + cast(App.Sponsor_ID as char(1)) + ',', ',' + @SPONSORID + ',' ) > 0 and Student.Student_Status = 1 
group by Student.Student_EnrollmentDate, App.Application_Sponsor 
order by Student.Student_EnrollmentDate";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            cmd.Parameters.Add(new SqlParameter("TSPID", TSPs));
            cmd.Parameters.Add(new SqlParameter("SPONSORID", Sponsorships));

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
        #endregion
        
        public class RptSalesSubmissionDetailSum
        {
            public int TradeID = 0;
            public double TotalSales = 0;
            public int Sqft = 0;
            public double TotalSalesPerSqft = 0;
            public double TotalSalesPerSqftPerDay = 0;
        }
    }
}
