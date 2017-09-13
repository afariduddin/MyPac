using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class StudentCourseDetailTable {
}
partial class StudentCourseDetailRow {
}
public partial class StudentCourseDetailMinimalizedEntity {
        public void CopyTo(StudentCourseRow dr)
        {
            dr.StudentCourse_ID = this.StudentCourse_ID;
            dr.Student_ID = this.Student_ID;
            dr.CourseSubject_ID = this.CourseSubject_ID;
            dr.StudentCourse_Status = this.StudentCourse_Status;
            dr.StudentCourse_CreatedDate = this.StudentCourse_CreatedDate;
            dr.StudentCourse_UpdatedDate = this.StudentCourse_UpdatedDate;
            dr.StudentCourse_CreatedBy = this.StudentCourse_CreatedBy;
            dr.StudentCourse_UpdatedBy = this.StudentCourse_UpdatedBy;
            dr.StudentCourse_Remark = this.StudentCourse_Remark;
            dr.StudentCourse_DefermentReason = this.StudentCourse_DefermentReason;
        }

    }
partial class StudentCourseDetailAdapter {
        public StudentCourseDetailRow GetBy(System.Guid StudentCourse_ID)
        {
            string sql = "SELECT * FROM StudentCourseDetail WHERE StudentCourse_ID = @StudentCourse_ID and Application_Deleted = 0 ";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("StudentCourse_ID", StudentCourse_ID);
            StudentCourseDetailTable tbl = new StudentCourseDetailTable();
            DA.ExecuteQuery(com, tbl);
            if (tbl.Rows.Count > 0)
            {
                return tbl.GetStudentCourseDetailRow(0);
            }
            else
            {
                return null;
            }
        }

        public PagedDataList<StudentCourseDetailTable> Search(DateTime startDate, DateTime endDate, string FullName, int Gender, string Email, string ICNumber, string State, int ContractType, int StudentCourseStatusType, SqlOrder[] ordering, int pg)
        {
            string sql = " StudentCourseDetail WHERE 1 = 1 AND Application_Deleted = 0 ";

            SqlCommand com = new SqlCommand(sql);

            if (startDate.Year > 1900 && endDate.Year > 1900)
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND StudentCourse_CreatedDate >= @startDate AND StudentCourse_CreatedDate < @dt";
                com.Parameters.AddWithValue("@startDate", startDate);
                com.Parameters.AddWithValue("@dt", dt);
            }
            if (startDate.Year > 1900 && endDate.Year < 1900) //if only one date is selected
            {
                //DateTime dt = endDate.AddDays(1);
                sql += " AND StudentCourse_CreatedDate >= @startDate";
                com.Parameters.AddWithValue("@startDate", startDate);
            }
            if (startDate.Year < 1900 && endDate.Year > 1900) //if only one date is selected
            {
                DateTime dt = endDate.AddDays(1);
                sql += " AND StudentCourse_CreatedDate < @dt";
                com.Parameters.AddWithValue("@dt", dt);
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
            if (StudentCourseStatusType != -1)
            {
                sql += " AND StudentCourse_Status = @StudentCourseStatusType ";
                com.Parameters.AddWithValue("@StudentCourseStatusType", StudentCourseStatusType);
            }

            SqlOrder def = new SqlOrder(StudentCourseDetailTable.StudentCourse_CreatedDateColumnIndex, false);
            PagedDataList<StudentCourseDetailTable> lis = DA.GetPagedDataList<StudentCourseDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }

        public PagedDataList<StudentCourseDetailTable> Search(Guid Candidate_ID, SqlOrder[] ordering, int pg)
        {
            string sql = " StudentCourseDetail WHERE 1 = 1 AND Application_Deleted = 0 ";
            sql += " AND StudentCourseDetail.Application_OverallStatus != @Application_OverallStatus AND Candidate_ID = @Candidate_ID";
            SqlCommand com = new SqlCommand(sql);
            
            com.Parameters.AddWithValue("@Application_OverallStatus", (int)EngineVariable.ApplicationOverallStatusType.Inactive);
            com.Parameters.AddWithValue("@Candidate_ID", Candidate_ID);

            SqlOrder def = new SqlOrder(StudentCourseDetailTable.CourseSubject_CodeColumnIndex, true);
            PagedDataList<StudentCourseDetailTable> lis = DA.GetPagedDataList<StudentCourseDetailTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
    }
}
