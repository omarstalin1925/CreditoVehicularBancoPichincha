using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<IEnumerable<Ejecutivo>> ConsultarEjecutivos();
        Task<Ejecutivo> CrearEjecutivo(Ejecutivo ejecutivo);
        Task<Ejecutivo> BuscarEjecutivo(string identificacion);
    }
}