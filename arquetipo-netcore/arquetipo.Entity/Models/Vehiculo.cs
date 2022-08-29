using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Models
{
    public partial class Vehiculo
    {
        public int VehiculoId { get; set; }
        public int PatioId { get; set; }
        public int MarcaId { get; set; }
        public string Placa { get; set; } = null!;
        public string NumeroChasis { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string? Tipo { get; set; }
        public string Cilindraje { get; set; } = null!;
        public decimal Avaluo { get; set; }

        //public virtual Marca Marca { get; set; } = null!;
        //public virtual Patio Patio { get; set; } = null!;
    }
}
