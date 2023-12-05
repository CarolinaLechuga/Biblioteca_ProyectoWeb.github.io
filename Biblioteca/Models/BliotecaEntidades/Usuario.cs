using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }

        // Clave externa
        public int RolID { get; set; }
        public Rol Rol { get; set; }
    }
}