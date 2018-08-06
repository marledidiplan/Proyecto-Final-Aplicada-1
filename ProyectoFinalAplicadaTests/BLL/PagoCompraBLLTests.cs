using BLL;
using DAL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


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
            int id = 3;
            bool paso;
            paso = PagoCompraBLL.Eliminar(id);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<PagoCompra , bool>> expression)
        {
            List<PagoCompra> pagoCompras = new List<PagoCompra>();
            Contexto contexto = new Contexto();
            pagoCompras = contexto.pagoCompras.Where(expression).ToList();
            Assert.IsNotNull(pagoCompras);
        }
    }
}