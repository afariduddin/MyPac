<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RptStudentProgressSummary.ascx.cs" Inherits="RptStudentProgressSummary" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="width: 100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr valign="middle">
                <td><span id="<%= ClientID%>_spanTitle" style="font-weight: bold; font-size: 1.1em;">Student Progress Summary Report</span></td>
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <button id="<%=ClientID%>_btnExport">Export</button>
                </td>
            </tr>
        </table>
    </div>

    <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="height: 100%;">
                <tr>
                    <td>
                        <table class="Form">
                            <tr>
                                <td colspan="2" class="searchtitle" valign="top">Search</td>
                            </tr>
                            <tr>
                                <td>Intake Date Range :</td>
                                <td>
                                    <input type="text" id="<%=ClientID%>_dpSearchIntakeFrom" class="searchdate" />
                                    ~ 
                                <input type="text" id="<%=ClientID%>_dpSearchIntakeTo" class="searchdate"/></td>
                            </tr>
                            <tr>
                                <td>Full Name :</td>
                                <td>
                                    <input type="text" id="<%=ClientID%>_txtSearchFullName" class="search" /></td>
                            </tr>
                            <tr>
                                <td>Gender :</td>
                                <td>
                                    <select id="<%=ClientID%>_selSearchGender" class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Contract Type :</td>
                                <td>
                                    <select id="<%=ClientID%>_selSearchContractType" class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Sponsorship Type :</td>
                                <td>
                                    <div id="<%=ClientID%>_chkSearchSponsorshipType" />
                                </td>
                            </tr>

                        </table>
                    </td>
                    <td valign="bottom">
                        <table cellpadding="0" cellspacing="0" border="0" style="height: 100%;">
                            <tr valign="top">
                                <td align="right" style="padding-bottom: 5px;">
                                    <button id="<%=ClientID%>_btnPinSearch"></button>
                                </td>
                            </tr>
                            <tr valign="bottom">
                                <td align="right">
                                    <button id="<%=ClientID%>_btnSearch">Search</button></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <br style="clear: both;" />
    </div>
    <div id="<%=ClientID%>_divList">
        <div class="Wrap" style="width: 100%;">
            <div class="WrapPadding">
                <table class="List">
                    <thead id="<%=ClientID%>_thdList"></thead>
                    <tbody id="<%=ClientID%>_tbdList"></tbody>
                </table>
                <table id="<%=ClientID%>_tblPager" class="Pager"></table>
            </div>
        </div>
    </div>

</div>
