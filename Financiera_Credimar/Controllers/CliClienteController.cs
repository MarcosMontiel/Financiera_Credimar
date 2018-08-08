using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financiera_Credimar.Models;

namespace Financiera_Credimar.Controllers
{
    public class CliClienteController : Controller
    {
        private readonly CredimarContext _context;

        public CliClienteController(CredimarContext context)
        {
            _context = context;
        }

        // GET: CliCliente
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.CliCliente.Include(c => c.CliCatEstadoFinal).Include(c => c.CliCatEstadoTemporal).Include(c => c.ComCatSucursal).Include(c => c.ComPersona).Include(c => c.EmpEmpleado);
            return View(await credimarContext.ToListAsync());
        }

        // GET: CliCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliCliente = await _context.CliCliente
                .Include(c => c.CliCatEstadoFinal)
                .Include(c => c.CliCatEstadoTemporal)
                .Include(c => c.ComCatSucursal)
                .Include(c => c.ComPersona)
                .Include(c => c.EmpEmpleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cliCliente == null)
            {
                return NotFound();
            }

            return View(cliCliente);
        }

        // GET: CliCliente/Create
        public IActionResult Create()
        {
            ViewData["FKCliCatEstadoFinal"] = new SelectList(_context.CliCatEstadoFinal, "ID", "Valor");
            ViewData["FKCliCatEstadoTemporal"] = new SelectList(_context.CliCatEstadoTemporal, "ID", "Valor");
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor");
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno");
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado");
            return View();
        }

        // POST: CliCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClaveCliente,FechaAlta,FKComCatSucursal,FKComPersona,FKEmpEmpleado,FKCliCatEstadoTemporal,FKCliCatEstadoFinal,FechaBaja")] CliCliente cliCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKCliCatEstadoFinal"] = new SelectList(_context.CliCatEstadoFinal, "ID", "Valor", cliCliente.FKCliCatEstadoFinal);
            ViewData["FKCliCatEstadoTemporal"] = new SelectList(_context.CliCatEstadoTemporal, "ID", "Valor", cliCliente.FKCliCatEstadoTemporal);
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", cliCliente.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", cliCliente.FKComPersona);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", cliCliente.FKEmpEmpleado);
            return View(cliCliente);
        }

        // GET: CliCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliCliente = await _context.CliCliente.SingleOrDefaultAsync(m => m.ID == id);
            if (cliCliente == null)
            {
                return NotFound();
            }
            ViewData["FKCliCatEstadoFinal"] = new SelectList(_context.CliCatEstadoFinal, "ID", "Valor", cliCliente.FKCliCatEstadoFinal);
            ViewData["FKCliCatEstadoTemporal"] = new SelectList(_context.CliCatEstadoTemporal, "ID", "Valor", cliCliente.FKCliCatEstadoTemporal);
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", cliCliente.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", cliCliente.FKComPersona);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", cliCliente.FKEmpEmpleado);
            return View(cliCliente);
        }

        // POST: CliCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClaveCliente,FechaAlta,FKComCatSucursal,FKComPersona,FKEmpEmpleado,FKCliCatEstadoTemporal,FKCliCatEstadoFinal,FechaBaja")] CliCliente cliCliente)
        {
            if (id != cliCliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CliClienteExists(cliCliente.ID))
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
            ViewData["FKCliCatEstadoFinal"] = new SelectList(_context.CliCatEstadoFinal, "ID", "Valor", cliCliente.FKCliCatEstadoFinal);
            ViewData["FKCliCatEstadoTemporal"] = new SelectList(_context.CliCatEstadoTemporal, "ID", "Valor", cliCliente.FKCliCatEstadoTemporal);
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", cliCliente.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", cliCliente.FKComPersona);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", cliCliente.FKEmpEmpleado);
            return View(cliCliente);
        }

        // GET: CliCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliCliente = await _context.CliCliente
                .Include(c => c.CliCatEstadoFinal)
                .Include(c => c.CliCatEstadoTemporal)
                .Include(c => c.ComCatSucursal)
                .Include(c => c.ComPersona)
                .Include(c => c.EmpEmpleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cliCliente == null)
            {
                return NotFound();
            }

            return View(cliCliente);
        }

        // POST: CliCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliCliente = await _context.CliCliente.SingleOrDefaultAsync(m => m.ID == id);
            _context.CliCliente.Remove(cliCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CliClienteExists(int id)
        {
            return _context.CliCliente.Any(e => e.ID == id);
        }
    }
}
