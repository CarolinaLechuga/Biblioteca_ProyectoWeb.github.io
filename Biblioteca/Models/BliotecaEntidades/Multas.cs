using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models.BliotecaEnridades
{
    public class Multas
    {
        [Key]
        public int MultaID { get; set; }

        // Clave externa
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
    }
}