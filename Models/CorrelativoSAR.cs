﻿namespace Proyecto3erParcialGrupo3.Models
{
    public class CorrelativoSAR
    {
        public Guid IDCorrelativoSAR { get; set; }
        public string NumeroCAI { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }
        public int UltimoUtilizado { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool Finalizado { get; set; }


        // Relaciones
        public ICollection<EncabezadoFactura> Facturas { get; set; }
    }
}