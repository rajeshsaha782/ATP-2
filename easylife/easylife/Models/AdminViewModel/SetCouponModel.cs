using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class SetCouponModel:MemberView
    {
        public int ID;
        public DateTime expiredDate;
        public float percentage;
        public Coupon coupon { get; set; }
    }
}