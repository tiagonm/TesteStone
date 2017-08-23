using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using SimpleInjector;
using Stone.Imobilizado.IOC;
using System.Web.Http.Dependencies;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Stone.Imobilizado
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
