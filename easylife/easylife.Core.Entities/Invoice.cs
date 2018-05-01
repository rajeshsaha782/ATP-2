using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public int    id { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }

    }
}
