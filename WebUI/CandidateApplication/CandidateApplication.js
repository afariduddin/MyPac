/// <reference path="../Components/Debug/teq.js" />
/// <reference path="../Components/Debug/teq.widgets.js" />
/// <reference path="../Components/Debug/jquery-1.8.3.js" />
/// <reference path="../Components/Debug/jquery-ui-1.9.2.custom.js" />
/// <reference path="../Components/ErrorCodes.Js.aspx" />
/// <reference path="../Components/Flags.Js.aspx" />
/// <reference path="../Components/local.js" />

local.CandidateApplicationPageController = function (idPrefix)
{
    //#region Elements

    var btnSaveDraft = "#" + idPrefix + "_btnSaveDraft";
    var btnSubmit = "#" + idPrefix + "_btnSubmit";
    var btnSaveDraft2 = "#" + idPrefix + "_btnSaveDraft2";
    var btnSubmit2 = "#" + idPrefix + "_btnSubmit2";
    var dpDOB = "#" + idPrefix + "_dpDOB";
    var dpPQStartDate = "#" + idPrefix + "_dpPQStartDate";
    var dpPQDealine = "#" + idPrefix + "_dpPQDealine";
    var dpNextExam = "#" + idPrefix + "_dpNextExam";
    var linkFileIC = "#" + idPrefix + "_FileIC";
    var linkFileBirthCertificate = "#" + idPrefix + "_FileBirthCertificate";
    var linkFileAcademicTranscript = "#" + idPrefix + "_FileAcademicTranscript";
    var linkFilePassport = "#" + idPrefix + "_FilePassport";
    var linkFilePQAcceptanceLetter = "#" + idPrefix + "_FilePQAcceptanceLetter";
    var ApplicationID = '';

    //#endregion

    //#region Initialize
    this.Initialize = Initialize;
    function Initialize()
    {
        $(btnSaveDraft +","+ btnSaveDraft2).button({
            icons: { primary: null, secondary: 'ui-icon-disk' }
        }).click(function ()
        {

            return false;
        });
        $(btnSubmit + "," + btnSubmit2).button({
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
            showButtonPanel: true,
            yearRange: "-100:+5"
        });
        teq.Common.SetDatePickerClearable($(dpIDStrList));
        $(dpDOB).datepicker("setDate", "1-Jan-1989");

       

        //alert('hi 2')
    }
    //#endregion

    //#region Activated
    this.Activated = Activated;
    function Activated()
    {
        local.AdvancedSearchMode = null;

        var navigationTrails = [];
        var navigationTrail = {
            Name: "Home > New Application",
            Link: local.aspxContent_Dashboard1
        };

        navigationTrails.push(navigationTrail);
        local.navigationTrailsBuild(navigationTrails);
        LoadData();
        $('#divSubmitted').hide();
        $('#divMain').show();
        $('#divThankYou').hide();
        
        $(btnSubmit + "," + btnSubmit2).show();
        $(btnSaveDraft + "," + btnSaveDraft2).show();

       // alert($('#Course').val());
 
    }
    function LoadData()
    {
        CandidateApplicationManagementAjaxGateway.GetApplication(function (res) {
            if (res.error == null) {
                if (res.value == null) {

                   // alert('no application record.');
                    CandidateApplicationManagementAjaxGateway.GetCandidate(function (res) {
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
                else {
                   

                    if (res.value.Application_Submitted)
                    {
                        var now = new Date();
                       // alert(interval);
                        //alert(daydiff(res.value.Application_SubmittedDate, now));
                        if (daydiff(res.value.Application_SubmittedDate, now) < interval || (res.value.Application_OverallStatus == FlagCodes.ApplicationOverallStatusType.Active ||res.value.Application_OverallStatus == FlagCodes.ApplicationOverallStatusType.Completed))
                        {
                            $('#divSubmitted').show();
                            $('#divMain').hide();
                            $('#divThankYou').hide();
                            $('#PreviousSubmission').text(teq.Common.FormatDate(res.value.Application_SubmittedDate));
                            var myDate = new Date(res.value.Application_SubmittedDate.getTime() + (interval * 24 * 60 * 60 * 1000));
                            $('#NextSubmission').text(teq.Common.FormatDate(myDate));
                            
                            $(btnSubmit + "," + btnSubmit2).hide();
                            $(btnSaveDraft + "," + btnSaveDraft2).hide();
                        } else
                        {
                            CandidateApplicationManagementAjaxGateway.GetCandidate(function (res) {
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
                    } else
                    {
                        FillData(null, res.value);
                        //ApplicationData.Application_ID
                    }
                   // if (res.value.Application_Submitted && res.value.Application_UpdatedDate)
                   
                   // alert('with application record');
                }

            }
        });
    }
    function daydiff(first, second) {
        return Math.round((second - first) / (1000 * 60 * 60 * 24));
    }
    function FillData(CandidateData, ApplicationData)
    {
        if(CandidateData !=null)
        {
            $('#ApplicationID').val(GuidEmpty);
            $('#FullName').val(CandidateData.Candidate_FullName);
            $(dpDOB).val(teq.Common.FormatDate(CandidateData.Candidate_DOB));
            //alert(CandidateData.Candidate_Gender);
            $("input[name=Gender]").filter('[value=' + CandidateData.Candidate_Gender + ']').prop('checked', true);
            $('#IC').val(CandidateData.Candidate_ICNumber);
            $('#Address1').val(CandidateData.Candidate_Address1);
            $('#Address2').val(CandidateData.Candidate_Address2);
            $('#City').val(CandidateData.Candidate_City);
            $('#Postcode').val(CandidateData.Candidate_Postcode);
            $('#State').val(CandidateData.Candidate_State);
            //$('#Country').val(CandidateData.Candidate_Country);
            $('#Country').val(CandidateData.Country_ID);
            $('#PhoneNumberPrefix').val(CandidateData.Candidate_PhonePrefix);
            $('#PhoneNumber').val(CandidateData.Candidate_PhoneNumber);
            $('#MobilePhoneNumberPrefix').val(CandidateData.Candidate_MobilePhonePrefix);
            $('#MobilePhoneNumber').val(CandidateData.Candidate_MobilePhoneNumber);
            //alert(CandidateData.Candidate_Email);
            $('#Email').val(CandidateData.Candidate_Email);
            $('#FatherName').val(CandidateData.Candidate_FatherGuardianName);
            $('#FatherIC').val(CandidateData.Candidate_FatherGuardianIC);
            $('#MotherName').val(CandidateData.Candidate_MotherGuardianName);
            $('#MotherIC').val(CandidateData.Candidate_MotherGuardianIC);
            $('#CombinedHouseholdIncome').val();
            $('#CurrentFieldOfStudy').val();
            $('#University').val();
            $('#CGPA').val();

            if( $("input[name=WithPQ]:checked").val() == "0")
            {
               
            }
            $('#PQRegNo').val();
            $(dpPQStartDate).val();
            $('#LevelStartPQ input:checked').val();

            $(dpPQDealine).val();
            $("input[name=NextExam]:checked").val();
            $(dpNextExam).val
            $("input[name=studyPreferences]:checked").val();
            $('#TSP').val();
            $('#ScholarshipProvider').val();
            $('#CostCoveredByScholarship').val();
            $('#Agree').prop('checked', false);
            $('#PDPA1').prop('checked', false);
            $('#PDPA2').prop('checked', false);
            //resume
            if (CandidateData.Candidate_CurrentlyEmployed) {
                $("input[name=CurrentlyEmployed]").filter('[value=0]').prop('checked', true);
            }
            else {
                $("input[name=CurrentlyEmployed]").filter('[value=1]').prop('checked', true);
            }
            $('#Sector').val(CandidateData.Candidate_Sector);
            $('#Position').val(CandidateData.Candidate_Position);
            $('#Department').val(CandidateData.Candidate_Department);
           

        }else if (ApplicationData != null)
        {
            $('#Course').val(ApplicationData.Course_ID);
            CandidateApplicationManagementAjaxGateway.GetSubjectList(ApplicationData.Course_ID, function (res) {
                if (res.error == null) {
                    // alert(res.value);
                    $('#Subject').checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value));
                    CandidateApplicationManagementAjaxGateway.GetSelectedSubjectList($('#ApplicationID').val(), function (res) {
                        if (res.error == null) {

                            for (var x = 0; x < res.value.length; x++) {
                                //if (x > 0)
                                    $("#Subject input").filter('[value=' + res.value[x] + ']').prop('checked', true);
                            }


                        }
                    });
                   
                }
            });
            CandidateApplicationManagementAjaxGateway.GetTSPList($('#Course').val(), function (res) {
                $('#TSP').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
                $('#TSP').val(ApplicationData.TSP_ID);
            });

            CandidateApplicationManagementAjaxGateway.GetYear(function (res) {
                $('#IntakeYear').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
                $('#IntakeYear').val(ApplicationData.Application_IntakeYear);
            });

            CandidateApplicationManagementAjaxGateway.GetMonth(ApplicationData.TSP_ID, ApplicationData.Application_IntakeYear, function (res) {
                $('#IntakeMonth').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
                $('#IntakeMonth').val(ApplicationData.Application_IntakeMonth);
            });

            $('#ApplicationID').val(ApplicationData.Application_ID);
            $('#FullName').val(ApplicationData.Application_FullName);
            $(dpDOB).val(teq.Common.FormatDate(ApplicationData.Application_DOB));
            $("input[name=Gender]").filter('[value=' + ApplicationData.Application_Gender + ']').prop('checked', true);
            $('#IC').val(ApplicationData.Application_IdentificationNumber);
            $('#Address1').val(ApplicationData.Application_Address1);
            $('#Address2').val(ApplicationData.Application_Address2);
            $('#City').val(ApplicationData.Application_City);
            $('#Postcode').val(ApplicationData.Application_Postcode);
            $('#State').val(ApplicationData.Application_State);
            //$('#Country').val(ApplicationData.Application_Country);
            $('#Country').val(ApplicationData.Country_ID);
            $('#PhoneNumberPrefix').val(ApplicationData.Application_PhonePrefix);
            $('#PhoneNumber').val(ApplicationData.Application_PhoneNumber);
            $('#MobilePhoneNumberPrefix').val(ApplicationData.Application_MobilePhonePrefix);
            $('#MobilePhoneNumber').val(ApplicationData.Application_MobilePhoneNumber);

            $('#Email').val(ApplicationData.Application_Email);
            $('#FatherName').val(ApplicationData.Application_FatherName);
            $('#FatherIC').val(ApplicationData.Application_FatherIdentification);
            $('#MotherName').val(ApplicationData.Application_MotherName);
            $('#MotherIC').val(ApplicationData.Application_MotherIdentification);
            $('#CombinedHouseholdIncome').val(ApplicationData.Application_CombinedHouseholdIncome);
            $('#CurrentFieldOfStudy').val(ApplicationData.Application_CurrentFieldOfStudy);
            $('#University').val(ApplicationData.Application_University);
            $('#CGPA').val(ApplicationData.Application_CGPA);
          
            if (ApplicationData.Application_PQQualification)
            {
                $("input[name=WithPQ]").filter('[value=0]').prop('checked', true);
            }
            else
            {
                $("input[name=WithPQ]").filter('[value=1]').prop('checked', true);
            }
            $('#PQRegNo').val(ApplicationData.Application_PGRegistrationNumber);
            $(dpPQStartDate).val(teq.Common.FormatDate(ApplicationData.Application_PQStartDate));
           // $("#LevelStartPQ input").filter('[value=' + ApplicationData.Application_PQLevelStart + ']').prop('checked', true);
            $("#LevelStartPQ").val(ApplicationData.Application_PQLevelStart);
            $(dpPQDealine).val(teq.Common.FormatDate(ApplicationData.Application_PQDeadline));
            //$("input[name=NextExam]:checked").val();
            if (ApplicationData.Application_RegisteredNextExam) {
                $("input[name=NextExam]").filter('[value=0]').prop('checked', true);
            }
            else {
                $("input[name=NextExam]").filter('[value=1]').prop('checked', true);
            }

            $(dpNextExam).val(teq.Common.FormatDate(ApplicationData.Application_NextExamSession));

            //$("input[name=studyPreferences]:checked").val();
            $("input[name=studyPreferences]").filter('[value=' + ApplicationData.Application_ContractType + ']').prop('checked', true);

            //alert(ApplicationData.TSP_ID);
         
            $('#ScholarshipProvider').val(ApplicationData.Application_ScholarshipProvider);
            $('#CostCoveredByScholarship').val(ApplicationData.Application_ScholarshipCost);
       
            $('#Agree').prop('checked', ApplicationData.Application_DeclarationAgree);
            $('#PDPA1').prop('checked', ApplicationData.Application_ConfirmReceiveMyPACNotice);
            $('#PDPA2').prop('checked', ApplicationData.Application_ConfirmAgreeTermsAndCondition);

           // $('#linkFileIC').
           // $(linkFileIC).text(ApplicationData.Application_IdentificationImage);
            //alert(ApplicationData.Application_IdentificationImage);
            $(linkFileIC).text(ApplicationData.Application_IdentificationImage);
            $(linkFileIC).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_IdentificationFile);
            $(linkFileIC).attr("download", ApplicationData.Application_IdentificationImage);

            $(linkFileBirthCertificate).text(ApplicationData.Application_BirthCertificateImage);
            $(linkFileBirthCertificate).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_BirthCertificateFile);
            $(linkFileBirthCertificate).attr("download", ApplicationData.Application_BirthCertificateImage);

            $(linkFileAcademicTranscript).text(ApplicationData.Application_AcademicTranscriptImage);
            $(linkFileAcademicTranscript).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_AcademicTranscriptFile);
            $(linkFileAcademicTranscript).attr("download", ApplicationData.Application_AcademicTranscriptImage);

            $(linkFileBirthCertificate).text(ApplicationData.Application_BirthCertificateImage);
            $(linkFileBirthCertificate).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_BirthCertificateFile);
            $(linkFileBirthCertificate).attr("download", ApplicationData.Application_BirthCertificateImage);

            $(linkFilePassport).text(ApplicationData.Application_PassportSizeImage);
            $(linkFilePassport).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_PassportSizeFile);
            $(linkFilePassport).attr("download", ApplicationData.Application_PassportSizeImage);

            $(linkFilePQAcceptanceLetter).text(ApplicationData.Application_PQAcceptanceImage);
            $(linkFilePQAcceptanceLetter).attr("href", "/UserFiles/UploadedAttachments/" + ApplicationData.Application_ID + "/" + ApplicationData.Application_PQAcceptanceFile);
            $(linkFilePQAcceptanceLetter).attr("download", ApplicationData.Application_PQAcceptanceImage);

            if (ApplicationData.Application_CurrentlyEmployed) {
                $("input[name=CurrentlyEmployed]").filter('[value=0]').prop('checked', true);
            }
            else {
                $("input[name=CurrentlyEmployed]").filter('[value=1]').prop('checked', true);
            }
            $('#Sector').val(ApplicationData.Application_CompanySector);
            $('#Position').val(ApplicationData.Application_CompanyPosition);
            $('#Department').val(ApplicationData.Application_CompanyDepartment);
            $('#CompanyName').val(ApplicationData.Application_CompanyName);
            $('#CompanyContact').val(ApplicationData.Application_CompanyContact);
            $('#CompanyAddress').val(ApplicationData.Application_CompanyAddress);
        }
    }
    //#endregion
}