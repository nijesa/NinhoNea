const WebSocket = require('ws');

// Crear servidor en puerto 3000
const wss = new WebSocket.Server({ port: 3000 });

console.log("Servidor corriendo en ws://localhost:3000");

// Cuando alguien se conecta
wss.on('connection', (ws) => {
    console.log("Cliente conectado");

    // Cuando llega un mensaje
    ws.on('message', (message) => {
        console.log("Mensaje recibido:", message.toString());

        // Reenviar a todos los clientes
        wss.clients.forEach(client => {
            if (client.readyState === WebSocket.OPEN) {
                client.send(message.toString());
            }
        });
    });

    // Cuando alguien se desconecta
    ws.on('close', () => {
        console.log("Cliente desconectado");
    });
});