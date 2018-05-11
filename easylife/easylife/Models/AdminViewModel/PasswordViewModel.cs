using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class PasswordViewModel:MemberView
    {
        public Member member { get; set; }
        public int flag { get; set; }


    }
}