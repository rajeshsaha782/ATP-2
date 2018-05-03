using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class catagoryViewModel:MemberModel
    {
        public IEnumerable<Product> productByCatagory { get; set; }
    }
}