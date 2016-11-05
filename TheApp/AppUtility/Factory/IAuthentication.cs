using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Factory
{
    public interface IAuthentication
    {
        /// <summary>
        /// Retorna a chave de criptografia de segurança
        /// </summary>
        string AuthenticationParameter { get; }

        /// <summary>
        /// Retorna o schema de busca
        /// </summary>
        string AuthenticationScheme { get; }
    }
}
