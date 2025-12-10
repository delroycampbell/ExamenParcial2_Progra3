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
    public class TareasController : Controller
        {
        private readonly AppDbContext _context;

        public TareasController(AppDbContext context)
            {
            _context = context;
            }

        // GET: Tareas
        public async Task<IActionResult> Index()
            {
            var appDbContext = _context.Tarea.Include(t => t.Estado)
                .Include(t => t.Meta)
                .Include(t => t.Dificultad);
            return View(await appDbContext.ToListAsync());
            }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var tarea = await _context.Tarea
                .Include(t => t.Estado)
                .Include(t => t.Meta)
                .Include(t => t.Dificultad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
                {
                return NotFound();
                }

            return View(tarea);
            }

        // GET: Tareas/Create
        public IActionResult Create()
            {
            ViewData["EstadoTareaId"] = new SelectList(_context.Set<EstadoTarea>(), "Id", "Nombre");
            ViewData["MetaId"] = new SelectList(_context.Meta, "Id", "Titulo");
            ViewData["DificultadId"] = new SelectList(_context.Dificultad, "Id", "Nombre");
            return View();
            }

        // POST: Tareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,FechaCreacion,FechaLimite,DificultadId,TiempoEstimadoHoras,EstadoTareaId,MetaId")] Tarea tarea)
            {
            // Validar que la fechaLimite no sea menor a la fecha actual
            if (tarea.FechaLimite.HasValue && tarea.FechaLimite < tarea.FechaCreacion)
                {
                ModelState.AddModelError("FechaLimite", "La fecha limite debe ser mayor a la fecha actual");
                }


            try
                {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            catch (Exception e)
                {
                ViewData["EstadoTareaId"] = new SelectList(_context.Set<EstadoTarea>(), "Id", "Nombre", tarea.EstadoTareaId);
                ViewData["MetaId"] = new SelectList(_context.Meta, "Id", "Titulo", tarea.MetaId);
                ViewData["DificultadId"] = new SelectList(_context.Dificultad, "Id", "Nombre", tarea.DificultadId);
                return View(tarea);
                }

            }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
                {
                return NotFound();
                }
            ViewData["EstadoTareaId"] = new SelectList(_context.Set<EstadoTarea>(), "Id", "Nombre", tarea.EstadoTareaId);
            ViewData["MetaId"] = new SelectList(_context.Meta, "Id", "Titulo", tarea.MetaId);
            ViewData["DificultadId"] = new SelectList(_context.Dificultad, "Id", "Nombre", tarea.DificultadId);

            return View(tarea);
            }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FechaCreacion,FechaLimite,DificultadId,TiempoEstimadoHoras,EstadoTareaId,MetaId")] Tarea tarea)
            {
            if (id != tarea.Id)
                {
                return NotFound();
                }

            //Validar fechaLimite no sea menor a la fechacreacion

            if (tarea.FechaLimite.HasValue && tarea.FechaLimite < tarea.FechaCreacion)
                {
                ModelState.AddModelError("FechaLimite", "La fecha limite no puede ser menor a la fecha de creacion");
                }

            try
                {
                _context.Update(tarea);
                await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!TareaExists(tarea.Id))
                    {
                    return NotFound();
                    }
                else
                    {
                    throw;
                    }
                }
            return RedirectToAction(nameof(Index));

            ViewData["EstadoTareaId"] = new SelectList(_context.Set<EstadoTarea>(), "Id", "Nombre", tarea.EstadoTareaId);
            ViewData["MetaId"] = new SelectList(_context.Meta, "Id", "Titulo", tarea.MetaId);
            ViewData["DificultadId"] = new SelectList(_context.Dificultad, "Id", "Nombre", tarea.DificultadId);
            return View(tarea);
            }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var tarea = await _context.Tarea
                .Include(t => t.Estado)
                .Include(t => t.Meta)
                .Include(t => t.Dificultad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarea == null)
                {
                return NotFound();
                }

            return View(tarea);
            }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea != null)
                {
                _context.Tarea.Remove(tarea);
                }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }

        private bool TareaExists(int id)
            {
            return _context.Tarea.Any(e => e.Id == id);
            }
        }
    }
