using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class MesaRequest : IXW3FormModel
    {
        public Dictionary<string, string> GetBody()
        {
            return new Dictionary<string, string>();
        }

        public string GetControllerPath()
        {
            return @"mesas/index";
        }
    }
}
