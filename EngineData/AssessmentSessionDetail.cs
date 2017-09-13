using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class AssessmentSessionDetailTable {
}
partial class AssessmentSessionDetailRow {
}
public partial class AssessmentSessionDetailMinimalizedEntity {}
partial class AssessmentSessionDetailAdapter {

        public AssessmentSessionDetailTable Get(DateTime startDate, bool isInterview)
        {
            string sql = "SELECT * FROM AssessmentSessionDetail WHERE 1 = 1";
            sql += " AND AssessmentSession_IsDeleted = 0";
            sql += " AND AssessmentSession_DateTime > @startDate";
            sql += " AND AssessmentSession_IsInterview = @isInterview";
            SqlCommand com = new SqlCommand(sql);
                
            com.Parameters.AddWithValue("@startDate", startDate.ToString(EngineVariable.LibraryVariable.Format_DateTime));
            com.Parameters.AddWithValue("@isInterview", isInterview);

            AssessmentSessionDetailTable dt = new AssessmentSessionDetailTable();
            DA.ExecuteQuery(com, dt);

            return dt;
        }
        public AssessmentSessionDetailRow Get(Guid AssessmentSession_ID)
        {
            string sql = "SELECT * FROM AssessmentSessionDetail WHERE 1 = 1";
            sql += " AND AssessmentSession_IsDeleted = 0";
            sql += " AND AssessmentSession_ID = @AssessmentSession_ID";
            SqlCommand com = new SqlCommand(sql);
            
            com.Parameters.AddWithValue("@AssessmentSession_ID", AssessmentSession_ID);

            AssessmentSessionDetailTable dt = new AssessmentSessionDetailTable();
            DA.ExecuteQuery(com, dt);
            if(dt.Rows.Count > 0)
            {
                return dt.GetAssessmentSessionDetailRow(0);
            }else
            {
                return null;
            }
        }
        public PagedDataList<AssessmentSessionDetailTable> Search(DateTime startDate, DateTime endDate, string location, SqlOrder[] ordering, int pg)
        {
            string sql = "AssessmentSessionDetail WHERE 1=1 ";
            sql += " AND AssessmentSession_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            if (location.Length > 0)
            {
                sql += " AND AssessmentSession_Location LIKE @location ";
                com.Parameters.AddWithValue("@location", "%" + location + "%");
            }
            if (startDate.Year > 1900 && endDate.Year > 1900)
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND AssessmentSession_DateTime >= @startDate AND AssessmentSession_DateTime < @dt";
                com.Parameters.AddWithValue("@startDate", startDate);
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND AssessmentSession_DateTime >= @startDate";
                com.Parameters.AddWithValue("@startDate", startDate);
            }
            if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND AssessmentSession_DateTime < @dt";
                com.Parameters.AddWithValue("@dt", dt);
            }

            SqlOrder def = new SqlOrder(AssessmentSessionDetailTable.AssessmentSession_DateTimeColumnIndex, false);
            PagedDataList<AssessmentSessionDetailTable> lis = DA.GetPagedDataList<AssessmentSessionDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}
