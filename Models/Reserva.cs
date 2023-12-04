using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Reserva
    {
        public Guid IDReserva { get; set; }
        public string IDUsuario { get; set; }
        public Guid IDHabitacion { get; set; }
        public Guid? IDFactura { get; set; }

        [Required(ErrorMessage = "La fecha de check-in es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckin { get; set; }

        [Required(ErrorMessage = "La fecha de check-out es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckOut { get; set; }
        public string EstadoReserva { get; set; }

        // Relaciones
        public Habitacion Habitacion { get; set; }
        public EncabezadoFactura EncabezadoFactura { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Campos exclusivos de las vistas
        [NotMapped]
        [RegularExpression(@"^\d{1,13}$", ErrorMessage = "El número de identidad debe contener solo números y tener como máximo 13 dígitos.")]
        public string? NumeroIdentidad { get; set; }

        [NotMapped]
        public string? Nombre { get; set; }

        [NotMapped]
        public string? Telefono { get; set; }

        [NotMapped]
        public string? Direccion { get; set; }

        [NotMapped]
        public string? CorreoElectronico { get; set; }

        [NotMapped]
        public int CantidadDias => (int)(FechaCheckOut - FechaCheckin).TotalDays;

    }
}
