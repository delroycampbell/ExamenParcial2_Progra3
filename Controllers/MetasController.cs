using ExamenParcial2_Progra3.Data;
using ExamenParcial2_Progra3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcial2_Progra3.Controllers
    {
    public class MetasController : Controller
        {
        private readonly AppDbContext _context;

        public MetasController(AppDbContext context)
            {
            _context = context;
            }

        // GET: Metas
        public async Task<IActionResult> Index()
            {
            var appDbContext = _context.Meta.Include(m => m.Categoria).Include(m => m.Estado).Include(m => m.Prioridad);
            return View(await appDbContext.ToListAsync());
            }

        // GET: Metas/Details/5
        public async Task<IActionResult> Details(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var meta = await _context.Meta
                .Include(m => m.Categoria)
                .Include(m => m.Estado)
                .Include(m => m.Prioridad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meta == null)
                {
                return NotFound();
                }

            return View(meta);
            }

        // GET: Metas/Create
        public IActionResult Create()
            {
            ViewData["CategoriaMetaId"] = new SelectList(_context.CategoriaMeta, "Id", "Nombre");
            ViewData["EstadoMetaId"] = new SelectList(_context.EstadoMeta, "Id", "Nombre");
            ViewData["PrioridadMetaId"] = new SelectList(_context.Set<PrioridadMeta>(), "Id", "Nombre");
            return View();
            }

        // POST: Metas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("Id,Titulo,Descripcion,FechaCreacion,FechaLimite,CategoriaMetaId,PrioridadMetaId,EstadoMetaId")]
    Meta meta)
            {
            // Validar título
            if (string.IsNullOrEmpty(meta.Titulo))
                {
                ModelState.AddModelError("Titulo", "El Titulo es obligatorio");
                CargarVistas(meta);
                return View(meta);
                }

            // Validar fecha límite
            if (meta.FechaLimite.HasValue && meta.FechaLimite < DateTime.Now)
                {
                ModelState.AddModelError("FechaLimite",
                    "La fecha limite debe ser mayor a la fecha actual");

                CargarVistas(meta);
                return View(meta);
                }

            try
                {
                // Guardar la meta
                _context.Add(meta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            catch (Exception ex)
                {
                ModelState.AddModelError(string.Empty,
                    "Ocurrió un error al crear la meta: " + ex.Message);

                CargarVistas(meta);
                return View(meta);
                }
            }



        // GET: Metas/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var meta = await _context.Meta.FindAsync(id);
            if (meta == null)
                {
                return NotFound();
                }
            ViewData["CategoriaMetaId"] = new SelectList(_context.CategoriaMeta, "Id", "Nombre", meta.CategoriaMetaId);
            ViewData["EstadoMetaId"] = new SelectList(_context.EstadoMeta, "Id", "Nombre", meta.EstadoMetaId);
            ViewData["PrioridadMetaId"] = new SelectList(_context.Set<PrioridadMeta>(), "Id", "Nombre", meta.PrioridadMetaId);
            return View(meta);
            }

        // POST: Metas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,FechaLimite,CategoriaMetaId,PrioridadMetaId,EstadoMetaId")] Meta meta)
            {
            if (id != meta.Id)
                {
                return NotFound();
                }
            //Cargar el valor de la fecha creacion que tenga la meta antes de editarla

            var metaOriginal = await _context.Meta.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (metaOriginal == null)
                {
                return NotFound();
                }

            if (meta.FechaLimite != metaOriginal.FechaLimite && meta.FechaLimite < DateTime.Now)
                {
                ModelState.AddModelError("FechaLimite", "La fecha limite debe ser mayor a la fecha actual");
                CargarVistas(meta);
                return View(meta);
                }

            try
                {
                _context.Update(meta);
                await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!MetaExists(meta.Id))
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

        // GET: Metas/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }

            var meta = await _context.Meta
                .Include(m => m.Categoria)
                .Include(m => m.Estado)
                .Include(m => m.Prioridad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meta == null)
                {
                return NotFound();
                }

            return View(meta);
            }

        // POST: Metas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
            var meta = await _context.Meta.FindAsync(id);
            if (meta != null)
                {
                _context.Meta.Remove(meta);
                }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }

        private bool MetaExists(int id)
            {
            return _context.Meta.Any(e => e.Id == id);
            }

        public void CargarVistas(Meta meta)
            {
            ViewData["CategoriaMetaId"] = new SelectList(_context.CategoriaMeta, "Id", "Nombre", meta.CategoriaMetaId);
            ViewData["PrioridadMetaId"] = new SelectList(_context.Set<PrioridadMeta>(), "Id", "Nombre", meta.PrioridadMetaId);
            ViewData["EstadoMetaId"] = new SelectList(_context.EstadoMeta, "Id", "Nombre", meta.EstadoMetaId);


            }
        }
    }
