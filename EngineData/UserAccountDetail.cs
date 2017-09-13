using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class UserAccountDetailTable
    {
    }
    partial class UserAccountDetailRow
    {
    }
    public partial class UserAccountDetailMinimalizedEntity
    {
        public void CopyTo(UserAccountRow dr)
        {
            dr.UserAccount_ID = this.UserAccount_ID;
            dr.UserAccount_UserID = this.UserAccount_UserID;
            //dr.UserAccount_Password = this.UserAccount_Password;
            dr.UserAccount_FullName = this.UserAccount_FullName;
            dr.UserAccount_Email = this.UserAccount_Email;
            dr.UserAccount_Contact = this.UserAccount_Contact;
            dr.UserGroup_ID = this.UserGroup_ID;
            dr.UserAccount_IsEnabled = this.UserAccount_IsEnabled;
            dr.UserAccount_IsDeleted = this.UserAccount_IsDeleted;
            dr.UserAccount_Remark = this.UserAccount_Remark;
            dr.UserAccount_CreatedDate = this.UserAccount_CreatedDate;
            dr.UserAccount_CreatedBy = this.UserAccount_CreatedBy;
            dr.UserAccount_UpdatedDate = this.UserAccount_UpdatedDate;
            dr.UserAccount_UpdatedBy = this.UserAccount_UpdatedBy;
        }
    }
    partial class UserAccountDetailAdapter
    {
        public PagedDataList<UserAccountDetailTable> Search(string name, string userid, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(UserAccountTable.UserAccount_CreatedDateColumnIndex);

            string sql = "UserAccountDetail WHERE (UserAccount_FullName LIKE @name and UserAccount_UserID LIKE @userid) ";
            sql += " And UserAccount_IsDeleted = 0 And UserGroup_IsDeleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@name", "%" + name + "%");
            com.Parameters.AddWithValue("@userid", "%" + userid + "%");
            com.CommandText = sql;
            PagedDataList<UserAccountDetailTable> lis = DA.GetPagedDataList<UserAccountDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);

            return lis;
        }

        public UserAccountDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM UserAccountDetail WHERE UserAccount_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            UserAccountDetailTable tbl = new UserAccountDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetUserAccountDetailRow(0);
            }
            else
            {
                return null;
            }
        }
    }
}
