using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ProyectoFinalAplicada.BLL.Tests
{
    [TestClass()]
    public class PagoCompraBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            PagoCompra pagoCompra = new PagoCompra();
            bool paso;
            pagoCompra.PagoCompraId = 3;
            pagoCompra.Fecha = DateTime.Now;
            pagoCompra.MontoPagar = 10;
            paso = PagoCompraBLL.Guardar(pagoCompra);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            PagoCompra pagoCompra = new PagoCompra();
            bool paso;
            pagoCompra.PagoCompraId = 3;
            pagoCompra.Fecha = DateTime.Now;
            pagoCompra.MontoPagar = 12;
            paso = PagoCompraBLL.Modificar(pagoCompra);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            PagoCompra pagoCompra = new PagoCompra();
            int id = 2;
            pagoCompra = PagoCompraBLL.Buscar(id);
            Assert.IsNotNull(pagoCompra);

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
    }
}