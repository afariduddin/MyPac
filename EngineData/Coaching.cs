using System;
using System.Data.SqlClient;
using System.Data;
using EngineVariable;
using Teq;

namespace EngineData
{
    partial class CoachingTable
    {
    }
    partial class CoachingRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class CoachingMinimalizedEntity { }
    partial class CoachingAdapter
    {
        public DataTable GetActiveAppointment(Guid studentId) // not used
        {//AND Coaching.Coaching_Date >=GETDATE()
            string sql = @"
SELECT Coaching_ID, Coaching_Date, Coaching_Description, Course_Code, Course_Name, CourseSubject_Code, CourseSubject_Name FROM Coaching 
INNER JOIN StudentCourse ON StudentCourse.StudentCourse_ID = Coaching.StudentCourse_ID
INNER JOIN CourseSubject ON CourseSubject.CourseSubject_ID = StudentCourse.CourseSubject_ID
INNER JOIN Course ON Course.Course_ID = CourseSubject.Course_ID
WHERE 1=1
AND StudentCourse.Student_ID = @studentId
AND Coaching.Coaching_IsDeleted = 0
AND Coaching.Coaching_Status = @cStatus
";
//AND Coaching.Coaching_Date >=GETDATE()

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("studentId", studentId);
            com.Parameters.AddWithValue("cStatus", CoachingStatusType.Open.Code);
            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}