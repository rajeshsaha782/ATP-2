using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
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
        public ActionResult brand()
        {
            return View();
        }
        public ActionResult catagory(string category, string subcategory)
        {
            return View(_ProductService.GetByCategory(category, subcategory));
        }
        public ActionResult details(int id=0)
        {
            return View(_ProductService.GetById(id));
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
        public ActionResult shoppingCart()
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
