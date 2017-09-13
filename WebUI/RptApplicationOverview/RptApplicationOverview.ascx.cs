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
using EngineVariable;

public partial class RptApplicationOverview : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptApplicationOverviewAjaxGateway));
        AjaxLib.RegisterController("RptApplicationOverview", ClientID);
    }
}

public class RptApplicationOverviewAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public PagedDataList<DataTable> GetResult(DateTime IntakeDF, DateTime IntakeDT, bool isExport, int[] col, bool[] asc, int pg)
    {

        DA da = new DA();

        //Generate Multiple Months Record based on Date Range
        IntakeDF = new DateTime(IntakeDF.Year, IntakeDF.Month, 1);
        IntakeDT = new DateTime(IntakeDT.Year, IntakeDT.Month, 28);

        DataTable dt = new DataTable();
        int pageSize = 9999; //Just max it
        double TotalRegister = 0;
        double TotalApply = 0;
        double TotalSuccess = 0;
        double TotalRejected = 0;
        double TotalActive = 0;
        double TotalCompleted = 0;
        double TotalTerminated = 0;
        double TotalWithdrawn = 0;

        while (true) //Generate Record Month by Month
        {
            if (IntakeDF > IntakeDT) break;

            DataTable dt2 = da.Reports.SearchApplicationOverview(IntakeDF.Month, IntakeDF.Year);
            if(dt.Rows.Count == 0 && dt2.Rows.Count > 0 ) //First Time, Populate the Data
            {
                dt.Columns.Add("Month Year");
                foreach (DataColumn dc in dt2.Columns)
                {
                    dt.Columns.Add(dc.ColumnName, dc.DataType);
                }

            }

            if (dt2.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                DataRow dr2 = dt2.Rows[0];

                dr["Month Year"] = IntakeDF.ToString("MMM yyyy");
                foreach(DataColumn dc in dt2.Columns)
                {
                    dr[dc.ColumnName] = dr2[dc];
                    #region Total Up Records
                    if (dc.ColumnName.IndexOf("Register") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalRegister += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Apply") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalApply += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Total Success") > -1 )
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalSuccess += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Reject") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalRejected += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Active") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalActive += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Complete") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalCompleted += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Terminate") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalTerminated += rst;
                    }
                    else if (dc.ColumnName.IndexOf("Withdrawn") > 0)
                    {
                        double rst = 0;
                        double.TryParse(dr2[dc].ToString(), out rst);

                        TotalWithdrawn += rst;
                    }
                    #endregion
                }

                dt.Rows.Add(dr);
            }

            IntakeDF = IntakeDF.AddMonths(1);
        }


        //Add Row for Total.
        DataRow drTotal = dt.NewRow();
        drTotal[0] = "TOTAL";
        drTotal[1] = TotalRegister;
        drTotal[2] = TotalApply;
        drTotal[3] = -1;
        drTotal[4] = TotalSuccess;
        drTotal[5] = TotalRejected;
        drTotal[6] = -1;
        drTotal[7] = TotalActive;
        drTotal[8] = TotalCompleted;
        drTotal[9] = TotalTerminated;
        drTotal[10] = TotalWithdrawn;
        drTotal[11] = -1;

        dt.Rows.Add(drTotal);


        PagedDataList<DataTable> lis = new PagedDataList<DataTable>(dt, dt.Rows.Count, pageSize, pg);

        if (isExport)
        {
            HttpContext.Current.Session["RptApplicationOverview"] = dt;
        }



        return lis;
    }

}