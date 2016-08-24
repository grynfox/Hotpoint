using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TheServer.Attributes
{
    public class MesaAuthenticationIdentity : GenericIdentity
    {
        public string senha { get; set; }
        public int mesaId { get; set; }
        public MesaAuthenticationIdentity(string mesaId, string senha) : base(mesaId, "Usuario")
        {
            this.senha = senha;
            try
            {
                this.mesaId = int.Parse(mesaId);
            }
            catch { }
        }
    }
}