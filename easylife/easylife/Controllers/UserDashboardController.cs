using easylife.Core.Entities;
using easylife.Core.Service.Interfaces;
using easylife.Models;
using easylife.Models.UserDashboardViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace easylife.Controllers
{
    public class UserDashboardController : Controller
    {
        public IProductService _ProductService;
        public IMemberService _MemberService;
        public IInvoiceService _InvoiceService;
        public IProductReviewService _ProductReviewService;
        public ICouponService _CouponService;
        public IUserFavoriteService _UserFavoriteService;
        public IReportService _ReportService;
        public IAddressService _AddressService;

        public UserDashboardController(IProductService ProductService, IMemberService MemberService, IInvoiceService InvoiceService, IProductReviewService ProductReviewService, ICouponService CouponService, IUserFavoriteService UserFavoriteService, IReportService ReportService, IAddressService AddressService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
            _InvoiceService = InvoiceService;
            _ProductReviewService = ProductReviewService;
            _CouponService = CouponService;
            _UserFavoriteService = UserFavoriteService;
            _ReportService = ReportService;
            _AddressService = AddressService;
        }

        public ActionResult Dashboard(int id)
        {
            return View(_MemberService.GetById(id));
        }

        public ActionResult info(int id)
        {
            return View(_MemberService.GetById(id));
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            return View(_MemberService.GetById(id));
        }
        [HttpPost]
        public ActionResult edit(Member m)
        {
            //if(_MemberService.Update(m))
            //{
            //    return View(_MemberService.GetById(m.MemberId));
            //}
            
            return View(_MemberService.GetById(m.MemberId));
        }

        public ActionResult changepass(int id,int f)
        {
            myPasswordViewModel p = new myPasswordViewModel();
            p.member = _MemberService.GetById(id);
            if (f == 1)
            {
                p.flag = 1;
            }
            else if (f==2)
            {
                p.flag = 2;
            }
            else
                p.flag = 0;
            
            return View(p);
        }

        public ActionResult ChangePassword(int mid, string cpass, string npass, string rpass)
        {
            myPasswordViewModel p = new myPasswordViewModel();
            p.member = _MemberService.GetById(mid);
            if (p.member.Password != cpass)
            {
                return RedirectToAction("changepass", "UserDashboard", new { id = mid, f=1 });
            }
            else if(npass != rpass)
            {
                return RedirectToAction("changepass", "UserDashboard", new { id = mid, f=2 });
            }
            else
            {
                p.member.Password = npass;
                _MemberService.Update(p.member);
                return RedirectToAction("info", "UserDashboard", new { id = mid });
            }

            
        }

        public ActionResult myOrders(int id)
        {
            myOrdersViewModel m = new myOrdersViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Invoices = _InvoiceService.GetByMemberId(id);
            return View(m);
        }

        public ActionResult invoices(int id)//This id is the InvoiceId not memberId
        {
            InvoiceViewModel I = new InvoiceViewModel();
            I.MemberId = _InvoiceService.GetById(id).MemberId;
            I.Name = _MemberService.GetById(I.MemberId).Name;
            I.Invoice = _InvoiceService.GetById(id);
            return View(I);
        }

        public ActionResult myReviews(int id)
        {
            myReviewsViewModel m = new myReviewsViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Reviews = _ProductReviewService.GetByMemberId(id);
            //m.count = _ProductReviewService.CountReviewsByMemberId(id);
            int count1 = 0;
            foreach (var review in m.Reviews)
            {
                m.Products[count1]=_ProductService.GetById(review.ProductId);
                count1++;
                //m.ProductNames.Add("hey");
            }
            //Console.WriteLine(m.ProductNames[0]);
            return View(m);
        }

        public ActionResult manageAddress(int id)
        {
            myAddressViewModel m = new myAddressViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Addresses = _AddressService.GetByMemberId(id);
            return View(m);
        }
        [HttpPost]
        public ActionResult addAddress(string fulladdress, int mid)
        {
            Address a = new Address();
            a.MemberId = mid;
            a.MemberAddress = fulladdress;

            _AddressService.Insert(a);
            return RedirectToAction("manageAddress", "UserDashboard", new { id = mid });
        }
        public ActionResult myCoupon(int id)
        {
            myCouponViewModel m = new myCouponViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Coupons = _CouponService.GetByMemberId(id);
            return View(m);

        }
        public ActionResult myFavorite(int id)
        {
            myFavoriteViewModel m = new myFavoriteViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Favorites = _UserFavoriteService.GetByMemberId(id);
            //m.count = _ProductReviewService.CountReviewsByMemberId(id);
            int count1 = 0;
            foreach (var favorite in m.Favorites)
            {
                m.Products[count1] = _ProductService.GetById(favorite.ProductId);
                count1++;
                //m.ProductNames.Add("hey");
            }
            //Console.WriteLine(m.ProductNames[0]);
            return View(m);
        }
       
        public ActionResult myReports(int id)
        {
            myReportViewModel m = new myReportViewModel();
            m.MemberId = id;
            m.Name = _MemberService.GetById(id).Name;
            m.Reports = _ReportService.GetByMemberId(id);
            return View(m);
        }
        
  



    }
}
