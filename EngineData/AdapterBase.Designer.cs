using System;
using System.Data;
using System.Collections.Generic;
namespace EngineData {
public partial class AdapterBase {
DA da;
public DA DA {
get { return da; }
}
public AdapterBase (DA _da) { 
da = _da;
}
protected void Log(DataTable tbl, IActivityLog log) { 
if( log != null ) foreach( DataRow dr in tbl.Rows ) log.AddTransaction(dr);
}
protected void Log(DataRow dr, IActivityLog log) { 
if( log != null ) log.AddTransaction(dr);
}
}
}
