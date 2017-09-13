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

public partial class RptSuccessRateSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptSuccessRateSummaryAjaxGateway));
        AjaxLib.RegisterController("RptSuccessRateSummary", ClientID);
    }
}

public class RptSuccessRateSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public DataTable GetResult(DateTime IntakeDF, DateTime IntakeDT, DateTime EntrollmentDateFrom, DateTime EntrollmentDateTo,
    string fullname, int gender, string email, string contactNum, int contractType, string[] sponsorID, bool isExport)
    {
        DA da = new DA();

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }

        //string courseJoin = "";
        //foreach (string tt in course)
        //{
        //    courseJoin += tt + ",";
        //}


        DataTable lis = da.Reports.SearchSuccessRateSummary(IntakeDF, IntakeDT, EntrollmentDateFrom, EntrollmentDateTo,
    fullname, email, contactNum, sponsorIDJoin, gender, contractType);

        if (isExport) HttpContext.Current.Session["RptSuccessRateSummary"] = lis;

        return lis;
    }
}