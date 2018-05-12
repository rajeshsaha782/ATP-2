using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class InvoiceAdminViewModel:MemberView
    {
        public string Name { get; set; }
        public int MemberId { get; set; }
        public Invoice Invoice { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Product[] Products = new Product[1000];
        public Member DeliveryMan { get; set; }
    }
}