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
    public class EmpEmpleadoController : Controller
    {
        private readonly CredimarContext _context;

        public EmpEmpleadoController(CredimarContext context)
        {
            _context = context;
        }

        // GET: EmpEmpleado
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.EmpEmpleado.Include(e => e.ComCatSucursal).Include(e => e.ComPersona).Include(e => e.EmpCatEstadoFinal).Include(e => e.EmpCatEstadoTemporal).Include(e => e.EmpCatPuesto);
            return View(await credimarContext.ToListAsync());
        }

        // GET: EmpEmpleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empEmpleado = await _context.EmpEmpleado
                .Include(e => e.ComCatSucursal)
                .Include(e => e.ComPersona)
                .Include(e => e.EmpCatEstadoFinal)
                .Include(e => e.EmpCatEstadoTemporal)
                .Include(e => e.EmpCatPuesto)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empEmpleado == null)
            {
                return NotFound();
            }

            return View(empEmpleado);
        }

        // GET: EmpEmpleado/Create
        public IActionResult Create()
        {
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor");
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno");
            ViewData["FKEmpCatEstadoFinal"] = new SelectList(_context.EmpCatEstadoFinal, "ID", "Valor");
            ViewData["FKEmpCatEstadoTemporal"] = new SelectList(_context.EmpCatEstadoTemporal, "ID", "Valor");
            ViewData["FKEmpCatPuesto"] = new SelectList(_context.EmpCatPuesto, "ID", "Valor");
            return View();
        }

        // POST: EmpEmpleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClaveEmpleado,FechaAlta,Rfc,NoImms,FKComPersona,FKComCatSucursal,FKEmpCatPuesto,FKEmpCatEstadoTemporal,FKEmpCatEstadoFinal,FechaBaja")] EmpEmpleado empEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", empEmpleado.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", empEmpleado.FKComPersona);
            ViewData["FKEmpCatEstadoFinal"] = new SelectList(_context.EmpCatEstadoFinal, "ID", "Valor", empEmpleado.FKEmpCatEstadoFinal);
            ViewData["FKEmpCatEstadoTemporal"] = new SelectList(_context.EmpCatEstadoTemporal, "ID", "Valor", empEmpleado.FKEmpCatEstadoTemporal);
            ViewData["FKEmpCatPuesto"] = new SelectList(_context.EmpCatPuesto, "ID", "Valor", empEmpleado.FKEmpCatPuesto);
            return View(empEmpleado);
        }

        // GET: EmpEmpleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empEmpleado = await _context.EmpEmpleado.SingleOrDefaultAsync(m => m.ID == id);
            if (empEmpleado == null)
            {
                return NotFound();
            }
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", empEmpleado.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", empEmpleado.FKComPersona);
            ViewData["FKEmpCatEstadoFinal"] = new SelectList(_context.EmpCatEstadoFinal, "ID", "Valor", empEmpleado.FKEmpCatEstadoFinal);
            ViewData["FKEmpCatEstadoTemporal"] = new SelectList(_context.EmpCatEstadoTemporal, "ID", "Valor", empEmpleado.FKEmpCatEstadoTemporal);
            ViewData["FKEmpCatPuesto"] = new SelectList(_context.EmpCatPuesto, "ID", "Valor", empEmpleado.FKEmpCatPuesto);
            return View(empEmpleado);
        }

        // POST: EmpEmpleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClaveEmpleado,FechaAlta,Rfc,NoImms,FKComPersona,FKComCatSucursal,FKEmpCatPuesto,FKEmpCatEstadoTemporal,FKEmpCatEstadoFinal,FechaBaja")] EmpEmpleado empEmpleado)
        {
            if (id != empEmpleado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpEmpleadoExists(empEmpleado.ID))
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
            ViewData["FKComCatSucursal"] = new SelectList(_context.ComCatSucursal, "ID", "Valor", empEmpleado.FKComCatSucursal);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", empEmpleado.FKComPersona);
            ViewData["FKEmpCatEstadoFinal"] = new SelectList(_context.EmpCatEstadoFinal, "ID", "Valor", empEmpleado.FKEmpCatEstadoFinal);
            ViewData["FKEmpCatEstadoTemporal"] = new SelectList(_context.EmpCatEstadoTemporal, "ID", "Valor", empEmpleado.FKEmpCatEstadoTemporal);
            ViewData["FKEmpCatPuesto"] = new SelectList(_context.EmpCatPuesto, "ID", "Valor", empEmpleado.FKEmpCatPuesto);
            return View(empEmpleado);
        }

        // GET: EmpEmpleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empEmpleado = await _context.EmpEmpleado
                .Include(e => e.ComCatSucursal)
                .Include(e => e.ComPersona)
                .Include(e => e.EmpCatEstadoFinal)
                .Include(e => e.EmpCatEstadoTemporal)
                .Include(e => e.EmpCatPuesto)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empEmpleado == null)
            {
                return NotFound();
            }

            return View(empEmpleado);
        }

        // POST: EmpEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empEmpleado = await _context.EmpEmpleado.SingleOrDefaultAsync(m => m.ID == id);
            _context.EmpEmpleado.Remove(empEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpEmpleadoExists(int id)
        {
            return _context.EmpEmpleado.Any(e => e.ID == id);
        }
    }
}
