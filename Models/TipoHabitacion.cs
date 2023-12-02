namespace HotelManager.Models
{
    public class TipoHabitacion
    {
        public Guid IDTipoHabitacion { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public ICollection<Habitacion>? Habitaciones { get; set; }

    }

}