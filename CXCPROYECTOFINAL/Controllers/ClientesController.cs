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
    public class ClientesController : Controller
    {
        private readonly CxcContext _context;

        public ClientesController(CxcContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return _context.Clientesses != null ? 
                          View(await _context.Clientesses.ToListAsync()) :
                          Problem("Entity set 'CxcContext.Clientesses'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientesses == null)
            {
                return NotFound();
            }

            var clientess = await _context.Clientesses
                .FirstOrDefaultAsync(m => m.IdentificadorClientess == id);
            if (clientess == null)
            {
                return NotFound();
            }

            return View(clientess);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentificadorClientess,Nombre,Cedula,LimiteCredito,Estado")] Clientess clientess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientess);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientesses == null)
            {
                return NotFound();
            }

            var clientess = await _context.Clientesses.FindAsync(id);
            if (clientess == null)
            {
                return NotFound();
            }
            return View(clientess);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdentificadorClientess,Nombre,Cedula,LimiteCredito,Estado")] Clientess clientess)
        {
            if (id != clientess.IdentificadorClientess)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientessExists(clientess.IdentificadorClientess))
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
            return View(clientess);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientesses == null)
            {
                return NotFound();
            }

            var clientess = await _context.Clientesses
                .FirstOrDefaultAsync(m => m.IdentificadorClientess == id);
            if (clientess == null)
            {
                return NotFound();
            }

            return View(clientess);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientesses == null)
            {
                return Problem("Entity set 'CxcContext.Clientesses'  is null.");
            }
            var clientess = await _context.Clientesses.FindAsync(id);
            if (clientess != null)
            {
                _context.Clientesses.Remove(clientess);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientessExists(int id)
        {
          return (_context.Clientesses?.Any(e => e.IdentificadorClientess == id)).GetValueOrDefault();
        }
    }
}
