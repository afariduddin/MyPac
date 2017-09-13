using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EngineData;

public class WebLib
{
    public static LoggedInUser LoggedInUser
    {
        get
        {
            string key = "LoggedInUser";
            if( HttpContext.Current.Session[key] != null )
            {
                LoggedInUser u = (LoggedInUser)HttpContext.Current.Session[key];
                HttpContext.Current.Session.Remove(key);
                HttpContext.Current.Session.Add(key, u);
                return u;
            }
            else return null;
        }
        set
        {
            string key = "LoggedInUser";
            HttpContext.Current.Session.Remove(key);
            if( value != null ) HttpContext.Current.Session.Add(key, value);
            HttpContext.Current.Session.Timeout = 60;
        }
    }
    public static ActionLog CreateLog(string operation)
    {
        if (LoggedInUser == null) return new ActionLog("", HttpContext.Current.Request.UserHostAddress, operation);
        return new ActionLog(LoggedInUser.UserName, HttpContext.Current.Request.UserHostAddress, operation);
    }
    /// <summary>
    /// not fully done, need to check againt role.
    /// </summary>
    /// <param name="Role"></param>
    /// <returns></returns>
    public static bool CheckPermission(EngineVariable.PermissionType Permission)
    {
        if (WebLib.LoggedInUser == null)
        {
            return false;
        }
        else
        {
            string[] AccessRightCollection = LoggedInUser.AccessRight.Split(new char[] { ';' });
            foreach (string AccessRight in AccessRightCollection)
            {
                if (AccessRight == Permission.Code.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        //else
        //{
        //    if (WebLib.LoggedInUser.TheUserRole == UserRole.Administrator && Role !=StaticRoles.Payment_Approval)//payment approval can not override by administrator rights
        //    {
        //        return ErrorCodes.GEN_NoError;
        //    }
        //    else
        //    {
        //        if (WebLib.LoggedInUser.Roles.Contains(Role))
        //        {
        //            return ErrorCodes.GEN_NoError;
        //        }
        //        else
        //        {
        //            return ErrorCodes.GEN_NoPermission;
        //        }
        //    }
        //}
    }
    public static void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code);
        else lis.Add(err);
    }

    public static void ResponseExcelHeader(string strFilename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();

        HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;

        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\""  +strFilename+"\"");

        HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    }
    public static void DownloadExcelTemplate(string path, string strFilename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();

        HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;

        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment; filename=\"" + strFilename+"\"");

        HttpContext.Current.Response.TransmitFile(path);
        HttpContext.Current.Response.End();
    }

    public static string GetDate(DateTime DT)
    {
    
        if (DT.Date == EngineVariable.LibraryVariable.Empty_DateTime.Date)
        {
            return "";
        }
        else
        {

            return DT.ToString(EngineVariable.LibraryVariable.Format_Date);
        }
    }
}