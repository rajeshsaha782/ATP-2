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
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Features { get; set; }
        public float  Quantity { get; set; }
        public float  Buying_Price { get; set; }
        public float  Selling_Price { get; set; }
        public string Category { get; set; }
        public string Sub_Category { get; set; }
        public string Brand { get; set; }
        public int    Size { get; set; }
        public string Date { get; set; }
        public int    Last_Sold { get; set; }
        public float  Total_Sell { get; set; }
        public int    Total_Viewed { get; set; }
        public int    Like { get; set; }
        public int    Dislike { get; set; }


    }
}
