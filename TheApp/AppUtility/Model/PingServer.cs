using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppUtility.Http;

namespace AppUtility.Model
{
    public class PingServer : IXW3FormModel
    {
        public Dictionary<string, string> GetBody()
        {
            return new Dictionary<string, string>();
        }

        public string GetControllerPath()
        {
            return @"Home/Ping";
        }
    }
}
