using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> ConsultarClientes();
        Task<Cliente> CrearCliente(Cliente cliente);
        Task<Cliente> EditarCliente(Cliente cliente);
        Task<Cliente> EliminarCliente(string identificacion);
        Task<Cliente> BuscarCliente(string identificacion);
        Task<Patio> BuscarPatio(int idPatio);
        Task<Cliente> AsignarClientePatio(Cliente cliente);
        Task<Cliente> EliminarAsignacionClientePatio(Cliente cliente);

    }
}