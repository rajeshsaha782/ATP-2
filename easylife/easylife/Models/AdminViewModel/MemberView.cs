using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class MemberView
    {
        public int TotalAdmin;
        public int TotalUser;
        public int TotalProducts;
        public int TotalPending;

        //public int MemberId;
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int totalProductInCart { get; set; }
        public int ReportCount { get; set; }
        public Member member { get; set; }



    }
}