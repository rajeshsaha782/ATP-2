using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Product
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public string Features { get; set; }
        public float Quantity { get; set; }
        public float Buying_Price { get; set; }
        public float Selling_Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
       
    }
}
