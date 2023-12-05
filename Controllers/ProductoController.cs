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
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor del controlador que recibe una instancia de ApplicationDbContext
        public ProductoController(ApplicationDbContext context)
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
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            // Obtener la reserva con detalles de ApplicationUser, EncabezadoFactura y Habitacion
            var producto = await _context.Producto
                
                .FirstOrDefaultAsync(m => m.IDProducto == id);

            // Validación de existencia de la reserva
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
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
        public async Task<IActionResult> Create([Bind("IDProducto,NombreProducto,Descripcion,PrecioUnitario,Existencia")] Producto producto)
        {

            // Asignar un nuevo GUID como ID de la reserva
            producto.IDProducto = Guid.NewGuid();
            // Agregar la reserva al contexto y guardar los cambios
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // Recargar listas desplegables en caso de error
            return View(producto);
        }

        // GET: Reservas/Edit/5
        // Muestra el formulario para editar una reserva existente con listas desplegables para ApplicationUser, EncabezadoFactura y Habitacion
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            // Obtener la reserva a editar
            var producto = await _context.Producto.FindAsync(id);

            // Validación de existencia de la reserva
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Reservas/Edit/5
        // Procesa la edición de una reserva existente, con validación del modelo y redirección a la lista de reservas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDProducto,NombreProducto,Descripcion,PrecioUnitario,Existencia")] Producto producto)
        {
            // Validación de igualdad de IDs
            if (id != producto.IDProducto)
            {
                return NotFound();
            }
            try
            {
                // Actualizar la reserva en el contexto y guardar los cambios
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de excepciones de concurrencia
                if (!ReservaExists(producto.IDProducto))
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


            return View(producto);
        }

        // GET: Reservas/Delete/5
        // Muestra la página de confirmación de eliminación de una reserva
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            // Obtener la reserva a eliminar con detalles de ApplicationUser, EncabezadoFactura y Habitacion
            var producto = await _context.Producto

                .FirstOrDefaultAsync(m => m.IDProducto == id);

            // Validación de existencia de la reserva
            if (producto == null)
            {
                return NotFound();
            }

            // Mostrar la página de confirmación de eliminación
            return View(producto);
        }

        // POST: Reservas/Delete/5
        // Procesa la eliminación de una reserva y redirecciona a la lista de reservas
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Validación de existencia del conjunto de entidades
            if (_context.Producto == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Producto' is null.");
            }

            // Buscar la reserva por ID
            var producto = await _context.Producto.FindAsync(id);

            // Validar la existencia de la reserva antes de intentar eliminarla
            if (producto != null)
            {
                // Eliminar la reserva del contexto
                _context.Producto.Remove(producto);
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
            return (_context.Producto?.Any(e => e.IDProducto == id)).GetValueOrDefault();
        }

        // Obtener la tarifa de la habitación seleccionada


        // Buscar usuarios
        public IActionResult SearchProductos(string NombreProducto, string Descripcion, decimal? PrecioUnitario, int? Existencias)
        {
            // Realiza la búsqueda de productos por varios campos, incluyendo nombre, descripción, precio unitario y existencias
            var productos = _context.Producto
                .Where(p =>
                    (string.IsNullOrEmpty(NombreProducto) || p.NombreProducto.Contains(NombreProducto)) &&
                    (string.IsNullOrEmpty(Descripcion) || p.Descripcion.Contains(Descripcion)) &&
                    (!PrecioUnitario.HasValue || p.PrecioUnitario == PrecioUnitario) &&
                    (!Existencias.HasValue || p.Existencias == Existencias)
                )
                .Select(p => new { p.IDProducto, p.NombreProducto, p.Descripcion, p.PrecioUnitario, p.Existencias })
                .ToList();

            return Json(productos);
        }


    }
}

