using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Factory
{
    public class RequestFactory
    {
        public static HttpRequest createHttp(string serverUrl)
        {
            return new HttpRequest(serverUrl);
        }

        public static HttpRequest createHttps(string serverUrl, int mesaId, string senha)
        {
            var ret = new HttpRequest(serverUrl);
            var auth = AuthenticationFactory.createAuthenticationHeader(mesaId.ToString(), senha);
            ret.InsertAuthorization(auth);
            return ret;
        }

        public static void insertSsl(ref HttpRequest req, int mesaId, string senha)
        {
            var auth = AuthenticationFactory.createAuthenticationHeader(mesaId.ToString(), senha);
            req.InsertAuthorization(auth);
        }

        

    }
}
