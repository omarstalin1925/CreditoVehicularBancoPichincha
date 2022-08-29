using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IVehiculo    
    {
       Task<IEnumerable<Vehiculo>> ConsultarVehiculos();
        Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> EditarVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> EliminarVehiculo(string placa);
        Task<Vehiculo> BuscarVehiculo(string placa);

    }
}