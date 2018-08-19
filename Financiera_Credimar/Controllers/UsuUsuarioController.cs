using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financiera_Credimar.Models;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;

namespace Financiera_Credimar.Controllers
{
    public class UsuUsuarioController : Controller
    {
        // Inicialización DataContext
        readonly CredimarContext _context;
        public UsuUsuarioController(CredimarContext context)
        {
            _context = context;
        }

        // GET: UsuUsuario
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.UsuUsuario.Include(u => u.EmpEmpleado).Include(u => u.UsuCatEstado).Include(u => u.UsuCatRol);
            return View(await credimarContext.ToListAsync());
        }

        // GET: UsuUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuUsuario = await _context.UsuUsuario
                .Include(u => u.EmpEmpleado)
                .Include(u => u.UsuCatEstado)
                .Include(u => u.UsuCatRol)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usuUsuario == null)
            {
                return NotFound();
            }

            return View(usuUsuario);
        }

        // GET: UsuUsuario/Create
        public IActionResult Create()
        {
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado");
            ViewData["FKUsuCatEstado"] = new SelectList(_context.UsuCatEstado, "ID", "Valor");
            ViewData["FKUsuCatRol"] = new SelectList(_context.UsuCatRol, "ID", "Valor");
            return View();
        }

        // POST: UsuUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,User,Password,FKEmpEmpleado,FKUsuCatRol,FKUsuCatEstado")] UsuUsuario usuUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", usuUsuario.FKEmpEmpleado);
            ViewData["FKUsuCatEstado"] = new SelectList(_context.UsuCatEstado, "ID", "Valor", usuUsuario.FKUsuCatEstado);
            ViewData["FKUsuCatRol"] = new SelectList(_context.UsuCatRol, "ID", "Valor", usuUsuario.FKUsuCatRol);
            return View(usuUsuario);
        }

        // GET: UsuUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuUsuario = await _context.UsuUsuario.SingleOrDefaultAsync(m => m.ID == id);
            if (usuUsuario == null)
            {
                return NotFound();
            }
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", usuUsuario.FKEmpEmpleado);
            ViewData["FKUsuCatEstado"] = new SelectList(_context.UsuCatEstado, "ID", "Valor", usuUsuario.FKUsuCatEstado);
            ViewData["FKUsuCatRol"] = new SelectList(_context.UsuCatRol, "ID", "Valor", usuUsuario.FKUsuCatRol);
            return View(usuUsuario);
        }

        // POST: UsuUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User,Password,FKEmpEmpleado,FKUsuCatRol,FKUsuCatEstado")] UsuUsuario usuUsuario)
        {
            if (id != usuUsuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuUsuarioExists(usuUsuario.ID))
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
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", usuUsuario.FKEmpEmpleado);
            ViewData["FKUsuCatEstado"] = new SelectList(_context.UsuCatEstado, "ID", "Valor", usuUsuario.FKUsuCatEstado);
            ViewData["FKUsuCatRol"] = new SelectList(_context.UsuCatRol, "ID", "Valor", usuUsuario.FKUsuCatRol);
            return View(usuUsuario);
        }

        // GET: UsuUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuUsuario = await _context.UsuUsuario
                .Include(u => u.EmpEmpleado)
                .Include(u => u.UsuCatEstado)
                .Include(u => u.UsuCatRol)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usuUsuario == null)
            {
                return NotFound();
            }

            return View(usuUsuario);
        }

        // POST: UsuUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuUsuario = await _context.UsuUsuario.SingleOrDefaultAsync(m => m.ID == id);
            _context.UsuUsuario.Remove(usuUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuUsuarioExists(int id)
        {
            return _context.UsuUsuario.Any(e => e.ID == id);
        }
    }
}
