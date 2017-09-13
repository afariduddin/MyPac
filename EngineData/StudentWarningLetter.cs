using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class StudentWarningLetterTable
    {
    }
    partial class StudentWarningLetterRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class StudentWarningLetterMinimalizedEntity { }
    partial class StudentWarningLetterAdapter
    {
        public StudentWarningLetterRow GetByStudentID(Guid StudentID)
        {
            string sql = "SELECT * FROM StudentWarningLetter WHERE Student_ID  = @StudentID ";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@StudentID", StudentID);

            StudentWarningLetterTable tbl = new StudentWarningLetterTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
                return (StudentWarningLetterRow)tbl.Rows[0];
            else
                return null;
        }

        public void DeleteByStudentID(Guid StudentID)
        {
            string sql = "DELETE FROM StudentWarningLetter WHERE Student_ID = @StudentID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@StudentID", StudentID);

            DA.ExecuteNonQuery(com);
        }
    }
}
