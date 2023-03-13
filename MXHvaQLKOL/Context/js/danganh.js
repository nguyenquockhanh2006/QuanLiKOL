function chooseFileAnh(fileInput) {
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            var dataUrl = e.srcElement.result;
            console.log(dataUrl);
            document.getElementById('anhsrc').value = dataUrl;
            document.getElementById('anhdangsr').style.width = '300px';
            document.getElementById('anhdangsr').style.height = '300px';
            document.getElementById('anhdangsr').src = dataUrl;
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}
function exportHTML() {
    var header = "<html xmlns:o='urn:schemas-microsoft-com:office:office' " +
        "xmlns:w='urn:schemas-microsoft-com:office:word' " +
        "xmlns='http://www.w3.org/TR/REC-html40'>" +
        "<head><meta charset='utf-8'><title>Export HTML to Word Document with JavaScript</title></head><body>";
    var footer = "</body></html>";
    var sourceHTML = header + document.getElementById("vanban").innerHTML + footer;
    var source = 'data:application/vnd.ms-word;charset=utf-8,' + encodeURIComponent(sourceHTML);
    var fileDownload = document.createElement("a");
    document.body.appendChild(fileDownload);
    fileDownload.href = source;
    fileDownload.download = 'hopDong.doc';
    fileDownload.click();
    document.body.removeChild(fileDownload);
}

var xArray = ["Âm nhạc", "Ẩm thực", "Mỹ phẩm", "Thể thao", "Thương mại", "Thời trang"];
var yArray = [55, 49, 44, 24, 15, 90];
var layout = { title: "Hợp đồng trong lĩnh vực" };
var data = [{ labels: xArray, values: yArray, hole: .4, type: "pie" }];
Plotly.newPlot("myPlot", data, layout);