using easylife.Core.Entities;
using easylife.Core.Service.Interfaces;
using easylife.Models;
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
        public IInvoiceService _InvoiceService;
        public IProductReviewService _ProductReviewService;

        public UserDashboardController(IProductService ProductService, IMemberService MemberService, IInvoiceService InvoiceService, IProductReviewService ProductReviewService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
            _InvoiceService = InvoiceService;
            _ProductReviewService = ProductReviewService;
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

        public ActionResult changepass(int id)
        {
            return View(_MemberService.GetById(id));
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
            
            return View(m);
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
       
        public ActionResult myReports(int id)
        {
            return View(_MemberService.GetById(id));
        }
        
  



    }
}
