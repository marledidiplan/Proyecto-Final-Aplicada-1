using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;

namespace ProyectoFinalAplicada.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.usuarios.Add(usuario) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario = new Usuarios();

            try
            {
                usuario = contexto.usuarios.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Usuarios usuario = new Usuarios();
            try
            {
                usuario = contexto.usuarios.Find(id);
                contexto.usuarios.Remove(usuario);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Usuarios> usuario = new List<Usuarios>();

            try
            {
                usuario = contexto.usuarios.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }


    }
}
