<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntakeBarChart.aspx.cs" Inherits="Dashboard_IntakeBarChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="divChart" style="width: 1200px; height: 200px;"></div>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart()
        {
            var data = google.visualization.arrayToDataTable([
            ['', 'Application', 'Enrollment'],
            <%=JS%>
            /*
            ['Jan', 36, 45],
            ['Feb', 6, 16],
            ['Mar', 5, 8],
            ['Apr', 13, 15],
            ['Jan', 36, 45],
            ['Feb', 6, 16],
            ['Mar', 5, 8],
            ['Apr', 13, 15],
            ['Jan', 36, 45],
            ['Feb', 6, 16],
            ['Mar', 5, 8],
            ['Apr', 13, 15],
            */
            ]);

            var options = {
                chart: { title: 'STUDENT INTAKE FOR LAST 12 MONTHS' },
            };

            var chart = new google.charts.Bar(document.getElementById('divChart'));
            chart.draw(data, options);
        }
     
    </script>
</body>
</html>
