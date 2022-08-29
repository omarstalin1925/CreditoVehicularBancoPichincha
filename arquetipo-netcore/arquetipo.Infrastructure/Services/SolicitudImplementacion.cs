using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class SolicitudImplementacion : ISolicitud
    {
        private readonly BlogContext _context;

        public SolicitudImplementacion(BlogContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Solicitud>> ConsultarSolicitudes()
        {
            return await _context.Solicituds.ToListAsync();
        }

        public async Task<Solicitud> CrearSolicitud(Solicitud solicitud)
        {
            var sol = await BuscarSolicitudActual(solicitud.ClienteId);
            var veh = await BuscarVehiculoPorEstado(solicitud.VehiculoId);
            if (sol == null) //si no hay solicitudes del dia
            {
                if (veh == null)//si el vehiculo no esta en otra solicitud
                {
                    var per = await _context.AddAsync(solicitud);
                    _context.SaveChanges();
                    return solicitud;
                }
                else
                {
                    throw new ExMessage("El vehiculo se encuentra en reserva");

                }

            }
            else
            {
                throw new ExMessage("El cliente ya tiene registrada una solicitud para el dia de hoy");
            }
        }

        public async Task<Solicitud> BuscarSolicitudActual(int idCliente)
        {
            var fechaHoy = DateTime.Now.ToString("dd-MM-yyyy");
            var sol = await _context.Solicituds.
                Where(f => f.FechaElaboracion == Convert.ToDateTime(fechaHoy)
                && f.ClienteId == idCliente).FirstOrDefaultAsync();
            return sol;
        }

        public async Task<Solicitud> BuscarVehiculoPorEstado(int idVehiculo)
        {
            //buscar solicitudes en estado registrado dado el codigo de un vehiculo
            var veh = await _context.Solicituds.
                Where(f => f.Estado == "R" && f.VehiculoId == idVehiculo).FirstOrDefaultAsync();
            return veh;
        }
    }
}