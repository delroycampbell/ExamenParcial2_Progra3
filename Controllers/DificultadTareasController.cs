using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenParcial2_Progra3.Data;
using ExamenParcial2_Progra3.Models;

namespace ExamenParcial2_Progra3.Controllers
{
    public class DificultadTareasController : Controller
    {
        private readonly AppDbContext _context;

        public DificultadTareasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DificultadTareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dificultad.ToListAsync());
        }

        // GET: DificultadTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificultad = await _context.Dificultad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dificultad == null)
            {
                return NotFound();
            }

            return View(dificultad);
        }

        // GET: DificultadTareas/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: DificultadTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Dificultad dificultad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dificultad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dificultad);
        }

        // GET: DificultadTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificultad = await _context.Dificultad.FindAsync(id);
            if (dificultad == null)
            {
                return NotFound();
            }
            return View(dificultad);
        }

        // POST: DificultadTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Dificultad dificultad)
        {
            if (id != dificultad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dificultad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DificultadExists(dificultad.Id))
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
            return View(dificultad);
        }

        // GET: DificultadTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificultad = await _context.Dificultad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dificultad == null)
            {
                return NotFound();
            }

            return View(dificultad);
        }

        // POST: DificultadTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dificultad = await _context.Dificultad.FindAsync(id);
            if (dificultad != null)
            {
                _context.Dificultad.Remove(dificultad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DificultadExists(int id)
        {
            return _context.Dificultad.Any(e => e.Id == id);
        }
    }
}
