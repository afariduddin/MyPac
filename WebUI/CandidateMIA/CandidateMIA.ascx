<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateMIA.ascx.cs" Inherits="CandidateMIA" %>
<style>
    table.application button {
        font-size: 1.2em !important;
        margin-top: 10px;
    }

    .mark_notice {
        width: 16px;
        height: 16px;
        display: inline-block;
        position: relative;
        top: 1px;
        right: 3px;
        background-image: url(/Components/Css/smoothness/ui-icons_cd0a0a_256x240.png);
        background-position: -32px -144px;
    }

    .address {
        margin-top: 10px;
        width: 300px;
    }

    .gap {
        margin-left: 10px;
        margin-right: 10px;
    }

    table.application {
        width: 100%;
    }

        table.application td {
            /*border:1px black solid;*/
            padding: 10px;
            vertical-align: top;
        }
</style>

<div class="PageHeader">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="middle">
            <td>
                <span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">MIA Information</span>
            </td>
            <td align="right">
                <button id="<%=ClientID%>_btnSubmit">Submit</button>
            </td>
        </tr>
    </table>
</div>
<div style="width:100%;">

     <div class="WrapPadding">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFormRegister" width="100%">
<%--        <tr>
            <td>
                <img src="Components/Css/global/logo.png" />
            </td>
            <td style="vertical-align: middle;">
                <h1>MIA Information</h1>
            </td>
        </tr>--%>
         <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">MIA</td></tr>
        <tr>
            <td colspan="2" style="padding:20px;">
                <input type="hidden" id="CandidateID" />
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
          
<%--                 
                    <tr>
                        <td colspan="2">
                            <h3>MIA</h3>
                        </td>
                    </tr>--%>
             <%--       <tr>
                        <td><span class="mark_notice"></span>MIA Member Account Number :
                        </td>
                        <td>
                            <input type="text" placeholder="MIA Member Account Number" style="width:400px" />
                        </td>
                    </tr>--%>
                      <tr>
                            <td class="label"><span class="requiredfield"></span>MIA Member Account Number:</td>
                            <td><input type="text" placeholder="MIA Member Account Number" class="standardform" id="MIAAccountNumber" /></td>
                        </tr>
                    </table>

                </td>
            </tr>


          <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Additional Attachments</td></tr>

            <tr>
            <td colspan="2" style="padding:20px;">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                       <%-- <td>
                                          <span class="mark_notice"></span>MIA Certificate:
                                        </td>--%>
                                     <td class="label"><span class="requiredfield"></span>MIA Certificate:</td>
                                        <td>
                                            <%--<input type="file" class="standardform" />--%>
                                              <a download='' href='' id="<%=ClientID %>_FileMIA"></a>
                                <div id="FileMIA"></div>
                                             <div>
                                                <label style="min-height: 13px;"> Max filesize 2MB. Accepted file format: pdf, jpg, jpeg, png, gif </label>
                                                </div>
                                        </td>
                                 </tr>
                            </table>
                    </td>
            </tr>

            
          <tr><td style="padding:10px; background:#68a4ff; font-weight:bold; color:white;">Declaration</td></tr>

            <tr>
            <td colspan="2" style="padding:20px;">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                              <tr>
                        <td colspan="2">
                            I hereby certify that all statements made in this application are true and complete to the best of my knowledge and have not withheld any information which might influence the consideration of this application. I understand that any misrepresentation / false declaration or omission will be sufficient cause for cancellation of consideration for this application. I also authorise any investigation of the above information for the purpose of verification.
                            <br /><br />
                            <label><input type="checkbox" id="<%= ClientID%>_Agree" /> I Agree with the declaration terms</label>
                        </td>
                    </tr>
                            </table>
                    </td>
            </tr>
                    
                    
       
         

                </table>
    </div>
</div>
<script>





    if (!window.jQuery) {
        alert("jQuery not loaded");
    }
    else {
        var UploadMIA;
        teq.Common.BuildSingleFileUploadInput($('#FileMIA'), '150px', "FileUploadInput", "FileUploadInputHover", "myFile", 2000000, ["pdf", "jpg", "jpeg", "png", "gif"], 
            function (res) {
                if (res.error == null) {
                    if (res == null) {

                    }
                    else {
                        UploadMIA = res;
                    }

                }
            }
            );





        function CollectData()
        {
     
            //alert($('#<%=ClientID%>_Agree').prop('checked'));
            var entity = {
                CandidateID: $('#CandidateID').val(),
                MIAAccountNumber : $('#MIAAccountNumber').val(),
                Agree: $('#<%=ClientID%>_Agree').prop('checked'),
                FileMIA: UploadMIA,
                CurrentFileMIA:$("#<%=ClientID %>_FileMIA").text()
                
            }
            return entity;
        }

        $("#<%=ClientID%>_btnSubmit").click(function () {
            var ent = CollectData();
           CandidateMIAAjaxGateway.SaveCandidate(ent, function (res) {
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
                    var msg = "Thank You! Your information has been saved.";
                   // LoadData();
                    teq.Context.Alert(msg, null, function () {
                        // $('#FileMIA').element_reset();
                       // alert($('#FileMIA').val());
                        teq.Context.ShowPage(local.aspxContent_CandidateDashboard1);
                    });
                }
            });
        });
       
    }
</script>