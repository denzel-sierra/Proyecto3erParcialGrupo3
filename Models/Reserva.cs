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
        public DateTime FechaCheckin { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string EstadoReserva { get; set; }

        // Relaciones
        public Habitacion Habitacion { get; set; }
        public EncabezadoFactura EncabezadoFactura { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Campos exclusivos de las vistas
        [NotMapped]
        public string? NumeroIdentidad { get; set; }
        [NotMapped]
        public string? Nombre { get; set; }
        [NotMapped]
        public string? Telefono { get; set; }
        [NotMapped]
        public string? Direccion { get; set; }
        [NotMapped]
        public int CantidadDias => (int)(FechaCheckOut - FechaCheckin).TotalDays;

    }
}
