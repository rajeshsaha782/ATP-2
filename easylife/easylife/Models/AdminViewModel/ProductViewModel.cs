using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class ProductViewModel:ProductModel
    {
        public IEnumerable<Product> Products { set; get; }
        public Product products { set; get; }
        public int ProductId;

    }
}