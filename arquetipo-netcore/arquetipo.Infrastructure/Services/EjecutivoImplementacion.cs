using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class EjecutivoImplementacion : IEjecutivo
    {
        private readonly BlogContext _context;

        public EjecutivoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ejecutivo>> ConsultarEjecutivos()
        {
            return await _context.Ejecutivos.ToListAsync();
        }

        public async Task<Ejecutivo> CrearEjecutivo(Ejecutivo ejecutivo)
        {
            var ejec = await BuscarEjecutivo(ejecutivo.Identificacion);
            if (ejec == null)
            {
                await _context.AddAsync(ejecutivo);
                _context.SaveChanges();
                return ejecutivo;
            }
            else
            {
                throw new ExMessage("El Ejecutivo ya existe");
            }
        }

        public async Task<Ejecutivo> BuscarEjecutivo(string identificacion)
        {
            var ejec = await _context.Ejecutivos.Where(f => f.Identificacion==identificacion).FirstOrDefaultAsync();
            return ejec;
        }
    }
}