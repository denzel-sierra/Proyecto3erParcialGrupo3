using HotelManager.Data;
using HotelManager.Models;
using HotelManager.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace HotelManager.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly ILogger<ReservasController> _logger;
        private ApplicationDbContext _dbContext;

        public ReservasController(ILogger<ReservasController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // Acción para mostrar la lista de reservas
        public IActionResult Index()
        {
            var reservas = _dbContext.Reserva.Include(r => r.Habitacion).ToList();
            var reservasViewModel = reservas.Select(r => new ReservasVM
            {
                IDReserva = r.IDReserva,
                IDUsuario = r.IDUsuario,
                IDHabitacion = r.IDHabitacion,
                IDFactura = r.IDFactura,
                FechaCheckin = r.FechaCheckin,
                FechaCheckOut = r.FechaCheckOut,
                EstadoReserva = r.EstadoReserva,
                Habitacion = new HabitacionesVM
                {
                    IDHabitacion = r.Habitacion.IDHabitacion,
                    Numero = r.Habitacion.Numero,
                    TipoHabitacion = r.Habitacion.TipoHabitacion,
                    Tarifa = r.Habitacion.Tarifa,
                    Descripcion = r.Habitacion.Descripcion,
                    Disponibilidad = r.Habitacion.Disponibilidad,
                }
                // Puedes mapear otros campos según sea necesario
            }).ToList();

            return View(reservasViewModel);
        }

        // Acción para mostrar el formulario de inserción de reserva
        [HttpGet]
        public IActionResult Insertar()
        {
            var reservaViewModel = new ReservasVM();
            ViewBag.Habitaciones = ObtenerHabitacionesSelectList();

            if (User.IsInRole("Empleado"))
            {
                reservaViewModel.IDUsuario = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
            else
            {
                reservaViewModel.IDUsuario = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }

            return View(reservaViewModel);
        }

        // Acción para procesar la inserción de reserva
        [HttpPost]
        public IActionResult Insertar(ReservasVM ReservasVM)
        {
            Debug.WriteLine("Ingresando a la acción Insertar");

            try
            {
                if (ModelState.IsValid)
                {
                    var reserva = new Reserva
                    {
                        IDReserva = Guid.NewGuid(),
                        IDUsuario = ReservasVM.IDUsuario,
                        IDHabitacion = ReservasVM.IDHabitacion,
                        IDFactura = Guid.NewGuid(), // Generar un nuevo ID de factura
                        FechaCheckin = ReservasVM.FechaCheckin,
                        FechaCheckOut = ReservasVM.FechaCheckin.AddDays(ReservasVM.CantidadDias), // Calcular la fecha de checkout
                        EstadoReserva = "Vigente", // Cambiar el estado de la reserva
                        // Asignar otros campos según sea necesario
                    };

                    _dbContext.Reserva.Add(reserva);

                    var saveResult = _dbContext.SaveChanges();
                    Debug.WriteLine($"Número de cambios guardados: {saveResult}");

                    if (saveResult > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se guardaron los cambios correctamente. Por favor, inténtelo de nuevo.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El modelo no es válido. Por favor, corrige los errores.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en la acción Insertar: {ex.ToString()}");
                _logger.LogError(ex, "Error al insertar la reserva.");
                ModelState.AddModelError(string.Empty, "Error al insertar la reserva. Por favor, inténtelo de nuevo.");
            }

            ViewBag.Habitaciones = ObtenerHabitacionesSelectList();
            return View(ReservasVM);
        }

        private SelectList ObtenerHabitacionesSelectList()
        {
            var habitaciones = _dbContext.Habitacion.ToList();
            var habitacionesSelectList = habitaciones.Select(h => new
            {
                Id = h.IDHabitacion,
                DisplayText = $"{h.Numero} - {h.TipoHabitacion}"
            }).ToList();

            return new SelectList(habitacionesSelectList, "Id", "DisplayText");
        }
    }
}
