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

            Member m1 = new Member();
            m1.Email = "rajesh@gmail.com";
            m1.Password="123";
            m1.Name = "Rajesh saha";
            m1.Gender = "Male";
            m1.PhoneNumber = "01711111111";
            m1.Type = "1";
            m1.Status = "1";
            m1.MemberSince = DateTime.Now;
            m1.LastLoggedIn = DateTime.Now;
            m1.TotalPurchase = 1;
            m1.Point = 1;

            Console.WriteLine(ms.Insert(m1));


            Member m2 = new Member();
            m2.Email = "rakib@gmail.com";
            m2.Password = "123";
            m2.Name = "Rakibul Hossain";
            m2.Gender = "Male";
            m2.PhoneNumber = "01722222222";
            m2.Type = "2";
            m2.Status = "2";
            m2.MemberSince = DateTime.Now;
            m2.LastLoggedIn = DateTime.Now;
            m2.TotalPurchase = 1;
            m2.Point = 1;

            Console.WriteLine(ms.Insert(m2));



            Member m3 = new Member();
            m3.Email = "efti@gmail.com";
            m3.Password = "123";
            m3.Name = "Mashiul Azam";
            m3.Gender = "Male";
            m3.PhoneNumber = "01733333333";
            m3.Type = "3";
            m3.Status = "1";
            m3.MemberSince = DateTime.Now;
            m3.LastLoggedIn = DateTime.Now;
            m3.TotalPurchase = 1;
            m3.Point = 1;

            Console.WriteLine(ms.Insert(m3));



            Member m4 = new Member();
            m4.Email = "reza@gmail.com";
            m4.Password = "123";
            m4.Name = "Rezaul Karim";
            m4.Gender = "Male";
            m4.PhoneNumber = "01744444444";
            m4.Type = "4";
            m4.Status = "1";
            m4.MemberSince = DateTime.Now;
            m4.LastLoggedIn = DateTime.Now;
            m4.TotalPurchase = 1;
            m4.Point = 1;

            Console.WriteLine(ms.Insert(m4));

             Member m5 = new Member();
            m5.Email = "robi@gmail.com";
            m5.Password = "123";
            m5.Name = "Robi Ullah";
            m5.Gender = "Male";
            m5.PhoneNumber = "01811111111";
            m5.Type = "0";
            m5.Status = "1";
            m5.MemberSince = DateTime.Now;
            m5.LastLoggedIn = DateTime.Now;
            m5.TotalPurchase = 1;
            m5.Point = 1;

            Console.WriteLine(ms.Insert(m5));


            Member m6 = new Member();
            m6.Email = "tanim@gmail.com";
            m6.Password = "123";
            m6.Name = "Ibrahim Khalil";
            m6.Gender = "Male";
            m6.PhoneNumber = "01822222222";
            m6.Type = "0";
            m6.Status = "1";
            m6.MemberSince = DateTime.Now;
            m6.LastLoggedIn = DateTime.Now;
            m6.TotalPurchase = 1;
            m6.Point = 1;

            Console.WriteLine(ms.Insert(m6));

            Member m7 = new Member();
            m7.Email = "toma@gmail.com";
            m7.Password = "123";
            m7.Name = "Toma Azam";
            m7.Gender = "Female";
            m7.PhoneNumber = "01833333333";
            m7.Type = "0";
            m7.Status = "0";
            m7.MemberSince = DateTime.Now;
            m7.LastLoggedIn = DateTime.Now;
            m7.TotalPurchase = 1;
            m7.Point = 1;

            Console.WriteLine(ms.Insert(m7));

            Member m8 = new Member();
            m8.Email = "mizbah@gmail.com";
            m8.Password = "123";
            m8.Name = "Mizbah Ahmed";
            m8.Gender = "Male";
            m8.PhoneNumber = "01844444444";
            m8.Type = "0";
            m8.Status = "0";
            m8.MemberSince = DateTime.Now;
            m8.LastLoggedIn = DateTime.Now;
            m8.TotalPurchase = 1;
            m8.Point = 1;

            Console.WriteLine(ms.Insert(m8));



            Member m9 = new Member();
            m9.Email = "tushar@gmail.com";
            m9.Password = "123";
            m9.Name = "Saiful Islam";
            m9.Gender = "Male";
            m9.PhoneNumber = "01755555555";
            m9.Type = "2";
            m9.Status = "1";
            m9.MemberSince = DateTime.Now;
            m9.LastLoggedIn = DateTime.Now;
            m9.TotalPurchase = 1;
            m9.Point = 1;

            Console.WriteLine(ms.Insert(m8));



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

            AddressService ads = new AddressService(e);
           
            Address a1 = new Address();

            a1.MemberId = 5;
            a1.MemberAddress = "Khilkhet,Dhaka";
			Console.WriteLine(ads.Insert(a1));

            Address a2 = new Address();
            a2.MemberId = 5;
            a2.MemberAddress = "Khilgaon,Dhaka";
            Console.WriteLine(ads.Insert(a2));


			Address a3 = new Address();
			a3.MemberId = 5;
            a3.MemberAddress = "Mirpur,Dhaka";
			Console.WriteLine(ads.Insert(a3));




            //Cart--------------------
            CartService cs = new CartService(e);

            Cart c1 = new Cart();
            c1.MemberId = 5;
            c1.ProductId = 1;
            c1.ProductName = "Kakashi T Shirt";
            c1.Quantity = 1;
            c1.UnitPrice = 450;
			Console.WriteLine(cs.Insert(c1));


            Cart c2 = new Cart();
            c2.MemberId = 5;
            c2.ProductId = 2;
            c2.ProductName = "Naruto T Shirt";
            c2.Quantity = 1;
            c2.UnitPrice = 450;
            Console.WriteLine(cs.Insert(c2));


            Cart c3 = new Cart();
            c3.MemberId = 6;
            c3.ProductId = 3;
            c3.ProductName = "Avenger T Shirt";
            c3.Quantity = 1;
            c3.UnitPrice = 450;
            Console.WriteLine(cs.Insert(c3));



            //Coupon--------------------

            CouponService cus = new CouponService(e);

            Coupon cu1 = new Coupon();
            cu1.MemberId = 5;
            cu1.Percentage = 20;
            cu1.Availability = "1";
            cu1.IssueDate = DateTime.Now;
            cu1.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu1));


            Coupon cu2 = new Coupon();
            cu2.MemberId = 5;
            cu2.Percentage = 20;
            cu2.Availability = "0";
            cu2.IssueDate = DateTime.Now;
            cu2.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu2));


            Coupon cu3 = new Coupon();
            cu3.MemberId = 5;
            cu3.Percentage = 30;
            cu3.Availability = "2";
            cu3.IssueDate = DateTime.Now;
            cu3.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu3));


            //DeliveryMan--------------------

            DeliveryManService dms = new DeliveryManService(e);

            DeliveryMan dm1 = new DeliveryMan();
            dm1.AssignedBy = 1;
            dm1.MemberId = 5;
            dm1.Availability = "1";
            dm1.Zone = "khilkhet";
            Console.WriteLine(dms.Insert(dm1));

            DeliveryMan dm2 = new DeliveryMan();
            dm2.AssignedBy = 1;
            dm2.MemberId = 6;
            dm2.Availability = "1";
            dm2.Zone = "Mirpur";
            Console.WriteLine(dms.Insert(dm2));

            





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

            Cart c=new Cart();
            CartService cs = new CartService(e);

            c.MemberId = 1;
            c.ProductId = 1;
            c.ProductName = "54";
            c.Quantity = 1;
            c.UnitPrice = 10;
            Console.WriteLine(cs.Insert(c));
        }
    }
}
