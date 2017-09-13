<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegistrationDataProcessing.ascx.cs" Inherits="RegistrationDataProcessing" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Data Processing</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch"><span id="<%=ClientID%>_btnShowSearch_SpanIcon"></span>Please Select Task <span id="<%=ClientID%>_btnShowSearch_SpanArrowIcon"></span></button> 
                </td>             
            </tr>
        </table>
    </div>
     <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table>
                <tr>
                    <td>
                        <div id="<%=ClientID%>_divModuleBtn"></div>
                    </td>
                </tr>
                <tr>
                    <td align="right"> 
                        <button id="<%=ClientID%>_btnPinSearch"></button>

                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="<%=ClientID%>_divList">
        <div style="padding-top:10px; padding-bottom:5px; text-align:right;"><button id="<%=ClientID%>_btnNew"> New </button></div>

        <div class="Wrap" >
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