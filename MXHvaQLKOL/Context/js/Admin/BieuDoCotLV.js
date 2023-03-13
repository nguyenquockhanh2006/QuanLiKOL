// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
var th11 = document.getElementById("cAN").value;
var th21 = document.getElementById("cAT").value;
var th31 = document.getElementById("cMP").value;
var th41 = document.getElementById("cTM").value;
var th51 = document.getElementById("cTT").value;
var th61 = document.getElementById("cTTr").value;
var maxthang1 = document.getElementById("cmax").value;
var ctx = document.getElementById("bieudolv");
var myLineChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Âm nhạc", "ẩm thực", "Mỹ phẩm", "Thương mại", "Thể thao", "Thời trang"],
        datasets: [{
            label: "Revenue",
            backgroundColor: "rgba(2,117,216,1)",
            borderColor: "rgba(2,117,216,1)",
            data: [th11, th21, th31, th41, th51, th61],
        }],
    },
    options: {
        scales: {
            xAxes: [{
                time: {
                    unit: 'Lĩnh vực'
                },
                gridLines: {
                    display: false
                },
                ticks: {
                    maxTicksLimit: 6
                }
            }],
            yAxes: [{
                ticks: {
                    min: 0,
                    max: maxthang1.value,
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
