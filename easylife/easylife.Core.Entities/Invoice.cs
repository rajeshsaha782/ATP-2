﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Invoice
    {
        [Key]
        public int Invoice_id { get; set; }
        public DateTime Date { get; set; }
        public int    id { get; set; }
        public string Payment_Status { get; set; }
        public string Payment_Method { get; set; }
        public string Shipping_Address { get; set; }

    }
}
