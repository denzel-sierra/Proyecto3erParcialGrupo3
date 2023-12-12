using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Reserva
    {
        public Guid IDReserva { get; set; }

        [Required(ErrorMessage = "Seleccione un usurio.")]
        public string? IDUsuario { get; set; }

        public Guid IDHabitacion { get; set; }

        [DisplayName("Fecha de Check-in")]
        [Required(ErrorMessage = "La fecha de check-in es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckin { get; set; }

        [DisplayName("Fecha de Check-out")]
        [Required(ErrorMessage = "La fecha de check-out es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El campo debe ser una fecha.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckOut { get; set; }

        [DisplayName("Estado")]
        public string EstadoReserva { get; set; }

        // Relaciones
        public Habitacion Habitacion { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Campos exclusivos de las vistas
        [NotMapped]
        [RegularExpression(@"^\d{1,13}$", ErrorMessage = "El número de identidad debe contener solo números y tener como máximo 13 dígitos.")]
        public string? NumeroIdentidad { get; set; }

        [NotMapped]
        public string? Nombre { get; set; }

        [NotMapped]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo puede contener números.")]
        public string? Telefono { get; set; }

        [NotMapped]
        public string? Direccion { get; set; }

        [NotMapped]
        public string? CorreoElectronico { get; set; }

        [NotMapped]
        public int CantidadDias => (int)(FechaCheckOut - FechaCheckin).TotalDays;

        [NotMapped]
        public int NumeroHabitacion { get; set; }

        [NotMapped]
        public string TipoHabitacion { get; set; }

        [NotMapped]
        public bool Disponibilidad { get; set; }

        [NotMapped]
        public decimal Tarifa { get; set; }

    }
}
