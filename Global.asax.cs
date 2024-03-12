using AutoMapper;
using PMDLL;
using ProductManagementSPAWithEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductManagementSPAWithEntityFramework
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Product, ProductVM>();
                x.CreateMap<Product, Product>();
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
