using HotelManager.Data;
using HotelManager.Models;
using HotelManager.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace HotelManager.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly ILogger<CitasController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _dbContext;

        public CitasController(ILogger<CitasController> logger, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // Acción para mostrar la lista de citas
        public IActionResult Index(string estado = null)
        {
            IQueryable<Cita> citasQuery = _dbContext.Cita;

            // Aplicar filtro por estado si se proporciona
            if (!string.IsNullOrEmpty(estado))
            {
                // Intentar convertir estado a Guid
                if (Guid.TryParse(estado, out var estadoGuid))
                {
                    citasQuery = citasQuery.Where(c => c.EstadoCita.ToString() == estadoGuid.ToString());
                }
                else
                {
                    // Manejar el caso en que estado no es un Guid válido
                    ModelState.AddModelError(string.Empty, "El formato del estado no es válido.");
                    estado = null; // Restablecer el estado para evitar errores adicionales
                }
            }

            var citas = citasQuery.ToList();
            var citasViewModel = citas.Select(c => new CitasVM
            {
                IDCita = c.IDCita,
                IDUsuario = c.IDUsuario,
                IDEmpleado = c.IDEmpleado,
                FechaHoraCita = c.FechaHoraCita,
                EstadoCita = c.EstadoCita.ToString(), // Convertir a cadena
                TomadaPorEmpleado = c.TomadaPorEmpleado,
                // Otros campos según sea necesario
            }).ToList();

            return View(citasViewModel);
        }

        // Acción para mostrar el formulario de edición de cita
        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

            if (cita == null)
            {
                return NotFound();
            }

            var citaViewModel = new CitasVM
            {
                IDCita = cita.IDCita,
                IDUsuario = cita.IDUsuario,
                IDEmpleado = cita.IDEmpleado,
                FechaHoraCita = cita.FechaHoraCita,
                EstadoCita = cita.EstadoCita,
                // Otros campos según sea necesario
            };

            return View(citaViewModel);
        }

        // Acción para procesar la edición de cita
        [HttpPost]
        public IActionResult Editar(CitasVM CitasVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == CitasVM.IDCita);

                    if (cita != null)
                    {
                        // Actualizar los campos según sea necesario
                        cita.IDUsuario = CitasVM.IDUsuario;
                        cita.IDEmpleado = CitasVM.IDEmpleado;
                        cita.FechaHoraCita = CitasVM.FechaHoraCita;
                        cita.EstadoCita = CitasVM.EstadoCita;

                        _dbContext.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción Editar: {ex.ToString()}");
                ModelState.AddModelError(string.Empty, "Error al editar la cita. Por favor, inténtelo de nuevo.");
            }

            // Lógica para obtener los IDs de usuario y empleado según el rol del usuario actual
            ViewBag.Usuarios = ObtenerUsuariosSelectList();
            ViewBag.Empleados = ObtenerEmpleadosSelectList();

            return View(CitasVM);
        }

        // Acción para mostrar el formulario de eliminación de cita
        [HttpGet]
        public IActionResult Eliminar(Guid id)
        {
            var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

            if (cita == null)
            {
                return NotFound();
            }

            var citaViewModel = new CitasVM
            {
                IDCita = cita.IDCita,
                IDUsuario = cita.IDUsuario,
                IDEmpleado = cita.IDEmpleado,
                FechaHoraCita = cita.FechaHoraCita,
                EstadoCita = cita.EstadoCita,
                // Otros campos según sea necesario
            };

            return View(citaViewModel);
        }

        // Acción para procesar la eliminación de cita
        [HttpPost]
        public IActionResult EliminarConfirmado(Guid id)
        {
            try
            {
                var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

                if (cita != null)
                {
                    _dbContext.Cita.Remove(cita);
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción EliminarConfirmado: {ex.ToString()}");
                return RedirectToAction(nameof(Eliminar), new { id = id, error = true });
            }
        }

        // Acción para mostrar el formulario de inserción de cita
        [HttpGet]
        public IActionResult Insertar()
        {
            // Tu lógica actual para obtener usuarios y empleados
            ViewBag.Usuarios = ObtenerUsuariosSelectList();
            ViewBag.Empleados = ObtenerEmpleadosSelectList();

            var citaViewModel = new CitasVM();

            return View(citaViewModel);
        }

        // Acción para procesar la inserción de cita
        [HttpPost]
        public IActionResult Insertar(CitasVM CitasVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Validar que la fecha y hora no sea en el pasado
                    if (CitasVM.FechaHoraCita < DateTime.Now)
                    {
                        ModelState.AddModelError(nameof(CitasVM.FechaHoraCita), "La fecha y hora de la cita no puede ser en el pasado.");
                        return View(CitasVM);
                    }

                    // Resto de la lógica para insertar la cita
                    var cita = new Cita
                    {
                        IDCita = Guid.NewGuid(),
                        IDUsuario = CitasVM.IDUsuario,
                        IDEmpleado = CitasVM.IDEmpleado,
                        FechaHoraCita = CitasVM.FechaHoraCita,
                        EstadoCita = "Pendiente", // Puedes establecer el estado inicial según tus necesidades
                        TomadaPorEmpleado = false, // Inicialmente, la cita no está tomada por un empleado
                                                   // Otros campos según sea necesario
                    };

                    _dbContext.Cita.Add(cita);
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción Insertar: {ex.ToString()}");
                ModelState.AddModelError(string.Empty, "Error al insertar la cita. Por favor, inténtelo de nuevo.");
            }

            // Lógica para obtener los IDs de usuario y empleado según el rol del usuario actual
            ViewBag.Usuarios = ObtenerUsuariosSelectList();
            ViewBag.Empleados = ObtenerEmpleadosSelectList();

            return View(CitasVM);
        }


        // Acción para mostrar el formulario de aceptar cita
        [HttpGet]
        public IActionResult Aceptar(Guid id)
        {
            var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

            if (cita == null)
            {
                return NotFound();
            }

            var citaViewModel = new CitasVM
            {
                IDCita = cita.IDCita,
                IDUsuario = cita.IDUsuario,
                IDEmpleado = cita.IDEmpleado,
                FechaHoraCita = cita.FechaHoraCita,
                EstadoCita = cita.EstadoCita,
                // Otros campos según sea necesario
            };

            return View(citaViewModel);
        }

        // Acción para procesar la aceptación de cita
        [HttpPost]
        public IActionResult AceptarConfirmado(Guid id)
        {
            try
            {
                var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

                if (cita != null)
                {
                    // Lógica para cambiar el estado de la cita a "Aceptada"
                    cita.EstadoCita = "Aceptada";
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción AceptarConfirmado: {ex.ToString()}");
                return RedirectToAction(nameof(Aceptar), new { id = id, error = true });
            }
        }

        // Acción para mostrar el formulario de solicitud de cita
        [HttpGet]
        public IActionResult SolicitarCita()
        {
            // Lógica para obtener usuarios y empleados según sea necesario
            ViewBag.Usuarios = ObtenerUsuariosSelectList();
            ViewBag.Empleados = ObtenerEmpleadosSelectList();

            var citaViewModel = new CitasVM();

            return View(citaViewModel);
        }

        // Acción para procesar la solicitud de cita
        [HttpPost]
        public IActionResult SolicitarCita(CitasVM CitasVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Validar que la fecha y hora no sea en el pasado
                    if (CitasVM.FechaHoraCita < DateTime.Now)
                    {
                        ModelState.AddModelError(nameof(CitasVM.FechaHoraCita), "La fecha y hora de la cita no puede ser en el pasado.");
                        return View(CitasVM);
                    }

                    // Resto de la lógica para solicitar la cita
                    var cita = new Cita
                    {
                        IDCita = Guid.NewGuid(),
                        IDUsuario = CitasVM.IDUsuario,
                        IDEmpleado = CitasVM.IDEmpleado,
                        FechaHoraCita = CitasVM.FechaHoraCita,
                        EstadoCita = "Pendiente", // Puedes establecer el estado inicial según tus necesidades
                        TomadaPorEmpleado = false, // Inicialmente, la cita no está tomada por un empleado
                                                   // Otros campos según sea necesario
                    };

                    _dbContext.Cita.Add(cita);
                    _dbContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción SolicitarCita: {ex.ToString()}");
                ModelState.AddModelError(string.Empty, "Error al solicitar la cita. Por favor, inténtelo de nuevo.");
            }

            // Lógica para obtener los IDs de usuario y empleado según el rol del usuario actual
            ViewBag.Usuarios = ObtenerUsuariosSelectList();
            ViewBag.Empleados = ObtenerEmpleadosSelectList();

            return View(CitasVM);
        }

        // Acción para mostrar las citas pendientes para el empleado actual
        [HttpGet]
        public IActionResult CitasPendientes()
        {
            try
            {
                // Obtener el ID del usuario actual (empleado)
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Obtener las citas pendientes para el empleado actual
                var citasPendientes = _dbContext.Cita
                    .Where(c => c.IDEmpleado == Guid.Parse(userId) && c.EstadoCita == "Pendiente")
                    .ToList();

                var citasViewModel = citasPendientes.Select(c => new CitasVM
                {
                    IDCita = c.IDCita,
                    IDUsuario = c.IDUsuario,
                    IDEmpleado = c.IDEmpleado,
                    FechaHoraCita = c.FechaHoraCita,
                    EstadoCita = c.EstadoCita,
                    TomadaPorEmpleado = c.TomadaPorEmpleado,
                    // Otros campos según sea necesario
                }).ToList();

                return View(citasViewModel);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción CitasPendientes: {ex.ToString()}");
                return RedirectToAction(nameof(Index), new { error = true });
            }
        }

        // Acción para confirmar la cita por el empleado
        [HttpPost]
        public IActionResult ConfirmarCita(Guid id)
        {
            try
            {
                var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

                if (cita != null && !cita.TomadaPorEmpleado)
                {
                    // Lógica para confirmar la cita por el empleado
                    cita.TomadaPorEmpleado = true;
                    cita.EstadoCita = "Confirmada";
                    _dbContext.SaveChanges();

                    // Agregar mensaje de notificación
                    TempData["Notificacion"] = "Cita confirmada exitosamente.";
                }

                return RedirectToAction(nameof(CitasPendientes));
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción ConfirmarCita: {ex.ToString()}");
                return RedirectToAction(nameof(CitasPendientes), new { error = true });
            }
        }

        [HttpPost]
        public IActionResult CancelarCita(Guid id)
        {
            try
            {
                var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

                if (cita != null && !cita.TomadaPorEmpleado)
                {
                    // Lógica para cancelar la cita por el empleado
                    cita.EstadoCita = "Cancelada";
                    _dbContext.SaveChanges();

                    // Agregar mensaje de notificación
                    TempData["Notificacion"] = "Cita cancelada exitosamente.";
                }

                return RedirectToAction(nameof(CitasPendientes));
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción CancelarCita: {ex.ToString()}");
                return RedirectToAction(nameof(CitasPendientes), new { error = true });
            }
        }

        [HttpPost]
        public IActionResult PostergarCita(Guid id)
        {
            try
            {
                var cita = _dbContext.Cita.FirstOrDefault(c => c.IDCita == id);

                if (cita != null && !cita.TomadaPorEmpleado)
                {
                    // Lógica para postergar la cita por el empleado
                    cita.EstadoCita = "Postergada";
                    _dbContext.SaveChanges();

                    // Agregar mensaje de notificación
                    TempData["Notificacion"] = "Cita postergada exitosamente.";
                }

                return RedirectToAction(nameof(CitasPendientes));
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Debug.WriteLine($"Error en la acción PostergarCita: {ex.ToString()}");
                return RedirectToAction(nameof(CitasPendientes), new { error = true });
            }
        }

        // Acción para mostrar las citas del cliente
        public IActionResult CitasCliente()
        {
            // Obtener el ID del usuario actual
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtener las citas asociadas al cliente actual
            var citasCliente = _dbContext.Cita
                .Where(c => c.IDUsuario.ToString() == userId)
                .ToList();

            var citasViewModel = citasCliente.Select(c => new CitasVM
            {
                IDCita = c.IDCita,
                IDUsuario = c.IDUsuario,
                IDEmpleado = c.IDEmpleado,
                FechaHoraCita = c.FechaHoraCita,
                EstadoCita = c.EstadoCita,
                TomadaPorEmpleado = c.TomadaPorEmpleado,
                // Otros campos según sea necesario
            }).ToList();

            return View(citasViewModel);
        }

        private SelectList ObtenerUsuariosSelectList()
        {
            var usuarios = _dbContext.Users.ToList();
            var usuariosSelectList = usuarios.Select(u => new
            {
                Id = u.Id,
                DisplayText = $"{u.UserName} - {u.Email}"
            }).ToList();

            return new SelectList(usuariosSelectList, "Id", "DisplayText");
        }

        public async Task<SelectList> ObtenerEmpleadosSelectList()
        {
            // Obtener los IDs de usuarios con el rol "Empleado"
            var empleadosIds = await _dbContext.UserRoles
                .Where(ur => ur.RoleId == "IdDelRolEmpleado") // Reemplaza "IdDelRolEmpleado" con el ID del rol "Empleado"
                .Select(ur => ur.UserId)
                .ToListAsync();

            // Obtener los usuarios con el rol "Empleado"
            var empleados = await _userManager.Users
                .Where(u => empleadosIds.Contains(u.Id))
                .ToListAsync();

            // Crear una lista de SelectListItem
            var empleadosSelectList = empleados
            .Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName // Puedes cambiar esto por otro campo del usuario si lo prefieres
            })
            .ToList();

            // Agregar un elemento por defecto si lo necesitas
            empleadosSelectList.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Selecciona un empleado"
            });

            // Devolver la SelectList
            return new SelectList(empleadosSelectList, "Value", "Text");
        }
    }
}
