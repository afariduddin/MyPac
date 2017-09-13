<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateChangeProfile.ascx.cs" Inherits="CandidateChangeProfile" %>

<div id="<%= ClientID%>_divMain" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%=ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">My Profile</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnSave">Save</button>
                </td>             
            </tr>
        </table>
    </div>
    
    <center>
        <div class="WrapPadding">
            <div id="<%=ClientID%>_divProperty"></div>
        </div>
    </center>
    <% 
        Response.WriteFile("EthnicityList.html");
        Response.WriteFile("AustraliaUniversityList.html");
        Response.WriteFile("MalaysiaUniversityList.html");
        Response.WriteFile("NewZealandUniversityList.html");
        Response.WriteFile("SingaporeUniversityList.html");
        Response.WriteFile("UKUniversityList.html");
    %>
</div>