google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

var thang1 = document.getElementById('th1').value / 1000;
var thang2 = document.getElementById('th2').value / 1000;
var thang3 = document.getElementById('th3').value / 1000;
var thang4 = document.getElementById('th4').value / 1000;
var thang5 = document.getElementById('th5').value / 1000;
var thang6 = document.getElementById('th6').value / 1000;
var thang7 = document.getElementById('th7').value / 1000;
var thang8 = document.getElementById('th8').value / 1000;
var thang9 = document.getElementById('th9').value / 1000;
var thang10 = document.getElementById('th10').value / 1000;
var thang11 = document.getElementById('th11').value / 1000;
var thang12 = document.getElementById('th12').value / 1000;
function drawChart() {
    // Set Data
    var data = google.visualization.arrayToDataTable([
        ['Price', 'Size'],
        [1, thang1], [2, thang2], [3, thang3], [4, thang4], [5, thang5], [6, thang6],
        [7, thang7], [8, thang8], [9, thang9], [10, thang10], [11, thang11], [12, thang12]
    ]);
    // Set Options
    var options = {
        title: 'Nghìn VNĐ theo tháng trong năm',
        hAxis: { title: 'Tháng' },
        vAxis: { title: 'Trị giá' },
        legend: 'none'
    };
    // Draw Chart
    var chart = new google.visualization.LineChart(document.getElementById('myChartDT'));
    chart.draw(data, options);
}

var bdclvan = document.getElementById('bdclvan').value / 1000;
var bdclvat = document.getElementById('bdclvat').value / 1000;
var bdclvmp = document.getElementById('bdclvmp').value / 1000;
var bdclvtm = document.getElementById('bdclvtm').value / 1000;
var bdclvtt = document.getElementById('bdclvtt').value / 1000;
var bdclvttr = document.getElementById('bdclvttr').value / 1000;

var xValues = ["Âm nhạc", "Ẩm thực", "Mỹ phẩm", "Thương mại", "Thể thao", "Thời Trang"];
var yValues = [bdclvan, bdclvat, bdclvmp, bdclvtm, bdclvtt, bdclvttr];
var barColors = ["red", "green", "blue", "orange", "brown", "yellow"];

new Chart("myChartLV", {
    type: "bar",
    data: {
        labels: xValues,
        datasets: [{
            backgroundColor: barColors,
            data: yValues
        }]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: ""
        }
    }
});

var bdtlvan = document.getElementById('bdtlvan').value;
var bdtlvat = document.getElementById('bdtlvat').value;
var bdtlvmp = document.getElementById('bdtlvmp').value;
var bdtlvtm = document.getElementById('bdtlvtm').value;
var bdtlvtt = document.getElementById('bdtlvtt').value;
var bdtlvttr = document.getElementById('bdtlvttr').value;

var zValues = ["Âm nhạc", "Ẩm thực", "Mỹ phẩm", "Thương mại điện tử", "Thể thao", "Thời trang"];
var wValues = [bdtlvan, bdtlvat, bdtlvmp, bdtlvtm, bdtlvtt, bdtlvttr];
var barColors = [
    "#FF0000",
    "#FFFF33	",
    "#FF9933",
    "#00FF33",
    "#0099FF",
    "#CC00FF"
];

new Chart("myChartTLV", {
    type: "pie",
    data: {
        labels: zValues,
        datasets: [{
            backgroundColor: barColors,
            data: wValues
        }]
    },
    options: {
        title: {
            display: true,
            text: ""
        }
    }
});

//
var rt1 = document.getElementById('rt1').value;
var rt2 = document.getElementById('rt2').value;
var rt3 = document.getElementById('rt3').value;
var rt4 = document.getElementById('rt4').value;
var rt5 = document.getElementById('rt5').value;
var rt6 = document.getElementById('rt6').value;
var rt7 = document.getElementById('rt7').value;
var rt8 = document.getElementById('rt8').value;
var rt9 = document.getElementById('rt9').value;
var rt10 = document.getElementById('rt10').value;
var rt11 = document.getElementById('rt11').value;
var rt12 = document.getElementById('rt12').value;
var kValues = ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'];


new Chart("myChartBDSD", {
    type: "line",
    data: {
        labels: kValues,
        datasets: [{
            data: [rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12],
            borderColor: "red",
            fill: true
        }, {
            data: [thang1 * 9 / 10, thang2 * 9 / 10, thang3 * 9 / 10, thang4 * 9 / 10, thang5 * 9 / 10, thang6 * 9 / 10, thang7 * 9 / 10, thang8 * 9 / 10, thang9 * 9 / 10, thang10 * 9 / 10, thang11 * 9 / 10, thang12 * 9 / 10],
            borderColor: "green",
            fill: true
        }]
    },
    options: {
        legend: { display: false }
    }
});