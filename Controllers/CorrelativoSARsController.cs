using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManager.Data;
using HotelManager.Models;

namespace HotelManager.Controllers
{
    public class CorrelativoSARsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor del controlador que recibe una instancia de ApplicationDbContext
        public CorrelativoSARsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CorrelativoSARs/Index
        // Muestra la lista de correlativos SAR o un mensaje de problema si el conjunto de entidades es nulo
        public async Task<IActionResult> Index()
        {
            return _context.CorrelativoSAR != null ?
                          View(await _context.CorrelativoSAR.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CorrelativoSAR' is null.");
        }

        // GET: CorrelativoSARs/Details/5
        // Muestra los detalles de un correlativo SAR específico
        public async Task<IActionResult> Details(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.CorrelativoSAR == null)
            {
                return NotFound();
            }

            // Obtener el correlativo SAR con el ID proporcionado
            var correlativoSAR = await _context.CorrelativoSAR
                .FirstOrDefaultAsync(m => m.IDCorrelativoSAR == id);

            // Validación de existencia del correlativo SAR
            if (correlativoSAR == null)
            {
                return NotFound();
            }

            return View(correlativoSAR);
        }

        // GET: CorrelativoSARs/Create
        // Muestra el formulario para crear un nuevo correlativo SAR
        public IActionResult Create()
        {
            return View();
        }

        // POST: CorrelativoSARs/Create
        // Procesa la creación de un nuevo correlativo SAR, con validación del modelo y redirección a la lista de correlativos SAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCorrelativoSAR,NumeroCAI,NumeroInicial,NumeroFinal,FechaInicial,FechaLimite")] CorrelativoSAR correlativoSAR)
        {
            // Asignar un nuevo GUID como ID del correlativo SAR
            correlativoSAR.IDCorrelativoSAR = Guid.NewGuid();

            // Asignar valores específicos a los campos eliminados
            correlativoSAR.UltimoUtilizado = 0; // Puedes ajustar la lógica según tus requerimientos
            correlativoSAR.FechaFinal = null; // Puedes ajustar la lógica según tus requerimientos
            correlativoSAR.Finalizado = false; // Puedes ajustar la lógica según tus requerimientos

            // Agregar el correlativo SAR al contexto y guardar los cambios
            _context.Add(correlativoSAR);
            await _context.SaveChangesAsync();

            // Redirección a la lista de correlativos SAR
            return RedirectToAction(nameof(Index));
        }


        // GET: CorrelativoSARs/Edit/5
        // Muestra el formulario para editar un correlativo SAR existente
        public async Task<IActionResult> Edit(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.CorrelativoSAR == null)
            {
                return NotFound();
            }

            // Obtener el correlativo SAR a editar
            var correlativoSAR = await _context.CorrelativoSAR.FindAsync(id);

            // Validación de existencia del correlativo SAR
            if (correlativoSAR == null)
            {
                return NotFound();
            }
            return View(correlativoSAR);
        }

        // POST: CorrelativoSARs/Edit/5
        // Procesa la edición de un correlativo SAR existente, con validación del modelo y redirección a la lista de correlativos SAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IDCorrelativoSAR,NumeroCAI,NumeroInicial,NumeroFinal,UltimoUtilizado,FechaInicial,FechaLimite,FechaFinal,Finalizado")] CorrelativoSAR correlativoSAR)
        {
            // Validación de igualdad de IDs
            if (id != correlativoSAR.IDCorrelativoSAR)
            {
                return NotFound();
            }

            try
            {
                // Actualizar el correlativo SAR en el contexto y guardar los cambios
                _context.Update(correlativoSAR);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de excepciones de concurrencia
                if (!CorrelativoSARExists(correlativoSAR.IDCorrelativoSAR))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // Redirección a la lista de correlativos SAR
            return RedirectToAction(nameof(Index));

            return View(correlativoSAR);
        }

        // GET: CorrelativoSARs/Delete/5
        // Muestra la página de confirmación de eliminación de un correlativo SAR
        public async Task<IActionResult> Delete(Guid? id)
        {
            // Validación de parámetros
            if (id == null || _context.CorrelativoSAR == null)
            {
                return NotFound();
            }

            // Obtener el correlativo SAR a eliminar
            var correlativoSAR = await _context.CorrelativoSAR
                .FirstOrDefaultAsync(m => m.IDCorrelativoSAR == id);

            // Validación de existencia del correlativo SAR
            if (correlativoSAR == null)
            {
                return NotFound();
            }

            // Mostrar la página de confirmación de eliminación
            return View(correlativoSAR);
        }

        // POST: CorrelativoSARs/Delete/5
        // Procesa la eliminación de un correlativo SAR y redirecciona a la lista de correlativos SAR
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            // Validación de existencia del conjunto de entidades
            if (_context.CorrelativoSAR == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CorrelativoSAR' is null.");
            }

            // Buscar el correlativo SAR por ID
            var correlativoSAR = await _context.CorrelativoSAR.FindAsync(id);

            // Validar la existencia del correlativo SAR antes de intentar eliminarlo
            if (correlativoSAR != null)
            {
                // Eliminar el correlativo SAR del contexto
                _context.CorrelativoSAR.Remove(correlativoSAR);
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirección a la lista de correlativos SAR
            return RedirectToAction(nameof(Index));
        }

        // Verificación de existencia de un correlativo SAR
        private bool CorrelativoSARExists(Guid id)
        {
            // Verificar la existencia de un correlativo SAR con el ID proporcionado
            return (_context.CorrelativoSAR?.Any(e => e.IDCorrelativoSAR == id)).GetValueOrDefault();
        }

        [HttpGet]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsNumeroCAIUnique(string numeroCAI)
        {
            var isUnique = await _context.CorrelativoSAR
                .AllAsync(c => c.NumeroCAI != numeroCAI);

            return Json(isUnique);
        }
    }
}
