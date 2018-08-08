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
    public class ComDirDireccionController : Controller
    {
        private readonly CredimarContext _context;

        public ComDirDireccionController(CredimarContext context)
        {
            _context = context;
        }

        // GET: ComDirDireccion
        public async Task<IActionResult> Index()
        {
            var credimarContext = _context.ComDirDireccion.Include(c => c.ComDirCatColonia).Include(c => c.ComDirCatEstado).Include(c => c.ComDirCatMunicipio).Include(c => c.ComPersona);
            return View(await credimarContext.ToListAsync());
        }

        // GET: ComDirDireccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comDirDireccion = await _context.ComDirDireccion
                .Include(c => c.ComDirCatColonia)
                .Include(c => c.ComDirCatEstado)
                .Include(c => c.ComDirCatMunicipio)
                .Include(c => c.ComPersona)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comDirDireccion == null)
            {
                return NotFound();
            }

            return View(comDirDireccion);
        }

        // GET: ComDirDireccion/Create
        public IActionResult Create()
        {
            ViewData["FKComDirCatColonia"] = new SelectList(_context.ComDirCatColonia, "ID", "Valor");
            ViewData["FKComDirCatEstado"] = new SelectList(_context.ComDirCatEstado, "ID", "Valor");
            ViewData["FKComDirCatMunicipio"] = new SelectList(_context.ComDirCatMunicipio, "ID", "Valor");
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno");
            return View();
        }

        // POST: ComDirDireccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Calle,NumExt,NumInt,CP,FKComPersona,FKComDirCatEstado,FKComDirCatMunicipio,FKComDirCatColonia")] ComDirDireccion comDirDireccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comDirDireccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKComDirCatColonia"] = new SelectList(_context.ComDirCatColonia, "ID", "Valor", comDirDireccion.FKComDirCatColonia);
            ViewData["FKComDirCatEstado"] = new SelectList(_context.ComDirCatEstado, "ID", "Valor", comDirDireccion.FKComDirCatEstado);
            ViewData["FKComDirCatMunicipio"] = new SelectList(_context.ComDirCatMunicipio, "ID", "Valor", comDirDireccion.FKComDirCatMunicipio);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", comDirDireccion.FKComPersona);
            return View(comDirDireccion);
        }

        // GET: ComDirDireccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comDirDireccion = await _context.ComDirDireccion.SingleOrDefaultAsync(m => m.ID == id);
            if (comDirDireccion == null)
            {
                return NotFound();
            }
            ViewData["FKComDirCatColonia"] = new SelectList(_context.ComDirCatColonia, "ID", "Valor", comDirDireccion.FKComDirCatColonia);
            ViewData["FKComDirCatEstado"] = new SelectList(_context.ComDirCatEstado, "ID", "Valor", comDirDireccion.FKComDirCatEstado);
            ViewData["FKComDirCatMunicipio"] = new SelectList(_context.ComDirCatMunicipio, "ID", "Valor", comDirDireccion.FKComDirCatMunicipio);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", comDirDireccion.FKComPersona);
            return View(comDirDireccion);
        }

        // POST: ComDirDireccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Calle,NumExt,NumInt,CP,FKComPersona,FKComDirCatEstado,FKComDirCatMunicipio,FKComDirCatColonia")] ComDirDireccion comDirDireccion)
        {
            if (id != comDirDireccion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comDirDireccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComDirDireccionExists(comDirDireccion.ID))
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
            ViewData["FKComDirCatColonia"] = new SelectList(_context.ComDirCatColonia, "ID", "Valor", comDirDireccion.FKComDirCatColonia);
            ViewData["FKComDirCatEstado"] = new SelectList(_context.ComDirCatEstado, "ID", "Valor", comDirDireccion.FKComDirCatEstado);
            ViewData["FKComDirCatMunicipio"] = new SelectList(_context.ComDirCatMunicipio, "ID", "Valor", comDirDireccion.FKComDirCatMunicipio);
            ViewData["FKComPersona"] = new SelectList(_context.ComPersona, "ID", "AMaterno", comDirDireccion.FKComPersona);
            return View(comDirDireccion);
        }

        // GET: ComDirDireccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comDirDireccion = await _context.ComDirDireccion
                .Include(c => c.ComDirCatColonia)
                .Include(c => c.ComDirCatEstado)
                .Include(c => c.ComDirCatMunicipio)
                .Include(c => c.ComPersona)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (comDirDireccion == null)
            {
                return NotFound();
            }

            return View(comDirDireccion);
        }

        // POST: ComDirDireccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comDirDireccion = await _context.ComDirDireccion.SingleOrDefaultAsync(m => m.ID == id);
            _context.ComDirDireccion.Remove(comDirDireccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComDirDireccionExists(int id)
        {
            return _context.ComDirDireccion.Any(e => e.ID == id);
        }
    }
}
