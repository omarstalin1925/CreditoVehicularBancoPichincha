using arquetipo.Entity.Models;

namespace arquetipo.Domain.Interfaces
{
    public interface ISolicitud
    {
        Task<IEnumerable<Solicitud>> ConsultarSolicitudes();
        Task<Solicitud> CrearSolicitud(Solicitud solicitud);
        Task<Solicitud> BuscarSolicitudActual(int idCliente);
        Task<Solicitud> BuscarVehiculoPorEstado(int idVehiculo);


    }
}