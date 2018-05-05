using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
using easylife.Models;
using easylife.Core.Entities;
using easylife.Models.UserHomeViewModel;


namespace easylife.Controllers
{
    public class UserHomeController : Controller
    {
        public IProductService _ProductService;
        public IMemberService _MemberService;
        public ILikeService _LikeService;
        public IDislikeService _DislikeService;
        public IProductReviewService _ProductReviewService;
        public ICartService _CartService;
        public ICouponService _CouponService;
        public IAddressService _AddressService;
        public IInvoiceService _InvoiceService;
        public ILoginService _LoginService;
        public IReportService _ReportService;

        public UserHomeController(IProductService ProductService, IMemberService MemberService, ILikeService LikeService, IDislikeService DislikeService, IProductReviewService ProductReviewService, ICartService CartService, ICouponService CouponService, IAddressService AddressService, IInvoiceService InvoiceService, ILoginService LoginService, IReportService ReportService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
            _LikeService = LikeService;
            _DislikeService = DislikeService;
            _ProductReviewService = ProductReviewService;
            _CartService = CartService;
            _CouponService = CouponService;
            _AddressService = AddressService;
            _InvoiceService = InvoiceService;
            _LoginService = LoginService;
            _ReportService = ReportService;
        }

        public ActionResult Index()
        {

            IndexViewModel m = new IndexViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            return View(m);
        }
        [HttpGet]
        public ActionResult brand(string brand)
        {
            brandViewModel m = new brandViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productByBrand = _ProductService.GetByBrand(brand);
            ViewBag.brand = brand;
            return View(m);
        }

        [HttpGet]
        public ActionResult catagory(string category, string subcategory)
        {
            catagoryViewModel m = new catagoryViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productByCatagory = _ProductService.GetByCategory(category, subcategory);
            return View(m);
        }


        public ActionResult details(int id)
        {
            string pid = Convert.ToString(id);
            if(Session[pid] == null)
            {
                _ProductService.SetTotal_Viewed(id);//incraease total viewed
                Session[pid] = Convert.ToString(id);
            }


            DetailViewModel d = new DetailViewModel();
            if(Session["userId"] != null)
            {
                d.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            d.DetailProduct = _ProductService.GetById(id);
            d.Like = _LikeService.countlike(id);
            d.DisLike = _DislikeService.countdislike(id);
            d.Reviews = _ProductReviewService.GetByProductId(id);



            d.RelatedProducts = _ProductService.GetByCategory(d.DetailProduct.Category, d.DetailProduct.SubCategory);

            return View(d);
        }

        public ActionResult InsertReview(string review)
        {
            ProductReview p = new ProductReview();
            p.MemberId = Convert.ToInt32(Session["userId"]);
            p.ProductId = Convert.ToInt32(Session["ProductId"]);
            p.Review = review;
            p.Date = DateTime.Now;
            _ProductReviewService.Insert(p);
            return RedirectToAction("details", new { id = p.ProductId });
        }

        public ActionResult AddToCart(int qty, int id)
        {

            string a = "insert";
            int updateId = 0;
            foreach(var i in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))
            {
                if(i.ProductId == id)
                {
                    a = "update";
                    updateId = i.CartId;
                    break;
                }
            }


            Cart c = new Cart();
            c.MemberId = Convert.ToInt32(Session["userId"]);
            c.ProductId = id;
            c.ProductName = _ProductService.GetById(id).ProductName;
            c.UnitPrice = _ProductService.GetById(id).SellingPrice;

            if(a == "update")
            {
                c.Quantity = qty + _CartService.GetById(updateId).Quantity;
                c.UnitPrice = _ProductService.GetById(id).SellingPrice;
                _CartService.Update(c);
            }
            else
            {
                c.Quantity = qty;
                c.UnitPrice = _ProductService.GetById(id).SellingPrice;
                _CartService.Insert(c);
            }
            return RedirectToAction("shoppingCart");

        }

        public ActionResult shoppingCart()//product id
        {
            // ViewBag.detailId = id;

            shoppingCartViewModel m = new shoppingCartViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.GetCartByMemberId = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"]));
            m.GetAllCoupon = _CouponService.GetByMemberId(Convert.ToInt32(Session["userId"]));
            foreach(var item in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice * item.Quantity);
            }

            m.grandTotal = m.totalCost + 50;

            return View(m);
        }
        public ActionResult RemoveFormCart(int id)//cartid
        {
            _CartService.Delete(id);
            return RedirectToAction("shoppingCart");


        }


        public ActionResult confirmOrder()
        {
            confirmOrderViewModel m = new confirmOrderViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;//fake 
            m.PhoneNumber = _MemberService.GetById(Convert.ToInt32(Session["userId"])).PhoneNumber;//fake 
            m.MemberAddresses = _AddressService.GetByMemberId(Convert.ToInt32(Session["userId"]));//fake


            foreach(var item in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice * item.Quantity);
            }

            m.grandTotal = m.totalCost + 50 - m.Discount;

            return View(m);
        }

        public ActionResult invoices(string ShippingAddress, string paymentMethod)
        {
            invoicesViewModel m = new invoicesViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            Invoice I = new Invoice();
            I.Date = DateTime.Now;
            I.MemberId = Convert.ToInt32(Session["userId"]);//fake
            I.Status = "0";
            I.PaymentStatus = "0";
            I.PaymentMethod = paymentMethod;
            I.ShippingAddress = ShippingAddress;


            //I = _InvoiceService.Insert(I, true);
            //m.userInvoice.InvoiceId = I.InvoiceId;
            // m.userInvoice.Date = I.Date;

            //order...

            return View(m);
        }

        [HttpGet]
        public ActionResult reports()
        {
            reportsViewModel m = new reportsViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }

            return View(m);
        }
        [HttpPost]
        public ActionResult reports(string title, string description)
        {
            reportsViewModel m = new reportsViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }

            Report r = new Report();
            r.MemeberId = Convert.ToInt32(Session["userId"]);
            r.ReportTitle = title;
            r.Description = description;
            r.Date = DateTime.Now;
            _ReportService.Insert(r);


            return RedirectToAction("Index");
        }

        public ActionResult search(string search)
        {
            searchViewModel m = new searchViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productBySearch = _ProductService.GetBySearch(search);
            return View(m);
        }

        public ActionResult trackProduct()
        {
            trackProductViewModel m = new trackProductViewModel();
            if(Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            return View(m);
        }



        public ActionResult SignUp(Member m)
        {
            m.MemberSince = DateTime.Now;
            m.LastLoggedIn = DateTime.Now;
            m.Status = "active";
            m.Type = "User";
            _MemberService.Insert(m);

            return RedirectToAction("Index", "UserHome");

        }
        [HttpPost]
        public string Login(string email, string password)
        {
            if(_LoginService.isValidMember(email))
            {
                if(_LoginService.isActive(email))
                {
                    string s = _LoginService.Login(email, password);
                    if(s != "Invalid Password")
                    {
                        Session["userId"] = Convert.ToString(_MemberService.GetByEmail(email).FirstOrDefault().MemberId);

                        //Member mem = new Member();
                        //mem.MemberId = Convert.ToInt32(Session["userId"]);
                        //mem.LastLoggedIn = DateTime.Now;

                        //_MemberService.Update(mem);

                        return s;
                    }
                    else
                    {
                        return s;
                    }
                }
                return "Block";

            }

            return "Invalid";

        }



        public ActionResult SortByHighestPrice(IEnumerable<Product> products)
        {

            return View("search");
        }
        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("Index");
        }


    }
}
