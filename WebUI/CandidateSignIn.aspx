<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CandidateSignIn.aspx.cs" Inherits="CandidateSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="formContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aspxContent" Runat="Server">
    <div id="divLoggin" align="center" style="width:100%; height:80%; display:block;">
    <div style="display:block; width:100%; background-image: url('Resource/background.png'); background-repeat:repeat-x; margin-bottom:30px;">
        <table style="height:inherit; width:100%; padding-top:20px;" cellpadding="0" cellspacing="0" border="0" >
            <tr >
                <td style="height:inherit; font-size:25px; font-weight:bold; color:#363636; "> 
                    <div style="cursor:pointer; text-align: center">
                        <img src="Resource/mypac_Logo.png" alt="MyPAC"  style="vertical-align:middle; " />
                        <br /><br />
                        <span>Candidate Database System</span>
                        <br />
                        <span>Candidate Login</span>
                    </div>
                    </td>
            </tr>
        </table>       
    </div>
        <br />
        <div id="candidateLogin" style="background-color:#82ddff; border:1px solid #40c2f3; min-width:300px; display:inline-block;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr><td style="height:20px;"></td></tr>
                <tr>
                    <td colspan="2" style="color:black; font-weight:bold">
                        Please enter User ID and Password
                    </td>
                </tr>
                <tr><td style="height:20px;"></td></tr>
                <tr>
                    <td align="left">User ID :</td>
                    <td align="left"><input type="text" id="txtSigninID" placeholder="User ID" /></td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td align="left" style="padding-right:20px;">Password :</td>
                    <td align="left"><input type="password" id="txtPassword" placeholder="Password" /></td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td colspan="2" align="right" style="padding-left:0px; padding-right:0px; padding-top:0px; padding-bottom:20px; margin:0px;">
                        <br />
                        <span id="btnForgotPassword" class="button" title="Retrive Password via registered Email" style="background-color: white; cursor: pointer; color: black; font-weight: bold; padding: 5px 13px 5px 13px;">Forgot Password</span>
                        &nbsp
                        <span id="btnLogIn" class="button" title="Login with Staff ID and Password" style="background-color: white; cursor: pointer; color: black; font-weight: bold; padding: 5px 13px 5px 13px;">Login</span>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>

         <div id="candidateForgotPassword" style="background-color:#82ddff; border:1px solid #40c2f3; min-width:300px; display:none;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr><td style="height:20px;"></td></tr>
                <tr>
                    <td colspan="2" style="color:black; font-weight:bold">
                        Please enter User ID to retrieve password
                    </td>
                </tr>
                <tr><td style="height:20px;"></td></tr>
                <tr>
                    <td align="left">User ID :</td>
                    <td align="left"><input type="text" id="txtSigninIDForRetrieve" placeholder="User ID" /></td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td colspan="2" align="right" style="padding-left:0px; padding-right:0px; padding-top:0px; padding-bottom:20px; margin:0px;">
                        <br />
                        <span id="btnBackToLogin" class="button" title="Back to login screen" style="background-color: white; cursor: pointer; color: black; font-weight: bold; padding: 5px 13px 5px 13px;">Back</span>
                        &nbsp
                        <span id="btnRetrievePassword" class="button" title="Retrieve password via registered Email" style="background-color: white; cursor: pointer; color: black; font-weight: bold; padding: 5px 13px 5px 13px;">Retrieve Password</span>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function ()
        {
            local.InitAjaxPro();
            local.ContainerInit();
        });

        local.ContainerInit = function ()
        {
            $("#btnLogIn").on('click', function ()
            {

                var SignInID = $('#txtSigninID');
                var Password = $('#txtPassword');

                CandidateSignInAjaxGateway.SignIn(SignInID.val(), Password.val(), function (res) {
                    if (res.value.length == 0) {
                        window.location.href = "CandidateContainer.aspx";
                    }
                    else {
                        var errMessage = "";
                        for (var x = 0; x < res.value.length; x++) {
                            if (x > 0)
                                errMessage += "<br>";
                            errMessage += res.value[x].Name;
                        }
                        teq.Context.Alert(errMessage, null, function () {
                        });
                    }
                });

            });

            
            $("#btnForgotPassword").on('click', function () {
                $("#candidateLogin").css('display', 'none');
                $("#candidateForgotPassword").css('display', 'inline-block');
                
            });
            $("#btnBackToLogin").on('click', function () {
                $("#candidateLogin").css('display', 'inline-block');
                $("#candidateForgotPassword").css('display', 'none');

            });
            
            $("#btnRetrievePassword").on('click', function () {


                var SignInID = $('#txtSigninIDForRetrieve');

                CandidateSignInAjaxGateway.RetrievePassword(SignInID.val(), function (res) {
                    if (res.value.length == 0) {
                        $("#candidateLogin").css('display', 'inline-block');
                        $("#candidateForgotPassword").css('display', 'none');
                        SignInID.val('');
                        var msg = "Thank You! We will send you the password by email which is registered in our system. <br /> Please check your email in 10 minutes";
                        teq.Context.Alert(msg, null, function () {
                        
                        });
                    
                    }
                    else {
                        var errMessage = "";
                        for (var x = 0; x < res.value.length; x++) {
                            if (x > 0)
                                errMessage += "<br>";
                            errMessage += res.value[x].Name;
                        }
                        teq.Context.Alert(errMessage, null, function () {
                            $("#candidateLogin").css('display', 'none');
                            $("#candidateForgotPassword").css('display', 'inline-block');
                        });
                    }
                });


            });
        
        }
    </script>
</asp:Content>

