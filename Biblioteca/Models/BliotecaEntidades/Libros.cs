using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Libros
    {

        [Key]
        public int LibroID { get; set; }
        public string Titulo { get; set; }
        // Clave externa
        public int AutorID { get; set; }
        public Autores Autor { get; set; }
        // Clave externa
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
        public string ISBN { get; set; }
        // Clave externa
        public int EditorialID {  get; set; }
        public Editorial Editorial { get; set; }
        public string Estado { get; set; }
    }
}