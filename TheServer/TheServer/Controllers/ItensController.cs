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
            return ItensDAL.pegaTodasCategorias().ToJsonResult();
        }


        public ActionResult pegaItens(int? idCategoria = null)
        {
            //return Json(ItensDAL.pegaItens(idCategoria), JsonRequestBehavior.AllowGet);
            //return Content(JsonConvert.SerializeObject(ItensDAL.pegaItens(idCategoria), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), "application/json");
            return ItensDAL.pegaItens(idCategoria).ToJsonResult();
        }
    }
}