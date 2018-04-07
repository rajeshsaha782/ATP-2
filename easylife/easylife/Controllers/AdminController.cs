using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace easylife.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Edit_Profile_Admin()
        {
            return View();
        }
        public ActionResult View_Profile_Admin()
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
            return View();
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
        public ActionResult View_Stocks()
        {
            return View();
        }
        public ActionResult Profit_graph()
        {
            return View();
        }

        //---------------------------------------------

        public ActionResult View_Invoice()
        {
            return View();
        }

    }
}
