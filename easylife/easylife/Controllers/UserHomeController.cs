using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
using easylife.Models;
using easylife.Core.Entities;


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
            return View();
        }
        [HttpGet]
        public ActionResult brand(string brand)
        {
            ViewBag.brand = brand;
            return View( _ProductService.GetByBrand(brand));
        }

        [HttpGet]
        public ActionResult catagory(string category, string subcategory)
        {
            return View(_ProductService.GetByCategory(category,subcategory));
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

            //var cart = new HttpCookie("cart");
            //cart.Value = Convert.ToString(id);
            //cart.Expires = DateTime.Now.AddDays(7);
            //cart.Secure = true;
            //Response.Cookies.Add(cart);
            ViewBag.detailId = id;

            HttpCookie cookie = Request.Cookies["cart"];
            Response.Write(cookie);
            return View();
        }
        public ActionResult confirmOrder()
        {
            return View();
        }
        
        public ActionResult reports()
        {
            return View();
        }

        public ActionResult search(string search)
        {
            return View(_ProductService.GetBySearch(search));
        }
        
        public ActionResult trackProduct()
        {
            return View();
        }
        public ActionResult invoices()
        {
            return View();
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
