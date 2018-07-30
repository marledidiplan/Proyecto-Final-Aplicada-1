using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ProyectoFinalAplicada.Entidades;

namespace ProyectoFinalAplicada.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Suplidor> sublidors { get; set; }
        public DbSet<Articulos> articulos { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<PagoCompra> pagoCompras { get; set; }


        public Contexto() : base("ConStr")
        {

        }
    }
}
