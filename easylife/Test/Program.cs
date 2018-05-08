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
            easylifeDatabaseCodefirst db = new easylifeDatabaseCodefirst();
            db.CreateDB();
            

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

           /* Cart c=new Cart();
            CartService cs = new CartService(e);

            c.MemberId = 1;
            c.ProductId = 1;
            c.ProductName = "54";
            c.Quantity = 1;
            c.UnitPrice = 10;
            Console.WriteLine(cs.Insert(c));*/
        }
    }
}
