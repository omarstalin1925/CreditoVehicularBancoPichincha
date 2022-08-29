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
    public class UnitTestMarca
    {
        public IMarca servicio;

        [TestMethod]
        public async Task CrearMarca()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new MarcaServiceMock(context);
            var controller = new MarcaController(servic);

           await controller.CargarArchivo();
            var cantidad = await context.Marcas.CountAsync();
            Assert.AreEqual(7, cantidad);
        }

    }
}