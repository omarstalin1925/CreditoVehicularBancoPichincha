using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        //private object servicio;

        private readonly IPatio servicio;

        public PatioController(IPatio _servicio)
        {

            servicio = _servicio;

        }

        // GET: api/Patio
        [HttpGet]
        public async Task<IEnumerable<Patio>> ConsultarPatios()
        {
            return await servicio.ConsultarPatios();
        }

        [HttpPost]
        public async Task<Patio> CrearPatio(Patio cliente)
        {
            return await servicio.CrearPatio(cliente);
        }


        [HttpPost("EditarPatio")]
        public async Task<Patio> EditarPatio(Patio cliente)
        {
            return await servicio.EditarPatio(cliente);
        }

        [HttpDelete]
        public async Task<Patio> EliminarPatio(int id)
        {
            return await servicio.EliminarPatio(id);
        }
    }
}
