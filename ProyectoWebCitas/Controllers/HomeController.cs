using Microsoft.AspNetCore.Mvc;
using ProyectoWebCitas.Models;
using System;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Logging; // Asegúrate de tener esto
using System.Diagnostics;

namespace ProyectoWebCitas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult iniciosesion()
        {
            return View();
        }

        public IActionResult olvidocontraseña()
        {
            return View();
        }

        [HttpPost]
        public IActionResult olvidocontraseña(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                ModelState.AddModelError("", "Por favor, ingresa tu número de celular.");
                return View();
            }

            // Generar el código
            var code = new Random().Next(100000, 999999).ToString();

            const string ACCOUNT_SID = "ACe08371f3b363298225019e113bf4a021";
            const string authToken = "9bf7641b1a8e6e4572cba8b53ad421db";
            const string TWILIO_PHONE = "+18149850651";

            TwilioClient.Init(ACCOUNT_SID, authToken);
            try
            {
                var message = MessageResource.Create(
                    body: $"Usa el codigo: {code} para autenticarse",
                    from: TWILIO_PHONE,
                    to: phoneNumber
                );

                TempData["GeneratedCode"] = code;
            }
            catch (TwilioException ex)
            {
                _logger.LogError(ex, "Error al enviar el código a través de Twilio."); // Registrar el error
                ModelState.AddModelError("", "Error al enviar el código. Por favor intenta nuevamente.");
                return View();
            }

            return RedirectToAction("IngresarCodigo");
        }

        public IActionResult IngresarCodigo() // Asegúrate de que esta acción exista
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}



