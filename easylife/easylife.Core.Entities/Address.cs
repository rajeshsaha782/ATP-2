﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Address
    {
        [Key]
        public int Address_id { get; set; }
        public int Member_id { get; set; }
        public string Member_Address { get; set; }
    }
}
