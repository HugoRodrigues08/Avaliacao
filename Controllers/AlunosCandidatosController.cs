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
    public class AlunosCandidatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosCandidatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlunosCandidatos
        public async Task<IActionResult> Index()
        {
              return View(await _context.AlunosCandidatos.ToListAsync());
        }

        // GET: AlunosCandidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunosCandidatos == null)
            {
                return NotFound();
            }

            var alunosCandidatos = await _context.AlunosCandidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunosCandidatos == null)
            {
                return NotFound();
            }

            return View(alunosCandidatos);
        }

        // GET: AlunosCandidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunosCandidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,DataNascimento,Telefone,Email")] AlunosCandidatos alunosCandidatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunosCandidatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunosCandidatos);
        }

        // GET: AlunosCandidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlunosCandidatos == null)
            {
                return NotFound();
            }

            var alunosCandidatos = await _context.AlunosCandidatos.FindAsync(id);
            if (alunosCandidatos == null)
            {
                return NotFound();
            }
            return View(alunosCandidatos);
        }

        // POST: AlunosCandidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,DataNascimento,Telefone,Email")] AlunosCandidatos alunosCandidatos)
        {
            if (id != alunosCandidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunosCandidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunosCandidatosExists(alunosCandidatos.Id))
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
            return View(alunosCandidatos);
        }

        // GET: AlunosCandidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunosCandidatos == null)
            {
                return NotFound();
            }

            var alunosCandidatos = await _context.AlunosCandidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunosCandidatos == null)
            {
                return NotFound();
            }

            return View(alunosCandidatos);
        }

        // POST: AlunosCandidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlunosCandidatos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlunosCandidatos'  is null.");
            }
            var alunosCandidatos = await _context.AlunosCandidatos.FindAsync(id);
            if (alunosCandidatos != null)
            {
                _context.AlunosCandidatos.Remove(alunosCandidatos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunosCandidatosExists(int id)
        {
          return _context.AlunosCandidatos.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Cadastrado()
        {
            return View();
        }
    }
}
