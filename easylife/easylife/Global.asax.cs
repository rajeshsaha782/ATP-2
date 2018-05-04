using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Unity;
using Unity.Mvc4;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using easylife.Infrastructure;
using easylife.Core.Service.Interfaces;
using easylife.Core.Service;

namespace easylife
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<easylifeDbContext>(new DropCreateDatabaseIfModelChanges<easylifeDbContext>());

            IUnityContainer container = new UnityContainer();

            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<ICouponService, CouponService>();
            container.RegisterType<IDeliveryManService, DeliveryManService>();
            container.RegisterType<IDislikeService, DislikeService>();
            container.RegisterType<IInvoiceService, InvoiceService>();
            container.RegisterType<ILikeService, LikeService>();
            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductReviewService, ProductReviewService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<ISearchHistoryService, SearchHistoryService>();
            container.RegisterType<IUserFavoriteService, UserFavoriteService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ICartService, CartService>();

            container.RegisterType<DbContext, easylifeDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}