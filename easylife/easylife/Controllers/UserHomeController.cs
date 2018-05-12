using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using easylife.Core.Service.Interfaces;
using easylife.Models;
using easylife.Core.Entities;
using easylife.Models.UserHomeViewModel;


namespace easylife.Controllers
{
    public class UserHomeController : Controller
    {
        public IProductService _ProductService;
        public IMemberService _MemberService;
        public ILikeService _LikeService;
        public IDislikeService _DislikeService;
        public IProductReviewService _ProductReviewService;
        public ICartService _CartService;
        public ICouponService _CouponService;
        public IAddressService _AddressService;
        public IInvoiceService _InvoiceService;
        public ILoginService _LoginService;
        public IReportService _ReportService;
        public IUserFavoriteService _UserFavoriteService;
        public IOrderService _OrderService;

        public UserHomeController(IProductService ProductService, IMemberService MemberService, ILikeService LikeService, IDislikeService DislikeService, IProductReviewService ProductReviewService, ICartService CartService, ICouponService CouponService, IAddressService AddressService, IInvoiceService InvoiceService, ILoginService LoginService, IReportService ReportService, IUserFavoriteService UserFavoriteService,IOrderService OrderService)
        {
            _ProductService = ProductService;
            _MemberService = MemberService;
            _LikeService = LikeService;
            _DislikeService = DislikeService;
            _ProductReviewService = ProductReviewService;
            _CartService = CartService;
            _CouponService = CouponService;
            _AddressService = AddressService;
            _InvoiceService = InvoiceService;
            _LoginService = LoginService;
            _ReportService = ReportService;
            _UserFavoriteService = UserFavoriteService;
            _OrderService = OrderService;

        }

        public ActionResult Index()
        {

            IndexViewModel m = new IndexViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }


            return View(m);
        }
        [HttpGet]
        public ActionResult brand(string brand)
        {
            brandViewModel m = new brandViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productByBrand = _ProductService.GetByBrand(brand);
            ViewBag.brand = brand;
            return View(m);
        }

        [HttpGet]
        public ActionResult catagory(string category, string subcategory)
        {
            catagoryViewModel m = new catagoryViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productByCatagory = _ProductService.GetByCategory(category, subcategory);
            return View(m);
        }


        public ActionResult details(int id)
        {
            Session["productId"] = id;
            string pid = Convert.ToString(id);
            if (Session[pid] == null)
            {
                _ProductService.SetTotal_Viewed(id);//incraease total viewed
                Session[pid] = Convert.ToString(id);
            }


            DetailViewModel d = new DetailViewModel();
            if (Session["userId"] != null)
            {
                d.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                d.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            d.DetailProduct = _ProductService.GetById(id);
            d.Like = _LikeService.countlike(id);
            d.DisLike = _DislikeService.countdislike(id);
            d.Reviews = _ProductReviewService.GetByProductId(id);

            int c = 0;
            foreach (var i in d.Reviews)
            {
                d.ReviewdMembers[c] = _MemberService.GetById(i.MemberId);
                c++;
            }

            d.RelatedProducts = _ProductService.GetByCategory(d.DetailProduct.Category, d.DetailProduct.SubCategory);
            d.NewArrivalProducts = _ProductService.NewProducts();
            d.isFavorite = _UserFavoriteService.isFavorite(id, Convert.ToInt32(Session["userId"]));
            d.isLike = _LikeService.isLiked(id, Convert.ToInt32(Session["userId"]));
            d.isDislike = _DislikeService.isDisLiked(id, Convert.ToInt32(Session["userId"]));

            return View(d);
        }

        public ActionResult InsertReview(string review)
        {
            ProductReview p = new ProductReview();
            p.MemberId = Convert.ToInt32(Session["userId"]);
            p.ProductId = Convert.ToInt32(Session["ProductId"]);
            p.Review = review;
            p.Date = DateTime.Now;
            _ProductReviewService.Insert(p);
            _MemberService.SetPoint(Convert.ToInt32(Session["userId"]), 100);
            return RedirectToAction("details", new { id = p.ProductId });
        }

        public ActionResult addToFavourite(int id)//product id
        {
            UserFavorite f = new UserFavorite();
            f.ProductId = id;
            f.MemeberId = Convert.ToInt32(Session["userId"]);
            f.Date = DateTime.Now;

            _UserFavoriteService.Insert(f);

            return RedirectToAction("details", new { id = id });
        }
        public ActionResult removeFromFavourite(int id)//product id
        {
            _UserFavoriteService.Delete(id, Convert.ToInt32(Session["userId"]));
            return RedirectToAction("details", new { id = id });
        }
        public ActionResult likeIt(int id)
        {
            Like l = new Like();

            l.MemberId = Convert.ToInt32(Session["userId"]);
            l.ProductId = id;

            _LikeService.Insert(l);
            _DislikeService.UnsetDisike(Convert.ToInt32(Session["userId"]), id);
            _MemberService.SetPoint(Convert.ToInt32(Session["userId"]), 100);
            SetStar(id);

            return RedirectToAction("details", new { id = id });
        }
        public ActionResult removeFromlike(int id)
        {
            _LikeService.UnsetLike(Convert.ToInt32(Session["userId"]), id);
            _MemberService.SetPoint(Convert.ToInt32(Session["userId"]), -100);
            SetStar(id);

            return RedirectToAction("details", new { id = id });
        }

        public ActionResult dislikeIt(int id)
        {
            Dislike l = new Dislike();

            l.MemberId = Convert.ToInt32(Session["userId"]);
            l.ProductId = id;

            _DislikeService.Insert(l);
            _LikeService.UnsetLike(Convert.ToInt32(Session["userId"]), id);
            _MemberService.SetPoint(Convert.ToInt32(Session["userId"]), 100);
            SetStar(id);

            return RedirectToAction("details", new { id = id });
        }
        public ActionResult removeFromdislike(int id)
        {
            _DislikeService.UnsetDisike(Convert.ToInt32(Session["userId"]), id);
            _MemberService.SetPoint(Convert.ToInt32(Session["userId"]), -100);
            SetStar(id);

            return RedirectToAction("details", new { id = id });
        }

        public void SetStar(int id)//product id
        {
            //Star= (Like*5)/(like+dislike)
            Product p = new Product();
            int totalLike, totalDislike;

            p = _ProductService.GetById(id);
            totalLike = _LikeService.countlike(id);
            totalDislike = _DislikeService.countdislike(id);

            if(totalLike + totalDislike == 0)
            {
                p.Star = (totalLike * 5) / (1);
            }
            else
            {
                p.Star = (totalLike * 5) / (totalLike + totalDislike);
            }
            

            _ProductService.Update(p);

        }

        public ActionResult AddToCart(int qty, int id)
        {

            string a = "insert";
            int updateId = 0;
            foreach (var i in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))
            {
                if (i.ProductId == id)
                {
                    a = "update";
                    updateId = i.CartId;
                    break;
                }
            }




            if (a == "update")
            {
                Cart UpdateCart = _CartService.GetById(updateId);

                UpdateCart.Quantity = qty + UpdateCart.Quantity;

                _CartService.Update(UpdateCart);
            }
            else
            {
                Cart c = new Cart();
                c.MemberId = Convert.ToInt32(Session["userId"]);
                c.ProductId = id;
                c.ProductName = _ProductService.GetById(id).ProductName;
                c.UnitPrice = _ProductService.GetById(id).SellingPrice;
                c.Quantity = qty;
                c.UnitPrice = _ProductService.GetById(id).SellingPrice;
                _CartService.Insert(c);
            }
            return RedirectToAction("shoppingCart");

        }
        [HttpPost]
        public int UpdateCart(int qty, int id)
        {
            Cart UpdateCart = _CartService.GetById(id);

            UpdateCart.Quantity = qty;

            _CartService.Update(UpdateCart);

            return id;
        }
        public ActionResult shoppingCart()//product id
        {
            // ViewBag.detailId = id;

            shoppingCartViewModel m = new shoppingCartViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.GetCartByMemberId = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"]));
            m.GetAllCoupon = _CouponService.GetByMemberId(Convert.ToInt32(Session["userId"]));
            foreach (var item in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice * item.Quantity);
            }

            m.grandTotal = m.totalCost + 50;

            return View(m);
        }
        public ActionResult RemoveFormCart(int id)//cartid
        {
            _CartService.Delete(id);
            return RedirectToAction("shoppingCart");


        }

        public int setCoupon(int id)
        {
            return id;
        }

        public ActionResult confirmOrder()
        {
            confirmOrderViewModel m = new confirmOrderViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;//fake 
            m.PhoneNumber = _MemberService.GetById(Convert.ToInt32(Session["userId"])).PhoneNumber;//fake 
            m.MemberAddresses = _AddressService.GetByMemberId(Convert.ToInt32(Session["userId"]));//fake


            foreach (var item in _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])))//fake
            {
                m.totalCost = m.totalCost + (item.UnitPrice * item.Quantity);
            }

            m.grandTotal = m.totalCost + 50 - m.Discount;

            return View(m);
        }

        public ActionResult invoices(string ShippingAddress, string paymentMethod)
        {
            invoicesViewModel m = new invoicesViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
                m.ShippingAddress = ShippingAddress;
            }
            Invoice I = new Invoice();
            I.Date = DateTime.Now;
            I.MemberId = Convert.ToInt32(Session["userId"]);//fake
            I.Status = "0";
            I.PaymentStatus = "0";
            I.PaymentMethod = paymentMethod;
            I.ShippingAddress = ShippingAddress;


            _InvoiceService.Insert(I);

            m.userInvoice = _InvoiceService.GetByMemberId(Convert.ToInt32(Session["userId"])).Last();

            int count = 0;
            Order order = new Order();
            IEnumerable<Cart> carts = _CartService.GetByMemberId(I.MemberId);
            foreach (var item in carts)
            {
                order = new Order();
                order.ProductId = item.ProductId;
                order.MemeberId = Convert.ToInt32(Session["userId"]);
                order.InvoiceId = m.userInvoice.InvoiceId;
                order.Quantity = item.Quantity;
                order.Profit = 0;
                order.SellingDate = DateTime.Now;
                _OrderService.Insert(order);
                //_CartService.Delete(item.CartId);
            }

            m.Orders = _OrderService.GetByInvoiceId(m.userInvoice.InvoiceId);

            foreach (var item in m.Orders)
            {
                m.Products[count] = _ProductService.GetById(item.ProductId);
                count++;
            }

            _CartService.DeleteByMemberId(Convert.ToInt32(Session["userId"]));




            return View(m);
        }

        [HttpGet]
        public ActionResult reports()
        {
            reportsViewModel m = new reportsViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }

            return View(m);
        }
        [HttpPost]
        public ActionResult reports(string title, string description)
        {
            reportsViewModel m = new reportsViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }

            Report r = new Report();
            r.MemeberId = Convert.ToInt32(Session["userId"]);
            r.ReportTitle = title;
            r.Description = description;
            r.Date = DateTime.Now;
            _ReportService.Insert(r);


            return RedirectToAction("Index");
        }

        public ActionResult search(string search)
        {
            searchViewModel m = new searchViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            m.productBySearch = _ProductService.GetBySearch(search);
            return View(m);
        }

        public ActionResult PriceRange(int max)
        {
            searchViewModel m = new searchViewModel();
            m.productBySearch = _ProductService.GetByLessThanSellPrice(max);
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            Session["max"] = max;
            return View(m);
        }

        [HttpGet]
        public ActionResult trackProduct()
        {
            trackProductViewModel m = new trackProductViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.Email = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Email;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }
            return View(m);
        }
        [HttpPost]
        public String trackProduct(int id)//invoice id
        {
            trackProductViewModel m = new trackProductViewModel();
            if (Session["userId"] != null)
            {
                m.Name = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Name;
                m.Email = _MemberService.GetById(Convert.ToInt32(Session["userId"])).Email;
                m.totalProductInCart = _CartService.GetByMemberId(Convert.ToInt32(Session["userId"])).Count();
            }

            string Status, Payment, msg;

            

            if(Session["userId"] == null)
            {
                return "Not_logged";
            }
            else if (_InvoiceService.GetById(id).MemberId != Convert.ToInt32(Session["userId"]))
            {
                return "Invaild Invoice number.Enter for a valid Invoice";
            }
            



            Status = _InvoiceService.GetById(id).Status;
            Payment = _InvoiceService.GetById(id).PaymentStatus;

            if (Status == "0")
            {
                msg = "Your Order is in On the way.";
            }
            else if (Status == "1")
            {
                msg = "Your Order is Delivered.";
            }
            else
            {
                msg = "Your Order is Canceled .";
            }

            if (Payment == "1")
            {
                msg = msg + " Payment : Paid";
            }
            else if (Payment == "0")
            {
                msg = msg + " Payment : Not Paid yet";
            }


            return msg + "Thank you.";
        }


        [HttpPost]
        public string SignUp(Member m)
        {

            if(!_LoginService.isValidMember(m.Email))
            {
                m.MemberSince = DateTime.Now;
                m.LastLoggedIn = DateTime.Now;
                m.Status = "1";
                m.Type = "0";

                _MemberService.Insert(m);

                return "done";
            }
            return "Email already used";
           

            //Address address = new Address();
            //address.MemberId = _MemberService.GetAll().Last().MemberId;
            //address.MemberAddress = "No Address";
            //_AddressService.Insert(address);


            

        }
        [HttpPost]
        public string Login(string email, string password)
        {
            if (_LoginService.isValidMember(email))
            {
                if (_LoginService.isActive(email))
                {
                    string s = _LoginService.Login(email, password);
                    if (s != "Invalid Password")
                    {
                        Session["userId"] = Convert.ToString(_MemberService.GetByEmail(email).FirstOrDefault().MemberId);

                        Member mem = _MemberService.GetById(Convert.ToInt32(Session["userId"]));
                        mem.LastLoggedIn = DateTime.Now;

                        _MemberService.Update(mem);

                        return s;
                    }
                    else
                    {
                        return s;
                    }
                }
                return "Block";

            }

            return "Invalid";

        }



        public ActionResult SortByHighestPrice(IEnumerable<Product> products)
        {

            return View("search");
        }
        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("Index");
        }


    }
}
