using easylife.Core.Entities;
using easylife.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace easylife.Controllers
{
    public class UserDashboardController : Controller
    {
        public IProductService _ProductService;
        public IMemberService _MemberService;

        public UserDashboardController(IProductService ProductService, IMemberService MemberService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
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
            //return RedirectToAction("Dashboard", new {id= m.MemberId});
            return View(_MemberService.GetById(m.MemberId));
        }

        public ActionResult changepass(int id)
        {
            return View(_MemberService.GetById(id));
        }
        
        public ActionResult invoices(int id)
        {
            return View(_MemberService.GetById(id));
        }
        public ActionResult manageAddress(int id)
        {
            return View(_MemberService.GetById(id));
        }
        public ActionResult myCoupon(int id)
        {
            return View(_MemberService.GetById(id));

        }
        public ActionResult myFavorite(int id)
        {
            return View(_MemberService.GetById(id));
        }
        public ActionResult myOrders(int id)
        {
            return View(_MemberService.GetById(id));
        }
        public ActionResult myReports(int id)
        {
            return View(_MemberService.GetById(id));
        }
        public ActionResult myReviews(int id)
        {
            return View(_MemberService.GetById(id));
        }
  



    }
}
