const container = document.querySelector('#container');
const video = document.querySelector('#videoElm');

async function loadTrendingdata() {
    var label = document.getElementById('AccName').value;
    var soanh = document.getElementById('solan').value;
    console.log(label);
    console.log(soanh);
    const descriptions = [];
    for (let i = 0; i <= soanh; i++) {
        var temp = document.getElementById(`${i}`);
        var newImage = document.createElement('img');
        newImage.src = temp.src;

        const ima = await faceapi.fetchImage(temp.src);
        const detection = await faceapi.detectSingleFace(ima).withFaceLandmarks().withFaceDescriptor()
        descriptions.push(detection.descriptor)
        Toastify({
            Text: `Tai xong ${i}`
        }).showToast();
    }
    return new faceapi.LabeledFaceDescriptors(label, descriptions);
}
let trending
const init = async () => {
    await faceapi.nets.ssdMobilenetv1.loadFromUri('/Models/models')
    await faceapi.nets.faceLandmark68Net.loadFromUri('/Models/models');
    await faceapi.nets.faceRecognitionNet.loadFromUri('/Models/models');
    await faceapi.nets.tinyFaceDetector.loadFromUri('/Models/models');
    await faceapi.nets.faceExpressionNet.loadFromUri('/Models/models');

    trending = await loadTrendingdata();

    console.log({ trending })

    Toastify({
        Text: `Tai xong thu vien`
    }).showToast();
}

function getstream() {
    window.navigator.mediaDevices.getUserMedia({ video: true, audio: true })
        .then(stream => {
            video.srcObject = stream;
            video.onloadedmetadata = (e) => {
                video.play();
            };
        })
        .catch(error => {
            alert('You have to enable the mike and the camera');
        });
}

function clickbutton() {
    var dentrangchu = document.getElementById('dentrangchu');
    dentrangchu.click();
}


video.addEventListener('playing', () => {
    const canvas = faceapi.createCanvasFromMedia(video);
    document.body.append(canvas);

    const displaySize = {
        width: video.videoWidth,
        height: video.videoHeight
    }

    setInterval(async () => {
        const detects = await faceapi.detectSingleFace(video, new faceapi.SsdMobilenetv1Options())
            .withFaceLandmarks()
            .withFaceDescriptor();
        faceapi.matchDimensions(canvas, displaySize);
        const resizedDetections = faceapi.resizeResults(detects, displaySize);

        const faceMatcher3 = new faceapi.FaceMatcher(trending, 0.4);
        if (detects) {
            const bestMatch = faceMatcher3.findBestMatch(detects.descriptor);
            const box = resizedDetections.detection.box;
            const drawBox = new faceapi.draw.DrawBox(box, { label: bestMatch.label });
            drawBox.draw(canvas);

            if (bestMatch.label == document.getElementById('AccName').value){
                clickbutton();
            }
        }
    }, 300);
})



init().then(getstream)


