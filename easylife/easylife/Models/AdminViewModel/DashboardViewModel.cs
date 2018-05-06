using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class DashboardViewModel: MemberView
    {
       
        public IEnumerable<Member> Members { set; get; }
        public IEnumerable<Product> Product { set; get; }
        public IEnumerable<Invoice> Invoices { set; get; }

    }
}