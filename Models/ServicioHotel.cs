namespace Proyecto3erParcialGrupo3.Models
{
    public class ServicioHotel
    {
        public int IDServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public decimal Tarifa { get; set; }

        // Relaciones
        public ICollection<DetalleServicioFactura> DetallesFacturas { get; set; }
    }
}
