using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
using easylife.Models;


namespace easylife.Controllers
{
    public class UserHomeController : Controller
    {
        public IProductService _ProductService;

        public UserHomeController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult brand(string brand)
        {
            ViewBag.brand = brand;
            return View( _ProductService.GetByBrand(brand));
        }
        public ActionResult catagory(string category, string subcategory)
        {
            return View(_ProductService.GetByCategory(category, subcategory));
        }
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
        
        public ActionResult search()
        {
            return View();
        }
        
        public ActionResult trackProduct()
        {
            return View();
        }
        public ActionResult invoices()
        {
            return View();
        }


    }
}
