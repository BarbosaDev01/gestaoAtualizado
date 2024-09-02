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
    public class acaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public acaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: acao
        public async Task<IActionResult> Index()
        {
              return _context.acao != null ? 
                          View(await _context.acao.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.acao'  is null.");
        }

        // GET: acao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.acao == null)
            {
                return NotFound();
            }

            var acao = await _context.acao
                .FirstOrDefaultAsync(m => m.IdAcao == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // GET: acao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: acao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAcao,selecionarProjeto,adicionarAcao,dataHora,statusAcao,emailUsuario,IdProjeto")] acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acao);
        }

        // GET: acao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.acao == null)
            {
                return NotFound();
            }

            var acao = await _context.acao.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }
            return View(acao);
        }

        // POST: acao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAcao,selecionarProjeto,adicionarAcao,dataHora,statusAcao,emailUsuario,IdProjeto")] acao acao)
        {
            if (id != acao.IdAcao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!acaoExists(acao.IdAcao))
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
            return View(acao);
        }

        // GET: acao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.acao == null)
            {
                return NotFound();
            }

            var acao = await _context.acao
                .FirstOrDefaultAsync(m => m.IdAcao == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // POST: acao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.acao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.acao'  is null.");
            }
            var acao = await _context.acao.FindAsync(id);
            if (acao != null)
            {
                _context.acao.Remove(acao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool acaoExists(int id)
        {
          return (_context.acao?.Any(e => e.IdAcao == id)).GetValueOrDefault();
        }
    }
}
