using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Factory
{
    static class AuthenticationFactory
    {
        internal static AuthenticationHeaderValue createAuthenticationHeader(string mesaId, string senha)
        {
            var authData = string.Format("{0}:{1}", mesaId, senha);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            return new AuthenticationHeaderValue("Usuario", authHeaderValue);
        }
    }
}
