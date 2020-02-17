using Autofac;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using WWebApiTemplate.Models;

namespace WWebApiTemplate.App_Start
{
    public class IoCConfig
    {
        public static void Setup()
        {
            var builder = new ContainerBuilder();

            //1. Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // 2. RegisterTypes
            #region RegisterTypes

            builder.RegisterType(typeof(ApplicationDbContext))
               .AsSelf()
               .AsImplementedInterfaces()
               .As(typeof(IContext))
               .InstancePerRequest();


            //---------------------------- register Modules-------------
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(assemblies.ToArray());
            //--------------------------------------------------


            // Register your Web API controllers.
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(WebApiConfig).Assembly);


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();


            // custom class register register =====================================================

            //builder.RegisterType(typeof(ClassName)).AsImplementedInterfaces();

            // register ApplicationDbContext
            #endregion

            // 3.build container
            var container = builder.Build();

            // 4.Set the dependency resolver to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}