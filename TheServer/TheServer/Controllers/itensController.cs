using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheServer.Models;

namespace TheServer.Controllers
{
    public class itensController : Controller
    {
        private Model db = new Model();

        // GET: itens
        public ActionResult Index()
        {
            var itens = db.itens.Include(i => i.categoria);
            return Json(itens.ToList(), JsonRequestBehavior.AllowGet);
            //return View(itens.ToList());
        }

        // GET: itens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens itens = db.itens.Find(id);
            if (itens == null)
            {
                return HttpNotFound();
            }
            return View(itens);
        }

        // GET: itens/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descricao");
            return View();
        }

        // POST: itens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idItem,nome,informacao,valor,idCategoria")] itens itens)
        {
            if (ModelState.IsValid)
            {
                db.itens.Add(itens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descricao", itens.idCategoria);
            return View(itens);
        }

        // GET: itens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens itens = db.itens.Find(id);
            if (itens == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descricao", itens.idCategoria);
            return View(itens);
        }

        // POST: itens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idItem,nome,informacao,valor,idCategoria")] itens itens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descricao", itens.idCategoria);
            return View(itens);
        }

        // GET: itens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itens itens = db.itens.Find(id);
            if (itens == null)
            {
                return HttpNotFound();
            }
            return View(itens);
        }

        // POST: itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itens itens = db.itens.Find(id);
            db.itens.Remove(itens);
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
