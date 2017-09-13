using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using System.Web;
using Teq.Ajax;
using Teq.Data;

public partial class RptAlumniVoluntaryHourSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptAlumniVoluntaryHourSummaryAjaxGateway));
        AjaxLib.RegisterController("RptAlumniVoluntaryHourSummary", ClientID);
    }
}

public class RptAlumniVoluntaryHourSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public PagedDataList<RptAlumniVoluntaryHourSummaryTable> GetResult(DateTime EntrollmentDateFrom, DateTime EntrollmentDateTo,
    string fullname, int gender, string email, string contactNum, int contractType, string[] sponsorID, int status, bool isPaging, int[] col, bool[] asc, int pg)
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


        PagedDataList<RptAlumniVoluntaryHourSummaryTable> lis = da.Reports.SearchAlumniVoluntaryHourSummary(EntrollmentDateFrom, EntrollmentDateTo,
    fullname, gender, email, contactNum, contractType, sponsorIDJoin, status, isPaging, BuildSqlOrders(col, asc), pg);

        if (!isPaging) HttpContext.Current.Session["RptAlumniVoluntaryHourSummary"] = lis;

        return lis;
    }
}