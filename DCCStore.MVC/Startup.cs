using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCCStore.MVC.Startup))]
namespace DCCStore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
