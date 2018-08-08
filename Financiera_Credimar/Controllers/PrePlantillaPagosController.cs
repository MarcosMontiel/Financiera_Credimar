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
    public class PrePlantillaPagosController : Controller
    {
        private readonly CredimarContext _context;

        public PrePlantillaPagosController(CredimarContext context)
        {
            _context = context;
        }

        // GET: PrePlantillaPagos
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.PrePlantillaPagos.Include(p => p.PreCatEstadoPago).Include(p => p.PreSolicitudPrestamo);
            return View(await credimarContext.ToListAsync());
        }

        // GET: PrePlantillaPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prePlantillaPagos = await _context.PrePlantillaPagos
                .Include(p => p.PreCatEstadoPago)
                .Include(p => p.PreSolicitudPrestamo)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (prePlantillaPagos == null)
            {
                return NotFound();
            }

            return View(prePlantillaPagos);
        }

        // GET: PrePlantillaPagos/Create
        public IActionResult Create()
        {
            ViewData["FKPreCatEstadoPago"] = new SelectList(_context.PreCatEstadoPago, "ID", "Valor");
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud");
            return View();
        }

        // POST: PrePlantillaPagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NoPago,PagoRequerido,FechaRequeridaPago,PagoRealizado,FechaPago,FKPreSolicitudPrestamo,FKPreCatEstadoPago")] PrePlantillaPagos prePlantillaPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prePlantillaPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKPreCatEstadoPago"] = new SelectList(_context.PreCatEstadoPago, "ID", "Valor", prePlantillaPagos.FKPreCatEstadoPago);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", prePlantillaPagos.FKPreSolicitudPrestamo);
            return View(prePlantillaPagos);
        }

        // GET: PrePlantillaPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prePlantillaPagos = await _context.PrePlantillaPagos.SingleOrDefaultAsync(m => m.ID == id);
            if (prePlantillaPagos == null)
            {
                return NotFound();
            }
            ViewData["FKPreCatEstadoPago"] = new SelectList(_context.PreCatEstadoPago, "ID", "Valor", prePlantillaPagos.FKPreCatEstadoPago);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", prePlantillaPagos.FKPreSolicitudPrestamo);
            return View(prePlantillaPagos);
        }

        // POST: PrePlantillaPagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NoPago,PagoRequerido,FechaRequeridaPago,PagoRealizado,FechaPago,FKPreSolicitudPrestamo,FKPreCatEstadoPago")] PrePlantillaPagos prePlantillaPagos)
        {
            if (id != prePlantillaPagos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prePlantillaPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrePlantillaPagosExists(prePlantillaPagos.ID))
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
            ViewData["FKPreCatEstadoPago"] = new SelectList(_context.PreCatEstadoPago, "ID", "Valor", prePlantillaPagos.FKPreCatEstadoPago);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", prePlantillaPagos.FKPreSolicitudPrestamo);
            return View(prePlantillaPagos);
        }

        // GET: PrePlantillaPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prePlantillaPagos = await _context.PrePlantillaPagos
                .Include(p => p.PreCatEstadoPago)
                .Include(p => p.PreSolicitudPrestamo)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (prePlantillaPagos == null)
            {
                return NotFound();
            }

            return View(prePlantillaPagos);
        }

        // POST: PrePlantillaPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prePlantillaPagos = await _context.PrePlantillaPagos.SingleOrDefaultAsync(m => m.ID == id);
            _context.PrePlantillaPagos.Remove(prePlantillaPagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrePlantillaPagosExists(int id)
        {
            return _context.PrePlantillaPagos.Any(e => e.ID == id);
        }
    }
}
