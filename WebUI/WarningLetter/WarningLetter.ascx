<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WarningLetter.ascx.cs" Inherits="WarningLetter" %>

<div id="<%= ClientID%>_divReportContent" class="divContent" style="WIDTH:100%;">

    <div class="PageHeader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" >
            <tr valign="middle">
                <td ><span id="<%=ClientID%>_spanTitle" style="font-weight:bold; font-size:1.1em;">Warning Letter Template Setting</span></td>   
                <td align="right">
                    <button id="<%=ClientID%>_btnShowSearch">Search</button>
                    <button id="<%=ClientID%>_btnNew">Create New</button>
                    <button id="<%=ClientID%>_btnShowTemplateAttribute">Template Attributes</button>
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
                                <td>Warning Letter Template Name :</td>
                                <td><input type="text" id="<%=ClientID%>_txtSearchWarningLetterName" class="search" value="" /></td>
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

<script>

    $(function () {
         CKEDITOR.config.removePlugins = 'scayt';
        //CKEDITOR.config.scayt_autoStartup = false;
        //alert(CKEDITOR.config);

    });
  
</script>