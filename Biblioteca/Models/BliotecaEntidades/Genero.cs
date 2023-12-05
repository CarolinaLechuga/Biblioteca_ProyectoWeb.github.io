using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Genero
    {
        [Key]
        public int GeneroID { get; set; }
        public string NombreGenero { get; set; }

    }
}