﻿using BLL;
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
    public class UsuarioBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso;
            usuario.UsuarioId = 2;
            usuario.Nombre = "Maria";
            usuario.Contrasena = "1234";
            usuario.FechaIngreso = DateTime.Now;
            paso = UsuarioBLL.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso;
            usuario.UsuarioId = 2;
            usuario.Nombre = "Juan";
            usuario.Contrasena = "1111";
            usuario.FechaIngreso = DateTime.Now;
            paso = UsuarioBLL.Modificar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Usuarios usuario = new Usuarios();
            usuario = UsuarioBLL.Buscar(id);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 2;
            bool paso;
            paso = UsuarioBLL.Eliminar(id);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var usuario = UsuarioBLL.GetList(x => true);
            Assert.IsNotNull(usuario);
        }
    }
}