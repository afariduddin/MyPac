using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class AssessmentResultTable
    {
    }
    partial class AssessmentResultRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class AssessmentResultMinimalizedEntity { }
    partial class AssessmentResultAdapter
    {

        public AssessmentResultRow Get(string IdentificationNumber)
        {
            string sql = "SELECT AssessmentResult.* FROM AssessmentResult, [Application] WHERE AssessmentResult.Application_ID = [Application].Application_ID AND [Application].Application_IdentificationNumber = @IdentificationNumber";

            SqlCommand com = new SqlCommand(sql);

            com.Parameters.AddWithValue("@IdentificationNumber", IdentificationNumber);
            AssessmentResultTable dt = new AssessmentResultTable();

            DA.ExecuteQuery(com, dt);

            if (dt.Rows.Count > 0)
                return (AssessmentResultRow)dt.Rows[0];
            else
                return null;
        }
    }
}
