using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CXCPROYECTOFINAL.Models;

namespace CXCPROYECTOFINAL.Controllers
{
    public class TiposDocumentosController : Controller
    {
        private readonly CxcContext _context;

        public TiposDocumentosController(CxcContext context)
        {
            _context = context;
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
              return _context.TipossDocumentos != null ? 
                          View(await _context.TipossDocumentos.ToListAsync()) :
                          Problem("Entity set 'CxcContext.TipossDocumentos'  is null.");
        }

        // GET: TiposDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipossDocumentos == null)
            {
                return NotFound();
            }

            var tipossDocumento = await _context.TipossDocumentos
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (tipossDocumento == null)
            {
                return NotFound();
            }

            return View(tipossDocumento);
        }

        // GET: TiposDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificador,Descripcion,CuentaContable,Estado")] TipossDocumento tipossDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipossDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipossDocumento);
        }

        // GET: TiposDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipossDocumentos == null)
            {
                return NotFound();
            }

            var tipossDocumento = await _context.TipossDocumentos.FindAsync(id);
            if (tipossDocumento == null)
            {
                return NotFound();
            }
            return View(tipossDocumento);
        }

        // POST: TiposDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificador,Descripcion,CuentaContable,Estado")] TipossDocumento tipossDocumento)
        {
            if (id != tipossDocumento.Identificador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipossDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipossDocumentoExists(tipossDocumento.Identificador))
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
            return View(tipossDocumento);
        }

        // GET: TiposDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipossDocumentos == null)
            {
                return NotFound();
            }

            var tipossDocumento = await _context.TipossDocumentos
                .FirstOrDefaultAsync(m => m.Identificador == id);
            if (tipossDocumento == null)
            {
                return NotFound();
            }

            return View(tipossDocumento);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipossDocumentos == null)
            {
                return Problem("Entity set 'CxcContext.TipossDocumentos'  is null.");
            }
            var tipossDocumento = await _context.TipossDocumentos.FindAsync(id);
            if (tipossDocumento != null)
            {
                _context.TipossDocumentos.Remove(tipossDocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipossDocumentoExists(int id)
        {
          return (_context.TipossDocumentos?.Any(e => e.Identificador == id)).GetValueOrDefault();
        }
    }
}
