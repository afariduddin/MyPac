using System;
using System.Data.SqlClient;

namespace EngineData
{
    partial class StudentCourseAttachmentTable
    {
    }
    partial class StudentCourseAttachmentRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class StudentCourseAttachmentMinimalizedEntity { }
    partial class StudentCourseAttachmentAdapter
    {

        public StudentCourseAttachmentTable GetBy(Guid StudentCourse_ID)
        {
            string sql = "SELECT * FROM StudentCourseAttachment";
            sql += " Where StudentCourse_ID = @StudentCourse_ID ";
            sql += " AND StudentCourseAttachment_IsDeleted = 0 ";
            sql += " order by StudentCourseAttachment_Name asc ";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@StudentCourse_ID", StudentCourse_ID);
            StudentCourseAttachmentTable tbl = new StudentCourseAttachmentTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}
