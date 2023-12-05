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
    public class MultasController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: Multas
        public ActionResult Index()
        {
            var multas = db.Multas.Include(m => m.Usuario);
            return View(multas.ToList());
        }

        // GET: Multas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = db.Multas.Find(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            return View(multas);
        }

        // GET: Multas/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: Multas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MultaID,UsuarioID,Monto,FechaPago,Estado")] Multas multas)
        {
            if (ModelState.IsValid)
            {
                db.Multas.Add(multas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", multas.UsuarioID);
            return View(multas);
        }

        // GET: Multas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = db.Multas.Find(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", multas.UsuarioID);
            return View(multas);
        }

        // POST: Multas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MultaID,UsuarioID,Monto,FechaPago,Estado")] Multas multas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nombre", multas.UsuarioID);
            return View(multas);
        }

        // GET: Multas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multas multas = db.Multas.Find(id);
            if (multas == null)
            {
                return HttpNotFound();
            }
            return View(multas);
        }

        // POST: Multas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multas multas = db.Multas.Find(id);
            db.Multas.Remove(multas);
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
