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

public partial class RptStudentProgressSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(RptStudentProgressSummaryAjaxGateway));
        AjaxLib.RegisterController("RptStudentProgressSummary", ClientID);
    }
}

public class RptStudentProgressSummaryAjaxGateway : AjaxGatewayBase
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

        DataTable content = da.Reports.SearchStudentProgressSummary(IntakeDF, IntakeDT, fullname, sponsorIDJoin, gender, contractType);
        //DataTable content = GenerateFakeResult();
        DataTable header = content.DefaultView.ToTable(true, "ProgressDate");

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
        dt.Columns.Add("EndDate");
        dt.Columns.Add("Completed Paper");
        dt.Columns.Add("ExemptedPaper");
        dt.Columns.Add("Remaining Paper");

        foreach (DataRow drHeader in header.Rows)
        {
            string month = drHeader["ProgressDate"].ToString();

            DataColumn dc = new DataColumn(month+"-Paper");
            dc.DefaultValue = "";
            //dc.DataType = typeof(int);
            dt.Columns.Add(dc);

            dc = new DataColumn(month + "-Attn");
            dc.DefaultValue = "";
            //dc.DataType = typeof(int);
            dt.Columns.Add(dc);

            dc = new DataColumn(month + "-Result");
            dc.DefaultValue = "";
            //dc.DataType = typeof(int);
            dt.Columns.Add(dc);
        }

        int pageSize = LibraryVariable.Page_Size;


        foreach(DataRow drStudent in availStudent.Rows)
        {
            DataRow dr = dt.NewRow();

            foreach (DataRow drContent in content.Rows)
            {

                if (drContent["ICNumber"].ToString() == drStudent["ICNumber"].ToString()
                    && drContent["PaperName"].ToString() == drStudent["PaperName"].ToString()) //Unique by IC and Papers
                {
                    dr["FullName"] = drContent["FullName"];
                    dr["ICNumber"] = drContent["ICNumber"];
                    dr["Cohort"] = drContent["Cohort"];
                    dr["StartDate"] = drContent["StartDate"];
                    dr["EndDate"] = drContent["EndDate"];
                    dr["Completed Paper"] = drContent["Completed Paper"];
                    dr["ExemptedPaper"] = drContent["ExemptedPaper"];
                    dr["Remaining Paper"] = drContent["Remaining Paper"];

                    if (dr["StartDate"].ToString() != "")
                    {
                        DateTime dtime = DateTime.Parse(dr["StartDate"].ToString());
                        string ooi = dtime.ToString("dd MMM yyyy");
                        dr["StartDate"] = ooi;
                    }
                    if (dr["EndDate"].ToString() != "")
                    {
                        DateTime dtime = DateTime.Parse(dr["EndDate"].ToString());
                        string ooi = dtime.ToString("dd MMM yyyy");
                        dr["EndDate"] = ooi;
                    }
                    //More to go...

                    string month = drContent["ProgressDate"].ToString();
                    if (drContent["TotalClass"].ToString() != "0")
                    {
                        dr[month + "-Paper"] = drContent["PaperName"];
                        dr[month + "-Attn"] = drContent["Attendance"];
                    }
                    if (drContent["Final"].ToString() == "True")
                    {
                        dr[month + "-Paper"] = drContent["PaperName"];
                        //dr[month + "-Result"] = drContent["Score"];
                        if (!string.IsNullOrEmpty(drContent["Score"].ToString()))
                        {
                            dr[month + "-Result"] = Math.Round(double.Parse(drContent["Score"].ToString()));
                        }
                    }
                }
            }

            ////Get Last Row record. If same Student, merge the papers columns instead.
            if (dt.Rows.Count > 0)
            {
                DataRow previousRow = dt.Rows[dt.Rows.Count - 1];
                if (previousRow["ICNumber"].ToString() == dr["ICNumber"].ToString())
                {
                    for(int cnt=6; cnt < dt.Columns.Count; cnt++) //Merge column value from index 6 onwards
                    {
                        if(previousRow[cnt].ToString()!="" && dr[cnt].ToString()!= "")
                        {
                            string temp = previousRow[cnt].ToString();
                            temp += "<br>" + dr[cnt].ToString();

                            previousRow[cnt] = temp;
                        }
                        else if(previousRow[cnt].ToString() == "" && dr[cnt].ToString() != "")
                        {
                            previousRow[cnt] = dr[cnt].ToString();
                        }
                    }
                }
                else
                {
                    dt.Rows.Add(dr);
                }
            }
            else {
                dt.Rows.Add(dr);
            }

            //dt.Rows.Add(dr);
        }

        List<string> cols2 = new List<string>();
        foreach(DataColumn dc in dt.Columns)
        {
            cols2.Add(dc.ColumnName);
        }
        
        //Manual Populate Data based on paging...
        DataTable dt2 = dt.Clone();
        int initialRec = (pg - 1) * pageSize;
        for(int c=initialRec; c < (pg * pageSize); c++)
        {
            if (c >= dt.Rows.Count) break;
            DataRow drData = dt.Rows[c];

            DataRow dr = dt2.NewRow();
            foreach(DataColumn dc in dt.Columns)
            {
                string columnName = dc.ColumnName;
                dr[columnName] = drData[columnName];
            }

            dt2.Rows.Add(dr);
        }


        PagedDataList<DataTable> lis = new PagedDataList<DataTable>(dt2, dt.Rows.Count, pageSize, pg);

        if (!isPaging)
        {
            HttpContext.Current.Session["RptStudentProgressSummary"] = dt;
        }



        return lis;
    }

    private DataTable GenerateFakeResult()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("FullName");
        dt.Columns.Add("ICNumber");
        dt.Columns.Add("Cohort");
        dt.Columns.Add("StartDate");
        dt.Columns.Add("EndDate");
        dt.Columns.Add("ExemptedPaper");
        dt.Columns.Add("PaperName");
        dt.Columns.Add("ProgressDate");
        dt.Columns.Add("TotalClass");
        dt.Columns.Add("Attendance");
        dt.Columns.Add("Final");
        dt.Columns.Add("Score");

        Random r = new Random();

        for(int i=1; i< 350; i++) // Generate Students
        {
            string name = "Student " + i;
            string ic = "IC No " + i;
            for(int j=1; j<2;j++) // Generate Papers
            {
                string paper = "P" + j;
                for(int k = 1; k < 7; k++) //Generate Progress Months
                {
                    string mth = DateTime.Now.AddMonths(k).ToString("MMM yyyy");

                    DataRow dr = dt.NewRow();
                    dr["FullName"] = name;
                    dr["ICNumber"] = ic;
                    dr["PaperName"] = paper;
                    dr["ProgressDate"] = mth;
                    dr["TotalClass"] = r.Next(3, 10);
                    dr["Attendance"] = r.Next(41, 100);
                    dr["Final"] = "False";
                    dr["Score"] = 0;
                    dt.Rows.Add(dr);

                    //Add another row for final result, for last month
                    if(k == 6)
                    {
                        dr = dt.NewRow();
                        dr["FullName"] = name;
                        dr["ICNumber"] = ic;
                        dr["PaperName"] = paper;
                        dr["ProgressDate"] = mth;
                        dr["TotalClass"] = 0;
                        dr["Attendance"] = 0;
                        dr["Final"] = "True";
                        dr["Score"] = r.Next(20, 100); ;
                        dt.Rows.Add(dr);
                    }
                }
            }
        }


        return dt;

    }
}