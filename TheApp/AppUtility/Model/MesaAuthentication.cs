using AppUtility.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Model
{
    public class MesaAuthentication : IAuthentication
    {
        private int mesaId;
        private string senha;

        string IAuthentication.AuthenticationParameter
        {
            get
            {
                var authData = string.Format("{0}:{1}", mesaId, senha);
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            }
        }

        string IAuthentication.AuthenticationScheme
        {
            get
            {
                return "Usuario";
            }
        }
    }
}
