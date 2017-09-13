using System;
using System.Data.SqlClient;
using Teq.Data;

namespace EngineData {
partial class WorkHistoryTable {
}
partial class WorkHistoryRow {
public void OverrideDefaultValues() {
            WorkHistory_ResignDate = EngineVariable.LibraryVariable.Empty_DateTime ;
}
}
public partial class WorkHistoryMinimalizedEntity {}
partial class WorkHistoryAdapter {
    }
}
