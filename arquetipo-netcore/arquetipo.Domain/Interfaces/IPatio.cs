using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IPatio
    {
        Task<IEnumerable<Patio>> ConsultarPatios();
        Task<Patio> CrearPatio(Patio patio);
        Task<Patio> EditarPatio(Patio patio);
        Task<Patio> EliminarPatio(int id);
        Task<Patio> BuscarPatio(int id);
        Task<List<Cliente>> BuscarClientePorPatio(int id);
        Task<List<Ejecutivo>> BuscarEjecutivoPorPatio(int id);
        Task<List<Vehiculo>> BuscarVehiculoPorPatio(int id);

    }
}