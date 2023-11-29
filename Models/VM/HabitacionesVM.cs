using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.VM
{
    public class HabitacionesVM
    {
        public Guid IDHabitacion { get; set; }
        public int Numero { get; set; }
        public string TipoHabitacion { get; set; }
        public decimal Tarifa { get; set; }
        public bool Disponibilidad { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ReservasVM> Reservas { get; set; }
    }
}
