using HotelManager.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models
{
    public class CorrelativoSAR
    {
        private readonly ApplicationDbContext _dbContext;

        public CorrelativoSAR(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid IDCorrelativoSAR { get; set; }

        [Display(Name = "Número CAI")]
        [Required(ErrorMessage = "El Numero CAI es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo NumeroCAI no puede tener más de 50 caracteres.")]
        [Remote("IsNumeroCAIUnique", "CorrelativoSARs", ErrorMessage = "Este NumeroCAI ya está en uso.")]
        public string NumeroCAI { get; set; }

        [Display(Name = "Número Inicial")]
        [Required(ErrorMessage = "El Numero Inicial es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo NumeroInicial debe ser mayor que cero.")]
        [RegularExpression(@"^\d{1,8}$", ErrorMessage = "El campo debe tener como máximo 8 dígitos.")]

        public int NumeroInicial { get; set; }

        [Display(Name = "Número Final")]
        [Required(ErrorMessage = "El Numero Final es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo NumeroFinal debe ser mayor que cero.")]
        [RegularExpression(@"^\d{1,8}$", ErrorMessage = "El campo debe tener como máximo 8 dígitos.")]
        public int NumeroFinal { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo UltimoUtilizado debe ser mayor que cero.")]
        public int? UltimoUtilizado { get; set; }

        [Required(ErrorMessage = "La Fecha Inicial es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicial")]
        public DateTime FechaInicial { get; set; }

        [Required(ErrorMessage = "La Fecha Límite es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Límite")]
        public DateTime FechaLimite { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Final")]
        public DateTime? FechaFinal { get; set; }

        public bool Finalizado { get; set; }

        // Relaciones
        public ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }

        //Validaciones

        public void ActualizarUltimoUtilizado(int nuevoNumero)
        {
            UltimoUtilizado = nuevoNumero;

            // Buscar el correlativo en la base de datos y actualizar su UltimoUtilizado
            var correlativoEnDB = _dbContext.CorrelativoSAR.FirstOrDefault(c => c.IDCorrelativoSAR == IDCorrelativoSAR);

            if (correlativoEnDB != null)
            {
                correlativoEnDB.UltimoUtilizado = nuevoNumero;
                _dbContext.SaveChanges();
            }
            // Puedes agregar un manejo de errores aquí si correlativoEnDB es null
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validar que NumeroInicial no sea igual o mayor al límite
            if (NumeroInicial >= NumeroFinal)
            {
                yield return new ValidationResult("El número inicial debe ser menor que el número final.", new[] { nameof(NumeroInicial) });
            }

            // Validar que NumeroFinal no sea menor o igual al inicial
            if (NumeroFinal <= NumeroInicial)
            {
                yield return new ValidationResult("El número final debe ser mayor que el número inicial.", new[] { nameof(NumeroFinal) });
            }

            if (FechaFinal < FechaInicial)
            {
                yield return new ValidationResult("La FechaFinal no puede ser anterior a la FechaInicial.", new[] { nameof(FechaFinal) });
            }

            if (NumeroInicial >= NumeroFinal)
            {
                yield return new ValidationResult("El NumeroInicial debe ser menor que el NumeroFinal.", new[] { nameof(NumeroInicial) });
            }

            if (NumeroFinal <= NumeroInicial)
            {
                yield return new ValidationResult("El NumeroFinal debe ser mayor que el NumeroInicial.", new[] { nameof(NumeroFinal) });
            }

            // Validación de cruces con otros correlativos
            var dbContext = validationContext.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            if (dbContext != null)
            {
                var overlappingCorrelativos = dbContext.CorrelativoSAR
                    .Where(c =>
                        c.IDCorrelativoSAR != IDCorrelativoSAR &&
                        (
                            (FechaInicial >= c.FechaInicial && FechaInicial <= c.FechaFinal) ||
                            (FechaFinal >= c.FechaInicial && FechaFinal <= c.FechaFinal) ||
                            (c.FechaInicial >= FechaInicial && c.FechaInicial <= FechaFinal) ||
                            (c.FechaFinal >= FechaInicial && c.FechaFinal <= FechaFinal)
                        )
                    )
                    .ToList();

                if (overlappingCorrelativos.Any())
                {
                    yield return new ValidationResult("Los rangos de fechas no pueden cruzarse con otros correlativos.", new[] { nameof(FechaInicial), nameof(FechaFinal) });
                }
            }
        }
    }
}
