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
        public int TotalReportCount;


        public IEnumerable<Report> Reports { set; get; }
        public Member[] members = new Member[1000];
        public Report report { get; set; }
        public string name { get; set; }
    }
}