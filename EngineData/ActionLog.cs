using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EngineData
{
    public class ActionLog : IActivityLog
    {
        string userName;
        string operation;
        string ipAddress;
        List<TransactionLog> transactions = new List<TransactionLog>();
        public ActionLog(string username, string ipAddr, string op)
        {
            Init(username, ipAddr, op);
        }
        private void Init(string user, string ipAddr, string op)
        {
            userName = user;
            ipAddress = ipAddr;
            operation = op;
        }
        /// <summary>
        /// Add a 2nd level data. This method will collect any changes in the datarow and generate the 3rd level data as well.
        /// </summary>
        /// <param name="dr"></param>
        public void AddTransaction(DataRow dr)
        {
            if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Deleted)
            {
                TransactionLog t = new TransactionLog(dr);
                if (t.operation != "") transactions.Add(t);
            }
        }
        /// <summary>
        /// Add a 2nd level data.
        /// </summary>
        /// <param name="sql"></param>
        public void AddTransaction(string sql)
        {
            transactions.Add(new TransactionLog("SQL: " + sql.Replace(Environment.NewLine, " "))); //"Batch operation." + Environment.NewLine + 
        }
        /// <summary>
        /// Add a 2nd level data. This method will extract command details from the passed-in object.
        /// </summary>
        /// <param name="com"></param>
        public void AddTransaction(SqlCommand com)
        {
            string o = "SQL: <br/> " + com.CommandText.Replace(Environment.NewLine, " "); //"Batch operation." + Environment.NewLine + 
            if (com.Parameters.Count > 0)
            {
                string ps = "";
                foreach (SqlParameter p in com.Parameters)
                {
                    if (ps != "") ps += " <br/> ";
                    ps += p.ParameterName + " = " + p.Value.ToString();
                }
                o += " <br/><br/> " + "Params: " + " <br/> " + ps;
            }
            transactions.Add(new TransactionLog(o));
        }
        /// <summary>
        /// Save all data into database.
        /// </summary>
        public void Save()
        {
            if (transactions.Count > 0)
            {
                DA da = new DA();
                ActivityLogRow dr = new ActivityLogTable().NewActivityLogRow();
                dr.ActivityLog_ID = Guid.NewGuid();
                dr.ActivityLog_DateTime = DateTime.Now;
                dr.ActivityLog_UserName = userName;
                dr.ActivityLog_IPAddress = ipAddress.ToString();
                dr.ActivityLog_Description = operation;
                da.ActivityLog.Update(dr);

                ActivityLogTransactionTable tTbl = new ActivityLogTransactionTable();
                foreach (TransactionLog t in transactions)
                {
                    if (t.operation != "")
                    {
                        t.dr = tTbl.NewActivityLogTransactionRow();
                        t.dr.ActivityLogTransaction_ID = Guid.NewGuid();
                        t.dr.ActivityLog_ID = dr.ActivityLog_ID;
                        t.dr.Description = t.operation;
                    }
                }
                da.ActivityLogTransaction.Update(tTbl);

                ActivityLogColumnTable vTbl = new ActivityLogColumnTable();
                foreach (TransactionLog t in transactions)
                {
                    if (t.operation != "")
                    {
                        foreach (ValuesLog v in t.values)
                        {
                            ActivityLogColumnRow vdr = vTbl.NewActivityLogColumnRow();
                            vdr.ActivityLogColumn_ID = Guid.NewGuid();
                            vdr.ActivityLogColumn_ColumnName = v.fieldName;
                            vdr.ActivityLogColumn_OriginalValue = v.orignalValue;
                            vdr.ActivityLogColumn_NewValue = v.newValue;
                            vdr.ActivityLogTransaction_ID = t.dr.ActivityLogTransaction_ID;
                        }
                    }
                }
                da.ActivityLogColumn.Update(vTbl);
            }
        }

        class TransactionLog
        {
            public ActivityLogTransactionRow dr;
            public string operation;
            public List<ValuesLog> values = new List<ValuesLog>();
            public TransactionLog(DataRow dr)
            {
                if (dr.RowState == DataRowState.Added)
                {
                    operation = "Insert '" + dr.Table.TableName + "' record.";
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        values.Add(new ValuesLog(dc.ColumnName, "", dr[dc].ToString()));
                    }
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    operation = "Update '" + dr.Table.TableName + "' record.";
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        values.Add(new ValuesLog(dc.ColumnName, dr[dc, DataRowVersion.Original].ToString(), dr[dc].ToString()));
                    }
                    if (values.Count == 0) operation = "";
                }
                else if (dr.RowState == DataRowState.Deleted)
                {
                    operation = "Delete '" + dr.Table.TableName + "' record.";
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        values.Add(new ValuesLog(dc.ColumnName, dr[dc, DataRowVersion.Original].ToString(), ""));
                    }
                }
            }
            public TransactionLog(string op)
            {
                operation = op;
            }
        }
        class ValuesLog
        {
            public string fieldName;
            public string orignalValue;
            public string newValue;
            public ValuesLog(string fname, string oriVal, string newVal)
            {
                fieldName = fname;
                orignalValue = oriVal;
                newValue = newVal;
            }
        }
    }
}
