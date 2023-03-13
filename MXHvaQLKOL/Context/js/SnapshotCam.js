const container = document.querySelector('#container');
const video = document.querySelector('#videoElm');
const canvas = document.createElement('canvas');
var canvas1 = document.getElementById('canvas1');
const context = canvas.getContext('2d');
const context1 = canvas1.getContext('2d');

var w, h;


var btnchupanh = document.getElementById('btn_chupanh');
btn_chupanh.onclick = function Validate() {
    event.preventDefault();
    context1.fillRect(0, 0, w, h);
    context1.drawImage(video, 0, 0, w, h);

    var canvas2 = document.getElementById('canvas1'),
        dataUrl = canvas2.toDataURL(),
        copycanvas = document.getElementById('copycanvas'),
        srcanh = document.getElementById('srcanh');
    canvas2.style.display = 'none';
    copycanvas.src = dataUrl;
    srcanh.value = dataUrl;
    // Style your image here
    copycanvas.style.width = w;
    copycanvas.style.height = h;
}


function clickxacnhan() {
    document.getElementById('rederict_xacthuc').click();
}

var btnsave = document.getElementById('btn_save');
btnsave.onclick = function Validate() {
    event.preventDefault();
    clickxacnhan();
}
const init = async () => {
    await faceapi.nets.ssdMobilenetv1.loadFromUri('/Models/models')
    await faceapi.nets.faceLandmark68Net.loadFromUri('/Models/models');
    await faceapi.nets.faceRecognitionNet.loadFromUri('/Models/models');
    await faceapi.nets.tinyFaceDetector.loadFromUri('/Models/models');
    await faceapi.nets.faceExpressionNet.loadFromUri('/Models/models');
    Toastify({
        Text: `Tai xong thu vien`,
    }).showToast();
}

function getstream() {
    window.navigator.mediaDevices.getUserMedia({ video: { width: 400, height: 400 } , audio: true })
        .then(stream => {
            video.srcObject = stream;
            video.onloadedmetadata = (e) => {
                video.play();
                w = video.videoWidth;
                h = video.videoHeight

                canvas1.width = w;
                canvas1.height = h;
            };
        })
        .catch(error => {
            alert('You have to enable the mike and the camera');
        });
}


video.addEventListener('playing', () => {
    const canvasnap = faceapi.createCanvasFromMedia(video);
    var themcanvas = document.getElementById('traitren');
    themcanvas.append(canvasnap);

    const displaySize = {
        width: video.videoWidth,
        height: video.videoHeight
    }
    setInterval(async () => {
        const detections = await faceapi.detectSingleFace(video, new faceapi.TinyFaceDetectorOptions())
            .withFaceLandmarks();
           
        const resizedDetects = faceapi.resizeResults(detections, displaySize);

        canvasnap.getContext('2d').clearRect(0, 0, displaySize.width, displaySize.height);

        faceapi.draw.drawDetections(canvasnap, resizedDetects);

    }, 300);
})


init().then(getstream)
