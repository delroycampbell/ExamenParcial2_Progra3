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
    public class PrioridadMetasController : Controller
    {
        private readonly AppDbContext _context;

        public PrioridadMetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PrioridadMetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrioridadMeta.ToListAsync());
        }

        // GET: PrioridadMetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridadMeta = await _context.PrioridadMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prioridadMeta == null)
            {
                return NotFound();
            }

            return View(prioridadMeta);
        }

        // GET: PrioridadMetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrioridadMetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] PrioridadMeta prioridadMeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prioridadMeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridadMeta);
        }

        // GET: PrioridadMetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridadMeta = await _context.PrioridadMeta.FindAsync(id);
            if (prioridadMeta == null)
            {
                return NotFound();
            }
            return View(prioridadMeta);
        }

        // POST: PrioridadMetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] PrioridadMeta prioridadMeta)
        {
            if (id != prioridadMeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prioridadMeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioridadMetaExists(prioridadMeta.Id))
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
            return View(prioridadMeta);
        }

        // GET: PrioridadMetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridadMeta = await _context.PrioridadMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prioridadMeta == null)
            {
                return NotFound();
            }

            return View(prioridadMeta);
        }

        // POST: PrioridadMetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prioridadMeta = await _context.PrioridadMeta.FindAsync(id);
            if (prioridadMeta != null)
            {
                _context.PrioridadMeta.Remove(prioridadMeta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioridadMetaExists(int id)
        {
            return _context.PrioridadMeta.Any(e => e.Id == id);
        }
    }
}
