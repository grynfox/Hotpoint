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
    public class itenspedidoesController : Controller
    {
        private Model db = new Model();

        // GET: itenspedidoes
        public ActionResult Index()
        {
            var itenspedido = db.itenspedido.Include(i => i.itens).Include(i => i.pedidomesa);
            return View(itenspedido.ToList());
        }

        // GET: itenspedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itenspedido itenspedido = db.itenspedido.Find(id);
            if (itenspedido == null)
            {
                return HttpNotFound();
            }
            return View(itenspedido);
        }

        // GET: itenspedidoes/Create
        public ActionResult Create()
        {
            ViewBag.idItem = new SelectList(db.itens, "idItem", "nome");
            ViewBag.idPedidoMesa = new SelectList(db.pedidomesa, "idPedidoMesa", "idPedidoMesa");
            return View();
        }

        // POST: itenspedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iditensPedido,idPedidoMesa,idItem,dataPedido,quantidade,valorTotal,observacao,progresso")] itenspedido itenspedido)
        {
            if (ModelState.IsValid)
            {
                db.itenspedido.Add(itenspedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idItem = new SelectList(db.itens, "idItem", "nome", itenspedido.idItem);
            ViewBag.idPedidoMesa = new SelectList(db.pedidomesa, "idPedidoMesa", "idPedidoMesa", itenspedido.idPedidoMesa);
            return View(itenspedido);
        }

        // GET: itenspedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itenspedido itenspedido = db.itenspedido.Find(id);
            if (itenspedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idItem = new SelectList(db.itens, "idItem", "nome", itenspedido.idItem);
            ViewBag.idPedidoMesa = new SelectList(db.pedidomesa, "idPedidoMesa", "idPedidoMesa", itenspedido.idPedidoMesa);
            return View(itenspedido);
        }

        // POST: itenspedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iditensPedido,idPedidoMesa,idItem,dataPedido,quantidade,valorTotal,observacao,progresso")] itenspedido itenspedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itenspedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idItem = new SelectList(db.itens, "idItem", "nome", itenspedido.idItem);
            ViewBag.idPedidoMesa = new SelectList(db.pedidomesa, "idPedidoMesa", "idPedidoMesa", itenspedido.idPedidoMesa);
            return View(itenspedido);
        }

        // GET: itenspedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itenspedido itenspedido = db.itenspedido.Find(id);
            if (itenspedido == null)
            {
                return HttpNotFound();
            }
            return View(itenspedido);
        }

        // POST: itenspedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itenspedido itenspedido = db.itenspedido.Find(id);
            db.itenspedido.Remove(itenspedido);
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
