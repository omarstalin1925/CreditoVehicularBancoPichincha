using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        //private object servicio;

        private readonly ISolicitud servicio;

        public SolicitudController(ISolicitud _servicio)
        {
            servicio = _servicio;
        }

        // GET: api/Solicitud
        [HttpGet]
        public async Task<IEnumerable<Solicitud>> ConsultarSolicitudes()
        {
            return await servicio.ConsultarSolicitudes();
        }

        [HttpPost]
        public async Task<Solicitud> CrearSolicitud(Solicitud solicitud)
        {
            return await servicio.CrearSolicitud(solicitud);
        }
    }
}
