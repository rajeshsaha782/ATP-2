using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class UserFavorites
    {
        [Key]
        public int UserFavorites_id { get; set; }
        public int Product_id { get; set; }
        public int Memeber_id { get; set; }
        public string Date { get; set; }
    }
}
