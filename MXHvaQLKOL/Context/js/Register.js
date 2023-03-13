function checkTenDN(event, biengt) {
    var text = document.getElementById('ip_tentk').value;
    if (text == '') {
        document.getElementById('ip_tentk').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_tentk').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checkHoTen(event, biengt) {
    var text = document.getElementById('ip_hoten').value;
    if (text == '') {
        document.getElementById('ip_hoten').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_hoten').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checkgmail(event, biengt) {
    var text = document.getElementById('ip_mail').value;
    if (text == '') {
        document.getElementById('ip_mail').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_mail').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checkdiachi(event, biengt) {
    var text = document.getElementById('ip_dc').value;
    if (text == '') {
        document.getElementById('ip_dc').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_dc').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checksdt(event, biengt) {
    var text = document.getElementById('ip_sdt').value;
    if (text == '') {
        document.getElementById('ip_sdt').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if (text.length != 10) {

        document.getElementById('ip_sdt').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checkmatkhau(event, biengt) {
    var text = document.getElementById('ip_mk').value;
    if (text == '') {
        document.getElementById('ip_mk').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_mk').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}
function checknhaplaimk(event, biengt) {
    var text = document.getElementById('ip_nhaplaimk').value;
    var text2 = document.getElementById('ip_mk').value;
    if (text == '') {
        document.getElementById('ip_nhaplaimk').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if ((text.length > 0 && text.length < 6) || text.length > 30) {

        document.getElementById('ip_nhaplaimk').style.backgroundColor = 'yellow';
        biengt = 0;
    } else if (text != text2) {
        document.getElementById('ip_nhaplaimk').style.backgroundColor = 'yellow';
        biengt = 0;
    }
    return biengt;
}

var btnlayma = document.getElementById('btn_layma');
btnlayma.onclick = function Validate() {
    event.preventDefault();
    var a = 1;
    //Mặc định các lỗi này sẽ ẩn
    document.getElementById('ip_tentk').style.backgroundColor = 'white';
    document.getElementById('ip_hoten').style.backgroundColor = 'white';
    document.getElementById('ip_mail').style.backgroundColor = 'white';
    document.getElementById('ip_dc').style.backgroundColor = 'white';
    document.getElementById('ip_sdt').style.backgroundColor = 'white';
    document.getElementById('ip_mk').style.backgroundColor = 'white';
    document.getElementById('ip_nhaplaimk').style.backgroundColor = 'white';
    //Gọi các hàm đã viết
    a = checkTenDN(event, a);
    a = checkHoTen(event, a);
    a = checkgmail(event, a);
    a = checkdiachi(event, a);
    a = checksdt(event, a);
    a = checkmatkhau(event, a);
    a = checknhaplaimk(event, a);
    if (a == 1) {
        document.getElementById('xacnhangmail').style.display = 'block';
        var gmailnhan = document.getElementById('ip_mail').value;
        var ma = getRndInteger(100001, 999999);
        document.getElementById('matemp').value = ma;
        
        Email.send({
            Host: "smtp.elasticemail.com",
            Username: "nthien.truong.qk206@gmail.com",
            Password: "76237C893DCC260AB2E6F655E20295C6FAF4",
            To: gmailnhan,
            From: "nthien.truong.qk206@gmail.com",
            Subject: "Mã xác thực đăng kí tài khoản Website KOL (OTP):",
            Body: "Mã xác nhận đăng kí tài khoản của bạn là: " + ma
        }).then(
            message => alert('Mã xác nhận đã được gửi đi, vui lòng kiểm tra và nhập chính xác')
        );
    } else {
        document.getElementById('xacnhangmail').style.display = 'none';
    }

}
// tao so ngau nhien
function getRndInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
//
var btnxacnhan = document.getElementById('btn_xacnhan');
btnxacnhan.onclick = function Validate() {
    var matemp = document.getElementById('matemp').value;
    var manhap = document.getElementById('maxn').value;
    if (manhap != matemp) {
        event.preventDefault();
        document.getElementById('maxn').style.backgroundColor = 'yellow';
        alert('Mã xác nhân không chính xác, ma: ' + matemp + ' ma nhap: ' + manhap);
    } else {

    }
}

var btnnext = document.getElementById('tt');
btnnext.onclick = function Validate() {
    document.getElementById('cungfrm').style.display = 'none';
    document.getElementById('frmDK').style.display = 'block';
}

var radKhach = document.getElementById('khachhang');
radKhach.onclick = function Validate() {
    document.getElementById('phanquyen').value = 'KH';
}

var radKOL = document.getElementById('kol');
radKOL.onclick = function Validate() {
    document.getElementById('phanquyen').value = 'KOL';
}
