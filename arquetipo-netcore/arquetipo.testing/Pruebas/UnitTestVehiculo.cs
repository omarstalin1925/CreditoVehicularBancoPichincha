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
    public class UnitTestVehiculo
    {
        public IVehiculo servicio;

        [TestMethod]
        public async Task CrearVehiculo()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new VehiculoServiceMock(context);
            var controller = new VehiculoController(servic);

            Vehiculo nuevoVehiculo = new Vehiculo
            {
                PatioId=1,
                MarcaId=1,
                Placa="HGB5595",
                NumeroChasis="sdsds",
                Modelo="2022",
                Tipo="sedan",
                Cilindraje="12",
                Avaluo=12000
            };

            var respuesta = await controller.CrearVehiculo(nuevoVehiculo);
            var cantidad = await context.Vehiculos.CountAsync();
            Assert.AreEqual(1, cantidad);
        }

        [TestMethod]
        public async Task EditarVehiculo()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new VehiculoServiceMock(context);
            var controller = new VehiculoController(servic);

            Vehiculo editVehiculo = new Vehiculo
            {
                PatioId = 1,
                MarcaId = 1,
                Placa = "HGB5595",
                NumeroChasis = "aaasdsds",
                Modelo = "2022",
                Tipo = "sedan",
                Cilindraje = "12",
                Avaluo = 12000
            };

            var respuesta = await controller.EditarVehiculo(editVehiculo);
            var veh = await context.Vehiculos.FirstOrDefaultAsync(x => x.Placa=="HGB5595");
            Assert.AreEqual("HGB5595", veh.Placa);
        }

        [TestMethod]
        public async Task ConsultarPatios()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new VehiculoServiceMock(context);
            var controller = new VehiculoController(servic);

            var respuesta = await controller.ConsultarVehiculos();
            var cantidad = await context.Vehiculos.CountAsync();
            Assert.AreEqual(3, cantidad);
        }

        [TestMethod]
        public async Task EliminarVehiculo()
        {
            var context = ApplicationDbContextInMemory.Get();
            var servic = new VehiculoServiceMock(context);
            var controller = new VehiculoController(servic);

            Vehiculo nuevoVehiculo = new Vehiculo
            {
                PatioId = 1,
                MarcaId = 1,
                Placa = "HGB5595",
                NumeroChasis = "sdsds",
                Modelo = "2022",
                Tipo = "sedan",
                Cilindraje = "12",
                Avaluo = 12000
            };


            await controller.CrearVehiculo(nuevoVehiculo);
            var veh = await context.Vehiculos.FirstOrDefaultAsync(x => x.Placa == "HGB5595");
            await controller.EliminarVehiculo(veh.Placa);
            var cantidad = await context.Vehiculos.CountAsync();
            Assert.AreEqual(0, cantidad);
        }

    }
}