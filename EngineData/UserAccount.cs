using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class UserAccountTable
    {
    }
    partial class UserAccountRow
    {
        public void OverrideDefaultValues()
        {
            UserGroup_ID = Guid.NewGuid();
        }
    }
    public partial class UserAccountMinimalizedEntity { }
    partial class UserAccountAdapter
    {

        public UserAccountRow GetByUserID(string userid)
        {
            string sql = "SELECT * FROM UserAccount WHERE UserAccount_IsDeleted = 0 And UserAccount_UserID = @userid";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@userid", userid);
            UserAccountTable tbl = new UserAccountTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetUserAccountRow(0);
            }
            else
            {
                return null;
            }
        }

        public PagedDataList<UserAccountTable> Search(string name, string userid, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(UserAccountTable.UserAccount_CreatedDateColumnIndex);

            string sql = "UserAccount WHERE (UserAccount_FullName LIKE @name OR UserAccount_UserID LIKE @userid) ";
            sql += " And UserAccount_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@name", "%" + name + "%");
            com.Parameters.AddWithValue("@userid", "%" + userid + "%");
            PagedDataList<UserAccountTable> lis = DA.GetPagedDataList<UserAccountTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public UserAccountRow Get(Guid ID)
        {
            string sql = "SELECT * FROM UserAccount WHERE UserAccount_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            UserAccountTable tbl = new UserAccountTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetUserAccountRow(0);
            }
            else
            {
                return null;
            }
        }

        public UserAccountTable GetByActiveUserGroup_ID(System.Guid UserGroup_ID)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [UserAccount] WHERE [UserGroup_ID] = @UserGroup_ID AND UserAccount_IsDeleted = @UserAccount_IsDeleted";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("UserGroup_ID", UserGroup_ID);
            fcom.Parameters.AddWithValue("UserAccount_IsDeleted", false);
            UserAccountTable tbl = new UserAccountTable();
            DA.ExecuteQuery(fcom, tbl);
            return tbl;
        }

        public UserAccountTable GetAll()
        {
            string sql = "SELECT * FROM UserAccount WHERE UserAccount_IsDeleted = 0 order by UserAccount_FullName";
            SqlCommand com = new SqlCommand(sql);
            UserAccountTable tbl = new UserAccountTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}
