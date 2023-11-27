using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManager.Data;
using HotelManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelManager.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reserva.Include(r => r.EncabezadoFactura).Include(r => r.Habitacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.EncabezadoFactura)
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(m => m.IDReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["IDFactura"] = new SelectList(_context.EncabezadoFactura, "IDFactura", "IDFactura");
            ViewData["IDHabitacion"] = new SelectList(_context.Habitacion, "IDHabitacion", "IDHabitacion");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDReserva,IDUsuario,IDHabitacion,IDFactura,FechaCheckin,FechaCheckOut,EstadoReserva")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.IDReserva = Guid.NewGuid();
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFactura"] = new SelectList(_context.EncabezadoFactura, "IDFactura", "IDFactura", reserva.IDFactura);
            ViewData["IDHabitacion"] = new SelectList(_context.Habitacion, "IDHabitacion", "IDHabitacion", reserva.IDHabitacion);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["IDFactura"] = new SelectList(_context.EncabezadoFactura, "IDFactura", "IDFactura", reserva.IDFactura);
            ViewData["IDHabitacion"] = new SelectList(_context.Habitacion, "IDHabitacion", "IDHabitacion", reserva.IDHabitacion);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDReserva,IDUsuario,IDHabitacion,IDFactura,FechaCheckin,FechaCheckOut,EstadoReserva")] Reserva reserva)
        {
            if (id != reserva.IDReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IDReserva))
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
            ViewData["IDFactura"] = new SelectList(_context.EncabezadoFactura, "IDFactura", "IDFactura", reserva.IDFactura);
            ViewData["IDHabitacion"] = new SelectList(_context.Habitacion, "IDHabitacion", "IDHabitacion", reserva.IDHabitacion);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.EncabezadoFactura)
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(m => m.IDReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Reserva == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reserva'  is null.");
            }
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(Guid id)
        {
            return (_context.Reserva?.Any(e => e.IDReserva == id)).GetValueOrDefault();
        }
    }
}
