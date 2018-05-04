using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.UserDashboardViewModel
{
    public class myFavoriteViewModel:MemberInfo
    {
        public int count;
        public IEnumerable<UserFavorite> Favorites { set; get; }
        public Product[] Products = new Product[1000];
    }
}