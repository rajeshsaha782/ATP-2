using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    class Product_Review
    {
        [Key]
        public int Review_id { get; set; }
        public int Member_id { get; set; }
        public int Product_id { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }

    }
}
