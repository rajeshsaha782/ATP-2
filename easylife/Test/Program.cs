﻿using System;
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

           /* easylifeDbContext e = new easylifeDbContext();
            Member m = new Member();
            m.Email = "r@gmail.com";
            m.Name = "rajesh";
            m.Memeber_Since = DateTime.Now;
            m.Last_Logged_In = DateTime.Now;
            e.Members.Add(m);
            e.SaveChanges();*/

            easylifeDbContext e = new easylifeDbContext();
          
            //Address a = new Address();
            //a.Member_id = 1;
            //a.Member_Address = "Mirpur";

            // AddressService a1 = new AddressService(e);
            // Console.WriteLine(a1.Insert(a));

            Member m = new Member();
            m.Email = "r@gmail.com";
            m.MemeberSince = DateTime.Now;
            m.LastLoggedIn = DateTime.Now;

            MemberService ms = new MemberService(e);
            Console.WriteLine(ms.Insert(m));

            ///GetAll-----------------

            //foreach(var mem in e.Members)
            //{
            //    Console.WriteLine(mem.Name);
            //}



        }
    }
}
