using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Helpers;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class ClienteImplementacion : ICliente
    {
        private readonly BlogContext _context;

        public ClienteImplementacion(BlogContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> CrearCliente(Cliente cliente)
        {
            try
            {
                var cli = await BuscarCliente(cliente.Identificacion);
                if (cli == null)
                {
                    var per = await _context.AddAsync(cliente);
                    _context.SaveChanges();
                    return cliente;
                }
                else
                {
                    throw new ExMessage("El cliente ya existe");
                }
            }
            catch (Exception ex)
            {

                throw ex;
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

        public async Task<Cliente> BuscarCliente(string identificacion)
        {
            var cli = await _context.Clientes.Where(f => f.Identificacion.Equals(identificacion)).FirstOrDefaultAsync();
            return cli;
        }

        public async Task<Cliente> AsignarClientePatio(Cliente cliente)
        {
            var cli = await BuscarCliente(cliente.Identificacion);
            var pat = await BuscarPatio(cliente.PatioId.Value);
            if (cli != null)
            {
                if (pat != null)
                {
                    cli.PatioId = cliente.PatioId;
                    cli.FechaAsignacion = cliente.FechaAsignacion;
                    _context.Update(cli);
                    _context.SaveChanges();
                    return cli;
                }
                else
                {
                    throw new ExMessage("El patio no existe");
                }
            }
            else
            {
                throw new ExMessage("El cliente no existe");
            }
        }

        public async Task<Cliente> EliminarAsignacionClientePatio(Cliente cliente)
        {
            var cli = await BuscarCliente(cliente.Identificacion);
            var pat = await BuscarPatio(cliente.PatioId.Value);
            if (cli != null)
            {
                if (pat != null)
                {
                    cli.PatioId = null;
                    cli.FechaAsignacion = null;
                    _context.Update(cli);
                    _context.SaveChanges();
                    return cli;
                }
                else
                {
                    throw new ExMessage("El patio no existe");
                }
            }
            else
            {
                throw new ExMessage("El cliente no existe");
            }
        }

        public async Task<Patio> BuscarPatio(int idPatio)
        {
            var pat = await _context.Patios.Where(f => f.PatioId == idPatio).FirstOrDefaultAsync();
            return pat;
        }
    }
}