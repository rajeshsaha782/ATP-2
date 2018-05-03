using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models
{
    public class myReviewsViewModel:MemberInfo
    {
        public int count;
        public IEnumerable<ProductReview> Reviews { set; get; }
        public Product[] Products = new Product[1000];
    }
}