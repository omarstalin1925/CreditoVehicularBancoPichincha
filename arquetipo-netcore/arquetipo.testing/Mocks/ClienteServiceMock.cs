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
    public class ClienteServiceMock : ICliente
    {

        private readonly BlogContext _context;

        public ClienteServiceMock(BlogContext context)
        {
            _context = context;
        }
        public Task<Cliente> AsignarClientePatio(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> BuscarCliente(string identificacion)
        {
            var cli = await _context.Clientes.Where(f => f.Identificacion.Equals(identificacion)).FirstOrDefaultAsync();
            return cli;
        }

        public Task<Patio> BuscarPatio(int idPatio)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> CrearCliente(Cliente cliente)
        {
            var cli = await BuscarCliente(cliente.Identificacion);
            if (cli == null)
            {
                await _context.AddAsync(cliente);
                _context.SaveChanges();
                return cliente;
            }
            else
            {
                throw new ExMessage("El cliente ya existe");
            }
        }

        public async Task<Cliente> EditarCliente(Cliente cliente)
        {
            var cli = await BuscarCliente(cliente.Identificacion);
            if (cli == null)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return cliente;
            }
            else
            {
                throw new ExMessage("El cliente ya existe");
            }
        }

        public Task<Cliente> EliminarAsignacionClientePatio(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> EliminarCliente(string identificacion)
        {
            var cli = await BuscarCliente(identificacion);
            if (cli != null)
            {
                _context.Remove(cli);
                _context.SaveChanges();
                return cli;
            }
            else
            {
                throw new ExMessage("El cliente no existe");
            }
        }
    }
}
