using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class InvoicesViewModel:ProductModel
    {
        public int InvoiceCount;
       

        public IEnumerable<Invoice> Invoices { set; get; }
        public IEnumerable<Member> members { set; get; }

    }
}