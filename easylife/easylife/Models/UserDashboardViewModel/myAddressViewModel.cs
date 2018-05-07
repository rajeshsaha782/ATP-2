using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myAddressViewModel:MemberInfo
    {
        public IEnumerable<Address> Addresses { get; set; }
        public int count { get; set; }
    }
}