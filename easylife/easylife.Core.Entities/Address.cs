using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int MemberId { get; set; }
        public string MemberAddress { get; set; }
    }
}
