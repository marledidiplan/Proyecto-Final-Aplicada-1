using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using DAL;
using Entidades;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class EntradaBalanceBLL
    {
        public static bool Guardar(EntradaBalance entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.entradaBalances.Add(entrada) != null)
                {
                    contexto.balances.Find(entrada.BalanceId).Monto += entrada.Monto;
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

        public static bool Modificar(EntradaBalance entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(entrada).State = EntityState.Modified;
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

        public static EntradaBalance Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradaBalance entrada = new EntradaBalance();

            try
            {
                entrada = contexto.entradaBalances.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            EntradaBalance entrada = new EntradaBalance();
            try
            {
                entrada = contexto.entradaBalances.Find(id);
                contexto.entradaBalances.Remove(entrada);
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

        public static List<EntradaBalance> GetList(Expression<Func<EntradaBalance, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<EntradaBalance> entrada = new List<EntradaBalance>();

            try
            {
                entrada = contexto.entradaBalances.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }

    }
}
