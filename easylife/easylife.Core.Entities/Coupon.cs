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
        public int Coupon_id { get; set; }
        public int Member_id { get; set; }
        public int Percentage { get; set; }
        public string Availability { get; set; }
        public DateTime Issue_Date { get; set; }
        public DateTime Deadline_Date { get; set; }

    }
}
