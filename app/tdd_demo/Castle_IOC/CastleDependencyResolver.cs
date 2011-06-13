using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Windsor;

namespace tdd_demo.Castle_IOC
{
    public class CastleDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public CastleDependencyResolver(IWindsorContainer container) {
            this.container = container;
        }

        public object GetService(Type serviceType) {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            try
            {
                return (IEnumerable<object>)container.ResolveAll(serviceType);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}