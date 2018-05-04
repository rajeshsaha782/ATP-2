using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class confirmOrderViewModel : MemberModel
    {

        public IEnumerable<Address> MemberAddresses { get; set; }
        public float totalCost { get; set; }
        public float Discount { get; set; }
        public float grandTotal { get; set; }
    }
}