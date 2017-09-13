<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PartTimerCandidate.ascx.cs" Inherits="PartTimerCandidate" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="WIDTH:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Part-Timer Assessment Result List</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <button id="<%=ClientID%>_btnImport">Import Assessment</button>
                    <button id="<%=ClientID%>_btnImportCDP">Import CDP</button>
                    <button id="<%=ClientID%>_btnImportInterview">Import Interview</button>
                    <button id="<%=ClientID%>_btnDownloadImport"  onclick="window.open('ExcelSample/PartTimerAssessmentImportFormat.zip')">Download Import Format</button>
                    <button id="<%=ClientID%>_btnAssign">Bulk Assign Assessment Session</button>
                    <button id="<%=ClientID%>_btnExport">Export</button>
                </td>             
            </tr>
        </table>
    </div>
    
    <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                <tr>
                    <%--<td class="largetext" valign="top">Search Part-Timer Assessment Result List</td>--%>
                    <td>
                        <table class="Form">
                            <tr>
                                 <td colspan="2" class="searchtitle" valign="top">Search Part-Timer Assessment Result List</td>
                            </tr>
                            <tr>
                                <td>Assessment Date :</td> 
                                <td><input type="text" id="<%=ClientID%>_txtSearchAssessmentDateFrom"  class="searchdate"  /> ~
                                    <input type="text" id="<%=ClientID%>_txtSearchAssessmentDateTo"  class="searchdate" /></td>
                            </tr>
                            <tr>
                                <td>Enrollment Date :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchEnrollmentDateFrom"  class="searchdate" /> ~
                                    <input type="text" id="<%=ClientID%>_txtSearchEnrollmentDateTo"  class="searchdate" /></td>
                            </tr>
                            <tr>
                                <td>Full Name :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchFullName"  class="search" /></td>
                            </tr>
                            <tr>
                                <td>Gender :</td>
                                <td><select id="<%=ClientID%>_selSearchGender"  class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Email :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchEmail"  class="search" /></td>
                            </tr>
                            <tr>
                                <td>IC Number :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchIC"  class="search" /></td>
                            </tr>
                            <tr>
                                <td>State :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchState"  class="search" /></td>
                            </tr>
                            
                            <tr>
                                <td>Contract Type :</td>
                                <td><select id="<%=ClientID%>_selSearchContractType"  class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Score :</td>
                                <td><select id="<%=ClientID%>_selSearchSubjectType"  class="searchshort"></select>&nbsp;<input type="number" value="0" id="<%=ClientID%>_txtSearchScore" class="searchshort" style="width:78px;" />
                                </td>
                            </tr>
                            <tr>
                                <td>Location :</td>
                                <td><select id="<%=ClientID%>_selSearchLocation"  class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Status :</td>
                                <td><select id="<%=ClientID%>_selSearchStatus"  class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Sponsorship Type :</td>
                                <td><div id="<%=ClientID%>_chkSearchSponsorshipType"  class="search" /></td>
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
            </table>
            <table id="<%=ClientID%>_tblPager" class="Pager"></table>
                </div>
        </div>
    </div>
</div>