using System.Reflection;
using System.Web.Http;
using AngularWorkshop;
using AngularWorkshop.Init;
using JetBrains.Annotations;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
[assembly: OwinStartup(typeof(Startup))]

namespace AngularWorkshop
{
    public class Startup
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder appBuilder)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var configuration = new HttpConfiguration();

            WebApiConfig.Register(configuration);
#if DEBUG
            appBuilder.UseCors(CorsOptions.AllowAll);
#endif
            Resolver.Initialize(Assembly.GetExecutingAssembly(), configuration, appBuilder);

            appBuilder.UseWebApi(configuration);
        }
    }
}