using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
    partial class AssessmentSessionTable
    {
    }
    partial class AssessmentSessionRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class AssessmentSessionMinimalizedEntity
    {
    }
partial class AssessmentSessionAdapter {
        //public PagedDataList<AssessmentSessionTable> Search(DateTime startDate, DateTime endDate, string location, SqlOrder[] ordering, int pg)
        //{
        //    string sql = "AssessmentSession WHERE 1=1 ";
        //    sql += " AND AssessmentSession_IsDeleted = 0 ";
        //    SqlCommand com = new SqlCommand(sql);
        //    if (location.Length > 0)
        //    {
        //        sql += " AND AssessmentSession_Location LIKE @location ";
        //        com.Parameters.AddWithValue("@location", "%" + location + "%");
        //    }
        //    if (startDate.Year > 1900 && endDate.Year > 1900)
        //    {
        //        DateTime dt = endDate.AddDays(1);
        //        sql += " AND AssessmentSession_DateTime >= @startDate AND AssessmentSession_DateTime < @dt";
        //        com.Parameters.AddWithValue("@startDate", startDate);
        //        com.Parameters.AddWithValue("@dt", dt);
        //    }
        //    if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
        //    {
        //        DateTime dt = endDate.AddDays(1);
        //        sql += " AND AssessmentSession_DateTime >= @startDate";
        //        com.Parameters.AddWithValue("@startDate", startDate);
        //    }
        //    if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
        //    {
        //        DateTime dt = endDate.AddDays(1);
        //        sql += " AND AssessmentSession_DateTime < @dt";
        //        com.Parameters.AddWithValue("@dt", dt);
        //    }

        //    SqlOrder def = new SqlOrder(AssessmentSessionTable.AssessmentSession_DateTimeColumnIndex, false);
        //    PagedDataList<AssessmentSessionTable> lis = DA.GetPagedDataList<AssessmentSessionTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
        //    return lis;
        //}
    }
}
