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
    public class ServicioHotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor del controlador que recibe una instancia de ApplicationDbContext
        public ServicioHotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas/Index
        // Muestra la lista de reservas con detalles de ApplicationUser, EncabezadoFactura y Habitacion
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        // Muestra los detalles de una reserva específica con detalles de ApplicationUser, EncabezadoFactura y Habitacion
        public async Task<IActionResult> Details(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.ServicioHotel == null)
            {
                return NotFound();
            }

            // Obtener la reserva con detalles de ApplicationUser, EncabezadoFactura y Habitacion
            var servicioHotel = await _context.ServicioHotel

                .FirstOrDefaultAsync(m => m.IDServicio == id);

            // Validación de existencia de la reserva
            if (servicioHotel == null)
            {
                return NotFound();
            }

            return View(servicioHotel);
        }

        // GET: producto/Create
        // Muestra el formulario para crear una nueva reserva con listas desplegables para ApplicationUser, EncabezadoFactura y Habitacion
        public IActionResult Create()
        {
            //ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Producto/Create
        // Procesa la creación de una nueva reserva, con validación del modelo y redirección a la lista de reservas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDServicio,NombreServicio,Descripcion,Duracion,Tarifa")] ServicioHotel servicioHotel)
        {

            // Asignar un nuevo GUID como ID de la reserva
            servicioHotel.IDServicio = Guid.NewGuid();
            // Agregar la reserva al contexto y guardar los cambios
            _context.Add(servicioHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // Recargar listas desplegables en caso de error
            return View(servicioHotel);
        }

        // GET: Reservas/Edit/5
        // Muestra el formulario para editar una reserva existente con listas desplegables para ApplicationUser, EncabezadoFactura y Habitacion
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.ServicioHotel == null)
            {
                return NotFound();
            }

            // Obtener la reserva a editar
            var servicioHotel = await _context.ServicioHotel.FindAsync(id);

            // Validación de existencia de la reserva
            if (servicioHotel == null)
            {
                return NotFound();
            }

            return View(servicioHotel);
        }

        // POST: Reservas/Edit/5
        // Procesa la edición de una reserva existente, con validación del modelo y redirección a la lista de reservas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDServicio,NombreServicio,Descripcion,Duracion,Tarifa")] ServicioHotel servicioHotel)
        {
            // Validación de igualdad de IDs
            if (id != servicioHotel.IDServicio)
            {
                return NotFound();
            }
            try
            {
                // Actualizar la reserva en el contexto y guardar los cambios
                _context.Update(servicioHotel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de excepciones de concurrencia
                if (!ReservaExists(servicioHotel.IDServicio))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

                // Redirección a la lista de reservas
                return RedirectToAction(nameof(Index));
            }


            return View(servicioHotel);
        }

        // GET: Reservas/Delete/5
        // Muestra la página de confirmación de eliminación de una reserva
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.ServicioHotel == null)
            {
                return NotFound();
            }

            // Obtener la reserva a eliminar con detalles de ApplicationUser, EncabezadoFactura y Habitacion
            var servicioHotel = await _context.ServicioHotel

                .FirstOrDefaultAsync(m => m.IDServicio == id);

            // Validación de existencia de la reserva
            if (servicioHotel == null)
            {
                return NotFound();
            }

            // Mostrar la página de confirmación de eliminación
            return View(servicioHotel);
        }

        // POST: Reservas/Delete/5
        // Procesa la eliminación de una reserva y redirecciona a la lista de reservas
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Validación de existencia del conjunto de entidades
            if (_context.ServicioHotel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServicioHotel' is null.");
            }

            // Buscar la reserva por ID
            var servicioHotel = await _context.ServicioHotel.FindAsync(id);

            // Validar la existencia de la reserva antes de intentar eliminarla
            if (servicioHotel != null)
            {
                // Eliminar la reserva del contexto
                _context.ServicioHotel.Remove(servicioHotel);
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirección a la lista de reservas
            return RedirectToAction(nameof(Index));
        }

        // Verificación de existencia de una reserva
        private bool ReservaExists(Guid id)
        {
            // Verificar la existencia de una reserva con el ID proporcionado
            return (_context.ServicioHotel?.Any(e => e.IDServicio == id)).GetValueOrDefault();
        }

        // Obtener la tarifa de la habitación seleccionada


        // Buscar usuarios
        public IActionResult SearchUsers(string numeroIdentidad, string nombre, string telefono, string direccion, string userName)
        {
            // Realiza la búsqueda de usuarios por varios campos, incluyendo correo electrónico
            var users = _context.Users
                .Where(u =>
                    (string.IsNullOrEmpty(numeroIdentidad) || u.NumeroIdentidad.Contains(numeroIdentidad)) &&
                    (string.IsNullOrEmpty(nombre) || u.Nombre.Contains(nombre)) &&
                    (string.IsNullOrEmpty(telefono) || u.Telefono.Contains(telefono)) &&
                    (string.IsNullOrEmpty(direccion) || u.Direccion.Contains(direccion)) &&
                    (string.IsNullOrEmpty(userName) || u.UserName.Contains(userName)))
                .Select(u => new { u.Id, u.Nombre, u.NumeroIdentidad, u.Telefono, u.Direccion, u.UserName })
                .ToList();
            return Json(users);
        }

    }
}
