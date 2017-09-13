<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="ChangePassword" %>

<div id="<%= ClientID%>_divMain" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%=ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Change Password</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnSave">Save</button>
                </td>             
            </tr>
        </table>
    </div>
    
    <center>
        <table >
            <tr>
                <td  align="left" style="padding:5px; color:black;">
                    Current Password
                </td >
                <td align="center"style="padding:5px; color:black;">:</td>
                <td style="padding:5px;">
                            <input type="password" class="property" id="<%= ClientID%>_txtCurrentPassword"/>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding:5px; color:black;">
                    New Password:
                </td>
                <td align="center" style="padding:5px; color:black;">:</td>
                <td style="padding:5px;">
                        <input id="<%= ClientID%>_txtNewPassword" class="property" type="password" />
                </td>
            </tr>
            <tr>
                <td align="left" style="padding:5px; color:black;">
                    Confirm Password:
                </td>
                <td align="center" style="padding:5px; color:black;">:</td>
                <td style="padding:5px;">
                        <input id="<%= ClientID%>_txtConfirmPassword" class="property" type="password" />
                </td>
            </tr>
        </table>
    </center>

</div>