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


public partial class RptStudentWithdrawalSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptStudentWithdrawalSummaryAjaxGateway));
        AjaxLib.RegisterController("RptStudentWithdrawalSummary", ClientID);
    }
}

public class RptStudentWithdrawalSummaryAjaxGateway : AjaxGatewayBase
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

        DataTable content = da.Reports.SearchStudentWithdrawalSummary(yearfrom, yearto, tspJoin, sponsorJoin);
        DataTable header = content.DefaultView.ToTable(true, "Course_Code");
        DataTable availableIntake = content.DefaultView.ToTable(true, "Intake");

        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("Intake");
        foreach (DataRow drHeader in header.Rows)
        {
            DataColumn dc = new DataColumn(drHeader["Course_Code"].ToString());
            dc.DefaultValue = 0;
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }
        dt.Columns.Add("Total_Withdrawal").DefaultValue = "0";

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
                    drData[drContent["Course_Code"].ToString()] = drContent["Withdrawal"].ToString();
                }
            }

            int Total = 0;
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                DataColumn dc = dt.Columns[i];
                int val = (int)drData[dc];
                Total += val;
            }
            drData["Total_Withdrawal"] = Total.ToString();
        }
        if (!isExport) HttpContext.Current.Session["RptStudentWithdrawalSummary"] = dt;

        return dt;
    }

    [AjaxMethod]
    public string GetColumnChart()
    {
        if (HttpContext.Current.Session["RptStudentWithdrawalSummary"] == null) return "";

        DataTable dt = (DataTable)HttpContext.Current.Session["RptStudentWithdrawalSummary"];

        Chart Chart1 = new Chart();
        Chart1.Series.Add("Default");

        List<String> xValues = new List<String>();
        List<String> yValues = new List<String>();

        for(int i=1; i< dt.Columns.Count-1; i++)
        {
            DataColumn dc = dt.Columns[i];
            xValues.Add(dc.ColumnName);
            var sum = dt.Compute("Sum("+dc.ColumnName+")", "");
            yValues.Add(sum.ToString());
        }

        Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        Chart1.Series["Default"].ChartType = SeriesChartType.Column;
        Chart1.Series["Default"].Palette = ChartColorPalette.BrightPastel;
        foreach (DataPoint p in Chart1.Series["Default"].Points)
        {
            if (p.YValues[0] > 0) p.LabelFormat = "#,###"; //0,000,000 
        }
        //Chart1.Series["Default"].LabelBackColor = Color.FromArgb(64, 165, 191, 228);


        Chart1.Series["Default"].IsValueShownAsLabel = true;
        Chart1.Series["Default"].Font = new Font("Trebuchet MS", 8f, FontStyle.Bold);
        Chart1.Series["Default"]["PointWidth"] = "0.80"; // spaces btw bars

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

        Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Course";
        Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total Withdrawal";


        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 0; //RotateX
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 0; //RotateY
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 0; //RotateZ
        Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;

        Chart1.Width = 950;
        Chart1.Height = 450;
        //Chart1.BackColor = Color.Transparent;

        Chart1.AntiAliasing = AntiAliasingStyles.All;
        Chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

        string fileName = DateTime.Now.Ticks.ToString() + ".png";
        Chart1.SaveImage(ConfigurationManager.AppSettings["ChartImageFolder"] + "\\" + fileName, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
        return ConfigurationManager.AppSettings["ChartImageWebFolder"] + "/" + fileName;
    }
}