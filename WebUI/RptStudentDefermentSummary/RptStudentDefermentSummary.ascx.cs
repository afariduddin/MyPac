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


public partial class RptStudentDefermentSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptStudentDefermentSummaryAjaxGateway));
        AjaxLib.RegisterController("RptStudentDefermentSummary", ClientID);
    }
}

public class RptStudentDefermentSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(int yearfrom, int yearto, string[] tsp, string[] course, bool isExport)
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

        DataTable content = da.Reports.SearchStudentDefermentSummary(yearfrom, yearto, tspJoin, courseJoin);
        DataTable header = content.DefaultView.ToTable(true, "Reason");
        DataTable availableIntake = content.DefaultView.ToTable(true, "Intake");

        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("Intake");
        foreach (DataRow drHeader in header.Rows)
        {
            DataColumn dc = new DataColumn(drHeader["Reason"].ToString());
            dc.DefaultValue = 0;
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }
        dt.Columns.Add("Total").DefaultValue = "0";

        #region Populate All Intake inside the DataTableResult
        foreach (DataRow drIntake in availableIntake.Rows)
        {
            DataRow drData = dt.NewRow();
            drData["Intake"] = drIntake["Intake"].ToString();
            dt.Rows.Add(drData);
        }
        #endregion

        foreach (DataRow drData in dt.Rows)
        {
            foreach (DataRow drContent in content.Rows)
            {
                string currentIntake = drData["Intake"].ToString().ToLower();
                if (drContent["Intake"].ToString().ToLower() == currentIntake)
                {
                    drData[drContent["Reason"].ToString()] = drContent["TotalDeferred"].ToString();
                }
            }

            int Total = 0;
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                DataColumn dc = dt.Columns[i];
                int val = (int)drData[dc];
                Total += val;
            }
            drData["Total"] = Total.ToString();
        }
        if (!isExport) HttpContext.Current.Session["RptStudentDefermentSummary"] = dt;

        return dt;
    }

    [AjaxMethod]
    public string GetPieChart()
    {
        if (HttpContext.Current.Session["RptStudentDefermentSummary"] == null) return "";

        DataTable dt = (DataTable)HttpContext.Current.Session["RptStudentDefermentSummary"];

        Chart Chart1 = new Chart();
        Chart1.Series.Add("Default");

        List<String> xValues = new List<String>();
        List<String> yValues = new List<String>();

        for (int i = 1; i < dt.Columns.Count - 1; i++)
        {
            DataColumn dc = dt.Columns[i];
            xValues.Add(dc.ColumnName);

            var sum = dt.Compute("Sum([" + dc.ColumnName + "])", "");
            yValues.Add(sum.ToString());
        }
        Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

        Chart1.Series["Default"].Palette = ChartColorPalette.BrightPastel;
        foreach (DataPoint p in Chart1.Series["Default"].Points)
        {
            if (p.YValues[0] > 0) p.LabelFormat = "#,###"; //0,000,000 
        }

        //Labels' Font Style
        Chart1.Series["Default"].IsValueShownAsLabel = true;
        Chart1.Series["Default"].Font = new Font("Trebuchet MS", 8f, FontStyle.Bold);
        Chart1.Series["Default"]["PointWidth"] = "0.80";

        //Background
        Chart1.ChartAreas.Add("ChartArea1");
        Chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
        Chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.Transparent;
        Chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
        Chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;

        //For Displaying Chart Title
        //if(dt.Rows.Count != 0)
        //{
        //    Title Area1Title = new Title("Deferment", Docking.Top, new Font("Verdana", 20, FontStyle.Bold), Color.Black);
        //    Area1Title.DockedToChartArea = Chart1.ChartAreas["ChartArea1"].Name;
        //    Chart1.Titles.Add(Area1Title);
        //}

        //Customizing the labels
        Chart1.Series[0]["PieLabelStyle"] = "Outside";
        Chart1.Series[0].BorderWidth = 1;
        Chart1.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
        Chart1.Series[0].Label = "#VALX, #VALY, #PERCENT{P2}"; //xValues, yValues, percentage value in 2 decimal pts

        //Add a legend to the chart and dock it to the bottom-center
        Chart1.Legends.Add("Legend1");
        Chart1.Legends[0].Enabled = true;
        Chart1.Legends[0].Docking = Docking.Bottom;
        Chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
        Chart1.Series[0].LegendText = "#VALX";

        Chart1.Width = 600;
        Chart1.Height = 450;

        Chart1.AntiAliasing = AntiAliasingStyles.All;
        Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

        string fileName = DateTime.Now.Ticks.ToString() + ".png";
        Chart1.SaveImage(ConfigurationManager.AppSettings["ChartImageFolder"] + "\\" + fileName, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
        return ConfigurationManager.AppSettings["ChartImageWebFolder"] + "/" + fileName;
    }
}