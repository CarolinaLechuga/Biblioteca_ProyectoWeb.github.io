using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Biblioteca.Models.BliotecaEnridades
{
    public class Autores
    {
        [Key]
        public int AutorID { get; set; }
        public string NombreAutor { get; set; }
        public string Nacionalidad { get; set; }

    }
}