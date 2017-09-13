using System;
using System.Data;
using System.Data.SqlClient;
namespace EngineData {
public partial interface IActivityLog {
void AddTransaction(DataRow dr);
void AddTransaction(string sql);
void AddTransaction(SqlCommand com);
}
}
