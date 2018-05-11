using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class ReportViewModel
    {
        public int ReportCount;


        public IEnumerable<Report> Reports { set; get; }
        public IEnumerable<Member> members { set; get; }
    }
}