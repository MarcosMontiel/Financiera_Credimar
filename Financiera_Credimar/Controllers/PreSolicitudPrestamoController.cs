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
    public class PreSolicitudPrestamoController : Controller
    {
        private readonly CredimarContext _context;

        public PreSolicitudPrestamoController(CredimarContext context)
        {
            _context = context;
        }

        // GET: PreSolicitudPrestamo
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.PreSolicitudPrestamo.Include(p => p.CliCliente).Include(p => p.EmpEmpleado).Include(p => p.PreCatArticulo).Include(p => p.PreCatEstado);
            return View(await credimarContext.ToListAsync());
        }

        // GET: PreSolicitudPrestamo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preSolicitudPrestamo = await _context.PreSolicitudPrestamo
                .Include(p => p.CliCliente)
                .Include(p => p.EmpEmpleado)
                .Include(p => p.PreCatArticulo)
                .Include(p => p.PreCatEstado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (preSolicitudPrestamo == null)
            {
                return NotFound();
            }

            return View(preSolicitudPrestamo);
        }

        // GET: PreSolicitudPrestamo/Create
        public IActionResult Create()
        {
            ViewData["FKCliCliente"] = new SelectList(_context.CliCliente, "ID", "ClaveCliente");
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado");
            ViewData["FKPreCatArticulo"] = new SelectList(_context.PreCatArticulo, "ID", "Valor");
            ViewData["FKPreCatEstado"] = new SelectList(_context.PreCatEstado, "ID", "Valor");
            return View();
        }

        // POST: PreSolicitudPrestamo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClaveSolicitud,FechaSolicitud,MontoSolicitado,CodigoArticulo,Kilates,Gramos,MontoAprobado,FKCliCliente,FKEmpEmpleado,FKPreCatArticulo,FKPreCatEstado,FechaAprobacion,FechaFin")] PreSolicitudPrestamo preSolicitudPrestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preSolicitudPrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKCliCliente"] = new SelectList(_context.CliCliente, "ID", "ClaveCliente", preSolicitudPrestamo.FKCliCliente);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", preSolicitudPrestamo.FKEmpEmpleado);
            ViewData["FKPreCatArticulo"] = new SelectList(_context.PreCatArticulo, "ID", "Valor", preSolicitudPrestamo.FKPreCatArticulo);
            ViewData["FKPreCatEstado"] = new SelectList(_context.PreCatEstado, "ID", "Valor", preSolicitudPrestamo.FKPreCatEstado);
            return View(preSolicitudPrestamo);
        }

        // GET: PreSolicitudPrestamo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preSolicitudPrestamo = await _context.PreSolicitudPrestamo.SingleOrDefaultAsync(m => m.ID == id);
            if (preSolicitudPrestamo == null)
            {
                return NotFound();
            }
            ViewData["FKCliCliente"] = new SelectList(_context.CliCliente, "ID", "ClaveCliente", preSolicitudPrestamo.FKCliCliente);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", preSolicitudPrestamo.FKEmpEmpleado);
            ViewData["FKPreCatArticulo"] = new SelectList(_context.PreCatArticulo, "ID", "Valor", preSolicitudPrestamo.FKPreCatArticulo);
            ViewData["FKPreCatEstado"] = new SelectList(_context.PreCatEstado, "ID", "Valor", preSolicitudPrestamo.FKPreCatEstado);
            return View(preSolicitudPrestamo);
        }

        // POST: PreSolicitudPrestamo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClaveSolicitud,FechaSolicitud,MontoSolicitado,CodigoArticulo,Kilates,Gramos,MontoAprobado,FKCliCliente,FKEmpEmpleado,FKPreCatArticulo,FKPreCatEstado,FechaAprobacion,FechaFin")] PreSolicitudPrestamo preSolicitudPrestamo)
        {
            if (id != preSolicitudPrestamo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preSolicitudPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreSolicitudPrestamoExists(preSolicitudPrestamo.ID))
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
            ViewData["FKCliCliente"] = new SelectList(_context.CliCliente, "ID", "ClaveCliente", preSolicitudPrestamo.FKCliCliente);
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", preSolicitudPrestamo.FKEmpEmpleado);
            ViewData["FKPreCatArticulo"] = new SelectList(_context.PreCatArticulo, "ID", "Valor", preSolicitudPrestamo.FKPreCatArticulo);
            ViewData["FKPreCatEstado"] = new SelectList(_context.PreCatEstado, "ID", "Valor", preSolicitudPrestamo.FKPreCatEstado);
            return View(preSolicitudPrestamo);
        }

        // GET: PreSolicitudPrestamo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preSolicitudPrestamo = await _context.PreSolicitudPrestamo
                .Include(p => p.CliCliente)
                .Include(p => p.EmpEmpleado)
                .Include(p => p.PreCatArticulo)
                .Include(p => p.PreCatEstado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (preSolicitudPrestamo == null)
            {
                return NotFound();
            }

            return View(preSolicitudPrestamo);
        }

        // POST: PreSolicitudPrestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preSolicitudPrestamo = await _context.PreSolicitudPrestamo.SingleOrDefaultAsync(m => m.ID == id);
            _context.PreSolicitudPrestamo.Remove(preSolicitudPrestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreSolicitudPrestamoExists(int id)
        {
            return _context.PreSolicitudPrestamo.Any(e => e.ID == id);
        }
    }
}
