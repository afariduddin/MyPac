using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using Teq.Ajax;
using Teq.Data;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;


public partial class RptStudentIntakeSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptStudentIntakeSummaryAjaxGateway));
        AjaxLib.RegisterController("RptStudentIntakeSummary", ClientID);
    }
}

public class RptStudentIntakeSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(int yearfrom, int yearto, string[] tsp,  string[] course, string[] sponsor, string[] statuses, bool isPaging, int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        string tspJoin = "";
        foreach (string tt in tsp)
        {
            tspJoin += tt + ",";
        }

        string courseJoin = "";
        foreach (string tt in course)
        {
            courseJoin += tt + ",";
        }

        string sponsorJoin = "";
        foreach (string tt in sponsor)
        {
            sponsorJoin += tt + ",";
        }
        string statusJoin = "";
        foreach (string tt in statuses)
        {
            statusJoin += tt + ",";
        }

        DataTable content = da.Reports.SearchStudentIntakeSummary(yearfrom, yearto,  tspJoin, courseJoin, sponsorJoin, statusJoin, isPaging, BuildSqlOrders(col, asc), pg);

        DataTable dt = new DataTable();
        dt.Columns.Add("Intake");
        dt.Columns.Add("TSP");
        foreach (string s in sponsor)
        {
            SponsorRow drSponsor = da.Sponsor.GetBySponsor_ID(Guid.Parse(s));
            if (drSponsor == null)
            {
                DataColumn dc = new DataColumn("NA");
                dc.DefaultValue = 0;
                dc.DataType = typeof(int);
                dt.Columns.Add(dc);
            }
            else
            {
                DataColumn dc = new DataColumn(drSponsor.Sponsor_Code);
                dc.DefaultValue = 0;
                dc.DataType = typeof(int);
                dt.Columns.Add(dc);
            }
        }
        dt.Columns.Add("Total");

        #region Populate All Intake inside the DataTableResult
        foreach (DataRow drContent in content.Rows)
        {
            bool isFound = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Intake"].ToString() == drContent["Intake"].ToString() && dr["TSP"].ToString() == drContent["TSP"].ToString())
                {
                    string SponsorCode = "NA";
                    if (drContent["Sponsor_Code"].ToString() != "")
                        SponsorCode = drContent["Sponsor_Code"].ToString();

                    dr[SponsorCode] = int.Parse(drContent["ActiveCount"].ToString());
                    dr["Total"] = int.Parse(dr["Total"].ToString()) + int.Parse(drContent["ActiveCount"].ToString());
                    isFound = true;
                }
            }

            if (!isFound)
            {
                string SponsorCode = "NA";
                if (drContent["Sponsor_Code"].ToString() != "")
                    SponsorCode = drContent["Sponsor_Code"].ToString();

                DataRow d = dt.NewRow();
                d["Intake"] = drContent["Intake"];
                d["TSP"] = drContent["TSP"];
                d[SponsorCode] = int.Parse(drContent["ActiveCount"].ToString());
                d["Total"] = int.Parse(drContent["ActiveCount"].ToString());
                //d["Total"] = (int)drContent["ActiveCount"];

                dt.Rows.Add(d);
            }
        }
        #endregion
        if (!isPaging) HttpContext.Current.Session["RptStudentIntakeSummary"] = dt;

        return dt;
    }

    [AjaxMethod]
    public string GetColumnChart()
    {
        if (HttpContext.Current.Session["RptStudentIntakeSummary"] == null) return "";


        DataTable dt = (DataTable)HttpContext.Current.Session["RptStudentIntakeSummary"];

        Chart Chart1 = new Chart();
        //Chart1.Series.Add("Default");

        List<String> xValues = new List<String>();
        List<String> yValues = new List<String>();


        for (int y = 2; y < dt.Columns.Count - 1; y++)
        {
            Series s = new Series();
            s.ChartType = SeriesChartType.Column;
            s.Font = new Font("Trebuchet MS", 8f, FontStyle.Bold);
            s.IsValueShownAsLabel = true;
            //s.Label = dt.Columns[y].ColumnName;
            s.SetCustomProperty("DrawSideBySide", "True");
            s.IsVisibleInLegend = true;
            //s.Name = dt.Columns[y].ColumnName;
            s.Legend = "Legend1";
            s.LegendText = dt.Columns[y].ColumnName;
            foreach (DataRow dr in dt.Rows)
            {
                //s.Points.AddXY(dr["Intake"].ToString(), dr[y]);
                DataPoint dp = new DataPoint();
                //dp.Label = dt.Columns["Intake"].ColumnName + " - " + dt.Columns["TSP"];
                //dp.Name = dt.Columns["Intake"].ColumnName + " - " + dt.Columns["TSP"];
                string label = dr["Intake"].ToString() + " - " + dr["TSP"].ToString();
                dp.SetValueXY(label, dr[y]);
                s.Points.Add(dp);
            }

            Chart1.Series.Add(s);
        }

        //foreach (DataRow row in dt.Rows)
        //{
        //    xValues.Add(row["Intake"].ToString() + "-" + row["TSP"].ToString());
        //    yValues.Add((row["TSP"].ToString()));
        //}
        //Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        //Chart1.Series["Default"].ChartType = SeriesChartType.Column;
        //Chart1.Series["Default"].Palette = ChartColorPalette.BrightPastel;
        //foreach (DataPoint p in Chart1.Series["Default"].Points)
        //{
        //    if (p.YValues[0] > 0) p.LabelFormat = "#,###"; //0,000,000 
        //}
        //Chart1.Series["Default"].LabelBackColor = Color.FromArgb(64, 165, 191, 228);



        Chart1.ChartAreas.Add("ChartArea1");
        Chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.Transparent;
        Chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
        Chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;

        //Chart1.ChartAreas["ChartArea1"].AxisY.Enabled = AxisEnabled.False;
        Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
        //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;
        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Trebuchet MS", 8f, FontStyle.Regular);

        Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Intake - TSP";
        Chart1.ChartAreas["ChartArea1"].AxisY.Title = "";

        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;

        Chart1.Width = 950;
        Chart1.Height = 550;
        //Chart1.BackColor = Color.Transparent;

        Chart1.AntiAliasing = AntiAliasingStyles.All;
        Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

        Chart1.Legends.Add("Legend1");

        string fileName = DateTime.Now.Ticks.ToString() + ".png";
        Chart1.SaveImage(ConfigurationManager.AppSettings["ChartImageFolder"] + "\\" + fileName, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
        return ConfigurationManager.AppSettings["ChartImageWebFolder"] + "/" + fileName;
    }
}