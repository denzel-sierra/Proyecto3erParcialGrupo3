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
            var applicationDbContext = _context.Habitacion.Include(h => h.TipoHabitacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Habitaciones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Habitacion == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.IDHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitaciones/Create
        [Authorize(Roles = "Admin,Empleado" )]
        public IActionResult Create()
        {
            ViewData["IDTipoHabitacion"] = new SelectList(_context.TipoHabitacion, "IDTipoHabitacion", "Descripcion");
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDHabitacion,Numero,IDTipoHabitacion,Tarifa,Disponibilidad")] Habitacion habitacion)
        {
            
                habitacion.IDHabitacion = Guid.NewGuid();
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IDTipoHabitacion"] = new SelectList(_context.TipoHabitacion, "IDTipoHabitacion", "IDTipoHabitacion", habitacion.IDTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitaciones/Edit/5
        [Authorize(Roles = "Admin,Empleado")]
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

            // Obtén las descripciones en lugar de los IDs para cargar en la vista
            var tipoHabitacionList = _context.TipoHabitacion.Select(th => new SelectListItem
            {
                Value = th.IDTipoHabitacion.ToString(),
                Text = th.Descripcion
            });

            ViewData["IDTipoHabitacion"] = new SelectList(tipoHabitacionList, "Value", "Text", habitacion.IDTipoHabitacion);

            return View(habitacion);
        }


        [Authorize(Roles = "Admin,Empleado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDHabitacion,Numero,IDTipoHabitacion,Tarifa,Disponibilidad")] Habitacion habitacion)
        {
            if (id != habitacion.IDHabitacion)
            {
                return NotFound();
            }

            
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
            
            ViewData["IDTipoHabitacion"] = new SelectList(_context.TipoHabitacion, "IDTipoHabitacion", "IDTipoHabitacion", habitacion.IDTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitaciones/Delete/5
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Habitacion == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.IDHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitaciones/Delete/5
        [Authorize(Roles = "Admin,Empleado")]
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
        public IActionResult Reservar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .FirstOrDefault(m => m.IDHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            // Aquí puedes implementar la lógica de reserva según tus requisitos.
            // Puedes pasar el objeto habitacion o cualquier información adicional a la vista Reservar.cshtml.

            return RedirectToAction("Create", "Reservas", new { idHabitacion = id });
        }
    }
}
