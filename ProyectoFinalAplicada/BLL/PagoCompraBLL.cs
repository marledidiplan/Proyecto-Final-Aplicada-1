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
    public class PagoCompraBLL
    {
        public static bool Guardar(PagoCompra pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.pagoCompras.Add(pago) != null)
                {
                    contexto.sublidors.Find(pago.SuplidorId).CuentasPorPagar -= pago.MontoPagar;
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

        public static bool Modificar(PagoCompra pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

               
                PagoCompra pagoC = Buscar(pago.PagoCompraId);

                var TotalSupli = contexto.sublidors.Find(pago.SuplidorId);
                var TotalSupliAnt = contexto.sublidors.Find(pagoC.SuplidorId);

                if (pagoC.SuplidorId != pago.SuplidorId)
                {
                    TotalSupli.CuentasPorPagar += pago.MontoPagar;
                    TotalSupliAnt.CuentasPorPagar -= pagoC.MontoPagar;
                    SuplidorBLL.Modificar(TotalSupli);
                    SuplidorBLL.Modificar(TotalSupliAnt);
                }

                PagoCompra pagoCompra = Buscar(pago.PagoCompraId);
                float desigualdad = pago.MontoPagar - pagoCompra.MontoPagar;
                var pagos = contexto.sublidors.Find(pago.SuplidorId);
                pagos.CuentasPorPagar += desigualdad;
                SuplidorBLL.Modificar(pagos);

                contexto.Entry(pago).State = EntityState.Modified;
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

        public static PagoCompra Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagoCompra pago = new PagoCompra();

            try
            {
                pago = contexto.pagoCompras.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            PagoCompra pago = new PagoCompra();
            try
            {
                pago = contexto.pagoCompras.Find(id);
                contexto.sublidors.Find(pago.SuplidorId).CuentasPorPagar += pago.MontoPagar;
                contexto.pagoCompras.Remove(pago);
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

        public static List<PagoCompra> GetList(Expression<Func<PagoCompra, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<PagoCompra> pago = new List<PagoCompra>();

            try
            {
                pago = contexto.pagoCompras.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }
        //public static float CalcularMonto(float CantidadDinero , float merca)
        //{
        //    return CantidadDinero * merca;
        //}
    }
}
