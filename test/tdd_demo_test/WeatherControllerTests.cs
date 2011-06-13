using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tdd_demo.Castle_IOC;
using tdd_demo.Controllers;
using tdd_demo.Services;
using Telerik.JustMock;

namespace tdd_demo_test
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void all_controllers_implement_IController() {
            IWindsorContainer containerWithControllers = new WindsorContainer().Install(new ControllerInstaller());

            var allHandlers = GetAllHandlers(containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof (IController), containerWithControllers);

            Assert.IsTrue(allHandlers.Count() > 0);
            CollectionAssert.AreEqual(allHandlers, controllerHandlers);
        }

        [TestMethod]
        public void All_controllers_are_registered() {
            IWindsorContainer containerWithControllers = new WindsorContainer().Install(new ControllerInstaller());

	        // Is<TType> is an helper, extension method from Windsor
	        // which behaves like 'is' keyword in C# but at a Type, not instance level
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof(IController), containerWithControllers);
            CollectionAssert.AreEqual(allControllers, registeredControllers);
}
        private IHandler[] GetAllHandlers(IWindsorContainer container) {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container) {
            return container.Kernel.GetAssignableHandlers(type);
        }

        private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container) {
            return GetHandlersFor(type, container)
                    .Select(h => h.ComponentModel.Implementation)
                    .OrderBy(t => t.Name)
                    .ToArray();
        }

        private Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where) {
            return typeof(HomeController).Assembly.GetExportedTypes()
            .Where(t => t.IsClass)
            .Where(t => t.IsAbstract == false)
            .Where(where.Invoke)
            .OrderBy(t => t.Name)
            .ToArray();
        }

        [TestMethod]
        public void County_method_returns_json() {
            IWeatherSvc weatherSvc = Mock.Create<IWeatherSvc>();
            WeatherController weatherController = new WeatherController(weatherSvc);

            ActionResult actionResult = weatherController.County("Montgomery");

            Assert.AreEqual(typeof (JsonResult), actionResult.GetType());
        }

        [TestMethod]
        public void County_method_calls_WeatherSvc_GetWeatherForCounty() {
            IWeatherSvc weatherSvc = Mock.Create<IWeatherSvc>();
            WeatherController weatherController = new WeatherController(weatherSvc);

            Mock.Arrange(() => weatherSvc.GetWeatherForCounty("Montgomery"))
                                .IgnoreArguments()
                                .MustBeCalled();

            weatherController.County("Montgomery");  // act

            Mock.Assert(weatherSvc); // assert
        }
    }
}
