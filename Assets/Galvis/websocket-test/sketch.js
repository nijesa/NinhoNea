let video;
let poseNet;
let pose;

let suavizadoX = 0;
let velocidadSuavizado = 0.15;

let socket;

function setup() {
  createCanvas(640, 480);

  // cámara
  video = createCapture(VIDEO);
  video.size(width, height);
  video.hide();

  // PoseNet
  poseNet = ml5.poseNet(video, () => {
    console.log("✅ PoseNet listo");
  });

  poseNet.on("pose", (results) => {
    if (results.length > 0) {
      pose = results[0].pose;
    }
  });

  // WebSocket
  socket = new WebSocket("ws://localhost:8080");

  socket.onopen = () => {
    console.log("✅ Conectado al servidor");
  };

  socket.onerror = (e) => {
    console.log("❌ Error WebSocket:", e);
  };
}

function draw() {
  image(video, 0, 0);

  if (pose) {
    actualizarX();
    dibujarPunto();
    mostrarX();

    // enviar cada pocos frames para no saturar
    if (frameCount % 3 === 0) {
      enviarDatos();
    }
  }
}

function actualizarX() {
  let leftShoulder = pose.leftShoulder;
  let rightShoulder = pose.rightShoulder;

  let centroX = (leftShoulder.x + rightShoulder.x) / 2;

  suavizadoX = lerp(suavizadoX, centroX, velocidadSuavizado);
}

function dibujarPunto() {
  fill(0, 0, 255);
  noStroke();
  circle(suavizadoX, height / 2, 15);
}

function mostrarX() {
  fill(0);
  textSize(24);
  textAlign(CENTER);
  text("X: " + suavizadoX.toFixed(0), width / 2, 30);
}

function enviarDatos() {
  if (socket.readyState === WebSocket.OPEN) {
    let data = {
      tipo: "posicion",
      x: suavizadoX
    };

    socket.send(JSON.stringify(data));
  }
}