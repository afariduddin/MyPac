using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EngineVariable;

public class LoggedInUser
{
    public string UserName = "";
    public string FullName = "";
    public Guid UserGroupID = Guid.Empty;
    public Guid UserAccountID = Guid.Empty;
    public Guid CandidateID = Guid.Empty;
    public string AccessRight = "";
    public LoggedInUser()
    {

    }
}