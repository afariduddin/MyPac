using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class SponsorTable
    {
    }
    partial class SponsorRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class SponsorMinimalizedEntity
    {
    }
    partial class SponsorAdapter
    {
        public SponsorTable Get()
        {
            string sql = @"SELECT * FROM Sponsor WHERE Sponsor_IsDeleted = 0";
            SqlCommand com = new SqlCommand(sql);
            SponsorTable tbl = new SponsorTable();
            DA.ExecuteQuery(com, tbl);
            return tbl; ;
        }
        public SponsorRow Get(string Code)
        {
            string sql = @"SELECT * FROM Sponsor WHERE Sponsor_Code = @Code";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("Code", Code);
            SponsorTable tbl = new SponsorTable();
            DA.ExecuteQuery(com, tbl);
            return (tbl.Rows.Count > 0 ? (SponsorRow)tbl.Rows[0] : null);
        }
        public PagedDataList<SponsorTable> Search(string Sponsor_Code, string Sponsor_Label, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(CoachingDetailTable.Coaching_CreatedDateColumnIndex);

            string sql = "";

            sql += "Sponsor WHERE Sponsor_IsDeleted = 0";

            if (Sponsor_Code != "")
                sql += " AND Sponsor_Code = @Sponsor_Code";
            if (Sponsor_Label != "")
                sql += " AND Sponsor_Label = @Sponsor_Label";

            SqlCommand com = new SqlCommand(sql);

            if (Sponsor_Code != "")
                com.Parameters.AddWithValue("@Sponsor_Code", Sponsor_Code);
            if (Sponsor_Label != "")
                com.Parameters.AddWithValue("@Sponsor_Label", Sponsor_Label);

            PagedDataList<SponsorTable> lis = DA.GetPagedDataList<SponsorTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}