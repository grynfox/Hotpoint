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

        public static HttpRequest createHttps(string serverUrl, IAuthentication authMethod)
        {
            var ret = new HttpRequest(serverUrl);
            var auth = new AuthenticationHeaderValue(authMethod.AuthenticationScheme, authMethod.AuthenticationParameter); 
            ret.InsertAuthorization(auth);
            return ret;
        }

        public static void insertSsl(ref HttpRequest req, IAuthentication authMethod)
        {
            var auth = new AuthenticationHeaderValue(authMethod.AuthenticationScheme, authMethod.AuthenticationParameter);
            req.InsertAuthorization(auth);
        }

        

    }
}
