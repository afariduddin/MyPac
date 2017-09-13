<%@Control Language="C#" AutoEventWireup="true" CodeFile="Dashboard.ascx.cs" Inherits="Dashboard" %>

    <center>
        <iframe src="Dashboard/IntakeBarChart.aspx" width="1200" height="200" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" ></iframe>
        <table cellspacing="0" cellpadding="0" border="0">
             <tr>
                <td>
                    <iframe src="Dashboard/StudentPieChart.aspx?r=todate" width="600" height="400" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" ></iframe>
                </td>
                <td>
                    <iframe src="Dashboard/StudentPieChart.aspx?r=year" width="600" height="400" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" ></iframe>
                </td>
            </tr>    
        </table>
    </center>

