using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
   public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }
        public int MemberId { get; set; }
        public string ProductCategory { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
