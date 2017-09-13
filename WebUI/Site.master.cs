using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        string title = "MyPac Database Management System";
        if (aspxContent.Page.Title != "") Page.Title = aspxContent.Page.Title + " :: " + title;
        else Page.Title = title;
        base.OnPreRender(e);
    }
}
