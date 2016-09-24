using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
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
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;

            if (SessionPersister.Mesa == null)
            {
                var host = actionContext.Request.RequestUri.DnsSafeHost;
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                //actionContext.Response.Headers.Add("WWW-Authenticate", "Usuario");
            }
        }


        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}