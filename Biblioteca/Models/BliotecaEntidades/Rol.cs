using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Rol
    {
        [Key]
        public int rolID { get; set; }
        public string TipoRol { get; set; }

        // Navegación de la relación
        public List<Usuario> Usuarios { get; set; }
    }
}