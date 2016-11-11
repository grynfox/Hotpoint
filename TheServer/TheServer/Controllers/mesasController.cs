using DAL.Core;
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
using TheServer.Extensions;

namespace TheServer.Controllers
{
    [MesaAuthorization]
    public class mesasController : Controller
    {
        //private ModelContext db = new ModelContext();

        // GET: mesas
        [AllowAnonymous]
        public ActionResult Index(string nomeMesa = null)
        {
            var result = MesaDAL.listaMesas(nomeMesa);
            if (result.Count > 1)
            {
                return result.ToList().ToJsonResult();
            }
            else if (result.Count == 1)
            {
                return result[0].ToJsonResult();
            }
            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult teste()
        {
            //var db = new Models.ModelContext();
            //pedidomesa pm = db.pedidomesa.Add(new pedidomesa { idMesa = 11 });

            //db.SaveChanges();
            //return Json(pm);
            throw new NotImplementedException("");
        }

        // GET: mesas
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authentication(int mesaId, string senha)
        {
            var mesa = MesaDAL.PegaMesaPorId(mesaId);
            var pedidoMesa = mesa.mesatempedido.FirstOrDefault();

            if (mesa == null) // id da mesa não existe
            {
                return new HttpUnauthorizedResult();
            }

            if (pedidoMesa != null && string.Compare(pedidoMesa.senhaPedido, senha, false) != 0) // senha invalida
            {
                return new HttpUnauthorizedResult();
            }
            else if( pedidoMesa == null) // cria mesa 
            {
                if(MesaDAL.InserePedidoEmMesa(mesa, senha))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK, "Autenticação Autorizada, senha criada");
                }
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Algo deu errado ao abrir a mesa");
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Autenticação Autorizada, senha criada");

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
