using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class WorkHistoryDetailTable {
}
partial class WorkHistoryDetailRow {
}
public partial class WorkHistoryDetailMinimalizedEntity
    {
        public void CopyTo(WorkHistoryRow dr)
        {
            dr.WorkHistory_ID = this.WorkHistory_ID;
            dr.Application_ID = this.Application_ID;
            dr.WorkHistory_CompanyName = this.WorkHistory_CompanyName;
            dr.WorkHistory_JobTitle = this.WorkHistory_JobTitle;
            dr.WorkHistory_StartDate = this.WorkHistory_StartDate;
            dr.WorkHistory_ResignDate = this.WorkHistory_ResignDate;
            dr.WorkHistory_Description = this.WorkHistory_Description;
            dr.WorkHistory_CreatedBy = this.WorkHistory_CreatedBy;
            dr.WorkHistory_CreatedDate = this.WorkHistory_CreatedDate;
            dr.WorkHistory_UpdatedBy = this.WorkHistory_UpdatedBy;
            dr.WorkHistory_UpdatedDate = this.WorkHistory_UpdatedDate;
            dr.WorkHistory_IsDeleted = this.WorkHistory_IsDeleted;
        }
    }
 
partial class WorkHistoryDetailAdapter {
        //for Candidate Work History
        public PagedDataList<WorkHistoryDetailTable> Search(Guid CandidateID, string CompanyName, string JobTitle, DateTime startDate, DateTime endDate, SqlOrder[] ordering, int pg)
        {
            string sql = sql = " WorkHistoryDetail WHERE 1 = 1 AND WorkHistory_IsDeleted = 0 AND Application_Deleted = 0 AND Application_OverallStatus = 3 AND Candidate_ID = @CandidateID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CandidateID", CandidateID);

            if (startDate.Year > 1900 && endDate.Year > 1900)
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND WorkHistory_StartDate >= @startDate AND WorkHistory_ResignDate < @dt";
                com.Parameters.AddWithValue("@startDate", startDate);
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            {
                sql += " AND WorkHistory_StartDate >= @startDate";
                com.Parameters.AddWithValue("@startDate", startDate);
            }
            if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND WorkHistory_ResignDate < @dt";
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (CompanyName.Length > 0)
            {
                sql += " AND WorkHistory_CompanyName LIKE @CompanyName ";
                com.Parameters.AddWithValue("@CompanyName", "%" + CompanyName + "%");
            }
            if (JobTitle.Length > 0)
            {
                sql += " AND WorkHistory_JobTitle LIKE @JobTitle ";
                com.Parameters.AddWithValue("@JobTitle", "%" + JobTitle + "%");
            }

            SqlOrder def = new SqlOrder(WorkHistoryDetailTable.WorkHistory_StartDateColumnIndex, false);
            PagedDataList<WorkHistoryDetailTable> lis = DA.GetPagedDataList<WorkHistoryDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        //for Candidate Work History
        public WorkHistoryDetailRow GetBy(System.Guid Candidate_ID)
        {
            string sql = "SELECT * FROM Application WHERE Application_Deleted = 0 AND Candidate_ID = @Candidate_ID AND Application_OverallStatus='3'";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
            WorkHistoryDetailTable tbl = new WorkHistoryDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetWorkHistoryDetailRow(0);
            }
            else
            {
                return null;
            }
        }

        public PagedDataList<WorkHistoryDetailTable> Search(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState, SqlOrder[] ordering, int pg)
        {
            string sql = sql = " WorkHistoryDetail WHERE 1 = 1 AND WorkHistory_IsDeleted = 0 AND Application_Deleted = 0 AND Application_OverallStatus = 3";
            SqlCommand com = new SqlCommand(sql);

            if (SearchFullName != "")
            {
                sql += " AND Application_FullName LIKE @SearchFullName";
                com.Parameters.AddWithValue("@SearchFullName", SearchFullName);
            }
            if (SearchGender != -1)
            {
                sql += " AND Application_Gender LIKE @SearchGender";
                com.Parameters.AddWithValue("@SearchGender", SearchGender);
            }
            if (SearchEmail != "")
            {
                sql += " AND Application_Email LIKE @SearchEmail";
                com.Parameters.AddWithValue("@SearchEmail", SearchEmail);
            }
            if (SearchICNumber != "")
            {
                sql += " AND Application_IdentificationNumber LIKE @SearchICNumber";
                com.Parameters.AddWithValue("@SearchICNumber", SearchICNumber);
            }
            if (SearchState != "")
            {
                sql += " AND Application_State LIKE @SearchState";
                com.Parameters.AddWithValue("@SearchState", SearchState);
            }

            SqlOrder def = new SqlOrder(WorkHistoryDetailTable.Application_FullNameColumnIndex, false);
            PagedDataList<WorkHistoryDetailTable> lis = DA.GetPagedDataList<WorkHistoryDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
        
        public WorkHistoryDetailRow Get(Guid WorkHistory_ID)
        {
            string sql = "SELECT * FROM WorkHistoryDetail WHERE WorkHistory_ID = @WorkHistory_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("WorkHistory_ID", WorkHistory_ID);
            WorkHistoryDetailTable tbl = new WorkHistoryDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetWorkHistoryDetailRow(0);
            }
            else
            {
                return null;
            }
        }
    }
}
