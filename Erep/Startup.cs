using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Erep.Startup))]
namespace Erep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
