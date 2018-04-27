using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace easylife.Core.Entities
{
    public class Order
    {
        [Key]
        public int Orderer_id { get; set; }
        public int Product_id { get; set; }
        public int Memeber_id { get; set; }
        public int Invoice_id { get; set; }
        public int Quantity { get; set; }
    }
}
