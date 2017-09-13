using System.Data.SqlClient;
using Teq.Data;
using System;
namespace EngineData
{
    partial class PartTimerAssessmentResultDetailTable
    {
    }
    partial class PartTimerAssessmentResultDetailRow
    {
    }
    public partial class PartTimerAssessmentResultDetailMinimalizedEntity {

        public void CopyTo(PartTimerAssessmentResultRow dr)
        {
            dr.PartTimerAssessmentResult_ID = this.PartTimerAssessmentResult_ID;
            dr.Application_ID = this.Application_ID;
            dr.PartTimerAssessmentResult_Assessment1 = this.PartTimerAssessmentResult_Assessment1;
            dr.PartTimerAssessmentResult_Assessment2 = this.PartTimerAssessmentResult_Assessment2;
            dr.PartTimerAssessmentResult_Assessment3 = this.PartTimerAssessmentResult_Assessment3;
            dr.PartTimerAssessmentResult_Attendance = this.PartTimerAssessmentResult_Attendance;
            dr.PartTimerAssessmentResult_Status = this.PartTimerAssessmentResult_Status;
            dr.PartTimerAssessmentResult_CreatedDate = this.PartTimerAssessmentResult_CreatedDate;
            dr.PartTimerAssessmentResult_CreatedBy = this.PartTimerAssessmentResult_CreatedBy;
            dr.PartTimerAssessmentResult_UpdatedBy = this.PartTimerAssessmentResult_UpdatedBy;
            dr.PartTimerAssessmentResult_UpdatedDate = this.PartTimerAssessmentResult_UpdatedDate;
            dr.PartTimerAssessmentResult_IsDeleted = this.PartTimerAssessmentResult_IsDeleted;
            dr.PartTimerAssessmentResult_Remark = this.PartTimerAssessmentResult_Remark;
            dr.PartTimerAssessmentResult_InterviewResult = this.PartTimerAssessmentResult_InterviewResult;
            dr.PartTimerAssessmentResult_InterviewLocation = this.PartTimerAssessmentResult_InterviewLocation;
        }
    }
    partial class PartTimerAssessmentResultDetailAdapter
    {
        public PagedDataList<PartTimerAssessmentResultDetailTable> Search(string FullName, int Gender, string Email, string IC, string State, float Score, Guid Location, DateTime AssessmentDateFrom, DateTime AssessmentDateTo, int ContractType, int SubjectType, int Status, string sponsorIDs, DateTime EnrollmentDateFrom, DateTime EnrollmentDateTo, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(PartTimerAssessmentResultDetailTable.PartTimerAssessmentResult_CreatedDateColumnIndex);

            string sql = "";

            sql += "PartTimerAssessmentResultDetail WHERE 1 = 1";

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

            if (Location.CompareTo(Guid.Empty) != 0)
                sql += " AND TSP_ID = @Location";

            if (SubjectType != -1)
            {
                if (SubjectType == (int)EngineVariable.PartTimerAssessmentSubjectType.Assessment1)
                    sql += " AND PartTimerAssessmentResult_Assessment1 >= @Score";
                else if (SubjectType == (int)EngineVariable.PartTimerAssessmentSubjectType.Assessment2)
                    sql += " AND PartTimerAssessmentResult_Assessment2 >= @Score";
                else if (SubjectType == (int)EngineVariable.PartTimerAssessmentSubjectType.Assessment3)
                    sql += " AND PartTimerAssessmentResult_Assessment3 >= @Score";
            }

            if (AssessmentDateFrom > DateTime.MinValue)
            {
                AssessmentDateFrom = new DateTime(AssessmentDateFrom.Year, AssessmentDateFrom.Month, AssessmentDateFrom.Day, 0, 0, 0);
                sql += " AND PartTimerAssessmentResult_CreatedDate >= @AssessmentDateFrom";
            }

            if (AssessmentDateTo > DateTime.MinValue)
            {
                AssessmentDateTo = new DateTime(AssessmentDateTo.Year, AssessmentDateTo.Month, AssessmentDateTo.Day, 23, 59, 59);
                sql += " AND PartTimerAssessmentResult_CreatedDate <= @AssessmentDateTo";
            }
            if (EnrollmentDateFrom > DateTime.MinValue)
            {
                EnrollmentDateFrom = new DateTime(EnrollmentDateFrom.Year, EnrollmentDateFrom.Month, EnrollmentDateFrom.Day, 0, 0, 0);
                sql += " AND AssessmentResult_ExpectedEnrollmentDate >= @EnrollmentDateFrom";
            }

            if (EnrollmentDateTo > DateTime.MinValue)
            {
                EnrollmentDateTo = new DateTime(EnrollmentDateTo.Year, EnrollmentDateTo.Month, EnrollmentDateTo.Day, 23, 59, 59);
                sql += " AND AssessmentResult_ExpectedEnrollmentDate <= @EnrollmentDateTo";
            }


            if (ContractType != -1)
                sql += " AND Application_ContractType = @ContractType";
            if (Status != -1)
                sql += " AND PartTimerAssessmentResult_Status = @Status";
            if (sponsorIDs != "")
                sql += " and CHARINDEX(',' + cast(Sponsor_ID as char(36)) + ',', ',' + @SPONSORID + ',' ) > 0 ";

            SqlCommand com = new SqlCommand(sql);

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
            if (Location.CompareTo(Guid.Empty) != 0)
                com.Parameters.AddWithValue("@Location", Location);
            if (SubjectType != -1)
                com.Parameters.AddWithValue("@Score", Score);
            if (AssessmentDateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@AssessmentDateFrom", AssessmentDateFrom);
            if (AssessmentDateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@AssessmentDateTo", AssessmentDateTo);
            if (ContractType != -1)
                com.Parameters.AddWithValue("@ContractType", ContractType);
            if (Status != -1)
                com.Parameters.AddWithValue("@Status", Status);
            if (sponsorIDs != "")
                com.Parameters.AddWithValue("SPONSORID", sponsorIDs);
            if (EnrollmentDateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@EnrollmentDateFrom", EnrollmentDateFrom);
            if (EnrollmentDateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@EnrollmentDateTo", EnrollmentDateTo);

            PagedDataList<PartTimerAssessmentResultDetailTable> lis = DA.GetPagedDataList<PartTimerAssessmentResultDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public PartTimerAssessmentResultDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM PartTimerAssessmentResultDetail WHERE PartTimerAssessmentResult_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            PartTimerAssessmentResultDetailTable tbl = new PartTimerAssessmentResultDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (PartTimerAssessmentResultDetailRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }
    }
}
