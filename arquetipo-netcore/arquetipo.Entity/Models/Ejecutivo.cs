using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Models
{
    public partial class Ejecutivo
    {
        public int EjecutivoId { get; set; }
        public int PatioId { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public string Celular { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string TelefonoConvencional { get; set; } = null!;

        public virtual Patio Patio { get; set; } = null!;
    }
}
