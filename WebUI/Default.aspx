<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Debug | MyPac</title>
    <style>
        form button {
            width: 100%;
            height: 50px;
            font-size: 1.1em;
        }
    </style>
</head>
    <script>
        window.location.href = "CandidateSignIn.aspx";
    </script>
<body>
    <form id="form1" runat="server">
        <div style="margin: 100px auto; display: block; width: 300px;">
            <h3>Choose one:</h3>
            <br />
            <button onclick="location.href='CandidateRegistration.aspx'; return false;">Candidate Registration</button>
            <br /><br />
            <button onclick="location.href='CandidateSignIn.aspx'; return false;">Candidate Login</button>
            <br /><br />
            <button onclick="location.href='AdministratorSignIn.aspx';return false;">Admin Login</button>
        </div>
    </form>
</body>
</html>
