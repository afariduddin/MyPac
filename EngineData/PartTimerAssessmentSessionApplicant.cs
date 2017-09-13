using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class PartTimerAssessmentSessionApplicantTable
    {
    }
    partial class PartTimerAssessmentSessionApplicantRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class PartTimerAssessmentSessionApplicantMinimalizedEntity { }
    partial class PartTimerAssessmentSessionApplicantAdapter
    {
        public bool Get(Guid ID)
        {
            string sql = "SELECT * FROM PartTimerAssessmentSessionApplicant WHERE PartTimerAssessmentSession_ID = @ID";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ID", ID);
            PartTimerAssessmentSessionApplicantTable tbl = new PartTimerAssessmentSessionApplicantTable();
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

        public PartTimerAssessmentSessionApplicantRow Get(Guid Applicant_ID, Guid PartTimerAssessmentSession_ID)
        {
            SqlCommand fcom = new SqlCommand();
            string sql = "SELECT * FROM [PartTimerAssessmentSessionApplicant] WHERE [Applicant_ID] = @Applicant_ID AND [PartTimerAssessmentSession_ID] = @PartTimerAssessmentSession_ID";
            fcom.CommandText = sql;
            fcom.Parameters.AddWithValue("Applicant_ID", Applicant_ID);
            fcom.Parameters.AddWithValue("PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
            PartTimerAssessmentSessionApplicantTable tbl = new PartTimerAssessmentSessionApplicantTable();
            DA.ExecuteQuery(fcom, tbl);
            return (tbl.Rows.Count > 0) ? (PartTimerAssessmentSessionApplicantRow)tbl.Rows[0] : null;
        }
    }
}
