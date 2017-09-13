<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegistrationListing.ascx.cs" Inherits="RegistrationListing" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="width:100%;">
    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%= ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Registration List</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <button id="<%=ClientID%>_btnImport">Import</button>
                    <button id="<%=ClientID%>_btnDownloadImport"  onclick="window.open('ExcelSample/CandidateRegistrationList.xlsx')">Download Import Format</button>
                    <button id="<%=ClientID%>_btnDownloadExcel">Export</button>
                </td>             
            </tr>
        </table>
    </div>
    
    <div id="<%=ClientID%>_divSearch">
        <div class="HeaderDropPanel">
            <table cellpadding="0" cellspacing="0" border="0" style="HEIGHT:100%;">
                <tr>
                  <%--  <td class="largetext" valign="top">Search Registration List</td>--%>
                    <td>
                        <table class="Form">
                           <tr>
                                 <td colspan="2" class="searchtitle" valign="top">Search Registration List</td>
                            </tr>
                            <tr>
                                <td>Registration Date :</td>
                                <td><input type="text" class="searchdate" id="<%=ClientID%>_dtpSearchRegisterFrom" /> ~ <input type="text" class="searchdate" id="<%=ClientID%>_dtpSearchRegisterTo" /></td>
                            </tr>
                            <tr>
                                <td>Full Name :</td>
                                <td><input type="text" class="search" id="<%=ClientID%>_txtSearchFullName" /></td>
                            </tr>
                            <tr>
                                <td>Gender :</td>
                                <td><select id="<%=ClientID%>_selSearchGender" class="search"></select></td>
                            </tr>
                            <tr>
                                <td>Email :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchEmail" class="search" /></td>
                            </tr>
                            <tr>
                                <td>IC Number :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchIC" class="search" /></td>
                            </tr>
                            <tr>
                                <td>State :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchState" class="search" /></td>
                            </tr>
                             <tr>
                                <td>Course :</td>
                                <td><select id="<%=ClientID%>_selSearchCourse" class="search"></select></td>
                            </tr>
                             <tr>
                                <td>
                                    Currently Employed:
                                </td>
                                <td><select id="<%=ClientID%>_selSearchEmployed" class="search"></select></td>
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
                                              <%
          Response.WriteFile("StateList.html");
        %>
</div>