using System.Web.Http;

namespace LucAdm.Web
{
    public class WebApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                AutoMapperConfig.Register();
                CompositionRootConfig.Register(config);
                RoutingConfig.Register(config);
            });
        }
    }
}
