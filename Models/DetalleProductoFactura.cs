﻿namespace Proyecto3erParcialGrupo3.Models
{
    public class DetalleProductoFactura
    {
        public int IDDetalleFactura { get; set; }
        public int IDFactura { get; set; }
        public int IDProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotalLinea { get; set; }
    }
}
