using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace AngularWorkshop.Init
{
    public static class Resolver
    {
        private static IContainer _container;

        public static void Initialize(
            Assembly webApiAssembly,
            HttpConfiguration configuration,
            IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();

            builder.Register(context => appBuilder.GetDataProtectionProvider()).As<IDataProtectionProvider>()
                .SingleInstance();

            //ContainerBuilderHelper.RegisterCommonTypes(builder);

            builder.RegisterApiControllers(webApiAssembly).InstancePerRequest();
            //builder.RegisterWebApiFilterProvider(configuration);

            //builder.RegisterModule(new AutoMapperModule { Assemblies = new[] { webApiAssembly } });
            builder.RegisterModule<EntityFrameworkModule>();

            _container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);

            appBuilder.UseAutofacMiddleware(_container);
            appBuilder.UseAutofacWebApi(configuration);
        }

        public static IContainer Container => _container;
    }
}