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

public partial class RptSemesterSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptSemesterSummaryAjaxGateway));
        AjaxLib.RegisterController("RptSemesterSummary", ClientID);
    }
}

public class RptSemesterSummaryAjaxGateway : AjaxGatewayBase
{
    [AjaxMethod]
    public PagedDataList<DataTable> GetResult(DateTime IntakeDF, DateTime IntakeDT, string fullname, int gender,
        int contractType, string[] sponsorID, bool isPaging, int[] col, bool[] asc, int pg)
    {

        DA da = new DA();

        string sponsorIDJoin = "";
        foreach (string tt in sponsorID)
        {
            sponsorIDJoin += tt + ",";
        }

        DataTable content = da.Reports.SearchSemesterSummary(IntakeDF, IntakeDT, fullname, sponsorIDJoin, gender, contractType);
        //DataTable content = GenerateFakeResult();
        DataTable header = content.DefaultView.ToTable(true, "ProgressMonth");
        DataTable availablePaper = content.DefaultView.ToTable(true, "PaperName");

        List<string> cols = new List<string>();
        cols.Add("ICNumber");
        cols.Add("PaperName");

        DataTable availStudent = content.DefaultView.ToTable(true, cols.ToArray());

        //Prepare the formattted Data Table Content
        DataTable dt = new DataTable();
        dt.Columns.Add("FullName");
        dt.Columns.Add("ICNumber");
        dt.Columns.Add("Cohort");
        dt.Columns.Add("StartDate");
        dt.Columns.Add("Withdrawal");
        dt.Columns.Add("PaperName");

        foreach (DataRow drHeader in header.Rows)
        {
            string month = drHeader["ProgressMonth"].ToString();

            DataColumn dc = new DataColumn(month + "-Attn"); //"-Attn" as attendance indicator in JavaScript
            dc.DefaultValue = "";
            dt.Columns.Add(dc);
        }

        dt.Columns.Add("Total-Attn").DefaultValue = "0";

        for (int i = 1; i <= 4; i++)
        {
            DataColumn dc = new DataColumn("Test" + i.ToString() + "-Score"); //"-Score" as test indicator in JavaScript
            dc.DefaultValue = "";
            dt.Columns.Add(dc);
        }

        dt.Columns.Add("FinalResult");

        int pageSize = LibraryVariable.Page_Size;

        foreach (DataRow drStudent in availStudent.Rows)
        {
            DataRow dr = dt.NewRow();
            int totClass = 0;
            int attended = 0;
            int testCnt = 1;

            foreach (DataRow drContent in content.Rows)
            {

                if (drContent["ICNumber"].ToString() == drStudent["ICNumber"].ToString()
                    && drContent["PaperName"].ToString() == drStudent["PaperName"].ToString()) //Unique by IC and Papers
                {
                    dr["FullName"] = drContent["FullName"];
                    dr["ICNumber"] = drContent["ICNumber"];
                    dr["Cohort"] = drContent["Cohort"];
                    dr["StartDate"] = drContent["StartDate"];
                    dr["Withdrawal"] = drContent["Withdrawal"];
                    dr["PaperName"] = drContent["PaperName"];
                        
                    if (dr["StartDate"].ToString() != "")
                    {
                        DateTime dtime = DateTime.Parse(dr["StartDate"].ToString());
                        string temp = dtime.ToString("dd MMM yyyy");
                        dr["StartDate"] = temp;
                    }
                    //More to go...

                    string month = drContent["ProgressMonth"].ToString();
                    dr[month + "-Attn"] = drContent["AttendanceRate"];
                    totClass += int.Parse(drContent["TotalClass"].ToString());
                    attended += int.Parse(drContent["AttendedClass"].ToString());

                    //dr["Test" + testCnt.ToString() + "-Score"] = drContent["TestScore"];
                    if (!string.IsNullOrEmpty(drContent["TestScore"].ToString()))
                    {
                        dr["Test" + testCnt.ToString() + "-Score"] = Math.Round(double.Parse(drContent["TestScore"].ToString()));
                    }

                    if (testCnt < 4)
                    {
                        testCnt++;
                    }
                    else
                    {
                        testCnt = 1;
                    }
                    //dr["FinalResult"] = drContent["FinalResult"];
                    if (!string.IsNullOrEmpty(drContent["FinalResult"].ToString()))
                    {
                        dr["FinalResult"] = Math.Round(double.Parse(drContent["FinalResult"].ToString()));
                    }
                }

            }

            double totalAttendance = (double)totClass==0?0: ((double)attended / (double)totClass) * 100;
            dr["Total-Attn"] = totalAttendance.ToString();

            dt.Rows.Add(dr);
        }

        List<string> cols2 = new List<string>();
        foreach (DataColumn dc in dt.Columns)
        {
            cols2.Add(dc.ColumnName);
        }

        //Manual Populate Data based on paging...
        DataTable dt2 = dt.Clone();
        int initialRec = (pg - 1) * pageSize;
        for (int c = initialRec; c < (pg * pageSize); c++)
        {
            if (c >= dt.Rows.Count) break;
            DataRow drData = dt.Rows[c];

            DataRow dr = dt2.NewRow();
            foreach (DataColumn dc in dt.Columns)
            {
                string columnName = dc.ColumnName;
                dr[columnName] = drData[columnName];
            }

            dt2.Rows.Add(dr);
        }


        PagedDataList<DataTable> lis = new PagedDataList<DataTable>(dt2, dt.Rows.Count, pageSize, pg);

        if (!isPaging)
        {
            HttpContext.Current.Session["RptSemesterSummary"] = dt;
        }



        return lis;
    }
}