using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheServer.Securety
{
    public static class SessionPersister
    {
        static string mesaSessionvar = "mesa";
        static string pedidoSessionvar = "pedido";

        public static mesa Mesa
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var sessionVar = HttpContext.Current.Session[mesaSessionvar];
                if (sessionVar != null)
                    return sessionVar as mesa;

                return null;
            }
            set { HttpContext.Current.Session[mesaSessionvar] = value; }
        }

        public static pedidomesa Pedido
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                var sessionVar = HttpContext.Current.Session[pedidoSessionvar];
                if (sessionVar != null)
                    return sessionVar as pedidomesa;

                return null;
            }
            set { HttpContext.Current.Session[pedidoSessionvar] = value; }
        }


    }
}