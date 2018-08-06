using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entidades;
using BLL;
using DAL;

namespace ProyectoFinalAplicada.BLL.Tests
{
    [TestClass()]
    public class ArticuloBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 2;
            articulo.Descripcion = "Pan";
            articulo.Precio = 50;
            articulo.Costo = 30;
            articulo.Ganancia = 10;
            articulo.Inventario = 0;
            paso = ArticuloBLL.Guardar(articulo);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {

            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 2;
            articulo.Descripcion = "Pan";
            articulo.Precio = 100;
            articulo.Costo = 30;
            articulo.Ganancia = 45;
            articulo.Inventario = 0; 
            paso = ArticuloBLL.Modificar(articulo);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Articulos articulo = new Articulos();
            int id = 1;
            articulo = ArticuloBLL.Buscar(id);
            Assert.IsNotNull(articulo);

            
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 2;
            paso = ArticuloBLL.Eliminar(id);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var articulo = ArticuloBLL.GetList(x => true);
            Assert.IsNotNull(articulo);
        }
    }
}