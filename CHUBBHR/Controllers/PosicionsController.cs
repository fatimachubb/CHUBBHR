using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHUBBHR.Models;

namespace CHUBBHR.Controllers
{
    public class PosicionsController : Controller
    {
        private readonly RegistroContext _context;

        public PosicionsController(RegistroContext context)
        {
            _context = context;
        }

        // GET: Posicions
      

        public async Task<IActionResult> Index()
        {
            if (_context.Posicions != null)
            {
                var posicions = await _context.Posicions.ToListAsync();
                return View(posicions);
            } else
            {
                // Manejar el caso cuando _context.Posicions es null
                // Por ejemplo, puedes redirigir a una vista de error o hacer algo más.
                return View("Error");
            }
           
        }

        // GET: Posicions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posicions == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicion == null)
            {
                return NotFound();
            }

            return View(posicion);
        }

        // GET: Posicions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posicions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Posicion1")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posicion);
        }

        // GET: Posicions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posicions == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicions.FindAsync(id);
            if (posicion == null)
            {
                return NotFound();
            }
            return View(posicion);
        }

        // POST: Posicions/Edit/5
        // |
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Posicion1")] Posicion posicion)
        {
            if (id != posicion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosicionExists(posicion.Id))
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
            return View(posicion);
        }

        // GET: Posicions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posicions == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicion == null)
            {
                return NotFound();
            }

            return View(posicion);
        }

        // POST: Posicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posicions == null)
            {
                return Problem("Entity set 'RegistroContext.Posicions'  is null.");
            }
            var posicion = await _context.Posicions.FindAsync(id);
            if (posicion != null)
            {
                _context.Posicions.Remove(posicion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosicionExists(int id)
        {
          return (_context.Posicions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
