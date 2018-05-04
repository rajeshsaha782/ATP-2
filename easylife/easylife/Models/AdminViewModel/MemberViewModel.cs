using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class MemberViewModel
    {
        public int AdminCount;
        public int UserCount;
        public IEnumerable<Member> Members { set; get; }
        
    }
}