using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoFinalAplicada.Entidades
{
    public class CompraDetalles
    {
        public int Id { get; set; }
        public int CompraDetalleId { get; set; }
        public int ArticuloId { get; set; }
        
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Importe { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulo { get; set; }

       

        public CompraDetalles()
        {
            Id = 0;
            CompraDetalleId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0f;
            Importe = 0f;
        }

        public CompraDetalles(int id, int compraDetalleId, int articuloId,  int cantidad, float precio, float importe)
        {
            this.Id = id;
            this.CompraDetalleId = compraDetalleId;
            this.ArticuloId = articuloId;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Importe = importe;
        }
    }
}
