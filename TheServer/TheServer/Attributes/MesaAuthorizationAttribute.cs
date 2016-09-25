using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using TheServer.Extensions;
using TheServer.Securety;

namespace TheServer.Attributes
{
    public class MesaAuthorizationAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Inicia a autorização de acesso a mesa 
        /// </summary>
        /// <param name="actionContext">AINDA NAO SEI</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SkipAuthorization(filterContext)) return;

            if (SessionPersister.Mesa == null)
            {
                filterContext.Result = new HttpUnauthorizedResult("Acesso negado");
            }
        }


        private static bool SkipAuthorization(AuthorizationContext filterContext)
        {
            return filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                   filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                       typeof(AllowAnonymousAttribute), true);            
        }
    }
}