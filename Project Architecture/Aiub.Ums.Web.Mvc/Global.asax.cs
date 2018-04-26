using Aiub.Ums.Core.Service;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Aiub.Ums.Web.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<DbContext, UmsDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
