<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangeProfile.ascx.cs" Inherits="ChangeProfile" %>

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
    
    <center><div id="<%=ClientID%>_divProperty">
            <!--<div style="padding-top:10px; padding-bottom:5px; text-align:right;"><button id="<%=ClientID%>_btnNew"> New Work Order </button></div>-->
        <br /><br />
    </div>
    </center>

</div>    
<style>
.Button
{
 background-color:rgb(128, 128, 128);
 color:white;
 cursor:pointer; 
 padding:5px 5px 5px 5px; 
 border-radius:2px;
 height:10px;
 font-weight:bold;
 
}

.divModuleButton
{
    padding:1%;
    width:98%;

}
</style>