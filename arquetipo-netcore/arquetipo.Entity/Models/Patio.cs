using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace arquetipo.Entity.Models
{
    public partial class Patio
    {
        //public Patio()
        //{
        //    Clientes = new HashSet<Cliente>();
        //    Ejecutivos = new HashSet<Ejecutivo>();
        //    Vehiculos = new HashSet<Vehiculo>();
        //}

        public int PatioId { get; set; }

        //[Required(ErrorMessage = "El campo {1} es requerido")]
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int NumeroPuntoVenta { get; set; }

        //public virtual ICollection<Cliente> Clientes { get; set; }
        //public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
        //public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
