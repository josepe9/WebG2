using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebG2.Web.Data;
using WebG2.Web.Models;

namespace WebG2.Web.Controllers
{
    public class HistoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Historias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Historias.Include(h => h.Animal).Include(h => h.Enfermedad).Include(h => h.Veterinario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Historias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias
                .Include(h => h.Animal)
                .Include(h => h.Enfermedad)
                .Include(h => h.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // GET: Historias/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Nombre");
            ViewData["EnfermedadId"] = new SelectList(_context.Enfermedades, "Id", "Nombre");
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Id");
            return View();
        }

        // POST: Historias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,AnimalId,EnfermedadId,VeterinarioId")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Nombre", historia.AnimalId);
            ViewData["EnfermedadId"] = new SelectList(_context.Enfermedades, "Id", "Nombre", historia.EnfermedadId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Id", historia.VeterinarioId);
            return View(historia);
        }

        // GET: Historias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Nombre", historia.AnimalId);
            ViewData["EnfermedadId"] = new SelectList(_context.Enfermedades, "Id", "Nombre", historia.EnfermedadId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Id", historia.VeterinarioId);
            return View(historia);
        }

        // POST: Historias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,AnimalId,EnfermedadId,VeterinarioId")] Historia historia)
        {
            if (id != historia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaExists(historia.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Nombre", historia.AnimalId);
            ViewData["EnfermedadId"] = new SelectList(_context.Enfermedades, "Id", "Nombre", historia.EnfermedadId);
            ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Id", historia.VeterinarioId);
            return View(historia);
        }

        // GET: Historias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historia = await _context.Historias
                .Include(h => h.Animal)
                .Include(h => h.Enfermedad)
                .Include(h => h.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // POST: Historias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historia = await _context.Historias.FindAsync(id);
            _context.Historias.Remove(historia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaExists(int id)
        {
            return _context.Historias.Any(e => e.Id == id);
        }
    }
}
