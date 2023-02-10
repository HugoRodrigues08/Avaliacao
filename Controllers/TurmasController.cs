using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using escola.Data;
using escola.Models;

namespace escola.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Turmas.ToListAsync());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Materia,Professor")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas == null)
            {
                return NotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Materia,Professor")] Turmas turmas)
        {
            if (id != turmas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmasExists(turmas.Id))
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
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Turmas == null)
            {
                return NotFound();
            }

            var turmas = await _context.Turmas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmas == null)
            {
                return NotFound();
            }

            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Turmas'  is null.");
            }
            var turmas = await _context.Turmas.FindAsync(id);
            if (turmas != null)
            {
                _context.Turmas.Remove(turmas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmasExists(int id)
        {
          return _context.Turmas.Any(e => e.Id == id);
        }
    }
}
