using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using DCCScore.MVC.Models;
using DCCScore.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Web;
using DCCScore.Data.Repository;
using DCCScore.Data;
using DCCScore.Services.Membership;
using SimpleInjector.Diagnostics;

namespace DCCScore.MVC.App_Start
{

    public static class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder app)
        {
            var container = GetInitializeContainer(app);

            //container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));

            return container;
        }

        public static Container GetInitializeContainer(
                  IAppBuilder app)
        {
            var container = new Container();
            

            container.RegisterSingleton<IAppBuilder>(app);

            container.RegisterPerWebRequest<
                   ApplicationUserManager>();

            container.RegisterPerWebRequest<ApplicationDbContext>(()
              => new ApplicationDbContext());

            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(
                () =>
                new UserStore<ApplicationUser>(
                  container.GetInstance<ApplicationDbContext>()));

            container.RegisterPerWebRequest<SignInManager<ApplicationUser, string>, 
                ApplicationSignInManager>();

            container.RegisterPerWebRequest<IAuthenticationManager>(() =>
                AdvancedExtensions.IsVerifying(container)
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication);

            container.RegisterInitializer<ApplicationUserManager>(
                manager => InitializeUserManager(manager, app));

            container.Register<IUnitOfWork, UnitOfWork>();
            // meus registros
            container.Register(typeof(IRepositorioBase<>), new[] { typeof(IRepositorioBase<>).Assembly });
            container.Register(typeof(IServicoBase<>), new[] { typeof(IServicoBase<>).Assembly });
            container.Register<IRepositorioBase<Curso>,RepositorioBase<Curso>>();
            container.Register<IAlunoService, AlunoService>();
            container.Register<IEncryptionService, EncryptionService>();


            container.RegisterMvcControllers(
                    Assembly.GetExecutingAssembly());

            return container;
        }

        private static void InitializeUserManager(
            ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator =
             new UserValidator<ApplicationUser>(manager)
             {
                 AllowOnlyAlphanumericUserNames = false,
                 RequireUniqueEmail = true
             };

            //Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = false,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true,
            };

            var dataProtectionProvider = app.GetDataProtectionProvider();

            manager.EmailService = new EmailService();
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                 new DataProtectorTokenProvider<ApplicationUser>(
                  dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
        
    }
}