const express = require('express');
const bodyParser = require('body-parser');
const twilio = require('twilio');
const dotenv = require('dotenv');
const cors = require('cors');

const app = express();

// Habilitar CORS
app.use(cors({ origin: 'https://localhost:7187' }));


// Usar bodyParser para procesar solicitudes JSON
app.use(bodyParser.json());

// Servir archivos estáticos desde la carpeta 'public'
app.use(express.static('public'));

// Configuración de Twilio usando variables de entorno
const ACCOUNT_SID = 'ACe08371f3b363298225019e113bf4a021';
const AUTH_TOKEN = 'f845de3ac776b06c9b007515298e65a1';
const TWILIO_PHONE = '+18149850651';

const client = twilio(ACCOUNT_SID, AUTH_TOKEN);

// Ruta para enviar el código
app.post('/sendCode', (req, res) => {
    const phoneNumber = req.body.phoneNumber;
    const code = Math.floor(Math.random() * 900000 + 100000);


    console.log("Intentando enviar mensaje a:", phoneNumber, "con código:", code);

    client.messages.create({
        body: "Usa el codigo: " + code + " para autenticarse",
        from: TWILIO_PHONE,
        to: phoneNumber
    })
        .then(message => {
            console.log("Mensaje enviado con SID:", message.sid);
            res.json({ code: code });
        })
        .catch(err => {
            console.error("Error al enviar el código:", err);
            res.status(500).send("Error al enviar el código");
        });
});

// Iniciar el servidor
app.listen(5000, () => {
    console.log('Servidor corriendo en el puerto 5000');
});
