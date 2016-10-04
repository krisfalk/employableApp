using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployableApp.Startup))]
namespace EmployableApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
