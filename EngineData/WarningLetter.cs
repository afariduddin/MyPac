using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class WarningLetterTable
    {
    }
    partial class WarningLetterRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class WarningLetterMinimalizedEntity { }
    partial class WarningLetterAdapter
    {
        public PagedDataList<WarningLetterTable> Search(string WarningLetterName, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(WarningLetterTable.WarningLetter_CreatedDateColumnIndex, false);

            string sql = "WarningLetter WHERE WarningLetter_Name LIKE @WarningLetterName ";
            sql += " and WarningLetter_Deleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@WarningLetterName", "%" + WarningLetterName + "%");

            PagedDataList<WarningLetterTable> lis = DA.GetPagedDataList<WarningLetterTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
        public List<WarningLetterRow> GetWarningLetterList()
        {
            List<WarningLetterRow> list = new List<WarningLetterRow>();
            string sql = "SELECT * FROM WarningLetter WHERE WarningLetter_Deleted = 0 order by WarningLetter_Name asc";
            SqlCommand com = new SqlCommand(sql);
            WarningLetterTable tbl = new WarningLetterTable();
            DA.ExecuteQuery(com, tbl);
            foreach (WarningLetterRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
        }
        public PagedDataList<WarningLetterTable> GetForCandidateDashboard(Guid studentId, int pg)
        {
            //SELECT WarningLetter_ID, WarningLetter_Subject, WarningLetter_CreatedDate FROM WarningLetter
                string sql = @"
WarningLetter
WHERE WarningLetter_ID IN
(
	SELECT WarningLetter_ID FROM StudentWarningLetter WHERE Student_ID = @studentId
)
ORDER BY WarningLetter_CreatedDate DESC
";
                SqlOrder def = new SqlOrder(WarningLetterTable.WarningLetter_CreatedDateColumnIndex, false);
                SqlCommand com = new SqlCommand();
                com.Parameters.AddWithValue("studentId", studentId);
                PagedDataList<WarningLetterTable> lis = DA.GetPagedDataList<WarningLetterTable>(sql, com, def, new SqlOrder[0], EngineVariable.LibraryVariable.Page_Size, pg);
                #region clear unwanted columns to reduce package size - DO NOT update the table
                foreach (WarningLetterRow dr in lis.DataTable.Rows)
                {
                    dr.WarningLetter_Body = "";
                    dr.WarningLetter_CreatedBy = "";
                    dr.WarningLetter_Name = "";
                    dr.WarningLetter_UpdatedBy = "";
                }
                #endregion
                return lis;
        }
    }
}
