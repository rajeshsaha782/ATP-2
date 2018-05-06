using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models
{
    public class MemberInfo
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int totalProductInCart { get; set; }
    }
}