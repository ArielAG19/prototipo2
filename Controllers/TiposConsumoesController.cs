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
    public class TiposConsumoesController : Controller
    {
        private readonly CantinaContext _context;

        public TiposConsumoesController(CantinaContext context)
        {
            _context = context;
        }

        // GET: TiposConsumoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposConsumos.ToListAsync());
        }

        // GET: TiposConsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos
                .FirstOrDefaultAsync(m => m.IdTipoConsumo == id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }

            return View(tiposConsumo);
        }

        // GET: TiposConsumoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposConsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoConsumo,Tipo,CreditosNecesarios,RequiereReserva,HoraInicio,HoraFin")] TiposConsumo tiposConsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposConsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposConsumo);
        }

        // GET: TiposConsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos.FindAsync(id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }
            return View(tiposConsumo);
        }

        // POST: TiposConsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoConsumo,Tipo,CreditosNecesarios,RequiereReserva,HoraInicio,HoraFin")] TiposConsumo tiposConsumo)
        {
            if (id != tiposConsumo.IdTipoConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposConsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposConsumoExists(tiposConsumo.IdTipoConsumo))
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
            return View(tiposConsumo);
        }

        // GET: TiposConsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos
                .FirstOrDefaultAsync(m => m.IdTipoConsumo == id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }

            return View(tiposConsumo);
        }

        // POST: TiposConsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposConsumo = await _context.TiposConsumos.FindAsync(id);
            if (tiposConsumo != null)
            {
                _context.TiposConsumos.Remove(tiposConsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposConsumoExists(int id)
        {
            return _context.TiposConsumos.Any(e => e.IdTipoConsumo == id);
        }
    }
}
