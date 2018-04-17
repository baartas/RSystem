using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSystem.Startup))]
namespace RSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
