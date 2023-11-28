using HotelManager.Data;
using HotelManager.Models;
using HotelManager.Models.VM;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HotelManager.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly ILogger<HabitacionesController> _logger;
        private ApplicationDbContext _dbContext;
        public HabitacionesController(ILogger<HabitacionesController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var habitaciones = _dbContext.Habitacion.ToList();  // Obtener la lista de habitaciones desde la base de datos

            // Puedes ajustar este mapeo según la estructura exacta de tu ViewModel
            var habitacionesViewModel = habitaciones.Select(h => new HabitacionesVM
            {
                IDHabitacion = h.IDHabitacion,
                Numero = h.Numero,
                TipoHabitacion = h.TipoHabitacion,
                Tarifa = h.Tarifa,
                Descripcion = h.Descripcion,
                // Mapear otros campos según sea necesario
            }).ToList();

            return View(habitacionesViewModel);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var habitacionViewModel = new HabitacionesVM(); // Puedes inicializarlo según sea necesario
            return View(habitacionViewModel);

        }

        [HttpPost]
        public IActionResult Insertar(HabitacionesVM HabitacionVM)
        {
            Debug.WriteLine("Ingresando a la acción Insertar");
            //if (ModelState.IsValid)
            //{
                try
                {
                    var habitacion = new Habitacion
                    {
                        IDHabitacion = Guid.NewGuid(),
                        Numero = HabitacionVM.Numero,
                        TipoHabitacion = HabitacionVM.TipoHabitacion,
                        Tarifa = HabitacionVM.Tarifa,
                        Descripcion = HabitacionVM.Descripcion,
                        Disponibilidad = HabitacionVM.Disponibilidad,

                        // Asigna otros campos según sea necesario
                    };

                    _dbContext.Habitacion.Add(habitacion);

                    // Verifica si hay errores al guardar los cambios
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
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error en la acción Insertar: {ex.Message}");
                    _logger.LogError(ex, "Error al insertar la habitación.");
                    ModelState.AddModelError(string.Empty, "Error al insertar la habitación. Por favor, inténtelo de nuevo.");
                }
            //}

            // Si llegamos aquí, significa que hay errores de validación o de inserción.
            // Devuelve la vista Insertar con el modelo para mostrar los mensajes de error.
            return View(HabitacionVM);
        }

    }
}
