﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prototipo2.Models;

namespace prototipo2.Controllers
{
    public class Menus1Controller : Controller
    {
        private readonly CantinaContext _context;

        public Menus1Controller(CantinaContext context)
        {
            _context = context;
        }

        // GET: Menus1
        public async Task<IActionResult> Index()
        {
            var cantinaContext = _context.Menus.Include(m => m.IdTipoConsumoNavigation);
            return View(await cantinaContext.ToListAsync());
        }

        // GET: Menus1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdMenu == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus1/Create
        public IActionResult Create()
        {
            ViewData["IdTipoConsumo"] = new SelectList(_context.TiposConsumos, "IdTipoConsumo", "IdTipoConsumo");
            return View();
        }

        // POST: Menus1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMenu,IdTipoConsumo,NombreMenu,Descripcion,CostoExtra,CantidadDisponible,Fecha")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoConsumo"] = new SelectList(_context.TiposConsumos, "IdTipoConsumo", "IdTipoConsumo", menu.IdTipoConsumo);
            return View(menu);
        }

        // GET: Menus1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["IdTipoConsumo"] = new SelectList(_context.TiposConsumos, "IdTipoConsumo", "IdTipoConsumo", menu.IdTipoConsumo);
            return View(menu);
        }

        // POST: Menus1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMenu,IdTipoConsumo,NombreMenu,Descripcion,CostoExtra,CantidadDisponible,Fecha")] Menu menu)
        {
            if (id != menu.IdMenu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.IdMenu))
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
            ViewData["IdTipoConsumo"] = new SelectList(_context.TiposConsumos, "IdTipoConsumo", "IdTipoConsumo", menu.IdTipoConsumo);
            return View(menu);
        }

        // GET: Menus1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .Include(m => m.IdTipoConsumoNavigation)
                .FirstOrDefaultAsync(m => m.IdMenu == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.IdMenu == id);
        }
    }
}
