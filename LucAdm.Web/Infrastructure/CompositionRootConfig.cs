using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace LucAdm.Web
{
    public class CompositionRootConfig
    {
        private static IWindsorContainer container;

        public static void Register(HttpConfiguration config)
        {
            // DI Composition Root
            container = new WindsorContainer().Install(FromAssembly.This());
            config.Services.Replace(typeof(IHttpControllerActivator), new WinsorControllerActivator(container));
        }
    }
}