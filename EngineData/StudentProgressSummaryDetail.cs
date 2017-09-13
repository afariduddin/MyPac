using System.Data.SqlClient;
using Teq.Data;
using System;
namespace EngineData
{
    partial class StudentProgressSummaryDetailTable
    {
    }
    partial class StudentProgressSummaryDetailRow
    {
    }
    public partial class StudentProgressSummaryDetailMinimalizedEntity {
        public void CopyTo(StudentRow dr)
        {
            dr.Student_Remark = Student_Remark;
            dr.Student_Status = Student_Status;
        }
    }
    partial class StudentProgressSummaryDetailAdapter
    {
        public PagedDataList<StudentProgressSummaryDetailTable> Search(string FullName, int Gender, string Email, string ContactNum, DateTime CreatedDateFrom, DateTime CreatedDateTo, int ContractType, int Status, string sponsorIDs, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo,string IC, string TSPIDs, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(StudentProgressSummaryDetailTable.Application_FullNameColumnIndex);

            string sql = "";

            sql += "StudentProgressSummaryDetail WHERE 1 = 1";

            if (FullName != "")
                sql += " AND Application_FullName LIKE @FullName";
            
            if (Gender != -1)
                sql += " AND Application_Gender = @Gender";

            if (Email != "")
                sql += " AND Application_Email LIKE @Email";

            if (ContactNum != "")
                sql += " AND (Application_PhoneNumber LIKE @ContactNum or Application_PhonePrefix like @ContactNum) ";



            if (CreatedDateFrom > DateTime.MinValue)
            {
                //DateFrom = new DateTime(DateFrom.Day, DateFrom.Month, DateFrom.Year, 0, 0, 0);
                CreatedDateFrom = new DateTime(CreatedDateFrom.Year, CreatedDateFrom.Month, CreatedDateFrom.Day , 0, 0, 0);
                sql += " AND Student_CreatedDate >= @CreatedDateFrom";
            }

            if (CreatedDateTo > DateTime.MinValue)
            {
                // DateTo = new DateTime(DateTo.Day, DateTo.Month, DateTo.Year, 23, 59, 59);
                CreatedDateTo = new DateTime(CreatedDateTo.Year, CreatedDateTo.Month, CreatedDateTo.Day, 23, 59, 59);
                sql += " AND Student_CreatedDate <= @CreatedDateTo";
            }

            if (EnrollmentDateFrom > DateTime.MinValue)
            {
                EnrollmentDateFrom = new DateTime(EnrollmentDateFrom.Year, EnrollmentDateFrom.Month, EnrollmentDateFrom.Day, 0, 0, 0);
                sql += " AND Student_EnrollmentDate >= @EnrollmentDateFrom";
            }

            if (EnrollmentDateTo > DateTime.MinValue)
            {
                EnrollmentDateTo = new DateTime(EnrollmentDateTo.Year, EnrollmentDateTo.Month, EnrollmentDateTo.Day, 23, 59, 59);
                sql += " AND Student_EnrollmentDate <= @EnrollmentDateTo";
            }

            if (ContractType != -1)
                sql += " AND Application_ContractType = @ContractType";
            if (Status != -1)
                sql += " AND Student_Status = @Status";
            //if (Sponsorship != -1)
            //    sql += " AND Application_Sponsor = @Sponsorship";
            if (sponsorIDs != "")
                sql += " and CHARINDEX(',' + cast(Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 ";

            if (TSPIDs != "")
                sql += " and CHARINDEX(',' + cast(TSP_ID as varchar(36)) + ',', ',' + @TSPIDs + ',' ) > 0 ";

            if (IC != "")
                sql += " AND Application_IdentificationNumber LIKE @IC";

            SqlCommand com = new SqlCommand(sql);

            if (FullName != "")
                com.Parameters.AddWithValue("@FullName", "%" + FullName + "%");
            if (Gender != -1)
                com.Parameters.AddWithValue("@Gender", Gender);
            if (Email != "")
                com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            if (ContactNum != "")
                com.Parameters.AddWithValue("@ContactNum", "%" + ContactNum + "%");

            if (CreatedDateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@CreatedDateFrom", CreatedDateFrom);
            if (CreatedDateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@CreatedDateTo", CreatedDateTo);
            if (ContractType != -1)
                com.Parameters.AddWithValue("@ContractType", ContractType);
            if (Status != -1)
                com.Parameters.AddWithValue("@Status", Status);
            //if (Sponsorship != -1)
            //    com.Parameters.AddWithValue("@Sponsorship", Sponsorship);
            if (sponsorIDs != "")
                com.Parameters.AddWithValue("@SPONSORID", sponsorIDs);
            if (TSPIDs != "")
                com.Parameters.AddWithValue("@TSPIDs", TSPIDs);
            if (EnrollmentDateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@EnrollmentDateFrom", EnrollmentDateFrom);
            if (EnrollmentDateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@EnrollmentDateTo", EnrollmentDateTo);

            if (IC != "")
                com.Parameters.AddWithValue("@IC", "%" + IC + "%");

            PagedDataList<StudentProgressSummaryDetailTable> lis = DA.GetPagedDataList<StudentProgressSummaryDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public StudentProgressSummaryDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM StudentProgressSummaryDetail WHERE Student_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            StudentProgressSummaryDetailTable tbl = new StudentProgressSummaryDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (StudentProgressSummaryDetailRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }
    }
}
