using Autofac;
using Autofac.Integration.WebApi;
using DCCScore.Data;
using DCCScore.Data.Repository;
using DCCScore.Services;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace DCCScore.MVC.App_Start
{
    public class AutofacConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container)
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // EF DCCScoreDbContext 
            builder.RegisterType<DCCScoreDbEntities>().As<DbContext>() .InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(RepositorioBase<>)).As(typeof(IRepositorioBase<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(ServicoBase<>)).As(typeof(IServicoBase<>)).InstancePerRequest();
            // Services 
            // Scan an assembly for components
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
            // Repositorios
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repositorio"))
                .AsImplementedInterfaces();
            Container = builder.Build();
            return Container;
        }
    }
}