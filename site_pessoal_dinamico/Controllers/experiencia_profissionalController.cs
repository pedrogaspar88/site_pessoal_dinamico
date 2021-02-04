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
    
    public class experiencia_profissionalController : Controller
    {
        private readonly SitePessoalBdContext _context;

        public experiencia_profissionalController(SitePessoalBdContext context)
        {
            _context = context;
        }

        // GET: experiencia_profissional
        public async Task<IActionResult> Index()
        {
            return View(await _context.experiencia_profissional.ToListAsync());
        }

        // GET: experiencia_profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_profissional = await _context.experiencia_profissional
                .FirstOrDefaultAsync(m => m.experiencia_profissionalId == id);
            if (experiencia_profissional == null)
            {
                return NotFound();
            }

            return View(experiencia_profissional);
        }

        // GET: experiencia_profissional/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: experiencia_profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("experiencia_profissionalId,funcao,empresa,descricao_exp,dataInicio,dataFim")] experiencia_profissional experiencia_profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencia_profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencia_profissional);
        }

        // GET: experiencia_profissional/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_profissional = await _context.experiencia_profissional.FindAsync(id);
            if (experiencia_profissional == null)
            {
                return NotFound();
            }
            return View(experiencia_profissional);
        }

        // POST: experiencia_profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("experiencia_profissionalId,funcao,empresa,descricao_exp,dataInicio,dataFim")] experiencia_profissional experiencia_profissional)
        {
            if (id != experiencia_profissional.experiencia_profissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencia_profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!experiencia_profissionalExists(experiencia_profissional.experiencia_profissionalId))
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
            return View(experiencia_profissional);
        }

        // GET: experiencia_profissional/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencia_profissional = await _context.experiencia_profissional
                .FirstOrDefaultAsync(m => m.experiencia_profissionalId == id);
            if (experiencia_profissional == null)
            {
                return NotFound();
            }

            return View(experiencia_profissional);
        }

        // POST: experiencia_profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencia_profissional = await _context.experiencia_profissional.FindAsync(id);
            _context.experiencia_profissional.Remove(experiencia_profissional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool experiencia_profissionalExists(int id)
        {
            return _context.experiencia_profissional.Any(e => e.experiencia_profissionalId == id);
        }
    }
}
