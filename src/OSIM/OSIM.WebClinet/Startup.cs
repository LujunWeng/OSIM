using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSIM.WebClinet.Startup))]
namespace OSIM.WebClinet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
