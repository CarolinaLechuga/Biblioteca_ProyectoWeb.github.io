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
    public class PrestamosController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: Prestamos
        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.Libro).Include(p => p.Usuario);
            return View(prestamos.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: Prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrestamoID,UsuarioID,LibroID,FechaInicio,FechaFin,Estado")] Prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", prestamos.LibroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", prestamos.UsuarioID);
            return View(prestamos);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", prestamos.LibroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", prestamos.UsuarioID);
            return View(prestamos);
        }

        // POST: Prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrestamoID,UsuarioID,LibroID,FechaInicio,FechaFin,Estado")] Prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LibroID = new SelectList(db.Libros, "LibroID", "Titulo", prestamos.LibroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", prestamos.UsuarioID);
            return View(prestamos);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamos);
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
