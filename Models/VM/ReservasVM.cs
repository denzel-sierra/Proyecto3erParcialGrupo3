using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelManager.Models.VM
{
    public class ReservasVM
    {
        public Guid IDReserva { get; set; }

        
        public Guid? IDUsuario { get; set; }

       
        public Guid IDHabitacion { get; set; }

       
        public Guid IDFactura { get; set; }

        
        public DateTime FechaCheckin { get; set; }

       
        public DateTime FechaCheckOut { get; set; }

        public string EstadoReserva { get; set; }

        // Relaciones
        public HabitacionesVM Habitacion { get; set; }
        //public EncabezadoFacturaVM EncabezadoFactura { get; set; }
    }
}
