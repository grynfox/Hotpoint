using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using TheServer.Extensions;

namespace TheServer.Attributes
{
    /// <summary>
    /// Define a engine de acesso e autorização SSL com a mesa 
    /// </summary>
    public class MesaAuthenticationAttribute : AuthorizeAttribute
    {
        public bool RequireSsl { get; set; }

        /// <summary>
        /// Construtor da autenticação de mesa simples
        /// </summary>
        public MesaAuthenticationAttribute()
        {
            this.RequireSsl = true;
        }

        /// <summary>
        /// Inicia a autorização de acesso a mesa 
        /// </summary>
        /// <param name="actionContext">AINDA NAO SEI</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            var isAuthenticated = this.Authorize(actionContext);
            if (!isAuthenticated)
            {
                SendUnauthorizedResponse(actionContext);
            }
        }

        /// <summary>
        /// Busca a mesa e verifica se o login e senha estão corretos caso esteja ocupada ou cria um pedido caso esteja vazia 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns>true = autorizado  | false = não autorizado </returns>
        private bool Authorize(HttpActionContext actionContext)
        {
            var httpContext = HttpContext.Current;

            if (httpContext.Request.IsAuthenticated)
            {
                return true;
            }

            if (this.RequireSsl && !httpContext.Request.IsSecureConnection && !httpContext.Request.IsLocal)
            {
                return false;
            }

            if (!httpContext.Request.Headers.AllKeys.Contains("Authorization"))
            {
                return false;
            }


            var identity = ParseAuthorizationHeader(actionContext);
            if (identity == null)
            {
                return false;
            }

            Models.mesa theMesa;
            // acessar o banco pra ver 
            using (var db = new Models.ModelContext())
            {
                var teste = from mesa in db.mesa where mesa.idMesa == identity.mesaId select mesa;
                theMesa = teste.FirstOrDefault();

                if (theMesa == null)
                {
                    return false;
                }
                if (theMesa.isMesaVaga)
                {
                    db.mesatempedido.Add(new Models.mesatempedido() { mesa = theMesa, senhaPedido = identity.senha });
                    return true;
                }

                if (theMesa.mesatempedido.FirstOrDefault(p => p.mesa == theMesa)?.senhaPedido == identity.senha)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Cria uma chave de autenticação (NÃO verifica se o usuário e senha é realmente valido, só cria uma chave)
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns> An Valid MesaAuthenticationIdentity</returns>
        private MesaAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            // se a requisição de senha é para um usuário (mesa) 
            if (auth != null && auth.Scheme == "Usuario")
            {
                authHeader = auth.Parameter;
            }

            if (string.IsNullOrWhiteSpace(authHeader))
            {
                return null;
            }

            if (authHeader.IsBase64Encoded())
            {
                authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));
            }
            else
            {
                return null;
            }

            int index = authHeader.IndexOf(':');
            if (index < 0)
            {
                return null;
            }

            string mesaId = authHeader.Substring(0, index);
            string senha = authHeader.Substring(index + 1);

            if (string.IsNullOrWhiteSpace(mesaId) || string.IsNullOrWhiteSpace(senha))
            {
                return null;
            }

            return new MesaAuthenticationIdentity(mesaId, senha);
        }

        /// <summary>
        /// Envia uma resposta de acesso negado
        /// </summary>
        /// <param name="actionContext"></param>
        private void SendUnauthorizedResponse(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Usuario");
        }
    }
}