namespace HotelManager.Models
{
    public class DetalleServicioFactura
    {
        public int Id { get; set; }
        public int producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
}
