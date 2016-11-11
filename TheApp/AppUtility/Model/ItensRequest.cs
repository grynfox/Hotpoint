using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class ItensRequest : IXW3FormModel
    {
        public int? idCategoria { get; set; }
        public Dictionary<string, string> GetBody()
        {
            var tmp = new Dictionary<string, string>();
            if(idCategoria != null) { tmp.Add("idCategoria", idCategoria.ToString()); }
            return tmp;
        }

        public string GetControllerPath()
        {
            return @"Itens/PegaItens";
        }
    }
}
