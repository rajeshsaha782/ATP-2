using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime MemberSince { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public float  TotalPurchase { get; set; }
        public int Point { set; get; }
    }
}
