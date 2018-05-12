using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class OrdersViewModel:ProductModel
    {
        
        public IEnumerable<Order> Orders { set; get; }
        public IEnumerable<Invoice> Invoices { set; get; }
        public Product[] Products = new Product[1000];


    }
}