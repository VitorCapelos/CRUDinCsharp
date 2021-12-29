#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Data;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly Contexto _context;

        public VisitantesController(Contexto context)
        {
            _context = context;
        }

        // GET: Visitantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visitantes.ToListAsync());
        }

        // GET: Visitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitantes == null)
            {
                return NotFound();
            }

            return View(visitantes);
        }

        // GET: Visitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Area,Responsavel")] Visitantes visitantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitantes);
        }

        // GET: Visitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes.FindAsync(id);
            if (visitantes == null)
            {
                return NotFound();
            }
            return View(visitantes);
        }

        // POST: Visitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Area,Responsavel")] Visitantes visitantes)
        {
            if (id != visitantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitantesExists(visitantes.Id))
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
            return View(visitantes);
        }

        // GET: Visitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitantes = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitantes == null)
            {
                return NotFound();
            }

            return View(visitantes);
        }

        // POST: Visitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitantes = await _context.Visitantes.FindAsync(id);
            _context.Visitantes.Remove(visitantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitantesExists(int id)
        {
            return _context.Visitantes.Any(e => e.Id == id);
        }
    }
}
