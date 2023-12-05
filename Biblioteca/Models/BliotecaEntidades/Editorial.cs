using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Editorial
    {
        [Key]
        public int EditorialID { get; set; }
        public string NombreEditorial { get; set; }


    }
}
