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
    public class UnitTestPatio
    {
        public IPatio servicio;

        [TestMethod]
        public async Task CrearPatio()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new PatioServiceMock(context);
            var controller = new PatioController(servic);

            Patio nuevoPatio = new Patio
            {
                Nombre="rumipamba",
                NumeroPuntoVenta=1,
                Direccion="pruebas",
                Telefono="0895768947"
            };

            var respuesta = await controller.CrearPatio(nuevoPatio);
            var cantidad = await context.Patios.CountAsync();
            Assert.AreEqual(1, cantidad);
        }

        [TestMethod]
        public async Task EditarPatio()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new PatioServiceMock(context);
            var controller = new PatioController(servic);

            Patio editPatio = new Patio
            {
                Nombre = "rumipamba",
                NumeroPuntoVenta = 1,
                Direccion = "pruebas",
                Telefono = "0895768947"
            };

            var respuesta = await controller.EditarPatio(editPatio);
            var pat = await context.Patios.FirstOrDefaultAsync(x => x.Nombre=="rumipamba");
            Assert.AreEqual("rumipamba", pat.Nombre);
        }

        [TestMethod]
        public async Task ConsultarPatios()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new PatioServiceMock(context);
            var controller = new PatioController(servic);

            var respuesta = await controller.ConsultarPatios();
            var cantidad = await context.Patios.CountAsync();
            Assert.AreEqual(3, cantidad);
        }

        [TestMethod]
        public async Task EliminarPatio()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new PatioServiceMock(context);
            var controller = new PatioController(servic);

            Patio nuevoPatio = new Patio
            {
                Nombre = "rumipamba",
                NumeroPuntoVenta = 1,
                Direccion = "pruebas",
                Telefono = "0895768947"
            };

            await controller.CrearPatio(nuevoPatio);
            var pat = await context.Patios.FirstOrDefaultAsync(x => x.Nombre == "rumipamba");
            await controller.EliminarPatio(pat.PatioId);
            var cantidad = await context.Patios.CountAsync();
            Assert.AreEqual(0, cantidad);
        }

    }
}