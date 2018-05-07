using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using easylife.Core.Entities;

namespace easylife.Models.UserHomeViewModel
{
    public class DetailViewModel : MemberModel
    {
        public Product DetailProduct { get; set; }
        public int Like { set; get; }
        public int DisLike { set; get; }
        public IEnumerable<ProductReview> Reviews { set; get; }
        public Member[] ReviewdMembers = new Member[1000];

        public IEnumerable<Product> RelatedProducts { set; get; }
        public IEnumerable<Product> NewArrivalProducts { set; get; }

        public bool isFavorite { get; set; }
        public bool isLike { get; set; }
        public bool isDislike { get; set; }
    }
}