using System;
using System.Data.SqlClient;
using System.Data;
using EngineVariable;
using Teq;

namespace EngineData
{
    partial class StudentCourseProgressTable
    {
    }
    partial class StudentCourseProgressRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class StudentCourseProgressMinimalizedEntity { }
    partial class StudentCourseProgressAdapter
    {

//        AND StudentCourseProgress_Date >= @dtf
//AND StudentCourseProgress_Date<@dtt
        public DataTable GetAttendanceSummary(Guid studentId, DateTime dtf, DateTime dtt)
        {
            string sql = @"
SELECT StudentCourse_ID, StudentCourseProgress_Date, StudentCourseProgress_TotalClass, StudentCourseProgress_AttendedClass
FROM StudentCourseProgress WHERE 1=1
AND StudentCourseProgress_IsDeleted = 0

AND StudentCourse_ID IN
(
	SELECT StudentCourse_ID FROM StudentCourse WHERE Student_ID = @studentId
)
ORDER BY StudentCourse_ID
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("studentId", studentId);
            //com.Parameters.AddWithValue("dtf", dtf);
            //com.Parameters.AddWithValue("dtt", dtt);
            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}