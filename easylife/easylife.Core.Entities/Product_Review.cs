using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class ProductReview
    {
        [Key]
        public int ReviewId { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }

    }
}
