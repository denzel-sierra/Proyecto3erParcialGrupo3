namespace Proyecto3erParcialGrupo3.Models
{
    public class Citas
    {
        public int IDCita { get; set; }
        public int IDUsuario { get; set; }
        public int IDEmpleado { get; set; }
        public DateTime FechaHoraCita { get; set; }
        public string EstadoCita { get; set; }
        // PRUEBA

        // Relaciones
        public Usuario Usuario { get; set; }
    }
}
