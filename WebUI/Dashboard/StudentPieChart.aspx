<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentPieChart.aspx.cs" Inherits="Dashboard_StudentPieChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="divChart" style="width: 600px; height: 400px;"></div>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
      
        function drawChart()
        {
            var data = google.visualization.arrayToDataTable([
            ['', 'Enrollment'],
            <%=JS%>
            /*
            ['Campus 1', 36],
            ['Campus 2', 34],
            ['Campus 3', 76],
            ['Campus 4', 23],
            ['Campus 5', 45],
            */
            ]);

            var options = {
                title: '<%=ChartTitle%>',
                is3D: true,
            };

            var chart = new google.visualization.PieChart(document.getElementById('divChart'));
            chart.draw(data, options);
        }
     
    </script>
</body>
</html>
