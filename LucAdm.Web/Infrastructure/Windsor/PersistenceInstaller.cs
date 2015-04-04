using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LucAdm.Web
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<EntityFrameworkFacility>();

            container.Register(Classes.FromAssemblyContaining(typeof(Repository<>))
                                .BasedOn(typeof(Repository<>))
                                .LifestyleTransient());
        }
    }
}