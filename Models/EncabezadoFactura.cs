﻿namespace Proyecto3erParcialGrupo3.Models
{
    public class EncabezadoFactura
    {
        public Guid IDFactura { get; set; }
        public Guid IDCorrelativoSAR { get; set; }
        public Guid IDEmpleado { get; set; }
        public Guid IDUsuario { get; set; }
        public string NumeroFacturaSAR { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal SubTotalFactura { get; set; }
        public decimal DescuentoFactura { get; set; }
        public decimal ImpuestoFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public bool Eliminada { get; set; }

        // Relaciones
        public CorrelativosSAR CorrelativoSAR { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<DetalleProductoFactura> DetallesProductos { get; set; }
        public ICollection<DetalleServicioFactura> DetallesServicios { get; set; }
    }
}
