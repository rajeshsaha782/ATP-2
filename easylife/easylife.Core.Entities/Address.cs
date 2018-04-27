using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace easylife.Core.Entities
{
    public class Address
    {
        [Key]
        public int Address_id { get; set; }
        public int Member_id { get; set; }
        public string Addess { get; set; }
    }
}
