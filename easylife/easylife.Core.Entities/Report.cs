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
        public int ReportId { get; set; }
        public string ReportTitle { get; set; }
        public int    MemeberId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string SeenStatus { get; set; }
    }
}
