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

        public UserHomeController(IProductService ProductService,IMemberService MemberService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
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
        public ActionResult details(int id=0)
        {
            DetailViewModel d = new DetailViewModel();
            d.DetailProduct = _ProductService.GetById(id);
            d.RelatedProducts = _ProductService.GetByCategory(d.DetailProduct.Category,d.DetailProduct.SubCategory);
            return View(d);
        }
        public ActionResult shoppingCart(int id)
        {
            shoppingCartViewModel m = new shoppingCartViewModel();
            //var cart = new HttpCookie("cart");
            //cart.Value = Convert.ToString(id);
            //cart.Expires = DateTime.Now.AddDays(7);
            //cart.Secure = true;
            //Response.Cookies.Add(cart);
            ViewBag.detailId = id;

            HttpCookie cookie = Request.Cookies["cart"];
            Response.Write(cookie);

            return View(m);
        }
        public ActionResult confirmOrder()
        {
            confirmOrderViewModel m = new confirmOrderViewModel();

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
            m.productBySearch=_ProductService.GetBySearch(search);
            return View(m);
        }
        
        public ActionResult trackProduct()
        {
            trackProductViewModel m = new trackProductViewModel();
            return View(m);
        }
        public ActionResult invoices()
        {
            invoicesViewModel m = new invoicesViewModel();
            return View(m);
        }

        
        public ActionResult SignUp(Member m)
        {
            //m.MemberSince = DateTime.Now;
            //m.LastLoggedIn = DateTime.Now;
            //m.Status = "active";
            //m.Type = "User";
            //_MemberService.Insert(m);

            return RedirectToAction("Index", "UserHome");


        }

        public ActionResult SortByHighestPrice(IEnumerable<Product> products)
        {

             return View("search");
        }


    }
}
