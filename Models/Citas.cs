namespace Proyecto3erParcialGrupo3.Models
{
    public class Citas
    {
        public Guid IDCita { get; set; }
        public Guid IDUsuario { get; set; }
        public Guid IDEmpleado { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public string EstadoCita { get; set; }
        // PRUEBA

        // Relaciones
        public Usuario Usuario { get; set; }
    }
}
