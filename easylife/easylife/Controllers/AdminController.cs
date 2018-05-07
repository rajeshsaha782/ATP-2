﻿using System;
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
        public ICouponService _CouponService;

        public AdminController(IMemberService MemberService,ICouponService CouponService, IOrderService OrderService, IInvoiceService InvoiceService, IDeliveryManService DeliveryManService, IProductService ProductService)
        {
            _InvoiceService = InvoiceService;
            _MemberService = MemberService;
            _DeliveryManService = DeliveryManService;
            _ProductService = ProductService;
            _OrderService = OrderService;
            _CouponService = CouponService;
        }

        public ActionResult Dashboard()
        {
            DashboardViewModel D = new DashboardViewModel();
            int Total= _MemberService.GetAll().Count();
            int user = _MemberService.GetByType("0").Count();
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
            D.MemberId = Convert.ToInt32(Session["userId"]);

            //Session["userName"]=

            Session["userName"] = _MemberService.GetById(D.MemberId).Name;

            return View(D);
        }

        public ActionResult DeleteUser(int  MemberId)
        {
            _MemberService.Delete(MemberId);
            return RedirectToAction("View_Users");


        }

        public ActionResult DeleteDeliveryMan(int MemberId)
        {
            _MemberService.Delete(MemberId);
            return RedirectToAction("View_Delivery_man");


        }

        public ActionResult Change_Password(int id, int f=0)
        {
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                PasswordViewModel p = new PasswordViewModel();
                p.MemberId = id;
                p.Name = _MemberService.GetById(id).Name;
                // p.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                p.member = _MemberService.GetById(id);
                if (f == 1)
                {
                    p.flag = 1;
                }
                else if (f == 2)
                {
                    p.flag = 2;
                }
                else
                    p.flag = 0;

                return View(p);
            }
            else
                return RedirectToAction("Index", "Admin");


        }

        public ActionResult ChangePassword(int mid, string cpass, string npass, string rpass)
        {
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                PasswordViewModel p = new PasswordViewModel();
                p.member = _MemberService.GetById(mid);
                if (p.member.Password != cpass)
                {
                    return RedirectToAction("Change_Password", "Admin", new { id = mid, f = 1 });
                }
                else if (npass != rpass)
                {
                    return RedirectToAction("Change_Password", "Admin", new { id = mid, f = 2 });
                }
                else
                {
                    p.member.Password = npass;
                    _MemberService.Update(p.member);
                    return RedirectToAction("Dashboard", "Admin", new { id = mid });
                }
            }
            else
                return RedirectToAction("Dashboard", "Admin");




        }

       


        [HttpGet]
        public ActionResult Edit_Profile_Admin(int id=0)
        {
            return View(_MemberService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit_Profile_Admin(int id,string Name,string Gender,string CellPhone,string Type)
        {

            Member mem = _MemberService.GetById(id);
            mem.Name = Name;
            mem.Gender = Gender;
            mem.PhoneNumber = CellPhone;
            mem.Type = Type;

            if (_MemberService.Update(mem))
                return RedirectToAction("Dashboard");
            else
            {

                return View(mem);
            }
           
        }

        [HttpGet]
        public ActionResult Edit_Profile_User(int MemberId=0)
        {
            return View(_MemberService.GetById(MemberId));
        }
        [HttpPost]
        public ActionResult Edit_Profile_User(Member mem)
        {
            if (_MemberService.Update(mem))
                return RedirectToAction("Dashboard");
            else
            {

                return View(mem);
            }
        }

        
        public ActionResult View_Profile_Admin()
        {
           
            int x = Convert.ToInt32(Session["userId"]);

            return View(_MemberService.GetById(x));
        }

        [HttpGet]
        public ActionResult View_Profile_Admin(int id)
        {
            return View(_MemberService.GetById(id));
        }
        [HttpGet]
        public ActionResult View_Profile_User(int id = 0)
        {

            return View(_MemberService.GetById(id));
        }
        [HttpGet]
        public ActionResult View_Profile_Delivery_Man(int id = 0)
        {
            return View(_MemberService.GetById(id));
        }


        [HttpGet]
        public ActionResult Edit_Profile_Delivery_Man(int MemberId=0)
        {
            return View(_MemberService.GetById(MemberId));
        }



       

        //---------------------------------------------

        public ActionResult Add_Member()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Member(Member mem)
        {
            if(mem.Email!=null&&mem.Name!=null&&mem.Password!=null&&mem.Gender!=null&&mem.Type!=null&&mem.Status!=null)
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
            if(pro.ProductName!=null&&pro.SellingPrice!=0&&pro.Size!=0)
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
            }
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
            int y = _MemberService.GetByType("0").Count();
            m.AdminCount = x - y;

            return View(m);
        }

        [HttpPost]
        public ActionResult View_Members(string searching, string Searchby, string SearchbyUser)
        {
            MemberViewModel m = new MemberViewModel();

            if (Searchby == "Name")
            {
                m.Members = _MemberService.GetByName(searching);
            }
            else if (Searchby == "Email")
            {
                m.Members = _MemberService.GetByEmail(searching);
            }
            else if (Searchby == "Type")
            {
                m.Members = _MemberService.GetByType(searching);
            }
            else
            {
                m.Members = _MemberService.GetAll();
            }

            //m.Members = _MemberService.GetByName(searching);
            int count = 0;
            foreach (var item in m.Members)
            {
                if (item.Type != "0")
                {
                    count++;
                }
            }
            m.AdminCount = count;
           // m.SearchName = searching;
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

        [HttpPost]
        public ActionResult View_Delivery_Man(string searching, string Searchby)
        {
            DeliveryManViewModel D = new DeliveryManViewModel();

            if (Searchby == "Name")
            {
                D.members = _MemberService.GetByName(searching);

            }
            else if (Searchby == "Email")
            {
                D.members = _MemberService.GetByEmail(searching);
            }
            else if (Searchby == "Type")
            {
                D.members = _MemberService.GetByType(searching);
            }
            else
            {
                D.members = _MemberService.GetAll();
            }


            D.Invoices = _InvoiceService.GetAll();
            D.DeliveryMan = _DeliveryManService.GetAll();
            int Count = 0;
            foreach (var item in D.members)
            {
                if (item.Type == "2")
                {
                    Count++;
                }
            }
            D.MemberCount = Count;

            return View(D);
        }




        public ActionResult View_Products()
        {
            ProductViewModel m = new ProductViewModel();
            m.Products = _ProductService.GetAll();
            m.TotalProduct = _ProductService.GetAll().Count();

            return View(m);
        }

        [HttpPost]
        public ActionResult View_Products(string searching, string Searchby)
        {
            ProductViewModel m = new ProductViewModel();

            if (Searchby == "Product Name")
            {
                m.Products = _ProductService.GetBySearch(searching);

            }
            else if (Searchby == "Brand")
            {
                m.Products = _ProductService.GetByBrand(searching);
            }
            else
            {
                m.Products = _ProductService.GetAll();
            }

            m.TotalProduct = m.Products.Count();

            return View(m);
        }



        public ActionResult View_Users()
        {
            MemberViewModel m = new MemberViewModel();
            m.Members = _MemberService.GetAll();
            m.UserCount = _MemberService.GetByType("0").Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult View_Users(string searching, string Searchby)
        {
            MemberViewModel m = new MemberViewModel();
            if (Searchby == "Name")
            {
                m.Members = _MemberService.GetByName(searching);

            }
            else if (Searchby == "Email")
            {
                m.Members = _MemberService.GetByEmail(searching);
            }
            else if (Searchby == "Type")
            {
                m.Members = _MemberService.GetByType(searching);
            }
            else
            {
                m.Members = _MemberService.GetAll();
            }
            //m.Members = _MemberService.GetByName(searching);
            int count = _MemberService.GetByType("0").Count();

           
            m.UserCount = count;
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

        [HttpPost]
        public ActionResult View_Invoices(string searching, string Searchby)
        {
            InvoicesViewModel m = new InvoicesViewModel();
            if (Searchby == "Buyer Name")
            {
                // m.Invoice = _InvoiceService.GetByMemberId(searching);

            }
            else if (Searchby == "Address")
            {
                // m.Invoice = _InvoiceService.getByAddress(searching);
            }
            else
            {
                m.Invoices = _InvoiceService.GetAll();
            }
            m.members = _MemberService.GetAll();
            m.InvoiceCount = m.Invoices.Count();

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

        [HttpPost]
        public ActionResult View_Orders(string searching, string Searchby)
        {
            OrdersViewModel m = new OrdersViewModel();

            if (Searchby == "Invoice Code")
            {
                m.Orders = _OrderService.GetByInvoiceId(Convert.ToInt32(searching));

            }
            else if (Searchby == "Product Code")
            {
                m.Orders = _OrderService.GetByProductId(Convert.ToInt32(searching));
            }
            else
            {
                m.Orders = _OrderService.GetAll();
            }

            // m.Orders = _OrderService.GetAll();
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

        [HttpPost]
        public ActionResult View_Stock(string searching, string Searchby)
        {
            ProductViewModel p = new ProductViewModel();

            if (Searchby == "Brand")
            {
                p.Products = _ProductService.GetByBrand(searching);

            }
            else if (Searchby == "Product Name")
            {
                p.Products = _ProductService.GetBySearch(searching);
            }
            else
            {
                p.Products = _ProductService.GetAll();
            }

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


        public ActionResult View_Invoice(int id)
        {
            InvoiceAdminViewModel I = new InvoiceAdminViewModel();
            I.Invoice = _InvoiceService.GetById(id);
            I.MemberId = I.Invoice.MemberId;
            I.Name = _MemberService.GetById(I.MemberId).Name;
            I.Orders = _OrderService.GetByInvoiceId(id);
            int count = 0;
            foreach (var item in I.Orders)
            {
                I.Products[count] = _ProductService.GetById(item.ProductId);
                count++;
            }
            
            return View(I);
        }
       [HttpGet]
        public ActionResult View_Product_Details(int id=0)
        {
            ProductViewModel p = new ProductViewModel();
            p.Products = _ProductService.GetAll();
            p.products = _ProductService.GetById(id);
            p.ProductId = id;
            return View(p);
        }
      
       
        [HttpGet]
        public ActionResult Set_Coupon(int id=0)
        {
            Coupon m = new Coupon();
            m.MemberId = id;
            
            return View(m);
        }

        [HttpPost]
        public ActionResult Set_Coupon(Coupon coupon,int id)
        {
            // SetCouponModel s = new SetCouponModel();
            coupon.MemberId = id;
            coupon.Availability = "1";
            coupon.IssueDate = DateTime.Now;
            if (_CouponService.Insert(coupon))
                return RedirectToAction("View_Users");
            else
            {

                return RedirectToAction("View_Users");
            }
           
        }


        [HttpGet]
        public ActionResult Send_Mail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Send_Mail(string email,string subject,string body)
        {
            easylife.Core.Service.EmailService e = new Core.Service.EmailService();
            if(e.SendEmail(email, subject, body))
                return RedirectToAction("View_Users");
            else
                return View();
        }


        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["userName"] = null;
            return RedirectToAction("Index", "UserHome");
        }

    }
}
