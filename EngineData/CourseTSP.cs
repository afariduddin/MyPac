using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class CourseTSPTable
    {
    }
    partial class CourseTSPRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class CourseTSPMinimalizedEntity { }
    partial class CourseTSPAdapter
    {

        public List<CourseTSPRow> GetByCourse(Guid CourseID)
        {
            List<CourseTSPRow> list = new List<CourseTSPRow>();
            string sql = "SELECT * FROM CourseTSP WHERE Course_ID  = @Course_ID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Course_ID", CourseID);

            CourseTSPTable tbl = new CourseTSPTable();
            DA.ExecuteQuery(com, tbl);
            foreach (CourseTSPRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
        }

        public void DeleteByCourse(Guid CourseID)
        {
            string sql = "DELETE FROM CourseTSP WHERE Course_ID = @Course_ID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Course_ID", CourseID);

            DA.ExecuteNonQuery(com);
        }
    }
}