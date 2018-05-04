using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
using easylife.Models;
using easylife.Core.Entities;
using easylife.Models.AdminViewModel;
using System.Data.Entity;

namespace easylife.Controllers
{
    public class AdminController : Controller
    {
        public IMemberService _MemberService;
        public IInvoiceService _InvoiceService;
        public IDeliveryManService _DeliveryManService;
        public IProductService _ProductService;
        public IOrderService _OrderService;

        public AdminController(IMemberService MemberService, IOrderService OrderService, IInvoiceService InvoiceService, IDeliveryManService DeliveryManService, IProductService ProductService)
        {
            _InvoiceService = InvoiceService;
            _MemberService = MemberService;
            _DeliveryManService = DeliveryManService;
            _ProductService = ProductService;
            _OrderService = OrderService;
        }

        public ActionResult Dashboard()
        {
            DashboardViewModel D = new DashboardViewModel();
            int Total= _MemberService.GetAll().Count();
            int user = _MemberService.GetByType("User").Count();
            int count = 0;
            foreach(var item in _InvoiceService.GetAll())
            {
                if(item.PaymentStatus=="Done")
                {
                    count++;
                }
            }

            D.TotalAdmin = Total - user;
            D.TotalUser = user;
            D.TotalProducts = _ProductService.GetAll().Count();
            D.TotalPending = count;
                
            D.Members = _MemberService.GetAll();
            D.Product = _ProductService.GetAll();
            D.Invoices = _InvoiceService.GetAll();
            return View(D);
        }
        public ActionResult Edit_Profile_Admin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult View_Profile_Admin(int id = 0)
        {
            return View(_MemberService.GetById(id));
        }
        [HttpGet]
        public ActionResult View_Profile_User(int id = 0)
        {

            return View(_MemberService.GetById(id));
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
        [HttpPost]
        public ActionResult Add_Member(Member mem)
        {
            mem.LastLoggedIn = DateTime.Now;
            mem.MemberSince = DateTime.Now;
            mem.TotalPurchase = 0;
            mem.Point = 0;
            if (_MemberService.Insert(mem))
                return RedirectToAction("Dashboard");
            else
            {
               
                return View(mem);
            }
        }
        public ActionResult Add_Product()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Product(Product pro)
        {
            pro.TotalViewed = 0;
            pro.TotalSell = 0;
            pro.Star = 0;
            pro.Date = DateTime.Now;
            pro.BuyingPrice = 2;
            pro.LastSold = DateTime.Now;

            if (_ProductService.Insert(pro))
                return RedirectToAction("Dashboard");
            else
            {

                return View(pro);
            }
            //return View();
        }
        //---------------------------------------------

        public ActionResult View_Members()
        {
            MemberViewModel m = new MemberViewModel();
            m.Members = _MemberService.GetAll();
            int x= _MemberService.GetAll().Count();
            int y = _MemberService.GetByType("User").Count();
            m.AdminCount = x - y;

            return View(m);
        }
        public ActionResult View_Delivery_Man()
        {
            DeliveryManViewModel D = new DeliveryManViewModel();
            D.members = _MemberService.GetAll();
            D.Invoices = _InvoiceService.GetAll();
            D.DeliveryMan = _DeliveryManService.GetAll();
            D.MemberCount = _DeliveryManService.GetAll().Count();

            return View(D);
        }
       
        public ActionResult View_Products()
        {
            ProductViewModel m = new ProductViewModel();
            m.Products = _ProductService.GetAll();
            m.TotalProduct = _ProductService.GetAll().Count();

            return View(m);
        }
        public ActionResult View_Users()
        {
            MemberViewModel m = new MemberViewModel();
            m.Members = _MemberService.GetAll();
            m.UserCount = _MemberService.GetByType("User").Count();
            return View(m);
        }
        public ActionResult View_Invoices()
        {
            InvoicesViewModel m = new InvoicesViewModel();
            m.Invoices = _InvoiceService.GetAll();
            m.members = _MemberService.GetAll();
            m.InvoiceCount = _InvoiceService.GetAll().Count();

            return View(m);
        }
        public ActionResult View_Orders()
        {
            OrdersViewModel m = new OrdersViewModel();
            m.Orders = _OrderService.GetAll();
            m.Invoices = _InvoiceService.GetAll();
            m.Products = _ProductService.GetAll();
            m.TotalOrder = _OrderService.GetAll().Count();
            return View(m);
        }
        public ActionResult View_Stock()
        {
            ProductViewModel p = new ProductViewModel();
            p.Products = _ProductService.GetAll();

            return View(p);
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
        public ActionResult View_Profile_Delivery_Man(int id = 0)
        {
            return View(_MemberService.GetById(id));
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
