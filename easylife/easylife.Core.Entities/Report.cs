using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Report
    {
        [Key]
        public int Report_id { get; set; }
        public string Report_Title { get; set; }
        public int    Memeber_id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Seen_Status { get; set; }
    }
}
