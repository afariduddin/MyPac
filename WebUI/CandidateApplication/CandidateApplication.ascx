<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateApplication.ascx.cs" Inherits="CandidateApplication" %>
<div class="PageHeader">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">New Application</span></td>   
            <td align="right">
                <button id="<%=ClientID%>_btnSaveDraft">Save as Draft</button>
                <button id="<%=ClientID%>_btnSubmit">Submit</button>
            </td>
        </tr>
    </table>
</div>

<div style="width:100%; padding:3px;" id="divSubmitted">
    <div class="WrapPadding">
        <h2>Your Application Status is Active/Complete or your application has been submitted previously. You are allowed to submit again after <%=EngineVariable.LibraryVariable.MinimumApplicationSubmittedInterval%> days from the previously submission. Your Previous Submission at <span id="PreviousSubmission"></span>. Your next submission date will be <span id="NextSubmission"></span></h2>
    </div>
</div>

<div style="width:100%; padding:3px;" id="divThankYou">
    <div class="WrapPadding">
        <h2>Thank you for your submission.</h2>
    </div>
</div>
<div style="width:100%;" id="divMain">
    <div class="WrapPadding">
        <form action="/" method="post">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFormRegister" width="100%">
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Personal Information<input type="hidden" id="ApplicationID" /></td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Full Name:</td>
                            <td><input type="text" placeholder="Full Name" class="standardform" id="FullName" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Date of Birth:</td>
                            <td><input class="standardform" type="text" id="<%=ClientID %>_dpDOB" readonly="readonly" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>IC Number (<i>without dash</i>):</td>
                            <td><input class="standardform" type="text" id="IC" placeholder="910101107189" value="910101107189" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Nationality:</td>
                            <td><label><input type="radio" name="nationality" id="Nationality" value="0" checked="checked" />Malaysian</label></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Gender:</td>
                            <td>
                                    <label><input type="radio" name="Gender" value="1" />Male</label>
                                    <span class="gap"></span>
                                    <label><input type="radio" name="Gender" value="2" />Female</label>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Currently Employed:</td>
                            <td>
                                <label><input type="radio" name="CurrentlyEmployed" value="0" />Yes</label>
                                <span class="gap"></span>
                                <label><input type="radio" name="CurrentlyEmployed" value="1" />No</label>
                            </td>
                        </tr>
                         <tr><td class="gap"></td></tr>
                         <tr><td class="gap"></td></tr>
                        <tr>
							<td>Sector :</td>
                            <td>
									<select class="standardform" id="Sector"></select>				  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
							<td>Position :</td>
                            <td>
									<select class="standardform" id="Position"></select>				  
							</td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Department:</td>
                            <td><input class="standardform" type="text" id="Department" /></td>
                        </tr>
                         <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Company Name:</td>
                            <td><input class="standardform" type="text" id="CompanyName" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Company Contact:</td>
                            <td><input class="standardform" type="text" id="CompanyContact" /></td>
                        </tr>
                           <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Company Address:</td>
                            <td><textarea rows="4" class="standardform"  id="CompanyAddress"></textarea></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Contact Detail</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
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
                                        <td><input list="dtState" class="standardformshort" id="State" type="text" placeholder="State" />
                                                    <%
          Response.WriteFile("StateList.html");
        %>

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
                                  <%--  <option>-Select Country-</option>
                                    <option selected="selected" value="Malaysia">Malaysia </option>
                                    <option value="United States">United States </option>
                                    <option value="Afghanistan">Afghanistan </option>
                                    <option value="Albania">Albania </option>
                                    <option value="Algeria">Algeria </option>
                                    <option value="American Samoa">American Samoa </option>
                                    <option value="Andorra">Andorra </option>
                                    <option value="Angola">Angola </option>
                                    <option value="Anguilla">Anguilla </option>
                                    <option value="Antigua and Barbuda">Antigua and Barbuda </option>
                                    <option value="Argentina">Argentina </option>
                                    <option value="Armenia">Armenia </option>
                                    <option value="Aruba">Aruba </option>
                                    <option value="Australia">Australia </option>
                                    <option value="Austria">Austria </option>
                                    <option value="Azerbaijan">Azerbaijan </option>
                                    <option value="The Bahamas">The Bahamas </option>
                                    <option value="Bahrain">Bahrain </option>
                                    <option value="Bangladesh">Bangladesh </option>
                                    <option value="Barbados">Barbados </option>
                                    <option value="Belarus">Belarus </option>
                                    <option value="Belgium">Belgium </option>
                                    <option value="Belize">Belize </option>
                                    <option value="Benin">Benin </option>
                                    <option value="Bermuda">Bermuda </option>
                                    <option value="Bhutan">Bhutan </option>
                                    <option value="Bolivia">Bolivia </option>
                                    <option value="Bosnia and Herzegovina">Bosnia and Herzegovina </option>
                                    <option value="Botswana">Botswana </option>
                                    <option value="Brazil">Brazil </option>
                                    <option value="Brunei">Brunei </option>
                                    <option value="Bulgaria">Bulgaria </option>
                                    <option value="Burkina Faso">Burkina Faso </option>
                                    <option value="Burundi">Burundi </option>
                                    <option value="Cambodia">Cambodia </option>
                                    <option value="Cameroon">Cameroon </option>
                                    <option value="Canada">Canada </option>
                                    <option value="Cape Verde">Cape Verde </option>
                                    <option value="Cayman Islands">Cayman Islands </option>
                                    <option value="Central African Republic">Central African Republic </option>
                                    <option value="Chad">Chad </option>
                                    <option value="Chile">Chile </option>
                                    <option value="People's Republic of China">People's Republic of China </option>
                                    <option value="Republic of China">Republic of China </option>
                                    <option value="Christmas Island">Christmas Island </option>
                                    <option value="Cocos (Keeling) Islands">Cocos (Keeling) Islands </option>
                                    <option value="Colombia">Colombia </option>
                                    <option value="Comoros">Comoros </option>
                                    <option value="Congo">Congo </option>
                                    <option value="Cook Islands">Cook Islands </option>
                                    <option value="Costa Rica">Costa Rica </option>
                                    <option value="Cote d'Ivoire">Cote d'Ivoire </option>
                                    <option value="Croatia">Croatia </option>
                                    <option value="Cuba">Cuba </option>
                                    <option value="Cyprus">Cyprus </option>
                                    <option value="Czech Republic">Czech Republic </option>
                                    <option value="Denmark">Denmark </option>
                                    <option value="Djibouti">Djibouti </option>
                                    <option value="Dominica">Dominica </option>
                                    <option value="Dominican Republic">Dominican Republic </option>
                                    <option value="Ecuador">Ecuador </option>
                                    <option value="Egypt">Egypt </option>
                                    <option value="El Salvador">El Salvador </option>
                                    <option value="Equatorial Guinea">Equatorial Guinea </option>
                                    <option value="Eritrea">Eritrea </option>
                                    <option value="Estonia">Estonia </option>
                                    <option value="Ethiopia">Ethiopia </option>
                                    <option value="Falkland Islands">Falkland Islands </option>
                                    <option value="Faroe Islands">Faroe Islands </option>
                                    <option value="Fiji">Fiji </option>
                                    <option value="Finland">Finland </option>
                                    <option value="France">France </option>
                                    <option value="French Polynesia">French Polynesia </option>
                                    <option value="Gabon">Gabon </option>
                                    <option value="The Gambia">The Gambia </option>
                                    <option value="Georgia">Georgia </option>
                                    <option value="Germany">Germany </option>
                                    <option value="Ghana">Ghana </option>
                                    <option value="Gibraltar">Gibraltar </option>
                                    <option value="Greece">Greece </option>
                                    <option value="Greenland">Greenland </option>
                                    <option value="Grenada">Grenada </option>
                                    <option value="Guadeloupe">Guadeloupe </option>
                                    <option value="Guam">Guam </option>
                                    <option value="Guatemala">Guatemala </option>
                                    <option value="Guernsey">Guernsey </option>
                                    <option value="Guinea">Guinea </option>
                                    <option value="Guinea-Bissau">Guinea-Bissau </option>
                                    <option value="Guyana">Guyana </option>
                                    <option value="Haiti">Haiti </option>
                                    <option value="Honduras">Honduras </option>
                                    <option value="Hong Kong">Hong Kong </option>
                                    <option value="Hungary">Hungary </option>
                                    <option value="Iceland">Iceland </option>
                                    <option value="India">India </option>
                                    <option value="Indonesia">Indonesia </option>
                                    <option value="Iran">Iran </option>
                                    <option value="Iraq">Iraq </option>
                                    <option value="Ireland">Ireland </option>
                                    <option value="Israel">Israel </option>
                                    <option value="Italy">Italy </option>
                                    <option value="Jamaica">Jamaica </option>
                                    <option value="Japan">Japan </option>
                                    <option value="Jersey">Jersey </option>
                                    <option value="Jordan">Jordan </option>
                                    <option value="Kazakhstan">Kazakhstan </option>
                                    <option value="Kenya">Kenya </option>
                                    <option value="Kiribati">Kiribati </option>
                                    <option value="North Korea">North Korea </option>
                                    <option value="South Korea">South Korea </option>
                                    <option value="Kosovo">Kosovo </option>
                                    <option value="Kuwait">Kuwait </option>
                                    <option value="Kyrgyzstan">Kyrgyzstan </option>
                                    <option value="Laos">Laos </option>
                                    <option value="Latvia">Latvia </option>
                                    <option value="Lebanon">Lebanon </option>
                                    <option value="Lesotho">Lesotho </option>
                                    <option value="Liberia">Liberia </option>
                                    <option value="Libya">Libya </option>
                                    <option value="Liechtenstein">Liechtenstein </option>
                                    <option value="Lithuania">Lithuania </option>
                                    <option value="Luxembourg">Luxembourg </option>
                                    <option value="Macau">Macau </option>
                                    <option value="Macedonia">Macedonia </option>
                                    <option value="Madagascar">Madagascar </option>
                                    <option value="Malawi">Malawi </option>
                                    <option value="Maldives">Maldives </option>
                                    <option value="Mali">Mali </option>
                                    <option value="Malta">Malta </option>
                                    <option value="Marshall Islands">Marshall Islands </option>
                                    <option value="Martinique">Martinique </option>
                                    <option value="Mauritania">Mauritania </option>
                                    <option value="Mauritius">Mauritius </option>
                                    <option value="Mayotte">Mayotte </option>
                                    <option value="Mexico">Mexico </option>
                                    <option value="Micronesia">Micronesia </option>
                                    <option value="Moldova">Moldova </option>
                                    <option value="Monaco">Monaco </option>
                                    <option value="Mongolia">Mongolia </option>
                                    <option value="Montenegro">Montenegro </option>
                                    <option value="Montserrat">Montserrat </option>
                                    <option value="Morocco">Morocco </option>
                                    <option value="Mozambique">Mozambique </option>
                                    <option value="Myanmar">Myanmar </option>
                                    <option value="Nagorno-Karabakh">Nagorno-Karabakh </option>
                                    <option value="Namibia">Namibia </option>
                                    <option value="Nauru">Nauru </option>
                                    <option value="Nepal">Nepal </option>
                                    <option value="Netherlands">Netherlands </option>
                                    <option value="Netherlands Antilles">Netherlands Antilles </option>
                                    <option value="New Caledonia">New Caledonia </option>
                                    <option value="New Zealand">New Zealand </option>
                                    <option value="Nicaragua">Nicaragua </option>
                                    <option value="Niger">Niger </option>
                                    <option value="Nigeria">Nigeria </option>
                                    <option value="Niue">Niue </option>
                                    <option value="Norfolk Island">Norfolk Island </option>
                                    <option value="Turkish Republic of Northern Cyprus">Turkish Republic of Northern Cyprus </option>
                                    <option value="Northern Mariana">Northern Mariana </option>
                                    <option value="Norway">Norway </option>
                                    <option value="Oman">Oman </option>
                                    <option value="Pakistan">Pakistan </option>
                                    <option value="Palau">Palau </option>
                                    <option value="Palestine">Palestine </option>
                                    <option value="Panama">Panama </option>
                                    <option value="Papua New Guinea">Papua New Guinea </option>
                                    <option value="Paraguay">Paraguay </option>
                                    <option value="Peru">Peru </option>
                                    <option value="Philippines">Philippines </option>
                                    <option value="Pitcairn Islands">Pitcairn Islands </option>
                                    <option value="Poland">Poland </option>
                                    <option value="Portugal">Portugal </option>
                                    <option value="Puerto Rico">Puerto Rico </option>
                                    <option value="Qatar">Qatar </option>
                                    <option value="Romania">Romania </option>
                                    <option value="Russia">Russia </option>
                                    <option value="Rwanda">Rwanda </option>
                                    <option value="Saint Barthelemy">Saint Barthelemy </option>
                                    <option value="Saint Helena">Saint Helena </option>
                                    <option value="Saint Kitts and Nevis">Saint Kitts and Nevis </option>
                                    <option value="Saint Lucia">Saint Lucia </option>
                                    <option value="Saint Martin">Saint Martin </option>
                                    <option value="Saint Pierre and Miquelon">Saint Pierre and Miquelon </option>
                                    <option value="Saint Vincent and the Grenadines">Saint Vincent and the Grenadines </option>
                                    <option value="Samoa">Samoa </option>
                                    <option value="San Marino">San Marino </option>
                                    <option value="Sao Tome and Principe">Sao Tome and Principe </option>
                                    <option value="Saudi Arabia">Saudi Arabia </option>
                                    <option value="Senegal">Senegal </option>
                                    <option value="Serbia">Serbia </option>
                                    <option value="Seychelles">Seychelles </option>
                                    <option value="Sierra Leone">Sierra Leone </option>
                                    <option value="Singapore">Singapore </option>
                                    <option value="Slovakia">Slovakia </option>
                                    <option value="Slovenia">Slovenia </option>
                                    <option value="Solomon Islands">Solomon Islands </option>
                                    <option value="Somalia">Somalia </option>
                                    <option value="Somaliland">Somaliland </option>
                                    <option value="South Africa">South Africa </option>
                                    <option value="South Ossetia">South Ossetia </option>
                                    <option value="South Sudan">South Sudan </option>
                                    <option value="Spain">Spain </option>
                                    <option value="Sri Lanka">Sri Lanka </option>
                                    <option value="Sudan">Sudan </option>
                                    <option value="Suriname">Suriname </option>
                                    <option value="Svalbard">Svalbard </option>
                                    <option value="Swaziland">Swaziland </option>
                                    <option value="Sweden">Sweden </option>
                                    <option value="Switzerland">Switzerland </option>
                                    <option value="Syria">Syria </option>
                                    <option value="Taiwan">Taiwan </option>
                                    <option value="Tajikistan">Tajikistan </option>
                                    <option value="Tanzania">Tanzania </option>
                                    <option value="Thailand">Thailand </option>
                                    <option value="Timor-Leste">Timor-Leste </option>
                                    <option value="Togo">Togo </option>
                                    <option value="Tokelau">Tokelau </option>
                                    <option value="Tonga">Tonga </option>
                                    <option value="Transnistria Pridnestrovie">Transnistria Pridnestrovie </option>
                                    <option value="Trinidad and Tobago">Trinidad and Tobago </option>
                                    <option value="Tristan da Cunha">Tristan da Cunha </option>
                                    <option value="Tunisia">Tunisia </option>
                                    <option value="Turkey">Turkey </option>
                                    <option value="Turkmenistan">Turkmenistan </option>
                                    <option value="Turks and Caicos Islands">Turks and Caicos Islands </option>
                                    <option value="Tuvalu">Tuvalu </option>
                                    <option value="Uganda">Uganda </option>
                                    <option value="Ukraine">Ukraine </option>
                                    <option value="United Arab Emirates">United Arab Emirates </option>
                                    <option value="United Kingdom">United Kingdom </option>
                                    <option value="Uruguay">Uruguay </option>
                                    <option value="Uzbekistan">Uzbekistan </option>
                                    <option value="Vanuatu">Vanuatu </option>
                                    <option value="Vatican City">Vatican City </option>
                                    <option value="Venezuela">Venezuela </option>
                                    <option value="Vietnam">Vietnam </option>
                                    <option value="British Virgin Islands">British Virgin Islands </option>
                                    <option value="Isle of Man">Isle of Man </option>
                                    <option value="US Virgin Islands">US Virgin Islands </option>
                                    <option value="Wallis and Futuna">Wallis and Futuna </option>
                                    <option value="Western Sahara">Western Sahara </option>
                                    <option value="Yemen">Yemen </option>
                                    <option value="Zambia">Zambia </option>
                                    <option value="Zimbabwe">Zimbabwe </option>
                                    <option value="other">Other </option>--%>
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

            
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Parents' Information</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Father's Full Name:</td>
                            <td><input type="text" class="standardform" id="FatherName" placeholder="Father's Full Name" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>IC Number (<i>without dash</i>):</td>
                            <td><input type="text" class="standardform" id="FatherIC" placeholder="910101107189"/></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Mother's Full Name:</td>
                            <td><input type="text" class="standardform" id="MotherName" placeholder="Mother's Full Name" /></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>IC Number (<i>without dash</i>):</td>
                            <td><input type="text" class="standardform" id="MotherIC" placeholder="910101107189"/></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                          <tr>
                            <td><span class="requiredfield"></span>Combined Household Income</td>
                            <td><input type="number" class="standardform" id="CombinedHouseholdIncome" placeholder=""/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            

            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Education Background</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Current Field of Study:</td>
                            <td><input type="text" id="CurrentFieldOfStudy" placeholder="Bachelor of Accountancy, Diploma in Accountancy, etc" class="standardform"/></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>University / Institution:</td>
                            <td><input list="dtUniversity" type="text" id="University" placeholder="UNITAR - Kelana Jaya, UiTM - Melaka, etc" class="standardform"/>

                                                                  <%
          Response.WriteFile("UniversityList.html");
        %>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Current or Final CGPA:</td>
                            <td><input type="number" id="CGPA" placeholder="3.00" class="standardform"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Application Detail</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Accountancy Professional Qualification (PQ) Course:</td>
                            <td><select id="Course" class="standardform"></select></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Remaining PQ Papers (<i>outstanding papers</i>)</td>
                            <td><div class="list" id="Subject"></div></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Study Preference</td>
                            <td>
                                 <label><input type="radio" value="2" name="studyPreferences"/>Full Time</label>
                                <span class="gap"></span>
                                <label><input type="radio"  value="1" name="studyPreferences"/>Part Time</label>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Preferred Location:</td>
                            <td><select id="TSP" class="standardform"></select></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Preferred Intake Year:</td>
                            <td><select id="IntakeYear" class="standardform"></select></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td>Preferred Intake Month:</td>
                            <td><select id="IntakeMonth" class="standardform"></select></td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td><span class="requiredfield"></span>Do you currently have any PQ:</td>
                            <td>
                                <input type="radio" name="WithPQ" value="0" checked="checked" />Yes</label>
                                <span class="gap"></span>
                                <label><input type="radio" name="WithPQ" value="1" />No</label>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr id="trPQ">
                            <td colspan="2">
                                
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td class="label">PQ Registration No.:</td>
                                        <td><input type="text" id="PQRegNo" placeholder="PQ Registration Number" class="standardform"/></td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td>PQ Start Date:</td>
                                        <td><input id="<%=ClientID %>_dpPQStartDate" type="text" placeholder="PQ Start Date" class="standardform" readonly="readonly"/></td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td>Deadline to Complete all PQ Papers:</td>
                                        <td><input id="<%=ClientID%>_dpPQDealine" type="text" class="standardform" readonly="readonly"/></td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td>Level you started PQ</td>
                                        <td>
                                          <%--  <div id="LevelStartPQ"></div>--%>
                                             <select class="standardform" id="LevelStartPQ">
                                        </td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td>Have you registered Next Exam Sitting?</td>
                                        <td>
                                            <label><input type="radio" name="NextExam" value="0" />Yes</label>
                                            <span class="gap"></span>
                                            <label><input type="radio" name="NextExam" value="1" />No</label>
                                        </td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td>Next Exam Session</td>
                                        <td><input id="<%=ClientID%>_dpNextExam" type="text" class="standardform" readonly="readonly"/></td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr>
                                        <td><span class="requiredfield"></span>Do you have Financial Assistance for PQ Exams (<i>scholarship</i>)? :</td>
                                        <td>
                                            <input type="radio" name="WithSponsor" value="0" checked="checked" />Yes</label>
                                            <span class="gap"></span>
                                            <label><input type="radio" name="WithSponsor" value="1" />No</label>
                                        </td>
                                    </tr>
                                    <tr><td class="gap"></td></tr>
                                    <tr id="trSponsor">
                                        <td colspan="2">
                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr><td class="gap"></td></tr>
                                                <tr>
                                                    <td class="label">Name of Scholarship Provider:</td>
                                                    <td><input type="text" id="ScholarshipProvider" class="standardform"/></td>
                                                </tr>
                                                <tr><td class="gap"></td></tr>
                                                <tr>
                                                    <td>Cost Covered by Scholarship (<i>MYR</i>):</td>
                                                    <td><input type="number" id="CostCoveredByScholarship" class="standardform"/></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Addtional Application Attachments</td></tr>
            <tr>
                <td style="padding:20px;">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Identification (<i>single page front & back</i>):</td>
                                <td><%--<input type="file" id="FileIC" class="standardform" />--%>
                                <a download='' href='' id="<%=ClientID %>_FileIC"></a>
                                <div id="FileIC"></div>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Birth Certificate:</td>
                            <td><%--<input type="file" id="FileBirthCertificate" class="standardform" />--%>

                                <a download='' href='' id="<%=ClientID %>_FileBirthCertificate"></a>
                                  <div id="FileBirthCertificate"></div>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Academic Transcript:</td>
                            <td><%--<input type="file" id="FileAcademicTranscript" class="standardform" />--%>

                                   <a download='' href='' id="<%=ClientID %>_FileAcademicTranscript"></a>
                                  <div id="FileAcademicTranscript"></div>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label"><span class="requiredfield"></span>Passport Size Photo (<i>35mm x 50mm</i>):</td>
                            <td><%--<input type="file" id="FilePassport" class="standardform" />--%>
                                  <a download='' href='' id="<%=ClientID %>_FilePassport"></a>
                                  <div id="FilePassport"></div>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td class="gap"></td></tr>
                        <tr>
                            <td class="label">PQ Acceptance Letter:</td>
                            <td>
                               <%-- <input type="file" id="FilePQAcceptanceLetter" class="standardform" />--%>
                                <a download='' href='' id="<%=ClientID %>_FilePQAcceptanceLetter"></a>
                                  <div id="FilePQAcceptanceLetter"></div>
                            </td>
                        </tr>
                        <tr><td class="gap"></td></tr>
                        <tr><td colspan="2">Note: <i>Each attachment can only have a maximum filesize of 2MB. Accepted file formats are <b>.pdf, .jpg, .jpeg, .png, .gif</b></i></td></tr>
                    </table>
                </td>
            </tr>

            <tr><td class="gap"></td></tr>
            <tr><td class="gap"></td></tr>
            <tr><td class="gap"></td></tr>

            
            <tr>
                <td>
                    I hereby certify that all statements made in this application are true and complete to the best of my knowledge and have not withheld any information which might influence the consideration of this application. I understand that any misrepresentation / false declaration or omission will be sufficient cause for cancellation of consideration for this application. I also authorise any investigation of the above information for the purpose of verification.
                </td>
            </tr>
            <tr><td class="gap"></td></tr>
            <tr>
                <td><label><input type="checkbox" id="Agree" />I Agree with the declaration terms</label></td>
            </tr>
            <tr><td class="gap"></td></tr>
            <tr>
                <td><label><input type="checkbox" checked="checked" id="PDPA1" />I hereby confirm that I have received a copy of MyPAC's Personal Data & Information Notice ("the Notice").</label></td>
            </tr>
            <tr><td class="gap"></td></tr>
            <tr>
                <td><label><input type="checkbox" checked="checked" id="PDPA2"/>I acknowledge and agree to the terms and conditions of the Notice and consent to the use of my personal data in the manner and for the purposes stipulated in the Notice.</label></td>
            </tr>

    </table>
            </form>
    </div>
</div>
<div class="PageHeader">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle2" style="font-weight:bold; font-size:1.1em;"></span></td>   
            <td align="right">
                <button id="<%=ClientID%>_btnSaveDraft2">Save as Draft</button>
                <button id="<%=ClientID%>_btnSubmit2">Submit</button>
            </td>
        </tr>
    </table>
</div>

<script>
    $(document).ready(function() {
        $('input[type=radio][name=WithPQ]').change(function() {
            if (this.value == '1') {
                document.getElementById("trPQ").style.display = "none";
            }
            else if (this.value == '0') {
                document.getElementById("trPQ").style.display = "";
            }
        });
        
        $('input[type=radio][name=WithSponsor]').change(function() {
            if (this.value == '1') {
                document.getElementById("trSponsor").style.display = "none";
            }
            else if (this.value == '0') {
                document.getElementById("trSponsor").style.display = "";
            }
        });
    });




    if (!window.jQuery) {
        alert("jQuery not loaded");
    }
    else {
        var UploadIC;
        var UploadBirthCertificate;
        var UploadAcademicTranscript;
        var UploadPassport;
        var UploadPQAcceptanceLetter;
        teq.Common.BuildSingleFileUploadInput($('#FileIC'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
            function (res) {
                if (res.error == null) {
                    if (res == null) {

                    }
                    else {
                        UploadIC = res;
                    }

                }
            }
            );

        teq.Common.BuildSingleFileUploadInput($('#FileBirthCertificate'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
    function (res) {
        if (res.error == null) {
            if (res == null) {

            }
            else {
                UploadBirthCertificate = res;
            }

        }
    }
    );

        teq.Common.BuildSingleFileUploadInput($('#FileAcademicTranscript'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
    function (res) {
        if (res.error == null) {
            if (res == null) {


            }
            else {
                UploadAcademicTranscript = res;
            }

        }
    }
    );
        teq.Common.BuildSingleFileUploadInput($('#FilePassport'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
    function (res) {
        if (res.error == null) {
            if (res == null) {

            }
            else {
                UploadPassport = res;
            }

        }
    }
    );

        teq.Common.BuildSingleFileUploadInput($('#FilePQAcceptanceLetter'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
    function (res) {
        if (res.error == null) {
            if (res == null) {

            }
            else {
                UploadPQAcceptanceLetter = res;
            }

        }
    }
    );


        var interval = <%=EngineVariable.LibraryVariable.MinimumApplicationSubmittedInterval%>;
        $('#Course').dropdownSelect(
                     {
                         nullLabel: "- Please Select -",
                         nullValue: GuidEmpty
                     });

        $('#TSP').dropdownSelect(
                    {
                        nullLabel: "- Please Select -",
                        nullValue: GuidEmpty
                    });

        $('#IntakeYear').dropdownSelect(
                    {
                        nullLabel: "- Please Select -",
                        nullValue: GuidEmpty
                    });

        $('#IntakeMonth').dropdownSelect(
                    {
                        nullLabel: "- Please Select -",
                        nullValue: GuidEmpty
                    });

        

        CandidateApplicationManagementAjaxGateway.GetCourseList(function (res) {
            $('#Course').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });

        $('#LevelStartPQ').dropdownSelect(
              {
                  nullLabel: "- Please Select -",
                  nullValue: ""
              });
        CandidateApplicationManagementAjaxGateway.GetPQLevelStartList(function (res) {

            $('#LevelStartPQ').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });
        $('#Sector').dropdownSelect({
            nullLabel: "- Select Sector -",
            nullValue: ""
        });

        CandidateApplicationManagementAjaxGateway.GetSectorList(function (res) {
            $('#Sector').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });
        $('#Position').dropdownSelect(
           {
               nullLabel: "- Select Position -",
               nullValue: ""
           });
        CandidateApplicationManagementAjaxGateway.GetPositionList(function (res) {
            $('#Position').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });

        //$("#LevelStartPQ").radioButtonList({
        //    choices: Enums.LevelStartPQ,
        //    columns: 1,
        //    columnSpacing: "20px",
        //    width: null,
        //    allowNone: false
        //});


        $("#Subject").checkboxList({
            columns: 1,
            columnSpacing: "20px",
            width: null,
            allowNone: false
        });

        
        $('#Country').dropdownSelect(
               {
                   nullLabel: "- Select Country -",
                   nullValue: GuidEmpty
               });


        CandidateApplicationManagementAjaxGateway.GetCountryList(function (res) {

            $('#Country').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
        });

  
        $('#TSP').change(function () {
            CandidateApplicationManagementAjaxGateway.GetYear(function (res) {
                $('#IntakeYear').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
        });
        
        $('#IntakeYear').change(function () {
            CandidateApplicationManagementAjaxGateway.GetMonth($('#TSP').val(), $(this).val(), function (res) {
                $('#IntakeMonth').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
        });
  
        $('#Course').change(function () {
            CandidateApplicationManagementAjaxGateway.GetSubjectList($(this).val(), function (res) {
                if (res.error == null) {
                    $('#Subject').checkboxList("option", "choices", teq.Common.DictionaryToArray(res.value));
                    CandidateApplicationManagementAjaxGateway.GetSelectedSubjectList($('#ApplicationID').val(), function (res) {
                        if (res.error == null) {
                       
                            for (var x = 0; x < res.value.length; x++) {
                                    $("#Subject input").filter('[value=' + res.value[x]+ ']').prop('checked', true);
                            }
                        }
                    });
              
                }
            });
            CandidateApplicationManagementAjaxGateway.GetTSPList($(this).val(),function (res) {
                $('#TSP').dropdownSelect("option", "choices", teq.Common.DictionaryToArray(res.value));
            });
        });
        function CollectData(submitted)
        {
            var SelectedSubjects = [];
            $('#Subject input:checked').each(function () {
                SelectedSubjects.push($(this).attr('value'));
            });
            var entity = {
                CourseID: $('#Course').val(),
                ApplicationID: $('#ApplicationID').val(),
                FullName: $('#FullName').val(),
                DOB: $('#<%=ClientID %>_dpDOB').val(),
                Gender: $("input[name=Gender]:checked").val(),
                IC: $('#IC').val(),
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
                FatherName: $('#FatherName').val(),
                FatherIC: $('#FatherIC').val(),
                MotherName: $('#MotherName').val(),
                MotherIC: $('#MotherIC').val(),
                CombinedHouseholdIncome: $('#CombinedHouseholdIncome').val(),
                CurrentFieldOfStudy: $('#CurrentFieldOfStudy').val(),
                University: $('#University').val(),
                CGPA: $('#CGPA').val(),
                WithPQ:($("input[name=WithPQ]:checked").val() == 0) ? true : false,
                PQRegNo: $('#PQRegNo').val(),
                PQStartDate: $('#<%=ClientID %>_dpPQStartDate').val(),
                //LevelStartPQ: $("input[name=LevelStartPQ]:checked").val(),
                LevelStartPQ:$('#LevelStartPQ').val(),
                PQDealine: $('#<%=ClientID %>_dpPQDealine').val(),
                RegisteredNextExam: ($("input[name=NextExam]:checked").val() == 0) ? true : false,
                NextExam: $('#<%=ClientID %>_dpNextExam').val(),
                StudyPreferences: $("input[name=studyPreferences]:checked").val(),
                TSP: $('#TSP').val(),
                ScholarshipProvider: $('#ScholarshipProvider').val(),
                CostCoveredByScholarship: $('#CostCoveredByScholarship').val(),
                SelectedMonth: $('#IntakeMonth').val(),
                SelectedYear: $('#IntakeYear').val(),

                Agree: $('#Agree').prop('checked'),
                PDPA1: $('#PDPA1').prop('checked'),
                PDPA2: $('#PDPA2').prop('checked'),
                Submitted: submitted,
                SelectedSubject: SelectedSubjects,
                FileIC: UploadIC,
                CurrentFileIC:$("#<%=ClientID %>_FileIC").text(),
                FileBirthCertificate: UploadBirthCertificate,
                CurrentFileBirthCertificate:$("#<%=ClientID %>_FileBirthCertificate").text(),
                FileAcademicTranscript: UploadAcademicTranscript,
                CurrentFileAcademicTranscript:$("#<%=ClientID %>_FileAcademicTranscript").text(),
                FilePassport: UploadPassport,
                CurrentFilePassport:$("#<%=ClientID %>_FilePassport").text(),
                FilePQAcceptanceLetter: UploadPQAcceptanceLetter,
                CurrentFilePQAcceptanceLetter:$("#<%=ClientID %>_FilePQAcceptanceLetter").text(),
                //FileIC: $('#FileIC').prop('files')
                CurrentlyEmployed: $("input[name=CurrentlyEmployed]:checked").val(),
                Position: $('#Position').val(),
                Sector: $('#Sector').val(),
                Department: $('#Department').val(),
                CompanyName: $('#CompanyName').val(),
                CompanyContact: $('#CompanyContact').val(),
                CompanyAddress: $('#CompanyAddress').val()
                
            }
            return entity;
        }

        $("#<%=ClientID%>_btnSubmit,#<%=ClientID%>_btnSubmit2").click(function () {
            var ent = CollectData(true);
            CandidateApplicationManagementAjaxGateway.SaveApplication(ent, function (res) {
                if (res.value.length > 0) {
                    var errMessage = "";
                    for (var x = 0; x < res.value.length; x++) {
                        if (x > 0)
                            errMessage += "<br>";
                        errMessage += res.value[x].Name;
                    }
                    teq.Context.Alert(errMessage, null, function () {
                    });
                }
                else {
                    var msg = "Thank You! Your application has been submitted.";
                           $('#divMain').hide();
                        $('#divThankYou').show();
                        $('#divSubmitted').hide();
                        $("#<%=ClientID%>_btnSubmit,#<%=ClientID%>_btnSubmit2").hide();
                        $("#<%=ClientID%>_btnSaveDraft,#<%=ClientID%>_btnSaveDraft2").hide();
                    teq.Context.Alert(msg, null, function () {
                        //alert('hh');
                        //teq.Context.ShowPage(local.aspxContent_CandidateDashboard1);
                 
                    });
                }
            });
        });
       
        $("#<%=ClientID%>_btnSaveDraft,#<%=ClientID%>_btnSaveDraft2").click(function () {
            var ent = CollectData(false);
       
            CandidateApplicationManagementAjaxGateway.SaveApplication(ent, function (res) {
                if (res.value.length > 0) {
                    var errMessage = "";
                    for (var x = 0; x < res.value.length; x++) {
                        if (x > 0)
                            errMessage += "<br>";
                        errMessage += res.value[x].Name;
                    }
                    teq.Context.Alert(errMessage, null, function () {
                    });
                }
                else {
                    var msg = "Your application has been saved.";
                    teq.Context.ShowPage(local.aspxContent_CandidateDashboard1);
                    teq.Context.Alert(msg, null, function () {
                    });
                }
            });
            return false;
        });
    }
</script>