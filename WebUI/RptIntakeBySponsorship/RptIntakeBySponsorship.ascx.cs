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


public partial class RptIntakeBySponsorship : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptIntakeBySponsorshipAjaxGateway));
        AjaxLib.RegisterController("RptIntakeBySponsorship", ClientID);
    }
}
public class RptIntakeBySponsorshipAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(int yearfrom, int yearto, string[] tsp, string[] sponsor, bool isExport)
    {
        DA da = new DA();
        string tspJoin = "";
        foreach (string tt in tsp)
        {
            tspJoin += tt + ",";
        }

        string sponsorJoin = "";
        foreach (string tt in sponsor)
        {
            sponsorJoin += tt + ",";
        }

        DataTable content = da.Reports.SearchIntakeBySponsorship(yearfrom, yearto, tspJoin, sponsorJoin);

        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("Intake");
        foreach (string s in sponsor)
        {
            SponsorRow drSponsor = da.Sponsor.GetBySponsor_ID(Guid.Parse(s));
            string ColName = "";
            if (drSponsor != null)
                ColName = drSponsor.Sponsor_Code;

            DataColumn dc = new DataColumn(ColName);
            dc.DefaultValue = 0;
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }

        dt.Columns.Add("Total").DefaultValue = 0;

        #region Populate All Intake inside the DataTableResult
        foreach (DataRow drContent in content.Rows)
        {
            bool isFound = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Intake"].ToString() == drContent["Intake"].ToString())
                {
                    dr[drContent["Sponsor_Code"].ToString()] = int.Parse(dr[drContent["Sponsor_Code"].ToString()].ToString()) + (int)drContent["ActiveCount"];
                    dr["Total"] = int.Parse(dr["Total"].ToString()) + int.Parse(drContent["ActiveCount"].ToString());
                    isFound = true;
                }
            }

            if (!isFound)
            {
                DataRow d = dt.NewRow();
                d["Intake"] = drContent["Intake"];
                d[drContent["Sponsor_Code"].ToString()] = (int)drContent["ActiveCount"];
                d["Total"] = (int)drContent["ActiveCount"];

                dt.Rows.Add(d);
            }
        }
        #endregion
        if (!isExport) HttpContext.Current.Session["RptIntakeBySponsorship"] = dt;

        return dt;
    }

    [AjaxMethod]
    public string GetColumnChart()
    {
        if (HttpContext.Current.Session["RptIntakeBySponsorship"] == null) return "";

        DataTable dt = (DataTable)HttpContext.Current.Session["RptIntakeBySponsorship"];

        Chart Chart1 = new Chart();
        //Chart1.Series.Add("Default");

        List<String> xValues = new List<String>();
        List<String> yValues = new List<String>();

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    //for (int y = 1; y < dt.Columns.Count - 1; i++)
        //    //{
        //        DataRow dr = dt.Rows[i];
        //        xValues.Add(dr[0].ToString());
        //        //var sum = dt.Compute("Sum(" + dc.ColumnName + ")", "");
        //        //yValues.Add(sum.ToString());
        //    //}
        //}


        for (int y = 1; y < dt.Columns.Count - 1; y++)
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
                //dp.Label = dt.Columns[y].ColumnName;
                //dp.Name = dt.Columns[y].ColumnName + Environment.NewLine + dr[y].ToString();
                dp.SetValueXY(dr["Intake"], dr[y]);
                s.Points.Add(dp);
            }

            Chart1.Series.Add(s);
        }

        //Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        //Chart1.Series["Default"].ChartType = SeriesChartType.Bar;
        //Chart1.Series["Default"].Palette = ChartColorPalette.BrightPastel;
        //foreach (DataPoint p in Chart1.Series["Default"].Points)
        //{
        //    if (p.YValues[0] > 0) p.LabelFormat = "#,###"; //0,000,000 
        //}
        //Chart1.Series["Default"].LabelBackColor = Color.FromArgb(64, 165, 191, 228);


        //Chart1.Series["Default"].IsValueShownAsLabel = true;
        //Chart1.Series["Default"].Font = new Font("Trebuchet MS", 8f, FontStyle.Bold);
        //Chart1.Series["Default"]["PointWidth"] = "0.80"; // spaces btw bars

        Chart1.ChartAreas.Add("ChartArea1");
        Chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.Transparent;
        Chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
        Chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;

        //Chart1.ChartAreas["ChartArea1"].AxisY.Enabled = AxisEnabled.False;
        Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
        //Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
        //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -90;
        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Trebuchet MS", 8f, FontStyle.Regular);

        Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Intake";
        Chart1.ChartAreas["ChartArea1"].AxisY.Title = "";

        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 0; //RotateX
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 0; //RotateY
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 0; //RotateZ
        //Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;

        Chart1.Width = 950;
        Chart1.Height = 450;
        //Chart1.BackColor = Color.Transparent;

        Chart1.AntiAliasing = AntiAliasingStyles.All;
        Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

        Chart1.Legends.Add("Legend1");
        //Chart1.Legends["Legend1"].DockedToChartArea = "Default";

        string fileName = DateTime.Now.Ticks.ToString() + ".png";
        Chart1.SaveImage(ConfigurationManager.AppSettings["ChartImageFolder"] + "\\" + fileName, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
        return ConfigurationManager.AppSettings["ChartImageWebFolder"] + "/" + fileName;
    }
}