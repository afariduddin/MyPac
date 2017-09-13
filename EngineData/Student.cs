using System;
using System.Data.SqlClient;
using System.Data;
using EngineVariable;
using Teq;

namespace EngineData
{
    partial class StudentTable
    {
    }
    partial class StudentRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class StudentMinimalizedEntity { }
    partial class StudentAdapter
    {
        public Guid GetStudentIDByCandidateID(Guid candidateId)
        {
            string sql = @"
SELECT Student_ID FROM Student 
WHERE Application_ID = 
(
	SELECT Application_ID FROM Application 
	WHERE Application_OverallProgress =  @appStatus
	AND Candidate_ID = @canId
)
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("appStatus", ApplicationOverallProgressType.StudentCourse.Code);
            com.Parameters.AddWithValue("canId", candidateId);
            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0 && !tbl.Rows[0].IsNull(0) && tbl.Rows[0][0] is Guid) return (Guid)tbl.Rows[0][0];
            else return Guid.Empty;
        }
        public StudentTable GetByDateRange(DateTime dtf, DateTime dtt)
        {
            string sql = @"
SELECT * FROM Student WHERE 1=1
AND Student_EnrollmentDate >= @dtf 
AND Student_EnrollmentDate < @dtt 
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("dtf", dtf);
            com.Parameters.AddWithValue("dtt", dtt);

            StudentTable tbl = new StudentTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public DataTable GetNumberByCampus(DateTime dtf, DateTime dtt)
        {
            string sql = @"
SELECT COUNT(*) AS Total, TSP.TSP_CampusName AS CampusName FROM Student 
INNER JOIN TSP ON TSP.TSP_ID = Student.TSP_ID
WHERE 1=1
AND Student_EnrollmentDate >= @dtf 
AND Student_EnrollmentDate < @dtt 
GROUP BY TSP.TSP_CampusName
";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("dtf", dtf);
            com.Parameters.AddWithValue("dtt", dtt);

            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public DataTable GetNumberByCampus()
        {
            string sql = @"
SELECT COUNT(*) AS Total, TSP.TSP_CampusName AS CampusName FROM Student 
INNER JOIN TSP ON TSP.TSP_ID = Student.TSP_ID
GROUP BY TSP.TSP_CampusName
";
            SqlCommand com = new SqlCommand(sql);

            DataTable tbl = new DataTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
    }
}