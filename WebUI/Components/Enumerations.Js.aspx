<%@ Page Language="C#" %>
<%@ Import Namespace="Teq" %>
<%@ Import Namespace="Teq.Ajax" %>
<%@ Import Namespace="EngineVariable" %>

<%  
    if( AjaxLib.CheckLastModified(Context, typeof(ApplicationOverallStatusType).Assembly) ) AjaxLib.Build304Header(Response);
    else
    {
        AjaxLib.BuildFlagScriptsHeader(Response);
        Response.Write(AjaxLib.BuildFlagScripts<MaritalStatus>());
        Response.Write(AjaxLib.BuildFlagScripts<EventType>());
        Response.Write(AjaxLib.BuildFlagScripts<CourseType>());
        Response.Write(AjaxLib.BuildFlagScripts<YesNoType>());
        Response.Write(AjaxLib.BuildFlagScripts<NationalityType>());
        Response.Write(AjaxLib.BuildFlagScripts<GenderType>());
        Response.Write(AjaxLib.BuildFlagScripts<GlobalSettingType>());
        Response.Write(AjaxLib.BuildFlagScripts<VoluntaryHourStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<ApplicationStatus>());
        Response.Write(AjaxLib.BuildFlagScripts<ContractType>());
        Response.Write(AjaxLib.BuildFlagScripts<LevelStartPQ>());
        Response.Write(AjaxLib.BuildFlagScripts<AssessmentStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<AssessmentSubjectType>());
        Response.Write(AjaxLib.BuildFlagScripts<PartTimerAssessmentStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<PartTimerAssessmentSubjectType>());
        Response.Write(AjaxLib.BuildFlagScripts<FinalisedApplicationStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<StatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<StudentStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<StudentCourseStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<EmailNotificationStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<AssessmentInterviewStatus>());
        Response.Write(AjaxLib.BuildFlagScripts<StudentCourseProgressType>());
        Response.Write(AjaxLib.BuildFlagScripts<CoachingStatusType>());
        Response.Write(AjaxLib.BuildFlagScripts<PermissionType>());
        Response.Write(AjaxLib.BuildFlagScripts<PartTimerInterviewType>());
        Response.Write(AjaxLib.BuildFlagScripts<PartTimerSessionType>());
        Response.Write(AjaxLib.BuildFlagScripts<CandidateType>());
        Response.Write(AjaxLib.BuildFlagScripts<ApplicationOverallStatusType>());
        
        // custom
        //Type[] enums =
        //{
        //    typeof()
        //};
        //foreach( Type en in enums )
        //{
        //    Response.Write("Enums." + en.Name + " = [];" + Environment.NewLine);
        //    Response.Write("Enums." + en.Name + ".Label = Enums_GetLabel;" + Environment.NewLine);

        //    object[] vals = (object[])(Enum.GetValues(en).Cast<object>().ToArray());
        //    foreach( object v in vals )
        //    {
        //        Response.Write("Enums." + en.Name + "[\"" + ((char)(int)v) + "\"] = \"" + Lib.SplitCamelString(v.ToString()) + "\";" + Environment.NewLine);
        //    }
        //}
    }

%>
