using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EngineData;

public partial class Dashboard_IntakeBarChart : System.Web.UI.Page
{
    protected string JS = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DA da = new DA();
        DateTime dtf = DateTime.Today.AddYears(-1);
        dtf = new DateTime(dtf.Year, dtf.Month, 1);
        DateTime dtt = dtf.AddYears(1).AddMonths(1).AddDays(-1);

        List<tmpcache> months = new List<tmpcache>();
        for (int i = 0; i < 13; i++)
        {
            DateTime dt = dtf.AddMonths(i);
            tmpcache t = new tmpcache { Month = dt.ToString("MMM-yy"), App = 0, Enroll = 0 };
            months.Add(t);
        }

        ApplicationTable appTbl = da.Application.GetByDateRange(dtf, dtt);
        foreach (ApplicationRow dr in appTbl.Rows)
        {
            string month = dr.Application_Date.ToString("MMM-yy");
            tmpcache m = Find(months, month);
            if (m != null) m.App++;
        }
        StudentTable stuTbl = da.Student.GetByDateRange(dtf, dtt);
        foreach (StudentRow dr in stuTbl.Rows)
        {
            string month = dr.Student_EnrollmentDate.ToString("MMM-yy");
            tmpcache m = Find(months, month);
            if (m != null) m.Enroll++;
        }

        string js = "";
        foreach (tmpcache m in months)
        {
            js += "['" + m.Month + "', " + m.App + ", " + m.Enroll + "],";
        }
        JS = js;
    }
    tmpcache Find(List<tmpcache> months, string month)
    {
        foreach (tmpcache m in months)
        {
            if (m.Month == month) return m;
        }
        return null;
    }
    class tmpcache
    {
        public string Month;
        public int App;
        public int Enroll;
    }
}