/*
function napdata(idnap) {
    $("#lopphu").css('display', 'block');
    $("#lopphu").css('z-index', '3');
    var a = 'mini' + idnap;
    $('.mini').id = a;
    document.getElementById('div_tieude').innerHTML = document.getElementById('td_' + idnap).innerHTML;
    document.getElementById('tieudephu').innerHTML = document.getElementById('tdp_' + idnap).innerHTML;
    document.getElementById('ngay').innerHTML = document.getElementById('ngay_' + idnap).value;
    document.getElementById('ip_id_mota').innerHTML = document.getElementById('mota_' + idnap).value;
    document.getElementById('div_tieude').innerHTML = document.getElementById('td_' + idnap).innerHTML;

    var button = document.createElement('button')
    document.getElementById('congviec').append(button);
    $('.mini').css('display', 'block');
}
*/


if (document.getElementById('formloadlp').value == 1) {
    $("#lopphu").css('display', 'block');
    $("#lopphu").css('z-index', '3');
    $('.mini').css('display', 'block');
} 

var dc = document.getElementById('socheck').value;
var t = document.getElementById('solist').value;
var chia = Math.round((dc / t) * 100);
document.getElementById('tiendo').style.width = chia + '%';
document.getElementById('phantram').innerHTML = chia;


function napdata(idnap) {
    document.getElementById('macvloadlp').value = idnap;
    document.getElementById('hanhdonglp').value = '1';
    document.getElementById('subloadlopphu').click();
}
$('#close').click(function () {
    $('.mini').css('display', 'none')
    $('#tieude').css('display', 'block')
    $('#btn1').css('display', 'block')
    $('#div_tieude').css('display', 'block')
   
    $("#lopphu").css('display', 'none');
})
$('#btn1').click(function () {
    $('#btn1').css('display', 'none')
    $('#div-move').css('display', 'block')
})
$('#icmenu').click(function () {
    $('#header').css('display', 'block')
})
$('#ic-close').click(function () {
    $('#header').css('display', 'none')
})
$('#nt1').click(function () {
    $('#nt1').css('display', 'none')
    $('#ip1').css('display', 'block')
})
$('#nt2').click(function () {
    $('#nt2').css('display', 'none')
    $('#ip2').css('display', 'block')
})
$('#nt3').click(function () {
    $('#nt3').css('display', 'none')
    $('#ip3').css('display', 'block')
})
$('#nt4').click(function () {
    $('#nt4').css('display', 'none')
    $('#ip4').css('display', 'block')
})
$('#cl1').click(function () {
    $('#ip1').css('display', 'none')
    $('#nt1').css('display', 'block')
})
$('#cl2').click(function () {
    $('#ip2').css('display', 'none')
    $('#nt2').css('display', 'block')
})
$('#cl3').click(function () {
    $('#ip3').css('display', 'none')
    $('#nt3').css('display', 'block')
})
$('#cl4').click(function () {
    $('#ip4').css('display', 'none')
    $('#nt4').css('display', 'block')
})
$('#btn2').click(function () {
    $('#chinhsua').css('display', 'block')
    $('.mota').css('display', 'none')
})
$('#xong').click(function () {
    $('#chinhsua').css('display', 'none')
    $('.mota').css('display', 'block')
})
$('#btn-suatd').click(function () {
    $('#div_tieude').css('display', 'none')
    $('#div_suatieude').css('display', 'block')
})
$('#menuanh').click(function () {
    $('#listanh').css('display', 'block')
})
$('#close_anh').click(function () {
    $('#listanh').css('display', 'none')
})
$('#btn4').click(function () {
    $('#div_cl').css('display', 'block');
})
$('#btn6').click(function () {
    $('#ngay').css('display', 'none')
    $('#nhapngay').css('display', 'block')
})
$('#btn7').click(function () {
    $('.tdphu').css('display', 'none')
    $('#ip_tdphu').css('display', 'block')
    $('#xong_tdphu').css('display', 'block')
})
$('#ok').click(function () {
    $('#div_cl').css('display', 'none')
})

//------------------------------------------------------------------------------
function allowDrop(ev) {
    ev.preventDefault();

}
function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
    document.getElementById('phantudiv1').style.backgroundColor = "#d3d3d3"
    document.getElementById('phantudiv2').style.backgroundColor = "#d3d3d3"
    document.getElementById('phantudiv3').style.backgroundColor = "#d3d3d3"
    document.getElementById('phantudiv4').style.backgroundColor = "#d3d3d3"
}
function drop(ev) {
    //ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
    document.getElementById('phantudiv1').style.backgroundColor = "#e9ecef"
    document.getElementById('phantudiv2').style.backgroundColor = "#e9ecef"
    document.getElementById('phantudiv3').style.backgroundColor = "#e9ecef"
    document.getElementById('phantudiv4').style.backgroundColor = "#e9ecef"

}