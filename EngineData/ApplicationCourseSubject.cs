using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class ApplicationCourseSubjectTable {
}
partial class ApplicationCourseSubjectRow {
public void OverrideDefaultValues() {
}
}
public partial class ApplicationCourseSubjectMinimalizedEntity {}
partial class ApplicationCourseSubjectAdapter {
        public List<ApplicationCourseSubjectRow> GetByApplication(Guid ApplicationID)
        {
            List<ApplicationCourseSubjectRow> list = new List<ApplicationCourseSubjectRow>();
            string sql = "SELECT * FROM ApplicationCourseSubject WHERE Application_ID  = @ApplicationID ";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            ApplicationCourseSubjectTable tbl = new ApplicationCourseSubjectTable();
            DA.ExecuteQuery(com, tbl);
            foreach (ApplicationCourseSubjectRow r in tbl.Rows)
            {
                list.Add(r);
            }
            return list;
        }

        public void DeleteByApplication(Guid ApplicationID)
        {
            string sql = "DELETE FROM ApplicationCourseSubject WHERE Application_ID = @ApplicationID";

            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            DA.ExecuteNonQuery(com);
        }
    }
}
