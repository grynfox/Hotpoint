using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheServer.Startup))]
namespace TheServer
{
    public partial class Startup
    {       
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
