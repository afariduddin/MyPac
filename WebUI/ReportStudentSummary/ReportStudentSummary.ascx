<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportStudentSummary.ascx.cs" Inherits="ReportStudentSummary" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Registered Student Report</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnExport"><span id="<%=ClientID%>_btnExport_SpanIcon"></span>Export Excel</button> 

                    <button id="<%=ClientID%>_btnShowSearch"><span id="<%=ClientID%>_btnShowSearch_SpanIcon"></span>Search <span id="<%=ClientID%>_btnShowSearch_SpanArrowIcon"></span></button> 
                </td>             
            </tr>
        </table>
    </div>
     <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                <tr>
                    <td class="LargeText" valign="top">Search</td>
                    <td>
                        <br /><br />
                        <table class="Form">
                            <tr>
                                <td>Student Name :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchName" style="WIDTH:200px;" value="test" /></td>
                            </tr>
                            <tr>
                                <td>Course :</td>
                                <td>
                                    <select>
                                        <option>ACCA</option>
                                        <option>ICAEW</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>Intake Year :</td>
                                <td><input type="text" style="WIDTH:100px;" /></td>
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
    </div>
    <div id="<%=ClientID%>_divList"><br />
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