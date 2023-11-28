using HotelManager.Data;
using HotelManager.Models;
using HotelManager.Models.VM;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace HotelManager.Controllers
{
    [Authorize (Roles = "Admin")]
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
        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var habitacion = _dbContext.Habitacion.FirstOrDefault(h => h.IDHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            var habitacionVM = new HabitacionesVM
            {
                IDHabitacion = habitacion.IDHabitacion,
                Numero = habitacion.Numero,
                TipoHabitacion = habitacion.TipoHabitacion,
                Tarifa = habitacion.Tarifa,
                Disponibilidad = habitacion.Disponibilidad,
                Descripcion = habitacion.Descripcion,
                // Mapea otros campos según sea necesario
            };

            return View(habitacionVM);
        }
        [HttpPost]
        public IActionResult GuardarEdicion(HabitacionesVM habitacionVM)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    var habitacion = _dbContext.Habitacion.FirstOrDefault(h => h.IDHabitacion == habitacionVM.IDHabitacion);

                    if (habitacion == null)
                    {
                        return NotFound();
                    }
                    habitacion.IDHabitacion = habitacionVM.IDHabitacion;
                    habitacion.Numero = habitacionVM.Numero;
                    habitacion.TipoHabitacion = habitacionVM.TipoHabitacion;
                    habitacion.Tarifa = habitacionVM.Tarifa;
                    habitacion.Disponibilidad = habitacionVM.Disponibilidad;
                    habitacion.Descripcion = habitacionVM.Descripcion;
                    // Actualiza otros campos según sea necesario

                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al guardar la edición de la habitación.");
                    ModelState.AddModelError(string.Empty, "Error al guardar la edición de la habitación. Por favor, inténtelo de nuevo.");
                }
            //}

            return View("Editar", habitacionVM);
        }
        [HttpGet]
        public IActionResult Eliminar(Guid id)
        {
            Debug.WriteLine($"Entrando a get");
            var habitacion = _dbContext.Habitacion.FirstOrDefault(h => h.IDHabitacion == id);

            if (habitacion == null)
            {
                Debug.WriteLine($"Entrando a if get");
                return NotFound();
            }

            var habitacionVM = new HabitacionesVM
            {
                IDHabitacion = habitacion.IDHabitacion,
                Numero = habitacion.Numero,
                TipoHabitacion = habitacion.TipoHabitacion,
                Tarifa = habitacion.Tarifa,
                Disponibilidad = habitacion.Disponibilidad,
                Descripcion = habitacion.Descripcion,

                // Mapea otros campos según sea necesario
            };

            return View(habitacionVM);
            Debug.WriteLine($"retorno");
        }

        [HttpPost]
        public IActionResult EliminarConfirmacion(Guid id)
        {
                    Debug.WriteLine($"Entrando a try del post");
                    try
            {
                var habitacion = _dbContext.Habitacion.FirstOrDefault(h => h.IDHabitacion == id);

                if (habitacion == null)
                {
                            Debug.WriteLine($"Entro a if post");
                            return NotFound();
                }
                Debug.WriteLine($"Salio de if");
                _dbContext.Habitacion.Remove(habitacion);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la habitación.");
                // Puedes manejar errores y mostrar un mensaje al usuario si es necesario
                return RedirectToAction(nameof(Index));
            }
        }

            }

        }

