using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dWeb.Auger.Drilling.Startup))]
namespace dWeb.Auger.Drilling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
