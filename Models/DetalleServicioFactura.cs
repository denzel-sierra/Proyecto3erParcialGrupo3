namespace HotelManager.Models
{
    public class DetalleServicioFactura
    {
        public Guid IDDetalleFactura { get; set; }
        public Guid IDFactura { get; set; }
        public Guid IDServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotalLinea { get; set; }
    }
}
