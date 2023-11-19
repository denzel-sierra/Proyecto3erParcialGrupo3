﻿namespace Proyecto3erParcialGrupo3.Models
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
        public EncabezadoFactura Factura { get; set; }
        public Productos Producto { get; set; }
    }
}
