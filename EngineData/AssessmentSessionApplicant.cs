using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class AssessmentSessionApplicantTable
    {
    }
    partial class AssessmentSessionApplicantRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class AssessmentSessionApplicantMinimalizedEntity { }
    partial class AssessmentSessionApplicantAdapter
    {
        public AssessmentSessionApplicantRow Get(Guid AssessmentSession_ID, Guid Applicant_ID)
        {
            string sql = "SELECT * FROM AssessmentSessionApplicant WHERE AssessmentSession_ID = @PartTimerAssessmentSession_ID AND Applicant_ID = @Applicant_ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@AssessmentSession_ID", AssessmentSession_ID);
            com.Parameters.AddWithValue("@Applicant_ID", Applicant_ID);

            AssessmentSessionApplicantTable tbl = new AssessmentSessionApplicantTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (AssessmentSessionApplicantRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public bool Get(Guid ID)
        {
            string sql = "SELECT * FROM AssessmentSessionApplicant WHERE AssessmentSession_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            AssessmentSessionApplicantTable tbl = new AssessmentSessionApplicantTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}