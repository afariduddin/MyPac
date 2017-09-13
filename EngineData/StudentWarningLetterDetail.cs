using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class StudentWarningLetterDetailTable
    {
    }
    partial class StudentWarningLetterDetailRow
    {
    }
    public partial class StudentWarningLetterDetailMinimalizedEntity { }
    partial class StudentWarningLetterDetailAdapter
    {

        public StudentWarningLetterDetailTable GetByStudentID(Guid ID)
        {
            string sql = "SELECT * FROM StudentWarningLetterDetail WHERE Student_ID = @Student_ID ";
            sql += " order by StudentWarningLetter_CreatedDate desc ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Student_ID", ID);
            StudentWarningLetterDetailTable tbl = new StudentWarningLetterDetailTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }

        public StudentWarningLetterDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM StudentWarningLetterDetail WHERE EmailNotification_ID = @EmailNotification_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@EmailNotification_ID", ID);
            StudentWarningLetterDetailTable tbl = new StudentWarningLetterDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetStudentWarningLetterDetailRow(0);
            }
            else
            {
                return null;
            }
        }
        public PagedDataList<StudentWarningLetterDetailTable> GetForCandidateDashboard(Guid studentId, int pg)
        {
            //SELECT WarningLetter_ID, WarningLetter_Subject, WarningLetter_CreatedDate FROM WarningLetter
//            string sql = @"
//StudentWarningLetterDetail where 1=1  And Student_ID = @studentId

//";


            string sql = "";

            sql += "StudentWarningLetterDetail where 1=1  And Student_ID = @studentId ";
            SqlOrder def = new SqlOrder(StudentWarningLetterDetailTable.StudentWarningLetter_CreatedDateColumnIndex, false);
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@studentId", studentId);
            PagedDataList<StudentWarningLetterDetailTable> lis = DA.GetPagedDataList<StudentWarningLetterDetailTable>(sql, com, def, new SqlOrder[0], EngineVariable.LibraryVariable.Page_Size, pg);
            #region clear unwanted columns to reduce package size - DO NOT update the table
            //foreach (StudentWarningLetterDetailRow dr in lis.DataTable.Rows)
            //{
            //    dr.WarningLetter_Body = "";
            //    dr.WarningLetter_CreatedBy = "";
            //    dr.WarningLetter_Name = "";
            //    dr.WarningLetter_UpdatedBy = "";
            //}
            #endregion
            return lis;
        }

    }
}
