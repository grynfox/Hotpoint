using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheServer.Controllers
{
    public class ItensController : Controller
    {
        // GET: Itens
        public ActionResult pegaCategorias()
        {
            return Json(ItensDAL.pegaTodasCategorias(),JsonRequestBehavior.AllowGet);
        }
    }
}