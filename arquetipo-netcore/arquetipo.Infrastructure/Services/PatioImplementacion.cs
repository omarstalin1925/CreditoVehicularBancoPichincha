using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class PatioImplementacion : IPatio
    {
        private readonly BlogContext _context;

        public PatioImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patio>> ConsultarPatios()
        {
            return await _context.Patios.ToListAsync();
        }

        public async Task<Patio> CrearPatio(Patio patio)
        {
            var pat = await BuscarPatio(patio.PatioId);
            if (pat == null)
            {
                await _context.AddAsync(patio);
                _context.SaveChanges();
                return patio;
            }
            else
            {
                throw new ExMessage("El patio ya existe");
            }
        }

        public async Task<Patio> EditarPatio(Patio patio)
        {
            var pat = await BuscarPatio(patio.PatioId);
            if (pat == null)
            {
                _context.Update(patio);
                _context.SaveChanges();
                return patio;
            }
            else
            {
                throw new ExMessage("El patio ya existe");
            }
        }

        public async Task<Patio> EliminarPatio(int id)
        {
            var pat = await BuscarPatio(id);
            var cli = await BuscarClientePorPatio(id);
            var ejec = await BuscarEjecutivoPorPatio(id);
            var veh = await BuscarVehiculoPorPatio(id);
            if (pat != null)
            {
                if (cli.Count == 0 && ejec.Count == 0 && veh.Count == 0)
                {
                    _context.Remove(pat);
                    _context.SaveChanges();
                    return pat;
                }
                else
                {
                    throw new ExMessage("El patio no se puede eliminar porque tiene informacion asociada");
                }

            }
            else
            {
                throw new ExMessage("El patio no existe");
            }
        }

        public async Task<Patio> BuscarPatio(int id)
        {
            var pat = await _context.Patios.Where(f => f.PatioId.Equals(id)).FirstOrDefaultAsync();
            return pat;
        }

        public async Task<List<Cliente>> BuscarClientePorPatio(int id)
        {
            var cli = await _context.Clientes.Where(f => f.PatioId.Equals(id)).ToListAsync();
            return cli;
        }

        public async Task<List<Ejecutivo>> BuscarEjecutivoPorPatio(int id)
        {
            var ejec = await _context.Ejecutivos.Where(f => f.PatioId.Equals(id)).ToListAsync();
            return ejec;
        }

        public async Task<List<Vehiculo>> BuscarVehiculoPorPatio(int id)
        {
            var veh = await _context.Vehiculos.Where(f => f.PatioId.Equals(id)).ToListAsync();
            return veh;
        }
    }
}