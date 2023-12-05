using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Reservas
    {
        [Key]
        public int ReservaID { get; set; }

        // Claves externas
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public int LibroID { get; set; }
        public Libros Libro { get; set; }

        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }

    }
}