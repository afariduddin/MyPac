<%@Control Language="C#" AutoEventWireup="true" CodeFile="CandidateDashboard.ascx.cs" Inherits="CandidateDashboard" %>

<div style="text-align:center;">
    <div id="<%=ClientID %>_divNextMeeting"></div>    
    <div id="<%=ClientID %>_divProgressWrap">
        <div class="PageHeader">        
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle">
                    <td align="left"><span id="<%=ClientID%>_spnProgressTitle" style="font-weight: bold; font-size: 1.1em;"></span></td>
                </tr>
            </table>
        </div>
        <br />
        <div id="<%=ClientID%>_divCourseBadges"></div>
        <br />
    </div>
    <div id="<%=ClientID%>_divAttnWrap">
        <div class="PageHeader">        
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="middle">
                    <td align="left"><span style="font-weight: bold; font-size: 1.1em;">Attendance Performance</span></td>
                </tr>
            </table>
        </div>
        <br />
        <center>
            <table cellspacing="0" cellpadding="0" border="0">
                <tr valign="top">
                    <td>
                        <table cellspacing="0" cellpadding="0" border="0" class="List">
                            <thead id="<%=ClientID%>_theadAttn"></thead>
                            <tbody id="<%=ClientID%>_tbodyAttn"></tbody>
                        </table>
                    </td>
                    <td width="10">&nbsp;</td>
                    <td>
                        <div style="text-align:center;border:solid 1px #000; padding:0px;">
                            Average Attendance:
                            <table cellspacing="2" cellpadding="0" border="0">
                                <tr id="<%=ClientID%>_trAttnMeter">
                                    <td style="background-color:#000;padding:5px;padding-bottom:0px;font-size:100px;font-weight:bold;color:#FFF;font-family:'Courier New';line-height:100px;">9</td>
                                    <td style="background-color:#000;padding:5px;padding-bottom:0px;font-size:100px;font-weight:bold;color:#FFF;font-family:'Courier New';line-height:100px;">9</td>
                                    <td style="background-color:#000;padding:5px;padding-bottom:0px;font-size:100px;font-weight:bold;color:#FFF;font-family:'Courier New';line-height:100px;">%</td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </center>    
        <br /><br />
    </div>
    <div>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr valign="top">
                <td width="49%">
                    <div class="PageHeader">        
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr valign="middle">
                                <td align="left"><span style="font-weight: bold; font-size: 1.1em;">Email Notification</span></td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div id="<%=ClientID %>_divEmlWrap">
                        <div class="Wrap" style="WIDTH:100%;">
                            <table class="List" style="WIDTH:100%;">
                                <thead id="<%=ClientID%>_thdEmlList"></thead>
                                <tbody id="<%=ClientID%>_tbdEmlList"></tbody>
                            </table>
                            <table id="<%=ClientID%>_tblEmlPager" class="Pager"></table>
                        </div>
                    </div>
                </td>
                <td width="2%">&nbsp;</td>
                <td width="49%">
                    <div class="PageHeader">        
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr valign="middle">
                                <td align="left"><span style="font-weight: bold; font-size: 1.1em;">Warning Letters</span></td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div id="<%=ClientID %>_divWarnWrap">
                        <div class="Wrap" style="WIDTH:100%;">
                            <table class="List" style="WIDTH:100%;">
                                <thead id="<%=ClientID%>_thdWarnList"></thead>
                                <tbody id="<%=ClientID%>_tbdWarnList"></tbody>
                            </table>
                            <table id="<%=ClientID%>_tblWarnPager" class="Pager"></table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
