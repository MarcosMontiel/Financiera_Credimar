using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financiera_Credimar.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace Financiera_Credimar.Controllers
{
    public class ComPersonaController : Controller
    {
        // Inicialización DataContext
        readonly CredimarContext _context;

        // Constructor
        public ComPersonaController(CredimarContext context)
        {
            _context = context;
        }

        // Obtiene resultados de la tabla ComPersona.
        public async Task<IActionResult> Index(string user, string search_person)
        {
            try
            {
                var persona = from s in _context.ComPersona select s;
                persona = persona.Include(c => c.ComCatGenero);

                // Obtener valores de usuario
                int userID = Convert.ToInt32(user);
                var validaUser = await _context.UsuUsuario.SingleOrDefaultAsync(m => m.ID == userID);
                if (validaUser != null)
                {
                    ViewData["idUser"] = validaUser.ID;
                    ViewData["usName"] = validaUser.User;
                    ViewData["usRol"] = validaUser.FKUsuCatRol;
                    ViewData["usState"] = validaUser.FKUsuCatEstado;
                }

                // Caja de búsqueda
                ViewData["filter_name"] = search_person;
                if (!string.IsNullOrEmpty(search_person))
                {
                    persona = persona.Where(s => s.Nombre.Contains(search_person) || s.APaterno.Contains(search_person));
                }

                return View(await persona.ToListAsync());
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

        // Redirecciona a la vista Create. Método Get
        public IActionResult Create()
        {
            try
            {
                ViewData["FKComCatGenero"] = new SelectList(_context.ComCatGenero, "ID", "Valor");
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




        // GET: ComPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona
                .Include(c => c.ComCatGenero)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }

            return View(comPersona);
        }


        // POST: ComPersona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,APaterno,AMaterno,Curp,FechaNac,FKComCatGenero")] ComPersona comPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKComCatGenero"] = new SelectList(_context.ComCatGenero, "ID", "Valor", comPersona.FKComCatGenero);
            return View(comPersona);
        }

        // GET: ComPersona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona.SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }
            ViewData["FKComCatGenero"] = new SelectList(_context.ComCatGenero, "ID", "Valor", comPersona.FKComCatGenero);
            return View(comPersona);
        }

        // POST: ComPersona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,APaterno,AMaterno,Curp,FechaNac,FKComCatGenero")] ComPersona comPersona)
        {
            if (id != comPersona.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComPersonaExists(comPersona.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKComCatGenero"] = new SelectList(_context.ComCatGenero, "ID", "Valor", comPersona.FKComCatGenero);
            return View(comPersona);
        }

        // GET: ComPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comPersona = await _context.ComPersona
                .Include(c => c.ComCatGenero)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comPersona == null)
            {
                return NotFound();
            }

            return View(comPersona);
        }

        // POST: ComPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comPersona = await _context.ComPersona.SingleOrDefaultAsync(m => m.ID == id);
            _context.ComPersona.Remove(comPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComPersonaExists(int id)
        {
            return _context.ComPersona.Any(e => e.ID == id);
        }
    }
}
