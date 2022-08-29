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
    public class EjecutivoServiceMock : IEjecutivo
    {

        private readonly BlogContext _context;

        public EjecutivoServiceMock(BlogContext context)
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
            var ejec = await _context.Ejecutivos.Where(f => f.Identificacion == identificacion).FirstOrDefaultAsync();
            return ejec;
        }


    }
}
