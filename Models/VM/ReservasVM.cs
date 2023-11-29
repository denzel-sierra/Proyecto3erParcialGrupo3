using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManager.Models.VM
{
    public class ReservasVM
    {
        public Guid IDReserva { get; set; }
        public Guid? IDUsuario { get; set; }
        public Guid IDHabitacion { get; set; }
        public Guid? IDFactura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCheckOut { get; set; }
        public string EstadoReserva { get; set; }

        // Puedes agregar otras propiedades según sea necesario
        public HabitacionesVM Habitacion { get; set; }
        public double CantidadDias { get; set; }
    }
}
