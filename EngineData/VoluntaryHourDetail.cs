using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class VoluntaryHourDetailTable
    {
    }
    partial class VoluntaryHourDetailRow
    {
    }
    public partial class VoluntaryHourDetailMinimalizedEntity {
        public void CopyTo(VoluntaryHourRow dr)
        {
            dr.VoluntaryHour_ID = this.VoluntaryHour_ID;
            dr.Application_ID = this.Application_ID;
            dr.VoluntaryHour_Type = this.VoluntaryHour_Type;
            dr.VoluntaryHour_Duration = this.VoluntaryHour_Duration;
            dr.VoluntaryHour_Status = this.VoluntaryHour_Status;
            dr.VoluntaryHour_Description = this.VoluntaryHour_Description;
            dr.VoluntaryHour_CreatedBy = this.VoluntaryHour_CreatedBy;
            dr.VoluntaryHour_CreatedDate = this.VoluntaryHour_CreatedDate;
            dr.VoluntaryHour_UpdatedBy = this.VoluntaryHour_UpdatedBy;
            dr.VoluntaryHour_UpdatedDate = this.VoluntaryHour_UpdatedDate;
            dr.VoluntaryHour_IsDeleted = this.VoluntaryHour_IsDeleted;
            dr.VoluntaryHour_Remark = this.VoluntaryHour_Remark;
        }
    }
    partial class VoluntaryHourDetailAdapter
    {
        public PagedDataList<VoluntaryHourDetailTable> Search(string fullname, int gender, string email, string IC, string state, int status, SqlOrder[] ordering, int pg)
        {
            SqlOrder def = new SqlOrder(VoluntaryHourDetailTable.VoluntaryHour_CreatedDateColumnIndex);

            string sql = "VoluntaryHourDetail WHERE VoluntaryHour_IsDeleted = 0";
            if (fullname != "")
                sql += "Candidate_FullName LIKE @fullname";
            if (gender != -1)
                sql += "Candidate_Gender = @gender";
            if (email != "")
                sql += "Candidate_Email LIKE @email";
            if (IC != "")
                sql += "Candidate_ICNumber LIKE @IC";
            if (state != "")
                sql += "Candidate_State LIKE @state";
            if (status != -1)
                sql += "Candidate_LastName = @status";

            SqlCommand com = new SqlCommand(sql);
            if (fullname != "")
                com.Parameters.AddWithValue("@fullname", "%" + fullname + "%");
            if (gender != -1)
                com.Parameters.AddWithValue("@gender", gender);
            if (email != "")
                com.Parameters.AddWithValue("@email", "%" + email + "%");
            if (IC != "")
                com.Parameters.AddWithValue("@IC", "%" + IC + "%");
            if (state != "")
                com.Parameters.AddWithValue("@state", "%" + state + "%");
            if (status != -1)
                com.Parameters.AddWithValue("@status", status);
            com.CommandText = sql;
            PagedDataList<VoluntaryHourDetailTable> lis = DA.GetPagedDataList<VoluntaryHourDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public VoluntaryHourDetailRow Get(Guid ID)
        {
            string sql = "SELECT * FROM VoluntaryHourDetail WHERE VoluntaryHour_ID = @VoluntaryHour_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@VoluntaryHour_ID", ID);
            com.CommandText = sql;

            VoluntaryHourDetailTable dt = new VoluntaryHourDetailTable();
            DA.ExecuteQuery(com, dt);
            return (dt.Rows.Count > 0) ? (VoluntaryHourDetailRow)dt.Rows[0] : null;
        }

        //for Candidate Voluntary Work
        public PagedDataList<VoluntaryHourDetailTable> Search2(Guid CandidateID, DateTime startDate, DateTime endDate, string title, int startHour, int endHour, int VoluntaryHourStatusType, SqlOrder[] ordering, int pg)
        {
            string sql = sql = " VoluntaryHourDetail WHERE 1 = 1 AND VoluntaryHour_IsDeleted = 0 AND Application_Deleted = 0 AND Application_OverallStatus = 3 AND Candidate_ID = @CandidateID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CandidateID", CandidateID);

            if (startDate.Year > 1900 && endDate.Year > 1900)
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND VoluntaryHour_Date >= @startDate AND VoluntaryHour_Date < @dt";
                com.Parameters.AddWithValue("@startDate", startDate);
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            {
                //DateTime dt = endDate.AddDays(1);
                sql += " AND VoluntaryHour_Date >= @startDate";
                com.Parameters.AddWithValue("@startDate", startDate);
            }
            if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND VoluntaryHour_Date < @dt";
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (title.Length > 0)
            {
                sql += " AND VoluntaryHour_Title LIKE @title ";
                com.Parameters.AddWithValue("@title", "%" + title + "%");
            }
            if (startHour > 0 && endHour > 0)
            {
                int dHr = endHour + 1;
                sql += " AND VoluntaryHour_Duration >= @startHour AND VoluntaryHour_Duration < @dHr";
                com.Parameters.AddWithValue("@startHour", startHour);
                com.Parameters.AddWithValue("@dHr", dHr);
            }
            if (startHour > 0 && endHour == 0) //if only one field is selected
            {
                sql += " AND VoluntaryHour_Duration >= @startHour";
                com.Parameters.AddWithValue("@startHour", startHour);
            }
            if (endHour > 0 && startHour == 0) //if only one field is selected
            {
                int dHr = endHour + 1;
                sql += " AND VoluntaryHour_Duration < @dHr";
                com.Parameters.AddWithValue("@dHr", dHr);
            }
            if (VoluntaryHourStatusType != -1)
            {
                sql += " AND VoluntaryHour_Status = @VoluntaryHourStatusType ";
                com.Parameters.AddWithValue("@VoluntaryHourStatusType", VoluntaryHourStatusType);
            }

            SqlOrder def = new SqlOrder(VoluntaryHourDetailTable.VoluntaryHour_DateColumnIndex, false);
            PagedDataList<VoluntaryHourDetailTable> lis = DA.GetPagedDataList<VoluntaryHourDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        //for Candidate Voluntary Work
        public VoluntaryHourDetailRow GetBy(System.Guid Candidate_ID)
        {
            string sql = "SELECT * FROM Application WHERE Application_Deleted = 0 AND Candidate_ID = @Candidate_ID AND Application_OverallStatus='3'";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("Candidate_ID", Candidate_ID);
            VoluntaryHourDetailTable tbl = new VoluntaryHourDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetVoluntaryHourDetailRow(0);
            }
            else
            {
                return null;
            }
        }
    }
}