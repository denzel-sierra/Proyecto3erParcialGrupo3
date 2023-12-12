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
using Microsoft.AspNetCore.Authorization;

namespace HotelManager.Controllers
{
    [Authorize]
    public class EncabezadoFacturasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public EncabezadoFacturasController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: EncabezadoFacturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EncabezadoFactura.Include(e => e.ApplicationUser).Include(e => e.Reserva).Where(e => !e.Eliminada);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EncabezadoFacturas/Details/5
        public async Task<IActionResult> Details(Guid? idReserva)
        {
            if (idReserva == null)
            {
                return NotFound();
            }

            // Buscar la factura que corresponde al IDReserva proporcionado
            var encabezadoFactura = await _context.EncabezadoFactura
                .Include(e => e.ApplicationUser)
                .Include(e => e.Reserva)
                .FirstOrDefaultAsync(m => m.Reserva.IDReserva == idReserva);

            if (encabezadoFactura == null)
            {
                return NotFound();
            }

            return View(encabezadoFactura);
        }

        // GET: EncabezadoFacturas/Create
        public IActionResult Create(string idReserva)
        {
            ViewData["IDReserva"] = idReserva;

            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: EncabezadoFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFactura,IDCorrelativoSAR,IDReserva,IDUsuario,NumeroFacturaSAR,FechaFactura,SubTotalFactura,DescuentoFactura,ImpuestoFactura,TotalFactura,Eliminada")] EncabezadoFactura encabezadoFactura)
        {
            var reserva = _context.Reserva.Include(r => r.Habitacion).FirstOrDefault(r => r.IDReserva == encabezadoFactura.IDReserva);
            var correlativo = ObtenerCorrelativo(encabezadoFactura.IDCorrelativoSAR);

            // Guardar la factura
            encabezadoFactura.IDFactura = Guid.NewGuid();
            encabezadoFactura.FechaFactura = DateTime.Now;

            // Obtener el usuario autenticado
            var usuarioAutenticado = await _userManager.GetUserAsync(User);

            // Si el usuario autenticado no tiene el rol de cliente, asignar IDEmpleado como el ID del usuario autenticado
            if (!await _userManager.IsInRoleAsync(usuarioAutenticado, "Cliente"))
            {
                encabezadoFactura.IDEmpleado = usuarioAutenticado.Id;
            }

            _context.Add(encabezadoFactura);

            reserva.Habitacion.Disponibilidad = false;

            await _context.SaveChangesAsync();

            // Llamar a la acción para actualizar UltimoUtilizado
            await UpdateUltimoUtilizado(encabezadoFactura.IDCorrelativoSAR, encabezadoFactura.NumeroFacturaSAR);

            return RedirectToAction(nameof(Index));

        }

        // GET: EncabezadoFacturas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EncabezadoFactura == null)
            {
                return NotFound();
            }

            var encabezadoFactura = await _context.EncabezadoFactura.FindAsync(id);
            if (encabezadoFactura == null)
            {
                return NotFound();
            }
            ViewData["IDReserva"] = encabezadoFactura.IDReserva;
            return View(encabezadoFactura);
        }

        // POST: EncabezadoFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDFactura,IDCorrelativoSAR,IDReserva,IDEmpleado,IDUsuario,NumeroFacturaSAR,FechaFactura,SubTotalFactura,DescuentoFactura,ImpuestoFactura,TotalFactura,Eliminada")] EncabezadoFactura encabezadoFactura)
        {
            if (id != encabezadoFactura.IDFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encabezadoFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncabezadoFacturaExists(encabezadoFactura.IDFactura))
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
            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id", encabezadoFactura.IDUsuario);
            ViewData["IDReserva"] = new SelectList(_context.Reserva, "IDReserva", "IDUsuario", encabezadoFactura.IDReserva);
            return View(encabezadoFactura);
        }

        // GET: EncabezadoFacturas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EncabezadoFactura == null)
            {
                return NotFound();
            }

            var encabezadoFactura = await _context.EncabezadoFactura
                .Include(e => e.ApplicationUser)
                .Include(e => e.Reserva)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (encabezadoFactura == null)
            {
                return NotFound();
            }

            return View(encabezadoFactura);
        }

        // POST: EncabezadoFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            var encabezadoFactura = await _context.EncabezadoFactura.FindAsync(id);

            encabezadoFactura.Eliminada = true;

            _context.Add(encabezadoFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncabezadoFacturaExists(Guid id)
        {
          return (_context.EncabezadoFactura?.Any(e => e.IDFactura == id)).GetValueOrDefault();
        }

        // GET: EncabezadoFacturas/GetCorrelativoNoFinalizado
        [HttpGet]
        public IActionResult GetCorrelativoNoFinalizado()
        {
            var correlativoNoFinalizado = _context.CorrelativoSAR
                .FirstOrDefault(c => !c.Finalizado);

            return Json(new { IDCorrelativoSAR = correlativoNoFinalizado?.IDCorrelativoSAR });
        }

        [HttpGet]
        public IActionResult GetReservaDetails(Guid idReserva)
        {
            var reserva = _context.Reserva.FirstOrDefault(r => r.IDReserva == idReserva);

            if (reserva == null)
            {
                // Manejar el caso donde no se encuentra la reserva
                return Json(null);
            }

            // Retorna un JSON con todos los datos de la reserva
            return Json(reserva);
        }

        [HttpGet]
        public IActionResult ObtenerHabitacion(Guid idHabitacion)
        {
            var habitacion = _context.Habitacion.FirstOrDefault(h => h.IDHabitacion == idHabitacion);

            if (habitacion == null)
            {
                return Json(null);
            }

            return Json(habitacion);
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

        public IActionResult ObtenerCorrelativo(Guid idCorrelativo)
        {
            var correlativo = _context.CorrelativoSAR.FirstOrDefault(c => c.IDCorrelativoSAR == idCorrelativo);

            if (correlativo == null)
            {
                return Json(null);
            }

            return Json(correlativo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUltimoUtilizado(Guid? correlativoId, int nuevoNumero)
        {
            var correlativo = await _context.CorrelativoSAR.FindAsync(correlativoId);

            if (correlativo != null)
            {
                correlativo.ActualizarUltimoUtilizado(nuevoNumero);
                await _context.SaveChangesAsync();
            }

            // Puedes redirigir a donde desees después de la actualización
            return RedirectToAction(nameof(Index));
        }
    }
}