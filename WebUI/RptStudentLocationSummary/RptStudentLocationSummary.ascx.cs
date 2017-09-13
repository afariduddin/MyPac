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


public partial class RptStudentLocationSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptStudentLocationSummaryAjaxGateway));
        AjaxLib.RegisterController("RptStudentLocationSummary", ClientID);
    }
}

public class RptStudentLocationSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(int yearfrom, int yearto, bool isExport)
    {
        DA da = new DA();

        DataTable content = da.Reports.SearchStudentLocationSummary(yearfrom, yearto);
        DataTable header = content.DefaultView.ToTable(true, "Intake");
        
        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("State");
        foreach(DataRow drHeader in header.Rows)
        {
            DataColumn dc = new DataColumn(drHeader["Intake"].ToString());
            dc.DefaultValue = 0;
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }
        dt.Columns.Add("Total").DefaultValue="0";

        #region Populate All States inside the DataTableResult
        List<string> states = new List<string>();
        states.Add("Selangor");
        states.Add("Kuala Lumpur");
        states.Add("Sarawak");
        states.Add("Johor");
        states.Add("Penang");
        states.Add("Sabah");
        states.Add("Perak");
        states.Add("Pahang");
        states.Add("Negeri Sembilan");
        states.Add("Kedah");
        states.Add("Malacca");
        states.Add("Terengganu");
        states.Add("Kelantan");
        states.Add("Perlis");
        states.Add("Labuan");
        //states.Add("Others");
        foreach (string str in states)
        {
            DataRow drData = dt.NewRow();
            drData["State"] = str;
            dt.Rows.Add(drData);
        }
        #endregion

        foreach(DataRow drData in dt.Rows)
        {
            foreach(DataRow drContent in content.Rows)
            {
                string currentState = drData["State"].ToString().ToLower();
                //if(drContent["State"].ToString().ToLower() == currentState)
                //if (drContent["State"].ToString().ToLower().IndexOf(currentState) > -1)
                if (currentState.IndexOf(drContent["State"].ToString().ToLower()) > -1)
                {
                    drData[drContent["Intake"].ToString()] = drContent["TotalIntake"].ToString();
                }
            }

            int Total = 0;
            for(int i = 1; i < dt.Columns.Count-1; i++)
            {
                DataColumn dc = dt.Columns[i];                
                int val = (int)drData[dc];
                Total += val;
            }
            drData["Total"] = Total.ToString();
        }
        if (!isExport) HttpContext.Current.Session["RptStudentLocationSummary"] = dt;

        return dt;
    }


    [AjaxMethod]
    public string GetColumnChart()
    {
        if (HttpContext.Current.Session["RptStudentLocationSummary"] == null) return "";

        DataTable dt = (DataTable)HttpContext.Current.Session["RptStudentLocationSummary"];

        Chart Chart1 = new Chart();
        Chart1.Series.Add("Default");

        List<String> xValues = new List<String>();
        List<String> yValues = new List<String>();
        foreach (DataRow row in dt.Rows)
        {
            xValues.Add(row["State"].ToString());
            yValues.Add(row["Total"].ToString());
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

        Chart1.ChartAreas["ChartArea1"].AxisX.Title = "State";
        Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";


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