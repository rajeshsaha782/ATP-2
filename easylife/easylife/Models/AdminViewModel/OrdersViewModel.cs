using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { set; get; }
        public IEnumerable<Invoice> Invoices { set; get; }
        public IEnumerable<Product> Products { set; get; }


    }
}