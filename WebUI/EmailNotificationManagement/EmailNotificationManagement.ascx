<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmailNotificationManagement.ascx.cs" Inherits="EmailNotificationManagement" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="width: 100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr valign="middle">
                <td><span id="<%= ClientID%>_spanTitle" style="font-weight: bold; font-size: 1.1em;">Email Notification Management</span></td>
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <%--<button id="<%=ClientID%>_btnImport">Import</button>
                    <button id="<%=ClientID%>_btnDownloadImport"  onclick="window.open('ExcelSample/CandidateRegistrationList.xlsx')">Download Import Format</button>
                    <button id="<%=ClientID%>_btnDownloadExcel">Export</button>--%>
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
                                <td>Created Date :</td>
                                <td>
                                    <input type="text" id="<%=ClientID%>_dtpSearchCreatedFrom" class="searchdate" />
                                    ~
                                    <input type="text" id="<%=ClientID%>_dtpSearchCreatedTo" class="searchdate" /></td>
                            </tr>
                            <tr>
                                <td>Email Recipient :</td>
                                <td>
                                    <input type="text" id="<%=ClientID%>_txtSearchRecipient" class="search"/></td>
                            </tr>
                            <tr>
                                <td>Email Subject :</td>
                                <td>
                                    <input type="text" id="<%=ClientID%>_txtSearchSubject" class="search"/></td>
                            </tr>
                            <tr>
                                <td>Status :</td>
                                <td>
                                    <select id="<%=ClientID%>_selSearchStatus" class="search"></select></td>
                            </tr>
                            <%--<tr>
                                <td>IC Number :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchIC" style="WIDTH:200px;" /></td>
                            </tr>
                            <tr>
                                <td>State :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchState" style="WIDTH:200px;" /></td>
                            </tr>
                             <tr>
                                <td>Course :</td>
                                <td><select id="<%=ClientID%>_selSearchCourse"></select></td>
                            </tr>
                             <tr>
                                <td>
                                    Currently Employed:
                                </td>
                                <td><select id="<%=ClientID%>_selSearchEmployed"></select></td>
                            </tr>--%>
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