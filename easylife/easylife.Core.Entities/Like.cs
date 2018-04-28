﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Like
    {
        [Key]
        public int Like_id { get; set; }
        public int Member_id { get; set; }
        public int Product_id { get; set; }
    }
}
