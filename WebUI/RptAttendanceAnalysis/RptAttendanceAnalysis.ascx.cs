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

public partial class RptAttendanceAnalysis : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptAttendanceAnalysisAjaxGateway));
        AjaxLib.RegisterController("RptAttendanceAnalysis", ClientID);
    }
}

public class RptAttendanceAnalysisAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public PagedDataList<RptAttendanceAnalysisTable> GetResult(DateTime IntakeDF, DateTime IntakeDT, string fullname, int gender, 
        int contractType, string[] sponsorID, string[] tsp, bool isPaging, int[] col, bool[] asc, int pg)
    {
        //Hardcode the column ordering
        List<int> cols = new List<int>();
        cols.Add(3); //Fullname
        cols.Add(12); //Paper Code
        col = cols.ToArray();

        DA da = new DA();

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }

        string tspJoin = "";
        foreach (string tt in tsp)
        {
            tspJoin += tt + ",";
        }

        //string courseJoin = "";
        //foreach (string tt in course)
        //{
        //    courseJoin += tt + ",";
        //}


        PagedDataList<RptAttendanceAnalysisTable> lis = da.Reports.SearchAttendanceAnalysis(IntakeDF, IntakeDT, fullname, gender, 
            contractType, sponsorIDJoin, tspJoin, isPaging, BuildSqlOrders(col, asc), pg);
        
        if (!isPaging) HttpContext.Current.Session["RptAttendanceAnalysis"] = lis;

        return lis;
    }
}