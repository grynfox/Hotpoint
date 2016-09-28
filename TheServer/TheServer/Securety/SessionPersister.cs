using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheServer.Models;

namespace TheServer.Securety
{
    public static class SessionPersister
    {
        static string usernameSessionvar = "username";
        static string mesaSessionvar = "mesa";

        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;

                return null;
            }
            set { HttpContext.Current.Session[usernameSessionvar] = value; }
        }

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
            set { HttpContext.Current.Session[usernameSessionvar] = value; }
        }


    }
}