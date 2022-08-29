using System;
using System.Collections.Generic;

namespace arquetipo.Entity.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int MarcaId { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
