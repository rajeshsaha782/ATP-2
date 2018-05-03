using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserHomeViewModel
{
    public class brandViewModel:MemberModel
    {
        public IEnumerable<Product> productByBrand { get; set; }
    }
}