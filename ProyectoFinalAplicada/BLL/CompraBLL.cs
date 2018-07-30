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
   public class CompraBLL
    {
        public static bool Guardar(Compra compra)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                if (contexto.compras.Add(compra) != null)
                {
                    foreach (var item in compra.Detalles)
                    {
                        contexto.articulos.Find(item.ArticuloId).Inventario += item.Cantidad;
                    }
                    contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar += compra.Total;
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

        public static bool Modificar(Compra compra)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var comprar = Buscar(compra.CompraId);

                var TotalSupli = contexto.sublidors.Find(compra.SuplidorId);
                var TotalSupliAnt = contexto.sublidors.Find(comprar.SuplidorId);

                if (comprar.SuplidorId != compra.SuplidorId)
                {
                    TotalSupli.CuentasPorPagar += compra.Total ;
                    TotalSupliAnt.CuentasPorPagar -= comprar.Total ;
                    SuplidorBLL.Modificar(TotalSupli);
                    SuplidorBLL.Modificar(TotalSupliAnt);
                }

                foreach (var item in comprar.Detalles)
                {
                    contexto.articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    if (!compra.Detalles.ToList().Exists(m => m.Id == item.Id ))
                    {
                        contexto.articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                        item.Articulo = null;
                        contexto.Entry(item).State = EntityState.Deleted; 
                    }
                }
                foreach (var item in compra.Detalles)
                {
                    contexto.articulos.Find(item.ArticuloId).Inventario += item.Cantidad;
                    var state = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = state;
                }



                contexto.Entry(compra).State = EntityState.Modified;
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

        public static Compra Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compra compra = new Compra();

            try
            {
                compra = contexto.compras.Find(id);

                if (compra != null)
                {
                    compra.Detalles.Count();
                    foreach (var item in compra.Detalles)
                    {
                        string a = item.ArticuloId.ToString();
                    }
                }
                //contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return compra;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Compra compra = contexto.compras.Find(id);
            PagoCompra pago = contexto.pagoCompras.Find(id);
            try
            {
                
                foreach (var item in compra.Detalles)
                {
                    var Articulos = contexto.articulos.Find(item.ArticuloId);
                    Articulos.Inventario -= item.Cantidad;
                }
                contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar -= pago.MontoPagar;
                contexto.compras.Remove(compra);
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

        public static List<Compra> GetList(Expression<Func<Compra, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Compra> compra = new List<Compra>();

            try
            {
                compra = contexto.compras.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return compra;
        }
        public static float CalcularImporte(float cantidad, float precio)
        {
            return precio * cantidad;
        }

    }
}
