using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Financiera_Credimar.Models;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Financiera_Credimar.Controllers
{
    public class HomeController : Controller
    {
        // Inicialización DataContext
        readonly CredimarContext _context;

        // Constructor
        public HomeController(CredimarContext context)
        {
            _context = context;
        }

        // Retorna la vista Index
        public IActionResult Index()
        {
            try
            {
                if (ViewData["usName"] == null)
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Credimar Exceptions", "marcosmontiel.excepciones@gmail.com"));
                message.To.Add(new MailboxAddress("Reception", "marcos-gab14@hotmail.com"));
                message.Subject = "Exceptions";
                message.Body = new TextPart("plain")
                {
                    Text = "Excepción encontrada: " + ex.StackTrace
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("marcosmontiel.excepciones@gmail.com", "PruebaExcepciones123");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return null;
            }
            return View();
        }

        // Retorna la vista About
        public async Task<IActionResult> About(string user)
        {
            try
            {
                int userID = Convert.ToInt32(user);
                var validaUser = await _context.UsuUsuario.SingleOrDefaultAsync(m => m.ID == userID);
                if (validaUser != null)
                {
                    ViewData["idUser"] = validaUser.ID;
                    ViewData["usName"] = validaUser.User;
                    ViewData["usRol"] = validaUser.FKUsuCatRol;
                    ViewData["usState"] = validaUser.FKUsuCatEstado;
                }
                if (ViewData["usName"] == null)
                {
                    return View("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Credimar Exceptions", "marcosmontiel.excepciones@gmail.com"));
                message.To.Add(new MailboxAddress("Reception", "marcos-gab14@hotmail.com"));
                message.Subject = "Exceptions";
                message.Body = new TextPart("plain")
                {
                    Text = "Excepción encontrada: " + ex.StackTrace
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("marcosmontiel.excepciones@gmail.com", "PruebaExcepciones123");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return null;
            }
        }

        // Método que captura los datos del formulario y otorga o niega permisos de acceso.
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index([Bind("User,Password")] UsuUsuario usuUsuario)
        {
            try
            {
                var validaUser = await _context.UsuUsuario.SingleOrDefaultAsync(m => m.User == usuUsuario.User);
                if (validaUser != null)
                {
                    if (validaUser.Password != usuUsuario.Password)
                    {
                        ViewData["error"] = "Contraseña incorrecta.";
                        return View();
                    }
                    if (validaUser.FKUsuCatEstado != 1)
                    {
                        ViewData["error"] = "Cuenta inactiva.";
                        return View();
                    }
                    if (validaUser.User == usuUsuario.User &&
                        validaUser.Password == usuUsuario.Password && 
                        validaUser.FKUsuCatEstado == 1)
                    {
                        ViewData["idUser"] = validaUser.ID;
                        ViewData["usName"] = validaUser.User;
                        ViewData["usRol"] = validaUser.FKUsuCatRol;
                        ViewData["usState"] = validaUser.FKUsuCatEstado;
                        return View("About");
                    }
                }
                ViewData["error"] = "La cuenta no existe.";
                return View();
            }
            catch (Exception ex)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Credimar Exceptions", "marcosmontiel.excepciones@gmail.com"));
                message.To.Add(new MailboxAddress("Reception", "marcos-gab14@hotmail.com"));
                message.Subject = "Exceptions";
                message.Body = new TextPart("plain")
                {
                    Text = "Excepción encontrada: " + ex.StackTrace
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("marcosmontiel.excepciones@gmail.com", "PruebaExcepciones123");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return null;
            }
        }

        // Retorna la vista Error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}