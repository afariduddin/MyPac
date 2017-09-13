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

public partial class RptExamAnalysis : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptExamAnalysisAjaxGateway));
        AjaxLib.RegisterController("RptExamAnalysis", ClientID);
    }
}

public class RptExamAnalysisAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(DateTime IntakeDF, DateTime IntakeDT, int contractType, string[] sponsorID, string[] tsp, string courseid, bool isExport)
    {
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

        DataTable content = da.Reports.SearchExamAnalysis(IntakeDF, IntakeDT, sponsorIDJoin, contractType, tspJoin, courseid);
        DataTable header = content.DefaultView.ToTable(true, "Paper");
        DataTable availSponsor = content.DefaultView.ToTable(true, "Sponsor");

        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("Sponsor");
        foreach (DataRow drHeader in header.Rows)
        {
            DataColumn dc = new DataColumn(drHeader["Paper"].ToString());
            dc.DefaultValue = "";
            //dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }

        //Populate data, based on available Sponsors
        //FOUR row record per sponsor
        foreach(DataRow drSponsor in availSponsor.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["Sponsor"] = drSponsor["Sponsor"].ToString();
            dt.Rows.Add(dr);

            DataRow dr2 = dt.NewRow();
            dr2["Sponsor"] = "Passed";
            //Loop and insert correspondant data into each Column
            foreach(DataRow drContent in content.Rows)
            {
                if(drContent["Sponsor"].ToString() == drSponsor["Sponsor"].ToString())
                {
                    dr2[drContent["Paper"].ToString()] = drContent["TotalPass"].ToString();
                }
            }
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["Sponsor"] = "Failed";
            //Loop and insert correspondant data into each Column
            foreach (DataRow drContent in content.Rows)
            {
                if (drContent["Sponsor"].ToString() == drSponsor["Sponsor"].ToString())
                {
                    dr3[drContent["Paper"].ToString()] = drContent["TotalFail"].ToString();
                }
            }
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["Sponsor"] = "Total";
            //Loop and insert correspondant data into each Column
            foreach (DataRow drContent in content.Rows)
            {
                if (drContent["Sponsor"].ToString() == drSponsor["Sponsor"].ToString())
                {
                    dr4[drContent["Paper"].ToString()] = int.Parse(drContent["TotalPass"].ToString()) + int.Parse(drContent["TotalFail"].ToString());
                }
            }
            dt.Rows.Add(dr4);
        }



        if (isExport) HttpContext.Current.Session["RptExamAnalysis"] = dt;

        return dt;
    }
}