// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
var th1 = document.getElementById("thang1").value;
var th2 = document.getElementById("thang2").value;
var th3 = document.getElementById("thang3").value;
var th4 = document.getElementById("thang4").value;
var th5 = document.getElementById("thang5").value;
var th6 = document.getElementById("thang6").value;
var th7 = document.getElementById("thang7").value;
var th8 = document.getElementById("thang8").value;
var th9 = document.getElementById("thang9").value;
var th10 = document.getElementById("thang10").value;
var th11 = document.getElementById("thang11").value;
var th12 = document.getElementById("thang12").value;
var maxthang = document.getElementById("thangmax").value;
var ctx = document.getElementById("bieudovethang");
var myLineChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12"],
        datasets: [{
            label: "Revenue",
            backgroundColor: "rgba(2,117,216,1)",
            borderColor: "rgba(2,117,216,1)",
            data: [th1, th2, th3, th4, th5, th6, th7, th8, th9, th10, th11, th12],
        }],
    },
    options: {
        scales: {
            xAxes: [{
                time: {
                    unit: 'month'
                },
                gridLines: {
                    display: false
                },
                ticks: {
                    maxTicksLimit: 12
                }
            }],
            yAxes: [{
                ticks: {
                    min: 0,
                    max: maxthang.value,
                    maxTicksLimit: 10
                },
                gridLines: {
                    display: true
                }
            }],
        },
        legend: {
            display: false
        }
    }
});
