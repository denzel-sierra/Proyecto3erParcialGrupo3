﻿namespace HotelManager.Models
{
    public class DetalleServicioFactura
    {
        public int IDDetalleFactura { get; set; }
        public int IDFactura { get; set; }
        public int IDServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotalLinea { get; set; }

        // Relaciones
        public EncabezadoFactura Factura { get; set; }
        public ServicioHotel ServicioHotel { get; set; }
    }
}