google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);
var thang1 = document.getElementById('thang1').value;
var thang2 = document.getElementById('thang2').value;
var thang3 = document.getElementById('thang3').value;
var thang4 = document.getElementById('thang4').value;
var thang5 = document.getElementById('thang5').value;
var thang6 = document.getElementById('thang6').value;
var thang7 = document.getElementById('thang7').value;
var thang8 = document.getElementById('thang8').value;
var thang9 = document.getElementById('thang9').value;
var thang10 = document.getElementById('thang10').value;
var thang11 = document.getElementById('thang11').value;
var thang12 = document.getElementById('thang12').value;
function drawChart() {
    // Set Data
    var data = google.visualization.arrayToDataTable([
        ['Tháng', 'Số lượng'],
        [1, thang1], [2, thang2], [3, thang3], [4, thang4], [5, thang5],
        [6, thang6], [7, thang7], [8, thang8],
        [9, thang9], [10, thang10], [11, thang11], [12, thang12]
    ]);
    // Set Options
    var options = {
        title: 'Số hợp đồng theo tháng - sự tin cậy của khách hàng',
        hAxis: { title: 'Tháng' },
        vAxis: { title: 'Số lượng hợp đồng' },
        legend: 'block'
    };
    // Draw
    var chart = new google.visualization.LineChart(document.getElementById('myChart'));
    chart.draw(data, options);
}