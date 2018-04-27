using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    class Delivery_Man
    {
        [Key]
        public int Delivery_Man_id { get; set; }
        public int Member_id { get; set; }
        public string Availability { get; set; }
        public string Zone { get; set; }
    }
}
