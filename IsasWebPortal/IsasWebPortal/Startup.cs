using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IsasWebPortal.Startup))]
namespace IsasWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
