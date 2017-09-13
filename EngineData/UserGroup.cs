using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class UserGroupTable
    {
    }
    partial class UserGroupRow
    {
        public void OverrideDefaultValues()
        {
            //UserGroup_ID = Guid.NewGuid();
        }
    }
    public partial class UserGroupMinimalizedEntity {
        //public string Name = "";
        //public string Remark = "";

    }
    partial class UserGroupAdapter
    {

        public List<UserGroupRow> GetAll()
        {
            List<UserGroupRow> list = new List<UserGroupRow>();
            string sql = "SELECT * FROM UserGroup WHERE UserGroup_IsDeleted = 0 order by UserGroup_Name asc";
            SqlCommand com = new SqlCommand(sql);
            UserGroupTable tbl = new UserGroupTable();
            DA.ExecuteQuery(com, tbl);
            foreach(UserGroupRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
            //if (tbl.Rows.Count > 0)
            //{
            //    return tbl.GetUserAccountRow(0);
            //}
            //else
            //{
            //    return null;
            //}
        }

        public PagedDataList<UserGroupTable> Search(string keyword, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(UserGroupTable.UserGroup_CreatedDateColumnIndex);

            string sql = "UserGroup WHERE (UserGroup_Name LIKE @keyword OR UserGroup_Remark LIKE @keyword) ";
            sql += " And UserGroup_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
          
            PagedDataList<UserGroupTable> lis = DA.GetPagedDataList<UserGroupTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}
