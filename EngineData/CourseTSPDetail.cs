using System;
using System.Data.SqlClient;

namespace EngineData
{
    partial class CourseTSPDetailTable
    {
    }
    partial class CourseTSPDetailRow
    {
    }
    public partial class CourseTSPDetailMinimalizedEntity { }
    partial class CourseTSPDetailAdapter
    {
        public CourseTSPDetailTable GetBy(System.Guid Course_ID)
        {
            string sql = "SELECT * FROM CourseTSPDetail WHERE Course_ID = @Course_ID and TSP_IsDeleted = 0 ORDER BY TSP_CampusName asc";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("Course_ID", Course_ID);
            CourseTSPDetailTable tbl = new CourseTSPDetailTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}
