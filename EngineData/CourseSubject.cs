using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class CourseSubjectTable {
}
partial class CourseSubjectRow {
public void OverrideDefaultValues() {
}
}
public partial class CourseSubjectMinimalizedEntity {}
partial class CourseSubjectAdapter {
        //public List<CourseSubjectRow> GetCourseSubjectDetail()
        //{
        //    List<CourseSubjectRow> list = new List<CourseSubjectRow>();
        //    //string sql = "SELECT * FROM CourseSubject WHERE Course_ID = @CourseID ORDER BY CourseSubject_Code asc ";
        //    string sql = "SELECT * FROM CourseSubject ORDER BY CourseSubject_Code asc ";
        //    SqlCommand com = new SqlCommand(sql);
        //    //com.Parameters.AddWithValue("@CourseID", CourseID);

        //    CourseSubjectTable tbl = new CourseSubjectTable();
        //    DA.ExecuteQuery(com, tbl);
        //    foreach (CourseSubjectRow r in tbl.Rows)
        //    {
        //        list.Add(r);
        //    }
        //    return list;
        //}
        public CourseSubjectTable GetAll(Guid CourseID)
        {
            string sql = "SELECT * FROM CourseSubject WHERE Course_ID = @CourseID ORDER BY CourseSubject_Code asc ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CourseID", CourseID);

            CourseSubjectTable tbl = new CourseSubjectTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public CourseSubjectRow GetBy_Code(Guid CourseID, string Code)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [CourseSubject] WHERE  Course_ID = @CourseID And [CourseSubject_Code] = @CourseSubject_Code";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@CourseID", CourseID);
            fcom.Parameters.AddWithValue("CourseSubject_Code", Code);
            CourseSubjectTable tbl = new CourseSubjectTable();
            DA.ExecuteQuery(fcom, tbl);
            if (tbl.Rows.Count > 0)
                return (CourseSubjectRow)tbl.Rows[0];
            else
                return null;
        }
        public CourseSubjectRow GetBy_Code(string Code)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [CourseSubject] WHERE [CourseSubject_Code] = @CourseSubject_Code";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("CourseSubject_Code", Code);
            CourseSubjectTable tbl = new CourseSubjectTable();
            DA.ExecuteQuery(fcom, tbl);
            if (tbl.Rows.Count > 0)
                return (CourseSubjectRow)tbl.Rows[0];
            else
                return null;
        }
        public CourseSubjectTable GetBy(System.Guid Course_ID)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [CourseSubject] WHERE [Course_ID] = @Course_ID order by CourseSubject_Code, CourseSubject_Name asc ";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("Course_ID", Course_ID);
            CourseSubjectTable tbl = new CourseSubjectTable();
            DA.ExecuteQuery(fcom, tbl);
            return tbl;
        }
    }
}
