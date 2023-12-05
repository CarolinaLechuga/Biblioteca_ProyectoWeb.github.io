using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca.Models;
using Biblioteca.Models.BliotecaEnridades;

namespace Biblioteca.Controllers.BibliotecaController
{
    public class LibrosController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: Libros
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero);
            return View(libros.ToList());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "NombreAutor");
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial");
            ViewBag.GeneroID = new SelectList(db.Generos, "GeneroID", "NombreGenero");
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibroID,Titulo,AutorID,GeneroID,ISBN,EditorialID,Estado")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Libros.Add(libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "NombreAutor", libros.AutorID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.GeneroID = new SelectList(db.Generos, "GeneroID", "NombreGenero", libros.GeneroID);
            return View(libros);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "NombreAutor", libros.AutorID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.GeneroID = new SelectList(db.Generos, "GeneroID", "NombreGenero", libros.GeneroID);
            return View(libros);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibroID,Titulo,AutorID,GeneroID,ISBN,EditorialID,Estado")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "NombreAutor", libros.AutorID);
            ViewBag.EditorialID = new SelectList(db.Editoriales, "EditorialID", "NombreEditorial", libros.EditorialID);
            ViewBag.GeneroID = new SelectList(db.Generos, "GeneroID", "NombreGenero", libros.GeneroID);
            return View(libros);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libros libros = db.Libros.Find(id);
            db.Libros.Remove(libros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
