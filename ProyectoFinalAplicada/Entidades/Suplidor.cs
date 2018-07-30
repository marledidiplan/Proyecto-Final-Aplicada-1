using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Entidades
{
    public class Suplidor
    {
        [Key]
        public int SuplidorId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public float CuentasPorPagar { get; set; }


        public Suplidor()
        {
            SuplidorId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            CuentasPorPagar = 0f;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
