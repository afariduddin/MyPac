using System;
using System.Data;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData
{
    partial class EmailNotificationTable
    {
    }
    partial class EmailNotificationRow
    {
        public void OverrideDefaultValues()
        {
        }
    }
    public partial class EmailNotificationMinimalizedEntity { }
    partial class EmailNotificationAdapter
    {
        public EmailNotificationTable GetPending()
        {
            string sql = "SELECT * FROM EmailNotification WHERE EmailNotification_Status = @status";
            SqlCommand com = new SqlCommand(sql);
            com.Parameters.AddWithValue("status", (short)EngineVariable.EmailNotificationStatusType.Pending);
            EmailNotificationTable tbl = new EmailNotificationTable();
            DA.ExecuteQuery(com, tbl);
            return tbl;
        }
        public PagedDataList<EmailNotificationTable> Search(DateTime? CreatedDateFrom, DateTime? CreatedDateTo, string SearchEmailRecipient, int SearchStatus, string SearchEmailSubject, SqlOrder[] ordering, int pg)
        {
            string sql = "EmailNotification WHERE 1=1 ";
            SqlCommand com = new SqlCommand(sql);

            if (CreatedDateFrom.HasValue)
            {
                sql += " AND (EmailNotification_CreatedDate >= @CreatedDateFrom)";
                com.Parameters.AddWithValue("CreatedDateFrom", CreatedDateFrom.Value);
            }
            if (CreatedDateTo.HasValue)
            {
                sql += " AND (EmailNotification_CreatedDate <= @CreatedDateTo)";
                com.Parameters.AddWithValue("CreatedDateTo", CreatedDateTo.Value);
            }

            if (SearchEmailRecipient.Length > 0)
            {
                sql += " AND EmailNotification_Recipient LIKE @SearchEmailRecipient ";
                com.Parameters.AddWithValue("@SearchEmailRecipient", "%" + SearchEmailRecipient + "%");
            }
            if (SearchStatus != -1)
            {
                sql += " AND EmailNotification_Status = @SearchStatus ";
                com.Parameters.AddWithValue("@SearchStatus", SearchStatus);
            }
            if (SearchEmailSubject.Length > 0)
            {
                sql += " AND EmailNotification_Subject LIKE @SearchEmailSubject ";
                com.Parameters.AddWithValue("@SearchEmailSubject", "%" + SearchEmailSubject + "%");
            }

            SqlOrder def = new SqlOrder(EmailNotificationTable.EmailNotification_CreatedDateColumnIndex, false);
            PagedDataList<EmailNotificationTable> lis = DA.GetPagedDataList<EmailNotificationTable>(sql, com, def, ordering, EngineVariable.LibraryVariable.Page_Size, pg);
            return lis;
        }
        public PagedDataList<EmailNotificationTable> GetForCandidateDashboard(Guid candidateId, int pg)
        {
            ApplicationRow appDr = DA.Application.GetBy_ActiveCompleteCandidate(candidateId);
            if (appDr != null)
            {
                //SELECT EmailNotification_ID, EmailNotification_Subject, EmailNotification_IsRead FROM EmailNotification 
                //WHERE Application_ID = @appId
                //ORDER BY EmailNotification_CreatedDate DESC
//                string sql = @"
//(
//	SELECT EmailNotification_ID, EmailNotification_Subject, EmailNotification_IsRead, EmailNotification_CreatedDate FROM EmailNotification 
//	WHERE Application_ID = ''
//) EmailNotification
//";
                string sql = "EmailNotification WHERE Application_ID = @appId";
                SqlOrder def = new SqlOrder(EmailNotificationTable.EmailNotification_CreatedDateColumnIndex, false);
                SqlCommand com = new SqlCommand();
                com.Parameters.AddWithValue("appId", appDr.Application_ID);
                PagedDataList<EmailNotificationTable> lis = DA.GetPagedDataList<EmailNotificationTable>(sql, com, def, new SqlOrder[0], EngineVariable.LibraryVariable.Page_Size, pg);
                #region clear unwanted columns to reduce package size - DO NOT update the table
                foreach (EmailNotificationRow dr in lis.DataTable.Rows)
                {
                    dr.EmailNotification_EmailContent = "";
                    dr.EmailNotification_Recipient = "";
                    dr.EmailNotification_StatusMessage = "";
                } 
                #endregion
                return lis;
            }
            else return new PagedDataList<EmailNotificationTable>(new EmailNotificationTable());
        }
    }
}
