using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Features { get; set; }
        public int  Quantity { get; set; }
        public float  BuyingPrice { get; set; }
        public float  SellingPrice { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public int    Size { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastSold { get; set; }
        public int  TotalSell { get; set; }
        public int    TotalViewed { get; set; }
        public float Star { get; set; }//Star= (Like*5)/(like+dislike)


    }
}
