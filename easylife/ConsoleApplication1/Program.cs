using easylife.Infrastructure;
using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            easylifeDbContext e = new easylifeDbContext();
            Member m = new Member();
            m.Memeber_id = 1;
            m.Email = "rajesh@gmail.com";
            m.Name = "Rajesh";

            e.Members.Add(m);
            e.SaveChanges();
        }
    }
}
