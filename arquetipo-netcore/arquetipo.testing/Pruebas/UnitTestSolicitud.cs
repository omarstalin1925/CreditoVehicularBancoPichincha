using arquetipo.API.Controllers;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using arquetipo.testing.Config;
using arquetipo.testing.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace arquetipo.testing.Pruebas
{
    [TestClass]
    public class UnitTestSolicitud
    {
        public ISolicitud servicio;

        [TestMethod]
        public async Task CrearSolicitud()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new SolicitudServiceMock(context);
            var controller = new SolicitudController(servic);

            Solicitud nuevaSolicitud = new Solicitud
            {
                ClienteId = 1,
                PatioId = 1,
                VehiculoId = 1,
                EjecutivoId = 1,
                FechaElaboracion = System.DateTime.Now,
                Estado = "R",
                MesesPlazo = 12,
                Cuotas = 30,
                Entrada = 400,
                Observacion = "pruebas"
            };

            var respuesta = await controller.CrearSolicitud(nuevaSolicitud);
            var cantidad = await context.Solicituds.CountAsync();
            Assert.AreEqual(1, cantidad);
        }

    }
}