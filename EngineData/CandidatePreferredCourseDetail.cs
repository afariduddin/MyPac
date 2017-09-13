using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;
using System;

namespace EngineData
{
    partial class CandidatePreferredCourseDetailTable
    {
    }
    partial class CandidatePreferredCourseDetailRow
    {
    }
    public partial class CandidatePreferredCourseDetailMinimalizedEntity { }
    partial class CandidatePreferredCourseDetailAdapter
    {
        public List<CandidatePreferredCourseDetailRow> Get_ByCandidate(Guid CandidateID)
        {
            List<CandidatePreferredCourseDetailRow> list = new List<CandidatePreferredCourseDetailRow>();
            string sql = "SELECT * FROM CandidatePreferredCourseDetail WHERE Course_IsDeleted = 0 AND Candidate_ID = @CandidateID ORDER BY Course_Name ASC";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@CandidateID", CandidateID);

            CandidatePreferredCourseDetailTable tbl = new CandidatePreferredCourseDetailTable();
            DA.ExecuteQuery(com, tbl);
            foreach (CandidatePreferredCourseDetailRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
        }
    }
}