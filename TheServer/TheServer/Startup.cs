using DAL.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheServer.Startup))]
namespace TheServer
{
    public partial class Startup
    {
        private static ModelContext _dataBase;
        public static ModelContext dataBase { get { if (_dataBase == null) _dataBase = new ModelContext(); return _dataBase; } }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
