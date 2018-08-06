
using System.ComponentModel.DataAnnotations;

namespace Entidades
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
        public int CuentasPorPagar { get; set; }


        public Suplidor()
        {
            SuplidorId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            CuentasPorPagar = 0;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
