﻿using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class searchViewModel:MemberModel
    {
        public IEnumerable<Product> productBySearch { get; set; }
    }
}