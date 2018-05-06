using easylife.Core.Entities;
using easylife.Models.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models
{
    public class DeliveryManViewModel:MemberView
    {
        public int MemberCount;
       

        public IEnumerable<Invoice> Invoices { set; get; }
        public IEnumerable<Member> members { set; get; }
        public IEnumerable<DeliveryMan> DeliveryMan { set; get; }

    }
}