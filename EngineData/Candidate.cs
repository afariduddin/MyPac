using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class CandidateTable
    {
    }
    partial class CandidateRow
    {
        public void OverrideDefaultValues()
        {
        }
      
    }
    public partial class CandidateMinimalizedEntity { }
    partial class CandidateAdapter
    {
        public CandidateRow GetByIdentificationNumber(string ICNumber)
        {
            string sql = "SELECT * FROM Candidate WHERE Candidate_IsDeleted = 0 And Candidate_ICNumber = @ICNumber";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ICNumber", ICNumber);
            CandidateTable tbl = new CandidateTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetCandidateRow(0);
            }
            else
            {
                return null;
            }
        }
        public CandidateTable GetAll()
        {
            string sql = "SELECT * FROM Candidate";
            SqlCommand com = new SqlCommand(sql);
            CandidateTable tbl = new CandidateTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public CandidateRow GetByEmail(string Email)
        {
            string sql = "SELECT * FROM Candidate WHERE Candidate_IsDeleted = 0 And Candidate_Email = @Email";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Email", Email);
            CandidateTable tbl = new CandidateTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetCandidateRow(0);
            }
            else
            {
                return null;
            }
        }
        public CandidateRow GetByUserID(string userid)
        {
            string sql = "SELECT * FROM Candidate WHERE Candidate_IsDeleted = 0 And Candidate_UserID = @userid";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@userid", userid);
            CandidateTable tbl = new CandidateTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetCandidateRow(0);
            }
            else
            {
                return null;
            }
        }
        public CandidateRow GetByCandidateID(Guid Candidate_ID)
        {
            string sql = "SELECT * FROM Candidate WHERE Candidate_IsDeleted = 0 And Candidate_ID = @Candidate_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@Candidate_ID", Candidate_ID);
            CandidateTable tbl = new CandidateTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetCandidateRow(0);
            }
            else
            {
                return null;
            }
        }
        public PagedDataList<CandidateTable> Search(string SearchFullName, int SearchGender, string SearchEmail, string SearchICNumber, string SearchState, Guid SearchCourseID, int SearchCurrentlyEmployed, DateTime? RegisterDateFrom, DateTime? RegisterDateTo, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(CandidateTable.Candidate_CreatedDateColumnIndex);
            
            string sql = "";
            SqlCommand com = new SqlCommand(sql);

            if (SearchCourseID != Guid.Empty)
                sql += "(SELECT Candidate.* FROM Candidate, CandidatePreferredCourse WHERE Candidate_IsDeleted = 0 ";
            else
                sql += "Candidate WHERE Candidate_IsDeleted = 0";

            if (SearchFullName != "")
                sql += " AND Candidate_FullName LIKE @SearchFullName";
            
            if (SearchGender != -1)
                sql += " AND Candidate_Gender = @SearchGender";

            if (SearchEmail != "")
                sql += " AND Candidate_Email LIKE @SearchEmail";

            if (SearchICNumber != "")
                sql += " AND Candidate_ICNumber LIKE @SearchICNumber";

            if (SearchState != "")
                sql += " AND Candidate_State LIKE @SearchState";

            if (SearchCourseID != Guid.Empty)
            { 
                sql += " AND Candidate.Candidate_ID = CandidatePreferredCourse.Candidate_ID";
                sql += " AND CandidatePreferredCourse.Course_ID = @SearchCourseID";
            }

            bool Employed = false;
            if (SearchCurrentlyEmployed != -1)
            {
                if ((int)EngineVariable.YesNoType.Yes == SearchCurrentlyEmployed)
                    Employed = true;
                else
                    Employed = false;

                sql += " AND Candidate_CurrentlyEmployed = @Employed";
            }

            //if (RegisterDateFrom > DateTime.MinValue)
            //{
            //    RegisterDateFrom = new DateTime(RegisterDateFrom.Day, RegisterDateFrom.Month, RegisterDateFrom.Year, 0, 0, 0);
            //    sql += " AND Candidate_CreatedDate >= @RegisterDateFrom";
            //}

            //if (RegisterDateTo > DateTime.MinValue)
            //{
            //    RegisterDateTo = new DateTime(RegisterDateTo.Day, RegisterDateTo.Month, RegisterDateTo.Year, 23, 59, 59);
            //    sql += " AND Candidate_CreatedDate <= @RegisterDateTo";
            //}

            if (RegisterDateFrom.HasValue)
            {
                sql += " AND (Candidate_CreatedDate >= @RegisterDateFrom)";
                com.Parameters.AddWithValue("RegisterDateFrom", RegisterDateFrom.Value);
            }
            if (RegisterDateTo.HasValue)
            {
                sql += " AND (Candidate_CreatedDate <= @RegisterDateTo)";
                com.Parameters.AddWithValue("RegisterDateTo", RegisterDateTo.Value);
            }

            if (SearchCourseID != Guid.Empty)
            {
                sql += ") AS Candidate";
            }
                

            if (SearchFullName != "")
                com.Parameters.AddWithValue("@SearchFullName", "%" + SearchFullName + "%");
            if (SearchGender != -1)
                com.Parameters.AddWithValue("@SearchGender", SearchGender);
            if (SearchEmail != "")
                com.Parameters.AddWithValue("@SearchEmail", "%" + SearchEmail + "%");
            if (SearchICNumber != "")
                com.Parameters.AddWithValue("@SearchICNumber", "%" + SearchICNumber + "%");
            if (SearchState != "")
                com.Parameters.AddWithValue("@SearchState", "%" + SearchState + "%");
            if (SearchCourseID != Guid.Empty)
                com.Parameters.AddWithValue("@SearchCourseID", SearchCourseID);
            if (SearchCurrentlyEmployed != -1)
                com.Parameters.AddWithValue("@Employed", Employed);
            //if (RegisterDateFrom > DateTime.MinValue)
            //    com.Parameters.AddWithValue("@RegisterDateFrom", RegisterDateFrom);
            //if (RegisterDateTo > DateTime.MinValue)
            //    com.Parameters.AddWithValue("@RegisterDateTo", RegisterDateTo);

            PagedDataList<CandidateTable> lis = DA.GetPagedDataList<CandidateTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}
