using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prototipo2.Models;

namespace prototipo2.Controllers
{
    public class ConsumoesController : Controller
    {
        private readonly CantinaContext _context;

        public ConsumoesController(CantinaContext context)
        {
            _context = context;
        }

        // GET: Consumoes
        public async Task<IActionResult> Index()
        {
            var cantinaContext = _context.Consumos.Include(c => c.IdMenuNavigation).Include(c => c.IdTurnoNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await cantinaContext.ToListAsync());
        }

        // GET: Consumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.IdMenuNavigation)
                .Include(c => c.IdTurnoNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumoes/Create
        public IActionResult Create()
        {
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu");
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Consumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsumo,IdUsuario,IdMenu,FechaConsumo,HoraConsumo,IdTurno,EmpleadoEntrega,MontoPagado")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", consumo.IdMenu);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", consumo.IdTurno);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", consumo.IdUsuario);
            return View(consumo);
        }

        // GET: Consumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", consumo.IdMenu);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", consumo.IdTurno);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", consumo.IdUsuario);
            return View(consumo);
        }

        // POST: Consumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsumo,IdUsuario,IdMenu,FechaConsumo,HoraConsumo,IdTurno,EmpleadoEntrega,MontoPagado")] Consumo consumo)
        {
            if (id != consumo.IdConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.IdConsumo))
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
            ViewData["IdMenu"] = new SelectList(_context.Menus, "IdMenu", "IdMenu", consumo.IdMenu);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", consumo.IdTurno);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", consumo.IdUsuario);
            return View(consumo);
        }

        // GET: Consumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.IdMenuNavigation)
                .Include(c => c.IdTurnoNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumos.Remove(consumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumos.Any(e => e.IdConsumo == id);
        }
    }
}
