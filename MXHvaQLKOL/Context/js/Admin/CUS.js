$("#cot1").click(function () {
    $("#d2").css('display', 'block')
    $("#d3").css('display', 'none')
    $("#d4").css('display', 'none')
    $("#d5").css('display', 'none')
    $("#cot1").css('background-image', 'linear-gradient(135deg,#b7e4c7, #ffff3f)')
    $("#cot2").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot3").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot4").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
})
$("#cot2").click(function () {
    $("#d2").css('display', 'none')
    $("#d3").css('display', 'block')
    $("#d4").css('display', 'none')
    $("#d5").css('display', 'none')
    $("#cot1").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot2").css('background-image', 'linear-gradient(135deg,#b7e4c7, #ffff3f)')
    $("#cot3").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot4").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
})
$("#cot3").click(function () {
    $("#d2").css('display', 'none')
    $("#d3").css('display', 'none')
    $("#d4").css('display', 'block')
    $("#d5").css('display', 'none')
    $("#cot1").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot2").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot3").css('background-image', 'linear-gradient(135deg,#b7e4c7, #ffff3f)')
    $("#cot4").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
})
$("#cot4").click(function () {
    $("#d2").css('display', 'none')
    $("#d3").css('display', 'none')
    $("#d4").css('display', 'none')
    $("#d5").css('display', 'block')
    $("#cot1").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot2").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot3").css('background-image', 'linear-gradient(135deg,#ccdbfd, #ffccd5)')
    $("#cot4").css('background-image', 'linear-gradient(135deg,#b7e4c7, #ffff3f)')
})
$("#tao").click(function () {
    $("#dsKOL").css('display', 'block')
    $("#dsHD").css('display', 'none')
})
$("#tao2").click(function () {
    var a = $("input[name='tensp']").val()
    var a1 = $("input[name='ngaybd']").val()
    var a2 = $("input[name='ngaykt']").val()
    var a3 = $("#yc").val()
    var a4 = $("#chon").val()
    if (a == "") {
        $("input[name='tensp']").css('border', '1px solid red')
    }
    else {
        $("input[name='tensp']").css('border', '1px solid gray')
    }
    if (a1 == "") {
        $("input[name='ngaybd']").css('border', '1px solid red')
    }
    else {
        $("input[name='ngaybd']").css('border', '1px solid gray')
    }
    if (a2 == "") {
        $("input[name='ngaykt']").css('border', '1px solid red')
    }
    else {
        $("input[name='ngaykt']").css('border', '1px solid gray')
    }
    if (a3 == "") {
        $("#yc").css('border', '1px solid red')
    }
    else {
        $("#yc").css('border', '1px solid gray')
    }
    if (a4 == "null") {
        $("#chon").css('border', '1px solid red')
    }
    else {
        $("#chon").css('border', '1px solid gray')
    }
    if (a != "" && a1 != "" && a2 != "" && a3 != "" && a4 != "null") {
        $("#dsKOL").css('display', 'none')
        $("#hopdong").css('display', 'block')
        $("#popup").css('display', 'none')
        var today = new Date();
        var date = today.getDate();
        var month = today.getMonth();
        var year = today.getFullYear();
        var ngay = $("#ngay");
        ngay.append(date);
        var thang = $("#thang");
        thang.append(month);
        var nam = $("#nam");
        nam.append(year);
        var ten = $("#sp")
        ten.append(a)
        document.getElementById('TENHD').value = a;
        var ngayki = $("#ngayngaybd")
        ngayki.append(a1)
        var nbd2 = $("#NgayKi")
        nbd2.val(a1);
        var ngaykt = $("#ngayngaykt")
        var nkt2 = $("#NgayKT")
        nkt2.val(a2);
        ngaykt.append(a2);
        var yeucau = $("#yc2")
        yeucau.append(a3)
        document.getElementById('NdungHD').value = a3;
        if (a4 == 'AN') {
            var daidien = $("#loai")
            daidien.append('Âm nhạc')
            document.getElementById('LVu').value = 'AN';
        }
        else if (a4 == 'AT') {
            var daidien = $("#loai")
            daidien.append('Ẩm thực')
            document.getElementById('LVu').value = 'AT';
        }
        if (a4 == 'MP') {
            var daidien = $("#loai")
            daidien.append('Mỹ phẩm')
            document.getElementById('LVu').value = 'MP';
        }
        else if (a4 == 'TM') {
            var daidien = $("#loai")
            daidien.append('Thương maih điện tử')
            document.getElementById('LVu').value = 'TM';
        }
        if (a4 == 'TT') {
            var daidien = $("#loai")
            daidien.append('Thể thao')
            document.getElementById('LVu').value = 'TT';
        }
        else if (a4 == 'TTR') {
            var daidien = $("#loai")
            daidien.append('Thời trang')
            document.getElementById('LVu').value = 'TTr';
        }

    }
})
$("#gui").click(function () {
    $("#popup2").css('display', 'flex')
    setTimeout(function () {
        $("#popup2").css('display', 'none')
    }, 2000)
})


$("#huy").click(function () {
    $("input[name='tensp']").val('')
    $("input[name='ngaybd']").val('')
    $("input[name='ngaykt']").val('')
    $("#yc").val('')
    $("#chon").val('null')
    $("#popup").css('display', 'none')
})
$(".booking").click(function () {
    $("#popup").css('display', 'flex')
})
$(".file").click(function () {
    $("#popup3").css('display', 'flex')
})
$("#cl").click(function () {
    $("#popup3").css('display', 'none')
})


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
    document.getElementById("htmlsource").value = sourceHTML;
    var source = 'data:application/vnd.ms-word;charset=utf-8,' + encodeURIComponent(sourceHTML);
    console.log(source);
    document.getElementById('htmlsource').value = source;
    var sourcecodedoc = $("#htmlsource");
    sourcecodedoc.val(source);
    var fileDownload = document.createElement("a");
    document.body.appendChild(fileDownload);
    fileDownload.href = source;
    fileDownload.download = 'HopDong.doc';
    fileDownload.click();
    document.body.removeChild(fileDownload);
}





