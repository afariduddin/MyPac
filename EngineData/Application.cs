using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class ApplicationTable
    {
    }
    partial class ApplicationRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class ApplicationMinimalizedEntity { }
    partial class ApplicationAdapter
    {
        public int SetReject(System.Collections.Generic.List<string> AppIDs, string UpdatedBy)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "UPDATE [Application] SET Application_Status = @Application_Status, Application_UpdatedBy = @Application_UpdatedBy, Application_UpdatedDate = @Application_UpdatedDate, Application_OverallStatus = @Application_OverallStatus";
            sql += " WHERE [Application_ID] IN (";
           
            int Counter = 0;
            foreach(string AppID in AppIDs)
            {
                if (Counter > 0)
                    sql += ", ";

                sql += "@AppID" + Counter.ToString();
                fcom.Parameters.AddWithValue("@AppID" + Counter.ToString(), AppID);

                Counter += 1;
            }
            sql += ")";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Application_Status", (short)EngineVariable.ApplicationStatus.Terminated);
            fcom.Parameters.AddWithValue("@Application_UpdatedBy", UpdatedBy);
            fcom.Parameters.AddWithValue("@Application_UpdatedDate", DateTime.Now);
            fcom.Parameters.AddWithValue("@Application_OverallStatus", (short)EngineVariable.ApplicationOverallStatusType.Inactive);
            ApplicationTable tbl = new ApplicationTable();
            return DA.ExecuteNonQuery(fcom);
        }


        public ApplicationTable GetBy(System.Guid Candidate_ID)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Candidate_ID] = @Candidate_ID and Application_Deleted = 0 order by Application_UpdatedDate desc ";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Candidate_ID", Candidate_ID);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);
            return tbl;
        }

        public ApplicationRow GetBy_Name(string Application_FullName)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Application_FullName] = @Application_FullName";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Application_FullName", Application_FullName);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);
            if (tbl.Rows.Count > 0)
                return (ApplicationRow)tbl.Rows[0];
            else
                return null;
        }

        public ApplicationRow GetBy_ActiveCompleteCandidate(System.Guid Candidate_ID)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Candidate_ID] = @Candidate_ID AND Application_Deleted = 0 AND (Application_OverallStatus = @Application_OverallStatusActive OR Application_OverallStatus = @Application_OverallStatusComplete)";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Candidate_ID", Candidate_ID);
            fcom.Parameters.AddWithValue("@Application_OverallStatusActive", (int)EngineVariable.ApplicationOverallStatusType.Active);
            fcom.Parameters.AddWithValue("@Application_OverallStatusComplete", (int)EngineVariable.ApplicationOverallStatusType.Completed);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);
            if (tbl.Rows.Count > 0)
                return (ApplicationRow)tbl.Rows[0];
            else
                return null;
        }

        public ApplicationTable GetBy_CourseType(short CourseType)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE 1 = 1";
            if (CourseType > 0)
            {
                sql += " AND [Application_ContractType] = @CourseType";
            }

            fcom.CommandText = sql;

            if (CourseType > 0)
                fcom.Parameters.AddWithValue("@CourseType", CourseType);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);
            return tbl;
        }

        public ApplicationRow GetBy(System.Guid Candidate_ID, EngineVariable.ApplicationOverallStatusType Application_OverallStatus)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Candidate_ID] = @Candidate_ID AND Application_Deleted = 0 AND Application_OverallStatus = @Application_OverallStatus";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Candidate_ID", Candidate_ID);
            fcom.Parameters.AddWithValue("@Application_OverallStatus", (int)Application_OverallStatus);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);
            if (tbl.Rows.Count > 0)
                return (ApplicationRow)tbl.Rows[0];
            else
                return null;
        }


        public ApplicationRow GetBy_Identification(string Application_IdentificationNumber)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Application_IdentificationNumber] = @Application_IdentificationNumber";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Application_IdentificationNumber", Application_IdentificationNumber);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);

            if (tbl.Rows.Count > 0)
            {
                return (ApplicationRow)tbl.Rows[0];
            }
            else
                return null;
        }

        public ApplicationRow GetBy(string Application_IdentificationNumber, EngineVariable.ApplicationOverallStatusType Application_OverallStatus)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [Application] WHERE [Application_IdentificationNumber] = @Application_IdentificationNumber AND Application_OverallStatus = @Application_OverallStatus";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("@Application_IdentificationNumber", Application_IdentificationNumber);
            fcom.Parameters.AddWithValue("@Application_OverallStatus", (int)Application_OverallStatus);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(fcom, tbl);

            if (tbl.Rows.Count > 0)
            {
                return (ApplicationRow)tbl.Rows[0];
            }
            else
                return null;
        }

        public string GetStatusCount(int status)
        {
            SqlCommand com = new SqlCommand();
            string sql = "SELECT * FROM Application WHERE Application_Status = @status AND Application_Deleted = 0";
            com.CommandText = sql;
            com.Parameters.AddWithValue("@status", status);
            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows.Count.ToString();
            }
            else
            {
                return "0".ToString();
            }
        }

        //for Finalised Candidate List
        public PagedDataList<ApplicationTable> Search(string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, int FinalisedApplicationStatusType, SqlOrder[] ordering, int pg)
        {
            string sql = " Application WHERE 1 = 1 AND Application_Deleted = 0 ";
            sql += " AND (Application_OverallStatus  = @Application_OverallStatusActive OR Application_OverallStatus  = @Application_OverallStatusComplete)";
            sql += " AND (Application_OverallProgress = @Application_OverallProgressFinal OR Application_OverallProgress = @Application_OverallProgressStudent)";

            SqlCommand com = new SqlCommand(sql);

            if (FullName.Length > 0)
            {
                sql += " AND Application_FullName LIKE @FullName ";
                com.Parameters.AddWithValue("@FullName", "%" + FullName + "%");
            }
            if (Gender != -1)
            {
                sql += " AND Application_Gender = @Gender ";
                com.Parameters.AddWithValue("@Gender", Gender);
            }
            if (Email.Length > 0)
            {
                sql += " AND Application_Email LIKE @Email ";
                com.Parameters.AddWithValue("@Email", "%" + Email + "%");
            }
            if (ICNumber.Length > 0)
            {
                sql += " AND Application_IdentificationNumber LIKE @ICNumber ";
                com.Parameters.AddWithValue("@ICNumber", "%" + ICNumber + "%");
            }
            if (State.Length > 0)
            {
                sql += " AND Application_State LIKE @State ";
                com.Parameters.AddWithValue("@State", "%" + State + "%");
            }
            if (ContractType != -1)
            {
                sql += " AND Application_ContractType = @ContractType ";
                com.Parameters.AddWithValue("@ContractType", ContractType);
            }
            if (FinalisedApplicationStatusType != -1)
            {
                sql += " AND Application_FinalisedStatus = @FinalisedApplicationStatusType ";
                com.Parameters.AddWithValue("@FinalisedApplicationStatusType", FinalisedApplicationStatusType);
            }

            com.Parameters.AddWithValue("@Application_OverallStatusActive", (int)EngineVariable.ApplicationOverallStatusType.Active);
            com.Parameters.AddWithValue("@Application_OverallStatusComplete", (int)EngineVariable.ApplicationOverallStatusType.Completed);

            com.Parameters.AddWithValue("@Application_OverallProgressFinal", (int)EngineVariable.ApplicationOverallProgressType.Finalised);
            com.Parameters.AddWithValue("@Application_OverallProgressStudent", (int)EngineVariable.ApplicationOverallProgressType.StudentCourse);

            SqlOrder def = new SqlOrder(ApplicationTable.Application_CreatedDateColumnIndex, false);
            PagedDataList<ApplicationTable> lis = DA.GetPagedDataList<ApplicationTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public ApplicationTable GetByDateRange(DateTime dtf, DateTime dtt)
        {
            string sql = @"
SELECT * FROM Application WHERE 1=1
AND Application_Date >= @dtf 
AND Application_Date < @dtt 
AND Application_Deleted = 0
AND Application_Submitted = 1
ORDER BY Application_Date
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("dtf", dtf);
            com.Parameters.AddWithValue("dtt", dtt);

            ApplicationTable tbl = new ApplicationTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}
