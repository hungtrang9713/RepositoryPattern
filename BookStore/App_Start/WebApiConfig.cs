using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Service;
using Unity.Lifetime;
using Repository;
using BookStore.Unity;

namespace BookStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IBookService, BookService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
