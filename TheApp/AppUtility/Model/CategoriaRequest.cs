using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class CategoriaRequest : IXW3FormModel
    {
        public string nomeMesa { get; set; }
        public Dictionary<string, string> GetBody()
        {
            var tmp = new Dictionary<string, string>();            
            return tmp;
        }

        public string GetControllerPath()
        {
            return @"itens/pegaCategorias";
        }
    }
}
