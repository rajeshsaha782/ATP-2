using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easylife.Infrastructure;
using easylife.Core.Entities;
using easylife.Core.Service;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ///---------email Test

            //SendEmail email = new SendEmail();

            //if(email.Email("rajeshsaha782@gmail.com", "test", "<h1>Success</h1>"))
            //{
            //    Console.WriteLine("Send");
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}


            ///----------EF Test
            easylifeDbContext e = new easylifeDbContext();
            MemberService ms = new MemberService(e);

            Member m = new Member();
            m.Email = "r@gmail.com";
            m.Name = "rajesh";
            m.MemberSince = DateTime.Now;
            m.LastLoggedIn = DateTime.Now;
            Console.WriteLine(ms.Insert(m));

            //Console.WriteLine(ms.GetById(1).MemeberId);
            //Console.WriteLine(ms.GetById(1).Name);
            //Console.WriteLine(ms.GetById(1).Email);


            //Member m1 = new Member();
            //m1.MemberId = 1;
            //m1.Email = "e@gmail.com";
            //m1.Name = "efti1";
            //m1.MemberSince = DateTime.Now;
            //m1.LastLoggedIn = DateTime.Now;
            //Console.WriteLine(ms.Update(m1));

            //Console.WriteLine(ms.GetById(1).MemberId);
            //Console.WriteLine(ms.GetById(1).Name);
            //Console.WriteLine(ms.GetById(1).Email);

            //easylifeDbContext e = new easylifeDbContext();
          
            //Address a = new Address();
            //a.Member_id = 1;
            //a.Member_Address = "Mirpur";

            // AddressService a1 = new AddressService(e);
            // Console.WriteLine(a1.Insert(a));

            ////Member--------------------

            //Member m = new Member();
            //m.Email = "r@gmail.com";
            //m.MemeberSince = DateTime.Now;
            //m.LastLoggedIn = DateTime.Now;

            //MemberService ms = new MemberService(e);
            //Console.WriteLine(ms.Insert(m));

            //Product--------------------

            Product p = new Product();
            p.ProductName = "54";
            p.Quantity = 10;
            p.BuyingPrice = 100;
            p.SellingPrice = 101;
            p.Category = "Mens Wear";
            p.SubCategory = "Shirt";
            p.Brand = "easy";
            p.Date = DateTime.Now;
            p.LastSold = DateTime.Now;

            ProductService ps = new ProductService(e);
            Console.WriteLine(ps.Insert(p));

            //Address--------------------
            Address a = new Address();
            a.MemberId = 1;
            a.MemberAddress = "Khilkhet,Dhaka";


            AddressService ads = new AddressService(e);
            Console.WriteLine(ads.Insert(a));



            //Cart--------------------

            Cart c = new Cart();
            c.MemberId = 1;
            c.ProductId = 1;
            c.ProductName = "Shirt";
            c.Quantity = 1;
            c.UnitPrice = 450;

            CartService cs = new CartService(e);
            Console.WriteLine(cs.Insert(c));



            //Coupon--------------------

            Coupon cu = new Coupon();
            cu.MemberId = 1;
            cu.Percentage = 20;
            cu.Availability = "1";
            cu.IssueDate = DateTime.Now;
            cu.DeadlineDate = DateTime.Now;

            CouponService cus = new CouponService(e);
            Console.WriteLine(cus.Insert(cu));


            //DeliveryMan--------------------

            DeliveryMan dm = new DeliveryMan();
            dm.AssignedBy = 1;
            dm.MemberId = 1;
            dm.Availability = "1";
            dm.Zone = "khilkhet";

            DeliveryManService dms = new DeliveryManService(e);
            Console.WriteLine(dms.Insert(dm));


            //Dislike--------------------

            Dislike d = new Dislike();
            d.MemberId = 1;
            d.ProductId = 1;

            DislikeService ds = new DislikeService(e);
            Console.WriteLine(ds.Insert(d));

            //like--------------------

            Like l = new Like();
            l.MemberId = 1;
            l.ProductId = 1;

            LikeService ls = new LikeService(e);
            Console.WriteLine(ls.Insert(l));

            //Invoice--------------------

            Invoice i = new Invoice();
            i.Date = DateTime.Now;
            i.MemberId = 1;
            i.DeliveryManId = 1;
            i.Status = "0";
            i.PaymentStatus = "0";
            i.PaymentMethod = "1";
            i.ShippingAddress = "khilkhet,dhaka";

            InvoiceService ivs = new InvoiceService(e);
            Console.WriteLine(ivs.Insert(i));

            //Order--------------------

            Order o = new Order();
            o.ProductId = 1;
            o.MemeberId = 1;
            o.InvoiceId = 1;
            o.Quantity = 10;
            o.Profit = 100;
            o.SellingDate = DateTime.Now;

            OrderService os = new OrderService(e);
            Console.WriteLine(os.Insert(o));


            //ProductReview--------------------

            ProductReview pr = new ProductReview();
            pr.MemberId = 1;
            pr.ProductId = 1;
            pr.Review = "good";
            pr.Date = DateTime.Now;


            ProductReviewService prs = new ProductReviewService(e);
            Console.WriteLine(prs.Insert(pr));

            //Report--------------------

            Report r = new Report();
            r.ReportTitle = "Faulty product";
            r.MemeberId = 1;
            r.Date = DateTime.Now;
            r.Description = "loreum ispum";
            r.SeenStatus = "2";

            ReportService rs = new ReportService(e);
            Console.WriteLine(rs.Insert(r));

            //SearchHistory--------------------

            SearchHistory sh = new SearchHistory();
            sh.MemberId = 1;
            sh.ProductCategory = "shirt";
            sh.ProductId = 1;
            sh.Date = DateTime.Now;


            SearchHistoryService shs = new SearchHistoryService(e);
            Console.WriteLine(shs.Insert(sh));

            //UserFavorite--------------------

            UserFavorite u = new UserFavorite();
            u.ProductId = 1;
            u.MemeberId = 1;
            u.Date = DateTime.Now;

            UserFavoriteService ufs = new UserFavoriteService(e);
            Console.WriteLine(ufs.Insert(u));


            ///GetAll-----------------

            //foreach(var mem in e.Members)
            //{
            //    Console.WriteLine(mem.Name);
            //}

            //ProductService ps = new ProductService(e);
            //IEnumerable<Product> products = ps.GetByCategory("Mens Wear", "Shirt");

            //foreach(var i in products)
            //{
            //    Console.WriteLine(i.ProductName);
            //}

            Cart c1 = new Cart();
            CartService cs1 = new CartService(e);

            c.MemberId = 1;
            c.ProductId = 1;
            c.ProductName = "54";
            c.Quantity = 1;
            c.UnitPrice = 10;
            Console.WriteLine(cs1.Insert(c));
        }
    }
}
