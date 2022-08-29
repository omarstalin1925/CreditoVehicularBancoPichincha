using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Models
{
    public partial class Cliente
    {
        //public Cliente()
        //{
        //    Solicituds = new HashSet<Solicitud>();
        //}

        public int ClienteId { get; set; }
        public int? PatioId { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string EstadoCivil { get; set; } = null!;
        public string IdentificacionConyuge { get; set; } = null!;
        public string NombreConyuge { get; set; } = null!;
        public string SujetoCredito { get; set; } = null!;
        public DateTime? FechaAsignacion { get; set; }
        //public virtual Patio Patio { get; set; } = null!;
        //public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
