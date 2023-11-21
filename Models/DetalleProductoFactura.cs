namespace HotelManager.Models
{
    public class DetalleProductoFactura
    {
        public Guid IDDetalleFactura { get; set; }
        public Guid IDFactura { get; set; }
        public Guid IDProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotalLinea { get; set; }

        // Relaciones
        public EncabezadoFactura EncabezadoFactura { get; set; }
        public Producto Producto { get; set; }
    }
}
