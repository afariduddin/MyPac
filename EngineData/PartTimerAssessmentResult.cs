using System;
using System.Data.SqlClient;

namespace EngineData
{
    partial class PartTimerAssessmentResultTable
    {
    }
    partial class PartTimerAssessmentResultRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class PartTimerAssessmentResultMinimalizedEntity { }
    partial class PartTimerAssessmentResultAdapter
    {
        public PartTimerAssessmentResultRow Get(Guid Applicant_ID)
        {
            string sql = "SELECT * FROM PartTimerAssessmentResult WHERE Application_ID = @Applicant_ID";
            SqlCommand com = new SqlCommand(sql);
            //com.Parameters.AddWithValue("@PartTimerAssessmentSession_ID", PartTimerAssessmentSession_ID);
            com.Parameters.AddWithValue("@Applicant_ID", Applicant_ID);

            PartTimerAssessmentResultTable tbl = new PartTimerAssessmentResultTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return (PartTimerAssessmentResultRow)tbl.Rows[0];
            }
            else
            {
                return null;
            }
        }
    }
}