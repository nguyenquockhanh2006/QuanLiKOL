var xValues = ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'];

new Chart("myChartDuong", {
    type: "line",
    data: {
        labels: xValues,
        datasets: [{
            data: [860, 1140, 1060, 1060, 1070, 1110, 1330, 2210, 7830, 2478, 3600, 1234],
            borderColor: "red",
            fill: false
        }, {
            data: [1600, 1700, 1700, 1900, 2000, 2700, 4000, 5000, 6000, 7000, 3600, 1234],
            borderColor: "green",
            fill: false
        }, {
            data: [300, 700, 2000, 5000, 6000, 4000, 2000, 1000, 200, 100, 3600, 1234],
            borderColor: "blue",
            fill: false
        }, {
            data: [2358, 700, 2000, 251, 6523, 4335, 2000, 135, 200, 100, 3600, 1234],
            borderColor: "yellow",
            fill: false
        }, {
            data: [5538, 700, 1000, 5000, 423, 4000, 2000, 1000, 200, 100, 3600, 1234],
            borderColor: "purple",
            fill: false
        }, {
            data: [1231, 700, 3000, 5000, 6000, 4000, 2000, 1000, 200, 100, 3600, 1234],
            borderColor: "orange",
            fill: false
        }
        ]
    },
    options: {
        legend: { display: false }
    }
});