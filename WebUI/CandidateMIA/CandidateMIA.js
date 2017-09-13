/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateMIAPageController = function (idPrefix)
{
    //#region Elements

    var btnSaveDraft = "#" + idPrefix + "_btnSaveDraft";
    var btnSubmit = "#" + idPrefix + "_btnSubmit";
    var dpDOB = "#" + idPrefix + "_dpDOB";
    var dpPQStartDate = "#" + idPrefix + "_dpPQStartDate";
    var dpPQDealine = "#" + idPrefix + "_dpPQDealine";
    var dpNextExam = "#" + idPrefix + "_dpNextExam";
    var linkFileMIA = "#" + idPrefix + "_FileMIA";
    var chkAgree = "#" + idPrefix + "_Agree";
    //#endregion

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize()
    {
        $(btnSaveDraft).button({
            icons: { primary: null, secondary: 'ui-icon-disk' }
        }).click(function ()
        {

            return false;
        });
        $(btnSubmit).button({
            icons: { primary: null, secondary: 'ui-icon-circle-check' }
        }).click(function ()
        {
            
            return false;
        });

        var dpIDStrList = dpDOB + ", " + dpPQStartDate + "," + dpPQDealine + "," + dpNextExam;
        $(dpIDStrList).datepicker({
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            dateFormat: "d-M-yy",
            showButtonPanel: true
        });
        teq.Common.SetDatePickerClearable($(dpIDStrList));
        $(dpDOB).datepicker("setDate", "1-Jan-1989");
    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated()
    {
        local.AdvancedSearchMode = null;

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home > MIA Information",
            Link: local.aspxContent_Dashboard1
        };

        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);
        LoadData();
    }
    //#endregion

    function LoadData() {
        CandidateMIAAjaxGateway.GetCandidate(function (res) {
            if (res.error == null) {
                if (res.value == null) {


                    // alert('no candidate record.');

                }
                else {
                    //   alert('with candidate record');
                    FillData(res.value, null);
                }

            }
        });
    }
    function FillData(CandidateData) {
        if (CandidateData != null) {
            $('#CandidateID').val(CandidateData.Candidate_ID);
            $('#MIAAccountNumber').val(CandidateData.Candidate_MIA);
   
            $(chkAgree).prop('checked', true);


            $(linkFileMIA).text(CandidateData.Candidate_MIAImage);
            $(linkFileMIA).attr("href", "/UserFiles/UploadedMIA/" + CandidateData.Candidate_ID + "/" + CandidateData.Candidate_MIAFile);
            $(linkFileMIA).attr("download", CandidateData.Candidate_MIAImage);


        } 
    }
}