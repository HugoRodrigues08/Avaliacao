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
    public class ProfessoresCandidatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessoresCandidatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfessoresCandidatos
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProfessoresCandidatos.ToListAsync());
        }

        // GET: ProfessoresCandidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessoresCandidatos == null)
            {
                return NotFound();
            }

            var professoresCandidatos = await _context.ProfessoresCandidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professoresCandidatos == null)
            {
                return NotFound();
            }

            return View(professoresCandidatos);
        }

        // GET: ProfessoresCandidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessoresCandidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,DataNascimento,Telefone,Email,Linkedin")] ProfessoresCandidatos professoresCandidatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professoresCandidatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professoresCandidatos);
        }

        // GET: ProfessoresCandidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessoresCandidatos == null)
            {
                return NotFound();
            }

            var professoresCandidatos = await _context.ProfessoresCandidatos.FindAsync(id);
            if (professoresCandidatos == null)
            {
                return NotFound();
            }
            return View(professoresCandidatos);
        }

        // POST: ProfessoresCandidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,DataNascimento,Telefone,Email,Linkedin")] ProfessoresCandidatos professoresCandidatos)
        {
            if (id != professoresCandidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professoresCandidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessoresCandidatosExists(professoresCandidatos.Id))
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
            return View(professoresCandidatos);
        }

        // GET: ProfessoresCandidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessoresCandidatos == null)
            {
                return NotFound();
            }

            var professoresCandidatos = await _context.ProfessoresCandidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professoresCandidatos == null)
            {
                return NotFound();
            }

            return View(professoresCandidatos);
        }

        // POST: ProfessoresCandidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessoresCandidatos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfessoresCandidatos'  is null.");
            }
            var professoresCandidatos = await _context.ProfessoresCandidatos.FindAsync(id);
            if (professoresCandidatos != null)
            {
                _context.ProfessoresCandidatos.Remove(professoresCandidatos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessoresCandidatosExists(int id)
        {
          return _context.ProfessoresCandidatos.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Cadastrado()
        {
            return View();
        }
    }
}
