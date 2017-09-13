<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdministratorSignIn.aspx.cs" Inherits="AdministratorSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="formContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aspxContent" Runat="Server">
    <div id="divLoggin" align="center" style="width:100%; height:80%; display:block; ">
    <div style="display:block; width:100%; background-image: url('Resource/background.png'); background-repeat:repeat-x; margin-bottom:30px;">
        <table style="height:inherit; width:100%; padding-top:20px;" cellpadding="0" cellspacing="0" border="0" >
            <tr >
                <td style="height:inherit; font-size:25px; font-weight:bold; color:#363636;"> 
                    <div style="cursor:pointer; text-align: center">
                        <img src="Resource/mypac_Logo.png" alt="Medini LOGO"  style="vertical-align:middle; " />
                        <br /><br />
                        <span>Candidate Database System</span>
                        <br />
                        <span>Administrator Login</span>
                    </div>
                    </td>
            </tr>
        </table>       
    </div>
        <br />
        <div style="background-color:#ffbb6e; border:1px solid #f8982a; min-width:300px; display:inline-block;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr><td style="height:20px;"></td></tr>
                <tr >
                    <td colspan="2" style="color:black; font-weight:bold">
                        Please enter User ID and Password
                    </td>                
                </tr>
                <tr><td style="height:20px;"></td></tr>
                <tr>
                    <td align="left">User ID :</td >
                    <td><input type="text" id="txtSigninID" value=""/></td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr>
                    <td align="left" style="padding-right:20px;">Password :</td>
                    <td><input id="txtPassword" type="password" value=""/></td>
                </tr>
                <tr><td style="height:10px;"></td></tr>
                <tr >
                    <td colspan="2" align="right" style="padding-left:0px; padding-right:0px; padding-top:0px; padding-bottom:20px; margin:0px;">
                        <br />
                        <span id="btnSignIn" class="button" title="Login with Staff ID and Password" style="background-color:white; cursor:pointer; color:black; font-weight:bold; padding:5px 13px 5px 13px;">Login</span>
                        <br /><br />
                    </td>               
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            local.InitAjaxPro();
            local.ContainerInit();
        });

        local.ContainerInit = function () {
            $("#btnSignIn").on('click', function () {
                var SignInID = $('#txtSigninID');
                var Password = $('#txtPassword');

                AdministratorSignInAjaxGateway.SignIn(SignInID.val(), Password.val(), function (res) {
                    if (res.value.length == 0) {
                        window.location.href = "Container.aspx";
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


                //}

                ////$('#divLoggin').hide();
                //if ($('#txtLoginId').val().toLowerCase() == "new") {
                //    local.BuildAdvancedSearchDialogController(, function (res) {

                //        $('#divLoggedIn').show();
                //        $('#divLoggedInInfo').show();
                //        $('#divMyPresetFilter').show();
                //    });
                //}
                //else {
                //    $('#divLoggedIn').show();
                //    $('#divLoggedInInfo').show();
                //    $('#divMyPresetFilter').show();
                //}
            });

            $("#btnLogOut").on('click', function () {
                window.location = "Container.aspx";
            });



            }


    </script>
</asp:Content>

