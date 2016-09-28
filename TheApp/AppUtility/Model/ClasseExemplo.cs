using AppUtility.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class ClasseExemplo : IXW3FormModel
    {
        public int preco { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }

        public Dictionary<string, string> GetBody()
        {
            var temp = new Dictionary<String, String>();
            temp.Add("preco", preco.ToString());
            temp.Add("nome", nome);
            temp.Add("quantidade", quantidade.ToString());
            return temp;
        }

        public string GetControllerPath()
        {
            return @"caminho/para/o/controller";
        }
    }
}
