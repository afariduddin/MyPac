using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Teq;
namespace EngineData {
public partial class StoredProcedureAdapter:AdapterBase {
SqlDataAdapter adapter;
SqlDataAdapter adapterTool_ScriptDiagram2005;
public SqlDataAdapter Adapter {
get { return adapter; }
}
public StoredProcedureAdapter(DA da):base(da) {
InitializeAdapter();
}
void InitializeAdapter() {
adapter = new SqlDataAdapter();

adapterTool_ScriptDiagram2005 = new SqlDataAdapter();
{
}
}
public int Tool_ScriptDiagram2005(System.String name) {
SqlCommand comm = new SqlCommand();
comm.CommandText = "Tool_ScriptDiagram2005";
comm.CommandType = CommandType.StoredProcedure;
comm.Parameters.Add("@name", SqlDbType.VarChar);
comm.Parameters["@name"].Value = name;
adapterTool_ScriptDiagram2005.SelectCommand = comm;
int ret = DA.ExecuteStoredProc(adapterTool_ScriptDiagram2005);
return ret;
}
}
}
