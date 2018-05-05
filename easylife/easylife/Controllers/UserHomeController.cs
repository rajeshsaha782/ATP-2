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

        public UserHomeController(IProductService ProductService, IMemberService MemberService, ILikeService LikeService, IDislikeService DislikeService, IProductReviewService ProductReviewService, ICartService CartService, ICouponService CouponService, IAddressService AddressService, IInvoiceService InvoiceService, ILoginService LoginService)
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
        }

        public ActionResult Index()
        {
            IndexViewModel m = new IndexViewModel();
            return View(m);
        }
        [HttpGet]
        public ActionResult brand(string brand)
        {
            brandViewModel m = new brandViewModel();
            m.productByBrand = _ProductService.GetByBrand(brand);
            ViewBag.brand = brand;
            return View(m);
        }

        [HttpGet]
        public ActionResult catagory(string category, string subcategory)
        {
            catagoryViewModel m = new catagoryViewModel();
            m.productByCatagory = _ProductService.GetByCategory(category, subcategory);
            return View(m);
        }

        [HttpGet]
        public ActionResult details(int id = 0)
        {
            string pid = Convert.ToString(id);
            if(Session[pid] == null)
            {
                _ProductService.SetTotal_Viewed(id);//incraease total viewed
                Session[pid] = Convert.ToString(id);
            }


            DetailViewModel d = new DetailViewModel();
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
            p.MemberId = 1;//fake 
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
            foreach(var i in _CartService.GetByMemberId(1))
            {
                if(i.ProductId == id)
                {
                    a = "update";
                    updateId = i.CartId;
                    break;
                }
            }


            Cart c = new Cart();
            c.MemberId = 1;//fake
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
            m.GetCartByMemberId = _CartService.GetByMemberId(1);
            m.GetAllCoupon = _CouponService.GetByMemberId(1);
            foreach(var item in _CartService.GetByMemberId(1))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice*item.Quantity);
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

            m.Name = _MemberService.GetById(1).Name;//fake 
            m.PhoneNumber = _MemberService.GetById(1).PhoneNumber;//fake 
            m.MemberAddresses = _AddressService.GetByMemberId(1);//fake


            foreach(var item in _CartService.GetByMemberId(1))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice*item.Quantity);
            }

            m.grandTotal = m.totalCost + 50 - m.Discount;

            return View(m);
        }

        public ActionResult invoices(string ShippingAddress, string paymentMethod)
        {
            invoicesViewModel m = new invoicesViewModel();

            Invoice I = new Invoice();
            I.Date = DateTime.Now;
            I.MemberId = 1;//fake
            I.Status = "0";
            I.PaymentStatus = "0";
            I.PaymentMethod = paymentMethod;
            I.ShippingAddress = ShippingAddress;

            _InvoiceService.Insert(I);

            //order...

            return View(m);
        }

        public ActionResult reports()
        {
            reportsViewModel m = new reportsViewModel();
            return View(m);
        }

        public ActionResult search(string search)
        {
            searchViewModel m = new searchViewModel();
            m.productBySearch = _ProductService.GetBySearch(search);
            return View(m);
        }

        public ActionResult trackProduct()
        {
            trackProductViewModel m = new trackProductViewModel();
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
        public string Login(string email,string password)
        {
            if(_LoginService.isValidMember(email))
            {
                if(_LoginService.isActive(email))
                {
                    string s=_LoginService.Login(email,password);
                    if(s != "Invalid Password")
                    {
                        Session["userId"] = s;
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


    }
}
