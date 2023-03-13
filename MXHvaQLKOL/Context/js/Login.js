var a = 0;
var b = 0;

function checkTenDN(event, minKt, maxKt) {
    a = 0;
    var mess = document.getElementById('erUsename');
    var text = document.getElementById('mail').value;
    document.getElementById('erUsename').style.color = 'red';
    if (text == '') {
        document.getElementById('mail').style.backgroundColor = 'yellow';
        mess.innerHTML += 'Ten dang nhap khong the trong';
    } else if ((text.length > 0 && text.length < minKt) || text.length > maxKt) {

        document.getElementById('mail').style.backgroundColor = 'yellow';

        mess.innerHTML += 'Tên đăng nhập từ 3-10 kí tự ';

    } else {
        a = 1;
    }
}
function Checkpass(event) {
    b = 0;

    var pass = document.getElementById('pass').value;

    var mess = document.getElementById('erPass');

    if (pass == '') {

        document.getElementById('pass').style.backgroundColor = 'yellow';
        document.getElementById('erPass').style.color = 'red';
        mess.innerHTML += 'Mật khẩu ko được để trống ';

    } else {
        b = 1;
    }
}
var btndangnhap = document.getElementById('btnDangNhap');
btndangnhap.onclick = function Validate() {

    //Mặc định các lỗi này sẽ ẩn
    document.getElementById('mail').style.backgroundColor = 'white';
    var mess = document.getElementById('erUsename');
    mess.innerHTML = '';
    document.getElementById('pass').style.backgroundColor = 'white';
    var mess2 = document.getElementById('erPass');
    mess2.innerHTML = '';

    //Gọi các hàm đã viết

    checkTenDN(event, 6, 30);

    Checkpass(event);

    //var mess3 = document.getElementById('erUsename').value;
    //var mess4 = document.getElementById('erPass').value;

    if (a == 0 || b == 0) {
        event.preventDefault();
    }

}