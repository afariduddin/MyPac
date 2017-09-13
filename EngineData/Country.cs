using System;
using System.Data.SqlClient;

namespace EngineData
{
    partial class CountryTable
    {
    }
    partial class CountryRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class CountryMinimalizedEntity { }
    partial class CountryAdapter
    {
        public CountryTable GetAll()
        {
            string sql = "SELECT * FROM Country order by Country_Name asc ";
            SqlCommand com = new SqlCommand(sql);
            CountryTable tbl = new CountryTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public CountryRow Get(string Country_Name)
        {
            string sql = "SELECT * FROM [Country] WHERE Country_Name = @Country_Name";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Country_Name", Country_Name);

            CountryTable tbl = new CountryTable();
            DA.ExecuteQuery(com, tbl);

            if (tbl.Rows.Count > 0)
                return (CountryRow)tbl.Rows[0];
            else return null;
        }
    }
}
