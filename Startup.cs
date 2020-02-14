using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbyssRunSite.Startup))]
namespace AbyssRunSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
