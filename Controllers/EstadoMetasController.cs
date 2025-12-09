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
    public class EstadoMetasController : Controller
    {
        private readonly AppDbContext _context;

        public EstadoMetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EstadoMetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoMeta.ToListAsync());
        }

        // GET: EstadoMetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMeta = await _context.EstadoMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMeta == null)
            {
                return NotFound();
            }

            return View(estadoMeta);
        }

        // GET: EstadoMetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoMetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadoMeta estadoMeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoMeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoMeta);
        }

        // GET: EstadoMetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMeta = await _context.EstadoMeta.FindAsync(id);
            if (estadoMeta == null)
            {
                return NotFound();
            }
            return View(estadoMeta);
        }

        // POST: EstadoMetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadoMeta estadoMeta)
        {
            if (id != estadoMeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoMeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoMetaExists(estadoMeta.Id))
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
            return View(estadoMeta);
        }

        // GET: EstadoMetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMeta = await _context.EstadoMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMeta == null)
            {
                return NotFound();
            }

            return View(estadoMeta);
        }

        // POST: EstadoMetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoMeta = await _context.EstadoMeta.FindAsync(id);
            if (estadoMeta != null)
            {
                _context.EstadoMeta.Remove(estadoMeta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoMetaExists(int id)
        {
            return _context.EstadoMeta.Any(e => e.Id == id);
        }
    }
}
