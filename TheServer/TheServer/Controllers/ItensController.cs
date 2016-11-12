using DAL.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheServer.Extensions;

namespace TheServer.Controllers
{
    public class ItensController : Controller
    {
        // GET: Itens
        public ActionResult pegaCategorias()
        {
            var dal = new ItensDAL(Startup.dataBase);
            return dal.pegaTodasCategorias().ToJsonResult();
        }


        public ActionResult pegaItens(int? idCategoria = null)
        {
            var dal = new ItensDAL(Startup.dataBase);
            //return Json(ItensDAL.pegaItens(idCategoria), JsonRequestBehavior.AllowGet);
            //return Content(JsonConvert.SerializeObject(ItensDAL.pegaItens(idCategoria), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), "application/json");
            return dal.pegaItens(idCategoria).ToJsonResult();
        }
    }
}