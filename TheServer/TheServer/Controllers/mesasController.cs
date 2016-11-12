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
using TheServer.Securety;

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
            var dal = new MesaDAL(Startup.dataBase);
            var result = dal.listaMesas(nomeMesa);
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
            var dal = new MesaDAL(Startup.dataBase);
            var mesa = dal.PegaMesaPorId(mesaId);
           
            if (mesa == null) // id da mesa não existe
            {
                return new HttpUnauthorizedResult();
            }

            var mesaTmPdd = mesa.mesatempedido.FirstOrDefault();

            if (mesaTmPdd != null && string.Compare(mesaTmPdd.senhaPedido, senha, false) != 0) // senha invalida
            {
                return new HttpUnauthorizedResult();
            }
            else if( mesaTmPdd == null) // cria mesa 
            {
                var pedido = dal.InserePedidoEmMesa(mesa, senha);
                if (pedido != null)
                {
                    SessionPersister.Mesa = mesa;
                    SessionPersister.Pedido = pedido;
                    return new HttpStatusCodeResult(HttpStatusCode.OK, "Autenticação Autorizada, senha criada");
                }
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Algo deu errado ao abrir a mesa");
            }

            //inserir em sessão
            SessionPersister.Mesa = mesa;
            SessionPersister.Pedido = mesaTmPdd.pedidomesa;
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Autenticação Autorizada, senha criada");

        }

        [HttpPost]
        [MesaAuthorization]
        public ActionResult CompraProduto(int idItem, float quantidade, string observacao = null)
        {
            var dal = new PedidoDAL(Startup.dataBase);
            var pedido = SessionPersister.Pedido;
            if (dal.inserePedidoItem(pedido, idItem, quantidade, observacao))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Compra Efetuada");
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Algo deu errado");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
