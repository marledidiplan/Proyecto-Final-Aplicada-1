using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using DAL;
using Entidades;

namespace BLL
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
                    var balance = contexto.balances.Find(compra.BalanceId);
                    if (compra.Total == compra.General)
                    {
                        balance.Monto -= compra.Total;
                        
                    }
                    else
                    {
                        contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar+=compra.Total;
                        balance.Monto -= compra.BalanceC;

                    }
                    //contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar += compra.Total;
                    //contexto.balances.Find(compra.BalanceId).Monto -= compra.BalanceC;

                    
                    paso = contexto.SaveChanges()>0;
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
                var comprar = contexto.compras.Find(compra.CompraId);
                foreach (var item in comprar.Detalles)
                {
                    contexto.articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    if (!compra.Detalles.ToList().Exists(m => m.Id == item.Id))
                    {
                        contexto.articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                        // item.Articulo = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                var balance = contexto.balances.Find(compra.BalanceId);
                if (compra.Total == compra.General)
                {
                    balance.Monto -= compra.Total;
                    contexto.Entry(balance).State = EntityState.Modified;

                }
                else
                {
                    contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar += compra.Total;
                    balance.Monto -= compra.BalanceC;

                    var suplidorr = contexto.sublidors.Find(compra.SuplidorId);
                    int desigualdal = compra.Total + suplidorr.CuentasPorPagar;

                    Suplidor supli = contexto.sublidors.Find(compra.SuplidorId);
                    supli.CuentasPorPagar -= compra.Total;
                    SuplidorBLL.Modificar(supli);

                    Compra obtener = new Compra();
                    int disimilitud = compra.Total + obtener.Total;
                    Balance balanc = new Balance();
                    balanc.Monto += compra.BalanceC;
                    BalanceBLL.Buscar(disimilitud);

                }



                //var TotalSupli = contexto.sublidors.Find(compra.SuplidorId);
                //var TotalSupliAnt = contexto.sublidors.Find(comprar.SuplidorId);

                //if (comprar.SuplidorId != compra.SuplidorId)
                //{
                //    TotalSupli.CuentasPorPagar += compra.Total ;
                //    TotalSupliAnt.CuentasPorPagar -= comprar.Total ;
                //    //SuplidorBLL.Modificar(TotalSupli);
                //    //SuplidorBLL.Modificar(TotalSupliAnt);
                //}


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
            Suplidor suplidor = contexto.sublidors.Find(id);
            try
            {
                
                foreach (var item in compra.Detalles)
                {
                    var Articulos = contexto.articulos.Find(item.ArticuloId);
                    Articulos.Inventario -= item.Cantidad;
                }


                contexto.sublidors.Find(compra.SuplidorId).CuentasPorPagar -= compra.Total ;
                //pago.MontoPagar -= suplidor.CuentasPorPagar;
                //contexto.pagoCompras.Find(pago.SuplidorId).MontoPagar -= suplidor.CuentasPorPagar;
                    
         
               
                contexto.balances.Find(compra.BalanceId).Monto += compra.BalanceC;
                compra.Detalles.Count();

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
                foreach (var item in compra)
                {
                    item.Detalles.Count();
                }
                compra = contexto.compras.Where(expression).ToList();
               // contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return compra;
        }
        public static int CalcularImporte(int cantidad, int precio)
        {
            return precio * cantidad;
        }

        public static int CalcularDevuelta(int efectivo , int total)
        {
           return efectivo  - total;
        }
    }
}
