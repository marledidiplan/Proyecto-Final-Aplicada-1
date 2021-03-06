﻿using System;

using System.ComponentModel.DataAnnotations;
namespace Entidades
{
   public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaIngreso { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Contrasena = string.Empty;
            FechaIngreso = DateTime.Now;
        }
        public Usuarios(string nombre, string contrasena)
        {
            this.Nombre = nombre;
            this.Contrasena = contrasena;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
