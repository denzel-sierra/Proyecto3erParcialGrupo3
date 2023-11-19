namespace Proyecto3erParcialGrupo3.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<EncabezadoFactura> Facturas { get; set; }
        public ICollection<Citas> Citas { get; set; }
    }
}
