﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Dislike
    {
        [Key]
        public int DislikeId { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
    }
}
