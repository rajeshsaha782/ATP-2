using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class invoicesViewModel : MemberModel
    {
        public string ShippingAddress { get; set; }
        public Invoice userInvoice { get; set; }
    }
}