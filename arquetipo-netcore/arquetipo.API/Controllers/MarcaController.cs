using Microsoft.AspNetCore.Mvc;

using arquetipo.Entity.Models;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarca servicio;
        public MarcaController(IMarca _servicio)
        {
            servicio = _servicio;
        }

        //GET: api/Marca
       [HttpGet]
        public async Task<IEnumerable<Marca>> ConsultarMarcas()
        {
            return await servicio.ConsultarMarcas();
        }

        [HttpPost]
        public async Task CargarArchivo()
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"D:\BANCO PICHINCHA\marcas_vehiculo.csv"))
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values= line.Split(';');
                        Marca marca = new Marca();
                        marca.Descripcion=values[1];
                        await servicio.CrearMarca(marca);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
