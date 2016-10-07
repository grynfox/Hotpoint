using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheServer.Attributes;
using TheServer.DAL;
using TheServer.Models;

namespace TheServer.Controllers
{
    [MesaAuthorization]
    public class mesasController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: mesas
        [AllowAnonymous]
        public ActionResult Index()
        {
            var result = MesaDAL.listaMesas();
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult teste()
        {
            var db = new Models.ModelContext();
            pedidomesa pm = db.pedidomesa.Add(new pedidomesa { idMesa = 11 });
            
            db.SaveChanges();
            return Json(pm);
        }

        // GET: mesas
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authentication(int mesaId, string senha)
        {
            using (var db = new Models.ModelContext())
            {
                var mesa = db.mesa.Where(m => m.idMesa == mesaId).Include(m => m.mesatempedido).FirstOrDefault();

                if (mesa == null)
                {
                    return new HttpUnauthorizedResult();
                }
                if (mesa.mesatempedido.FirstOrDefault() != null)
                {
                    var pedido = mesa.mesatempedido.First();
                    if (pedido.senhaPedido != senha)
                    {
                        return new HttpUnauthorizedResult();
                    }
                }
                else
                {
                    pedidomesa pm = db.pedidomesa.Add(new pedidomesa { idMesa = 11 });

                    mesatempedido mtp = db.mesatempedido.Add(new mesatempedido { mesa = mesa, pedidomesa = pm, senhaPedido="bario" });
                    db.Entry(mesa).State = EntityState.Unchanged;
                    db.Entry(pm).State = EntityState.Added;
                    db.SaveChanges();

                    return Json(new { pm, mtp });
                }

                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                return Json(mesa);
            }
            //return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }


        // GET: mesas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesa mesa = db.mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // GET: mesas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMesa,nomeMesa,isMesaVaga")] mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.mesa.Add(mesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesa);
        }

        // GET: mesas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesa mesa = db.mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: mesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMesa,nomeMesa,isMesaVaga")] mesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesa);
        }

        // GET: mesas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesa mesa = db.mesa.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mesa mesa = db.mesa.Find(id);
            db.mesa.Remove(mesa);
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
