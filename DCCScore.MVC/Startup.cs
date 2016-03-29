using Microsoft.Owin;
using Owin;
using DCCScore.MVC.App_Start;

[assembly: OwinStartup(typeof(DCCScore.MVC.Startup))]

namespace DCCScore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorInitializer.Initialize(app);
            ConfigureAuth(app, container);
        }
    }
}
