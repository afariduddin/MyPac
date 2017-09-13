using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class PartTimerAssessmentSessionDetailTable
    {
    }
    partial class PartTimerAssessmentSessionDetailRow
    {
    }
    public partial class PartTimerAssessmentSessionDetailMinimalizedEntity { }
    partial class PartTimerAssessmentSessionDetailAdapter
    {
        public PartTimerAssessmentSessionDetailTable Get(DateTime startDate /*, bool isInterview*/)
        {
            string sql = "SELECT * FROM PartTimerAssessmentSessionDetail WHERE 1 = 1";
            sql += " AND PartTimerAssessmentSession_IsDeleted = 0";
            sql += " AND PartTimerAssessmentSession_DateTime > @startDate";
            //sql += " AND PartTimerAssessmentSession_IsInterview = @isInterview";
            SqlCommand com = new SqlCommand(sql);

            com.Parameters.AddWithValue("@startDate", startDate.ToString(EngineVariable.LibraryVariable.Format_DateTime));
            //com.Parameters.AddWithValue("@isInterview", isInterview);

            PartTimerAssessmentSessionDetailTable dt = new PartTimerAssessmentSessionDetailTable();
            DA.ExecuteQuery(com, dt);

            return dt;
        }
        public PartTimerAssessmentSessionDetailRow Get(Guid PartTimerAssessmentSession_ID)
        {
            string sql = "SELECT * FROM PartTimerAssessmentSessionDetail WHERE 1 = 1";
            sql += " AND PartTimerAssessmentSession_IsDeleted = 0";
            sql += " AND PartTimerAssessmentSession_ID = @PartTimerAssessmentSession_ID";
            //sql += " AND PartTimerAssessmentSession_IsInterview = @isInterview";
            SqlCommand com = new SqlCommand(sql);

            com.Parameters.AddWithValue("@PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
            //com.Parameters.AddWithValue("@isInterview", isInterview);

            PartTimerAssessmentSessionDetailTable dt = new PartTimerAssessmentSessionDetailTable();
            DA.ExecuteQuery(com, dt);
            if(dt.Rows.Count > 0)
            {
                return dt.GetPartTimerAssessmentSessionDetailRow(0);
            }
            else

            {
                return null;
            }
        }
        public PagedDataList<PartTimerAssessmentSessionDetailTable> Search(DateTime startDate, DateTime endDate, string location, SqlOrder[] ordering, int pg)
        {
            string sql = "PartTimerAssessmentSessionDetail WHERE 1=1 ";
            sql += " AND PartTimerAssessmentSession_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            if (location.Length > 0)
            {
                sql += " AND PartTimerAssessmentSession_Location LIKE @location ";
                com.Parameters.AddWithValue("@location", "%" + location + "%");
            }
            if (startDate.Year > 1900 && endDate.Year > 1900)
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND PartTimerAssessmentSession_DateTime >= @startDate AND PartTimerAssessmentSession_DateTime < @dt";
                com.Parameters.AddWithValue("@startDate", startDate);
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND PartTimerAssessmentSession_DateTime >= @startDate";
                com.Parameters.AddWithValue("@startDate", startDate);
            }
            if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND PartTimerAssessmentSession_DateTime < @dt";
                com.Parameters.AddWithValue("@dt", dt);
            }

            SqlOrder def = new SqlOrder(PartTimerAssessmentSessionDetailTable.PartTimerAssessmentSession_DateTimeColumnIndex, false);
            PagedDataList<PartTimerAssessmentSessionDetailTable> lis = DA.GetPagedDataList<PartTimerAssessmentSessionDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}
