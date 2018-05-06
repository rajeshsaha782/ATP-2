using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models
{
    public class InvoiceViewModel:MemberInfo
    {
        public Invoice Invoice { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Product[] Products = new Product[1000];
    }
}