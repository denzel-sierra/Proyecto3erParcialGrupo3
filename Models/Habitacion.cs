namespace HotelManager.Models
{
    public class Habitacion
    {
        public Guid IDHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal Tarifa { get; set; }
        public bool Disponibilidad { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; }
    }
}
