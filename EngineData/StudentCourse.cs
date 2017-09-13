using System;
using System.Data.SqlClient;
using System.Data;
using EngineVariable;
using Teq;

namespace EngineData
{
    partial class StudentCourseTable
    {
    }
    partial class StudentCourseRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class StudentCourseMinimalizedEntity { }
    partial class StudentCourseAdapter
    {
        public DataTable GetSubjectsStatus(Guid studentId)
        {
            string sql = @"
SELECT CourseSubject.CourseSubject_Code, CourseSubject.CourseSubject_Name, StudentCourse.StudentCourse_Status FROM StudentCourse
INNER JOIN CourseSubject ON StudentCourse.CourseSubject_ID = CourseSubject.CourseSubject_ID
WHERE StudentCourse.Student_ID = @studentId
AND StudentCourse.StudentCourse_Status != " + StudentCourseStatusType.Failed.Code + @"
AND StudentCourse.StudentCourse_Status != " + StudentCourseStatusType.Deferred.Code + @"
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("studentId", studentId);
            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public int CountCompletedSubjects(Guid studentId)
        {
            string sql = @"
SELECT COUNT(*) FROM StudentCourse
WHERE Student_ID = @studentId
AND (StudentCourse_Status = @completed OR StudentCourse_Status = @exempted)
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("studentId", studentId);
            com.Parameters.AddWithValue("completed", StudentCourseStatusType.Completed.Code);
            com.Parameters.AddWithValue("exempted", StudentCourseStatusType.Exempted.Code);
            return DA.ExecuteScalar<int>(com);
        }
        public DataTable GetSubjectsName(Guid studentId)
        {
            string sql = @"
SELECT StudentCourse.StudentCourse_ID, Course_Code, Course_Name, CourseSubject_Code, CourseSubject_Name FROM CourseSubject
INNER JOIN Course ON Course.Course_ID = CourseSubject.Course_ID
INNER JOIN StudentCourse ON StudentCourse.CourseSubject_ID = CourseSubject.CourseSubject_ID
WHERE StudentCourse.Student_ID = @studentId
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("studentId", studentId);
            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }

        public StudentCourseRow Get(string Application_IdentificationNumber, EngineVariable.ApplicationOverallStatusType Application_OverallStatus, string CourseSubject_Code)
        {
            string sql = "SELECT StudentCourse.* FROM StudentCourse, Student, [Application], CourseSubject";
            sql += " WHERE StudentCourse.Student_ID = Student.Student_ID";
            sql += " AND Student.Application_ID = [Application].Application_ID";
            sql += " AND Student.Course_ID = CourseSubject.Course_ID";
            sql += " AND StudentCourse.CourseSubject_ID = CourseSubject.CourseSubject_ID";
            sql += " AND [Application].Application_IdentificationNumber = @Application_IdentificationNumber";
            sql += " AND [Application].Application_OverallStatus = @Application_OverallStatus";
            sql += " AND CourseSubject.CourseSubject_Code = @CourseSubject_Code";
            sql += " AND (StudentCourse.StudentCourse_Status = 1 OR StudentCourse.StudentCourse_Status = 2)";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Application_IdentificationNumber", Application_IdentificationNumber);
            com.Parameters.AddWithValue("@Application_OverallStatus", (short)Application_OverallStatus);
            com.Parameters.AddWithValue("@CourseSubject_Code", CourseSubject_Code);
            StudentCourseTable tbl = new StudentCourseTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
                return (StudentCourseRow)tbl.Rows[0];
            else
                return null;
        }

        public StudentCourseTable Get_RemainingSubject(Guid Student_ID)
        {
            string sql = "SELECT StudentCourse.* FROM StudentCourse";
            sql += " WHERE StudentCourse.StudentCourse_Status != 3";
            sql += " AND StudentCourse.StudentCourse_Status != 6";
            sql += " AND [StudentCourse].Student_ID = @Student_ID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Student_ID", Student_ID);
            StudentCourseTable tbl = new StudentCourseTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }

        public DataTable GetStudentAttendanceHistory(Guid StudentCourse_ID)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT DATEPART(MM, StudentCourseProgress_Date) as 'AttendanceMonth', DATEPART(YYYY, StudentCourseProgress_Date) as 'AttendanceYear', SUM(StudentCourseProgress.StudentCourseProgress_TotalClass) AS TotalClass, SUM(StudentCourseProgress.StudentCourseProgress_AttendedClass) AS TotalAttended, StudentCourse_ID FROM StudentCourseProgress
WHERE StudentCourseProgress_Type = 3
AND StudentCourse_ID = @StudentCourse_ID
GROUP BY StudentCourseProgress_Date, StudentCourse_ID         
ORDER BY AttendanceYear, AttendanceMonth
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@StudentCourse_ID", StudentCourse_ID);

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }

        public DataTable GetStudentExamHistory(Guid StudentCourse_ID)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT StudentCourseProgress_Date, StudentCourseProgress_ExamScore, StudentCourseProgress_ExamIsFinal, StudentCourse_ID FROM StudentCourseProgress
WHERE StudentCourseProgress_Type = 2
AND StudentCourse_ID = @StudentCourse_ID     
ORDER BY StudentCourseProgress_Date
            ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@StudentCourse_ID", StudentCourse_ID);

            DA.ExecuteQuery(cmd, dt);

            return dt;
        }
    }
}