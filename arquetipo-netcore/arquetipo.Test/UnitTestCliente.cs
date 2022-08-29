using arquetipo.Entity.Models;
using arquetipo.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;

namespace arquetipo.Test;

[TestClass]
public class UnitTestCliente
{
    [TestMethod]
    public void Test1()
    {
        var context = ApplicationDbContextInMemory.Get();

        context.Clientes.Add(new Cliente
        {
            PatioId = 1,
            Identificacion = "0603888547",
            Nombres = "Katherine",
            Apellidos = "Pullupaxi",
            Edad = 30,
            Direccion = "Riobamba",
            Telefono = "098536254",
            EstadoCivil = "c",
            IdentificacionConyuge = "0603985478",
            NombreConyuge = "Omar Centeno",
            SujetoCredito = "s"
        });

        context.SaveChanges();
    }
}