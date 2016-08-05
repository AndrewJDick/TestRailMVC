using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestRailMVC.Startup))]
namespace TestRailMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
