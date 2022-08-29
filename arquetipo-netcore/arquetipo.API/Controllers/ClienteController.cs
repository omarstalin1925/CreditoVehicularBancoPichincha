using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //private object servicio;

        private readonly ICliente servicio;

        public ClienteController(ICliente _servicio)
        {

            servicio = _servicio;

        }

       

        // GET: api/Cliente
        [HttpGet]
        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return await servicio.ConsultarClientes();
        }

        [HttpPost]
        public async Task<Cliente> CrearCliente([FromBody] Cliente cliente)
        {
            try
            {

                return await servicio.CrearCliente(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost("EditarCliente")]
        public async Task<Cliente> EditarCliente(Cliente cliente)
        {
            return await servicio.EditarCliente(cliente);
        }

        [HttpPost("AsignarClientePatio")]
        public async Task<Cliente> AsignarClientePatio(Cliente cliente)
        {
            return await servicio.AsignarClientePatio(cliente);
        }

        [HttpPost("EliminarAsignacionClientePatio")]
        public async Task<Cliente> EliminarAsignacionClientePatio(Cliente cliente)
        {
            return await servicio.EliminarAsignacionClientePatio(cliente);
        }

        [HttpDelete]
        public async Task<Cliente> EliminarCliente(string identificacion)
        {
            return await servicio.EliminarCliente(identificacion);
        }

        [HttpPost("CargarArchivoClientes")]
        public async Task CargarArchivoClientes()
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\BANCO PICHINCHA\clientes.csv"))
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        Cliente cliente = new Cliente();
                        cliente.Identificacion = values[0];
                        cliente.Nombres = values[1];
                        cliente.Apellidos = values[2];
                        cliente.Edad = Convert.ToInt32(values[3]);
                        cliente.FechaNacimiento = Convert.ToDateTime(values[4]);
                        cliente.Direccion = values[5];
                        cliente.Telefono = values[6];
                        cliente.EstadoCivil = values[7];
                        cliente.IdentificacionConyuge = values[8];
                        cliente.NombreConyuge = values[9];
                        cliente.SujetoCredito = values[10];
                        await servicio.CrearCliente(cliente);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
