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

input.addEventListener('change', (e) => {
    if (e.target.files.length) {
        const src = URL.createObjectURL(e.target.files[0]);
        image.src = src;
    }
});
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

function doianh(chon) {
    $("#nutdoianh").css('display', 'none');
    $("#ghimadoianh").css('display', 'block');
    $("#thongtinanhcu").css('display', 'none');
    document.getElementById('tdcl').value = 'cailai';
    if (chon = 'thaydoi')
        document.getElementById('tdcl').value = 'thaydoi';
    var maso = getRandomIntInclusive(111111, 999999);
    var nguoinhan = document.getElementById('gmail2').value;
    
    document.getElementById('ghima').value = maso;
    Email.send({
        Host: "smtp.elasticemail.com",
        Username: "nthien.truong.qk206@gmail.com",
        Password: "76237C893DCC260AB2E6F655E20295C6FAF4",
        To: nguoinhan,
        From: "nthien.truong.qk206@gmail.com",
        Subject: "Đổi thông tin xác nhận tài khoản",
        Body: "Mã xác nhận là: " + maso
    }).then(
        message => alert('Mã xác nhận đã được gửi đi, vui lòng kiểm tra và nhập chính xác')
    );
}
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
function chooseFile(fileInput) {
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            var dataUrl = e.srcElement.result;
            console.log(dataUrl);
            document.getElementById('anhsrc2').value = dataUrl;
            //document.getElementById('anh').src = dataUrl;
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}
function chooseFileAnh(fileInput) {
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            var dataUrl = e.srcElement.result;
            console.log(dataUrl);
            document.getElementById('srcavatar').value = dataUrl;
            document.getElementById('anhavt').src = dataUrl;
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}
function Laymadoimail() {
    var gmai = document.getElementById('macu').value;
    var maso = getRandomIntInclusive(111111, 999999);
    document.getElementById('maxnmail').value = maso;
    document.getElementById('nhapma').style.display = 'none';
    document.getElementById('chuamail').style.display = 'block';

    Email.send({
        Host: "smtp.elasticemail.com",
        Username: "nthien.truong.qk206@gmail.com",
        Password: "76237C893DCC260AB2E6F655E20295C6FAF4",
        To: gmai,
        From: "nthien.truong.qk206@gmail.com",
        Subject: "Đổi thông tin xác nhận tài khoản",
        Body: "Mã xác nhận là: " + maso
    }).then(
        message => alert('Mã xác nhận đã được gửi đi, vui lòng kiểm tra và nhập chính xác')
    );
}

function XetLoad() {
    var maxt = document.getElementById('maxnmail').value;
    var manhap = document.getElementById('upgmail').value;
    if (maxt == manhap) {
        document.getElementById('subgmail').click();
    }
    else {
        event.preventDefault();
        alert('Mã xác thực không chính xác!');
    }
}

function chooseCMNDmt(fileInput) {
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            var dataUrl = e.srcElement.result;
            console.log(dataUrl);
            document.getElementById('srcCMMT').value = dataUrl;
            document.getElementById('anhcmndmattruoc').src = dataUrl;
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}

function chooseCMNDms(fileInput) {
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            var dataUrl = e.srcElement.result;
            console.log(dataUrl);
            document.getElementById('srcCMMS').value = dataUrl;
            document.getElementById('anhcmndmatsau').src = dataUrl;
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}

