using System;
using System.Configuration;
using System.Collections.Generic;
using Teq.Data;
namespace EngineData {
public partial class DA : SqlDataAccessBase {
public DA() : base(ConfigurationManager.AppSettings["DBConnection"]) {
}
        ReportsAdapter _Reports;
        public ReportsAdapter Reports
        {
            get { if (_Reports == null) _Reports = new ReportsAdapter(this); return _Reports; }
        }
    }
}
