using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.testing.Mocks
{
    public class VehiculoServiceMock : IVehiculo
    {

        private readonly BlogContext _context;

        public VehiculoServiceMock(BlogContext context)
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
