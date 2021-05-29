using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(satıs.Startup))]
namespace satıs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
