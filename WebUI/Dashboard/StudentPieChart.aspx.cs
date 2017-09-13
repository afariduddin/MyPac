using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EngineData;

public partial class Dashboard_StudentPieChart : System.Web.UI.Page
{
    protected string JS;
    protected string ChartTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        DA da = new DA();
        DataTable tbl = null;
        if (Request.QueryString["r"] == "year")
        {
            DateTime dtf = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime dtt = DateTime.Today;
            tbl = da.Student.GetNumberByCampus(dtf, dtt);
            ChartTitle = "STUDENT ENROLLMENT BY CAMPUS (YEAR " + DateTime.Today.Year + ")";
        }
        else if (Request.QueryString["r"] == "todate")
        {
            tbl = da.Student.GetNumberByCampus();
            ChartTitle = "STUDENT ENROLLMENT BY CAMPUS (TO-DATE)";
        }

        if (tbl != null)
        {
            string js = "";
            foreach (DataRow dr in tbl.Rows)
            {
                js += "['" + dr[1].ToString() + "', " + dr[0].ToString() + "],";
            }
            JS = js;
        }
    }
}