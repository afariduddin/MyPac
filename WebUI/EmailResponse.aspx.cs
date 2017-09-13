using AjaxPro;
using EngineCommon;
using EngineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq.Ajax;
using Teq;
using EngineVariable;


public partial class EmailResponse : System.Web.UI.Page
{
    protected EmailResponseType ResponseType
    {
        get
        {
            try
            {

                if (EmailResponseType.AssessmentInvitation.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.AssessmentInvitation;
                }
                else if (EmailResponseType.CLO.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.CLO;
                }
                else if (EmailResponseType.InterviewInvitation.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.InterviewInvitation;
                }
                else if (EmailResponseType.LO.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.LO;
                }
                else if (EmailResponseType.PartTimerAssessment.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.PartTimerAssessment;
                }
                else if (EmailResponseType.PartTimerCDP.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.PartTimerCDP;
                }
                else if (EmailResponseType.PartTimerInterview.Code.ToString() == Request["ResponseType"])
                {
                    return EmailResponseType.PartTimerInterview;
                }
                else
                {
                    return EmailResponseType.Unknown;
                }
            }
            catch
            {
                return EmailResponseType.Unknown;
            }
            //EmailResponseType
        }
    }
    protected Guid ApplicationID
    {
        get
        {
            try
            {

               return Guid.Parse(Request["ApplicationID"]);
            }
            catch
            {
                return Guid.Empty;
            }
            //EmailResponseType
        }
    }
    protected bool Accept
    {
        get
        {
            try
            {

                return bool.Parse(Request["Accept"]);
            }
            catch
            {
                return false;
            }
            //EmailResponseType
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxLib.IncludeCoreScripts();
        Utility.RegisterTypeForAjax(typeof(EmailResponseAjaxGateway));
        DA da = new DA();
        ApplicationRow applicationRow = da.Application.GetByApplication_ID(ApplicationID);
        AssessmentResultTable assessmentResultTbl = da.AssessmentResult.GetByApplication_ID(ApplicationID);
        ActionLog log = WebLib.CreateLog("Email Response.");
        if (applicationRow != null)
        {
            if (ResponseType == EmailResponseType.AssessmentInvitation)
            {
                if (applicationRow.Application_Status == (short)ApplicationStatus.SessionAccepted || applicationRow.Application_Status == (short)ApplicationStatus.SessionRejected || applicationRow.Application_Status == (short)ApplicationStatus.SessionAssigned)
                {
                    applicationRow.Application_Status = (Accept) ? (short)ApplicationStatus.SessionAccepted : (short)ApplicationStatus.SessionRejected;
                    applicationRow.Application_IsAssessmentSessionAccepted = Accept;
                    da.Application.Update(applicationRow, log);
                    litMessage.Text = "Thanks. Your application is being set to " + ((Accept) ? "Session Accepted" : "Session Rejected") + ".";
                    //Accept - ApplicationStatus.SessionAccepted (Application Table)
                    //Reject - ApplicationStatus.SessionRejected(Application Table)
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }

            }
            else if (ResponseType == EmailResponseType.CLO)
            {
                //Accept - AssessmentStatusType.Complete(AssessmentResult Table)
                //Accept - ApplicationOverallProgressType.PTAssessment(Application Table) If Part Time
                //Accept - ApplicationOverallProgressType.Finalised(Application Table) If Full Time

                //Reject - AssessmentStatusType.Rejected(AssessmentResult Table)
                //Reject - ApplicationOverallStatusType.Inactive(Application Table)

                if (assessmentResultTbl.Rows.Count > 0 && (assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.Complete
                    || assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.Rejected
                    || assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.CLOSent))
                {
                    if (Accept)
                    {
                        if (assessmentResultTbl.Rows.Count > 0)
                        {
                            assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status = (short)AssessmentStatusType.Complete;
                            da.AssessmentResult.Update(assessmentResultTbl.GetAssessmentResultRow(0), log);
                            if (applicationRow.Application_ContractType == (short)ContractType.FullTime)
                            {
                                applicationRow.Application_OverallProgress = (short)ApplicationOverallProgressType.Finalised;
                                applicationRow.Application_FinalisedStatus = (short)FinalisedApplicationStatusType.Pending;
                                litMessage.Text = "Thanks. Your application is being set to " + ApplicationOverallProgressType.Finalised.Name + ".";
                            }
                            else
                            {
                                PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(applicationRow.Application_ID);
                                PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                                if (dtPartTimerAssessmentResult.Rows.Count > 0)
                                {
                                    litMessage.Text = "Thanks. Your application is being set to " + ApplicationOverallProgressType.PTAssessment.Name + ".";
                                    return;
                                }
                                else
                                    drPartTimerAssessmentResult = new PartTimerAssessmentResultTable().NewPartTimerAssessmentResultRow();

                                drPartTimerAssessmentResult.Application_ID = applicationRow.Application_ID;
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_ID = Guid.NewGuid();
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_CreatedBy = "";
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_CreatedDate = DateTime.Now;
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedBy = "";
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_UpdatedDate = DateTime.Now;
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_IsDeleted = false;
                                drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)EngineVariable.PartTimerAssessmentStatusType.Pending;

                                da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, log);

                                applicationRow.Application_OverallProgress = (short)ApplicationOverallProgressType.PTAssessment;
                                litMessage.Text = "Thanks. Your application is being set to " + ApplicationOverallProgressType.PTAssessment.Name + ".";
                            }
                            da.Application.Update(applicationRow, log);

                        }
                        else
                        {
                            litMessage.Text = "Opps... There is an error occur while processing it.";
                        }
                    }
                    else
                    {
                        if (assessmentResultTbl.Rows.Count > 0)
                        {
                            assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status = (short)AssessmentStatusType.Rejected;
                            da.AssessmentResult.Update(assessmentResultTbl.GetAssessmentResultRow(0), log);
                            applicationRow.Application_OverallStatus = (short)ApplicationOverallStatusType.Inactive;
                            da.Application.Update(applicationRow, log);
                            litMessage.Text = "Thanks. Your application is being set to " + AssessmentStatusType.Rejected.Name + ".";
                        }
                        else
                        {
                            litMessage.Text = "Opps... There is an error occur while processing it.";
                        }
                    }
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }


            }
            else if (ResponseType == EmailResponseType.InterviewInvitation)
            {
                //Accept - AssessmentStatusType.InterviewAccepted(AssessmentResult Table)
                //Reject - AssessmentStatusType.InterviewRejected(AssessmentResult Table)

                if (assessmentResultTbl.Rows.Count > 0 && (assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.InterviewAccepted
                    || assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.InterviewInvited
                    || assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status == (short)AssessmentStatusType.InterviewRejected))
                {

                    if (assessmentResultTbl.Rows.Count > 0)
                    {
                        assessmentResultTbl.GetAssessmentResultRow(0).AssessmentResult_Status = (Accept) ? (short)AssessmentStatusType.InterviewAccepted : (short)AssessmentStatusType.InterviewRejected;
                        da.AssessmentResult.Update(assessmentResultTbl.GetAssessmentResultRow(0), log);
                        litMessage.Text = "Thanks. Your application is being set to " + ((Accept) ? AssessmentStatusType.InterviewAccepted.Name : AssessmentStatusType.InterviewRejected.Name) + ".";


                    }
                    else
                    {
                        litMessage.Text = "Opps... There is an error occur while processing it.";
                    }
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }

            }
            else if (ResponseType == EmailResponseType.LO)
            {
                //Accept - FinalisedApplicationStatusType.Confirmed(Application Table)

                //Reject - FinalisedApplicationStatusType.StudentReject(Application Table)
                //Reject - ApplicationOverallStatusType.Inactive(Application Table)

                if (applicationRow.Application_FinalisedStatus == (short)FinalisedApplicationStatusType.Confirmed
                    || applicationRow.Application_FinalisedStatus == (short)FinalisedApplicationStatusType.StudentReject
                    || applicationRow.Application_FinalisedStatus == (short)FinalisedApplicationStatusType.LOIssued)
                {
                    if (Accept)
                    {
                        applicationRow.Application_FinalisedStatus = (short)FinalisedApplicationStatusType.Confirmed;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.Confirmed.Name + ".";

                    }
                    else
                    {
                        applicationRow.Application_FinalisedStatus = (short)FinalisedApplicationStatusType.StudentReject;
                        applicationRow.Application_OverallStatus = (short)ApplicationOverallStatusType.Inactive;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.StudentReject.Name + ".";
                    }
                    da.Application.Update(applicationRow, log);
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }

            }
            else if (ResponseType == EmailResponseType.PartTimerAssessment)
            {
                PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(ApplicationID);
                PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                if (dtPartTimerAssessmentResult.Rows.Count > 0)
                    drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];
                else
                {
                    litMessage.Text = "Opps... There is an error occur while processing it.";
                    return;
                }

                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.AssessmentInvitationConfirmed ||

                     drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.AssessmentInvitationRejected ||
                      drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.AssessmentInvitationSent)
                {
                    if (Accept)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.AssessmentInvitationConfirmed;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.Confirmed.Name + ".";

                    }
                    else
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.AssessmentInvitationRejected;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.StudentReject.Name + ".";
                    }
                    da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, log);
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }

            }
            else if (ResponseType == EmailResponseType.PartTimerCDP)
            {
                PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(ApplicationID);
                PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                if (dtPartTimerAssessmentResult.Rows.Count > 0)
                    drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];
                else
                {
                    litMessage.Text = "Opps... There is an error occur while processing it.";
                    return;
                }

                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.CDPInvitationConfirmed
                    || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.CDPInvitationRejected
                    || drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.CDPInvitationSent)
                {
                    if (Accept)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.CDPInvitationConfirmed;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.Confirmed.Name + ".";

                    }
                    else
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.CDPInvitationRejected;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.StudentReject.Name + ".";
                    }
                    da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, log);
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }

            }
            else if (ResponseType == EmailResponseType.PartTimerInterview)
            {
                PartTimerAssessmentResultTable dtPartTimerAssessmentResult = da.PartTimerAssessmentResult.GetByApplication_ID(ApplicationID);
                PartTimerAssessmentResultRow drPartTimerAssessmentResult = null;
                if (dtPartTimerAssessmentResult.Rows.Count > 0)
                    drPartTimerAssessmentResult = (PartTimerAssessmentResultRow)dtPartTimerAssessmentResult.Rows[0];
                else
                {
                    litMessage.Text = "Opps... There is an error occur while processing it.";
                    return;
                }

                if (drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.InterviewInvitationConfirmed||
                    drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.InterviewInvitationRejected ||
                    drPartTimerAssessmentResult.PartTimerAssessmentResult_Status == (short)PartTimerAssessmentStatusType.InterviewInvitationSent)
                {
                    if (Accept)
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.InterviewInvitationConfirmed;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.Confirmed.Name + ".";

                    }
                    else
                    {
                        drPartTimerAssessmentResult.PartTimerAssessmentResult_Status = (short)PartTimerAssessmentStatusType.InterviewInvitationRejected;
                        litMessage.Text = "Thanks. Your application is being set to " + FinalisedApplicationStatusType.StudentReject.Name + ".";
                    }
                    da.PartTimerAssessmentResult.Update(drPartTimerAssessmentResult, log);
                }
                else
                {
                    litMessage.Text = "Sorry, we can not perform this action due to the link is expired.";
                }


            }
            else
            {
                litMessage.Text = "Opps... There is an error occur while processing it.";
            }
        }
        else
        {
            litMessage.Text = "Opps... There is an error occur while processing it.";
        }
        log.Save();
    }
}
public class EmailResponseAjaxGateway : AjaxGatewayBase
{
    private DA da = new DA();


}

