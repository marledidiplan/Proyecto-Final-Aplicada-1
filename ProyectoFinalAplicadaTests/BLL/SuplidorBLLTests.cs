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
    public class SuplidorBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Suplidor suplidor = new Suplidor();
            bool paso;
            suplidor.SuplidorId = 2;
            suplidor.Nombre = "Maria";
            suplidor.Cedula = "00000000000";
            suplidor.Direccion = "Bani";
            suplidor.Telefono = "1111111111";
            suplidor.Email = "maria@gmail.com";
            paso = SuplidorBLL.Guardar(suplidor);
             Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Suplidor suplidor = new Suplidor();
            bool paso;
            suplidor.SuplidorId = 2;
            suplidor.Nombre = "Juan";
            suplidor.Cedula = "00100000000";
            suplidor.Direccion = "Bani";
            suplidor.Telefono="10000000000";
            suplidor.Email = "juan@gmail.com";
            paso = SuplidorBLL.Modificar(suplidor);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Suplidor suplidor = new Suplidor();
            int id = 1;
            suplidor = SuplidorBLL.Buscar(id);
            Assert.IsNotNull(suplidor);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 2;
            bool paso;
            paso = SuplidorBLL.Eliminar(id);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var suplidor = SuplidorBLL.GetList(x => true);
            Assert.IsNotNull(suplidor);
        }
    }
}