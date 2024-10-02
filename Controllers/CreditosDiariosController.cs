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
    public class CreditosDiariosController : Controller
    {
        private readonly CantinaContext _context;

        public CreditosDiariosController(CantinaContext context)
        {
            _context = context;
        }

        // GET: CreditosDiarios
        public async Task<IActionResult> Index()
        {
            var cantinaContext = _context.CreditosDiarios.Include(c => c.IdUsuarioNavigation);
            return View(await cantinaContext.ToListAsync());
        }

        // GET: CreditosDiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditosDiario = await _context.CreditosDiarios
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCredito == id);
            if (creditosDiario == null)
            {
                return NotFound();
            }

            return View(creditosDiario);
        }

        // GET: CreditosDiarios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: CreditosDiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCredito,IdUsuario,Fecha,CreditosAsignados,CreditosConsumidos")] CreditosDiario creditosDiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditosDiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", creditosDiario.IdUsuario);
            return View(creditosDiario);
        }

        // GET: CreditosDiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditosDiario = await _context.CreditosDiarios.FindAsync(id);
            if (creditosDiario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", creditosDiario.IdUsuario);
            return View(creditosDiario);
        }

        // POST: CreditosDiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCredito,IdUsuario,Fecha,CreditosAsignados,CreditosConsumidos")] CreditosDiario creditosDiario)
        {
            if (id != creditosDiario.IdCredito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditosDiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditosDiarioExists(creditosDiario.IdCredito))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", creditosDiario.IdUsuario);
            return View(creditosDiario);
        }

        // GET: CreditosDiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditosDiario = await _context.CreditosDiarios
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCredito == id);
            if (creditosDiario == null)
            {
                return NotFound();
            }

            return View(creditosDiario);
        }

        // POST: CreditosDiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditosDiario = await _context.CreditosDiarios.FindAsync(id);
            if (creditosDiario != null)
            {
                _context.CreditosDiarios.Remove(creditosDiario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditosDiarioExists(int id)
        {
            return _context.CreditosDiarios.Any(e => e.IdCredito == id);
        }
    }
}
