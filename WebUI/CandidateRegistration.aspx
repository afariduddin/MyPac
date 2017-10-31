<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateRegistration.aspx.cs" Inherits="CandidateRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration | MyPAC</title>
    <link rel="icon" href="Components/Css/global/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="Components/Css/css.css" />
    <link rel="stylesheet" type="text/css" href="Components/Css/StyleSheet.css" />
    <script src='https://www.google.com/recaptcha/api.js'></script>
        <script src='Components/custom.js'></script>
</head>

<body>
    <script>
 
       
    </script>
    <form id="mainform" runat="server">
		<table align="center">
            <tr>
                <td><img src="Resource/mypac_logo_small.png" /></td>
				<td width="20px"></td>
                <td style="vertical-align: middle"><h1>Candidate Registration Form</h1></td>
            </tr>
		</table>
        <input type="hidden" id="IsCaptchaVerified" name="IsCaptchaVerified" value="false" />
        <table border="0" id="tblFormRegister" width="60%" align="center">
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Personal Information</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table border="0" style="padding:0px !important; margin:0px;" cellspacing="0" cellpadding="0" >
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Full Name:</td>
                            <td><input type="text" placeholder="Full Name" class="standardform" id="FullName"/></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Date of Birth:</td>
                            <td><input type="text" id="dpDOB" placeholder="Date of Birth" class="standardform" readonly="readonly" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>IC Number (without dash):</td>
                            <td><input type="text" id="IC" placeholder="910101107189" class="standardform" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Nationality:</td>
                            <%--<td><label><input type="radio" name="Nationality" id="Nationality" value="0" />Malaysian</label></td>--%>
                            <td>
                                <select class="standardform" id="Nationality" />
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Gender:
                            </td>
                            <td>
                                <label><input type="radio" name="Gender" value="1" />Male</label>
                                <span class="gap"></span>
                                <label><input type="radio" name="Gender" value="2" />Female</label>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Bumiputra:</td>
                            <td>
                                <label><input type="radio" name="BumiPutra" value="0" />Yes</label>
                                <span class="gap"></span>
                                <label><input type="radio" name="BumiPutra" value="1" />No</label>
                            </td>
                        </tr>
                         <tr><td class="gap"></td></tr>
                         <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Ethnicity:</td>
                            <td><input list="dtEthnicity" type="text" id="Ethnicity" placeholder="MELAYU" class="standardform" />

                              <%--   <uc1:UniversityList runat="server" ID="UniversityList" />--%>
                                  <% Response.WriteFile("EthnicityList.html"); %>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Currently Employed:</td>
                            <td>
                                <label><input type="radio" name="CurrentlyEmployed" value="0" checked />Yes</label>
                                <span class="gap"></span>
                                <label><input type="radio" name="CurrentlyEmployed" value="1" />No</label>
                            </td>
                        </tr>
                             <tr class="JobInfo"><td class="gap"></td></tr>
                             <tr class="JobInfo"><td class="gap"></td></tr>
                            <tr class="JobInfo">
							    <td><span class="requiredfield"></span>Sector :</td>
                                <td>
									    <select class="standardform" id="Sector"></select>				  
							    </td>
                            </tr>
                            <tr class="JobInfo"><td class="gap"></td></tr>
                            <tr class="JobInfo"><td class="gap"></td></tr>
                            <tr class="JobInfo">
							    <td><span class="requiredfield"></span>Position :</td>
                                <td>
									    <select class="standardform" id="Position"></select>				  
							    </td>
                            </tr>
                       
                    </table>
                </td>
            </tr>
            <tr><td><hr /></td></tr>
            <tr>
                <td style="padding:20px;">
                    <table border="0" style="padding:0px !important; margin:0px;" cellspacing="0" cellpadding="0" >
                        <tr>
                            <td class="label"><span class="requiredfield"></span>User ID  (<i>combinations of letters and numbers</i>):</td>
                            <td><input type="text" class="standardform" id="UserID" placeholder="User ID"/></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Account Password (<i>minimum 8 characters</i>):</td>
                            <td><input type="password" class="standardform" id="Password" placeholder="Account Password" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Confirm Password:</td>
                            <td><input type="password" id="ConfirmPassword" placeholder="Confirm Password" class="standardform" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Contact Detail</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table border="0" style="padding:0px !important; margin:0px;" cellspacing="0" cellpadding="0" >

                        <tr>
                            <td class="label"><span class="requiredfield"></span>Address:</td>
                            <td><input class="standardform" id="Address1" type="text" placeholder="Street Address Line 1"/></td>
                        </tr>
                        <tr><td class="gapsmall"></td></tr>
                        <tr>
                            <td></td>
                            <td><input class="standardform" id="Address2" type="text" placeholder="Street Address Line 2" /></td>
                        </tr>
                        <tr><td class="gapsmall"></td></tr>
                        <tr>
                            <td></td>
                            <td>
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td><input class="standardformshort" style="width:70px !important;" id="Postcode" type="text" placeholder="Postcode" /></td>
                                        <td style="width:11px;"></td>
                                        <td><input class="standardformshort" id="City" type="text" placeholder="City" /></td>
                                        <td style="width:11px;"></td>
                                        <td><input  list="dtState" class="standardformshort" id="State" type="text" placeholder="State" />
                                                <%Response.WriteFile("StateList.html");%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td class="gapsmall"></td></tr>
                        <tr>
                            <td></td>
                            <td>
                                <select class="standardform" id="Country">
                                </select>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        
                        <tr>
                            <td><span class="requiredfield"></span>Phone Number:</td>
                            <td><input class="standardform" style="width:50px;" type="text" id="PhoneNumberPrefix" placeholder="03"/> - <input class="standardform" style="width:215px;" id="PhoneNumber" type="text" placeholder="12345678"/> </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Mobile Phone Number:</td>
                            <td><input class="standardform" style="width:50px;" type="text" id="MobilePhoneNumberPrefix" placeholder="012"/> - <input class="standardform" style="width:215px;" type="text" id="MobilePhoneNumber" placeholder="1234567"/> </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Email:</td>
                            <td><input class="standardform" id="Email" type="email" placeholder="name@example.com"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Academic Information</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table border="0" style="padding:0px !important; margin:0px;" cellspacing="0" cellpadding="0" >
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Preferred Accountancy Professional Qualification Course:</td>
                            <td><div id="PreferredQualification"></div></td>	
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td><span class="requiredfield"></span>Education History :</td>
                            <td>
									<select class="standardform" style="width:200px;" id="EducationLevel1"></select>
									<select class="standardform" id="FieldOfStudy1"></select>							  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td></td>
                            <td>
									<select class="standardform" style="width:200px;" id="EducationLevel2"></select>
									<select class="standardform" id="FieldOfStudy2"></select>							  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td></td>
                            <td>
									<select class="standardform" style="width:200px;" id="EducationLevel3"></select>
									<select class="standardform" id="FieldOfStudy3"></select>							  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td></td>
                            <td>
									<select class="standardform" style="width:200px;" id="EducationLevel4"></select>
									<select class="standardform" id="FieldOfStudy4"></select>							  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td></td>
                            <td>
									<select class="standardform" style="width:200px;" id="EducationLevel5"></select>
									<select class="standardform" id="FieldOfStudy5"></select>							  
							</td>
                        </tr>	
                       <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td><span class="requiredfield"></span>Which Country You Attain Your Highest Education :</td>
                             <td><select class="standardform" id="UniversityCountry">
                                 <option value="Australia">Australia</option>
                                 <option value="Malaysia" selected>Malaysia</option>
                                 <option value="NewZealand">New Zealand</option>
                                 <option value="Singapore">Singapore</option>
                                 <option value="UK">United Kingdom</option>
                                 <option value="Others">Others</option>
                                 </select></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>University / Institution / School - Branch :</td>
                            <td><input list="dtMalaysiaUniversity" type="text" id="HighestEducation" placeholder="UNITAR - Kelana Jaya, UiTM - Melaka, etc" class="standardform" />
                                <%
                                  Response.WriteFile("AustraliaUniversityList.html");
                                  Response.WriteFile("MalaysiaUniversityList.html");
                                  Response.WriteFile("NewZealandUniversityList.html");
                                  Response.WriteFile("SingaporeUniversityList.html");
                                  Response.WriteFile("UKUniversityList.html");
                                %>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Are You Currently Persuing Your Highest Level of Education?</td>
                            <td><input type="checkbox"  id="CurrentlyPursuing" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                    </table>
                </td>
            </tr>

            <tr><td><label for="PDPA1"><input type="checkbox" id="PDPA1" />I hereby confirm that I have downloaded and read the MyPAC's <a href="Resource/MyPAC_PDPA.pdf" target="_blank">Personal Data & Information Notice</a> ("the Notice").</label></td></tr>
            <tr><td class="gap"></td></tr>
            <tr><td><label for="PDPA2"><input type="checkbox" id="PDPA2" />I acknowledge and agree to the terms and conditions of the Notice and consent to the use of my personal data in the manner and for the purposes stipulated in the Notice.</label></td></tr>
            <tr><td class="gap"></td></tr>
            <tr><td align="center"><div class="g-recaptcha" data-sitekey="<%=ConfigurationManager.AppSettings["ReCaptchaSiteKey"]%>"></div></td></tr>
            <tr><td class="gap"></td></tr>
            <tr><td align="center"><button id="btnRegister">Register</button></td></tr>
            <tr><td style="height: 50px"></td></tr>
        </table>

        <table id="tblInfo" style="display: none;" align="center">
            <tr>
                <td>
                    <img src="Components/Css/global/logo.png" />
                </td>
                <td>
                    <h1>Thank you for your interest in obtaining Professional Qualification through Malaysia Professional Accountancy Centre (MyPAC)</h1>
                </td>
            </tr>
            <tr>
                <td colspan="2">The Eligibility Criteria for the ACCA Programme offered through MyPAC 
                    <br />
                    (You are required to fulfill all these conditions in order to proceed with the application. Tick all boxes and click <b>Continue</b>): 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>
                        <input type="checkbox" />
                        I am an upstanding* Malaysian Bumiputera (*Honest, Respectable, Ethical, Principled, etc.)</label>
                    <br />
                    <label>
                        <input type="checkbox" />
                        I am Over 18 but below 50 years of age</label>
                    <br />
                    <label>
                        <input type="checkbox" />
                        I am interested to be an accredited Professional (ACCA, ICAEW, MICPA and CPA Australia)</label>
                    <br />
                    <label>
                        <input type="checkbox" />
                        I am highly responsible and committed to complete the Professional Qualification programme within the set time period</label>
                    <br />
                    <label>
                        <input type="checkbox" />
                        I am willing to come forward to support MyPAC and help future MyPAC candidates as mentors, coaches, MyPAC alumnus, etc.</label>
                    <br />
                    <label>
                        <input type="checkbox" />
                        I have NOT applied for this programme through MyPAC before *</label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    * If you have previously applied for MyPAC programme, please email your details to <u>info@mypac.org.my</u>. 
                    <br />
                    We will be in touch with you for further action.
                    <br />
                    <br />
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">Kindly prepare the following for attachment before clicking Continue:
                    <ol>
                        <li>IC (front and back on one page)</li>
                        <li>Academic Transcript</li>
                        <li>Professional Qualification (PQ) Acceptance Letter (if applicable)</li>
                        <li>Latest PQ Exam Result (if applicable)</li>
                        <li>Latest PQ Exam Result (if applicable)</li>
                    </ol>
                    Please ensure that your supporting documents are "certified true copy".
                    <br />
                    <br />
                    Subject to terms & conditions. MyPAC reserves the right to amend or add any criteria from time to time.
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <button id="btnContinue">Continue</button>
                </td>
            </tr>
        </table>
    </form>
    <script>
        if (!window.jQuery)
        {
            alert("jQuery not loaded");
        }
        else
        {
            $("input[name=CurrentlyEmployed]").change(function () {
             //   alert($("input[name=CurrentlyEmployed]:checked").val());
                if($("input[name=CurrentlyEmployed]:checked").val() == "0")
                {
                    $(".JobInfo").show();
                }else
                {
                    $(".JobInfo").hide();
                }
                //if (this.checked) {
                //    //Do stuff
                //}
            });
          
            $("#UniversityCountry").change(function () {
                //alert($("#UniversityCountry").val());
                $("#HighestEducation").attr("list","dt"+$("#UniversityCountry").val()+"University");

            });

            $("#btnContinue").button({
                icons: { primary: null, secondary: 'ui-icon-triangle-1-e' }
            }).click(function ()
            {
                $("#tblInfo").fadeOut("200", function ()
                {
                    window.scrollTo(0, 0);
                    $("#tblFormRegister").fadeIn();
                });
                return false;
            });

            $("#dpDOB").datepicker({
                autoSize: true,
                changeMonth: true,
                changeYear: true,
                dateFormat: "d-M-yy",
                   showButtonPanel: true,yearRange: "-100:+5"
            });
            teq.Common.SetDatePickerClearable($("#dpDOB"));
            $("#btnRegister").button({
                icons: { primary: null, secondary: 'ui-icon-check' }
            }).click(function ()
            {
                //alert($('#g-recaptcha-response').val());
                var selected = [];
                $('#PreferredQualification input:checked').each(function () {
                    selected.push($(this).attr('value'));
                });
               // alert(selected);
                var entity = {
                    UserID: $('#UserID').val(),
                    Password: $('#Password').val(),
                    ConfirmPassword: $('#ConfirmPassword').val(),
                    FullName: $('#FullName').val(),
                    DOB: $("#dpDOB").val(),
                    BumiPutra: $("input[name=BumiPutra]:checked").val(),
                    Gender: $("input[name=Gender]:checked").val(),
                    //Nationality: $("input[name=Nationality]:checked").val(),
                    Nationality: $("#Nationality").find("option:selected").text(),
                    IC: $('#IC').val(),
                    CurrentlyEmployed: $("input[name=CurrentlyEmployed]:checked").val(),
                    EducationLevel1: $('#EducationLevel1').val(),
                    FieldOfStudy1: $('#FieldOfStudy1').val(),
                    EducationLevel2: $('#EducationLevel2').val(),
                    FieldOfStudy2: $('#FieldOfStudy2').val(),
                    EducationLevel3: $('#EducationLevel3').val(),
                    FieldOfStudy3: $('#FieldOfStudy3').val(),
                    EducationLevel4: $('#EducationLevel4').val(),
                    FieldOfStudy4: $('#FieldOfStudy4').val(),
                    EducationLevel5: $('#EducationLevel5').val(),
                    FieldOfStudy5: $('#FieldOfStudy5').val(),
                    CurrentlyPursuing: $('#CurrentlyPursuing').prop('checked'),
                    HighestEducation: $('#HighestEducation').val(),
                    Address1: $('#Address1').val(),
                    Address2: $('#Address2').val(),
                    City: $('#City').val(),
                    Postcode: $('#Postcode').val(),
                    State: $('#State').val(),
                    Country: $('#Country').val(),
                    PhoneNumberPrefix: $('#PhoneNumberPrefix').val(),
                    PhoneNumber: $('#PhoneNumber').val(),
                    MobilePhoneNumberPrefix: $('#MobilePhoneNumberPrefix').val(),
                    MobilePhoneNumber: $('#MobilePhoneNumber').val(),
                    Email: $('#Email').val(),
                    PDPA1: $('#PDPA1').prop('checked'),
                    PDPA2: $('#PDPA2').prop('checked'),
                    PreferredQualification: selected,
                    Ethnicity: $('#Ethnicity').val(),
                    Position: $('#Position').val(),
                    Sector: $('#Sector').val(),
                    UniversityCountry: $('#UniversityCountry').val(),
                    ReCaptchaResponse: $('#g-recaptcha-response').val(),
                    IsCaptchaVerified :$('#IsCaptchaVerified').val()

                };

   
                CandidateRegistrationManagementAjaxGateway.SaveCandidateRegistration(entity, function (res) {
                    if (res.value.length > 0)
                    {
                        var errMessage = "";
                        var Captcha = "";
                        for (var x = 0; x < res.value.length; x++) {
                            if (x > 0)
                                errMessage += "<br>";
                            errMessage += res.value[x].Name;

                            if(res.value[x].Code == ErrorCodes.CandidateRegistration_InvalidCaptcha)
                            {
                                //alert('Found catcha error');
                                Captcha = "failed";
                               
                            }
                        }

                        if (Captcha == "" && $('#IsCaptchaVerified').val() != "true")
                        {
                            $('#IsCaptchaVerified').val("true");
                           // alert($('#IsCaptchaVerified').val());
                        }

                       // grecaptcha.reset();
                        teq.Context.Alert(errMessage, null, function () {
                        });
                    }
                    else
                    {
                        var msg = "Thank You! Your account has been created. <br /> Please click the confirmation link that sent to your email <b>" + $("#txtEmail").text() + ".</b>";
                        teq.Context.Alert(msg, null, function ()
                        {
                            window.location.href = "http://mypac.org.my";
                            return;
                        });
                    }
                });
                return false;
            });

            $('#Nationality').dropdownSelect({
                nullLabel: "- Select Country -",
                nullValue: GuidEmpty
            });

            CandidateRegistrationManagementAjaxGateway.GetCountryList(function (res) {
                $('#Nationality').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
                $("#Nationality option:contains(" + "Malaysia" + ")").attr('selected', 'selected');
            });

            $('#Sector').dropdownSelect({
                         nullLabel: "- Select Sector -",
                         nullValue: ""
                     });

            CandidateRegistrationManagementAjaxGateway.GetSectorList(function (res) {
                $('#Sector').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
            $('#Position').dropdownSelect(
               {
                   nullLabel: "- Select Position -",
                   nullValue: ""
               });
            CandidateRegistrationManagementAjaxGateway.GetPositionList(function (res) {
                $('#Position').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
            $('#EducationLevel1,#EducationLevel2,#EducationLevel3,#EducationLevel4,#EducationLevel5').dropdownSelect({
                            nullLabel: "- Select Level -",
                            nullValue: ""
                        });
            $('#FieldOfStudy1,#FieldOfStudy2,#FieldOfStudy3,#FieldOfStudy4,#FieldOfStudy5').dropdownSelect({
                         nullLabel: "- Select Field of Study -",
                         nullValue: ""
                     });
            CandidateRegistrationManagementAjaxGateway.GetEducationLevelList(function (res) {
                $('#EducationLevel1,#EducationLevel2,#EducationLevel3,#EducationLevel4,#EducationLevel5').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
            CandidateRegistrationManagementAjaxGateway.GetFieldOfStudyList(function (res) {
                $('#FieldOfStudy1,#FieldOfStudy2,#FieldOfStudy3,#FieldOfStudy4,#FieldOfStudy5').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });

            $('#Country').dropdownSelect({
                       nullLabel: "- Select Country -",
                       nullValue: GuidEmpty
                   });

            CandidateRegistrationManagementAjaxGateway.GetCountryList(function (res) {
                $('#Country').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });

            $("#PreferredQualification").checkboxList({
                columns: 4,
                columnSpacing: "20px",
                width: null,
                allowNone: false
            });
            CandidateRegistrationManagementAjaxGateway.GetCourseList(function (res) {
                $("#PreferredQualification").checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
        }
    </script>
</body>
</html>
