using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using site_pessoal_dinamico.Data;
using site_pessoal_dinamico.Models;
using Microsoft.AspNetCore.Authorization;

namespace site_pessoal_dinamico.Controllers
{
    [Authorize(Roles = "Administrador,Gestor")]
    public class outras_informacoesController : Controller
    {
        private readonly SitePessoalBdContext _context;

        public outras_informacoesController(SitePessoalBdContext context)
        {
            _context = context;
        }

        // GET: outras_informacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.outras_informacoes.ToListAsync());
        }

        // GET: outras_informacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outras_informacoes = await _context.outras_informacoes
                .FirstOrDefaultAsync(m => m.outras_informacoesId == id);
            if (outras_informacoes == null)
            {
                return NotFound();
            }

            return View(outras_informacoes);
        }

        // GET: outras_informacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: outras_informacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("outras_informacoesId,descricao_informacao")] outras_informacoes outras_informacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outras_informacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outras_informacoes);
        }

        // GET: outras_informacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outras_informacoes = await _context.outras_informacoes.FindAsync(id);
            if (outras_informacoes == null)
            {
                return NotFound();
            }
            return View(outras_informacoes);
        }

        // POST: outras_informacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("outras_informacoesId,descricao_informacao")] outras_informacoes outras_informacoes)
        {
            if (id != outras_informacoes.outras_informacoesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outras_informacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!outras_informacoesExists(outras_informacoes.outras_informacoesId))
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
            return View(outras_informacoes);
        }

        // GET: outras_informacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outras_informacoes = await _context.outras_informacoes
                .FirstOrDefaultAsync(m => m.outras_informacoesId == id);
            if (outras_informacoes == null)
            {
                return NotFound();
            }

            return View(outras_informacoes);
        }

        // POST: outras_informacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var outras_informacoes = await _context.outras_informacoes.FindAsync(id);
            _context.outras_informacoes.Remove(outras_informacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool outras_informacoesExists(int id)
        {
            return _context.outras_informacoes.Any(e => e.outras_informacoesId == id);
        }
    }
}
