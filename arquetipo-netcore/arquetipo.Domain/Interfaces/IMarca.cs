using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface IMarca
    {
        Task<IEnumerable<Marca>> ConsultarMarcas();
        Task<Marca> CrearMarca(Marca marca);
        Task<Marca> BuscarMarca(string descripcion);
    }
}