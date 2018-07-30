using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAplicada.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;
using System.Linq.Expressions;

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
        public void GetListTest(Expression<Func<Articulos, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Articulos> articulo = new List<Articulos>();
            articulo = contexto.articulos.Where(expression).ToList();
            Assert.IsNotNull(articulo);
        }
    }
}