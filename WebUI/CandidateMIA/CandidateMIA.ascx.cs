using AjaxPro;
using EngineData;
using EngineVariable;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teq;
using Teq.Ajax;

public partial class CandidateMIA : PageUserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxLib.RegisterController("CandidateMIA", ClientID);
        Utility.RegisterTypeForAjax(typeof(CandidateMIAAjaxGateway));
    }
}
public class CandidateMIAAjaxGateway : AjaxGatewayBase
{
    private DA da = new DA();
    public CandidateMIAAjaxGateway()
    {
    }
    [AjaxMethod]
    public CandidateMinimalizedEntity GetCandidate()
    {
        if (WebLib.LoggedInUser != null)
        {

            CandidateRow row = da.Candidate.GetByCandidateID(WebLib.LoggedInUser.CandidateID);

            if (row != null)
            {
                CandidateMinimalizedEntity ett = new CandidateMinimalizedEntity(row);
                return ett;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
        //WebLib.LoggedInUser.CandidateID
    }
    [AjaxMethod]
    public ErrorCodes[] SaveCandidate(CandidateData data)
    {
        List<ErrorCodes> errs = new List<ErrorCodes>();
        //AddError(errs, VerifyModDate(ett.ModifiedDate));
        AddError(errs, VerifyRequiredField(data.MIAAccountNumber, ErrorCodes.CandidateMIA_MIARequired));
        AddError(errs, VerifyAttachment(data.FileMIA, data.CurrentFileMIA, ErrorCodes.CandidateMIA_ICFileRequired));
        AddError(errs, (!data.Agree) ? ErrorCodes.CandidateMIA_AgreeRequired : ErrorCodes.GEN_NoError);

   

        ActionLog log = WebLib.CreateLog("Save MIA.");


        if (errs.Count == 0)
        {
            CandidateRow dr = null;
            dr = da.Candidate.GetByCandidateID(data.CandidateID);
        
            if(dr != null)
            {
                dr.Candidate_MIA = data.MIAAccountNumber;
            }
               
            dr.Candidate_UpdatedBy = WebLib.LoggedInUser.UserName;
            dr.Candidate_UpdatedDate = DateTime.Now;


            #region File Upload

            string folderPath = ConfigurationManager.AppSettings["UploadedMIA"];
            string defaultSavePath = folderPath + "\\" + dr.Candidate_ID;
            Directory.CreateDirectory(defaultSavePath);

            if (data.FileMIA != null)
            {
                string ext = Path.GetExtension(data.FileMIA.OriginalName);
                //string oldPath = defaultSavePath + "\\" + ett.Entity.Application_IdentificationImage;
                string filename = data.FileMIA.TemporaryName + ext;
                string savePath = defaultSavePath + "\\" + filename;
                //if (File.Exists(oldPath)) File.Delete(oldPath);
                dr.Candidate_MIAImage = data.FileMIA.OriginalName;
                dr.Candidate_MIAFile = filename;
                try
                {
                    File.Move(AjaxLib.FileUploadTempPath + data.FileMIA.TemporaryName, savePath);
                }
                catch(Exception ex)
                {

                }
               
            }

           
            #endregion


            da.Candidate.Update(dr, log);

            log.Save();
        }

        return errs.ToArray();
    }
   
    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(string value, ErrorCodes Error)
    {
        if (String.IsNullOrEmpty(value)) return Error;
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(DateTime? value, ErrorCodes Error)
    {
        if (!value.HasValue)
        {
            return Error;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyRequiredField(Guid value, ErrorCodes Error)
    {
        if (value == Guid.Empty)
        {
            return Error;
        }
        else return ErrorCodes.GEN_NoError;
    }

    [AjaxMethod]
    public ErrorCodes VerifyDropDownField(string value, string defaultValue, ErrorCodes Error)
    {
        if (String.IsNullOrEmpty(value)) return Error;
        else if (value == defaultValue) return Error;
        else return ErrorCodes.GEN_NoError;
    }




    void AddError(List<ErrorCodes> lis, ErrorCodes err)
    {
        if (err.Code == ErrorCodes.GEN_NoError.Code) ;
        else lis.Add(err);
    }




    [AjaxMethod]
    public ErrorCodes VerifyAttachment(UploadedFile attachment, string originalfilename, ErrorCodes code)
    {
        if (attachment == null && String.IsNullOrEmpty(originalfilename)) return code;
        else return ErrorCodes.GEN_NoError;
    }
}

public class CandidateData
{
    public Guid CandidateID = Guid.Empty;
    public string MIAAccountNumber = "";
    public bool Agree = false;
    public UploadedFile FileMIA;
    public string CurrentFileMIA;
}