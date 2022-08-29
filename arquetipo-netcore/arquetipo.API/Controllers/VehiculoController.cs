using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        //private object servicio;

        private readonly IVehiculo servicio;

        public VehiculoController(IVehiculo _servicio)
        {

            servicio = _servicio;

        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<IEnumerable<Vehiculo>> ConsultarVehiculos()
        {
            return await servicio.ConsultarVehiculos();
        }

        [HttpPost]
        public async Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            return await servicio.CrearVehiculo(vehiculo);
        }


        [HttpPost("EditarCliente")]
        public async Task<Vehiculo> EditarVehiculo(Vehiculo vehiculo)
        {
            return await servicio.EditarVehiculo(vehiculo);
        }

        [HttpDelete]
        public async Task<Vehiculo> EliminarVehiculo(string placa)
        {
            return await servicio.EliminarVehiculo(placa);
        }
    }
}
