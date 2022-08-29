using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EjecutivoController : ControllerBase
    {
        private readonly IEjecutivo servicio;
        public EjecutivoController(IEjecutivo _servicio)
        {
            servicio = _servicio;
        }

        //GET: api/Ejecutivo
        [HttpGet]
        public async Task<IEnumerable<Ejecutivo>> ConsultarEjecutivos()
        {
            return await servicio.ConsultarEjecutivos();
        }

        [HttpPost("CargarArchivoEjecutivos")]
        public async Task CargarArchivoEjecutivos()
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\BANCO PICHINCHA\Ejecutivos.csv"))
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        Ejecutivo ejecutivo = new Ejecutivo();
                        ejecutivo.PatioId = Convert.ToInt32(values[0]);
                        ejecutivo.Identificacion = values[1];
                        ejecutivo.Nombres = values[2];
                        ejecutivo.Apellidos = values[3];
                        ejecutivo.Edad = Convert.ToInt32(values[4]);
                        ejecutivo.Celular = values[5];
                        ejecutivo.Direccion = values[6];
                        ejecutivo.TelefonoConvencional = values[7];
                        await servicio.CrearEjecutivo(ejecutivo);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
