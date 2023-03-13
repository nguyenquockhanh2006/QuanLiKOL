//
var th100 = document.getElementById("tAN").value;
var th200 = document.getElementById("tAT").value;
var th300 = document.getElementById("tMP").value;
var th400 = document.getElementById("tTM").value;
var th500 = document.getElementById("tTT").value;
var th600 = document.getElementById("tTTr").value;
// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ["Âm nhạc", "Ẩm thực", "Mỹ phẩm", "Thương mại điện tử", "Thể thao", "Thời trang"],
        datasets: [{
            data: [th100, th200, th300, th400, th500, th600],
            backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745', '#ff66ff', '#cccccc'],
        }],
    },
});
