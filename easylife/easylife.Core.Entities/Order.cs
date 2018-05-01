using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int MemeberId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Profit { get; set; }
        public DateTime SellingDate { get; set; }

    }
}
