using Biblioteca.Models.BliotecaEnridades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base("Data Source=(local);Initial Catalog=Bilbioteca;Integrated Security=True;")
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Multas> Multas { get; set; }
    }
}