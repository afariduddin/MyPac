<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailResponse.aspx.cs" Inherits="EmailResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration | MyPAC</title>
    <link rel="icon" href="Components/Css/global/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="Components/Css/css.css" />
    <link rel="stylesheet" type="text/css" href="Components/Css/StyleSheet.css" />
    <script src='https://www.google.com/recaptcha/api.js'></script>
        <script src='Components/custom.js'></script>
</head>

<body>
    <script>
 
       
    </script>
    <form id="mainform" runat="server">
		<table align="center">
            <tr>
                <td><img src="Resource/mypac_logo_small.png" /></td>
				<td width="20px"></td>
                <td style="vertical-align: middle"><h1>Candidate Database System</h1></td>
            </tr>
		</table>

       

        <table id="tblInfo" style="display1: none;" align="center">
            <tr>
                <td>
                    <img src="Components/Css/global/logo.png" />
                </td>
                <td>
                    
                    <h1><asp:Literal ID="litMessage" runat="server"></asp:Literal></h1>
                   <br />Click <a href="CandidateContainer.aspx">here</a> to login.
                </td>
                
            </tr>
          
        </table>
    </form>
    <script>
        if (!window.jQuery)
        {
            alert("jQuery not loaded");
        }
        else
        {
   
          
         
            
        }
    </script>
</body>
</html>
