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
        public int MemberId { get; set; }
        public int DeliveryManId { get; set; }
        public string Status { set; get; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }

    }
}
