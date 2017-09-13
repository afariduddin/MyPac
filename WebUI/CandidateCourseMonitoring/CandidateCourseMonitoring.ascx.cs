using AjaxPro;
using EngineData;
using System;
using System.Collections.Generic;
using System.Web;
using Teq.Ajax;
using Teq.Data;
using EngineCommon;

public partial class CandidateCourseMonitoring : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(CandidateCourseMonitoringAjaxGateway));
        AjaxLib.RegisterController("CandidateCourseMonitoring", ClientID);
    }

}

public class CandidateCourseMonitoringAjaxGateway : AjaxGatewayBase
{
    public CandidateCourseMonitoringAjaxGateway()
    {
    }
    [AjaxMethod]
    public PagedDataList<StudentCourseDetailTable> GetStudentProgressList(int[] col, bool[] asc, int pg)
    {
        DA da = new DA();

        Guid CandidateID = WebLib.LoggedInUser.CandidateID;

        PagedDataList<StudentCourseDetailTable> lis = da.StudentCourseDetail.Search(CandidateID, BuildSqlOrders(col, asc), pg);
        return lis;
    }

}