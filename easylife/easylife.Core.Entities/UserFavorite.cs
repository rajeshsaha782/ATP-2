using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class UserFavorite
    {
        [Key]
        public int UserFavoriteId { get; set; }
        public int ProductId { get; set; }
        public int MemeberId { get; set; }
        public DateTime Date { get; set; }
    }
}
