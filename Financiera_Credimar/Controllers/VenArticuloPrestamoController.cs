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
    public class VenArticuloPrestamoController : Controller
    {
        private readonly CredimarContext _context;

        public VenArticuloPrestamoController(CredimarContext context)
        {
            _context = context;
        }

        // GET: VenArticuloPrestamo
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.VenArticuloPrestamo.Include(v => v.EmpEmpleado).Include(v => v.PreSolicitudPrestamo).Include(v => v.VenCatEstadoVenta);
            return View(await credimarContext.ToListAsync());
        }

        // GET: VenArticuloPrestamo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venArticuloPrestamo = await _context.VenArticuloPrestamo
                .Include(v => v.EmpEmpleado)
                .Include(v => v.PreSolicitudPrestamo)
                .Include(v => v.VenCatEstadoVenta)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (venArticuloPrestamo == null)
            {
                return NotFound();
            }

            return View(venArticuloPrestamo);
        }

        // GET: VenArticuloPrestamo/Create
        public IActionResult Create()
        {
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado");
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud");
            ViewData["FKVenCatEstadoVenta"] = new SelectList(_context.VenCatEstadoVenta, "ID", "Valor");
            return View();
        }

        // POST: VenArticuloPrestamo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PrecioArticulo,Descripcion,FechaVenta,FKEmpEmpleado,FKPreSolicitudPrestamo,FKVenCatEstadoVenta")] VenArticuloPrestamo venArticuloPrestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venArticuloPrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", venArticuloPrestamo.FKEmpEmpleado);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", venArticuloPrestamo.FKPreSolicitudPrestamo);
            ViewData["FKVenCatEstadoVenta"] = new SelectList(_context.VenCatEstadoVenta, "ID", "Valor", venArticuloPrestamo.FKVenCatEstadoVenta);
            return View(venArticuloPrestamo);
        }

        // GET: VenArticuloPrestamo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venArticuloPrestamo = await _context.VenArticuloPrestamo.SingleOrDefaultAsync(m => m.ID == id);
            if (venArticuloPrestamo == null)
            {
                return NotFound();
            }
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", venArticuloPrestamo.FKEmpEmpleado);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", venArticuloPrestamo.FKPreSolicitudPrestamo);
            ViewData["FKVenCatEstadoVenta"] = new SelectList(_context.VenCatEstadoVenta, "ID", "Valor", venArticuloPrestamo.FKVenCatEstadoVenta);
            return View(venArticuloPrestamo);
        }

        // POST: VenArticuloPrestamo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PrecioArticulo,Descripcion,FechaVenta,FKEmpEmpleado,FKPreSolicitudPrestamo,FKVenCatEstadoVenta")] VenArticuloPrestamo venArticuloPrestamo)
        {
            if (id != venArticuloPrestamo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venArticuloPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenArticuloPrestamoExists(venArticuloPrestamo.ID))
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
            ViewData["FKEmpEmpleado"] = new SelectList(_context.EmpEmpleado, "ID", "ClaveEmpleado", venArticuloPrestamo.FKEmpEmpleado);
            ViewData["FKPreSolicitudPrestamo"] = new SelectList(_context.PreSolicitudPrestamo, "ID", "ClaveSolicitud", venArticuloPrestamo.FKPreSolicitudPrestamo);
            ViewData["FKVenCatEstadoVenta"] = new SelectList(_context.VenCatEstadoVenta, "ID", "Valor", venArticuloPrestamo.FKVenCatEstadoVenta);
            return View(venArticuloPrestamo);
        }

        // GET: VenArticuloPrestamo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venArticuloPrestamo = await _context.VenArticuloPrestamo
                .Include(v => v.EmpEmpleado)
                .Include(v => v.PreSolicitudPrestamo)
                .Include(v => v.VenCatEstadoVenta)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (venArticuloPrestamo == null)
            {
                return NotFound();
            }

            return View(venArticuloPrestamo);
        }

        // POST: VenArticuloPrestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venArticuloPrestamo = await _context.VenArticuloPrestamo.SingleOrDefaultAsync(m => m.ID == id);
            _context.VenArticuloPrestamo.Remove(venArticuloPrestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenArticuloPrestamoExists(int id)
        {
            return _context.VenArticuloPrestamo.Any(e => e.ID == id);
        }
    }
}
