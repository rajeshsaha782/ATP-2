﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using easylife.Core.Entities;

namespace easylife.Models
{
    public class DetailViewModel
    {
        public Product DetailProduct { get; set; }
        public IEnumerable<Product> RelatedProducts { set; get; }
        public IEnumerable<Product> NewArrivalProducts { set; get; }
    }
}