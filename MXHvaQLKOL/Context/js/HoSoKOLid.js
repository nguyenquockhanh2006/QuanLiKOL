$("#d1").click(function () {
    $("#d1").addClass('d1_2')
    $("#d2").removeClass('d1_2')
    $("#d3").removeClass('d1_2')
})
$("#d2").click(function () {
    $("#d2").addClass('d1_2')
    $("#d1").removeClass('d1_2')

    $("#d3").removeClass('d1_2')
})
$("#d3").click(function () {
    $("#d3").addClass('d1_2')
    $("#d1").removeClass('d1_2')

    $("#d2").removeClass('d1_2')
})

const getRandomIntInclusive = (min, max) => {
    return Math.floor(Math.random() * (max - min + 1)) + min;
};

$("#sua").click(function () {
    $("#thongtin2").css('display', 'block')
    $("#thongtin").css('display', 'none')
    var a = $("#tentk").text()
    $("input[name='ip_tentk']").val(a)
    var a1 = $("#hoten").text()
    $("input[name='ip_hoten']").val(a1)
    var a2 = $("#ngaysinh").text()
    $("input[name='ip_ngaysinh']").val(a2)
    var a3 = $("#gioitinh").text()
    $("input[name='ip_gioitinh']").val(a3)
    var a4 = $("#email").text()
    $("input[name='ip_email']").val(a4)
    var a5 = $("#diachi").text()
    $("input[name='ip_diachi']").val(a5)
    var a6 = $("#sdt").text()
    $("input[name='ip_sdt']").val(a6)
})
$("#save").click(function () {
    $("#thongtin").css('display', 'block')
    $("#thongtin2").css('display', 'none')
    var a = $("input[name='ip_tentk']").val()
    $("#tentk").text(a)
    var a1 = $("input[name='ip_hoten']").val()
    $("#hoten").text(a1)
    var a2 = $("input[name='ip_ngaysinh']").val()
    $("#ngaysinh").text(a2)
    var a3 = $("input[name='ip_gioitinh']").val()
    $("#gioitinh").text(a3)
    var a4 = $("input[name='ip_email']").val()
    $("#email").text(a4)
    var a5 = $("input[name='ip_diachi']").val()
    $("#diachi").text(a5)
    var a5 = $("input[name='ip_sdt']").val()
    $("#sdt").text(a5)
})
$("#huy").click(function () {
    $("#popup").css('display', 'none')
    $("#img-preview").attr('src', './istockphoto-1194891687-1024x1024.jpg')
})
$("#luu").click(function () {
    $("#popup").css('display', 'none')
    var a = $("#img-preview").attr('src')
    var hinh = $(`<img src="${a}" />`);
    var phantuchon = $("#listanh");
    phantuchon.append(hinh);
    $("#img-preview").attr('src', './istockphoto-1194891687-1024x1024.jpg')
})
$("#them").click(function () {
    $("#popup").css('display', 'flex')
})
const input = document.getElementById('file-input');
const image = document.getElementById('img-preview');

$("#d1").click(function () {
    $("#chuanone").css('display', 'block')
    $("#anh").css('display', 'none')
    $("#doimk").css('display', 'none')
})
$("#d2").click(function () {
    $("#chuanone").css('display', 'none')
    $("#anh").css('display', 'block')
    $("#doimk").css('display', 'none')
})
$("#d3").click(function () {
    $("#doimk").css('display', 'block')
    $("#anh").css('display', 'none')
    $("#chuanone").css('display', 'none')
})
$("#tieptuc").click(function () {
    var a = $("input[name='mkcu']").val();
    var a1 = $("input[name='mkmoi']").val();
    if (a != "" && a1 != "") {
        $("#mk").css('display', 'none')
        $("#tb").css('display', 'flex')
        var e = $("#email").text();
        var phantuchon = $("#tb2");
        phantuchon.append(e);
    }
    if (a == "") {
        $("input[name='mkcu']").css('border', '1px solid red')
        $("input[name='mkcu']").attr('placeholder', 'vui lòng nhập mật khẩu cũ')
    }
    else {
        $("input[name='mkcu']").css('border', '1px solid #adb5bd')
    }
    if (a1 == "") {
        $("input[name='mkmoi']").css('border', '1px solid red')
        $("input[name='mkmoi']").attr('placeholder', 'vui lòng nhập mật khẩu mới')
    }
    else {
        $("input[name='mkmoi']").css('border', '1px solid #adb5bd')
    }

})
$("#gui").click(function () {
    var a2 = $("input[name='ma']").val();
    if (a2 == "") {
        $("input[name='ma']").css('border', '1px solid red')
        $("input[name='ma']").attr('placeholder', 'nhập mã xác nhận')
    }
    else {
        $("input[name='ma']").css('border', '1px solid #adb5bd')
    }
})

function XacNhanLC() {
    var lc = document.getElementById('tdcl').value;
    var maxt = document.getElementById('ghima').value;
    var manhap = document.getElementById('ghimahinh').value;
    if (maxt == manhap) {
        if (lc = 'thaydoi')
            document.getElementById('clickthaydoi').click();
        else
            document.getElementById('clickcailai').click();
    }
    else {
        document.getElementById('ghimahinh').style.backgroundColor = 'yellow';
    }
}
