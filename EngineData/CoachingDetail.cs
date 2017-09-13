using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class CoachingDetailTable
    {
    }
    partial class CoachingDetailRow
    {
    }
    public partial class CoachingDetailMinimalizedEntity
    {
        public void CopyTo(CoachingRow dr)
        {
            dr.Coaching_ID = this.Coaching_ID;
            dr.Coaching_Description = this.Coaching_Description;
            dr.StudentCourse_ID = this.StudentCourse_ID;
            dr.Coaching_Remark = this.Coaching_Remark;
            dr.Coaching_Date = this.Coaching_Date;
            dr.Coaching_IsDeleted = this.Coaching_IsDeleted;
            dr.Coaching_Status = this.Coaching_Status;
            dr.Coaching_CreatedDate = this.Coaching_CreatedDate;
            dr.Coaching_CreatedBy = this.Coaching_CreatedBy;
            dr.Coaching_UpdatedDate = this.Coaching_UpdatedDate;
            dr.Coaching_UpdatedBy = this.Coaching_UpdatedBy;
            dr.UserAccount_ID = this.UserAccount_ID;
        }
    }
    partial class CoachingDetailAdapter
    {
        public PagedDataList<CoachingDetailTable> Search(Guid UserAccount_ID, string FullName, int Gender, string Email, string IC, string State, DateTime DateFrom, DateTime DateTo, int ContractType, int Status, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(CoachingDetailTable.Coaching_CreatedDateColumnIndex);

            string sql = "";

            sql += "CoachingDetail WHERE 1 = 1";

            if (FullName != "")
                sql += " AND Application_FullName LIKE @FullName";
            
            if (Gender != -1)
                sql += " AND Application_Gender = @Gender";

            if (Email != "")
                sql += " AND Application_Email LIKE @SearchEmail";

            if (IC != "")
                sql += " AND Application_IdentificationNumber LIKE @IC";

            if (State != "")
                sql += " AND Application_State LIKE @State";
            
            if (DateFrom > DateTime.MinValue)
            {
                DateFrom = new DateTime(DateFrom.Day, DateFrom.Month, DateFrom.Year, 0, 0, 0);
                sql += " AND Coaching_Date >= @DateFrom";
            }

            if (DateTo > DateTime.MinValue)
            {
                DateTo = new DateTime(DateTo.Day, DateTo.Month, DateTo.Year, 23, 59, 59);
                sql += " AND Coaching_Date <= @DateTo";
            }

            if (ContractType != -1)
                sql += " AND Application_ContractType = @ContractType";

            if (Status != -1)
                sql += " AND Coaching_Status = @Status";

            if (UserAccount_ID.CompareTo(Guid.Empty) != 0)
                sql += " AND UserAccount_ID = @UserAccount_ID";


            SqlCommand com = new SqlCommand(sql);
            if (UserAccount_ID.CompareTo(Guid.Empty) != 0)
            {
                com.Parameters.AddWithValue("@UserAccount_ID", UserAccount_ID);
            }
            if (FullName != "")
                com.Parameters.AddWithValue("@FullName", "%" + FullName + "%");
            if (Gender != -1)
                com.Parameters.AddWithValue("@Gender", Gender);
            if (Email != "")
                com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            if (IC != "")
                com.Parameters.AddWithValue("@IC", "%" + IC + "%");
            if (State != "")
                com.Parameters.AddWithValue("@State", "%" + State + "%");
            if (DateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@DateFrom", DateFrom);
            if (DateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@DateTo", DateTo);
            if (ContractType != -1)
                com.Parameters.AddWithValue("@ContractType", ContractType);
            if (Status != -1)
                com.Parameters.AddWithValue("@Status", Status);

            PagedDataList<CoachingDetailTable> lis = DA.GetPagedDataList<CoachingDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public PagedDataList<CoachingDetailTable> Search(Guid ApplicationID, int Status, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(CoachingDetailTable.Coaching_CreatedDateColumnIndex);

            string sql = "";

            sql += "CoachingDetail WHERE 1 = 1";
            sql += " AND Application_ID = @Application_ID";

            if (Status != -1)
                sql += " AND Coaching_Status = @Status";

            SqlCommand com = new SqlCommand(sql);
            
            com.Parameters.AddWithValue("@Application_ID", ApplicationID);
            if (Status != -1)
                com.Parameters.AddWithValue("@Status", Status);

            PagedDataList<CoachingDetailTable> lis = DA.GetPagedDataList<CoachingDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public CoachingDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM CoachingDetail WHERE Coaching_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            CoachingDetailTable tbl = new CoachingDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (CoachingDetailRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }
    }
}