using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Entidades
{
   public class Compra
    {
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public float SubTotal { get; set; }
        public float Itbis { get; set; }

        public virtual List<CompraDetalles> Detalles { get; set; }

        public Compra()
        {
            this.Detalles = new List<CompraDetalles>();
        }
        public void AgregarDetalle(int id, int compraDetalleId, int articuloId, int cantidad, float precio, float importe)
        {
            this.Detalles.Add(new CompraDetalles(id, compraDetalleId, articuloId, cantidad, precio, importe));
        }
    }
}
