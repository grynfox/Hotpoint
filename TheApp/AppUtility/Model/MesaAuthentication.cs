using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class MesaAuthentication : IXW3FormModel
    {
        public int mesaId { get; set; }
        public string senha { get; set; }
        public Dictionary<string, string> GetBody()
        {
            var temp = new Dictionary<string, string>();
            temp.Add("mesaId", mesaId.ToString());
            temp.Add("senha", senha);
            return temp;
        }

        public string GetControllerPath()
        {
            return @"mesas/Authentication";
        }
    }
}
