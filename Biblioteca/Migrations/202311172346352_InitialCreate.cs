namespace Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autores",
                c => new
                    {
                        AutorID = c.Int(nullable: false, identity: true),
                        NombreAutor = c.String(),
                        Nacionalidad = c.String(),
                    })
                .PrimaryKey(t => t.AutorID);
            
            CreateTable(
                "dbo.Editorials",
                c => new
                    {
                        EditorialID = c.Int(nullable: false, identity: true),
                        NombreEditorial = c.String(),
                    })
                .PrimaryKey(t => t.EditorialID);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        GeneroID = c.Int(nullable: false, identity: true),
                        NombreGenero = c.String(),
                    })
                .PrimaryKey(t => t.GeneroID);
            
            CreateTable(
                "dbo.Libros",
                c => new
                    {
                        LibroID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        AutorID = c.Int(nullable: false),
                        GeneroID = c.Int(nullable: false),
                        ISBN = c.String(),
                        EditorialID = c.Int(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.LibroID)
                .ForeignKey("dbo.Autores", t => t.AutorID, cascadeDelete: true)
                .ForeignKey("dbo.Editorials", t => t.EditorialID, cascadeDelete: true)
                .ForeignKey("dbo.Generoes", t => t.GeneroID, cascadeDelete: true)
                .Index(t => t.AutorID)
                .Index(t => t.GeneroID)
                .Index(t => t.EditorialID);
            
            CreateTable(
                "dbo.Multas",
                c => new
                    {
                        MultaID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.MultaID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Rols", t => t.RolID, cascadeDelete: true)
                .Index(t => t.RolID);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        rolID = c.Int(nullable: false, identity: true),
                        TipoRol = c.String(),
                    })
                .PrimaryKey(t => t.rolID);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        PrestamoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        LibroID = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.PrestamoID)
                .ForeignKey("dbo.Libros", t => t.LibroID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.LibroID);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        LibroID = c.Int(nullable: false),
                        FechaReserva = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.ReservaID)
                .ForeignKey("dbo.Libros", t => t.LibroID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.LibroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Reservas", "LibroID", "dbo.Libros");
            DropForeignKey("dbo.Prestamos", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Prestamos", "LibroID", "dbo.Libros");
            DropForeignKey("dbo.Multas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "RolID", "dbo.Rols");
            DropForeignKey("dbo.Libros", "GeneroID", "dbo.Generoes");
            DropForeignKey("dbo.Libros", "EditorialID", "dbo.Editorials");
            DropForeignKey("dbo.Libros", "AutorID", "dbo.Autores");
            DropIndex("dbo.Reservas", new[] { "LibroID" });
            DropIndex("dbo.Reservas", new[] { "UsuarioID" });
            DropIndex("dbo.Prestamos", new[] { "LibroID" });
            DropIndex("dbo.Prestamos", new[] { "UsuarioID" });
            DropIndex("dbo.Usuarios", new[] { "RolID" });
            DropIndex("dbo.Multas", new[] { "UsuarioID" });
            DropIndex("dbo.Libros", new[] { "EditorialID" });
            DropIndex("dbo.Libros", new[] { "GeneroID" });
            DropIndex("dbo.Libros", new[] { "AutorID" });
            DropTable("dbo.Reservas");
            DropTable("dbo.Prestamos");
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Multas");
            DropTable("dbo.Libros");
            DropTable("dbo.Generoes");
            DropTable("dbo.Editorials");
            DropTable("dbo.Autores");
        }
    }
}
