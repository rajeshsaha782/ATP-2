using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public int MemberId { get; set; }
        public int Percentage { get; set; }
        public string Availability { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeadlineDate { get; set; }

    }
}
