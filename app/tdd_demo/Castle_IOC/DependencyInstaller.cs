using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace tdd_demo.Castle_IOC
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes
                                   .FromThisAssembly()
                                   .BasedOn<IDependency>()
                                   .WithService.FirstInterface()
                                   .Configure(component => component.LifeStyle.Transient));
        }
    }
}