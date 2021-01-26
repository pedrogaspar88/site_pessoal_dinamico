using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using site_pessoal_dinamico.Data;
using site_pessoal_dinamico.Models;

namespace site_pessoal_dinamico.Controllers
{
    public class distincao_premiosController : Controller
    {
        private readonly SitePessoalBdContext _context;

        public distincao_premiosController(SitePessoalBdContext context)
        {
            _context = context;
        }

        // GET: distincao_premios
        public async Task<IActionResult> Index()
        {
            return View(await _context.distincao_premios.ToListAsync());
        }

        // GET: distincao_premios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distincao_premios = await _context.distincao_premios
                .FirstOrDefaultAsync(m => m.distincao_premiosId == id);
            if (distincao_premios == null)
            {
                return NotFound();
            }

            return View(distincao_premios);
        }

        // GET: distincao_premios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: distincao_premios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("distincao_premiosId,descricao_distincao")] distincao_premios distincao_premios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distincao_premios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distincao_premios);
        }

        // GET: distincao_premios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distincao_premios = await _context.distincao_premios.FindAsync(id);
            if (distincao_premios == null)
            {
                return NotFound();
            }
            return View(distincao_premios);
        }

        // POST: distincao_premios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("distincao_premiosId,descricao_distincao")] distincao_premios distincao_premios)
        {
            if (id != distincao_premios.distincao_premiosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distincao_premios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!distincao_premiosExists(distincao_premios.distincao_premiosId))
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
            return View(distincao_premios);
        }

        // GET: distincao_premios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distincao_premios = await _context.distincao_premios
                .FirstOrDefaultAsync(m => m.distincao_premiosId == id);
            if (distincao_premios == null)
            {
                return NotFound();
            }

            return View(distincao_premios);
        }

        // POST: distincao_premios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distincao_premios = await _context.distincao_premios.FindAsync(id);
            _context.distincao_premios.Remove(distincao_premios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool distincao_premiosExists(int id)
        {
            return _context.distincao_premios.Any(e => e.distincao_premiosId == id);
        }
    }
}
