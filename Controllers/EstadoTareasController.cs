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
    public class EstadoTareasController : Controller
    {
        private readonly AppDbContext _context;

        public EstadoTareasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EstadoTareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoTarea.ToListAsync());
        }

        // GET: EstadoTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTarea = await _context.EstadoTarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTarea == null)
            {
                return NotFound();
            }

            return View(estadoTarea);
        }

        // GET: EstadoTareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadoTarea estadoTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoTarea);
        }

        // GET: EstadoTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTarea = await _context.EstadoTarea.FindAsync(id);
            if (estadoTarea == null)
            {
                return NotFound();
            }
            return View(estadoTarea);
        }

        // POST: EstadoTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadoTarea estadoTarea)
        {
            if (id != estadoTarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTareaExists(estadoTarea.Id))
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
            return View(estadoTarea);
        }

        // GET: EstadoTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTarea = await _context.EstadoTarea
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTarea == null)
            {
                return NotFound();
            }

            return View(estadoTarea);
        }

        // POST: EstadoTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTarea = await _context.EstadoTarea.FindAsync(id);
            if (estadoTarea != null)
            {
                _context.EstadoTarea.Remove(estadoTarea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTareaExists(int id)
        {
            return _context.EstadoTarea.Any(e => e.Id == id);
        }
    }
}
