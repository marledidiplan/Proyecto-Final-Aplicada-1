using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using Entidades;
using BLL;

namespace ProyectoFinalAplicada.BLL.Tests
{
    [TestClass()]
    public class CompraBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Compra compra = new Compra();
            bool paso;
            compra.CompraId = 3;
            compra.Fecha = DateTime.Now;
            compra.Detalles.Add(new CompraDetalles(0, 0,  1, 3, 20, 5));
            compra.Detalles.Add(new CompraDetalles(0, 0,  4, 6, 10, 7));
            paso = CompraBLL.Guardar(compra);


            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalcularImporteTest()
        {
            Assert.Fail();
        }
    }
}