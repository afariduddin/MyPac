<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CandidateContainer.aspx.cs" Inherits="CandidateContainer" %>

<%@ Register Src="~/Blank/Blank.ascx" TagName="Blank" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateDashboard/CandidateDashboard.ascx" TagName="CandidateDashboard" TagPrefix="uc1" %>

<%@ Register Src="~/CandidateApplication/CandidateApplication.ascx" TagName="CandidateApplication" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateChangePassword/CandidateChangePassword.ascx" TagName="CandidateChangePassword" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateChangeProfile/CandidateChangeProfile.ascx" TagName="CandidateChangeProfile" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateApplicationListing/CandidateApplicationListing.ascx" TagName="CandidateApplicationListing" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateAssessmentResult/CandidateAssessmentResult.ascx" TagName="CandidateAssessmentResult" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateCourseMonitoring/CandidateCourseMonitoring.ascx" TagName="CandidateCourseMonitoring" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateMentoring/CandidateMentoring.ascx" TagName="CandidateMentoring" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateVoluntaryWork/CandidateVoluntaryWork.ascx" TagName="CandidateVoluntaryWork" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateWorkHistory/CandidateWorkHistory.ascx" TagName="CandidateWorkHistory" TagPrefix="uc1" %>
<%@ Register Src="~/CandidateMIA/CandidateMIA.ascx" TagName="CandidateMIA" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="aspxContent" runat="Server">

    <div id="divLoggedIn" class="loggedIn">
        <div style="background-image: url('Resource/background.png'); background-repeat:repeat-x; height: 5px">&nbsp;</div>
                    
        <div style="background-color:#ffffff; color:#000000; width:100%; padding-bottom:5px;">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; height: 40px">
                <tr valign="middle">
                    <td style="padding-left: 10px; vertical-align: middle" width="10px"><img src="Resource/mypac_logo_small.png" /></td>
                    <td style="font-weight:normal; font-size:20px; padding-left:10px;">Candidate Registration System<%--MyPAC Candidate Database System--%></td>
                    <td align="right" style="padding-right:10px;">
                        <div id="divLoggedInInfo" style="display:none; height:inherit;  text-align:right; ">
                            Logged in as <span id="LoginName"></span> &#149; <a href="#" id="btnLogOut" title="Logout from the system"  style="cursor:pointer;"> Logout </a>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <div id="menu" class="mainMenu">

            <div style="width:100%; overflow-y: auto; overflow-x:hidden;">
                <div id="mnu_Dashb0" class="menu">
                    <div id="tt_Dash0" class="ui-menu menuHeader" onclick="teq.Context.ShowPage(local.aspxContent_CandidateDashboard1);">                        <img src="Resource/icon-register.png" height="20px" alt="">
                        <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;HOME</span>                        
                    </div>
                </div>
                <div id="mnu_Dashb1" class="menu">
                    <div id="tt_Dash1" class="ui-menu menuHeader" onclick="teq.Context.ShowPage(local.aspxContent_CandidateApplication1);">
                        <img src="Resource/icon-register.png" height="20px" alt="">
                        <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;NEW APPLICATION</span>
                    </div>
                </div>
              <div id="mnu_Dashb8" style="color: black; width: 100%; margin: 0% 3% 3% 2%; background-color: rgb(204,204,204);">
                    <div id="tt_Dash8" class="ui-menu menuHeader" onclick="teq.Context.ShowPage(local.aspxContent_CandidateCourseMonitoring1);">
                        <img src="Resource/icon-navigation.png" height="20px" alt="" />
                        <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;COURSE MONITORING</span>
                    </div>
                </div>
                <div id="mnu_Dashb4" style="color: black; width: 100%; margin: 0% 3% 3% 2%; background-color: rgb(204,204,204);">
                    <div id="tt_Dash4" class="ui-menu menuHeader" onclick="teq.Context.ShowPage(local.aspxContent_CandidateMentoring1);">
                        <img src="Resource/icon-student.png" height="20px" alt="Road Info">
                        <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;<%--COACHING & MENTORING--%>COUNSELLING & COACHING</span>
                    </div>
                </div>
                <div id="mnu_Dashb7" style="color: black; width: 100%; margin: 0% 3% 3% 2%; background-color: rgb(204,204,204);">
                    <div id="tt_Dash7" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                            <img src="Resource/icon-alumni.png" height="20px" alt="ALUMNI">
                        <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;ALUMNI</span>
                        <span class='ui-icon ui-icon-triangle-1-e' style='display: inline-block; position: relative; top: -1px; margin-right: 10px; float: right;'></span>
                    </div>
                    <div id="it_tt_Dash7" class="menu-dropdown">
                        <div>
                            <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                            <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CandidateVoluntaryWork1);">Voluntary Work</span>
                        </div>
                            <div>
                            <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                            <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CandidateWorkHistory1);">Work History</span>
                        </div>
                        <div>
                            <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                            <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CandidateMIA1);">MIA</span>
                        </div>
                    </div>
                </div>
                <div id="mnu_Dashb10" class="menu">
                    <div id="tt_Dash10" class="ui-menu menuHeader" onclick="ToggleDashMenu(this);">
                        <img src="Resource/icon-account.png" height="20px" alt="Work list" />
                            <span style="color: #FFF; position: absolute; top: 50%; margin-top: -8px;">&nbsp;MY ACCOUNT</span>
                        <span class='ui-icon ui-icon-triangle-1-e' style='display: inline-block; position: relative; top: -1px; margin-right: 10px; float: right;'></span>
                    </div>
                    <div id="it_tt_Dash10" class="menu-dropdown">
                        <div>
                            <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                            <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CandidateChangeProfile1);">Profile</span>
                        </div>
                        <div>
                            <span class='ui-icon ui-icon-triangle-1-e arrow'></span>
                            <span class="item" onclick="teq.Context.ShowPage(local.aspxContent_CandidateChangePassword1);">Change Password</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        

        <div id="divToggleMenu" align="center" class="menuToggle">            
            <table cellpadding="0" cellspacing="0" style="height:inherit;">
                <tr valign="middle">
                    <td >
                        <img id="imgToggle" src="Resource/arrow-left.png" style="height:18px; width:18px; max-height:9px; max-width:9px; " alt="expand" />
                    </td>
                </tr>
            </table>
            
        </div>

        <div id="mainContent" style="WIDTH:78.8%; HEIGHT:99%;  float:left;" >
            <div id="navigationTrails" style="WIDTH:100%; HEIGHT:3%; padding-bottom:10px;"></div>
            
            <div style="overflow-y:auto; width:100%; HEIGHT:92%; padding-top:5px;">
                <uc1:Blank ID="Blank1" runat="server" />
                <uc1:CandidateDashboard ID="CandidateDashboard1" runat="server" />
                <uc1:CandidateApplication ID="CandidateApplication1" runat="server" />
                 <uc1:CandidateChangePassword ID="CandidateChangePassword1" runat="server" />
                  <uc1:CandidateChangeProfile ID="CandidateChangeProfile1" runat="server" />
                  <uc1:CandidateApplicationListing ID="CandidateApplicationListing1" runat="server" />
                  <uc1:CandidateAssessmentResult ID="CandidateAssessmentResult1" runat="server" />
                <uc1:CandidateCourseMonitoring ID="CandidateCourseMonitoring1" runat="server" />
                <uc1:CandidateMentoring ID="CandidateMentoring1" runat="server" />
                 <uc1:CandidateVoluntaryWork ID="CandidateVoluntaryWork1" runat="server" />
                  <uc1:CandidateWorkHistory ID="CandidateWorkHistory1" runat="server" />
                  <uc1:CandidateMIA ID="CandidateMIA1" runat="server" />
            </div>

        </div>



    </div>
    <div id="advanceSearch"></div>
    <script type="text/javascript">
        $(function ()
        {
            //$("#txtSigninID").val("c004"); // JK:tmp
            //$("#txtPassword").val("c004"); // JK:tmp

            local.InitAjaxPro();
            //teq.Context.ShowPage(local.aspxContent_Blank1);
            teq.Context.ShowPage(local.aspxContent_CandidateDashboard1);


            local.ContainerInit();
        });

        local.AdvancedSearchMode = null;
        local.AdvancedSearchModule = null;

        CandidateContainerAjaxGateway.ValidateSession(function (res) {
            if (res.value.length == 0) {
            }
            else {
                window.location.href = "CandidateSignIn.aspx";
            }
        });

        local.ContainerInit = function ()
        {
            CandidateContainerAjaxGateway.GetCandidateType(function (res) {

                $('#LoginName').text(res.value.UserID);

                $('#divLoggedIn').show();
                $('#divLoggedInInfo').show();
                $('#divMyPresetFilter').show();

                //alert(res.value.Code);
                $('#mnu_Dashb8').hide();
                $('#mnu_Dashb4').hide();
                $('#mnu_Dashb7').hide();
                if (res.value.ret.Code == FlagCodes.CandidateType.Candidate) {

                }
                else if (res.value.ret.Code == FlagCodes.CandidateType.Alumni) {
                    $('#mnu_Dashb8').show();
                    $('#mnu_Dashb4').show();
                    $('#mnu_Dashb7').show();
                } else if (res.value.ret.Code == FlagCodes.CandidateType.Student) {
                    $('#mnu_Dashb8').show();
                    $('#mnu_Dashb4').show();
                }

            });

            var hide = true;

            //divToggleMenu 
            {
                $("#divToggleMenu").attr("title", "Hide The Menu Bar");
                //$("#toggle").css("background", "url('Resource/btnToggleMenu.png')");
                //$("#divToggleMenu").append(imgToggle);
                //$("#toggle").button({
                //    icons: { primary: "ui-icon-circle-arrow-w" },
                //    text: false
                //});
                $("#imgToggle").hide();
                $("#divToggleMenu").mouseenter(function ()
                {

                    //imgToggle.attr("src", "Resource/btnToggleMenu.png");
                    //imgToggle.animate({ opacity: 1 }, 10);

                    $("#imgToggle").show();
                    $("#divToggleMenu").css("background-color", "rgb(68,68,68)");


                })
                $("#divToggleMenu").mouseleave(function ()
                {

                    //imgToggle.attr("src", "Resource/btnToggleMenu_hover.png");
                    //imgToggle.animate({ opacity: 0.5 }, 10);
                    //$(this).animate({ opacity: 1 }, 10);
                    //if (hide != false) {
                    $("#divToggleMenu").css("background-color", "transparent");
                    $("#imgToggle").hide();
                    //}


                })

                $("#divToggleMenu").on('click', function (e)
                {
                    e.preventDefault();

                    if (hide == true)
                    {
                        $("#divToggleMenu").attr("title", "Expand The Menu Bar");
                        //$("#toggle").button({
                        //    icons: { primary: "ui-icon-circle-arrow-e" },
                        //    text: false
                        //});
                        $("#divToggleMenu").css("background-color", "rgb(68,68,68)");
                        $("#imgToggle").hide();
                        $("#imgToggle").attr("src", "Resource/arrow-right.png");
                        $('#menu').hide("slide", function ()
                        {
                            $('#mainContent').css("width", '99.5%');

                        });
                        hide = false;

                        //document.getElementById("gisframe").width = 1250;
                    }
                    else
                    {
                        $('#mainContent').css("width", '79.5%');
                        $("#divToggleMenu").attr("title", "Hide The Menu Bar");
                        //$("#toggle").button({
                        //    icons: { primary: "ui-icon-circle-arrow-w" },
                        //    text: false
                        //});
                        $("#divToggleMenu").css("background-color", "transparent");
                        $("#imgToggle").hide();
                        $("#imgToggle").attr("src", "Resource/arrow-left.png");
                        $('#menu').show("slide", function ()
                        {
                            $('#mainContent').css("width", '78.8%');

                        });
                        hide = true;
                        //alert(window.innerWidth)

                        //document.getElementById("gisframe").width = 1000;
                    }
                });
            }
            var imgToggle = $(" <img src='Resource/btnToggleMenu.png' style='width:80%;' /> ")
            //var imgToggleHide = $(" <img src='Resource/btnToggleMenu.png' /> ")

            $("#toggle").attr("title", "Hide The Menu Bar");
            //$("#toggle").css("background", "url('Resource/btnToggleMenu.png')");
            $("#toggle").append(imgToggle);
            //$("#toggle").button({
            //    icons: { primary: "ui-icon-circle-arrow-w" },
            //    text: false
            //});

            $("#toggle").mouseout(function ()
            {

                //imgToggle.attr("src", "Resource/btnToggleMenu.png");
                imgToggle.animate({ opacity: 1 }, 10);

            })
            $("#toggle").mouseover(function ()
            {

                //imgToggle.attr("src", "Resource/btnToggleMenu_hover.png");
                imgToggle.animate({ opacity: 0.5 }, 10);
                //$(this).animate({ opacity: 1 }, 10);

            })

            $('#toggle').on('click', function (e)
            {
                e.preventDefault();

                if (hide == true)
                {
                    $("#toggle").attr("title", "Expand The Menu Bar");
                    //$("#toggle").button({
                    //    icons: { primary: "ui-icon-circle-arrow-e" },
                    //    text: false
                    //});
                    $('#menu').hide("slide", function ()
                    {
                        $('#mainContent').css("width", '97.9%');

                    });
                    hide = false;
                }
                else
                {
                    $('#mainContent').css("width", '77.9%');
                    $("#toggle").attr("title", "Hide The Menu Bar");
                    //$("#toggle").button({
                    //    icons: { primary: "ui-icon-circle-arrow-w" },
                    //    text: false
                    //});
                    $('#menu').show("slide", function ()
                    {
                        $('#mainContent').css("width", '77.9%');
                    });
                    hide = true;
                }
            });
            var divAdvanceSearch = $("#advanceSearch");

            //$("#btnLogIn").on('click', function ()
            //{

            //    var SignInID = $('#txtSigninID');
            //    var Password = $('#txtPassword');

            //    CandidateContainerAjaxGateway.SignIn(SignInID.val(), Password.val(), function (res) {
            //        if (res.value.length == 0) {
            //            $('#divLoggin').hide();
            //            $('#divLoggedIn').show();
            //            $('#divLoggedInInfo').show();
            //            $('#divMyPresetFilter').show();
            //            $('#LoginName').text(SignInID.val());


                       
            //        }
            //        else {
            //            var errMessage = "";
            //            for (var x = 0; x < res.value.length; x++) {
            //                if (x > 0)
            //                    errMessage += "<br>";
            //                errMessage += res.value[x].Name;
            //            }
            //            teq.Context.Alert(errMessage, null, function () {
            //            });
            //        }
            //    });

            //});

            $("#btnLogOut").on('click', function ()
            {
                CandidateContainerAjaxGateway.SignOut(function (res) {
                    window.location = "CandidateSignIn.aspx";
                });
            });

            {
                $("#divMyPresetFilter").mousedown(function ()
                {

                    //$(this).animate({ opacity: 0.3 }, 10);

                })
                //$("#divMyPresetFilter").mouseup(function () {

                //    $(this).animate({ opacity: 1 }, 10);

                //})
                $("#divMyPresetFilter").mouseleave(function ()
                {

                    //$(this).animate({ opacity: 1 }, 10);

                })
                $("#divMyPresetFilter").mouseenter(function ()
                {

                    // $(this).animate({ opacity: 0.6 }, 10);

                })
            }

            $("#divMyPresetFilter").on('click', function ()
            {
                local.AdvancedSearchMode = null;
                local.BuildAdvancedSearchDialogController(divAdvanceSearch);
            });

            {
                $(".button").mousedown(function ()
                {

                    $(this).animate({ opacity: 0.1 }, 10);

                })
                $(".button").mouseup(function ()
                {

                    $(this).animate({ opacity: 1 }, 10);

                })
                $(".button").mouseout(function ()
                {

                    $(this).animate({ opacity: 1 }, 10);

                })
                $(".button").mouseenter(function ()
                {

                    $(this).animate({ opacity: 0.8 }, 10);

                })
            }

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

                CandidateContainerAjaxGateway.RetrievePassword(SignInID.val(), function (res) {
                    if (res.value.length == 0) {
                        $("#candidateLogin").css('display', 'inline-block');
                        $("#candidateForgotPassword").css('display', 'none');
                        SignInID.val('');
                        var msg = "Thank You! We will send you the password by email which is registed in our system. <br /> Please check your email in 10 minutes";
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
            //DEBUG
            //$("#btnLogIn").click();
        }

        local.navigationTrailsBuild = function (navigationTrails)
        {
            var divNavigationTrails = $("#navigationTrails");
            divNavigationTrails.empty();
            var span = $("<span>");
            var table = $("<table cellpadding='0' cellspacing='0' style='width:100%;'>");
            var tr = $("<tr vallign='middle'>");
            var td = $("<td class='breadCrumb'>");
            table.append(tr);
            tr.append(td);

            var spanhome = $("<span style='width:12px;height:12px; padding:2px 0px 0px 0px; vertical-align:top; '>");
            spanhome.button({
                icons: { primary: "ui-icon-home" },
                text: false
            });
            spanhome.click(function ()
            {
                //teq.Context.ShowPage(local.aspxContent_Blank1);
                teq.Context.ShowPage(local.aspxContent_Dashboard1);
            });
            td.append(spanhome);
            td.append("&nbsp;");
            td.append(span);


            divNavigationTrails.append(table);
            for (i = 0 ; i < navigationTrails.length ; i++)
            {
                var navigationTrail = navigationTrails[i];

                if (navigationTrails.length == 1 || i == (navigationTrails.length - 1))
                {
                    addLink(span, false);
                }
                else
                {
                    addLink(span, true);
                }
            }


            function addLink(span, next)
            {
                var spaninner = $("<span >");
                span.append(spaninner);
                if (next)
                {
                    span.append(" > ");
                }
                var spanInnerByID = $("#spanNavigation_" + i);
                spaninner.css("cursor", "pointer");
                spaninner.html(navigationTrail.Name);
                var link = navigationTrail.Link;
                spaninner.click(function ()
                {
                    teq.Context.ShowPage(link);
                });

                //span.append(spanInnerByID);
                {//set animation
                    spaninner.mousedown(function ()
                    {
                        $(this).animate({ opacity: 0.1 }, 10);
                    })
                    spaninner.mouseup(function ()
                    {
                        $(this).animate({ opacity: 1 }, 10);
                    })
                    spaninner.mouseout(function ()
                    {
                        $(this).animate({ opacity: 1 }, 10);
                    })
                    spaninner.mouseenter(function ()
                    {
                        $(this).animate({ opacity: 0.8 }, 10);
                    })
                }
            }
        }
        local.ShowPage = function (page, callback)
        {
            var _callBack = null;
            _callBack = callback;
            var _page = null;
            _page = page;
            var divAdvanceSearch = $('#advanceSearch');
            local.BuildAdvancedSearchDialogController(divAdvanceSearch, null, function ()
            {
                if (_callBack != null) _callBack();
                if (_page != null) teq.Context.ShowPage(_page, true);
            });
        }

        function ToggleDashMenu(obj)
        {
            if ($('#it_' + obj.id).is(":visible"))
            {
                $('#it_' + obj.id).slideUp();
                $('#' + obj.id).children(".ui-icon").removeClass("ui-icon-triangle-1-s").addClass("ui-icon-triangle-1-n");
            }
            else
            {
                $('#it_' + obj.id).slideDown();
                $('#' + obj.id).children(".ui-icon").removeClass("ui-icon-triangle-1-n").addClass("ui-icon-triangle-1-s");
            }
        }

    </script>
</asp:Content>


