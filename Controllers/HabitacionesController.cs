using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManager.Data;
using HotelManager.Models;

namespace HotelManager.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habitaciones
        public async Task<IActionResult> Index()
        {
              return _context.Habitacion != null ? 
                          View(await _context.Habitacion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Habitacion'  is null.");
        }

        // GET: Habitaciones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Habitacion == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .FirstOrDefaultAsync(m => m.IDHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDHabitacion,TipoHabitacion,Tarifa,Disponibilidad,Descripcion")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                habitacion.IDHabitacion = Guid.NewGuid();
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitacion);
        }

        // GET: Habitaciones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Habitacion == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDHabitacion,TipoHabitacion,Tarifa,Disponibilidad,Descripcion")] Habitacion habitacion)
        {
            if (id != habitacion.IDHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IDHabitacion))
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
            return View(habitacion);
        }

        // GET: Habitaciones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Habitacion == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .FirstOrDefaultAsync(m => m.IDHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Habitacion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitacion'  is null.");
            }
            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitacion.Remove(habitacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(Guid id)
        {
          return (_context.Habitacion?.Any(e => e.IDHabitacion == id)).GetValueOrDefault();
        }
    }
}
