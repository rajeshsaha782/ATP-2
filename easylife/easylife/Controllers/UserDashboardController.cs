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
        public ICartService _CartService;
        public IOrderService _OrderService;

        public UserDashboardController(IProductService ProductService, IMemberService MemberService, IInvoiceService InvoiceService, IProductReviewService ProductReviewService, ICouponService CouponService, IUserFavoriteService UserFavoriteService, IReportService ReportService, IAddressService AddressService, ICartService CartService, IOrderService OrderService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
            _InvoiceService = InvoiceService;
            _ProductReviewService = ProductReviewService;
            _CouponService = CouponService;
            _UserFavoriteService = UserFavoriteService;
            _ReportService = ReportService;
            _AddressService = AddressService;
            _CartService = CartService;
            _OrderService = OrderService;
        }

        public ActionResult Dashboard()
        {
            if(Session["userId"]==null)
            {
                return RedirectToAction("Index","UserHome");
            }
            myDashboardViewModel d = new myDashboardViewModel();
            int id = Convert.ToInt32(Session["userId"]);
            d.MemberId = id;
            d.Name = _MemberService.GetById(id).Name;
            d.member = _MemberService.GetById(id);
            d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            IEnumerable<Invoice> invoices = _InvoiceService.GetByMemberId(id);
            d.OderCount = 0;
            foreach (var item in invoices)
            {
                d.OderCount += _OrderService.CountByInvoiceId(item.InvoiceId);
            }
            d.CouponCount = _CouponService.CountByMemberId(id);
            d.ReviewCount = _ProductReviewService.CountReviewsByMemberId(id);
            d.FavoriteCount = _UserFavoriteService.GetByMemberId(id).Count();

            if(_AddressService.GetByMemberId(id).Count() == 0)
            {
                d.Address = null;
            }
            else
            {
                d.Address = _AddressService.GetByMemberId(id).First().MemberAddress;
            }
            
            return View(d);
        }

        public ActionResult info(int id)
        {

            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myInfoViewModel d = new myInfoViewModel();
                d.MemberId = id;
                d.Name = _MemberService.GetById(id).Name;
                d.member = _MemberService.GetById(id);
                d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(d);
            }
            else
                return RedirectToAction("Index", "UserHome");
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myEditViewModel d = new myEditViewModel();
                d.MemberId = id;
                d.Name = _MemberService.GetById(id).Name;
                d.Email = _MemberService.GetById(id).Email;
                d.Gender = _MemberService.GetById(id).Gender;
                d.PhoneNumber = _MemberService.GetById(id).PhoneNumber;

                d.member = _MemberService.GetById(id);
                d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(d);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
        }
        /*public ActionResult editMember(Member m)
        {
            _MemberService.Update(m);
            return RedirectToAction("edit", "UserDashboard", new { id = m.MemberId });
        }*/
        [HttpPost]
        public ActionResult edit(int id,string Name, string Email, string Gender, string PhoneNumber)
        {
            
            Member m = new Member();
            m = _MemberService.GetById(id);
            m.Name = Name;
            m.Email = Email;
            m.Gender = Gender;
            m.PhoneNumber = PhoneNumber;
            _MemberService.Update(m);

            myEditViewModel d = new myEditViewModel();

            
            d.MemberId = id;
            d.Name = _MemberService.GetById(id).Name;
            d.Email = _MemberService.GetById(id).Email;
            d.Gender = _MemberService.GetById(id).Gender;
            d.PhoneNumber = _MemberService.GetById(id).PhoneNumber;

            d.member = _MemberService.GetById(id);
            d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            return RedirectToAction("info", "UserDashboard", new { id = id });


        }

        public ActionResult changepass(int id,int f)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myPasswordViewModel p = new myPasswordViewModel();
                p.MemberId = id;
                p.Name = _MemberService.GetById(id).Name;
                p.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                p.member = _MemberService.GetById(id);
                if (f == 1)
                {
                    p.flag = 1;
                }
                else if (f == 2)
                {
                    p.flag = 2;
                }
                else
                    p.flag = 0;

                return View(p);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }

        public ActionResult ChangePassword(int mid, string cpass, string npass, string rpass)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                myPasswordViewModel p = new myPasswordViewModel();
                p.member = _MemberService.GetById(mid);
                if (p.member.Password != cpass)
                {
                    return RedirectToAction("changepass", "UserDashboard", new { id = mid, f = 1 });
                }
                else if (npass != rpass)
                {
                    return RedirectToAction("changepass", "UserDashboard", new { id = mid, f = 2 });
                }
                else
                {
                    p.member.Password = npass;
                    _MemberService.Update(p.member);
                    return RedirectToAction("info", "UserDashboard", new { id = mid });
                }
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            

            
        }

        public ActionResult myOrders(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myOrdersViewModel m = new myOrdersViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Invoices = _InvoiceService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(m);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }
        public ActionResult removeOrder(int id, int mid)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                _InvoiceService.Delete(id);
                return RedirectToAction("myOrders", "UserDashboard", new { id = mid });
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }

        public ActionResult invoices(int id,int mid)//This id is the InvoiceId not memberId
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                InvoiceViewModel I = new InvoiceViewModel();
                I.MemberId = _InvoiceService.GetById(id).MemberId;
                I.Name = _MemberService.GetById(I.MemberId).Name;
                I.Invoice = _InvoiceService.GetById(id);
                I.Orders = _OrderService.GetByInvoiceId(id);
                int count = 0;
                foreach (var item in I.Orders)
                {
                    I.Products[count] = _ProductService.GetById(item.ProductId);
                    count++;
                }
                I.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(I);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }

        public ActionResult myReviews(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myReviewsViewModel m = new myReviewsViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Reviews = _ProductReviewService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                //m.count = _ProductReviewService.CountReviewsByMemberId(id);
                int count1 = 0;
                foreach (var review in m.Reviews)
                {
                    m.Products[count1] = _ProductService.GetById(review.ProductId);
                    count1++;
                    //m.ProductNames.Add("hey");
                }
                //Console.WriteLine(m.ProductNames[0]);
                return View(m);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }

        public ActionResult manageAddress(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myAddressViewModel m = new myAddressViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Addresses = _AddressService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                m.count = m.Addresses.Count();
                return View(m);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }
        [HttpPost]
        public ActionResult addAddress(string fulladdress, int mid)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                //Address a1=_AddressService.GetByMemberId(mid).SingleOrDefault();
                //if (a1.MemberAddress == "No Address")
                //    _AddressService.Delete(a1.AddressId);


                Address a = new Address();
                a.MemberId = mid;
                a.MemberAddress = fulladdress;
                _AddressService.Insert(a);
                return RedirectToAction("manageAddress", "UserDashboard", new { id = mid });
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }
        public ActionResult removeAddress(int id,int mid)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                _AddressService.Delete(id);
                return RedirectToAction("manageAddress", "UserDashboard", new { id = mid });
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }
        public ActionResult myCoupon(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myCouponViewModel m = new myCouponViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Coupons = _CouponService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(m);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            

        }
        public ActionResult myFavorite(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myFavoriteViewModel m = new myFavoriteViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Favorites = _UserFavoriteService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
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
            else
                return RedirectToAction("Index", "UserHome");
            
           
        }
        public ActionResult removeFavorite(int id, int mid)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                _UserFavoriteService.Delete(id);
                return RedirectToAction("myFavorite", "UserDashboard", new { id = mid });
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }
       
        public ActionResult myReports(int id)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                myReportViewModel m = new myReportViewModel();
                m.MemberId = id;
                m.Name = _MemberService.GetById(id).Name;
                m.Reports = _ReportService.GetByMemberId(id);
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                return View(m);
            }
            else
                return RedirectToAction("Index", "UserHome");
            
            
        }

        public ActionResult Logout()
        {
                Session["userId"] = null;
                return RedirectToAction("Index", "UserHome");
        }



    }
}
