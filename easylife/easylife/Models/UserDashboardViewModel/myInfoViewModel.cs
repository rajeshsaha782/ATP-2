using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myInfoViewModel:MemberInfo
    {
        public Member member { get; set; }
    }
}