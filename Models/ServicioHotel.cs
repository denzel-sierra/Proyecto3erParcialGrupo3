namespace HotelManager.Models
{
    public class ServicioHotel
    {
        public Guid IDServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public decimal Tarifa { get; set; }

        // Relaciones
        public ICollection<DetalleServicioFactura> DetalleServicioFacturas { get; set; }
    }
}
