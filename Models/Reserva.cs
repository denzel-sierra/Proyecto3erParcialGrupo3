namespace HotelManager.Models
{
    public class Reserva
    {
        public Guid IDReserva { get; set; }
        public Guid? IDUsuario { get; set; }
        public Guid IDHabitacion { get; set; }
        public Guid IDFactura { get; set; }
        public DateTime FechaCheckin { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string EstadoReserva { get; set; }

        // Relaciones
        public Habitacion Habitacion { get; set; }
        public EncabezadoFactura EncabezadoFactura { get; set; }
    }
}
