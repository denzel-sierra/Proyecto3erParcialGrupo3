using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManager.Data;
using HotelManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelManager.Controllers
{
    public class CitasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CitasController(UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Citas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.Cita != null ? 
                          View(await _context.Cita.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cita'  is null.");
        }

        // GET: Citas/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .FirstOrDefaultAsync(m => m.IDCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCita,IDUsuario,IDEmpleado,FechaHoraCita")] Cita cita)
        {
            cita.IDCita = Guid.NewGuid();
            cita.IDUsuario = _userManager.GetUserId(User);
            cita.IDEmpleado = null;
            cita.EstadoCita = "Sin Confirmar";
            _context.Add(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Citas/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDCita,IDUsuario,IDEmpleado,FechaHoraCita,EstadoCita,TomadaPorEmpleado")] Cita cita)
        {
            cita.IDEmpleado = Guid.Parse(_userManager.GetUserId(User));
            cita.EstadoCita = "Confirmada";
            _context.Update(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Citas/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .FirstOrDefaultAsync(m => m.IDCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Cita == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cita'  is null.");
            }
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(Guid id)
        {
          return (_context.Cita?.Any(e => e.IDCita == id)).GetValueOrDefault();
        }

        public IActionResult ObtenerUsuario(string idUsuario)
        {
            var usuario = _context.ApplicationUser.FirstOrDefault(u => u.Id.Equals(idUsuario));

            if (usuario == null)
            {
                return Json(null);
            }

            return Json(usuario);
        }

        [HttpGet]
        public IActionResult ObtenerCitasPorUsuario()
        {
            var usuarioId = _userManager.GetUserId(User);
            var citas = _context.Cita
                .Where(c => c.IDUsuario.Equals(usuarioId))
                .ToList();

            return Json(citas);
        }

    }
}
