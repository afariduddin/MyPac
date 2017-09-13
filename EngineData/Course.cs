using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class CourseTable
    {
    }
    partial class CourseRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class CourseMinimalizedEntity { }
    partial class CourseAdapter
    {
        public CourseTable GetAll()
        {
            string sql = "SELECT * FROM Course WHERE Course_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            CourseTable tbl = new CourseTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public CourseRow GetBy_CourseCode(string Course_Code)
        {
            string sql = "SELECT [Course].* FROM [Course] WHERE [Course].Course_Code = @Course_Code AND [Course].Course_IsDeleted = 0";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Course_Code", Course_Code);
            CourseTable tbl = new CourseTable();
            DA.ExecuteQuery(com, tbl);

            return tbl.Rows.Count > 0 ? (CourseRow)tbl.Rows[0] : null;
        }
        public CourseTable Get_ActiveByTSP(Guid TSP_ID)
        {
            string sql = "SELECT DISTINCT [Course].* FROM [Course], [CourseTSP] WHERE [Course].Course_ID = [CourseTSP].Course_ID AND [Course].Course_IsDeleted = 0 AND [CourseTSP].TSP_ID = @TSP_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@TSP_ID", TSP_ID);
            CourseTable tbl = new CourseTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public PagedDataList<CourseTable> Search(string keyword, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(CourseTable.Course_CreatedDateColumnIndex);

            string sql = "Course WHERE (Course_Name LIKE @keyword) ";
            sql += " And Course_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            PagedDataList<CourseTable> lis = DA.GetPagedDataList<CourseTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
        //public List<CourseRow> GetCourseDetail()
        //{
        //    List<CourseRow> list = new List<CourseRow>();
        //    string sql = "SELECT * FROM Course WHERE Course_IsDeleted = 0 ORDER BY Course_Name asc ";
        //    SqlCommand com = new SqlCommand(sql);
        //    CourseTable tbl = new CourseTable();
        //    DA.ExecuteQuery(com, tbl);
        //    foreach (CourseRow r in tbl.Rows)
        //    {
        //        list.Add(r);
        //    }
        //    return list;
        //}
    }
}