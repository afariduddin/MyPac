using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq.Ajax;

public partial class ReportStudentSummary : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxLib.RegisterController("ReportStudentSummary", ClientID);
    }
}