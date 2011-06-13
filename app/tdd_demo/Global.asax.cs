using System;
using Castle.Windsor;
using System.Web.Mvc;
using System.Web.Routing;
using tdd_demo.Castle_IOC;

namespace tdd_demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer _container;
        public IWindsorContainer Container {
            get { return _container; }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            BootstrapContainer();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private void BootstrapContainer() {
            _container = new WindsorContainer();
            _container.Install(new DependencyInstaller(), new ControllerInstaller());
            DependencyResolver.SetResolver(new CastleDependencyResolver(_container));
        }
    }
}