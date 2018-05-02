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
            //Console.WriteLine(ms.Insert(m));

            //Console.WriteLine(ms.GetById(1).MemeberId);
            //Console.WriteLine(ms.GetById(1).Name);
            //Console.WriteLine(ms.GetById(1).Email);


            Member m1 = new Member();
            m1.MemberId = 1;
            m1.Email = "e@gmail.com";
            m1.Name = "efti";
            m1.MemberSince = DateTime.Now;
            m1.LastLoggedIn = DateTime.Now;
            Console.WriteLine(ms.Update(m1));

            Console.WriteLine(ms.GetById(1).MemberId);
            Console.WriteLine(ms.GetById(1).Name);
            Console.WriteLine(ms.GetById(1).Email);

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

          /*  Product p = new Product();
            p.ProductName = "5";
            p.Quantity = 10;
            p.BuyingPrice = 100;
            p.SellingPrice = 101;
            p.Category = "Mens Wear";
            p.SubCategory = "Shirt";
            p.Date = DateTime.Now;
            p.LastSold = DateTime.Now;

            ProductService ps = new ProductService(e);
            Console.WriteLine(ps.Insert(p));*/

            ///GetAll-----------------

            //foreach(var mem in e.Members)
            //{
            //    Console.WriteLine(mem.Name);
            //}



        }
    }
}
