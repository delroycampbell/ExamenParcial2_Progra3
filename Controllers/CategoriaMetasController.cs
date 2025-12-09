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
    public class CategoriaMetasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaMetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaMetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaMeta.ToListAsync());
        }

        // GET: CategoriaMetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMeta = await _context.CategoriaMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaMeta == null)
            {
                return NotFound();
            }

            return View(categoriaMeta);
        }

        // GET: CategoriaMetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaMetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] CategoriaMeta categoriaMeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaMeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaMeta);
        }

        // GET: CategoriaMetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMeta = await _context.CategoriaMeta.FindAsync(id);
            if (categoriaMeta == null)
            {
                return NotFound();
            }
            return View(categoriaMeta);
        }

        // POST: CategoriaMetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CategoriaMeta categoriaMeta)
        {
            if (id != categoriaMeta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaMeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaMetaExists(categoriaMeta.Id))
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
            return View(categoriaMeta);
        }

        // GET: CategoriaMetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMeta = await _context.CategoriaMeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaMeta == null)
            {
                return NotFound();
            }

            return View(categoriaMeta);
        }

        // POST: CategoriaMetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaMeta = await _context.CategoriaMeta.FindAsync(id);
            if (categoriaMeta != null)
            {
                _context.CategoriaMeta.Remove(categoriaMeta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaMetaExists(int id)
        {
            return _context.CategoriaMeta.Any(e => e.Id == id);
        }
    }
}
