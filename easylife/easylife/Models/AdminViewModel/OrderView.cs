using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class OrderView:MemberView
    {
        public int Pending;
        public int Completed;
        public int Cancel;
        public int MemberId;

    }
}