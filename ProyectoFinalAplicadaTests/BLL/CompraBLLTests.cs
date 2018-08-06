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
            compra.CompraId = 4;
            compra.UsuarioId = 1;
            compra.SuplidorId = 1;
            compra.BalanceC = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 100;
            compra.SubTotal = 75;
            compra.Itbis = 25;
            compra.BalanceC = 300;
            compra.Efectivo = 200;
            compra.Devuelta = 100;
            compra.General = 100;
            compra.TipoDePago = "Contado";
            paso = CompraBLL.Guardar(compra);
           

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Compra compra = new Compra();
            bool paso;
            compra.CompraId = 4;
            compra.UsuarioId = 1;
            compra.SuplidorId = 1;
            compra.BalanceC = 1;
            compra.Fecha = DateTime.Now;
            compra.Total = 150;
            compra.SubTotal = 125;
            compra.Itbis = 25;
            compra.BalanceC = 300;
            compra.Efectivo = 200;
            compra.Devuelta = 100;
            compra.General = 100;
            compra.TipoDePago = "Contado";
            paso = CompraBLL.Modificar(compra);


            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Compra compra = new Compra();
            int id = 1;
            compra = CompraBLL.Buscar(id);
            Assert.IsNotNull(compra);
        }

        [TestMethod()]
        public void EliminarTest()
        {

            bool paso;
            int id = 2;
            paso = CompraBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var comprass = CompraBLL.GetList(x => true);
            Assert.IsNotNull(comprass);
        }

        [TestMethod()]
        public void CalcularImporteTest()
        {
            Assert.Fail();
        }
    }
}