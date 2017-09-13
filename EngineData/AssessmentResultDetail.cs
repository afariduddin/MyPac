using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class AssessmentResultDetailTable
    {
    }
    partial class AssessmentResultDetailRow
    {
    }
    public partial class AssessmentResultDetailMinimalizedEntity
    {
        public void CopyTo(AssessmentResultRow dr)
        {
            dr.AssessmentResult_ID = this.AssessmentResult_ID;
            dr.Application_ID = this.Application_ID;
            //dr.AssessmentResult_AbstractLogic = this.AssessmentResult_AbstractLogic;
            //dr.AssessmentResult_LogicalProcess = this.AssessmentResult_LogicalProcess;
            //dr.AssessmentResult_Numerical = this.AssessmentResult_Numerical;
            //dr.AssessmentResult_SpatialReasoning = this.AssessmentResult_SpatialReasoning;
            //dr.AssessmentResult_SocialContext = this.AssessmentResult_SocialContext;
            dr.AssessmentResult_TechnicalAssessment = this.AssessmentResult_TechnicalAssessment;
            dr.AssessmentResult_EnglishFoundation = this.AssessmentResult_EnglishFoundation;
            dr.AssessmentResult_EPTSummary = this.AssessmentResult_EPTSummary;
            dr.AssessmentResult_Interview = this.AssessmentResult_Interview;
            dr.AssessmentResult_Listening = this.AssessmentResult_Listening;
            dr.AssessmentResult_Writing = this.AssessmentResult_Writing;
            dr.AssessmentResult_Speaking = this.AssessmentResult_Speaking;
            dr.AssessmentResult_Reading = this.AssessmentResult_Reading;
            dr.AssessmentResult_Status = this.AssessmentResult_Status;
            //dr.AssessmentResult_Sponsor = this.AssessmentResult_Sponsor;
            dr.AssessmentResult_CreatedBy = this.AssessmentResult_CreatedBy;
            dr.AssessmentResult_CreatedDate = this.AssessmentResult_CreatedDate;
            dr.AssessmentResult_UpdatedBy = this.AssessmentResult_UpdatedBy;
            dr.AssessmentResult_UpdatedDate = this.AssessmentResult_UpdatedDate;
            dr.AssessmentResult_TotalScore = this.AssessmentResult_TotalScore;
            dr.AssessmentResult_AverageScore = this.AssessmentResult_AverageScore;
            dr.AssessmentResult_Date = this.AssessmentResult_Date;
        }
    }
    partial class AssessmentResultDetailAdapter
    {
        public PagedDataList<AssessmentResultDetailTable> Search(string FullName, int Gender, string Email, string IC, string State, float Score, Guid Location, DateTime DateFrom, DateTime DateTo, int ContractType, int ExamType, int Status, string sponsorIDs, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(AssessmentResultDetailTable.AssessmentResult_DateColumnIndex);

            string sql = "";
            
            sql += "AssessmentResultDetail WHERE 1 = 1";

            if (FullName != "")
                sql += " AND Application_FullName LIKE @FullName";
            
            if (Gender != -1)
                sql += " AND Application_Gender = @Gender";

            if (Email != "")
                sql += " AND Application_Email LIKE @Email";

            if (IC != "")
                sql += " AND Application_IdentificationNumber LIKE @IC";

            if (State != "")
                sql += " AND Application_State LIKE @State";

            if (Location.CompareTo(Guid.Empty) != 0)
                sql += " AND TSP_ID = @Location";

            if (ExamType != -1)
            {
                //if (ExamType == (int)EngineVariable.AssessmentSubjectType.AbstractLogic)
                //    sql += " AND AssessmentResult_AbstractLogic >= @Score";
                //else if (ExamType == (int)EngineVariable.AssessmentSubjectType.LogicalProcess)
                //    sql += " AND AssessmentResult_LogicalProcess >= @Score";
                //else if (ExamType == (int)EngineVariable.AssessmentSubjectType.Numerical)
                //    sql += " AND AssessmentResult_Numerical >= @Score";
                //else if (ExamType == (int)EngineVariable.AssessmentSubjectType.SocialContext)
                //    sql += " AND AssessmentResult_SocialContext >= @Score";
                //else if (ExamType == (int)EngineVariable.AssessmentSubjectType.SpatialReasoning)
                //    sql += " AND AssessmentResult_SpatialReasoning >= @Score";
                if (ExamType == (int)EngineVariable.AssessmentSubjectType.TechnicalAssessment)
                    sql += " AND AssessmentResult_TechnicalAssessment >= @Score";
                else if (ExamType == (int)EngineVariable.AssessmentSubjectType.EnglishFoundation)
                    sql += " AND AssessmentResult_EnglishFoundation >= @Score";
                else if (ExamType == (int)EngineVariable.AssessmentSubjectType.Listening)
                    sql += " AND AssessmentResult_Listening >= @Score";
                else if (ExamType == (int)EngineVariable.AssessmentSubjectType.Writing)
                    sql += " AND AssessmentResult_Writing >= @Score";
                else if (ExamType == (int)EngineVariable.AssessmentSubjectType.Speaking)
                    sql += " AND AssessmentResult_Speaking >= @Score";
                else if (ExamType == (int)EngineVariable.AssessmentSubjectType.Reading)
                    sql += " AND AssessmentResult_Reading >= @Score";
            }
            
            if (DateFrom > DateTime.MinValue)
            {
                // DateFrom = new DateTime(DateFrom.Day, DateFrom.Month, DateFrom.Year, 0, 0, 0);
                DateFrom = new DateTime(DateFrom.Year, DateFrom.Month, DateFrom.Day, 0, 0, 0);
                sql += " AND AssessmentResult_Date >= @DateFrom";
            }

            if (DateTo > DateTime.MinValue)
            {
                //DateTo = new DateTime(DateTo.Day, DateTo.Month, DateTo.Year, 23, 59, 59);
                DateTo = new DateTime(DateTo.Year, DateTo.Month, DateTo.Day, 23, 59, 59);
                sql += " AND AssessmentResult_Date <= @DateTo";
            }

            if (ContractType != -1)
                sql += " AND Application_ContractType = @ContractType";
            if (Status != -1)
                sql += " AND AssessmentResult_Status = @Status";
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
            if (ExamType != -1)
                com.Parameters.AddWithValue("@Score", Score);
            if (DateFrom > DateTime.MinValue)
                com.Parameters.AddWithValue("@DateFrom", DateFrom);
            if (DateTo > DateTime.MinValue)
                com.Parameters.AddWithValue("@DateTo", DateTo);
            if (ContractType != -1)
                com.Parameters.AddWithValue("@ContractType", ContractType);
            if (Status != -1)
                com.Parameters.AddWithValue("@Status", Status);
            if (sponsorIDs != "" )
                com.Parameters.AddWithValue("SPONSORID", sponsorIDs);

            PagedDataList<AssessmentResultDetailTable> lis = DA.GetPagedDataList<AssessmentResultDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public AssessmentResultDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM AssessmentResultDetail WHERE AssessmentResult_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            AssessmentResultDetailTable tbl = new AssessmentResultDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (AssessmentResultDetailRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }
    }
}