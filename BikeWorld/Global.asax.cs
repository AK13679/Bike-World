using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using BikeWorld.App_Start;

namespace BikeWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
        }
    /// <summary>
    /// Application Error Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                //Log
                if (HttpContext.Current.Server != null)
                {
                    //HttpContext.Current.Server.Transfer("/siteerror.aspx");
                }
            }
        }
    }
}
