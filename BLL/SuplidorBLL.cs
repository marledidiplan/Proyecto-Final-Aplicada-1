using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Entidades;
using DAL;

namespace BLL
{
  public class SuplidorBLL
    {
        public static bool Guardar(Suplidor sublidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.sublidors.Add(sublidor) != null)
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

        public static bool Modificar(Suplidor sublidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(sublidor).State = EntityState.Modified;
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

        public static Suplidor Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidor sublidor = new Suplidor();

            try
            {
                sublidor = contexto.sublidors.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return sublidor;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Suplidor sublidor = new Suplidor();
            try
            {
                sublidor = contexto.sublidors.Find(id);
                contexto.sublidors.Remove(sublidor);
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

        public static List<Suplidor> GetList(Expression<Func<Suplidor, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Suplidor> sublidor = new List<Suplidor>();

            try
            {
                sublidor = contexto.sublidors.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return sublidor;
        }

    }
}
