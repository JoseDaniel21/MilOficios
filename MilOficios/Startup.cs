using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilOficios.Startup))]
namespace MilOficios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
