using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class shoppingCartViewModel : MemberModel
    {
        public IEnumerable<Cart> GetCartByMemberId { get; set; }
        public IEnumerable<Coupon> GetAllCoupon { set; get; }
        public float totalCost { get; set; }
        public float grandTotal { get; set; }
    }
}