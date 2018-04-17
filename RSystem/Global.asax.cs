using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using RSystem.Controllers;
using RSystem.Models;
using RSystem.ViewModels;

namespace RSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mapper.Initialize(cfg => {
                cfg.CreateMap<RecruitDataViewModel, RecruitData>();
                cfg.CreateMap<RecruitData, RecruitDataViewModel>();
            });
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Response.Clear();
            var httpexception = exception as HttpException;

            var route = new RouteData();
            route.Values.Add("controller","Error");
            route.Values.Add("action","Index");
            if(httpexception!=null)
                route.Values.Add("id",httpexception.GetHttpCode().ToString());

            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;

            IController errorController=new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context),route ));
        }
    }
}
