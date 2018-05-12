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
        public ICouponService _CouponService;
        public IAddressService _AddressService;
        public IReportService _ReportService;

        public AdminController(IMemberService MemberService, ICouponService CouponService, IOrderService OrderService, IInvoiceService InvoiceService, IDeliveryManService DeliveryManService, IProductService ProductService, IAddressService AddressService, IReportService ReportService)
        {
            _InvoiceService = InvoiceService;
            _MemberService = MemberService;
            _DeliveryManService = DeliveryManService;
            _ProductService = ProductService;
            _OrderService = OrderService;
            _CouponService = CouponService;
            _AddressService = AddressService;
            _ReportService = ReportService;
        }

        public ActionResult Dashboard()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            DashboardViewModel D = new DashboardViewModel();
            D.ReportCount = _ReportService.GetByUnseenStatus().Count();
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



        public ActionResult View_Reports()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ReportViewModel m = new ReportViewModel();
            m.Reports = _ReportService.GetAll();
            m.TotalReportCount = m.Reports.Count();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            int c = 0;
            foreach (var item in m.Reports)
            {
                m.members[c] = _MemberService.GetById(item.MemeberId);
                c++;
            }

            return View(m);


        }

        public ActionResult View_Report(int rid,string name)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            _ReportService.SetSeen(rid);
            ReportViewModel m = new ReportViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            m.report = _ReportService.GetById(rid);
            m.name = _MemberService.GetById(m.report.MemeberId).Name;
            return View(m);
        }

        public ActionResult Delete_Report(int rid)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            _ReportService.Delete(rid);
            return RedirectToAction("View_Reports", "Admin");
        }

        public ActionResult SetUnseenReport(int rid)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            _ReportService.SetUnseen(rid);
            return RedirectToAction("View_Reports", "Admin");
        }


        public ActionResult DeleteUser(int  MemberId)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            _MemberService.Delete(MemberId);
            return RedirectToAction("View_Users");


        }

        public ActionResult DeleteDeliveryMan(int MemberId)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            _MemberService.Delete(MemberId);
            return RedirectToAction("View_Delivery_man");


        }

        public ActionResult Change_Password(int id, int f=0)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            if (Convert.ToInt32(Session["userId"]) == id)
            {
                PasswordViewModel p = new PasswordViewModel();
                p.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            if (Convert.ToInt32(Session["userId"]) == mid)
            {
                PasswordViewModel p = new PasswordViewModel();
                p.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            MemberView m = new MemberView();
            m.member = _MemberService.GetById(id);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit_Profile_Admin(int id,string Name,string Gender,string CellPhone,string Type)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            Member mem = _MemberService.GetById(id);
            mem.Name = Name;
            mem.Gender = Gender;
            mem.PhoneNumber = CellPhone;
            mem.Type = Type;


            if (_MemberService.Update(mem))
                return RedirectToAction("Dashboard");
            else
            {
                MemberView mem1 = new MemberView();
                mem1.member = mem;
                mem1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                return View(mem1);
            }
           
        }

        [HttpGet]
        public ActionResult Edit_Profile_User(int MemberId=0)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            
            MemberView m = new MemberView();
            m.member = _MemberService.GetById(MemberId);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }
        [HttpPost]
        public ActionResult Edit_Profile_User(Member mem)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            if (_MemberService.Update(mem))
                return RedirectToAction("Dashboard");
            else
            {
                MemberView mem1 = new MemberView();
                mem1.member = mem;
                mem1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                return View(mem1);
            }
        }

        
        public ActionResult View_Profile_Admin()
        {

            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            int x = Convert.ToInt32(Session["userId"]);
            MemberView m = new MemberView();
            m.member = _MemberService.GetById(x);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpGet]
        public ActionResult View_Profile_Admin(int id)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberView m = new MemberView();
            m.member = _MemberService.GetById(id);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }
        [HttpGet]
        public ActionResult View_Profile_User(int id = 0)
        {

            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberView m = new MemberView();
            m.member = _MemberService.GetById(id);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }
        [HttpGet]
        public ActionResult View_Profile_Delivery_Man(int id = 0)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberView m = new MemberView();
            m.member = _MemberService.GetById(id);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }


        [HttpGet]
        public ActionResult Edit_Profile_Delivery_Man(int MemberId=0)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberView m = new MemberView();
            m.member = _MemberService.GetById(MemberId);
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }



       

        //---------------------------------------------

        public ActionResult Add_Member()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }
            MemberView mem1 = new MemberView();
            //mem1.member = mem;
            mem1.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(mem1);
        }
        [HttpPost]
        public ActionResult Add_Member(Member mem)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            if (mem.Email != null && mem.Name != null && mem.Password != null && mem.Gender != null && mem.Type != null && mem.Status != null)
            {
                mem.LastLoggedIn = DateTime.Now;
                mem.MemberSince = DateTime.Now;
                mem.TotalPurchase = 0;
                mem.Point = 0;
                Address address= new Address();


                if (_MemberService.Insert(mem))
                {
                    address.MemberId = _MemberService.GetAll().Last().MemberId;
                    address.MemberAddress = "No Address";
                    _AddressService.Insert(address);
                    return RedirectToAction("Dashboard");
                }
                else
                {

                    MemberView mem1 = new MemberView();
                    mem1.member = mem;
                    mem1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                    return View(mem1);
                }
            }
            else
            {

                MemberView mem1 = new MemberView();
                mem1.member = mem;
                mem1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                return View(mem1);
            }

        }
        public ActionResult Add_Product()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ProductViewModel pro1 = new ProductViewModel();
            //pro1.products = pro;
            pro1.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(pro1);
        }
        [HttpPost]
        public ActionResult Add_Product(Product pro)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            if (pro.ProductName != null && pro.SellingPrice != 0 && pro.Size != 0)
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
                    ProductViewModel pro1 = new ProductViewModel();
                    pro1.products = pro;
                    pro1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                    return View(pro1);
                }
            }
            else
            {
                ProductViewModel pro1 = new ProductViewModel();
                pro1.products = pro;
                pro1.ReportCount = _ReportService.GetByUnseenStatus().Count();
                return View(pro1);
            }

            //return View();
        }
        //---------------------------------------------

        public ActionResult View_Members()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberViewModel m = new MemberViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            m.Members = _MemberService.GetAll();
            int x= _MemberService.GetAll().Count();
            int y = _MemberService.GetByType("0").Count();
            m.AdminCount = x - y;

            return View(m);
        }

        [HttpPost]
        public ActionResult View_Members(string searching, string Searchby, string SearchbyUser)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberViewModel m = new MemberViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            DeliveryManViewModel D = new DeliveryManViewModel();
            D.members = _MemberService.GetAll();
            D.Invoices = _InvoiceService.GetAll();
            D.DeliveryMan = _DeliveryManService.GetAll();
            D.MemberCount = _DeliveryManService.GetAll().Count();
            D.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(D);
        }

        [HttpPost]
        public ActionResult View_Delivery_Man(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

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
            D.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(D);
        }




        public ActionResult View_Products()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ProductViewModel m = new ProductViewModel();
            m.Products = _ProductService.GetAll();
            m.TotalProduct = _ProductService.GetAll().Count();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult View_Products(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

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
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }



        public ActionResult View_Users()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberViewModel m = new MemberViewModel();
            m.Members = _MemberService.GetAll();
            m.UserCount = _MemberService.GetByType("0").Count();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult View_Users(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            MemberViewModel m = new MemberViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            InvoicesViewModel m = new InvoicesViewModel();
            m.Invoices = _InvoiceService.GetAll();
            m.members = _MemberService.GetAll();
            m.InvoiceCount = _InvoiceService.GetAll().Count();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult View_Invoices(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            InvoicesViewModel m = new InvoicesViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            OrdersViewModel m = new OrdersViewModel();
            m.Orders = _OrderService.GetAll();
            m.Invoices = _InvoiceService.GetAll();
            int count = 0;
            foreach (var item in m.Orders)
            {
                m.Products[count] = _ProductService.GetById(item.ProductId);
                count++;
            }

            m.TotalOrder = _OrderService.GetAll().Count();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(m);
        }

        [HttpPost]
        public ActionResult View_Orders(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            OrdersViewModel m = new OrdersViewModel();
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            int count = 0;
            foreach (var item in m.Orders)
            {
                m.Products[count] = _ProductService.GetById(item.ProductId);
                count++;
            }
            m.TotalOrder = _OrderService.GetAll().Count();
            return View(m);
        }




        public ActionResult View_Stock()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ProductViewModel p = new ProductViewModel();
            p.Products = _ProductService.GetAll();
            p.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(p);
        }

        [HttpPost]
        public ActionResult View_Stock(string searching, string Searchby)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ProductViewModel p = new ProductViewModel();
            p.ReportCount = _ReportService.GetByUnseenStatus().Count();
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            return View();
        }

        //---------------------------------------------

        public ActionResult Update_Slider()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            return View();
        }

        public ActionResult Advertise()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            return View();
        }



        //---------------------------------------------


        public ActionResult View_Invoice(int id)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            InvoiceAdminViewModel I = new InvoiceAdminViewModel();
            I.ReportCount = _ReportService.GetByUnseenStatus().Count();
            I.Invoice = _InvoiceService.GetById(id);
            I.MemberId = I.Invoice.MemberId;
            I.Name = _MemberService.GetById(I.MemberId).Name;
            I.Orders = _OrderService.GetByInvoiceId(id);
            I.DeliveryMan = _MemberService.GetById(I.Invoice.DeliveryManId);
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            ProductViewModel p = new ProductViewModel();
            p.Products = _ProductService.GetAll();
            p.products = _ProductService.GetById(id);
            p.ProductId = id;
            p.ReportCount = _ReportService.GetByUnseenStatus().Count();
            return View(p);
        }
      
       
        [HttpGet]
        public ActionResult Set_Coupon(int id=0)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }



            SetCouponModel m = new SetCouponModel();
            m.coupon.MemberId = id;
            m.ReportCount = _ReportService.GetByUnseenStatus().Count();
            
            return View(m);
        }

        [HttpPost]
        public ActionResult Set_Coupon(Coupon coupon,int id)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

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

            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Send_Mail(string email,string subject,string body)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "UserHome");
            }

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
