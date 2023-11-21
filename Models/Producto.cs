namespace HotelManager.Models
{
    public class Producto
    {
        public Guid IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Existencias { get; set; }

        // Relaciones
        public ICollection<DetalleProductoFactura> DetalleProductoFacturas { get; set; }
    }
}
