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
    public class MarcaServiceMock : IMarca
    {

        private readonly BlogContext _context;

        public MarcaServiceMock(BlogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Marca>> ConsultarMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> CrearMarca(Marca marca)
        {
            var mar = await BuscarMarca(marca.Descripcion);
            if (mar == null)
            {
                await _context.AddAsync(marca);
                _context.SaveChanges();
                return marca;
            }
            else
            {
                throw new ExMessage("La marca ya existe");
            }
        }

        public async Task<Marca> BuscarMarca(string descripcion)
        {
            var mar = await _context.Marcas.Where(f => f.Descripcion == descripcion).FirstOrDefaultAsync();
            return mar;
        }

    }
}
