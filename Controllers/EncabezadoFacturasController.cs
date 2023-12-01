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
    public class EncabezadoFacturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor del controlador que recibe una instancia de ApplicationDbContext
        public EncabezadoFacturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EncabezadoFacturas/Index
        // Muestra la lista de encabezados de facturas con detalles de ApplicationUser
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EncabezadoFactura.Include(e => e.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EncabezadoFacturas/Details/5
        // Muestra los detalles de un encabezado de factura específico con detalles de ApplicationUser
        public async Task<IActionResult> Details(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.EncabezadoFactura == null)
            {
                return NotFound();
            }

            // Obtener el encabezado de factura con detalles de ApplicationUser
            var encabezadoFactura = await _context.EncabezadoFactura
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.IDFactura == id);

            // Validación de existencia del encabezado de factura
            if (encabezadoFactura == null)
            {
                return NotFound();
            }

            return View(encabezadoFactura);
        }

        // GET: EncabezadoFacturas/Create
        // Muestra el formulario para crear un nuevo encabezado de factura con lista desplegable para ApplicationUser
        public IActionResult Create()
        {
            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: EncabezadoFacturas/Create
        // Procesa la creación de un nuevo encabezado de factura, con validación del modelo y redirección a la lista de encabezados de facturas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFactura,IDCorrelativoSAR,IDEmpleado,IDUsuario,NumeroFacturaSAR,FechaFactura,SubTotalFactura,DescuentoFactura,ImpuestoFactura,TotalFactura,Eliminada")] EncabezadoFactura encabezadoFactura)
        {
            // Asignar un nuevo GUID como ID del encabezado de factura
            encabezadoFactura.IDFactura = Guid.NewGuid();
            // Agregar el encabezado de factura al contexto y guardar los cambios
            _context.Add(encabezadoFactura);
            await _context.SaveChangesAsync();
            // Redirección a la lista de encabezados de facturas
            return RedirectToAction(nameof(Index));

            // Recargar lista desplegable en caso de error
            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id", encabezadoFactura.IDUsuario);
            return View(encabezadoFactura);
        }

        // GET: EncabezadoFacturas/Edit/5
        // Muestra el formulario para editar un encabezado de factura existente con lista desplegable para ApplicationUser
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.EncabezadoFactura == null)
            {
                return NotFound();
            }

            // Obtener el encabezado de factura a editar
            var encabezadoFactura = await _context.EncabezadoFactura.FindAsync(id);

            // Validación de existencia del encabezado de factura
            if (encabezadoFactura == null)
            {
                return NotFound();
            }

            // Cargar lista desplegable para ApplicationUser
            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id", encabezadoFactura.IDUsuario);
            return View(encabezadoFactura);
        }

        // POST: EncabezadoFacturas/Edit/5
        // Procesa la edición de un encabezado de factura existente, con validación del modelo y redirección a la lista de encabezados de facturas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDFactura,IDCorrelativoSAR,IDEmpleado,IDUsuario,NumeroFacturaSAR,FechaFactura,SubTotalFactura,DescuentoFactura,ImpuestoFactura,TotalFactura,Eliminada")] EncabezadoFactura encabezadoFactura)
        {
            // Validación de igualdad de IDs
            if (id != encabezadoFactura.IDFactura)
            {
                return NotFound();
            }

            try
            {
                // Actualizar el encabezado de factura en el contexto y guardar los cambios
                _context.Update(encabezadoFactura);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de excepciones de concurrencia
                if (!EncabezadoFacturaExists(encabezadoFactura.IDFactura))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // Redirección a la lista de encabezados de facturas
            return RedirectToAction(nameof(Index));


            // Recargar lista desplegable en caso de error
            ViewData["IDUsuario"] = new SelectList(_context.ApplicationUser, "Id", "Id", encabezadoFactura.IDUsuario);
            return View(encabezadoFactura);
        }

        // GET: EncabezadoFacturas/Delete/5
        // Muestra la página de confirmación de eliminación de un encabezado de factura
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.EncabezadoFactura == null)
            {
                return NotFound();
            }

            // Obtener el encabezado de factura a eliminar con detalles de ApplicationUser
            var encabezadoFactura = await _context.EncabezadoFactura
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(m => m.IDFactura == id);

            // Validación de existencia del encabezado de factura
            if (encabezadoFactura == null)
            {
                return NotFound();
            }

            // Mostrar la página de confirmación de eliminación
            return View(encabezadoFactura);
        }

        // POST: EncabezadoFacturas/Delete/5
        // Procesa la eliminación de un encabezado de factura y redirecciona a la lista de encabezados de facturas
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Validación de existencia del conjunto de entidades
            if (_context.EncabezadoFactura == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EncabezadoFactura' is null.");
            }

            // Buscar el encabezado de factura por ID
            var encabezadoFactura = await _context.EncabezadoFactura.FindAsync(id);

            // Validar la existencia del encabezado de factura antes de intentar eliminarlo
            if (encabezadoFactura != null)
            {
                // Eliminar el encabezado de factura del contexto
                _context.EncabezadoFactura.Remove(encabezadoFactura);
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirección a la lista de encabezados de facturas
            return RedirectToAction(nameof(Index));
        }

        // Verificación de existencia de un encabezado de factura
        private bool EncabezadoFacturaExists(Guid id)
        {
            // Verificar la existencia de un encabezado de factura con el ID proporcionado
            return (_context.EncabezadoFactura?.Any(e => e.IDFactura == id)).GetValueOrDefault();
        }
    }
}
