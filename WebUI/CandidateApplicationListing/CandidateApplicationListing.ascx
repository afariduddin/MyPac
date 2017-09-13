<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateApplicationListing.ascx.cs" Inherits="CandidateApplicationListing" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Application List</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                 <%--   <button id="<%=ClientID%>_btnAssign">Bulk Assign Assessment Session</button>--%>
                </td>             
            </tr>
        </table>
    </div>
    
    <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                <tr>
                    <td class="largetext" valign="top">Search Application List</td>
                    <td>
                        <table class="Form">
                      
                            <tr>
                                <td>Contract Type :</td>
                                <td><select id="<%=ClientID%>_selSearchContractType">
                                    <option>- Select All - </option>
                                    <option>Full Time</option>
                                    <option>Part Time</option>
                                    </select></td>
                            </tr>
                            <tr>
                                <td>Location :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchLocation" style="WIDTH:200px;" /></td>
                            </tr>
                        </table>
                    </td>
                    <td valign="bottom">
                        <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                            <tr valign="top"><td align="right" style="PADDING-BOTTOM:5px;"><button id="<%=ClientID%>_btnPinSearch"></button></td></tr>
                            <tr valign="bottom"><td align="right"><button id="<%=ClientID%>_btnSearch">Search</button></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br style="CLEAR:both;" />
    </div>

    <div id="<%=ClientID%>_divList">
            <!--<div style="padding-top:10px; padding-bottom:5px; text-align:right;"><button id="<%=ClientID%>_btnNew"> New Work Order </button></div>-->
        <br /><br />
        
        <div class="Wrap" style="width:99%; ">
            <table class="List">
                <thead id="<%=ClientID%>_thdList"></thead>
                <tbody id="<%=ClientID%>_tbdList"></tbody>
            </table>
            <table id="<%=ClientID%>_tblPager" class="Pager"></table>
        </div>
    </div>

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