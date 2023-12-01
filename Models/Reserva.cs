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

        // Create
        [NotMapped] // Esta propiedad no será mapeada a la base de datos
        public int CantidadDias => (int)(FechaCheckOut - FechaCheckin).TotalDays;

    }
}
