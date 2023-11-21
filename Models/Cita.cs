namespace HotelManager.Models
{
    public class Cita
    {
        public Guid IDCita { get; set; }
        public Guid IDUsuario { get; set; }
        public Guid IDEmpleado { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public string EstadoCita { get; set; }
        // PRUEBA

        // Relaciones
    }
}
