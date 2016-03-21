using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCCScore.MVC.Startup))]
namespace DCCScore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
