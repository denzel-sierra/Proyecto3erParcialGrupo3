using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class EncabezadoFactura
    {
        public Guid IDFactura { get; set; }
        public Guid IDCorrelativoSAR { get; set; }
        public Guid IDReserva {  get; set; }
        public string? IDEmpleado { get; set; }
        public string IDUsuario { get; set; }
        public int NumeroFacturaSAR { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal SubTotalFactura { get; set; }
        public decimal? DescuentoFactura { get; set; }
        public decimal ImpuestoFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public bool Eliminada { get; set; }

        // Relaciones
        public CorrelativoSAR CorrelativoSAR { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Reserva Reserva { get; set; }

    }
}
