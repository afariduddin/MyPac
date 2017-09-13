using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopupWarningLetter : System.Web.UI.Page
{
    protected Guid WarningLetterID
    {
        get
        {
            try
            {

                return Guid.Parse(Request["ID"]);
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        DA da = new DA();
        WarningLetterRow row = da.WarningLetter.GetByWarningLetter_ID(WarningLetterID);
        if (row != null)
        {
            litContent.Text = row.WarningLetter_Body;
        }
        else
        {
            litContent.Text = "<h1>Content not found.</h1>";
        }
    }
}