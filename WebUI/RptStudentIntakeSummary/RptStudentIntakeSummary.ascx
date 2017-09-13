<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RptStudentIntakeSummary.ascx.cs" Inherits="RptStudentIntakeSummary" %>

<div id="<%= ClientID%>_divMain" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Student Intake Summary Report</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <button id="<%=ClientID%>_btnExport">Export</button>
                </td>             
            </tr>
        </table>
    </div>
    
    <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                <tr>
                   
                    <td>
                        <table class="Form">
                            <tr>
                                 <td colspan="2" class="searchtitle" valign="top">Search</td>
                            </tr>
                            <tr>
                                <td>Intake Year Range :</td>
                                <td> 
                                    <select id="<%=ClientID%>_cboSearchYearFrom" class="searchshort"></select>
                                     ~ 
                                    <select id="<%=ClientID%>_cboSearchYearTo" class="searchshort"></select>
                                </td>
                            </tr>
                            <tr>
                                <td>TSP : </td>
                                <td>
                                    <div id="<%=ClientID%>_chkSearchTSP" />
                                </td>
                            </tr>
                            <tr>
                                <td>Course : </td>
                                <td>
                                    <div id="<%=ClientID%>_chkSearchCourse" />
                                </td>
                            </tr>
                            <tr>
                                <td>Sponsor : </td>
                                <td>
                                    <div id="<%=ClientID%>_chkSearchSponsor" />
                                </td>
                            </tr>
                            <tr>
                                <td>Status : </td>
                                <td>
                                    <div id="<%=ClientID%>_chkSearchStatus" />
                                </td>
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
        <div class="Wrap" style="width:100%; ">
            <div class="WrapPadding">
            <table class="List">
                <thead id="<%=ClientID%>_thdList"></thead>
                <tbody id="<%=ClientID%>_tbdList"></tbody>
                <tfoot id="<%=ClientID%>_tftList"></tfoot>
            </table>
            <table style="display:none" id="<%=ClientID%>_tblPager" class="Pager"></table>
            </div>
        </div>
    </div>
    <div style="height: 25px"></div>
    <div style="width: auto; overflow:auto; text-align: center" id="<%=ClientID%>_divChart"></div>
</div> 