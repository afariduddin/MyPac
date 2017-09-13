using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class ActivityLogTable
    {
    }
    partial class ActivityLogRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class ActivityLogMinimalizedEntity { }
    partial class ActivityLogAdapter
    {
        public PagedDataList<ActivityLogTable> Search(DateTime? startDate, DateTime? endDate, string Username, SqlOrder[] ordering, int pg)
        {
            string sql = " ActivityLog WHERE 1 = 1 ";

            SqlCommand com = new SqlCommand(sql);

            if (startDate.HasValue)
            {
                sql += " AND (ActivityLog_DateTime >= @startDate)";
                com.Parameters.AddWithValue("startDate", startDate.Value);
            }
            if (endDate.HasValue)
            {
                sql += " AND (ActivityLog_DateTime <= @endDate)";
                com.Parameters.AddWithValue("endDate", endDate.Value);
            }
            if (Username.Length > 0)
            {
                sql += " AND ActivityLog_UserName LIKE @Username ";
                com.Parameters.AddWithValue("@Username", "%" + Username + "%");
            }

            SqlOrder def = new SqlOrder(ActivityLogTable.ActivityLog_DateTimeColumnIndex, false);
            PagedDataList<ActivityLogTable> lis = DA.GetPagedDataList<ActivityLogTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}