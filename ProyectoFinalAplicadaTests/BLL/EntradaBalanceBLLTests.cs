using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entidades;

namespace ProyectoFinalAplicada.BLL.Tests
{
    [TestClass()]
    public class EntradaBalanceBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            EntradaBalance entradaBalance = new EntradaBalance();
            entradaBalance.Fecha = DateTime.Now;
            entradaBalance.EntradaBalanceId = 4;
            entradaBalance.BalanceId = 1;
            entradaBalance.Monto = 100;
            paso = EntradaBalanceBLL.Guardar(entradaBalance);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            EntradaBalance entradaBalance = new EntradaBalance();
            entradaBalance.Fecha = DateTime.Now;
            entradaBalance.EntradaBalanceId = 4;
            entradaBalance.BalanceId = 1;
            entradaBalance.Monto = 200;
            paso = EntradaBalanceBLL.Modificar(entradaBalance);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            EntradaBalance entrada = new EntradaBalance();
            int id = 1;
            entrada = EntradaBalanceBLL.Buscar(id);
            Assert.IsNotNull(entrada);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 2;
            paso = EntradaBalanceBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var entrada = EntradaBalanceBLL.GetList(x => true);
            Assert.IsNotNull(entrada);
        }
    }
}