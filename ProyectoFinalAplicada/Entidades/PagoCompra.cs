using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace ProyectoFinalAplicada.Entidades
{
    public class PagoCompra
    {
        [Key]

        public int PagoCompraId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; }
        public float MontoPagar { get; set; }
       
        public PagoCompra()
        {
            PagoCompraId = 0;
            SuplidorId = 0;
            Fecha = DateTime.Now;
            MontoPagar = 0f;
            
        }

    }
}
