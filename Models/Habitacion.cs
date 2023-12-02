namespace HotelManager.Models
{
    public class Habitacion
    {
        public Guid IDHabitacion { get; set; }
        public int Numero { get; set; }
        public Guid IDTipoHabitacion { get; set; }
        public decimal Tarifa { get; set; }
        public bool Disponibilidad { get; set; }

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
