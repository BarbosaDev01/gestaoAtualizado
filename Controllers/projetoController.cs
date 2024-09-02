using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class projetoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public projetoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: projeto
        public async Task<IActionResult> Index()
        {
              return _context.projeto != null ? 
                          View(await _context.projeto.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.projeto'  is null.");
        }

        // GET: projeto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.projeto
                .FirstOrDefaultAsync(m => m.IdProjeto == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: projeto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: projeto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProjeto,NomeProjeto,DataInicioProjeto,DataFinalProjeto,Casa,valorEstimado,AnoAprovacao,NumeroAprovacao,situacao,IdUsuario")] projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: projeto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: projeto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProjeto,NomeProjeto,DataInicioProjeto,DataFinalProjeto,Casa,valorEstimado,AnoAprovacao,NumeroAprovacao,situacao,IdUsuario")] projeto projeto)
        {
            if (id != projeto.IdProjeto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!projetoExists(projeto.IdProjeto))
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
            return View(projeto);
        }

        // GET: projeto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.projeto
                .FirstOrDefaultAsync(m => m.IdProjeto == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.projeto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.projeto'  is null.");
            }
            var projeto = await _context.projeto.FindAsync(id);
            if (projeto != null)
            {
                _context.projeto.Remove(projeto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool projetoExists(int id)
        {
          return (_context.projeto?.Any(e => e.IdProjeto == id)).GetValueOrDefault();
        }
    }
}
