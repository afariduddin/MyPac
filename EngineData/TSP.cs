using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class TSPTable
    {
    }
    partial class TSPRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class TSPMinimalizedEntity {
        public List<string> CheckedMonths = new List<string>();
        public List<string> SelectedMonth
        {
            get
            {
                List<string> l = new List<string>();
                if (this.TSP_IntakeJan)
                    l.Add("1");
                if (this.TSP_IntakeFeb)
                    l.Add("2");
                if (this.TSP_IntakeMar)
                    l.Add("3");
                if (this.TSP_IntakeApr)
                    l.Add("4");
                if (this.TSP_IntakeMay)
                    l.Add("5");
                if (this.TSP_IntakeJun)
                    l.Add("6");
                if (this.TSP_IntakeJul)
                    l.Add("7");
                if (this.TSP_IntakeAug)
                    l.Add("8");
                if (this.TSP_IntakeSep)
                    l.Add("9");
                if (this.TSP_IntakeOct)
                    l.Add("10");
                if (this.TSP_IntakeNov)
                    l.Add("11");
                if (this.TSP_IntakeDec)
                    l.Add("12");

                return l;
            }
            set
            {
                this.TSP_IntakeJan = value.Contains("1");
                this.TSP_IntakeFeb = value.Contains("2");
                this.TSP_IntakeMar = value.Contains("3");
                this.TSP_IntakeApr = value.Contains("4");
                this.TSP_IntakeMay = value.Contains("5");
                this.TSP_IntakeJun = value.Contains("6");
                this.TSP_IntakeJul = value.Contains("7");
                this.TSP_IntakeAug = value.Contains("8");
                this.TSP_IntakeSep = value.Contains("9");
                this.TSP_IntakeOct = value.Contains("10");
                this.TSP_IntakeNov = value.Contains("11");
                this.TSP_IntakeDec = value.Contains("12");
            }
        }
    }
    partial class TSPAdapter
    {
        public PagedDataList<TSPTable> Search(string keyword, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(TSPTable.TSP_CreatedDateColumnIndex);

            string sql = "TSP WHERE (TSP_CampusName LIKE @keyword) ";
            sql += " And TSP_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            PagedDataList<TSPTable> lis = DA.GetPagedDataList<TSPTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
        
        public TSPRow GetByName(string CampusName)
        {
            string sql = "SELECT * FROM TSP WHERE TSP_IsDeleted = 0 And TSP_CampusName = @CampusName";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CampusName", CampusName);
            TSPTable tbl = new TSPTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (TSPRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public List<TSPRow> GetAll()
        {
            List<TSPRow> list = new List<TSPRow>();
            string sql = "SELECT * FROM TSP WHERE TSP_IsDeleted = 0 ORDER BY TSP_CampusName asc";
            SqlCommand com = new SqlCommand(sql);
            TSPTable tbl = new TSPTable();
            DA.ExecuteQuery(com, tbl);
            foreach (TSPRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
        }
    }
}