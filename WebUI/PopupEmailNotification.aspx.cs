using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopupEmailNotification : System.Web.UI.Page
{
    protected Guid EmailNotificationID
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
        ActionLog log = WebLib.CreateLog("Read Email Notification.");
        EmailNotificationRow row = da.EmailNotification.GetByEmailNotification_ID(EmailNotificationID);
        if(row != null)
        {
            litContent.Text = row.EmailNotification_EmailContent;
            row.EmailNotification_IsRead = true;
            da.EmailNotification.Update(row, log);
            log.Save();
        }else
        {
            litContent.Text = "<h1>Content not found.</h1>";
        }
    }
}