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
    public class UnitTestEjecutivo
    {
        public IEjecutivo servicio;

        [TestMethod]
        public async Task CrearEjecutivo()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new EjecutivoServiceMock(context);
            var controller = new EjecutivoController(servic);

           await controller.CargarArchivoEjecutivos();
            var cantidad = await context.Ejecutivos.CountAsync();
            Assert.AreEqual(20, cantidad);
        }

    }
}