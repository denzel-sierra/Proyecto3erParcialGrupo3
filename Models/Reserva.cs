namespace Proyecto3erParcialGrupo3.Models
{
    public class Reserva
    {
        public int IDReserva { get; set; }
        public int IDUsuario { get; set; }
        public int IDHabitacion { get; set; }
        public int IDFactura { get; set; }
        public DateTime FechaCheckin { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string EstadoReserva { get; set; }
    }
}
