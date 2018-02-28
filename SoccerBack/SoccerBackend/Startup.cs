using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoccerBackend.Startup))]
namespace SoccerBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
