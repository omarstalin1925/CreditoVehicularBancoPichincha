using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Models
{
    public partial class Solicitud
    {
        public int SolicitudId { get; set; }
        public int ClienteId { get; set; }
        public int PatioId { get; set; }
        public int VehiculoId { get; set; }
        public int EjecutivoId { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public string Estado { get; set; }
        public int MesesPlazo { get; set; }
        public int Cuotas { get; set; }
        public decimal Entrada { get; set; }
        public string? Observacion { get; set; }

        //public virtual Cliente Cliente { get; set; } = null!;
    }
}
