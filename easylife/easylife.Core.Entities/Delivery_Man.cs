using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
   public class DeliveryMan
    {
        [Key]
        public int Id { set; get; }
        public int AssignedBy { get; set; }
        public int MemberId { get; set; }
        public string Availability { get; set; }
        public string Zone { get; set; }
    }
}
