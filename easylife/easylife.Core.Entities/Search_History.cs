using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
   public class Search_History
    {
        [Key]
        public int Search_id { get; set; }
        public int Member_id { get; set; }
        public string Product_Category { get; set; }
        public int Product_id { get; set; }
        public DateTime Date { get; set; }
    }
}
