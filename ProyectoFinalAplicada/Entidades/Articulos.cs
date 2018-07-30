using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
        public float Ganancia { get; set; }
        public int Inventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Precio = 0f;
            Costo = 0f;
            Ganancia = 0f;
            Inventario = 0;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
