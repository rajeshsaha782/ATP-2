using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;

namespace easylife.Controllers
{
    public class AdminController : Controller
    {
        public IMemberService _MemberService;

        public AdminController(IMemberService MemberService)
        {
            _MemberService = MemberService;
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Edit_Profile_Admin()
        {
            return View();
        }
        public ActionResult View_Profile_Admin(string id)
        {
            return View(_MemberService.GetByEmail(id));
        }
        public ActionResult View_Profile_User()
        {
            return View();
        }
        public ActionResult Change_Password()
        {
            return View();
        }

        //---------------------------------------------

        public ActionResult Add_Member()
        {
            return View();
        }
        public ActionResult Add_Product()
        {
            return View();
        }

        //---------------------------------------------

        public ActionResult View_Members()
        {
            return View(_MemberService.GetAll());
        }
        public ActionResult View_Delivery_Man()
        {
            return View();
        }
        public ActionResult View_Products()
        {
            return View();
        }
        public ActionResult View_Users()
        {
            return View();
        }
        public ActionResult View_Invoices()
        {
            return View();
        }
        public ActionResult View_Orders()
        {
            return View();
        }
        public ActionResult View_Stock()
        {
            return View();
        }
        public ActionResult Profit_graph()
        {
            return View();
        }

        //---------------------------------------------

        public ActionResult Update_Slider()
        {
            return View();
        }

        public ActionResult Advertise()
        {
            return View();
        }



        //---------------------------------------------


        public ActionResult View_Invoice()
        {
            return View();
        }
        public ActionResult View_Profile_Delivery_Man()
        {
            return View();
        }
        public ActionResult View_Product_Details()
        {
            return View();
        }
        public ActionResult Edit_Profile_User()
        {
            return View();
        }
        public ActionResult Edit_Profile_Delivery_Man()
        {
            return View();
        }
        public ActionResult Set_Cupon()
        {
            return View();
        }
        public ActionResult Send_Mail()
        {
            return View();
        }

    }
}
