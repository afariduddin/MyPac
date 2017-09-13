using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class CandidatePreferredCourseTable
    {
    }
    partial class CandidatePreferredCourseRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class CandidatePreferredCourseMinimalizedEntity { }
    partial class CandidatePreferredCourseAdapter
    {
        public void DeleteByCandidate(Guid CandidateID)
        {
            string sql = "DELETE FROM CandidatePreferredCourse WHERE Candidate_ID = @CandidateID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CandidateID", CandidateID);

            DA.ExecuteNonQuery(com);
        }
    }
}
