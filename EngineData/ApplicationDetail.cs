using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class ApplicationDetailTable {
}
partial class ApplicationDetailRow {
}
public partial class ApplicationDetailMinimalizedEntity {}
partial class ApplicationDetailAdapter {
        public PagedDataList<ApplicationDetailTable> Search(DateTime? startDate, DateTime? endDate, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, Guid TSPID, int ApplicationStatusType, string CGPA, Guid CourseID, string AgeFrom, string AgeTo, SqlOrder[] ordering, int pg)
        {
            string sql = "";
            if (TSPID == Guid.Empty)
            {
                sql = " ApplicationDetail WHERE 1 = 1 ";
            }
            else
            {
                sql = "ApplicationDetail INNER JOIN TSP on ApplicationDetail.TSP_ID = TSP.TSP_ID WHERE 1=1 ";
            }
            sql += " AND Application_Deleted = 0 ";
            SqlCommand com = new SqlCommand(sql);

            //if (startDate.Year > 1900 && endDate.Year > 1900)
            //{
            //    DateTime dt = endDate.AddDays(1);
            //    sql += " AND Application_Date >= @startDate AND Application_Date < @dt";
            //    com.Parameters.AddWithValue("@startDate", startDate);
            //    com.Parameters.AddWithValue("@dt", dt);
            //}
            //if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            //{
            //    //DateTime dt = endDate.AddDays(1);
            //    sql += " AND Application_Date >= @startDate";
            //    com.Parameters.AddWithValue("@startDate", startDate);
            //}
            //if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            //{
            //    DateTime dt = endDate.AddDays(1);
            //    sql += " AND Application_Date < @dt";
            //    com.Parameters.AddWithValue("@dt", dt);
            //}
            if (startDate.HasValue)
            {
                sql += " AND (Application_Date >= @startDate)";
                com.Parameters.AddWithValue("startDate", startDate.Value);
            }
            if (endDate.HasValue)
            {
                sql += " AND (Application_Date <= @endDate)";
                com.Parameters.AddWithValue("endDate", endDate.Value);
            }

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
            if (TSPID != Guid.Empty)
            {
                sql += " AND TSP.TSP_ID = @TSPID";
                com.Parameters.AddWithValue("@TSPID", TSPID);
            }
            if (ApplicationStatusType != -1)
            {
                sql += " AND Application_Status = @ApplicationStatusType ";
                com.Parameters.AddWithValue("@ApplicationStatusType", ApplicationStatusType);
            }

            if (CGPA.Length > 0)
            {
                sql += " AND Application_CGPA <= @Application_CGPA ";
                com.Parameters.AddWithValue("@Application_CGPA", CGPA);
            }
            if (CourseID != Guid.Empty)
            {
                sql += " AND Course_ID = @Course_ID";
                com.Parameters.AddWithValue("@Course_ID", CourseID);
            }
            if (AgeFrom.Length > 0)
            {
                int number;
                if(int.TryParse(AgeFrom,out number))
                {
                    sql += " AND dbo.GetAge(Application_DOB) >= @AgeFrom";
                    com.Parameters.AddWithValue("@AgeFrom", number);
                }
            }
            if (AgeTo.Length > 0)
            {
                int number;
                if (int.TryParse(AgeTo, out number))
                {
                    sql += " AND dbo.GetAge(Application_DOB) <= @AgeTo";
                    com.Parameters.AddWithValue("@AgeTo", number);
                }
            }
            SqlOrder def = new SqlOrder(ApplicationDetailTable.Application_DateColumnIndex, false);
            PagedDataList<ApplicationDetailTable> lis = DA.GetPagedDataList<ApplicationDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public PagedDataList<ApplicationDetailTable> Search(string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, int FinalisedApplicationStatusType, SqlOrder[] ordering, int pg)
        {
            string sql = " ApplicationDetail WHERE 1 = 1 AND Application_Deleted = 0 ";
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

            SqlOrder def = new SqlOrder(ApplicationDetailTable.Application_CreatedDateColumnIndex, false);
            PagedDataList<ApplicationDetailTable> lis = DA.GetPagedDataList<ApplicationDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

    }
}
