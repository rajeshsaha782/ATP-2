using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myPasswordViewModel:MemberInfo
    {
        public Member member { get; set; }
        public int flag { get; set; }
    }
}