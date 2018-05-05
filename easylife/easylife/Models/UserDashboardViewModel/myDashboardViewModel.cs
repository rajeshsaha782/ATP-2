using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myDashboardViewModel:MemberInfo
    {
        public Member  member { get; set; }
        public int OderCount { get; set; }
        public int CouponCount { get; set; }
        public int ReviewCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Address { get; set; }

    }
}