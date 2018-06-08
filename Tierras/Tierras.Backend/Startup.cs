using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tierras.Backend.Startup))]
namespace Tierras.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
