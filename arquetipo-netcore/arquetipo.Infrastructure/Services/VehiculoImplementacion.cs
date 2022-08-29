using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class VehiculoImplementacion : IVehiculo
    {
        private readonly BlogContext _context;

        public VehiculoImplementacion(BlogContext context)
        {
            _context = context;
        }

       

        public async Task<IEnumerable<Vehiculo>> ConsultarVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            var veh = await BuscarVehiculo(vehiculo.Placa);
            if (veh == null)
            {
                await _context.AddAsync(vehiculo);
                _context.SaveChanges();
                return vehiculo;
            }
            else
            {
                throw new ExMessage("El vehiculo ya existe");
            }
        }

        public async Task<Vehiculo> EditarVehiculo(Vehiculo vehiculo)
        {
            var veh = await BuscarVehiculo(vehiculo.Placa);
            if (veh == null)
            {
                _context.Update(vehiculo);
                _context.SaveChanges();
                return vehiculo;
            }
            else
            {
                throw new ExMessage("El vehiculo ya existe");
            }
        }

        public async Task<Vehiculo> EliminarVehiculo(string placa)
        {
            var veh = await BuscarVehiculo(placa);
            if (veh != null)
            {
                _context.Remove(veh);
                _context.SaveChanges();
                return veh;
            }
            else
            {
                throw new ExMessage("El vehiculo no existe");
            }
        }
        public async Task<Vehiculo> BuscarVehiculo(string placa)
        {
            var cli = await _context.Vehiculos.Where(f => f.Placa.Equals(placa)).FirstOrDefaultAsync();
            return cli;
        }

    }
}