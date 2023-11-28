using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;
using System;

namespace HotelManager.Models
{
    public class DetallesFactura
    {
        public int Id { get; set; }
        public int producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
public class FacturaController : Controller
    {
        private static List<DetallesFactura> detallesFactura = new List<DetallesFactura>();

        // Acción para mostrar todos los detalles de la factura
        public IActionResult Index()
        {
            return View(detallesFactura);
        }

        // Acción para mostrar el formulario de creación de detalle de factura
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para procesar la creación de un nuevo detalle de factura
        [HttpPost]
        public IActionResult Crear(DetallesFactura nuevoDetalle)
        {
            nuevoDetalle.Id = detallesFactura.Count + 1;
            detallesFactura.Add(nuevoDetalle);
            return RedirectToAction("Index");
        }

        // Acción para mostrar el formulario de edición de detalle de factura
        public IActionResult Editar(int id)
        {
            var detalle = detallesFactura.FirstOrDefault(d => d.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }
            return View(detalle);
        }

        // Acción para procesar la edición de un detalle de factura
        [HttpPost]
        public IActionResult Editar(DetallesFactura detalleEditado)
        {
            var detalleExistente = detallesFactura.FirstOrDefault(d => d.Id == detalleEditado.Id);
            if (detalleExistente != null)
            {
                detalleExistente.producto = detalleEditado.producto;
                detalleExistente.PrecioUnitario = detalleEditado.PrecioUnitario;
                detalleExistente.Cantidad = detalleEditado.Cantidad;
            }
            return RedirectToAction("Index");
        }

        // Acción para mostrar el formulario de confirmación de eliminación
        public IActionResult Eliminar(int id)
        {
            var detalle = detallesFactura.FirstOrDefault(d => d.Id == id);
            if (detalle == null)
            {
                return NotFound();
            }
            return View(detalle);
        }

        // Acción para procesar la eliminación de un detalle de factura
        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            var detalle = detallesFactura.FirstOrDefault(d => d.Id == id);
            if (detalle != null)
            {
                detallesFactura.Remove(detalle);
            }
            return RedirectToAction("Index");
        }
    }
}
